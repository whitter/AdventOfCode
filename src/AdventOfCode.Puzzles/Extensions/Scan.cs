namespace AdventOfCode.Puzzles.Extensions;

public static class ScanExtension
{
    public static IEnumerable<TResult> Scan<TSource, TResult>(this IEnumerable<TSource> source, TResult seed, Func<TResult, TSource, TResult> transformation)
    {
        using var e = source.GetEnumerator();

        yield return seed;

        while (e.MoveNext())
        {
            seed = transformation(seed, e.Current);
            yield return seed;
        }
    }
}