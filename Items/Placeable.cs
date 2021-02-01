using System;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AutoBuilder.Items
{
    public class Placeable
    {

        public Placeable(String name, int tileId, int style, PlaceableCatalogEntry catalogEntry, int availableInstances)
        {
            this.Name = name;
            this.TileId = tileId;
            this.Style = style;
            this.CatalogEntry = catalogEntry;
            this.AvailableInstances = availableInstances;
        }

        public String Name { get; set; }
        public PlaceableCatalogEntry CatalogEntry { get; set; }
        public int TileId { get; set; }
        public int Style { get; set; }
        public int AvailableInstances { get; set; }
    }
}
