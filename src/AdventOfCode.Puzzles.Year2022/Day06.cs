using MoreLinq;

namespace AdventOfCode.Puzzles.Year2022;

public class Day06 : PuzzleBase<string>
{
    public override int Year => 2022;
    public override int Day => 6;
    public override string Name => "Tuning Trouble";

    protected override string Parse(string input)
        => input;

    protected override string Part1(string input)
        => Process(input).ToString();

    protected override string Part2(string input)
        => Process(input, 14).ToString();

    private static int Process(string input, int size = 4)
    {
        var distinct = input
            .Window(size)
            .Index()
            .First(x => x.Value.Distinct().Count() == size);

        return distinct.Key + size;
    }
}