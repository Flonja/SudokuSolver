using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.Logics;
using SudokuSolver.Models;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver.Tests
{
    [TestClass]
    public class SudokuTests
    {
        private readonly Solver solver = new Solver();

        [TestMethod]
        public void TestLogical()
        {
            SudokuModel sudoku = SudokuData.GetMockData().FirstOrDefault(sudku => sudku.Name == "Logical");
            var solvedCells = solver.Solve(sudoku.Cells);

            var fullySolved = new int[][]
                    {
                        new int[9] { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
                        new int[9] { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
                        new int[9] { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
                        new int[9] { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
                        new int[9] { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
                        new int[9] { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
                        new int[9] { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
                        new int[9] { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
                        new int[9] { 3, 4, 5, 2, 8, 6, 1, 7, 9 }
                    };

            for(int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    Assert.AreEqual(solvedCells[y][x], fullySolved[y][x], "Row: " + y + " | Column: " + x);
                }
            }
        }

        [TestMethod]
        public void TestCheckingSimpleAll()
        {
            int[][] sudoku = new int[][]
                {
                    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };

            IList<int> output = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            output = solver.CheckAllowed(output, sudoku);

            Assert.IsTrue(output.Count > 0, "Output count: " + output.Count);
        }

        [TestMethod]
        public void TestCheckingCantAll()
        {
            int[][] sudoku = new int[][]
                {
                    new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                    new int[9] { 4, 5, 6, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 7, 8, 9, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 3, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 5, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 6, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 8, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[9] { 9, 0, 0, 0, 0, 0, 0, 0, 0 }
                };

            IList<int> output = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            output = solver.CheckAllowed(output, sudoku);

            Assert.IsFalse(output.Count > 0, "Output count: " + output.Count);
        }
    }
}
