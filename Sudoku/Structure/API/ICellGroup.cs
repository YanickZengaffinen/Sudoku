using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Structure
{
    /// <summary>
    /// Interfaces that represents a group of <see cref="ICell"/>... for example a row or a block
    /// </summary>
    public interface ICellGroup
    {
        /// <summary>
        /// The cells of this line
        /// </summary>
        ICell[] Cells { get; }

    }
}
