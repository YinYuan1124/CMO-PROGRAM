# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this repository is

A reconstructed decompiler export (ILSpy) of **Command: Modern Operations v1.06, Build 1328.18** — a Windows desktop wargame written in C# (.NET Framework 4.8) with WinForms + WPF. The whole game is a single `WinExe` project, `Command`, producing `Command.exe` (AnyCPU, `Prefer32Bit=false`, so it runs 64-bit on x64 Windows).

The complete game source was recovered from the unobfuscated `Command/bin/Debug/Command.exe` and is now present in `Command/` (~2410 `.cs` files: `command/` for the UI, `Command_Core/` for the simulation, `DXRenderer/`, `ExWorldWind/`, `DotSpatial/`, `OpenDis/`, `DISnet/`, vendored helpers). The old partial `Command.csproj` is kept as a reference; the buildable project is `Command/Command.Localization.csproj`.

The game's runtime data lives next to the binary in `Command/bin/Debug/` and is mandatory: `GIS/` (~5.6 GB rasters/shapefiles), `WW/Cache/` (~13.7 GB MBTiles), `DB/` (85 SQLite `.db3` database builds), `Scenarios/`, `Symbols/`, `Shaders/`, `Config/`, `Lua/`, `Tacview/`.

## Build / run

Use the reconstructed SDK-style project (VS 2022 or the .NET SDK 9):

```
dotnet build Command/Command.Localization.csproj -c Debug
```

Output goes to `Command/bin/Debug/localized/Command.exe` (with dependencies). Because the game resolves all paths relative to the executable, run it with the data directory as its home: copy `Command/bin/Debug/localized/Command.exe` (and the PDB/config) into `Command/bin/Debug/`, or set the project's `<OutputPath>` to `bin\Debug\` if you want the build to deploy in place. The deployed `Command/bin/Debug/Command.exe` is the developed/localized build and is the only game executable kept in that folder.

The solution `CMO.Localization.sln` (repo root) contains the reconstructed project. The legacy `Command48.sln` still references a missing `Steamworks.NET` project; the new project references `Steamworks.NET.dll` from `bin/Debug` directly, so it does not need that project.

There is no test project and no lint setup.

### Build notes

- The project uses `Microsoft.NET.Sdk.WindowsDesktop`, `TargetFramework=net48`, `UseWPF` + `UseWindowsForms`, `LangVersion=11.0`, `AllowUnsafeBlocks`.
- `GenerateResourceUsePreserializedResources` is enabled and `dll/System.Resources.Extensions.dll` is referenced (required for the non-string `.resx` resources).
- `System.Management.Automation` (used by `Command.Tasks.ExpressionCollectionTask`) is referenced from the GAC; adjust the `HintPath` if building on a machine without Windows PowerShell 4/5.
- `Command.g.resources` (extracted from the original build) is embedded verbatim so WPF `Application.LoadComponent("/Command;component/...xaml")` finds the BAML. The decompiled `.baml` files are also embedded individually; do not remove `Command.g.resources`.
- `command/QResourceHelper.cs`, `command/QResourceManager.cs`, `command/QComponentResourceManager.cs` and the ILSpy module file are excluded via `<Compile Remove>` because the custom root `QResourceHelper.cs` defines the same types.
- The decompiled code contains a few VB/decompiler artifacts that were patched to compile: a missing `_MerchantDispatcher` field in `DarkUI.Collections.ObservableList`, an uninitialized `string_` in `Command_Core.EventAction_Points`, and ref-safety patterns in `ThreadSafeCollections.TDictionary`.

## Localization (EN / ZH)

The runtime language layer lives in `Command/command/Localization.cs`:

