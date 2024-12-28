using Advent_Of_Code_2024_.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Advent_Of_Code_2024_.Net.Day13
{

    internal class ClawContraptionInput
    {
        public readonly List<ClawMachine> ClawMachines;

        private const string buttonPattern = @"Button\s*[A-B]:\s*X\+(\d+),\s*Y\+(\d+)";
        private const string pricePattern = @"Prize\s*:\s*X=(\d+),\s*Y=(\d+)";

        public ClawContraptionInput(string inputTextFile)
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

            ClawMachines = new List<ClawMachine>();
            for (int i = 0; i < lines.Length; i += 4)
            {
                Button buttonA = getButton(lines[i]);
                Button buttonB = getButton(lines[i + 1]);
                GridPointLong price = getPrice(lines[i + 2]);

                ClawMachines.Add(new ClawMachine(buttonA, buttonB, price));
            }
        }

        private Button getButton(string buttonLine)
        {
            Match match = Regex.Match(buttonLine, buttonPattern);

            if (match.Success)
            {
                var xMovement = int.Parse(match.Groups[1].Value);
                var yMovement = int.Parse(match.Groups[2].Value);
                return new Button(xMovement, yMovement);
            }
            else
            {
                Console.WriteLine($"No button at line {buttonLine}");
                throw new Exception($"No button at line {buttonLine}");
            }
        }

        private GridPointLong getPrice(string priceLine)
        {
            Match match = Regex.Match(priceLine, pricePattern);

            if (match.Success)
            {
                var xLocation = long.Parse(match.Groups[1].Value);
                var ylocation = long.Parse(match.Groups[2].Value);
                return new GridPointLong(xLocation, ylocation);
            }
            else
            {
                Console.WriteLine($"No price at line {priceLine}");
                throw new Exception($"No price at line {priceLine}");
            }
        }
    }
}
