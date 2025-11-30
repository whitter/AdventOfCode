using AdventOfCode.Puzzles.Year2024;

namespace AdventOfCode.Tests.Year2024;

public class Day04Tests
{
    private const string SampleInput = """
    MMMSXXMASM
    MSAMXMSMSA
    AMXSXMAAMM
    MSAMASMSMX
    XMASAMXAMM
    XXAMMXXAMA
    SMSMSASXSS
    SAXAMASAAA
    MAMMMXMMMM
    MXMXAXMASX
    """;

    [Fact]
    public void Part1()
    {
        var puzzle = new Day04();

        var result = puzzle.SolvePart1(SampleInput);

        Assert.Equal("18", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day04();

        var result = puzzle.SolvePart2(SampleInput);

        Assert.Equal("9", result);
    }
}
