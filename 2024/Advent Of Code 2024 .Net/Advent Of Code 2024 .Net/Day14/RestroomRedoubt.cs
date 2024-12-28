using Advent_Of_Code_2024_.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day14
{
    internal static class RestroomRedoubt
    {
        /// <summary>
        /// Part 1 of the Restroom Redoubt task
        /// </summary>
        /// <param name="robots"></param>
        /// <param name="tilesWide"></param>
        /// <param name="tilesTall"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static int GetSafetyFactor(Robot[] robots, int tilesWide, int tilesTall, int seconds)
        {
            moveRobots(robots, tilesWide, tilesTall, seconds);

            int q1 = 0;
            int q2 = 0;
            int q3 = 0;
            int q4 = 0;

            int XdimMax = tilesTall - 1;
            int YdimMax = tilesWide - 1;
            int XhalfBoundary = XdimMax / 2;
            int YhalfBoundary = YdimMax / 2;

            Tuple<int, int, int, int> q1Dim = new Tuple<int, int, int, int>(0, XhalfBoundary - 1, 0, YhalfBoundary - 1);
            Tuple<int, int, int, int> q2Dim = new Tuple<int, int, int, int>(0, XhalfBoundary - 1, YhalfBoundary + 1, YdimMax);
            Tuple<int, int, int, int> q3Dim = new Tuple<int, int, int, int>(XhalfBoundary + 1, XdimMax, 0, YhalfBoundary - 1);
            Tuple<int, int, int, int> q4Dim = new Tuple<int, int, int, int>(XhalfBoundary + 1, XdimMax, YhalfBoundary + 1, YdimMax);

            foreach (var robot in robots)
            {
                if (robot.GetPosition().CheckGridBoundary(q1Dim.Item1, q1Dim.Item2, q1Dim.Item3, q1Dim.Item4))
                {
                    q1 += 1;
                    continue;
                }
                if (robot.GetPosition().CheckGridBoundary(q2Dim.Item1, q2Dim.Item2, q2Dim.Item3, q2Dim.Item4))
                {
                    q2 += 1;
                    continue;
                }
                if (robot.GetPosition().CheckGridBoundary(q3Dim.Item1, q3Dim.Item2, q3Dim.Item3, q3Dim.Item4))
                {
                    q3 += 1;
                    continue;
                }
                if (robot.GetPosition().CheckGridBoundary(q4Dim.Item1, q4Dim.Item2, q4Dim.Item3, q4Dim.Item4))
                {
                    q4 += 1;
                    continue;
                }
            }

            return q1 * q2 * q3 * q4;
        }

        /// <summary>
        /// Part 2 of the Restroom Redoubt task
        /// </summary>
        /// <param name="robots"></param>
        /// <param name="tilesWide"></param>
        /// <param name="tilesTall"></param>
        /// <returns></returns>
        public static Dictionary<int, int> GetEarliestXmasTree(Robot[] robots, int tilesWide, int tilesTall, int maxSeconds)
        {
            Dictionary<int, int> secondSafety = new Dictionary<int, int>();

            for (int i = 0; i < maxSeconds; i++)
            {
                int safety = GetSafetyFactor(robots, tilesWide, tilesTall, 1);
                secondSafety.Add(i, safety);

                if (hasLongLineOfRobots(robots, tilesWide, tilesTall))
                {
                    printGrid(robots, tilesWide, tilesTall);
                    Console.WriteLine($"--------------------------------------------------------------------------------------{i + 1}--------------------------------------------------------------------------------------");
                    continue;
                }
            }

            var sortedDict = secondSafety.OrderBy(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            return sortedDict;
        }

        public static void GetEarliestXmasTreeVoid(Robot[] robots, int tilesWide, int tilesTall, int maxSeconds)
        {

            for (int i = 0; i < maxSeconds; i++)
            {
                foreach (Robot robot in robots)
                {
                    robot.MoveRobot(tilesTall, tilesWide);
                }

                if (hasLongLineOfRobots(robots, tilesWide, tilesTall))
                {
                    printGrid(robots, tilesWide, tilesTall);
                    Console.WriteLine($"--------------------------------------------------------------------------------------{i + 1}--------------------------------------------------------------------------------------");
                    continue;
                }
            }
        }

        private static bool hasLongLineOfRobotsVertically(Robot[] robots, int width, int height)
        {
            var grid = new bool[height, width];

            foreach (var robot in robots)
            {
                var position = robot.GetPosition();
                grid[position.X, position.Y] = true;
            }

            for (int x = 0; x < height; x++)
            {
                int consecutiveRobots = 0;
                for (int y = 0; y < width; y++)
                {
                    if (grid[x, y])
                    {
                        consecutiveRobots++;
                    }
                    else
                    {
                        consecutiveRobots = 0;
                    }

                    if (consecutiveRobots >= 10)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool hasLongLineOfRobots(Robot[] robots, int width, int height)
        {
            var grid = new bool[height, width];

            foreach (var robot in robots)
            {
                var position = robot.GetPosition();
                grid[position.X, position.Y] = true;
            }

            for (int y = 0; y < width; y++)
            {
                int consecutiveRobots = 0;
                for (int x = 0; x < height; x++)
                {
                    if (grid[x, y])
                    {
                        consecutiveRobots++;
                    }
                    else
                    {
                        consecutiveRobots = 0;
                    }

                    if (consecutiveRobots >= 6)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void printGrid(Robot[] robots, int width, int height)
        {
            var grid = new char[height, width];
            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    grid[x, y] = '.';
                }
            }

            foreach (var robot in robots)
            {
                var position = robot.GetPosition();
                grid[position.X, position.Y] = 'R';
            }

            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    Console.Write(grid[x, y] + " ");
                }
                Console.WriteLine();
            }
        }


        private static void moveRobots(Robot[] robots, int width, int height, int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                foreach (Robot robot in robots)
                {
                    robot.MoveRobot(height, width);
                }
            }
        }

    }
}
