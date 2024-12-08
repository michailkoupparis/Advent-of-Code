using Advent_Of_Code_2024_.Net.Day1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day2
{
    internal class RedNosedReportsInput
    {
        public static readonly RedNosedReportsInput ExampleInput =
            new RedNosedReportsInput(
                new List<List<int>>() {
                    new List<int> { 7, 6, 4, 2, 1 },
                    new List<int> { 1, 2, 7, 8, 9 },
                    new List<int> { 9, 7, 6, 2, 1 },
                    new List<int> { 1, 3, 2, 4, 5 },
                    new List<int> { 8, 6, 4, 4, 1 },
                    new List<int> { 1, 3, 6, 7, 9 },
                    //new List<int> { 3, 2, 3, 3, 4, 5 },
                    //new List<int> { 55, 56, 55, 53, 51, 50 },
                    //new List<int> { 70, 68, 71, 73, 76, 77, 78, 80 },
                    //new List<int> { 54, 58, 61, 64, 66, 69, 71, 74 },
                    //new List<int> { 45, 52, 55, 56, 59, 60, 63 },
                    //new List<int> { 14, 17, 19, 23, 24 },
                    //new List<int> { 36, 39, 41, 47, 49, 50, 51, 54 }
                   }
                );

        public readonly List<List<int>> Reports;

        private RedNosedReportsInput(List<List<int>> reports)
        {
            this.Reports = reports;
        }

        public RedNosedReportsInput(string inputTextFile)
        {
            Reports = new List<List<int>>();
            string[] lines;
            try
            {
                lines = File.ReadAllLines(inputTextFile);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                throw;
            }

            foreach (var line in lines)
            {
                List<int> report = new List<int>();
                string[] lineParts = line.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var part in lineParts)
                {
                    report.Add(int.Parse(part));
                }
                Reports.Add(report);
            }

        }
    }
}
