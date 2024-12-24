using Advent_Of_Code_2024_.Net.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_Of_Code_2024_.Net.Day13
{
    internal static class ClawContraption
    {
        private const int BUTTON_A_COST = 3;
        private const int BUTTON_B_COST = 1;

        /// <summary>
        /// Part 1 and 2 of the Claw Contraption task
        /// </summary>
        /// <param name="clawMachines"></param>
        /// <returns></returns>
        public static long GetTokensToPrices(List<ClawMachine> clawMachines)
        {
            long totalTokens = 0;
            foreach (ClawMachine machine in clawMachines)
            {
                totalTokens += getTokensUsingMahts(machine);
            }
            return totalTokens;
        }

        private static long getTokensUsingMahts(ClawMachine machine)
        {
            //PriceX = A MoveAX + B MoveBX
            //PriceY = A MoveAY + B MoveBY

            long div1 = machine.ButtonB.GetX() * machine.ButtonA.GetY();
            long div2 = machine.ButtonB.GetY() * machine.ButtonA.GetX();

            long div = div1 - div2;
            if (div == 0)
            {
                return 0;
            }

            long up = machine.Price.X * machine.ButtonA.GetY() - machine.Price.Y * machine.ButtonA.GetX();
            
            long beta = up / div;
            long alpha = (machine.Price.X - beta * machine.ButtonB.GetX()) / machine.ButtonA.GetX();

            if(alpha * machine.ButtonA.GetX() +  beta * machine.ButtonB.GetX() != machine.Price.X)
            {
                return 0;
            }


            if (alpha * machine.ButtonA.GetY() + beta * machine.ButtonB.GetY() != machine.Price.Y)
            {
                return 0;
            }

            return alpha * BUTTON_A_COST + beta * BUTTON_B_COST;
        }

        private static long getTokensToPrice(ClawMachine clawMachine)
        {
            var priorityQueue = new SortedSet<(int cost, GridPointLong point)>(
                Comparer<(int cost, GridPointLong point)>.Create((a, b) =>
                {
                    // Compare by cost first
                    int cmp = a.cost.CompareTo(b.cost);
                    if (cmp != 0) return cmp;

                    // If costs are equal, compare by Manhattan distance to the prize (maximize the distance)
                    var distanceA = Math.Abs(a.point.X - clawMachine.Price.X) + Math.Abs(a.point.Y - clawMachine.Price.Y);
                    var distanceB = Math.Abs(b.point.X - clawMachine.Price.X) + Math.Abs(b.point.Y - clawMachine.Price.Y);
                    return distanceB.CompareTo(distanceA); // Want the further distance first (maximize)
                }));

            var visited = new HashSet<GridPointLong>();

            // Add the start point (0, 0) with cost 0
            priorityQueue.Add((0, new GridPointLong(0, 0)));

            while (priorityQueue.Count > 0)
            {
                var (currentCost, currentPoint) = priorityQueue.First();
                priorityQueue.Remove(priorityQueue.First());

                // If we reached the price point, return the cost to reach it
                if (currentPoint == clawMachine.Price)
                    return currentCost;

                if (visited.Contains(currentPoint))
                    continue;
                visited.Add(currentPoint);

                // Explore Button A (move forward with Button A)
                var nextPointA = clawMachine.ButtonA.GetNext(currentPoint);
                if (nextPointA.X <= clawMachine.Price.X && nextPointA.Y <= clawMachine.Price.Y)
                {
                    var newStateA = (currentCost + BUTTON_A_COST, nextPointA);
                    if (!visited.Contains(nextPointA))
                        priorityQueue.Add(newStateA);
                }

                // Explore Button B (move forward with Button B)
                var nextPointB = clawMachine.ButtonB.GetNext(currentPoint);
                if (nextPointB.X <= clawMachine.Price.X && nextPointB.Y <= clawMachine.Price.Y)
                {
                    var newStateB = (currentCost + BUTTON_B_COST, nextPointB);
                    if (!visited.Contains(nextPointB))
                        priorityQueue.Add(newStateB);
                }
            }

            return 0;  // If no path is found to the price, return 0
        }

        /*
        private static long getTokensToPrice(ClawMachine clawMachine)
        {
            var priorityQueue = new SortedSet<(int cost, GridPointLong point)>(
                Comparer<(int cost, GridPointLong point)>.Create((a, b) =>
                {
                    int cmp = a.cost.CompareTo(b.cost);
                    if (cmp != 0) return cmp;
                    cmp = a.point.X.CompareTo(b.point.X);
                    if (cmp != 0) return cmp;
                    return a.point.Y.CompareTo(b.point.Y);
                }));

            var visited = new HashSet<GridPointLong>();

            priorityQueue.Add((0, new GridPointLong(0, 0)));
            while (priorityQueue.Count > 0)
            {
                var (currentCost, currentPoint) = priorityQueue.First();
                priorityQueue.Remove(priorityQueue.First());

                if (currentPoint == clawMachine.Price)
                    return currentCost;

                var state = currentPoint;
                if (visited.Contains(state))
                    continue;
                visited.Add(state);


                var nextPointA = clawMachine.ButtonA.GetNext(currentPoint);
                if (nextPointA.X <= clawMachine.Price.X && nextPointA.Y <= clawMachine.Price.Y)
                {
                    var newStateA = (currentCost + BUTTON_A_COST, nextPointA);
                    if (!visited.Contains(nextPointA))
                        priorityQueue.Add(newStateA);
                }


                var nextPointB = clawMachine.ButtonB.GetNext(currentPoint);
                if (nextPointB.X <= clawMachine.Price.X && nextPointB.Y <= clawMachine.Price.Y)
                {
                    var newStateB = (currentCost + BUTTON_B_COST, nextPointB);
                    if (!visited.Contains(nextPointB))
                        priorityQueue.Add(newStateB);
                }
            }

            return 0;
        }
        */
    }
}
