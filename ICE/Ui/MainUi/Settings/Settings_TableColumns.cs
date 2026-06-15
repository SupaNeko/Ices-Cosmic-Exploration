using Dalamud.Interface.Utility.Raii;
using ICE.Utilities.Cosmic_Helper;
using ICE.Utilities.ImGuiTools;

namespace ICE.Ui.MainUi.Settings;

public static class Settings_TableColumns
{
    private static string[] missionSortOptions = 
        ["Id", "姓名", "Cosmo积分", "月球积分", 
        "Exp I", "Exp II", "Exp III", "Exp IV", "Exp V", 
        "地图位置", "Class分数", "类经验"];

    public static void ColumnSettings()
    {
        int missionSelectedOption = C.TableSortOption;
        if (ImGui.BeginCombo("Sort By", missionSortOptions[missionSelectedOption]))
        {
            for (int i = 0; i < missionSortOptions.Length; i++)
            {
                bool isSelected = (i == missionSelectedOption);
                if (ImGui.Selectable(missionSortOptions[i], isSelected))
                {
                    missionSelectedOption = i;
                }
                if (isSelected)
                {
                    ImGui.SetItemDefaultFocus();
                }
                if (missionSelectedOption != C.TableSortOption)
                {
                    C.TableSortOption = missionSelectedOption;
                    C.Save();
                }
            }
            ImGui.EndCombo();
        }

        bool hideUnsupported = C.HideUnsupportedMissions;
        if (ImGui.Checkbox("隐藏不支持的任务", ref hideUnsupported))
        {
            C.HideUnsupportedMissions = hideUnsupported;
            C.Save();
        }

        bool autoShowToken = C.Auto_ShowTokens;
        if (ImGui.Checkbox("自动隐藏/显示星球令牌", ref autoShowToken))
        {
            C.Auto_ShowTokens = autoShowToken;
            C.Save();
        }

        ImGuiEx.HelpMarker("仅当您想自己计划执行任务时才启用此功能。并且不自动化. " +
                           "或者如果你让一个不同的插件完成所有上交、制作、收集的自动化......而不让 I.C.E. 处理与这些插件的交互");
    }

    private static bool ApplyToAllClasses = true;
    private static bool ApplyToSpecicClass = false;
    private static int SpecificClass = 8;
    private static int selectedClassIndex = 0;

    private static readonly string[] classOptions = new[]
    {
        "木匠 (CRP)",      // 0
        "铁匠（BSM）",     // 1
        "装甲师(ARM)",        // 2
        "金匠（GSM）",      // 3
        "皮革工人 (LTW)",  // 4
        "Weaver(WVR)",         // 5
        "炼金术士（ALC）",      // 6
        "Culinarian（CUL）",     // 7
        "矿工(MIN)",          // 8
        "植物学家 (BTN)",       // 9
        "费舍尔 (FSH)"          // 10
    };

    private static readonly int[] classIds = new[]
    {
        8,  // Carpenter
        9,  // Blacksmith
        10, // Armorer
        11, // Goldsmith
        12, // Leatherworker
        13, // Weaver
        14, // Alchemist
        15, // Culinarian
        16, // Miner
        17, // Botanist
        18  // Fisher
    };

    private static TurninState HighestTurnin = TurninState.Gold;

    public static void GeneralMissionSettings()
    {
        if (ImGui.Button("快速应用转向"))
        {
            ImGui.OpenPopup("快速应用_任务转向");
        }

        if (ImGui.BeginPopup("快速应用_任务转向"))
        {
            if (ImGui.RadioButton("适用于所有职业", ApplyToAllClasses))
            {
                ApplyToAllClasses = true;
                ApplyToSpecicClass = false;
            }

            if (ImGui.RadioButton("适用于特定职业", ApplyToSpecicClass))
            {
                ApplyToAllClasses = false;
                ApplyToSpecicClass = true;
            }
            if (ImGui.Combo("##ClassSelector", ref selectedClassIndex, classOptions, classOptions.Length))
            {
                // Update SpecificClass when selection changes
                SpecificClass = classIds[selectedClassIndex];
                IceLogging.Debug($"Selected class: {classOptions[selectedClassIndex]}, ID: {SpecificClass}");
            }
            ImGui.Separator();
            ImGui.Text("选择上交选项");
            ImGui.Dummy(new Vector2(0, 2));

            if (ImGui.RadioButton("黄金", HighestTurnin is TurninState.Gold))
            {
                HighestTurnin = TurninState.Gold;
            }
            if (ImGui.RadioButton("银", HighestTurnin is TurninState.Silver))
            {
                HighestTurnin = TurninState.Silver;
            }
            if (ImGui.RadioButton("铜牌", HighestTurnin is TurninState.Bronze))
            {
                HighestTurnin = TurninState.Bronze;
            }

            ImGui.Separator();

            if (ImGui.Button("应用"))
            {
                var amountApplied = 0;
                foreach (var mission in C.MissionConfig)
                {
                    if (CosmicHelper.SheetMissionDict.TryGetValue(mission.Key, out var sheetInfo))
                    {
                        if (ApplyToSpecicClass && !sheetInfo.Jobs.Contains((uint)SpecificClass))
                            continue;

                        if (sheetInfo.Attributes.HasFlag(MissionAttributes.Score_TimeRemaining))
                            continue;

                        if (C.MissionConfig.TryGetValue(mission.Key, out var config))
                        {
                            config.TurninGoal = HighestTurnin;
                        }
                        amountApplied += 1;
                    }
                }
                C.SaveDebounced();

                Notify.Success($"Applied settings to: {amountApplied} missions, just for you buddy.");
                ImGui.CloseCurrentPopup();
            }


            ImGui.EndPopup();
        }
    }
}
