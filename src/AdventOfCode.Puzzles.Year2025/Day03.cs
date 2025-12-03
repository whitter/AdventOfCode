namespace AdventOfCode.Puzzles.Year2025;

public class Day03 : PuzzleBase<string[]>
{
    public override int Year => 2025;
    public override int Day => 3;
    public override string Name => "Lobby";

    protected override string[] Parse(string input)
        => Lines(input);

    protected override string Part1(string[] input)
        => input.ToJolts(2).Sum().ToString();

    protected override string Part2(string[] input)
        => input.ToJolts(12).Sum().ToString();
}

file static class Day03Extensions
{
    public static IEnumerable<long> ToJolts(this string[] source, int digits)
    {
        foreach (var line in source)
        {
            var num = "";
            var temp = line;

            for (var i = 1; i <= digits; i++)
            {
                var max = temp[..^(digits - i)].Max();
                var index = temp.IndexOf(max);

                temp = temp[(index + 1)..];
                num += max;
            }

            yield return long.Parse(num.ToString());
        }
    }
}
