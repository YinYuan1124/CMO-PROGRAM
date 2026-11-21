#!/usr/bin/env python3
"""Write localization sidecars for campaign-level intro/ending documents.

CampaignPlayWindow and CampaignEnd read <campaign>.campaign.i18n.ini and call
Localization.ScenarioText(campaignPath, "Description"/"EndingText", original).
This script points those keys at the translated documents:

  <campaign>.campaign.i18n.ini
      [zh-CN]
      Description=<BODY>[LOADDOC]Intro.zh-CN.html[/LOADDOC]</BODY>
      EndingText=<BODY>[LOADDOC]CampaignEnd.zh-CN.html[/LOADDOC]</BODY>

Documents are left in place; a sidecar is only written for keys whose translated
file exists. Strike Tutorial stores its text inline, so it uses the
<name>.campaign.Description.zh-CN.html / .Ending.zh-CN.html files.

Usage:
    python tools/build_campaign_sidecars.py [--dry-run]
"""
import argparse
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
SCEN_ROOT = ROOT / "Command" / "bin" / "Debug" / "Scenarios"
DOC_RE = re.compile(r"\[LOADDOC\](.*?)\[/LOADDOC\]", re.S | re.I)


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument("--dry-run", action="store_true")
    args = ap.parse_args()

    written = 0
    for campaign in sorted(SCEN_ROOT.glob("*/*.campaign")):
        xml = campaign.read_text(encoding="utf-8-sig")
        lines = ["[zh-CN]"]
        for key in ("Description", "EndingText"):
            match = re.search(r"<%s>(.*?)</%s>" % (key, key), xml, re.S | re.I)
            if not match or not match.group(1).strip():
                continue
            value = match.group(1)
            doc = DOC_RE.search(value)
            if doc:
                rel = doc.group(1).strip()
                original = campaign.parent / rel
                translated = original.with_name(original.stem + ".zh-CN.html")
                if not translated.exists():
                    print("skip %s %s: no %s" % (campaign.stem, key, translated.name))
                    continue
                out_rel = (Path(rel).parent / translated.name).as_posix()
            else:
                candidates = [
                    campaign.parent / (campaign.name + "." + key + ".zh-CN.html"),
                ]
                if key == "EndingText":
                    candidates.append(
                        campaign.parent / (campaign.name + ".Ending.zh-CN.html"))
                translated = next((p for p in candidates if p.exists()), candidates[0])
                if not translated.exists():
                    print("skip %s %s: no %s" % (campaign.stem, key, translated.name))
                    continue
                out_rel = translated.name
            lines.append("%s=<BODY>[LOADDOC]%s[/LOADDOC]</BODY>" % (key, out_rel))

        if len(lines) == 1:
            print("skip %s: nothing translated" % campaign.name)
            continue
        sidecar = Path(str(campaign) + ".i18n.ini")
        content = "\n".join(lines) + "\n"
        if args.dry_run:
            print("would write", sidecar)
        else:
            sidecar.write_text(content, encoding="utf-8")
        written += 1
    print("%s %d campaign sidecars" % ("would write" if args.dry_run else "wrote", written))
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
