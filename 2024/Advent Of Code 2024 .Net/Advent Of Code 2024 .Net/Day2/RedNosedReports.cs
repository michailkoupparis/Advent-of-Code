using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day2
{
    internal static class RedNosedReports
    {
        /// <summary>
        /// For Part 1 of the Red-Nosed Reports task
        /// </summary>
        /// <param name="reports"></param>
        /// <returns></returns>
        public static int GetSafeReports(List<List<int>> reports)
        {
            int safeReportsCount = 0;
            foreach (var report in reports)
            {
                if (checkReportSafetyWithOneMistake(report, true))
                {
                    safeReportsCount++;
                }
            }

            return safeReportsCount;
        }


        /// <summary>
        /// For Part 2 of the Red-Nosed Reports task
        /// </summary>
        /// <param name="reports"></param>
        /// <returns></returns>
        public static int GetSafeReportsWithProblemDamper(List<List<int>> reports)
        {
            int safeRepotsCount = 0;
            foreach (var report in reports)
            {
                if (checkReportSafetyWithOneMistake(report, false))
                {
                    safeRepotsCount++;
                }
            }

            return safeRepotsCount;
        }

        private static bool checkReportSafetyWithOneMistake(List<int> report, bool isMistakeHappened, int? isIncreasingFactor = null)
        {
            int reportLength = report.Count;
            if (reportLength == 0 || reportLength == 1)
            {
                return true;
            }

            isIncreasingFactor = isIncreasingFactor ?? (report[0] < report[1] ? 1 : -1);
            bool isSafe = true;
            for (int i = 0; i < reportLength - 1; i++)
            {
                int reportDiff = isIncreasingFactor.Value * (report[i + 1] - report[i]);
                if (reportDiff < 1 || reportDiff > 3)
                {
                    if (isMistakeHappened) return false;

                    if (i == 1)
                    {
                        bool skipFirst = checkReportSafetyWithOneMistake(
                        report.GetRange(i, reportLength - i),
                        true,
                        null);

                        if (skipFirst)
                        {
                            return true;
                        }
                    }

                    bool skipNext = i + 2 > reportLength || checkReportSafetyWithOneMistake(
                        new List<int> { report[i] }.Concat(report.GetRange(i + 2, reportLength - i - 2)).ToList(),
                        true,
                        i == 0 ? null : isIncreasingFactor);

                    if (skipNext)
                    {
                        return true;
                    }

                    List<int> optionSkipCurrent = new List<int>();
                    if (i-1 >= 0)
                    {
                        optionSkipCurrent.Add(report[i - 1]);
                    }
                    bool skipCurrent = checkReportSafetyWithOneMistake(
                        optionSkipCurrent.Concat(report.GetRange(i + 1, reportLength - i - 1)).ToList(),
                        true,
                        i - 1 == 0 ? null : isIncreasingFactor);

                    return skipCurrent;
                }
            }

            return isSafe;
        }
    }
}
