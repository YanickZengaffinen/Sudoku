using Sudoku.Structure;
using Sudoku.Checker;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sudoku_Unit_Tests.Checker
{
    public class SudokuCheckerUnitTester
    {

        [Fact]
        public void CellGroupContains()
        {
            var state = UIntToCellGroup(1, 3, 0);

            Assert.True(state.Contains(1));
            Assert.False(state.Contains(2));
        }

        [Fact]
        public void IsCompleted()
        {
            var completed = UIntToCellGroup(3, 1, 2);
            Assert.True(completed.IsCompleted());

            var unfinished = UIntToCellGroup(0, 1, 0);
            Assert.False(unfinished.IsCompleted());

            var empty = UIntToCellGroup(0, 0, 0);
            Assert.False(empty.IsCompleted());
        }

        /// <summary>
        /// Generates a CellGroup out of an array of uints
        /// </summary>
        private ICellGroup UIntToCellGroup(params uint[] values)
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
