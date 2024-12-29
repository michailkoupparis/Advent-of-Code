using Advent_Of_Code_2024_.Net.EnumsConsts;
using Advent_Of_Code_2024_.Net.Helpers;
using Advent_Of_Code_2024_.Net.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        /// Task 1 of the Reindeer Maze task
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

            var pq = new SortedSet<(int cost, GridPoint point, int dir)>(
                Comparer<(int cost, GridPoint point, int dir)>.Create((a, b) =>
                {
                    int costComparison = a.cost.CompareTo(b.cost);
                    if (costComparison != 0) return costComparison;
                    int pointComparisonX = a.point.X.CompareTo(b.point.X);
                    if (pointComparisonX != 0) return pointComparisonX;
                    int pointComparisonY = a.point.Y.CompareTo(b.point.Y);
                    if (pointComparisonY != 0) return pointComparisonY;

                    return a.dir.CompareTo(b.dir);
                }));
            var costs = new Dictionary<(GridPoint point, int dir), int>();

            GridDirections gridDirections = new GridDirections();
            int rightDirKey = gridDirections.GetAllDirections().Where(x => x.Value == Consts.DIR_SYMBOL_RIGHT).First().Key;
            pq.Add((0, startEnd.Item1, rightDirKey));
            costs[(startEnd.Item1, rightDirKey)] = 0;
            while (pq.Count > 0)
            {
                var current = pq.Min;
                pq.Remove(current);
                int cost = current.cost;
                GridPoint point = current.point;
                int dir = current.dir;

                if (point == startEnd.Item2)
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

                    if (gridDir.Key != dir)
                    {
                        var turnGradient = Math.Abs((gridDir.Key - dir) % 4) == 2 ? 2 : 1;
                        newCost += turnGradient * 1000;
                    }

                    if (!costs.ContainsKey((nextLocation, gridDir.Key)) || costs[(nextLocation, gridDir.Key)] > newCost)
                    {
                        costs[(nextLocation, gridDir.Key)] = newCost;
                        pq.Add((newCost, nextLocation, gridDir.Key));
                    }
                }
            }

            return int.MaxValue;
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
