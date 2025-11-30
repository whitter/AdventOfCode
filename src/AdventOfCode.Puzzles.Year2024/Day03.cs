using System.Globalization;
using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles.Year2024;

public partial class Day03 : PuzzleBase<string>
{
    public override int Year => 2024;
    public override int Day => 3;
    public override string Name => "Mull It Over";

    protected override string Parse(string input) => input;

    protected override string Part1(string input) => MulRegex().Matches(input).Sum(CalcMatch).ToString();

    protected override string Part2(string input)
    {
        var enable = true;

        return EnabledMulRegex().Matches(input).Sum(match =>
        {
            switch (match.Groups[0].Value)
            {
                case "do()":
                    enable = true;
                    return 0;
                case "don't()":
                    enable = false;
                    return 0;
                default:
                    return enable ? CalcMatch(match) : 0;
            }
        }).ToString();
    }

    private static int CalcMatch(Match match) =>
        int.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture) * int.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);

    [GeneratedRegex(@"mul\((\d*),(\d*)\)")]
    private static partial Regex MulRegex();

    [GeneratedRegex(@"mul\((\d*),(\d*)\)|(do\(\))|(don't\(\))")]
    private static partial Regex EnabledMulRegex();
}