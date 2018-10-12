using System;
using System.Collections.Generic;
using System.Text;

namespace ZenDoku.Structure
{
    /// <summary>
    /// Interface that represents a basic sudoku structure.
    /// </summary>
    public interface ISudoku
    {
        /// <summary>
        /// Get a 2D array of all the cells of the sudoku
        /// </summary>
        ICell[,] Cells { get; }

        /// <summary>
        /// Get a 2D array of all the blocks of the sudoku 
        /// </summary>
        IBlock[,] Blocks { get; }

        /// <summary>
        /// Get the rows of the sudoku as an array
        /// </summary>
        ICellGroup[] Rows { get; }

        /// <summary>
        /// Get the columns of the sudoku as an array
        /// </summary>
        ICellGroup[] Columns { get; }

        /// <summary>
        /// The size of one block
        /// </summary>
        int BlockSize { get; }

        /// <summary>
        /// The amount of blocks in one line
        /// </summary>
        int BlockAmount { get; }

        /// <summary>
        /// The size of the sudoku
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Indexer of the sudoku
        /// </summary>
        /// <param name="row">The row of the target cell in the sudoku</param>
        /// <param name="column">The column of the target cell in the sudoku</param>
        /// <returns> The target cell </returns>
        ICell this[in int row, in int column] { get; }

    }
}
