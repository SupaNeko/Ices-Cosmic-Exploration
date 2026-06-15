# ICE 英文 UI 文本提取表

本文件用于汇总 ICE 插件中需要翻译的玩家可见英文文本。

## 覆盖范围

- `ICE/ICE.cs`
- `ICE/Ui/` 及其所有子目录下的 `.cs` 文件

## 技术定位方式

使用 Roslyn C# 语法分析器扫描上述文件，提取在 ImGui / ImGuiEx / 自定义 UI 助手 / 聊天输出 / 命令帮助 / 窗口标题等玩家可见位置出现的字符串字面量（含普通字符串、逐字字符串、原始字符串及插值字符串中的静态文本片段）。随后根据字符串内容与出现上下文过滤掉非玩家可见的字符串。

## 排除内容

- 空字符串或仅含空白/标点的字符串
- ImGui 内部 ID（如 `##id`、`###id`）
- 资源路径与 URL（如 `.png`、`.json`、`https://...`）
- 内部标识符、命令名、IPC 调用名等不向玩家直接展示的字符串
- 对象序列化 / 调试输出片段（如 `X =`、`new Vector3(` 等）
- printf 风格的纯格式说明符（如 `%.1f`）

## 缩写处理规则

以下通用缩写或 FFXIV 职业缩写作为独立文本出现时，中文翻译列保留英文原文，不做翻译：

`ID`、`XP`、`NQ`、`HQ`、`NPC`、`GP`、`AP`、`PP`、`CP`、`AF`、`WF`、`LB`、`HP`、`MP`、`TP`、`HUD`、`UI`、`CS`，以及制作/采集职业缩写 `CRP`、`BSM`、`ARM`、`GSM`、`LTW`、`WVR`、`ALC`、`CUL`、`MIN`、`BTN`、`FSH`。

> 共提取 **1377** 条玩家可见英文文本。

