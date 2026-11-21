Scenario localization / 想定本地化
=================================

Put a sidecar file next to a scenario:

    <scenario-file>.scen.i18n.ini

Example:

    Scenarios/Tutorials/.../Flight Tutorial 7 ....scen.i18n.ini

Content:

    [zh-CN]
    Title=中文标题
    Description=<p>中文简介 HTML</p>

    [en-US]
    Title=English title
    Description=<p>English description HTML</p>

The game reads the section matching Config\Command.ini -> [Game Preferences] Language.
Missing fields fall back to the original text in the .scen file.
The current hooks cover the scenario browser/preview (LoadScenario, CampaignScenarioWindow).
In-scenario briefing/message text is stored in the compressed .scen payload and is not modified.
