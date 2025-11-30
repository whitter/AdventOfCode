using System.Numerics;

namespace AdventOfCode.Puzzles.Year2024;

public class Day06 : PuzzleBase<(Dictionary<Complex, char> Grid, Complex Start)>
{
    public override int Year => 2024;
    public override int Day => 6;
    public override string Name => "Guard Gallivant";

    protected override (Dictionary<Complex, char> Grid, Complex Start) Parse(string input)
    {
        var grid = Lines(input)
            .SelectMany((row, y) => row.Select((cell, x) => new KeyValuePair<Complex, char>((-Complex.ImaginaryOne * y) + x, cell)))
            .ToDictionary();

        var start = grid.First(x => x.Value == '^').Key;

        return (grid, start);
    }

    protected override string Part1((Dictionary<Complex, char> Grid, Complex Start) input)
        => TraceRoute(input.Grid, input.Start).Path.Count().ToString();

    protected override string Part2((Dictionary<Complex, char> Grid, Complex Start) input)
    {
        var route = TraceRoute(input.Grid, input.Start).Path;

        var count = 0;

        foreach (var cell in route.Where(x => input.Grid[x] == '.'))
        {
            input.Grid[cell] = '#';

            var path = TraceRoute(input.Grid, input.Start);

            if (path.IsLoop)
            {
                count++;
            }

            input.Grid[cell] = '.';
        }

        return count.ToString();
    }

    private static (IEnumerable<Complex> Path, bool IsLoop) TraceRoute(Dictionary<Complex, char> grid, Complex position)
    {
        var path = new HashSet<(Complex Position, Complex Direction)>();
        var direction = Complex.ImaginaryOne;

        while (grid.ContainsKey(position) && !path.Contains((position, direction)))
        {
            path.Add((position, direction));

            if (grid.GetValueOrDefault(position + direction) == '#')
            {
                direction *= -Complex.ImaginaryOne;
            }
            else
            {
                position += direction;
            }
        }

        return (path.Select(x => x.Position).Distinct(), path.Contains((position, direction)));
    }
}