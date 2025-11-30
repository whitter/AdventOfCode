namespace AdventOfCode.Puzzles.Year2022;

public class Day07 : PuzzleBase<Dictionary<string, int>>
{
    public override int Year => 2022;
    public override int Day => 7;
    public override string Name => "No Space Left On Device";

    protected override Dictionary<string, int> Parse(string input)
    {
        var commands = Lines(input)
            .Select(x => x.Split(' '))
            .ToArray();

        var result = new Dictionary<string, int>();

        var path = "";

        for (int i = 0; i < commands.Length; i++)
        {
            switch (commands[i][1])
            {
                case "cd":
                    path = Path.GetFullPath(Path.Combine(path, commands[i][2]));
                    break;
                case "ls":
                    var files = commands
                        .Skip(i + 1)
                        .TakeWhile(x => x[0] != "$")
                        .Where(x => x[0].All(char.IsAsciiDigit))
                        .Sum(x => int.Parse(x[0]));

                    result.Add(path, files);
                    break;
            }
        }

        foreach (var x in result)
        {
            foreach (var y in result.Where(n => x.Key != n.Key).Where(n => n.Key.StartsWith(x.Key)))
            {
                result[x.Key] += y.Value;
            }
        }

        return result;
    }

    protected override string Part1(Dictionary<string, int> input)
        => input
            .Where(x => x.Value <= 100000)
            .Sum(x => x.Value)
            .ToString();

    protected override string Part2(Dictionary<string, int> input)
    {
        var space = 30000000 - (70000000 - input.First().Value);

        return input
            .Where(x => x.Value >= space)
            .Min(x => x.Value)
            .ToString();
    }
}