namespace AdventOfCode.Puzzles.Year2022;

public class Day02 : PuzzleBase<(int, int)[]>
{
    public override int Year => 2022;
    public override int Day => 2;
    public override string Name => "Rock Paper Scissors";

    protected override (int, int)[] Parse(string input)
        => Lines(input)
            .Select(x => SplitBy<char>(x, " "))
            .Select(x => (x[0] - 'A', x[1] - 'X'))
            .ToArray();

    protected override string Part1((int, int)[] input)
    {
        int score = 0;

        foreach ((int op, int me) in input)
        {
            score += Score(op, me);
        }

        return score.ToString();
    }

    protected override string Part2((int, int)[] input)
    {
        int score = 0;

        foreach ((int op, int me) in input)
        {
            var mod = (op + me - 1) % 3;

            score += Score(op, mod < 0 ? mod + 3 : mod);
        }

        return score.ToString();
    }

    private static int Score(int op, int me)
    {
        int score = me + 1;

        if (op == me)
        {
            score += 3;
        }
        else if (me == (op + 1) % 3)
        {
            score += 6;
        }

        return score;
    }
}