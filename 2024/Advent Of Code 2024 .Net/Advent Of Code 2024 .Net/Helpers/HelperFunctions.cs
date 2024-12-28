using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Helpers
{
    internal static class HelperFunctions
    {
        public static Dictionary<int, int> GetCountDictionary(List<int> ints)
        {
            var counter = new Dictionary<int, int>();
            foreach (var i in ints)
            {
                if (counter.ContainsKey(i))
                {
                    counter[i]++;
                }
                else
                {
                    counter[i] = 1;
                }
            }
            return counter;
        }

        internal static T DeepCopy<T>(this T self)
        {
            var serialized = JsonConvert.SerializeObject(self);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        internal static T[] DeepCopyArray<T>(this T[] array) where T : ICloneable
        {
            return array.Select(item => (T)item.Clone()).ToArray();
        }
    }
}
