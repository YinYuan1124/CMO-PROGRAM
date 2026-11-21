#!/usr/bin/env python3
"""Apply a translated batch to the game data.

Usage:
    python tools/finalize_translation_batch.py --batch _translation_work/batches/falklands-000

For every entry in batch.json:
  * take the agent's translated HTML from out_file
  * rewrite it as UTF-8 with BOM + <meta charset="utf-8"> (IE WebBrowser needs this)
  * write the .scen.i18n.ini sidecar pointing at the translated document
  * add/update the scenario title in Config/ScenarioNames.ini [zh-CN]

Missing output files or titles are reported and skipped; the script exits 1.
"""
import argparse
import json
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
NAMES_FILE = ROOT / "Command" / "bin" / "Debug" / "Config" / "ScenarioNames.ini"
META = '<meta http-equiv="Content-Type" content="text/html; charset=utf-8">'


def add_meta(text):
    text = text.lstrip("﻿")
    if re.search(r"charset\s*=", text[:3000], re.I):
        return text
    head = re.search(r"<head\b[^>]*>", text, re.I)
    if head:
        return text[: head.end()] + "\n\t" + META + text[head.end():]
    html = re.search(r"<html\b[^>]*>", text, re.I)
    if html:
        return text[: html.end()] + "\n\t<head>" + META + "</head>" + text[html.end():]
    return '<html><head>' + META + '</head><body>\n' + text + '\n</body></html>'


def read_titles(path):
    titles = {}
    if not path.exists():
        return titles
    for line in path.read_text(encoding="utf-8-sig").splitlines():
        if "\t" in line:
            slug, title = line.split("\t", 1)
        elif "=" in line:
            slug, title = line.split("=", 1)
        else:
            continue
        slug, title = slug.strip(), title.strip()
        if slug and title:
            titles[slug] = title
    return titles


def update_names(pairs):
    """Insert/replace keys in the [zh-CN] section, preserving the rest of the file."""
    text = NAMES_FILE.read_text(encoding="utf-8-sig") if NAMES_FILE.exists() else ""
    lines = text.splitlines()
    try:
        start = next(i for i, line in enumerate(lines)
                     if line.strip().lower() == "[zh-cn]")
    except StopIteration:
        lines += ["", "[zh-CN]"]
        start = len(lines) - 1
    end = len(lines)
    for i in range(start + 1, len(lines)):
        if lines[i].strip().startswith("[") and lines[i].strip().endswith("]"):
            end = i
            break

    existing = {}
    order = []
    for i in range(start + 1, end):
        line = lines[i]
        if "=" in line and not line.lstrip().startswith(";"):
            key = line.split("=", 1)[0].strip()
            existing[key] = i
            order.append(key)

    changed = 0
    for key, value in pairs.items():
        newline = "%s=%s" % (key, value)
        if key in existing:
            idx = existing[key]
            if lines[idx] != newline:
                lines[idx] = newline
                changed += 1
        else:
            insert_at = end
            lines.insert(insert_at, newline)
            for k, v in existing.items():
                if v >= insert_at:
                    existing[k] = v + 1
            existing[key] = insert_at
            end += 1
            changed += 1
    NAMES_FILE.write_text("\n".join(lines) + "\n", encoding="utf-8")
    return changed


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--batch", required=True)
    args = ap.parse_args()

    batch_dir = (ROOT / args.batch) if not Path(args.batch).is_absolute() else Path(args.batch)
    data = json.loads((batch_dir / "batch.json").read_text(encoding="utf-8-sig"))
    titles = read_titles(batch_dir / "titles.txt")

    done = 0
    missing = []
    name_pairs = {}
    for entry in data["entries"]:
        out_file = ROOT / entry["out_file"]
        if not out_file.exists():
            missing.append((entry["slug"], "missing output %s" % entry["out_file"]))
            continue
        html = out_file.read_text(encoding="utf-8-sig", errors="replace")
        out_file.write_text(add_meta(html), encoding="utf-8-sig")

        sidecar = ROOT / entry["sidecar"]
        sidecar.write_text(
            "[zh-CN]\nDescription=<BODY>[LOADDOC]%s[/LOADDOC]</BODY>\n"
            % entry["ref_rel"], encoding="utf-8")

        title = titles.get(entry["slug"])
        if not title:
            missing.append((entry["slug"], "missing title in titles.txt"))
        else:
            name_pairs[entry["stem"]] = title
        done += 1

    changed = update_names(name_pairs)
    print("applied %d/%d entries (%d name entries changed)"
          % (done, len(data["entries"]), changed))
    if missing:
        print("\nIncomplete entries:")
        for slug, note in missing:
            print("  %s: %s" % (slug, note))
        return 1
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
