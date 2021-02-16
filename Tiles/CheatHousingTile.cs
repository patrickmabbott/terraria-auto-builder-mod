using Terraria.Enums;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.ObjectData;

namespace AutoBuilder.Tiles
{
    class CheatHousingTile : ModTile
    {
        public override void SetDefaults()
            {
                TileObjectData.newTile.CopyFrom(TileObjectData.StyleTorch);
                Main.tileFrameImportant[Type] = false;
                Main.tileNoAttach[Type] = false;
                Main.tileLavaDeath[Type] = false;
                TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
                TileObjectData.newTile.CoordinateHeights = new[] { 16,16,16 };
                TileObjectData.newTile.Direction = TileObjectDirection.PlaceLeft;
                TileObjectData.newTile.StyleWrapLimit = 2; //not really necessary but allows me to add more subtypes of chairs below the example chair texture
                TileObjectData.newTile.StyleMultiplier = 2; //same as above
                TileObjectData.newTile.StyleHorizontal = true;
                TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
                TileObjectData.newAlternate.Direction = TileObjectDirection.PlaceRight; //allows me to place example chairs facing the same way as the player
                TileObjectData.addTile(Type);
                AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
                AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
                AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
                ModTranslation name = CreateMapEntryName();
                name.SetDefault("CheatHousingTile");
                disableSmartCursor = true;
            }
    }
    }