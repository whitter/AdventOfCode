
using AdventOfCode.Puzzles;
using ConsoleTables;

var puzzleTypes = typeof(IPuzzle).Assembly
    .GetTypes()
    .Where(t => !t.IsAbstract && typeof(IPuzzle).IsAssignableFrom(t))
    .ToList();

var puzzles = puzzleTypes
    .Select(t => (IPuzzle)Activator.CreateInstance(t)!)
    .OrderBy(p => p.Year)
    .ThenBy(p => p.Day)
    .ToList();

if (args.Length == 0)
{
    var grouped = puzzles.GroupBy(p => p.Year).OrderBy(g => g.Key);

    foreach (var group in grouped)
    {
        Console.WriteLine($"Year {group.Key}");

        var table = new ConsoleTable("Day", "Name", "Part 1", "Part 2");

        foreach (var puzzle in group)
        {
            var input = Input.For(puzzle.Year, puzzle.Day);
            var part1 = puzzle.SolvePart1(input);
            var part2 = puzzle.SolvePart2(input);
            table.AddRow(puzzle.Day.ToString("00"), puzzle.Name, part1, part2);
        }

        table.Write(Format.Alternative);
        Console.WriteLine();
    }

    return;
}

if (args.Length == 1)
{
    if (!int.TryParse(args[0], out var year))
    {
        Console.WriteLine("Year must be an integer, e.g. `2024`.");
        return;
    }
    var yearPuzzles = puzzles.Where(p => p.Year == year).OrderBy(p => p.Day).ToList();

    if (!yearPuzzles.Any())
    {
        Console.WriteLine($"No puzzles found for year {year}.");
        return;
    }
    Console.WriteLine($"Year {year}");

    var table = new ConsoleTable("Day", "Name", "Part 1", "Part 2");

    foreach (var puzzle in yearPuzzles)
    {
        var input = Input.For(puzzle.Year, puzzle.Day);
        var part1 = puzzle.SolvePart1(input);
        var part2 = puzzle.SolvePart2(input);
        table.AddRow(puzzle.Day.ToString("00"), puzzle.Name, part1, part2);
    }
    table.Write(Format.Alternative);
    Console.WriteLine();
    return;
}

if (args.Length >= 2)
{
    if (!int.TryParse(args[0], out var year) || !int.TryParse(args[1], out var day))
    {
        Console.WriteLine("Year and day must be integers, e.g. `2024 1`.");
        return;
    }
    int? part = null;

    if (args.Length >= 3 && int.TryParse(args[2], out var parsedPart))
    {
        part = parsedPart;
    }

    var puzzleInstance = puzzles.SingleOrDefault(p => p.Year == year && p.Day == day);

    if (puzzleInstance is null)
    {
        Console.WriteLine($"No puzzle found for {year} day {day:00}.");
        return;
    }

    var input = Input.For(year, day);
    var table = new ConsoleTable("Day", "Name", "Part 1", "Part 2");
    var part1 = part is null || part == 1 ? puzzleInstance.SolvePart1(input) : "-";
    var part2 = part is null || part == 2 ? puzzleInstance.SolvePart2(input) : "-";

    table.AddRow(day.ToString("00"), puzzleInstance.Name, part1, part2);

    table.Write(Format.Alternative);
    Console.WriteLine();
    return;
}
