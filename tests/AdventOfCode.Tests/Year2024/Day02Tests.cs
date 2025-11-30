using AdventOfCode.Puzzles.Year2024;

namespace AdventOfCode.Tests.Year2024;

public class Day02Tests
{
    private const string SampleInput = """
    7 6 4 2 1
    1 2 7 8 9
    9 7 6 2 1
    1 3 2 4 5
    8 6 4 4 1
    1 3 6 7 9
    """;

    [Fact]
    public void Part1()
    {
        var puzzle = new Day02();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("2", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day02();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("4", result);
    }
}
