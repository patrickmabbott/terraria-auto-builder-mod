using AutoBuilder.Model;
using AutoBuilder.Util;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AutoBuilder.Items
{
    public class Replicator : ModItem
    {
        private int _curBlueprintSlot = 0;
        private GlobalPlacer _placer;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Replicator");
            Tooltip.SetDefault("Automatically identifies clicked structure and stores its layout for future pasting");
        }

        public override void SetDefaults()
        {
            ItemUtils.SetItemDefaults(item);
        }

        public override bool AltFunctionUse(Player player)//You use this to allow the item to be right clicked
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)//Sets what happens on right click(special ability)
            {
                if (BlueprintArchive.Instance.AllBlueprints.Count == 0)
                {
                    Main.NewText($"No blueprints defined", 150, 250, 150);
                    return true;
                }
                _curBlueprintSlot++;
                if (_curBlueprintSlot >= (BlueprintArchive.Instance.AllBlueprints.Count))
                {
                    _curBlueprintSlot = 0;
                }

                string blueprintName;
                if (_curBlueprintSlot < BlueprintArchive.Instance.StandardBlueprintNames.Count)
                {
                    blueprintName = BlueprintArchive.Instance.StandardBlueprintNames[_curBlueprintSlot];
                }
                else
                {
                    blueprintName =
                        BlueprintArchive.Instance.CustomBlueprintNames[
                            _curBlueprintSlot - BlueprintArchive.Instance.StandardBlueprintNames.Count];
                }
                Main.NewText($"Ready to place blueprint {blueprintName}", 150, 250, 150);
            }
            else //Sets what happens on left click(normal use)
            {
                if (_curBlueprintSlot > BlueprintArchive.Instance.AllBlueprints.Count ||
                    BlueprintArchive.Instance.CustomBlueprints[_curBlueprintSlot - BlueprintArchive.Instance.StandardBlueprints.Count] == null)
                {
                    Main.NewText($"No blueprints to place", 150, 250, 150);
                }
                Blueprint blueprint;
                if (_curBlueprintSlot < BlueprintArchive.Instance.StandardBlueprints.Count)
                {
                    blueprint = BlueprintArchive.Instance.StandardBlueprints[_curBlueprintSlot];
                }
                else
                {
                    blueprint =
                        BlueprintArchive.Instance.CustomBlueprints[
                            _curBlueprintSlot - BlueprintArchive.Instance.StandardBlueprints.Count];
                }
                if (_placer == null)
                {
                    _placer = new GlobalPlacer(player);
                }
                _placer.PlaceBlueprint(blueprint);
            }

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 5);
            recipe.AddIngredient(ItemID.Torch);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
