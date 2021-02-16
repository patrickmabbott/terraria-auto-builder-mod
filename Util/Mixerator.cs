using System;
using System.Collections.Generic;
using System.Linq;
using AutoBuilder.Items;
using AutoBuilder.json;
using AutoBuilder.Model;
using Terraria.ModLoader;

namespace AutoBuilder.Util
{
    /**
     * Responsible for mixing up a provided blueprint's parts in interesting ways.
     * TODO: Consider whether to make most of this class's theme logic populate from a JSON file instead.
     */
    public class Mixerator
    {
        private readonly Blueprint _blueprint;
        private readonly ReplacementStrategy _replacementStrategy;


        private static IDictionary<Tuple<PlaceableCatalogEntry, ThemeDefinitions.Themes>, ISet<TileIdentifier>> IdsByCategoryAndTheme { get; } =
            new Dictionary<Tuple<PlaceableCatalogEntry, ThemeDefinitions.Themes>, ISet<TileIdentifier>>();

        private static IDictionary<TileIdentifier, ISet<ThemeDefinitions.Themes>> ThemesById { get; } =
            new Dictionary<TileIdentifier, ISet<ThemeDefinitions.Themes>>();

        private readonly IDictionary<TileIdentifier, TileIdentifier> _replacements =
            new Dictionary<TileIdentifier, TileIdentifier>();

        /**
         * Where possible, replace things with the same starting prefix with things with the same ending prefix.
         * i.e. if your set includes both an ebonwood bench and an ebonwood lamp and you ask to replace things with SameTheme
         * you'll get a boreal wood bench and a borreal wood lamp, rather than a random wood bench and a random wood lamp.
         */
        private readonly IDictionary<string, string> _prefixReplacements =
            new Dictionary<string, string>();

        private readonly IDictionary<string, ISet<Tuple<TileIdentifier, PlaceableCatalogEntry>>> _prefixToTiles =
            new Dictionary<string, ISet<Tuple<TileIdentifier, PlaceableCatalogEntry>>>();

        readonly Random _random = new Random();

        public List<string> PreferredPrefixes { get; set; } = new List<string>();

        /**
         * Tracks which themes are most common in the blueprint so we can try to either match or invert those themes, as appropriate.
         * This is useful because many items have multiple themes and we want to try choosing the same matching themes as much as possible.
         */
        private List<ThemeDefinitions.Themes> _mostFrequentThemes = new List<ThemeDefinitions.Themes>();

        private void AddToThemes(PlaceableCatalogEntry category, TileIdentifier identifier)
        {
            string name = identifier.Name;
            if (!string.IsNullOrEmpty(name))
            {
                //Go ahead and add it to mapping of prefix to tiles.
                if (!string.IsNullOrEmpty(category.DeterminePrefix(identifier.Name)))
                {
                    MiscUtilities.AddToMultimap(_prefixToTiles, category.DeterminePrefix(identifier.Name),
                        new Tuple<TileIdentifier, PlaceableCatalogEntry>(identifier, category));
                }
                bool foundTheme = false;
                foreach (var themeWords in ThemeDefinitions.MatchIfWordContains)
                {
                    if (themeWords.Value.Any(entry => name.Contains(entry)))
                    {
                        foundTheme = true;
                        Tuple<PlaceableCatalogEntry, ThemeDefinitions.Themes> tuple =
                            new Tuple<PlaceableCatalogEntry, ThemeDefinitions.Themes>(category, themeWords.Key);
                        MiscUtilities.AddToMultimap(IdsByCategoryAndTheme, tuple, identifier);
                        MiscUtilities.AddToMultimap(ThemesById, identifier, themeWords.Key);
                    }
                }

                if (!foundTheme)
                {
                    Tuple<PlaceableCatalogEntry, ThemeDefinitions.Themes> tuple =
                        new Tuple<PlaceableCatalogEntry, ThemeDefinitions.Themes>(category, ThemeDefinitions.Themes.None);
                    MiscUtilities.AddToMultimap(IdsByCategoryAndTheme, tuple, identifier);
                    MiscUtilities.AddToMultimap(ThemesById, identifier, ThemeDefinitions.Themes.None);
                }
            }
        }

        private void PopulateThemes()
        {
            foreach (var pair in DataOrganizer.Instance.PlaceablesByCategory)
            {
                foreach (TileIdentifier tile in pair.Value)
                {
                    AddToThemes(pair.Key, tile);
                }
            }
        }

        public Mixerator(Blueprint blueprint, ReplacementStrategy replacementStrategy)
        {
            this._blueprint = blueprint;
            this._replacementStrategy = replacementStrategy;
            if (IdsByCategoryAndTheme.Count == 0)
            {
                PopulateThemes();
            }
        }

        private ISet<ThemeDefinitions.Themes> calculateAssociatedThemes(string name)
        {
            ISet<ThemeDefinitions.Themes> themes = new HashSet<ThemeDefinitions.Themes>();
            foreach (var themeWords in ThemeDefinitions.MatchIfWordContains)
            {
                if (themeWords.Value.Any(name.Contains))
                {

                    themes.Add(themeWords.Key);
                }
            }

            return themes;
        }

