using Sudoku.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Checker
{
    /// <summary>
    /// Class that holds extension methods to simplify structural checks on an instance of <see cref="ISudoku"/> or <see cref="IBlock"/>
    /// </summary>
    // Note: cannot pass parameters with "in" modifier into anonymous methods
    public static class SudokuChecker
    {
        
        /// <summary>
        /// Checks if an <see cref="ICellGroup"/> contains a specific number
        /// </summary>
        /// <param name="number">The number to look for </param>
        /// <returns> True if the group contains the number </returns>
        public static bool Contains(this ICellGroup line, uint number)
        {
            return line.Cells.Any(x => x.Value == number);
        }


        /// <summary>
        /// Check if a sudoku is completed.
        /// This means that all it's blocks and rows/columns must be completed.
        /// </summary>
        /// <returns> True if the sudoku is completed </returns>
        public static bool IsCompleted(this ISudoku sudoku)
        {
            //check lines (rows and columns)
            for (int line = 0; line < sudoku.Size; line++)
            {
                if(!sudoku.Rows[line].IsCompleted() || !sudoku.Columns[line].IsCompleted())
                {
                    return false;
                }
            }

            //check blocks
            for (int row = 0; row < sudoku.BlockSize; row++)
            {
                for (int column = 0; column < sudoku.BlockSize; column++)
                {
                    if(!sudoku.Blocks[row, column].IsCompleted())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if an enumeration of <see cref="ICell"/> contains one cell for each value starting at 1
        /// </summary>
        /// <param name="line"> The enumeration of cells </param>
        /// <returns> True if the group is completed </returns>
        public static bool IsCompleted(this ICellGroup line)
        {
            for (int column = 0; column < line.Cells.Count(); column++)
            {
                if (!line.Cells.Any(x => x.Value == column + 1))
                {
                    return false;
                }
            }

            return true;
        }

    }
}
