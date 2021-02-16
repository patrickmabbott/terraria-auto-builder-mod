namespace AutoBuilder.json
{
    /**
     * Sole purpose is to hold text because I just couldn't seem to manage to read in json from an embedded resource. Unsure if issue was due to tmodloader or just doing it wrong.
     */
    class PlaceableCatalogText
    {

        public static string text =
@"[
	{
		'Name' :  'Block',
		'Suffix' :  'Block',
		'Height' : 1,
		'Width' : 1,
		'StylesAvailable' :  true,
		'PlacementType' :  'Block',
		'PreferredPosition' :  0,
		'Satisfies' :  ['Block'],
		'Tags' :  []
	},
	{
		'Name' :  'Trap Door',
		'Suffix' :  'Trap Door',
		'Height' : 1,
		'Width' : 2,
		'StylesAvailable' :  false,
		'PlacementType' :  'Block',
		'PreferredPosition' :  0,
		'Satisfies' :  ['Block'],
		'Tags' :  []
	},
	{
		'Name' :  'Platform',
		'Suffix' :  'Platform',
		'Height' : 1,
		'Width' : 1,
		'StylesAvailable' :  true,
		'PlacementType' :  'Block',
		'PreferredPosition' :  0,
		'Satisfies' :  ['Block'],
		'Tags' :  []
	},
	{
		'Name' :  'Wall',
		'Suffix' :  'Wall',
		'Height' : 1,
		'Width' : 1,
		'StylesAvailable' :  true,
		'PlacementType' :  'Wall',
		'PreferredPosition' :  0,
		'Satisfies' :  ['Wall'],
		'Tags' :  []
	},
	{
		'Name' :  'Bar',
		'Suffix' :  'Bar',
		'Height' : 1,
		'Width' : 1,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  0,
		'Satisfies' :  [],
		'Tags' :  ['Fancy', 'Bar']
	},
	{
		'Name' :  'Torch',
		'Suffix' :  'Torch',
		'Height' : 2,
		'Width' : 1,
		'StylesAvailable' :  false, //Variants are available. But, torches don't fall into the same sets as blocks/walls/chairs etc...
		'PlacementType' :  'Wall',
		'PreferredPosition' :  50,
		'Satisfies' :  ['Light'],
		'Tags' :  ['Simple', 'FireHazard']
	},
	{
		'Name' :  'Chair',
		'Suffix' :  'Chair',
		'Height' : 2,
		'Width' : 1,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  50,
		'Satisfies' :  ['Comfort'],
		'Tags' :  ['Simple', 'Seat']
	},
	{
		'Name' :  'Bathtub',
		'Suffix' :  'Bathtub',
		'Height' : 2,
		'Width' : 4,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  40,
		'Satisfies' :  ['Surface'],
		'Tags' :  ['Bathroom']
	},
	{
		'Name' :  'Bed',
		'Suffix' :  'Bed',
		'Height' : 4,
		'Width' : 2,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  30,
		'Satisfies' :  ['Comfort'],
		'Tags' :  ['Bedroom']
	},
	{
		'Name' :  'Campfire',
		'Suffix' :  'Campfire',
		'Height' : 1,
		'Width' : 3,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  30,
		'Satisfies' :  ['Light'],
		'Tags' :  ['Nature', 'Pretty']
	},
	{
		'Name' :  'Bookcase',
		'Suffix' :  'Bookcase',
		'Height' : 4,
		'Width' : 3,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  65,
		'Satisfies' :  ['Surface'],
		'Tags' :  ['Fancy','Library', 'Container']
	},
	{
		'Name' :  'Chandelier',
		'Suffix' :  'Chandelier',
		'Height' : 3,
		'Width' : 3,
		'StylesAvailable' :  true,
		'PlacementType' :  'Ceiling',
		'PreferredPosition' :  50,
		'Satisfies' :  ['Light'],
		'Tags' :  ['Fancy', 'Pretty']
	},
	{
		'Name' :  'Clock',
		'Suffix' :  'Clock',
		'Height' : 5,
		'Width' : 2,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  20,
		'Satisfies' :  [],
		'Tags' :  ['Fancy', 'Art']
	},
	{
		'Name' :  'Dresser',
		'Suffix' :  'Dresser',
		'Height' : 2,
		'Width' : 3,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  15,
		'Satisfies' :  ['Surface'],
		'Tags' :  ['Bedroom','Container']
	},
	{
		'Name' :  'Piano',
		'Suffix' :  'Piano',
		'Height' : 2,
		'Width' : 3,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  80,
		'Satisfies' :  ['Surface'],
		'Tags' :  ['Fancy', 'Pretty']
	},
	{
		'Name' :  'Sofa',
		'Suffix' :  'Sofa',
		'Height' : 2,
		'Width' : 3,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  70,
		'Satisfies' :  ['Comfort'],
		'Tags' :  ['Fancy', 'Seat']
	},
	{
		'Name' :  'Bench',
		'Suffix' :  'Bench',
		'Height' : 2,
		'Width' : 3,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  70,
		'Satisfies' :  ['Comfort'],
		'Tags' :  ['Fancy', 'Seat']
	},
	{
		'Name' :  'Toilet',
		'Suffix' :  'Toilet',
		'Height' : 2,
		'Width' : 1,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  75,
		'Satisfies' :  ['Comfort'],
		'Tags' :  ['Bathroom']
	},
	{
		'Name' :  'Candelabra',
		'Suffix' :  'Candelabra',
		'Height' : 2,
		'Width' : 2,
		'StylesAvailable' :  true,
		'PlacementType' :  'Atop',
		'PreferredPosition' :  50,
		'Satisfies' :  ['Light'],
		'Tags' :  ['Fancy', 'FireHazard']
	},
	{
		'Name' :  'Chest',
		'Suffix' :  'Chest',
		'Height' : 2,
		'Width' : 2,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  50,
		'Satisfies' :  [],
		'Tags' :  ['Container', 'Fancy']
	},
	{
		'Name' :  'Door',
		'Suffix' :  'Door',
		'Height' : 3,
		'Width' : 2,
		'StylesAvailable' :  true,
		'PlacementType' :  'Door',
		'PreferredPosition' :  0,
		'Satisfies' :  ['Door'],
		'Tags' :  []
	},
	{
		'Name' :  'Lamp',
		'Suffix' :  'Lamp',
		'Height' : 3,
		'Width' : 1,
		'StylesAvailable' :  true,
		'PlacementType' :  'Atop',
		'PreferredPosition' :  50,
		'Satisfies' :  ['Light'],
		'Tags' :  []
	},
	{
		'Name' :  'Lantern',
		'Suffix' :  'Lantern',
		'Height' : 2,
		'Width' : 1,
		'StylesAvailable' :  true,
		'PlacementType' :  'Ceiling',
		'PreferredPosition' :  50,
		'Satisfies' :  ['Light'],
		'Tags' :  []
	},
	{
		'Name' :  'Sink',
		'Suffix' :  'Sink',
		'Height' : 2,
		'Width' : 2,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  30,
		'Satisfies' :  [],
		'Tags' :  ['Bathroom']
	},
	{
		'Name' :  'Table',
		'Suffix' :  'Table',
		'Height' : 2,
		'Width' : 3,
		'StylesAvailable' :  true,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  20,
		'Satisfies' :  ['Surface'],
		'Tags' :  ['Simple']
	},
	{
		'Name' :  'Cage',
		'Suffix' :  'Cage',
		'Height' : 3,
		'Width' : 6,
		'StylesAvailable' :  false,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  70,
		'Satisfies' :  [],
		'Tags' :  ['Trophy', 'Nature','Cute', 'Pretty']
	},
	{
		'Name' :  'Trophy',
		'Suffix' :  'Trophy',
		'Height' : 3,
		'Width' : 3,
		'StylesAvailable' :  false,
		'PlacementType' :  'Wall',
		'PreferredPosition' :  30,
		'Satisfies' :  [],
		'Tags' :  ['Fancy','Trophy']
	},
	{
		'Name' :  'Banner',
		'Suffix' :  'Banner',
		'Height' : 1,
		'Width' : 3,
		'StylesAvailable' :  false,
		'PlacementType' :  'Wall',
		'PreferredPosition' :  20,
		'Satisfies' :  [],
		'Tags' :  ['Military', 'Fancy','Trophy', 'Pretty', 'Art']
	},
	{
		'Name' :  'Rack',
		'Suffix' :  'Rack',
		'Height' : 3,
		'Width' : 3,
		'StylesAvailable' :  false,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  80,
		'Satisfies' :  [],
		'Tags' :  ['Military', 'Fancy','Trophy']
	},
	{
		'Name' :  'Throne',
		'Suffix' :  'Throne',
		'Height' : 4,
		'Width' : 3,
		'StylesAvailable' :  false,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  10,
		'Satisfies' :  ['Comfort'],
		'Tags' :  ['Fancy', 'Seat']
	},
	{
		'Name' :  'Coral',
		'Suffix' :  'Coral',
		'Height' : 2,
		'Width' : 1,
		'StylesAvailable' :  false,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  30,
		'Satisfies' :  [],
		'Tags' :  ['Exotic', 'Nature', 'Pretty']
	},
	{
		'Name' :  'Statue',
		'Suffix' :  'Statue',
		'Height' : 3,
		'Width' : 2,
		'StylesAvailable' :  false,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  70,
		'Satisfies' :  [],
		'Tags' :  ['Fancy', 'Trophy', 'Art', 'Pretty']
	},
	{
		'Name' :  'Painting',
		'Suffix' :  'Misc',
		'Height' : 4,
		'Width' : 6,
		'StylesAvailable' :  false,
		'PlacementType' :  'Wall',
		'PreferredPosition' :  30,
		'Satisfies' :  [],
		'Tags' :  ['Fancy', 'Art', 'Pretty']
	},
	{
		'Name' :  'Hanging Plant',
		'Suffix' :  '',
		'Prefix' :  'Hanging',
		'Height' : 3,
		'Width' : 2,
		'StylesAvailable' :  false,
		'PlacementType' :  'Ceiling',
		'PreferredPosition' :  10,
		'Satisfies' :  [],
		'Tags' :  ['Plant', 'Nature', 'Pretty']
	},
	{
		'Name' :  'Mannequin',
		'Suffix' :  'Mannequin',
		'Height' : 3,
		'Width' : 2,
		'StylesAvailable' :  false,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  20,
		'Satisfies' :  [],
		'Tags' :  ['Trophy','Pretty']
	},
	{
		'Name' :  'Womannequin',
		'Suffix' :  'Womannequin',
		'Height' : 3,
		'Width' : 2,
		'StylesAvailable' :  false,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  20,
		'Satisfies' :  [],
		'Tags' :  ['Trophy', 'Pretty']
	},
	{
		'Name' :  'Target Dummy',
		'Suffix' :  'Dummy',
		'Height' : 3,
		'Width' : 2,
		'StylesAvailable' :  false,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  15,
		'Satisfies' :  [],
		'Tags' :  ['Military']
	},
	{
		'Name' :  'Fountain',
		'Suffix' :  'Fountain',
		'Height' : 4,
		'Width' : 2,
		'StylesAvailable' :  false,
		'PlacementType' :  'Floor',
		'PreferredPosition' :  0,
		'Satisfies' :  [],
		'Tags' :  ['Fancy', 'Pretty', 'Art', 'Nature', 'Magic']
	},
]";

    }
}
