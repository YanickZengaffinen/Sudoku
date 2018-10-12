using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ZenDoku.Solver;
using System.Linq;

namespace Sudoku_Unit_Tests.Solver
{
    public class SudokuSolverUtilUnitTester
    {

        [Fact]
        public void MissingValuesTest()
        {
            var noMissing = SudokuUtil.CellGroup(1, 3, 2).GetMissingValues();
            Assert.Empty(noMissing);

            var multipleMissing = SudokuUtil.CellGroup(0,0,1).GetMissingValues();
            Assert.True(multipleMissing.Intersect(new uint[] { 2, 3 }).Count() == 2);
        }

        [Fact]
        public void EmptyIndicesTest()
        {
            var allEmpty = SudokuUtil.CellGroup(0,0,0).GetEmptyIndices();
            Assert.True(allEmpty.Intersect(new uint[] { 0, 1, 2}).Count() == 3);

            var noEmpty = SudokuUtil.CellGroup(2, 1, 3).GetEmptyIndices();
            Assert.Empty(noEmpty);
        }

    }
}
