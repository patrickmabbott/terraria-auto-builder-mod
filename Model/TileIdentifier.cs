using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoBuilder.json;

namespace AutoBuilder.Model
{
    public class TileIdentifier : IEquatable<TileIdentifier>
    {
        //Id -1 is valid. Basically means has no tile or object.
        public int TileId { get; set; }
        public int StyleId { get; set; }
        public bool IsWall { get; set; } = false;
        public string Name { get; set; } = "";

        public TileIdentifier(int tileId, int styleId, bool isWall = false, string name = "")
        {
            this.TileId = tileId;
            this.StyleId = styleId;
            this.IsWall = isWall;
            this.Name = name;
        }

        public TileIdentifier FromTileInfo(in TileInfo tileInfo)
        {
            this.TileId = tileInfo.TileId;
            this.StyleId = tileInfo.Style;
            this.Name = tileInfo.TileName;
            return this;
        }

        public bool Equals(TileIdentifier other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return TileId == other.TileId && IsWall == other.IsWall && (IsWall || StyleId == other.StyleId); //Style doesn't matter for walls.
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TileIdentifier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = TileId.GetHashCode();
                if (!IsWall)
                {
                    hashCode = (hashCode * 397) ^ StyleId;
                }
                hashCode = (hashCode * 397) ^ (IsWall ? 2 : 1);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{nameof(TileId)}: {TileId}, {nameof(StyleId)}: {StyleId} {nameof(IsWall)}: {IsWall}";
        }
    }
}
