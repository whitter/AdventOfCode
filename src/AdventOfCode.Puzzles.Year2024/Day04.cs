namespace AdventOfCode.Puzzles.Year2024;

public class Day04 : PuzzleBase<(char[] Grid, int Length)>
{
    public override int Year => 2024;
    public override int Day => 4;
    public override string Name => "Ceres Search";

    protected override (char[] Grid, int Length) Parse(string input)
    {
        var lines = Lines(input);

        return (lines.SelectMany(x => x).ToArray(), lines.Length);
    }

    protected override string Part1((char[] Grid, int Length) input)
        => input.Grid.SelectMany((cell, index) => new[] { (0, 1), (1, 1), (1, 0), (1, -1) }.Where(dir => IsMatch(input.Grid, index, dir, "XMAS", input.Length))).Count().ToString();

    protected override string Part2((char[] Grid, int Length) input)
        => input.Grid.Where((cell, index) => IsMatch(input.Grid, index - input.Length - 1, (1, 1), "MAS", input.Length) && IsMatch(input.Grid, index - input.Length + 1, (1, -1), "MAS", input.Length)).Count().ToString();

    private static bool IsMatch(char[] grid, int start, (int Y, int X) dir, string match, int length)
    {
        var reversed = match.Reverse().ToArray();
        var offset = start;
        var set = new List<char>();

        for (var i = 0; i < match.Length; i++)
        {
            offset = start + (i * dir.Y * length) + (i * dir.X);

            if (offset < 0 || offset >= grid.Length || (start % length) + (i * dir.X) < 0 || (start % length) + (i * dir.X) >= length)
            {
                return false;
            }

            if (grid[offset] != match[i] && grid[offset] != reversed[i])
            {
                return false;
            }

            set.Add(grid[offset]);
        }

        return set.SequenceEqual(match) || set.SequenceEqual(reversed);
    }
}