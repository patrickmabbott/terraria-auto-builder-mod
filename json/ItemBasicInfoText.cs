using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBuilder.json
{
    public class ItemBasicInfoTexts
    {
        public static string text =
        @"
type,name,createTile,placeStyle,createWall,paint
3,Stone Block,1,-,-,-
8,Torch,4,-,-,-
9,Wood,30,-,-,-
11,Iron Ore,6,-,-,-
12,Copper Ore,7,-,-,-
13,Gold Ore,8,-,-,-
14,Silver Ore,9,-,-,-
19,Gold Bar,239,6,-,-
20,Copper Bar,239,-,-,-
21,Silver Bar,239,4,-,-
22,Iron Bar,239,2,-,-
25,Wooden Door,10,-,-,-
26,Stone Wall,-,-,1,-
27,Acorn,20,-,-,-
30,Dirt Wall,-,-,16,-
31,Bottle,13,-,-,-
32,Wooden Table,14,-,-,-
33,Furnace,17,-,-,-
34,Wooden Chair,15,-,-,-
35,Iron Anvil,16,-,-,-
36,Work Bench,18,-,-,-
48,Chest,21,-,-,-
52,Angel Statue,105,1,-,-
56,Demonite Ore,22,-,-,-
57,Demonite Bar,239,8,-,-
59,Corrupt Seeds,23,-,-,-
61,Ebonstone Block,25,-,-,-
62,Grass Seeds,2,-,-,-
63,Sunflower,27,-,-,-
71,Copper Coin,330,-,-,-
72,Silver Coin,331,-,-,-
73,Gold Coin,332,-,-,-
74,Platinum Coin,333,-,-,-
85,Chain,214,-,-,-
87,Piggy Bank,29,-,-,-
93,Wood Wall,-,-,4,-
94,Wood Platform,19,-,-,-
105,Candle,33,-,-,-
106,Copper Chandelier,34,-,-,-
107,Silver Chandelier,34,1,-,-
108,Gold Chandelier,34,2,-,-
116,Meteorite,37,-,-,-
117,Meteorite Bar,239,9,-,-
129,Gray Brick,38,-,-,-
130,Gray Brick Wall,-,-,5,-
131,Red Brick,39,-,-,-
132,Red Brick Wall,-,-,6,-
133,Clay Block,40,-,-,-
134,Blue Brick,41,-,-,-
135,Blue Brick Wall,-,-,17,-
136,Chain Lantern,42,-,-,-
137,Green Brick,43,-,-,-
138,Green Brick Wall,-,-,18,-
139,Pink Brick,44,-,-,-
140,Pink Brick Wall,-,-,19,-
141,Gold Brick,45,-,-,-
142,Gold Brick Wall,-,-,10,-
143,Silver Brick,46,-,-,-
144,Silver Brick Wall,-,-,11,-
145,Copper Brick,47,-,-,-
146,Copper Brick Wall,-,-,12,-
147,Spike,48,-,-,-
148,Water Candle,49,-,-,-
149,Book,50,-,-,-
150,Cobweb,51,-,-,-
169,Sand Block,53,-,-,-
170,Glass,54,-,-,-
171,Sign,55,-,-,-
172,Ash Block,57,-,-,-
173,Obsidian,56,-,-,-
174,Hellstone,58,-,-,-
175,Hellstone Bar,239,10,-,-
176,Mud Block,59,-,-,-
177,Sapphire,178,2,-,-
178,Ruby,178,4,-,-
179,Emerald,178,3,-,-
180,Topaz,178,1,-,-
181,Amethyst,178,-,-,-
182,Diamond,178,5,-,-
183,Glowing Mushroom,190,-,-,-
192,Obsidian Brick,75,-,-,-
194,Mushroom Grass Seeds,70,-,-,-
195,Jungle Grass Seeds,60,-,-,-
213,Staff of Regrowth,2,-,-,-
214,Hellstone Brick,76,-,-,-
221,Hellforge,77,-,-,-
222,Clay Pot,78,-,-,-
224,Bed,79,-,-,-
250,Fish Bowl,282,-,-,-
275,Coral,81,-,-,-
276,Cactus,188,-,-,-
306,Gold Chest,21,1,-,-
307,Daybloom Seeds,82,-,-,-
308,Moonglow Seeds,82,1,-,-
309,Blinkroot Seeds,82,2,-,-
310,Deathweed Seeds,82,3,-,-
311,Waterleaf Seeds,82,4,-,-
312,Fireblossom Seeds,82,5,-,-
321,Tombstone,85,-,-,-
328,Shadow Chest,21,3,-,-
330,Obsidian Brick Wall,-,-,20,-
332,Loom,86,-,-,-
333,Piano,87,-,-,-
334,Dresser,88,-,-,-
335,Bench,89,-,-,-
336,Bathtub,90,-,-,-
337,Red Banner,91,-,-,-
338,Green Banner,91,1,-,-
339,Blue Banner,91,2,-,-
340,Yellow Banner,91,3,-,-
341,Lamp Post,92,-,-,-
342,Tiki Torch,93,-,-,-
343,Barrel,21,5,-,-
344,Chinese Lantern,95,-,-,-
345,Cooking Pot,96,-,-,-
346,Safe,97,-,-,-
347,Skull Lantern,98,-,-,-
348,Trash Can,21,6,-,-
349,Candelabra,100,-,-,-
350,Pink Vase,13,3,-,-
351,Mug,13,4,-,-
352,Keg,94,-,-,-
354,Bookcase,101,-,-,-
355,Throne,102,-,-,-
356,Bowl,103,-,-,-
358,Toilet,15,1,-,-
359,Grandfather Clock,104,-,-,-
360,Armor Statue,105,-,-,-
363,Sawmill,106,-,-,-
364,Cobalt Ore,107,-,-,-
365,Mythril Ore,108,-,-,-
366,Adamantite Ore,111,-,-,-
369,Hallowed Seeds,109,-,-,-
370,Ebonsand Block,112,-,-,-
381,Cobalt Bar,239,11,-,-
382,Mythril Bar,239,13,-,-
391,Adamantite Bar,239,15,-,-
392,Glass Wall,-,-,21,-
398,Tinkerer's Workshop,114,-,-,-
408,Pearlsand Block,116,-,-,-
409,Pearlstone Block,117,-,-,-
412,Pearlstone Brick,118,-,-,-
413,Iridescent Brick,119,-,-,-
414,Mudstone Block,120,-,-,-
415,Cobalt Brick,121,-,-,-
416,Mythril Brick,122,-,-,-
417,Pearlstone Brick Wall,-,-,22,-
418,Iridescent Brick Wall,-,-,23,-
419,Mudstone Brick Wall,-,-,24,-
420,Cobalt Brick Wall,-,-,25,-
421,Mythril Brick Wall,-,-,26,-
424,Silt Block,123,-,-,-
427,Blue Torch,4,1,-,-
428,Red Torch,4,2,-,-
429,Green Torch,4,3,-,-
430,Purple Torch,4,4,-,-
431,White Torch,4,5,-,-
432,Yellow Torch,4,6,-,-
433,Demon Torch,4,7,-,-
438,Star Statue,105,2,-,-
439,Sword Statue,105,3,-,-
440,Slime Statue,105,4,-,-
441,Goblin Statue,105,5,-,-
442,Shield Statue,105,6,-,-
443,Bat Statue,105,7,-,-
444,Fish Statue,105,8,-,-
445,Bunny Statue,105,9,-,-
446,Skeleton Statue,105,10,-,-
447,Reaper Statue,105,11,-,-
448,Woman Statue,105,12,-,-
449,Imp Statue,105,13,-,-
450,Gargoyle Statue,105,14,-,-
451,Gloom Statue,105,15,-,-
452,Hornet Statue,105,16,-,-
453,Bomb Statue,105,17,-,-
454,Crab Statue,105,18,-,-
455,Hammer Statue,105,19,-,-
456,Potion Statue,105,20,-,-
457,Spear Statue,105,21,-,-
458,Cross Statue,105,22,-,-
459,Jellyfish Statue,105,23,-,-
460,Bow Statue,105,24,-,-
461,Boomerang Statue,105,25,-,-
462,Boot Statue,105,26,-,-
463,Chest Statue,105,27,-,-
464,Bird Statue,105,28,-,-
465,Axe Statue,105,29,-,-
466,Corrupt Statue,105,30,-,-
467,Tree Statue,105,31,-,-
468,Anvil Statue,105,32,-,-
469,Pickaxe Statue,105,33,-,-
470,Mushroom Statue,349,-,-,-
471,Eyeball Statue,105,35,-,-
472,Pillar Statue,105,36,-,-
473,Heart Statue,105,37,-,-
474,Pot Statue,105,38,-,-
475,Sunflower Statue,105,39,-,-
476,King Statue,105,40,-,-
477,Queen Statue,105,41,-,-
478,Piranha Statue,105,42,-,-
479,Planked Wall,-,-,27,-
480,Wooden Beam,124,-,-,-
487,Crystal Ball,125,-,-,-
488,Disco Ball,126,-,-,-
498,Mannequin,128,-,-,-
502,Crystal Shard,129,-,-,-
511,Active Stone Block,130,-,-,-
512,Inactive Stone Block,131,-,-,-
513,Lever,132,-,-,-
523,Cursed Torch,4,8,-,-
524,Adamantite Forge,133,-,-,-
525,Mythril Anvil,134,-,-,-
529,Red Pressure Plate,135,-,-,-
538,Switch,136,-,-,-
539,Dart Trap,137,-,-,-
540,Boulder,138,-,-,-
541,Green Pressure Plate,135,1,-,-
542,Gray Pressure Plate,135,2,-,-
543,Brown Pressure Plate,135,3,-,-
562,Music Box (Overworld Day),139,-,-,-
563,Music Box (Eerie),139,1,-,-
564,Music Box (Night),139,2,-,-
565,Music Box (Title),139,3,-,-
566,Music Box (Underground),139,4,-,-
567,Music Box (Boss 1),139,5,-,-
568,Music Box (Jungle),139,6,-,-
569,Music Box (Corruption),139,7,-,-
570,Music Box (Underground Corruption),139,8,-,-
571,Music Box (The Hallow),139,9,-,-
572,Music Box (Boss 2),139,10,-,-
573,Music Box (Underground Hallow),139,11,-,-
574,Music Box (Boss 3),139,12,-,-
577,Demonite Brick,140,-,-,-
580,Explosives,141,-,-,-
581,Inlet Pump,142,-,-,-
582,Outlet Pump,143,-,-,-
583,1 Second Timer,144,-,-,-
584,3 Second Timer,144,1,-,-
585,5 Second Timer,144,2,-,-
586,Candy Cane Block,145,-,-,-
587,Candy Cane Wall,-,-,29,-
591,Green Candy Cane Block,146,-,-,-
592,Green Candy Cane Wall,-,-,30,-
593,Snow Block,147,-,-,-
594,Snow Brick,148,-,-,-
595,Snow Brick Wall,-,-,31,-
596,Blue Light,149,-,-,-
597,Red Light,149,1,-,-
598,Green Light,149,2,-,-
604,Adamantite Beam,150,-,-,-
605,Adamantite Beam Wall,-,-,32,-
606,Demonite Brick Wall,-,-,33,-
607,Sandstone Brick,151,-,-,-
608,Sandstone Brick Wall,-,-,34,-
609,Ebonstone Brick,152,-,-,-
610,Ebonstone Brick Wall,-,-,35,-
611,Red Stucco,153,-,-,-
612,Yellow Stucco,154,-,-,-
613,Green Stucco,155,-,-,-
614,Gray Stucco,156,-,-,-
615,Red Stucco Wall,-,-,36,-
616,Yellow Stucco Wall,-,-,37,-
617,Green Stucco Wall,-,-,38,-
618,Gray Stucco Wall,-,-,39,-
619,Ebonwood,157,-,-,-
620,Rich Mahogany,158,-,-,-
621,Pearlwood,159,-,-,-
622,Ebonwood Wall,-,-,41,-
623,Rich Mahogany Wall,-,-,42,-
624,Pearlwood Wall,-,-,43,-
625,Ebonwood Chest,21,7,-,-
626,Rich Mahogany Chest,21,8,-,-
627,Pearlwood Chest,21,9,-,-
628,Ebonwood Chair,15,2,-,-
629,Rich Mahogany Chair,15,3,-,-
630,Pearlwood Chair,15,4,-,-
631,Ebonwood Platform,19,1,-,-
632,Rich Mahogany Platform,19,2,-,-
633,Pearlwood Platform,19,3,-,-
634,Bone Platform,19,4,-,-
635,Ebonwood Work Bench,18,1,-,-
636,Rich Mahogany Work Bench,18,2,-,-
637,Pearlwood Work Bench,18,3,-,-
638,Ebonwood Table,14,1,-,-
639,Rich Mahogany Table,14,2,-,-
640,Pearlwood Table,14,3,-,-
641,Ebonwood Piano,87,1,-,-
642,Rich Mahogany Piano,87,2,-,-
643,Pearlwood Piano,87,3,-,-
644,Ebonwood Bed,79,1,-,-
645,Rich Mahogany Bed,79,2,-,-
646,Pearlwood Bed,79,3,-,-
647,Ebonwood Dresser,88,1,-,-
648,Rich Mahogany Dresser,88,2,-,-
649,Pearlwood Dresser,88,3,-,-
650,Ebonwood Door,10,1,-,-
651,Rich Mahogany Door,10,2,-,-
652,Pearlwood Door,10,3,-,-
662,Rainbow Brick,160,-,-,-
663,Rainbow Brick Wall,-,-,44,-
664,Ice Block,161,-,-,-
673,Boreal Wood Work Bench,18,23,-,-
677,Boreal Wood Table,14,28,-,-
680,Ivy Chest,21,10,-,-
681,Ice Chest,21,11,-,-
699,Tin Ore,166,-,-,-
700,Lead Ore,167,-,-,-
701,Tungsten Ore,168,-,-,-
702,Platinum Ore,169,-,-,-
703,Tin Bar,239,1,-,-
704,Lead Bar,239,3,-,-
705,Tungsten Bar,239,5,-,-
706,Platinum Bar,239,7,-,-
710,Tin Chandelier,34,3,-,-
711,Tungsten Chandelier,34,4,-,-
712,Platinum Chandelier,34,5,-,-
713,Platinum Candle,174,-,-,-
714,Platinum Candelabra,173,-,-,-
716,Lead Anvil,16,1,-,-
717,Tin Brick,175,-,-,-
718,Tungsten Brick,176,-,-,-
719,Platinum Brick,177,-,-,-
720,Tin Brick Wall,-,-,45,-
721,Tungsten Brick Wall,-,-,46,-
722,Platinum Brick Wall,-,-,47,-
745,Grass Wall,-,-,66,-
746,Jungle Wall,-,-,67,-
747,Flower Wall,-,-,68,-
750,Cactus Wall,-,-,72,-
751,Cloud,189,-,-,-
752,Cloud Wall,-,-,73,-
762,Slime Block,193,-,-,-
763,Flesh Block,195,-,-,-
764,Mushroom Wall,-,-,74,-
765,Rain Cloud,196,-,-,-
766,Bone Block,194,-,-,-
767,Frozen Slime Block,197,-,-,-
768,Bone Block Wall,-,-,75,-
769,Slime Block Wall,-,-,76,-
770,Flesh Block Wall,-,-,77,-
775,Asphalt Block,198,-,-,-
789,Ankh Banner,91,4,-,-
790,Snake Banner,91,5,-,-
791,Omega Banner,91,6,-,-
806,Living Wood Chair,15,5,-,-
807,Cactus Chair,15,6,-,-
808,Bone Chair,15,7,-,-
809,Flesh Chair,15,8,-,-
810,Mushroom Chair,15,9,-,-
811,Bone Work Bench,18,4,-,-
812,Cactus Work Bench,18,5,-,-
813,Flesh Work Bench,18,6,-,-
814,Mushroom Work Bench,18,7,-,-
815,Slime Work Bench,18,8,-,-
816,Cactus Door,10,4,-,-
817,Flesh Door,10,5,-,-
818,Mushroom Door,10,6,-,-
819,Living Wood Door,10,7,-,-
820,Bone Door,10,8,-,-
824,Sunplate Block,202,-,-,-
825,Disc Wall,-,-,82,-
826,Skyware Chair,15,10,-,-
827,Bone Table,14,4,-,-
828,Flesh Table,14,5,-,-
829,Living Wood Table,14,6,-,-
830,Skyware Table,14,7,-,-
831,Living Wood Chest,21,12,-,-
832,Living Wood Wand,191,-,-,-
833,Purple Ice Block,163,-,-,-
834,Pink Ice Block,164,-,-,-
835,Red Ice Block,200,-,-,-
836,Crimstone Block,203,-,-,-
837,Skyware Door,10,9,-,-
838,Skyware Chest,21,13,-,-
845,World Banner,91,7,-,-
846,Sun Banner,91,8,-,-
847,Gravity Banner,91,9,-,-
852,Blue Pressure Plate,135,4,-,-
853,Yellow Pressure Plate,135,5,-,-
858,Boreal Wood Sofa,89,24,-,-
880,Crimtane Ore,204,-,-,-
883,Ice Brick,206,-,-,-
884,Ice Brick Wall,-,-,84,-
909,Pure Water Fountain,207,-,-,-
910,Desert Water Fountain,207,1,-,-
911,Shadewood,208,-,-,-
912,Shadewood Door,10,10,-,-
913,Shadewood Platform,19,5,-,-
914,Shadewood Chest,21,14,-,-
915,Shadewood Chair,15,11,-,-
916,Shadewood Work Bench,18,9,-,-
917,Shadewood Table,14,8,-,-
918,Shadewood Dresser,88,4,-,-
919,Shadewood Piano,87,4,-,-
920,Shadewood Bed,79,4,-,-
927,Shadewood Wall,-,-,85,-
928,Cannon,209,-,-,-
932,Bone Wand,194,-,-,-
933,Leaf Wand,192,-,-,-
937,Land Mine,210,-,-,-
940,Jungle Water Fountain,207,2,-,-
941,Icy Water Fountain,207,3,-,-
942,Corrupt Water Fountain,207,4,-,-
943,Crimson Water Fountain,207,5,-,-
944,Hallowed Water Fountain,207,6,-,-
945,Blood Water Fountain,207,7,-,-
947,Chlorophyte Ore,211,-,-,-
951,Snowball Launcher,212,-,-,-
952,Web Covered Chest,21,15,-,-
965,Rope,213,-,-,-
966,Campfire,215,-,-,-
970,Red Rocket,216,-,-,-
971,Green Rocket,216,1,-,-
972,Blue Rocket,216,2,-,-
973,Yellow Rocket,216,3,-,-
974,Ice Torch,4,9,-,-
995,Blend-O-Matic,217,-,-,-
996,Meat Grinder,218,-,-,-
997,Extractinator,219,-,-,-
998,Solidifier,220,-,-,-
999,Amber,178,6,-,-
1006,Chlorophyte Bar,239,17,-,-
1073,Red Paint,-,-,-,1
1074,Orange Paint,-,-,-,2
1075,Yellow Paint,-,-,-,3
1076,Lime Paint,-,-,-,4
1077,Green Paint,-,-,-,5
1078,Teal Paint,-,-,-,6
1079,Cyan Paint,-,-,-,7
1080,Sky Blue Paint,-,-,-,8
1081,Blue Paint,-,-,-,9
1082,Purple Paint,-,-,-,10
1083,Violet Paint,-,-,-,11
1084,Pink Paint,-,-,-,12
1085,Deep Red Paint,-,-,-,13
1086,Deep Orange Paint,-,-,-,14
1087,Deep Yellow Paint,-,-,-,15
1088,Deep Lime Paint,-,-,-,16
1089,Deep Green Paint,-,-,-,17
1090,Deep Teal Paint,-,-,-,18
1091,Deep Cyan Paint,-,-,-,19
1092,Deep Sky Blue Paint,-,-,-,20
1093,Deep Blue Paint,-,-,-,21
1094,Deep Purple Paint,-,-,-,22
1095,Deep Violet Paint,-,-,-,23
1096,Deep Pink Paint,-,-,-,24
1097,Black Paint,-,-,-,25
1098,White Paint,-,-,-,26
1099,Gray Paint,-,-,-,27
1101,Lihzahrd Brick,226,-,-,-
1102,Lihzahrd Brick Wall,-,-,112,-
1103,Slush Block,224,-,-,-
1104,Palladium Ore,221,-,-,-
1105,Orichalcum Ore,222,-,-,-
1106,Titanium Ore,223,-,-,-
1107,Teal Mushroom,227,-,-,-
1108,Green Mushroom,227,1,-,-
1109,Sky Blue Flower,227,2,-,-
1110,Yellow Marigold,227,3,-,-
1111,Blue Berries,227,4,-,-
1112,Lime Kelp,227,5,-,-
1114,Orange Bloodroot,227,7,-,-
1120,Dye Vat,228,-,-,-
1125,Honey Block,229,-,-,-
1126,Hive Wall,-,-,108,-
1127,Crispy Honey Block,230,-,-,-
1129,Hive Wand,225,-,-,-
1137,Lihzahrd Door,10,12,-,-
1138,Dungeon Door,10,13,-,-
1139,Lead Door,10,14,-,-
1140,Iron Door,10,15,-,-
1142,Lihzahrd Chest,21,16,-,-
1143,Lihzahrd Chair,15,12,-,-
1144,Lihzahrd Table,14,9,-,-
1145,Lihzahrd Work Bench,18,10,-,-
1146,Super Dart Trap,137,1,-,-
1147,Flame Trap,137,2,-,-
1148,Spiky Ball Trap,137,3,-,-
1149,Spear Trap,137,4,-,-
1150,Wooden Spike,232,-,-,-
1151,Lihzahrd Pressure Plate,135,6,-,-
1152,Lihzahrd Statue,105,43,-,-
1153,Lihzahrd Watcher Statue,105,44,-,-
1154,Lihzahrd Guardian Statue,105,45,-,-
1173,Grave Marker,85,1,-,-
1174,Cross Grave Marker,85,2,-,-
1175,Headstone,85,3,-,-
1176,Gravestone,85,4,-,-
1177,Obelisk,85,5,-,-
1184,Palladium Bar,239,12,-,-
1191,Orichalcum Bar,239,14,-,-
1198,Titanium Bar,239,16,-,-
1220,Orichalcum Anvil,134,1,-,-
1221,Titanium Forge,133,1,-,-
1225,Hallowed Bar,239,18,-,-
1245,Orange Torch,4,10,-,-
1246,Crimsand Block,234,-,-,-
1257,Crimtane Bar,239,19,-,-
1263,Teleporter,235,-,-,-
1267,Purple Stained Glass,-,-,88,-
1268,Yellow Stained Glass,-,-,89,-
1269,Blue Stained Glass,-,-,90,-
1270,Green Stained Glass,-,-,91,-
1271,Red Stained Glass,-,-,92,-
1272,Multicolored Stained Glass,-,-,93,-
1292,Lihzahrd Altar,237,-,-,-
1298,Water Chest,21,17,-,-
1333,Ichor Torch,4,11,-,-
1337,Bunny Cannon,209,1,-,-
1344,Cog,272,-,-,-
1360,Eye of Cthulhu Trophy,240,-,-,-
1361,Eater of Worlds Trophy,240,1,-,-
1362,Brain of Cthulhu Trophy,240,2,-,-
1363,Skeletron Trophy,240,3,-,-
1364,Queen Bee Trophy,240,4,-,-
1365,Wall of Flesh Trophy,240,5,-,-
1366,Destroyer Trophy,240,6,-,-
1367,Skeletron Prime Trophy,240,7,-,-
1368,Retinazer Trophy,240,8,-,-
1369,Spazmatism Trophy,240,9,-,-
1370,Plantera Trophy,240,10,-,-
1371,Golem Trophy,240,11,-,-
1372,Blood Moon Rising,240,12,-,-
1373,The Hanged Man,240,13,-,-
1374,Glory of the Fire,240,14,-,-
1375,Bone Warp,240,15,-,-
1376,Wall Skeleton,240,16,-,-
1377,Hanging Skeleton,240,17,-,-
1378,Blue Slab Wall,-,-,100,-
1379,Blue Tiled Wall,-,-,101,-
1380,Pink Slab Wall,-,-,102,-
1381,Pink Tiled Wall,-,-,103,-
1382,Green Slab Wall,-,-,104,-
1383,Green Tiled Wall,-,-,105,-
1384,Blue Brick Platform,19,6,-,-
1385,Pink Brick Platform,19,7,-,-
1386,Green Brick Platform,19,8,-,-
1387,Metal Shelf,19,9,-,-
1388,Brass Shelf,19,10,-,-
1389,Wood Shelf,19,11,-,-
1390,Brass Lantern,42,1,-,-
1391,Caged Lantern,42,2,-,-
1392,Carriage Lantern,42,3,-,-
1393,Alchemy Lantern,42,4,-,-
1394,Diabolist Lamp,42,5,-,-
1395,Oil Rag Sconse,42,6,-,-
1396,Blue Dungeon Chair,15,13,-,-
1397,Blue Dungeon Table,14,10,-,-
1398,Blue Dungeon Work Bench,18,11,-,-
1399,Green Dungeon Chair,15,14,-,-
1400,Green Dungeon Table,14,11,-,-
1401,Green Dungeon Work Bench,18,12,-,-
1402,Pink Dungeon Chair,15,15,-,-
1403,Pink Dungeon Table,14,12,-,-
1404,Pink Dungeon Work Bench,18,13,-,-
1405,Blue Dungeon Candle,33,1,-,-
1406,Green Dungeon Candle,33,2,-,-
1407,Pink Dungeon Candle,33,3,-,-
1408,Blue Dungeon Vase,105,46,-,-
1409,Green Dungeon Vase,105,47,-,-
1410,Pink Dungeon Vase,105,48,-,-
1411,Blue Dungeon Door,10,16,-,-
1412,Green Dungeon Door,10,17,-,-
1413,Pink Dungeon Door,10,18,-,-
1414,Blue Dungeon Bookcase,101,1,-,-
1415,Green Dungeon Bookcase,101,2,-,-
1416,Pink Dungeon Bookcase,101,3,-,-
1417,Catacomb,241,-,-,-
1418,Dungeon Shelf,19,12,-,-
1419,Skellington J Skellingsworth,240,18,-,-
1420,The Cursed Man,240,19,-,-
1421,The Eye Sees the End,242,-,-,-
1422,Something Evil is Watching You,242,1,-,-
1423,The Twins Have Awoken,242,2,-,-
1424,The Screamer,242,3,-,-
1425,Goblins Playing Poker,242,4,-,-
1426,Dryadisque,242,5,-,-
1427,Sunflowers,240,20,-,-
1428,Terrarian Gothic,240,21,-,-
1430,Imbuing Station,243,-,-,-
1431,Star in a Bottle,42,7,-,-
1433,Impact,242,6,-,-
1434,Powered by Birds,242,7,-,-
1435,The Destroyer,242,8,-,-
1436,The Persistency of Eyes,242,9,-,-
1437,Unicorn Crossing the Hallows,242,10,-,-
1438,Great Wave,242,11,-,-
1439,Starry Night,242,12,-,-
1440,Guide Picasso,240,22,-,-
1441,The Guardian's Gaze,240,23,-,-
1442,Father of Someone,240,24,-,-
1443,Nurse Lisa,240,25,-,-
1447,Wooden Fence,-,-,106,-
1448,Lead Fence,-,-,107,-
1449,Bubble Machine,244,-,-,-
1451,Marching Bones Banner,91,10,-,-
1452,Necromantic Sign,91,11,-,-
1453,Rusted Company Standard,91,12,-,-
1454,Ragged Brotherhood Sigil,91,13,-,-
1455,Molten Legion Flag,91,14,-,-
1456,Diabolic Sigil,91,15,-,-
1457,Obsidian Platform,19,13,-,-
1458,Obsidian Door,10,19,-,-
1459,Obsidian Chair,15,16,-,-
1460,Obsidian Table,14,13,-,-
1461,Obsidian Work Bench,18,14,-,-
1462,Obsidian Vase,105,49,-,-
1463,Obsidian Bookcase,101,4,-,-
1464,Hellbound Banner,91,16,-,-
1465,Hell Hammer Banner,91,17,-,-
1466,Helltower Banner,91,18,-,-
1467,Lost Hopes of Man Banner,91,19,-,-
1468,Obsidian Watcher Banner,91,20,-,-
1469,Lava Erupts Banner,91,21,-,-
1470,Blue Dungeon Bed,79,5,-,-
1471,Green Dungeon Bed,79,6,-,-
1472,Pink Dungeon Bed,79,7,-,-
1473,Obsidian Bed,79,8,-,-
1474,Waldo,245,-,-,-
1475,Darkness,245,1,-,-
1476,Dark Soul Reaper,245,2,-,-
1477,Land,245,3,-,-
1478,Trapped Ghost,245,4,-,-
1479,Demon's Eye,246,-,-,-
1480,Finding Gold,246,1,-,-
1481,First Encounter,246,2,-,-
1482,Good Morning,246,3,-,-
1483,Underground Reward,246,4,-,-
1484,Through the Window,246,5,-,-
1485,Place Above the Clouds,246,6,-,-
1486,Do Not Step on the Grass,246,7,-,-
1487,Cold Waters in the White Land,246,8,-,-
1488,Lightless Chasms,246,9,-,-
1489,The Land of Deceiving Looks,246,10,-,-
1490,Daylight,246,11,-,-
1491,Secret of the Sands,246,12,-,-
1492,Deadland Comes Alive,246,13,-,-
1493,Evil Presence,246,14,-,-
1494,Sky Guardian,246,15,-,-
1495,American Explosive,245,5,-,-
1496,Discover,240,26,-,-
1497,Hand Earth,240,27,-,-
1498,Old Miner,240,28,-,-
1499,Skelehead,240,29,-,-
1500,Facing the Cerebral Mastermind,242,13,-,-
1501,Lake of Fire,242,14,-,-
1502,Trio Super Heroes,242,15,-,-
1509,Gothic Chair,15,17,-,-
1510,Gothic Table,14,14,-,-
1511,Gothic Work Bench,18,15,-,-
1512,Gothic Bookcase,101,5,-,-
1528,Jungle Chest,21,18,-,-
1529,Corruption Chest,21,19,-,-
1530,Crimson Chest,21,20,-,-
1531,Hallowed Chest,21,21,-,-
1532,Frozen Chest,21,22,-,-
1538,Imp Face,240,30,-,-
1539,Ominous Presence,240,31,-,-
1540,Shining Moon,240,32,-,-
1541,Living Gore,246,16,-,-
1542,Flowing Magma,246,17,-,-
1551,Autohammer,247,-,-,-
1552,Shroomite Bar,239,20,-,-
1573,The Creation of the Guide,242,16,-,-
1574,The Merchant,240,33,-,-
1575,Crowno Devours His Lunch,240,34,-,-
1576,Rare Enchantment,240,35,-,-
1577,Glorious Night,245,6,-,-
1589,Palladium Column,248,-,-,-
1590,Palladium Column Wall,-,-,109,-
1591,Bubblegum Block,249,-,-,-
1592,Bubblegum Block Wall,-,-,110,-
1593,Titanstone Block,250,-,-,-
1594,Titanstone Block Wall,-,-,111,-
1596,Music Box (Snow),139,13,-,-
1597,Music Box (Space),139,14,-,-
1598,Music Box (Crimson),139,15,-,-
1599,Music Box (Boss 4),139,16,-,-
1600,Music Box (Alt Overworld Day),139,17,-,-
1601,Music Box (Rain),139,18,-,-
1602,Music Box (Ice),139,19,-,-
1603,Music Box (Desert),139,20,-,-
1604,Music Box (Ocean),139,21,-,-
1605,Music Box (Dungeon),139,22,-,-
1606,Music Box (Plantera),139,23,-,-
1607,Music Box (Boss 5),139,24,-,-
1608,Music Box (Temple),139,25,-,-
1609,Music Box (Eclipse),139,26,-,-
1610,Music Box (Mushrooms),139,27,-,-
1615,Angler Fish Banner,91,22,-,-
1616,Angry Nimbus Banner,91,23,-,-
1617,Anomura Fungus Banner,91,24,-,-
1618,Antlion Banner,91,25,-,-
1619,Arapaima Banner,91,26,-,-
1620,Armored Skeleton Banner,91,27,-,-
1621,Cave Bat Banner,91,28,-,-
1622,Bird Banner,91,29,-,-
1623,Black Recluse Banner,91,30,-,-
1624,Blood Feeder Banner,91,31,-,-
1625,Blood Jelly Banner,91,32,-,-
1626,Blood Crawler Banner,91,33,-,-
1627,Bone Serpent Banner,91,34,-,-
1628,Bunny Banner,91,35,-,-
1629,Chaos Elemental Banner,91,36,-,-
1630,Mimic Banner,91,37,-,-
1631,Clown Banner,91,38,-,-
1632,Corrupt Bunny Banner,91,39,-,-
1633,Corrupt Goldfish Banner,91,40,-,-
1634,Crab Banner,91,41,-,-
1635,Crimera Banner,91,42,-,-
1636,Crimson Axe Banner,91,43,-,-
1637,Cursed Hammer Banner,91,44,-,-
1638,Demon Banner,91,45,-,-
1639,Demon Eye Banner,91,46,-,-
1640,Derpling Banner,91,47,-,-
1641,Eater of Souls Banner,91,48,-,-
1642,Enchanted Sword Banner,91,49,-,-
1643,Zombie Eskimo Banner,91,50,-,-
1644,Face Monster Banner,91,51,-,-
1645,Floaty Gross Banner,91,52,-,-
1646,Flying Fish Banner,91,53,-,-
1647,Flying Snake Banner,91,54,-,-
1648,Frankenstein Banner,91,55,-,-
1649,Fungi Bulb Banner,91,56,-,-
1650,Fungo Fish Banner,91,57,-,-
1651,Gastropod Banner,91,58,-,-
1652,Goblin Thief Banner,91,59,-,-
1653,Goblin Sorcerer Banner,91,60,-,-
1654,Goblin Peon Banner,91,61,-,-
1655,Goblin Scout Banner,91,62,-,-
1656,Goblin Warrior Banner,91,63,-,-
1657,Goldfish Banner,91,64,-,-
1658,Harpy Banner,91,65,-,-
1659,Hellbat Banner,91,66,-,-
1660,Herpling Banner,91,67,-,-
1661,Hornet Banner,91,68,-,-
1662,Ice Elemental Banner,91,69,-,-
1663,Icy Merman Banner,91,70,-,-
1664,Fire Imp Banner,91,71,-,-
1665,Blue Jellyfish Banner,91,72,-,-
1666,Jungle Creeper Banner,91,73,-,-
1667,Lihzahrd Banner,91,74,-,-
1668,Man Eater Banner,91,75,-,-
1669,Meteor Head Banner,91,76,-,-
1670,Moth Banner,91,77,-,-
1671,Mummy Banner,91,78,-,-
1672,Mushi Ladybug Banner,91,79,-,-
1673,Parrot Banner,91,80,-,-
1674,Pigron Banner,91,81,-,-
1675,Piranha Banner,91,82,-,-
1676,Pirate Deckhand Banner,91,83,-,-
1677,Pixie Banner,91,84,-,-
1678,Raincoat Zombie Banner,91,85,-,-
1679,Reaper Banner,91,86,-,-
1680,Shark Banner,91,87,-,-
1681,Skeleton Banner,91,88,-,-
1682,Dark Caster Banner,91,89,-,-
1683,Blue Slime Banner,91,90,-,-
1684,Snow Flinx Banner,91,91,-,-
1685,Wall Creeper Banner,91,92,-,-
1686,Spore Zombie Banner,91,93,-,-
1687,Swamp Thing Banner,91,94,-,-
1688,Giant Tortoise Banner,91,95,-,-
1689,Toxic Sludge Banner,91,96,-,-
1690,Umbrella Slime Banner,91,97,-,-
1691,Unicorn Banner,91,98,-,-
1692,Vampire Banner,91,99,-,-
1693,Vulture Banner,91,100,-,-
1694,Nymph Banner,91,101,-,-
1695,Werewolf Banner,91,102,-,-
1696,Wolf Banner,91,103,-,-
1697,World Feeder Banner,91,104,-,-
1698,Worm Banner,91,105,-,-
1699,Wraith Banner,91,106,-,-
1700,Wyvern Banner,91,107,-,-
1701,Zombie Banner,91,108,-,-
1702,Glass Platform,19,14,-,-
1703,Glass Chair,15,18,-,-
1704,Golden Chair,15,19,-,-
1705,Golden Toilet,15,20,-,-
1706,Bar Stool,15,21,-,-
1707,Honey Chair,15,22,-,-
1708,Steampunk Chair,15,23,-,-
1709,Glass Door,10,20,-,-
1710,Golden Door,10,21,-,-
1711,Honey Door,10,22,-,-
1712,Steampunk Door,10,23,-,-
1713,Glass Table,14,15,-,-
1714,Banquet Table,14,16,-,-
1715,Bar,14,17,-,-
1716,Golden Table,14,18,-,-
1717,Honey Table,14,19,-,-
1718,Steampunk Table,14,20,-,-
1719,Glass Bed,79,9,-,-
1720,Golden Bed,79,10,-,-
1721,Honey Bed,79,11,-,-
1722,Steampunk Bed,79,12,-,-
1723,Living Wood Wall,-,-,78,-
1725,Pumpkin,251,-,-,-
1726,Pumpkin Wall,-,-,113,-
1727,Hay,252,-,-,-
1728,Hay Wall,-,-,114,-
1729,Spooky Wood,253,-,-,-
1730,Spooky Wood Wall,-,-,115,-
1791,Cauldron,96,1,-,-
1792,Pumpkin Chair,15,24,-,-
1793,Pumpkin Door,10,24,-,-
1794,Pumpkin Table,14,21,-,-
1795,Pumpkin Work Bench,18,16,-,-
1796,Pumpkin Platform,19,15,-,-
1808,Hanging Jack 'O Lantern,42,8,-,-
1812,Jackelier,34,6,-,-
1813,Jack 'O Lantern,35,-,-,-
1814,Spooky Chair,15,25,-,-
1815,Spooky Door,10,25,-,-
1816,Spooky Table,14,22,-,-
1817,Spooky Work Bench,18,17,-,-
1818,Spooky Platform,19,16,-,-
1828,Pumpkin Seed,254,-,-,-
1846,Jacking Skeletron,242,17,-,-
1847,Bitter Harvest,242,18,-,-
1848,Blood Moon Countess,242,19,-,-
1849,Hallow's Eve,242,20,-,-
1850,Morbid Curiosity,242,21,-,-
1855,Mourning Wood Trophy,240,36,-,-
1856,Pumpking Trophy,240,37,-,-
1859,Heart Lantern,42,9,-,-
1869,Present,36,-,-,-
1872,Pine Tree Block,170,-,-,-
1873,Christmas Tree,171,-,-,-
1908,Holly,246,18,-,-
1924,Pine Door,10,26,-,-
1925,Pine Chair,15,26,-,-
1926,Pine Table,14,23,-,-
1948,Christmas Tree Wallpaper,-,-,116,-
1949,Ornament Wallpaper,-,-,117,-
1950,Candy Cane Wallpaper,-,-,118,-
1951,Festive Wallpaper,-,-,119,-
1952,Stars Wallpaper,-,-,120,-
1953,Squiggles Wallpaper,-,-,121,-
1954,Snowflake Wallpaper,-,-,122,-
1955,Krampus Horn Wallpaper,-,-,123,-
1956,Bluegreen Wallpaper,-,-,124,-
1957,Grinch Finger Wallpaper,-,-,125,-
1960,Ice Queen Trophy,240,38,-,-
1961,Santa-NK1 Trophy,240,39,-,-
1962,Everscream Trophy,240,40,-,-
1963,Music Box (Pumpkin Moon),139,28,-,-
1964,Music Box (Alt Underground),139,29,-,-
1965,Music Box (Frost Moon),139,30,-,-
1966,Brown Paint,-,-,-,28
1967,Shadow Paint,-,-,-,29
1968,Negative Paint,-,-,-,30
1970,Amethyst Gemspark Block,262,-,-,-
1971,Topaz Gemspark Block,263,-,-,-
1972,Sapphire Gemspark Block,264,-,-,-
1973,Emerald Gemspark Block,265,-,-,-
1974,Ruby Gemspark Block,266,-,-,-
1975,Diamond Gemspark Block,267,-,-,-
1976,Amber Gemspark Block,268,-,-,-
1989,Womannequin,269,-,-,-
1993,Firefly in a Bottle,270,-,-,-
1994,Monarch Butterfly,-,1,-,-
1995,Purple Emperor Butterfly,-,2,-,-
1996,Red Admiral Butterfly,-,3,-,-
1997,Ulysses Butterfly,-,4,-,-
1998,Sulphur Butterfly,-,5,-,-
1999,Tree Nymph Butterfly,-,6,-,-
2000,Zebra Swallowtail Butterfly,-,7,-,-
2001,Julia Butterfly,-,8,-,-
2005,Lightning Bug in a Bottle,271,-,-,-
2008,Fancy Gray Wallpaper,-,-,126,-
2009,Ice Floe Wallpaper,-,-,127,-
2010,Music Wallpaper,-,-,128,-
2011,Purple Rain Wallpaper,-,-,129,-
2012,Rainbow Wallpaper,-,-,130,-
2013,Sparkle Stone Wallpaper,-,-,131,-
2014,Starlit Heaven Wallpaper,-,-,132,-
2020,Cactus Bookcase,101,6,-,-
2021,Ebonwood Bookcase,101,7,-,-
2022,Flesh Bookcase,101,8,-,-
2023,Honey Bookcase,101,9,-,-
2024,Steampunk Bookcase,101,10,-,-
2025,Glass Bookcase,101,11,-,-
2026,Rich Mahogany Bookcase,101,12,-,-
2027,Pearlwood Bookcase,101,13,-,-
2028,Spooky Bookcase,101,14,-,-
2029,Skyware Bookcase,101,15,-,-
2030,Lihzahrd Bookcase,101,16,-,-
2031,Frozen Bookcase,101,17,-,-
2032,Cactus Lantern,42,10,-,-
2033,Ebonwood Lantern,42,11,-,-
2034,Flesh Lantern,42,12,-,-
2035,Honey Lantern,42,13,-,-
2036,Steampunk Lantern,42,14,-,-
2037,Glass Lantern,42,15,-,-
2038,Rich Mahogany Lantern,42,16,-,-
2039,Pearlwood Lantern,42,17,-,-
2040,Frozen Lantern,42,18,-,-
2041,Lihzahrd Lantern,42,19,-,-
2042,Skyware Lantern,42,20,-,-
2043,Spooky Lantern,42,21,-,-
2044,Frozen Door,10,27,-,-
2045,Cactus Candle,33,4,-,-
2046,Ebonwood Candle,33,5,-,-
2047,Flesh Candle,33,6,-,-
2048,Glass Candle,33,7,-,-
2049,Frozen Candle,33,8,-,-
2050,Rich Mahogany Candle,33,9,-,-
2051,Pearlwood Candle,33,10,-,-
2052,Lihzahrd Candle,33,11,-,-
2053,Skyware Candle,33,12,-,-
2054,Pumpkin Candle,33,13,-,-
2055,Cactus Chandelier,34,7,-,-
2056,Ebonwood Chandelier,34,8,-,-
2057,Flesh Chandelier,34,9,-,-
2058,Honey Chandelier,34,10,-,-
2059,Frozen Chandelier,34,11,-,-
2060,Rich Mahogany Chandelier,34,12,-,-
2061,Pearlwood Chandelier,34,13,-,-
2062,Lihzahrd Chandelier,34,14,-,-
2063,Skyware Chandelier,34,15,-,-
2064,Spooky Chandelier,34,16,-,-
2065,Glass Chandelier,34,17,-,-
2066,Cactus Bed,79,13,-,-
2067,Flesh Bed,79,14,-,-
2068,Frozen Bed,79,15,-,-
2069,Lihzahrd Bed,79,16,-,-
2070,Skyware Bed,79,17,-,-
2071,Spooky Bed,79,18,-,-
2072,Cactus Bathtub,90,1,-,-
2073,Ebonwood Bathtub,90,2,-,-
2074,Flesh Bathtub,90,3,-,-
2075,Glass Bathtub,90,4,-,-
2076,Frozen Bathtub,90,5,-,-
2077,Rich Mahogany Bathtub,90,6,-,-
2078,Pearlwood Bathtub,90,7,-,-
2079,Lihzahrd Bathtub,90,8,-,-
2080,Skyware Bathtub,90,9,-,-
2081,Spooky Bathtub,90,10,-,-
2082,Cactus Lamp,93,1,-,-
2083,Ebonwood Lamp,93,2,-,-
2084,Flesh Lamp,93,3,-,-
2085,Glass Lamp,93,4,-,-
2086,Frozen Lamp,93,5,-,-
2087,Rich Mahogany Lamp,93,6,-,-
2088,Pearlwood Lamp,93,7,-,-
2089,Lihzahrd Lamp,93,8,-,-
2090,Skyware Lamp,93,9,-,-
2091,Spooky Lamp,93,10,-,-
2092,Cactus Candelabra,100,1,-,-
2093,Ebonwood Candelabra,100,2,-,-
2094,Flesh Candelabra,100,3,-,-
2095,Honey Candelabra,100,4,-,-
2096,Steampunk Candelabra,100,5,-,-
2097,Glass Candelabra,100,6,-,-
2098,Rich Mahogany Candelabra,100,7,-,-
2099,Pearlwood Candelabra,100,8,-,-
2100,Frozen Candelabra,100,9,-,-
2101,Lihzahrd Candelabra,100,10,-,-
2102,Skyware Candelabra,100,11,-,-
2103,Spooky Candelabra,100,12,-,-
2114,Blacksmith Rack,240,41,-,-
2115,Carpentry Rack,240,42,-,-
2116,Helmet Rack,240,43,-,-
2117,Spear Rack,240,44,-,-
2118,Sword Rack,240,45,-,-
2119,Stone Slab,273,-,-,-
2120,Sandstone Slab,274,-,-,-
2124,Honey Bathtub,90,11,-,-
2125,Steampunk Bathtub,90,12,-,-
2126,Living Wood Bathtub,90,13,-,-
2127,Shadewood Bathtub,90,14,-,-
2128,Bone Bathtub,90,15,-,-
2129,Honey Lamp,93,11,-,-
2130,Steampunk Lamp,93,12,-,-
2131,Living Wood Lamp,93,13,-,-
2132,Shadewood Lamp,93,14,-,-
2133,Golden Lamp,93,15,-,-
2134,Bone Lamp,93,16,-,-
2135,Living Wood Bookcase,101,18,-,-
2136,Shadewood Bookcase,101,19,-,-
2137,Golden Bookcase,101,20,-,-
2138,Bone Bookcase,101,21,-,-
2139,Living Wood Bed,79,19,-,-
2140,Bone Bed,79,20,-,-
2141,Living Wood Chandelier,34,18,-,-
2142,Shadewood Chandelier,34,19,-,-
2143,Golden Chandelier,34,20,-,-
2144,Bone Chandelier,34,21,-,-
2145,Living Wood Lantern,42,22,-,-
2146,Shadewood Lantern,42,23,-,-
2147,Golden Lantern,42,24,-,-
2148,Bone Lantern,42,25,-,-
2149,Living Wood Candelabra,100,13,-,-
2150,Shadewood Candelabra,100,14,-,-
2151,Golden Candelabra,100,15,-,-
2152,Bone Candelabra,100,16,-,-
2153,Living Wood Candle,33,14,-,-
2154,Shadewood Candle,33,15,-,-
2155,Golden Candle,33,16,-,-
2158,Bubble Wallpaper,-,-,133,-
2159,Copper Pipe Wallpaper,-,-,134,-
2160,Ducky Wallpaper,-,-,135,-
2162,Bunny Cage,275,-,-,-
2163,Squirrel Cage,276,-,-,-
2164,Mallard Duck Cage,277,-,-,-
2165,Duck Cage,278,-,-,-
2166,Bird Cage,279,-,-,-
2167,Blue Jay Cage,280,-,-,-
2168,Cardinal Cage,281,-,-,-
2169,Waterfall Wall,-,-,136,-
2170,Lavafall Wall,-,-,137,-
2171,Crimson Seeds,199,-,-,-
2172,Heavy Work Bench,283,-,-,-
2173,Copper Plating,284,-,-,-
2174,Snail Cage,285,-,-,-
2175,Glowing Snail Cage,286,-,-,-
2177,Ammo Box,287,-,-,-
2178,Monarch Butterfly Jar,288,-,-,-
2179,Purple Emperor Butterfly Jar,289,-,-,-
2180,Red Admiral Butterfly Jar,290,-,-,-
2181,Ulysses Butterfly Jar,291,-,-,-
2182,Sulphur Butterfly Jar,292,-,-,-
2183,Tree Nymph Butterfly Jar,293,-,-,-
2184,Zebra Swallowtail Butterfly Jar,294,-,-,-
2185,Julia Butterfly Jar,295,-,-,-
2186,Scorpion Cage,296,-,-,-
2187,Black Scorpion Cage,297,-,-,-
2190,Frog Cage,298,-,-,-
2191,Mouse Cage,299,-,-,-
2192,Bone Welder,300,-,-,-
2193,Flesh Cloning Vat,301,-,-,-
2194,Glass Kiln,302,-,-,-
2195,Lihzahrd Furnace,303,-,-,-
2196,Living Loom,304,-,-,-
2197,Sky Mill,305,-,-,-
2198,Ice Machine,306,-,-,-
2203,Steampunk Boiler,307,-,-,-
2204,Honey Dispenser,308,-,-,-
2206,Penguin Cage,309,-,-,-
2207,Worm Cage,310,-,-,-
2210,Ebonwood Fence,-,-,138,-
2211,Rich Mahogany Fence,-,-,139,-
2212,Pearlwood Fence,-,-,140,-
2213,Shadewood Fence,-,-,141,-
2224,Large Dynasty Lantern,34,22,-,-
2225,Dynasty Lamp,93,17,-,-
2226,Dynasty Lantern,42,26,-,-
2227,Large Dynasty Candle,100,17,-,-
2228,Dynasty Chair,15,27,-,-
2229,Dynasty Work Bench,18,18,-,-
2230,Dynasty Chest,21,28,-,-
2231,Dynasty Bed,79,21,-,-
2232,Dynasty Bathtub,90,16,-,-
2233,Dynasty Bookcase,101,22,-,-
2234,Dynasty Cup,13,5,-,-
2235,Dynasty Bowl,103,1,-,-
2236,Dynasty Candle,33,17,-,-
2237,Dynasty Clock,104,1,-,-
2238,Golden Clock,104,2,-,-
2239,Glass Clock,104,3,-,-
2240,Honey Clock,104,4,-,-
2241,Steampunk Clock,104,5,-,-
2242,Fancy Dishes,103,2,-,-
2243,Glass Bowl,103,3,-,-
2244,Wine Glass,13,6,-,-
2245,Living Wood Piano,87,5,-,-
2246,Flesh Piano,87,6,-,-
2247,Frozen Piano,87,7,-,-
2248,Frozen Table,14,24,-,-
2249,Honey Chest,21,29,-,-
2250,Steampunk Chest,21,30,-,-
2251,Honey Work Bench,18,19,-,-
2252,Frozen Work Bench,18,20,-,-
2253,Steampunk Work Bench,18,21,-,-
2254,Glass Piano,87,8,-,-
2255,Honey Piano,87,9,-,-
2256,Steampunk Piano,87,10,-,-
2257,Honey Cup,13,7,-,-
2258,Chalice,13,8,-,-
2259,Dynasty Table,14,25,-,-
2260,Dynasty Wood,311,-,-,-
2261,Red Dynasty Shingles,312,-,-,-
2262,Blue Dynasty Shingles,313,-,-,-
2263,White Dynasty Wall,-,-,142,-
2264,Blue Dynasty Wall,-,-,143,-
2265,Dynasty Door,10,28,-,-
2271,Arcane Rune Wall,-,-,144,-
2274,Ultrabright Torch,4,12,-,-
2281,Tiger Skin,242,22,-,-
2282,Leopard Skin,242,23,-,-
2283,Zebra Skin,242,24,-,-
2288,Frozen Chair,15,28,-,-
2333,Iron Fence,-,-,145,-
2334,Wooden Crate,376,-,-,-
2335,Iron Crate,376,1,-,-
2336,Golden Crate,376,2,-,-
2340,Minecart Track,314,-,-,-
2357,Shiverthorn Seeds,82,6,-,-
2376,Blue Dungeon Piano,87,11,-,-
2377,Green Dungeon Piano,87,12,-,-
2378,Pink Dungeon Piano,87,13,-,-
2379,Golden Piano,87,14,-,-
2380,Obsidian Piano,87,15,-,-
2381,Bone Piano,87,16,-,-
2382,Cactus Piano,87,17,-,-
2383,Spooky Piano,87,18,-,-
2384,Skyware Piano,87,19,-,-
2385,Lihzahrd Piano,87,20,-,-
2386,Blue Dungeon Dresser,88,5,-,-
2387,Green Dungeon Dresser,88,6,-,-
2388,Pink Dungeon Dresser,88,7,-,-
2389,Golden Dresser,88,8,-,-
2390,Obsidian Dresser,88,9,-,-
2391,Bone Dresser,88,10,-,-
2392,Cactus Dresser,88,11,-,-
2393,Spooky Dresser,88,12,-,-
2394,Skyware Dresser,88,13,-,-
2395,Honey Dresser,88,14,-,-
2396,Lihzahrd Dresser,88,15,-,-
2397,Sofa,89,1,-,-
2398,Ebonwood Sofa,89,2,-,-
2399,Rich Mahogany Sofa,89,3,-,-
2400,Pearlwood Sofa,89,4,-,-
2401,Shadewood Sofa,89,5,-,-
2402,Blue Dungeon Sofa,89,6,-,-
2403,Green Dungeon Sofa,89,7,-,-
2404,Pink Dungeon Sofa,89,8,-,-
2405,Golden Sofa,89,9,-,-
2406,Obsidian Sofa,89,10,-,-
2407,Bone Sofa,89,11,-,-
2408,Cactus Sofa,89,12,-,-
2409,Spooky Sofa,89,13,-,-
2410,Skyware Sofa,89,14,-,-
2411,Honey Sofa,89,15,-,-
2412,Steampunk Sofa,89,16,-,-
2413,Mushroom Sofa,89,17,-,-
2414,Glass Sofa,89,18,-,-
2415,Pumpkin Sofa,89,19,-,-
2416,Lihzahrd Sofa,89,20,-,-
2432,Copper Plating Wall,-,-,146,-
2433,Stone Slab Wall,-,-,147,-
2434,Sail,-,-,148,-
2435,Coralstone Block,315,-,-,-
2439,Blue Jellyfish Jar,316,-,-,-
2440,Green Jellyfish Jar,317,-,-,-
2441,Pink Jellyfish Jar,318,-,-,-
2442,Life Preserver,240,46,-,-
2443,Ship's Wheel,240,47,-,-
2444,Compass Rose,240,48,-,-
2445,Wall Anchor,240,49,-,-
2446,Goldfish Trophy,240,50,-,-
2447,Bunnyfish Trophy,240,51,-,-
2448,Swordfish Trophy,240,52,-,-
2449,Sharkteeth Trophy,240,53,-,-
2489,King Slime Trophy,240,54,-,-
2490,Ship in a Bottle,319,-,-,-
2492,Pressure Plate Track,314,1,-,-
2495,Treasure Map,242,25,-,-
2496,Seaweed Planter,320,-,-,-
2497,Pillagin Me Pixels,242,26,-,-
2503,Boreal Wood,321,-,-,-
2504,Palm Wood,322,-,-,-
2505,Boreal Wood Wall,-,-,149,-
2506,Palm Wood Wall,-,-,151,-
2507,Boreal Wood Fence,-,-,150,-
2508,Palm Wood Fence,-,-,152,-
2518,Palm Wood Platform,19,17,-,-
2519,Palm Wood Bathtub,90,17,-,-
2520,Palm Wood Bed,79,22,-,-
2521,Palm Wood Bench,89,21,-,-
2522,Palm Wood Candelabra,100,18,-,-
2523,Palm Wood Candle,33,18,-,-
2524,Palm Wood Chair,15,29,-,-
2525,Palm Wood Chandelier,34,23,-,-
2526,Palm Wood Chest,21,31,-,-
2527,Palm Wood Sofa,89,22,-,-
2528,Palm Wood Door,10,29,-,-
2529,Palm Wood Dresser,88,16,-,-
2530,Palm Wood Lantern,42,27,-,-
2531,Palm Wood Piano,87,21,-,-
2532,Palm Wood Table,14,26,-,-
2533,Palm Wood Lamp,93,18,-,-
2534,Palm Wood Work Bench,18,22,-,-
2536,Palm Wood Bookcase,101,23,-,-
2537,Mushroom Bathtub,90,18,-,-
2538,Mushroom Bed,79,23,-,-
2539,Mushroom Bench,89,23,-,-
2540,Mushroom Bookcase,101,24,-,-
2541,Mushroom Candelabra,100,19,-,-
2542,Mushroom Candle,33,19,-,-
2543,Mushroom Chandelier,34,24,-,-
2544,Mushroom Chest,21,32,-,-
2545,Mushroom Dresser,88,17,-,-
2546,Mushroom Lantern,42,28,-,-
2547,Mushroom Lamp,93,19,-,-
2548,Mushroom Piano,87,22,-,-
2549,Mushroom Platform,19,18,-,-
2550,Mushroom Table,14,27,-,-
2552,Boreal Wood Bathtub,90,19,-,-
2553,Boreal Wood Bed,79,24,-,-
2554,Boreal Wood Bookcase,101,25,-,-
2555,Boreal Wood Candelabra,100,20,-,-
2556,Boreal Wood Candle,33,20,-,-
2557,Boreal Wood Chair,15,30,-,-
2558,Boreal Wood Chandelier,34,25,-,-
2559,Boreal Wood Chest,21,33,-,-
2560,Boreal Wood Clock,104,6,-,-
2561,Boreal Wood Door,10,30,-,-
2562,Boreal Wood Dresser,88,18,-,-
2563,Boreal Wood Lamp,93,20,-,-
2564,Boreal Wood Lantern,42,29,-,-
2565,Boreal Wood Piano,87,23,-,-
2566,Boreal Wood Platform,19,19,-,-
2567,Slime Bathtub,90,20,-,-
2568,Slime Bed,79,25,-,-
2569,Slime Bookcase,101,26,-,-
2570,Slime Candelabra,100,21,-,-
2571,Slime Candle,33,21,-,-
2572,Slime Chair,15,31,-,-
2573,Slime Chandelier,34,26,-,-
2574,Slime Chest,21,34,-,-
2575,Slime Clock,104,7,-,-
2576,Slime Door,10,31,-,-
2577,Slime Dresser,88,19,-,-
2578,Slime Lamp,93,21,-,-
2579,Slime Lantern,42,30,-,-
2580,Slime Piano,87,24,-,-
2581,Slime Platform,19,20,-,-
2582,Slime Sofa,89,25,-,-
2583,Slime Table,14,29,-,-
2589,Duke Fishron Trophy,240,55,-,-
2591,Bone Clock,104,8,-,-
2592,Cactus Clock,104,9,-,-
2593,Ebonwood Clock,104,10,-,-
2594,Frozen Clock,104,11,-,-
2595,Lihzahrd Clock,104,12,-,-
2596,Living Wood Clock,104,13,-,-
2597,Rich Mahogany Clock,104,14,-,-
2598,Flesh Clock,104,15,-,-
2599,Mushroom Clock,104,16,-,-
2600,Obsidian Clock,104,17,-,-
2601,Palm Wood Clock,104,18,-,-
2602,Pearlwood Clock,104,19,-,-
2603,Pumpkin Clock,104,20,-,-
2604,Shadewood Clock,104,21,-,-
2605,Spooky Clock,104,22,-,-
2606,Skyware Clock,104,23,-,-
2612,Green Dungeon Chest,21,35,-,-
2613,Pink Dungeon Chest,21,37,-,-
2614,Blue Dungeon Chest,21,39,-,-
2615,Bone Chest,21,41,-,-
2616,Cactus Chest,21,42,-,-
2617,Flesh Chest,21,43,-,-
2618,Obsidian Chest,21,44,-,-
2619,Pumpkin Chest,21,45,-,-
2620,Spooky Chest,21,46,-,-
2625,Seashell,324,-,-,-
2626,Starfish,324,1,-,-
2627,Steampunk Platform,19,21,-,-
2628,Skyware Platform,19,22,-,-
2629,Living Wood Platform,19,23,-,-
2630,Honey Platform,19,24,-,-
2631,Skyware Work Bench,18,24,-,-
2632,Glass Work Bench,18,25,-,-
2633,Living Wood Work Bench,18,26,-,-
2634,Flesh Sofa,89,26,-,-
2635,Frozen Sofa,89,27,-,-
2636,Living Wood Sofa,89,28,-,-
2637,Pumpkin Dresser,88,20,-,-
2638,Steampunk Dresser,88,21,-,-
2639,Glass Dresser,88,22,-,-
2640,Flesh Dresser,88,23,-,-
2641,Pumpkin Lantern,42,31,-,-
2642,Obsidian Lantern,42,32,-,-
2643,Pumpkin Lamp,93,22,-,-
2644,Obsidian Lamp,93,23,-,-
2645,Blue Dungeon Lamp,93,24,-,-
2646,Green Dungeon Lamp,93,25,-,-
2647,Pink Dungeon Lamp,93,26,-,-
2648,Honey Candle,33,22,-,-
2649,Steampunk Candle,33,23,-,-
2650,Spooky Candle,33,24,-,-
2651,Obsidian Candle,33,25,-,-
2652,Blue Dungeon Chandelier,34,27,-,-
2653,Green Dungeon Chandelier,34,28,-,-
2654,Pink Dungeon Chandelier,34,29,-,-
2655,Steampunk Chandelier,34,30,-,-
2656,Pumpkin Chandelier,34,31,-,-
2657,Obsidian Chandelier,34,32,-,-
2658,Blue Dungeon Bathtub,90,21,-,-
2659,Green Dungeon Bathtub,90,22,-,-
2660,Pink Dungeon Bathtub,90,23,-,-
2661,Pumpkin Bathtub,90,24,-,-
2662,Obsidian Bathtub,90,25,-,-
2663,Golden Bathtub,90,26,-,-
2664,Blue Dungeon Candelabra,100,22,-,-
2665,Green Dungeon Candelabra,100,23,-,-
2666,Pink Dungeon Candelabra,100,24,-,-
2667,Obsidian Candelabra,100,25,-,-
2668,Pumpkin Candelabra,100,26,-,-
2669,Pumpkin Bed,79,26,-,-
2670,Pumpkin Bookcase,101,27,-,-
2671,Pumpkin Piano,87,25,-,-
2672,Shark Statue,105,50,-,-
2677,Amber Gemspark Wall,-,-,153,-
2678,Offline Amber Gemspark Wall,-,-,157,-
2679,Amethyst Gemspark Wall,-,-,154,-
2680,Offline Amethyst Gemspark Wall,-,-,158,-
2681,Diamond Gemspark Wall,-,-,155,-
2682,Offline Diamond Gemspark Wall,-,-,159,-
2683,Emerald Gemspark Wall,-,-,156,-
2684,Offline Emerald Gemspark Wall,-,-,160,-
2685,Ruby Gemspark Wall,-,-,164,-
2686,Offline Ruby Gemspark Wall,-,-,161,-
2687,Sapphire Gemspark Wall,-,-,165,-
2688,Offline Sapphire Gemspark Wall,-,-,162,-
2689,Topaz Gemspark Wall,-,-,166,-
2690,Offline Topaz Gemspark Wall,-,-,163,-
2691,Tin Plating Wall,-,-,167,-
2692,Tin Plating,325,-,-,-
2693,Waterfall Block,326,-,-,-
2694,Lavafall Block,327,-,-,-
2695,Confetti Block,328,-,-,-
2696,Confetti Wall,-,-,168,-
2697,Midnight Confetti Block,329,-,-,-
2698,Midnight Confetti Wall,-,-,169,-
2699,Weapon Rack,334,-,-,-
2700,Fireworks Box,335,-,-,-
2701,Living Fire Block,336,-,-,-
2702,'0' Statue,337,-,-,-
2703,'1' Statue,337,1,-,-
2704,'2' Statue,337,2,-,-
2705,'3' Statue,337,3,-,-
2706,'4' Statue,337,4,-,-
2707,'5' Statue,337,5,-,-
2708,'6' Statue,337,6,-,-
2709,'7' Statue,337,7,-,-
2710,'8' Statue,337,8,-,-
2711,'9' Statue,337,9,-,-
2712,'A' Statue,337,10,-,-
2713,'B' Statue,337,11,-,-
2714,'C' Statue,337,12,-,-
2715,'D' Statue,337,13,-,-
2716,'E' Statue,337,14,-,-
2717,'F' Statue,337,15,-,-
2718,'G' Statue,337,16,-,-
2719,'H' Statue,337,17,-,-
2720,'I' Statue,337,18,-,-
2721,'J' Statue,337,19,-,-
2722,'K' Statue,337,20,-,-
2723,'L' Statue,337,21,-,-
2724,'M' Statue,337,22,-,-
2725,'N' Statue,337,23,-,-
2726,'O' Statue,337,24,-,-
2727,'P' Statue,337,25,-,-
2728,'Q' Statue,337,26,-,-
2729,'R' Statue,337,27,-,-
2730,'S' Statue,337,28,-,-
2731,'T' Statue,337,29,-,-
2732,'U' Statue,337,30,-,-
2733,'V' Statue,337,31,-,-
2734,'W' Statue,337,32,-,-
2735,'X' Statue,337,33,-,-
2736,'Y' Statue,337,34,-,-
2737,'Z' Statue,337,35,-,-
2738,Firework Fountain,338,-,-,-
2739,Booster Track,314,2,-,-
2741,Grasshopper Cage,339,-,-,-
2742,Music Box (Underground Crimson),139,31,-,-
2743,Cactus Table,14,30,-,-
2744,Cactus Platform,19,25,-,-
2748,Glass Chest,21,47,-,-
2751,Living Cursed Fire Block,340,-,-,-
2752,Living Demon Fire Block,341,-,-,-
2753,Living Frost Fire Block,342,-,-,-
2754,Living Ichor Block,343,-,-,-
2755,Living Ultrabright Fire Block,344,-,-,-
2787,Honeyfall Block,345,-,-,-
2788,Honeyfall Wall,-,-,172,-
2789,Chlorophyte Brick Wall,-,-,173,-
2790,Crimtane Brick Wall,-,-,174,-
2791,Shroomite Plating Wall,-,-,175,-
2792,Chlorophyte Brick,346,-,-,-
2793,Crimtane Brick,347,-,-,-
2794,Shroomite Plating,348,-,-,-
2809,Martian Astro Clock,104,24,-,-
2810,Martian Bathtub,90,27,-,-
2811,Martian Bed,79,27,-,-
2812,Martian Hover Chair,15,32,-,-
2813,Martian Chandelier,34,33,-,-
2814,Martian Chest,21,48,-,-
2815,Martian Door,10,32,-,-
2816,Martian Dresser,88,24,-,-
2817,Martian Holobookcase,101,28,-,-
2818,Martian Hover Candle,33,26,-,-
2819,Martian Lamppost,93,27,-,-
2820,Martian Lantern,42,33,-,-
2821,Martian Piano,87,26,-,-
2822,Martian Platform,19,26,-,-
2823,Martian Sofa,89,29,-,-
2824,Martian Table,14,31,-,-
2825,Martian Table Lamp,100,27,-,-
2826,Martian Work Bench,18,27,-,-
2827,Wooden Sink,172,-,-,-
2828,Ebonwood Sink,172,1,-,-
2829,Rich Mahogany Sink,172,2,-,-
2830,Pearlwood Sink,172,3,-,-
2831,Bone Sink,172,4,-,-
2832,Flesh Sink,172,5,-,-
2833,Living Wood Sink,172,6,-,-
2834,Skyware Sink,172,7,-,-
2835,Shadewood Sink,172,8,-,-
2836,Lihzahrd Sink,172,9,-,-
2837,Blue Dungeon Sink,172,10,-,-
2838,Green Dungeon Sink,172,11,-,-
2839,Pink Dungeon Sink,172,12,-,-
2840,Obsidian Sink,172,13,-,-
2841,Metal Sink,172,14,-,-
2842,Glass Sink,172,15,-,-
2843,Golden Sink,172,16,-,-
2844,Honey Sink,172,17,-,-
2845,Steampunk Sink,172,18,-,-
2846,Pumpkin Sink,172,19,-,-
2847,Spooky Sink,172,20,-,-
2848,Frozen Sink,172,21,-,-
2849,Dynasty Sink,172,22,-,-
2850,Palm Wood Sink,172,23,-,-
2851,Mushroom Sink,172,24,-,-
2852,Boreal Wood Sink,172,25,-,-
2853,Slime Sink,172,26,-,-
2854,Cactus Sink,172,27,-,-
2855,Martian Sink,172,28,-,-
2860,Martian Conduit Plating,350,-,-,-
2861,Martian Conduit Wall,-,-,176,-
2865,Castle Marsberg,242,27,-,-
2866,Martia Lisa,242,28,-,-
2867,The Truth Is Up There,242,29,-,-
2868,Smoke Block,351,-,-,-
2897,Angry Trapper Banner,91,109,-,-
2898,Armored Viking Banner,91,110,-,-
2899,Black Slime Banner,91,111,-,-
2900,Blue Armored Bones Banner,91,112,-,-
2901,Blue Cultist Archer Banner,91,113,-,-
2902,Blue Cultist Caster Banner,91,114,-,-
2903,Blue Cultist Fighter Banner,91,115,-,-
2904,Bone Lee Banner,91,116,-,-
2905,Clinger Banner,91,117,-,-
2906,Cochineal Beetle Banner,91,118,-,-
2907,Corrupt Penguin Banner,91,119,-,-
2908,Corrupt Slime Banner,91,120,-,-
2909,Corruptor Banner,91,121,-,-
2910,Crimslime Banner,91,122,-,-
2911,Cursed Skull Banner,91,123,-,-
2912,Cyan Beetle Banner,91,124,-,-
2913,Devourer Banner,91,125,-,-
2914,Diabolist Banner,91,126,-,-
2915,Doctor Bones Banner,91,127,-,-
2916,Dungeon Slime Banner,91,128,-,-
2917,Dungeon Spirit Banner,91,129,-,-
2918,Elf Archer Banner,91,130,-,-
2919,Elf Copter Banner,91,131,-,-
2920,Eyezor Banner,91,132,-,-
2921,Flocko Banner,91,133,-,-
2922,Ghost Banner,91,134,-,-
2923,Giant Bat Banner,91,135,-,-
2924,Giant Cursed Skull Banner,91,136,-,-
2925,Giant Flying Fox Banner,91,137,-,-
2926,Gingerbread Man Banner,91,138,-,-
2927,Goblin Archer Banner,91,139,-,-
2928,Green Slime Banner,91,140,-,-
2929,Headless Horseman Banner,91,141,-,-
2930,Hell Armored Bones Banner,91,142,-,-
2931,Hellhound Banner,91,143,-,-
2932,Hoppin' Jack Banner,91,144,-,-
2933,Ice Bat Banner,91,145,-,-
2934,Ice Golem Banner,91,146,-,-
2935,Ice Slime Banner,91,147,-,-
2936,Ichor Sticker Banner,91,148,-,-
2937,Illuminant Bat Banner,91,149,-,-
2938,Illuminant Slime Banner,91,150,-,-
2939,Jungle Bat Banner,91,151,-,-
2940,Jungle Slime Banner,91,152,-,-
2941,Krampus Banner,91,153,-,-
2942,Lac Beetle Banner,91,154,-,-
2943,Lava Bat Banner,91,155,-,-
2944,Lava Slime Banner,91,156,-,-
2945,Martian Brainscrambler Banner,91,157,-,-
2946,Martian Drone Banner,91,158,-,-
2947,Martian Engineer Banner,91,159,-,-
2948,Martian Gigazapper Banner,91,160,-,-
2949,Martian Gray Grunt Banner,91,161,-,-
2950,Martian Officer Banner,91,162,-,-
2951,Martian Ray Gunner Banner,91,163,-,-
2952,Martian Scutlix Gunner Banner,91,164,-,-
2953,Martian Tesla Turret Banner,91,165,-,-
2954,Mister Stabby Banner,91,166,-,-
2955,Mother Slime Banner,91,167,-,-
2956,Necromancer Banner,91,168,-,-
2957,Nutcracker Banner,91,169,-,-
2958,Paladin Banner,91,170,-,-
2959,Penguin Banner,91,171,-,-
2960,Pinky Banner,91,172,-,-
2961,Poltergeist Banner,91,173,-,-
2962,Possessed Armor Banner,91,174,-,-
2963,Present Mimic Banner,91,175,-,-
2964,Purple Slime Banner,91,176,-,-
2965,Ragged Caster Banner,91,177,-,-
2966,Rainbow Slime Banner,91,178,-,-
2967,Raven Banner,91,179,-,-
2968,Red Slime Banner,91,180,-,-
2969,Rune Wizard Banner,91,181,-,-
2970,Rusty Armored Bones Banner,91,182,-,-
2971,Scarecrow Banner,91,183,-,-
2972,Scutlix Banner,91,184,-,-
2973,Skeleton Archer Banner,91,185,-,-
2974,Skeleton Commando Banner,91,186,-,-
2975,Skeleton Sniper Banner,91,187,-,-
2976,Slimer Banner,91,188,-,-
2977,Snatcher Banner,91,189,-,-
2978,Snow Balla Banner,91,190,-,-
2979,Snowman Gangsta Banner,91,191,-,-
2980,Spiked Ice Slime Banner,91,192,-,-
2981,Spiked Jungle Slime Banner,91,193,-,-
2982,Splinterling Banner,91,194,-,-
2983,Squid Banner,91,195,-,-
2984,Tactical Skeleton Banner,91,196,-,-
2985,The Groom Banner,91,197,-,-
2986,Tim Banner,91,198,-,-
2987,Undead Miner Banner,91,199,-,-
2988,Undead Viking Banner,91,200,-,-
2989,White Cultist Archer Banner,91,201,-,-
2990,White Cultist Caster Banner,91,202,-,-
2991,White Cultist Fighter Banner,91,203,-,-
2992,Yellow Slime Banner,91,204,-,-
2993,Yeti Banner,91,205,-,-
2994,Zombie Elf Banner,91,206,-,-
2995,Sparky,242,30,-,-
2996,Vine Rope,353,-,-,-
2999,Bewitching Table,354,-,-,-
3000,Alchemy Table,355,-,-,-
3004,Bone Torch,4,13,-,-
3044,Music Box (Lunar Boss),139,32,-,-
3045,Rainbow Torch,4,14,-,-
3046,Cursed Campfire,215,1,-,-
3047,Demon Campfire,215,2,-,-
3048,Frozen Campfire,215,3,-,-
3049,Ichor Campfire,215,4,-,-
3050,Rainbow Campfire,215,5,-,-
3055,Acorns,242,31,-,-
3056,Cold Snap,242,32,-,-
3057,Cursed Saint,242,33,-,-
3058,Snowfellas,242,34,-,-
3059,The Season,242,35,-,-
3064,Enchanted Sundial,356,-,-,-
3066,Smooth Marble Block,357,-,-,-
3067,Hellstone Brick Wall,-,-,177,-
3070,Gold Bird Cage,358,-,-,-
3071,Gold Bunny Cage,359,-,-,-
3072,Gold Butterfly Jar,360,-,-,-
3073,Gold Frog Cage,361,-,-,-
3074,Gold Grasshopper Cage,362,-,-,-
3075,Gold Mouse Cage,363,-,-,-
3076,Gold Worm Cage,364,-,-,-
3077,Silk Rope,365,-,-,-
3078,Web Rope,366,-,-,-
3081,Marble Block,367,-,-,-
3082,Marble Wall,-,-,183,-
3083,Smooth Marble Wall,-,-,179,-
3086,Granite Block,368,-,-,-
3087,Smooth Granite Block,369,-,-,-
3088,Granite Wall,-,-,184,-
3089,Smooth Granite Wall,-,-,181,-
3100,Meteorite Brick,370,-,-,-
3101,Meteorite Brick Wall,-,-,182,-
3113,Pink Slime Block,371,-,-,-
3114,Pink Torch,4,15,-,-
3117,Peace Candle,372,-,-,-
3125,Granite Chest,21,50,-,-
3126,Meteorite Clock,104,25,-,-
3127,Marble Clock,104,27,-,-
3128,Granite Clock,104,26,-,-
3129,Meteorite Door,10,33,-,-
3130,Marble Door,10,35,-,-
3131,Granite Door,10,34,-,-
3132,Meteorite Dresser,88,25,-,-
3133,Marble Dresser,88,27,-,-
3134,Granite Dresser,88,26,-,-
3135,Meteorite Lamp,93,28,-,-
3136,Marble Lamp,93,30,-,-
3137,Granite Lamp,93,29,-,-
3138,Meteorite Lantern,42,34,-,-
3139,Marble Lantern,42,36,-,-
3140,Granite Lantern,42,35,-,-
3141,Meteorite Piano,87,27,-,-
3142,Marble Piano,87,29,-,-
3143,Granite Piano,87,28,-,-
3144,Meteorite Platform,19,27,-,-
3145,Marble Platform,19,29,-,-
3146,Granite Platform,19,28,-,-
3147,Meteorite Sink,172,29,-,-
3148,Marble Sink,172,31,-,-
3149,Granite Sink,172,30,-,-
3150,Meteorite Sofa,89,30,-,-
3151,Marble Sofa,89,32,-,-
3152,Granite Sofa,89,31,-,-
3153,Meteorite Table,14,32,-,-
3154,Marble Table,14,34,-,-
3155,Granite Table,14,33,-,-
3156,Meteorite Work Bench,18,28,-,-
3157,Marble Work Bench,18,30,-,-
3158,Granite Work Bench,18,29,-,-
3159,Meteorite Bathtub,90,28,-,-
3160,Marble Bathtub,90,30,-,-
3161,Granite Bathtub,90,29,-,-
3162,Meteorite Bed,79,28,-,-
3163,Marble Bed,79,30,-,-
3164,Granite Bed,79,29,-,-
3165,Meteorite Bookcase,101,29,-,-
3166,Marble Bookcase,101,31,-,-
3167,Granite Bookcase,101,30,-,-
3168,Meteorite Candelabra,100,28,-,-
3169,Marble Candelabra,100,30,-,-
3170,Granite Candelabra,100,29,-,-
3171,Meteorite Candle,33,27,-,-
3172,Marble Candle,33,29,-,-
3173,Granite Candle,33,28,-,-
3174,Meteorite Chair,15,33,-,-
3175,Marble Chair,15,35,-,-
3176,Granite Chair,15,34,-,-
3177,Meteorite Chandelier,34,34,-,-
3178,Marble Chandelier,34,36,-,-
3179,Granite Chandelier,34,35,-,-
3180,Meteorite Chest,21,49,-,-
3181,Marble Chest,21,51,-,-
3182,Magic Water Dropper,373,-,-,-
3184,Magic Lava Dropper,374,-,-,-
3185,Magic Honey Dropper,375,-,-,-
3198,Sharpening Station,377,-,-,-
3202,Target Dummy,378,-,-,-
3203,Corrupt Crate,376,3,-,-
3204,Crimson Crate,376,4,-,-
3205,Dungeon Crate,376,5,-,-
3206,Sky Crate,376,6,-,-
3207,Hallowed Crate,376,7,-,-
3208,Jungle Crate,376,8,-,-
3214,Bubble,379,-,-,-
3215,Daybloom Planter Box,380,-,-,-
3216,Moonglow Planter Box,380,1,-,-
3217,Deathweed Planter Box,380,2,-,-
3218,Deathweed Planter Box,380,3,-,-
3219,Blinkroot Planter Box,380,4,-,-
3220,Waterleaf Planter Box,380,5,-,-
3221,Shiverthorn Planter Box,380,6,-,-
3222,Fireblossom Planter Box,380,7,-,-
3229,Golden Cross Grave Marker,85,6,-,-
3230,Golden Tombstone,85,7,-,-
3231,Golden Grave Marker,85,8,-,-
3232,Golden Gravestone,85,9,-,-
3233,Golden Headstone,85,10,-,-
3234,Crystal Block,385,-,-,-
3235,Music Box (Martian Madness),139,33,-,-
3236,Music Box (Pirate Invasion),139,34,-,-
3237,Music Box (Hell),139,35,-,-
3238,Crystal Block Wall,-,-,186,-
3239,Trap Door,387,-,-,-
3240,Tall Gate,388,-,-,-
3253,Lava Lamp,390,-,-,-
3254,Enchanted Nightcrawler Cage,391,-,-,-
3255,Buggy Cage,392,-,-,-
3256,Grubby Cage,393,-,-,-
3257,Sluggy Cage,394,-,-,-
3261,Spectre Bar,239,21,-,-
3270,Item Frame,395,-,-,-
3271,Sandstone Block,396,-,-,-
3272,Hardened Sand Block,397,-,-,-
-,-,-,-,187,-
3274,Hardened Ebonsand Block,398,-,-,-
3275,Hardened Crimsand Block,399,-,-,-
3276,Ebonsandstone Block,400,-,-,-
3277,Crimsandstone Block,401,-,-,-
3338,Hardened Pearlsand Block,402,-,-,-
3339,Pearlsandstone Block,403,-,-,-
-,-,-,-,216,-
-,-,-,-,217,-
-,-,-,-,218,-
-,-,-,-,219,-
-,-,-,-,220,-
-,-,-,-,221,-
-,-,-,-,222,-
3347,Desert Fossil,404,-,-,-
3348,Desert Fossil Wall,-,-,223,-
3357,Ancient Cultist Trophy,240,56,-,-
3358,Martian Saucer Trophy,240,57,-,-
3359,Flying Dutchman Trophy,240,58,-,-
3360,Living Mahogany Wand,383,-,-,-
3361,Rich Mahogany Leaf Wand,384,-,-,-
3364,Fireplace,405,-,-,-
3365,Chimney,406,-,-,-
3369,Confetti Cannon,209,2,-,-
3370,Music Box (The Towers),139,36,-,-
3371,Music Box (Goblin Invasion),139,37,-,-
3380,Sturdy Fossil,407,-,-,-
3385,Strange Plant,227,8,-,-
3386,Strange Plant,227,9,-,-
3387,Strange Plant,227,10,-,-
3388,Strange Plant,227,11,-,-
3390,Goblin Summoner Banner,91,207,-,-
3391,Salamander Banner,91,208,-,-
3392,Giant Shelly Banner,91,209,-,-
3393,Crawdad Banner,91,210,-,-
3394,Fritz Banner,91,211,-,-
3395,Creature From The Deep Banner,91,212,-,-
3396,Dr. Man Fly Banner,91,213,-,-
3397,Mothron Banner,91,214,-,-
3398,Severed Hand Banner,91,215,-,-
3399,The Possessed Banner,91,216,-,-
3400,Butcher Banner,91,217,-,-
3401,Psycho Banner,91,218,-,-
3402,Deadly Sphere Banner,91,219,-,-
3403,Nailhead Banner,91,220,-,-
3404,Poisonous Spore Banner,91,221,-,-
3405,Medusa Banner,91,222,-,-
3406,Hoplite Banner,91,223,-,-
3407,Granite Elemental Banner,91,224,-,-
3408,Grolem Banner,91,225,-,-
3409,Blood Zombie Banner,91,226,-,-
3410,Drippler Banner,91,227,-,-
3411,Tomb Crawler Banner,91,228,-,-
3412,Dune Splicer Banner,91,229,-,-
3413,Antlion Swarmer Banner,91,230,-,-
3414,Antlion Charger Banner,91,231,-,-
3415,Ghoul Banner,91,232,-,-
3416,Lamia Banner,91,233,-,-
3417,Desert Spirit Banner,91,234,-,-
3418,Basilisk Banner,91,235,-,-
3419,Ravager Scorpion Banner,91,236,-,-
3420,Stargazer Banner,91,237,-,-
3421,Milkyway Weaver Banner,91,238,-,-
3422,Flow Invader Banner,91,239,-,-
3423,Twinkle Popper Banner,91,240,-,-
3424,Small Star Cell Banner,91,241,-,-
3425,Star Cell Banner,91,242,-,-
3426,Corite Banner,91,243,-,-
3427,Sroller Banner,91,244,-,-
3428,Crawltipede Banner,91,245,-,-
3429,Drakomire Rider Banner,91,246,-,-
3430,Drakomire Banner,91,247,-,-
3431,Selenian Banner,91,248,-,-
3432,Predictor Banner,91,249,-,-
3433,Brain Suckler Banner,91,250,-,-
3434,Nebula Floater Banner,91,251,-,-
3435,Evolution Beast Banner,91,252,-,-
3436,Alien Larva Banner,91,253,-,-
3437,Alien Queen Banner,91,254,-,-
3438,Alien Hornet Banner,91,255,-,-
3439,Vortexian Banner,91,256,-,-
3440,Storm Diver Banner,91,257,-,-
3441,Pirate Captain Banner,91,258,-,-
3442,Pirate Deadeye Banner,91,259,-,-
3443,Pirate Corsair Banner,91,260,-,-
3444,Pirate Crossbower Banner,91,261,-,-
3445,Martian Walker Banner,91,262,-,-
3446,Red Devil Banner,91,263,-,-
3447,Pink Jellyfish Banner,91,264,-,-
3448,Green Jellyfish Banner,91,265,-,-
3449,Dark Mummy Banner,91,266,-,-
3450,Light Mummy Banner,91,267,-,-
3451,Angry Bones Banner,91,268,-,-
3452,Ice Tortoise Banner,91,269,-,-
3460,Luminite,408,-,-,-
3461,Luminite Brick,409,-,-,-
3467,Luminite Bar,239,22,-,-
3472,Luminite Brick Wall,-,-,224,-
3536,Vortex Monolith,410,-,-,-
3537,Nebula Monolith,410,1,-,-
3538,Stardust Monolith,410,2,-,-
3539,Solar Monolith,410,3,-,-
3545,Detonator,411,-,-,-
3549,Ancient Manipulator,412,-,-,-
3565,Red Squirrel Cage,413,-,-,-
3566,Gold Squirrel Cage,414,-,-,-
3573,Solar Fragment Block,415,-,-,-
3574,Vortex Fragment Block,416,-,-,-
3575,Nebula Fragment Block,417,-,-,-
3576,Stardust Fragment Block,418,-,-,-
3584,Living Leaf Wall,-,-,60,-
3593,Sand Slime Banner,91,270,-,-
3594,Sea Snail Banner,91,271,-,-
3595,Moon Lord Trophy,240,59,-,-";
    }
}
