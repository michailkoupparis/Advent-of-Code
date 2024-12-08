using Advent_Of_Code_2024_.Net.Day1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day1
{
    internal class HistorianHysteriaInput
    {
        public static readonly HistorianHysteriaInput ExampleInput =
            new HistorianHysteriaInput(new List<int> { 3, 4, 2, 1, 3, 3 }, new List<int> { 4, 3, 5, 3, 9, 3 });

        public readonly List<int> List1;
        public readonly List<int> List2;

        private HistorianHysteriaInput(List<int> list1, List<int> list2)
        {
            this.List1 = list1;
            this.List2 = list2;
        }

        public HistorianHysteriaInput(string inputTextFile)
        {
            List1 = new List<int>();
            List2 = new List<int>();

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
                string[] lineParts = line.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                List1.Add(int.Parse(lineParts[0]));
                List2.Add(int.Parse(lineParts[1]));
            }

        }

    }
}
