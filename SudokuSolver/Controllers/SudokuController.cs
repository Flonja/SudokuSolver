using SudokuSolver.Logics;
using SudokuSolver.Models;
using SudokuSolver.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SudokuSolver.Controllers
{
    public class SudokuController : Controller
    {
        private readonly Solver solver = new Solver();
        private readonly IEnumerable<SudokuModel> SudokuList = SudokuData.GetMockData();

        // GET: Sudoku
        public ActionResult Sudoku()
        {
            var SudokuVM = new SudokuViewModel { Sudoku = new SudokuModel()};
            if (TempData["sudoku"] != null)
            {
                SudokuVM.Sudoku = TempData["sudoku"] as SudokuModel;
                SudokuVM.SelectedSudoku = SudokuVM.Sudoku.SudokuId;
            }
            
            SudokuVM.Sudokus = SudokuList;
            

            if (SudokuVM.Sudoku.Cells == null)
            {
                SudokuVM.Sudoku.Cells = SudokuList.ElementAt(0).Cells;
            }

            return View(SudokuVM);
        }

        /// <summary>
        /// Solve without guessing.
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public ActionResult Solve(SudokuModel Model)
        {
            Model.Cells = solver.Solve(Model.Cells);
            TempData["sudoku"] = Model;
            return RedirectToAction("Sudoku");
        }

        /// <summary>
        /// Solve with guessing
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public ActionResult SolveGuessing(SudokuModel Model)
        {
            Model.Cells = solver.SolveGuessing(Model.Cells);
            TempData["sudoku"] = Model;
            return RedirectToAction("Sudoku");
        }

        /// <summary>
        /// Change the Sudoku to the given sudoku Id from the Sukokus model containing several Sudokus.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ChangeSudoku(int? id)
        {
            int sudokuNumber = id ?? 0;

            TempData["sudoku"] = new SudokuModel
            {
                Cells = SudokuList.ElementAt(sudokuNumber).Cells,
                SudokuId = sudokuNumber
            };

            return RedirectToAction("Sudoku");
        }

        /// <summary>
        /// Creates a randomized sudoku using the empty sudoku.
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateSudoku()
        {
            TempData["sudoku"] = new SudokuModel {Cells = solver.Create(SudokuList.ElementAt(2).Cells)};
            return RedirectToAction("Sudoku");
        }
    }
}