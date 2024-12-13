using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day7
{
    internal static class BridgeRepair
    {
        /// <summary>
        /// Task 1 and 2 of the Bridge Repair task
        /// </summary>
        /// <param name="equations"></param>
        /// <returns></returns>
        public static long SumValidEquations(List<EquationItem> equations, bool allowConc)
        {
            long sum = 0;
            foreach (EquationItem equation in equations)
            {
                if (checkEquation(equation, allowConc))
                {
                    sum += equation.Result;
                }
            }
            return sum;
        }

        private static bool checkEquation(EquationItem equation, bool allowConc)
        {
            if (equation.Factors.Length == 0)
            {
                return false;
            }

            if (equation.Factors.Length == 1)
            {
                return equation.Result == equation.Factors[0];
            }

            Queue<long> possibleResults = new Queue<long>();
            possibleResults.Enqueue(equation.Factors[0]);
            for (int i = 1; i < equation.Factors.Length; i++)
            {
                bool isValid = false;
                int currentResultsCount = possibleResults.Count;
                for (int j = 0; j < currentResultsCount; j++)
                {
                    long currResult = possibleResults.Dequeue();

                    long sum = currResult + equation.Factors[i];
                    if (sum <= equation.Result)
                    {
                        isValid = true;
                        possibleResults.Enqueue(sum);
                    }

                    long prod = currResult * equation.Factors[i];
                    if (prod <= equation.Result)
                    {
                        isValid = true;
                        possibleResults.Enqueue(prod);
                    }

                    if (allowConc)
                    {
                        long conc = long.Parse(currResult.ToString() +  equation.Factors[i].ToString());
                        if (conc <= equation.Result)
                        {
                            isValid = true;
                            possibleResults.Enqueue(conc);
                        }
                    }
                }
                if (!isValid)
                {
                    return false;
                }
            }

            return possibleResults.Any(x => x == equation.Result);
        }
    }
}