        private enum EntityToReplace
        {
            Block,
            Wall,
            Object
        }

        public IDictionary<TileIdentifier, TileIdentifier> GenerateReplacements()
        {
            CalculateThemeFrequencies();

            foreach (var tile in _blueprint.Tiles)
            {
                Constants.Logger.Info($"Trying to replace object {tile.TileName} {tile.ToPlaceable() == null}");
                if (tile.ToPlaceable()?.CatalogEntry == null || string.IsNullOrEmpty(tile.TileName) || tile.IsExternalBlock)
                {
                    //Only going to try replacing things whose type I can identify. i.e. chairs vs walls.
                    continue;
                }
                ProcessTileEntryForReplacements(tile, EntityToReplace.Object);
            }

            foreach (var tile in _blueprint.Tiles)
            {
                Constants.Logger.Info($"Trying to replace wall {tile.WallName} {tile.ToPlaceable(true) == null}");
                if (tile.ToPlaceable()?.CatalogEntry != null && !string.IsNullOrEmpty(tile.TileName) && tile.IsExternalBlock)
                {
                    ProcessTileEntryForReplacements(tile, EntityToReplace.Block);
                }
                if (tile.ToPlaceable()?.CatalogEntry != null && !string.IsNullOrEmpty(tile.WallName) && tile.HasWall)
                {
                    ProcessTileEntryForReplacements(tile, EntityToReplace.Wall);
                }
            }

            return _replacements;
        }

        private void ProcessTileEntryForReplacements(TileInfo tile, EntityToReplace entityToReplace)
        {
            string name = entityToReplace != EntityToReplace.Wall ? tile.TileName : tile.WallName;
            TileIdentifier id = new TileIdentifier(entityToReplace != EntityToReplace.Wall ? tile.TileId : tile.WallId, 
                tile.Style, entityToReplace == EntityToReplace.Wall, name);
            //Do furniture first because the set of prefixes is much smaller for them.
            //So, the prefix matching will get a much better hit rate then prefixing based on walls or blocks first.

            PlaceableCatalogEntry category = tile.ToPlaceable(entityToReplace == EntityToReplace.Wall).CatalogEntry;
            string prefix = category.DeterminePrefix(name) ?? "";

            Constants.Logger.Info($"prefix for {tile.TileName} {tile.WallName} is {prefix}");

            //If we already have an appropriate prefix matchup.
            bool foundMatchOnPrefix = TryFindMatchOnPrefix(prefix, category, id);
            //No match found for this prefix yet or the chosen prefix map does not have an entry for this item type.
            //Execute the replacement strategy
            if (!foundMatchOnPrefix)
            {
                Constants.Logger.Info($"No prefix match yet. continuing on");
                ExecuteReplacementStrategy(id, category);
            }
        }

        private void ExecuteReplacementStrategy(TileIdentifier id, PlaceableCatalogEntry category)
        {
            if (!ThemesById.TryGetValue(id, out var themes))
            {
                themes = new HashSet<ThemeDefinitions.Themes>() {ThemeDefinitions.Themes.None};
            }

            Constants.Logger.Info($" possible themes include {themes} {themes.FirstOrDefault()}");

            List<ThemeDefinitions.Themes> mostRelevantThemesForThisItem = _mostFrequentThemes.
                Where(t => themes.Contains(t)).ToList();

            Constants.Logger.Info($" relevant themes include {mostRelevantThemesForThisItem} {mostRelevantThemesForThisItem.FirstOrDefault()}");

            if (!mostRelevantThemesForThisItem.Any())
            {
                return;
            }

            //Now, execute the replacement strategy. This should be simple enough, not going to make separate classes for each strategy.
            //But, that is an option if there get to be enough of them or they get complex enough.
            switch (_replacementStrategy)
            {
                case ReplacementStrategy.FullRandom:
                    //Try up to 10 times to find a random theme that has an appropriate match.
                    for (int i = 0; i < 10; i++)
                    {
                        Array values = Enum.GetValues(typeof(ThemeDefinitions.Themes));
                        ThemeDefinitions.Themes randomTheme =
                            (ThemeDefinitions.Themes) values.GetValue(_random.Next(values.Length));
                        if (ProcessPotentialThemeChange(id, category, randomTheme))
                        {
                            break;
                        }
                    }
                    break;
                case ReplacementStrategy.SameTheme:
                    //Find the first entry that shares a theme.
                    foreach (ThemeDefinitions.Themes curTheme in
                        mostRelevantThemesForThisItem)
                    {
                        if (ProcessPotentialThemeChange(id, category, curTheme))
                        {
                            break;
                        }
                    }
                    break;
                case ReplacementStrategy.Inverter:
                    var opposites =
                        new List<Tuple<ThemeDefinitions.Themes, ThemeDefinitions.Themes>>();
                    opposites.AddRange(ThemeDefinitions.Opposites);
                    opposites.Shuffle();
                    bool matchFound = opposites.Any(e =>
                    {
                        ThemeDefinitions.Themes possibleMatch = ThemeDefinitions.Themes.None;
                        if (mostRelevantThemesForThisItem.Contains(e.Item1))
                        {
                            possibleMatch = e.Item2;
                        }
                        else if (mostRelevantThemesForThisItem.Contains(e.Item2))
                        {
                            possibleMatch = e.Item1;
                        }

                        return ProcessPotentialThemeChange(id, category, possibleMatch);
                    });
                    break;
                case ReplacementStrategy.PreferredThemes:

                    List<string> names = ModContent.GetInstance<AutoBuilderConfig>().PreferredThemes.Split(',').ToList();
                    IEnumerable<ThemeDefinitions.Themes> preferredThemes = 
                        Enum.GetValues(typeof(ThemeDefinitions.Themes)).Cast<ThemeDefinitions.Themes>()
                        .Where(e => names.Contains(e.ToString()) );

                    foreach (ThemeDefinitions.Themes curTheme in
                        preferredThemes)
                    {
                        if (ProcessPotentialThemeChange(id, category, curTheme))
                        {
                            break;
                        }
                    }

                    break;
                default:
                    break;
            }
        }

