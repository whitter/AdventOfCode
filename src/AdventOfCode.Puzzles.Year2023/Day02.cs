namespace AdventOfCode.Puzzles.Year2023;

public record Cube(string Color, int Count);

public class Day02 : PuzzleBase<Dictionary<int, IEnumerable<Cube>>>
{
    public override int Year => 2023;
    public override int Day => 2;
    public override string Name => "Cube Conundrum";

    protected override Dictionary<int, IEnumerable<Cube>> Parse(string input)
        => Lines(input)
            .Select(line =>
            {
                var game = line.Split(':');

                var key = int.Parse(game[0].Split(' ')[1]);
                var value = game[1]
                    .Split([',', ';'])
                    .Select(cube =>
                    {
                        var set = cube.Trim().Split(' ');

                        return new Cube(set[1], int.Parse(set[0]));
                    })
                    .OrderByDescending(x => x.Count)
                    .GroupBy(cube => cube.Color)
                    .Select(cubes => cubes.First());

                return new KeyValuePair<int, IEnumerable<Cube>>(key, value);
            })
            .ToDictionary();


    protected override string Part1(Dictionary<int, IEnumerable<Cube>> input)
    {
        var bounds = new Dictionary<string, int> {
            { "red", 12},
            { "green", 13},
            { "blue", 14},
        };

        return input
            .Where(game => !game.Value.Any(set => set.Count > bounds[set.Color]))
            .Sum(game => game.Key)
            .ToString();
    }

    protected override string Part2(Dictionary<int, IEnumerable<Cube>> input)
        => input.Sum(x => x.Value.Aggregate(1, (power, set) => power * set.Count)).ToString();
}