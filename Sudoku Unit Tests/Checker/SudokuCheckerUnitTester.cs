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
        public void CellGroupContainsTest()
        {
            var state = SudokuUtil.CellGroup(1, 3, 0);

            Assert.True(state.Contains(1));
            Assert.False(state.Contains(2));
        }

        [Fact]
        public void IsCompletedTest()
        {
            var completed = SudokuUtil.CellGroup(3, 1, 2);
            Assert.True(completed.IsCompleted());

            var unfinished = SudokuUtil.CellGroup(0, 1, 0);
            Assert.False(unfinished.IsCompleted());

            var empty = SudokuUtil.CellGroup(0, 0, 0);
            Assert.False(empty.IsCompleted());
        }


    }
}
