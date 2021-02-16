using System.Collections.Generic;
using System.IO;
using AutoBuilder.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AutoBuilder.json
{
    public class BlueprintItemJson
    {

        public BlueprintItemJson() { }

        [JsonConstructor]
        public BlueprintItemJson(string Name, List<TileInfo> Tiles, List<IntPair> Perimeter, int slot)
        {
            this.Name = Name;
            this.Tiles.AddRange(Tiles);
            this.Perimeter.AddRange(Perimeter);
            this.BlueprintSlot = slot;
        }

        public int BlueprintSlot { get; set; }

        public string Name { get; set; }

        public List<TileInfo> Tiles { get; set; } = new List<TileInfo>();

        public List<IntPair> Perimeter { get; set; } = new List<IntPair>();

        public Blueprint ToBlueprint()
        {
            Blueprint blueprint = new Blueprint();
            blueprint.Perimeter.AddRange(this.Perimeter);
            foreach(var tile in Tiles)
            {
                blueprint.Tiles.Add(tile);
            }

            blueprint.BlueprintSlot = this.BlueprintSlot;
            return blueprint;
        }

        public override string ToString()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StringWriter writer = new StringWriter())
            {
                using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(writer, this);
                    return writer.ToString();
                }
            }
        }
    }
}
