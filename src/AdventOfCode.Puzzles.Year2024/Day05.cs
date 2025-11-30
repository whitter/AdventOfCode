namespace AdventOfCode.Puzzles.Year2024;

public class Day05 : PuzzleBase<IEnumerable<int[]>>
{
    public override int Year => 2024;
    public override int Day => 5;
    public override string Name => "Print Queue";

    private PageComparer _pageComparer = null!;

    protected override IEnumerable<int[]> Parse(string input)
    {
        var sections = Lines(input, true);

        var order = Lines(sections[0]);

        _pageComparer = new PageComparer(order);

        return Lines(sections[1]).Select(x => SplitBy<int>(x, ","));
    }

    protected override string Part1(IEnumerable<int[]> input)
        => input
            .Where(IsSorted)
            .Sum(MiddleValue).ToString();

    protected override string Part2(IEnumerable<int[]> input)
        => input
            .Where(pages => !IsSorted(pages))
            .Select(pages => OrderPages(pages).ToArray())
            .Sum(MiddleValue).ToString();

    private bool IsSorted(int[] pages) => pages.SequenceEqual(OrderPages(pages));

    private static int MiddleValue(int[] pages) => pages[pages.Length / 2];

    private IOrderedEnumerable<int> OrderPages(int[] pages) => pages.OrderBy(page => page, _pageComparer);

    internal sealed class PageComparer : IComparer<int>
    {
        private readonly IEnumerable<string> _order;

        public PageComparer(IEnumerable<string> order) => _order = order;

        public int Compare(int x, int y) => _order.Contains(x + "|" + y) ? -1 : 1;
    }
}