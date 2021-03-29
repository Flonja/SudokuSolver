using SudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SudokuSolver.ViewModels
{
    public class SudokuViewModel
    {
        public IEnumerable<SudokuModel> Sudokus { get; set; }
        public SudokuModel Sudoku { get; set; }
        public int SelectedSudoku { get; set; }
    }
}