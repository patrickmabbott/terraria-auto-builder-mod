Simple Terraria/TModLoader mod that introduces a series of items that automatically build 
rooms/houses/bases from the items currently in your inventory.
I'm planning to support some basic room and building room layouts and mostly limit to standard furniture
items like chairs, torches, beds, bathtubs etc...
If anyone wishes to fork this project and make it a full mod with dozens of room layouts, intricate structures, 
support for a wide range of placeables etc..., have at it. Alternately, feel free to take bits of the algorithms for
tile placement and other logic to make something completely different.

Usage:
-Equip a buildinator variant (roominator, mansioninator, baseinator etc...).
-Ensure you have the blocks/walls/furniture you want in your inventory
-Use it like a weapon.
-When clicked, it will look in your inventory and catalogue all of the blocks, walls, doors, and "basic" furniture.
--Note that it does this via naming patterns (e.g. borreal wood "chair"). Other methods mostly work for some vanilla furniture but are unreliable for modded sets.
-In the default configuration, it will try to find a matching set that forms a valid house.
--e.g. two frozen doors, frozen chair, ice block, frozen table, ice torch, and ice wall. It will also sub in couches, bathtubs, Lanterns etc...
-If the chosen furniture set contains additional furniture, it will try to place up to 3 additional items.
-Once found, it will place down a standard box house with the various house items (by default, 15 X 8 dimensions to allow for less cluttered furniture placement)
-Most buildinator variants will begin a structure with the lower-right corner at the cursor.
-It will prefer to try creating a themed room. e.g. a bathtub, toilet, and sink for a bathroom or a piano, chandelier, bench, and bookcase as a fancy music room.
--But, if necessary, it'll just throw down furniture at semi-random.
--How many themed rooms are implemented is basically subject to my time (not alot) and artistic sense (abyssmal). So, I would encourage any modder who wants to take this idea up to 11 to fork this project and make something amazing.
-One room at a time not enough to fill your insatiable desire for fancy housing? Enter the mansionator. This will build a large frame in one of a few configurations and then fill it with rooms, as above.


-Developer Notes:
--Alot can be done just by modifying the json files. This was very much designed as a data-centric application.
--CSLD = Comfort/Surface/Light/Door. The requirements of an NPC housing. See https://terraria.gamepedia.com/House

Credits
-This mod would not exist without the instahouse from Fargo's Mutant Mod. I looked at that and asked "how far can I take this?" I also took a look at his code for an initial idea of how to accomplish some of this.