using Advent_Of_Code_2024_.Net.Day1;
using Advent_Of_Code_2024_.Net.Day2;

namespace Advent_Of_Code_2024_.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //checkDay1();
            checkDay2();
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
    }
}
