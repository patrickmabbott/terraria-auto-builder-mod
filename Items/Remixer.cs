using System;
using System.Collections.Generic;
using System.Linq;
using AutoBuilder.Model;
using AutoBuilder.Util;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AutoBuilder.Items
{
    public class Remixer : ModItem
    {
        //Could reasonably start at enum 1 but this teaches user that they should choose a strategy with right-click before left-clicking.
        private ReplacementStrategy _replacementStrategy = ReplacementStrategy.None;
        private GlobalPlacer _placer;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Remixer");
            Tooltip.SetDefault("Scans an existing structure then replaces its blocks/walls/furniture etc...\nwith equivalent but differently themed ones");
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
            if (_placer == null)
            {
                _placer = new GlobalPlacer(player);
            }

            if (player.altFunctionUse == 2)//Sets what happens on right click(special ability)
            {
                //Loop through. When at end, go straight to the 1st valid option instead of back to none.
                if(_replacementStrategy != ReplacementStrategy.PreferredThemes)
                {
                    _replacementStrategy = _replacementStrategy.NextEnum();
                }
                else
                {
                    _replacementStrategy = ReplacementStrategy.SameTheme;
                }
                Main.NewText($"Ready to mix with {_replacementStrategy}", 150, 250, 150);
            }
            else //Sets what happens on left click(normal use)
            {

                if (_replacementStrategy == ReplacementStrategy.None)
                {
                    Main.NewText($"No replacement strategy chosen. Select one by right-clicking", 150, 250, 150);
                    return true;
                }

                if (_replacementStrategy == ReplacementStrategy.PreferredThemes &&
                    !ModContent.GetInstance<AutoBuilderConfig>().PreferredThemes.Split(',')
                        .Any(e => ThemeDefinitions.ThemesAsString().Contains(e)))
                {
                    Main.NewText($"Chosen strategy requires configuration in mod configuration menu.", 150, 250, 150);
                    return true;
                }

                BlueprintCreator creator = new BlueprintCreator();
                Vector2 lowerLeftCorner = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                lowerLeftCorner /= 16f;
                if (!BlueprintCreator.DoesPositionContainExternalTileAbs(new IntPair(lowerLeftCorner)))
                {
                    Constants.Logger.Info("Scanning a blueprint");
                    Blueprint blueprint = creator.CreateBlueprint(1);
                    if (blueprint != null)
                    {
                        Constants.Logger.Info("Starting up mixerator");
                        Mixerator mixerator = new Mixerator(blueprint, this._replacementStrategy);
                        IDictionary<TileIdentifier, TileIdentifier> replacements = mixerator.GenerateReplacements();
                        Constants.Logger.Info("Generated replacements");
                        foreach (var entry in replacements)
                        {
                            Constants.Logger.Info($"replacing {entry.Key.Name} with {entry.Value.Name}");   
                        }
                        if (replacements.Any())
                        {
                            _placer.ReplaceTiles(blueprint, creator.Referent, replacements);
                        }
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
