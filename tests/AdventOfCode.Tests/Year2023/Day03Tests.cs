using AdventOfCode.Puzzles.Year2023;

namespace AdventOfCode.Tests.Year2023;

public class Day03Tests
{
    private const string SampleInput = """
    467..114..
    ...*......
    ..35..633.
    ......#...
    617*......
    .....+.58.
    ..592.....
    ......755.
    ...$.*....
    .664.598..
    """;

    [Fact]
    public void Part1()
    {
        var puzzle = new Day03();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("4361", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day03();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("467835", result);
    }
}
