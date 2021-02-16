using System;
using System.Collections.Generic;
using System.Linq;
using AutoBuilder.Items;
using AutoBuilder.json;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace AutoBuilder.Model
{
    public class Blueprint : TagSerializable
    {
        public static readonly Func<TagCompound, Blueprint> DESERIALIZER = Load;
        public int BlueprintSlot { get; set; }

        public string Name
        {
            get
            {
                if (IsCustom)
                {
                    List<string> customBuildingNames =
                        ModContent.GetInstance<AutoBuilderConfig>().CustomBuildingNames.Split(',').ToList();
                    if (customBuildingNames.Count >= BlueprintSlot)
                    {
                        return customBuildingNames[BlueprintSlot];
                    }
                    else
                    {
                        return $"Custom Building {BlueprintSlot}";
                    }
                }
                else
                {
                    if (BlueprintArchive.Instance.StandardBlueprintNames.Count >= BlueprintSlot)
                    {
                        return BlueprintArchive.Instance.StandardBlueprintNames[BlueprintSlot];
                    }
                    else
                    {
                        return $"Standard Building {BlueprintSlot}";
                    }
                }
            }
        }

        public List<TileInfo> Tiles { get; set; } = new List<TileInfo>();


        public List<IntPair> Perimeter { get; set; } = new List<IntPair>();

        public bool IsCustom { get; set; } = false;

        public TagCompound SerializeData()
        {
            return new TagCompound
            {
                ["BlueprintSlot"] = BlueprintSlot,
                ["Tiles"] = Tiles,
                ["Perimeter"] = Perimeter,
                ["IsCustom"] = IsCustom
            };
        }

        public static Blueprint Load(TagCompound tag)
        {
            Blueprint print = new Blueprint();
            print.BlueprintSlot = tag.GetInt("BlueprintSlot");
            print.Tiles = tag.Get<List<TileInfo>>("Tiles");
            print.Perimeter = tag.Get<List<IntPair>>("Perimeter");
            print.IsCustom = tag.GetBool("IsCustom");
            return print;
        }

        public BlueprintItemJson ToBlueprintJson()
        {
            BlueprintItemJson json = new BlueprintItemJson();
            json.BlueprintSlot = this.BlueprintSlot;
            json.Name = this.Name;
            json.Tiles.AddRange(this.Tiles);
            json.Perimeter.AddRange(this.Perimeter);
            return json;
        }
    }
}
