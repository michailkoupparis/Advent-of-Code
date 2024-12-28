using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Models
{
    public class ClawMachine
    {
        public Button ButtonA;
        public Button ButtonB;
        public GridPointLong Price;

        public ClawMachine(Button buttonA, Button buttonB, GridPointLong gridPoint)
        {
            ButtonA = buttonA;
            ButtonB = buttonB;
            Price = gridPoint;
        }
    }
}
