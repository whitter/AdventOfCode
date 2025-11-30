using AdventOfCode.Puzzles;
using ConsoleTables;


var assemblies = new[] {
    typeof(AdventOfCode.Puzzles.Year2020.Day01).Assembly,
    typeof(AdventOfCode.Puzzles.Year2021.Day01).Assembly,
    typeof(AdventOfCode.Puzzles.Year2022.Day01).Assembly,
    typeof(AdventOfCode.Puzzles.Year2023.Day01).Assembly,
    typeof(AdventOfCode.Puzzles.Year2024.Day01).Assembly
};

var puzzleTypes = assemblies
    .SelectMany(a => a.GetTypes())
    .Where(t => !t.IsAbstract && typeof(IPuzzle).IsAssignableFrom(t))
    .ToList();

var puzzles = puzzleTypes
    .Select(t => (IPuzzle)Activator.CreateInstance(t)!)
    .OrderBy(p => p.Year)
    .ThenBy(p => p.Day)
    .ToList();

int? year = null, day = null, part = null;
if (args.Length > 0 && int.TryParse(args[0], out var y)) year = y;
if (args.Length > 1 && int.TryParse(args[1], out var d)) day = d;
if (args.Length > 2 && int.TryParse(args[2], out var p)) part = p;

var filtered = puzzles.Where(p => (!year.HasValue || p.Year == year.Value)
    && (!day.HasValue || p.Day == day.Value)).ToList();

if (filtered.Count == 0)
{
    if (year.HasValue && day.HasValue)
        Console.WriteLine($"No puzzle found for {year} day {day:00}.");
    else if (year.HasValue)
        Console.WriteLine($"No puzzles found for year {year}.");
    else
        Console.WriteLine("No puzzles found.");
    return;
}

var grouped = filtered.GroupBy(p => p.Year).OrderBy(g => g.Key);

foreach (var group in grouped)
{
    Console.WriteLine($"Year {group.Key}");

    var table = new ConsoleTable("Day", "Name", "Part 1", "Bench 1 (ms)", "Part 2", "Bench 2 (ms)");

    foreach (var puzzle in group)
    {
        var input = Input.For(puzzle.Year, puzzle.Day);

        var sw1 = System.Diagnostics.Stopwatch.StartNew();
        var part1 = part is null || part == 1 ? SafeSolve(() => puzzle.SolvePart1(input)) : "-";
        sw1.Stop();
        var bench1 = sw1.ElapsedMilliseconds;

        var sw2 = System.Diagnostics.Stopwatch.StartNew();
        var part2 = part is null || part == 2 ? SafeSolve(() => puzzle.SolvePart2(input)) : "-";
        sw2.Stop();
        var bench2 = sw2.ElapsedMilliseconds;

        table.AddRow(puzzle.Day.ToString("00"), puzzle.Name, part1, $"{bench1}ms", part2, $"{bench2}ms");
    }

    table.Write();

    Console.WriteLine();
}

static string SafeSolve(Func<object> solve)
{
    try
    {
        var result = solve();
        return result?.ToString() ?? "(null)";
    }
    catch (Exception ex)
    {
        return $"Error: {ex.Message}";
    }
}
