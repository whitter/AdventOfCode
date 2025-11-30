using AdventOfCode.Puzzles.Year2023;

namespace AdventOfCode.Tests.Year2023;

public class Day06Tests
{
    private const string SampleInput = """
    Time:      7  15   30
    Distance:  9  40  200
    """;

    [Fact]
    public void Part1()
    {
        var puzzle = new Day06();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("288", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day06();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("71503", result);
    }
}
