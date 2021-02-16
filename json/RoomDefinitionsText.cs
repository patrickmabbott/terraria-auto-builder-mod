namespace AutoBuilder.json
{
    /**
     * Sole purpose is to hold text because I just couldn't seem to manage to read in json from an embedded resource. Unsure if issue was due to tmodloader or just doing it wrong.
     */
    class RoomDefinitionsText
    {

        public static string text =
@"[
	{
		'TileName' :  'Random',
        'RequiredTags' :  [],
        'RequiredTagsCount' : 0,
        'AllowedTags' :  [],
        'Width' : 20,
        'Height' : 12
    },
    {
    'TileName' :  'Bathroom',
    'RequiredTags' :  ['Bathroom'],
    'RequiredTagsCount' :  2,
    'AllowedTags' :  ['Bathroom', 'Pretty'],
    'Width' : 20,
    'Height' : 24
},
{
    'TileName' :  'Bedroom',
    'RequiredTags' :  ['Bed','Dresser'],
    'RequiredTagsCount' :  2,
    'AllowedTags' :  ['Bedroom', 'Container', 'Art', 'Seat'],
    'DisallowedTags' :  ['Bathroom'],
    'Width' : 20,
    'Height' : 24
},
{
    'TileName' :  'Library',
    'RequiredTags' :  ['Bookcase'],
    'RequiredTagsCount' :  1,
    'AllowedTags' :  ['Library', 'Art'],
    'DisallowedTags' :  ['FireHazard'],
    'Width' : 30,
    'Height' : 24
},
{
    'TileName' :  'Display Room',
    'RequiredTags' : ['Art', 'Trophy'],
    'RequiredTagsCount' : 2,
    'AllowedTags' :  ['Art','Trophy', 'Fancy'],
    'DisallowedTags' :  ['Bathroom','Bedroom'],
    'Width' : 30,
    'Height' : 24
},
{
    'TileName' :  'Nature Preserve',
    'RequiredTags' :  ['Nature'],
    'RequiredTagsCount' :  1,
    'AllowedTags' :  ['Nature', 'Pretty'],
    'DisallowedTags' :  ['Bathroom','Bedroom'],
    'Width' : 60,
    'Height' : 12
},
{
    'TileName' :  'Armory',
    'RequiredTags' :  ['Military'],
    'RequiredTagsCount' :  1,
    'AllowedTags' :  ['Military', 'Trophy'],
    'DisallowedTags' :  ['Bathroom','Bedroom'],
    'Width' : 30,
    'Height' : 24
}
]";

    }
}
