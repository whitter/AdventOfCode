using AdventOfCode.Puzzles.Year2023;

namespace AdventOfCode.Tests.Year2023;

public class Day01Tests
{
    [Fact]
    public void Part1()
    {
        var puzzle = new Day01();

        var result = puzzle.SolvePart1("""
        1abc2
        pqr3stu8vwx
        a1b2c3d4e5f
        treb7uchet
        """);

        Assert.Equal("142", result);
    }

    [Fact]
    public void Part2()
    {
        var puzzle = new Day01();

        var result = puzzle.SolvePart2("""
        two1nine
        eightwothree
        abcone2threexyz
        xtwone3four
        4nineeightseven2
        zoneight234
        7pqrstsixteen
        """);

        Assert.Equal("281", result);
    }
}
