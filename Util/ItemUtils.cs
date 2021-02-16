using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoBuilder.json;
using AutoBuilder.Model;
using Terraria;

namespace AutoBuilder.Util
{
    public static class ItemUtils
    {

        public static void SetItemDefaults(Item item)
        {
            item.damage = 36;
            item.melee = true;
            item.noMelee = true;
            item.width = 20;
            item.height = 20;
            item.useTime = 15;
            item.useAnimation = 15;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 2;
            item.reuseDelay = 2000;
            item.value = Item.buyPrice(0, 5, 78, 0);
            item.rare = 0;
            item.autoReuse = false;
        }
    }
}
