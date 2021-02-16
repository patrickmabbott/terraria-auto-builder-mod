using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoBuilder.json;
using AutoBuilder.Model;
using AutoBuilder.Util;
using Microsoft.Xna.Framework;
using On.Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace AutoBuilder.Items
{
    public class Identificator : ModItem
    {
        double lastRefreshTime = 0;

        private string currentRoom;

        private GlobalPlacer placer;

        private List<string> availableRoomNames = new List<string>();

        private bool hasRoomBeenPlacedSinceLastCalc = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Identificator");
            Tooltip.SetDefault("Prints out info about space under cursor");
        }

        public override void SetDefaults()
        {
            ItemUtils.SetItemDefaults(item);
        }

        public override bool AltFunctionUse(Player player)//You use this to allow the item to be right clicked
        {
            return true;
        }

        private string printTileInfo(Tile tile)
        {
            StringBuilder writer = new StringBuilder();
            writer.AppendLine($"collisionType {tile.collisionType}");
            writer.AppendLine($"type {tile.type}");
            writer.AppendLine($"wall {tile.wall}");
            writer.AppendLine($"bTileHeader {tile.bTileHeader}");
            writer.AppendLine($"bTileHeader2 {tile.bTileHeader2}");
            writer.AppendLine($"sTileHeader {tile.sTileHeader}");
            writer.AppendLine($"frameX {tile.frameX}");
            writer.AppendLine($"frameX {tile.frameY}");
            writer.AppendLine($"frameX {tile.frameNumber()}");
            writer.AppendLine($"frameX {tile.wallFrameNumber()}");
            writer.AppendLine($"frameX {tile.wallFrameX()}");
            writer.AppendLine($"frameX {tile.wallFrameY()}");
            writer.AppendLine($"liquid {tile.liquid}");
            writer.AppendLine($"bottomSlope {tile.bottomSlope()}");
            writer.AppendLine($"active {tile.active()}");
            writer.AppendLine($"blockType {tile.blockType()}");
            writer.AppendLine($"inActive {tile.inActive()}");
            writer.AppendLine($"wallColor {tile.wallColor()}");
            writer.AppendLine($"tileAlch {Main.tileAlch[tile.type]}");
            writer.AppendLine($"tileAxe {Main.tileAxe[tile.type]}");
            writer.AppendLine($"tileBrick {Main.tileBrick[tile.type]}");
            writer.AppendLine($"tileCut {Main.tileCut[tile.type]}");
            writer.AppendLine($"tileFrameImportant {Main.tileFrameImportant[tile.type]}");
            writer.AppendLine($"tileHammer {Main.tileHammer[tile.type]}");
            writer.AppendLine($"tileNoFail {Main.tileNoFail[tile.type]}");
            writer.AppendLine($"tileSolid {Main.tileSolid[tile.type]}");
            writer.AppendLine($"tileSpelunker {Main.tileSpelunker[tile.type]}");
            writer.AppendLine($"tileValue {Main.tileValue[tile.type]}");
            writer.AppendLine($"tileValue {Main.tileValue[tile.type]}");
            writer.AppendLine($"tileSpelunker {Main.tileSpelunker[tile.type]}");
            return writer.ToString();
        }

        class IntPoint
        {
            public IntPoint(int x, int y)
            {
                X = x;
                Y = y;
            }
            private int X { get; }
            private int Y { get; }

            public override string ToString()
            {
                return $"{X},{Y}";
            }
        }

        public override bool CanUseItem(Player player)
        {
            Constants.Logger.Info("Trying to set ");
            if (placer == null)
            {
                this.placer = new GlobalPlacer(player);
            }

            Constants.Logger.Info($"Got placer");

            Constants.Logger.Info($"{Main.screenPosition} {Main.mouseX}");

            Vector2 lowerLeftCorner = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
            Constants.Logger.Info($"position {lowerLeftCorner}");
            lowerLeftCorner /= 16f;
            Tile tileUnderCursor = Main.tile[(int)lowerLeftCorner.X, (int)lowerLeftCorner.Y];
            Constants.Logger.Info(printTileInfo(tileUnderCursor));
            if (tileUnderCursor != null)
            {
                TileInfo tileInfo = new TileInfo();
                tileInfo.FromTile(tileUnderCursor, new IntPair((int) lowerLeftCorner.X, (int) lowerLeftCorner.Y));

                Main.NewText($"Tile info {tileInfo}", Color.Green);
                Constants.Logger.Info($"Tile info {tileInfo}");
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