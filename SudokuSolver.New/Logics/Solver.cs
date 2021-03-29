using SudokuSolver.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SudokuSolver.Logics
{
    public class Solver
    {
        public int[][] Solve(int[][] sudoku)
        {
            int[][] initialCopy = (int[][]) sudoku.Clone();

            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (sudoku[y][x] == 0)
                    {
                        IList<int> output = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        output = CheckAllowed(output, sudoku, x, y);

                        if (output.Count == 1)
                        {
                            sudoku[y][x] = output.FirstOrDefault();
                            sudoku = Solve(sudoku);
                        }

                        Console.WriteLine("X: " + x + " | Y: " + y);
                        Console.WriteLine("Out: " + string.Join(", ", output));
                    }
                }
            }

            return sudoku;
        }

        public int[][] SolveGuessing(int[][] sudoku)
        {
            return sudoku;
        }

        public int[][] Create(int[][] sudoku)
        {
            return sudoku;
        }

        public IList<int> CheckAllowed(IList<int> output, int[][] sudoku, int whichX = 0, int whichY = 0)
        {
            for (int x = 0; x < 9; x++)
            {
                if(output.Contains(sudoku[whichY][x]))
                {
                    output.Remove(sudoku[whichY][x]);
                }
            }
            for (int y = 0; y < 9; y++)
            {
                if(output.Contains(sudoku[y][whichX]))
                {
                    output.Remove(sudoku[y][whichX]);
                }
            }
            int coordinateX = whichX - whichX % 3;
            int coordinateY = whichY - whichY % 3;
            for (int y = coordinateY; y < coordinateY + 3; y++)
            {
                for (int x = coordinateX; x < coordinateX + 3; x++)
                {
                    if(output.Contains(sudoku[y][x]))
                    {
                        output.Remove(sudoku[y][x]);
                    }
                }
            }

            return output;
        }
    }

    public enum CheckType
    {
        Row, Column, Box
    }
}