using System.Globalization;

namespace AdventOfCode.Puzzles.Year2024;

public class Day07 : PuzzleBase<IEnumerable<(long Target, int[] Numbers)>>
{
    public override int Year => 2024;
    public override int Day => 7;
    public override string Name => "Bridge Repair";

    protected override IEnumerable<(long Target, int[] Numbers)> Parse(string input)
    => Lines(input)
        .Select(lines =>
        {
            var sections = SplitBy<string>(lines, ":");

            return (long.Parse(sections[0], CultureInfo.InvariantCulture), SplitBy<int>(sections[1].Trim(), " "));
        });

    protected override string Part1(IEnumerable<(long Target, int[] Numbers)> input)
        => input.Where(x => IsEquationPart1(x.Numbers[0], x.Target, x.Numbers[1..])).Sum(x => x.Target).ToString();

    protected override string Part2(IEnumerable<(long Target, int[] Numbers)> input)
        => input.Where(x => IsEquationPart2(x.Numbers[0], x.Target, x.Numbers[1..])).Sum(x => x.Target).ToString();

    private static bool IsEquationPart1(long total, long target, int[] numbers)
    {
        if (numbers.Length == 0)
        {
            return total == target;
        }

        return IsEquationPart1(total * numbers[0], target, numbers[1..]) || IsEquationPart1(total + numbers[0], target, numbers[1..]);
    }

    private static bool IsEquationPart2(long total, long target, int[] numbers)
    {
        if (numbers.Length == 0)
        {
            return total == target;
        }

        return IsEquationPart2(total * numbers[0], target, numbers[1..])
            || IsEquationPart2(total + numbers[0], target, numbers[1..])
            || IsEquationPart2(long.Parse($"{total}{numbers[0]}", CultureInfo.InvariantCulture), target, numbers[1..]);
    }
}