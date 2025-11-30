using AdventOfCode.Puzzles;
using AdventOfCode.Puzzles.Year2024;

namespace AdventOfCode.Tests.Year2024;

public class Day01Tests
{
    private readonly string SampleInput = Input.For(2024, 1, true);

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
