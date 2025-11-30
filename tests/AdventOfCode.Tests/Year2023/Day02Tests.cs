using AdventOfCode.Puzzles;
using AdventOfCode.Puzzles.Year2023;

namespace AdventOfCode.Tests.Year2023;

public class Day02Tests
{
    private readonly string SampleInput = Input.For(2023, 2, true);

    [Fact]
    public void Part1()
    {
        var puzzle = new Day02();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("8", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day02();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("2286", result);
    }
}
