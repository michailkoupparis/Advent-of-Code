using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Helpers
{
    public class GridPointLong
    {
        public long X { get; set; }
        public long Y { get; set; }

        public GridPointLong(long x, long y)
        {
            X = x;
            Y = y;
        }

        public bool CheckGridBoundary(List<string> grid)
        {
            return X <= grid.Count - 1
                && X >= 0
                && Y <= grid[(int)X].Length - 1
                && Y >= 0;
        }

        public bool CheckGridBoundary(string[] grid)
        {
            return X <= grid.Length - 1
                && X >= 0
                && Y <= grid[(int)X].Length - 1
                && Y >= 0;
        }

        public bool CheckGridBoundary(int[][] grid)
        {
            return X <= grid.Length - 1
                && X >= 0
                && Y <= grid[(int)X].Length - 1
                && Y >= 0;
        }

        public bool CheckAdjacent(GridPointLong GridPointLong)
        {
            return (X == GridPointLong.X - 1 && Y == GridPointLong.Y) ||
                   (X == GridPointLong.X + 1 && Y == GridPointLong.Y) ||
                   (X == GridPointLong.X && Y == GridPointLong.Y - 1) ||
                   (X == GridPointLong.X && Y == GridPointLong.Y + 1);
        }


        public GridPointLong[] GetAdjacent()
        {
            return new GridPointLong[]
            {
                new GridPointLong(X - 1, Y),
                new GridPointLong(X + 1, Y),
                new GridPointLong(X, Y - 1),
                new GridPointLong(X, Y + 1),
            };
        }

        public Tuple<CellBoundary, GridPointLong>[] GetAdjacentWithDirection()
        {
            return new Tuple<CellBoundary, GridPointLong>[]
            {
                new Tuple<CellBoundary, GridPointLong>(CellBoundary.UP, new GridPointLong(X - 1, Y)),
                new Tuple<CellBoundary, GridPointLong>(CellBoundary.DOWN, new GridPointLong(X + 1, Y)),
                new Tuple<CellBoundary, GridPointLong>(CellBoundary.LEFT, new GridPointLong(X, Y - 1)),
                new Tuple<CellBoundary, GridPointLong>(CellBoundary.RIGHT, new GridPointLong(X, Y + 1))
            };
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public override bool Equals(object? obj)
        {
            if (obj is GridPointLong other)
            {
                return this.X == other.X && this.Y == other.Y;
            }
            return false;
        }

        public static bool operator ==(GridPointLong obj1, GridPointLong obj2)
        {
            if (ReferenceEquals(obj1, null) || ReferenceEquals(obj2, null))
                return false;

            return obj1.X == obj2.X && obj1.Y == obj2.Y;
        }

        public static bool operator !=(GridPointLong obj1, GridPointLong obj2)
        {
            return !(obj1 == obj2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
