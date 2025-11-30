using AdventOfCode.Puzzles;
using AdventOfCode.Puzzles.Year2022;

namespace AdventOfCode.Tests.Year2022;

public class Day02Tests
{
    private readonly string SampleInput = Input.For(2022, 2, true);

    [Fact]
    public void Part1()
    {
        var puzzle = new Day02();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("15", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day02();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("12", result);
    }
}
