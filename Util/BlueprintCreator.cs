using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoBuilder.Items;
using AutoBuilder.json;
using AutoBuilder.Model;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Main = Terraria.Main;
using Tile = Terraria.Tile;

namespace AutoBuilder.Util
{
    /**
     * Class responsible for finding the bounds of the external wall of a building and then noting all the contents of the building and storing as an entry in the blueprint archive.
     */
    public class BlueprintCreator
    {
        public List<IntPair> ExternalBlocks = new List<IntPair>();

        public List<IntPair> BoundingPolygon = new List<IntPair>();

        public List<TileInfo> Tiles = new List<TileInfo>();


        public IntPair Referent { get; set; }

        private IntPair convertToAbs(IntPair relativeCoords)
        {
            //-lowerLeftY because relative coords are in positive lowerLeftY = up for ease of visualizing.
            return new IntPair(Referent.X + relativeCoords.X, Referent.Y - relativeCoords.Y);
        }

        private IntPair convertToRelative(IntPair absCoords)
        {
            //-lowerLeftY because relative coords are in positive lowerLeftY = up for ease of visualizing.
            return new IntPair(absCoords.X - Referent.X, -(absCoords.Y - Referent.Y) );
        }

        public static bool DoesPositionContainExternalTileAbs(int x, int y)
        {
            Tile tile = Main.tile[x, y];
            TileInfo info = new TileInfo();
            info.FromTile(tile, new IntPair(x, y));
            //In particular, ignore dirt and grass and flowers when trying to form a perimeter.
            //You will still have issues with structures sitting atop stone or other material. But, this should cover most
            //cases where people don't dig their structure out before scanning it.
            //Valid outer bounds include blocks (including bricks etc...), platforms, trapdoors, and doors.
            return info.IsValidForOuterPerimeter;
        }

        public static bool DoesPositionContainExternalTileAbs(IntPair pair)
        {
            return DoesPositionContainExternalTileAbs(pair.X, pair.Y);
        }

        private bool DoesPositionContainExternalTile(IntPair pair)
        {
            return DoesPositionContainExternalTileAbs(convertToAbs( pair));
        }

        private bool DoesPositionContainExternalTile(int x, int y)
        {
            return DoesPositionContainExternalTile(new IntPair(x, y));
        }

        private TileInfo GetTileInfo(IntPair point)
        {
            return GetTileInfoAbs(convertToAbs(point));
        }

        private TileInfo GetTileInfoAbs(IntPair point)
        {
            Tile tile = Main.tile[point.X, point.Y];
            TileInfo info = new TileInfo();
            info.FromTile(tile, point);
            info.IsExternalBlock = ExternalBlocks.Contains(convertToRelative(point));
            info.Position = convertToRelative(point);
            return info;
        }

        public Blueprint CreateBlueprint(int blueprintSlot)
        {
            if (DetermineBoundingPolygon())
            {
                if (DetermineTiles())
                {
                    Constants.Logger.Debug($" Tiles include {Tiles.Count} points");
                    Blueprint blueprint = new Blueprint();
                    blueprint.BlueprintSlot = blueprintSlot;
                    blueprint.Perimeter.AddRange(BoundingPolygon);
                    blueprint.Tiles.AddRange(Tiles);
                    blueprint.IsCustom = true;

                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Converters.Add(new JavaScriptDateTimeConverter());
                    serializer.NullValueHandling = NullValueHandling.Ignore;
                    using (StringWriter writer = new StringWriter())
                    {
                        using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                        {
                            serializer.Serialize(writer, blueprint);
                            Constants.Logger.Debug(writer.ToString());
                        }
                    }

                    return blueprint;
                }
            }
            return null;
        }

