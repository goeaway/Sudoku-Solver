using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SudokuSolver.Tests
{
    [TestClass]
    public class SudokuTests
    {
        private readonly int[,] array = new int[,]
        {
            {0,0,5,0,0,8,3,9,0},
            {0,3,0,0,0,0,0,0,0},
            {0,0,0,7,0,0,0,8,0},
            {0,0,4,5,0,0,6,0,2},
            {6,1,0,0,0,0,0,0,0},
            {2,0,0,0,4,9,0,0,0},
            {0,0,0,0,0,2,4,0,5},
            {0,0,9,0,8,0,0,0,0},
            {5,6,0,0,0,0,0,0,0},
        };

        [TestMethod]
        public void Solve()
        {
            var s = new Sudoku(array);
            var solved = Solver.Solve(s);
            Console.Write(solved.ToString());
            Assert.IsTrue(Checker.Check(solved));
        }

        [TestMethod]
        public void Generate()
        {
            var s = Generator.Generate(Difficulty.Easy);
            Console.Write(s.ToString());
            Assert.IsFalse(Checker.Check(s));
            Assert.IsFalse(s.Cells.All(c => c.Value == 0));

            var solved = Solver.Solve(s);
            Console.WriteLine();

            Console.Write(solved.ToString());
            Assert.IsTrue(Checker.Check(solved));
        }

        [TestMethod]
        public void Generate_Same_Seed_Generates_Same_Board()
        {
            var s1 = Generator.Generate(Difficulty.Medium, 1);
            var s2 = Generator.Generate(Difficulty.Medium, 1);
            Assert.AreEqual(s1, s2);
        }

        [TestMethod]
        public void Generate_Same_Seed_Different_Difficulty_Different_Boards()
        {
            var s1 = Generator.Generate(Difficulty.Easy, 1);
            var s2 = Generator.Generate(Difficulty.Medium, 1);
            Assert.AreNotEqual(s1, s2);
        }

        [TestMethod]
        public void Generate_No_Seed_Generates_New_Board()
        {
            var s1 = Generator.Generate(Difficulty.Medium);
            var s2 = Generator.Generate(Difficulty.Medium);
            Console.WriteLine(s1.ToString());
            Console.WriteLine();
            Console.WriteLine(s2.ToString());
            Assert.AreNotEqual(s1, s2);
        }
    }
}