        private bool ProcessPotentialThemeChange(TileIdentifier originalId, PlaceableCatalogEntry category, ThemeDefinitions.Themes possibleTheme)
        {
            var sameThemeAndCategory = new Tuple<PlaceableCatalogEntry, ThemeDefinitions.Themes>(category, possibleTheme);
            Constants.Logger.Info($" looking at cat and theme {category} {possibleTheme}");
            if (IdsByCategoryAndTheme.ContainsKey(sameThemeAndCategory))
            {
                TileIdentifier newTile = MiscUtilities.RandomEntry(IdsByCategoryAndTheme[sameThemeAndCategory]);
                if (newTile != null)
                {
                    ProcessTileReplacement(originalId, category, newTile);
                    return true;
                }
            }

            return false;
        }

        private void ProcessTileReplacement(TileIdentifier id, PlaceableCatalogEntry category, TileIdentifier tile)
        {
            _replacements.Add(id, tile);
            string origPrefix = category.DeterminePrefix(id.Name);
            string replacementPrefix = category.DeterminePrefix(tile.Name);
            //If there's already a registered match for this prefix, ignore. We could make prefix replacements a multimap but that'd add alot of complication for little gain.
            if (!string.IsNullOrEmpty(origPrefix) && !string.IsNullOrEmpty(replacementPrefix) && !_prefixReplacements.ContainsKey(origPrefix))
            {
                _prefixReplacements.Add(origPrefix, replacementPrefix);
            }
        }

        private bool TryFindMatchOnPrefix(string prefix, PlaceableCatalogEntry category, TileIdentifier id)
        {
            bool foundMatchOnPrefix = false;
            if (!string.IsNullOrEmpty(prefix) && _prefixReplacements.ContainsKey(prefix))
            {
                string matchingPrefix = _prefixReplacements[prefix];
                //Find a tile with matching prefix and category. i.e. shadewood bed to mahogany bed.
                if (_prefixToTiles.ContainsKey(matchingPrefix))
                {
                    //Ref comparison is acceptable because both are drawing from the same collection of pre-created category objects.
                    TileIdentifier matchingTileFound =
                        _prefixToTiles[matchingPrefix].FirstOrDefault(e => e.Item2 == category)?.Item1;
                    if (matchingTileFound != null)
                    {
                        _replacements.Add(id, matchingTileFound);
                        foundMatchOnPrefix = true;
                    }
                }
            }
            return foundMatchOnPrefix;
        }

        private void CalculateThemeFrequencies()
        {
            IDictionary<ThemeDefinitions.Themes, int> themeCounts = new Dictionary<ThemeDefinitions.Themes, int>();
            foreach (var tile in _blueprint.Tiles)
            {
                if (!string.IsNullOrEmpty(tile.WallName))
                {
                    foreach (ThemeDefinitions.Themes theme in calculateAssociatedThemes(tile.WallName))
                    {
                        MiscUtilities.AddCountToDictionary(themeCounts, theme, 1);
                    }
                }

                if (!string.IsNullOrEmpty(tile.TileName))
                {
                    foreach (ThemeDefinitions.Themes theme in calculateAssociatedThemes(tile.TileName))
                    {
                        MiscUtilities.AddCountToDictionary(themeCounts, theme, 1);
                    }
                }
            }
            //Now, form an ordered list of themes by frequency.
            var list = themeCounts.Select(entry => new Tuple<ThemeDefinitions.Themes, int>(entry.Key, entry.Value))
                .ToList();
            list.Sort((e1, e2) => e1.Item2.CompareTo(e2.Item2) * -1); //Times -1 b/c we want highest first.
            _mostFrequentThemes = list.Select(e => e.Item1).ToList();
        }
    }
}
