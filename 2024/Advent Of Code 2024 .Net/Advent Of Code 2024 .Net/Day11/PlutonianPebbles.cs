using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day11
{
    internal static class PlutonianPebbles
    {

        private static readonly Dictionary<(long, int), long> Memo = new();

        /// <summary>
        /// Part 1, 2 of the Plutonian Pebbles task
        /// </summary>
        /// <param name="pebbles"></param>
        /// <returns></returns>
        public static long GetPebblesAfterBlink(List<long> pebbles, int blinkTimes)
        {
            for (int i = 0; i < blinkTimes; i++)
            {
                int pebblesPointer = 0;
                while (pebblesPointer < pebbles.Count)
                {
                    if (pebbles[pebblesPointer] == 0)
                    {
                        pebbles[pebblesPointer] = 1;
                        pebblesPointer++;
                        continue;
                    }

                    (long, long)? split = null;
                    if (trySplitNumber(pebbles[pebblesPointer], out split))
                    {
                        pebbles[pebblesPointer] = split.Value.Item1;
                        pebblesPointer++;
                        pebbles.Insert(pebblesPointer, split.Value.Item2);
                        pebblesPointer++;
                        continue;
                    }

                    pebbles[pebblesPointer] *= 2024;
                    pebblesPointer++;
                }
            }


            return pebbles.Count;
        }

        /// <summary>
        /// Part 1, 2 of the Plutonian Pebbles task
        /// </summary>
        /// <param name="pebbles"></param>
        /// <returns></returns>
        public static long GetPebblesAfterBlinkRecursive(List<long> pebbles, int blinkTimes)
        {
            long count = 0;
            for (int i = 0; i < pebbles.Count; i++)
            {
                count += getPebblesRecursive(pebbles[i], blinkTimes);
            }

            return count;
        }


        /// <summary>
        /// Part 1, 2 of the Plutonian Pebbles task
        /// </summary>
        /// <param name="pebbles"></param>
        /// <returns></returns>
        public static long GetPebblesAfterBlinkRecursiveMemo(List<long> pebbles, int blinkTimes)
        {
            long count = 0;
            for (int i = 0; i < pebbles.Count; i++)
            {
                count += getPebblesRecursiveMemo(pebbles[i], blinkTimes);
            }

            return count;
        }

        private static long getPebblesRecursiveMemo(long pebble, int blinkTimes)
        {
            if (blinkTimes == 0)
            {
                return 1;
            }

            var key = (pebble, blinkTimes);
            if (Memo.ContainsKey(key))
                return Memo[key];

            long result;
            if (pebble == 0)
            {
                result = getPebblesRecursiveMemo(1, blinkTimes - 1);
            }
            else if (trySplitNumber(pebble, out var split))
            {
                result = getPebblesRecursiveMemo(split.Value.Item1, blinkTimes - 1) +
                         getPebblesRecursiveMemo(split.Value.Item2, blinkTimes - 1);
            }
            else
            {
                result = getPebblesRecursiveMemo(pebble * 2024, blinkTimes - 1);
            }

            Memo[key] = result;
            return result;
        }

        private static long getPebblesRecursive(long pebble, int blinkTimes)
        {
            if (blinkTimes == 0)
            {
                return 1;
            }

            if (pebble == 0)
            {
                return getPebblesRecursive(1, blinkTimes - 1);
            }

            (long, long)? split = null;
            if (trySplitNumber(pebble, out split))
            {
                return getPebblesRecursive(split.Value.Item1, blinkTimes - 1) + getPebblesRecursive(split.Value.Item2, blinkTimes - 1);
            }

            return getPebblesRecursive(pebble * 2024, blinkTimes - 1);
        }

        private static bool trySplitNumber(long num, out (long, long)? split)
        {
            split = null;
            string numStr = num.ToString();
            int length = numStr.Length;
            if (length % 2 != 0)
            {
                return false;
            }

            int mid = length / 2;

            string firstHalfStr = numStr.Substring(0, mid);
            string secondHalfStr = numStr.Substring(mid);

            int firstHalf = string.IsNullOrEmpty(firstHalfStr) ? 0 : int.Parse(firstHalfStr);
            int secondHalf = string.IsNullOrEmpty(secondHalfStr) ? 0 : int.Parse(secondHalfStr);

            split = (firstHalf, secondHalf);
            return true;
        }
    }
}
