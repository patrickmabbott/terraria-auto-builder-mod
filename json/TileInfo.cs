using System;
using System.IO;
using System.Linq;
using AutoBuilder.Items;
using AutoBuilder.Model;
using AutoBuilder.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Terraria;
using Terraria.ModLoader.IO;
using Terraria.ObjectData;
using Player = On.Terraria.Player;

namespace AutoBuilder.json
{
    public class TileInfo : TagSerializable
    {
        public int CollisionType { get; set; } = -1;
        public int TileId { get; set; }
        public int WallId { get; set; }
        public IntPair Position { get; set; }
        public bool IsAnchorTile { get; set; } = false;
        public bool IsExternalBlock { get; set; } = false;
        public int Style { get; set; } = -1;
        public int Alternate { get; set; } = -1;
        public bool IsActive { get; set; } = true;
        public bool HasActuator { get; set; } = false;
        public byte TileColor { get; private set; }
        public byte WallColor { get; set; }
        public bool HasWire1 { get; private set; }
        public bool HasWire2 { get; private set; }
        public bool HasWire3 { get; private set; }
        public bool HasWire4 { get; private set; }
        public byte Slope { get; set; } = 0;
        public byte Liquid { get; set; } = 0;
        public int LiquidType { get; set; } = 0;
        public bool HalfBrick { get; set; } = false;

        public int Height { get; set; } = 1;
        public int Width { get; set; } = 1;

        public static readonly Func<TagCompound, TileInfo> DESERIALIZER = Load;

        public TagCompound SerializeData()
        {
            return new TagCompound
            {
                ["CollisionType"] = CollisionType,
                ["TileId"] = TileId,
                ["WallId"] = WallId,
                ["Position"] = Position,
                ["IsAnchorTile"] = IsAnchorTile,
                ["IsExternalBlock"] = IsExternalBlock,
                ["Style"] = Style,
                ["Alternate"] = Alternate,
                ["IsActive"] = IsActive,
                ["HasActuator"] = HasActuator,
                ["TileColor"] = TileColor,
                ["WallColor"] = WallColor,
                ["HasWire1"] = HasWire1,
                ["HasWire2"] = HasWire2,
                ["HasWire3"] = HasWire3,
                ["HasWire4"] = HasWire4,
                ["Height"] = Height,
                ["Width"] = Width,
                ["Slope"] = Slope,
                ["HalfBrick"] = HalfBrick,
                ["Liquid"] = Liquid,
                ["LiquidType"] = LiquidType
            };
        }

        public static TileInfo Load(TagCompound tag)
        {
            TileInfo info = new TileInfo();
            info.CollisionType = tag.GetInt("CollisionType");
            info.TileId = tag.GetInt("TileId");
            info.WallId = tag.GetInt("WallId");
            info.Position = tag.Get<IntPair>("Position");
            info.IsAnchorTile = tag.GetBool("IsAnchorTile");
            info.IsExternalBlock = tag.GetBool("IsExternalBlock");
            info.Style = tag.GetInt("Style");
            info.Alternate = tag.GetInt("Alternate");
            info.IsActive = tag.GetBool("IsActive");
            info.HasActuator = tag.GetBool("HasActuator");
            info.TileColor = tag.GetByte("TileColor");
            info.WallColor = tag.GetByte("WallColor");
            info.HasWire1 = tag.GetBool("HasWire1");
            info.HasWire2 = tag.GetBool("HasWire2");
            info.HasWire3 = tag.GetBool("HasWire3");
            info.HasWire4 = tag.GetBool("HasWire4");
            info.Height = tag.GetInt("Height");
            info.Width = tag.GetInt("Width");
            info.Slope = tag.GetByte("Slope");
            info.HalfBrick = tag.GetBool("HalfBrick");
            info.Liquid = tag.GetByte("Liquid");
            info.LiquidType = tag.GetInt("LiquidType");
            return info;
        }

        [JsonIgnore] //We are ignoring tile ids 0 and 2 (grass and dirt) for outer perimeter
        public bool IsValidForOuterPerimeter => (IsBlock && TileId != 0 && TileId != 2) ||
                                              IsDoor || IsTrapdoor || IsPlatform;

        [JsonIgnore]
        public bool IsBlock => CollisionType > 0 && !IsDoor && Height == 1;

