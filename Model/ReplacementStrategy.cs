
namespace AutoBuilder.Model
{
    /**
     * Strategy to use for replacing parts with equivalent parts in replication.
     */
    public enum ReplacementStrategy
    {
        /**
         * No replacement. Exact copy-paste
         */
        None,
        /**
         * Attempts, if possible, to place something that matches the original entry's theme.
         */
        SameTheme,
        /**
         * Replace all instances of a specific item with no consideration for style.
         */
        FullRandom,
        /**
         * Same as RandomBiased only strongly biased *towards* replacing with opposite.
         */
        Inverter,
        /**
         * Try to change each entry to one from a set of themes, provided in priority order.
         */
        PreferredThemes //,
        /**
         * Ignore the theme system and specify exactly the prefixes you want. i.e. Iron or Ebonstone instead of a theme like Metals.
         */
        //PreferredPrefixes,
        /**
         * Replace items from inventory. The most common block will be replaced by the first block in your inventory,
         * second most common with second block, most common chair with first chair etc...
         */
        //Inventory,
        /**
         * Same as inventory but will draw on significantly larger selection of replacement parts from specific chests near spawn point.
         */
        //InventoryAndChests
    }
}
