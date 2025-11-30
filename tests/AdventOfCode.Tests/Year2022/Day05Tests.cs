using AdventOfCode.Puzzles;
using AdventOfCode.Puzzles.Year2022;

namespace AdventOfCode.Tests.Year2022;

public class Day05Tests
{
    private readonly string SampleInput = Input.For(2022, 5, true);

    [Fact]
    public void Part1()
    {
        var puzzle = new Day05();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("CMZ", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day05();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("MCD", result);
    }
}
