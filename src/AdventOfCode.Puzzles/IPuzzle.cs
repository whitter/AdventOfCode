namespace AdventOfCode.Puzzles
{
    public interface IPuzzle
    {
        int Year { get; }
        int Day { get; }
        string Name { get; }

        string SolvePart1(string input);
        string SolvePart2(string input);
    }
}
