using System;
using System.Collections.Generic;
using System.Linq;
using AutoBuilder.json;
using AutoBuilder.Model;
using Newtonsoft.Json;
using Terraria.ModLoader;

namespace AutoBuilder.Items
{
    public class BlueprintArchive
    {

        private BlueprintArchive()
        {
            LoadStandardBlueprints();
        }

        public static BlueprintArchive Instance { get; } = new BlueprintArchive();

        public bool NeedsReload { get; set; } = false;

        public List<string> StandardBlueprintNames { get; } = new List<string>();

        public List<Blueprint> StandardBlueprints { get; } = new List<Blueprint>();

        public List<Blueprint> CustomBlueprints { get; } = new List<Blueprint>();

        public List<string> CustomBlueprintNames => ModContent.GetInstance<AutoBuilderConfig>().CustomBuildingNames.Split(',').ToList();

        public List<Blueprint> AllBlueprints
        {
            get
            {
                List<Blueprint> allBlueprints = new List<Blueprint>();
                allBlueprints.AddRange(StandardBlueprints);
                allBlueprints.AddRange(CustomBlueprints);
                return allBlueprints;
            }
        }

        public void LoadCustomBlueprints(IEnumerable<Blueprint> blueprints)
        {
            CustomBlueprints.Clear();
            foreach (Blueprint item in blueprints)
            {
                CustomBlueprints.Add(item);
            }
        }

        public void LoadCustomBlueprintsFromText(string serialized)
        {
            if (serialized != null && serialized.Length > 3)
            {
                try
                {
                    List<BlueprintItemJson> blueprints =
                        JsonConvert.DeserializeObject<BlueprintItemJson[]>(serialized).ToList();
                    blueprints.Sort((b1, b2) => b1.BlueprintSlot.CompareTo(b2.BlueprintSlot));
                    CustomBlueprints.Clear();
                    foreach (BlueprintItemJson item in blueprints)
                    {
                        Blueprint blueprint = item.ToBlueprint();
                        CustomBlueprints.Add(blueprint);
                    }
                }
                catch (Exception e)
                {
                    Constants.Logger.Error(e);
                }
            }
        }

        public string SaveCustomBlueprints()
        {
            List<BlueprintItemJson> blueprints = StandardBlueprints.Select(entry => entry.ToBlueprintJson()).ToList();
            try
            {

                string serialized = JsonConvert.SerializeObject(blueprints);
                Constants.Logger.Debug(serialized);
                NeedsReload = false;
                return serialized;
            }
            catch (JsonSerializationException e)
            {
                Constants.Logger.Error(e);
            }

            return "[]";
        }

        public void LoadStandardBlueprints()
        {
            try
            {
                string text = Constants.ReadFile("StandardBlueprintsText");
                IEnumerable<BlueprintItemJson> blueprints = JsonConvert.DeserializeObject<BlueprintItemJson[]>(text);
                StandardBlueprints.Clear();
                StandardBlueprintNames.Clear();
                foreach (BlueprintItemJson item in blueprints)
                {
                    Blueprint blueprint = item.ToBlueprint();
                    blueprint.BlueprintSlot = StandardBlueprintNames.Count;
                    StandardBlueprintNames.Add(item.Name);
                    StandardBlueprints.Add(blueprint);
                }
            }
            catch (JsonSerializationException e)
            {
                Constants.Logger.Error(e);
            }
        }

        public void SetCustomBlueprint(int curBlueprintSlot, Blueprint blueprint)
        {
            if (curBlueprintSlot >= CustomBlueprintNames.Count)
            {
                Constants.Logger.Warn("Cannot place more blueprints than there are names for");
            }
            else
            {
                if (curBlueprintSlot >= CustomBlueprints.Count)
                {
                    CustomBlueprints.Add(blueprint);
                }
                else
                {
                    CustomBlueprints[curBlueprintSlot] = blueprint;
                }
            }
            SaveCustomBlueprints();
        }
    }
}
