using Advent_Of_Code_2024_.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day10
{
    internal static class HoofIt
    {

        private static readonly int[] dx = { -1, 1, 0, 0 };
        private static readonly int[] dy = { 0, 0, -1, 1 };

        /// <summary>
        /// Part 1 of the Hoof it task
        /// </summary>
        /// <param name="hikingTrails"></param>
        /// <returns></returns>
        public static int CalculateTrailheadScores(int[][] topographicMap)
        {
            int rows = topographicMap.Length;
            int cols = topographicMap[0].Length;
            int totalScore = 0;

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (topographicMap[i][j] == 0)
                    {
                        bool[,] visited = new bool[rows, cols];
                        int score = countReachableNines(topographicMap, new GridPoint(i,j), 0, visited);
                        totalScore += score;
                    }
                }
            }

            return totalScore;
        }

        /// <summary>
        /// Part 2 of the Hoof it task
        /// </summary>
        /// <param name="hikingTrails"></param>
        /// <returns></returns>
        public static int CalculateTrailheadRatings(int[][] topographicMap)
        {
            int rows = topographicMap.Length;
            int cols = topographicMap[0].Length;
            int totalScore = 0;

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (topographicMap[i][j] == 0)
                    {
                        bool[,] visited = new bool[rows, cols];
                        int score = countReachableNines(topographicMap, new GridPoint(i, j) , 0);
                        totalScore += score;
                    }
                }
            }

            return totalScore;
        }

        private static int countReachableNines(int[][] topographicMap, GridPoint point, int currentHeight)
        {
            if (!point.CheckGridBoundary(topographicMap))
                return 0;

            if (topographicMap[point.X][point.Y] != currentHeight)
                return 0;

            if (currentHeight == 9)
                return 1;

            int count = 0;
            for (int dir = 0; dir < 4; dir++)
            {
                int nx = point.X + dx[dir];
                int ny = point.Y + dy[dir];
                count += countReachableNines(topographicMap, new GridPoint(nx, ny), currentHeight + 1);
            }

            return count;
        }

        private static int countReachableNines(int[][] topographicMap, GridPoint point, int currentHeight, bool[,] visited)
        {
            if (!point.CheckGridBoundary(topographicMap) || visited[point.X, point.Y])
                return 0;

            if (topographicMap[point.X][point.Y] != currentHeight)
                return 0;

            visited[point.X, point.Y] = true;

            if (currentHeight == 9)
                return 1;

            int count = 0;
            for (int dir = 0; dir < 4; dir++)
            {
                int nx = point.X + dx[dir];
                int ny = point.Y + dy[dir];
                count += countReachableNines(topographicMap, new GridPoint(nx, ny), currentHeight + 1, visited);
            }

            return count;
        }

    }
}
