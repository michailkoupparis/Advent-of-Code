using Advent_Of_Code_2024_.Net.Day1;
using Advent_Of_Code_2024_.Net.Day10;
using Advent_Of_Code_2024_.Net.Day11;
using Advent_Of_Code_2024_.Net.Day2;
using Advent_Of_Code_2024_.Net.Day3;
using Advent_Of_Code_2024_.Net.Day4;
using Advent_Of_Code_2024_.Net.Day5;
using Advent_Of_Code_2024_.Net.Day6;
using Advent_Of_Code_2024_.Net.Day7;
using Advent_Of_Code_2024_.Net.Day8;
using Advent_Of_Code_2024_.Net.Day9;

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
            checkDay11();
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
    }
}
