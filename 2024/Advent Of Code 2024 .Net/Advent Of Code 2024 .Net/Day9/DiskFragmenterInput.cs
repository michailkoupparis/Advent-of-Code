using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day9
{
    internal class DiskFragmenterInput
    {
        public readonly string DISK;

        public DiskFragmenterInput(string textFile)
        {
            try
            {
                DISK = File.ReadAllText(textFile);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                throw;
            }
        }
    }
}
