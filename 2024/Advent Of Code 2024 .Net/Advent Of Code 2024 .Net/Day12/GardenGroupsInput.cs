using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day12
{
    internal class GardenGroupsInput
    {
        public static readonly GardenGroupsInput Example1 = new GardenGroupsInput(
            new string[]{
                "AAAA",
                "BBCD",
                "BBCC",
                "EEEC"
            });
        
        public static readonly GardenGroupsInput Example2 = new GardenGroupsInput(
            new string[]{
                "OOOOO",
                "OXOXO",
                "OOOOO",
                "OXOXO",
                "OOOOO"
            });

        public static readonly GardenGroupsInput Example3 = new GardenGroupsInput(
             new string[]{
                "EEEEE",
                "EXXXX",
                "EEEEE",
                "EXXXX",
                "EEEEE"
            });

        public static readonly GardenGroupsInput Example4 = new GardenGroupsInput(
             new string[]{
                "AAAAAA",
                "AAABBA",
                "AAABBA",
                "ABBAAA",
                "ABBAAA",
                "AAAAAA"
            });

        public string[] Plots;
        private GardenGroupsInput(string[] plots)
        {
            Plots = plots;
        }

        public GardenGroupsInput(string inputTextFile)
        {
            try
            {
                Plots = File.ReadAllLines(inputTextFile);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                throw;
            }
        }
    }
}
