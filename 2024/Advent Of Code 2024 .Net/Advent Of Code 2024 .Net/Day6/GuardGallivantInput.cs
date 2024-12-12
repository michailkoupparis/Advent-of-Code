using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day6
{
    internal class GuardGallivantInput
    {
        public readonly string[] Room;

        public GuardGallivantInput(string textFile)
        {
            try
            {
                Room = File.ReadAllLines(textFile);
            }
            catch(IOException e) {

                Console.WriteLine($"Error reading file: {e.Message}");
                throw;
            }
        }
    }
}
