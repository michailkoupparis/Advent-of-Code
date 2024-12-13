using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day8
{
    internal class ResonantCollinearityInput
    {
        public readonly string[] AntenaGrid;

        public ResonantCollinearityInput(string textFile)
        {
            try
            {
                AntenaGrid = File.ReadAllLines(textFile);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                throw;
            }
        }
    }
}
