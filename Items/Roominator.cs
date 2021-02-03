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

        //private PlaceableOrganizer organizer = new PlaceableOrganizer();
        //private PlaceableOrganizer organizer = new PlaceableOrganizer();
        double lastPlacementTime = 0;

        private string currentRoom;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Roominator");
            Tooltip.SetDefault("Places a house room from items in your inventory");
        }

        public override void SetDefaults()
        {
            item.damage = 36;
            item.melee = true;
            item.noMelee = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 15;
            item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 2;
            item.reuseDelay = 100;
            item.value = Item.buyPrice(0, 5, 78, 0);
            item.rare = 0;
            item.autoReuse = false;
        }

        public override bool AltFunctionUse(Player player)//You use this to allow the item to be right clicked
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)//Sets what happens on right click(special ability)
            {
                Main.NewText("whaaaaaaaa", 150, 250, 150);
            }
            else //Sets what happens on left click(normal use)
            {
                mod.Logger.Info($"Attempting to place room {currentRoom}");
                int width = ModContent.GetInstance<AutoBuilderConfig>().UseDefaultSize
                    ? ModContent.GetInstance<AutoBuilderConfig>().DefaultRoomWidth : -1;
                int height = ModContent.GetInstance<AutoBuilderConfig>().UseDefaultSize
                    ? ModContent.GetInstance<AutoBuilderConfig>().DefaultRoomHeight : -1;

                GlobalPlacer.PlaceRoom(player, new Vector2(width, height), useFurnitureSets: this.
                    DoUseThemes(), preferredRoom: currentRoom);
            }

            return true;
        }

        protected virtual bool DoUseThemes()
        {
            return false;
        }

        //public override void MeleeEffects(Player player, Rectangle hitbox)
        //{
            //if (Main.netMode != NetmodeID.SinglePlayer)
            //    return;

            //Main.NewText(text, 150, 250, 150);
            //double currentTime = DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            //if (currentTime - this.lastPlacementTime > 1.0)
            //{
            //    mod.Logger.Info("Attempting to place room");
            //    this.lastPlacementTime = currentTime;
            //    int width = ModContent.GetInstance<AutoBuilderConfig>().UseDefaultSize
            //        ? ModContent.GetInstance<AutoBuilderConfig>().DefaultRoomWidth : -1;
            //    int height = ModContent.GetInstance<AutoBuilderConfig>().UseDefaultSize
            //        ? ModContent.GetInstance<AutoBuilderConfig>().DefaultRoomHeight : -1;

            //    GlobalPlacer.PlaceRoom(player, new Vector2(width, height), useFurnitureSets: this.DoUseThemes());
            //}
        //}

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