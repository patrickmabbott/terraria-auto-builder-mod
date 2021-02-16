using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using AutoBuilder.json;
using AutoBuilder.Model;
using AutoBuilder.Util;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AutoBuilder.Items
{
    public class GlobalPlacer
    {

        public GlobalPlacer(Player player)
        {
            this.player = player;
            this.organizer = new PlaceableOrganizer(player);
        }

        private PlaceableOrganizer organizer;

        private Player player;

        private IList<Tuple<ThemedPlaceableSet, RoomSpecification>> _roomSets;

        public IList<Tuple<ThemedPlaceableSet, RoomSpecification>> RoomSets { get; }

        private Dictionary<TileIdentifier, TileIdentifier> _replacements =
            new Dictionary<TileIdentifier, TileIdentifier>();

        private static void ConsumeItem(Item item, int amountToConsume = 1)
        {
            if (ModContent.GetInstance<AutoBuilderConfig>().DoConsumeResources)
            {
                item.stack -= Math.Min(amountToConsume, item.stack);
            }
        }

        private void ConsumeItem(string itemName, int amountToConsume = 1)
        {
            Item item = player.inventory.FirstOrDefault(entry => entry.Name == itemName);
            if (item != null)
            {
                ConsumeItem(item, amountToConsume);
            }
            else
            {
                Constants.Logger.Warn($"Attempted to consume item {itemName} but couldn't find it");
            }
        }

        public void PlaceTile(Vector2 position, TileInfo tileInfo)
        {
            if (tileInfo.HasWall)
            {
                Constants.Logger.Info($"Placing wall with id {tileInfo.WallId} at position {position}");
                WorldGen.PlaceWall((int)position.X, (int)position.Y, tileInfo.WallId, true);
            }

            if(tileInfo.IsBlock)
            {
                Constants.Logger.Info($"Placing tileInfo with id {tileInfo.TileId} and collision {tileInfo.CollisionType} and style {tileInfo.Style} at position {position}");
                WorldGen.PlaceTile((int)position.X, (int)position.Y, tileInfo.TileId, style: Math.Max(tileInfo.Style, 0), plr : tileInfo.Alternate);
            }
        }

        public void PlaceObject(Vector2 position, TileInfo tile)
        {
            if (tile.IsAnchorTile)
            {
                Constants.Logger.Info($"Placing object with id {tile.TileId} and style {tile.Style} at position {position}");
                WorldGen.PlaceObject((int)position.X, (int)position.Y, tile.TileId, style: Math.Max(tile.Style, 0), alternate: tile.Alternate);
            }
        }

        public void PlaceFurniturePiece(Vector2 position, Placeable placeable)
        {
            Constants.Logger.Info($"Placing furniture {placeable.Name} {placeable.TileId} {placeable.Style} at (" +
                                  position.X + "," + position.Y + ")");
            WorldGen.PlaceTile((int)position.X, (int)position.Y, placeable.TileId, style: placeable.Style);
            ConsumeItem(placeable.Name);
        }

        public void PlaceBlueprint(Blueprint blueprint, ReplacementStrategy replacementStrategy = ReplacementStrategy.None)
        {

            Mixerator mixerator = new Mixerator(blueprint, replacementStrategy);

            Vector2 lowerLeftCorner = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
            lowerLeftCorner /= 16f;
            //Do walls and blocks first since furniture/lights etc... need attachment pts.
            foreach (var info in blueprint.Tiles)
            {
                Vector2 position = new Vector2(info.Position.X + lowerLeftCorner.X, lowerLeftCorner.Y - info.Position.Y);
                PlaceTile(position, info);
            }

            foreach (var info in blueprint.Tiles)
            {
                if (info.IsObject || info.IsDoor)
                {
                    Vector2 position = new Vector2(info.Position.X + lowerLeftCorner.X, lowerLeftCorner.Y - info.Position.Y);
                    PlaceObject(position, info);
                }
                //This part doesn't matter what's in the space, including no walls, blocks, or objects.
                //We still need stuff like wires and actuators.
                Tile tile = Main.tile[info.Position.X + (int)lowerLeftCorner.X, (int)lowerLeftCorner.Y - info.Position.Y];
                info.ToTile(tile);
            }
        }

        /**
         * Replace tiles based upon the provided replacements map.
         * @param referent The starting point of the blueprint. All tile coordinates as assumed relative to this.
         */
        public void ReplaceTiles(Blueprint blueprint, IntPair referent, IDictionary<TileIdentifier, TileIdentifier> replacements)
        {
            foreach (TileInfo tile in blueprint.Tiles)
            {
                IntPair position = new IntPair(referent.X + tile.Position.X, referent.Y - tile.Position.Y);
                Vector2 vec = new Vector2(position.X, position.Y);

                //First, determine if the wall changed.
                TileIdentifier wallIdentifier = new TileIdentifier(tile.WallId, tile.Style, true, tile.WallName);
                TileIdentifier tileIdentifier = new TileIdentifier(tile.TileId, tile.Style, false, tile.TileName);

                TileIdentifier wallReplacement;
                replacements.TryGetValue(wallIdentifier, out wallReplacement);
                TileIdentifier tileReplacement;
                replacements.TryGetValue(tileIdentifier, out tileReplacement);

                if (wallReplacement == null && tileReplacement == null)
                {
                    //If neither are replaced, skip this tile.
                    Constants.Logger.Info($"No tile to replace at {position}");
                    continue;
                }
                else
                {
                    if (wallReplacement != null)
                    {
                        tile.WallId = wallReplacement.TileId;
                    }

                    if (tileReplacement != null)
                    {
                        tile.TileId = tileReplacement.TileId;
                    }
                }

                if (!tile.HasNoTile)
                {
                    Constants.Logger.Info($"Killing tile at {position}");
                    WorldGen.KillTile(position.X, position.Y);
                }

                if (tile.HasWall)
                {
                    Constants.Logger.Info($"Killing wall at {position}");
                    WorldGen.KillWall(position.X, position.Y);
                }

                PlaceTile(vec, tile);

                if (tile.IsObject || tile.IsDoor)
                {
                    PlaceObject(vec, tile);
                }

                Tile newTile = Main.tile[position.X, position.Y];
                tile.ToTile(newTile);
            }
        }

        public void PlaceWall(Vector2 position, int tileId)
        {
            WorldGen.PlaceWall((int)position.X, (int)position.Y, tileId);
            //This would probably work. But, I don't have a way of testing it so making this singleplayer-only for now.
            //if (Main.netMode == NetmodeID.Server)
            //    NetMessage.SendTileSquare(-1, (int)position.X, yPosition, 1);
        }

        public void PlaceBlock(Vector2 position, int tileId)
        {
            WorldGen.PlaceTile((int)position.X, (int)position.Y, tileId);
        }


        public static bool IsSpaceClear(int leftX, int lowerY, int sizeX, int sizeY, bool[,] occupiedSpaces)
        {
            for (int x = leftX; x <= leftX + sizeX; x++)
            {
                for (int y = lowerY; y <= lowerY + sizeY; y++)
                {
                    if (occupiedSpaces[x, y])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool SetOccupied(int leftX, int lowerY, int sizeX, int sizeY, bool[,] occupiedSpaces)
        {
            for (int x = leftX; x <= leftX + sizeX; x++)
            {
                for (int y = lowerY; y <= lowerY + sizeY; y++)
                {
                    occupiedSpaces[x, y] = true;
                }
            }

            return true;
        }

        //Now, for the furniture. We need to make sure that furniture doesn't overlap and that it all fits inside the perimeter.
        //That's where the occupied array comes in.

        private bool PlaceOnCeiling(Vector2 roomSize, Placeable placeable, bool[,] isOccupied)
        {
            //Start from its preferred placement and go to the right. If you don't find an open space that way, go left instead.
            int startingX = (int)roomSize.X / 2;

            int lowEnd = (int)roomSize.Y - placeable.CatalogEntry.Height - 1;

            int unoccupiedXPosition = -1;
            for (int x = startingX; x < roomSize.X - 1 - placeable.CatalogEntry.Width; x++)
            {
                if (IsSpaceClear(x, lowEnd, placeable.CatalogEntry.Width, placeable.CatalogEntry.Height, isOccupied))
                {
                    unoccupiedXPosition = x;
                }
            }

            //Otherwise, go the other way.
            if (unoccupiedXPosition == -1)
            {
                for (int x = startingX; x > 1 + placeable.CatalogEntry.Width / 2; x--)
                {
                    if (IsSpaceClear(x, lowEnd, placeable.CatalogEntry.Width, placeable.CatalogEntry.Height,
                        isOccupied))
                    {
                        unoccupiedXPosition = x;
                    }
                }
            }

            if (unoccupiedXPosition == -1)
            {
                //Couldn't place this object. Move on.
                Constants.Logger.Warn("Couldn't place item" + placeable.Name);
                return false;
            }
            else
            {
                Vector2 lowerLeftCorner = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                lowerLeftCorner /= 16f;
                PlaceFurniturePiece(lowerLeftCorner + new Vector2(unoccupiedXPosition, 1 - (int)roomSize.Y),
                    placeable);
                SetOccupied(unoccupiedXPosition, lowEnd,
                    placeable.CatalogEntry.Width + 1, placeable.CatalogEntry.Height, isOccupied);
                return true;
            }
        }

        private bool PlaceOnFloor(Vector2 roomSize, Placeable placeable, bool[,] isOccupied)
        {
            //Start from its preferred placement and go to the right. If you don't find an open space that way, go left instead.
            int startingX = (int)roomSize.X / 2;
            int onOccupiedYPosition = 1;

            int unoccupiedXPosition = -1;
            for (int x = startingX; x < roomSize.X - 1 - placeable.CatalogEntry.Width; x++)
            {
                if (IsSpaceClear(x, onOccupiedYPosition, placeable.CatalogEntry.Width, placeable.CatalogEntry.Height, isOccupied))
                {
                    unoccupiedXPosition = x;
                }
            }

            //Otherwise, go the other way.
            if (unoccupiedXPosition == -1)
            {
                for (int x = startingX; x > 1 + placeable.CatalogEntry.Width / 1; x--)
                {
                    if (IsSpaceClear(x, onOccupiedYPosition, placeable.CatalogEntry.Width, placeable.CatalogEntry.Height, isOccupied))
                    {
                        unoccupiedXPosition = x;
                    }
                }
            }

            if (unoccupiedXPosition == -1)
            {
                onOccupiedYPosition = 7;

                for (int x = startingX; x < roomSize.X - 1 - placeable.CatalogEntry.Width; x++)
                {
                    if (IsSpaceClear(x, onOccupiedYPosition, placeable.CatalogEntry.Width, placeable.CatalogEntry.Height, isOccupied))
                    {
                        unoccupiedXPosition = x;
                    }
                }
                //Otherwise, go the other way.
                if (unoccupiedXPosition == -1)
                {
                    for (int x = startingX; x > 1 + placeable.CatalogEntry.Width / 1; x--)
                    {
                        if (IsSpaceClear(x, onOccupiedYPosition, placeable.CatalogEntry.Width, placeable.CatalogEntry.Height, isOccupied))
                        {
                            unoccupiedXPosition = x;
                        }
                    }
                }
            }

            if (unoccupiedXPosition == -1)
            {
                //Couldn't place this object. Move on.
                Constants.Logger.Warn("Couldn't place item" + placeable.Name);
                return false;
            }
            else
            {
                Vector2 lowerLeftCorner = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                lowerLeftCorner /= 16f;
                PlaceFurniturePiece(lowerLeftCorner + new Vector2(unoccupiedXPosition, -1), placeable);
                SetOccupied(unoccupiedXPosition, onOccupiedYPosition,
                    placeable.CatalogEntry.Width + 1, placeable.CatalogEntry.Height, isOccupied);
                return true;
            }
        }

        private bool PlaceOnWall(Vector2 roomSize, int wallStartHeight, Placeable placeable, bool[,] isOccupied)
        {
            //Start from its preferred placement and go to the right. If you don't find an open space that way, go left instead.
            int startingX = (int)roomSize.X / 2;

            int unoccupiedXPosition = -1;
            int unoccupiedYPosition = -1;

            for (int y = wallStartHeight; y <= roomSize.Y - 6; y += 4)
            {
                for (int x = startingX; x < roomSize.X - 1 - placeable.CatalogEntry.Width; x++)
                {
                    if (IsSpaceClear(x, y, placeable.CatalogEntry.Width, placeable.CatalogEntry.Height, isOccupied))
                    {
                        unoccupiedXPosition = x;
                        unoccupiedYPosition = y;
                    }
                }

                if (unoccupiedXPosition == -1)
                {
                    //Otherwise, go the other way.
                    for (int x = startingX; x > 1 + placeable.CatalogEntry.Width / 2; x--)
                    {
                        if (IsSpaceClear(x, y, placeable.CatalogEntry.Width, placeable.CatalogEntry.Height, isOccupied))
                        {
                            unoccupiedXPosition = x;
                            unoccupiedYPosition = y;
                        }
                    }
                }

            }


            if (unoccupiedXPosition == -1)
            {
                //Couldn't place this object. Move on.
                Constants.Logger.Warn("Couldn't place item" + placeable.Name);
                return false;
            }
            else
            {
                Vector2 lowerLeftCorner = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
                lowerLeftCorner /= 16f;
                PlaceFurniturePiece(lowerLeftCorner + new Vector2(unoccupiedXPosition, 
                        -unoccupiedYPosition - placeable.CatalogEntry.Height / 2),
                    placeable);
                SetOccupied(unoccupiedXPosition, unoccupiedYPosition,
                    placeable.CatalogEntry.Width + 1, placeable.CatalogEntry.Height, isOccupied);
                return true;
            }
        }

        public bool PlaceBox(ThemedPlaceableSet foundSet, Vector2 size, bool[,] occupied)
        {
            Vector2 lowerLeftCorner = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
            Placeable block = foundSet.Blocks.First();
            Placeable wall = foundSet.Walls.First();

            //floor
            for (int xRelative = 0; xRelative <= size.X; xRelative++)
            {
                occupied[xRelative, 0] = true;
                PlaceBlock(lowerLeftCorner + new Vector2(xRelative, 0), block.TileId);
            }
            //2 because top and bottom, left and rt. -5 for two 3-high doors and the sidewalls each share 2 blocks already counted in floor/ceiling.
            ConsumeItem(block.Name, (int)((size.X + size.Y - 5) * 2));

            //Left side
            //Starts at 3 to leave room for a 3-high door
            for (int yRelative = 4; yRelative < size.Y; yRelative++)
            {
                PlaceBlock(lowerLeftCorner + new Vector2(0, -yRelative), foundSet.Blocks.First().TileId);
                occupied[0, yRelative] = true;
            }

            //Left door
            WorldGen.PlaceTile((int)lowerLeftCorner.X, (int)lowerLeftCorner.Y - 1, TileID.ClosedDoor, style: foundSet.Doors.First().Style);
            occupied[0, 1] = true;
            occupied[0, 2] = true;
            occupied[0, 3] = true;
            occupied[1, 1] = true;
            occupied[1, 2] = true;
            occupied[1, 3] = true;

            //Ceiling
            for (int xRelative = 0; xRelative <= size.X; xRelative++)
            {
                PlaceBlock(lowerLeftCorner + new Vector2(xRelative, -size.Y), foundSet.Blocks.First().TileId);
            }

            //Right side
            for (int yRelative = 4; yRelative < size.Y; yRelative++)
            {
                PlaceBlock(lowerLeftCorner + new Vector2(size.X, -yRelative), foundSet.Blocks.First().TileId);
            }

            ConsumeItem(block.Name, (int)((size.X + size.Y - 5) * 2));

            //Right door
            WorldGen.PlaceTile((int)lowerLeftCorner.X + (int)size.X, (int)lowerLeftCorner.Y - 1, TileID.ClosedDoor, style: foundSet.Doors.First().Style);
            occupied[(int)size.X, 1] = true;
            occupied[(int)size.X, 2] = true;
            occupied[(int)size.X, 3] = true;
            occupied[(int)size.X - 1, 1] = true;
            occupied[(int)size.X - 1, 2] = true;
            occupied[(int)size.X - 1, 3] = true;


            //Walls
            for (int xRelative = 1; xRelative < size.X; xRelative++)
            {
                for (int yRelative = 1; yRelative < size.Y; yRelative++)
                {
                    PlaceWall(lowerLeftCorner + new Vector2(xRelative, -yRelative), foundSet.Walls.First().TileId);
                }
            }
            return true;
        }

        public bool PlaceRoom(Vector2 size, string roomToPlace)
        {
            RoomSpecification foundRoom = this._roomSets.First(entry => entry.Item2.Name == roomToPlace)?.Item2;
            ThemedPlaceableSet foundSet = this._roomSets.First(entry => entry.Item2.Name == roomToPlace)?.Item1;

            if (foundRoom == null || foundSet == null)
            {
                return false;
            }

            if (size.X < 1 || size.Y < 1)
            {
                size = new Vector2(foundRoom.Width, foundRoom.Height);
            }

            Vector2 lowerLeftCorner = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
            Main.PlaySound(SoundID.Item14, (int)lowerLeftCorner.X, (int)lowerLeftCorner.Y);

            lowerLeftCorner /= 16f;
            //Firstly, place the perimeter of the room.
            //Treating y as if up was positive for ease of reasoning about the space. This will be inverted further down.

            //Will keep track of which "pixels" or whatever the game calls it, are occupied.
            bool[,] occupied = new bool[100, 100];

            for (int xRelative = 0; xRelative < size.X; xRelative++)
            {
                for (int yRelative = 0; yRelative < size.Y; yRelative++)
                {
                    occupied[xRelative, yRelative] = false;
                }
            }

            if (!PlaceBox(foundSet, size, occupied))
            {
                return false;
            }

            PlaceableCatalogEntry catEntry = new PlaceableCatalogEntry();
            catEntry.PlacementType = PlaceableCatalogEntry.PLACEMENT_WALL;
            catEntry.Height = 3;
            catEntry.Width = 3;
            catEntry.Name = "Cheat Placeable";
            Placeable cheatPlaceableFloor = new Placeable("Cheat Placeable",
                ModContent.TileType<Tiles.CheatHousingTile>(),
                0,
                0, catEntry, 2);
            //PlaceOnCeiling(size, cheatPlaceableFloor, occupied);
            PlaceOnWall(size, 6, cheatPlaceableFloor, occupied);
            //PlaceOnFloor(size, cheatPlaceableFloor, occupied);

            //Want to make sure that required light/surface/comfort get first crack at placement. Even if the room doesn't have space for everything,
            //want to make sure it is at least a valid room.
            List<Placeable> orderedFurniture = new List<Placeable>();

            int wallStart = 6;
            foreach (Placeable placeable in foundSet.GetAllFurniture())
            {
                if (placeable.CatalogEntry.PlacementType == PlaceableCatalogEntry.PLACEMENT_FLOOR)
                {
                    PlaceOnFloor(size, placeable, occupied);
                }
                if (placeable.CatalogEntry.PlacementType == PlaceableCatalogEntry.PLACEMENT_CEILING)
                {
                    PlaceOnCeiling(size, placeable, occupied);
                }
                if (placeable.CatalogEntry.PlacementType == PlaceableCatalogEntry.PLACEMENT_WALL)
                {
                    PlaceOnWall(size, wallStart, placeable, occupied);
                }
                //Finding room atop things like tables seems a bit complicated. Going to ignore this furniture type for right now.
                //if (placeable.CatalogEntry.PlacementType == PlaceableCatalogEntry.PLACEMENT_ATOP)
                //{
                //    PlaceOnFloor(size, placeable, occupied);
                //}
            }

            return true;
        }

        public IList<Tuple<ThemedPlaceableSet, RoomSpecification>> DetermineAvailableRooms(Vector2 size, bool useFurnitureSets = true,
            string preferredRoom = null, string preferredTheme = null)
        {
            this.organizer = new PlaceableOrganizer(this.player);
            bool validSetFound = this.organizer.DetermineAvailableThemedSets(useFurnitureSets);
            if (!validSetFound)
            {
                Constants.Logger.Warn("No full, NPC-housable set of blocks/walls/furniture found");
                return new List<Tuple<ThemedPlaceableSet, RoomSpecification>>();
            }
            _roomSets =
                organizer.FindPlaceableRooms(preferredRoom != null ? new List<string>() { preferredRoom } : null, size,
                    useFurnitureSets: useFurnitureSets);

            if (!_roomSets.Any())
            {
                Constants.Logger.Warn("Couldn't find any room buildable from current furniture");
            }
            return _roomSets;
        }
    }
}
