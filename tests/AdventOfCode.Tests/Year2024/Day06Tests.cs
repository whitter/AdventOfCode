using AdventOfCode.Puzzles.Year2024;

namespace AdventOfCode.Tests.Year2024;

public class Day06Tests
{
    private const string SampleInput = """
    ....#.....
    .........#
    ..........
    ..#.......
    .......#..
    ..........
    .#..^.....
    ........#.
    #.........
    ......#...
    """;

    [Fact]
    public void Part1()
    {
        var puzzle = new Day06();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("41", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day06();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("6", result);
    }
}
