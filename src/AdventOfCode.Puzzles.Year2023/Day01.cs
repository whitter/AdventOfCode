namespace AdventOfCode.Puzzles.Year2023;

public class Day01 : PuzzleBase<string[]>
{
    public override int Year => 2023;
    public override int Day => 1;
    public override string Name => "Trebuchet?!";

    protected override string[] Parse(string input)
        => Lines(input);


    protected override string Part1(string[] input)
        => input.Sum(ParseNumber).ToString();

    protected override string Part2(string[] input)
        => input.Sum(ParseLines).ToString();

    private static int ParseLines(string line)
    {
        line = line
            .Replace("one", "o1e")
            .Replace("two", "t2o")
            .Replace("three", "t3e")
            .Replace("four", "f4r")
            .Replace("five", "f5e")
            .Replace("six", "s6x")
            .Replace("seven", "s7n")
            .Replace("eight", "e8t")
            .Replace("nine", "n9e");

        return ParseNumber(line);
    }

    private static int ParseNumber(string line) => int.Parse($"{line.First(char.IsNumber)}{line.Last(char.IsNumber)}");
}