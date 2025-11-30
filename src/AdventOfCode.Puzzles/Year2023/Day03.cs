using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles.Year2023;

public record Part(int Number, (int y, int x)? Position);

public partial class Day03 : PuzzleBase<IEnumerable<Part>>
{
    public override int Year => 2023;
    public override int Day => 3;
    public override string Name => "Gear Ratios";

    protected override IEnumerable<Part> Parse(string input)
     => ToParts(Lines(input));


    protected override string Part1(IEnumerable<Part> input)
        => input.Sum(x => x.Number).ToString();

    protected override string Part2(IEnumerable<Part> input)
        => input
            .GroupBy(x => x.Position)
            .Where(x => x.Count() == 2)
            .Sum(x => x.First().Number * x.Last().Number)
            .ToString();

    public static IEnumerable<Part> ToParts(string[] values)
    {
        for (var i = 0; i < values.Length; i++)
        {
            var matches = FindNumberRegex().Matches(values[i]).AsQueryable();

            foreach (var match in matches)
            {
                for (var y = i - 1; y <= i + 1; y++)
                {
                    for (var x = match.Index - 1; x <= match.Index + match.Length; x++)
                    {
                        if (y < 0 || y >= values.Length || x < 0 || x >= values[i].Length)
                        {
                            continue;
                        }

                        if (char.IsDigit(values[y][x]) || values[y][x] == '.')
                        {
                            continue;
                        }

                        yield return new Part(int.Parse(match.Value), values[y][x] == '*' ? (y, x) : null);
                    }
                }
            }
        }
    }

    [GeneratedRegex(@"(\d+)")]
    private static partial Regex FindNumberRegex();
}