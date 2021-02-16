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
        private int _wallId = 0;

        public Placeable(String name, int tileId, int wallId, int style, PlaceableCatalogEntry catalogEntry, int availableInstances)
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
        public int WallId
        {
            get => _wallId > 0 ? _wallId : TileId;
            set => _wallId = value;
        }
        public int Style { get; set; }
        public int AvailableInstances { get; set; }

        public Boolean IsWall => this.CatalogEntry != null && this.CatalogEntry.IsWall;

        public Boolean IsBlock => this.CatalogEntry != null && this.CatalogEntry.IsBlock;

        public Boolean IsSurface => this.CatalogEntry != null && this.CatalogEntry.Satisfies.Contains(Constants.SATISFIES_SURFACE);

        public bool IsPlatform => this.CatalogEntry?.Suffix?.Equals("Platform") ?? false;
    }
}
