using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Structure
{
    /// <summary>
    /// Interface that represents a basic sudoku structure.
    /// </summary>
    public interface ISudoku
    {
        /// <summary>
        /// Get a 2D array of all the blocks of the sudoku 
        /// </summary>
        IBlock[,] Blocks { get; }

        /// <summary>
        /// Get a 2D array of all the cells of the sudoku
        /// </summary>
        ICell[,] Cells { get; }

        /// <summary>
        /// The size of one block
        /// </summary>
        int BlockSize { get; }

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

        /// <summary>
        /// Get a block
        /// </summary>
        /// <param name="row"> The row index of the block </param>
        /// <param name="column"> The column index of the block </param>
        /// <returns> An instance of <see cref="IBlock"/> specified by its coordinates </returns>
        IBlock GetBlock(in int row, in int column);

        /// <summary>
        /// Get an entire row of cells
        /// </summary>
        /// <param name="row"> The index of the row </param>
        /// <returns> An enumeration of the cells in this row </returns>
        IEnumerable<ICell> GetRow(in int row);

        /// <summary>
        /// Get an entire column of cells
        /// </summary>
        /// <param name="column"> The index of the column </param>
        /// <returns> An enumeration of the cells in this column </returns>
        IEnumerable<ICell> GetColumn(in int column);

    }
}