        [JsonIgnore]
        //Mostly only blocks and doors have collision types. So, use height to differentiate in a way that should still work for non-vanilla
        public bool IsDoor => (TileId == 10 || TileId == 11) || (CollisionType > 0 && Height == 3 );

        [JsonIgnore]
        public bool IsObject => TileId > 0 && CollisionType <= 0;

        [JsonIgnore]
        public bool HasNoTile => TileId == 0 && !IsBlock;

        [JsonIgnore]
        public bool HasWall => WallId > 0;

        [JsonIgnore] public bool IsPlatform => TileId == 19 || (ToPlaceable()?.IsPlatform ?? false);

        [JsonIgnore] //Assuming no mods are going to make a trap door.
        public bool IsTrapdoor => TileId == 387;

        [JsonIgnore]
        private string _tileName;

        [JsonIgnore]
        private string _wallName;

        private TileIdentifier ToTileId()
        {
            return new TileIdentifier(this.TileId, this.Style);
        }

        /**
         * The item that creates this item. Useful for stuff like determining if player
         * has this item in inventory/storage or getting name to associate to the tile.
         */
        [JsonIgnore]
        public string TileName
        {
            get
            {
                if (_tileName == null && !HasNoTile)
                {
                    DataOrganizer.Instance.TileNames.TryGetValue(ToTileId(), out _tileName);
                }
                return _tileName;
            }
        }

        /**
         * The item that creates this item. Useful for stuff like determining if player
         * has this item in inventory/storage or getting name to associate to the tile.
         */
        [JsonIgnore]
        public string WallName
        {
            get
            {
                if (HasWall && _wallName == null)
                {
                    DataOrganizer.Instance.WallNames.TryGetValue(WallId, out _wallName);
                }
                return _wallName;
            }
        }

        [JsonIgnore]
        private Placeable _placeable;

        public Placeable ToPlaceable(bool useWallEntry = false)
        {
            string nameToCheck = useWallEntry ? this.WallName : this.TileName;
            Constants.Logger.Info($"Checking {nameToCheck} {_placeable} against {Constants.GetCatalogEntries().Values.Count}");
            if (_placeable == null && !string.IsNullOrEmpty(nameToCheck))
            {
                PlaceableCatalogEntry catalogEntry =
                    Constants.GetCatalogEntries().Values.FirstOrDefault(entry => entry.IsMember(nameToCheck, null, true));
                //Only returning if we can provide a catalog entry. Otherwise, a lot of uses of placeable
                //will have to be null checked.
                if (catalogEntry != null)
                {
                    _placeable = new Placeable(nameToCheck, useWallEntry ? -1 : TileId,
                        useWallEntry ? WallId : -1, Style, catalogEntry, 1);
                }
            }

            return _placeable;
        }

        [JsonIgnore]
        private Placeable _wallPlaceable;

        public Placeable ToWallPlaceable()
        {
            if (_placeable == null && this.WallName != null)
            {
                PlaceableCatalogEntry catalogEntry =
                    Constants.GetCatalogEntries().Values.First(entry => entry.IsMember(this.WallName, null, true));
                //Only returning if we can provide a catalog entry. Otherwise, a lot of uses of placeable
                //will have to be null checked.
                if (catalogEntry != null)
                {
                    _placeable = new Placeable(WallName, -1, WallId, Style, catalogEntry, 1);
                }
            }

            return _placeable;
        }

        public bool AreSame(TileInfo other)
        {
            return other != null && this.TileId == other.TileId && this.CollisionType == other.CollisionType;
        }

        /**
         * Doors, unfortunately, seem to require some extra TLC due to what appears to be some buggy implementation.
         * Have yet to see another tile type exhibit same behavior. But, may need to expand this logic if that happens.
         * For now, limit potential misfires by limiting to doors only.
         */
        private void ProcessDoor(in TileObjectData data, int style, int alternate)
        {
            //Doors exhibit some... unfortunately style reporting behavior. This is probably a bug.
            int styleRange = data.StyleWrapLimit > 0 ? data.StyleWrapLimit : Constants.DOOR_STYLE_ID_RANGE;
            if (data.Style >= styleRange * 4)
            {
                this.Style = styleRange + style % styleRange;
            }
            else
            {
                this.Style = style % styleRange;
            }

            this.Alternate = alternate;
        }

