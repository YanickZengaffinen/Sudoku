using Sudoku.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Solver
{
    /// <summary>
    /// Interface for a class that solves sudokus
    /// </summary>
    public interface ISolver
    {
        /// <summary>
        /// Solve the sudoku
        /// </summary>
        /// <param name="sudoku">The sudoku to be solved</param>
        void Solve(ISudoku sudoku);
    }
}
