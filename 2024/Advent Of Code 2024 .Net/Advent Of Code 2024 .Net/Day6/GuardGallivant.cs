using Advent_Of_Code_2024_.Net.Models;
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
            HashSet<GridPoint> passedGridPoints = findPassedPoints(room);
            return passedGridPoints.Count;
        }

        /// <summary>
        /// For part 2 of the Guard Gallivant task
        /// This solution tries to check for loops as we go
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        /// 
        public static int CountPossibleLoopObstacles(string[] room)
        {
            HashSet<GridPoint> passedGridPoints = findPassedPoints(room);
            HashSet<GridPoint> possibleObstacles = new HashSet<GridPoint>();

            foreach (GridPoint point in passedGridPoints)
            {
                string[] roomCopy = room.ToArray();
                updateRoom(roomCopy, point, OBSTACLE);

                GridPoint guardLocation = new GridPoint(passedGridPoints.First().X, passedGridPoints.First().Y);
                char guardDirection = room[guardLocation.X][guardLocation.Y];
                Dictionary<GridPoint, HashSet<char>> newLoopPoints = new Dictionary<GridPoint, HashSet<char>>();
                updatePassedPointsAndDirection(newLoopPoints, guardLocation, guardDirection);
                while (true)
                {
                    GridPoint nextLocation = getNextLocation(guardLocation, guardDirection);
                    if (!nextLocation.CheckGridBoundary(room))
                    {
                        break;
                    }

                    if (roomCopy[nextLocation.X][nextLocation.Y] == OBSTACLE)
                    {
                        guardDirection = getNewDirection(guardDirection);
                        continue;
                    }

                    if (newLoopPoints.ContainsKey(nextLocation) && newLoopPoints[nextLocation].Contains(guardDirection))
                    {
                        possibleObstacles.Add(new GridPoint(point.X, point.Y));
                        break;
                    }

                    guardLocation.X = nextLocation.X;
                    guardLocation.Y = nextLocation.Y;
                    updatePassedPointsAndDirection(newLoopPoints, guardLocation, guardDirection);

                };

            }

            return possibleObstacles.Count;

        }

        /// <summary>
        /// For part 2 of the Guard Gallivant task
        /// This solution tries to check for loops as we go
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        /// 
        public static int CountPossibleLoopObstaclesAsWeGo(string[] room)
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
            updatePassedPointsAndDirection(passedGridPoints, guardLocation, guardDirection);
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
                    foundObstacles.Add(new GridPoint(nextLocation.X, nextLocation.Y));
                    countPossibleLoopObs++;
                }

                guardLocation.X = nextLocation.X;
                guardLocation.Y = nextLocation.Y;
                updatePassedPointsAndDirection(passedGridPoints, guardLocation, guardDirection);

            };

            return countPossibleLoopObs;
        }

        private static HashSet<GridPoint> findPassedPoints(string[] room)
        {
            GridPoint guardLocation = findGuardLocation(room);
            if (guardLocation == null)
            {
                throw new Exception("Guard was not found room");
            }

            char guardDirection = room[guardLocation.X][guardLocation.Y];
            HashSet<GridPoint> passedGridPoints = new HashSet<GridPoint> { new GridPoint(guardLocation.X, guardLocation.Y) };
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

            return passedGridPoints;
        }

        private static bool checkLoop(string[] room, Dictionary<GridPoint, HashSet<char>> passedPoints, GridPoint location, char direction)
        {

            GridPoint prevPoint = new GridPoint(location.X, location.Y);
            Dictionary<GridPoint, HashSet<char>> loopPoints = new Dictionary<GridPoint, HashSet<char>>();
            foreach (GridPoint point in passedPoints.Keys)
            {
                var directions = new HashSet<char>();
                foreach (char c in passedPoints[point])
                {
                    directions.Add(c);
                }
                loopPoints.Add(new GridPoint(point.X, point.Y), directions);
            }

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

                updatePassedPointsAndDirection(loopPoints, trialPoint, trialDirection);
                prevPoint.X = trialPoint.X;
                prevPoint.Y = trialPoint.Y;

            };

            return false;
        }

        private static void updatePassedPointsAndDirection(Dictionary<GridPoint, HashSet<char>> passedPoints, GridPoint point, char direction)
        {
            if (passedPoints.ContainsKey(point))
            {
                passedPoints[new GridPoint(point.X, point.Y)].Add(direction);
            }
            else
            {
                passedPoints.Add(new GridPoint(point.X, point.Y), new HashSet<char> { direction });
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
                        return new GridPoint(i, j);
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
                    return new GridPoint(currLocation.X - 1, currLocation.Y);
                case GUARD_SYMBOL_RIGHT:
                    return new GridPoint(currLocation.X, currLocation.Y + 1);
                case GUARD_SYMBOL_DOWN:
                    return new GridPoint(currLocation.X + 1, currLocation.Y);
                case GUARD_SYMBOL_LEFT:
                    return new GridPoint(currLocation.X, currLocation.Y - 1);
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
