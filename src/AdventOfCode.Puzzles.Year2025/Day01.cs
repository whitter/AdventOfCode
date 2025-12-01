using AdventOfCode.Puzzles.Extensions;

namespace AdventOfCode.Puzzles.Year2025;

public class Day01 : PuzzleBase<IEnumerable<int>>
{
    public override int Year => 2025;
    public override int Day => 1;
    public override string Name => "Secret Entrance";

    protected override IEnumerable<int> Parse(string input)
        => Lines(input)
            .Select(line => Convert.ToInt32(line[1..]) * (line[0] == 'R' ? 1 : -1));

    protected override string Part1(IEnumerable<int> input)
    {
        return input.Scan(50, (position, step) => (position + step) % 100)
            .Count(x => x == 0)
            .ToString();
    }

    protected override string Part2(IEnumerable<int> input)
    {
        return input.Scan((Position: 50, Count: 0), (current, step) =>
        {
            var rotated = current.Position + step;
            var count = Math.Abs(rotated / 100) + ((rotated <= 0 && current.Position > 0) || rotated >= 0 && current.Position < 0 ? 1 : 0);

            return (rotated % 100, count);
        })
            .Sum(x => x.Count)
            .ToString();
    }
}