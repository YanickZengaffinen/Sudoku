using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Structure
{
    /// <summary>
    /// Interface that represents a sudoku-cell... contains only a integer value
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// The value of this cell
        /// </summary>
        uint Value { get; } //Using uint instead of byte to allow block sizes bigger than 16x16
    }
}
