using System.Numerics;

namespace AdventOfCode.Puzzles.Extensions;

public static class EnumerableExtensions
{
    extension(Enumerable)
    {
        public static IEnumerable<TResult> Range<TResult>(TResult start, TResult end) where TResult : INumber<TResult>
        {
            for (var value = start; value <= end; value++)
            {
                yield return value;
            }
        }
    }
}