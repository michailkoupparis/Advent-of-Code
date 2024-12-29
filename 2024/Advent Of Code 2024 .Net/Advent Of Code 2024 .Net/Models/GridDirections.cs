using Advent_Of_Code_2024_.Net.EnumsConsts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Models
{
    internal class GridDirections

    {
        private Dictionary<int, char> Directions = new Dictionary<int, char>();

        public GridDirections()
        {
            Directions.Add(0, Consts.DIR_SYMBOL_UP);
            Directions.Add(1, Consts.DIR_SYMBOL_RIGHT);
            Directions.Add(2, Consts.DIR_SYMBOL_DOWN);
            Directions.Add(3, Consts.DIR_SYMBOL_LEFT);
        }

        public Dictionary<int, char> GetAllDirections()
        {
            return Directions;
        }

        public char Get90deegrees(int id)
        {
            return Directions[(id + 1) % 4];
        }

        public char Get90deegreesAntiClockWise(int id)
        {
            return Directions[(id - 1) % 4];
        }

        public char Get180deegrees(int id)
        {
            return Directions[(id + 2) % 4];
        }
    }
}
