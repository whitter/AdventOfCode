using AdventOfCode.Puzzles;
using AdventOfCode.Puzzles.Year2022;

namespace AdventOfCode.Tests.Year2022;

public class Day01Tests
{
    private readonly string SampleInput = Input.For(2022, 1, true);

    [Fact]
    public void Part1()
    {
        var puzzle = new Day01();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("24000", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day01();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("45000", result);
    }
}
