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
    public class PlaceableCatalogEntry : IEquatable<PlaceableCatalogEntry>
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

        public static List<string> blockSuffixes = new List<string>() { "Brick", "Astroturf", "Chunk", "Block", "Ore", "Shingles", "Stucco", "Conduit Plating", "Ice", "Plating", "Slab", "Stone", "Slag", "Gravel", "Stone", "Crystal" };

        public static List<string> wallSuffixes = new List<string>() { "Wall", "Wallpaper", "Stained Glass", "Fence"};

        // TODO: Should probably add an alternateSuffixes field to the catalog text instead of defining here.
        public static List<string> platformSuffixes = new List<string>() { "Shelf" };

        public static List<string> singularNameBlocks = new List<string>() { "Glass", "Bamboo", "Cactus", "Luminite", "Pumpkin", "Cog", "Snow", "Sand", "Hay" };

        //Example: R. Moosdijk, V. Costa Moura, A. G. Kolf
        private const string PATTERN = @"[A-Z]\..*";
        // Create a Regex  
        private static readonly Regex regex = new Regex(PATTERN);

        public Boolean IsWall => this.Satisfies.Contains(Constants.SATISFIES_WALL);

        public Boolean IsBlock => this.Satisfies.Contains(Constants.SATISFIES_BLOCK);

        /**
         * Determines whether the provided item is covered under this catalog entry.
         */
        public bool IsMember(Item item, bool checkForBlock)
        {
            return IsMember(item.Name, item.ToolTip?.GetLine(0), checkForBlock);
        }

        /**
         * Determines whether the provided item is covered under this catalog entry.
         */
        public bool IsMember(string name, string tooltip, bool checkForBlock)
        {
            if (name == null)
            {
                return false;
            }
            List<string> nameBlocks = new List<string>() { };
            nameBlocks.AddRange(singularNameBlocks);
            if (ModContent.GetInstance<AutoBuilderConfig>().AdditionalBlockNames.Any())
            {
                nameBlocks.AddRange(ModContent.GetInstance<AutoBuilderConfig>().AdditionalBlockNames.Split(','));
            }

            Constants.Logger.Info($"Checking suffix {Suffix} against {name}");
            if (!string.IsNullOrEmpty(this.Suffix) && name.EndsWith(this.Suffix))
            {
                return true;
            }

            if (this.Name == "Wall" && wallSuffixes.Any(name.EndsWith))
            {
                return true;
            }
            //Specifically for blocks
            //Only want to use this mostly when we are looking for 
            if (this.Name == "Block" && checkForBlock &&
                (nameBlocks.Any(name.EndsWith) ||
                 singularNameBlocks.Contains(name) ||
                 name.ToLower().EndsWith("wood")
                )
            )
            {
                return true;
            }

            if (this.Suffix == "Platform" && platformSuffixes.Any(name.EndsWith))
            {
                return true;
            }
            if (this.Prefix != null && this.Prefix.Any() && name.StartsWith(this.Prefix))
            {
                return true;
            }
            //Special case for paintings. Thankfully, all (vanilla) paintings follow a particular pattern for the tooltip.
            if (this.Name == "Painting" && tooltip != null &&
                regex.Matches(tooltip).Count > 0)
            {
                return true;
            }
            return false;
        }

        internal string DeterminePrefix(Item item)
        {
            return DeterminePrefix(item.Name);
        }

        internal string DeterminePrefix(string name)
        {
            if (name == null)
            {
                return "";
            }
            List<string> nameBlocks = new List<string>() { };
            nameBlocks.AddRange(singularNameBlocks);
            if (ModContent.GetInstance<AutoBuilderConfig>().AdditionalBlockNames.Any())
            {
                nameBlocks.AddRange(ModContent.GetInstance<AutoBuilderConfig>().AdditionalBlockNames.Split(','));
            }

            if (this.Suffix != null && this.Suffix.Any() && name.EndsWith(this.Suffix))
            {
                //e.g. pearlwood bed. You remove "bed" and trim and the prefix is "pearlwood"
                return name.Replace(this.Suffix, "").Trim();
            }
            else if (this.Name == "Block")
            {
                string foundSuffix = blockSuffixes.FirstOrDefault(suffix => name.EndsWith(suffix));
                if (foundSuffix != null)
                {
                    return name.Replace(foundSuffix, "").Trim();
                }
                else if (nameBlocks.Contains(name) || name.ToLower().EndsWith("wood"))
                {
                    return name;
                }
            }
            return "";
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Suffix)}: {Suffix}, {nameof(Prefix)}: {Prefix}, {nameof(Height)}: {Height}, {nameof(Width)}: {Width}, {nameof(StylesAvailable)}: {StylesAvailable}, {nameof(PlacementType)}: {PlacementType}, {nameof(PreferredPosition)}: {PreferredPosition}, {nameof(Satisfies)}: {Satisfies}, {nameof(Tags)}: {Tags}";
        }

        public bool Equals(PlaceableCatalogEntry other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PlaceableCatalogEntry) obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}
