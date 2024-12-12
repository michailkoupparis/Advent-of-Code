using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Helpers
{
    public class GridPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool CheckGridBoundary(List<string> grid)
        {
            return X <= grid.Count - 1
                && X >= 0
                && Y <= grid[X].Length - 1
                && Y >= 0;
        }

        public bool CheckGridBoundary(string[] grid)
        {
            return X <= grid.Length - 1
                && X >= 0
                && Y <= grid[X].Length - 1
                && Y >= 0;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public override bool Equals(object? obj)
        {
            if (obj is GridPoint other)
            {
                return this.X == other.X && this.Y == other.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }

}
