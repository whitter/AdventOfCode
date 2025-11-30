using AdventOfCode.Puzzles.Year2023;

namespace AdventOfCode.Tests.Year2023;

public class Day09Tests
{
    private const string SampleInput = """
    0 3 6 9 12 15
    1 3 6 10 15 21
    10 13 16 21 30 45
    """;

    [Fact]
    public void Part1()
    {
        var puzzle = new Day09();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("142", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day09();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("281", result);
    }
}
