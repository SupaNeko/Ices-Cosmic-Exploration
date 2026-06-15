using Dalamud.Interface;
using ICE.Ui.Debug_Tabs.Debug_CS;
using ICE.Ui.Debug_Tabs.Debug_Hud;
using ICE.Ui.Debug_Tabs.Debug_Tables;
using ICE.Ui.Debug_Tabs.Debug_Ui;
using ICE.Ui.DebugWindowTabs;
using ICE.Ui.MainUi.HelpFolder;
using System.Collections.Generic;

namespace ICE.Ui;

internal class DebugWindow : Window
{
    private bool _showSidebar = true;

    public DebugWindow() :
        base($"ICE {P.GetType().Assembly.GetName().Version} Debugger ###IceCosmicDebug1")
    {
        Flags = ImGuiWindowFlags.None;
        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(100, 100),
            MaximumSize = new Vector2(3000, 3000)
        };

        // Title-bar toggle for the left tab list, so the window can be shrunk down to just the content.
        TitleBarButtons.Add(new TitleBarButton
        {
            Icon = FontAwesomeIcon.Bars,
            IconOffset = new Vector2(2, 1),
            Click = _ => _showSidebar = !_showSidebar,
            ShowTooltip = () => ImGui.SetTooltip(_showSidebar ? "隐藏选项卡列表" : "显示选项卡列表"),
        });

        P.windowSystem.AddWindow(this);
    }

    public void Dispose()
    {
        P.windowSystem.RemoveWindow(this);
    }

    private readonly Dictionary<string, Action> DebugViews = new()
    {
        ["Ui：表格V3"] = () => Table_MissionsV3.Draw(),

        // HUD Elements
        ["Hud：月球主"] = () => Hud_MainMoon.Draw(),
        ["Hud：任务"] = () => Hud_Mission.Draw(),
        ["Hud：任务信息"] = () => Hud_MissionInfo.Draw(),
        ["Hud：命运之轮！"] = () => Hud_WheelofFortune.Draw(),
        ["Hud：月球食谱"] = () => Hud_MoonRecipe.Draw(),
        ["Hud：收集收藏品"] = () => Hud_CollectableGathering.Draw(),
        ["Hud：物品交换"] = () => Hud_ItemExchange.Draw(),

        // Table Elements
        ["Table：任务信息"] = () => Table_MissionInfo.Draw(),
        ["Table：收集任务"] = () => Table_GatheringInfo.Draw(),
        ["表：特殊任务"] = () => Table_TimeWeather.Draw(),
        ["Table：任务文本"] = () => Table_MissionText.Draw(),
        ["表：食谱"] = () => Table_MoonRecipies.Draw(),
        ["Table：鱼类信息"] = () => Table_FishInfo.Draw(),

        // UI Elements
        ["Ui：选择字符串"] = () => Ui_RedAlertString.Draw(),
        ["Ui：钓场编辑器"] = () => Ui_Fish_HoleEditor.Draw(),
        ["Ui：钓鱼预设编辑器"] = () => Ui_FishPresets.Draw(),
        ["Ui：收集编辑器"] = () => Ui_GatherEditor.Draw(),
        ["Ui：日志查看器"] = () => helpSelect_Logs.Draw_Debug(),
        ["Ui：玩家齿轮组"] = () => Ui_Gearsets.Draw(),

        // Non-labeled Elements
        ["CS：Tiemr信息"] = () => CS_TimerInfo.Draw(),
        ["CS：可用任务"] = () => CS_Missions.Draw(),
        ["玩家信息"] = () => Ui_PlayerInfo.Draw(),
        ["测试按钮"] = () => Ui_TestButtons.Draw(),
        ["IPC 测试"] = () => Ui_IPCTesting.Draw(),
        ["Map Test"] = () => Ui_MapTesting.Draw(),
        ["Navmesh 测试"] = () => Ui_NavmeshTesting.Draw(),
        ["文物信息"] = () => Ui_RelicInfo.Draw(),
        ["TaskManager 测试"] = () => Ui_TaskManagerInfo.Draw(),
        ["NPC 盒子查看器"] = () => Ui_NpcViewer.Draw(),
        ["ImGui测试"] = () => UI_Test.Draw(),
        ["文物信息V2"] = () => Ui_ClassInfo.Draw(),

        // Sheet Viewer Info
        ["职业表：任务奖励"] = () => Sheet_MissionRewards.Draw(),
        ["Table：升级任务"] = () => Table_LevelingMissions.Draw(),
        ["Table：任务选择"] = () => Table_MissionSelect.Draw(),
        ["奥伊济尔地图资料"] = () => Ui_OyzinMap.Draw(),
        ["以太之光测试"] = () => Ui_Aethernet.Draw(),

        ["IPC：Artisan"] = () => Ipc_Artisan.Draw()
    };

    private string selectedDebugView = "Hud：月球主"; // Store the name instead of index

    public override unsafe void Draw()
    {
        float spacing = 10f;
        float leftPanelWidth = 200f;
        float childHeight = ImGui.GetContentRegionAvail().Y;

        if (_showSidebar)
        {
            if (ImGui.BeginChild("DebugSelector", new Vector2(leftPanelWidth, childHeight), true))
            {
                foreach (var viewName in DebugViews.Keys)
                {
                    bool isSelected = (selectedDebugView == viewName);
                    string label = isSelected ? $"→ {viewName}" : $"   {viewName}";

                    if (ImGui.Selectable(label, isSelected))
                    {
                        selectedDebugView = viewName;
                    }
                }
            }
            ImGui.EndChild();

            ImGui.SameLine(0, spacing);
        }

        float rightPanelWidth = ImGui.GetContentRegionAvail().X;

        if (ImGui.BeginChild("DebugContent", new Vector2(rightPanelWidth, childHeight), true))
        {
            if (DebugViews.TryGetValue(selectedDebugView, out var drawAction))
            {
                drawAction();
            }
            else
            {
                ImGui.Text("未知调试视图");
            }
        }
        ImGui.EndChild();
    }
}
