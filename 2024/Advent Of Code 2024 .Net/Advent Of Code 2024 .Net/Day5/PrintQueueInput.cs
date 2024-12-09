using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day5
{
    internal class PrintQueueInput
    {
        public readonly Dictionary<int, List<int>> PageOrderingRules;
        public readonly List<int[]> Protocols;

        public PrintQueueInput(string inputTextFile)
        {
            PageOrderingRules = new Dictionary<int, List<int>>();
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

            int orderingLinesCount = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    orderingLinesCount = i;
                    break;
                }

                string[] lineParts = lines[i].Split("|");
                int pageBefore = int.Parse(lineParts[0]);
                int pageAfter = int.Parse(lineParts[1]);
                if (PageOrderingRules.ContainsKey(pageBefore))
                {
                    PageOrderingRules[pageBefore].Add(pageAfter);
                }
                else
                {
                    PageOrderingRules.Add(pageBefore, new List<int>() { pageAfter });
                }
            }

            Protocols = new List<int[]>();
            for (int i = orderingLinesCount + 1; i < lines.Length; i++)
            {
                string[] lineParts = lines[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
                Protocols.Add(lineParts.Select(x => int.Parse(x)).ToArray());
            }
        }
    }
}
