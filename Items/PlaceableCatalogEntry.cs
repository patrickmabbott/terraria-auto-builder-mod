using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AutoBuilder.Items
{
    public class PlaceableCatalogEntry
    {
        public String Name { get; set; }
        public String Suffix { get; set; }
        public String Prefix { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool StylesAvailable { get; set; }
        public String PlacementType { get; set; }
        public int PreferredPosition { get; set; }
        public List<string> Satisfies { get; set; } = new List<string>() { };
        public List<string> Tags { get; set; } = new List<string>() { };

        public static readonly string PLACEMENT_FLOOR = "Floor";
        public static readonly string PLACEMENT_CEILING = "Ceiling";
        public static readonly string PLACEMENT_WALL = "Wall";
        public static readonly string PLACEMENT_ATOP = "Atop";

        //Example: R. Moosdijk, V. Costa Moura, A. G. Kolf
        private const string PATTERN = @"[A-Z]\..*";
        // Create a Regex  
        private static readonly Regex regex = new Regex(PATTERN);

        /**
         * Determines whether the provided item is covered under this catalog entry.
         */
        public bool IsMember(Item item)
        {
            if (this.Suffix != null && this.Suffix.Any() && item.Name.EndsWith(this.Suffix))
            {
                return true;
            }
            else if (this.Prefix != null && this.Prefix.Any() && item.Name.StartsWith(this.Prefix))
            {
                return true;
            }
            //Special case for paintings. Thankfully, all (vanilla) paintings follow a particular pattern for the tooltip.
            else if (this.Name == "Painting" && item.ToolTip != null && 
                     item.ToolTip.Lines >= 1 && 
                     regex.Matches(item.ToolTip.GetLine(0)).Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal string DeterminePrefix(Item item)
        {
            if (this.Suffix != null && this.Suffix.Any() && item.Name.EndsWith(this.Suffix))
            {
                //e.g. pearlwood bed. You remove "bed" and trim and the prefix is "pearlwood"
                return item.Name.Replace(this.Suffix, "").Trim();
            }
            else
            {
                return "";
            }
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Suffix)}: {Suffix}, {nameof(Prefix)}: {Prefix}, {nameof(Height)}: {Height}, {nameof(Width)}: {Width}, {nameof(StylesAvailable)}: {StylesAvailable}, {nameof(PlacementType)}: {PlacementType}, {nameof(PreferredPosition)}: {PreferredPosition}, {nameof(Satisfies)}: {Satisfies}, {nameof(Tags)}: {Tags}";
        }
    }
}
