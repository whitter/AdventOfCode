namespace AdventOfCode.Puzzles.Year2022;

public class Day01 : PuzzleBase<int[]>
{
    public override int Year => 2022;
    public override int Day => 1;
    public override string Name => "Calorie Counting";

    protected override int[] Parse(string input)
     => [.. Lines(input, true)
            .Select(x => SplitBy<int>(x, "\r", "\n", "\r\n").Sum())
            .OrderByDescending(x => x)];

    protected override string Part1(int[] input)
        => input.First().ToString();

    protected override string Part2(int[] input)
        => input
            .Take(3)
            .Sum()
            .ToString();
}