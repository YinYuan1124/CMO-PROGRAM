#!/usr/bin/env python3
"""Extract scenario titles/descriptions to plain text for translation work.

Usage:
    python tools/extract_scenarios.py --set "Falklands" [--out _translation_work]

Writes one UTF-8 .txt per scenario (title + plain-text description) to:
    _translation_work/<set>/<scenario stem>.txt
"""
import argparse
import html
import re
import sys
import xml.etree.ElementTree as ET
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
SCEN_ROOT = ROOT / "Command" / "bin" / "Debug" / "Scenarios"
DOC_RE = re.compile(r"\[LOADDOC\](.*?)\[/LOADDOC\]", re.S | re.I)


def plain(value):
    value = re.sub(r"<br\s*/?>", "\n", value, flags=re.I)
    value = re.sub(r"</p>", "\n", value, flags=re.I)
    value = re.sub(r"<li[^>]*>", "- ", value, flags=re.I)
    value = re.sub(r"<[^>]+>", "", value)
    value = html.unescape(value)
    value = re.sub(r"[ \t]+", " ", value)
    value = re.sub(r"\n\s*\n+", "\n", value)
    return value.strip()


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--set", dest="group", required=True,
                    help='top-level folder, e.g. "Falklands" or "Standalone Scenarios"')
    ap.add_argument("--out", default="_translation_work")
    args = ap.parse_args()

    source = SCEN_ROOT / args.group
    if not source.is_dir():
        print("Not found:", source, file=sys.stderr)
        return 2
    out_dir = ROOT / args.out / args.group
    out_dir.mkdir(parents=True, exist_ok=True)

    count = 0
    for scenario in sorted(source.rglob("*.scen")):
        try:
            root = ET.parse(scenario).getroot()
        except Exception as exc:  # noqa: BLE001
            print("skip %s: %s" % (scenario.name, exc), file=sys.stderr)
            continue
        title = root.findtext("ScenTitle") or scenario.stem
        desc = root.findtext("ScenDescription") or ""
        match = DOC_RE.search(desc)
        if match:
            doc = scenario.parent / match.group(1).strip()
            if doc.exists():
                desc = doc.read_text(encoding="utf-8", errors="replace")
            else:
                print("missing LOADDOC %s for %s" % (match.group(1), scenario.name),
                      file=sys.stderr)
        text = "TITLE: %s\nFILE: %s\n\n%s\n" % (
            title, scenario.relative_to(SCEN_ROOT), plain(desc))
        target = out_dir / (scenario.stem + ".txt")
        target.write_text(text, encoding="utf-8")
        count += 1
    print("wrote %d files to %s" % (count, out_dir))
    return 0


if __name__ == "__main__":
    sys.exit(main())
