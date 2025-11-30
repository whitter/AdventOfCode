namespace AdventOfCode.Puzzles.Year2021;

public class Day03 : PuzzleBase<IEnumerable<uint>>
{
    public override int Year => 2021;
    public override int Day => 3;
    public override string Name => "Binary Diagnostic";

    public int BitLength { get; set; } = 12;

    protected override IEnumerable<uint> Parse(string input)
        => Lines(input)
            .Select(x => Convert.ToUInt32(x, 2));

    protected override string Part1(IEnumerable<uint> input)
    {
        var most = MostBits(input, BitLength);

        return (most * InvertBits(most, BitLength)).ToString();
    }

    protected override string Part2(IEnumerable<uint> input)
        => (ToRating(input, BitLength) * ToRating(input, BitLength, true)).ToString();

    private static uint ToRating(IEnumerable<uint> input, int bitLength, bool invert = false)
    {
        IEnumerable<uint> rating = input.ToList();

        for (var i = 1u << bitLength - 1; i >= 1; i >>= 1)
        {
            if (rating.Count() == 1) break;

            var flag = GetCommonBit(rating, i);
            var mask = invert ? InvertBits(flag, bitLength) & i : flag;

            rating = rating.Where(x => (x & i) == mask).ToList();
        }

        return rating.First();
    }

    private static uint GetCommonBit(IEnumerable<uint> input, uint bit)
    {
        var agg = input.Aggregate(0, (count, n) => count + ((n & bit) == bit ? 1 : 0));

        return agg >= input.Count() / 2d ? bit : 0;
    }

    private static uint MostBits(IEnumerable<uint> input, int bitLength)
    {
        uint count = 0;

        for (var i = 1u << bitLength - 1; i >= 1; i >>= 1)
        {
            count += GetCommonBit(input, i);
        }

        return count;
    }

    private static uint InvertBits(uint input, int bitLength)
    {
        return (1u << bitLength) - input - 1;
    }
}