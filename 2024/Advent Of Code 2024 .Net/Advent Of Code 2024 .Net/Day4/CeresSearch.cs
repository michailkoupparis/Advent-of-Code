using Advent_Of_Code_2024_.Net.Helpers;
using System.Xml;

namespace Advent_Of_Code_2024_.Net.Day4
{
    internal static class CeresSearch
    {

        /// <summary>
        /// Part 1 of the Ceres Search tasks
        /// </summary>
        /// <param name="xmasText"></param>
        /// <returns></returns>
        public static int CountXmas(string[] xmasText)
        {
            string xmasString = "XMAS";
            int count = 0;
            for (int i = 0; i < xmasText.Length; i++)
            {
                for (int j = 0; j < xmasText[i].Length; j++)
                {
                    // Check if i,j is the upper left diagonal
                    count += checkIndices(xmasText, xmasString, new GridPoint[] {
                        new GridPoint(){X=i,   Y=j},
                        new GridPoint(){X=i+1, Y=j+1},
                        new GridPoint(){X=i+2, Y=j+2},
                        new GridPoint(){X=i+3, Y=j+3},
                    });

                    // Check if i,j is the upper horizontal
                    count += checkIndices(xmasText, xmasString, new GridPoint[] {
                        new GridPoint(){X=i,   Y=j},
                        new GridPoint(){X=i+1, Y=j},
                        new GridPoint(){X=i+2, Y=j},
                        new GridPoint(){X=i+3, Y=j}
                    });

                    // Check if i,j is the upper right diagonal
                    count += checkIndices(xmasText, xmasString, new GridPoint[] {
                        new GridPoint(){X=i,   Y=j},
                        new GridPoint(){X=i+1, Y=j-1},
                        new GridPoint(){X=i+2, Y=j-2},
                        new GridPoint(){X=i+3, Y=j-3}
                    });

                    // Check if i,j is the left veritcal
                    count += checkIndices(xmasText, xmasString, new GridPoint[] {
                        new GridPoint(){X=i, Y=j},
                        new GridPoint(){X=i, Y=j+1},
                        new GridPoint(){X=i, Y=j+2},
                        new GridPoint(){X=i, Y=j+3}
                    });

                    // Check if i,j is the right veritcal
                    count += checkIndices(xmasText, xmasString, new GridPoint[] {
                        new GridPoint(){X=i, Y=j},
                        new GridPoint(){X=i, Y=j-1},
                        new GridPoint(){X=i, Y=j-2},
                        new GridPoint(){X=i, Y=j-3}
                    });

                    // Check if i,j is the bottom left diagonal
                    count += checkIndices(xmasText, xmasString, new GridPoint[] {
                        new GridPoint(){X=i,   Y=j},
                        new GridPoint(){X=i-1, Y=j+1},
                        new GridPoint(){X=i-2, Y=j+2},
                        new GridPoint(){X=i-3, Y=j+3}
                    });

                    // Check if i,j is the lower horizontal
                    count += checkIndices(xmasText, xmasString, new GridPoint[] {
                        new GridPoint(){X=i,   Y=j},
                        new GridPoint(){X=i-1, Y=j},
                        new GridPoint(){X=i-2, Y=j},
                        new GridPoint(){X=i-3, Y=j}
                    });

                    // Check if i,j is the bottom right diagonal
                    count += checkIndices(xmasText, xmasString, new GridPoint[] {
                        new GridPoint(){X=i, Y=j},
                        new GridPoint(){X=i-1, Y=j-1},
                        new GridPoint(){X=i-2, Y=j-2},
                        new GridPoint(){X=i-3, Y=j-3},
                    });
                }
            }

            return count;
        }


        /// <summary>
        /// Part 2 of the Ceres Search Task
        /// </summary>
        /// <param name="xmasText"></param>
        /// <returns></returns>
        public static int CoutXshapeMAS(string[] xmasText)
        {
            string mas_mas = "MMASS";
            string mas_sam = "MSAMS";
            string sam_mas = "SMASM";
            string sam_sam = "SSAMM";

            int count = 0;
            for (int i = 0; i < xmasText.Length; i++)
            {
                for (int j = 0; j < xmasText[i].Length; j++)
                {
                    count += checkIndices(xmasText, mas_sam, new GridPoint[] {
                        new GridPoint(){X=i,   Y=j},   // upper left M
                        new GridPoint(){X=i,   Y=j+2}, // upper right S
                        new GridPoint(){X=i+1, Y=j+1}, // center center A
                        new GridPoint(){X=i+2, Y=j},   // bottom left M
                        new GridPoint(){X=i+2, Y=j+2 } // bottom right S
                    });

                    count += checkIndices(xmasText, mas_mas, new GridPoint[] {
                        new GridPoint(){X=i,   Y=j},   // upper left M
                        new GridPoint(){X=i,   Y=j+2}, // upper right M
                        new GridPoint(){X=i+1, Y=j+1}, // center center A
                        new GridPoint(){X=i+2, Y=j},   // bottom left S
                        new GridPoint(){X=i+2, Y=j+2 } // bottom right S
                    });

                    count += checkIndices(xmasText, sam_mas, new GridPoint[] {
                        new GridPoint(){X=i,   Y=j},   // upper left S
                        new GridPoint(){X=i,   Y=j+2}, // upper right M
                        new GridPoint(){X=i+1, Y=j+1}, // center center A
                        new GridPoint(){X=i+2, Y=j},   // bottom left S
                        new GridPoint(){X=i+2, Y=j+2 } // bottom right M
                    });

                    count += checkIndices(xmasText, sam_sam, new GridPoint[] {
                        new GridPoint(){X=i,   Y=j},   // upper left S
                        new GridPoint(){X=i,   Y=j+2}, // upper right S
                        new GridPoint(){X=i+1, Y=j+1}, // center center A
                        new GridPoint(){X=i+2, Y=j},   // bottom left M
                        new GridPoint(){X=i+2, Y=j+2 } // bottom right M
                    });
                }
            }

            return count;
        }

        private static int checkIndices(string[] xmasTexts, string checkText, GridPoint[] points)
        {
            int i = 0;
            foreach (char c in checkText)
            {
                if(!points[i].CheckGridBoundary(xmasTexts))
                {
                    return 0;
                }
                
                if (xmasTexts[points[i].X][points[i].Y] != c)
                {
                    return 0;
                }

                i++;
            }

            return 1;
        }
    }
}
