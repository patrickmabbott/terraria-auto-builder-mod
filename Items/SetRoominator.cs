using AutoBuilder.Items;
using System;
using log4net;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AutoBuilder.Items
{
    public class SetRoominator : Roominator
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Roominator (Set)");
            Tooltip.SetDefault("Places a house room from a furniture set in your inventory\n(i.e. all marble furniture and non-set furniture like paintings)");
        }

        protected override bool DoUseThemes()
        {
            return true;
        }
    }
}