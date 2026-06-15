using Dalamud.Interface;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Textures;
using Dalamud.Interface.Utility.Raii;
using ECommons.GameHelpers;
using ICE.Ui.MainUi;
using ICE.Ui.MainUi.HelpFolder;
using ICE.Ui.MainUi.ModeSelect_Modes;
using ICE.Ui.MainUi.Settings;
using ICE.Ui.MainUi.Settings.Settings_Table;
using System.Collections.Generic;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace ICE.Ui
{
    internal class MainWindow : Window
    {
        public MainWindow() :
#if DEBUG
        base($"Ice's Cosmic Exploration {P.GetType().Assembly.GetName().Version} [Debug Build] ###ICEMainWindow2")
#else
        base($"Ice's Cosmic Exploration {P.GetType().Assembly.GetName().Version} ###ICEMainWindow2")
#endif
        {
            Flags = ImGuiWindowFlags.NoScrollbar;
            SizeConstraints = new()
            {
                MinimumSize = new Vector2(500, 500),
                MaximumSize = new Vector2(4000, 4000),
            };
            TitleBarButtons.Add(new() { ShowTooltip = () => ImGui.SetTooltip("♥ Ko-fi（给我买杯冰咖啡）"), Icon = FontAwesomeIcon.Heart, IconOffset = new(1, 1), Click = _ => GenericHelpers.ShellStart("https://ko-fi.com/ice643269") });

            P.windowSystem.AddWindow(this);

            AllowPinning = true;
            AllowClickthrough = true;
        }

        public void Dispose()
        {
            P.windowSystem.RemoveWindow(this);
        }

        public override void Draw()
        {
            using var style = ImRaii.PushStyle(ImGuiStyleVar.ChildRounding, 10).Push(ImGuiStyleVar.ChildBorderSize, 1);

            SelectableSidebar.Draw();

            ImGui.SameLine(0, 5);

            var windowSizeRemaining = ImGui.GetContentRegionAvail();
            using (var mainBody = ImRaii.Child("mainBody_WindowV3", windowSizeRemaining, true))
            {
                if (!mainBody.Success) return;
                MainBody();
            }
        }

        private static readonly Dictionary<WindowSelection, Action> SelectedView = new()
        {
            // Cosmic Helper
            [WindowSelection.MissionSetup] = () =>  Mission_Setup.Draw(),
            [WindowSelection.CosmicAgenda] = () => Cosmic_Agenda.Draw(),
            [WindowSelection.ExpeditionLogs] = () => Expedition_Log.Draw(),

            // Settings
            [WindowSelection.StopWhen] = () => StopWhen.Draw(),
            [WindowSelection.GatheringProfiles] = () => GatherSettings.Draw(),
            [WindowSelection.MissionPriority] = () => Priority_Settings.Draw(),
            [WindowSelection.CharacterSettings] = () => Character_Settings.Draw(),
            [WindowSelection.MiscSettings] = () => Misc_Settings.Draw(),
            [WindowSelection.TravelSettings] = () => TravelSettings.Draw(),

            // Hub Activities
            [WindowSelection.CreditShopping] = () => ShoppingTab.Draw(),
            [WindowSelection.GambaShopping] = () => GambaWheel.Draw(),
            [WindowSelection.DroneShopping] = () => Shop_Dronebit.Draw(),

            // Help Section
            [WindowSelection.Plugin_Install] = () => helpSelect_Required.Draw(),
            [WindowSelection.Plugin_Logs] = () => helpSelect_Logs.Draw_Helper(),
            [WindowSelection.Plugin_Tips] = () => helpSelect_Tips.Draw(),
        };

        private static void MainBody()
        {
            var selectedWindow = C.SelectedTab;

            if (SelectedView.TryGetValue(selectedWindow, out var drawAction))
            {
                drawAction();
            }
            else
            {
                ImGui.Text("呵呵");
            }
        }

        public static void ModeSelection()
        {
            bool standard = C.SelectedMode == ModeSelect.Standard;
            bool relicMode = C.SelectedMode == ModeSelect.RelicMode;
            bool xpLeveling = C.SelectedMode == ModeSelect.LevelMode;
            bool goldMode = C.SelectedMode == ModeSelect.MissionGoldMode;
            bool agendaMode = C.SelectedMode == ModeSelect.AgendaMode;

            ImGui.Text("选择模式");
            ImGui.Separator();

            if (ImGui.RadioButton("标准模式", standard))
            {
                C.SelectedMode = ModeSelect.Standard;
                C.Save();
            }
            ImGuiEx.HelpMarker(HelpInfoText(ModeSelect.Standard));
            if (ImGui.RadioButton("辉煌武器刷取", relicMode))
            {
                C.SelectedMode = ModeSelect.RelicMode;
                C.Save();
            }
            ImGuiEx.HelpMarker(HelpInfoText(ModeSelect.RelicMode));

            if (ImGui.RadioButton("练级刷取", xpLeveling))
            {
                C.SelectedMode = ModeSelect.LevelMode;
                C.Save();
            }
            ImGuiEx.HelpMarker(HelpInfoText(ModeSelect.LevelMode));
            if (ImGui.RadioButton("金牌完成刷取", goldMode))
            {
                C.SelectedMode = ModeSelect.MissionGoldMode;
                C.Save();
            }
            ImGuiEx.HelpMarker(HelpInfoText(ModeSelect.MissionGoldMode));
            if (ImGui.RadioButton("日程模式", agendaMode))
            {
                C.SelectedMode = ModeSelect.AgendaMode;
                C.Save();
            }
            ImGuiEx.HelpMarker(HelpInfoText(ModeSelect.AgendaMode));
        }
        public static string HelpInfoText(ModeSelect mode)
        {
            return mode switch
            {
                ModeSelect.Standard =>
                    "标准模式\n" +
                    "-> 用于选择你想刷的任务。优先级如下：\n" +
                    "-> 紧急任务 -> 临时任务[连续/限时/天气] -> 标准任务[A→D]\n" +
                    "-> 选择你想做的任务，然后开始吧。",
                ModeSelect.LevelMode =>
                    "练级刷取\n" +
                    "-> 会根据你当前所在等级区间自动选择最适合练级的任务\n" +
                    "-> 这些任务由我手动挑选，依据是完成所需时间\n" +
                    "-> 对制作职业来说，是所需进展最少的任务；对采集职业来说，是技能需求最少、最轻松的任务\n" +
                    "**这些会临时自动设置使用这些模式所需的设置**",
                ModeSelect.RelicMode =>
                    "辉煌武器刷取\n" +
                    "-> 自动选择最有利于完成辉煌武器的任务\n" +
                    "-> 这些任务根据完成工具下一阶段所需条件进行权衡\n" +
                    "-> 如果你只想做特定任务，请启用该选项并选择要做的任务",
                ModeSelect.AgendaMode =>
                    "如果你想按特定顺序执行一系列操作，请使用此模式。例如，如果你想连续刷取所有职业的辉煌武器\n" +
                    "或者你想先完成裁衣匠的辉煌武器 -> 然后去园艺工刷分 -> 再去锻铁匠刷信用点\n" +
                    "这本质上就是“我想按这个顺序做事”的模式。\n" +
                    "注意：如果你一直开着它并因此被封号，我不负责。我不是那种会把东西丢在电脑上不管的人，但总会有人盯着。请记住这一点",
                ModeSelect.MissionGoldMode =>
                    "金牌完成模式\n" +
                    "-> 会自动选择你当前尚未获得金牌的所有任务，且只做这些任务。\n" +
                    "-> 如果属于连续任务链，它会接取前置任务以帮助完成，必要时也会接取后续任务\n" +
                    "-> 如果没有可刷新的任务，它会不断切换标签页直到任务可用（通过临时或紧急任务）\n" +
                    "**这会尊重你启用跨职业临时任务和紧急任务的设置**",
                _ => "???? 不知何故这里缺失了。请向我报告"
            };
        }
    }
}
