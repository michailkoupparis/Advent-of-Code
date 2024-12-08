using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day3
{
    internal class MullItOverInput
    {
        public readonly string CorruptedString;
        public MullItOverInput(string inputTextFile)
        {
            try
            {
                CorruptedString = File.ReadAllText(inputTextFile);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                throw;
            }
        }
    }
}
