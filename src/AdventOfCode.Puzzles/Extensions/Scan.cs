using System;
using System.Collections.Generic;

namespace AdventOfCode.Puzzles.Extensions
{
    public static class ScanExtension
    {
        public static IEnumerable<TResult> Scan<TSource, TResult>(this IEnumerable<TSource> source, TResult seed, Func<TResult, TSource, TResult> transformation)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (transformation == null) throw new ArgumentNullException(nameof(transformation));

            using var e = source.GetEnumerator();

            yield return seed;

            while (e.MoveNext())
            {
                seed = transformation(seed, e.Current);
                yield return seed;
            }
        }
    }
}