using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day3
{
    internal class MullItOver
    {
        /// <summary>
        /// Part 1 of Mull It Over task
        /// </summary>
        /// <param name="corruptedInput"></param>
        /// <returns></returns>
        public static int CheckMulAndAddResults(string corruptedInput)
        {
            int sum = 0;
            int pointer = 0;
            while (pointer < corruptedInput.Length)
            {
                for (int i = pointer; i < corruptedInput.Length; i++)
                {
                    if (corruptedInput[i] == 'm')
                    {
                        pointer = i;
                        break;
                    }
                }
                sum += findMull(corruptedInput, ref pointer);
            }
            return sum;
        }

        /// <summary>
        /// Part 2 of Mull It Over task
        /// </summary>
        /// <param name="corruptedInput"></param>
        /// <returns></returns>
        public static int CheckMulAndAddResultsWithEnabled(string corruptedInput)
        {
            int sum = 0;
            int pointer = 0;
            bool isEnabled = true;
            while (pointer < corruptedInput.Length)
            {
                if (!isEnabled)
                {
                    for (int i = pointer; i < corruptedInput.Length; i++)
                    {
                        if(corruptedInput[i]  == 'd')
                        {
                            pointer = i;
                            break;
                        }
                    }
                    isEnabled = findDo(corruptedInput, ref pointer);
                    continue;
                }
                if (corruptedInput[pointer] == 'd')
                {
                    if (checkDont(corruptedInput, pointer))
                    {
                        isEnabled = false;
                        pointer += 7;
                        continue;
                    }
                    pointer++;
                    continue;
                }
                sum += findMull(corruptedInput, ref pointer);
            }
            return sum;
        }

        private static bool checkDont(string corruptedInput, int pointer)
        {
            if (pointer + 7 > corruptedInput.Length - 1)
            {
                return false;
            }

            return corruptedInput.Substring(pointer, 7) == "don't()";
        }

        private static bool findDo(string corruptedInput, ref int pointer)
        {
            if (pointer + 4 > corruptedInput.Length - 1)
            {
                pointer = corruptedInput.Length;
                return false;
            }

            if (corruptedInput.Substring(pointer, 4) == "do()")
            {
                pointer += 4;
                return true;
            }

            pointer++;
            return false;
        }

        private static int findMull(string corruptedInput, ref int pointer)
        {
            if (pointer + 4 > corruptedInput.Length - 1)
            {
                pointer = corruptedInput.Length;
                return 0;
            }

            if (corruptedInput.Substring(pointer, 4) != "mul(")
            {
                pointer++;
                return 0;
            }
            pointer += 4;

            string num1str = readDigitsUntilChar(corruptedInput.Substring(pointer, corruptedInput.Length - pointer - 1), ',');
            int num1;
            if (!int.TryParse(num1str, out num1))
            {
                return 0;
            }
            pointer += num1str.Length + 1;

            string num2str = readDigitsUntilChar(corruptedInput.Substring(pointer, corruptedInput.Length - pointer - 1), ')');
            int num2;
            if (!int.TryParse(num2str, out num2))
            {
                return 0;
            }
            pointer += num2str.Length + 1;

            return num1 * num2;
        }

        private static string readDigitsUntilChar(string input, char endChar)
        {
            string candidateNum = "";
            foreach (char s in input)
            {
                if (char.IsDigit(s))
                {
                    candidateNum += s;
                }
                else if (s == endChar)
                {
                    return candidateNum;
                }
                else
                {
                    break;
                }
            }

            return "";
        }

    }
}
