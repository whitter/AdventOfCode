namespace AdventOfCode.Puzzles.Year2023;

public class Day09 : PuzzleBase<IEnumerable<long[]>>
{
    public override int Year => 2023;
    public override int Day => 9;
    public override string Name => "Mirage Maintenance";

    protected override IEnumerable<long[]> Parse(string input)
        => Lines(input).Select(line => SplitBy<long>(line, " "));


    protected override string Part1(IEnumerable<long[]> input)
        => input.Select(Calculate).Sum().ToString();

    protected override string Part2(IEnumerable<long[]> input)
        => "0";

    private long Calculate(long[] input)
    {
        input.Skip(1).Zip(input, (first, second) => first - second);

        return 0;
    }
}