#!/usr/bin/env python3
"""Audit CMO scenario Chinese localization coverage.

Usage:
    python tools/audit_translations.py [--verbose] [--set NAME]

Checks:
  * every .scen has a [zh-CN] name in Command/bin/Debug/Config/ScenarioNames.ini
  * every non-empty scenario description has a <scenario>.scen.i18n.ini
    with a [zh-CN] Description key
  * every [LOADDOC] reference points to an existing file
"""
import argparse
import configparser
import os
import re
import sys
from collections import defaultdict
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
SCEN_ROOT = ROOT / "Command" / "bin" / "Debug" / "Scenarios"
CONFIG_DIR = ROOT / "Command" / "bin" / "Debug" / "Config"
NAMES_FILE = CONFIG_DIR / "ScenarioNames.ini"
SKIP_GROUPS = {"Autosaves", "Steam Workshop"}
DESC_RE = re.compile(r"<ScenDescription>(.*?)</ScenDescription>", re.S | re.I)
DOC_RE = re.compile(r"\[LOADDOC\](.*?)\[/LOADDOC\]", re.S | re.I)
TAG_RE = re.compile(r"<[^>]+>")


def load_names():
    parser = configparser.RawConfigParser(interpolation=None)
    parser.optionxform = str
    if not NAMES_FILE.exists():
        return set()
    parser.read(NAMES_FILE, encoding="utf-8-sig")
    if not parser.has_section("zh-CN"):
        return set()
    return set(parser.options("zh-CN"))


def description_text(path):
    """Return the raw description text, or '' when it has no visible content."""
    try:
        raw = path.read_text(encoding="utf-8", errors="ignore")[:2_000_000]
    except OSError:
        return ""
    match = DESC_RE.search(raw)
    if not match:
        return ""
    raw_desc = match.group(1)
    if "[LOADDOC]" in raw_desc.upper():
        return raw_desc.strip()
    visible = TAG_RE.sub("", raw_desc)
    visible = re.sub(r"&nbsp;|&#160;", " ", visible, flags=re.I)
    return visible.strip()


def sidecar_state(scenario):
    """Return (ok, note). ok is True when the zh-CN description exists and is valid."""
    sidecar = Path(str(scenario) + ".i18n.ini")
    if not sidecar.exists():
        return False, "no sidecar"
    parser = configparser.RawConfigParser(interpolation=None)
    parser.optionxform = str
    try:
        parser.read(sidecar, encoding="utf-8-sig")
    except Exception as exc:  # noqa: BLE001
        return False, "bad sidecar: %s" % exc
    if not parser.has_section("zh-CN") or not parser.has_option("zh-CN", "Description"):
        return False, "no [zh-CN] Description"
    value = parser.get("zh-CN", "Description")
    match = DOC_RE.search(value)
    if match:
        doc = os.path.join(os.path.dirname(str(scenario)), match.group(1).strip())
        if not os.path.exists(doc):
            return False, "missing doc: %s" % match.group(1)
    return True, ""


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--verbose", "-v", action="store_true")
    ap.add_argument("--set", dest="only_set", help="limit to one top-level folder")
    args = ap.parse_args()

    names = load_names()
    stats = defaultdict(lambda: {"scenarios": 0, "names": 0, "descs": 0,
                                 "missing_names": [], "missing_descs": [], "bad": []})

    for scenario in sorted(SCEN_ROOT.rglob("*.scen")):
        rel = scenario.relative_to(SCEN_ROOT)
        group = rel.parts[0] if len(rel.parts) > 1 else "(root)"
        if group in SKIP_GROUPS or group == "(root)":
            continue
        if args.only_set and group != args.only_set:
            continue
        item = stats[group]
        item["scenarios"] += 1
        stem = scenario.stem

        if stem in names:
            item["names"] += 1
        else:
            item["missing_names"].append(str(rel))

        raw_desc = description_text(scenario)
        if not raw_desc:
            item["descs"] += 1  # nothing to translate
            continue
        ok, note = sidecar_state(scenario)
        if ok:
            item["descs"] += 1
        else:
            item["missing_descs"].append(str(rel))
            if note.startswith("missing doc"):
                item["bad"].append((str(rel), note))

    header = "%-28s %9s %7s %7s %12s %12s" % (
        "Set", "Scenarios", "Names", "Descs", "MissingNames", "MissingDescs")
    print(header)
    print("-" * len(header))
    total = defaultdict(int)
    for group in sorted(stats):
        item = stats[group]
        print("%-28s %9d %7d %7d %12d %12d" % (
            group, item["scenarios"], item["names"], item["descs"],
            len(item["missing_names"]), len(item["missing_descs"])))
        for key in ("scenarios", "names", "descs"):
            total[key] += item[key]
        total["missing_names"] += len(item["missing_names"])
        total["missing_descs"] += len(item["missing_descs"])
        total["bad"] += len(item["bad"])
    print("-" * len(header))
    print("%-28s %9d %7d %7d %12d %12d" % (
        "TOTAL", total["scenarios"], total["names"], total["descs"],
        total["missing_names"], total["missing_descs"]))
    if total["bad"]:
        print("\nBroken [LOADDOC] references:")
        for group in sorted(stats):
            for rel, note in stats[group]["bad"]:
                print("  %s  (%s)" % (rel, note))

    if args.verbose:
        for group in sorted(stats):
            item = stats[group]
            if item["missing_names"]:
                print("\n[%s] missing names:" % group)
                for rel in item["missing_names"]:
                    print("  -", rel)
            if item["missing_descs"]:
                print("\n[%s] missing descriptions:" % group)
                for rel in item["missing_descs"]:
                    print("  -", rel)
    return 1 if (total["missing_names"] or total["missing_descs"] or total["bad"]) else 0


if __name__ == "__main__":
    sys.exit(main())
