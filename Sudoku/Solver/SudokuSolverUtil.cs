using Sudoku.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Solver
{
    /// <summary>
    /// Holds extension methods that make writing sudoku solving algorithms easier.
    /// </summary>
    public static class SudokuSolverUtil
    {
        /// <summary>
        /// Get all the values that are missing in an enumeration of cells.
        /// </summary>
        /// <returns> An enumeration of uints representing the missing values </returns>
        public static IEnumerable<uint> GetMissingValues(this ICellGroup line)
        {
            var rVal = new LinkedList<uint>();

            for (uint i = 1; i <= line.Cells.Count(); i++)
            {
                if(!line.Cells.Any(x => x.Value == i))
                {
                    rVal.AddLast(i);
                }
            }

            return rVal;
        }

        /// <summary>
        /// Get the indices of all empty cells inside this line
        /// </summary>
        /// <param name="cells"> The enumeration of cells </param>
        /// <returns> The indices of the empty cells </returns>
        public static IEnumerable<uint> GetEmptyIndices(this ICellGroup line)
        {
            var rVal = new LinkedList<uint>();

            for(uint i = 0; i < line.Cells.Count(); i++)
            {
                if(line.Cells.ElementAt((int)i).Value == 0)
                {
                    rVal.AddLast(i);
                }
            }

            return rVal;
        }
    }
}
