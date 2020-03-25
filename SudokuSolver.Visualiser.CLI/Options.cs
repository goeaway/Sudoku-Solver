using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace SudokuSolver.Visualiser.CLI
{
    public class Options
    {
        [Option('d', "difficulty", Default = 0, HelpText = "Difficulty of puzzle - Easy (0), Medium (1), Hard (2), Expert (3), Bloody Hard (4)")]
        public Difficulty Difficulty { get; set; }

        [Option('s', "seed", HelpText = "Seed for the puzzle generator")]
        public int? Seed { get; set; }

        [Option('t', "timeout", HelpText = "Time between values being tried in the puzzle")]
        public uint Timeout { get; set; }
    }
}
