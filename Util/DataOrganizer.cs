using System;
using System.Collections.Generic;
using System.Linq;
using AutoBuilder.Items;
using AutoBuilder.json;
using AutoBuilder.Model;
using AutoBuilder.Util;
using log4net.Repository.Hierarchy;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Item = Terraria.Item;
using Main = Terraria.Main;

namespace AutoBuilder.Util
{
    /**
     * Singleton incharge of self-populating and organizing important relations for rapid lookup.
     * For example, looking up inventory items by the tile or wall ID and style they produce when placed.
     */
    public class DataOrganizer
    {

        private DataOrganizer()
        {
            Initialize();
        }

        private static DataOrganizer _instance;

        public static DataOrganizer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataOrganizer();
                }
                return _instance;
            }
        }

        public IDictionary<PlaceableCatalogEntry, ISet<TileIdentifier>> PlaceablesByCategory { get; } = 
            new Dictionary<PlaceableCatalogEntry, ISet<TileIdentifier>>();

        public IDictionary<TileIdentifier, string> TileNames { get; } = new Dictionary<TileIdentifier, string>();
        public IDictionary<int, string> WallNames { get; } = new Dictionary<int, string>();
        public IDictionary<int, string> PaintNames { get; } = new Dictionary<int, string>();



        //public IDictionary<TileIdentifier, TileInfo> TileInfoFromTileId { get; } = new Dictionary<TileIdentifier, TileInfo>();

        private void Initialize()
        {
            try
            {
                string txt = Constants.ReadFile("ItemBasicInfo");
                string[] lines = txt.Split(
                    new[] { Environment.NewLine },
                    StringSplitOptions.None
                );
                bool firstLine = true;
                foreach (string line in lines)
                {
                    if (firstLine)
                    {
                        //Ignore the title line
                        firstLine = false;
                        continue;
                    }
                    string[] splits = line.Split(',');

                    if (splits.Length != 6)
                    {
                        Constants.Logger.Warn($"Got unexpected number of items for line {line}");
                        continue;
                    }

                    string name = splits[1];
                    int tileId = -1;
                    int style = 0;
                    int wallId = -1;
                    int paint = -1;
                    if (splits[2] != "-")
                    {
                        int.TryParse(splits[2], out tileId);
                    }
                    if (splits[3] != "-")
                    {
                        int.TryParse(splits[3], out style);
                    }
                    if (splits[4] != "-")
                    {
                        int.TryParse(splits[4], out wallId);
                    }
                    if (splits[5] != "-")
                    {
                        int.TryParse(splits[5], out paint);
                    }

                    ExtractTileNames(tileId, style, name, wallId, paint);
                }

                //Also load modded.
                foreach (int itemId in Enumerable.Range(0, 20000))
                {
                    ModItem item = ItemLoader.GetItem(itemId);
                    if (item?.item != null && (item.item.createTile > -1 || item.item.createWall > -1) )
                    {
                        ExtractTileNames(item.item.createTile, item.item.placeStyle, item.item.Name, item.item.createWall, -1);
                    }
                }
            }
            catch (Exception e)
            {   
                Constants.Logger.Error(e);
            }
        }

        private void ExtractTileNames(int tileId, int style, string name, int wallId, int paint)
        {
            if (tileId > -1)
            {
                TileIdentifier id = new TileIdentifier((ushort) tileId, style);

                foreach (PlaceableCatalogEntry entry in Constants.GetCatalogEntries().Values)
                {
                    if (entry.IsMember(name, null, true))
                    {
                        if (!PlaceablesByCategory.ContainsKey(entry))
                        {
                            PlaceablesByCategory.Add(entry, new HashSet<TileIdentifier>());
                        }

                        PlaceablesByCategory[entry].Add(id);
                        break;
                    }
                }

                if (!TileNames.ContainsKey(id))
                {
                    TileNames.Add(id, name);
                    Constants.Logger.Info($"Adding tile with {tileId} style {style} and name {name}");
                }
                else
                {
                    Constants.Logger.Warn($"Duplicate tile id {id} and name {name}");
                }
            }

            if (wallId > -1)
            {
                if (!WallNames.ContainsKey(wallId))
                {
                    WallNames.Add(wallId, name);
                }
                else
                {
                    Constants.Logger.Warn($"Duplicate wall id {wallId} and name {name}");
                }
                foreach (PlaceableCatalogEntry entry in Constants.GetCatalogEntries().Values)
                {
                    if (entry.IsMember(name, null, false))
                    {
                        if (!PlaceablesByCategory.ContainsKey(entry))
                        {
                            PlaceablesByCategory.Add(entry, new HashSet<TileIdentifier>());
                        }

                        PlaceablesByCategory[entry].Add(new TileIdentifier(wallId, -1, true));
                        break;
                    }
                }
            }

            if (paint > -1)
            {
                if (!PaintNames.ContainsKey(paint))
                {
                    PaintNames.Add(paint, name);
                }
                else
                {
                    Constants.Logger.Warn($"Duplicate paint id {paint} and name {name}");
                }
            }
        }
    }
}
