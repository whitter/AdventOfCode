namespace AdventOfCode.Puzzles.Year2025;

public class Day01 : PuzzleBase<IEnumerable<(char Direction, int Steps)>>
{
    public override int Year => 2025;
    public override int Day => 1;
    public override string Name => "Secret Entrance";

    protected override IEnumerable<(char Direction, int Steps)> Parse(string input)
        => Lines(input)
            .Select(line => (line[0], Convert.ToInt32(line[1..])));

    protected override string Part1(IEnumerable<(char Direction, int Steps)> input)
    {
        var steps = input.Select(step => step.Direction == 'R' ? step.Steps : -step.Steps);

        return Rotate(steps).Count(IsZero).ToString();
    }

    protected override string Part2(IEnumerable<(char Direction, int Steps)> input)
    {
        var steps = input.SelectMany(x =>
        {
            var direction = x.Direction == 'R' ? 1 : -1;

            return Enumerable.Range(0, x.Steps).Select(_ => direction);
        });

        return Rotate(steps).Count(IsZero).ToString();
    }

    private static readonly Func<int, bool> IsZero = step => step == 0;

    private static IEnumerable<int> Rotate(IEnumerable<int> input)
    {
        int current = 50;

        foreach (var step in input)
        {
            current = (current + step) % 100;
            yield return current;
        }
    }
}