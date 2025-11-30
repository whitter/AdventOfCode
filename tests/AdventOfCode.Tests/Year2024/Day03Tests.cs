using AdventOfCode.Puzzles.Year2024;

namespace AdventOfCode.Tests.Year2024;

public class Day03Tests
{
    [Fact]
    public void Part1()
    {
        var puzzle = new Day03();

        var result = puzzle.SolvePart1("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))");

        Assert.Equal("161", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day03();

        var result = puzzle.SolvePart2("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))");

        Assert.Equal("48", result);
    }
}
