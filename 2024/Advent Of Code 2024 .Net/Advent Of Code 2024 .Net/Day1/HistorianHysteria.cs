using Advent_Of_Code_2024_.Net.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day1
{
    internal static class HistorianHysteria
    {
        /// <summary>
        /// For Part 1 of the HistorianHysteria task
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static int calculateDistance(List<int> list1, List<int> list2)
        {
            list1.Sort();
            list2.Sort();

            int difference = 0;
            for (int i = 0; i < list1.Count; i++)
            {
                difference += Math.Abs(list1[i] - list2[i]); ;
            }

            return difference;
        }

        /// <summary>
        /// For Part 2 of the HistorianHysteria task
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static int calculateSimilarity(List<int> list1, List<int> list2)
        {
            Dictionary<int, int> countList1 = HelperFunctions.GetCountDictionary(list1);
            Dictionary<int, int> countList2 = HelperFunctions.GetCountDictionary(list2);

            int similarity = 0;
            foreach(var item in countList1)
            {
                if (countList2.ContainsKey(item.Key))
                {
                    similarity += item.Key * item.Value * countList2[item.Key];
                }
            }
            return similarity;
        } 
    }
}
