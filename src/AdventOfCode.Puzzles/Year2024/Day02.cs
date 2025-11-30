namespace AdventOfCode.Puzzles.Year2024;

public class Day02 : PuzzleBase<int[][]>
{

    public override int Year => 2024;
    public override int Day => 2;
    public override string Name => "Red-Nosed Reports";

    protected override int[][] Parse(string input) => [.. Lines(input).Select(line => SplitBy<int>(line, " "))];

    protected override string Part1(int[][] input) => input.Count(IsSafe).ToString();

    protected override string Part2(int[][] input) =>
        input.Count(line => ToDampened(line).Any(IsSafe)).ToString();

    private static bool IsSafe(int[] line)
    {
        var increasing = line[1] > line[0];
        return line[..^1].Zip(line[1..], (first, second) =>
            Math.Abs(second - first) >= 1 &&
            Math.Abs(second - first) <= 3 &&
            (increasing ? second > first : second < first)
        ).All(x => x);
    }

    public static IEnumerable<int[]> ToDampened(int[] line)
    {
        for (var i = 0; i < line.Length; i++)
        {
            var newLine = new List<int>(line);
            newLine.RemoveAt(i);
            yield return newLine.ToArray();
        }
    }
}