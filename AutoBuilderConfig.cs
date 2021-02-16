using System;
using System.ComponentModel;
using AutoBuilder.Items;
using Terraria.ModLoader.Config;

namespace AutoBuilder
{
    public class AutoBuilderConfig : ModConfig
    {
        // You MUST specify a ConfigScope.
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        [Label("Consume items used to build?")]
        [Tooltip("Consume items used to build rooms. Might want to leave this off.\nCan't guarantee the mod won't consume items and not succeed in loading them for some modded furniture.")]
        public bool DoConsumeResources { get; set; }

        [DefaultValue("")]
        [Tooltip("By default, only blocks that ending in 'block', 'brick', 'wood' etc.. are recognized.\nAdd extra block names like 'cloud' or 'glass' here ")]
        public String AdditionalBlockNames { get; set; }

        [DefaultValue(false)]
        [Label("Use Default Size For Rooms?")]
        [Tooltip("Some rooms (e.g. display gallery) are larger than others (e.g. bedroom).\nUse false to make all standalone rooms a given size")]
        public bool UseDefaultSize { get; set; }

        [DefaultValue(20)]
        [Label("Default Room Width")]
        public int DefaultRoomWidth { get; set; }

        [DefaultValue(12)]
        [Label("Default Room Height")]
        public int DefaultRoomHeight { get; set; }

        [Label("Disabled Room Types")]
        [Tooltip("Room types to not try making")]
        public string DisabledRoomTypes { get; set; }

        [DefaultValue(true)]
        [Label("Disable Chair/Table Requirement")]
        [Tooltip("Disables chair/table housing requirement when furniture cannot be found that fits a room.\nDoes so via an invisible token that satisfies these requirements")]
        public bool DisableHousingRequirements { get; set; }

        [DefaultValue("Building 1, Building 2, Building 3, Building 4, Building 5, Building 6")]
        [Label("Custom Building Names")]
        [Tooltip("Names for custom blueprinted buildings. Separate names with commas.\n e.g. Castle,Super Cool Base,Awful House For Guide")]
        public string CustomBuildingNames { get; set; }

        [DefaultValue("[]")]
        [Label("Blueprints Encoded")]
        [Tooltip("A large block of JSON that stores custom blueprints.\nUse select all and copy to take a backup or share(ctrl-a and ctrl-v on windows)\n If you understand JSON, you can also merge multiple backups.\nMake sure you update building names as well")]
        public string SerializedCustomBlueprints
        {
            get;
            set;
        }

        [DefaultValue("")]
        [Label("Preferred Mixerator Themes")]
        [Tooltip("Comma-separated list of themes you prefer when using the Remixer in Preferred Theme mode")]
        public string PreferredThemes
        {
            get;
            set;
        }

        private string prevEncodedBlueprints = null;

        public override void OnLoaded()
        {
            prevEncodedBlueprints = SerializedCustomBlueprints;
        }

        public override void OnChanged()
        {
            if (prevEncodedBlueprints != SerializedCustomBlueprints)
            {
                BlueprintArchive.Instance.LoadCustomBlueprintsFromText(SerializedCustomBlueprints);
                prevEncodedBlueprints = SerializedCustomBlueprints;
            }
        }
    }
}