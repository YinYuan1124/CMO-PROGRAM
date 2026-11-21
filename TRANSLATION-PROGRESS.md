# CMO 想定本地化进度与交接

本文件供**新对话**接手继续维护翻译，避免重复摸索。项目背景见 [CLAUDE.md](CLAUDE.md)。

## 当前状态（2026-11-21）：全部完成

| 范围 | 想定数 | 名称已翻译 | 简介已翻译 |
|---|---:|---:|---:|
| Tutorials | 51 | 51 | 51 |
| Standalone Scenarios | 59 | 59 | 59 |
| Strike Tutorial（顶层副本） | 6 | 6 | 6 |
| Chains Of War | 16 | 16 | 16 |
| Desert Storm | 15 | 15 | 15 |
| Falklands | 15 | 15 | 15 |
| Kashmir Fire | 15 | 15 | 15 |
| LIVE | 14 | 14 | 14 |
| Northern Inferno | 15 | 15 | 15 |
| Red Tide | 12 | 12 | 12 |
| Shifting Sands | 17 | 17 | 17 |
| Showcase | 4 | 4 | 4 |
| The Silent Service | 18 | 18 | 18 |
| Community | 550 | 550 | 550 |
| **总计** | **807** | **807** | **807** |

此外：

- 9 个战役（`.campaign`）的序章与结局共 18 篇全部翻译，侧车为 `<campaign>.campaign.i18n.ini`。
- `Config/Localization.ini` 的 `[EnglishToChinese]` 已覆盖全部 367 个 `ScenSetting`（地点）取值。
- `ScenarioNames.ini` 已包含全部 807 个想定标题、所有套系文件夹名，以及 `Community/Northern Fury` 的 6 个子战役文件夹名。

`Scenarios/Autosave.scen` 是自动存档，不在统计内。

## 验证

```bash
python tools/audit_translations.py            # 必须为 0 缺失、0 broken LOADDOC
python tools/check_translation_quality.py     # 检查 BOM/charset 与整段英文残留
```

`check_translation_quality.py` 仅会报告来源链接/引用行（YouTube、Discord、维基等），属正常。

## 关键编码规则（乱码根因）

游戏的简介窗口是 **IE WebBrowser**，直接 `Navigate` 到 `.zh-CN.html` 文件。IE 在没有 **UTF-8 BOM**或
`<meta charset>` 时按系统 ANSI（中文 Windows 为 GBK）解码，中文就会显示成
`鏈、腑蹂烊鍵…` 之类的乱码。

- 所有翻译 HTML 必须保存为 **UTF-8 with BOM**，并带有 `<meta charset="utf-8">`。
- 新增/修改后运行 `python tools/fix_html_encoding.py` 统一修复。
- 侧车 `.i18n.ini` 与 `ScenarioNames.ini` 保持 UTF-8（无 BOM 也可，Nini 按 UTF-8 读取）。

## 新增/修改想定时的流程

### 想定名称

编辑 [Config/ScenarioNames.ini](Command/bin/Debug/Config/ScenarioNames.ini) 的 `[zh-CN]` 段：

```ini
想定文件名（去掉 .scen）=中文标题
```

### 想定简介

不要修改 `.scen` 本身。每个想定旁边保留两个文件：

1. `<想定名>.zh-CN.html`：简体中文 HTML，保留段落/列表结构。
2. `<想定名>.scen.i18n.ini`：

```ini
[zh-CN]
Description=<BODY>[LOADDOC]<想定名>.zh-CN.html[/LOADDOC]</BODY>
```

如果原 `ScenDescription` 是 `[LOADDOC]foo.html[/LOADDOC]`，翻译 `foo.html` 为
`foo.zh-CN.html`（放在同一目录，保证相对图片/CSS 路径不变），侧车写：

```ini
[zh-CN]
Description=<BODY>[LOADDOC]foo.zh-CN.html[/LOADDOC]</BODY>
```

### 战役序章/结局

在 `<campaign>.campaign.i18n.ini` 中写：

```ini
[zh-CN]
Description=<BODY>[LOADDOC]Intro.zh-CN.html[/LOADDOC]</BODY>
EndingText=<BODY>[LOADDOC]CampaignEnd.zh-CN.html[/LOADDOC]</BODY>
```

可用 `python tools/build_campaign_sidecars.py` 自动生成。

### 地点（ScenSetting）

在 [Config/Localization.ini](Command/bin/Debug/Config/Localization.ini) 的
`[EnglishToChinese]` 增加：

```ini
Northwestern Europe=西北欧
```

## 批量翻译工具

```bash
# 1. 按套系切批（每批 15 篇）
python tools/prepare_translation_batch.py --set "Community" \
    --batch-index 0 --batch-size 15 --out _translation_work/batches/community-000

# 2. 子任务按 batch.json 翻译 src/*.html → out_file，并写 titles.txt
#    （见 _translation_work/AGENT_GUIDE.md）

# 3. 合并：写 BOM/charset、生成侧车、更新 ScenarioNames.ini
python tools/finalize_translation_batch.py --batch _translation_work/batches/community-000

# 4. 审计
python tools/audit_translations.py
```

## 翻译风格

- 忠实原意，可适度精简，但保留日期、数字、地点、编队/舰机/武器型号（英文专名保留原文）。
- 不调用外部翻译服务；在会话内直接翻译。
- 保留 HTML 结构：`<html><body><p>…</p><ul><li>…</li></ul></body></html>`。
- 名称、简介、地点都是**数据文件**，不需要重新编译；重启 `Command/bin/Debug/Command.exe` 查看。

## 完成标准

```bash
python tools/audit_translations.py
```

所有集合的 `MissingNames`、`MissingDescs` 均为 `0`，且没有 `missing doc` 引用。
