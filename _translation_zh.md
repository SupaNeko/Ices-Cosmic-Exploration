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

## 纠正指导

1. relic被翻译成了“遗物”，修改为“工具”，比如“遗物研磨 Mode”，修改为“升级工具 Mode”。背景补充：这是一系列升级宇宙工具的任务，有一个relic Lv表示升级阶段，
2. 所有提到的“辉煌工具”，我没有在该文档中搜索到原文，但应该对应的翻译是“宇宙工具”
3. "red alert"翻译为“紧急任务”,"timed"通常对应为“限时”任务而非“定时”任务。
4. “黄金完成”修改为“达成金星”
5.4个星球的专有名词分别为：“憧憬湾”，“法恩娜行星”，“俄匊斯行星”，“奥克塞西亚行星”
5. 信用点的专有名词分别为：“宇宙信用点”，“奥克塞西亚信用点”，其它信用点也与行星名称一致（如果英文一致的话）
6. "Stylist","AutoHook","Artisan"是插件名称，保留英文原文。
7. 检查所有的“收集”，优化为“采集”，这是游戏专有名词，表示采集植物、矿物等。“植物学家/矿工/渔民”优化为“园艺工/采矿工/捕鱼人”。“自动化中心活动”优化为“自动寻路”

> 共提取 **1377** 条玩家可见英文文本。

