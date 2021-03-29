using SudokuSolver.Models;
using System.Linq;
using System;
using SudokuSolver.Logics;

namespace SudokuSolver.ConsoleTests
{
    class Program
    {
        private static readonly Solver solver = new Solver();

        static void Main(string[] args)
        {
            int[][] sudoku = SudokuData.GetMockData().First().Cells;
            PrintSudoku(sudoku);
            Console.WriteLine();
            PrintSudoku(solver.Solve(sudoku));
        }

        private static void PrintSudoku(int[][] sudoku)
        {
            for (int x = 0; x < sudoku.Length; x++)
            {
                for (int y = 0; y < sudoku[x].Length; y++)
                {
                    Console.Write(sudoku[x][y] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
