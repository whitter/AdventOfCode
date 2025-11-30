using AdventOfCode.Puzzles.Year2023;

namespace AdventOfCode.Tests.Year2023;

public class Day02Tests
{
    private const string SampleInput = """
    Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
    Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
    Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
    Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
    Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
    """;

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
