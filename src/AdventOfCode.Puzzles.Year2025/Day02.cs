using AdventOfCode.Puzzles.Extensions;

namespace AdventOfCode.Puzzles.Year2025;

public class Day02 : PuzzleBase<IEnumerable<long[]>>
{
    public override int Year => 2025;
    public override int Day => 2;
    public override string Name => "Gift Shop";

    protected override IEnumerable<long[]> Parse(string input)
        => SplitBy<string>(input, ",").Select(x => SplitBy<long>(x, "-"));

    protected override string Part1(IEnumerable<long[]> input)
        => Process(input, id => [2]).ToString();

    protected override string Part2(IEnumerable<long[]> input)
        => Process(input, id => [.. Enumerable.Range(2, id.Length)]).ToString();

    private static long Process(IEnumerable<long[]> input, Func<string, int[]> selector)
        => input
            .SelectMany(a => Enumerable.Range(a[0], a[1]))
            .Where(x => IsInvalid(x, selector))
            .Sum();

    private static bool IsInvalid(long id, Func<string, int[]> selector)
    {
        var sId = id.ToString();

        return selector(sId)
            .Where(x => sId.Length % x == 0)
            .Select(x => sId.Length / x)
            .Any(x => string.Concat(Enumerable.Repeat(sId[..x], sId.Length / x)) == sId);
    }
}
