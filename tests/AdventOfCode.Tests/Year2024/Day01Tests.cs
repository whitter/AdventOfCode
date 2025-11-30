using AdventOfCode.Puzzles.Year2024;

namespace AdventOfCode.Tests.Year2024;

public class Day01Tests
{
    private const string SampleInput = """
    3   4
    4   3
    2   5
    1   3
    3   9
    3   3
    """;

    [Fact]
    public void Part1()
    {
        var puzzle = new Day01();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("11", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day01();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("31", result);
    }
}
