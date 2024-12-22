using Advent_Of_Code_2024_.Net.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day12
{
    internal static class GardenGroups
    {
        /// <summary>
        /// Part 1 of the Garden Groups task
        /// </summary>
        /// <param name="plots"></param>
        /// <returns></returns>
        public static long CalculateFenceCostPerimeter(string[] plots)
        {
            Dictionary<char, List<GridPoint>> plotKindLocations = getPlotKindLoaction(plots);
            Dictionary<char, List<List<GridPoint>>> plotRegions = getRegions(plotKindLocations);
            long totalFenceCost = 0;
            foreach (var pRegions in plotRegions.Values)
            {
                foreach (var region in pRegions)
                {
                    totalFenceCost += region.Count * getRegionPeremeter(region);
                }
            }

            return totalFenceCost;
        }

        /// <summary>
        /// Part 2 of the Garden Groups task
        /// </summary>
        /// <param name="plots"></param>
        /// <returns></returns>
        public static long CalculateFenceCostSides(string[] plots)
        {
            Dictionary<char, List<GridPoint>> plotKindLocations = getPlotKindLoaction(plots);
            Dictionary<char, List<List<GridPoint>>> plotRegions = getRegions(plotKindLocations);
            long totalFenceCost = 0;
            foreach (var pRegions in plotRegions.Values)
            {
                foreach (var region in pRegions)
                {
                    totalFenceCost += region.Count * getNumberOfSides(region);
                }
            }

            return totalFenceCost;
        }

        private static Dictionary<char, List<GridPoint>> getPlotKindLoaction(string[] plots)
        {
            Dictionary<char, List<GridPoint>> plotKindLocations = new Dictionary<char, List<GridPoint>>();
            for (int i = 0; i < plots.Length; i++)
            {
                for (int j = 0; j < plots[i].Length; j++)
                {
                    if (plotKindLocations.ContainsKey(plots[i][j]))
                    {
                        plotKindLocations[plots[i][j]].Add(new GridPoint(i, j));
                    }
                    else
                    {
                        plotKindLocations[plots[i][j]] = new List<GridPoint> { new GridPoint(i, j) };
                    }
                }
            }
            return plotKindLocations;
        }

        private static Dictionary<char, List<List<GridPoint>>> getRegions(Dictionary<char, List<GridPoint>> plotKindLocations)
        {
            var regions = new Dictionary<char, List<List<GridPoint>>>();

            foreach (var plotKind in plotKindLocations.Keys)
            {
                var visited = new HashSet<GridPoint>();
                var allPoints = plotKindLocations[plotKind];
                regions[plotKind] = new List<List<GridPoint>>();

                foreach (var point in allPoints)
                {
                    if (visited.Contains(point))
                        continue;

                    var newRegion = new List<GridPoint>();
                    var stack = new Stack<GridPoint>();
                    stack.Push(point);

                    while (stack.Count > 0)
                    {
                        var current = stack.Pop();
                        if (visited.Contains(current))
                            continue;

                        visited.Add(current);
                        newRegion.Add(current);

                        foreach (var neighbor in allPoints.Where(p => !visited.Contains(p) && current.CheckAdjacent(p)))
                        {
                            stack.Push(neighbor);
                        }
                    }

                    regions[plotKind].Add(newRegion);
                }
            }

            return regions;
        }

        private static long getRegionPeremeter(List<GridPoint> region)
        {
            long peremeter = 0;
            foreach (GridPoint p in region)
            {
                GridPoint[] adjacentPoints = p.GetAdjacent();
                foreach (GridPoint adjP in adjacentPoints)
                {
                    if (!region.Any(x => x == adjP))
                    {
                        peremeter++;
                    }
                }
            }
            return peremeter;
        }


        private static long getNumberOfSides(List<GridPoint> region)
        {
            List<Tuple<CellBoundary, GridPoint>> boundaryPoints = new();
            foreach (GridPoint p in region)
            {
                Tuple<CellBoundary, GridPoint>[] adjacentPoints = p.GetAdjacentWithDirection();
                foreach (Tuple<CellBoundary, GridPoint> adjP in adjacentPoints)
                {
                    if (!region.Any(x => x == adjP.Item2))
                    {
                        boundaryPoints.Add(adjP);
                    }
                }
            }

            var sides = Edge.GetConnectedEdges(boundaryPoints);
            return sides.Count;
        }


    }
}
