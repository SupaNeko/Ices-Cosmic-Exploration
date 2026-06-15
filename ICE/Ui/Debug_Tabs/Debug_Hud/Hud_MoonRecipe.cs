using static ECommons.UIHelpers.AddonMasterImplementations.AddonMaster;

namespace ICE.Ui.Debug_Tabs.Debug_Hud
{
    internal class Hud_MoonRecipe
    {
        public static void Draw()
        {
            if (GenericHelpers.TryGetAddonMaster<WKSRecipeNotebook>("WKSRecipeNotebook", out var x) && x.IsAddonReady)
            {
                ImGui.Text(x.SelectedCraftingItem);

                if (ImGui.Button("填写NQ"))
                {
                    x.NQItemInput();
                }
                ImGui.SameLine();

                if (ImGui.Button("填写HQ"))
                {
                    x.HQItemInput();
                }
                ImGui.SameLine();

                if (ImGui.Button("两者都填写"))
                {
                    x.NQItemInput();
                    x.HQItemInput();
                }
                ImGui.SameLine();

                if (ImGui.Button("合成"))
                {
                    x.Synthesize();
                }

                foreach (var m in x.CraftingItems)
                {
                    if (ImGui.Button($"Select ###Select + {m.Name}"))
                    {
                        m.Select();
                    }
                    ImGui.SameLine();
                    ImGui.Text($"{m.Name}");
                }
            }
            else
            {
                ImGui.Text("等待“WKSRecipeNotebook”可见");
            }
        }
    }
}
