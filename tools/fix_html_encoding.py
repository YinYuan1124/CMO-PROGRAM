#!/usr/bin/env python3
"""Make every translated HTML briefing load correctly in the game's IE WebBrowser.

The game displays [LOADDOC] briefing files by navigating the embedded IE control
directly to the file. IE does not assume UTF-8: without a BOM or a <meta charset>
it decodes the file with the system ANSI code page (GBK on Chinese Windows) and
the Chinese text turns into mojibake.

This script rewrites every *.zh-CN.html under Scenarios as UTF-8 **with BOM** and
inserts a <meta charset="utf-8"> when one is missing.

Usage:
    python tools/fix_html_encoding.py [--dry-run] [PATH ...]
"""
import argparse
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
DEFAULT_ROOT = ROOT / "Command" / "bin" / "Debug" / "Scenarios"

META = '<meta http-equiv="Content-Type" content="text/html; charset=utf-8">'


def add_meta(text):
    if re.search(r"charset\s*=", text[:3000], re.I):
        return text
    head = re.search(r"<head\b[^>]*>", text, re.I)
    if head:
        return text[: head.end()] + "\n\t" + META + text[head.end():]
    html = re.search(r"<html\b[^>]*>", text, re.I)
    if html:
        return text[: html.end()] + "\n\t<head>" + META + "</head>" + text[html.end():]
    return META + "\n" + text


def has_bom(data):
    return data.startswith(b"\xef\xbb\xbf")


def fix(path, dry_run):
    data = path.read_bytes()
    if has_bom(data):
        text = data[3:].decode("utf-8", errors="replace")
    else:
        try:
            text = data.decode("utf-8")
        except UnicodeDecodeError:
            # Already-encoded ANSI file? Leave it alone; we cannot guess safely.
            return False
    new_text = add_meta(text)
    new_data = b"\xef\xbb\xbf" + new_text.encode("utf-8")
    if new_data == data:
        return False
    if not dry_run:
        path.write_bytes(new_data)
    return True


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("paths", nargs="*")
    ap.add_argument("--dry-run", action="store_true")
    args = ap.parse_args()

    targets = []
    if args.paths:
        for raw in args.paths:
            p = Path(raw)
            targets.extend([p] if p.is_file() else sorted(p.rglob("*.zh-CN.html")))
    else:
        targets = sorted(DEFAULT_ROOT.rglob("*.zh-CN.html"))

    changed = 0
    for path in targets:
        try:
            if fix(path, args.dry_run):
                changed += 1
                print(("would fix " if args.dry_run else "fixed ") + str(path))
        except OSError as exc:
            print("FAILED %s: %s" % (path, exc))
    print("done: %d/%d files %s" % (
        changed, len(targets), "need fixing" if args.dry_run else "updated"))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
