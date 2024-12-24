using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Helpers
{
    public class Button
    {
        private int MoveX;
        private int MoveY;

        public Button(int moveX, int moveY)
        {
            MoveX = moveX;
            MoveY = moveY;
        }

        public GridPointLong GetNext(GridPointLong gridPoint)
        {
            return new GridPointLong(gridPoint.X + MoveX, gridPoint.Y + MoveY);
        }

        public GridPointLong GetPrevious(GridPointLong gridPoint)
        {
            return new GridPointLong(gridPoint.X - MoveX, gridPoint.Y - MoveY);
        }

        public int GetX() { return MoveX; }

        public int GetY() { return MoveY; }

        public override string ToString()
        {
            return $"({MoveX}, {MoveY})";
        }
    }
}
