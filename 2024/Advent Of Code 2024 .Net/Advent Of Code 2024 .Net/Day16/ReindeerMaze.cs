using Advent_Of_Code_2024_.Net.EnumsConsts;
using Advent_Of_Code_2024_.Net.Helpers;
using Advent_Of_Code_2024_.Net.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day16
{
    internal static class ReindeerMaze
    {
        private static readonly char START = 'S';
        private static readonly char END = 'E';
        private static readonly char WALL = '#';

        /// <summary>
        /// Part 1 of the Reindeer Maze task
        /// </summary>
        /// <param name="maze"></param>
        /// <returns></returns>
        public static int GetMazeShortestPathCost(string[] maze)
        {
            var startEnd = getStartEnd(maze);
            if (startEnd.Item1 == new GridPoint(-1, -1) || startEnd.Item2 == new GridPoint(-1, -1))
            {
                throw new ArgumentException("Grid must contain a start 'S' and end 'E' point.");
            }

            var costs = new Dictionary<(GridPoint point, int dir), int>();
            return getCostsToEnd(maze, startEnd, true, out costs);
        }

        /// <summary>
        /// Part 2 of the Reindeer Maze task
        /// </summary>
        /// <param name="maze"></param>
        /// <returns></returns>
        public static int GetMazeShortestPath(string[] maze)
        {
            var startEnd = getStartEnd(maze);
            if (startEnd.Item1 == new GridPoint(-1, -1) || startEnd.Item2 == new GridPoint(-1, -1))
            {
                throw new ArgumentException("Grid must contain a start 'S' and end 'E' point.");
            }

            var costs = new Dictionary<(GridPoint point, int dir), int>();
            int pathCost = getCostsToEnd(maze, startEnd, true, out costs);
            if(pathCost == int.MaxValue)
            {
                return -1;
            }

            var allPaths = new List<List<GridPoint>>();
            GridDirections gridDirections = new GridDirections();
            void Backtrack(GridPoint current, int currentDir, List<GridPoint> path)
            {
                path.Add(current);

                if (current == startEnd.Item1)
                {
                    allPaths.Add(new List<GridPoint>(path));
                    path.RemoveAt(path.Count - 1);
                    return;
                }

                var allDirections = gridDirections.GetAllDirections();
                foreach (var gridDir in allDirections)
                {
                    var reverseDir = gridDirections.Get180deegrees(gridDir.Key);
                    var prevLocation = HelperFunctions.GetNextLocation(current, reverseDir);
                    if (!costs.ContainsKey((prevLocation, gridDir.Key)))
                        continue;

                    var turningCost = getTurningGradient(currentDir - gridDir.Key);
                    int expectedCost = costs[(current, currentDir)] - (1 + turningCost);
                    if (costs[(prevLocation, gridDir.Key)] == expectedCost)
                    {
                        Backtrack(prevLocation, gridDir.Key, path);
                    }
                }

                path.RemoveAt(path.Count - 1);
            }

            foreach (var kvp in costs.Where(kvp => kvp.Key.point == startEnd.Item2))
            {
                var path = new List<GridPoint>();
                Backtrack(kvp.Key.point, kvp.Key.dir, path);
            }

            /*Console.WriteLine("All shortest paths:");
            foreach (var path in allPaths)
            {
                Console.WriteLine(string.Join(" -> ", path));
            }
            */
            return allPaths.SelectMany(x => x).ToHashSet().Count();
        }
        

        private static int getCostsToEnd(string[] maze, Tuple<GridPoint, GridPoint> startEnd, bool earlyStoppage, out Dictionary<(GridPoint point, int dir), int> costs)
        {
            var pq = new PriorityQueue<(int cost, GridPoint point, int dir), int>();
            costs = new Dictionary<(GridPoint point, int dir), int>();

            GridDirections gridDirections = new GridDirections();
            int rightDirKey = gridDirections.GetAllDirections().Where(x => x.Value == Consts.DIR_SYMBOL_RIGHT).First().Key;
            pq.Enqueue((0, startEnd.Item1, rightDirKey), 0);

            costs[(startEnd.Item1, rightDirKey)] = 0;
            while (pq.Count > 0)
            {
                var current = pq.Dequeue();
                int cost = current.cost;
                GridPoint point = current.point;
                int dir = current.dir;

                if (earlyStoppage && point == startEnd.Item2)
                {
                    return cost;
                }

                foreach (var gridDir in gridDirections.GetAllDirections())
                {
                    var nextLocation = HelperFunctions.GetNextLocation(point, gridDir.Value);
                    if (!nextLocation.CheckGridBoundary(maze) || maze[nextLocation.X][nextLocation.Y] == WALL)
                    {
                        continue;
                    }

                    int newCost = cost + 1;
                    int turningCost = getTurningGradient(gridDir.Key - dir);
                    newCost += turningCost;

                    if (!costs.ContainsKey((nextLocation, gridDir.Key)) || costs[(nextLocation, gridDir.Key)] > newCost)
                    {
                        costs[(nextLocation, gridDir.Key)] = newCost;
                        pq.Enqueue((newCost, nextLocation, gridDir.Key), newCost);

                        if (turningCost > 0 && (!costs.ContainsKey((point, gridDir.Key)) || costs[(point, gridDir.Key)] > cost + turningCost))
                        {
                            costs[(point, gridDir.Key)] = cost + turningCost;
                        }
                    }
                }
            }

            return int.MaxValue;
        }

        private static int getTurningGradient(int diff)
        {
            int turningCost = 0;
            if (diff != 0)
            {
                var turnGradient = Math.Abs(diff % 4) == 2 ? 2 : 1;
                turningCost = turnGradient * 1000;
            }
            return turningCost;
        }

        private static Tuple<GridPoint, GridPoint> getStartEnd(string[] maze)
        {
            GridPoint start = new GridPoint(-1, -1);
            GridPoint end = new GridPoint(-1, -1);

            for (int i = 0; i < maze.Length; i++)
            {
                for (int j = 0; j < maze[i].Length; j++)
                {
                    if (maze[i][j] == START) start = new GridPoint(i, j);
                    if (maze[i][j] == END) end = new GridPoint(i, j);
                }
            }

            return new Tuple<GridPoint, GridPoint>(start, end);
        }
    }
}
