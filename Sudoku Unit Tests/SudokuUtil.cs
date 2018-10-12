using ZenDoku.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku_Unit_Tests
{
    internal static class SudokuUtil
    {
        /// <summary>
        /// Generates a CellGroup out of an array of uints
        /// </summary>
        internal static ICellGroup CellGroup(params uint[] values)
        {
            var cells = new ICell[values.Length];

            for (int i = 0; i < cells.Length; i++)
            {
                cells[i] = new Cell(values[i]);
            }

            return new Line(cells);
        }
    }
}
