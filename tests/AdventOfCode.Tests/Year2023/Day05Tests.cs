using AdventOfCode.Puzzles.Year2023;

namespace AdventOfCode.Tests.Year2023;

public class Day05Tests
{
    private const string SampleInput = """
    seeds: 79 14 55 13

    seed-to-soil map:
    50 98 2
    52 50 48

    soil-to-fertilizer map:
    0 15 37
    37 52 2
    39 0 15

    fertilizer-to-water map:
    49 53 8
    0 11 42
    42 0 7
    57 7 4

    water-to-light map:
    88 18 7
    18 25 70

    light-to-temperature map:
    45 77 23
    81 45 19
    68 64 13

    temperature-to-humidity map:
    0 69 1
    1 0 69

    humidity-to-location map:
    60 56 37
    56 93 4
    """;

    [Fact]
    public void Part1()
    {
        var puzzle = new Day05();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("35", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day05();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("46", result);
    }
}
