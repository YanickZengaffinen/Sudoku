using System;
using System.Collections.Generic;
using System.Text;

namespace ZenDoku.Util
{
    /// <summary>
    /// Points to a coordinate specified by a row index and a column index
    /// </summary>
    public struct RowColumnPointer
    {
        /// <summary>
        /// The row index
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// The column index
        /// </summary>
        public int Column { get; }
        
        public RowColumnPointer(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

    }
}
