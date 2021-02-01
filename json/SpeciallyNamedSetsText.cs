namespace AutoBuilder.json
{
    /**
     * Sole purpose is to hold text because I just couldn't seem to manage to read in json from an embedded resource. Unsure if issue was due to tmodloader or just doing it wrong.
     */
    class SpeciallyNamedSetsText
    {

        public static string text =
@"[
	{
		'WallName' :  'Ice Wall',
        'BlockName' :  'Ice Block',
        'FurniturePrefix' :  'Frozen'

    },
    {
    'WallName' :  'Disc Wall',
    'BlockName' :  'Sunplate Block',
    'FurniturePrefix' :  'Skyware'
},
{
    'WallName' :  'Wood Wall',
    'BlockName' :  'Wood',
    'FurniturePrefix' : ''
},
{
    'WallName' :  'Smooth Marble Wall',
    'BlockName' :  'Smooth Marble Block',
    'FurniturePrefix' : 'Marble'
},
{
    'WallName' :  'Smooth Granite Wall',
    'BlockName' :  'Smooth Granite Block',
    'FurniturePrefix' : 'Granite'
},
{
    'WallName' :  'Cog Wall',
    'BlockName' :  'Cog',
    'FurniturePrefix' : 'Steampunk'
}
]";

    }
}
