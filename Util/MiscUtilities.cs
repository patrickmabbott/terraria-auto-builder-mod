using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoBuilder.Model;

namespace AutoBuilder.Util
{
    /**
     * Utilities that don't fit neatly within any category big enough to get its own utilities class (yet)
     */
    public static class MiscUtilities
    {

        public static void AddKeyToDictionary<K, V>(IDictionary<K, V> map, K key, V startingValue)
        {
            if (!map.ContainsKey(key))
            {
                map.Add(key, startingValue);
            }
        }

        public static void AddCountToDictionary<K>(IDictionary<K, int> map, K key, int value)
        {
            if (!map.ContainsKey(key))
            {
                map.Add(key, value);
            }
            else
            {
                map[key] = map[key] + value;
            }
        }

        public static void AddToOrderedMultimap<K,V>(IDictionary<K, IList<V>> map, K key, V value)
        {
            if (!map.ContainsKey(key))
            {
                map.Add(key, new List<V>());
            }

            map[key].Add(value);
        }

        public static void AddToMultimap<K, V>(IDictionary<K, ISet<V>> map, K key, V value)
        {
            if (!map.ContainsKey(key))
            {
                map.Add(key, new HashSet<V>());
            }

            map[key].Add(value);
        }

        private static Random random = new Random();


        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static T RandomEntry<T>(ICollection<T> collection)
        {
            if (collection.Count == 0)
            {
                return default;
            }

            if (collection.Count == 1)
            {
                return collection.First();
            }
            int randNum = random.Next(collection.Count);
            return collection.Skip(randNum).First();
        }
    }
}
