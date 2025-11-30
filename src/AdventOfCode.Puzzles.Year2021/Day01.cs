using MoreLinq;

namespace AdventOfCode.Puzzles.Year2021;

public class Day01 : PuzzleBase<IEnumerable<int>>
{
    public override int Year => 2021;
    public override int Day => 1;
    public override string Name => "Sonar Sweep";

    protected override IEnumerable<int> Parse(string input)
        => Lines(input)
            .Select(x => Convert.ToInt32(x));

    protected override string Part1(IEnumerable<int> input)
        => CountIncreases(input).ToString();

    protected override string Part2(IEnumerable<int> input)
    {
        var windowed = input
            .Window(3)
            .Select(x => x.Sum());

        return CountIncreases(windowed).ToString();
    }

    public static int CountIncreases(IEnumerable<int> items)
    {
        return items
            .Pairwise((prev, current) => current > prev)
            .Count(x => x);
    }
}