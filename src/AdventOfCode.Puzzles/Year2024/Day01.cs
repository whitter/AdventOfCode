namespace AdventOfCode.Puzzles.Year2024;

public class Day01 : PuzzleBase<(int[] First, int[] Second)>
{
    public override int Year => 2024;
    public override int Day => 1;
    public override string Name => "Historian Hysteria";

    protected override (int[] First, int[] Second) Parse(string input)
    {
        var lines = Lines(input)
            .Select(line => SplitBy<int>(line, "   ").ToArray());

        return (
            lines.Select(x => x[0]).OrderBy(x => x).ToArray(),
            lines.Select(x => x[1]).OrderBy(x => x).ToArray()
        );
    }

    protected override string Part1((int[] First, int[] Second) input)
        => input.First.Zip(input.Second, (first, second) => Math.Abs(first - second)).Sum().ToString();

    protected override string Part2((int[] First, int[] Second) input)
    {
        var counts = input.Second.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
        return input.First.Sum(x => x * counts.GetValueOrDefault(x, 0)).ToString();
    }

}