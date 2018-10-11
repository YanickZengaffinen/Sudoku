using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Structure
{

    /// <summary>
    /// Basic implementation of an <see cref="ICell"/>
    /// </summary>
    public class Cell : ICell
    {
        public uint Value { get; set; }

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="initialValue"></param>
        public Cell(in uint initialValue = 0)
        {
            this.Value = initialValue;
        }
    }
}
