namespace AdventOfCode.Puzzles.Year2021;

public class Day02 : PuzzleBase<IEnumerable<(string, int)>>
{
    public override int Year => 2021;
    public override int Day => 2;
    public override string Name => "Dive!";

    protected override IEnumerable<(string, int)> Parse(string input)
        => Lines(input)
            .Select(x =>
            {
                var line = x.Split(' ');

                return (line[0], Convert.ToInt32(line[1]));
            });

    protected override string Part1(IEnumerable<(string, int)> input)
    {
        (int x, _, int d) = CalcPosition(input);

        return (x * d).ToString();
    }

    protected override string Part2(IEnumerable<(string, int)> input)
    {
        (int x, int y, _) = CalcPosition(input);

        return (x * y).ToString();
    }

    private static (int, int, int) CalcPosition(IEnumerable<(string, int)> input)
    {
        (int X, int Y, int D) position = (0, 0, 0);

        foreach ((string direction, int value) in input)
        {
            switch (direction)
            {
                case "forward":
                    position.X += value;
                    position.Y += position.D * value;
                    break;
                case "up":
                    position.D -= value;
                    break;
                case "down":
                    position.D += value;
                    break;
            }
        }

        return position;
    }
}