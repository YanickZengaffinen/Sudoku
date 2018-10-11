using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Structure
{
    /// <summary>
    /// Interface that represents a squared group of cells in an <see cref="ISudoku"/>
    /// </summary>
    public interface IBlock
    {
        /// <summary>
        /// All the cells contained in this block
        /// </summary>
        ICell[,] Cells { get; }

        /// <summary>
        /// The size of the block
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="row"> The row of the cell relative to the block </param>
        /// <param name="column"> The column of the cell relative to the block </param>
        /// <returns> The cell specified by the coordinates </returns>
        ICell this[in int row, in int column] { get; }

    }
}
