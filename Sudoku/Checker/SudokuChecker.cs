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
        #region Contains
        /// <summary>
        /// Checks whether or not a specific row of a sudoku contains a certain number
        /// </summary>
        /// <param name="row"> The row in which to search for the number </param>
        /// <param name="number"> The number to be searched for </param>
        /// <returns> True if the row does contain the number else false </returns>
        public static bool DoesRowContainNumber(this ISudoku sudoku, in int row, in uint number)
            => DoesCellGroupContain(sudoku.GetRow(in row), number);

        /// <summary>
        /// Checks whether or not a specific column of a sudoku contains a certain number
        /// </summary>
        /// <param name="column"> The column in which to search for the number </param>
        /// <param name="number"> The number to be searched for </param>
        /// <returns> True if the column does contain the number else false </returns>
        public static bool DoesColumnContainNumber(this ISudoku sudoku, in int column, in uint number)
            => DoesCellGroupContain(sudoku.GetColumn(in column), number);

        /// <summary>
        /// Checks whether or not a specific block of a sudoku contains a certain number
        /// </summary>
        /// <param name="block"> The block in which to search </param>
        /// <param name="number"> The number to be searched for </param>
        /// <returns> True if the column does contain the number. Else false </returns>
        public static bool DoesBlockContain(this IBlock block, in uint number)
            => DoesCellGroupContain(block.Cells.Cast<ICell>(), number); //TODO: check if nested for loops aren't faster
        
        /// <summary>
        /// Helper method that checks if a group of cells contains a cell with the value equal to the specified number.
        /// </summary>
        /// <param name="cells">The enumeration of cells in which to look for the number </param>
        /// <param name="number">The number to look for </param>
        /// <returns></returns>
        private static bool DoesCellGroupContain(IEnumerable<ICell> cells, uint number)
        {
            return cells.Any(x => x.Value == number);
        }

        #endregion

        #region Completed

        /// <summary>
        /// Check if a sudoku is completed.
        /// This means that all it's blocks and rows/columns must be completed.
        /// </summary>
        /// <returns> True if the sudoku is completed. Else false </returns>
        public static bool IsCompleted(this ISudoku sudoku)
        {
            //check lines (rows and columns). Note: Do this first because it's faster.
            for (int line = 0; line < sudoku.Size; line++)
            {
                sudoku.IsRowCompleted(line);
                sudoku.IsColumnCompleted(line);
            }

            //check blocks
            for (int row = 0; row < sudoku.BlockSize; row++)
            {
                for (int column = 0; column < sudoku.BlockSize; column++)
                {
                    if(!sudoku.IsBlockCompleted(row, column))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Check a row of a sudoku for completion 
        /// </summary>
        /// <param name="row"> The index of the row </param>
        /// <returns> True if the row is completed. Else false </returns>
        public static bool IsRowCompleted(this ISudoku sudoku, in int row) 
            => IsCellGroupCompleted(sudoku.GetRow(in row));

        /// <summary>
        /// Check a column of a sudoku for completion
        /// </summary>
        /// <param name="column"> The index of the column </param>
        /// <returns> True if the column is completed. Else false </returns>
        public static bool IsColumnCompleted(this ISudoku sudoku, in int column) 
            => IsCellGroupCompleted(sudoku.GetColumn(in column));

        /// <summary>
        /// Check if a block of numbers is completed
        /// </summary>
        /// <param name="row"> The index of the row (in blocks) </param>
        /// <param name="column"> The index of the column (in blocks) </param>
        /// <returns></returns>
        public static bool IsBlockCompleted(this ISudoku sudoku, in int row, in int column) 
            => IsCellGroupCompleted(sudoku.GetBlock(in row, in column).Cells.Cast<ICell>());


        /// <summary>
        /// Helper method that checks if an enumeration of <see cref="ICell"/> contains one cell for each value starting at 1
        /// </summary>
        /// <param name="cells"> The enumeration of cells </param>
        /// <returns> True if the line is completed. Else false </returns>
        private static bool IsCellGroupCompleted(IEnumerable<ICell> cells)
        {
            for (int column = 0; column < cells.Count(); column++)
            {
                if (!cells.Any(x => x.Value == column + 1))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}
