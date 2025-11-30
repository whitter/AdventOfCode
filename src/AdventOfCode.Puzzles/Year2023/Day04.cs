namespace AdventOfCode.Puzzles.Year2023;

public class Day04 : PuzzleBase<int[]>
{
    public override int Year => 2023;
    public override int Day => 4;
    public override string Name => "Scratchcards";

    protected override int[] Parse(string input)
     => [.. Lines(input)
            .Select(line =>
            {
                var winning = SplitBy<string>(line[(line.IndexOf(':') + 1)..line.IndexOf('|')], " ");
                var scratched = SplitBy<string>(line[(line.IndexOf('|') + 1)..], " ");

                return scratched.Count(winning.Contains);
            })];


    protected override string Part1(int[] input)
        => input.Sum(x => x > 0 ? 1 << x - 1 : 0).ToString();

    protected override string Part2(int[] input)
    {
        int[] counts = Enumerable.Repeat(1, input.Length).ToArray();

        for (var i = 0; i < input.Length; i++)
        {
            for (var n = 1; n <= input[i]; n++)
            {
                counts[n + i] += counts[i];
            }
        }

        return counts.Sum().ToString();
    }
}