        public void FromTile(Tile tile, IntPair position)
        {
            this.TileId = tile.type;
            this.WallId = tile.wall;
            this.CollisionType = tile.collisionType;
            if (this.TileId > 0 && this.TileId != 54)
            {
                Constants.Logger.Info($"Collision Type {tile.collisionType} tile id {TileId}");
            }
            TileObjectData data = TileObjectData.GetTileData(tile);
            if (data != null)
            {
                int style = -1;
                int alternate = -1;
                TileObjectData.GetTileInfo(tile, ref style, ref alternate);
                if (tile.type == Constants.DOOR_CLOSED_TILE_ID || tile.type == Constants.DOOR_OPEN_TILE_ID)
                {
                    ProcessDoor(data, style, alternate);
                }
                else
                {
                    this.Style = style;
                    this.Alternate = alternate;
                }

                if (data.Height <= 0 || data.Width <= 0)
                {
                    //Firstly, see if we can get it from the category.
                    Placeable placeable = ToPlaceable();
                    if (placeable?.CatalogEntry != null)
                    {
                        this.Height = placeable.CatalogEntry.Height;
                        this.Width = placeable.CatalogEntry.Width;
                    }
                    else if (TileId == 10 || TileId == 11)
                    {
                        this.Height = 3;
                    }
                    else if(position != null)
                    {
                        IntPair dimensions = GeometryUtils.DetermineDimensions(position.X, position.Y, this);
                        this.Width = Math.Max(1, dimensions.X);
                        this.Height = Math.Max(dimensions.Y, 1);
                    }
                }
                else
                {
                    this.Height = data.Height;
                    this.Width = data.Width;
                }
            }

            this.IsActive = tile.inActive();
            this.HasActuator = tile.actuator();
            this.TileColor = tile.color();
            this.WallColor = tile.wallColor();
            this.HasWire1 = tile.wire();
            this.HasWire2 = tile.wire2();
            this.HasWire3 = tile.wire3();
            this.HasWire4 = tile.wire4();
            this.Slope = tile.slope();
            this.HalfBrick = tile.halfBrick();
            this.Liquid = tile.liquid;
            this.LiquidType = tile.liquidType();
        }

        public void  ToTile(Tile tile)
        {
            tile.inActive(this.IsActive);
            tile.actuator(this.HasActuator);
            tile.color(this.TileColor);
            tile.wallColor(this.WallColor);
            tile.wire(this.HasWire1);
            tile.wire2(this.HasWire2);
            tile.wire3(this.HasWire3);
            tile.wire4(this.HasWire4);
            tile.slope(this.Slope);
            tile.halfBrick(this.HalfBrick);
            tile.liquid = this.Liquid;
            tile.liquidType(LiquidType);
        }

        public string ToJson()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StringWriter writer = new StringWriter())
            {
                using (JsonWriter jsonWriter = new JsonTextWriter(writer))
                {
                    serializer.Serialize(writer, this);
                    return writer.ToString();
                }
            }
        }

        public override string ToString()
        {
            return $" {nameof(TileName)}: {TileName}, {nameof(WallName)}: {WallName}, {nameof(TileId)}: {TileId}, {nameof(WallId)}: {WallId}, Prefix : {ToPlaceable()?.CatalogEntry?.Prefix} Suffix : {ToPlaceable()?.CatalogEntry?.Suffix} {nameof(Position)}: {Position}, {nameof(CollisionType)}: {CollisionType}, {nameof(IsExternalBlock)}: {IsExternalBlock}, {nameof(Style)}: {Style}, {nameof(Alternate)}: {Alternate}, {nameof(IsActive)}: {IsActive}, {nameof(HasActuator)}: {HasActuator}, {nameof(TileColor)}: {TileColor}, {nameof(WallColor)}: {WallColor}, {nameof(HasWire1)}: {HasWire1}, {nameof(HasWire2)}: {HasWire2}, {nameof(HasWire3)}: {HasWire3}, {nameof(HasWire4)}: {HasWire4}, {nameof(Height)}: {Height}, {nameof(Width)}: {Width}, {nameof(IsBlock)}: {IsBlock}, {nameof(IsDoor)}: {IsDoor}, {nameof(IsObject)}: {IsObject}, {nameof(HasNoTile)}: {HasNoTile}, {nameof(HasWall)}: {HasWall}";
        }
    }
}
