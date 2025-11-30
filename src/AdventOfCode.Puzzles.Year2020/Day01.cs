using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Puzzles.Year2020
{
    public class Day01 : PuzzleBase<IEnumerable<int>>
    {
        public override int Year => 2020;
        public override int Day => 1;
        public override string Name => "Report Repair";

        protected override IEnumerable<int> Parse(string input)
            => Lines(input)
                .Select(x => Convert.ToInt32(x));

        protected override string Part1(IEnumerable<int> input)
            => Calculate(input, 2, 2020).ToString();

        protected override string Part2(IEnumerable<int> input)
            => Calculate(input, 3, 2020).ToString();

        private static int Calculate(IEnumerable<int> input, int length, int target)
        {
            return Permutations(input, length)
                .Where(x => x.Sum() == target)
                .First()
                .Aggregate((x1, x2) => x1 * x2);
        }

        public static IEnumerable<IEnumerable<int>> Permutations(IEnumerable<int> list, int length)
        {
            if (length == 1)
            {
                return list.Select(x => new int[] { x });
            }

            return Permutations(list, length - 1)
                .SelectMany(x => list.Where(n => !x.Contains(n)), (x1, x2) => x1.Concat(new int[] { x2 }));
        }
    }
}