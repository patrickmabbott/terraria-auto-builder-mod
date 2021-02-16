using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AutoBuilder.json;
using AutoBuilder.Util;
using log4net;
using Newtonsoft.Json;

namespace AutoBuilder.Items
{
    public class Constants
    {

        private static readonly IDictionary<string, SpeciallyNamedSet> speciallyNamedSets = new Dictionary<string, SpeciallyNamedSet>();
        private static readonly IDictionary<string, PlaceableCatalogEntry> catalogEntries = new Dictionary<string, PlaceableCatalogEntry>();
        private static IEnumerable<RoomSpecification> roomSpecs;

        public static readonly String SATISFIES_LIGHT = "Light";
        public static readonly String SATISFIES_COMFORT = "Comfort";
        public static readonly String SATISFIES_SURFACE = "Surface";
        public static readonly String SATISFIES_DOOR = "Door";
        public static readonly String SATISFIES_WALL = "Wall";
        public static readonly String SATISFIES_BLOCK = "Block";
        public static readonly int DOOR_STYLE_WRAP_LIMIT = 45;
        //Doors have this very annoying behavior of reporting either the correct style for a constitutent tile or 36 higher or 72 higher.
        public static readonly int DOOR_STYLE_ID_RANGE = 36;
        public static readonly int DOOR_CLOSED_TILE_ID = 10;
        public static readonly int DOOR_OPEN_TILE_ID = 11;

        public static ILog Logger { get; set; }

        public static void Init()
        {
            string text = ReadFile("SpeciallyNamedSets");
            IEnumerable<SpeciallyNamedSet> speciallyNamedSetsList = JsonConvert.DeserializeObject<SpeciallyNamedSet[]>(text);
            foreach (SpeciallyNamedSet item in speciallyNamedSetsList)
            {
                if (!speciallyNamedSets.ContainsKey(item.FurniturePrefix))
                {
                    speciallyNamedSets.Add(item.FurniturePrefix, item);
                }
            }

            text = ReadFile("RoomDefinitions");
            roomSpecs = JsonConvert.DeserializeObject<RoomSpecification[]>(text);

            text = ReadFile("PlaceableCatalog");
            IList<PlaceableCatalogEntry> catalogEntriesList = JsonConvert.DeserializeObject<PlaceableCatalogEntry[]>(text).ToList();
            foreach (PlaceableCatalogEntry item in catalogEntriesList)
            {
                //Add the item's name as a tag so we can use tags for look for exact items as well as categories.
                if (item.Name != null)
                {
                    item.Tags.Add(item.Name);
                    Constants.Logger.Info($" Catalog Entry Suffix: {item.Suffix} from catalog entries {item.Name}");
                    if (!catalogEntries.ContainsKey(item.Name))
                    {
                        catalogEntries.Add(item.Name, item);
                    }
                }
            }
            Constants.Logger.Info($"{catalogEntries.Count} catalog entries");
        }

        public static string ReadFile(String fileName)
        {

            if (fileName.Contains("PlaceableCatalog"))
            {
                return PlaceableCatalogText.text.Replace("'", "\"");
            }
            else if (fileName.Contains("RoomDefinitions"))
            {
                return RoomDefinitionsText.text.Replace("'", "\"");
            }
            else if (fileName.Contains("Specially"))
            {
                return SpeciallyNamedSetsText.text.Replace("'", "\"");
            }
            else if (fileName.Contains("StandardBlueprints"))
            {
                return StandardBlueprintsText.text.Replace("'", "\"");
            }
            else if (fileName.Contains("ItemBasicInfo"))
            {
                return ItemBasicInfoTexts.text;
            }

            return null;
            //var assembly = Assembly.GetExecutingAssembly();
            //Logger.Info("Pre-file-read: " + assembly.GetManifestResourceNames().Length);
            //string result = Properties.Resources.RoomDefinitions;
            //Logger.Info(result);
            //return result;
            //string resourceName = assembly.GetManifestResourceNames()
            //    .First(str =>
            //    {
            //        Logger.Error($"Manifest includes {str}");
            //        return str.EndsWith($"{fileName}.json");
            //    });
            //using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            //using (StreamReader reader = new StreamReader(stream))
            //{
            //    return reader.ReadToEnd();
            //}
        }

        public static IDictionary<string, SpeciallyNamedSet> GetSpeciallyNamedSets()
        {
            return speciallyNamedSets;
        }

        public static IEnumerable<RoomSpecification> GetRoomSpecs()
        {
            return roomSpecs;
        }

        public static IDictionary<string, PlaceableCatalogEntry> GetCatalogEntries()
        {
            return catalogEntries;
        }

    }
}
