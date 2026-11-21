#!/usr/bin/env python3
"""Post-translation sanity checks beyond the coverage audit.

Flags:
  * translated HTML missing the UTF-8 BOM or a charset declaration
  * whole paragraphs left in English (heuristic: a visible text run with
    >= 8 ASCII words and no CJK characters)
  * sidecars pointing at missing files

Usage:
    python tools/check_translation_quality.py [--set NAME] [--limit N]
"""
import argparse
import html
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
SCEN_ROOT = ROOT / "Command" / "bin" / "Debug" / "Scenarios"
DOC_RE = re.compile(r"\[LOADDOC\](.*?)\[/LOADDOC\]", re.S | re.I)
BLOCK_RE = re.compile(r"<(p|li|h[1-6]|div)\b[^>]*>(.*?)</\1>", re.S | re.I)
TAG_RE = re.compile(r"<[^>]+>")
CJK_RE = re.compile(r"[㐀-鿿]")
WORD_RE = re.compile(r"[A-Za-z][A-Za-z'’-]+")
SKIP_GROUPS = {"Autosaves", "Steam Workshop"}


def visible(fragment):
    text = TAG_RE.sub(" ", fragment)
    text = html.unescape(text)
    return re.sub(r"\s+", " ", text).strip()


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--set", dest="group")
    ap.add_argument("--limit", type=int, default=0, help="max findings per kind")
    args = ap.parse_args()

    problems = []
    checked = 0
    for sidecar in sorted(SCEN_ROOT.rglob("*.scen.i18n.ini")):
        rel = sidecar.relative_to(SCEN_ROOT)
        group = rel.parts[0] if len(rel.parts) > 1 else "(root)"
        if group in SKIP_GROUPS:
            continue
        if args.group and group != args.group:
            continue
        text = sidecar.read_text(encoding="utf-8-sig", errors="replace")
        match = DOC_RE.search(text)
        if not match:
            problems.append((str(rel), "sidecar has no [LOADDOC]"))
            continue
        doc = sidecar.parent / match.group(1).strip()
        if not doc.exists():
            problems.append((str(rel), "missing doc: %s" % match.group(1)))
            continue
        raw = doc.read_bytes()
        if not raw.startswith(b"\xef\xbb\xbf"):
            problems.append((str(rel), "doc has no UTF-8 BOM: %s" % doc.name))
        if b"charset" not in raw[:3000].lower():
            problems.append((str(rel), "doc has no charset: %s" % doc.name))
        content = raw.decode("utf-8-sig", errors="replace")
        unchecked = []
        for block in BLOCK_RE.findall(content):
            text_run = visible(block[1])
            if not text_run or CJK_RE.search(text_run):
                continue
            if len(WORD_RE.findall(text_run)) >= 8:
                unchecked.append(text_run[:120])
        checked += 1
        for snippet in unchecked[:2]:
            problems.append((str(rel), "possible untranslated text: %s" % snippet))

    shown = problems if not args.limit else problems[: args.limit]
    for rel, note in shown:
        print("%s\n    %s" % (rel, note))
    if args.limit and len(problems) > len(shown):
        print("... %d more" % (len(problems) - len(shown)))
    print("\nchecked %d sidecars, %d findings" % (checked, len(problems)))
    return 1 if problems else 0


if __name__ == "__main__":
    sys.exit(main())