| 英文原文 | 中文翻译 | 英文原意/上下文 | 修改意见 |
|---|---|---|---|
| % of Level | 水平百分比 | Table column \| ICE\Ui\Window_ExternalDetails.cs:265 |  |
| (e.g. Rank D completed but Rank C not yet unlocked), make sure to unlock it manually before starting. | （例如，D 级已完成，但 C 级尚未解锁），请确保在开始之前手动解锁。 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:66 |  |
| (It helps if you verbally say it like a pirate) | （如果您像海盗一样口头说出它会有所帮助） | UI string \| ICE\Ui\Window_ExternalDetails.cs:28 |  |
| (optional custom name) | （可选自定义名称） | UI text (disabled) \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:457 |  |
| (select to add optional name) | （选择添加可选名称） | UI text (disabled) \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:461 |  |
| (So if you're on crp, but a bsm red alert pops up) | （因此，如果您在 crp 上，但弹出 bsm 紧急任务） | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:264 |  |
| (Sorry for making you start big fish #NotSorry#MuchLove) | （抱歉让您开始大鱼 #NotSorry#MuchLove) | UI string \| ICE\Ui\Window_ExternalDetails.cs:60 |  |
| **These will automatically set settings for using these modes temporarily** | **这些将自动设置暂时使用这些模式的设置** | UI string \| ICE\Ui\MainWindow.cs:159 |  |
| **This will respect the want to grind off class provisionals, and criticals if you have those enabled | **如果您启用了这些功能，这将尊重磨掉职业临时条件和紧急任务的愿望 | UI string \| ICE\Ui\MainWindow.cs:175 |  |
| - - - Mission specific - - - | - - - 特定任务 - - - | UI string \| ICE\ICE.cs:311 |  |
| - - ICE Commands Help - - | - - ICE 命令帮助 - - | UI string \| ICE\ICE.cs:307 |  |
| - Jump: attempts to jump over the obstacle | - 跳跃：尝试跳过障碍 | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:204 |  |
| - Retarget: stops and re-pathfinds to the destination (re-randomizes if enabled) | - 重新定位：停止并重新寻路到目的地（如果启用，则重新随机化） | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:205 |  |
| - This is due to the fact that I cba coding this in at this time. (might change my mind in the future *shrugs*) | - 这是因为我此时使用 cba 编码这一事实。（将来可能会改变我的想法*耸耸肩*） | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:296 |  |
| - This is optional, you can disable it at your own free will, I just like this so I can just go back to an isolated area of my choosing | - 这是可选的，您可以随意禁用它，我只是喜欢这样，这样我就可以回到我选择的隔离区域 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:299 |  |
| --> Name: {0} \| ID: {1} | -->名称：{0} \|ID: {1} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:276 |  |
| -> Automatically select which missions that are best to finish up your relic | -> 自动选择最适合完成你的宇宙工具的任务 | UI string \| ICE\Ui\MainWindow.cs:162 |  |
| -> For crafters it's whatever missions take the least amount of progress | -> 对于能工巧匠来说，它是进度最少的任务 | UI string \| ICE\Ui\MainWindow.cs:157 |  |
| -> For gathering, it's whatever is the least pain to do w/ the minimum amount of skills | -> 对于采集来说，它是用最少的技能完成最不痛苦的任务 | UI string \| ICE\Ui\MainWindow.cs:158 |  |
| -> If it is apart of a sequence chain, it will grab the mission that are needed previously to help complete it, and the missions post if necessary | -> 如果它是序列链的一部分，它将获取之前需要帮助完成它的任务，并且任务发布如果有必要 | UI string \| ICE\Ui\MainWindow.cs:173 |  |
| -> If it runs out of missions to reroll, it will just continually swap tabs until the mission is available (via provisional or critical) | -> 如果它用完要重新滚动的任务，它将不断交换选项卡，直到任务可用（通过临时或紧急任务） | UI string \| ICE\Ui\MainWindow.cs:174 |  |
| -> If you want to only do certain missions, enable the option and select which ones you want to do | -> 如果您只想执行某些任务，请启用该选项并选择您想要执行的任务 | UI string \| ICE\Ui\MainWindow.cs:164 |  |
| -> Select which missions you want to do, and go at it. | -> 选择您想要执行的任务，然后继续执行。 | UI string \| ICE\Ui\MainWindow.cs:152 |  |
| -> These are hand picked by me, and determined by the time it takes to complete it | -> 这些是我亲手挑选的，并由完成它所需的时间决定 | UI string \| ICE\Ui\MainWindow.cs:156 |  |
| -> These are weighed based on what is needed to complete the tool to the next step | -> 这些是根据完成下一步所需的工具进行权衡 | UI string \| ICE\Ui\MainWindow.cs:163 |  |
| -> Used to select which missions you want to grind. It'll priortize in the following order: | -> 用于选择您想要完成的任务。它将按以下顺序进行优先级排序： | UI string \| ICE\Ui\MainWindow.cs:150 |  |
| -> Will automatically pick all the missions that you do not have currently gold, AND ONLY THOSE MISSIONS. | -> 将自动选择您当前没有金星的所有任务，并且仅选择那些任务。 | UI string \| ICE\Ui\MainWindow.cs:172 |  |
| -> Will automatically select which mission is the best for leveling your current class based on what level bracket you're in | -> 将根据您所在的等级区间自动选择哪个任务最适合您当前的等级 | UI string \| ICE\Ui\MainWindow.cs:155 |  |
| /ice | /ice | Command help \| ICE\ICE.cs:91 |  |
| /ice -> opens the main settings | /ice -> opens the main settings | UI string \| ICE\ICE.cs:309 |  |
| /ice add (ids) - enables select missions | /ice add (ids) - enables select missions | UI string \| ICE\ICE.cs:316 |  |
| /ice flag (id) - opens the map and flags the mission (if it has one). | /ice flag (id) - opens the map and flags the mission (if it has one). | UI string \| ICE\ICE.cs:320 |  |
| /ice help - show all available commands | /ice help - show all available commands | UI string \| ICE\ICE.cs:308 |  |
| /ice only (ids) - makes only select missions enabled | /ice only (ids) - makes only select missions enabled | UI string \| ICE\ICE.cs:319 |  |
| /ice remove (ids) - removes/disables select missions | /ice remove (ids) - removes/disables select missions | UI string \| ICE\ICE.cs:317 |  |
| /ice s -> opens the settings menu | /ice s -> opens the settings menu | UI string \| ICE\ICE.cs:310 |  |
| /ice start - starts ICE | /ice start - starts ICE | UI string \| ICE\ICE.cs:313 |  |
| /ice stop - Stops ICE | /ice stop - Stops ICE | UI string \| ICE\ICE.cs:312 |  |
| /ice toggle (ids) - toggles select mission ids | /ice toggle (ids) - toggles select mission ids | UI string \| ICE\ICE.cs:318 |  |
| /icecosmic | /icecosmic | Command help \| ICE\ICE.cs:82; ICE\ICE.cs:92 |  |
| /vnav moveflag | /vnav moveflag | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:168; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:150 |  |
| 0 = will just keep buying | 0 = 将继续购买 | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:57 |  |
| 100% the cheapest will be applied | 100% 最便宜的将被应用 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:836; ICE\Ui\MainUi\Settings\GatherSettings.cs:882; ICE\Ui\MainUi\Settings\GatherSettings.cs:928 |  |
| 1: A position is saved: | 1：保存位置： | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:279 |  |
| 1: Score that you personally have set has been met | 1：已达到您个人设置的分数 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:991 |  |
| 1: This will check for your current CLASS [not menu class, actual current class] for relic turnin. | 1：这将检查您当前的职业[不是菜单职业，实际当前职业]是否有宇宙工具上交。 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:294 |  |
| 1: You have immaculate rng of getting the mission you want every time | 1：您每次都能完美地完成您想要的任务 | UI text \| ICE\Ui\Window_ExternalDetails.cs:374 |  |
| 2: A random spot even is saved | 2：甚至保存了一个随机点 | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:280 |  |
| 2: Timer has ran out | 2：计时器已用完 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:992 |  |
| 2: You must not have the tool eqipped for this to run full auto. | 2：您必须没有该工具配备此功能以全自动运行。 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:295 |  |
| 2: You're hitting the threshold every time | 2：您每次都会达到阈值 | UI text \| ICE\Ui\Window_ExternalDetails.cs:375 |  |
| 2nd Job | 第二职业 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:187 |  |
| 360 = the whole fan will be available for selection | 360 =整个扇形将可供选择 | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:102 |  |
| 3: This will take prio over "Stop @ Relic Turnin", in the sense that if you have both enabled, it will turnin vs stop. And continue about it's day | 3：这将优先于“停止 @ 宇宙工具 Turnin”，从某种意义上说，如果您同时启用了两者，它将转入与停止。继续今天的 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:297 |  |
| 4: If you're on a crafting class, it will return you back to the stop you were crafting post turnin. | 4：如果您正在上制作职业，它会让您回到交接后正在制作的站点。 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:298 |  |
| 50% chance to grant Eureka Moment | 50% 几率获得灵光一现 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:727 |  |
| ???? For some reason we're missing this. Please Report this to I | ????由于某种原因我们错过了这个。请将此报告给I | UI string \| ICE\Ui\MainWindow.cs:176 |  |
| A "Doyouthinkheseemesaurs" | A“Doyouthinkheseemesaurs” | UI string \| ICE\Ui\Window_ExternalDetails.cs:54 |  |
| A and above | A及以上 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:45 |  |
| A mode designed to automate mission selection for relic progression with minimal intervention. | A模式旨在以最小的干预自动选择宇宙工具升级的任务。 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:61 |  |
| A way for you to save your own positions if you choose to not use a randomized spot that's included in the plugin | 如果您选择不使用插件中包含的随机点，您可以保存自己的位置 | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:277 |  |
| Abandon | 放弃 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:127; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:417 |  |
| Abandon Mission | 放弃任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:34 |  |
| Above 0 to keep a set limit | 高于 0以保留一组上限 | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:233 |  |
| Action Info: | 动作信息： | UI text \| ICE\Ui\MainUi\Settings\GatherSettings.cs:485; ICE\Ui\MainUi\Settings\GatherSettings.cs:527; ICE\Ui\MainUi\Settings\GatherSettings.cs:571; ICE\Ui\MainUi\Settings\GatherSettings.cs:617; ICE\Ui\MainUi\Settings\GatherSettings.cs:673; ICE\Ui\MainUi\Settings\GatherSettings.cs:729; ICE\Ui\MainUi\Settings\GatherSettings.cs:781; ICE\Ui\MainUi\Settings\GatherSettings.cs:838; ICE\Ui\MainUi\Settings\GatherSettings.cs:884; ICE\Ui\MainUi\Settings\GatherSettings.cs:930; ICE\Ui\MainUi\Settings\GatherSettings.cs:975 |  |
| Activate Mission | 激活任务 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:223 |  |
| Add Armor/Housing/Mounts | 添加装甲/房屋/坐骑 | Button \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:86 |  |
| Add delay to athernet / npc travel | 添加以太之光延迟/npc旅行 | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:176 |  |
| Add delay to crafting menu | 添加制作菜单延迟 | Checkbox \| ICE\Ui\MainUi\Settings\SafetySettings.cs:55 |  |
| Add delay to gather | 添加采集延迟 | Checkbox \| ICE\Ui\MainUi\Settings\SafetySettings.cs:85 |  |
| Add delay to mission menu | 添加延迟任务菜单 | Checkbox \| ICE\Ui\MainUi\Settings\SafetySettings.cs:33 |  |
| Add Fishing Spot | 添加钓场 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:231 |  |
| Add Location | 添加位置 | Button \| ICE\Ui\MainUi\Settings\TravelSettings.cs:263 |  |
| Add Material/Dyes/Items | 添加材质/染料/物品 | Button \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:79 |  |
| Add Missing Fishing Holes | 添加缺失的钓场 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:32 |  |
| Add New Command | 添加新命令 | Button \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:245 |  |
| Add Node: {0} | 添加节点：{0} | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:189 |  |
| Add Position | 添加位置 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NavmeshTesting.cs:29 |  |
| Add Profile | 添加配置文件 | Button \| ICE\Ui\MainUi\Settings\GatherSettings.cs:334 |  |
| Add to Cosmic Agenda | 添加到宇宙议程 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:187 |  |
| Added | 额外 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:61 |  |
| Addon Ready: {0} | 插件就绪：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:14 |  |
| Adds a random delay before interacting with the aethershard / red alert npc travel. | 在与以太碎片/紧急任务交互之前添加随机延迟npc旅行. | Help marker \| ICE\Ui\MainUi\Settings\TravelSettings.cs:181 |  |
| Adds a small random offset to navigation destinations so the character doesn't always follow the exact same path | 向导航目的地添加一个小的随机偏移，以便角色不会总是遵循完全相同的路径 | Tooltip \| ICE\Ui\MainUi\Settings\TravelSettings.cs:72 |  |
| Adjust | 调整 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NavmeshTesting.cs:39 |  |
| Aethernet Test | 以太之光测试 | UI string \| ICE\Ui\DebugWindow.cs:91 |  |
| Aethershard Unlocked | 以太碎片解锁 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Aethernet.cs:66 |  |
| after | 后 | UI text \| ICE\Ui\MainUi\Settings\TravelSettings.cs:221 |  |
| Ageless Words / Solid Reason | 永恒的话语/坚实的理由 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:715 |  |
| Agenda | 议程 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:350; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:445 |  |
| Agenda Info: Profile Save | Agenda信息：配置文件保存 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:218; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:221 |  |
| Agenda List Viewer | Agenda列表查看器 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:293 |  |
| Agenda Missions Table: Favorites Info | 议程任务表：收藏夹信息 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:347 |  |
| Agenda Mode | 议程模式 | UI string \| Radio button \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:29; ICE\Ui\MainWindow.cs:137 |  |
| Agenda Mode: Tabs | 议程模式：选项卡 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:46 |  |
| Agenda Viewer: Details | 议程查看器：详细信息 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:315 |  |
| AgentMap is null! | AgentMap为空！ | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:20 |  |
| ALC | ALC | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:31; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:17; ICE\Ui\MainUi\Settings\Misc_Settings.cs:129 |  |
| Alchemist (ALC) | 炼金术士（ALC） | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:70 |  |
| All Class progresses | 所有职业进度 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:108 |  |
| All Classes | 所有职业 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:79 |  |
| All Current objects | 所有当前对象 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:268 |  |
| All fishing data exported to clipboard! | 导出到的所有钓鱼数据剪贴板！ | Chat message \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:60 |  |
| All gathering profile have been updated/automatically applied | 所有采集配置文件已更新/自动应用 | UI text \| ICE\Ui\InfoWindow.cs:99 |  |
| All Missions | 所有任务 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:45 |  |
| All Missions for this hole | 此洞的所有任务 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:135 |  |
| All world timers: | 所有世界计时器： | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_TimerInfo.cs:13 |  |
| Allow for all Provisional Jobs | 允许所有临时职业 | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:189 |  |
| Allows testing to make sure that you have the preset name | 允许测试以确保您拥有预设名称 | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1289 |  |
| Always navigate to the closest targetable node instead of following the fixed route order.<br>Useful for timed EX+ missions where speed matters. | 始终导航到最近的目标节点，而不是遵循固定的路线顺序。<br>对于速度快的限时EX+任务很有用事项. | Tooltip \| ICE\Ui\MainUi\Settings\TravelSettings.cs:61 |  |
| Amount | 数量 | Table column \| ICE\Ui\MainUi\Settings\GatherSettings.cs:275 |  |
| Amount #1 | 金额 #1 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:209 |  |
| Amount #2 | 金额 #2 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:211 |  |
| Amount #3 | 金额 #3 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:213 |  |
| Amount Enabled | 启用金额 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:368 |  |
| Amount [1] | 金额 [1] | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:26; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:32 |  |
| Amount [2] | 金额 [2] | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:28; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:34 |  |
| Amount [3] | 金额 [3] | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:30; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:36 |  |
| Amount [G-{0}] | 金额 [G-{0}] | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:220 |  |
| Amount [{0}] | 金额 [{0}] | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:32 |  |
| Amount: {0} | Amount：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:77; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:112 |  |
| and honestly I'm having a hard time putting it down | 老实说，我很难把它放下 | UI string \| ICE\Ui\Window_ExternalDetails.cs:31 |  |
| Anything above 0 will just be a hard cap and will stop buying if it reaches this | 任何高于0的东西都将只是一个硬上限，如果达到这个就会停止购买 | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:58 |  |
| Anything below 0 to keep all logs | 任何低于0的东西以保留所有日志 | Tooltip \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:232 |  |
| Anything besides that will chose within that fan (if it's available) | 除此之外的任何东西都将在该扇形内选择（如果可用） | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:103 |  |
| Apply | 应用 | Button \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:139 |  |
| Apply a 10% buff to your boon chance. | 对你的恩赐触发几率施加 10% 的增益。 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:525 |  |
| Apply a 30% buff to your boon chance. | 对你的恩赐触发几率施加 30% 的增益。 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:483 |  |
| Apply Temp | 应用临时 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:75; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:190 |  |
| Apply to agenda | 适用于议程 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:324 |  |
| Apply to all classes | 适用于所有职业 | Radio button \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:103 |  |
| Apply to Mission Types | 适用于任务类型 | Button \| ICE\Ui\MainUi\Settings\GatherSettings.cs:413 |  |
| Apply to similar missions | 适用于类似任务 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1415 |  |
| Apply to specific class | 适用于特定职业 | Radio button \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:109 |  |
| ARM | ARM | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:27; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:27; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:13; ICE\Ui\MainUi\Settings\Misc_Settings.cs:128 |  |
| Armorer (ARM) | 装甲师(ARM) | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:66 |  |
| Artisan Craft | Artisan工艺 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:260 |  |
| Artisan Endurance: {0} | Artisan耐力：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:205 |  |
| Artisan Is Busy? {0} | Artisan忙吗？{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:32 |  |
| Artisan Macro | Artisan宏 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1530 |  |
| Artisan, craft this | Artisan，制作这个 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:34 |  |
| Attribute | 属性 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:19 |  |
| Attribute Flags | 属性标志 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:193 |  |
| Auto Close Reward Popups | 自动关闭奖励弹出窗口 | Checkbox \| ICE\Ui\MainUi\Settings\SafetySettings.cs:91 |  |
| Auto Cordial | 自动强心剂 | Checkbox \| ICE\Ui\MainUi\Settings\GatherSettings.cs:190 |  |
| Auto Gamba | 自动抽奖 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:9; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:35 |  |
| Auto Hide/Show Planet Tokens | 自动隐藏/显示星球令牌 | Checkbox \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:47 |  |
| Auto Resize Overlay | 自动调整大小覆盖 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:94 |  |
| Auto Select | 自动选择 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:45 |  |
| Auto Select Job | 自动选择作业 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:138 |  |
| Auto start upon entering a Cosmic Exploration area | 输入时自动启动宇宙探索区 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:182 |  |
| Auto-Remove Stellar Status | 自动移除恒星状态 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:171 |  |
| Auto-Use | 自动使用 | Section header \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:167 |  |
| Auto-Use Stellar Sprint | 自动使用恒星冲刺 | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:47 |  |
| AutoHook | AutoHook | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:61 |  |
| Autohook Presets | Autohook预设 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:118 |  |
| Automate cosmodrone | 自动化cosmodrone | Checkbox \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:62 |  |
| Automatically removes the Star Contributor visual effect (the glow you get for being a top contributor). | 自动移除明星贡献者视觉效果（作为顶级贡献者所获得的光芒）. | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:178 |  |
| Automating Hub Activities | 自动寻路 | Section header \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:31 |  |
| Average SPM: {0} | 平均SPM：{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1331 |  |
| Average Time History to keep | 要保留的平均时间历史 | Input label \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:223 |  |
| Average Time: --:--:-- | 平均时间：--:--:-- | UI text \| ICE\Ui\Window_ExternalDetails.cs:356 |  |
| Average Time: {0} | 平均时间：{0} | UI text \| ICE\Ui\Window_ExternalDetails.cs:351 |  |
| Avoid Stellar Return for pathing | 避免寻路的恒星返回 | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:129 |  |
| B and above | B及以上 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:45 |  |
| Bait is not currently equipped | 诱饵当前未装备 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:90 |  |
| Bait is null... aka not in the middle of a mission | 诱饵为空...又名不在任务中间 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:103 |  |
| Basic Missions | 基本任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:44 |  |
| Basic missions (Ranks D→A) will only pull from the class you started on. | 基本任务（等级D→A）只会从您开始的职业中提取。 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:50 |  |
| Battle Job | 战斗职业 | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:971; ICE\Ui\MainUi\Settings\Character_Settings.cs:1012 |  |
| Because they have hallow-eenies | 因为他们有万圣节 | UI string \| ICE\Ui\Window_ExternalDetails.cs:37 |  |
| Because they start their match at "Love All" | 因为他们在“Love All”开始比赛 | UI string \| ICE\Ui\Window_ExternalDetails.cs:34 |  |
| Best Mission for leveling: [{0}] | 最佳升级任务：[{0}] | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:106 |  |
| Best Relic Mission: {0} \| {1} | 最佳宇宙工具任务：{0} \|{1} | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:165 |  |
| Best Score Per Minute | 每分钟最佳分数 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1312 |  |
| Best Time: --:--:-- | 最佳时间：--:--:-- | UI text \| ICE\Ui\Window_ExternalDetails.cs:355 |  |
| Best Time: {0} | 最佳时间：{0} | UI text \| ICE\Ui\Window_ExternalDetails.cs:350 |  |
| Beta, might not work | Beta，可能不起作用 | UI text (disabled) \| ICE\Ui\MainUi\Settings\TravelSettings.cs:126 |  |
| between missions — enable the multi-class setting to allow switching classes for these as well. | 任务之间 - 启用多职业设置以允许切换这些职业。 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:52 |  |
| Black Mage | 黑法师 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:43; ICE\Ui\MainUi\Settings\Character_Settings.cs:1057 |  |
| Blacksmith (BSM) | 铁匠（BSM） | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:65 |  |
| Blessed / Kings Yield I | 祝福/国王产量 I | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:659 |  |
| Blessed / Kings Yield II | 祝福/国王产量 II | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:603 |  |
| Boon Scoring | 恩赐得分 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:37 |  |
| Botanist (BTN) | 园艺工 (BTN) | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:73 |  |
| Bountiful Yield II / Bountiful Harvest II | 丰沛产量 II / 丰收 II | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:768 |  |
| Brazen Power | 黄铜力量 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:109 |  |
| Bronze | 铜星 | Table column \| Radio button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:190; ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:132 |  |
| Bronze Requirement | 铜星要求 | UI text \| ICE\Ui\Window_ExternalDetails.cs:202 |  |
| Bronze: 1 Item | 铜星：1物品 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:462 |  |
| Browse... | 浏览... | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:131 |  |
| BSM | BSM | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:26; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:27; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:12; ICE\Ui\MainUi\Settings\Misc_Settings.cs:128 |  |
| BTN | BTN | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:34; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:20; ICE\Ui\MainUi\Settings\Misc_Settings.cs:130 |  |
| But I know there's going to be people who enable this and don't read, so it's a tehe. | 但我知道会有人启用此功能但不阅读，所以这是一个tehe. | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:325 |  |
| Buy | 买 | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:219 |  |
| Buy 1 Item | 购买 1 件商品 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:129; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:211 |  |
| Buy At Amount | 按金额购买 | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:35 |  |
| Buy Drones | 购买无人机 | Checkbox \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:24 |  |
| Buy Item | 购买物品 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:60 |  |
| Buy Items | 购买物品 | Checkbox \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:29 |  |
| Buy Items from shop | 从商店购买物品 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:72 |  |
| Buy Max | BuyMax | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:135; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:217 |  |
| Buy: Will buy X amount of those items, as it buys it from the vendor, the number will decrease until it hits 0. | 购买：将购买 X 数量的这些物品，当它从供应商处购买时，数量会减少，直到达到 0. | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:44 |  |
| Buying from shop throttle | 从商店节气门购买 | UI string \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:137; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:219 |  |
| C and above | C 及以上 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:45 |  |
| Carpenter (CRP) | 木匠 (CRP) | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:64 |  |
| Category | 职业 | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:72 |  |
| Chain + Boon Scoring | 连锁+奖励得分 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:38 |  |
| Chained Gather Scoring | 连锁聚集得分 | UI string \| ICE\Ui\Window_ExternalDetails.cs:454 |  |
| Chained Scoring | Chained评分 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:36 |  |
| Change mode | 更改模式 | UI text \| ICE\Ui\OverlayWindow.cs:131 |  |
| Change to gamba | 更改为抽奖 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:127 |  |
| Character Settings | 角色设置 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:112 |  |
| Character Specific | 角色特定 | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:53 |  |
| Class | 职业 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:32 |  |
| Class Exp | 类经验 | Table column \| ICE\Ui\Window_ExternalDetails.cs:264 |  |
| Class Progress | Class进度 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:103; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:151 |  |
| Class Progress: All | Class进度：全部 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:725 |  |
| Class Progress: Icon Preview | Class进度：图标预览 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:699 |  |
| Class Score | Class分数 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:811; ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:12 |  |
| Class Score: | Class分数： | UI text \| ICE\Ui\Window_ExternalDetails.cs:171 |  |
| Class Selection | Class选择 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:50 |  |
| Class Selection Table | Class选择表 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:52 |  |
| Class Swap | ClassSwap | Section header \| ICE\Ui\MainUi\Settings\Character_Settings.cs:958 |  |
| ClassTracker | 职业追踪器 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:46 |  |
| Clear | 清除 | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:41; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionText.cs:25 |  |
| Clear All | 清除全部 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:375 |  |
| Clear All Selections | 清除所有选择 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:404 |  |
| Clear Profile | 清除配置文件 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1293 |  |
| Clear shopping list | 清除购物清单 | Button \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:93 |  |
| Clear stored scores | 清除存储的分数 | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:121 |  |
| Clear Task | 清除任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:256 |  |
| Click Nearest Collection Point | 单击最近的采集点 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:303 |  |
| Click Nearest EventObject | 单击最近的事件对象 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:291 |  |
| Click to override mount for this character | 单击以覆盖此角色的安装 | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:803 |  |
| Click to override this setting for this character | 单击以覆盖此角色的此设置字符 | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:100; ICE\Ui\MainUi\Settings\Character_Settings.cs:122 |  |
| Collected Individual | 采集的个体 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:88 |  |
| Collected Total | 采集的总计 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:94 |  |
| Column 0 | 列0 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:27 |  |
| Column 1 | 列1 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:28 |  |
| Column 10 | 列10 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:37 |  |
| Column 11 | 列11 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:38 |  |
| Column 12 | 列12 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:39 |  |
| Column 13 | 列13 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:40 |  |
| Column 14 | 列14 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:41 |  |
| Column 15 | 列15 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:42 |  |
| Column 16 | 列 16 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:43 |  |
| Column 17 | 列 17 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:44 |  |
| Column 2 | 列 2 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:29 |  |
| Column 3 | 列 3 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:30 |  |
| Column 4 | 列 4 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:31 |  |
| Column 5 | 列 5 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:32 |  |
| Column 6 | 列 6 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:33 |  |
| Column 7 | 列 7 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:34 |  |
| Column 8 | 列 8 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:35 |  |
| Column 9 | 列 9 | Table column \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:36 |  |
| Command | 命令 | Table column \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:260 |  |
| Completed: | 完全的： | UI text \| ICE\Ui\Window_ExternalDetails.cs:193 |  |
| Completion | 完成 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:222 |  |
| Completion Stats | Completion统计 | UI string \| ICE\Ui\Window_ExternalDetails.cs:115; ICE\Ui\Window_ExternalDetails.cs:414 |  |
| Cone Color Editor | 圆锥颜色编辑器 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:221 |  |
| Confirm | 确认 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:30 |  |
| Copied {0} fishing missions to clipboard! | 已将{0}钓鱼任务复制到剪贴板！ | Tooltip \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:111 |  |
| Copy Auxesia CSV | 复制奥克塞西亚行星 CSV | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:79 |  |
| Copy current set | 复制当前集 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:65 |  |
| Copy Flag | 复制标志 | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:366 |  |
| Copy Ids | 复制ID | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionText.cs:54 |  |
| Copy Info | 复制信息 | Button \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:178 |  |
| Copy Item List | 复制项目列表 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:76; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:162 |  |
| Copy Logs | 复制日志 | Button \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:55 |  |
| Copy logs to clipboard | 将日志复制到剪贴板 | Button \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:41 |  |
| Copy Missing CSV | 复制缺失的CSV | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:57 |  |
| Copy Scores | 复制分数 | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:51 |  |
| Copy Selected | 复制选定的 | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:32 |  |
| Copy Selected Profile | 复制选定的配置文件 | Button \| ICE\Ui\MainUi\Settings\GatherSettings.cs:1013 |  |
| Copy to Clipboard | 复制到剪贴板 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:500 |  |
| Copy Vector2 | 复制向量2 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:42 |  |
| Copy Vector3 | 复制向量3 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:47 |  |
| Cordial Busy | 强心剂的忙碌 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:362 |  |
| Cordial Check | 强心剂的检查 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:304 |  |
| Cordial Checkers | 强心剂的跳棋 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:308 |  |
| Cordial Settings | 强心剂的设置 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:197 |  |
| Cordial Test | 强心剂测试 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:133 |  |
| Cosmic Agenda | 宇宙议程 | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Tips.cs:27; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:84; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:97; ICE\Ui\MainUi\SelectableSidebar.cs:40; ICE\Ui\OverlayWindow.cs:165 |  |
| Cosmic Agenda Mode | 宇宙议程模式 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:422 |  |
| Cosmic Agenda Table | 宇宙议程表 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:439 |  |
| Cosmic Class Info | 宇宙职业信息 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:12 |  |
| Cosmic Helper | 宇宙助手 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:37 |  |
| Cosmo Crafting Log | Cosmo制作日志 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:106 |  |
| Cosmo Credits | Cosmo信用点 | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:10 |  |
| Cosmo Gear Shop | Cosmo装备店 | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:149 |  |
| Cosmo Materia Shop | Cosmo材料店 | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:127 |  |
| Cosmo Pouch | CosmoPouch | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:99 |  |
| CosmocreditMateriaPopup | CosmocreditMateriaPopup | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:120 |  |
| Cosmocredits | 宇宙信用点 | UI text \| ICE\Ui\Window_ExternalDetails.cs:134 |  |
| Cosmocredit_MountArmorPopup | Cosmocredit_MountArmorPopup | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:142 |  |
| Cost | 成本 | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:215 |  |
| Could not find a contiguous arc of reachable angles. | 无法找到可到达角度的连续弧。 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:536 |  |
| Count | 数数 | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:70 |  |
| Craft Details | 工艺详细信息 | UI string \| ICE\Ui\Window_ExternalDetails.cs:108 |  |
| Craft Item Settings | 工艺项目设置 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1409 |  |
| Craft Settings: Recipies | 工艺设置：食谱 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1186; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1189; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:532; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:535 |  |
| Crafting | 制作 | Section header \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:19 |  |
| Crafting Return Spot | 制作返回点 | Section header \| ICE\Ui\MainUi\Settings\TravelSettings.cs:237 |  |
| Create files | 创建文件 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:367 |  |
| Create waypoint list | 创建航路点列表 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:54 |  |
| Credit / Planetary Credits / Token farming | 信用/行星信用点/代币耕作 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:48 |  |
| Credit Shopping | 信用购物 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:100 |  |
| Credits | 信用点 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:865 |  |
| Critical Area | 紧急任务区域 | UI text \| ICE\Ui\Window_ExternalDetails.cs:247 |  |
| Critical Location | 紧急任务地点 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:35 |  |
| Critical Mission | 紧急任务 | UI string \| ICE\Ui\Window_ExternalDetails.cs:459 |  |
| Critical Missions | 紧急任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:56 |  |
| Critical Value: | 临界值： | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:70 |  |
| Critical: Allow All Classes | 紧急任务：允许所有职业 | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:258 |  |
| CRP | CRP | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:25; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:27; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:11; ICE\Ui\MainUi\Settings\Misc_Settings.cs:128 |  |
| CS: Available Missions | CS：可用任务 | UI string \| ICE\Ui\DebugWindow.cs:74 |  |
| CS: Missions Avaialble | CS：可用任务 | UI string \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:37 |  |
| CS: Tiemr Info | CS：Tiemr信息 | UI string \| ICE\Ui\DebugWindow.cs:73 |  |
| CUL | CUL | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:32; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:18; ICE\Ui\MainUi\Settings\Misc_Settings.cs:129 |  |
| Culinarian (CUL) | Culinarian（CUL） | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:71 |  |
| Currency Amount: {0} | 货币金额：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:23 |  |
| Current | 当前的 | Table column \| ICE\Ui\OverlayWindow.cs:75 |  |
| Current Agenda | Current议程 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:48 |  |
| Current Bait | 当前诱饵 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:80 |  |
| Current Collectability: | 当前收藏价值： | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:55 |  |
| Current location: {0} \| Currency Amount: {1} | 当前位置：{0} \|货币金额：{1} | UI text \| ICE\Ui\MainUi\Settings\GambaWheel.cs:58; ICE\Ui\MainUi\Settings\GambaWheel.cs:135 |  |
| Current Mission: | 当前任务： | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:38 |  |
| Current Mission: {0} | 当前任务：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:59; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:204 |  |
| Current planet has no stored fishing holes in the sheets. (Might need to be added?) | 当前星球上没有存储的钓场。（可能需要添加？） | UI text \| ICE\Ui\MainUi\Settings\TravelSettings.cs:342 |  |
| Current pos: {0} \| {1} \| {2} | 当前位置：{0} \|{1} \|{2} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NavmeshTesting.cs:27 |  |
| Current Score: | 当前分数： | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:46 |  |
| Current Score: {0} | 当前分数：{0} | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:599 |  |
| Current Stage | 当前阶段 | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:35 |  |
| Current State | 当前状态 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:53 |  |
| Current State: {0} | 当前状态：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:18 |  |
| Current task running: {0} | 当前任务运行：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:17 |  |
| Current Territory/ZoneId: {0} | 当前领土/区域ID：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:53 |  |
| Current Tool XP | 当前工具XP | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:160 |  |
| Current waypoint list count: {0} | 当前路径点列表计数：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:46 |  |
| Current XP | 当前XP | Input label \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:131; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:26 |  |
| Current: {0} | 当前：{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:749 |  |
| Currently have: {0} Grade 8 Dark Matter | 当前有：{0} 8级暗物质 | UI text \| ICE\Ui\MainUi\Settings\Character_Settings.cs:262 |  |
| Currently Selected: {0} | 当前选择：{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1229; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:473 |  |
| Currently there isn't a way to stop artisan from crafting, it's been requested | 当前没有办法阻止Artisan制作，已要求 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:979 |  |
| Custom Is Busy: {0} | 自定义忙：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:170 |  |
| D and above | D及以上 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:45 |  |
| Dark Knight | 黑暗骑士 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:20; ICE\Ui\MainUi\Settings\Character_Settings.cs:1048 |  |
| DEBUG TEST | 调试测试 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:292 |  |
| Default | 默认 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1712; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1768; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1825; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1874; ICE\Ui\MainUi\Settings\Character_Settings.cs:472; ICE\Ui\MainUi\Settings\Character_Settings.cs:507; ICE\Ui\MainUi\Settings\Character_Settings.cs:549; ICE\Ui\MainUi\Settings\Character_Settings.cs:584; ICE\Ui\MainUi\Settings\Character_Settings.cs:626; ICE\Ui\MainUi\Settings\Character_Settings.cs:657; ICE\Ui\MainUi\Settings\Character_Settings.cs:695; ICE\Ui\MainUi\Settings\Character_Settings.cs:726 |  |
| Delay | 延迟 | Table column \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:261 |  |
| Delay Post Relic Turnin | 延迟宇宙工具上交后 | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:79 |  |
| Delete | 删除 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:258 |  |
| Delete Profile | 删除配置文件 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:339 |  |
| Delete Selected Profile | 删除选定的配置文件 | Button \| ICE\Ui\MainUi\Settings\GatherSettings.cs:357 |  |
| Depending on what you want / what your goal is, these all serve all different functions. | 取决于你想要什么/什么你的目标是，这些都服务于所有不同的功能。 | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:13 |  |
| Description | 描述 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:224 |  |
| Description: {0} | Description：{0} | UI text (wrapped) \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:319 |  |
| Destination | 目的地 | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:151 |  |
| Destination Log Viewer | 目标日志查看器 | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:147 |  |
| Destination Logs | 目的地日志 | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:28 |  |
| Detailed Class View | 详细的类视图 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:44 |  |
| Detailed Mission Info | 详细的任务信息 | UI string \| ICE\Ui\Window_ExternalDetails.cs:126 |  |
| Dev Favorites | Dev favorites | Section header \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:309 |  |
| Dictionary code copied to clipboard! | 字典代码复制到剪贴板！ | Chat message \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:503 |  |
| Disable Autohook | DisableAutohook | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:115 |  |
| Disable Endurance | 禁用耐力 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:207 |  |
| Disable HUD Clipping | 禁用HUD剪裁 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:154 |  |
| Disable Pathfinding to Red Alerts | 禁用紧急任务寻路 | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:162 |  |
| Dismount Target Range | 卸载目标范围 | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:875; ICE\Ui\MainUi\Settings\Character_Settings.cs:911 |  |
| Dismount_Radius Circle | 下马_半径圆 | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:931 |  |
| Distance | 距离 | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:152 |  |
| Distance before hub return is used (yalms) | 使用枢纽返回之前的距离（亚尔姆斯） | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:155 |  |
| Distance to nearest: {0} | 到最近的距离：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:297; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:309 |  |
| Distance: {0} | 距离：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:46; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:76 |  |
| Do you want to buy drones? If yes, enable this | 您想购买无人机吗？如果是，请启用此 | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:30 |  |
| Do you want to run the automated drone finding? If yes, enable this | 您想运行自动无人机查找吗？如果是，请启用此 | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:68 |  |
| Don't do hub activities when a red alert is active | 紧急任务处于活动状态时不执行自动寻路 | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:169 |  |
| Drawing Mission Table | 绘制任务表 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionsV3.cs:56; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:489 |  |
| Drone Ready: {0} | 无人机就绪：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:118 |  |
| Drone Search | 无人机搜索 | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:157 |  |
| Dronebit Settings | Dronebit设置 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:104 |  |
| Dronebits | 无人机 | UI text \| ICE\Ui\Window_ExternalDetails.cs:162 |  |
| Dropdown Detail | 下拉详细信息 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1500 |  |
| Dropdown Selection | 下拉选择 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1501 |  |
| Dual Class | 双类 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:39 |  |
| Durability: {0} | 耐用性：{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1700 |  |
| E8 ?? ?? ?? ?? 84 C0 75 58 FF C3 | E8 ????????84 C0 75 58 FF C3 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishingRaycast.cs:21 |  |
| Each planet has a dedicated set of missions are deemed the most "Optimal" when it comes to farming score. | 每个星球都有一组专门的任务，在刷分方面被认为是最“最佳”的。 | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\helpSelect_Tips.cs:75 |  |
| Editing Spot {0}: | 编辑点{0}： | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:273 |  |
| Enable | 使能够 | Checkbox \| ICE\Ui\MainUi\Settings\GatherSettings.cs:488; ICE\Ui\MainUi\Settings\GatherSettings.cs:530; ICE\Ui\MainUi\Settings\GatherSettings.cs:574; ICE\Ui\MainUi\Settings\GatherSettings.cs:620; ICE\Ui\MainUi\Settings\GatherSettings.cs:676; ICE\Ui\MainUi\Settings\GatherSettings.cs:732; ICE\Ui\MainUi\Settings\GatherSettings.cs:784; ICE\Ui\MainUi\Settings\GatherSettings.cs:841; ICE\Ui\MainUi\Settings\GatherSettings.cs:887; ICE\Ui\MainUi\Settings\GatherSettings.cs:933; ICE\Ui\MainUi\Settings\GatherSettings.cs:978 |  |
| Enable Auto Gamba | 启用自动抽奖 | Checkbox \| ICE\Ui\MainUi\Settings\GambaWheel.cs:18 |  |
| Enable Auto Gamba Wheel | 启用自动抽奖轮 | Checkbox \| ICE\Ui\MainUi\Settings\GambaWheel.cs:96 |  |
| Enable AutoHook | 启用AutoHook | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:111 |  |
| Enable Dummy XP | 启用虚拟XP | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:69 |  |
| Enabled | 启用 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:252 |  |
| Enabled Mission Table | 启用任务表 | UI string \| ICE\Ui\OverlayWindow.cs:320 |  |
| Enabling this will make it to where pandora's cordial feature won't be auto-paused. | 启用此功能将使其到潘多拉的强心剂功能不会自动暂停的位置。 | Help marker \| ICE\Ui\MainUi\Settings\GatherSettings.cs:187 |  |
| Enabling this will show you all weather/timed/sequence missions that you can grind, | 启用此功能将向您显示您可以完成的所有天气/限时/序列任务， | Help marker \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:253 |  |
| End Hour | 结束时间 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_TimeWeather.cs:16 |  |
| Error: Please specify an export path | 错误：请指定导出路径 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:506 |  |
| Estimated Score Per Hour: | 每小时估计分数： | UI text \| ICE\Ui\Window_ExternalDetails.cs:367 |  |
| Event Markers | 事件标记 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:24; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:93 |  |
| EX and above | EX及以上 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:45 |  |
| EX. /ice add 10 155 185 | EX。/ice 添加 10 155 185 | UI string \| ICE\ICE.cs:315 |  |
| Except for hub activities | 中心活动除外 | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:142 |  |
| Exp Grinding | Exp刷取 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:47 |  |
| Exp Rewards | Exp奖励 | UI string \| ICE\Ui\Window_ExternalDetails.cs:262 |  |
| ExpBar | ExpBar | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:807 |  |
| Expected to start with: AH4_ | 预计开始于：AH4_ | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:105 |  |
| Expedition Log | 远征日志 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:41 |  |
| Expedition: Class Selection | 远征：职业选择 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:36 |  |
| Expert Craft | 专家工艺 | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1628 |  |
| Expert Craft Settings | 专家工艺设置 | Table column \| ICE\Ui\MainUi\Settings\Character_Settings.cs:394 |  |
| Expert Craft: {0} | 专家工艺：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:71; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:104 |  |
| Expert Crafts | 专家工艺 | UI string \| ICE\Ui\Window_ExternalDetails.cs:452 |  |
| Expert Recipe Solver | 专家配方求解器 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1529; ICE\Ui\MainUi\Settings\Character_Settings.cs:320 |  |
| Expires in {0} | 到期于{0} | UI text \| ICE\Ui\OverlayWindow.cs:450 |  |
| Export | 出口 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:216 |  |
| Export All Fishing Data | 导出所有钓鱼数据 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:56 |  |
| Export All Presets | 导出所有预设 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:82 |  |
| Export CSV | 导出CSV | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:160 |  |
| Export Fishing Missions | 导出钓鱼任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:94 |  |
| Export Missing CSV | 导出缺失的CSV | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:149 |  |
| Export Selected Flag | 导出选定的旗帜 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:66 |  |
| Export Selected Mission | 导出选定的任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:88 |  |
| Export Selected to Dictionary | 将选定的任务导出到字典 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:397 |  |
| Export to Clipboard | 导出到剪贴板 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:258 |  |
| Exported Icon Dictionary | 导出图标字典 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:498 |  |
| Extract Spiritbond on Gather | 在采集时提取Spiritbond | Checkbox \| ICE\Ui\MainUi\Settings\GatherSettings.cs:179 |  |
| Face toward spot | 面向点 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:190 |  |
| Failed to deserialize profile | 反序列化失败轮廓 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:86; ICE\Ui\MainUi\Settings\GatherSettings.cs:133 |  |
| Fan Height | 扇形高度 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:335 |  |
| Field Mastery \| Sharp Vision I | 领域掌握\|敏锐的视野I | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:916 |  |
| Field Mastery \| Sharp Vision II | 领域掌握\|敏锐视野II | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:870 |  |
| Field Mastery \| Sharp Vision III | 领域掌握\|Sharp Vision III | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:824 |  |
| Fill Both | 两者都填写 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MoonRecipe.cs:25 |  |
| Fill HQ | 填写HQ | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MoonRecipe.cs:19 |  |
| Fill NQ | 填写NQ | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MoonRecipe.cs:13 |  |
| Filter by current job only | 仅按当前作业过滤 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:116 |  |
| Filters which planets appear in the<br>mission list and the overlay. | 过滤哪些行星出现在<br>任务列表和叠加层中。 | UI text \| ICE\Ui\MainUi\SelectableSidebar.cs:60 |  |
| Find Mission | 查找任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:252 |  |
| Finding drone locations is turned off, so we're just going to ignore this. If you want to run this, please enable it | 查找无人机位置已关闭，因此我们将忽略它。如果您想运行此功能，请启用 | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:168 |  |
| First Available Fishing Spot: {0}, {1}, {2} | 第一个可用钓场：{0}、{1}、{2} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:189 |  |
| Fish Editor \| Window Selector | Fish Editor \|窗口选择器 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:21 |  |
| Fish Item Info | 鱼项信息 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:46 |  |
| Fisher (FSH) | 费舍尔 (FSH) | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:74 |  |
| Fishing Editor Table | 钓鱼编辑表 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:82 |  |
| Fishing flag data for Zone {0} at ({1}, {2}) exported to clipboard! | 位于({1}, {2})的区域{0}的钓鱼标志数据导出到剪贴板！ | Chat message \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:70 |  |
| Fishing Hole Editor | 钓场编辑器 | Table column \| UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:85; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:121 |  |
| Fishing Hole Selector | 钓场选择器 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:84 |  |
| Fishing Info | 钓鱼信息 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:15 |  |
| Fishing Location Selector | 钓鱼位置选择器 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:91 |  |
| Fishing Position | 钓鱼位置 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:279 |  |
| Fishing profile: {0} | 钓鱼配置文件：{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1264; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:504 |  |
| Fishing raycast initialized successfully | 钓鱼光线投射初始化成功 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishingRaycast.cs:22 |  |
| Fishing Settings | 钓鱼设置 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1258 |  |
| Flag | 旗帜 | Table column \| Button \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:42; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:355 |  |
| Flora Mastery \| Clear Vision [Temp] | Flora Mastery \|清除 Vision [Temp] | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:962 |  |
| Font Test | 字体测试 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:356 |  |
| Food | 食物 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1705; ICE\Ui\MainUi\Settings\Character_Settings.cs:464 |  |
| Food Item | 食品项目 | Table column \| ICE\Ui\MainUi\Settings\GatherSettings.cs:274 |  |
| Food Item Selection | 食品选择 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:272 |  |
| Food Selection | 食物选择 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:257; ICE\Ui\MainUi\Settings\GatherSettings.cs:270 |  |
| Food Settings | 食物设置 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:232 |  |
| Food [HQ] | 食物 [HQ] | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:142 |  |
| Food [NQ] | 食物 [NQ] | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:147 |  |
| For botanist/miner/fisher | For 园艺工/采矿工/捕鱼人 | UI text \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:24 |  |
| For BTN/MIN, this will gather the non-collectable item | ForBTN/MIN，这将采集不可采集的物品 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1014 |  |
| For fisher only | 仅适用于捕鱼人 | UI text \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:27 |  |
| For most of you this would be fine, this is really only here if you don't know what to apply for each one. | 对于你们大多数人来说这很好，这实际上只是在您不知道要为每件申请什么时才在这里。 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:1048 |  |
| for your current class — you pick what you want done, and it handles the rest. | 对于您当前的课程 - 您选择您想要完成的事情，它会处理其余的事情。 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:44 |  |
| Force OOM Main | 强制 OOM 主要 | Checkbox \| ICE\Ui\MainUi\Settings\DebugTab.cs:18 |  |
| Force OOM Sub | 强制 OOM 子项 | Checkbox \| ICE\Ui\MainUi\Settings\DebugTab.cs:19 |  |
| from automating the gathering and crafting process, to the buying of shop items or spending those planetary credits away. | 从自动化采集和制作过程，到购买商店物品或花费这些行星信用点。 | UI string \| ICE\Ui\InfoWindow.cs:45 |  |
| FSH | FSH | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:35; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:21; ICE\Ui\MainUi\Settings\Misc_Settings.cs:130 |  |
| Gamba Delay | 抽奖延迟 | UI string \| ICE\Ui\MainUi\Settings\GambaWheel.cs:39; ICE\Ui\MainUi\Settings\GambaWheel.cs:116 |  |
| Gamba Item Tabs | 抽奖物品选项卡 | UI string \| ICE\Ui\MainUi\Settings\GambaWheel.cs:147 |  |
| Gamble Between Runs | 跑步之间的赌博 | Checkbox \| ICE\Ui\MainUi\Settings\GambaWheel.cs:31; ICE\Ui\MainUi\Settings\GambaWheel.cs:109 |  |
| Gambling Settings | 赌博设置 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:101 |  |
| Gather Fan | Gather粉丝 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:343 |  |
| Gather Item [{0}] | 采集物品[{0}] | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:31 |  |
| Gather Profiles | 采集配置文件 | UI text \| ICE\Ui\MainUi\Settings\GatherSettings.cs:352 |  |
| Gather Route Editor Table | 采集路线编辑表 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:64 |  |
| Gather x Amount | 采集x数量 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:34 |  |
| Gather [{0}] | 采集[{0}] | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:219 |  |
| Gatherer's Boons Scoring | 采集者的奖励得分 | UI string \| ICE\Ui\Window_ExternalDetails.cs:455 |  |
| Gathering | 采集 | Section header \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:23 |  |
| Gathering Fan Selection | 采集粉丝选择 | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:94 |  |
| Gathering Profile | 采集配置文件 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:109 |  |
| Gathering Profile Settings | 采集配置文件设置 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:321 |  |
| gathering routes | 采集路线 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:200 |  |
| Gathering Settings | 采集设置 | Table column \| ICE\Ui\MainUi\Settings\GatherSettings.cs:324 |  |
| Gathering Setup | 采集设置 | Section header \| ICE\Ui\InfoWindow.cs:51 |  |
| Gathering Zone | 采集区 | UI text \| ICE\Ui\Window_ExternalDetails.cs:230 |  |
| Gearset Viewer | 齿轮组查看器 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Gearsets.cs:46 |  |
| Generate Fan from Navmesh | 从导航网格生成扇形 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:302 |  |
| Get Active List | 获取活动列表 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Aethernet.cs:61 |  |
| Get current hub forecast | 获取当前中心预测 | Button \| ICE\Ui\MainUi\Settings\DebugTab.cs:21 |  |
| Global Artisan Settings | 全局Artisan设置 | Section header \| ICE\Ui\MainUi\Settings\Character_Settings.cs:270 |  |
| Global Character Settings | 全局角色设置 | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:27 |  |
| Global setting — applies to all characters. | 全局设置-适用于所有角色。 | Tooltip \| ICE\Ui\MainUi\Settings\Character_Settings.cs:890; ICE\Ui\MainUi\Settings\Character_Settings.cs:895; ICE\Ui\MainUi\Settings\Character_Settings.cs:905; ICE\Ui\MainUi\Settings\Character_Settings.cs:917 |  |
| Go buy items when you reach | 当你购买物品时达到 | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:56 |  |
| Goal: {0} | 目标：{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:750 |  |
| Gold | 金星 | Table column \| Radio button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:192; ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:124 |  |
| Gold Completion Grind | 达成金星 | UI string \| Radio button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:79; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:92; ICE\Ui\MainWindow.cs:131; ICE\Ui\OverlayWindow.cs:166 |  |
| Gold Completion Mode | 达成金星模式 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:421; ICE\Ui\MainWindow.cs:171 |  |
| Gold Requirement | 金星要求 | UI text \| ICE\Ui\Window_ExternalDetails.cs:220 |  |
| Gold Sequence | 金星序列 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:809 |  |
| Gold: 3 Items | 金星：3件 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:460 |  |
| Goldsmith (GSM) | 金匠（GSM） | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:67 |  |
| Good for one off buys, or something that you only need a particular amount of | 适合一次性购买，或者您只需要特定数量的 | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:45 |  |
| GSM | GSM | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:28; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:27; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:14; ICE\Ui\MainUi\Settings\Misc_Settings.cs:128 |  |
| Has Tokens | HasTokens | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:479 |  |
| Have | 有 | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:214 |  |
| Having this enabled means it will use the default preset that is included with the plugin for autohook. | 启用此功能意味着它将使用 autohook 插件中包含的默认预设。 | Help marker \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1272; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:512 |  |
| Hehe | 呵呵 | UI text \| ICE\Ui\MainWindow.cs:97 |  |
| Help | 帮助 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:26 |  |
| Here's what each of the following does: | 以下是以下各项的作用： | UI text \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:41 |  |
| Hey! You need to update artisan to use this mode, please update to at minimum: | 嘿！您需要更新 artisan 才能使用此模式，请至少更新到： | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:182 |  |
| Hey! You seem to not have any standardard missions enabled on the planet/moon you're currently on. | Hey！您似乎没有在当前所在的行星/月球上启用任何标准任务。 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:649 |  |
| Hey! Your version of autohook is not currently supported on this planet | 嘿！这个星球目前不支持您的 autohook 版本 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:214 |  |
| Hey! {0} is not supported for leveling yet. | 嘿！尚不支持 {0} 升级。 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:195 |  |
| Hi! Welcome to Ice's Cosmic Exploration [Short form, I.C.E.] | 嗨！欢迎来到 Ice 的宇宙探索 [简写形式，I.C.E.] | UI text \| ICE\Ui\InfoWindow.cs:42 |  |
| Hide Completed | 隐藏已完成 | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:159 |  |
| Hide tab list | 隐藏选项卡列表 | Tooltip \| ICE\Ui\DebugWindow.cs:32 |  |
| Hide Unsupported Missions | 隐藏不支持的任务 | Checkbox \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:40 |  |
| High Collectibility: | 高收藏性： | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:87 |  |
| Highlight EX+ token weathers | 突出显示 EX+ 代币天气 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:102 |  |
| Highlight Visible Missions | 突出显示可见任务 | Checkbox \| ICE\Ui\MainUi\Settings\DebugTab.cs:61 |  |
| Hold Control to delete profile | 按住 Control 删除个人资料 | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:344 |  |
| Hold Shift + Control | 按住 Shift + Control | UI text \| ICE\Ui\Window_ExternalDetails.cs:344 |  |
| Hold shift to allow applying | Hold shift允许申请 | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:332; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1492 |  |
| Honestly, just wanted to say thank you for using my plugin, you're appreciated <3 | 老实说，只是想说谢谢您使用我的插件，非常感谢<3 | UI string \| ICE\Ui\Window_ExternalDetails.cs:45 |  |
| How do you save a drowning pirate? | 您如何拯救溺水海盗？ | UI string \| ICE\Ui\Window_ExternalDetails.cs:39 |  |
| HQ Regular Cordial | HQ普通强心剂 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:314 |  |
| HQ Watered Cordial | HQ 兑水强心剂 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:316 |  |
| Hub Activities | Hub活动 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:98 |  |
| Hud: Gather Collectable | Hud：采集收藏品 | UI string \| ICE\Ui\DebugWindow.cs:53 |  |
| Hud: Item Exchange | Hud：物品交换 | UI string \| ICE\Ui\DebugWindow.cs:54 |  |
| Hud: Mission | Hud：任务 | UI string \| ICE\Ui\DebugWindow.cs:49 |  |
| Hud: Mission Info | Hud：任务信息 | UI string \| ICE\Ui\DebugWindow.cs:50 |  |
| Hud: Moon Main | Hud：月球主 | UI string \| ICE\Ui\DebugWindow.cs:48; ICE\Ui\DebugWindow.cs:96 |  |
| Hud: Moon Recipe | Hud：月球食谱 | UI string \| ICE\Ui\DebugWindow.cs:52 |  |
| Hud: Wheel of fortune! | Hud：命运之轮！ | UI string \| ICE\Ui\DebugWindow.cs:51 |  |
| I'll get to it when my world gets to it o/ | 当我的世界到达它时我会得到它o/ | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:286 |  |
| Ice Log Tabs | Ice日志选项卡 | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:21 |  |
| ICE Overlay | ICE覆盖 | Window title \| ICE\Ui\OverlayWindow.cs:18 |  |
| ICE {0} Debugger | ICE{0} 调试器 | Window title \| ICE\Ui\DebugWindow.cs:17 |  |
| Ice's Cosmic Exploration - Info | Ice 的宇宙探索 - 信息 | Window title \| ICE\Ui\InfoWindow.cs:19 |  |
| Ice's Cosmic Exploration {0} | Ice 的宇宙探索 {0} | Window title \| ICE\Ui\MainWindow.cs:23 |  |
| Ice's Cosmic Exploration \| Mission Details | Ice 的宇宙探索 \|任务详细信息 | Window title \| ICE\Ui\Window_ExternalDetails.cs:66 |  |
| Icon | 图标 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:124; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:480; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:54; ICE\Ui\MainUi\Settings\GambaWheel.cs:158; ICE\Ui\MainUi\Settings\Priority_Settings.cs:53; ICE\Ui\MainUi\Settings\Priority_Settings.cs:123; ICE\Ui\MainUi\Settings\Priority_Settings.cs:206; ICE\Ui\OverlayWindow.cs:322 |  |
| Icon ID | 图标 ID | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:96 |  |
| Icons | 图标 | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:129; ICE\Ui\MainUi\Settings\ShoppingTab.cs:151 |  |
| Id | Id | Table column \| UI string \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:40; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:182; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:59; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Gearsets.cs:48; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:151; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:255; ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:10 |  |
| ID: | ID: | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Aethernet.cs:72 |  |
| Id: {0} | Id：{0} | UI text \| Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:60; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:395; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:76; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:111; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:68 |  |
| If set to 0, it'll never use a cordial even with it enabled (because... you'll never have 0 gp) | 如果设置为0，即使启用它也永远不会使用强心剂的饮料（因为......你永远不会有0 gp） | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:229 |  |
| If stuck during nav movement: | 如果在导航运动期间卡住： | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:190 |  |
| If you are, it will automatically start as if you had pressed the start button yourself | 如果你是，它会自动启动，就像你一样你自己按下了开始按钮 | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:190 |  |
| If you just want to focus one specific class, set this to false | 如果你只想关注一个特定的类，请将其设置为 false | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:255 |  |
| If you want something more complex, just make an SND script at that point. And have this run that script post lol. | 如果你想要更复杂的东西，只需在此时创建一个 SND 脚本即可。并让它运行该脚本后哈哈。 | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:243 |  |
| If you want to let it auto select the wheels and gamba, enable this. If you want to not auto run when you're running the gamble wheel, disable this. | 如果您想让它自动选择轮子和 抽奖，请启用此功能。如果你不想在运行赌轮时自动运行，请禁用此功能。 | Help marker \| ICE\Ui\MainUi\Settings\GambaWheel.cs:23; ICE\Ui\MainUi\Settings\GambaWheel.cs:101 |  |
| If you would like to auto setup gathering to where all missions have their gathering buffs to what I would recommend | 如果你想自动设置采集到所有任务都有我推荐的采集增益的地方 | UI text \| ICE\Ui\InfoWindow.cs:54 |  |
| If you would like to use one that you already have in autohook, you can un-checkmark this and type the name of it below | 如果你想使用自动钩子中已有的一个，你可以取消选中此选项并在下面键入它的名称 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1273; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:513 |  |
| If you you uncheck this, YOU WILL JOIN random party invites. | 如果你取消选中此功能，你将加入随机聚会邀请。 | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:30 |  |
| If you're high enough level to need the next rank category but haven't unlocked it yet | 如果你很高足够级别需要下一个等级职业，但尚未解锁 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:65 |  |
| If you're okay with this, hold left shift and apply | 如果您对此感到满意，请按住左移并应用 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:1049 |  |
| Ignore Manual Mode | 忽略手动模式 | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:93 |  |
| Ignore non-Cosmic prompts | 忽略非宇宙提示 | Checkbox \| ICE\Ui\MainUi\Settings\SafetySettings.cs:23 |  |
| ImGui Testing | ImGui测试 | UI string \| ICE\Ui\DebugWindow.cs:83 |  |
| Import | 进口 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:64; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:269 |  |
| Import Missions | 导入任务 | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:408 |  |
| Import New Preset | 导入新预设 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:95 |  |
| Import Selected Profile | 导入选定的配置文件 | Button \| ICE\Ui\MainUi\Settings\GatherSettings.cs:1019 |  |
| Increase collectability | Increase可收藏性 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:126 |  |
| Increase Gathering & Crafting Speed | 提高采集和制作速度 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:318 |  |
| Increase the Integrity by 1 | 将完整性提高1 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:726 |  |
| Increases item yield from Gatherer's Boon by 1 | 将采集者恩赐的物品产量提高1 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:569 |  |
| Increases the gather chance by 15% | 采集几率提高 15% | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:880; ICE\Ui\MainUi\Settings\GatherSettings.cs:972 |  |
| Increases the gather chance by 5% | 采集几率增加 5% | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:926 |  |
| Increases the gather chance by 50% | 采集几率增加 50% | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:834 |  |
| Increases the number of items obtained when gathering by 1 | 采集时获得的项目数增加 1 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:670 |  |
| Increases the number of items obtained when gathering by 2 | 采集时获得的项目数增加 2 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:614; ICE\Ui\MainUi\Settings\GatherSettings.cs:778 |  |
| Info | 信息 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:806; ICE\Ui\Window_ExternalDetails.cs:129 |  |
| Infrastructor | 基础设施 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:32 |  |
| Initiate | 发起 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:159; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:424 |  |
| Input below a list of commands that you would like to run after a run has been completed. | 在运行完成后要运行的命令列表下方输入。 | UI text (wrapped) \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:241 |  |
| Install {0} | 安装 {0} | Button \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:74 |  |
| Install {0} Repo | 安装 {0} 存储库 | Button \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:53 |  |
| Invalid import string. | Invalid importstring. | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:282 |  |
| Invalid import string: Missing prefix | 无效的导入字符串：缺少前缀 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:74; ICE\Ui\MainUi\Settings\GatherSettings.cs:122 |  |
| Invalid import string: Not valid base64 | 无效的导入字符串：无效的base64 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:105; ICE\Ui\MainUi\Settings\GatherSettings.cs:163 |  |
| Inverse Priority (Watered -> Regular -> Hi) | 反向优先级（Watered -> Regular -> Hi） | Checkbox \| ICE\Ui\MainUi\Settings\GatherSettings.cs:211 |  |
| IPC Testing | IPC 测试 | UI string \| ICE\Ui\DebugWindow.cs:77 |  |
| IPC: Artisan | IPC：Artisan | UI string \| ICE\Ui\DebugWindow.cs:93 |  |
| Is ICE Running? \| {0} | ICE 正在运行吗？\|{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:121 |  |
| Is Mission Timed out | 任务超时 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:61 |  |
| It appears that you have on of the following enabled | 似乎您已启用以下一项 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:139 |  |
| It scans all available missions, evaluates the experience each one provides, and picks whichever | 它扫描所有可用任务，评估每个任务提供的经验，并选择其中之一 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:62 |  |
| Item Count: {0} | 项目计数：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionsV3.cs:24 |  |
| Item Details | 项目详细信息 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1499 |  |
| Item Exchange Window | 项目交换窗口 | UI string \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:25; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:98; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:180 |  |
| Item ID: | 项目ID： | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:47 |  |
| Item ID: {0} | 项目ID：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:68; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:101 |  |
| Item Integrity: | 项目完整性： | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:63 |  |
| Item Name: | 项目名称： | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:39 |  |
| Item Name: {0} | 项目名称：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:66; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:99 |  |
| ItemID: {0} | 项目ID：{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1618 |  |
| Items in left wheel | 左轮中的项目 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:40 |  |
| Items on person: | 人身上的项目： | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:79 |  |
| Job | 作业 | Table column \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:39; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:186; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:60; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:349; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:444; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:253; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:727 |  |
| Job Priority Order | 作业优先顺序 | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:203 |  |
| Job Selection | 作业选择 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:474; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:476 |  |
| Job(s) | 作业 | UI text \| ICE\Ui\Window_ExternalDetails.cs:179 |  |
| Job: {0} | 作业：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:51 |  |
| JobID | 作业ID | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Gearsets.cs:50 |  |
| JobId: {0} | JobId：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:52 |  |
| JobID: {0} \| HasUnlocked: {1} | JobID：{0} \|已解锁：{1} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:173 |  |
| JobId: {0} \| Unlocked: {1} | JobId：{0} \|解锁：{1} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:158 |  |
| Jobs | 职业机会 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:183 |  |
| Jump | 跳 | Radio button \| ICE\Ui\MainUi\Settings\TravelSettings.cs:207 |  |
| Keep | 保持 | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:218 |  |
| Keep "A Rank" missions and below | 保持“A Rank”任务及以下 | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:275; ICE\Ui\MainUi\Settings\Misc_Settings.cs:209 |  |
| Keep Buying | 继续购买 | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:220 |  |
| Keep Buying: Once the other 2 have been met (Keep/Buy), it will constantly buy this item if it has the credits to do so. | 保持 Buying：一旦满足其他2个（保留/购买），如果有信用点，它将不断购买该物品。 | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:46 |  |
| Keep this much Cosmocredits | 保留这么多宇宙信用点 | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:63 |  |
| Keep: Will buy up to that many items to make sure that you have in your inventory. This count doesn't go down between runs. | 保持：将购买最多数量的物品，以确保您的库存中有足够的物品。此计数在运行之间不会减少。 | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:42 |  |
| Key | 钥匙 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:27; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:23; ICE\Ui\Debug_Tabs\Debug_Tables\Table_TimeWeather.cs:13 |  |
| Key / RecipeId: {0} | Key / RecipeId：{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1617 |  |
| Kind | 种类 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:863; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:254; ICE\Ui\MainUi\Settings\ShoppingTab.cs:216 |  |
| Knock knock | Knock Knock | UI string \| ICE\Ui\Window_ExternalDetails.cs:47 |  |
| Largest Fish Scored | 最大鱼得分 | UI string \| ICE\Ui\Window_ExternalDetails.cs:456 |  |
| Leatherworker (LTW) | 皮革工人 (LTW) | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:68 |  |
| Left wheel select | 左轮选择 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:18 |  |
| Lettuce in | 生菜 | UI string \| ICE\Ui\Window_ExternalDetails.cs:51 |  |
| Level | 等级 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:62; ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:71 |  |
| Leveling Grind | 练级刷取 | UI string \| Radio button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:74; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:87; ICE\Ui\MainWindow.cs:125; ICE\Ui\MainWindow.cs:154; ICE\Ui\OverlayWindow.cs:164 |  |
| Leveling Mode | 练级模式 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:419 |  |
| Leveling Table | 练级任务表 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_LevelingMissions.cs:11 |  |
| Limited Nodes | 有限节点 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:33 |  |
| Limited Supplies | 有限供应 | UI string \| ICE\Ui\Window_ExternalDetails.cs:449 |  |
| List of Visible Missions | 可见任务列表 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:21 |  |
| Load Mission Preset | 加载任务预设 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:363 |  |
| Location: {0}, {1} | 位置：{0}，{1} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:143 |  |
| Log copied to clipbard | 日志复制到剪贴板 | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:184 |  |
| Long answer: Honestly, this was a cumbersome system in itself. And with square deciding to not continue on with dual crafting missions going into the 2nd moon, I figured it would be better to just tie it into the scoring system. You realistically only need: | Long回答： 老实说，这本身就是一个繁琐的系统。由于 Square 决定不再继续进入第二个月球的双重制作任务，我认为最好将其与评分系统联系起来。您实际上只需要： | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:459 |  |
| Lottery addon is visible! | Lottery 插件可见！ | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:16 |  |
| LTW | LTW | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:29; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:15; ICE\Ui\MainUi\Settings\Misc_Settings.cs:129 |  |
| Lunar Credits | 月球信用点 | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:10 |  |
| Lv | 左 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_LevelingMissions.cs:14 |  |
| Lv. 10-49 | Lv。10-49 | UI text \| ICE\Ui\Window_ExternalDetails.cs:273 |  |
| Lv. 50-89 | LV。50-89 | UI text \| ICE\Ui\Window_ExternalDetails.cs:283 |  |
| Lv. 90-99 | LV。90-99 | UI text \| ICE\Ui\Window_ExternalDetails.cs:293 |  |
| Macro Name | 宏名称 | Input label \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1686 |  |
| Main Item 1 | 主项目 1 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:208 |  |
| Main Item 2 | 主项目 2 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:210 |  |
| Main Item 3 | 主项目 3 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:212 |  |
| Main-Craft 1 | 主工艺1 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:25 |  |
| Main-Craft 2 | 主工艺2 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:27 |  |
| Main-Craft 3 | 主工艺3 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:29 |  |
| Mainly used for missions where you can chain durability refresh | 主要用于可以连续刷新耐久度的任务 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:641; ICE\Ui\MainUi\Settings\GatherSettings.cs:697 |  |
| Manipulation Check | 操作检查 | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:142 |  |
| Manual | 手动 | Button \| UI text \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:162; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1817; ICE\Ui\MainUi\Settings\Character_Settings.cs:618 |  |
| Map Location | 地图位置 | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:12 |  |
| Map Radius | 地图半径 | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_MapTesting.cs:43 |  |
| Map X (Sheet) | 地图X（图纸） | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_MapTesting.cs:37 |  |
| Map Y (Sheet) | 地图Y（图纸） | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_MapTesting.cs:40 |  |
| Marker move task | 标记移动任务 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:118 |  |
| Master Settings | 主设置 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:955 |  |
| Master Settings: Popup | 主设置：弹出 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:952 |  |
| Max Collectibility: | 最大可采集性： | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:95 |  |
| Max Distance | 最大距离 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:329 |  |
| Max use | 最大使用 | UI text \| Input label \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1926; ICE\Ui\MainUi\Settings\GatherSettings.cs:502; ICE\Ui\MainUi\Settings\GatherSettings.cs:544; ICE\Ui\MainUi\Settings\GatherSettings.cs:588; ICE\Ui\MainUi\Settings\GatherSettings.cs:644; ICE\Ui\MainUi\Settings\GatherSettings.cs:700; ICE\Ui\MainUi\Settings\GatherSettings.cs:753; ICE\Ui\MainUi\Settings\GatherSettings.cs:798; ICE\Ui\MainUi\Settings\GatherSettings.cs:855; ICE\Ui\MainUi\Settings\GatherSettings.cs:901; ICE\Ui\MainUi\Settings\GatherSettings.cs:947; ICE\Ui\MainUi\Settings\GatherSettings.cs:992 |  |
| Max XP | MaxXP | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:30 |  |
| Maximum Drones | 最大无人机 | Input label \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:48 |  |
| Mech | 机甲 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:18 |  |
| Message | 消息 | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:73 |  |
| Meticulous Power | 细致力量 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:116 |  |
| Mid Collectibility: | 中收藏度： | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:79 |  |
| MIN | MIN | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:33; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:19; ICE\Ui\MainUi\Settings\Misc_Settings.cs:130 |  |
| Min Collectibility: | Min收藏度： | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:71 |  |
| Min Distance | Min距离 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:322 |  |
| Min mission rank for cordials | Min强心剂任务等级 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:201 |  |
| Min mission rank for food | Min食物任务等级 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:236 |  |
| Miner (MIN) | 采矿工(MIN) | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:72 |  |
| Minimum Gp for Usage | 使用最低 Gp | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:495; ICE\Ui\MainUi\Settings\GatherSettings.cs:537; ICE\Ui\MainUi\Settings\GatherSettings.cs:581; ICE\Ui\MainUi\Settings\GatherSettings.cs:627; ICE\Ui\MainUi\Settings\GatherSettings.cs:683; ICE\Ui\MainUi\Settings\GatherSettings.cs:739; ICE\Ui\MainUi\Settings\GatherSettings.cs:791; ICE\Ui\MainUi\Settings\GatherSettings.cs:848; ICE\Ui\MainUi\Settings\GatherSettings.cs:894; ICE\Ui\MainUi\Settings\GatherSettings.cs:940; ICE\Ui\MainUi\Settings\GatherSettings.cs:985 |  |
| Minimum GP to start mission | 开始任务最低 GP | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:442 |  |
| Minimum Grade 8 Dark Matter | 最低 8 级暗物质 | Input label \| ICE\Ui\MainUi\Settings\Character_Settings.cs:191; ICE\Ui\MainUi\Settings\Character_Settings.cs:256 |  |
| Minimum Mounting Range | 最小安装范围 | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:868; ICE\Ui\MainUi\Settings\Character_Settings.cs:899 |  |
| Minimum Node Durability for Usage | 使用的最低节点耐用性 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:746 |  |
| Mininum credits to keep | 要保留的最小信用点 | UI string \| ICE\Ui\MainUi\Settings\GambaWheel.cs:25; ICE\Ui\MainUi\Settings\GambaWheel.cs:103 |  |
| Minumum Items To Gather | 要采集的最小项目 | UI text \| ICE\Ui\MainUi\Settings\GatherSettings.cs:806 |  |
| Misc Settings | 杂项设置 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:113 |  |
| Mission | 任务 | Button \| Table column \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:11; ICE\Ui\OverlayWindow.cs:323 |  |
| Mission Atributes | 任务属性 | UI text \| ICE\Ui\Window_ExternalDetails.cs:303 |  |
| Mission Commands | 任务命令 | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:258 |  |
| Mission Completion Status Window | 任务完成状态窗口 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:160 |  |
| Mission Details | 任务详细信息 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:24 |  |
| Mission Details Master Tabs | 任务详细信息主选项卡 | UI string \| ICE\Ui\Window_ExternalDetails.cs:98 |  |
| Mission ID | 任务ID | Table column \| UI string \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:26; ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:51 |  |
| Mission Info List | 任务信息列表 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:21 |  |
| Mission Log | 任务日志 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:38 |  |
| Mission Name | 任务名称 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:18; ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:28; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:185; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:24; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:257 |  |
| Mission Priority | 任务优先级 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:110 |  |
| Mission Priority Order | 任务优先顺序 | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:13 |  |
| Mission Priority Settings | 任务优先级设置 | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:11 |  |
| Mission Radius | 任务半径 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:34 |  |
| Mission Reward Sheet | 任务奖励表 | UI string \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:23 |  |
| Mission Score Required | 任务分数要求 | UI string \| ICE\Ui\Window_ExternalDetails.cs:458 |  |
| Mission Search Priority | 任务搜索优先级 | UI text \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:106 |  |
| Mission Selection | 任务选择 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:32 |  |
| Mission Selection Child | 任务选择子项 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:30 |  |
| Mission Selection Info | 任务选择信息 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:38 |  |
| Mission Selection Window | 任务选择窗口 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:52 |  |
| Mission Selector | 任务选择器 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:23 |  |
| Mission Settings | 任务设置 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:240 |  |
| Mission Settings: Popup | 任务设置：弹出 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:242; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:244 |  |
| Mission Setup | 任务设置 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:39 |  |
| Mission Timer: {0} | 任务计时器：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:388 |  |
| Mission Timers | 任务计时器 | UI string \| ICE\Ui\Window_ExternalDetails.cs:406 |  |
| Mission Type | 任务类型 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:411 |  |
| Mission Type Table | 任务类型表 | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:120 |  |
| Mission Viewer | 任务查看器 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:137 |  |
| Mission: | 任务： | UI text \| ICE\Ui\Window_ExternalDetails.cs:92 |  |
| Mission: [{0}] {1} | 任务：[{0}] {1} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1228 |  |
| Mission: {0} | 任务：{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1193; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:539 |  |
| MissionID | 任务ID | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:17 |  |
| MM Recipe Usage | MM 配方用法 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:179 |  |
| MM Step Use | MM 步骤使用 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:178 |  |
| Mode Select | 模式选择 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:352; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:447 |  |
| Mode Select \| Select Mode Window | 模式选择 \|选择模式窗口 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:100; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:102; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:113; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:115 |  |
| Mode Selection | 模式选择 | UI string \| Icon button \| ICE\Ui\MainUi\HelpFolder\helpSelect_Tips.cs:26; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:98; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:111 |  |
| Mode Selection Info | 模式选择信息 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:15 |  |
| Moon Mission Information Table | 月球任务信息表 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:180 |  |
| Mount | 安装 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:176 |  |
| Mount Options | 安装选项 | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:817; ICE\Ui\MainUi\Settings\Character_Settings.cs:950 |  |
| Mount Roulette | 安装轮盘 | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:939 |  |
| Mount Settings | 安装设置 | Section header \| ICE\Ui\MainUi\Settings\Character_Settings.cs:771 |  |
| Mount: {0} | 安装：{0} | UI text \| ICE\Ui\MainUi\Settings\Character_Settings.cs:789; ICE\Ui\MainUi\Settings\Character_Settings.cs:812 |  |
| Mount_Radius Circle | 安装_半径圆 | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:928 |  |
| Move Item | 移动项目 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:389 |  |
| Move To | 移动到 | Table column \| Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:35; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:53; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:116 |  |
| Move to Flag | 移动到Flag | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:166 |  |
| Move To Navmesh | 移动到导航网格 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:148 |  |
| Move To [Fan] | 移动到[扇形] | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:282 |  |
| MoveTo Spot | 移动到点 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:34 |  |
| ms stuck | 卡住 | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:225 |  |
| Name | 姓名 | Table column \| Input label \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:41; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:63; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Gearsets.cs:49; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:32; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:125; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:223; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:481; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:55; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:367; ICE\Ui\MainUi\Settings\GambaWheel.cs:160; ICE\Ui\MainUi\Settings\ShoppingTab.cs:213; ICE\Ui\OverlayWindow.cs:324; ICE\Ui\Window_ExternalDetails.cs:128 |  |
| Name: {0} | 名称：{0} | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:64 |  |
| Name: {0} : {1} | 名称：{0}：{1} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:214 |  |
| Name: {0} \| ID: {1} | 名称：{0} \|ID：{1} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:280 |  |
| Name: {0} \| Id: {1} \| Amount: {2} | 名称：{0} \|Id：{1} \|金额：{2} | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:43; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:49 |  |
| Names | 名称 | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:130; ICE\Ui\MainUi\Settings\ShoppingTab.cs:152 |  |
| Nav Move To | Nav 移动到 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:277 |  |
| Nav Position | Nav 位置 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:291 |  |
| Navmesh Testing | Navmesh 测试 | UI string \| ICE\Ui\DebugWindow.cs:79 |  |
| Necessary Amount: {0} | 必要金额：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:69; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:102 |  |
| Need Help? | 需要帮助？ | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:164 |  |
| Need to actually put the player info here. It got lost | 需要在此处实际放置玩家信息。它丢失了 | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:37 |  |
| Needed XP | 需要XP | Input label \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:138; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:28 |  |
| Needs Unlocked | 需要解锁 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1312 |  |
| New Profile Name | 新配置文件名称 | Input label \| ICE\Ui\MainUi\Settings\GatherSettings.cs:331 |  |
| Next | 下一个 | Button \| Table column \| ICE\Ui\MainUi\Settings\Character_Settings.cs:849; ICE\Ui\OverlayWindow.cs:76 |  |
| Next Missions | 下一个任务 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:741; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:586; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:911 |  |
| Next Sequence: | 下一个序列： | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1347 |  |
| Next Stage | 下一阶段 | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:42 |  |
| No bait is equipped | 没有配备诱饵 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:99 |  |
| No fishing missions found! | 没有找到钓鱼任务！ | Tooltip \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:115 |  |
| No Food Selected | 没有选择食物 | UI text \| ICE\Ui\MainUi\Settings\GatherSettings.cs:262 |  |
| No GatheringPoint targeted. | 没有目标聚集点。 | Chat message \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:334 |  |
| No items in {0} shopping list | 没有物品在 {0} 购物清单中 | UI text (disabled) \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:202 |  |
| No location set | 未设置位置 | UI text \| ICE\Ui\MainUi\Settings\TravelSettings.cs:269 |  |
| No markers found! | 未找到标记！ | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:80 |  |
| No missing Auxesia MissionScores rows. | 没有丢失 奥克塞西亚行星 MissionScores 行。 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:89 |  |
| No missing rows — embedded CSV covers all missions with bronze scores. | 没有丢失行 — 嵌入的 CSV 涵盖了所有具有青铜分数的任务。 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:67 |  |
| No mission | 没有任务 | UI text \| ICE\Ui\OverlayWindow.cs:220 |  |
| No mission selected currently. Woops [{0}] | 当前没有选择任务。哎呀[{0}] | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:143 |  |
| No reachable points found around this node. | 在此节点周围找不到可到达的点。 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:500 |  |
| No route file exist. Do you want to create one? | 不存在路由文件。您想创建一个吗？ | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:366 |  |
| No score can be loaded | 无法加载乐谱 | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:603 |  |
| Node Durability For Usage | 节点使用耐久性 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:634; ICE\Ui\MainUi\Settings\GatherSettings.cs:690 |  |
| Node Editor | 节点编辑器 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:215 |  |
| Node Selection | 节点选择 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:180 |  |
| Node Text: {0} | 节点文本：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:17 |  |
| Node: {0} | 节点：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:274 |  |
| None | 无 | UI text \| ICE\Ui\Window_ExternalDetails.cs:306 |  |
| Nophica's / Nald'thal's Tidings Buff | 诺菲卡/纳尔塔尔的消息增益 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:559 |  |
| Not a valid autohook preset. | 不是有效的自动挂接预设。 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:104 |  |
| Not Completed | Not已完成 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:357 |  |
| Note. I'm not responsible if you leave this on and get banned for it. I'm not one for leaving things at their pc, but people are watching always. Keep this in mind | 注。如果您保留此功能并因此被禁止，我不承担任何责任。我不喜欢把东西留在他们的电脑上，但人们总是在看着。请记住这一点 | UI string \| ICE\Ui\MainWindow.cs:169 |  |
| Note: this mode does not swap planets for you. Each planet also has an exp cap: | 注意：此模式不会为您交换行星。每个行星还有一个经验上限： | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:67 |  |
| Notes | 笔记 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:260 |  |
| NPC Box Viewer | NPC 盒子查看器 | UI string \| ICE\Ui\DebugWindow.cs:82 |  |
| NPC Info Debugger | NPC 信息调试器 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:30 |  |
| NQ Regular Cordial | NQ 普通强心剂 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:315 |  |
| NQ Watered Cordial | NQ 兑水强心剂 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:317 |  |
| Number of entries: {0} | Number of items: {0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:96 |  |
| Object info | 对象信息 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:210 |  |
| Oizyr Map Stuff | 奥伊济尔地图资料 | UI string \| ICE\Ui\DebugWindow.cs:90 |  |
| Oizys   — Rank VI Max | 俄匊斯行星— 等级 VI Max | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:70 |  |
| ON TOP OF doing the normal missions for whichever class you start on. | 在完成您开始的任何职业的正常任务之上。 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:254 |  |
| Only enable this if you want plan on doing missions YOURSELF. AND NOT AUTOMATING IT. | 仅当您想自己计划执行任务时才启用此功能。并且不自动化. | Help marker \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:53 |  |
| Only Enabled Missions | 仅启用任务 | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:98 |  |
| Only grab mission | 仅抓取任务 | Checkbox \| ICE\Ui\MainUi\Settings\DebugTab.cs:68 |  |
| Only Missions Via IPC | 仅通过IPC执行任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:122 |  |
| Only turn in when the mission timer expires (keep gathering for max score). | 仅在任务计时器到期时交出（继续采集以获得最高分数）. | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:442 |  |
| Open Craft Settings | 打开工艺设置 | UI string \| Button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1167; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1184; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:530 |  |
| Open ICE | 打开ICE | UI text \| ICE\Ui\OverlayWindow.cs:120 |  |
| Open Job Swap Settings | 打开职业交换设置 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:316 |  |
| Open map position | 打开地图位置 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:125 |  |
| Open mission details | 打开任务详细信息 | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:341 |  |
| Open plugin interface<br>/ice help - shows all commands<br>/ice clear - removes all missions<br>/ice stop - stops ICE<br>/ice start - Starts ICE<br>/ice add \| remove \| toggle \| only <br>/ice flag [id] - Opens the map and marks where the area of gathering is. | 打开插件界面<br>/ice help - 显示所有命令<br>/ice 清除 - 删除所有任务<br>/ice 停止 - 停止 ICE<br>/ice 开始 - 启动 ICE<br>/ice 添加 \|删除\|切换\|仅 <br>/ice flag [id] - 打开地图并标记聚集区域。 | Command help \| ICE\ICE.cs:82 |  |
| Option to Delete | 删除选项 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:254; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:256 |  |
| Or if you wanted to do the relic on WVR -> Then farm score on BTN -> Farm credits on BSM | 或者如果你想先完成裁衣匠的宇宙工具 -> 然后去园艺工刷分 -> 再去锻铁匠刷信用点 | UI string \| ICE\Ui\MainWindow.cs:167 |  |
| Or if you're feeling daredevil. Lower it. I'm not your dad (will tell dad jokes though. | 或者如果你很勇敢就调低。我不是你爸爸（不过我会讲爸爸笑话）。 | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:41; ICE\Ui\MainUi\Settings\SafetySettings.cs:63 |  |
| Or if you're letting a different plugin do all the automating of turning in, craftings, gathering... and not letting I.C.E. handle interacting with those plugins | 或者如果你让一个不同的插件完成所有上交、制作、采集的自动化......而不让 I.C.E. 处理与这些插件的交互 | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:54 |  |
| Or just read a specific tab to find out. Probably would answer a lot of questions | 或者只是阅读一个特定的选项卡来找出答案。可能会回答很多问题 | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\Welcome.cs:18 |  |
| Order | 命令 | Table column \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:212 |  |
| Order you would like to do the actions. It will work from the top down. | Order你想要执行的操作。它将从顶部开始职业down. | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:109 |  |
| Order you would like to do the provisional mission in, if multiple are selected and the option to do multiple classes is enabled | 如果选择了多个并且启用了执行多个类的选项，则您想要执行临时任务的顺序 | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:186 |  |
| Overlay Mode Select | 叠加模式选择 | UI string \| ICE\Ui\OverlayWindow.cs:126; ICE\Ui\OverlayWindow.cs:134 |  |
| Overlay Settings | 叠加设置 | Tooltip \| ICE\Ui\OverlayWindow.cs:27 |  |
| Overlay Window | 叠加窗口 | Section header \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:38 |  |
| OverlaySettingsPopup | 叠加设置弹出​​窗口 | UI string \| ICE\Ui\OverlayWindow.cs:60 |  |
| Override active — click to inherit from Global | Override active — 单击以继承 Global | UI string \| ICE\Ui\MainUi\Settings\Character_Settings.cs:99; ICE\Ui\MainUi\Settings\Character_Settings.cs:121; ICE\Ui\MainUi\Settings\Character_Settings.cs:802 |  |
| Override Expert Artisan settings | 覆盖 Expert Artisan 设置 | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:304 |  |
| Override Standard Artisan settings | 覆盖标准 Artisan 设置 | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:298 |  |
| Pandora Feature | Pandora功能 | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:54 |  |
| Path to repair NPC | 修复路径NPC | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:38 |  |
| Pathfinding | 寻路 | Section header \| ICE\Ui\MainUi\Settings\TravelSettings.cs:43 |  |
| Pathing to repair NPC | 修复路径NPC | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:40 |  |
| Pause Feature | 暂停功能 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:55 |  |
| Personalized Fishing Spots | 个性化钓场 | Section header \| ICE\Ui\MainUi\Settings\TravelSettings.cs:275 |  |
| Phaenna — Rank V Max | 法恩娜行星 — 等级V Max | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:69 |  |
| Pioneer's \| Mountaineer's Gift I | 登山者的礼物I | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:515 |  |
| Pioneer's \| Mountaineer's Gift II | 登山者的礼物II | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:473 |  |
| Planet | 行星 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_LevelingMissions.cs:13 |  |
| Planet Selection | 行星选择 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:43 |  |
| Planet: {0} | 行星：{0} | UI text \| ICE\Ui\MainUi\Settings\TravelSettings.cs:287 |  |
| Planetary | 行星 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:866 |  |
| Planetary Credits | 行星信用点 | UI text \| ICE\Ui\Window_ExternalDetails.cs:141 |  |
| Play Sound Alert on Stop | 停止时播放声音警报 | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:144 |  |
| Player Info | 玩家信息 | UI string \| ICE\Ui\DebugWindow.cs:75 |  |
| Player is busy, skipping cordial check | 玩家正忙，跳过强心剂检查 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:363 |  |
| Player Level | 玩家等级 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:101 |  |
| Player Moving: {0} | 玩家移动：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:91 |  |
| Player Position: X:{0}, Y:{1}, Z:{2} | 玩家位置：X：{0}，Y：{1}，Z：{2} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:40 |  |
| Player Start: {0} | 播放器开始：{0} | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:289 |  |
| Playlist Name | 播放列表名称 | Input label \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:328 |  |
| Please give it time | 请给它时间 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:980 |  |
| PLEASE MAKE SURE TO CHECK THE REQUIREMENTS SECTION TO SEE WHAT YOU NEED FOR WHAT | 请务必检查要求部分以了解您需要什么 | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\Welcome.cs:17 |  |
| Please make sure to do so for this job if you don't want it to stall out when there is no timed/weather missions. | 如果您不想让这项职业陷入停滞，请务必这样做当没有限时/天气任务时。 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:650 |  |
| PLEASE NOTE. DO. NOT. LEAVE. THIS. ALONE. This is still being worked on heavily | 请不要这样做。 | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:69 |  |
| PLEASE NOTE: | 请注意： | Help marker \| ICE\Ui\MainUi\Settings\GatherSettings.cs:1046 |  |
| Please note: You can have multiple enabled, but only the one that will get you the closest to | 请注意：您可以启用多个，但只能启用最接近的 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:835; ICE\Ui\MainUi\Settings\GatherSettings.cs:881; ICE\Ui\MainUi\Settings\GatherSettings.cs:927 |  |
| Plugin Logs | 插件日志 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:168 |  |
| Plugin Requirements | Plugin 要求 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:167 |  |
| Position | 位置 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:33; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:95 |  |
| Position: X: {0}, Y: {1}, Z: {2} | Position：{0}，Y：{1}，Z：{2} | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:72 |  |
| Post Mission Commands | 任务后命令 | Section header \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:238 |  |
| Post Mission Settings | 任务后设置 | Section header \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:197 |  |
| Potion | 药水 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1760 |  |
| Potion [HQ] | 药水[HQ] | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:152 |  |
| Potion [NQ] | 药水[NQ] | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:157 |  |
| Potions | 药水 | UI text \| ICE\Ui\MainUi\Settings\Character_Settings.cs:541 |  |
| Pre-Craft Amount | 预制数量 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:215 |  |
| Pre-Craft Item | 预制物品 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:214 |  |
| Pre-Craft [1] | 预制[1] | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:31 |  |
| Pre-Craft [2] | 前期制作 [2] | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:33 |  |
| Pre-Craft [3] | 前期制作 [3] | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:35 |  |
| Prefer smaller wheel | 更喜欢较小的轮子 | Checkbox \| ICE\Ui\MainUi\Settings\GambaWheel.cs:45; ICE\Ui\MainUi\Settings\GambaWheel.cs:122 |  |
| Preset Name | 预设名称 | Input label \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1278; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:518 |  |
| Preset Save Editor | 预设保存编辑器 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:323; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:326 |  |
| Preset String | 预设字符串 | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:63 |  |
| Preset: List Viewer | Preset：列表查看器 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:358; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:361 |  |
| Preset: TableViewer | Preset：TableViewer | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:365 |  |
| Prevent Overcap | 防止超额 | Checkbox \| ICE\Ui\MainUi\Settings\GatherSettings.cs:216 |  |
| Previous | 以前的 | Button \| ICE\Ui\MainUi\Settings\Character_Settings.cs:844 |  |
| Previous Missions | 以前的任务 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:732; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:576; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:903 |  |
| Previous Sequence: | Previous序列： | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1356 |  |
| Print GatheringPoint Info | 打印采集点信息 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:311 |  |
| Prioritize closest gathering node | 优先考虑最近的聚集节点 | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:54 |  |
| Profile Name: {0} | 配置文件名称：{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:318 |  |
| Profile Selection | 配置文件选择 | Table column \| ICE\Ui\MainUi\Settings\GatherSettings.cs:323 |  |
| Profile Setting | 配置文件设置 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:259 |  |
| Progress | 进度 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:449 |  |
| Progress Only Solver | 仅进度求解器 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:144; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:170; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:174; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1527; ICE\Ui\MainUi\Settings\Character_Settings.cs:318 |  |
| Progress: {0} | 进度：{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1755 |  |
| Property | 属性 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:28 |  |
| Provisional Job Priority | 临时职业优先级 | UI text \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:184 |  |
| Provisional Missions | 临时任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:50 |  |
| Provisional missions (Weather, Timed, and Sequence) and Red Alerts will be picked up | 将选择临时任务（天气、限时和顺序）和紧急任务 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:51 |  |
| Provisional: Allow All Classes | 临时：允许所有类 | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:248 |  |
| Provisional: Job Order | 临时：职业订单 | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:27 |  |
| Provisional: Type Order | 临时：类型订单 | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:20 |  |
| Puni.sh in general for each one of your help my dumb questions | Puni.sh一般为您帮助我的每一个愚蠢的问题 | UI string \| ICE\Ui\Window_ExternalDetails.cs:62 |  |
| Quality: {0} | 质量：{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1811 |  |
| Quick Apply Turnins | 快速应用转向 | Button \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:96 |  |
| Quick Apply_Mission Turnins | 快速应用_任务转向 | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:98; ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:101 |  |
| Quick Mission Add | 快速任务添加 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:57 |  |
| Quick Turnin | 快速转向 | Radio button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1005 |  |
| QuickLevelList missions | QuickLevelList任务 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:198 |  |
| Radius | 半径 | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:40 |  |
| Radius: {0} | Radius：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:144 |  |
| Randomize radius (yalms) | 随机化半径（yalms） | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:79 |  |
| Randomize waypoint positions | 随机化航路点位置 | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:65 |  |
| Rank | 秩 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:188 |  |
| Rank {0} | 排名 {0} | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:65 |  |
| Raphael Recipe Solver | 拉斐尔配方求解器 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:148; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:156; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:160 |  |
| Raphael Solver | 拉斐尔求解器 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1526; ICE\Ui\MainUi\Settings\Character_Settings.cs:317 |  |
| Raycast not initialized! | Raycast未初始化！ | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishingRaycast.cs:276 |  |
| Really is the "I want to do this order of things" kind of thing. | 确实是“我想做这个顺序的事情” | UI string \| ICE\Ui\MainWindow.cs:168 |  |
| Really useful if you have a tool to auto-log you in/if you just want to enter the moon and go | 如果你有一个自动登录的工具/如果你只想进入月球然后去 | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:191 |  |
| Recipe Detailed Info | Recipe详细信息 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1399 |  |
| Recipe ID: {0} | 食谱 ID：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:70; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:103 |  |
| RecipeID: {0} | 食谱ID：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:64; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:97 |  |
| RecipeNote | 食谱笔记 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:264 |  |
| Record Settings | 录音设置 | Section header \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:218 |  |
| Red Alert | 红色警戒 | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionsV3.cs:28 |  |
| Reducable Items | Reducable项目 | UI string \| ICE\Ui\Window_ExternalDetails.cs:451 |  |
| Refresh Class info | 刷新类信息 | Icon button \| ICE\Ui\MainUi\SelectableSidebar.cs:169 |  |
| Refresh Forecast | 刷新预测 | Button \| ICE\Ui\MainUi\Settings\DebugTab.cs:48 |  |
| Relic | 宇宙工具 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:728 |  |
| Relic Grind | 宇宙工具升级 | UI string \| Section header \| Radio button \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:23; ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:58; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:69; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:82; ICE\Ui\MainWindow.cs:118; ICE\Ui\MainWindow.cs:161; ICE\Ui\OverlayWindow.cs:163 |  |
| Relic Grind Mode | 宇宙工具升级模式 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:418 |  |
| Relic Info | 宇宙工具信息 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:30; ICE\Ui\DebugWindow.cs:80 |  |
| Relic Info V2 | 宇宙工具信息V2 | UI string \| ICE\Ui\DebugWindow.cs:84 |  |
| Relic Mode: Allow Red Alerts | 宇宙工具 模式：允许紧急任务 | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:304 |  |
| Relic Mode: Only Enabled | 宇宙工具 模式：仅启用 | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:311 |  |
| Relic Tool XP | 宇宙工具XP | UI string \| ICE\Ui\OverlayWindow.cs:644 |  |
| Relic Turnin | 宇宙工具上交 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:346 |  |
| Remove | 删除 | Button \| Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NavmeshTesting.cs:44; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:448; ICE\Ui\MainUi\Settings\Misc_Settings.cs:262 |  |
| Remove from list | 从列表中删除 | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:423 |  |
| Remove Mission Upon Gold Completion | 达成金星后删除任务 | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:267; ICE\Ui\MainUi\Settings\Misc_Settings.cs:200 |  |
| ReOrder | 重新订购 | Table column \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:52; ICE\Ui\MainUi\Settings\Priority_Settings.cs:122; ICE\Ui\MainUi\Settings\Priority_Settings.cs:205 |  |
| Repair all gear in bag | 修理包中的所有装备 | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:182; ICE\Ui\MainUi\Settings\Character_Settings.cs:238 |  |
| Repair at Vendor | 在供应商处修理 | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:159; ICE\Ui\MainUi\Settings\Character_Settings.cs:201 |  |
| Repair Settings | 修理设置 | Section header \| ICE\Ui\MainUi\Settings\Character_Settings.cs:152 |  |
| Report | 报告 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:120 |  |
| Required Item | 必需项目 | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:73; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:106 |  |
| Research | 研究 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:39 |  |
| Reset Buff Check | 重置增益检查 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:19 |  |
| Reset Stats | 重置统计 | Button \| ICE\Ui\Window_ExternalDetails.cs:336 |  |
| Reset Temp | 重置温度 | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:134 |  |
| Reset Weights | 重置权重 | Button \| ICE\Ui\MainUi\Settings\GambaWheel.cs:87; ICE\Ui\MainUi\Settings\GambaWheel.cs:142 |  |
| Restore Temp MM | 恢复温度MM | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:187 |  |
| Retarget | 重新定位 | Radio button \| ICE\Ui\MainUi\Settings\TravelSettings.cs:214 |  |
| Return back to normal | 恢复正常 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:193 |  |
| Reward Amount | 奖励金额 | UI string \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:111 |  |
| Reward ItemID | 奖励物品ID | UI string \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:181 |  |
| Ribs! Spare Ribs! | 排骨！备用肋骨！ | UI string \| ICE\Ui\Window_ExternalDetails.cs:43 |  |
| Right click to set minimum turnin to {0} | 右键单击将最小转向设置为{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:423 |  |
| Right wheel select | 右轮选择 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:24 |  |
| Rotation Tolerance (degrees) | 旋转公差（度） | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:305 |  |
| Route Editor | 路线编辑器 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:67 |  |
| Route Selector | 路线选择器 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:66 |  |
| Row ID | 行ID | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:55 |  |
| Rows for missions not in MissionScores.csv, using BronzeScore from sheets. | 未在MissionScores.csv中的任务的行，使用表格中的BronzeScore。 | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:72 |  |
| Run Drone Finder | 运行无人机Finder | Button \| UI text \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:13; ICE\Ui\OverlayWindow.cs:154 |  |
| Run Until.. | 运行 直到.. | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:351; ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:446 |  |
| Running task: {0} \| Amount of queue'd task: {1} | 运行任务：{0} \|排队任务的数量：{1} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:15 |  |
| Safety is around... 2500? If you're having animation locks you can absolutely increase it higher | 安全性约为……2500？如果你有动画锁，你完全可以为了刷信用点把它调得更高。 | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:62 |  |
| Safety is around... 250? If you're having animation locks you can absolutely increase it higher | 安全性约为……250？如果你有动画锁，你完全可以为了刷信用点把它调得更高。 | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:40 |  |
| Safety Settings | 安全设置 | Section header \| ICE\Ui\MainUi\Settings\SafetySettings.cs:20 |  |
| Save | 节省 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:227 |  |
| Save Current Mission Preset | 保存当前任务预设 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:321 |  |
| Save New List | 保存新列表 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:331 |  |
| Save Route | 保存路线 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:175 |  |
| Save to Favorites | 保存到收藏夹 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:216 |  |
| Saved Agenda's | 保存议程的 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:253 |  |
| Score | 分数 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:206; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:40; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:864; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:730 |  |
| Score 1 | 得分 1 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:140 |  |
| Score Farming — select specific high-value missions | 刷分 - 选择特定的高价值任务 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:46 |  |
| Score Goal | Score目标 | Radio button \| UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:983; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:999 |  |
| Score Info: External Details | 分数信息：外部详细信息 | UI string \| ICE\Ui\Window_ExternalDetails.cs:380 |  |
| Score: [{0}] | 分数：[{0}] | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:148 |  |
| Score: {0} | 分数：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:20; ICE\Ui\OverlayWindow.cs:618 |  |
| Scour Amount | 冲刷量 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:102 |  |
| Search | 搜索 | Input label \| ICE\Ui\MainUi\Settings\Character_Settings.cs:819 |  |
| Search by Attribute | 按属性搜索 | Input label \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:46 |  |
| Search by Name | 按名称搜索 | Input label \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:16; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:44; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MoonRecipies.cs:12 |  |
| Search logs... | 搜索日志... | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:52 |  |
| Search missions: | 搜索任务： | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionText.cs:15 |  |
| Search Name | 搜索名称 | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:28 |  |
| Select | 选择 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:154; ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MoonRecipe.cs:39 |  |
| Select Class | 选择职业 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:129 |  |
| Select Crafter Food | 选择能工巧匠食物 | UI string \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:43; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:46 |  |
| Select Export Folder | 选择导出文件夹 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:40 |  |
| Select Export Location | 选择导出位置 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:134 |  |
| Select Fishing Profile | 选择钓鱼配置文件 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1260; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1262; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:500; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:502 |  |
| Select Food | 选择食物 | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:33 |  |
| Select Gather Profile | 选择采集配置文件 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1220; ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1226 |  |
| Select Gathering Food | 选择采集食物 | Button \| ICE\Ui\MainUi\Settings\GatherSettings.cs:249 |  |
| Select gathering profile | 选择采集配置文件 | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1224 |  |
| Select Manual | 选择手动 | Button \| UI string \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:83; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:93; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:96 |  |
| Select mission to import | 选择要导入的任务 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:80 |  |
| Select Mode | 选择模式 | UI text \| ICE\Ui\MainWindow.cs:109 |  |
| Select Mounting Option | 选择安装选项 | Button \| ICE\Ui\MainUi\Settings\Character_Settings.cs:785; ICE\Ui\MainUi\Settings\Character_Settings.cs:808 |  |
| Select Pot | 选择药水 | Button \| UI string \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:58; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:68; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:71 |  |
| Select Profile | 选择配置文件 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:498 |  |
| Select profile to use | 选择要使用的配置文件 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:468 |  |
| Select Squadron Manual | 选择中队手册 | Button \| UI string \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:108; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:118; ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:121 |  |
| Select string not visible | 选择不可见的字符串 | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RedAlertString.cs:26 |  |
| Select Turnin Options | 选择上交选项 | UI text \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:121 |  |
| Selected Fan | 选定的扇形 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:349 |  |
| Selected Filter Index {0} | 选定的过滤器索引{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:21 |  |
| Selected Food: [{0}] {1} | 选定的食物：[{0}] {1} | UI text \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:31 |  |
| Selected Job Index {0} | 选定的作业索引{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:19 |  |
| Selected Manual: [{0}] {1} | 选定的手册：[{0}] {1} | UI text \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:81 |  |
| Selected Mission ID: {0} | 选定的任务ID：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:23 |  |
| Selected Mission Name: {0} | 选定的任务名称：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:22 |  |
| Selected Pot: [{0}] {1} | 选定的药水：[{0}] {1} | UI text \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:56 |  |
| Selected Squadron Manual: [{0}] {1} | 选定的中队手册：[{0}] {1} | UI text \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:106 |  |
| Selected Tab Index {0} | 选定的选项卡索引 {0} | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_Missions.cs:20 |  |
| Selected: {0} icons | 选定的：{0}图标 | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:411 |  |
| Selecting Gathering Profile | 选择采集资料 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:463; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:471 |  |
| Self Repair Crafter | 自我修复能工巧匠 | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:169; ICE\Ui\MainUi\Settings\Character_Settings.cs:220 |  |
| Self Repair Gather | 自我修复采集 | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:165; ICE\Ui\MainUi\Settings\Character_Settings.cs:212 |  |
| Sequence Missions | 序列任务 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:728; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:572; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:898 |  |
| Sequential Missions Required | 需要序列任务 | UI string \| ICE\Ui\Window_ExternalDetails.cs:462 |  |
| Set all leveling missions | 设置所有升级任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:89 |  |
| Set Area | 设置区域 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:50 |  |
| Set current mission to Progress | 设置当前任务为进度 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:164 |  |
| Set current mission to Raphael | 设置当前任务为拉斐尔 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:150 |  |
| Set export path first (or use Copy Missing CSV) | 先设置导出路径（或使用复制缺失的CSV） | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:152 |  |
| Set Fishing Rotation | 设置钓鱼旋转 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:296 |  |
| Set fishing to current | 将钓鱼设置为当前 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:284 |  |
| Set in incriments of 200, max of 5,000 | 设置增量为200，最大为5,000 | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:43 |  |
| Set Location: {0} | 设置位置：{0} | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:207 |  |
| Set marker to current position | 将标记设置为当前位置 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_WorldIconTEst.cs:13 |  |
| Set Miracle Solver | 设置奇迹解算器 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:181 |  |
| Set MM Temp | 设置MM温度 | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:180 |  |
| Set position: {0} | 设置位置：{0} | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:129 |  |
| Set raphael solver | 设置拉斐尔解算器 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:146 |  |
| Set Save Location | 设置保存位置 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:38 |  |
| Set State to Idle | 将状态设置为空闲 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:20 |  |
| Set temp setting | 设置临时设置 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:142 |  |
| Set to -1 to allow for infinite uses | 设置为-1以允许无限使用 | Help marker \| ICE\Ui\MainUi\Settings\GatherSettings.cs:549; ICE\Ui\MainUi\Settings\GatherSettings.cs:593; ICE\Ui\MainUi\Settings\GatherSettings.cs:649; ICE\Ui\MainUi\Settings\GatherSettings.cs:705; ICE\Ui\MainUi\Settings\GatherSettings.cs:758; ICE\Ui\MainUi\Settings\GatherSettings.cs:803; ICE\Ui\MainUi\Settings\GatherSettings.cs:860; ICE\Ui\MainUi\Settings\GatherSettings.cs:906; ICE\Ui\MainUi\Settings\GatherSettings.cs:952; ICE\Ui\MainUi\Settings\GatherSettings.cs:997 |  |
| Set to 1-> X to set maximum amount of uses per mission | 设置为1-> X以设置每个任务的最大使用量 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:550; ICE\Ui\MainUi\Settings\GatherSettings.cs:594; ICE\Ui\MainUi\Settings\GatherSettings.cs:650; ICE\Ui\MainUi\Settings\GatherSettings.cs:706; ICE\Ui\MainUi\Settings\GatherSettings.cs:759; ICE\Ui\MainUi\Settings\GatherSettings.cs:804; ICE\Ui\MainUi\Settings\GatherSettings.cs:861; ICE\Ui\MainUi\Settings\GatherSettings.cs:907; ICE\Ui\MainUi\Settings\GatherSettings.cs:953; ICE\Ui\MainUi\Settings\GatherSettings.cs:998 |  |
| Set To Current | 设置为当前 | Table column \| Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:36; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:60 |  |
| Set to current location | 设置为当前位置 | Button \| ICE\Ui\MainUi\Settings\TravelSettings.cs:253 |  |
| Setting Bool | 设置布尔 | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:136 |  |
| Setting Name | 设置名称 | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:135 |  |
| Settings | 设置 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:106 |  |
| Setup Gathering Profiles | 设置采集配置文件 | Button \| ICE\Ui\InfoWindow.cs:58; ICE\Ui\MainUi\Settings\GatherSettings.cs:1039 |  |
| Sheet: Mission Rewards | 职业表：任务奖励 | UI string \| ICE\Ui\DebugWindow.cs:87 |  |
| Short answer: It's built in now | 简答：现在已内置 | UI text (wrapped) \| ICE\Ui\MainUi\Settings\GatherSettings.cs:458 |  |
| Show Crazy Taxi Arrow when navmeshing | 导航时显示疯狂出租车箭头 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:311 |  |
| Show Current Class Score | 显示当前职业分数 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:80 |  |
| Show enabled missions on weather hover | 在天气悬停时显示已启用的任务 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:109 |  |
| Show Experience Bars on Overlay | 在叠加层上显示经验条 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:63 |  |
| Show fishing spot raycast | 显示钓场光线投射 | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:74; ICE\Ui\MainUi\Settings\TravelSettings.cs:288 |  |
| Show Gather Debug Info | 显示采集调试信息 | Checkbox \| ICE\Ui\MainUi\Settings\DebugTab.cs:54 |  |
| Show Overlay | 显示叠加 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:42 |  |
| Show random location debug target | 显示随机位置调试目标 | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:85 |  |
| Show Seconds | 显示秒 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:56 |  |
| Show tab list | 显示选项卡列表 | Tooltip \| ICE\Ui\DebugWindow.cs:32 |  |
| Show Total Score | 显示总分 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:87 |  |
| Showing {0} of {1} missions | 显示{1}任务的{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionText.cs:45 |  |
| Silver | 银星 | Table column \| Radio button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:191; ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:128 |  |
| Silver Requirement | 银星要求 | UI text \| ICE\Ui\Window_ExternalDetails.cs:211 |  |
| Silver: 2 Items | 银星：2个项目 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:461 |  |
| Sinus   — Rank IV Max | Sinus — Rank IV Max | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:68 |  |
| Skill Status [272]: {0} | 技能状态[272]：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:165 |  |
| So get a good couple of runs to get a good feel for the timing | 所以要跑好几次才能获得对时机有很好的感觉 | UI string \| ICE\Ui\Window_ExternalDetails.cs:377 |  |
| So if you Have Red Arert -> Drone Search, if a red alert isn't available, it will proceed to use a drone box if it can | 所以如果你有紧急任务->无人机搜索，如果紧急任务不可用，它会继续使用无人机箱（如果可以的话） | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:110 |  |
| So if you stop and you're unsure why... this might be why | 所以如果你停下来并且不确定为什么......这可能就是为什么 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:151 |  |
| So now how it'll work. Select the turnin option (Gold/Any both work the same) and it will now gather up to the necessary amount -> turnin when it's ready. | 所以现在它会如何运作。选择上交选项（金星/任意都相同），它现在会采集到必要的数量 -> 准备好后转交。 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:464 |  |
| So... you're telling me a shrimp fried this rice? | 所以...你是在告诉我这米饭是虾炒的吗？ | UI string \| ICE\Ui\Window_ExternalDetails.cs:56 |  |
| Solver | 求解器 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1643 |  |
| Solver Type | 求解器类型 | UI text \| ICE\Ui\MainUi\Settings\Character_Settings.cs:413 |  |
| Sound Volume | 音量 | UI text \| ICE\Ui\MainUi\Settings\StopWhen.cs:152 |  |
| Specific | 具体的 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:20 |  |
| Specific Class Details | 具体课程详情 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:804 |  |
| Spot {0} | 现货 {0} | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:248 |  |
| Squad Manual | 冒险者小队手册 | Button \| ICE\Ui\DebugWindowTabs\Ipc_Artisan.cs:167 |  |
| Squadron Manual | 中队手册 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1866; ICE\Ui\MainUi\Settings\Character_Settings.cs:687 |  |
| Square custom font | 方形自定义字体 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:351 |  |
| Stage | 阶段 | Table column \| UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:33; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:833 |  |
| Stage: {0} | Stage：{0} | UI text \| ICE\Ui\Relic_XP.cs:52 |  |
| Stand Mode | 站立模式 | UI string \| ICE\Ui\MainWindow.cs:149 |  |
| Standard | 标准 | Section header \| Radio button \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:41; ICE\Ui\MainWindow.cs:112 |  |
| Standard Craft Settings | 标准工艺设置 | Table column \| ICE\Ui\MainUi\Settings\Character_Settings.cs:393 |  |
| Standard Solver | 标准解算器 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1528; ICE\Ui\MainUi\Settings\Character_Settings.cs:319 |  |
| Start | 开始 | Table column \| Button \| UI text \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:150; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:168; ICE\Ui\OverlayWindow.cs:187 |  |
| Start Gambling @ | 开始赌博@ | UI string \| ICE\Ui\MainUi\Settings\GambaWheel.cs:228 |  |
| Start Hour | 开始时间 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_TimeWeather.cs:15 |  |
| Starting Test Navmesh | 开始测试Navmesh | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:449 |  |
| State | 状态 | Table column \| ICE\Ui\Window_ExternalDetails.cs:473 |  |
| State: {0} | State：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_TimerInfo.cs:18 |  |
| Steller | 斯特勒 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:25 |  |
| Steller Reduction | 斯特勒还原 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:113 |  |
| Still needed: {0}. | 仍然需要：{0}. | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:202 |  |
| Stop | 停止 | Button \| UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:230; ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:18; ICE\Ui\OverlayWindow.cs:187 |  |
| Stop @ Relic Complete | 停止@宇宙工具完成 | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:114 |  |
| Stop after current mission | 当前任务后停止 | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:282; ICE\Ui\MainUi\Settings\StopWhen.cs:20 |  |
| Stop after current mission: OFF | 当前任务后停止：OFF | UI text \| ICE\Ui\OverlayWindow.cs:205 |  |
| Stop after current mission: ON | 当前任务后停止：ON | UI text \| ICE\Ui\OverlayWindow.cs:205 |  |
| Stop All Task | 停止全部任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:181 |  |
| Stop at Cosmic Credits | 停止于宇宙信用点 | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:25 |  |
| Stop at Cosmic Score | 停止于宇宙分数 | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:71 |  |
| Stop at Cosmic Score [{0}] | 停止于宇宙分数[{0}] | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:141 |  |
| Stop at Level | 停止于等级 | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:93 |  |
| Stop at Planetary Credit Amount | 停止于行星信用点金额 | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:50 |  |
| Stop At Relic Lv. | 停止于宇宙工具等级 | Checkbox \| ICE\Ui\MainUi\Settings\StopWhen.cs:125; ICE\Ui\OverlayWindow.cs:653 |  |
| Stop Current Task | 停止当前任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:84 |  |
| Stop Drone Finder | 停止无人机探测器 | UI text \| ICE\Ui\OverlayWindow.cs:154 |  |
| Stop naving | 停止导航 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:171 |  |
| Stop once cosmo credit hit [{0}] | 一旦宇宙信用点命中[{0}]就停止 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:145 |  |
| Stop once planetary credit hit [{0}] | 一旦行星信用点命中[{0}] | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:147 |  |
| Stop once relic completed | 一旦宇宙工具完成就停止 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:149 |  |
| Stop Task | 停止任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:25 |  |
| Stop when below x dark matter | 低于x暗物质时停止 | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:186 |  |
| Stop when below x dark matter (Global) | 低于x暗物质时停止（全局） | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:246 |  |
| Stop When Level [{0}] | 水平时停止[{0}] | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:143 |  |
| Stop When... | 停止时... | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:108 |  |
| Strife special shoutout to you for doing what I didn't want to with fishing | Strife 特别感谢你做了我不想钓鱼的事情 | UI string \| ICE\Ui\Window_ExternalDetails.cs:59 |  |
| Stuck Detection | StuckDetection | Section header \| ICE\Ui\MainUi\Settings\TravelSettings.cs:186 |  |
| Stupid Test | 愚蠢的测试 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:95 |  |
| Stylist | Stylist | Section header \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:36 |  |
| SubLevel | 子级别 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:98 |  |
| Swap | 交换 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:71 |  |
| Swap Bait... simple | 交换诱饵...简单 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:86 |  |
| Swap jobs when turning in relic | 上交宇宙工具时交换职业 | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:963; ICE\Ui\MainUi\Settings\Character_Settings.cs:1000 |  |
| Swap to bait | Swap to诱饵 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:82 |  |
| Swap to preset | 交换到预设 | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:70 |  |
| Switch class to CRP | 切换职业到CRP | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:338 |  |
| Switch class to MIN | 切换职业到MIN | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:342 |  |
| Synthesize | 合成 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MoonRecipe.cs:32 |  |
| Tab # | 标签# | Input label \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:75 |  |
| Table: Fish Info | Table：鱼类信息 | UI string \| ICE\Ui\DebugWindow.cs:62 |  |
| Table: Gathering Missions | Table：采集任务 | UI string \| ICE\Ui\DebugWindow.cs:58 |  |
| Table: Leveling Missions | Table：练级任务 | UI string \| ICE\Ui\DebugWindow.cs:88 |  |
| Table: Mission Info | Table：任务信息 | UI string \| ICE\Ui\DebugWindow.cs:57 |  |
| Table: Mission Select | Table：任务选择 | UI string \| ICE\Ui\DebugWindow.cs:89 |  |
| Table: Mission Text | Table：任务文本 | UI string \| ICE\Ui\DebugWindow.cs:60 |  |
| Table: Recipies | 表：食谱 | UI string \| ICE\Ui\DebugWindow.cs:61 |  |
| Table: Special Missions | 表：特殊任务 | UI string \| ICE\Ui\DebugWindow.cs:59 |  |
| TableId | 表ID | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_MapTesting.cs:17 |  |
| Task Count: {0} | 任务计数：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:19 |  |
| TaskManager Testing | TaskManager 测试 | UI string \| ICE\Ui\DebugWindow.cs:81 |  |
| Temp Set Presets | 临时设置预设 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_FishPresets.cs:110 |  |
| Territory | 领土 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_OyzinMap.cs:97 |  |
| Territory Id: {0} | Territory Id：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:23 |  |
| Territory: {0} | Territory：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:142 |  |
| Test Buttons | 测试按钮 | UI string \| ICE\Ui\DebugWindow.cs:76 |  |
| Test Crafting | 测试制作 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:64 |  |
| Test Drone Buy | 测试无人机购买 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:247 |  |
| Test Drone Buy Item | 测试无人机购买物品 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:77 |  |
| Test Drone Pathing | 测试无人机路径 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:81 |  |
| Test Flag | 测试标志 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:204 |  |
| Test Gather Targeting | 测试采集目标 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:68 |  |
| Test Glamour | 测试魅力 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:222 |  |
| Test Hat | 测试帽子 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:226 |  |
| Test Map Marker from coords | 坐标中的测试地图标记 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_MapTesting.cs:44 |  |
| Test Mission List | 测试任务列表 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:61 |  |
| Test Naving to [New] | 测试导航到[新] | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:310 |  |
| Test Pathing to position | 测试路径到位置 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:124 |  |
| Test Picto | 测试图片 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:113 |  |
| Test Radius | 测试半径 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:46; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_MapTesting.cs:21 |  |
| Test Repair Function | 测试修复功能 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TaskManagerInfo.cs:42 |  |
| Test Sound Alert | 测试声音警报 | Button \| ICE\Ui\MainUi\Settings\StopWhen.cs:159 |  |
| Test Toast | 测试Toast | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:211 |  |
| Test Visor | 测试遮阳板 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:230 |  |
| Testing... if this fires off multiple times | 测试...如果多次触发 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:292 |  |
| Thank you everyone who's helped make this possible. | 感谢所有帮助实现这一目标的人。 | UI string \| ICE\Ui\Window_ExternalDetails.cs:58 |  |
| Thanks for using my plugin though, it means a lot <3 | 不过，感谢使用我的插件，这意味着很多<3 | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:326 |  |
| The buff restores itself when you re-enter the zone. | 当您重新进入区域时，buff会自行恢复。 | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:179 |  |
| The delays will be before, and a little bit inbetween interacting with menus | 之前会出现延迟，并且在与菜单交互之间会有一点 | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:182 |  |
| The following missions are required to have gold before you can do this one | 以下任务需要有金星才能执行此操作 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1384; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:635 |  |
| The most straightforward mode. Standard runs only the missions you have enabled | 最简单的模式。标准仅运行您已启用的任务 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:43 |  |
| The rest of the commands work by doing a single id/multiple in a row | 其余命令通过执行单个id/连续多个 | UI string \| ICE\ICE.cs:314 |  |
| There is 5 different modes that exist currently (as of writing this) that all serve minorly differently functions. | 当前存在5种不同的模式（截至撰写本文时），所有模式都提供略有不同的功能。 | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:12 |  |
| There will be another warning to pop up if you try and run this still and it selects a fishing mission... | 如果您尝试运行此任务并且它选择了钓鱼任务，将会弹出另一个警告... | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:216 |  |
| There's certain missions that are worth grinding more than others. Weather/time also plays a part of it all. Below is what I would recommend on a per class basis. | 有某些任务比其他任务更值得磨练。天气/时间也是其中的一部分。以下是我针对每个职业的建议。 | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Tips.cs:76 |  |
| These are a list of the following plugins that are required for the plugin to function. If you don't have these installed, it will not function properly | 这些是插件运行所需的以下插件的列表。如果您没有安装这些，它将无法正常运行 | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:16 |  |
| This can be applied with normal field mastery, but will only apply per hit | 这可以应用于正常的领域掌握，但仅适用于每次命中 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:973 |  |
| This can only be set to 1 item, and gererally used for things you want to just spend your credits on | 这只能设置为 1 个项目，通常用于您只想花费信用点的东西 | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:47 |  |
| This does abosolutely nothing | 这绝对没有任何作用 | Icon tooltip \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:324 |  |
| This gives you full control over what missions to run, making it ideal for: | 这使您可以完全控制要运行的任务，使其非常适合： | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:45 |  |
| This is ASSUMING: | 这是假设： | UI text \| ICE\Ui\Window_ExternalDetails.cs:373 |  |
| This is based on your average time. | 这是基于您的平均时间。 | UI text \| ICE\Ui\Window_ExternalDetails.cs:376 |  |
| This is here for safety! If you want to decrease the delay before turnin be my guest. | 这是为了安全起见！如果您想在成为我的客人之前减少延迟。 | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:61 |  |
| This is here for safety! If you want to decrease the delay between missions be my guest. | 这是为了安全！如果您想减少任务之间的延迟，请成为我的客人。 | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:39 |  |
| This is kind of my way of letting you somewhat script/set up a sequence of other things that you would like to do that might not be included in the plugin itself. | 这是我的一种方式，让您编写/设置一系列您想做的其他事情，这些事情可能不包含在插件本身中。 | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:242 |  |
| THIS IS YOUR HEADS UP ON HOW THIS WORKS. If I change this in the future, this tooltip will also change. | 请注意这是如何运作的。如果我将来更改此设置，此工具提示也会更改。 | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:293 |  |
| This is your personalized shopping list that you can create that it will run when you hit a certain amount of credits. | 这是您可以创建的个性化购物清单，当您达到一定数量的信用点时它将运行。 | UI text \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:40 |  |
| This isn't required, but highly recommended for leveling up characters. It will auto equip gear from your armory/inventory, and swap it out when running Leveling Grind Mode | 这不是必需的，但强烈建议用于升级角色。它将自动从你的军械库/库存中装备装备，并在运行练级刷取模式时将其更换。 | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:35 |  |
| This mission is currently missing stuff to allow it to work. It might be planet locked, or could be just needs mapped out | 此任务目前缺少让它职业的东西。它可能是行星锁定的，或者可能只是需要映射出来 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:285 |  |
| This mode is if you want to do a series of things in a particular order. So for example, if you wanted to grind out all the relics on all the classes back to back | 如果你想按特定顺序执行一系列操作，请使用此模式。例如，如果你想连续刷取所有职业的宇宙工具 | UI string \| ICE\Ui\MainWindow.cs:166 |  |
| This plugin is designed for specifically for the use of Cosmic Exploration, and is kinda hefty. So I'm going to try and go through all the different tips / tricks | 这个插件是专门为宇宙探索的使用而设计的，而且有点重。因此，我将尝试并完成所有不同的提示/技巧 | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\Welcome.cs:12 |  |
| This plugin is meant to help you with your cosmic exploration needs, | 这个插件旨在帮助您满足宇宙探索需求， | UI text (wrapped) \| ICE\Ui\InfoWindow.cs:44 |  |
| This setting is global and shared across all characters.<br>Edit it on the Global tab. | 此设置是全局的，并在所有角色之间共享。<br>在“全局”选项卡上编辑它。 | Tooltip \| ICE\Ui\MainUi\Settings\Character_Settings.cs:249 |  |
| This will adjust how much of the center point of the fan it will randomize from. | 这将调整扇形中心点的随机数量。 | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:101 |  |
| This will allow you to grind other classes for criticals/red alerts. | 这将允许您磨练其他职业的紧急任务/紧急任务。 | Help marker \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:263 |  |
| This will check to see if you're on a gathering/crafting class upon first entering the moon. | 这将检查是否有第一次进入月球时，你正在参加采集/制作课程。 | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:189 |  |
| This will make the Gamba prefer wheels with less items. | 这将使抽奖更喜欢物品较少的轮子。 | Help marker \| ICE\Ui\MainUi\Settings\GambaWheel.cs:50; ICE\Ui\MainUi\Settings\GambaWheel.cs:127 |  |
| This will ONLY run upon first entry. | 这只会在第一次进入时运行。 | UI string \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:192 |  |
| This will wipe out all your current profiles, and apply what I would suggest for each one. | 这将清除你当前的所有配置文件，并应用我对每个配置文件的建议。 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:1047 |  |
| Time | 时间 | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:69; ICE\Ui\Window_ExternalDetails.cs:472 |  |
| Time Attack | 时间攻击 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:35 |  |
| Time Required | Time required | UI string \| ICE\Ui\Window_ExternalDetails.cs:460 |  |
| Time Slot | 时隙 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:718 |  |
| Timed | 限时 | UI text \| ICE\Ui\OverlayWindow.cs:510 |  |
| Timed Scoring | Timed评分 | UI string \| ICE\Ui\Window_ExternalDetails.cs:453 |  |
| Timed Turnin | 限时转向 | Radio button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:971 |  |
| Timer: {0} | 计时器：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_CS\CS_TimerInfo.cs:19 |  |
| Times Attempted: {0} | 尝试次数：{0} | UI text \| ICE\Ui\Window_ExternalDetails.cs:360 |  |
| Times Completed: {0} | 完成次数：{0} | UI text \| ICE\Ui\Window_ExternalDetails.cs:359 |  |
| Timestamp | 时间戳 | Table column \| ICE\Ui\MainUi\HelpFolder\helpSelect_Logs.cs:149 |  |
| Tip Selector | 提示选择器 | UI string \| ICE\Ui\MainUi\HelpFolder\helpSelect_Tips.cs:45 |  |
| to be able to hit the threshold. And even then, if you manage to not hit it on the first attempt, it'll just keep gathering. Plus. This makes it to where I can not have to worry about profile managing on fishing for... 4 missions? Seemed minorly reduntant in my eyes. | 能够达到阈值。即便如此，如果你第一次尝试没有击中它，它就会继续聚集。加。这使得我不必担心钓鱼的配置文件管理...... 4 个任务？在我眼中似乎有点多余。 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:463 |  |
| To the side you'll find a couple of different tabs that will *try* and answer any question that you migth have. | 在旁边，您会发现几个不同的选项卡，它们将“尝试”并回答您可能遇到的任何问题。 | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\Welcome.cs:16 |  |
| ToDo ID | 待办事项 ID | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:189 |  |
| Toggle Setting | 切换设置 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:138 |  |
| Tokens | 代币 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:867 |  |
| Total Completions: {0}/{1} | 总完成数：{0}/{1} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:859 |  |
| Total Req | 总要求 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:21 |  |
| Total: {0} | 总：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:36 |  |
| Travel & Pathfinding | 旅行与寻路 | UI string \| ICE\Ui\MainUi\SelectableSidebar.cs:111 |  |
| Try and apply above profile | 尝试并应用上述配置文件 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1283 |  |
| TryGather | 尝试采集 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:14 |  |
| Turn in | 上交 | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:412 |  |
| Turnin if relic is complete | 如果宇宙工具已完成则上交 | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:284 |  |
| Turnin Mode | 上交模式 | Table column \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:258 |  |
| Type | 类型 | Table column \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:54; ICE\Ui\MainUi\Settings\Priority_Settings.cs:124; ICE\Ui\MainUi\Settings\Priority_Settings.cs:207 |  |
| Type Priority Table | 类型优先级表 | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:50 |  |
| typed in correctly. This is *case* specific so | 正确输入。这是*案例*特定的所以 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1290 |  |
| Ui: Fishing Hole Editor | Ui：钓场编辑器 | UI string \| ICE\Ui\DebugWindow.cs:66 |  |
| Ui: Fishing Preset Editor | Ui：钓鱼预设编辑器 | UI string \| ICE\Ui\DebugWindow.cs:67 |  |
| Ui: Gather Editor | Ui：采集编辑器 | UI string \| ICE\Ui\DebugWindow.cs:68 |  |
| Ui: Log Viewer | Ui：日志查看器 | UI string \| ICE\Ui\DebugWindow.cs:69 |  |
| Ui: Player Gearsets | Ui：玩家齿轮组 | UI string \| ICE\Ui\DebugWindow.cs:70 |  |
| Ui: Select String | Ui：选择字符串 | UI string \| ICE\Ui\DebugWindow.cs:65 |  |
| Ui: Table V3 | Ui：表格V3 | UI string \| ICE\Ui\DebugWindow.cs:45 |  |
| Unknown Debug View | 未知调试视图 | UI text \| ICE\Ui\DebugWindow.cs:134 |  |
| Unknown Job | 未知作业 | UI string \| ICE\Ui\MainUi\Settings\Priority_Settings.cs:258 |  |
| Unknown Tip View | 未知提示查看 | UI text \| ICE\Ui\MainUi\HelpFolder\helpSelect_Tips.cs:67 |  |
| Unknown0 | 未知0 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:65 |  |
| Unknown1 | 未知1 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:75 |  |
| Unknown10 | 未知10 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:135 |  |
| Unknown11 | 未知11 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:145 |  |
| Unknown12 | 未知12 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:155 |  |
| Unknown13 | 未知13 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:165 |  |
| Unknown14 | 未知14 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:175 |  |
| Unknown15 | 未知15 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:185 |  |
| Unknown16 | 未知16 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:195 |  |
| Unknown17 | 未知17 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:205 |  |
| Unknown18 | 未知18 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:215 |  |
| Unknown19 | 未知19 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:225 |  |
| Unknown2 | 未知2 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:85 |  |
| Unknown3 | 未知3 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:95 |  |
| Unknown4 | 未知4 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:105 |  |
| Unknown8 | 未知8 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:115 |  |
| Unknown9 | 未知9 | UI text \| ICE\Ui\DebugWindowTabs\Sheet_MissionRewards.cs:125 |  |
| Unlocked | 解锁 | Table column \| ICE\Ui\MainUi\Settings\GambaWheel.cs:159; ICE\Ui\MainUi\Settings\ShoppingTab.cs:217 |  |
| Until maxed only | Until仅最大 | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:72 |  |
| Update all mission text | 更新所有任务文本 | Button \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionText.cs:19 |  |
| Update Best Mission | 更新最佳任务 | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:166; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:102 |  |
| Update Character Stats | 更新角色统计 | UI string \| ICE\ICE.cs:137 |  |
| Update Dummy XP | 更新虚拟人物XP | Button \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:104 |  |
| Update Gearsets | 更新齿轮组 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Gearsets.cs:41 |  |
| Urgency Exp Values | 紧急经验值 | UI string \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:211 |  |
| Use Aethernet | 使用以太之光 | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:113 |  |
| Use after this many steps | 在这么多步骤后使用 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1991 |  |
| Use Built In Preset | 使用内置预设 | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1267; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:507 |  |
| Use cogs button instead of home | 使用齿轮按钮而不是home | Checkbox \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:49 |  |
| Use cordial when below the following GP | 在低于以下条件时使用强心剂键GP | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:222 |  |
| Use Drone | 使用无人机 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:120 |  |
| Use food on gathering missions | 在采集任务中使用食物 | Checkbox \| ICE\Ui\MainUi\Settings\GatherSettings.cs:243 |  |
| Use Gathering Food | 使用采集食物 | Button \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:85 |  |
| Use Global Artisan Settings | 使用全局Artisan设置 | Checkbox \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1513 |  |
| Use Hub Return | 使用自动寻路返回 | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:106 |  |
| Use mount in mission | 在任务中使用坐骑 | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:863; ICE\Ui\MainUi\Settings\Character_Settings.cs:893 |  |
| Use mount outside mission | 在任务外使用坐骑 | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:859; ICE\Ui\MainUi\Settings\Character_Settings.cs:885 |  |
| Use no gathering food | 不使用采集食物 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:280 |  |
| Use personal return spots | 使用个人返回点 | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:241 |  |
| Use Red Alert NPC for travel | 使用紧急任务NPC进行旅行 | Checkbox \| ICE\Ui\MainUi\Settings\TravelSettings.cs:120 |  |
| Use Stylist to re-equip tools | 使用Stylist重新装备工具 | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:988; ICE\Ui\MainUi\Settings\Character_Settings.cs:1033 |  |
| Useful for things like cordials where you want to always have a certain amount on hand | 对于像强心剂之类的东西很有用，你想要手头上总是有一定数量的 | UI string \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:43 |  |
| Valid Moon NPC Info: {0} | 有效月亮NPC信息：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NpcViewer.cs:24 |  |
| Value | 价值 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:29 |  |
| Variety of Fish Required | 所需的鱼品种 | UI string \| ICE\Ui\Window_ExternalDetails.cs:457 |  |
| Variety Req | 品种要求 | Table column \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_FishInfo.cs:22 |  |
| Very useful for quick score farming, mount tokens. | 非常适合快速刷分和兑换坐骑代币。 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1013 |  |
| Viable fishing spot: {0} | 可行的钓场：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:186 |  |
| View All Presets | 查看所有预设 | Button \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:356 |  |
| View All SE Custom Fonts (That's known | 查看所有SE自定义字体（这是已知的 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_TestButtons.cs:381 |  |
| View Fishing Spots | 查看钓场 | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:199 |  |
| View Nav Spots | 查看导航点 | Checkbox \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:209 |  |
| Visualize Dismount Radius | 可视化下车半径 | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:878; ICE\Ui\MainUi\Settings\Character_Settings.cs:919 |  |
| Visualize radius | 可视化半径 | Checkbox \| ICE\Ui\MainUi\Settings\Character_Settings.cs:871; ICE\Ui\MainUi\Settings\Character_Settings.cs:907 |  |
| Wah thank you for the UI, this is fucking beautiful as always | 哇谢谢你的UI，这他妈的很漂亮总是 | UI string \| ICE\Ui\Window_ExternalDetails.cs:61 |  |
| Waiting for "WKSHud" to be visible | 等待“WKShud”可见 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MainMoon.cs:53 |  |
| Waiting for "WKSLottery" to be visible | 等待“WKSLotery”可见 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_WheelofFortune.cs:54 |  |
| Waiting for "WKSMission" to be visible | 等待“WKSMission”可见 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:181 |  |
| Waiting for "WKSMissionInfomation" to be visible | 等待“WKSMissionInfomation”可见 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MissionInfo.cs:169 |  |
| Waiting for "WKSRecipeNotebook" to be visible | 等待“WKSRecipeNotebook”可见 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_MoonRecipe.cs:49 |  |
| Waiting for a shop exchange window to be open | 等待商店兑换窗口出现打开 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_ItemExchange.cs:233 |  |
| Waiting for Gather Collectable window to be visible | 等待采集采集窗口可见 | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_CollectableGathering.cs:142 |  |
| Warning! This is a safety feature to avoid joining random parties! | 警告！这是避免加入随机队伍的安全功能！ | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:29 |  |
| We're somehow not showing the window, so returning 0. | 我们不知何故没有显示该窗口，因此返回0. | UI string \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:282 |  |
| Weather | 天气 | UI text \| ICE\Ui\OverlayWindow.cs:510 |  |
| Weather Required | 需要天气 | Table column \| UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_TimeWeather.cs:14; ICE\Ui\Window_ExternalDetails.cs:461 |  |
| Weather/Time Info | 天气/时间信息 | UI string \| ICE\Ui\OverlayWindow.cs:71 |  |
| Weather: {0} | 天气：{0} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:615; ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:881 |  |
| Weaver (WVR) | Weaver(WVR) | UI string \| ICE\Ui\MainUi\Settings\Settings_TableColumns.cs:69 |  |
| Weight | 重量 | Table column \| ICE\Ui\MainUi\Settings\GambaWheel.cs:161 |  |
| Welcome! This is probably the most complicated plugin I've created so far. | 欢迎！这可能是迄今为止我创建的最复杂的插件。 | UI text (wrapped) \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\Welcome.cs:11 |  |
| What do you a dinosaur that only has one eye? | 你是一只只有一只眼睛的恐龙吗？ | UI string \| ICE\Ui\Window_ExternalDetails.cs:53 |  |
| What is a pirates favorite letter? | 海盗最喜欢的字母是什么？ | UI string \| ICE\Ui\Window_ExternalDetails.cs:26 |  |
| What is a skeleton's favorite snack? | 骷髅最喜欢的零食是什么？ | UI string \| ICE\Ui\Window_ExternalDetails.cs:42 |  |
| What's the maximum amount of drones you wanna keep? | 你想要保留的无人机的最大数量是多少？ | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:56 |  |
| What's the minimum durability a node can have before this action is activated? | 在此操作之前节点可以拥有的最低耐用性是多少已激活？ | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:640; ICE\Ui\MainUi\Settings\GatherSettings.cs:696 |  |
| What's the minimum gp you can have before it uses a cordial. | 在使用强心剂感之前，您可以拥有的最低 gp 是多少。 | Help marker \| ICE\Ui\MainUi\Settings\GatherSettings.cs:228 |  |
| When do you wanna buy drones from the vendor? | 您想从供应商那里购买无人机吗？ | UI string \| ICE\Ui\MainUi\Settings\Shop_Dronebit.cs:42 |  |
| When enabled, overlays will render over the native UI elements | 启用后，叠加层将在原生 UI 元素上渲染 | Tooltip \| ICE\Ui\MainUi\Settings\Misc_Settings.cs:161 |  |
| When enabled, Stellar Return will still be used to return to the hub<br>for activities like credit purchases, gambling, drone bits, and repairs. | 启用后，Stellar Return 仍将用于返回中心<br>进行信用购买、赌博、无人机零件和维修等活动。 | Tooltip \| ICE\Ui\MainUi\Settings\TravelSettings.cs:149 |  |
| When enabled, the pathfinder will not use Stellar Return to travel to gathering nodes.<br>This applies to both Hub Return and Hub + Aethernet travel methods. | 启用后，探路者不会使用恒星返回前往聚集节点。<br>这适用于自动寻路返回和自动寻路 + 以太之光旅行方法。 | Tooltip \| ICE\Ui\MainUi\Settings\TravelSettings.cs:136 |  |
| When stuck during navmesh movement for the configured delay: | 当在导航网移动期间卡住配置的延迟时： | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:203 |  |
| Where'd the dual craft amount go? | 双工艺量去了哪里？ | UI text \| ICE\Ui\MainUi\Settings\GatherSettings.cs:448 |  |
| White Mage | 白法师 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:24; ICE\Ui\MainUi\Settings\Character_Settings.cs:1050 |  |
| Why are tennis pros always hugging each other? | 为什么网球职业选手总是互相拥抱？ | UI string \| ICE\Ui\Window_ExternalDetails.cs:33 |  |
| Why can't ghost have babies? | 为什么幽灵不能生孩子？ | UI string \| ICE\Ui\Window_ExternalDetails.cs:36 |  |
| Will also pause pandora cordial usage while on the moon | 在月亮 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:196 |  |
| Will only apply when the gathering node has full durability | 仅在采集节点具有完全耐久度时适用 | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:615; ICE\Ui\MainUi\Settings\GatherSettings.cs:671; ICE\Ui\MainUi\Settings\GatherSettings.cs:779 |  |
| Will only work while using ICE and not manual mode | 仅在使用ICE时职业，而不是手动模式 | Help marker \| ICE\Ui\MainUi\Settings\GatherSettings.cs:195 |  |
| Will turnin once the timer runs out | 将在计时器用完后交接 | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:978 |  |
| Will turnin the mission as soon as it can | 将尽快交接任务 | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:1012 |  |
| Will turnin when 1 of the 2 things are met: | 将在满足两件事之一时交接： | Tooltip \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:990 |  |
| WKSMission Time Sheet | WKSMission时间表 | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_TimeWeather.cs:11 |  |
| World Cords: {0}, {1}, {2} | 世界线：{0}，{1}、{2} | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_GatheringInfo.cs:88 |  |
| World Stage: {0} | 世界舞台：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_PlayerInfo.cs:35 |  |
| WVR | WVR | UI string \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:30; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionSelect.cs:28; ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:16; ICE\Ui\MainUi\Settings\Misc_Settings.cs:129 |  |
| X Location | X 位置 | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:42 |  |
| x {0} | x {0} | UI string \| ICE\Ui\MainUi\Settings\GatherSettings.cs:303 |  |
| X: {0} Y: {1} | X：{0} Y：{1} | Icon button \| ICE\Ui\MainUi\Settings\TravelSettings.cs:316 |  |
| X: {0} \| Y: {1} | X：{0} \| Y：{1} | UI text \| ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:362; ICE\Ui\Debug_Tabs\Debug_Tables\Table_MissionInfo.cs:373 |  |
| X: {0} \| Y: {1} \| Z: {2} | X：{0} \| Y：{1} \| Z：{2} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:275 |  |
| X: {0}, Y: {1}, Z: {2} | X：{0}，Y：{1}，Z：{2} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_NavmeshTesting.cs:37 |  |
| X: {0}, Z: {1} | X：{0}，Z：{1} | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:308 |  |
| XP: {0} | XP：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Hud\Hud_Mission.cs:124 |  |
| Y Location | Y位置 | Input label \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:44 |  |
| Yet | 但是 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:994 |  |
| yields the most for your current level. | 为您当前的级别提供最大的收益。 | UI string \| ICE\Ui\MainUi\HelpFolder\Tips_Folder\ModeSelection.cs:63 |  |
| You can buy cosmocredit items from the list! | 您可以从列表中购买宇宙信用点项目！ | UI text \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:72 |  |
| You can set your score with this mode yourself, due to not knowing the scoring break points | 您可以自己使用此模式设置您的分数，因为不知道评分断点 | UI string \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:993 |  |
| You can't buy any items with your current credit value/items (tis fine, this just a test) | 您无法使用当前的信用值/项目购买任何项目（很好，这只是一个测试） | UI text \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:76 |  |
| You currently don't have any profiles saved! Please either make one and save, or import if you would like to populate this listing | 您目前没有保存任何配置文件！请制作一个并保存，或者如果您想填充此列表，请导入 | UI text (wrapped) \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:403 |  |
| You don't have to use this, it will just use a random spot if: | 您不必使用此功能，它只会使用一个随机点，如果： | UI string \| ICE\Ui\MainUi\Settings\TravelSettings.cs:278 |  |
| You give him Cprrrrrr | 您给他Cprrrrrrr | UI string \| ICE\Ui\Window_ExternalDetails.cs:40 |  |
| You have been warned. Disable at your own risk. | 您已被警告。禁用后果自负。 | UI string \| ICE\Ui\MainUi\Settings\SafetySettings.cs:31 |  |
| You know, I was reading this book about anti-gravity recently, | 你知道，我最近在读这本关于反重力的书， | UI string \| ICE\Ui\Window_ExternalDetails.cs:30 |  |
| You might thing it's R, but tis first love was the C | 你可能认为它是 R，但它的初恋是 C | UI string \| ICE\Ui\Window_ExternalDetails.cs:27 |  |
| You need to (currently) be on the testing version to be able fish automated here | 你需要（当前）处于测试版本才能在此处自动化捕鱼 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:215 |  |
| You need to update autohook for you to be able to fish here on Auxesia. Please swap to testing version | 你需要更新 autohook 才能在 奥克塞西亚行星 上钓鱼。请切换到测试版本 | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_IPCTesting.cs:214 |  |
| Zone {0} - X:{1} Z:{2} | 区域 {0} - X:{1} Z:{2} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:229 |  |
| Zone: {0} | 区域：{0} | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_Fish_HoleEditor.cs:95 |  |
| [Average] Rewards per minute | [平均] 每分钟奖励 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\CosmicTable\Mission_Table.cs:856 |  |
| [MAX] | [最大限度] | UI text \| ICE\Ui\Relic_XP.cs:56 |  |
| [{0}] {1} ({2}x tokens) | [{0}] {1} ({2}x 代币) | UI text \| ICE\Ui\OverlayWindow.cs:299 |  |
| {0} ({1} items) | {0} ({1}items) | UI text \| ICE\Ui\MainUi\Settings\ShoppingTab.cs:206 |  |
| {0} - Current | {0} - 当前 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:36 |  |
| {0} - Max | {0} - 最大 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:38 |  |
| {0} - Need | {0} - 需要 | Table column \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_RelicInfo.cs:37 |  |
| {0} / {1} (Max: {2}) | {0} / {1} (最大: {2}) | UI text \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_ClassInfo.cs:53 |  |
| {0} In {1} | {0} 在 {1} | UI string \| ICE\Ui\MainUi\Settings\DebugTab.cs:40 |  |
| {0} is installed | {0} 中已安装 | UI text \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:66 |  |
| {0} Mode | {0} 模式 | Section header \| ICE\Ui\MainUi\ModeSelect_Modes\Cosmic_Agenda.cs:88; ICE\Ui\MainUi\ModeSelect_Modes\Mission_Setup.cs:101 |  |
| {0} Repo is Installed | {0} 回购是已安装 | UI text \| ICE\Ui\MainUi\HelpFolder\helpSelect_Required.cs:47 |  |
| {0} Weather - {1} | {0} 天气 - {1} | UI string \| ICE\Ui\MainUi\Settings\DebugTab.cs:33 |  |
| {0} — turn in at {1} or better | {0} — 在 {1} 或更好的 | UI text \| ICE\Ui\MainUi\ModeSelect_Modes\Expedition_Log.cs:422 |  |
| {0}-{1} of {2} | {0}-{1} 处交房，共 {2} | UI text \| ICE\Ui\MainUi\Settings\Character_Settings.cs:847 |  |
| \| LandZone pick failed, kept player pos | \|LandZone 选择失败，保留玩家 pos | UI string \| ICE\Ui\Debug_Tabs\Debug_Ui\Ui_GatherEditor.cs:422 |  |
| ♥ Ko-fi (Buy me an ice coffee) | ♥ Ko-fi（给我买杯冰咖啡） | Tooltip \| ICE\Ui\MainWindow.cs:32 |  |
