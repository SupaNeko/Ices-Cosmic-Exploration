using Dalamud.Interface;
using ICE.Utilities.Cosmic_Helper;
using ICE.Utilities.ImGuiTools;

namespace ICE.Ui.MainUi.Settings
{
    internal class Priority_Settings
    {
        public static void Draw()
        {
            if (ImGui.BeginTabBar("任务优先级设置"))
            {
                if (ImGui.BeginTabItem("任务优先顺序"))
                {
                    MissionTypeOrderUi();

                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("临时：类型订单"))
                {
                    TypePriorityUi();

                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("临时：职业订单"))
                {
                    JobPriorityUi();

                    ImGui.EndTabItem();
                }

                ImGui.EndTabBar();
            }
        }

        private static ImGuiEx.RealtimeDragDrop<ProvisionalTypes>? _dragDrop_ProvisionalType;

        private static void TypePriorityUi()
        {
            _dragDrop_ProvisionalType ??= new ImGuiEx.RealtimeDragDrop<ProvisionalTypes>(
                "ProvisionalTypeDragDrop",
                (info) => $"{info}_{info.GetHashCode()}",
                smallButton: false
            );

            _dragDrop_ProvisionalType.Begin();

            if (ImGui.BeginTable("类型优先级表", 3, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.RowBg | ImGuiTableFlags.Borders))
            {
                ImGui.TableSetupColumn("重新订购");
                ImGui.TableSetupColumn("图标");
                ImGui.TableSetupColumn("类型");

                ImGui.TableHeadersRow();

                for (int i = 0; i < C.MissionPrio.Count; i++)
                {
                    ImGui.PushID(i);
                    var entry = C.MissionPrio[i];

                    ImGui.TableNextRow();
                    _dragDrop_ProvisionalType.NextRow();
                    _dragDrop_ProvisionalType.SetRowColor(entry);

                    ImGui.TableSetColumnIndex(0);
                    _dragDrop_ProvisionalType.DrawButtonDummy(entry, C.MissionPrio, i);

                    ImGui.TableNextColumn();
                    ImGui.AlignTextToFramePadding();
                    FontAwesomeIcon icon = entry switch
                    {
                        ProvisionalTypes.ProvisionalTimed => FontAwesomeIcon.Clock,
                        ProvisionalTypes.ProvisionalSequential => FontAwesomeIcon.ListOl,
                        ProvisionalTypes.ProvisionalWeather => FontAwesomeIcon.Cloud,
                        _ => FontAwesomeIcon.Question,
                    };

                    ImGuiEx.Icon(icon);

                    ImGui.TableNextColumn();
                    ImGui.AlignTextToFramePadding();
                    string type = entry switch
                    {
                        ProvisionalTypes.ProvisionalTimed => "定时",
                        ProvisionalTypes.ProvisionalSequential => "Sequence",
                        ProvisionalTypes.ProvisionalWeather => "天气",
                        _ => entry.ToString()
                    };
                    ImGui.Text($"{type}");

                    ImGui.PopID();
                }

                ImGui.EndTable();
            }

            _dragDrop_ProvisionalType.End();
        }

        private static ImGuiEx.RealtimeDragDrop<MissionTypes>? _dragDrop_MissionType;

