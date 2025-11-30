namespace AdventOfCode.Puzzles.Year2023;

public record Garden(long[] Seeds, IEnumerable<IEnumerable<(long From, long To, long Delta)>> Mappers);

public class Day05 : PuzzleBase<Garden>
{
    public override int Year => 2023;
    public override int Day => 5;
    public override string Name => "If You Give A Seed A Fertilizer";

    protected override Garden Parse(string input)
    {
        var groups = Lines(input, true);

        var seeds = SplitBy<long>(groups[0][(groups[0].IndexOf(':') + 1)..], " ");

        var maps = new List<List<(long From, long To, long Delta)>>();

        for (var i = 1; i < groups.Length; i++)
        {
            var group = new List<(long From, long To, long Delta)>();

            foreach (var map in Lines(groups[i]).Skip(1))
            {
                var numbers = SplitBy<long>(map, " ");

                group.Add((numbers[1], numbers[1] + numbers[2] - 1, numbers[0] - numbers[1]));
            }

            maps.Add(group);
        }

        return new Garden(seeds, maps);
    }


    protected override string Part1(Garden input)
    {
        var result = long.MaxValue;

        foreach (var seed in input.Seeds)
        {
            var current = seed;

            foreach (var mapper in input.Mappers)
            {
                foreach (var (From, To, Delta) in mapper)
                {
                    if (current >= From && current <= To)
                    {
                        current += Delta;
                        break;
                    }
                }
            }

            result = Math.Min(result, current);
        }

        return result.ToString();
    }

    protected override string Part2(Garden input)
    {
        var ranges = new List<(long From, long To)>();

        for (var i = 0; i < input.Seeds.Length; i += 2)
        {
            ranges.Add((input.Seeds[i], input.Seeds[i] + input.Seeds[i + 1] - 1));
        }

        foreach (var mapper in input.Mappers)
        {
            var next = new List<(long From, long To)>();
            var maps = mapper.OrderBy(x => x.From);

            foreach (var range in ranges)
            {
                var leftovers = range;

                foreach (var (From, To, Delta) in maps)
                {
                    (long From, long To) before = (leftovers.From, Math.Min(leftovers.To, From - 1));
                    (long From, long To) inside = (leftovers.From + Delta, Math.Min(leftovers.To, To) + Delta);

                    if (before.From <= before.To)
                    {
                        next.Add(before);

                        leftovers.From = From;
                    }

                    if (inside.From <= inside.To)
                    {
                        next.Add(inside);

                        leftovers.From = To + 1;
                    }

                    if (leftovers.From >= leftovers.To)
                    {
                        break;
                    }
                }

                if (leftovers.From < leftovers.To)
                {
                    next.Add(leftovers);
                }
            }

            ranges = next;
        }

        return ranges.Min(x => x.From).ToString();
    }
}