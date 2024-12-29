using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day16
{
    internal class ReindeerMazeInput
    {
        public string[] Maze;
        public ReindeerMazeInput(string inputTextFile)
        {
            try
            {
                Maze = File.ReadAllLines(inputTextFile);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                throw;
            }
        }
    }
}
