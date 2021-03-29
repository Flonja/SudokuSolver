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
                        IList<int> output = new List<int>();

                        IList<int> rows = CheckAllowed(CheckType.Row, sudoku, x, y);
                        IList<int> columns = CheckAllowed(CheckType.Column, sudoku, x, y);
                        IList<int> boxes = CheckAllowed(CheckType.Box, sudoku, x, y);

                        for (int i = 0; i < 9; i++)
                        {
                            if (rows.Contains(i) && columns.Contains(i) && boxes.Contains(i))
                            {
                                output.Add(i);
                            }
                        }

                        if (output.Count == 1)
                        {
                            sudoku[y][x] = output[0];
                            sudoku = Solve(sudoku);
                        }

                        Console.WriteLine("X: " + x + " | Y: " + y);
                        Console.WriteLine("Row: " + string.Join(", ", rows));
                        Console.WriteLine("Col: " + string.Join(", ", columns));
                        Console.WriteLine("Box: " + string.Join(", ", boxes));
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

        public IList<int> CheckAllowed(CheckType checkType, int[][] sudoku, int whichX = 0, int whichY = 0)
        {
            IList<int> output = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            switch(checkType)
            {
                case CheckType.Row:
                    for (int x = 0; x < 9; x++)
                    {
                        if(output.Contains(sudoku[whichY][x]))
                        {
                            output.Remove(sudoku[whichY][x]);
                        }
                    }
                    break;
                case CheckType.Column:
                    for (int y = 0; y < 9; y++)
                    {
                        if(output.Contains(sudoku[y][whichX]))
                        {
                            output.Remove(sudoku[y][whichX]);
                        }
                    }
                    break;
                case CheckType.Box:
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
                    break;
            }

            return output;
        }
    }

    public enum CheckType
    {
        Row, Column, Box
    }
}