using AdventOfCode.Puzzles;
using AdventOfCode.Puzzles.Year2025;

namespace AdventOfCode.Tests.Year2025;

public class Day02Tests
{
    private readonly string SampleInput = Input.For(2025, 2, true);

    [Fact]
    public void Part1()
    {
        var puzzle = new Day02();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("1227775554", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day02();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("4174379265", result);
    }
}
