using Advent_Of_Code_2024_.Net.Day1;
using Advent_Of_Code_2024_.Net.Day10;
using Advent_Of_Code_2024_.Net.Day11;
using Advent_Of_Code_2024_.Net.Day12;
using Advent_Of_Code_2024_.Net.Day13;
using Advent_Of_Code_2024_.Net.Day14;
using Advent_Of_Code_2024_.Net.Day15;
using Advent_Of_Code_2024_.Net.Day16;
using Advent_Of_Code_2024_.Net.Day2;
using Advent_Of_Code_2024_.Net.Day3;
using Advent_Of_Code_2024_.Net.Day4;
using Advent_Of_Code_2024_.Net.Day5;
using Advent_Of_Code_2024_.Net.Day6;
using Advent_Of_Code_2024_.Net.Day7;
using Advent_Of_Code_2024_.Net.Day8;
using Advent_Of_Code_2024_.Net.Day9;
using Advent_Of_Code_2024_.Net.Helpers;
using Advent_Of_Code_2024_.Net.Models;

namespace Advent_Of_Code_2024_.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //checkDay1();
            //checkDay2();
            //checkDay3();
            //checkDay4();
            //checkDay5();
            //checkDay6();
            //checkDay7();
            //checkDay8();
            //checkDay9();
            //checkDay10();
            //checkDay11();
            //checkDay12();
            //checkDay13();
            //checkDay14();
            //checkDay15();
            checkDay16();
        }

        private static void checkDay1()
        {
            int resultExmaple = HistorianHysteria.CalculateDistance(HistorianHysteriaInput.ExampleInput.List1, HistorianHysteriaInput.ExampleInput.List2);
            Console.WriteLine(resultExmaple);

            var input = new HistorianHysteriaInput("Day1/input.txt");
            int result = HistorianHysteria.CalculateDistance(input.List1, input.List2);
            Console.WriteLine(result);

            resultExmaple = HistorianHysteria.CalculateSimilarity(HistorianHysteriaInput.ExampleInput.List1, HistorianHysteriaInput.ExampleInput.List2);
            Console.WriteLine(resultExmaple);

            result = HistorianHysteria.CalculateSimilarity(input.List1, input.List2);
            Console.WriteLine(result);
        }

        private static void checkDay2()
        {
            int resultExmaple = RedNosedReports.GetSafeReports(RedNosedReportsInput.ExampleInput.Reports);
            Console.WriteLine(resultExmaple);

            var input = new RedNosedReportsInput("Day2/input.txt");
            int result = RedNosedReports.GetSafeReports(input.Reports);
            Console.WriteLine(result);

            resultExmaple = RedNosedReports.GetSafeReportsWithProblemDamper(RedNosedReportsInput.ExampleInput.Reports);
            Console.WriteLine(resultExmaple);

            result = RedNosedReports.GetSafeReportsWithProblemDamper(input.Reports);
            Console.WriteLine(result);
        }

        private static void checkDay3()
        {
            int resultExmaple = MullItOver.CheckMulAndAddResults("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))\r\n");
            Console.WriteLine(resultExmaple);

            var input = new MullItOverInput("Day3/input.txt");
            int result = MullItOver.CheckMulAndAddResults(input.CorruptedString);
            Console.WriteLine(result);

            resultExmaple = MullItOver.CheckMulAndAddResultsWithEnabled("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))\r\n");
            Console.WriteLine(resultExmaple);

            result = MullItOver.CheckMulAndAddResultsWithEnabled(input.CorruptedString);
            Console.WriteLine(result);
        }

        private static void checkDay4()
        {
            int resultExmaple = CeresSearch.CountXmas(CeresSearchInput.ExampleInput);
            Console.WriteLine(resultExmaple);

            var input = CeresSearchInput.GetInput("Day4/input.txt");
            int result = CeresSearch.CountXmas(input);
            Console.WriteLine(result);

            resultExmaple = CeresSearch.CoutXshapeMAS(CeresSearchInput.ExampleInput);
            Console.WriteLine(resultExmaple);

            result = CeresSearch.CoutXshapeMAS(input);
            Console.WriteLine(result);
        }

        private static void checkDay5()
        {
            var inputExample = new PrintQueueInput("Day5/example_input.txt");
            int resultExmaple = PrintQueue.GetAdditionOfMiddleSafetyProtocols(inputExample.Protocols, inputExample.PageOrderingRules);
            Console.WriteLine(resultExmaple);

            var input = new PrintQueueInput("Day5/input.txt");
            int result = PrintQueue.GetAdditionOfMiddleSafetyProtocols(input.Protocols, input.PageOrderingRules);
            Console.WriteLine(result);

            resultExmaple = PrintQueue.CorrectUnsafePagesAndGetMiddleAddition(inputExample.Protocols, inputExample.PageOrderingRules);
            Console.WriteLine(resultExmaple);

            result = PrintQueue.CorrectUnsafePagesAndGetMiddleAddition(input.Protocols, input.PageOrderingRules);
            Console.WriteLine(result);

        }

        private static void checkDay6()
        {
            var inputExample = new GuardGallivantInput("Day6/example_input.txt");
            int resultExmaple = GuardGallivant.CountSafePosts(inputExample.Room);
            Console.WriteLine(resultExmaple);

            var input = new GuardGallivantInput("Day6/input.txt");
            int result = GuardGallivant.CountSafePosts(input.Room);
            Console.WriteLine(result);

            resultExmaple = GuardGallivant.CountPossibleLoopObstacles(inputExample.Room);
            Console.WriteLine(resultExmaple);

            result = GuardGallivant.CountPossibleLoopObstacles(input.Room);
            Console.WriteLine(result);
        }

        private static void checkDay7()
        {
            var inputExample = new BridgeRepairInput("Day7/example_input.txt");
            long resultExmaple = BridgeRepair.SumValidEquations(inputExample.EquationItems, false);
            Console.WriteLine(resultExmaple);

            var input = new BridgeRepairInput("Day7/input.txt");
            long result = BridgeRepair.SumValidEquations(input.EquationItems, false);
            Console.WriteLine(result);

            resultExmaple = BridgeRepair.SumValidEquations(inputExample.EquationItems, true);
            Console.WriteLine(resultExmaple);

            result = BridgeRepair.SumValidEquations(input.EquationItems, true);
            Console.WriteLine(result);
        }

        private static void checkDay8()
        {
            var inputExample = new ResonantCollinearityInput("Day8/example_input.txt");
            int resultExmaple = ResonantCollinearity.CountAndinodes(inputExample.AntenaGrid, false);
            Console.WriteLine(resultExmaple);

            var input = new ResonantCollinearityInput("Day8/input.txt");
            int result = ResonantCollinearity.CountAndinodes(input.AntenaGrid, false);
            Console.WriteLine(result);

            resultExmaple = ResonantCollinearity.CountAndinodes(inputExample.AntenaGrid, true);
            Console.WriteLine(resultExmaple);

            result = ResonantCollinearity.CountAndinodes(input.AntenaGrid, true);
            Console.WriteLine(result);
        }

        private static void checkDay9()
        {
            long resultExmaple = DiskFragmenter.GetArrangedFilesCheckSum("2333133121414131402");
            Console.WriteLine(resultExmaple);

            var input = new DiskFragmenterInput("Day9/input.txt");
            long result = DiskFragmenter.GetArrangedFilesCheckSum(input.DISK);
            Console.WriteLine(result);

            resultExmaple = DiskFragmenter.GetArrangedFilesTogetherCheckSum("2333133121414131402");
            Console.WriteLine(resultExmaple);

            result = DiskFragmenter.GetArrangedFilesTogetherCheckSum(input.DISK);
            Console.WriteLine(result);
        }

        private static void checkDay10()
        {
            var inputExample = new HoofItInput("Day10/example_input.txt");
            int resultExmaple = HoofIt.CalculateTrailheadScores(inputExample.HikingTrails);
            Console.WriteLine(resultExmaple);

            var input = new HoofItInput("Day10/input.txt");
            int result = HoofIt.CalculateTrailheadScores(input.HikingTrails);
            Console.WriteLine(result);

            resultExmaple = HoofIt.CalculateTrailheadRatings(inputExample.HikingTrails);
            Console.WriteLine(resultExmaple);

            result = HoofIt.CalculateTrailheadRatings(input.HikingTrails);
            Console.WriteLine(result);
        }

        private static void checkDay11()
        {
            var inputExample = new List<long> { 125, 17 };
            long resultExmaple = PlutonianPebbles.GetPebblesAfterBlink(inputExample, 25);
            Console.WriteLine(resultExmaple);

            var input = new List<long> { 17639, 47, 3858, 0, 470624, 9467423, 5, 188 };
            long result = PlutonianPebbles.GetPebblesAfterBlinkRecursive(input.ToList(), 25);
            Console.WriteLine(result);


            result = PlutonianPebbles.GetPebblesAfterBlinkRecursiveMemo(input.ToList(), 75);
            Console.WriteLine(result);
        }

        private static void checkDay12()
        {
            long resultExample = GardenGroups.CalculateFenceCostPerimeter(GardenGroupsInput.Example1.Plots);
            Console.WriteLine(resultExample);
            resultExample = GardenGroups.CalculateFenceCostPerimeter(GardenGroupsInput.Example2.Plots);
            Console.WriteLine(resultExample);

            string[] exampleInput = new GardenGroupsInput("Day12/example_input.txt").Plots;
            resultExample = GardenGroups.CalculateFenceCostPerimeter(exampleInput);
            Console.WriteLine(resultExample);

            string[] input = new GardenGroupsInput("Day12/input.txt").Plots;
            long result = GardenGroups.CalculateFenceCostPerimeter(input);
            Console.WriteLine(result);

            resultExample = GardenGroups.CalculateFenceCostSides(GardenGroupsInput.Example1.Plots);
            Console.WriteLine(resultExample);
            resultExample = GardenGroups.CalculateFenceCostSides(GardenGroupsInput.Example2.Plots);
            Console.WriteLine(resultExample);
            resultExample = GardenGroups.CalculateFenceCostSides(GardenGroupsInput.Example3.Plots);
            Console.WriteLine(resultExample);
            resultExample = GardenGroups.CalculateFenceCostSides(GardenGroupsInput.Example4.Plots);
            Console.WriteLine(resultExample);

            resultExample = GardenGroups.CalculateFenceCostSides(exampleInput);
            Console.WriteLine(resultExample);

            result = GardenGroups.CalculateFenceCostSides(input);
            Console.WriteLine(result);
        }

        private static void checkDay13()
        {
            var inputExample = new ClawContraptionInput("Day13/example_input.txt");
            long resultExmaple = ClawContraption.GetTokensToPrices(inputExample.ClawMachines);
            Console.WriteLine(resultExmaple);

            var input = new ClawContraptionInput("Day13/input.txt");
            long result = ClawContraption.GetTokensToPrices(input.ClawMachines);
            Console.WriteLine(result);

            var inputExample2 = new List<ClawMachine>();
            foreach(ClawMachine machine in inputExample.ClawMachines)
            {
                inputExample2.Add(new ClawMachine(machine.ButtonA, machine.ButtonB, new GridPointLong(machine.Price.X + 10000000000000, machine.Price.Y + 10000000000000)));
            }
            long resultExmaple2 = ClawContraption.GetTokensToPrices(inputExample2);
            Console.WriteLine(resultExmaple2);

            var input2 = new List<ClawMachine>();
            foreach (ClawMachine machine in input.ClawMachines)
            {
                input2.Add(new ClawMachine(machine.ButtonA, machine.ButtonB, new GridPointLong(machine.Price.X + 10000000000000, machine.Price.Y + 10000000000000)));
            }
            long result2 = ClawContraption.GetTokensToPrices(input2);
            Console.WriteLine(result2);
        }

        private static void checkDay14()
        {
            var inputExample = new RestroomRedoubtInput("Day14/example_input.txt");
            int resultExmaple = RestroomRedoubt.GetSafetyFactor(inputExample.Robots.ToArray().DeepCopyArray(), 11, 7, 100);
            Console.WriteLine(resultExmaple);

            var input = new RestroomRedoubtInput("Day14/input.txt");
            int result = RestroomRedoubt.GetSafetyFactor(input.Robots.ToArray().DeepCopyArray(), 101, 103, 100);
            Console.WriteLine(result);

            //Dictionary<int, int> earliestXmasTree = RestroomRedoubt.GetEarliestXmasTree(inputExample.Robots.ToArray().DeepCopyArray(), 11, 7, 100000);
            //Console.WriteLine(earliestXmasTree);

            //var earliestXmasTree = RestroomRedoubt.GetEarliestXmasTree(input.Robots.ToArray().DeepCopyArray(), 101, 103, 19000);
            //Console.WriteLine(earliestXmasTree[10403]);
            //Console.WriteLine(earliestXmasTree);
            var input2 = new RestroomRedoubtInput("Day14/input.txt");
            RestroomRedoubt.GetEarliestXmasTreeVoid(input2.Robots.ToArray().DeepCopyArray(), 101, 103, 19000);
        }

        private static void checkDay15()
        {
            var inputExample = new WarehouseWoesInput("Day15/example_input.txt");
            int resultExmaple = WarehouseWoes.GetBoxesGpsLocations(inputExample.Warehouse, inputExample.RobotMovements);
            Console.WriteLine(resultExmaple);

            var input = new WarehouseWoesInput("Day15/input.txt");
            int result = WarehouseWoes.GetBoxesGpsLocations(input.Warehouse, input.RobotMovements);
            Console.WriteLine(result);

            var exampleWareHouseSize2 = inputExample.GetDoubleThWarehouse();
            int resultExmapleSize2 = WarehouseWoes.GetBoxesGpsLocationsDoubleWarehouse(exampleWareHouseSize2, inputExample.RobotMovements);
            Console.WriteLine(resultExmapleSize2);

            var inputWarehouseSize2 = input.GetDoubleThWarehouse();
            int resultSize2 = WarehouseWoes.GetBoxesGpsLocationsDoubleWarehouse(inputWarehouseSize2, input.RobotMovements);
            Console.WriteLine(resultSize2);
        }

        private static void checkDay16()
        {
            var inputExample = new ReindeerMazeInput("Day16/example_input.txt");
            int resultExmaple = ReindeerMaze.GetMazeShortestPathCost(inputExample.Maze);
            Console.WriteLine(resultExmaple);

            var inputExample2 = new ReindeerMazeInput("Day16/example_input2.txt");
            int resultExmaple2 = ReindeerMaze.GetMazeShortestPathCost(inputExample2.Maze);
            Console.WriteLine(resultExmaple2);

            var input = new ReindeerMazeInput("Day16/input.txt");
            int result = ReindeerMaze.GetMazeShortestPathCost(input.Maze);
            Console.WriteLine(result);

            resultExmaple = ReindeerMaze.GetMazeShortestPath(inputExample.Maze);
            Console.WriteLine(resultExmaple);

            resultExmaple2 = ReindeerMaze.GetMazeShortestPath(inputExample2.Maze);
            Console.WriteLine(resultExmaple2);

            result = ReindeerMaze.GetMazeShortestPath(input.Maze);
            Console.WriteLine(result);
        }

    }
}
