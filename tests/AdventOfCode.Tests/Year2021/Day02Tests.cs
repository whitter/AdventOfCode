using AdventOfCode.Puzzles;
using AdventOfCode.Puzzles.Year2021;

namespace AdventOfCode.Tests.Year2021;

public class Day02Tests
{
    private readonly string SampleInput = Input.For(2021, 2, true);

    [Fact]
    public void Part1()
    {
        var puzzle = new Day02();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("150", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day02();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("900", result);
    }
}
