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
        int current = 50;
        int result = 0;

        foreach (var (direction, steps) in input)
        {
            var move = direction == 'R' ? steps : -steps;
            current = (current + move) % 100;

            if (current == 0) result++;
        }

        return result.ToString();
    }

    protected override string Part2(IEnumerable<(char Direction, int Steps)> input)
        => "";
}