using AdventOfCode.Puzzles;
using AdventOfCode.Puzzles.Year2021;

namespace AdventOfCode.Tests.Year2021;

public class Day01Tests
{
    private readonly string SampleInput = Input.For(2021, 1, true);

    [Fact]
    public void Part1()
    {
        var puzzle = new Day01();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("7", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day01();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("5", result);
    }
}
