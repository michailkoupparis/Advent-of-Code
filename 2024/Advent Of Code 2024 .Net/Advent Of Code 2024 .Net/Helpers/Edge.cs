using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Helpers
{
    internal class Edge
    {
        public GridPoint StartingP;
        public GridPoint EndingP;
        public CellBoundary CellBoarder;

        public Edge(GridPoint startingP, GridPoint endingP, CellBoundary cellBoundary)
        {
            StartingP = startingP;
            EndingP = endingP;
            CellBoarder = cellBoundary;
        }

        public static List<Edge> GetConnectedEdges(List<Tuple<CellBoundary, GridPoint>> boundaries)
        {
            var edges = new List<Edge>();
            foreach (var horizontalGroup in boundaries.Where(x => x.Item1 == CellBoundary.UP || x.Item1 == CellBoundary.DOWN).GroupBy(x => x.Item1))
            {
                foreach (var Xgroup in horizontalGroup.GroupBy(x => x.Item2.X))
                {
                    var sortedPoints = Xgroup.OrderBy(p => p.Item2.Y).ToList();
                    var startPoint = new GridPoint(sortedPoints[0].Item2.X, sortedPoints[0].Item2.Y);
                    var endPoint = new GridPoint(sortedPoints[0].Item2.X, sortedPoints[0].Item2.Y);

                    for (int i = 1; i < sortedPoints.Count; i++)
                    {
                        if (sortedPoints[i - 1].Item2.Y == sortedPoints[i].Item2.Y - 1)
                        {
                            endPoint = sortedPoints[i].Item2;
                        }
                        else
                        {
                            edges.Add(new Edge(startPoint, endPoint, horizontalGroup.Key));
                            startPoint = new GridPoint(sortedPoints[i].Item2.X, sortedPoints[i].Item2.Y);
                            endPoint = new GridPoint(sortedPoints[i].Item2.X, sortedPoints[i].Item2.Y);
                        }
                    }
                    edges.Add(new Edge(startPoint, endPoint, horizontalGroup.Key));
                }
            }

            foreach (var verticalGroup in boundaries.Where(x => x.Item1 == CellBoundary.LEFT || x.Item1 == CellBoundary.RIGHT).GroupBy(x => x.Item1))
            {
                foreach (var YGroup in verticalGroup.GroupBy(x => x.Item2.Y))
                {
                    var sortedPoints = YGroup.OrderBy(p => p.Item2.X).ToList();
                    var startPoint = new GridPoint(sortedPoints[0].Item2.X, sortedPoints[0].Item2.Y);
                    var endPoint = new GridPoint(sortedPoints[0].Item2.X, sortedPoints[0].Item2.Y);

                    for (int i = 1; i < sortedPoints.Count; i++)
                    {
                        if (sortedPoints[i - 1].Item2.X == sortedPoints[i].Item2.X - 1)
                        {
                            endPoint = sortedPoints[i].Item2;
                        }
                        else
                        {
                            edges.Add(new Edge(startPoint, endPoint, verticalGroup.Key));
                            startPoint = new GridPoint(sortedPoints[i].Item2.X, sortedPoints[i].Item2.Y);
                            endPoint = new GridPoint(sortedPoints[i].Item2.X, sortedPoints[i].Item2.Y);
                        }
                    }
                    edges.Add(new Edge(startPoint, endPoint, verticalGroup.Key));
                }
            }

            return edges;
        }


        public override bool Equals(object? obj)
        {
            if (obj is Edge other)
            {
                return this.StartingP == other.StartingP && this.EndingP == other.EndingP;
            }
            return false;
        }

        public static bool operator ==(Edge obj1, Edge obj2)
        {
            if (ReferenceEquals(obj1, null) || ReferenceEquals(obj2, null))
                return false;

            return obj1.StartingP == obj2.StartingP && obj1.EndingP == obj2.EndingP;
        }

        public static bool operator !=(Edge obj1, Edge obj2)
        {
            return !(obj1 == obj2);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StartingP, EndingP);
        }

        public override string ToString()
        {
            return $"({StartingP.X}, {StartingP.Y}) - ({EndingP.X}, {EndingP.Y}) - ({CellBoarder})";
        }
    }
}
