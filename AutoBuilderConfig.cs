using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

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

        public override void OnChanged()
        {
            // Here we use the OnChanged hook to initialize ExampleUI.visible with the new values.
            // We maintain both ExampleUI.visible and ShowCoinUI as separate values so ShowCoinUI can act as a default while ExampleUI.visible can change within a play session.
            //UI.ExampleUI.Visible = ShowCoinUI;
        }
    }
}