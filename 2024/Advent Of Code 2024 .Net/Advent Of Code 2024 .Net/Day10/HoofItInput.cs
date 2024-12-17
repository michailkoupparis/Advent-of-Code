using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day10
{
    internal class HoofItInput
    {
        public int[][] HikingTrails;
        public HoofItInput(string inputTextFile)
        {
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

            HikingTrails = lines.Select(row => row.Select(ch => int.Parse(ch.ToString()))
                           .ToArray())
                           .ToArray();
        }
    }
}
