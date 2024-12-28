using Advent_Of_Code_2024_.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day15
{
    internal class WarehouseWoesInput
    {
        public readonly string[] Warehouse;
        public string RobotMovements;

        public WarehouseWoesInput(string inputTextFile)
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

            int warehouseLastIndex = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (!lines[i].StartsWith(WarehouseWoesConsts.WALL))
                {
                    warehouseLastIndex = i - 1;
                    break;
                }
            }

            Warehouse = new string[warehouseLastIndex + 1];
            Array.Copy(lines, 0, Warehouse, 0, warehouseLastIndex + 1);

            RobotMovements = "";
            for (int i = warehouseLastIndex + 1; i < lines.Length; i++)
            {
                RobotMovements += lines[i].TrimEnd();
            }
        }

        public string[] GetDoubleThWarehouse()
        {
            List<string> lines = new List<string>();

            for (int i = 0; i < Warehouse.Length; i++)
            {
                StringBuilder line = new StringBuilder();
                for (int j = 0; j < Warehouse[i].Length; j++)
                {
                    if (Warehouse[i][j] == WarehouseWoesConsts.WALL)
                    {
                        line.Append($"{WarehouseWoesConsts.WALL}{WarehouseWoesConsts.WALL}");
                    }
                    else if (Warehouse[i][j] == WarehouseWoesConsts.BOX)
                    {
                        line.Append($"{WarehouseWoesConsts.LEFT_BOX}{WarehouseWoesConsts.RIGHT_BOX}");
                    }
                    else if (Warehouse[i][j] == WarehouseWoesConsts.EMPTY)
                    {
                        line.Append($"{WarehouseWoesConsts.EMPTY}{WarehouseWoesConsts.EMPTY}");
                    }
                    else if (Warehouse[i][j] == WarehouseWoesConsts.ROBOT)
                    {
                        line.Append($"{WarehouseWoesConsts.ROBOT}{WarehouseWoesConsts.EMPTY}");
                    }
                }
                lines.Add(line.ToString());
            }

            return lines.ToArray();
        }


    }
}
