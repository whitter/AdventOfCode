using System;
using System.Globalization;
using System.Linq;

namespace AdventOfCode.Puzzles
{
    public abstract class PuzzleBase<TParsed> : IPuzzle
    {
        public abstract int Year { get; }
        public abstract int Day { get; }
        public virtual string Name => GetType().Name;

        protected abstract TParsed Parse(string input);

        protected abstract string Part1(TParsed input);

        protected abstract string Part2(TParsed input);

        public string SolvePart1(string input)
        {
            var parsed = Parse(input);
            return Part1(parsed);
        }

        public string SolvePart2(string input)
        {
            var parsed = Parse(input);
            return Part2(parsed);
        }

        protected static string[] Lines(string input, bool splitByBlanks = false)
        {
            return splitByBlanks ? SplitBy<string>(input, "\r\r", "\n\n", "\r\n\r\n") : SplitBy<string>(input, "\r", "\n", "\r\n");
        }

        protected static T[] SplitBy<T>(string value, params string[] separators) => value
            .Split(separators, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => (T)Convert.ChangeType(x, typeof(T), CultureInfo.InvariantCulture))
            .ToArray();

    }
}