        public bool DetermineTiles()
        {
            List<IntPair> minimalPolygon = GeometryUtils.MinimizePolygon(BoundingPolygon);
            //minimalPolygon.Select(entry => entry.ToString()).ToList().ForEach(entry => Constants.Logger.Info(entry));

            minimalPolygon.ForEach(p => Constants.Logger.Info(p));

            //Find the bounding box of the building. (We already know our left side is at 0 b/c that's how we started out search
            int maxX = minimalPolygon.Max(entry => entry.X);
            int minX = minimalPolygon.Min(entry => entry.X);
            int maxY = minimalPolygon.Max(entry => entry.Y);
            int minY = minimalPolygon.Min(entry => entry.Y);
            
            //A sort of cache that lets us, on finding the bottom-left tile of an object,
            //determine which tile is its anchor and mark other contributing tiles as not needing to be placed.
            ISet<IntPair> inObjectButNotAnchorTiles = new HashSet<IntPair>();
            ISet<IntPair> anchorTiles = new HashSet<IntPair>();

            foreach(IntPair pos in GeometryUtils.Range2D(minX, maxX, minY, maxY) )
            {
                int x = pos.X;
                int y = pos.Y;
                Constants.Logger.Info($"looking at point {pos} {GeometryUtils.IsPointInPolygon(minimalPolygon, new IntPair(x, y))}");
                if (GeometryUtils.IsPointInPolygon(minimalPolygon, new IntPair(x, y)))
                {
                    //Try to differentiate tiles that anchor objects (and therefore we will want to place an object at that position)
                    //and tiles that just participate in an object (and can largely be ignored for replicating the structure)
                    IntPair position = new IntPair(x, y);
                    TileInfo info = GetTileInfo(new IntPair(x, y));

                    if (anchorTiles.Contains(position))
                    {
                        //If we've already calculated that this is in fact an anchor tile.
                        info.IsAnchorTile = true;
                    }
                    if (inObjectButNotAnchorTiles.Contains(position))
                    {
                        //If we've already precalculated that this is part of an object but not the anchor,
                        //we know that we don't need to recalculate.
                        info.IsAnchorTile = false;
                    }
                    else
                    {
                        //If we haven't already calculated anchor tiles and in-object-nut-not-anchor-tiles, do so now.
                        CalculateAssociatedAnchorTiles(info, x, y, inObjectButNotAnchorTiles, anchorTiles);
                        info.IsAnchorTile = anchorTiles.Contains(position);
                    }
                    //Basically adding info on all tiles since even if they don't have a wall or tile,
                    //They could have actuators, wires etc...
                    this.Tiles.Add(info);
                }
            }

            return true;
        }

        private void CalculateAssociatedAnchorTiles(TileInfo info, int x, int y, ISet<IntPair> inObjectButNotAnchorTiles,
            ISet<IntPair> anchorTiles)
        {
            //Here's the real logic. Try to determine if a tile is an anchor or not
            //If the tile doesn't have any blocks or objects or doors etc..., don't bother
            //If it's a block, it's always an anchor. Move on
            if (info.HasNoTile)
            {
                //Move on, no need to worry about it.
            }
            else if (info.IsBlock || (info.Width == 1 && info.Height == 1))
            {
                //Blocks are always 1x1 so just incase info wasn't able to determine dimensions...
                anchorTiles.Add(new IntPair(x, y));
            }
            else
            {
                IntPair dimensions = new IntPair(info.Width, info.Height);

                string placementType = DeterminePlacementType(dimensions, x, y, info);

                IntPair placementPosition = DeterminePlacementPosition(x, y, dimensions, placementType);

                for (int relX = 0; relX < dimensions.X; relX++)
                {
                    for (int relY = 0; relY < dimensions.Y; relY++)
                    {
                        if (new IntPair(x + relX, y + relY) != placementPosition)
                        {
                            inObjectButNotAnchorTiles.Add(new IntPair(x + relX, y + relY));
                        }
                        else
                        {
                            anchorTiles.Add(new IntPair(x + relX, y + relY));
                        }
                    }
                }
            }
        }

        private IntPair DeterminePlacementPosition(int x, int y, IntPair dimensions, string placementType)
        {
            //X is easy. it's at the center along lowerLeftX axis (in case of even width, left side wins).
            int xAnchor = dimensions.X == 1 ? x : x + 1;
            int yAnchor = y;
            if (placementType == PlaceableCatalogEntry.PLACEMENT_FLOOR || placementType == PlaceableCatalogEntry.PLACEMENT_ATOP)
            {
                //Yes, this does nothing. But, it's more readable this way.
                yAnchor = y;
            }
            else if (placementType == PlaceableCatalogEntry.PLACEMENT_CEILING)
            {
                yAnchor = y + dimensions.Y - 1;
            }
            else if (placementType == PlaceableCatalogEntry.PLACEMENT_WALL)
            {
                yAnchor = y == 1 ? y : y + 1;
            }

            return new IntPair(xAnchor, yAnchor);
        }

        private string DeterminePlacementType(IntPair dimensions, int lowerLeftX, int lowerLeftY, TileInfo info)
        {
            //lowerLeftY is a bit more complicated because we have different rules for ceiling vs floor vs wall anchoring.
            //First, floor anchoring.
            if (GetTileInfo(new IntPair(lowerLeftX, lowerLeftY - 1)).IsExternalBlock)
            {
                return PlaceableCatalogEntry.PLACEMENT_FLOOR;
            } //On ceiling. In this case, the desired anchor is max lowerLeftY
            else if (GetTileInfo(new IntPair(lowerLeftX, lowerLeftY + 1)).IsBlock)
            {
                return PlaceableCatalogEntry.PLACEMENT_CEILING;
            }
            else if( GetTileInfo(new IntPair(lowerLeftX, lowerLeftY - 1)).IsExternalBlock ||
                    (GetTileInfo(new IntPair(lowerLeftX, lowerLeftY - 1)).ToPlaceable() != null &&
                    GetTileInfo(new IntPair(lowerLeftX, lowerLeftY - 1)).ToPlaceable().IsSurface)
                    )
            {
                return PlaceableCatalogEntry.PLACEMENT_ATOP;
            }
            else
            {
                //Anything else, assume it's placed on the wall.
                return PlaceableCatalogEntry.PLACEMENT_WALL;
            }
        }

