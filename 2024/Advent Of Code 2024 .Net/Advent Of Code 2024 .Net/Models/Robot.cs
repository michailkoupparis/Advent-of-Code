using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Models
{
    public class Robot : ICloneable
    {
        private GridPoint Position;
        private int MoveX;
        private int MoveY;
        
        public Robot(GridPoint position, int moveX, int moveY)
        {
            Position = position;
            MoveX = moveX;
            MoveY = moveY;
        }

        public object Clone()
        {
            return new Robot(Position, MoveX, MoveY);
        }

        public GridPoint GetPosition()
        {
            return Position;
        }

        public void MoveRobot(int Xdim, int Ydim)
        {
            Position.X += MoveX;
            Position.Y += MoveY;

            if (Position.X >= Xdim)
            {
                Position.X -= Xdim;
            }
            else if (Position.X < 0)
            {
                Position.X += Xdim;
            }

            if (Position.Y >= Ydim)
            {
                Position.Y -= Ydim;
            }
            else if (Position.Y < 0)
            {
                Position.Y += Ydim;
            }
        }

        public override string ToString()
        {
            return $"p={Position},v=({MoveX},{MoveY})";
        }
    }
}
