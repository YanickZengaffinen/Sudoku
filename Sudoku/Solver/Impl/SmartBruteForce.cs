using System;
using System.Collections.Generic;
using System.Text;
using ZenDoku.Structure;
using System.Linq;
using ZenDoku.Util;
using ZenDoku.Checker;

namespace ZenDoku.Solver
{
    /// <summary>
    /// Uses bruteforce to find a valid solution for the sudoku.
    /// Also computes a matrix and varies cells with a low amount of options first.
    /// Uses recursion to test out variations.
    /// </summary>
    public class SmartBruteForceSolver : MatrixSolver
    {
        private SmartBruteForceSolver variation; //allows this 

        public SmartBruteForceSolver(ISudoku sudoku) : base(sudoku)
        {
        }

        protected override bool TrySetNextNumber()
        {
            //if there are no definitives create a new variation
            if (base.TrySetNextNumber())
            {
                return true; //do not forget to return true if a number has been set
            }
            else
            {
                //get the cell with the least possible values
                var shortestValues = new LinkedList<uint>();
                int shortestLength = int.MaxValue;
                RowColumnPointer shortestCoords = default;

                matrix.ForEach((LinkedList<uint> entries, RowColumnPointer indices) => {
                    int cnt = entries.Count();
                    if (cnt > 0 && cnt < shortestLength)
                    {
                        shortestValues = entries;
                        shortestLength = cnt;
                        shortestCoords = indices;
                    }
                });

                //try out each possible value
                foreach(var value in shortestValues)
                {
                    //create a duplicate of the sudoku, modify the cell and create a solver for it
                    var sudokuClone = Sudoku.Clone() as ISudoku;
                    sudokuClone.Cells[shortestCoords.Row, shortestCoords.Column].Value = value;
                    this.variation = new SmartBruteForceSolver(sudokuClone);

                    //try to solve the variation
                    try
                    {
                        variation.Solve();
                    }
                    catch (NotEnoughInformationException ex) //the variation failed
                    {
                        continue;
                    }

                    //if we do not get an exceptions this means the variation has successfully been solved
                    this.Sudoku = GetSudokuVariation(); //get the sudoku from down the variation tree
                    return true;
                }
            }

            return false;
        }

        protected override bool IsCompleted()
        {
            return GetSudokuVariation().IsCompleted();
        }

        /// <summary>
        /// Get the variation of a sudoku if there exists one
        /// </summary>
        /// <returns> The varied sudoku </returns>
        private ISudoku GetSudokuVariation()
        {
            return variation?.Sudoku ?? Sudoku;
        }
        
        
    }
}
