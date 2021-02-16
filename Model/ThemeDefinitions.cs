using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBuilder.Model
{
    public class ThemeDefinitions
    {
        /**
 * tiles/walls get assigned to themes based on 
 */
        public enum Themes
        {
            None,
            Light,
            Dark,
            Nature,
            Tech,
            Stone,
            Wood,
            Metal,
            Cold,
            Hot,
            Water,
            Sky,
            Cave,
            Pretty,
            Fancy,
            Ugly,
            Christmas,
            Halloween,
            Transparent,
            Brick,
            Block,
            Wallpaper,
            Fence,
            Cute,
            Animated,
            Party,
            Colored,
            Gem
        }

        public static List<string> ThemesAsString()
        {
            return Enum.GetNames(typeof(Themes)).ToList();
        }

        public static ISet<Tuple<Themes, Themes>> Opposites { get; } = new HashSet<Tuple<Themes, Themes>>()
        {
            new Tuple<Themes, Themes>(Themes.Nature, Themes.Tech),
            new Tuple<Themes, Themes>(Themes.Light, Themes.Dark),
            new Tuple<Themes, Themes>(Themes.Stone, Themes.Wood),
            new Tuple<Themes, Themes>(Themes.Metal, Themes.Wood),
            new Tuple<Themes, Themes>(Themes.Cold, Themes.Hot),
            new Tuple<Themes, Themes>(Themes.Water, Themes.Hot),
            new Tuple<Themes, Themes>(Themes.Cave, Themes.Nature),
            new Tuple<Themes, Themes>(Themes.Sky, Themes.Stone),
            new Tuple<Themes, Themes>(Themes.Pretty, Themes.Ugly),
            new Tuple<Themes, Themes>(Themes.Fancy, Themes.Ugly),
            new Tuple<Themes, Themes>(Themes.Christmas, Themes.Halloween),
            new Tuple<Themes, Themes>(Themes.Brick, Themes.Block),
            new Tuple<Themes, Themes>(Themes.Wallpaper, Themes.Fence),
            new Tuple<Themes, Themes>(Themes.Cute, Themes.Ugly),
            new Tuple<Themes, Themes>(Themes.Party, Themes.Dark),
            new Tuple<Themes, Themes>(Themes.Colored, Themes.Dark),
            new Tuple<Themes, Themes>(Themes.Gem, Themes.Metal)
        };

        public static IDictionary<Themes, ISet<string>> MatchIfWordContains
        {
            get;
        } = new Dictionary<Themes, ISet<string>>()
        {
            {
                Themes.Light,
                new HashSet<string>() {"pearl", "hallow","spooky", "astral","iride","silva","statigel","stratus","otherworldly","honey", "crim", "pine","angel","sun","day","moon"}
            },
            {
                Themes.Dark,
                new HashSet<string>() {"corrupt","abyss","ancient", "plague","profane","monolith","void","scarlet","spider","web","diabolist","cursed","demon","devil","evil","shade", "lihzahrd","bone","dungeon","flesh","ebon","mushroom","death"}
            },
            {
                Themes.Nature, //Not including wood because that's more specifically covered under wood.
                new HashSet<string>() { "botanic", "hay","turf","cactus", "leaf","hive","honey","mushroom","pumpkin","grass","jungle","flower","ivy"}
            },
            {
                Themes.Tech,
                new HashSet<string>() { "meteor","sun", "lab", "silva", "statigel", "stratus", "eutrophic","otherworldly","alchemy","auto","chain","asphalt","skyware", "lihzahrd","plate","plating","martian","steam","cog" }
            },
            {
                Themes.Stone,
                new HashSet<string>() {"stone", "lihzahrd", "eutrophic","granite","marble","shady","naga","rock","bloodstained","cursed"}
            },
            {
                Themes.Wood,
                //Yes, cactus counts as a wood. Don't @ me.
                new HashSet<string>() {"wood", "mahogany", "evergreen","cactus","ornate","spooky","leaf","pine","ornate"}
            },
            {
                Themes.Metal,
                new HashSet<string>() {"iron","brass","metal", "rust","meteor", "cobalt","tin","tungsten","lead","orichalcum ","titanium","mythril","adamant", "chain", "demonite","copper", "gold", "silver", "platinum", "palladium", "thorium", "medicite", "marine", "valadium", "lodestone", "plate", "plating", "cog", "ore", "bar", "naga", "illumite", "chlorophyte", "aquaite"}
            },
            {
                Themes.Cold,
                new HashSet<string>() {"ice","snow","frost","frozen","cold","sleet","cryo"}
            },
            {
                Themes.Hot,
                new HashSet<string>() {"hell","obsidian","ash","fire","magma","lava","ancient","ashen","char","burn","sulp"}
            },
            {
                Themes.Water,
                new HashSet<string>() {"water","marine","aqua","rain","coral","navy","sunk","tenebris","sea","ocean","fish"}
            },
            {
                Themes.Sky,
                new HashSet<string>() {"cloud","rain","snow","sky","star","sun","cosm", "space","exo","astral","celestial","aer","otherworldly", "silva", "statigel", "stratus" }
            },
            {
                Themes.Cave,
                new HashSet<string>() {"sand","ash","obsidian","abyss", "silva", "statigel", "stratus","mushroom","hell"}
            },
            {
                Themes.Pretty,
                new HashSet<string>() { "amber", "diamond", "botanic","cosm", "coral", "slime","honey","crystal", "ruby", "emerald", "sapphire", "topaz", "amethyst", "onyx","pink","glass","wallpaper"}
            },
            {
                Themes.Fancy,
                new HashSet<string>() { "glass","wallpaper","chao","chinese","shingle","dynasty","stucco", "granite", "marble", "ornate", "naga","gold" }
            },
            {
                Themes.Ugly,
                new HashSet<string>() { "demonite", "scarlet","corrupt", "flesh", "ebon","spider","web","plague" }
            },
            {
                Themes.Christmas,
                new HashSet<string>() {"pine","candy","christmas","sugar","ginger","evergreen"}
            },
            {
                Themes.Halloween,
                new HashSet<string>() {"pumpkin","spooky","halloween","bone"}
            },
            {
                Themes.Transparent,
                new HashSet<string>() {"glass","confetti"}
            },
            {
                Themes.Brick,
                new HashSet<string>() {"Brick"}
            },
            {
                Themes.Block,
                new HashSet<string>() {"Block"}
            },
            {
                Themes.Wallpaper,
                new HashSet<string>() {"wallpaper","stucco"}
            },
            {
                Themes.Fence,
                new HashSet<string>() {"fence"}
            },
            {
                Themes.Cute,
                new HashSet<string>() {"pink", "balloon", "party", "confetti","candy","sugar","ginger"}
            },
            {
                Themes.Animated,
                new HashSet<string>() {"living","fall","confetti","starry"}
            },
            {
                Themes.Party,
                new HashSet<string>() {"pink","balloon","party","confetti"}
            },
            {
                Themes.Colored,
                new HashSet<string>() { "amber", "diamond", "opal", "ruby", "emerald", "sapphire", "topaz", "amethyst", "onyx","pink","red","blue","green","yellow","white","purple"}
            },
            {
                Themes.Gem,
                new HashSet<string>() {"amber","diamond","opal","ruby","crystal","emerald","sapphire","topaz","amethyst","onyx"}
            }
        };

    }
}
