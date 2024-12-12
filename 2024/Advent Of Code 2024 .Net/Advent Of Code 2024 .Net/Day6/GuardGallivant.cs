using Advent_Of_Code_2024_.Net.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day6
{
    internal static class GuardGallivant
    {
        private const char GUARD_SYMBOL_RIGHT = '>';
        private const char GUARD_SYMBOL_LEFT = '<';
        private const char GUARD_SYMBOL_UP = '^';
        private const char GUARD_SYMBOL_DOWN = 'v';

        private const char OBSTACLE = '#';
        private const char PASSED = 'X';

        /// <summary>
        /// Part 1 of the Guard Gallivant task
        /// Implement by updating grid
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public static int CountSafePostsAndUpdateRoom(string[] room)
        {
            GridPoint guardLocation = findGuardLocation(room);
            if (guardLocation == null)
            {
                throw new Exception("Guard was not found room");
            }
            char guardDirection = room[guardLocation.X][guardLocation.Y];
            updateRoom(room, guardLocation, PASSED);

            while (true)
            {
                GridPoint nextLocation = getNextLocation(guardLocation, guardDirection);
                if (!nextLocation.CheckGridBoundary(room))
                {
                    break;
                }

                if (room[nextLocation.X][nextLocation.Y] == OBSTACLE)
                {
                    guardDirection = getNewDirection(guardDirection);
                    continue;
                }

                guardLocation.X = nextLocation.X;
                guardLocation.Y = nextLocation.Y;
                updateRoom(room, guardLocation, PASSED);

            };

            return countSymbol(room, PASSED);

        }

        /// <summary>
        /// Part 1 of the Guard Gallivant task
        /// Implement by keeping track of passed points and directions at the time
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        public static int CountSafePosts(string[] room)
        {

            GridPoint guardLocation = findGuardLocation(room);
            if (guardLocation == null)
            {
                throw new Exception("Guard was not found room");
            }

            char guardDirection = room[guardLocation.X][guardLocation.Y];
            HashSet<GridPoint> passedGridPoints = new HashSet<GridPoint> { guardLocation };
            while (true)
            {

                GridPoint nextLocation = getNextLocation(guardLocation, guardDirection);
                if (!nextLocation.CheckGridBoundary(room))
                {
                    break;
                }

                if (room[nextLocation.X][nextLocation.Y] == OBSTACLE)
                {
                    guardDirection = getNewDirection(guardDirection);
                    continue;
                }

                passedGridPoints.Add(nextLocation);
                guardLocation.X = nextLocation.X;
                guardLocation.Y = nextLocation.Y;

            };

            return passedGridPoints.Count;
        }

        /// <summary>
        /// For part 2 of the Guard Gallivant task
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        /// 
        public static int CountPossibleLoopObstacles(string[] room)
        {

            GridPoint guardLocation = findGuardLocation(room);
            if (guardLocation == null)
            {
                throw new Exception("Guard was not found room");
            }

            char guardDirection = room[guardLocation.X][guardLocation.Y];
            int countPossibleLoopObs = 0;
            HashSet<GridPoint> foundObstacles = new HashSet<GridPoint>();
            Dictionary<GridPoint, HashSet<char>> passedGridPoints = new Dictionary<GridPoint, HashSet<char>>();
            updatePassedointsAndDirection(passedGridPoints, guardLocation, guardDirection);
            while (true)
            {
                GridPoint nextLocation = getNextLocation(guardLocation, guardDirection);
                if (!nextLocation.CheckGridBoundary(room))
                {
                    break;
                }

                if (room[nextLocation.X][nextLocation.Y] == OBSTACLE)
                {
                    guardDirection = getNewDirection(guardDirection);
                    continue;
                }

                if (!foundObstacles.Contains(nextLocation) && checkLoop(room, passedGridPoints, guardLocation, guardDirection))
                {
                    foundObstacles.Add(new GridPoint() { X = nextLocation.X, Y = nextLocation.Y });
                    countPossibleLoopObs++;
                }

                guardLocation.X = nextLocation.X;
                guardLocation.Y = nextLocation.Y;
                updatePassedointsAndDirection(passedGridPoints, guardLocation, guardDirection);

            };

            foreach (GridPoint point in foundObstacles.OrderBy(pair => pair.X).ThenBy(pair => pair.Y).ToList())
            {
                Console.WriteLine(point);
            }
            return countPossibleLoopObs;
        }

        private static bool checkLoop(string[] room, Dictionary<GridPoint, HashSet<char>> passedPoints, GridPoint location, char direction)
        {

            GridPoint prevPoint = new GridPoint() { X = location.X, Y = location.Y };
            Dictionary<GridPoint, HashSet<char>> loopPoints = passedPoints.ToDictionary(
                    entry => new GridPoint { X = entry.Key.X, Y = entry.Key.Y },
                    entry => new HashSet<char>(entry.Value)
            );

            char trialDirection = getNewDirection(direction);
            while (true)
            {
                GridPoint trialPoint = getNextLocation(prevPoint, trialDirection);
                if (!trialPoint.CheckGridBoundary(room))
                {
                    break;
                }

                if (room[trialPoint.X][trialPoint.Y] == OBSTACLE)
                {
                    trialDirection = getNewDirection(trialDirection);
                    continue;
                }

                if (loopPoints.ContainsKey(trialPoint) && loopPoints[trialPoint].Contains(trialDirection))
                {
                    return true;
                }

                updatePassedointsAndDirection(loopPoints, trialPoint, trialDirection);
                prevPoint.X = trialPoint.X;
                prevPoint.Y = trialPoint.Y;

            };

            return false;
        }

        private static void updatePassedointsAndDirection(Dictionary<GridPoint, HashSet<char>> passedPoints, GridPoint point, char direction)
        {
            if (passedPoints.ContainsKey(point))
            {
                passedPoints[new GridPoint() { X = point.X, Y = point.Y }].Add(direction);
            }
            else
            {
                passedPoints.Add(new GridPoint() { X = point.X, Y = point.Y }, new HashSet<char> { direction });
            }
        }

        private static void updateRoom(string[] room, GridPoint gridPoint, char symbol)
        {
            StringBuilder sb = new StringBuilder(room[gridPoint.X]);
            sb[gridPoint.Y] = symbol;
            room[gridPoint.X] = sb.ToString();
        }

        private static GridPoint findGuardLocation(string[] room)
        {
            for (int i = 0; i < room.Length; i++)
            {
                for (int j = 0; j < room[i].Length; j++)
                {
                    if (room[i][j] == GUARD_SYMBOL_RIGHT
                        | room[i][j] == GUARD_SYMBOL_LEFT
                        | room[i][j] == GUARD_SYMBOL_DOWN
                        | room[i][j] == GUARD_SYMBOL_UP
                        )
                    {
                        return new GridPoint() { X = i, Y = j };
                    }
                }
            }

            return null;
        }

        private static GridPoint getNextLocation(GridPoint currLocation, char direction)
        {

            switch (direction)
            {
                case GUARD_SYMBOL_UP:
                    return new GridPoint() { X = currLocation.X - 1, Y = currLocation.Y };
                case GUARD_SYMBOL_RIGHT:
                    return new GridPoint() { X = currLocation.X, Y = currLocation.Y + 1 };
                case GUARD_SYMBOL_DOWN:
                    return new GridPoint() { X = currLocation.X + 1, Y = currLocation.Y };
                case GUARD_SYMBOL_LEFT:
                    return new GridPoint() { X = currLocation.X, Y = currLocation.Y - 1 };
                default:
                    throw new ArgumentException($"Unknow direction {direction}");
            }

            return null;
        }

        private static char getNewDirection(char direction)
        {
            switch (direction)
            {
                case GUARD_SYMBOL_UP:
                    return GUARD_SYMBOL_RIGHT;
                case GUARD_SYMBOL_RIGHT:
                    return GUARD_SYMBOL_DOWN;
                case GUARD_SYMBOL_DOWN:
                    return GUARD_SYMBOL_LEFT;
                case GUARD_SYMBOL_LEFT:
                    return GUARD_SYMBOL_UP;
                default:
                    throw new ArgumentException($"Unknow direction {direction}");
            }

            return ' ';
        }

        private static int countSymbol(string[] room, char symbol)
        {
            int count = 0;
            foreach (string row in room)
            {
                foreach (char c in row)
                {
                    if (c == symbol) count++;
                }
            }

            return count;
        }

    }
}
