using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            Assert.AreEqual(solvedCells, new int[][]
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
                    });
        }
    }
}
