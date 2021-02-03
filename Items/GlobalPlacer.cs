using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AutoBuilder.Items
{
    public class GlobalPlacer
    {
        /**
         * Bit of a kludge. But, makes for less that needs to be passed between functions
         */
        private static Player player = null;

        private static void ConsumeItem(Item item, int amountToConsume = 1)
        {
            if (ModContent.GetInstance<AutoBuilderConfig>().DoConsumeResources)
            {
                item.stack -= Math.Min(amountToConsume, item.stack);
            }
        }

        private static void ConsumeItem(string itemName, int amountToConsume = 1)
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

        public static void PlaceFurniturePiece(Vector2 position, Placeable placeable)
        {
            Constants.Logger.Info($"Placing furniture {placeable.Name} {placeable.TileId} {placeable.Style} at (" + position.X + "," + position.Y + ")");
            WorldGen.PlaceTile((int)position.X, (int)position.Y, placeable.TileId, style: placeable.Style);
            ConsumeItem(placeable.Name);
        }

        public static void PlaceWall(Vector2 position, int tileId)
        {
            //Constants.Logger.Info($"Placing wall {tileId} at ({position.X},{position.Y})");
            WorldGen.PlaceWall((int)position.X, (int)position.Y, tileId);
            //This would probably work. But, I don't have a way of testing it so making this singleplayer-only for now.
            //if (Main.netMode == NetmodeID.Server)
            //    NetMessage.SendTileSquare(-1, (int)position.X, yPosition, 1);
        }

        public static void PlaceBlock(Vector2 position, int tileId)
        {
            //Constants.Logger.Info($"Placing {tileId} block at ({position.X},{position.Y}");
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

        private static bool PlaceOnCeiling(Vector2 roomSize, Placeable placeable, bool[,] isOccupied)
        {
            //Start from its preferred placement and go to the right. If you don't find an open space that way, go left instead.
            int startingX = (int)roomSize.X / 2;

            int lowEnd = (int) roomSize.Y - placeable.CatalogEntry.Height - 1;

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
                    if (IsSpaceClear(x, lowEnd, placeable.CatalogEntry.Width, placeable.CatalogEntry.Height, isOccupied))
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
                PlaceFurniturePiece(lowerLeftCorner + new Vector2(unoccupiedXPosition, 1 - (int)roomSize.Y), placeable);
                SetOccupied(unoccupiedXPosition, lowEnd,
                    placeable.CatalogEntry.Width + 1, placeable.CatalogEntry.Height, isOccupied);
                return true;
            }
        }

        private static bool PlaceOnFloor(Vector2 roomSize, Placeable placeable, bool[,] isOccupied)
        {
            //Start from its preferred placement and go to the right. If you don't find an open space that way, go left instead.
            int startingX = (int)roomSize.X / 2;

            int unoccupiedXPosition = -1;
            for (int x = startingX; x < roomSize.X - 1 - placeable.CatalogEntry.Width; x++)
            {
                if (IsSpaceClear(x, 1, placeable.CatalogEntry.Width, placeable.CatalogEntry.Height, isOccupied))
                {
                    unoccupiedXPosition = x;
                }
            }

            //Otherwise, go the other way.
            if (unoccupiedXPosition == -1)
            {
                for (int x = startingX; x > 1 + placeable.CatalogEntry.Width / 1; x--)
                {
                    if (IsSpaceClear(x, 1, placeable.CatalogEntry.Width, placeable.CatalogEntry.Height, isOccupied))
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
                PlaceFurniturePiece(lowerLeftCorner + new Vector2(unoccupiedXPosition, -1), placeable);
                SetOccupied(unoccupiedXPosition, 1,
                    placeable.CatalogEntry.Width + 1, placeable.CatalogEntry.Height, isOccupied);
                return true;
            }
        }

        private static bool PlaceOnWall(Vector2 roomSize, Placeable placeable, bool[,] isOccupied)
        {
            //Start from its preferred placement and go to the right. If you don't find an open space that way, go left instead.
            int startingX = (int)roomSize.X / 2;

            int unoccupiedXPosition = -1;
            int unoccupiedYPosition = -1;

            for (int y = 6; y <= roomSize.Y - 6; y+= 4)
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
                PlaceFurniturePiece(lowerLeftCorner + new Vector2(unoccupiedXPosition, -unoccupiedYPosition), placeable);
                SetOccupied(unoccupiedXPosition, unoccupiedYPosition,
                    placeable.CatalogEntry.Width + 1, placeable.CatalogEntry.Height, isOccupied);
                return true;
            }
        }

        public static void PlaceRoom(Player player, Vector2 size, bool useFurnitureSets = true, 
            string preferredRoom = null, string preferredTheme = null)
        {
            GlobalPlacer.player = player;
            PlaceableOrganizer organizer = new PlaceableOrganizer();
            Constants.Logger.Info($"Trying to place set with furniture? {useFurnitureSets}");
            bool validSetFound = organizer.DetermineAvailableThemedSets(player, useFurnitureSets);
            if (!validSetFound)
            {
                Constants.Logger.Info("No full, NPC-housable set of blocks/walls/furniture found");
                return;
            }
            Constants.Logger.Info("Found themed sets");
            Tuple<ThemedPlaceableSet, RoomSpecification> results = 
                organizer.FindPlaceableSet(preferredRoom != null ?new List<string>() { preferredRoom } : null, size, useFurnitureSets : useFurnitureSets);

            if (results?.Item1 == null || results.Item2 == null)
            {
                Constants.Logger.Warn("Couldn't find any room buildable from current furniture");
                //Couldn't find a valid room, unfortunately.
                return;
            }

            ThemedPlaceableSet foundSet = results.Item1;
            RoomSpecification foundRoom = results.Item2;

            Constants.Logger.Info("Found themed set");

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
            Constants.Logger.Info("Setting up occupied array");
            for (int xRelative = 0; xRelative < size.X; xRelative++)
            {
                for (int yRelative = 0; yRelative < size.Y; yRelative++)
                {
                    occupied[xRelative,yRelative] = false;
                }
            }

            Placeable block = foundSet.Blocks.First();
            Placeable wall = foundSet.Walls.First();

            //floor
            Constants.Logger.Info("Setting up floor");
            for (int xRelative = 0; xRelative <= size.X; xRelative++)
            {
                occupied[xRelative, 0] = true;
                PlaceBlock(lowerLeftCorner + new Vector2(xRelative, 0), block.TileId);
            }
            //2 because top and bottom, left and rt. -5 for two 3-high doors and the sidewalls each share 2 blocks already counted in floor/ceiling.
            ConsumeItem(block.Name, (int)((size.X + size.Y - 5) * 2) );

            //Left side
            //Starts at 3 to leave room for a 3-high door
            Constants.Logger.Info("Setting up left side");
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

            Constants.Logger.Info("Setting up Ceil");
            //Ceiling
            for (int xRelative = 0; xRelative <= size.X; xRelative++)
            {
                PlaceBlock(lowerLeftCorner + new Vector2(xRelative, -size.Y), foundSet.Blocks.First().TileId);
            }

            Constants.Logger.Info("Setting up rt side");
            //Right side
            for (int yRelative = 4; yRelative < size.Y; yRelative++)
            {
                PlaceBlock(lowerLeftCorner + new Vector2(size.X, -yRelative), foundSet.Blocks.First().TileId);
            }

            //Right door
            WorldGen.PlaceTile((int)lowerLeftCorner.X + (int)size.X, (int)lowerLeftCorner.Y -1 , TileID.ClosedDoor, style : foundSet.Doors.First().Style);
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

            ConsumeItem(block.Name, (int)((size.X + size.Y - 5) * 2));

            //Want to make sure that required light/surface/comfort get first crack at placement. Even if the room doesn't have space for everything,
            //want to make sure it is at least a valid room.
            List<Placeable> orderedFurniture = new List<Placeable>();

            foreach (Placeable placeable in foundSet.GetAllFurniture())
            {
                Constants.Logger.Info($"Trying to place {placeable.Name}");
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
                    PlaceOnWall(size, placeable, occupied);
                }
                //Finding room atop things like tables seems a bit complicated. Going to ignore this furniture type for right now.
                //if (placeable.CatalogEntry.PlacementType == PlaceableCatalogEntry.PLACEMENT_ATOP)
                //{
                //    PlaceOnFloor(size, placeable, occupied);
                //}
            }
        }
    }
}
