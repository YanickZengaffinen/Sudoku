using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ZenDoku;
using ZenDoku.Solver;
using ZenDoku.Structure;

namespace Sudoku_Unit_Tests.Solver
{
    public class SmartBruteForceUnitTester
    {
        [Fact]
        public void SmartBruteForceTest()
        {
            var sudoku = new Sudoku(new ICell[,] {
                { new Cell(6), new Cell(4), new Cell(0),    new Cell(2), new Cell(9), new Cell(8),      new Cell(5), new Cell(0), new Cell(7) },
                { new Cell(0), new Cell(5), new Cell(2),    new Cell(1), new Cell(0), new Cell(6),      new Cell(9), new Cell(8), new Cell(4) },
                { new Cell(7), new Cell(9), new Cell(8),    new Cell(0), new Cell(4), new Cell(5),      new Cell(0), new Cell(6), new Cell(2) },

                { new Cell(9), new Cell(0), new Cell(3),    new Cell(6), new Cell(1), new Cell(4),      new Cell(8), new Cell(7), new Cell(0) },
                { new Cell(0), new Cell(8), new Cell(6),    new Cell(5), new Cell(3), new Cell(0),      new Cell(4), new Cell(2), new Cell(9) },
                { new Cell(5), new Cell(7), new Cell(4),    new Cell(0), new Cell(8), new Cell(2),      new Cell(6), new Cell(0), new Cell(3) },

                { new Cell(8), new Cell(3), new Cell(0),    new Cell(7), new Cell(6), new Cell(9),      new Cell(2), new Cell(4), new Cell(1) },
                { new Cell(4), new Cell(1), new Cell(9),    new Cell(8), new Cell(0), new Cell(3),      new Cell(7), new Cell(5), new Cell(6) },
                { new Cell(2), new Cell(0), new Cell(7),    new Cell(4), new Cell(5), new Cell(1),      new Cell(3), new Cell(0), new Cell(8) }
            });

            var solver = new SmartBruteForceSolver(sudoku);
            solver.Solve();

            //TODO: check if result is correct
        }


    }
}
