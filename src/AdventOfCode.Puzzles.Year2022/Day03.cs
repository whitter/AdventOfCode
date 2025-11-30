namespace AdventOfCode.Puzzles.Year2022;

public class Day03 : PuzzleBase<string[]>
{
    public override int Year => 2022;
    public override int Day => 3;
    public override string Name => "Rucksack Reorganization";

    protected override string[] Parse(string input)
        => Lines(input);

    protected override string Part1(string[] input)
        => input
            .Select(x => x.Chunk(x.Length / 2).ToArray())
            .Select(x => x[0].Intersect(x[1]).Single())
            .Sum(Priority)
            .ToString();

    protected override string Part2(string[] input)
        => input
            .Chunk(3)
            .Select(x => x[0].Intersect(x[1].Intersect(x[2])).Single())
            .Sum(Priority)
            .ToString();

    private static int Priority(char item) => char.IsLower(item) ? item - 'a' + 1 : item - 'A' + 27;
}