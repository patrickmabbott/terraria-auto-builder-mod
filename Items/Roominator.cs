using AutoBuilder.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoBuilder.Util;
using log4net;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AutoBuilder.Items
{
    public class Roominator : ModItem
    {
        double lastRefreshTime = 0;

        private string currentRoom;

        private GlobalPlacer placer;

        private List<string> availableRoomNames = new List<string>();

        private bool hasRoomBeenPlacedSinceLastCalc = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Roominator");
            Tooltip.SetDefault("Places a house room from items in your inventory");
        }

        public override void SetDefaults()
        {
            ItemUtils.SetItemDefaults(item);
        }

        public override bool AltFunctionUse(Player player)//You use this to allow the item to be right clicked
        {
            return true;
        }

        private bool RecalculateRooms(Vector2 size)
        {
            this.availableRoomNames = placer.DetermineAvailableRooms(size, DoUseThemes())
                .Select(entry => entry.Item2.Name)
                .ToList();

            if (!this.availableRoomNames.Any())
            {
                Main.NewText("Unable to build any rooms", 150, 250, 150);
                return false;
            }

            this.availableRoomNames.Sort(((name1, name2) => name1.CompareTo(name2)));

            if (currentRoom == null)
            {
                currentRoom = this.availableRoomNames[0];
            }
            else
            {
                currentRoom = this.availableRoomNames.FirstOrDefault(entry => entry.CompareTo(currentRoom) == 1) ??
                              this.availableRoomNames[0];
            }

            hasRoomBeenPlacedSinceLastCalc = false;
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (placer == null)
            {
                this.placer = new GlobalPlacer(player);
            }

            int width = ModContent.GetInstance<AutoBuilderConfig>().UseDefaultSize
                ? ModContent.GetInstance<AutoBuilderConfig>().DefaultRoomWidth : -1;
            int height = ModContent.GetInstance<AutoBuilderConfig>().UseDefaultSize
                ? ModContent.GetInstance<AutoBuilderConfig>().DefaultRoomHeight : -1;
            Vector2 size = new Vector2(width, height);

            if (player.altFunctionUse == 2)//Sets what happens on right click(special ability)
            {
                RecalculateRooms(size);
                Main.NewText($"Ready to build {currentRoom}", 150, 250, 150);
            }
            else //Sets what happens on left click(normal use)
            {
                if (this.currentRoom == null)
                {

                    Main.NewText("No room selected to build", 255, 50, 50);
                    return true;
                }

                if (hasRoomBeenPlacedSinceLastCalc)
                {
                    RecalculateRooms(size);
                }

                placer.PlaceRoom(size, currentRoom);
                hasRoomBeenPlacedSinceLastCalc = true;
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

            //    GlobalPlacer.DetermineAvailableRooms(player, new Vector2(width, height), useFurnitureSets: this.DoUseThemes());
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