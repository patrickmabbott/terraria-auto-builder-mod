using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoBuilder.json;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Terraria.ModLoader.IO;

namespace AutoBuilder.Model
{
    public class IntPair : TagSerializable
    {

        public IntPair()
        {

        }
        [JsonConstructor]
        public IntPair(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IntPair(float x, float y)
        {
            X = (int)x;
            Y = (int)y;
        }

        public IntPair(Vector2 vec) : this(vec.X, vec.Y)
        {
        }

        public int X { get; set; }
        public int Y { get; set; }

        public static readonly Func<TagCompound, IntPair> DESERIALIZER = Load;

        public static IntPair operator -(IntPair a, IntPair b)
            => a + -b;

        public static IntPair operator +(IntPair a, IntPair b)
            => new IntPair(a.X + b.X, a.Y + b.Y);

        public static IntPair operator -(IntPair a)
            => new IntPair(-a.X, -a.Y);

        public static IntPair operator *(IntPair a, int mult)
            => new IntPair(a.X * mult, a.Y * mult);

        public static IntPair operator /(IntPair a, int div)
            => new IntPair(a.X / div, a.Y / div);

        public static bool operator ==(IntPair a, IntPair b)
            => a.Equals(b);

        public static bool operator !=(IntPair a, IntPair b)
            => !a.Equals(b);

        public override string ToString()
        {
            return $"{X},{Y}";
        }

        public override int GetHashCode()
        {
            return X + Y * 49;
        }

        public TagCompound SerializeData()
        {
            return new TagCompound
            {
                ["X"] = X,
                ["Y"] = Y
            };
        }

        public static IntPair Load(TagCompound tag)
        {
            IntPair pair = new IntPair();
            pair.X = tag.GetInt("X");
            pair.Y = tag.GetInt("Y");
            return pair;
        }

        public override bool Equals(object obj)
        {
            IntPair rhs = (IntPair)obj;
            return X == rhs.X && Y == rhs.Y;
        }
    }
}