        public bool DetermineBoundingPolygon()
        {
            this.Referent = FindBlueprintReferent();

            int startX = 0;
            int startY = 0;

            //To start, add the leftmost (and lower-most as tiebreaker) point. We know that we'll start going up because clockwise.
            BoundingPolygon.Add(new IntPair(startX, startY));
            int lastDirection = 0;
                
            // Track iterations so we don't potentially loop around forever on some unexpected geometry.
            Boolean endedOnIterations = true;
            for (int iterations = 0; iterations < 10000; iterations++)
            {
                lastDirection = NextPoint(lastDirection);
                if (lastDirection < 0)
                {
                    bool firsts = true;
                    foreach (IntPair point in BoundingPolygon)
                    {
                        if (!firsts)
                        {
                            Constants.Logger.Info(",");
                        }
                        if (firsts)
                        {
                            firsts = false;
                        }
                        Constants.Logger.Info(point.X);
                        Constants.Logger.Info(",");
                        Constants.Logger.Info(point.Y);
                    }
                    Constants.Logger.Warn("Could not complete a polygon");
                    return false;
                }
                else if (lastDirection >= 8)
                {
                    endedOnIterations = false;
                    break;
                }
            }

            if (endedOnIterations)
            {
                Constants.Logger.Error($"Unable to form complete bounding polygon. Ended at {BoundingPolygon.Last()}");
            }

            Constants.Logger.Debug($"bounding polygon has {BoundingPolygon.Count} points");

            return true;
        }

        /**
         * Finds a point known to be on the outer boundary of a structure.
         * All other points in the blueprint creation process are in reference to this.
         */
        public static IntPair FindBlueprintReferent()
        {
            Vector2 lowerLeftCorner = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
            lowerLeftCorner /= 16f;

            int startX = (int) lowerLeftCorner.X;
            int startY = (int) lowerLeftCorner.Y;

            while (!DoesPositionContainExternalTileAbs(new IntPair(--startX, startY)))
            {
                ;
            }

            while (DoesPositionContainExternalTileAbs(new IntPair(--startX, startY)))
            {
                ;
            }

            startX++;
            //Referent is the lower-left corner.
            return new IntPair((int)startX, (int)startY); ;
        }


        /**
 * Returns direction of travel and corner representing block to add to externals
 */
        private int NextPoint(int lastDirectionTraveled)
        {
            //Prefer to turn left if possible, then up, then right. Back is not acceptable because then we'd have loops.
            int nextDirection = lastDirectionTraveled;
            int startX = (int)BoundingPolygon.Last().X;
            int startY = (int)BoundingPolygon.Last().Y;
            for (int i = -2; i < 3; i += 2)
            {
                //-2 for the turn and 8 to ensure we don't end up with negative.
                nextDirection = (lastDirectionTraveled + 8 + i) % 8;
                int endX = 0;
                int endY = 0;
                int blockX = 0;
                int blockY = 0;
                //If we are going left in a clockwise direction, we know we are on the bottom surface so see if a block exists at (-1,0)
                if (nextDirection == 6) //left
                {
                    endX = startX - 1;
                    endY = startY;
                    blockX = endX;
                    blockY = endY;
                }
                else if (nextDirection == 0) //up
                {
                    endX = startX;
                    endY = startY + 1;
                    blockX = startX;
                    blockY = startY;
                }
                else if (nextDirection == 2) //right
                {
                    endX = startX + 1;
                    endY = startY;
                    blockX = startX;
                    blockY = startY - 1;
                }
                else if (nextDirection == 4) //down
                {
                    endX = startX;
                    endY = startY - 1;
                    blockX = startX - 1;
                    blockY = startY - 1;
                }
                IntPair externalPoint = new IntPair(blockX, blockY);
                if (DoesPositionContainExternalTile(new IntPair(blockX, blockY)))
                {
                    if (BoundingPolygon.Contains(new IntPair(endX, endY)))
                    {
                        //We have come full circle successfully.
                        return 8;
                    }
                    BoundingPolygon.Add(new IntPair(endX, endY));
                    ExternalBlocks.Add(externalPoint);
                    return nextDirection;
                }
            }
            return -1;
        }
    }
}
