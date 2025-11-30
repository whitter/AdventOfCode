namespace AdventOfCode.Puzzles.Year2023;

public class Day06 : PuzzleBase<int[][]>
{
    public override int Year => 2023;
    public override int Day => 6;
    public override string Name => "Wait For It";

    protected override int[][] Parse(string input)
        => [.. Lines(input).Select(line => SplitBy<int>(line[(line.IndexOf(':') + 1)..], " "))];


    protected override string Part1(int[][] input)
    {
        var results = new List<long>();

        for (var race = 0; race < input[0].Length; race++)
        {
            var fastest = new List<long>();

            var time = input[0][race];
            var distance = input[1][race];

            results.Add(CalculateCount(time, distance));
        }

        return results.Aggregate(1L, (total, count) => total * count).ToString();
    }

    protected override string Part2(int[][] input)
    {
        var time = long.Parse(input[0].Aggregate("", (result, input) => result + input));
        var distance = long.Parse(input[1].Aggregate("", (result, input) => result + input));

        return CalculateCount(time, distance).ToString();
    }

    private static long CalculateCount(long time, long distance)
    {
        var a = 1;
        var b = -time;
        var c = distance;

        var discriminant = b * b - 4 * a * c;

        var min = (long)(-b - (-b + Math.Sqrt(discriminant)) / (2 * a) + 1);

        return time - (min * 2) + 1;
    }
}