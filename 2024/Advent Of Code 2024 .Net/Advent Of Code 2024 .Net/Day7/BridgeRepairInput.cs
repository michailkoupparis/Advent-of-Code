using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day7
{
    internal class BridgeRepairInput
    {
        public List<EquationItem> EquationItems;
        public BridgeRepairInput(string textFile)
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines(textFile);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                throw;
            }

            EquationItems = new List<EquationItem>();
            foreach (var line in lines)
            {
                EquationItem equationItem = new EquationItem();
                string[] lineParts = line.Split(':', StringSplitOptions.RemoveEmptyEntries);
                equationItem.Result = (long.Parse(lineParts[0]));

                string[] factors = lineParts[1].Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
                equationItem.Factors = factors.Select(x => long.Parse(x)).ToArray();

                EquationItems.Add(equationItem);
            }
        }
    }
}
