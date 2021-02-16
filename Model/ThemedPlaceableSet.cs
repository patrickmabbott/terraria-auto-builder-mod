using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace AutoBuilder.Items
{
    public class ThemedPlaceableSet
    {
        public string Prefix { get; set; }
        public List<Placeable> Doors { get; set; } = new List<Placeable>();
        public List<Placeable> LightSources { get; set; } = new List<Placeable>();
        public List<Placeable> Comfort { get; set; } = new List<Placeable>();
        public List<Placeable> Surfaces { get; set; } = new List<Placeable>();
        public List<Placeable> Misc { get; set; } = new List<Placeable>();
        public List<Placeable> Walls { get; set; } = new List<Placeable>();
        public List<Placeable> Blocks { get; set; } = new List<Placeable>();
        public bool UseHousingCheat { get; set; }

        /**
         * Checks that this set can form a valid room.
         * @param checkLightSource if false, don't require this set to include a valid light source.
         * This is done because a lot of rooms will use a torch or other thing outside of a themed set.
         */
        public bool IsValidRoom(int requiredWallParts, int requiredBlocks, bool checkLightSource)
        {
            bool allowHousingCheat = ModContent.GetInstance<AutoBuilderConfig>().DisableHousingRequirements;
            return Doors.Any(door => door.AvailableInstances >= 2) &&
                   (!checkLightSource || LightSources.Any() ) &&
                   (Comfort.Any() || allowHousingCheat) &&
                   (Surfaces.Any() || allowHousingCheat) &&
                   Walls.Any(wall => wall.AvailableInstances >= requiredWallParts) &&
                   Blocks.Any(block => block.AvailableInstances >= requiredBlocks);
        }

        //Not including walls, doors and blocks because they are essentially handled separately
        public IList<Placeable> GetAllFurniture()
        {
            return LightSources
                .Concat(Comfort)
                .Concat(Surfaces)
                .Concat(Misc)
                .ToList();
        }
    }
}
