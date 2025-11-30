using System;
using System.IO;

namespace AdventOfCode.Puzzles
{
    public static class Input
    {
        /// <summary>
        /// Load an input file from the /inputs/{year}/{day}.txt folder.
        /// Use example = true to load {day}.example.txt.
        /// </summary>
        public static string For(int year, int day, bool example = false)
        {
            // BaseDirectory is /bin/Debug/.../ for the running project.
            var baseDir = AppContext.BaseDirectory;

            // Adjust to solution root then to /inputs
            var root = Path.GetFullPath(Path.Combine(baseDir, "..", "..", "..", "..", ".."));
            var inputsDir = Path.Combine(root, "inputs", year.ToString());

            var fileName = $"{day:00}{(example ? ".example" : "")}.txt";
            var path = Path.Combine(inputsDir, fileName);

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Puzzle input not found: {path}");
            }

            return File.ReadAllText(path);
        }
    }
}

