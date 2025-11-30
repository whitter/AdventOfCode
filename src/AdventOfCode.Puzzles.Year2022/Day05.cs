using System.Text.RegularExpressions;
using MoreLinq;

namespace AdventOfCode.Puzzles.Year2022;

public class Day05 : PuzzleBase<(char[][] Stacks, (int, int, int)[] Instructions)>
{
    public override int Year => 2022;
    public override int Day => 5;
    public override string Name => "Supply Stacks";

    protected override (char[][] Stacks, (int, int, int)[] Instructions) Parse(string input)
    {
        var sections = Lines(input, true);

        var stacks = Lines(sections[0])
            .Transpose()
            .Select(x => x.Where(char.IsAsciiLetter).Reverse().ToArray())
            .Where(x => x.Length != 0)
            .ToArray();

        var regex = new Regex(@"(\d+)");

        var instructions = Lines(sections[1])
            .Select(x => regex.Matches(x).Select(x => int.Parse(x.Value)).ToArray())
            .Select(x => (x[0], x[1], x[2]))
            .ToArray();

        return (stacks, instructions);
    }

    protected override string Part1((char[][] Stacks, (int, int, int)[] Instructions) input)
    {
        var stacks = BuildStacks(input.Stacks);

        var result = Process(input.Instructions, stacks);

        return result.ToString();
    }

    protected override string Part2((char[][] Stacks, (int, int, int)[] Instructions) input)
    {
        var stacks = BuildStacks(input.Stacks);

        var result = Process(input.Instructions, stacks, true);

        return result.ToString();
    }

    private static Stack<char>[] BuildStacks(char[][] stacks)
    {
        return stacks
            .Select(x => new Stack<char>(x))
            .ToArray();
    }

    private static string Process((int, int, int)[] instructions, Stack<char>[] stacks, bool multiple = false)
    {
        var crane = new Stack<char>();

        foreach ((int qty, int from, int to) in instructions)
        {
            for (int i = 0; i < qty; i++)
            {
                if (stacks[from - 1].TryPop(out char value))
                {
                    if (multiple)
                    {
                        crane.Push(value);

                        continue;
                    }

                    stacks[to - 1].Push(value);
                }
            }

            if (multiple)
            {
                while (crane.TryPop(out char value))
                {
                    stacks[to - 1].Push(value);
                }
            }
        }

        var result = "";

        foreach (var stack in stacks)
        {
            if (stack.TryPop(out char value))
            {
                result += value;
            }
        }

        return result;
    }
}