using AdventOfCode.Puzzles;
using AdventOfCode.Puzzles.Year2025;

namespace AdventOfCode.Tests.Year2025;

public class Day03Tests
{
    private readonly string SampleInput = Input.For(2025, 3, true);

    [Fact]
    public void Part1()
    {
        var puzzle = new Day03();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("357", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day03();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("3121910778619", result);
    }
}
