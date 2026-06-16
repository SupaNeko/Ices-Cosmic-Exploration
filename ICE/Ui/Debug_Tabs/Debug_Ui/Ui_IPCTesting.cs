using ECommons.ExcelServices.TerritoryEnumeration;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using ICE.Utilities.Cosmic_Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICE.Ui.Debug_Tabs.Debug_Ui
{
    internal class Ui_IPCTesting
    {
        private static int Radius = 10;
        private static int XLoc = 0;
        private static int YLoc = 0;
        private static string PandoraFeature = "";
        private static int amount = 1000;

        private static string importString = new string('\0', 2048); // Pre-allocate buffer
        private static string SwapToPreset = string.Empty;
        private static uint missionId = 0;
        private static uint baitId = 0;
        private static bool baitSwapped = false;
        private static uint MMSAmount = 20;
        private static uint MMMaxUse = 1;
        private static bool tempMM = true;


        private static string SettingChange = "";
        private static bool SettingState = false;

        public static unsafe void Draw()
        {
            ImGui.Text($"Artisan Is Busy? {P.Artisan.IsBusy()}");
            ImGui.Text($"{EzThrottler.GetRemainingTime("[Main Item(s)] Starting Main Craft")}");
            if (ImGui.Button("Artisan，制作这个"))
            {
                P.Artisan.CraftItem(36026, 1);
            }

            ImGui.SetNextItemWidth(125);
            ImGui.InputInt("半径", ref Radius);
            ImGui.SetNextItemWidth(125);
            ImGui.InputInt("X 位置", ref XLoc);
            ImGui.SetNextItemWidth(125);
            ImGui.InputInt("Y位置", ref YLoc);

            if (ImGui.Button($"测试半径"))
            {
                var agent = AgentMap.Instance();

                Utils.SetGatheringRing(agent->CurrentTerritoryId, XLoc, YLoc, Radius);
            }

            ImGui.Separator();
            ImGui.InputText("Pandora功能", ref PandoraFeature);
            if (ImGui.Button("暂停功能"))
            {
                P.Pandora.PauseFeature(PandoraFeature, amount);
            }

            ImGui.Separator();
            ImGui.Text("AutoHook");
            ImGui.SetNextItemWidth(150);
            ImGui.InputText("预设字符串", ref importString, 2048);
            if (ImGui.Button("进口"))
            {
                P.AutoHook.ImportAndSelectPreset(importString);
                importString = string.Empty;
            }
            ImGui.SetNextItemWidth(150);
            ImGui.InputText("交换到预设", ref SwapToPreset);
            if (ImGui.Button("交换"))
            {
                P.AutoHook.SetPreset(SwapToPreset);
            }
            if (ImGui.Button("应用临时"))
            {
                P.AutoHook.CreateAndSelectAnonymousPreset(importString);
            }
            ImGui.SetNextItemWidth(200);
            ImGui.InputUInt("选择要导入的任务", ref missionId);
            ImGui.InputUInt("Bait ID", ref baitId);
            if (ImGui.Button("Swap to诱饵"))
            {
                 SwapBait(baitId);
            }
            if (ImGui.Button("交换诱饵...简单"))
            {
                if (CosmicHelper.CurrentBait() == 0)
                {
                    IceLogging.Debug("Bait is not currently equipped");
                }

                P.AutoHook.SwapBaitById(baitId);
            }
            if (ImGui.Button("愚蠢的测试"))
            {
                if (CosmicHelper.CurrentBait() == 0)
                {
                    IceLogging.Debug($"No bait is equipped");
                }
                else if (CosmicHelper.CurrentBait == null)
                {
                    IceLogging.Debug("Bait is null... aka not in the middle of a mission");
                }
                else
                {
                    IceLogging.Debug($"Current bait: {CosmicHelper.CurrentBait}");
                }
            }

            if (ImGui.Button("启用AutoHook"))
            {
                P.AutoHook.Ah_State(true);
            }
            if (ImGui.Button("DisableAutohook"))
            {
                P.AutoHook.Ah_State(false);
            }

            ImGui.Separator();
            ImGui.Text($"Is ICE Running? | {P.IceIpc.IsRunning()}");
            if (ImGui.Button("仅通过IPC执行任务"))
            {
                HashSet<uint> missionListIds = new() { 1, 3, 4, 7, 9, 11 };
                P.IceIpc.OnlyMissions(missionListIds);
            }
            if (ImGui.Button("更改为抽奖"))
            {
                SchedulerMain.State = IceState.Gambling;
            }

            ImGui.Separator();

            ImGui.SetNextItemWidth(150);
            ImGui.InputText("设置名称", ref SettingChange);
            ImGui.Checkbox("设置布尔", ref SettingState);

            if (ImGui.Button("切换设置"))
            {
                P.IceIpc.ChangeSetting(SettingChange, SettingState);
            }
            if (ImGui.Button("设置临时设置"))
            {
                P.Artisan.ChangeSolver(37084, "仅进度求解器", true);
            }
            if (ImGui.Button("设置拉斐尔解算器"))
            {
                P.Artisan.ChangeSolver(37084, "拉斐尔配方求解器", true);
            }
            if (ImGui.Button("设置当前任务为拉斐尔"))
            {
                if (CosmicHelper.CurrentLunarMission != 0)
                {
                    foreach (var craftItem in CosmicHelper.CurrentMissionInfo.Crafts_Main)
                    {
                        P.Artisan.ChangeSolver(craftItem.Value.RecipeId, "拉斐尔配方求解器", true);
                    }
                    foreach (var preCraft in CosmicHelper.CurrentMissionInfo.Crafts_Pre)
                    {
                        P.Artisan.ChangeSolver(preCraft.Value.RecipeId, "拉斐尔配方求解器", true);
                    }
                }
            }
            if (ImGui.Button("设置当前任务为进度"))
            {
                if (CosmicHelper.CurrentLunarMission != 0)
                {
                    foreach (var craftItem in CosmicHelper.CurrentMissionInfo.Crafts_Main)
                    {
                        P.Artisan.ChangeSolver(craftItem.Value.RecipeId, "仅进度求解器", true);
                    }
                    foreach (var preCraft in CosmicHelper.CurrentMissionInfo.Crafts_Pre)
                    {
                        P.Artisan.ChangeSolver(preCraft.Value.RecipeId, "仅进度求解器", true);
                    }
                }
            }
            ImGui.DragUInt("MM 步骤使用", ref MMSAmount, 1, 0, 20);
            ImGui.DragUInt("MM 配方用法", ref MMMaxUse, 1, 0, 3);
            ImGui.Checkbox("设置MM温度", ref tempMM);
            if (ImGui.Button("设置奇迹解算器"))
            {
                P.Artisan.ChangeStandardMinimumStepsBeforeMiracle(MMSAmount, tempMM);
                P.Artisan.ChangeStandardMaxMaterialMiracleUses(MMMaxUse, tempMM);
            }
            ImGui.SameLine();
            if (ImGui.Button("恢复温度MM"))
            {
                P.Artisan.SetTempStandardMinimumStepsBeforeMiracleBackToNormal();
                P.Artisan.SetTempStandardMaxMaterialMiracleUsesBackToNormal();
            }

            if (ImGui.Button("恢复正常"))
            {
                if (CosmicHelper.CurrentLunarMission != 0)
                {
                    foreach (var craftItem in CosmicHelper.CurrentMissionInfo.Crafts_Main)
                    {
                        P.Artisan.SetTempSolverBackToNormal(craftItem.Value.RecipeId);
                    }
                    foreach (var preCraft in CosmicHelper.CurrentMissionInfo.Crafts_Pre)
                    {
                        P.Artisan.SetTempSolverBackToNormal(preCraft.Value.RecipeId);
                    }
                }
            }
            if (ImGui.Button("禁用耐力"))
            {
                P.Artisan.SetEnduranceStatus(false);
            }
            if (ImGui.Button("测试Toast"))
            {
                string message = "[I.C.E.] You didn't read the little warning in the mission setup\n" +
                    "你需要更新 autohook 才能在 Auxesia 上钓鱼。请切换到测试版本";
                Svc.Chat.Print(new()
                {
                    Type = Dalamud.Game.Text.XivChatType.ErrorMessage,
                    Message = message,
                });
                Svc.Toasts.ShowNormal($"{message}");
            }
            if (ImGui.Button("测试魅力"))
            {
                P.GlamourIpc.SetClownHead();
            }
            if (ImGui.Button("测试帽子"))
            {
                P.GlamourIpc.SetHat();
            }
            if (ImGui.Button("测试遮阳板"))
            {
                P.GlamourIpc.SetVisor();
            }
        }

        private static void SwapBait(uint baitId)
        {
            _ = Task.Run(async () =>
            {
                baitSwapped = await TaskSwapBait(baitId);
            });

            _ = Task.Run(async () =>
            {
                await P.AutoHook.SwapBaitById(baitId);
            });
        }

        private static async Task<bool> TaskSwapBait(uint bait)
        {
            return await P.AutoHook.SwapBaitById(bait);
        }
    }
}
