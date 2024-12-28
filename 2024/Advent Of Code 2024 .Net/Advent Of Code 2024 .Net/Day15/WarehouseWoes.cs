using Advent_Of_Code_2024_.Net.EnumsConsts;
using Advent_Of_Code_2024_.Net.Helpers;
using Advent_Of_Code_2024_.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day15
{
    internal static class WarehouseWoes
    {
        /// <summary>
        /// Part 1 of the Warehouse Woes task
        /// </summary>
        /// <param name="warehouse"></param>
        /// <param name="robotMovement"></param>
        /// <returns></returns>
        public static int GetBoxesGpsLocations(string[] warehouse, string robotMovement)
        {
            char[][] warehouseM = warehouse.Select(x => x.ToCharArray()).ToArray();
            GridPoint robotLocation = findRobotLocation(warehouseM);

            moveRobotInWarehouse(warehouseM, robotMovement, robotLocation);

            int totalGPScoordinates = 0;
            for (int i = 0; i < warehouseM.Length; i++)
            {
                for (int j = 0; j < warehouseM[i].Length; j++)
                {
                    if (warehouseM[i][j] == WarehouseWoesConsts.BOX)
                    {
                        totalGPScoordinates += 100 * i + j;
                    }
                }
            }

            return totalGPScoordinates;
        }

        /// <summary>
        /// Part 1 of the Warehouse Woes task
        /// </summary>
        /// <param name="warehouse"></param>
        /// <param name="robotMovement"></param>
        /// <returns></returns>
        public static int GetBoxesGpsLocationsDoubleWarehouse(string[] warehouse, string robotMovement)
        {
            char[][] warehouseM = warehouse.Select(x => x.ToCharArray()).ToArray();
            GridPoint robotLocation = findRobotLocation(warehouseM);

            moveRobotInWarehouseDoubleSize(warehouseM, robotMovement, robotLocation);

            int totalGPScoordinates = 0;
            for (int i = 0; i < warehouseM.Length; i++)
            {
                for (int j = 0; j < warehouseM[i].Length; j++)
                {
                    if (warehouseM[i][j] == WarehouseWoesConsts.LEFT_BOX)
                    {
                        totalGPScoordinates += 100 * i + j;
                    }
                }
            }

            return totalGPScoordinates;
        }

        #region generic
        private static GridPoint findRobotLocation(char[][] warehouse)
        {
            for (int i = 0; i < warehouse.Length; i++)
            {
                for (int j = 0; j < warehouse[i].Length; j++)
                {
                    if (warehouse[i][j] == WarehouseWoesConsts.ROBOT)
                    {
                        return new GridPoint(i, j);
                    }
                }
            }

            throw new Exception("Robot was not found in the warehouse");
        }

        private static void printWarehouse(char[][] warehouse)
        {
            Console.WriteLine("Current Warehouse State:");
            foreach (var row in warehouse)
            {
                Console.WriteLine(new string(row));
            }
            Console.WriteLine();
        }
        #endregion

        #region size 2
        private static void moveRobotInWarehouseDoubleSize(char[][] warehouse, string robotMovement, GridPoint robotLocation)
        {
            int iteration = 0;
            foreach (char movement in robotMovement)
            {
                iteration++;
                //Console.WriteLine($"Iteration: {iteration}, Movement: {movement}");

                GridPoint nextLocation = HelperFunctions.GetNextLocation(robotLocation, movement);
                //Console.WriteLine($"Robot moving from ({robotLocation.X}, {robotLocation.Y}) to ({nextLocation.X}, {nextLocation.Y})");

                if (warehouse[nextLocation.X][nextLocation.Y] == WarehouseWoesConsts.WALL)
                {
                    //Console.WriteLine("Movement blocked by a wall.");
                    continue;
                }
                if ((warehouse[nextLocation.X][nextLocation.Y] == WarehouseWoesConsts.LEFT_BOX || warehouse[nextLocation.X][nextLocation.Y] == WarehouseWoesConsts.RIGHT_BOX)
                 && !pushBoxesDoubleSize(warehouse, movement, nextLocation))
                {
                    //Console.WriteLine("Unable to push boxes.");
                    continue;
                }

                warehouse[nextLocation.X][nextLocation.Y] = WarehouseWoesConsts.ROBOT;
                warehouse[robotLocation.X][robotLocation.Y] = WarehouseWoesConsts.EMPTY;
                robotLocation = nextLocation;
                //printWarehouse(warehouse);
            }
        }

        private static bool pushBoxesDoubleSize(char[][] warehouse, char direction, GridPoint startLocation)
        {
            HashSet<GridPoint> pathPoints = new HashSet<GridPoint>();
            bool canPush = addBoxPathPoints(warehouse, direction, startLocation, pathPoints);

            if (canPush)
            {
                while (pathPoints.Count > 0)
                {
                    GridPoint current = pathPoints.First();
                    pathPoints.Remove(current);
                    char nextPush = warehouse[current.X][current.Y];
                    warehouse[current.X][current.Y] = WarehouseWoesConsts.EMPTY;
                    while (true)
                    {
                        GridPoint nextLocation = HelperFunctions.GetNextLocation(current, direction);
                        if (warehouse[nextLocation.X][nextLocation.Y] == WarehouseWoesConsts.EMPTY)
                        {
                            warehouse[nextLocation.X][nextLocation.Y] = nextPush;
                            pathPoints.Remove(nextLocation);
                            break;
                        }


                        char temp = warehouse[nextLocation.X][nextLocation.Y];
                        warehouse[nextLocation.X][nextLocation.Y] = nextPush;
                        nextPush = temp;

                        current = nextLocation;
                        pathPoints.Remove(nextLocation);
                    }
                }
            }

            return canPush;
        }

        private static bool addBoxPathPoints(char[][] warehouse, char direction, GridPoint startLocation, HashSet<GridPoint> pathPoints)
        {
            if (pathPoints.Contains(startLocation))
            {
                return true;
            }

            var bothSides = locateLeftRightSideBoxes(warehouse, startLocation);
            pathPoints.Add(bothSides.Item1);
            pathPoints.Add(bothSides.Item2);

            GridPoint leftNextLocation = HelperFunctions.GetNextLocation(bothSides.Item1, direction);
            if (warehouse[leftNextLocation.X][leftNextLocation.Y] == WarehouseWoesConsts.WALL)
            {
                pathPoints.Add(leftNextLocation);
                return false;
            }

            bool leftCanPush = true;
            if (warehouse[leftNextLocation.X][leftNextLocation.Y] == WarehouseWoesConsts.EMPTY)
            {
                pathPoints.Add(leftNextLocation);
            }
            else if (warehouse[leftNextLocation.X][leftNextLocation.Y] == WarehouseWoesConsts.LEFT_BOX || warehouse[leftNextLocation.X][leftNextLocation.Y] == WarehouseWoesConsts.RIGHT_BOX)
            {
                var bothSidesNextLeft = locateLeftRightSideBoxes(warehouse, leftNextLocation);
                leftCanPush = addBoxPathPoints(warehouse, direction, bothSidesNextLeft.Item1, pathPoints) &&
                              addBoxPathPoints(warehouse, direction, bothSidesNextLeft.Item2, pathPoints);
            }



            GridPoint rightNextLocation = HelperFunctions.GetNextLocation(bothSides.Item2, direction);
            if (warehouse[rightNextLocation.X][rightNextLocation.Y] == WarehouseWoesConsts.WALL)
            {
                pathPoints.Add(rightNextLocation);
                return false;
            }

            bool rightCanPush = true;
            if (warehouse[rightNextLocation.X][rightNextLocation.Y] == WarehouseWoesConsts.EMPTY)
            {
                pathPoints.Add(rightNextLocation);
            }
            if (warehouse[rightNextLocation.X][rightNextLocation.Y] == WarehouseWoesConsts.LEFT_BOX || warehouse[rightNextLocation.X][rightNextLocation.Y] == WarehouseWoesConsts.RIGHT_BOX)
            {
                var bothSidesNextRight = locateLeftRightSideBoxes(warehouse, rightNextLocation);
                rightCanPush = addBoxPathPoints(warehouse, direction, bothSidesNextRight.Item1, pathPoints) &&
                               addBoxPathPoints(warehouse, direction, bothSidesNextRight.Item2, pathPoints);
            }

            return leftCanPush && rightCanPush;

        }

        private static Tuple<GridPoint, GridPoint> locateLeftRightSideBoxes(char[][] warehouse, GridPoint sideLocation)
        {
            if (warehouse[sideLocation.X][sideLocation.Y] == WarehouseWoesConsts.RIGHT_BOX)
            {
                return new Tuple<GridPoint, GridPoint>(new GridPoint(sideLocation.X, sideLocation.Y - 1), sideLocation);
            }
            if (warehouse[sideLocation.X][sideLocation.Y] == WarehouseWoesConsts.LEFT_BOX)
            {
                return new Tuple<GridPoint, GridPoint>(sideLocation, new GridPoint(sideLocation.X, sideLocation.Y + 1));
            }
            throw new Exception($"No box side at location {sideLocation}");
        }
        #endregion

        #region size 1
        private static void moveRobotInWarehouse(char[][] warehouse, string robotMovement, GridPoint robotLocation)
        {
            foreach (char movement in robotMovement)
            {
                GridPoint nextLocation = HelperFunctions.GetNextLocation(robotLocation, movement);
                if (warehouse[nextLocation.X][nextLocation.Y] == WarehouseWoesConsts.WALL)
                {
                    continue;
                }
                if (warehouse[nextLocation.X][nextLocation.Y] == WarehouseWoesConsts.BOX && !pushBoxes(warehouse, movement, nextLocation))
                {
                    continue;
                }

                warehouse[nextLocation.X][nextLocation.Y] = WarehouseWoesConsts.ROBOT;
                warehouse[robotLocation.X][robotLocation.Y] = WarehouseWoesConsts.EMPTY;
                robotLocation = nextLocation;
            }
        }

        private static bool pushBoxes(char[][] warehouse, char direction, GridPoint firstBoxLocation)
        {
            GridPoint lastSeenBox = new GridPoint(firstBoxLocation.X, firstBoxLocation.Y);
            bool isBoxMoved = false;
            while (true)
            {
                GridPoint boxNextLocation = HelperFunctions.GetNextLocation(lastSeenBox, direction);
                if (warehouse[boxNextLocation.X][boxNextLocation.Y] == WarehouseWoesConsts.WALL)
                {
                    break;
                }
                if (warehouse[boxNextLocation.X][boxNextLocation.Y] == WarehouseWoesConsts.EMPTY)
                {
                    isBoxMoved = true;
                    warehouse[boxNextLocation.X][boxNextLocation.Y] = WarehouseWoesConsts.BOX;
                    break;
                }
                if (warehouse[boxNextLocation.X][boxNextLocation.Y] != WarehouseWoesConsts.BOX)
                {
                    throw new Exception("Tried to move box to a location that is not wall, box, or empty");
                }

                lastSeenBox = boxNextLocation;
            }

            if (isBoxMoved)
            {
                warehouse[firstBoxLocation.X][firstBoxLocation.Y] = WarehouseWoesConsts.EMPTY;
            }
            return isBoxMoved;
        }
        #endregion

    }
}
