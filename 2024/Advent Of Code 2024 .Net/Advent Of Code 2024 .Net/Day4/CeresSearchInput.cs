namespace Advent_Of_Code_2024_.Net.Day4
{
    internal static class CeresSearchInput
    {
        public static readonly string[] ExampleInput =
            new string[] {
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX"
            };
            

        public static string[] GetInput(string inputTextFile)
        {
            try
            {
                return File.ReadAllLines(inputTextFile);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                throw;
            }
        }
    }
}
