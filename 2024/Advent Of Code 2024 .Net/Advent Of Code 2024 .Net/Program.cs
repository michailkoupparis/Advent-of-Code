using Advent_Of_Code_2024_.Net.Day1;
using Advent_Of_Code_2024_.Net.Day2;
using Advent_Of_Code_2024_.Net.Day3;
using Advent_Of_Code_2024_.Net.Day4;
using Advent_Of_Code_2024_.Net.Day5;
using Advent_Of_Code_2024_.Net.Day6;

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
            checkDay6();
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

            //resultExmaple = GuardGallivant.CountPossibleLoopObstacles(inputExample.Room);
            //Console.WriteLine(resultExmaple);

            result = GuardGallivant.CountPossibleLoopObstacles(input.Room);
            Console.WriteLine(result);
        }

    }
}