| 英文原文 | 中文翻译 | 英文原意/上下文 | 修改意见 |
|---|---|---|---|
| % of Level |  | Table column \| ICE\Ui\Window_ExternalDetails.cs:265 | |
| (e.g. Rank D completed but Rank C not yet unlocked), make sure to unlock it manually before starting. |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:66 | |
| (It helps if you verbally say it like a pirate) |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:28 | |
| (optional custom name) |  | UI text (disabled) \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:457 | |
| (select to add optional name) |  | UI text (disabled) \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:461 | |
| (So if you're on crp, but a bsm red alert pops up) |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:264 | |
| (Sorry for making you start big fish #NotSorry#MuchLove) |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:60 | |
| **These will automatically set settings for using these modes temporarily** |  | UI string \| ICE\Ui\MainWindow.cs:159 | |
| **This will respect the want to grind off class provisionals, and criticals if you have those enabled |  | UI string \| ICE\Ui\MainWindow.cs:175 | |
| - - - Mission specific - - - |  | UI string \| ICE\ICE.cs:311 | |
| - - ICE Commands Help - - |  | UI string \| ICE\ICE.cs:307 | |
| - Jump: attempts to jump over the obstacle |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:204 | |
| - Retarget: stops and re-pathfinds to the destination (re-randomizes if enabled) |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:205 | |
| - This is due to the fact that I cba coding this in at this time. (might change my mind in the future *shrugs*) |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:296 | |
| - This is optional, you can disable it at your own free will, I just like this so I can just go back to an isolated area of my choosing |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:299 | |
| --> Name: {0} \| ID: {1} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:276 | |
| -> Automatically select which missions that are best to finish up your relic |  | UI string \| ICE\Ui\MainWindow.cs:162 | |
| -> For crafters it's whatever missions take the least amount of progress |  | UI string \| ICE\Ui\MainWindow.cs:157 | |
| -> For gathering, it's whatever is the least pain to do w/ the minimum amount of skills |  | UI string \| ICE\Ui\MainWindow.cs:158 | |
| -> If it is apart of a sequence chain, it will grab the mission that are needed previously to help complete it, and the missions post if necessary |  | UI string \| ICE\Ui\MainWindow.cs:173 | |
| -> If it runs out of missions to reroll, it will just continually swap tabs until the mission is available (via provisional or critical) |  | UI string \| ICE\Ui\MainWindow.cs:174 | |
| -> If you want to only do certain missions, enable the option and select which ones you want to do |  | UI string \| ICE\Ui\MainWindow.cs:164 | |
| -> Select which missions you want to do, and go at it. |  | UI string \| ICE\Ui\MainWindow.cs:152 | |
| -> These are hand picked by me, and determined by the time it takes to complete it |  | UI string \| ICE\Ui\MainWindow.cs:156 | |
| -> These are weighed based on what is needed to complete the tool to the next step |  | UI string \| ICE\Ui\MainWindow.cs:163 | |
| -> Used to select which missions you want to grind. It'll priortize in the following order: |  | UI string \| ICE\Ui\MainWindow.cs:150 | |
| -> Will automatically pick all the missions that you do not have currently gold, AND ONLY THOSE MISSIONS. |  | UI string \| ICE\Ui\MainWindow.cs:172 | |
| -> Will automatically select which mission is the best for leveling your current class based on what level bracket you're in |  | UI string \| ICE\Ui\MainWindow.cs:155 | |
| /ice |  | Command help \| ICE\ICE.cs:91 | |
| /ice -> opens the main settings |  | UI string \| ICE\ICE.cs:309 | |
| /ice add (ids) - enables select missions |  | UI string \| ICE\ICE.cs:316 | |
| /ice flag (id) - opens the map and flags the mission (if it has one). |  | UI string \| ICE\ICE.cs:320 | |
| /ice help - show all available commands |  | UI string \| ICE\ICE.cs:308 | |
| /ice only (ids) - makes only select missions enabled |  | UI string \| ICE\ICE.cs:319 | |
| /ice remove (ids) - removes/disables select missions |  | UI string \| ICE\ICE.cs:317 | |
| /ice s -> opens the settings menu |  | UI string \| ICE\ICE.cs:310 | |
| /ice start - starts ICE |  | UI string \| ICE\ICE.cs:313 | |
| /ice stop - Stops ICE |  | UI string \| ICE\ICE.cs:312 | |
| /ice toggle (ids) - toggles select mission ids |  | UI string \| ICE\ICE.cs:318 | |
| /icecosmic |  | Command help \| ICE\ICE.cs:82; ICE\ICE.cs:92 | |
| /vnav moveflag |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:168; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:150 | |
| 0 = will just keep buying |  | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:57 | |
| 100% the cheapest will be applied |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:836; ICE\Ui\MainUi\Settings\GatherSettings.cs:882; ICE\Ui\MainUi\Settings\GatherSettings.cs:928 | |
| 1: A position is saved: |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:279 | |
| 1: Score that you personally have set has been met |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:991 | |
| 1: This will check for your current CLASS [not menu class, actual current class] for relic turnin. |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:294 | |
| 1: You have immaculate rng of getting the mission you want every time |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:374 | |
| 2: A random spot even is saved |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:280 | |
| 2: Timer has ran out |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:992 | |
| 2: You must not have the tool eqipped for this to run full auto. |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:295 | |
| 2: You're hitting the threshold every time |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:375 | |
| 2nd Job |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:187 | |
| 360 = the whole fan will be available for selection |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:102 | |
| 3: This will take prio over "Stop @ Relic Turnin", in the sense that if you have both enabled, it will turnin vs stop. And continue about it's day |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:297 | |
| 4: If you're on a crafting class, it will return you back to the stop you were crafting post turnin. |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:298 | |
| 50% chance to grant Eureka Moment |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:727 | |
| ???? For some reason we're missing this. Please Report this to I |  | UI string \| ICE\Ui\MainWindow.cs:176 | |
| A "Doyouthinkheseemesaurs" |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:54 | |
| A and above |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:45 | |
| A mode designed to automate mission selection for relic progression with minimal intervention. |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:61 | |
| A way for you to save your own positions if you choose to not use a randomized spot that's included in the plugin |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:277 | |
| Abandon |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:127; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:417 | |
| Abandon Mission |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:34 | |
| Above 0 to keep a set limit |  | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:233 | |
| Action Info: |  | UI text \| ICE\Ui\MainUi\Settings\GatherSettings.cs:485; ICE\Ui\MainUi\Settings\GatherSettings.cs:527; ICE\Ui\MainUi\Settings\GatherSettings.cs:571; ICE\Ui\MainUi\Settings\GatherSettings.cs:617; ICE\Ui\MainUi\Settings\GatherSettings.cs:673; ICE\Ui\MainUi\Settings\GatherSettings.cs:729; ICE\Ui\MainUi\Settings\GatherSettings.cs:781; ICE\Ui\MainUi\Settings\GatherSettings.cs:838; ICE\Ui\MainUi\Settings\GatherSettings.cs:884; ICE\Ui\MainUi\Settings\GatherSettings.cs:930; ICE\Ui\MainUi\Settings\GatherSettings.cs:975 | |
| Activate Mission |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:223 | |
| Add Armor/Housing/Mounts |  | Button \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:86 | |
| Add delay to athernet / npc travel |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:176 | |
| Add delay to crafting menu |  | Checkbox \| ICE\Ui\MainUi\Settings\SafetySettings.cs:55 | |
| Add delay to gather |  | Checkbox \| ICE\Ui\MainUi\Settings\SafetySettings.cs:85 | |
| Add delay to mission menu |  | Checkbox \| ICE\Ui\MainUi\Settings\SafetySettings.cs:33 | |
| Add Fishing Spot |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:231 | |
| Add Location |  | Button \| ICE\Ui\MainUi\Settings\TravelSettings.cs:263 | |
| Add Material/Dyes/Items |  | Button \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:79 | |
| Add Missing Fishing Holes |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:32 | |
| Add New Command |  | Button \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:245 | |
| Add Node: {0} |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:189 | |
| Add Position |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NavmeshTesting.cs:29 | |
| Add Profile |  | Button \| ICE\Ui\MainUi\Settings\GatherSettings.cs:334 | |
| Add to Cosmic Agenda |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:187 | |
| Added |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:61 | |
| Addon Ready: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:14 | |
| Adds a random delay before interacting with the aethershard / red alert npc travel. |  | Help marker \| ICE\Ui\MainUi\Settings\TravelSettings.cs:181 | |
| Adds a small random offset to navigation destinations so the character doesn't always follow the exact same path |  | Tooltip \| ICE\Ui\MainUi\Settings\TravelSettings.cs:72 | |
| Adjust |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NavmeshTesting.cs:39 | |
| Aethernet Test |  | UI string \| ICE\Ui\DebugWindow.cs:91 | |
| Aethershard Unlocked |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Aethernet.cs:66 | |
| after |  | UI text \| ICE\Ui\MainUi\Settings\TravelSettings.cs:221 | |
| Ageless Words / Solid Reason |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:715 | |
| Agenda |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:350; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:445 | |
| Agenda Info: Profile Save |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:218; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:221 | |
| Agenda List Viewer |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:293 | |
| Agenda Missions Table: Favorites Info |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:347 | |
| Agenda Mode |  | UI string \| Radio button \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:29; ICE\Ui\MainWindow.cs:137 | |
| Agenda Mode: Tabs |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:46 | |
| Agenda Viewer: Details |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:315 | |
| AgentMap is null! |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:20 | |
| ALC | ALC | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:31; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:17; ICE\Ui\MainUi\Settings\Misc_Settings.cs:129 | |
| Alchemist (ALC) |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:70 | |
| All Class progresses |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:108 | |
| All Classes |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:79 | |
| All Current objects |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:268 | |
| All fishing data exported to clipboard! |  | Chat message \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:60 | |
| All gathering profile have been updated/automatically applied |  | UI text \| ICE\Ui\InfoWindow.cs:99 | |
| All Missions |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:45 | |
| All Missions for this hole |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:135 | |
| All world timers: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_TimerInfo.cs:13 | |
| Allow for all Provisional Jobs |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:189 | |
| Allows testing to make sure that you have the preset name |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1289 | |
| Always navigate to the closest targetable node instead of following the fixed route order.<br>Useful for timed EX+ missions where speed matters. |  | Tooltip \| ICE\Ui\MainUi\Settings\TravelSettings.cs:61 | |
| Amount |  | Table column \| ICE\Ui\MainUi\Settings\GatherSettings.cs:275 | |
| Amount #1 |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:209 | |
| Amount #2 |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:211 | |
| Amount #3 |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:213 | |
| Amount Enabled |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:368 | |
| Amount [1] |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:26; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:32 | |
| Amount [2] |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:28; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:34 | |
| Amount [3] |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:30; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:36 | |
| Amount [G-{0}] |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:220 | |
| Amount [{0}] |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:32 | |
| Amount: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:77; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:112 | |
| and honestly I'm having a hard time putting it down |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:31 | |
| Anything above 0 will just be a hard cap and will stop buying if it reaches this |  | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:58 | |
| Anything below 0 to keep all logs |  | Tooltip \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:232 | |
| Anything besides that will chose within that fan (if it's available) |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:103 | |
| Apply |  | Button \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:139 | |
| Apply a 10% buff to your boon chance. |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:525 | |
| Apply a 30% buff to your boon chance. |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:483 | |
| Apply Temp |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:75; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:190 | |
| Apply to agenda |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:324 | |
| Apply to all classes |  | Radio button \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:103 | |
| Apply to Mission Types |  | Button \| ICE\Ui\MainUi\Settings\GatherSettings.cs:413 | |
| Apply to similar missions |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1415 | |
| Apply to specific class |  | Radio button \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:109 | |
| ARM | ARM | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:27; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:27; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:13; ICE\Ui\MainUi\Settings\Misc_Settings.cs:128 | |
| Armorer (ARM) |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:66 | |
| Artisan Craft |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:260 | |
| Artisan Endurance: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:205 | |
| Artisan Is Busy? {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:32 | |
| Artisan Macro |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1530 | |
| Artisan, craft this |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:34 | |
| Attribute |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:19 | |
| Attribute Flags |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:193 | |
| Auto Close Reward Popups |  | Checkbox \| ICE\Ui\MainUi\Settings\SafetySettings.cs:91 | |
| Auto Cordial |  | Checkbox \| ICE\Ui\MainUi\Settings\GatherSettings.cs:190 | |
| Auto Gamba |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:9; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:35 | |
| Auto Hide/Show Planet Tokens |  | Checkbox \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:47 | |
| Auto Resize Overlay |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:94 | |
| Auto Select |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:45 | |
| Auto Select Job |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:138 | |
| Auto start upon entering a Cosmic Exploration area |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:182 | |
| Auto-Remove Stellar Status |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:171 | |
| Auto-Use |  | Section header \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:167 | |
| Auto-Use Stellar Sprint |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:47 | |
| AutoHook |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:61 | |
| Autohook Presets |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:118 | |
| Automate cosmodrone |  | Checkbox \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:62 | |
| Automatically removes the Star Contributor visual effect (the glow you get for being a top contributor). |  | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:178 | |
| Automating Hub Activities |  | Section header \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:31 | |
| Average SPM: {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1331 | |
| Average Time History to keep |  | Input label \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:223 | |
| Average Time: --:--:-- |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:356 | |
| Average Time: {0} |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:351 | |
| Avoid Stellar Return for pathing |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:129 | |
| B and above |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:45 | |
| Bait is not currently equipped |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:90 | |
| Bait is null... aka not in the middle of a mission |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:103 | |
| Basic Missions |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:44 | |
| Basic missions (Ranks D→A) will only pull from the class you started on. |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:50 | |
| Battle Job |  | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:971; ICE\Ui\MainUi\Settings\Character_Settings.cs:1012 | |
| Because they have hallow-eenies |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:37 | |
| Because they start their match at "Love All" |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:34 | |
| Best Mission for leveling: [{0}] |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:106 | |
| Best Relic Mission: {0} \| {1} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:165 | |
| Best Score Per Minute |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1312 | |
| Best Time: --:--:-- |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:355 | |
| Best Time: {0} |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:350 | |
| Beta, might not work |  | UI text (disabled) \| ICE\Ui\MainUi\Settings\TravelSettings.cs:126 | |
| between missions — enable the multi-class setting to allow switching classes for these as well. |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:52 | |
| Black Mage |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:43; ICE\Ui\MainUi\Settings\Character_Settings.cs:1057 | |
| Blacksmith (BSM) |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:65 | |
| Blessed / Kings Yield I |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:659 | |
| Blessed / Kings Yield II |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:603 | |
| Boon Scoring |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:37 | |
| Botanist (BTN) |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:73 | |
| Bountiful Yield II / Bountiful Harvest II |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:768 | |
| Brazen Power |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:109 | |
| Bronze |  | Table column \| Radio button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:190; ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:132 | |
| Bronze Requirement |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:202 | |
| Bronze: 1 Item |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:462 | |
| Browse... |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:131 | |
| BSM | BSM | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:26; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:27; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:12; ICE\Ui\MainUi\Settings\Misc_Settings.cs:128 | |
| BTN | BTN | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:34; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:20; ICE\Ui\MainUi\Settings\Misc_Settings.cs:130 | |
| But I know there's going to be people who enable this and don't read, so it's a tehe. |  | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:325 | |
| Buy |  | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:219 | |
| Buy 1 Item |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:129; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:211 | |
| Buy At Amount |  | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:35 | |
| Buy Drones |  | Checkbox \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:24 | |
| Buy Item |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:60 | |
| Buy Items |  | Checkbox \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:29 | |
| Buy Items from shop |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:72 | |
| Buy Max |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:135; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:217 | |
| Buy: Will buy X amount of those items, as it buys it from the vendor, the number will decrease until it hits 0. |  | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:44 | |
| Buying from shop throttle |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:137; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:219 | |
| C and above |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:45 | |
| Carpenter (CRP) |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:64 | |
| Category |  | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:72 | |
| Chain + Boon Scoring |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:38 | |
| Chained Gather Scoring |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:454 | |
| Chained Scoring |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:36 | |
| Change mode |  | UI text \| ICE\Ui\OverlayWindow.cs:131 | |
| Change to gamba |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:127 | |
| Character Settings |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:112 | |
| Character Specific |  | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:53 | |
| Class |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:32 | |
| Class Exp |  | Table column \| ICE\Ui\Window_ExternalDetails.cs:264 | |
| Class Progress |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:103; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:151 | |
| Class Progress: All |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:725 | |
| Class Progress: Icon Preview |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:699 | |
| Class Score |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:811; ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:12 | |
| Class Score: |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:171 | |
| Class Selection |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:50 | |
| Class Selection Table |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:52 | |
| Class Swap |  | Section header \| ICE\Ui\MainUi\Settings\Character_Settings.cs:958 | |
| ClassTracker |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:46 | |
| Clear |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:41; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionText.cs:25 | |
| Clear All |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:375 | |
| Clear All Selections |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:404 | |
| Clear Profile |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1293 | |
| Clear shopping list |  | Button \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:93 | |
| Clear stored scores |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:121 | |
| Clear Task |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:256 | |
| Click Nearest Collection Point |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:303 | |
| Click Nearest EventObject |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:291 | |
| Click to override mount for this character |  | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:803 | |
| Click to override this setting for this character |  | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:100; ICE\Ui\MainUi\Settings\Character_Settings.cs:122 | |
| Collected Individual |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:88 | |
| Collected Total |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:94 | |
| Column 0 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:27 | |
| Column 1 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:28 | |
| Column 10 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:37 | |
| Column 11 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:38 | |
| Column 12 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:39 | |
| Column 13 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:40 | |
| Column 14 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:41 | |
| Column 15 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:42 | |
| Column 16 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:43 | |
| Column 17 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:44 | |
| Column 2 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:29 | |
| Column 3 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:30 | |
| Column 4 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:31 | |
| Column 5 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:32 | |
| Column 6 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:33 | |
| Column 7 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:34 | |
| Column 8 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:35 | |
| Column 9 |  | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:36 | |
| Command |  | Table column \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:260 | |
| Completed: |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:193 | |
| Completion |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:222 | |
| Completion Stats |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:115; ICE\Ui\Window_ExternalDetails.cs:414 | |
| Cone Color Editor |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:221 | |
| Confirm |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:30 | |
| Copied {0} fishing missions to clipboard! |  | Tooltip \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:111 | |
| Copy Auxesia CSV |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:79 | |
| Copy current set |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:65 | |
| Copy Flag |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:366 | |
| Copy Ids |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionText.cs:54 | |
| Copy Info |  | Button \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:178 | |
| Copy Item List |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:76; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:162 | |
| Copy Logs |  | Button \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:55 | |
| Copy logs to clipboard |  | Button \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:41 | |
| Copy Missing CSV |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:57 | |
| Copy Scores |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:51 | |
| Copy Selected |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:32 | |
| Copy Selected Profile |  | Button \| ICE\Ui\MainUi\Settings\GatherSettings.cs:1013 | |
| Copy to Clipboard |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:500 | |
| Copy Vector2 |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:42 | |
| Copy Vector3 |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:47 | |
| Cordial Busy |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:362 | |
| Cordial Check |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:304 | |
| Cordial Checkers |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:308 | |
| Cordial Settings |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:197 | |
| Cordial Test |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:133 | |
| Cosmic Agenda |  | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Tips.cs:27; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:84; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:97; ICE\Ui\MainUi\SelectableSidebar.cs:40; ICE\Ui\OverlayWindow.cs:165 | |
| Cosmic Agenda Mode |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:422 | |
| Cosmic Agenda Table |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:439 | |
| Cosmic Class Info |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:12 | |
| Cosmic Helper |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:37 | |
| Cosmo Crafting Log |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:106 | |
| Cosmo Credits |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:10 | |
| Cosmo Gear Shop |  | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:149 | |
| Cosmo Materia Shop |  | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:127 | |
| Cosmo Pouch |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:99 | |
| CosmocreditMateriaPopup |  | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:120 | |
| Cosmocredits |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:134 | |
| Cosmocredit_MountArmorPopup |  | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:142 | |
| Cost |  | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:215 | |
| Could not find a contiguous arc of reachable angles. |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:536 | |
| Count |  | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:70 | |
| Craft Details |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:108 | |
| Craft Item Settings |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1409 | |
| Craft Settings: Recipies |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1186; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1189; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:532; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:535 | |
| Crafting |  | Section header \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:19 | |
| Crafting Return Spot |  | Section header \| ICE\Ui\MainUi\Settings\TravelSettings.cs:237 | |
| Create files |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:367 | |
| Create waypoint list |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:54 | |
| Credit / Planetary Credits / Token farming |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:48 | |
| Credit Shopping |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:100 | |
| Credits |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:865 | |
| Critical Area |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:247 | |
| Critical Location |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:35 | |
| Critical Mission |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:459 | |
| Critical Missions |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:56 | |
| Critical Value: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:70 | |
| Critical: Allow All Classes |  | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:258 | |
| CRP | CRP | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:25; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:27; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:11; ICE\Ui\MainUi\Settings\Misc_Settings.cs:128 | |
| CS: Available Missions |  | UI string \| ICE\Ui\DebugWindow.cs:74 | |
| CS: Missions Avaialble |  | UI string \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:37 | |
| CS: Tiemr Info |  | UI string \| ICE\Ui\DebugWindow.cs:73 | |
| CUL | CUL | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:32; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:18; ICE\Ui\MainUi\Settings\Misc_Settings.cs:129 | |
| Culinarian (CUL) |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:71 | |
| Currency Amount: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:23 | |
| Current |  | Table column \| ICE\Ui\OverlayWindow.cs:75 | |
| Current Agenda |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:48 | |
| Current Bait |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:80 | |
| Current Collectability: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:55 | |
| Current location: {0} \| Currency Amount: {1} |  | UI text \| ICE\Ui\MainUi\Settings\GambaWheel.cs:58; ICE\Ui\MainUi\Settings\GambaWheel.cs:135 | |
| Current Mission: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:38 | |
| Current Mission: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:59; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:204 | |
| Current planet has no stored fishing holes in the sheets. (Might need to be added?) |  | UI text \| ICE\Ui\MainUi\Settings\TravelSettings.cs:342 | |
| Current pos: {0} \| {1} \| {2} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NavmeshTesting.cs:27 | |
| Current Score: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:46 | |
| Current Score: {0} |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:599 | |
| Current Stage |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:35 | |
| Current State |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:53 | |
| Current State: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:18 | |
| Current task running: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:17 | |
| Current Territory/ZoneId: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:53 | |
| Current Tool XP |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:160 | |
| Current waypoint list count: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:46 | |
| Current XP |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:131; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:26 | |
| Current: {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:749 | |
| Currently have: {0} Grade 8 Dark Matter |  | UI text \| ICE\Ui\MainUi\Settings\Character_Settings.cs:262 | |
| Currently Selected: {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1229; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:473 | |
| Currently there isn't a way to stop artisan from crafting, it's been requested |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:979 | |
| Custom Is Busy: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:170 | |
| D and above |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:45 | |
| Dark Knight |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:20; ICE\Ui\MainUi\Settings\Character_Settings.cs:1048 | |
| DEBUG TEST |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:292 | |
| Default |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1712; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1768; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1825; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1874; ICE\Ui\MainUi\Settings\Character_Settings.cs:472; ICE\Ui\MainUi\Settings\Character_Settings.cs:507; ICE\Ui\MainUi\Settings\Character_Settings.cs:549; ICE\Ui\MainUi\Settings\Character_Settings.cs:584; ICE\Ui\MainUi\Settings\Character_Settings.cs:626; ICE\Ui\MainUi\Settings\Character_Settings.cs:657; ICE\Ui\MainUi\Settings\Character_Settings.cs:695; ICE\Ui\MainUi\Settings\Character_Settings.cs:726 | |
| Delay |  | Table column \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:261 | |
| Delay Post Relic Turnin |  | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:79 | |
| Delete |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:258 | |
| Delete Profile |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:339 | |
| Delete Selected Profile |  | Button \| ICE\Ui\MainUi\Settings\GatherSettings.cs:357 | |
| Depending on what you want / what your goal is, these all serve all different functions. |  | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:13 | |
| Description |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:224 | |
| Description: {0} |  | UI text (wrapped) \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:319 | |
| Destination |  | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:151 | |
| Destination Log Viewer |  | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:147 | |
| Destination Logs |  | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:28 | |
| Detailed Class View |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:44 | |
| Detailed Mission Info |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:126 | |
| Dev Favorites |  | Section header \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:309 | |
| Dictionary code copied to clipboard! |  | Chat message \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:503 | |
| Disable Autohook |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:115 | |
| Disable Endurance |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:207 | |
| Disable HUD Clipping |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:154 | |
| Disable Pathfinding to Red Alerts |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:162 | |
| Dismount Target Range |  | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:875; ICE\Ui\MainUi\Settings\Character_Settings.cs:911 | |
| Dismount_Radius Circle |  | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:931 | |
| Distance |  | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:152 | |
| Distance before hub return is used (yalms) |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:155 | |
| Distance to nearest: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:297; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:309 | |
| Distance: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:46; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:76 | |
| Do you want to buy drones? If yes, enable this |  | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:30 | |
| Do you want to run the automated drone finding? If yes, enable this |  | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:68 | |
| Don't do hub activities when a red alert is active |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:169 | |
| Drawing Mission Table |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionsV3.cs:56; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:489 | |
| Drone Ready: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:118 | |
| Drone Search |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:157 | |
| Dronebit Settings |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:104 | |
| Dronebits |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:162 | |
| Dropdown Detail |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1500 | |
| Dropdown Selection |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1501 | |
| Dual Class |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:39 | |
| Durability: {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1700 | |
| E8 ?? ?? ?? ?? 84 C0 75 58 FF C3 |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishingRaycast.cs:21 | |
| Each planet has a dedicated set of missions are deemed the most "Optimal" when it comes to farming score. |  | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\helpSelect_Tips.cs:75 | |
| Editing Spot {0}: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:273 | |
| Enable |  | Checkbox \| ICE\Ui\MainUi\Settings\GatherSettings.cs:488; ICE\Ui\MainUi\Settings\GatherSettings.cs:530; ICE\Ui\MainUi\Settings\GatherSettings.cs:574; ICE\Ui\MainUi\Settings\GatherSettings.cs:620; ICE\Ui\MainUi\Settings\GatherSettings.cs:676; ICE\Ui\MainUi\Settings\GatherSettings.cs:732; ICE\Ui\MainUi\Settings\GatherSettings.cs:784; ICE\Ui\MainUi\Settings\GatherSettings.cs:841; ICE\Ui\MainUi\Settings\GatherSettings.cs:887; ICE\Ui\MainUi\Settings\GatherSettings.cs:933; ICE\Ui\MainUi\Settings\GatherSettings.cs:978 | |
| Enable Auto Gamba |  | Checkbox \| ICE\Ui\MainUi\Settings\GambaWheel.cs:18 | |
| Enable Auto Gamba Wheel |  | Checkbox \| ICE\Ui\MainUi\Settings\GambaWheel.cs:96 | |
| Enable AutoHook |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:111 | |
| Enable Dummy XP |  | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:69 | |
| Enabled |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:252 | |
| Enabled Mission Table |  | UI string \| ICE\Ui\OverlayWindow.cs:320 | |
| Enabling this will make it to where pandora's cordial feature won't be auto-paused. |  | Help marker \| ICE\Ui\MainUi\Settings\GatherSettings.cs:187 | |
| Enabling this will show you all weather/timed/sequence missions that you can grind, |  | Help marker \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:253 | |
| End Hour |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_TimeWeather.cs:16 | |
| Error: Please specify an export path |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:506 | |
| Estimated Score Per Hour: |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:367 | |
| Event Markers |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:24; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:93 | |
| EX and above |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:45 | |
| EX. /ice add 10 155 185 |  | UI string \| ICE\ICE.cs:315 | |
| Except for hub activities |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:142 | |
| Exp Grinding |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:47 | |
| Exp Rewards |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:262 | |
| ExpBar |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:807 | |
| Expected to start with: AH4_ |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:105 | |
| Expedition Log |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:41 | |
| Expedition: Class Selection |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:36 | |
| Expert Craft |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1628 | |
| Expert Craft Settings |  | Table column \| ICE\Ui\MainUi\Settings\Character_Settings.cs:394 | |
| Expert Craft: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:71; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:104 | |
| Expert Crafts |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:452 | |
| Expert Recipe Solver |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1529; ICE\Ui\MainUi\Settings\Character_Settings.cs:320 | |
| Expires in {0} |  | UI text \| ICE\Ui\OverlayWindow.cs:450 | |
| Export |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:216 | |
| Export All Fishing Data |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:56 | |
| Export All Presets |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:82 | |
| Export CSV |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:160 | |
| Export Fishing Missions |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:94 | |
| Export Missing CSV |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:149 | |
| Export Selected Flag |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:66 | |
| Export Selected Mission |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:88 | |
| Export Selected to Dictionary |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:397 | |
| Export to Clipboard |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:258 | |
| Exported Icon Dictionary |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:498 | |
| Extract Spiritbond on Gather |  | Checkbox \| ICE\Ui\MainUi\Settings\GatherSettings.cs:179 | |
| Face toward spot |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:190 | |
| Failed to deserialize profile |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:86; ICE\Ui\MainUi\Settings\GatherSettings.cs:133 | |
| Fan Height |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:335 | |
| Field Mastery \| Sharp Vision I |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:916 | |
| Field Mastery \| Sharp Vision II |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:870 | |
| Field Mastery \| Sharp Vision III |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:824 | |
| Fill Both |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MoonRecipe.cs:25 | |
| Fill HQ |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MoonRecipe.cs:19 | |
| Fill NQ |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MoonRecipe.cs:13 | |
| Filter by current job only |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:116 | |
| Filters which planets appear in the<br>mission list and the overlay. |  | UI text \| ICE\Ui\MainUi\SelectableSidebar.cs:60 | |
| Find Mission |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:252 | |
| Finding drone locations is turned off, so we're just going to ignore this. If you want to run this, please enable it |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:168 | |
| First Available Fishing Spot: {0}, {1}, {2} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:189 | |
| Fish Editor \| Window Selector |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:21 | |
| Fish Item Info |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:46 | |
| Fisher (FSH) |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:74 | |
| Fishing Editor Table |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:82 | |
| Fishing flag data for Zone {0} at ({1}, {2}) exported to clipboard! |  | Chat message \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:70 | |
| Fishing Hole Editor |  | Table column \| UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:85; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:121 | |
| Fishing Hole Selector |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:84 | |
| Fishing Info |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:15 | |
| Fishing Location Selector |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:91 | |
| Fishing Position |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:279 | |
| Fishing profile: {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1264; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:504 | |
| Fishing raycast initialized successfully |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishingRaycast.cs:22 | |
| Fishing Settings |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1258 | |
| Flag |  | Table column \| Button \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:42; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:355 | |
| Flora Mastery \| Clear Vision [Temp] |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:962 | |
| Font Test |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:356 | |
| Food |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1705; ICE\Ui\MainUi\Settings\Character_Settings.cs:464 | |
| Food Item |  | Table column \| ICE\Ui\MainUi\Settings\GatherSettings.cs:274 | |
| Food Item Selection |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:272 | |
| Food Selection |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:257; ICE\Ui\MainUi\Settings\GatherSettings.cs:270 | |
| Food Settings |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:232 | |
| Food [HQ] |  | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:142 | |
| Food [NQ] |  | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:147 | |
| For botanist/miner/fisher |  | UI text \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:24 | |
| For BTN/MIN, this will gather the non-collectable item |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1014 | |
| For fisher only |  | UI text \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:27 | |
| For most of you this would be fine, this is really only here if you don't know what to apply for each one. |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:1048 | |
| for your current class — you pick what you want done, and it handles the rest. |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:44 | |
| Force OOM Main |  | Checkbox \| ICE\Ui\MainUi\Settings\DebugTab.cs:18 | |
| Force OOM Sub |  | Checkbox \| ICE\Ui\MainUi\Settings\DebugTab.cs:19 | |
| from automating the gathering and crafting process, to the buying of shop items or spending those planetary credits away. |  | UI string \| ICE\Ui\InfoWindow.cs:45 | |
| FSH | FSH | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:35; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:21; ICE\Ui\MainUi\Settings\Misc_Settings.cs:130 | |
| Gamba Delay |  | UI string \| ICE\Ui\MainUi\Settings\GambaWheel.cs:39; ICE\Ui\MainUi\Settings\GambaWheel.cs:116 | |
| Gamba Item Tabs |  | UI string \| ICE\Ui\MainUi\Settings\GambaWheel.cs:147 | |
| Gamble Between Runs |  | Checkbox \| ICE\Ui\MainUi\Settings\GambaWheel.cs:31; ICE\Ui\MainUi\Settings\GambaWheel.cs:109 | |
| Gambling Settings |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:101 | |
| Gather Fan |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:343 | |
| Gather Item [{0}] |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:31 | |
| Gather Profiles |  | UI text \| ICE\Ui\MainUi\Settings\GatherSettings.cs:352 | |
| Gather Route Editor Table |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:64 | |
| Gather x Amount |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:34 | |
| Gather [{0}] |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:219 | |
| Gatherer's Boons Scoring |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:455 | |
| Gathering |  | Section header \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:23 | |
| Gathering Fan Selection |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:94 | |
| Gathering Profile |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:109 | |
| Gathering Profile Settings |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:321 | |
| gathering routes |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:200 | |
| Gathering Settings |  | Table column \| ICE\Ui\MainUi\Settings\GatherSettings.cs:324 | |
| Gathering Setup |  | Section header \| ICE\Ui\InfoWindow.cs:51 | |
| Gathering Zone |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:230 | |
| Gearset Viewer |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Gearsets.cs:46 | |
| Generate Fan from Navmesh |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:302 | |
| Get Active List |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Aethernet.cs:61 | |
| Get current hub forecast |  | Button \| ICE\Ui\MainUi\Settings\DebugTab.cs:21 | |
| Global Artisan Settings |  | Section header \| ICE\Ui\MainUi\Settings\Character_Settings.cs:270 | |
| Global Character Settings |  | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:27 | |
| Global setting — applies to all characters. |  | Tooltip \| ICE\Ui\MainUi\Settings\Character_Settings.cs:890; ICE\Ui\MainUi\Settings\Character_Settings.cs:895; ICE\Ui\MainUi\Settings\Character_Settings.cs:905; ICE\Ui\MainUi\Settings\Character_Settings.cs:917 | |
| Go buy items when you reach |  | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:56 | |
| Goal: {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:750 | |
| Gold |  | Table column \| Radio button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:192; ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:124 | |
| Gold Completion Grind |  | UI string \| Radio button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:79; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:92; ICE\Ui\MainWindow.cs:131; ICE\Ui\OverlayWindow.cs:166 | |
| Gold Completion Mode |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:421; ICE\Ui\MainWindow.cs:171 | |
| Gold Requirement |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:220 | |
| Gold Sequence |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:809 | |
| Gold: 3 Items |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:460 | |
| Goldsmith (GSM) |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:67 | |
| Good for one off buys, or something that you only need a particular amount of |  | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:45 | |
| GSM | GSM | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:28; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:27; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:14; ICE\Ui\MainUi\Settings\Misc_Settings.cs:128 | |
| Has Tokens |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:479 | |
| Have |  | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:214 | |
| Having this enabled means it will use the default preset that is included with the plugin for autohook. |  | Help marker \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1272; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:512 | |
| Hehe |  | UI text \| ICE\Ui\MainWindow.cs:97 | |
| Help |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:26 | |
| Here's what each of the following does: |  | UI text \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:41 | |
| Hey! You need to update artisan to use this mode, please update to at minimum: |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:182 | |
| Hey! You seem to not have any standardard missions enabled on the planet/moon you're currently on. |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:649 | |
| Hey! Your version of autohook is not currently supported on this planet |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:214 | |
| Hey! {0} is not supported for leveling yet. |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:195 | |
| Hi! Welcome to Ice's Cosmic Exploration [Short form, I.C.E.] |  | UI text \| ICE\Ui\InfoWindow.cs:42 | |
| Hide Completed |  | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:159 | |
| Hide tab list |  | Tooltip \| ICE\Ui\DebugWindow.cs:32 | |
| Hide Unsupported Missions |  | Checkbox \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:40 | |
| High Collectibility: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:87 | |
| Highlight EX+ token weathers |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:102 | |
| Highlight Visible Missions |  | Checkbox \| ICE\Ui\MainUi\Settings\DebugTab.cs:61 | |
| Hold Control to delete profile |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:344 | |
| Hold Shift + Control |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:344 | |
| Hold shift to allow applying |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:332; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1492 | |
| Honestly, just wanted to say thank you for using my plugin, you're appreciated <3 |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:45 | |
| How do you save a drowning pirate? |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:39 | |
| HQ Regular Cordial |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:314 | |
| HQ Watered Cordial |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:316 | |
| Hub Activities |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:98 | |
| Hud: Gather Collectable |  | UI string \| ICE\Ui\DebugWindow.cs:53 | |
| Hud: Item Exchange |  | UI string \| ICE\Ui\DebugWindow.cs:54 | |
| Hud: Mission |  | UI string \| ICE\Ui\DebugWindow.cs:49 | |
| Hud: Mission Info |  | UI string \| ICE\Ui\DebugWindow.cs:50 | |
| Hud: Moon Main |  | UI string \| ICE\Ui\DebugWindow.cs:48; ICE\Ui\DebugWindow.cs:96 | |
| Hud: Moon Recipe |  | UI string \| ICE\Ui\DebugWindow.cs:52 | |
| Hud: Wheel of fortune! |  | UI string \| ICE\Ui\DebugWindow.cs:51 | |
| I'll get to it when my world gets to it o/ |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:286 | |
| Ice Log Tabs |  | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:21 | |
| ICE Overlay |  | Window title \| ICE\Ui\OverlayWindow.cs:18 | |
| ICE {0} Debugger |  | Window title \| ICE\Ui\DebugWindow.cs:17 | |
| Ice's Cosmic Exploration - Info |  | Window title \| ICE\Ui\InfoWindow.cs:19 | |
| Ice's Cosmic Exploration {0} |  | Window title \| ICE\Ui\MainWindow.cs:23 | |
| Ice's Cosmic Exploration \| Mission Details |  | Window title \| ICE\Ui\Window_ExternalDetails.cs:66 | |
| Icon |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:124; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:480; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:54; ICE\Ui\MainUi\Settings\GambaWheel.cs:158; ICE\Ui\MainUi\Settings\Priority_Settings.cs:53; ICE\Ui\MainUi\Settings\Priority_Settings.cs:123; ICE\Ui\MainUi\Settings\Priority_Settings.cs:206; ICE\Ui\OverlayWindow.cs:322 | |
| Icon ID |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:96 | |
| Icons |  | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:129; ICE\Ui\MainUi\Settings\ShoppingTab.cs:151 | |
| Id | Id | Table column \| UI string \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:40; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:182; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:59; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Gearsets.cs:48; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:151; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:255; ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:10 | |
| ID: | ID: | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Aethernet.cs:72 | |
| Id: {0} |  | UI text \| Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:60; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:395; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:76; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:111; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:68 | |
| If set to 0, it'll never use a cordial even with it enabled (because... you'll never have 0 gp) |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:229 | |
| If stuck during nav movement: |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:190 | |
| If you are, it will automatically start as if you had pressed the start button yourself |  | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:190 | |
| If you just want to focus one specific class, set this to false |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:255 | |
| If you want something more complex, just make an SND script at that point. And have this run that script post lol. |  | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:243 | |
| If you want to let it auto select the wheels and gamba, enable this. If you want to not auto run when you're running the gamble wheel, disable this. |  | Help marker \| ICE\Ui\MainUi\Settings\GambaWheel.cs:23; ICE\Ui\MainUi\Settings\GambaWheel.cs:101 | |
| If you would like to auto setup gathering to where all missions have their gathering buffs to what I would recommend |  | UI text \| ICE\Ui\InfoWindow.cs:54 | |
| If you would like to use one that you already have in autohook, you can un-checkmark this and type the name of it below |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1273; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:513 | |
| If you you uncheck this, YOU WILL JOIN random party invites. |  | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:30 | |
| If you're high enough level to need the next rank category but haven't unlocked it yet |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:65 | |
| If you're okay with this, hold left shift and apply |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:1049 | |
| Ignore Manual Mode |  | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:93 | |
| Ignore non-Cosmic prompts |  | Checkbox \| ICE\Ui\MainUi\Settings\SafetySettings.cs:23 | |
| ImGui Testing |  | UI string \| ICE\Ui\DebugWindow.cs:83 | |
| Import |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:64; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:269 | |
| Import Missions |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:408 | |
| Import New Preset |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:95 | |
| Import Selected Profile |  | Button \| ICE\Ui\MainUi\Settings\GatherSettings.cs:1019 | |
| Increase collectability |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:126 | |
| Increase Gathering & Crafting Speed |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:318 | |
| Increase the Integrity by 1 |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:726 | |
| Increases item yield from Gatherer's Boon by 1 |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:569 | |
| Increases the gather chance by 15% |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:880; ICE\Ui\MainUi\Settings\GatherSettings.cs:972 | |
| Increases the gather chance by 5% |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:926 | |
| Increases the gather chance by 50% |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:834 | |
| Increases the number of items obtained when gathering by 1 |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:670 | |
| Increases the number of items obtained when gathering by 2 |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:614; ICE\Ui\MainUi\Settings\GatherSettings.cs:778 | |
| Info |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:806; ICE\Ui\Window_ExternalDetails.cs:129 | |
| Infrastructor |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:32 | |
| Initiate |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:159; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:424 | |
| Input below a list of commands that you would like to run after a run has been completed. |  | UI text (wrapped) \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:241 | |
| Install {0} |  | Button \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:74 | |
| Install {0} Repo |  | Button \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:53 | |
| Invalid import string. |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:282 | |
| Invalid import string: Missing prefix |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:74; ICE\Ui\MainUi\Settings\GatherSettings.cs:122 | |
| Invalid import string: Not valid base64 |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:105; ICE\Ui\MainUi\Settings\GatherSettings.cs:163 | |
| Inverse Priority (Watered -> Regular -> Hi) |  | Checkbox \| ICE\Ui\MainUi\Settings\GatherSettings.cs:211 | |
| IPC Testing |  | UI string \| ICE\Ui\DebugWindow.cs:77 | |
| IPC: Artisan |  | UI string \| ICE\Ui\DebugWindow.cs:93 | |
| Is ICE Running? \| {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:121 | |
| Is Mission Timed out |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:61 | |
| It appears that you have on of the following enabled |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:139 | |
| It scans all available missions, evaluates the experience each one provides, and picks whichever |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:62 | |
| Item Count: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionsV3.cs:24 | |
| Item Details |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1499 | |
| Item Exchange Window |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:25; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:98; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:180 | |
| Item ID: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:47 | |
| Item ID: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:68; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:101 | |
| Item Integrity: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:63 | |
| Item Name: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:39 | |
| Item Name: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:66; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:99 | |
| ItemID: {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1618 | |
| Items in left wheel |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:40 | |
| Items on person: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:79 | |
| Job |  | Table column \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:39; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:186; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:60; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:349; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:444; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:253; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:727 | |
| Job Priority Order |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:203 | |
| Job Selection |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:474; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:476 | |
| Job(s) |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:179 | |
| Job: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:51 | |
| JobID |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Gearsets.cs:50 | |
| JobId: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:52 | |
| JobID: {0} \| HasUnlocked: {1} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:173 | |
| JobId: {0} \| Unlocked: {1} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:158 | |
| Jobs |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:183 | |
| Jump |  | Radio button \| ICE\Ui\MainUi\Settings\TravelSettings.cs:207 | |
| Keep |  | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:218 | |
| Keep "A Rank" missions and below |  | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:275; ICE\Ui\MainUi\Settings\Misc_Settings.cs:209 | |
| Keep Buying |  | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:220 | |
| Keep Buying: Once the other 2 have been met (Keep/Buy), it will constantly buy this item if it has the credits to do so. |  | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:46 | |
| Keep this much Cosmocredits |  | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:63 | |
| Keep: Will buy up to that many items to make sure that you have in your inventory. This count doesn't go down between runs. |  | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:42 | |
| Key |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:27; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:23; ICE\Ui\Debug_Tabs\Debug_Tables\Table_TimeWeather.cs:13 | |
| Key / RecipeId: {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1617 | |
| Kind |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:863; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:254; ICE\Ui\MainUi\Settings\ShoppingTab.cs:216 | |
| Knock knock |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:47 | |
| Largest Fish Scored |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:456 | |
| Leatherworker (LTW) |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:68 | |
| Left wheel select |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:18 | |
| Lettuce in |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:51 | |
| Level |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:62; ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:71 | |
| Leveling Grind |  | UI string \| Radio button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:74; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:87; ICE\Ui\MainWindow.cs:125; ICE\Ui\MainWindow.cs:154; ICE\Ui\OverlayWindow.cs:164 | |
| Leveling Mode |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:419 | |
| Leveling Table |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_LevelingMissions.cs:11 | |
| Limited Nodes |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:33 | |
| Limited Supplies |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:449 | |
| List of Visible Missions |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:21 | |
| Load Mission Preset |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:363 | |
| Location: {0}, {1} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:143 | |
| Log copied to clipbard |  | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:184 | |
| Long answer: Honestly, this was a cumbersome system in itself. And with square deciding to not continue on with dual crafting missions going into the 2nd moon, I figured it would be better to just tie it into the scoring system. You realistically only need: |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:459 | |
| Lottery addon is visible! |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:16 | |
| LTW | LTW | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:29; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:15; ICE\Ui\MainUi\Settings\Misc_Settings.cs:129 | |
| Lunar Credits |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:10 | |
| Lv |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_LevelingMissions.cs:14 | |
| Lv. 10-49 |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:273 | |
| Lv. 50-89 |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:283 | |
| Lv. 90-99 |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:293 | |
| Macro Name |  | Input label \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1686 | |
| Main Item 1 |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:208 | |
| Main Item 2 |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:210 | |
| Main Item 3 |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:212 | |
| Main-Craft 1 |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:25 | |
| Main-Craft 2 |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:27 | |
| Main-Craft 3 |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:29 | |
| Mainly used for missions where you can chain durability refresh |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:641; ICE\Ui\MainUi\Settings\GatherSettings.cs:697 | |
| Manipulation Check |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:142 | |
| Manual |  | Button \| UI text \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:162; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1817; ICE\Ui\MainUi\Settings\Character_Settings.cs:618 | |
| Map Location |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:12 | |
| Map Radius |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_MapTesting.cs:43 | |
| Map X (Sheet) |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_MapTesting.cs:37 | |
| Map Y (Sheet) |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_MapTesting.cs:40 | |
| Marker move task |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:118 | |
| Master Settings |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:955 | |
| Master Settings: Popup |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:952 | |
| Max Collectibility: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:95 | |
| Max Distance |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:329 | |
| Max use |  | UI text \| Input label \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1926; ICE\Ui\MainUi\Settings\GatherSettings.cs:502; ICE\Ui\MainUi\Settings\GatherSettings.cs:544; ICE\Ui\MainUi\Settings\GatherSettings.cs:588; ICE\Ui\MainUi\Settings\GatherSettings.cs:644; ICE\Ui\MainUi\Settings\GatherSettings.cs:700; ICE\Ui\MainUi\Settings\GatherSettings.cs:753; ICE\Ui\MainUi\Settings\GatherSettings.cs:798; ICE\Ui\MainUi\Settings\GatherSettings.cs:855; ICE\Ui\MainUi\Settings\GatherSettings.cs:901; ICE\Ui\MainUi\Settings\GatherSettings.cs:947; ICE\Ui\MainUi\Settings\GatherSettings.cs:992 | |
| Max XP |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:30 | |
| Maximum Drones |  | Input label \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:48 | |
| Mech |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:18 | |
| Message |  | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:73 | |
| Meticulous Power |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:116 | |
| Mid Collectibility: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:79 | |
| MIN | MIN | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:33; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:19; ICE\Ui\MainUi\Settings\Misc_Settings.cs:130 | |
| Min Collectibility: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:71 | |
| Min Distance |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:322 | |
| Min mission rank for cordials |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:201 | |
| Min mission rank for food |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:236 | |
| Miner (MIN) |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:72 | |
| Minimum Gp for Usage |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:495; ICE\Ui\MainUi\Settings\GatherSettings.cs:537; ICE\Ui\MainUi\Settings\GatherSettings.cs:581; ICE\Ui\MainUi\Settings\GatherSettings.cs:627; ICE\Ui\MainUi\Settings\GatherSettings.cs:683; ICE\Ui\MainUi\Settings\GatherSettings.cs:739; ICE\Ui\MainUi\Settings\GatherSettings.cs:791; ICE\Ui\MainUi\Settings\GatherSettings.cs:848; ICE\Ui\MainUi\Settings\GatherSettings.cs:894; ICE\Ui\MainUi\Settings\GatherSettings.cs:940; ICE\Ui\MainUi\Settings\GatherSettings.cs:985 | |
| Minimum GP to start mission |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:442 | |
| Minimum Grade 8 Dark Matter |  | Input label \| ICE\Ui\MainUi\Settings\Character_Settings.cs:191; ICE\Ui\MainUi\Settings\Character_Settings.cs:256 | |
| Minimum Mounting Range |  | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:868; ICE\Ui\MainUi\Settings\Character_Settings.cs:899 | |
| Minimum Node Durability for Usage |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:746 | |
| Mininum credits to keep |  | UI string \| ICE\Ui\MainUi\Settings\GambaWheel.cs:25; ICE\Ui\MainUi\Settings\GambaWheel.cs:103 | |
| Minumum Items To Gather |  | UI text \| ICE\Ui\MainUi\Settings\GatherSettings.cs:806 | |
| Misc Settings |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:113 | |
| Mission |  | Button \| Table column \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:11; ICE\Ui\OverlayWindow.cs:323 | |
| Mission Atributes |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:303 | |
| Mission Commands |  | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:258 | |
| Mission Completion Status Window |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:160 | |
| Mission Details |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:24 | |
| Mission Details Master Tabs |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:98 | |
| Mission ID |  | Table column \| UI string \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:26; ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:51 | |
| Mission Info List |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:21 | |
| Mission Log |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:38 | |
| Mission Name |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:18; ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:28; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:185; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:24; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:257 | |
| Mission Priority |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:110 | |
| Mission Priority Order |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:13 | |
| Mission Priority Settings |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:11 | |
| Mission Radius |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:34 | |
| Mission Reward Sheet |  | UI string \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:23 | |
| Mission Score Required |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:458 | |
| Mission Search Priority |  | UI text \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:106 | |
| Mission Selection |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:32 | |
| Mission Selection Child |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:30 | |
| Mission Selection Info |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:38 | |
| Mission Selection Window |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:52 | |
| Mission Selector |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:23 | |
| Mission Settings |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:240 | |
| Mission Settings: Popup |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:242; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:244 | |
| Mission Setup |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:39 | |
| Mission Timer: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:388 | |
| Mission Timers |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:406 | |
| Mission Type |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:411 | |
| Mission Type Table |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:120 | |
| Mission Viewer |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:137 | |
| Mission: |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:92 | |
| Mission: [{0}] {1} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1228 | |
| Mission: {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1193; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:539 | |
| MissionID |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:17 | |
| MM Recipe Usage |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:179 | |
| MM Step Use |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:178 | |
| Mode Select |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:352; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:447 | |
| Mode Select \| Select Mode Window |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:100; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:102; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:113; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:115 | |
| Mode Selection |  | UI string \| Icon button \| ICE\Ui\MainUi\HelpFolder\helpSelect_Tips.cs:26; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:98; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:111 | |
| Mode Selection Info |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:15 | |
| Moon Mission Information Table |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:180 | |
| Mount |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:176 | |
| Mount Options |  | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:817; ICE\Ui\MainUi\Settings\Character_Settings.cs:950 | |
| Mount Roulette |  | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:939 | |
| Mount Settings |  | Section header \| ICE\Ui\MainUi\Settings\Character_Settings.cs:771 | |
| Mount: {0} |  | UI text \| ICE\Ui\MainUi\Settings\Character_Settings.cs:789; ICE\Ui\MainUi\Settings\Character_Settings.cs:812 | |
| Mount_Radius Circle |  | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:928 | |
| Move Item |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:389 | |
| Move To |  | Table column \| Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:35; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:53; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:116 | |
| Move to Flag |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:166 | |
| Move To Navmesh |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:148 | |
| Move To [Fan] |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:282 | |
| MoveTo Spot |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:34 | |
| ms stuck |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:225 | |
| Name |  | Table column \| Input label \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:41; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:63; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Gearsets.cs:49; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:32; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:125; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:223; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:481; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:55; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:367; ICE\Ui\MainUi\Settings\GambaWheel.cs:160; ICE\Ui\MainUi\Settings\ShoppingTab.cs:213; ICE\Ui\OverlayWindow.cs:324; ICE\Ui\Window_ExternalDetails.cs:128 | |
| Name: {0} |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:64 | |
| Name: {0} : {1} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:214 | |
| Name: {0} \| ID: {1} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:280 | |
| Name: {0} \| Id: {1} \| Amount: {2} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:43; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:49 | |
| Names |  | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:130; ICE\Ui\MainUi\Settings\ShoppingTab.cs:152 | |
| Nav Move To |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:277 | |
| Nav Position |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:291 | |
| Navmesh Testing |  | UI string \| ICE\Ui\DebugWindow.cs:79 | |
| Necessary Amount: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:69; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:102 | |
| Need Help? |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:164 | |
| Need to actually put the player info here. It got lost |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:37 | |
| Needed XP |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:138; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:28 | |
| Needs Unlocked |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1312 | |
| New Profile Name |  | Input label \| ICE\Ui\MainUi\Settings\GatherSettings.cs:331 | |
| Next |  | Button \| Table column \| ICE\Ui\MainUi\Settings\Character_Settings.cs:849; ICE\Ui\OverlayWindow.cs:76 | |
| Next Missions |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:741; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:586; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:911 | |
| Next Sequence: |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1347 | |
| Next Stage |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:42 | |
| No bait is equipped |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:99 | |
| No fishing missions found! |  | Tooltip \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:115 | |
| No Food Selected |  | UI text \| ICE\Ui\MainUi\Settings\GatherSettings.cs:262 | |
| No GatheringPoint targeted. |  | Chat message \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:334 | |
| No items in {0} shopping list |  | UI text (disabled) \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:202 | |
| No location set |  | UI text \| ICE\Ui\MainUi\Settings\TravelSettings.cs:269 | |
| No markers found! |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:80 | |
| No missing Auxesia MissionScores rows. |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:89 | |
| No missing rows — embedded CSV covers all missions with bronze scores. |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:67 | |
| No mission |  | UI text \| ICE\Ui\OverlayWindow.cs:220 | |
| No mission selected currently. Woops [{0}] |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:143 | |
| No reachable points found around this node. |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:500 | |
| No route file exist. Do you want to create one? |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:366 | |
| No score can be loaded |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:603 | |
| Node Durability For Usage |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:634; ICE\Ui\MainUi\Settings\GatherSettings.cs:690 | |
| Node Editor |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:215 | |
| Node Selection |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:180 | |
| Node Text: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:17 | |
| Node: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:274 | |
| None |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:306 | |
| Nophica's / Nald'thal's Tidings Buff |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:559 | |
| Not a valid autohook preset. |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:104 | |
| Not Completed |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:357 | |
| Note. I'm not responsible if you leave this on and get banned for it. I'm not one for leaving things at their pc, but people are watching always. Keep this in mind |  | UI string \| ICE\Ui\MainWindow.cs:169 | |
| Note: this mode does not swap planets for you. Each planet also has an exp cap: |  | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:67 | |
| Notes |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:260 | |
| NPC Box Viewer |  | UI string \| ICE\Ui\DebugWindow.cs:82 | |
| NPC Info Debugger |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:30 | |
| NQ Regular Cordial |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:315 | |
| NQ Watered Cordial |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:317 | |
| Number of entries: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:96 | |
| Object info |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:210 | |
| Oizyr Map Stuff |  | UI string \| ICE\Ui\DebugWindow.cs:90 | |
| Oizys   — Rank VI Max |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:70 | |
| ON TOP OF doing the normal missions for whichever class you start on. |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:254 | |
| Only enable this if you want plan on doing missions YOURSELF. AND NOT AUTOMATING IT. |  | Help marker \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:53 | |
| Only Enabled Missions |  | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:98 | |
| Only grab mission |  | Checkbox \| ICE\Ui\MainUi\Settings\DebugTab.cs:68 | |
| Only Missions Via IPC |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:122 | |
| Only turn in when the mission timer expires (keep gathering for max score). |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:442 | |
| Open Craft Settings |  | UI string \| Button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1167; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1184; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:530 | |
| Open ICE |  | UI text \| ICE\Ui\OverlayWindow.cs:120 | |
| Open Job Swap Settings |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:316 | |
| Open map position |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:125 | |
| Open mission details |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:341 | |
| Open plugin interface<br>/ice help - shows all commands<br>/ice clear - removes all missions<br>/ice stop - stops ICE<br>/ice start - Starts ICE<br>/ice add \| remove \| toggle \| only <br>/ice flag [id] - Opens the map and marks where the area of gathering is. |  | Command help \| ICE\ICE.cs:82 | |
| Option to Delete |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:254; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:256 | |
| Or if you wanted to do the relic on WVR -> Then farm score on BTN -> Farm credits on BSM |  | UI string \| ICE\Ui\MainWindow.cs:167 | |
| Or if you're feeling daredevil. Lower it. I'm not your dad (will tell dad jokes though. |  | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:41; ICE\Ui\MainUi\Settings\SafetySettings.cs:63 | |
| Or if you're letting a different plugin do all the automating of turning in, craftings, gathering... and not letting I.C.E. handle interacting with those plugins |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:54 | |
| Or just read a specific tab to find out. Probably would answer a lot of questions |  | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\Welcome.cs:18 | |
| Order |  | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:212 | |
| Order you would like to do the actions. It will work from the top down. |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:109 | |
| Order you would like to do the provisional mission in, if multiple are selected and the option to do multiple classes is enabled |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:186 | |
| Overlay Mode Select |  | UI string \| ICE\Ui\OverlayWindow.cs:126; ICE\Ui\OverlayWindow.cs:134 | |
| Overlay Settings |  | Tooltip \| ICE\Ui\OverlayWindow.cs:27 | |
| Overlay Window |  | Section header \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:38 | |
| OverlaySettingsPopup |  | UI string \| ICE\Ui\OverlayWindow.cs:60 | |
| Override active — click to inherit from Global |  | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:99; ICE\Ui\MainUi\Settings\Character_Settings.cs:121; ICE\Ui\MainUi\Settings\Character_Settings.cs:802 | |
| Override Expert Artisan settings |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:304 | |
| Override Standard Artisan settings |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:298 | |
| Pandora Feature |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:54 | |
| Path to repair NPC |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:38 | |
| Pathfinding |  | Section header \| ICE\Ui\MainUi\Settings\TravelSettings.cs:43 | |
| Pathing to repair NPC |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:40 | |
| Pause Feature |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:55 | |
| Personalized Fishing Spots |  | Section header \| ICE\Ui\MainUi\Settings\TravelSettings.cs:275 | |
| Phaenna — Rank V Max |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:69 | |
| Pioneer's \| Mountaineer's Gift I |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:515 | |
| Pioneer's \| Mountaineer's Gift II |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:473 | |
| Planet |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_LevelingMissions.cs:13 | |
| Planet Selection |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:43 | |
| Planet: {0} |  | UI text \| ICE\Ui\MainUi\Settings\TravelSettings.cs:287 | |
| Planetary |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:866 | |
| Planetary Credits |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:141 | |
| Play Sound Alert on Stop |  | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:144 | |
| Player Info |  | UI string \| ICE\Ui\DebugWindow.cs:75 | |
| Player is busy, skipping cordial check |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:363 | |
| Player Level |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:101 | |
| Player Moving: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:91 | |
| Player Position: X:{0}, Y:{1}, Z:{2} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:40 | |
| Player Start: {0} |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:289 | |
| Playlist Name |  | Input label \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:328 | |
| Please give it time |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:980 | |
| PLEASE MAKE SURE TO CHECK THE REQUIREMENTS SECTION TO SEE WHAT YOU NEED FOR WHAT |  | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\Welcome.cs:17 | |
| Please make sure to do so for this job if you don't want it to stall out when there is no timed/weather missions. |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:650 | |
| PLEASE NOTE. DO. NOT. LEAVE. THIS. ALONE. This is still being worked on heavily |  | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:69 | |
| PLEASE NOTE: |  | Help marker \| ICE\Ui\MainUi\Settings\GatherSettings.cs:1046 | |
| Please note: You can have multiple enabled, but only the one that will get you the closest to |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:835; ICE\Ui\MainUi\Settings\GatherSettings.cs:881; ICE\Ui\MainUi\Settings\GatherSettings.cs:927 | |
| Plugin Logs |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:168 | |
| Plugin Requirements |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:167 | |
| Position |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:33; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:95 | |
| Position: X: {0}, Y: {1}, Z: {2} |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:72 | |
| Post Mission Commands |  | Section header \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:238 | |
| Post Mission Settings |  | Section header \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:197 | |
| Potion |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1760 | |
| Potion [HQ] |  | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:152 | |
| Potion [NQ] |  | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:157 | |
| Potions |  | UI text \| ICE\Ui\MainUi\Settings\Character_Settings.cs:541 | |
| Pre-Craft Amount |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:215 | |
| Pre-Craft Item |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:214 | |
| Pre-Craft [1] |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:31 | |
| Pre-Craft [2] |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:33 | |
| Pre-Craft [3] |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:35 | |
| Prefer smaller wheel |  | Checkbox \| ICE\Ui\MainUi\Settings\GambaWheel.cs:45; ICE\Ui\MainUi\Settings\GambaWheel.cs:122 | |
| Preset Name |  | Input label \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1278; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:518 | |
| Preset Save Editor |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:323; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:326 | |
| Preset String |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:63 | |
| Preset: List Viewer |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:358; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:361 | |
| Preset: TableViewer |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:365 | |
| Prevent Overcap |  | Checkbox \| ICE\Ui\MainUi\Settings\GatherSettings.cs:216 | |
| Previous |  | Button \| ICE\Ui\MainUi\Settings\Character_Settings.cs:844 | |
| Previous Missions |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:732; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:576; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:903 | |
| Previous Sequence: |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1356 | |
| Print GatheringPoint Info |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:311 | |
| Prioritize closest gathering node |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:54 | |
| Profile Name: {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:318 | |
| Profile Selection |  | Table column \| ICE\Ui\MainUi\Settings\GatherSettings.cs:323 | |
| Profile Setting |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:259 | |
| Progress |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:449 | |
| Progress Only Solver |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:144; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:170; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:174; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1527; ICE\Ui\MainUi\Settings\Character_Settings.cs:318 | |
| Progress: {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1755 | |
| Property |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:28 | |
| Provisional Job Priority |  | UI text \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:184 | |
| Provisional Missions |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:50 | |
| Provisional missions (Weather, Timed, and Sequence) and Red Alerts will be picked up |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:51 | |
| Provisional: Allow All Classes |  | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:248 | |
| Provisional: Job Order |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:27 | |
| Provisional: Type Order |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:20 | |
| Puni.sh in general for each one of your help my dumb questions |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:62 | |
| Quality: {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1811 | |
| Quick Apply Turnins |  | Button \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:96 | |
| Quick Apply_Mission Turnins |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:98; ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:101 | |
| Quick Mission Add |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:57 | |
| Quick Turnin |  | Radio button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1005 | |
| QuickLevelList missions |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:198 | |
| Radius |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:40 | |
| Radius: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:144 | |
| Randomize radius (yalms) |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:79 | |
| Randomize waypoint positions |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:65 | |
| Rank |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:188 | |
| Rank {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:65 | |
| Raphael Recipe Solver |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:148; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:156; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:160 | |
| Raphael Solver |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1526; ICE\Ui\MainUi\Settings\Character_Settings.cs:317 | |
| Raycast not initialized! |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishingRaycast.cs:276 | |
| Really is the "I want to do this order of things" kind of thing. |  | UI string \| ICE\Ui\MainWindow.cs:168 | |
| Really useful if you have a tool to auto-log you in/if you just want to enter the moon and go |  | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:191 | |
| Recipe Detailed Info |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1399 | |
| Recipe ID: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:70; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:103 | |
| RecipeID: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:64; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:97 | |
| RecipeNote |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:264 | |
| Record Settings |  | Section header \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:218 | |
| Red Alert |  | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionsV3.cs:28 | |
| Reducable Items |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:451 | |
| Refresh Class info |  | Icon button \| ICE\Ui\MainUi\SelectableSidebar.cs:169 | |
| Refresh Forecast |  | Button \| ICE\Ui\MainUi\Settings\DebugTab.cs:48 | |
| Relic |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:728 | |
| Relic Grind |  | UI string \| Section header \| Radio button \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:23; ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:58; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:69; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:82; ICE\Ui\MainWindow.cs:118; ICE\Ui\MainWindow.cs:161; ICE\Ui\OverlayWindow.cs:163 | |
| Relic Grind Mode |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:418 | |
| Relic Info |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:30; ICE\Ui\DebugWindow.cs:80 | |
| Relic Info V2 |  | UI string \| ICE\Ui\DebugWindow.cs:84 | |
| Relic Mode: Allow Red Alerts |  | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:304 | |
| Relic Mode: Only Enabled |  | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:311 | |
| Relic Tool XP |  | UI string \| ICE\Ui\OverlayWindow.cs:644 | |
| Relic Turnin |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:346 | |
| Remove |  | Button \| Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NavmeshTesting.cs:44; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:448; ICE\Ui\MainUi\Settings\Misc_Settings.cs:262 | |
| Remove from list |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:423 | |
| Remove Mission Upon Gold Completion |  | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:267; ICE\Ui\MainUi\Settings\Misc_Settings.cs:200 | |
| ReOrder |  | Table column \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:52; ICE\Ui\MainUi\Settings\Priority_Settings.cs:122; ICE\Ui\MainUi\Settings\Priority_Settings.cs:205 | |
| Repair all gear in bag |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:182; ICE\Ui\MainUi\Settings\Character_Settings.cs:238 | |
| Repair at Vendor |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:159; ICE\Ui\MainUi\Settings\Character_Settings.cs:201 | |
| Repair Settings |  | Section header \| ICE\Ui\MainUi\Settings\Character_Settings.cs:152 | |
| Report |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:120 | |
| Required Item |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:73; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:106 | |
| Research |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:39 | |
| Reset Buff Check |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:19 | |
| Reset Stats |  | Button \| ICE\Ui\Window_ExternalDetails.cs:336 | |
| Reset Temp |  | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:134 | |
| Reset Weights |  | Button \| ICE\Ui\MainUi\Settings\GambaWheel.cs:87; ICE\Ui\MainUi\Settings\GambaWheel.cs:142 | |
| Restore Temp MM |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:187 | |
| Retarget |  | Radio button \| ICE\Ui\MainUi\Settings\TravelSettings.cs:214 | |
| Return back to normal |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:193 | |
| Reward Amount |  | UI string \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:111 | |
| Reward ItemID |  | UI string \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:181 | |
| Ribs! Spare Ribs! |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:43 | |
| Right click to set minimum turnin to {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:423 | |
| Right wheel select |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:24 | |
| Rotation Tolerance (degrees) |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:305 | |
| Route Editor |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:67 | |
| Route Selector |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:66 | |
| Row ID |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:55 | |
| Rows for missions not in MissionScores.csv, using BronzeScore from sheets. |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:72 | |
| Run Drone Finder |  | Button \| UI text \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:13; ICE\Ui\OverlayWindow.cs:154 | |
| Run Until.. |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:351; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:446 | |
| Running task: {0} \| Amount of queue'd task: {1} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:15 | |
| Safety is around... 2500? If you're having animation locks you can absolutely increase it higher |  | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:62 | |
| Safety is around... 250? If you're having animation locks you can absolutely increase it higher |  | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:40 | |
| Safety Settings |  | Section header \| ICE\Ui\MainUi\Settings\SafetySettings.cs:20 | |
| Save |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:227 | |
| Save Current Mission Preset |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:321 | |
| Save New List |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:331 | |
| Save Route |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:175 | |
| Save to Favorites |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:216 | |
| Saved Agenda's |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:253 | |
| Score |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:206; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:40; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:864; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:730 | |
| Score 1 |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:140 | |
| Score Farming — select specific high-value missions |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:46 | |
| Score Goal |  | Radio button \| UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:983; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:999 | |
| Score Info: External Details |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:380 | |
| Score: [{0}] |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:148 | |
| Score: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:20; ICE\Ui\OverlayWindow.cs:618 | |
| Scour Amount |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:102 | |
| Search |  | Input label \| ICE\Ui\MainUi\Settings\Character_Settings.cs:819 | |
| Search by Attribute |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:46 | |
| Search by Name |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:16; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:44; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:12 | |
| Search logs... |  | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:52 | |
| Search missions: |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionText.cs:15 | |
| Search Name |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:28 | |
| Select |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:154; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MoonRecipe.cs:39 | |
| Select Class |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:129 | |
| Select Crafter Food |  | UI string \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:43; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:46 | |
| Select Export Folder |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:40 | |
| Select Export Location |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:134 | |
| Select Fishing Profile |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1260; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1262; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:500; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:502 | |
| Select Food |  | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:33 | |
| Select Gather Profile |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1220; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1226 | |
| Select Gathering Food |  | Button \| ICE\Ui\MainUi\Settings\GatherSettings.cs:249 | |
| Select gathering profile |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1224 | |
| Select Manual |  | Button \| UI string \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:83; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:93; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:96 | |
| Select mission to import |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:80 | |
| Select Mode |  | UI text \| ICE\Ui\MainWindow.cs:109 | |
| Select Mounting Option |  | Button \| ICE\Ui\MainUi\Settings\Character_Settings.cs:785; ICE\Ui\MainUi\Settings\Character_Settings.cs:808 | |
| Select Pot |  | Button \| UI string \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:58; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:68; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:71 | |
| Select Profile |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:498 | |
| Select profile to use |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:468 | |
| Select Squadron Manual |  | Button \| UI string \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:108; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:118; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:121 | |
| Select string not visible |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RedAlertString.cs:26 | |
| Select Turnin Options |  | UI text \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:121 | |
| Selected Fan |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:349 | |
| Selected Filter Index {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:21 | |
| Selected Food: [{0}] {1} |  | UI text \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:31 | |
| Selected Job Index {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:19 | |
| Selected Manual: [{0}] {1} |  | UI text \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:81 | |
| Selected Mission ID: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:23 | |
| Selected Mission Name: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:22 | |
| Selected Pot: [{0}] {1} |  | UI text \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:56 | |
| Selected Squadron Manual: [{0}] {1} |  | UI text \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:106 | |
| Selected Tab Index {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:20 | |
| Selected: {0} icons |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:411 | |
| Selecting Gathering Profile |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:463; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:471 | |
| Self Repair Crafter |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:169; ICE\Ui\MainUi\Settings\Character_Settings.cs:220 | |
| Self Repair Gather |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:165; ICE\Ui\MainUi\Settings\Character_Settings.cs:212 | |
| Sequence Missions |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:728; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:572; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:898 | |
| Sequential Missions Required |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:462 | |
| Set all leveling missions |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:89 | |
| Set Area |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:50 | |
| Set current mission to Progress |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:164 | |
| Set current mission to Raphael |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:150 | |
| Set export path first (or use Copy Missing CSV) |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:152 | |
| Set Fishing Rotation |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:296 | |
| Set fishing to current |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:284 | |
| Set in incriments of 200, max of 5,000 |  | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:43 | |
| Set Location: {0} |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:207 | |
| Set marker to current position |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_WorldIconTEst.cs:13 | |
| Set Miracle Solver |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:181 | |
| Set MM Temp |  | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:180 | |
| Set position: {0} |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:129 | |
| Set raphael solver |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:146 | |
| Set Save Location |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:38 | |
| Set State to Idle |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:20 | |
| Set temp setting |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:142 | |
| Set to -1 to allow for infinite uses |  | Help marker \| ICE\Ui\MainUi\Settings\GatherSettings.cs:549; ICE\Ui\MainUi\Settings\GatherSettings.cs:593; ICE\Ui\MainUi\Settings\GatherSettings.cs:649; ICE\Ui\MainUi\Settings\GatherSettings.cs:705; ICE\Ui\MainUi\Settings\GatherSettings.cs:758; ICE\Ui\MainUi\Settings\GatherSettings.cs:803; ICE\Ui\MainUi\Settings\GatherSettings.cs:860; ICE\Ui\MainUi\Settings\GatherSettings.cs:906; ICE\Ui\MainUi\Settings\GatherSettings.cs:952; ICE\Ui\MainUi\Settings\GatherSettings.cs:997 | |
| Set to 1-> X to set maximum amount of uses per mission |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:550; ICE\Ui\MainUi\Settings\GatherSettings.cs:594; ICE\Ui\MainUi\Settings\GatherSettings.cs:650; ICE\Ui\MainUi\Settings\GatherSettings.cs:706; ICE\Ui\MainUi\Settings\GatherSettings.cs:759; ICE\Ui\MainUi\Settings\GatherSettings.cs:804; ICE\Ui\MainUi\Settings\GatherSettings.cs:861; ICE\Ui\MainUi\Settings\GatherSettings.cs:907; ICE\Ui\MainUi\Settings\GatherSettings.cs:953; ICE\Ui\MainUi\Settings\GatherSettings.cs:998 | |
| Set To Current |  | Table column \| Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:36; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:60 | |
| Set to current location |  | Button \| ICE\Ui\MainUi\Settings\TravelSettings.cs:253 | |
| Setting Bool |  | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:136 | |
| Setting Name |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:135 | |
| Settings |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:106 | |
| Setup Gathering Profiles |  | Button \| ICE\Ui\InfoWindow.cs:58; ICE\Ui\MainUi\Settings\GatherSettings.cs:1039 | |
| Sheet: Mission Rewards |  | UI string \| ICE\Ui\DebugWindow.cs:87 | |
| Short answer: It's built in now |  | UI text (wrapped) \| ICE\Ui\MainUi\Settings\GatherSettings.cs:458 | |
| Show Crazy Taxi Arrow when navmeshing |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:311 | |
| Show Current Class Score |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:80 | |
| Show enabled missions on weather hover |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:109 | |
| Show Experience Bars on Overlay |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:63 | |
| Show fishing spot raycast |  | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:74; ICE\Ui\MainUi\Settings\TravelSettings.cs:288 | |
| Show Gather Debug Info |  | Checkbox \| ICE\Ui\MainUi\Settings\DebugTab.cs:54 | |
| Show Overlay |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:42 | |
| Show random location debug target |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:85 | |
| Show Seconds |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:56 | |
| Show tab list |  | Tooltip \| ICE\Ui\DebugWindow.cs:32 | |
| Show Total Score |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:87 | |
| Showing {0} of {1} missions |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionText.cs:45 | |
| Silver |  | Table column \| Radio button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:191; ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:128 | |
| Silver Requirement |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:211 | |
| Silver: 2 Items |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:461 | |
| Sinus   — Rank IV Max |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:68 | |
| Skill Status [272]: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:165 | |
| So get a good couple of runs to get a good feel for the timing |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:377 | |
| So if you Have Red Arert -> Drone Search, if a red alert isn't available, it will proceed to use a drone box if it can |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:110 | |
| So if you stop and you're unsure why... this might be why |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:151 | |
| So now how it'll work. Select the turnin option (Gold/Any both work the same) and it will now gather up to the necessary amount -> turnin when it's ready. |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:464 | |
| So... you're telling me a shrimp fried this rice? |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:56 | |
| Solver |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1643 | |
| Solver Type |  | UI text \| ICE\Ui\MainUi\Settings\Character_Settings.cs:413 | |
| Sound Volume |  | UI text \| ICE\Ui\MainUi\Settings\StopWhen.cs:152 | |
| Specific |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:20 | |
| Specific Class Details |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:804 | |
| Spot {0} |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:248 | |
| Squad Manual |  | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:167 | |
| Squadron Manual |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1866; ICE\Ui\MainUi\Settings\Character_Settings.cs:687 | |
| Square custom font |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:351 | |
| Stage |  | Table column \| UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:33; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:833 | |
| Stage: {0} |  | UI text \| ICE\Ui\Relic_XP.cs:52 | |
| Stand Mode |  | UI string \| ICE\Ui\MainWindow.cs:149 | |
| Standard |  | Section header \| Radio button \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:41; ICE\Ui\MainWindow.cs:112 | |
| Standard Craft Settings |  | Table column \| ICE\Ui\MainUi\Settings\Character_Settings.cs:393 | |
| Standard Solver |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1528; ICE\Ui\MainUi\Settings\Character_Settings.cs:319 | |
| Start |  | Table column \| Button \| UI text \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:150; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:168; ICE\Ui\OverlayWindow.cs:187 | |
| Start Gambling @ |  | UI string \| ICE\Ui\MainUi\Settings\GambaWheel.cs:228 | |
| Start Hour |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_TimeWeather.cs:15 | |
| Starting Test Navmesh |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:449 | |
| State |  | Table column \| ICE\Ui\Window_ExternalDetails.cs:473 | |
| State: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_TimerInfo.cs:18 | |
| Steller |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:25 | |
| Steller Reduction |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:113 | |
| Still needed: {0}. |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:202 | |
| Stop |  | Button \| UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:230; ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:18; ICE\Ui\OverlayWindow.cs:187 | |
| Stop @ Relic Complete |  | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:114 | |
| Stop after current mission |  | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:282; ICE\Ui\MainUi\Settings\StopWhen.cs:20 | |
| Stop after current mission: OFF |  | UI text \| ICE\Ui\OverlayWindow.cs:205 | |
| Stop after current mission: ON |  | UI text \| ICE\Ui\OverlayWindow.cs:205 | |
| Stop All Task |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:181 | |
| Stop at Cosmic Credits |  | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:25 | |
| Stop at Cosmic Score |  | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:71 | |
| Stop at Cosmic Score [{0}] |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:141 | |
| Stop at Level |  | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:93 | |
| Stop at Planetary Credit Amount |  | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:50 | |
| Stop At Relic Lv. |  | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:125; ICE\Ui\OverlayWindow.cs:653 | |
| Stop Current Task |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:84 | |
| Stop Drone Finder |  | UI text \| ICE\Ui\OverlayWindow.cs:154 | |
| Stop naving |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:171 | |
| Stop once cosmo credit hit [{0}] |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:145 | |
| Stop once planetary credit hit [{0}] |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:147 | |
| Stop once relic completed |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:149 | |
| Stop Task |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:25 | |
| Stop when below x dark matter |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:186 | |
| Stop when below x dark matter (Global) |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:246 | |
| Stop When Level [{0}] |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:143 | |
| Stop When... |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:108 | |
| Strife special shoutout to you for doing what I didn't want to with fishing |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:59 | |
| Stuck Detection |  | Section header \| ICE\Ui\MainUi\Settings\TravelSettings.cs:186 | |
| Stupid Test |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:95 | |
| Stylist |  | Section header \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:36 | |
| SubLevel |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:98 | |
| Swap |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:71 | |
| Swap Bait... simple |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:86 | |
| Swap jobs when turning in relic |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:963; ICE\Ui\MainUi\Settings\Character_Settings.cs:1000 | |
| Swap to bait |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:82 | |
| Swap to preset |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:70 | |
| Switch class to CRP |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:338 | |
| Switch class to MIN |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:342 | |
| Synthesize |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MoonRecipe.cs:32 | |
| Tab # |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:75 | |
| Table: Fish Info |  | UI string \| ICE\Ui\DebugWindow.cs:62 | |
| Table: Gathering Missions |  | UI string \| ICE\Ui\DebugWindow.cs:58 | |
| Table: Leveling Missions |  | UI string \| ICE\Ui\DebugWindow.cs:88 | |
| Table: Mission Info |  | UI string \| ICE\Ui\DebugWindow.cs:57 | |
| Table: Mission Select |  | UI string \| ICE\Ui\DebugWindow.cs:89 | |
| Table: Mission Text |  | UI string \| ICE\Ui\DebugWindow.cs:60 | |
| Table: Recipies |  | UI string \| ICE\Ui\DebugWindow.cs:61 | |
| Table: Special Missions |  | UI string \| ICE\Ui\DebugWindow.cs:59 | |
| TableId |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_MapTesting.cs:17 | |
| Task Count: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:19 | |
| TaskManager Testing |  | UI string \| ICE\Ui\DebugWindow.cs:81 | |
| Temp Set Presets |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:110 | |
| Territory |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:97 | |
| Territory Id: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:23 | |
| Territory: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:142 | |
| Test Buttons |  | UI string \| ICE\Ui\DebugWindow.cs:76 | |
| Test Crafting |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:64 | |
| Test Drone Buy |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:247 | |
| Test Drone Buy Item |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:77 | |
| Test Drone Pathing |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:81 | |
| Test Flag |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:204 | |
| Test Gather Targeting |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:68 | |
| Test Glamour |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:222 | |
| Test Hat |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:226 | |
| Test Map Marker from coords |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_MapTesting.cs:44 | |
| Test Mission List |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:61 | |
| Test Naving to [New] |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:310 | |
| Test Pathing to position |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:124 | |
| Test Picto |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:113 | |
| Test Radius |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:46; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_MapTesting.cs:21 | |
| Test Repair Function |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:42 | |
| Test Sound Alert |  | Button \| ICE\Ui\MainUi\Settings\StopWhen.cs:159 | |
| Test Toast |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:211 | |
| Test Visor |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:230 | |
| Testing... if this fires off multiple times |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:292 | |
| Thank you everyone who's helped make this possible. |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:58 | |
| Thanks for using my plugin though, it means a lot <3 |  | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:326 | |
| The buff restores itself when you re-enter the zone. |  | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:179 | |
| The delays will be before, and a little bit inbetween interacting with menus |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:182 | |
| The following missions are required to have gold before you can do this one |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1384; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:635 | |
| The most straightforward mode. Standard runs only the missions you have enabled |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:43 | |
| The rest of the commands work by doing a single id/multiple in a row |  | UI string \| ICE\ICE.cs:314 | |
| There is 5 different modes that exist currently (as of writing this) that all serve minorly differently functions. |  | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:12 | |
| There will be another warning to pop up if you try and run this still and it selects a fishing mission... |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:216 | |
| There's certain missions that are worth grinding more than others. Weather/time also plays a part of it all. Below is what I would recommend on a per class basis. |  | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Tips.cs:76 | |
| These are a list of the following plugins that are required for the plugin to function. If you don't have these installed, it will not function properly |  | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:16 | |
| This can be applied with normal field mastery, but will only apply per hit |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:973 | |
| This can only be set to 1 item, and gererally used for things you want to just spend your credits on |  | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:47 | |
| This does abosolutely nothing |  | Icon tooltip \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:324 | |
| This gives you full control over what missions to run, making it ideal for: |  | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:45 | |
| This is ASSUMING: |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:373 | |
| This is based on your average time. |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:376 | |
| This is here for safety! If you want to decrease the delay before turnin be my guest. |  | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:61 | |
| This is here for safety! If you want to decrease the delay between missions be my guest. |  | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:39 | |
| This is kind of my way of letting you somewhat script/set up a sequence of other things that you would like to do that might not be included in the plugin itself. |  | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:242 | |
| THIS IS YOUR HEADS UP ON HOW THIS WORKS. If I change this in the future, this tooltip will also change. |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:293 | |
| This is your personalized shopping list that you can create that it will run when you hit a certain amount of credits. |  | UI text \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:40 | |
| This isn't required, but highly recommended for leveling up characters. It will auto equip gear from your armory/inventory, and swap it out when running Leveling Grind Mode |  | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:35 | |
| This mission is currently missing stuff to allow it to work. It might be planet locked, or could be just needs mapped out |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:285 | |
| This mode is if you want to do a series of things in a particular order. So for example, if you wanted to grind out all the relics on all the classes back to back |  | UI string \| ICE\Ui\MainWindow.cs:166 | |
| This plugin is designed for specifically for the use of Cosmic Exploration, and is kinda hefty. So I'm going to try and go through all the different tips / tricks |  | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\Welcome.cs:12 | |
| This plugin is meant to help you with your cosmic exploration needs, |  | UI text (wrapped) \| ICE\Ui\InfoWindow.cs:44 | |
| This setting is global and shared across all characters.<br>Edit it on the Global tab. |  | Tooltip \| ICE\Ui\MainUi\Settings\Character_Settings.cs:249 | |
| This will adjust how much of the center point of the fan it will randomize from. |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:101 | |
| This will allow you to grind other classes for criticals/red alerts. |  | Help marker \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:263 | |
| This will check to see if you're on a gathering/crafting class upon first entering the moon. |  | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:189 | |
| This will make the Gamba prefer wheels with less items. |  | Help marker \| ICE\Ui\MainUi\Settings\GambaWheel.cs:50; ICE\Ui\MainUi\Settings\GambaWheel.cs:127 | |
| This will ONLY run upon first entry. |  | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:192 | |
| This will wipe out all your current profiles, and apply what I would suggest for each one. |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:1047 | |
| Time |  | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:69; ICE\Ui\Window_ExternalDetails.cs:472 | |
| Time Attack |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:35 | |
| Time Required |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:460 | |
| Time Slot |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:718 | |
| Timed |  | UI text \| ICE\Ui\OverlayWindow.cs:510 | |
| Timed Scoring |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:453 | |
| Timed Turnin |  | Radio button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:971 | |
| Timer: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_TimerInfo.cs:19 | |
| Times Attempted: {0} |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:360 | |
| Times Completed: {0} |  | UI text \| ICE\Ui\Window_ExternalDetails.cs:359 | |
| Timestamp |  | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:149 | |
| Tip Selector |  | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Tips.cs:45 | |
| to be able to hit the threshold. And even then, if you manage to not hit it on the first attempt, it'll just keep gathering. Plus. This makes it to where I can not have to worry about profile managing on fishing for... 4 missions? Seemed minorly reduntant in my eyes. |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:463 | |
| To the side you'll find a couple of different tabs that will *try* and answer any question that you migth have. |  | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\Welcome.cs:16 | |
| ToDo ID |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:189 | |
| Toggle Setting |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:138 | |
| Tokens |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:867 | |
| Total Completions: {0}/{1} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:859 | |
| Total Req |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:21 | |
| Total: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:36 | |
| Travel & Pathfinding |  | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:111 | |
| Try and apply above profile |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1283 | |
| TryGather |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:14 | |
| Turn in |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:412 | |
| Turnin if relic is complete |  | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:284 | |
| Turnin Mode |  | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:258 | |
| Type |  | Table column \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:54; ICE\Ui\MainUi\Settings\Priority_Settings.cs:124; ICE\Ui\MainUi\Settings\Priority_Settings.cs:207 | |
| Type Priority Table |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:50 | |
| typed in correctly. This is *case* specific so |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1290 | |
| Ui: Fishing Hole Editor |  | UI string \| ICE\Ui\DebugWindow.cs:66 | |
| Ui: Fishing Preset Editor |  | UI string \| ICE\Ui\DebugWindow.cs:67 | |
| Ui: Gather Editor |  | UI string \| ICE\Ui\DebugWindow.cs:68 | |
| Ui: Log Viewer |  | UI string \| ICE\Ui\DebugWindow.cs:69 | |
| Ui: Player Gearsets |  | UI string \| ICE\Ui\DebugWindow.cs:70 | |
| Ui: Select String |  | UI string \| ICE\Ui\DebugWindow.cs:65 | |
| Ui: Table V3 |  | UI string \| ICE\Ui\DebugWindow.cs:45 | |
| Unknown Debug View |  | UI text \| ICE\Ui\DebugWindow.cs:134 | |
| Unknown Job |  | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:258 | |
| Unknown Tip View |  | UI text \| ICE\Ui\MainUi\HelpFolder\helpSelect_Tips.cs:67 | |
| Unknown0 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:65 | |
| Unknown1 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:75 | |
| Unknown10 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:135 | |
| Unknown11 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:145 | |
| Unknown12 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:155 | |
| Unknown13 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:165 | |
| Unknown14 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:175 | |
| Unknown15 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:185 | |
| Unknown16 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:195 | |
| Unknown17 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:205 | |
| Unknown18 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:215 | |
| Unknown19 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:225 | |
| Unknown2 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:85 | |
| Unknown3 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:95 | |
| Unknown4 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:105 | |
| Unknown8 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:115 | |
| Unknown9 |  | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:125 | |
| Unlocked |  | Table column \| ICE\Ui\MainUi\Settings\GambaWheel.cs:159; ICE\Ui\MainUi\Settings\ShoppingTab.cs:217 | |
| Until maxed only |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:72 | |
| Update all mission text |  | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionText.cs:19 | |
| Update Best Mission |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:166; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:102 | |
| Update Character Stats |  | UI string \| ICE\ICE.cs:137 | |
| Update Dummy XP |  | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:104 | |
| Update Gearsets |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Gearsets.cs:41 | |
| Urgency Exp Values |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:211 | |
| Use Aethernet |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:113 | |
| Use after this many steps |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1991 | |
| Use Built In Preset |  | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1267; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:507 | |
| Use cogs button instead of home |  | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:49 | |
| Use cordial when below the following GP |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:222 | |
| Use Drone |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:120 | |
| Use food on gathering missions |  | Checkbox \| ICE\Ui\MainUi\Settings\GatherSettings.cs:243 | |
| Use Gathering Food |  | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:85 | |
| Use Global Artisan Settings |  | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1513 | |
| Use Hub Return |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:106 | |
| Use mount in mission |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:863; ICE\Ui\MainUi\Settings\Character_Settings.cs:893 | |
| Use mount outside mission |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:859; ICE\Ui\MainUi\Settings\Character_Settings.cs:885 | |
| Use no gathering food |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:280 | |
| Use personal return spots |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:241 | |
| Use Red Alert NPC for travel |  | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:120 | |
| Use Stylist to re-equip tools |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:988; ICE\Ui\MainUi\Settings\Character_Settings.cs:1033 | |
| Useful for things like cordials where you want to always have a certain amount on hand |  | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:43 | |
| Valid Moon NPC Info: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:24 | |
| Value |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:29 | |
| Variety of Fish Required |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:457 | |
| Variety Req |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:22 | |
| Very useful for quick score farming, mount tokens. |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1013 | |
| Viable fishing spot: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:186 | |
| View All Presets |  | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:356 | |
| View All SE Custom Fonts (That's known |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:381 | |
| View Fishing Spots |  | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:199 | |
| View Nav Spots |  | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:209 | |
| Visualize Dismount Radius |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:878; ICE\Ui\MainUi\Settings\Character_Settings.cs:919 | |
| Visualize radius |  | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:871; ICE\Ui\MainUi\Settings\Character_Settings.cs:907 | |
| Wah thank you for the UI, this is fucking beautiful as always |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:61 | |
| Waiting for "WKSHud" to be visible |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:53 | |
| Waiting for "WKSLottery" to be visible |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:54 | |
| Waiting for "WKSMission" to be visible |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:181 | |
| Waiting for "WKSMissionInfomation" to be visible |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:169 | |
| Waiting for "WKSRecipeNotebook" to be visible |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MoonRecipe.cs:49 | |
| Waiting for a shop exchange window to be open |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:233 | |
| Waiting for Gather Collectable window to be visible |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:142 | |
| Warning! This is a safety feature to avoid joining random parties! |  | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:29 | |
| We're somehow not showing the window, so returning 0. |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:282 | |
| Weather |  | UI text \| ICE\Ui\OverlayWindow.cs:510 | |
| Weather Required |  | Table column \| UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_TimeWeather.cs:14; ICE\Ui\Window_ExternalDetails.cs:461 | |
| Weather/Time Info |  | UI string \| ICE\Ui\OverlayWindow.cs:71 | |
| Weather: {0} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:615; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:881 | |
| Weaver (WVR) |  | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:69 | |
| Weight |  | Table column \| ICE\Ui\MainUi\Settings\GambaWheel.cs:161 | |
| Welcome! This is probably the most complicated plugin I've created so far. |  | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\Welcome.cs:11 | |
| What do you a dinosaur that only has one eye? |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:53 | |
| What is a pirates favorite letter? |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:26 | |
| What is a skeleton's favorite snack? |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:42 | |
| What's the maximum amount of drones you wanna keep? |  | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:56 | |
| What's the minimum durability a node can have before this action is activated? |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:640; ICE\Ui\MainUi\Settings\GatherSettings.cs:696 | |
| What's the minimum gp you can have before it uses a cordial. |  | Help marker \| ICE\Ui\MainUi\Settings\GatherSettings.cs:228 | |
| When do you wanna buy drones from the vendor? |  | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:42 | |
| When enabled, overlays will render over the native UI elements |  | Tooltip \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:161 | |
| When enabled, Stellar Return will still be used to return to the hub<br>for activities like credit purchases, gambling, drone bits, and repairs. |  | Tooltip \| ICE\Ui\MainUi\Settings\TravelSettings.cs:149 | |
| When enabled, the pathfinder will not use Stellar Return to travel to gathering nodes.<br>This applies to both Hub Return and Hub + Aethernet travel methods. |  | Tooltip \| ICE\Ui\MainUi\Settings\TravelSettings.cs:136 | |
| When stuck during navmesh movement for the configured delay: |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:203 | |
| Where'd the dual craft amount go? |  | UI text \| ICE\Ui\MainUi\Settings\GatherSettings.cs:448 | |
| White Mage |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:24; ICE\Ui\MainUi\Settings\Character_Settings.cs:1050 | |
| Why are tennis pros always hugging each other? |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:33 | |
| Why can't ghost have babies? |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:36 | |
| Will also pause pandora cordial usage while on the moon |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:196 | |
| Will only apply when the gathering node has full durability |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:615; ICE\Ui\MainUi\Settings\GatherSettings.cs:671; ICE\Ui\MainUi\Settings\GatherSettings.cs:779 | |
| Will only work while using ICE and not manual mode |  | Help marker \| ICE\Ui\MainUi\Settings\GatherSettings.cs:195 | |
| Will turnin once the timer runs out |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:978 | |
| Will turnin the mission as soon as it can |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1012 | |
| Will turnin when 1 of the 2 things are met: |  | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:990 | |
| WKSMission Time Sheet |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_TimeWeather.cs:11 | |
| World Cords: {0}, {1}, {2} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:88 | |
| World Stage: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:35 | |
| WVR | WVR | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:30; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:16; ICE\Ui\MainUi\Settings\Misc_Settings.cs:129 | |
| X Location |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:42 | |
| x {0} |  | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:303 | |
| X: {0} Y: {1} |  | Icon button \| ICE\Ui\MainUi\Settings\TravelSettings.cs:316 | |
| X: {0} \| Y: {1} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:362; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:373 | |
| X: {0} \| Y: {1} \| Z: {2} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:275 | |
| X: {0}, Y: {1}, Z: {2} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NavmeshTesting.cs:37 | |
| X: {0}, Z: {1} |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:308 | |
| XP: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:124 | |
| Y Location |  | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:44 | |
| Yet |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:994 | |
| yields the most for your current level. |  | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:63 | |
| You can buy cosmocredit items from the list! |  | UI text \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:72 | |
| You can set your score with this mode yourself, due to not knowing the scoring break points |  | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:993 | |
| You can't buy any items with your current credit value/items (tis fine, this just a test) |  | UI text \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:76 | |
| You currently don't have any profiles saved! Please either make one and save, or import if you would like to populate this listing |  | UI text (wrapped) \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:403 | |
| You don't have to use this, it will just use a random spot if: |  | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:278 | |
| You give him Cprrrrrr |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:40 | |
| You have been warned. Disable at your own risk. |  | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:31 | |
| You know, I was reading this book about anti-gravity recently, |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:30 | |
| You might thing it's R, but tis first love was the C |  | UI string \| ICE\Ui\Window_ExternalDetails.cs:27 | |
| You need to (currently) be on the testing version to be able fish automated here |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:215 | |
| You need to update autohook for you to be able to fish here on Auxesia. Please swap to testing version |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:214 | |
| Zone {0} - X:{1} Z:{2} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:229 | |
| Zone: {0} |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:95 | |
| [Average] Rewards per minute |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:856 | |
| [MAX] |  | UI text \| ICE\Ui\Relic_XP.cs:56 | |
| [{0}] {1} ({2}x tokens) |  | UI text \| ICE\Ui\OverlayWindow.cs:299 | |
| {0} ({1} items) |  | UI text \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:206 | |
| {0} - Current |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:36 | |
| {0} - Max |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:38 | |
| {0} - Need |  | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:37 | |
| {0} / {1} (Max: {2}) |  | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:53 | |
| {0} In {1} |  | UI string \| ICE\Ui\MainUi\Settings\DebugTab.cs:40 | |
| {0} is installed |  | UI text \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:66 | |
| {0} Mode |  | Section header \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:88; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:101 | |
| {0} Repo is Installed |  | UI text \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:47 | |
| {0} Weather - {1} |  | UI string \| ICE\Ui\MainUi\Settings\DebugTab.cs:33 | |
| {0} — turn in at {1} or better |  | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:422 | |
| {0}-{1} of {2} |  | UI text \| ICE\Ui\MainUi\Settings\Character_Settings.cs:847 | |
| \| LandZone pick failed, kept player pos |  | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:422 | |
| ♥ Ko-fi (Buy me an ice coffee) |  | Tooltip \| ICE\Ui\MainWindow.cs:32 | |
