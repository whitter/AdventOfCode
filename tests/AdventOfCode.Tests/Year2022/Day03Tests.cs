using AdventOfCode.Puzzles;
using AdventOfCode.Puzzles.Year2022;

namespace AdventOfCode.Tests.Year2022;

public class Day03Tests
{
    private readonly string SampleInput = Input.For(2022, 3, true);

    [Fact]
    public void Part1()
    {
        var puzzle = new Day03();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("157", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day03();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("70", result);
    }
}
