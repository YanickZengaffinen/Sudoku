using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Structure
{
    /// <summary>
    /// Basic implementation of a line
    /// </summary>
    public class Line : ICellGroup
    {
        public ICell[] Cells { get; }

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="cells"> The cells of this line </param>
        public Line(ICell[] cells)
        {
            this.Cells = cells;
        }
    }
}
