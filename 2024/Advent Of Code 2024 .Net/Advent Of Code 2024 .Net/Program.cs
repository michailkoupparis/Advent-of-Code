using Advent_Of_Code_2024_.Net.Day1;

namespace Advent_Of_Code_2024_.Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int resultExmaple = HistorianHysteria.calculateSimilarity(HistorianHysteriaInput.ExampleInput.list1, HistorianHysteriaInput.ExampleInput.list2);
            Console.WriteLine(resultExmaple);

            var input = new HistorianHysteriaInput("Day1/input.txt");
            int result = HistorianHysteria.calculateSimilarity(input.list1, input.list2);
            Console.WriteLine(result);
        }
    }
}
