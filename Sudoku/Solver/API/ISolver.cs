using ZenDoku.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZenDoku.Solver
{
    /// <summary>
    /// Interface for a class that solves sudokus
    /// </summary>
    public interface ISolver
    {
        /// <summary>
        /// The sudoku that is currently being solved
        /// </summary>
        ISudoku Sudoku { get; }

        /// <summary>
        /// Solve the sudoku
        /// </summary>
        void Solve();
    }
}
