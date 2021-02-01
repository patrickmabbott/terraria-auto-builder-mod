using AutoBuilder.Items;
using System;
using log4net;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AutoBuilder.Items
{
    public class Roominator : ModItem
    {

        double lastPlacementTime = 0;

        public override void SetStaticDefaults()
        {
            Constants.Logger = mod.Logger;
            mod.Logger.Info("Testing info logger");
            mod.Logger.Error("Testing logger");
            Constants.Init();
            mod.Logger.Error("Post init");
            DisplayName.SetDefault("Roominator");
            Tooltip.SetDefault("Places an house room from items in your inventory");
        }

        public override void SetDefaults()
        {
            item.damage = 50; // The damage your item deals
            item.melee = true; // Whether your item is part of the melee class
            item.width = 40; // The item texture's width
            item.height = 40; // The item texture's height
            item.useTime = 20; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
            item.useAnimation = 20;
            item.reuseDelay = 1000;
            item.useAnimation = 20; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
            item.knockBack = 6; // The force of knockback of the weapon. Maximum is 20
            item.value = Item.buyPrice(gold: 1); // The value of the weapon in copper coins
            item.rare = ItemRarityID.Green; // The rarity of the weapon, from -1 to 13. You can also use ItemRarityID.TheColorRarity
            item.UseSound = SoundID.Item1; // The sound when the weapon is being used
            item.autoReuse = false; // Whether the weapon can be used more than once automatically by holding the use button
            item.crit = 6; // The critical strike chance the weapon has. The player, by default, has 4 critical strike chance
            item.useStyle = ItemUseStyleID.SwingThrow; // 1 is the useStyle
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.netMode != NetmodeID.SinglePlayer)
                return;

            double currentTime = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            if (currentTime - this.lastPlacementTime > 1.0)
            {
                mod.Logger.Info("Attempting to place room");
                this.lastPlacementTime = currentTime;
                GlobalPlacer.PlaceRoom(player, new Vector2(-1, -1));
            }
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