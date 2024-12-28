using Advent_Of_Code_2024_.Net.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day14
{
    internal class RestroomRedoubtInput
    {
        public readonly List<Robot> Robots;

        private const string robotPattern = @"p=(\d+),(\d+)\s*v=(-?\d+),(-?\d+)";

        public RestroomRedoubtInput(string inputTextFile)
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

            Robots = new List<Robot>();
            foreach (string line in lines)
            {
                Match match = Regex.Match(line, robotPattern);

                if (match.Success)
                {
                    var yPosition = int.Parse(match.Groups[1].Value);
                    var xPosition = int.Parse(match.Groups[2].Value);
                    var yMovement = int.Parse(match.Groups[3].Value);
                    var xMovement = int.Parse(match.Groups[4].Value);
                    Robots.Add(new Robot(new GridPoint(xPosition, yPosition), xMovement, yMovement));
                }
                else
                {
                    Console.WriteLine($"No robot at line {line}");
                    throw new Exception($"No robot at line {line}");
                }
            }
        }
    }
}
