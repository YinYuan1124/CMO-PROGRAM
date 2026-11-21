#!/usr/bin/env python3
"""Prepare a self-contained translation batch for a sub-agent.

Usage:
    python tools/prepare_translation_batch.py --set "Falklands" \
        --batch-index 0 --batch-size 15 \
        --out _translation_work/batches/falklands-000

Writes to the batch folder:
    batch.json        one entry per scenario (paths + English title)
    src/<slug>.html   the exact description HTML to translate
    README.txt        short agent instructions

The agent translates each src file into Chinese, writes it to the "out_file"
path from batch.json, and records titles in titles.txt (one "slug<TAB>title"
line per scenario). Then run finalize_translation_batch.py.
"""
import argparse
import json
import re
import sys
import xml.etree.ElementTree as ET
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
SCEN_ROOT = ROOT / "Command" / "bin" / "Debug" / "Scenarios"
NAMES_FILE = ROOT / "Command" / "bin" / "Debug" / "Config" / "ScenarioNames.ini"
SKIP_GROUPS = {"Autosaves", "Steam Workshop"}
DOC_RE = re.compile(r"\[LOADDOC\](.*?)\[/LOADDOC\]", re.S | re.I)


def load_name_keys():
    keys = set()
    if not NAMES_FILE.exists():
        return keys
    section = None
    for line in NAMES_FILE.read_text(encoding="utf-8-sig").splitlines():
        stripped = line.strip()
        if stripped.startswith("[") and stripped.endswith("]"):
            section = stripped[1:-1]
            continue
        if section == "zh-CN" and "=" in line and not stripped.startswith(";"):
            keys.add(line.split("=", 1)[0].strip())
    return keys


def rel_url(path, start):
    return Path(path).resolve().relative_to(Path(start).resolve()).as_posix()


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--set", dest="group", required=True)
    ap.add_argument("--batch-index", type=int, default=0)
    ap.add_argument("--batch-size", type=int, default=15)
    ap.add_argument("--out", required=True)
    ap.add_argument("--include-translated", action="store_true",
                    help="also include scenarios that already have a zh-CN sidecar")
    args = ap.parse_args()

    source = SCEN_ROOT / args.group
    if not source.is_dir():
        print("Not found:", source, file=sys.stderr)
        return 2

    names = load_name_keys()
    batch_dir = (ROOT / args.out) if not Path(args.out).is_absolute() else Path(args.out)
    src_dir = batch_dir / "src"
    src_dir.mkdir(parents=True, exist_ok=True)

    pending = []
    for scen in sorted(source.rglob("*.scen")):
        sidecar = Path(str(scen) + ".i18n.ini")
        if not args.include_translated and sidecar.exists() and scen.stem in names:
            continue
        pending.append(scen)

    selected = pending[args.batch_index * args.batch_size:
                       (args.batch_index + 1) * args.batch_size]
    if not selected:
        print("No scenarios at this offset. Pending in set: %d" % len(pending),
              file=sys.stderr)
        return 1

    entries = []
    for i, scen in enumerate(selected):
        try:
            root = ET.parse(scen).getroot()
        except Exception as exc:  # noqa: BLE001
            print("skip %s: %s" % (scen.name, exc), file=sys.stderr)
            continue
        title = root.findtext("ScenTitle") or scen.stem
        desc = root.findtext("ScenDescription") or ""
        match = DOC_RE.search(desc)
        doc_rel = None
        if match:
            doc_rel = match.group(1).strip()
            doc_path = scen.parent / doc_rel
            if not doc_path.exists():
                print("missing LOADDOC %s for %s" % (doc_rel, scen.name), file=sys.stderr)
                doc_rel = None
            else:
                desc = doc_path.read_text(encoding="utf-8-sig", errors="replace")

        slug = "%03d_%s" % (i, re.sub(r"[^A-Za-z0-9._-]+", "_", scen.stem)[:60])
        src_file = src_dir / (slug + ".html")
        src_file.write_text(desc, encoding="utf-8")

        if doc_rel:
            # Keep the translated file next to the source document so relative
            # image/CSS references keep working.
            doc_path = scen.parent / doc_rel
            out_path = doc_path.with_name(doc_path.stem + ".zh-CN.html")
            ref_rel = rel_url(out_path, scen.parent)
        else:
            out_path = scen.parent / (scen.stem + ".zh-CN.html")
            ref_rel = out_path.name

        entries.append({
            "slug": slug,
            "scen": scen.resolve().relative_to(ROOT).as_posix(),
            "stem": scen.stem,
            "title_en": title,
            "kind": "loaddoc" if doc_rel else "inline",
            "doc_rel": doc_rel,
            "src_file": src_file.resolve().relative_to(ROOT).as_posix(),
            "out_file": out_path.resolve().relative_to(ROOT).as_posix(),
            "sidecar": Path(str(scen) + ".i18n.ini").resolve().relative_to(ROOT).as_posix(),
            "ref_rel": ref_rel,
        })

    (batch_dir / "batch.json").write_text(
        json.dumps({"set": args.group, "entries": entries},
                   ensure_ascii=False, indent=2) + "\n", encoding="utf-8")
    (batch_dir / "titles.txt").write_text("", encoding="utf-8")
    (batch_dir / "README.txt").write_text(
        "Translate every src/*.html entry in batch.json into Simplified Chinese.\n"
        "Write the result to the entry's out_file and add 'slug<TAB>title' lines\n"
        "to titles.txt. Do not touch any other file.\n", encoding="utf-8")
    print("prepared %d scenarios in %s (pending in set: %d)"
          % (len(entries), batch_dir, len(pending)))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
