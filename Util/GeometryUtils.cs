using System;
using System.Collections.Generic;
using System.Linq;
using AutoBuilder.json;
using AutoBuilder.Model;
using Terraria;

namespace AutoBuilder.Util
{
    class GeometryUtils
    {
        // Returns true if the IntPair targetPoint lies 
        // inside the polygon[] with n vertices 
        // Returns true if the IntPair targetPoint lies 
        // inside the polygon[] with n vertices 
        public static bool IsPointInPolygon(List<IntPair> polygon, IntPair targetPoint)
        {
            // There must be at least 3 vertices in polygon[] 
            if (polygon.Count < 3)
            {
                return false;
            }

            //If count is odd, it comes from inside. If we were using a regular polygon that doesn't have any concavity, it would
            //be sufficient to know if count > 1. But, with concavity, we need to allow for something like this. (Which would fair if our intersection line was vertical)
            // ---------
            // |       |
            // ---     |
            //   |     |
            //----     |
            //| x      |
            //----------
            int count = 0;

            //If a block is in the polygon, at the very least its center must be in the polygon.
            //But, in current coord system, we are using integers so .5 doesn't work.
            //So, going to multiply everything by 10 so .5,.5 becomes 5,5.

            targetPoint *= 10;
            targetPoint += new IntPair(5, 5);

            for (int i = 0; i < polygon.Count; i++)
            {
                IntPair curPoint = polygon[i] * 10;
                IntPair nextPoint = i == polygon.Count - 1 ? polygon[0] * 10 : polygon[i + 1] * 10;
                //Because of how the polygon is formed and the gridness of the world, we know every line segment will be either horizontal or vertical.
                //vertical. For an intersection, we want x to be <= target x and target y to be between the two.
                //This is NOT inclusive because if the point is at the height of a corner in the bounding polygon
                //it would register an intersect with both line segments hitting the point if both are inclusive
                if (Math.Min(curPoint.X, nextPoint.X) <= targetPoint.X && targetPoint.Y > Math.Min(curPoint.Y, nextPoint.Y) &&
                    targetPoint.Y < Math.Max(curPoint.Y, nextPoint.Y))
                {
                    ++count;
                }
            }
            //i.e., it's an odd num.
            return count % 2 == 1;
        }

        /**
 * Determines dimensions the hard way, by looking at surrounding tiles.
 */
        public static IntPair DetermineDimensions(int x, int y, TileInfo info)
        {
            //In this case, we need to figure out the dimensions the hard way.
            int objectMinX = 0;
            int objectMinY = 0;
            int objectMaxX = 0;
            int objectMaxY = 0;
            //Thankfully, all objects are rectangles. So, can figure out lowerLeftX bounds first and then lowerLeftY bounds.
            if (GetBasicTileInfoAbs(new IntPair(x - 1, y)).AreSame(info))
            {
                objectMinX = -1;
                if (GetBasicTileInfoAbs(new IntPair(x - 2, y)).AreSame(info))
                {
                    objectMinX = -2;
                }
            }

            if (GetBasicTileInfoAbs(new IntPair(x + 1, y)).AreSame(info))
            {
                objectMaxX = 1;
                if (GetBasicTileInfoAbs(new IntPair(x + 2, y)).AreSame(info))
                {
                    objectMaxX = 2;
                }
            }

            if (GetBasicTileInfoAbs(new IntPair(x, y - 1)).AreSame(info))
            {
                objectMinY = -1;
                if (GetBasicTileInfoAbs(new IntPair(x, y - 2)).AreSame(info))
                {
                    objectMinY = -2;
                }
            }

            if (GetBasicTileInfoAbs(new IntPair(x, y + 1)).AreSame(info))
            {
                objectMaxY = 1;
                if (GetBasicTileInfoAbs(new IntPair(x, y + 2)).AreSame(info))
                {
                    objectMaxY = 2;
                }
            }

            return new IntPair(objectMaxX - objectMinX, objectMaxY - objectMinY);
        }

        public static TileInfo GetBasicTileInfoAbs(IntPair point)
        {
            Tile tile = Main.tile[point.X, point.Y];
            TileInfo info = new TileInfo();
            info.FromTile(tile, null);
            return info;
        }

        public static IEnumerable<IntPair> Range2D(int xMin, int xMax, int yMin, int yMax)
        {
            return Enumerable.Range(xMin, xMax - xMin).SelectMany(x => Enumerable.Range(yMin, yMax - yMin).Select(y => new IntPair(x, y)));
        }

        public static IEnumerable<IntPair> Range2D(IntPair lowerLeft, IntPair upperRight)
        {
            return Range2D(lowerLeft.X, upperRight.X, lowerLeft.Y, upperRight.Y);
        }

        public static List<IntPair> MinimizePolygon(List<IntPair> boundingPolygon)
        {
            List<IntPair> minimizedPoly = new List<IntPair>();

            List<int> directions = new List<int>();
            for (int i = 0; i < boundingPolygon.Count; i++)
            {
                IntPair curPoint = boundingPolygon[i];
                IntPair nextPoint;
                if (i == boundingPolygon.Count - 1)
                {
                    nextPoint = boundingPolygon[0];
                }
                else
                {
                    nextPoint = boundingPolygon[i + 1];
                }

                IntPair diff = nextPoint - curPoint;

                if (diff.Y > 0)
                {
                    directions.Add(0);
                }
                else if (diff.Y < 0)
                {
                    directions.Add(4);
                }
                else if (diff.X > 0)
                {
                    directions.Add(2);
                }
                else if (diff.X < 0)
                {
                    directions.Add(6);
                }
            }

            //Now that we have directions, what we want is to disregard any points that are along a line in the same direction
            //as both the entry before them because that targetPoint will always be a midpoint between other points on the same line.
            for (int i = 0; i < boundingPolygon.Count; i++)
            {
                if (i == 0)
                {
                    if (directions[0] != directions[directions.Count - 1])
                    {
                        minimizedPoly.Add(boundingPolygon[i]);
                    }
                }
                else
                {
                    //It's fine as long as the direction that starts at this targetPoint is not the same as the direction that reached it.
                    if (directions[i] != directions[i - 1])
                    {
                        minimizedPoly.Add(boundingPolygon[i]);
                    }
                }
            }

            return minimizedPoly;
        }
    }
}
