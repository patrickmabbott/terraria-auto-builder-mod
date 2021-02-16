using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace AutoBuilder.Items
{
    /**
     * Utility class in charge of organizing information concerning placeables and the sets that they form.
     * Generally takes as input player inventory, configuration/description files, and user design preference specs.
     */
    public class PlaceableOrganizer
    {
        private Player player;

        private static readonly string MISC_ROOM_SET = "misc";

        private static Random rng = new Random();

        public PlaceableOrganizer(Player player)
        {
            this.player = player;
        }

        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public IDictionary<String, ThemedPlaceableSet> PossibleRoomSets { get; set; } = new Dictionary<String, ThemedPlaceableSet>();
        //Contains all placeables, those that are part of a style set and those that aren't alike.

        private static bool IsItemAllowed(Placeable placeable, RoomSpecification roomSpec,
            IList<Placeable> duplicatePlaceables = null, bool requiredOnly = false, bool allowNonDisabled = false)
        {
            return (duplicatePlaceables == null || !duplicatePlaceables.Contains(placeable)) &&
                   (
                       (
                           allowNonDisabled || //In the most desperate case, allow anything that isn't explicitly disallowed.
                           (placeable.CatalogEntry.Tags.Intersect(roomSpec.RequiredTags).Any()) ||
                           (!requiredOnly && (!roomSpec.AllowedTags.Any() ||
                                              placeable.CatalogEntry.Tags.Intersect(roomSpec.AllowedTags).Any()))
                            
                        )

                   )
                   && !placeable.CatalogEntry.Tags.Intersect(roomSpec.DisallowedTags).Any();
        }

        private static Func<Placeable, bool> IsItemAllowedLambda(RoomSpecification roomSpec,
            IList<Placeable> duplicatePlaceables = null, bool requiredOnly = false, bool allowNonDisabled = false)
        {
            return (placeable) => IsItemAllowed(placeable, roomSpec, duplicatePlaceables, requiredOnly, allowNonDisabled);
        }

        /**
         * Finds a room/set combination that can be placed.
         * @param desiredSize How large you want the room to be. If either length or height is less than 1, it'll default to standard size of chosen room.
         */
        public IList<Tuple<ThemedPlaceableSet, RoomSpecification>> FindPlaceableRooms(IEnumerable<string> desiredRooms,
            Vector2 desiredSize, bool useFurnitureSets = true)
        {
            IList<RoomSpecification> potentialRooms;

            List<Tuple<ThemedPlaceableSet, RoomSpecification>> roomSets =
                new List<Tuple<ThemedPlaceableSet, RoomSpecification>>();

            var enumerable = desiredRooms == null ? new List<string>(){} :  desiredRooms.ToList();
            if (!enumerable.Any())
            {
                //Then all rooms are on the table.
                //Poor man's clone because we are going to be changing this list in-place.
                potentialRooms = new List<RoomSpecification> (Constants.GetRoomSpecs());
            }
            else
            {
                potentialRooms = new List<RoomSpecification>();
                foreach (RoomSpecification spec in Constants.GetRoomSpecs())
                {
                    if (enumerable.Contains(spec.Name))
                    {
                        potentialRooms.Add(spec);
                    }
                }
            }

            if (ModContent.GetInstance<AutoBuilderConfig>().DisabledRoomTypes.Any())
            {
                potentialRooms = potentialRooms.Where(entry => 
                    !ModContent.GetInstance<AutoBuilderConfig>().
                        DisabledRoomTypes.Split(',').ToList().Contains(entry.Name)).ToList();
            }

            //Go ahead and randomize order so we don't always get the same room type.
            Shuffle(potentialRooms);

            foreach (RoomSpecification roomSpec in potentialRooms)
            {
                Vector2 size = desiredSize.X >= 1 && desiredSize.Y >= 1
                    ? desiredSize
                    : new Vector2(roomSpec.Width, roomSpec.Height);
                List<Placeable> requiredMiscPlaceables = new List<Placeable>();
                List<Placeable> desirableMiscPlaceables = new List<Placeable>();
                //Figure out if this room spec can be built
                ThemedPlaceableSet subset = new ThemedPlaceableSet();

                //First off, try to cover required item tags via the misc item collection. Then, look for a themed item set that covers the rest.

                ThemedPlaceableSet miscSet = PossibleRoomSets[MISC_ROOM_SET];
                IList<Placeable> allPlaceables = miscSet.GetAllFurniture();
                Shuffle(allPlaceables);

                if (useFurnitureSets)
                {
                    //Find placeables for which there is a set intersection between their tags and required tags.
                    //i.e. at least one tag on placeable is within the required tag set.
                    requiredMiscPlaceables.AddRange(
                allPlaceables.Where(IsItemAllowedLambda(roomSpec, requiredOnly: true))
                    );

                    //Now go ahead and find nice to have placeables while we're at it.

                    desirableMiscPlaceables.AddRange(
            allPlaceables.Where(IsItemAllowedLambda(roomSpec, duplicatePlaceables: requiredMiscPlaceables))
                    );
                }

                //Now, look in the themed sets to cover the rest of our needs.
                foreach (ThemedPlaceableSet curSet in PossibleRoomSets.Values)
                {
                    if (useFurnitureSets && curSet.Prefix == MISC_ROOM_SET)
                    {
                        continue;
                    }

                    List<Placeable> requiredPlaceables = curSet.GetAllFurniture()
                        .Where(IsItemAllowedLambda(roomSpec, requiredOnly: true)).ToList();

                    if (useFurnitureSets)
                    {
                        requiredPlaceables.AddRange(requiredMiscPlaceables);
                    }
                    Shuffle(requiredPlaceables);

                    //Does the total # of required tagged items equal at least that required of the room? If not, we can reject right now.
                    if (requiredPlaceables.Count < roomSpec.RequiredTagsCount)
                    {
                        Constants.Logger.Warn($"Found {requiredPlaceables.Count} required placeables. Less than {roomSpec.RequiredTagsCount}");
                        continue;
                    }

                    //If we don't already have the light requirement covered through required furniture.
                    if (!requiredPlaceables.Any(entry => entry.CatalogEntry.Satisfies.Contains(Constants.SATISFIES_LIGHT)))
                    {
                        //Prefer light sources from themed set that are allowed.
                        if (curSet.LightSources.Any(IsItemAllowedLambda(roomSpec)))
                        {
                            subset.LightSources.Add(curSet.LightSources.First(IsItemAllowedLambda(roomSpec)));
                        } //If that fails, find misc light sources that are allowed.
                        else if (useFurnitureSets && miscSet.LightSources.Any(IsItemAllowedLambda(roomSpec)))
                        {
                            subset.LightSources.Add(miscSet.LightSources.First(IsItemAllowedLambda(roomSpec)));
                        } //If absolutely necessary, break the room's allowed tags rule and just take the first light source not disallowed
                        else if (curSet.LightSources.Any())
                        {
                            subset.LightSources.Add(curSet.LightSources.First(IsItemAllowedLambda(roomSpec, allowNonDisabled: true)));
                        }
                        else if(useFurnitureSets)
                        {
                            subset.LightSources.Add(miscSet.LightSources.First(IsItemAllowedLambda(roomSpec, allowNonDisabled: true)));
                        }
                        else
                        {
                            break;
                        }
                    }

                    subset.Blocks.Add(curSet.Blocks.First(entry => !requiredPlaceables.Contains(entry)));

                    subset.Walls.Add(curSet.Walls.First(entry => !requiredPlaceables.Contains(entry)));

                    if (!requiredPlaceables.Any(entry =>
                        entry.CatalogEntry.Satisfies.Contains(Constants.SATISFIES_COMFORT)))
                    {
                        if (curSet.Comfort.Any(IsItemAllowedLambda(roomSpec)))
                        {
                            subset.Comfort.Add(curSet.Comfort.First(IsItemAllowedLambda(roomSpec)));
                        } //If that fails, find seat that is not allowed but atleast isn't disallowed.
                        else if (ModContent.GetInstance<AutoBuilderConfig>().DisableHousingRequirements)
                        {
                            subset.UseHousingCheat = true;
                        }
                        else if(curSet.Comfort.Any(IsItemAllowedLambda(roomSpec, allowNonDisabled: true)))
                        {
                            subset.Comfort.Add(curSet.Comfort.First(IsItemAllowedLambda(roomSpec, allowNonDisabled: true)));
                        }
                        else
                        {
                            break;
                        }
                    }

                    subset.Doors.Add(curSet.Doors.First(entry => !requiredPlaceables.Contains(entry)));

                    if (!requiredPlaceables.Any(entry =>
                        entry.CatalogEntry.Satisfies.Contains(Constants.SATISFIES_SURFACE)))
                    {
                        if (curSet.Surfaces.Any(IsItemAllowedLambda(roomSpec)))
                        {
                            subset.Surfaces.Add(curSet.Surfaces.First(IsItemAllowedLambda(roomSpec)));
                        }
                        else if (ModContent.GetInstance<AutoBuilderConfig>().DisableHousingRequirements)
                        {
                            subset.UseHousingCheat = true;
                        }
                        else if(curSet.Surfaces.Any(IsItemAllowedLambda(roomSpec, allowNonDisabled: true)))
                        {
                            subset.Surfaces.Add(curSet.Surfaces.First(IsItemAllowedLambda(roomSpec, allowNonDisabled: true)));
                        }
                        else
                        {
                            break;
                        }
                    }

                    //Get the first n items from required (where n is how many the room requires)
                    subset.Misc.AddRange(requiredPlaceables.GetRange(0, roomSpec.RequiredTagsCount));

                    //Now, try to add up to fill the rest of the space somewhat.
                    List<Placeable> placeablesPool = curSet.GetAllFurniture()
                        .Where(IsItemAllowedLambda(roomSpec, duplicatePlaceables: subset.GetAllFurniture())).ToList();

                    placeablesPool.AddRange(requiredPlaceables.Skip(roomSpec.RequiredTagsCount));
                    if (useFurnitureSets)
                    {
                        placeablesPool.AddRange(desirableMiscPlaceables);
                    }

                    //Remove any items from placeable pool that are already in required or 

                    Shuffle(placeablesPool);

                    //Put together all the remaining candidates for required placeables and the desired ones and shuffled em.
                    //-8 because 2 for wall and ceiling and 3 each reserved for ceiling and floor placement zones.
                    int numWallRegions = Math.Max((int) (size.Y - 8) / 4, 1);

                    Dictionary<string, int> spaceCoveredAtLayer = new Dictionary<string, int>
                    {
                        { PlaceableCatalogEntry.PLACEMENT_CEILING, 0 },
                        { PlaceableCatalogEntry.PLACEMENT_FLOOR, 0 }
                    };

                    List<int> wallRegions = new List<int>() {};
                    //TODO: See if there's a more elegant way of padding a list.
                    for (int i = 0; i < numWallRegions; i++)
                    {
                        wallRegions.Add(0);
                    }

                    
                    foreach (Placeable curFurniture in subset.GetAllFurniture())
                    {
                        if (curFurniture.CatalogEntry.PlacementType == PlaceableCatalogEntry.PLACEMENT_WALL)
                        {
                            wallRegions[0] += 1 + curFurniture.CatalogEntry.Width;
                        }
                        else
                        {
                            spaceCoveredAtLayer[curFurniture.CatalogEntry.PlacementType] += 1 + curFurniture.CatalogEntry.Width;
                        }
                    }
                    foreach (Placeable curFurniture in placeablesPool)
                    {

                        if (curFurniture.CatalogEntry.PlacementType == PlaceableCatalogEntry.PLACEMENT_WALL)
                        {
                            //Go through wall regions til we find one with space.
                            //If none do, skip it.
                            for (int i = 0; i < wallRegions.Count; i++)
                            {
                                if ((float)wallRegions[i] / size.X < .7)
                                {
                                    subset.Misc.Add(curFurniture);
                                    wallRegions[i] += 1 + curFurniture.CatalogEntry.Width;
                                    break;
                                }
                            }
                        }
                        else if ((float)spaceCoveredAtLayer[curFurniture.CatalogEntry.PlacementType] / size.X < .7)
                        {
                            //Try to fill each of these up to 70% capacity so it's not too crowded.
                            subset.Misc.Add(curFurniture);
                            spaceCoveredAtLayer[curFurniture.CatalogEntry.PlacementType] += 1 + curFurniture.CatalogEntry.Width;
                        }
                    }

                    roomSets.Add(new Tuple<ThemedPlaceableSet, RoomSpecification>(subset, roomSpec));
                    break;
                }
            }

            if (!roomSets.Any())
            {
                Constants.Logger.Warn($"Could not find a buildable room");
            }
            return roomSets;
        }

        /**
         * Determines which furniture sets are available (or, in the case of not using furniture sets, all of it just goes into misc.
         */
        public bool DetermineAvailableThemedSets(bool useFurnitureSets = true)
        {
            //First pass, look for furniture items
            //Then, do a second pass to see if we can pick up stuff like "glass" as a viable block/brick type.
            List<string> itemsAlreadyCategorized = new List<string>();
            PossibleRoomSets.Add(MISC_ROOM_SET, new ThemedPlaceableSet() { Prefix = MISC_ROOM_SET });
            foreach (Item item in player.inventory)
            {
                if (item.createTile > -1 || item.createWall > -1)
                {
                    int tileId = item.createTile > -1 ? item.createTile : item.createWall;
                    //Do check for blocks/walls if not using sets because we can't use knowledge
                    //of the prefix of the rest of the set to try identifying blocks/walls.
                    bool checkForBlock = !useFurnitureSets;
                    foreach (PlaceableCatalogEntry entry in Constants.GetCatalogEntries().Values)
                    {
                        if (!checkForBlock && (entry.Name == "Wall" || entry.Name == "Block"))
                        {
                            //Just more consistent to use the below algorithm for walls/blocks.
                            continue;
                        }
                        if (entry.IsMember(item, checkForBlock))
                        {
                            string prefix = entry.DeterminePrefix(item);

                            if ( entry.StylesAvailable && 
                                !prefix.Any() && 
                                !(entry.Name == "Wall" || entry.Name == "Block") )
                            {
                                continue;
                            }
                            Placeable newPlaceable = new Placeable(item.Name, tileId, tileId,
                                item.placeStyle, entry, item.stack);
                            ThemedPlaceableSet curThemedPlaceableSet;
                            if (useFurnitureSets && entry.StylesAvailable)
                            {
                                if (!prefix.Any())
                                {
                                    curThemedPlaceableSet = PossibleRoomSets[MISC_ROOM_SET];
                                }
                                else if (!PossibleRoomSets.ContainsKey(prefix))
                                {
                                    curThemedPlaceableSet = new ThemedPlaceableSet() { Prefix = prefix };
                                    PossibleRoomSets.Add(prefix, curThemedPlaceableSet);
                                }
                                else
                                {
                                    curThemedPlaceableSet = PossibleRoomSets[prefix];
                                }
                                
                            }
                            else //Misc items that are not styled get their own room set.
                            {
                                curThemedPlaceableSet = PossibleRoomSets[MISC_ROOM_SET];
                            }

                            itemsAlreadyCategorized.Add(item.Name);
                            if (entry.Satisfies.Contains(Constants.SATISFIES_LIGHT))
                            {
                                curThemedPlaceableSet?.LightSources.Add(newPlaceable);
                            }
                            else if (entry.Satisfies.Contains(Constants.SATISFIES_COMFORT))
                            {
                                curThemedPlaceableSet?.Comfort.Add(newPlaceable);
                            }
                            else if (entry.Satisfies.Contains(Constants.SATISFIES_SURFACE))
                            {
                                curThemedPlaceableSet?.Surfaces.Add(newPlaceable);
                            }
                            else if (entry.Satisfies.Contains(Constants.SATISFIES_DOOR))
                            {
                                curThemedPlaceableSet?.Doors.Add(newPlaceable);
                            }
                            else if (entry.Satisfies.Contains(Constants.SATISFIES_BLOCK))
                            {
                                curThemedPlaceableSet?.Blocks.Add(newPlaceable);
                            }
                            else if (entry.Satisfies.Contains(Constants.SATISFIES_WALL))
                            {
                                curThemedPlaceableSet?.Walls.Add(newPlaceable);
                            }
                            else
                            {
                                curThemedPlaceableSet?.Misc.Add(newPlaceable);
                            }
                        }
                    }
                }
            }

            //Now that we have cataloged all of the room sets based on furniture and standard-named walls/blocks,
            //go through all of them (other than misc)
            //and try to find blocks/bricks/walls that belong in that set but weren't spotted because of a non-standard naming convention.

            //Only helpful if using furniture sets. Otherwise, we use somewhat less reliable approach to look for blocks directly.
            if (useFurnitureSets)
            {
                foreach (Item item in player.inventory)
                {
                    //If we've already covered it, skip.
                    if (itemsAlreadyCategorized.Contains(item.Name))
                    {
                        continue;
                    }
                    if (item.createTile > -1 || item.createWall > -1)
                    {
                        int tileId = item.createTile > -1 ? item.createTile : item.createWall;
                        foreach (ThemedPlaceableSet curRoomSet in PossibleRoomSets.Values)
                        {
                            if (curRoomSet.Prefix == MISC_ROOM_SET)
                            {
                                continue;
                            }

                            //Firstly, check specially named sets to see if we are looking for a wall/block with a completely different
                            //prefix for the brick/wall vice the furniture.
                            if (Constants.GetSpeciallyNamedSets().ContainsKey(curRoomSet.Prefix))
                            {
                                if (item.Name.StartsWith(Constants.GetSpeciallyNamedSets()[curRoomSet.Prefix].BlockName))
                                {
                                    //Find the block entry in placeableCatalogEntries.
                                    PlaceableCatalogEntry entry = Constants.GetCatalogEntries()["Block"];
                                    Placeable newPlaceable = new Placeable(item.Name, tileId, 0,
                                        item.placeStyle, entry, item.stack);
                                    curRoomSet.Blocks.Add(newPlaceable);
                                }
                                else if (item.Name.StartsWith(Constants.GetSpeciallyNamedSets()[curRoomSet.Prefix].WallName)
                                )
                                {
                                    //Find the block entry in placeableCatalogEntries.
                                    PlaceableCatalogEntry entry = Constants.GetCatalogEntries()["Wall"];
                                    Placeable newPlaceable = new Placeable(item.Name, 0, tileId,
                                        item.placeStyle, entry, item.stack);
                                    curRoomSet.Walls.Add(newPlaceable);
                                }
                            }
                            else
                            {
                                if (item.Name.StartsWith(curRoomSet.Prefix))
                                {
                                    if (item.Name.EndsWith("Wall"))
                                    {
                                        PlaceableCatalogEntry entry = Constants.GetCatalogEntries()["Wall"];
                                        Placeable newPlaceable = new Placeable(item.Name, 0, tileId,
                                            item.placeStyle, entry, item.stack);
                                        curRoomSet.Walls.Add(newPlaceable);
                                    }
                                    else
                                    {
                                        PlaceableCatalogEntry entry = Constants.GetCatalogEntries()["Block"];
                                        bool isBlock = item.Name.Trim() == curRoomSet.Prefix;
                                        isBlock |= entry.IsMember(item, true);

                                        if (isBlock)
                                        {
                                            Placeable newPlaceable = new Placeable(item.Name, tileId, 0,
                                                item.placeStyle, entry, item.stack);
                                            curRoomSet.Blocks.Add(newPlaceable);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //For each of the sets, go ahead and shuffle the order of all of the placeables so we don't get the same room layout every time.

            foreach (ThemedPlaceableSet curSet in PossibleRoomSets.Values.ToList())
            {
                Shuffle(curSet.Blocks);
                Shuffle(curSet.Walls);
                Shuffle(curSet.Comfort);
                Shuffle(curSet.LightSources);
                Shuffle(curSet.Doors);
                Shuffle(curSet.Surfaces);
                Shuffle(curSet.Misc);
            }
            //We only need the themed set to for sure provide light if the misc set does not do so.
            bool needLightSourceFromThemedSet = !useFurnitureSets || !PossibleRoomSets[MISC_ROOM_SET].LightSources.Any();
            //Now, go ahead and reject any room sets that do not satisfy the basic requirements of a room. e.g. CSLD
            //Going to ignore the light requirement for now because we'll often get that via torches.
            
            //Remove sets that are not valid.
            if (useFurnitureSets)
            {
                PossibleRoomSets =
                    PossibleRoomSets.Where( (KeyValuePair<string, ThemedPlaceableSet>entry) =>
                        entry.Key == MISC_ROOM_SET || 
                        entry.Value.IsValidRoom(50, 30, needLightSourceFromThemedSet)
                    ).ToDictionary(entry => entry.Key,
                        entry => entry.Value);
                //To have a viable option, need the misc set and at least one themed set. So, 2.
                return PossibleRoomSets.Count >= 2;
            }
            else
            {
                //In this case, just check the whole misc set.
                return PossibleRoomSets[MISC_ROOM_SET].IsValidRoom(50, 30, true);
            }
        }
    }
}
