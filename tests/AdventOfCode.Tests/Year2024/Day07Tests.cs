using AdventOfCode.Puzzles.Year2024;

namespace AdventOfCode.Tests.Year2024;

public class Day07Tests
{
    private const string SampleInput = """
    190: 10 19
    3267: 81 40 27
    83: 17 5
    156: 15 6
    7290: 6 8 6 15
    161011: 16 10 13
    192: 17 8 14
    21037: 9 7 18 13
    292: 11 6 16 20
    """;

    [Fact]
    public void Part1()
    {
        var puzzle = new Day07();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("3749", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day07();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("11387", result);
    }
}