- `Localization.CurrentLanguage` (`Chinese` / `English`), `T(chinese, english)`, `Translate(original)`.
- Language is persisted in `Command/bin/Debug/Config/Localization.ini` under `[Settings] Language = zh-CN|en-US`. This file is the source of truth because the game rewrites `Command.ini` and drops unknown keys. `InitializeFromConfig()` runs at the start of `OpenDis.Candidates.AdapterCallbackCandidate.Main`.
- Translations are text-keyed. Defaults are in `Localization.AddDefaults()`; user overrides live in `Command/bin/Debug/Config/Localization.ini` with `[ChineseToEnglish]` and `[EnglishToChinese]` sections. Add entries there to translate more UI without rebuilding.
- **Hover-info settings** (`Options` → 鼠标悬浮信息 / Hover Info): `HoverInfoOptionsViewModel` is annotated with `HoverInfoLocalizedTypeDescriptionProvider`, which localizes `DisplayName`, `Description` and `Category`. `Command.Watchers.ListRuleWatcher` localizes the enum value captions (`Show`, `Hide`, `Show Summary`, `Show Detailed`). `HoverInfoOptions.RefreshLocalization` resets the WPF `PropertyGrid` DataContext when the language changes.
- The **language switch** is the new `Language / 语言` tab in `Command/command/Options.cs` (`InitializeLanguageTab`, `LanguageCombo_SelectedIndexChanged`). It now **saves the choice and requires a restart** (`Localization.SaveLanguagePreference`); the running UI is not rebuilt. This deliberately avoids the live-switch path that previously caused a `StackOverflowException`. Chinese (`zh-CN`) is the default and current language; restart in English if needed.
- UI translation is done at runtime by walking the WinForms control tree (all static `Control.Text` values, including custom DarkUI buttons, labels, forms, tabs and menus/toolstrips; list-view columns and DataGridView headers; text/input/data controls are deliberately skipped), the WPF logical/visual trees (text blocks, content controls, tooltips), and each `ElementHost` child. The WPF walk is **iterative** with a visited set (recursive logical+visual traversal overflowed the stack on large template trees). Original strings are cached so translation is idempotent. `StartGameMenuWindow` self-localizes on its own WPF dispatcher; `MainForm_Shown`, the `Application.Idle` sweep and a per-form delayed second pass catch late-created controls.
- The four start-menu flows are covered: **Start New Scenario / Edit Scenario** (`LoadScenario` + `ScenarioSelectControl`), **Quick Battle** (`QuickBattle`), **Campaign** (`CampaignPlayWindow`, `CampaignScenarioWindow`), plus the campaign/scenario editor dialogs (`CampaignEditorWindow`, `ScenarioTitle`, legacy `StartGame`).
- `Localization.SetLanguage` (live switch) remains in the code for future use but is no longer called by the Options UI.
- **Scenarios**: `Localization.ScenarioText(scenarioPath, field, original)` reads a sidecar `<scenario>.scen.i18n.ini` with `[zh-CN]` / `[en-US]` sections and `Title=` / `Description=` keys, then a per-scenario `<scenario>.<lang>.html` description file, then `Config/ScenarioNames.ini` (keyed by file stem) and the text map. It is wired into `LoadScenario` and `CampaignScenarioWindow`.
- **Scenario tree**: `LoadScenario.CompareAttribute` / `RestartAttribute` call `Localization.ScenarioDisplayName(path, isDirectory)`, which reads `Config/ScenarioNames.ini` `[zh-CN]`/`[en-US]` sections keyed by directory name or `.scen` file stem (without extension). **All 807 scenarios** (names + descriptions), all set folders and the `Community/Northern Fury` sub-folders are translated.
- `Description` can be an external `[LOADDOC]file.html[/LOADDOC]` reference; translate it by providing `<name>.zh-CN.html` and pointing the sidecar at it. All 807 scenarios have a `<scenario>.scen.i18n.ini` sidecar plus a translated HTML document.
- **Encoding requirement**: the game shows briefings in the IE `WebBrowser`, which decodes a file with the system ANSI code page (GBK) unless the HTML has a UTF-8 **BOM** or `<meta charset>`. Every `*.zh-CN.html` must therefore be written as UTF-8 **with BOM**; otherwise Chinese turns into mojibake (`鏈、腑蹂…`). `python tools/fix_html_encoding.py` normalizes all translated HTML files.
- **Campaign-level text**: `Campaign` now records `FilePath`; `CampaignPlayWindow` (intro) and `CampaignEnd` (ending) call `Localization.ScenarioText(campaignPath, "Description"/"EndingText", original)`. Each `<campaign>.campaign.i18n.ini` points at the translated `Intro/CampaignEnd/*.zh-CN.html`; `python tools/build_campaign_sidecars.py` regenerates those sidecars.
- Translation helpers: `python tools/audit_translations.py` (coverage; must report 0 missing), `python tools/check_translation_quality.py` (BOM/meta + leftover-English paragraphs), `python tools/prepare_translation_batch.py` / `finalize_translation_batch.py` (parallel batch workflow), `python tools/extract_scenarios.py --set <name>` (plain-text dump to `_translation_work/`).
- Scenario metadata shown in the right pane is localized too: `LoadScenario` translates `ScenSetting` (地点 / Location) through the text map (`Config/Localization.ini` contains the common theatre names), and the year label is emitted through `Localization.T`. The full set of 367 distinct `ScenSetting` values has been added to `[EnglishToChinese]`.

## Diagnosing map-screen failures

