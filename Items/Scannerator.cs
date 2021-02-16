using AutoBuilder.Model;
using AutoBuilder.Util;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AutoBuilder.Items
{
    public class Scannerator : ModItem
    {
        private int curBlueprintSlot = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scannerator");
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
                curBlueprintSlot++;
                if (curBlueprintSlot > BlueprintArchive.Instance.CustomBlueprints.Count || curBlueprintSlot >= BlueprintArchive.Instance.CustomBlueprintNames.Count)
                {
                    curBlueprintSlot = 0;
                }
                Main.NewText($"Ready to store blueprint {BlueprintArchive.Instance.CustomBlueprintNames[curBlueprintSlot]}", 150, 250, 150);
            }
            else //Sets what happens on left click(normal use)
            {
                BlueprintCreator creator = new BlueprintCreator();
                Vector2 lowerLeftCorner = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                lowerLeftCorner /= 16f;
                if (!BlueprintCreator.DoesPositionContainExternalTileAbs(new IntPair(lowerLeftCorner)))
                {
                    Blueprint blueprint = creator.CreateBlueprint(curBlueprintSlot);
                    if (blueprint != null)
                    {
                        BlueprintArchive.Instance.SetCustomBlueprint(curBlueprintSlot, blueprint);
                    }
                }
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
