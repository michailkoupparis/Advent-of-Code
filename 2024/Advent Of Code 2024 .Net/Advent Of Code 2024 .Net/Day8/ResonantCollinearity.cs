using Advent_Of_Code_2024_.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day8
{
    internal static class ResonantCollinearity
    {
        private const char NORMAL_CHAR = '.';

        /// <summary>
        /// Part 1 and 2 for the Resonant Collinearity task
        /// </summary>
        /// <param name="antenaGrid"></param>
        /// <returns></returns>
        public static int CountAndinodes(string[] antenaGrid, bool checkWholeLine)
        {
            HashSet<GridPoint> antenaPositions = new HashSet<GridPoint>();
            for (int i1 = 0; i1 < antenaGrid.Length; i1++)
            {
                for (int j1 = 0; j1 < antenaGrid[i1].Length; j1++)
                {
                    if (antenaGrid[i1][j1] == NORMAL_CHAR)
                    {
                        continue;
                    }

                    for (int i2 = i1; i2 < antenaGrid.Length; i2++)
                    {
                        for (int j2 = 0; j2 < antenaGrid[i2].Length; j2++)
                        {
                            if (i2 <= i1 && j2 <= j1)
                            {
                                continue;
                            }

                            if (antenaGrid[i1][j1] == antenaGrid[i2][j2])
                            {
                                if (checkWholeLine)
                                {
                                    addAntitodesThroughLine(antenaGrid, antenaPositions, new GridPoint(i1, j1), new GridPoint(i2, j2));
                                }
                                else
                                {
                                    addAntitodesBeforeAfter(antenaGrid, antenaPositions, new GridPoint(i1, j1), new GridPoint(i2, j2));
                                }
                            }

                        }
                    }
                }
            }


            return antenaPositions.Count;

        }

        private static void addAntitodesBeforeAfter(string[] antenaGrid, HashSet<GridPoint> antidotes, GridPoint antena1, GridPoint antena2)
        {
            GridPoint firstPoint = antena1.X <= antena2.X ? antena1 : antena2;
            GridPoint secondPoint = antena1.X > antena2.X ? antena1 : antena2;

            int xDiff = secondPoint.X - firstPoint.X;
            int yDiff = secondPoint.Y - firstPoint.Y;

            int minX = firstPoint.X - xDiff;
            int minY = firstPoint.Y - yDiff;
            GridPoint minPoint = new GridPoint(minX, minY);

            int maxX = secondPoint.X + xDiff;
            int maxY = secondPoint.Y + yDiff;
            GridPoint maxPoint = new GridPoint(maxX, maxY);

            foreach (GridPoint p in new GridPoint[] { minPoint, maxPoint })
            {
                if (p.CheckGridBoundary(antenaGrid))
                {
                    antidotes.Add(new GridPoint(p.X, p.Y));
                }
            }
        }

        private static void addAntitodesThroughLine(string[] antenaGrid, HashSet<GridPoint> antidotes, GridPoint antena1, GridPoint antena2)
        {
            double xDiff = antena1.X - antena2.X;
            double yDiff = antena1.Y - antena2.Y;
            if (xDiff == 0)
            {
                for (int y = 0; y < antenaGrid[antena1.X].Length; y += (int)yDiff)
                {
                    if (y != antena1.Y && y != antena2.Y)
                    {
                        antidotes.Add(new GridPoint(antena1.X, y));
                    }
                }
                return;
            }

            if (yDiff == 0)
            {
                for (int x = 0; x < antenaGrid[antena1.X].Length; x += (int)xDiff)
                {
                    if (x != antena1.X && x != antena2.X)
                    {
                        antidotes.Add(new GridPoint(x, antena1.Y));
                    }
                }
                return;
            }


            double slope = yDiff * 1.0 / xDiff;
            double interCept = antena1.Y - slope * antena2.X;

            
            for (double x = 0; x < antenaGrid.Length; x++)
            {
                int y;
                double yD = slope * x + interCept;
                if (tryGetExactInt(yD, out y))
                {
                    GridPoint gridPoint = new GridPoint((int)x, y);
                    if (gridPoint.CheckGridBoundary(antenaGrid))
                    {
                        antidotes.Add(new GridPoint(gridPoint.X, gridPoint.Y));
                    }
                }                
            }
        }

        private static bool tryGetExactInt(double value, out int intValue)
        {
            const double Tolerance = 1e-9;
            double roundedValue = Math.Round(value);

            if (Math.Abs(value - roundedValue) < Tolerance)
            {
                intValue = (int)roundedValue;
                return true;
            }

            intValue = -1;
            return false;
        }

        
    }
}
