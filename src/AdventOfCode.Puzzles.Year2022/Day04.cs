namespace AdventOfCode.Puzzles.Year2022;

public class Day04 : PuzzleBase<int[][][]>
{
    public override int Year => 2022;
    public override int Day => 4;
    public override string Name => "Camp Cleanup";

    protected override int[][][] Parse(string input)
        => Lines(input)
            .Select(x => SplitBy<string>(x, ",").Select(y => SplitBy<int>(y, "-")).ToArray())
            .ToArray();

    protected override string Part1(int[][][] input)
        => input
            .Where(x => (x[0][0] >= x[1][0] && x[0][1] <= x[1][1]) || (x[0][0] <= x[1][0] && x[0][1] >= x[1][1]))
            .Count()
            .ToString();

    protected override string Part2(int[][][] input)
        => input
            .Where(x => x[0][0] <= x[1][1] && x[1][0] <= x[0][1])
            .Count()
            .ToString();
}