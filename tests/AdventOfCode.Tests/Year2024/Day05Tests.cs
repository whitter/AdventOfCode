using AdventOfCode.Puzzles.Year2024;

namespace AdventOfCode.Tests.Year2024;

public class Day05Tests
{
    private const string SampleInput = """
    47|53
    97|13
    97|61
    97|47
    75|29
    61|13
    75|53
    29|13
    97|29
    53|29
    61|53
    97|53
    61|29
    47|13
    75|47
    97|75
    47|61
    75|61
    47|29
    75|13
    53|13

    75,47,61,53,29
    97,61,53,29,13
    75,29,13
    75,97,47,61,53
    61,13,29
    97,13,75,29,47
    """;

    [Fact]
    public void Part1()
    {
        var puzzle = new Day05();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("143", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day05();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("123", result);
    }
}