- Set `LogDebugInfoToFile = True` in `Command/bin/Debug/Config/Command.ini`. Exception logging is **disabled** when this is false (`GameGeneral.SortBridge` returns early), so a silently failing map leaves no trace in `Logs/ExceptionLog_YYYY_MM_DD.txt`.
- The map is initialized in `Command.MainForm` via `new DXRenderer.Main(GameGeneral.TopLevelWritablePath, WorldWindow1, 0, 0)` inside a try/catch that only logs. If it throws, the UI still runs but the map stays blank.
- `DXRenderer.Main` opens five MBTiles SQLite databases from `WW\Cache\*_webp.mbtiles` / `Bathymetry.mbtiles` and loads `shaders.hlsl`. It requires `SQLite.Interop.dll` matching `System.Data.SQLite` 1.0.119.0 (x64 for the 64-bit binaries) next to `System.Data.SQLite.dll`. This DLL was missing from the original copy; an x64 `SQLite.Interop.dll` is now present in `Command/bin/Debug/`. If you rebuild elsewhere, restore `Stub.System.Data.SQLite.Core.NetFramework` 1.0.119.0 or copy the interop DLL to the output.

## Architecture (big picture)

Single assembly, logically split by namespace:

- `Command_Core` — simulation engine and world state: `Game`, `Client`, `Scenario`, `ActiveUnit*` (AI, weaponry, sensors, docking, air ops), `Side`, `Terrain`, `MapProfile`, Lua API (`Command_Core.Lua`), DAL/caches.
- `Command` — WinForms UI: `MainForm` (map window), mission editor, ORBAT, weapon/DB windows, dialogs, WPF view-models. `Client` is the app-level façade connecting UI to the simulation.
- `DXRenderer` — custom Direct3D 11 / Direct2D map renderer built on `DirectN`; draws tiles from MBTiles, shapefile overlays, units, labels. `DXRenderer.Main` is the renderer singleton.
- `ExWorldWind` / `WorldWind` — 3D globe/camera/layers (`WorldWindow` is the WPF map host control).
- `DotSpatial` + `NetTopologySuite` + `GeoAPI` — GIS geometry/topology.
- `OpenDis` / `DISnet` — DIS protocol for multiplayer.
- Vendored support: `DarkUI` (theme), `CSMaterial`, `Sharp3D`, `GodSharp`, `Nini` (INI config), `Imazen.WebP.Extern` (WebP tile decoding, compiled in), `KeraLua`/`NLua`, `LiveCharts`, `NPOI`, `CoordinateSharp`, `MathNet`, `LZ4`, `SevenZipSharp`.

Runtime flow: `Command.exe` → `MainForm` (map + menus) → `Client` → `Command_Core.Game`/`Scenario`; `DXRenderer.Main` renders the map; `CommandTacviewManager.exe` and the `Tacview/` folder export ACMI/telemetry to the bundled Tacview.

## Binaries in `Command/bin/Debug` — don't confuse them

- `Command.exe` + `Command.pdb` — the developed/localized build produced from `Command.Localization.csproj`. This is now the **only game executable** in the folder.
- `Launcher.exe` — official Matrix launcher; its config points to `\Command.exe`, so it starts the developed build.
- `4KFix.exe`, `CommandTacviewManager.exe` — official utilities (DPI fix, Tacview integration), not alternate game builds.
- The old game binaries (`Command-main.exe`, `Command-main -英文原版.exe`, `Command - 英文原版.exe`, `Command.original.exe`, their PDBs) have been moved out of the runtime folder to `%TEMP%\cmo-tools\removed-originals\`. They are no longer launchable from `bin/Debug`.
- `Tacview/` — commercial **Tacview 1.9.3.200** installation (Raia Software), not source. It includes the official add-on SDK (`SDK/cs`, `SDK/cpp`) and Lua add-ons (`AddOns/`) for extension, but no Tacview core source.

## Version control hygiene

- `.gitignore` ignores IDE state, build outputs (`obj/`, `localized/`, `*.exe`, `*.pdb`, `*.dll`), NuGet `packages/`, and the huge runtime data (`GIS/`, `WW/`, `DB/`, `Tacview/`, logs, temp). `Command/dll/` third-party dependencies and `Command/bin/Debug/Config/Localization.ini` / `ScenarioNames.ini` are explicitly kept.
- `.gitattributes` normalizes source/config/translation files to CRLF, marks binaries, and marks `*.scen` as text with diff suppressed (large XML).
- Scenario translation sidecars (`*.scen.i18n.ini`) and `<name>.zh-CN.html` files live next to the scenarios under `Command/bin/Debug/Scenarios/` and are not ignored.

## Working with decompiled code

- Preserve the decompiler's style when patching: VB-origin constructs (`Microsoft.VisualBasic.CompilerServices`, `ProjectData`, `Conversions`), `VB_0024AnonymousDelegate_*.cs`, `-Module--...-.cs`, and surviving obfuscated identifiers (`MerchantMerchantPage`, `_Closure$__...`). Do not rename types wholesale.
- `Command.csproj` uses `LangVersion 11.0` with .NET Framework 4.8; C# 11 features are allowed.
- When a source file is missing, decompile the matching type from `Command.exe` (`DOTNET_ROLL_FORWARD=Major ilspycmd -t <Type> Command.exe`). The original `Command-main.exe` is obfuscated and decompiles to empty method bodies.
