using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day5
{
    internal static class PrintQueue
    {
        /// <summary>
        /// Part 1 of the Print Queue task
        /// </summary>
        /// <param name="safetyProtocols"></param>
        /// <param name="pageOrderingRules"></param>
        /// <returns></returns>
        public static int GetAdditionOfMiddleSafetyProtocols(List<int[]> safetyProtocols, Dictionary<int, List<int>> pageOrderingRules)
        {
            int sumMiddlePage = 0;
            foreach (var page in safetyProtocols)
            {
                int errorIndex;
                if (checkPageOrdering(page, pageOrderingRules, out errorIndex))
                {
                    sumMiddlePage += getMiddlePoint(page);
                }
            }
            return sumMiddlePage;
        }

        /// <summary>
        /// Part 2 of the Print Queue task
        /// </summary>
        /// <param name="safetyProtocols"></param>
        /// <param name="pageOrderingRules"></param>
        /// <returns></returns>
        public static int CorrectUnsafePagesAndGetMiddleAddition(List<int[]> safetyProtocols, Dictionary<int, List<int>> pageOrderingRules)
        {
            int sumMiddlePage = 0;
            foreach (var page in safetyProtocols)
            {
                int errorIndex;
                if (checkPageOrdering(page, pageOrderingRules, out errorIndex))
                {
                    continue;
                }

                while (errorIndex < page.Length)
                {
                    int temp = page[errorIndex];
                    page[errorIndex] = page[errorIndex-1];
                    page[errorIndex-1] = temp;

                    if(checkPageOrdering(page, pageOrderingRules, out errorIndex)){
                        sumMiddlePage += getMiddlePoint(page);
                        break;
                    }
                }
            }
            return sumMiddlePage;
        }

        private static bool checkPageOrdering(int[] protocol, Dictionary<int, List<int>> pageOrdering, out int errorIndex)
        {
            if (protocol.Length <= 1)
            {
                errorIndex = -1;
                return true;
            }

            for (int i = 1; i < protocol.Length; i++)
            {
                if (!pageOrdering.ContainsKey(protocol[i-1])){
                    errorIndex = i;
                    return false;
                }

                if (!pageOrdering[protocol[i-1]].Contains(protocol[i]))
                {
                    errorIndex = i;
                    return false;
                }

            }

            errorIndex = -1;
            return true;
        }

        private static int getMiddlePoint(int[] protocol)
        {
            return protocol[((protocol.Length + 1) / 2) - 1];
        }
    }
}
