using Advent_Of_Code_2024_.Net.EnumsConsts;
using Advent_Of_Code_2024_.Net.Models;
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

        public static GridPoint GetNextLocation(GridPoint currLocation, char direction)
        {

            switch (direction)
            {
                case Consts.DIR_SYMBOL_UP:
                    return new GridPoint(currLocation.X - 1, currLocation.Y);
                case Consts.DIR_SYMBOL_RIGHT:
                    return new GridPoint(currLocation.X, currLocation.Y + 1);
                case Consts.DIR_SYMBOL_DOWN:
                    return new GridPoint(currLocation.X + 1, currLocation.Y);
                case Consts.DIR_SYMBOL_LEFT:
                    return new GridPoint(currLocation.X, currLocation.Y - 1);
                default:
                    throw new ArgumentException($"Unknow direction {direction}");
            }
        }

        public static T DeepCopy<T>(this T self)
        {
            var serialized = JsonConvert.SerializeObject(self);
            return JsonConvert.DeserializeObject<T>(serialized);
        }

        public static T[] DeepCopyArray<T>(this T[] array) where T : ICloneable
        {
            return array.Select(item => (T)item.Clone()).ToArray();
        }
    }
}
