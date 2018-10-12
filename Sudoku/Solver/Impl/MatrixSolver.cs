using System;
using System.Collections.Generic;
using System.Text;
using Sudoku.Structure;

namespace Sudoku.Solver
{

    /// <summary>
    /// Solves an <see cref="ISudoku"/> by continuously evaluating a list of possible values for each <see cref="ICell"/>.
    /// Whenever a cell only contains one number it must have that value.
    /// If there are no cells which only have one possible entry this solver cannot solve the sudoku.
    /// </summary>
    public class MatrixSolver : ISolver
    {
        public void Solve(ISudoku sudoku)
        {
            
        }
    }
}