        private static void MissionTypeOrderUi()
        {
            ImGui.Text("任务搜索优先级");
            ImGui_Ice.IconWithTooltip(
                FontAwesomeIcon.InfoCircle, 
                "Order你想要执行的操作。它将从顶部开始职业down.\n" +
                "所以如果你有红色警戒->无人机搜索，如果红色警报不可用，它会继续使用无人机箱（如果可以的话）");

            _dragDrop_MissionType ??= new ImGuiEx.RealtimeDragDrop<MissionTypes>(
                "MissionTypeDragDrop",
                (info) => $"{info}_{info.GetHashCode()}",
                smallButton: false
            );

            _dragDrop_MissionType.Begin();

            if (ImGui.BeginTable("任务类型表", 3, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.RowBg | ImGuiTableFlags.Borders))
            {
                ImGui.TableSetupColumn("重新订购");
                ImGui.TableSetupColumn("图标");
                ImGui.TableSetupColumn("类型");

                ImGui.TableHeadersRow();

                for (int i = 0; i < C.MissionTypePrio.Count; i++)
                {
                    ImGui.PushID(i);
                    var entry = C.MissionTypePrio[i];

                    ImGui.TableNextRow();
                    _dragDrop_MissionType.NextRow();
                    _dragDrop_MissionType.SetRowColor(entry);

                    ImGui.TableSetColumnIndex(0);
                    _dragDrop_MissionType.DrawButtonDummy(entry, C.MissionTypePrio, i);

                    ImGui.TableNextColumn();
                    ImGui.AlignTextToFramePadding();
                    FontAwesomeIcon icon = entry switch
                    {
                        MissionTypes.DroneSearch => FontAwesomeIcon.Satellite,
                        MissionTypes.Critical => FontAwesomeIcon.Bell,
                        MissionTypes.Provisional => FontAwesomeIcon.HourglassHalf,
                        MissionTypes.Standard => FontAwesomeIcon.Star,
                        MissionTypes.ToolMastery => FontAwesomeIcon.Meteor,
                        _ => FontAwesomeIcon.Question
                    };
                    ImGuiEx.Icon(icon);

                    ImGui.TableNextColumn();
                    ImGui.AlignTextToFramePadding();
                    string name = entry switch
                    {
                        MissionTypes.DroneSearch => "无人机搜索",
                        MissionTypes.Critical => "红色警戒",
                        MissionTypes.Provisional => "Provisional Missions [Weather/Timed/Sequence]",
                        MissionTypes.Standard => "Standard Missions [A->D]",
                        _ => $"{entry}"
                    };
                    ImGui.Text($"{name}");
                    if (entry == MissionTypes.DroneSearch && !C.Cosmodrone_Run)
                    {
                        ImGui.SameLine();
                        ImGui_Ice.IconWithTooltip(FontAwesomeIcon.ExclamationTriangle,
                            "查找无人机位置已关闭，因此我们将忽略它。如果您想运行此功能，请启用");
                    }

                    ImGui.PopID();
                }

                ImGui.EndTable();
            }

            _dragDrop_MissionType.End();
        }

        private static ImGuiEx.RealtimeDragDrop<uint>? _dragDrop_JobPrio;

        private static void JobPriorityUi()
        {
            ImGui.Text("临时职业优先级");
            ImGui_Ice.IconWithTooltip(FontAwesomeIcon.InfoCircle,
                "如果选择了多个并且启用了执行多个类的选项，则您想要执行临时任务的顺序");

            bool provisionalAllJobs = C.GrindAllProvisionals;
            if (ImGui_Ice.SliderButton("##Provisional_AllJobsToggle", "允许所有临时职业", ref provisionalAllJobs))
            {
                C.GrindAllProvisionals = provisionalAllJobs;
                C.Save();
            }

            _dragDrop_JobPrio ??= new ImGuiEx.RealtimeDragDrop<uint>(
                "JobPrioDragDrop",
                (info) => ($"{info}_{info.GetHashCode()}"),
                smallButton: false
            );

            _dragDrop_JobPrio.Begin();

            if (ImGui.BeginTable("作业优先顺序", 3, ImGuiTableFlags.SizingFixedFit | ImGuiTableFlags.RowBg | ImGuiTableFlags.Borders))
            {
                ImGui.TableSetupColumn("重新订购");
                ImGui.TableSetupColumn("图标");
                ImGui.TableSetupColumn("类型");

                ImGui.TableHeadersRow();

                for (int i = 0; i < C.JobPrio.Count(); i++)
                {
                    ImGui.PushID(i);

                    var entry = C.JobPrio[i];
                    ImGui.TableNextRow();
                    _dragDrop_JobPrio.NextRow();
                    _dragDrop_JobPrio.SetRowColor(entry);

                    ImGui.TableSetColumnIndex(0);
                    _dragDrop_JobPrio.DrawButtonDummy(entry, C.JobPrio, i);

                    ImGui.TableNextColumn();
                    if (CosmicHelper.ClassInfoDict.TryGetValue(entry, out var icon))
                    {
                        ImGui.Image(icon.JobIcon.GetWrapOrEmpty().Handle, new(24, 24));
                    }

                    ImGui.TableNextColumn();
                    ImGui.AlignTextToFramePadding();
                    ImGui.Text($"{GetJobName(entry)}");

                    ImGui.PopID();
                }

                ImGui.EndTable();
            }

            _dragDrop_JobPrio.End();
        }

        // Job name helper
        private static string GetJobName(uint jobId)
        {
            return jobId switch
            {
                8 => "Carpenter",
                9 => "Blacksmith",
                10 => "Armorer",
                11 => "Goldsmith",
                12 => "Leatherworker",
                13 => "Weaver",
                14 => "Alchemist",
                15 => "Culinarian",
                16 => "Miner",
                17 => "Botanist",
                18 => "Fisher",
                _ => "未知作业"
            };
        }
    }
}