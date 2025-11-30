using AdventOfCode.Puzzles;
using AdventOfCode.Puzzles.Year2023;

namespace AdventOfCode.Tests.Year2023;

public class Day09Tests
{
    private readonly string SampleInput = Input.For(2023, 9, true);

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
