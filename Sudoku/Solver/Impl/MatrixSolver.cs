using System;
using System.Collections.Generic;
using System.Text;
using ZenDoku.Checker;
using ZenDoku.Structure;

namespace ZenDoku.Solver
{

    /// <summary>
    /// Solves an <see cref="ISudoku"/> by continuously evaluating a list of possible values for each <see cref="ICell"/>.
    /// Can only solve simple Sudokus!
    /// Whenever a cell only contains one number it must have that value.
    /// If there are no cells which only have one possible entry this solver cannot solve the sudoku.
    /// </summary>
    public class MatrixSolver : ISolver
    {
        public ISudoku Sudoku { get; protected set; }

        protected LinkedList<uint>[,] matrix;

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="sudoku"></param>
        public MatrixSolver(ISudoku sudoku)
        {
            this.Sudoku = sudoku;
            matrix = new LinkedList<uint>[sudoku.Size, sudoku.Size];

            ReCalculateMatrix();
        }

        public virtual void Solve()
        {
            while(!IsCompleted())
            {
                //Try to set the next definitive... if there is none throw an exception as this solver cannot solve the sudoku
                if(!TrySetNextNumber())
                {
                    throw new NotEnoughInformationException($"{this.GetType().Name} doesn't have enough information to solve the sudoku.");
                }
            }
        }

        /// <summary>
        /// Recalculates the entire matrix
        /// </summary>
        protected void ReCalculateMatrix()
        {
            for (int row = 0; row < Sudoku.Size; row++)
            {
                for (int column = 0; column < Sudoku.Size; column++)
                {
                    var entries = matrix[row, column] ?? new LinkedList<uint>(); //if the list for this cell has not yet been assigned, create a new one
                    entries.Clear();    //cleaning up all entries for this cell

                    for(uint i = 1; i <= Sudoku.Size; i++)
                    {
                        //check if the row, column or block doesn't contain the value already. Then we cannot add the entry.
                        if ( Sudoku[in row, in column].Value == 0 &&    //first check if we even need to find numbers for this cell
                            !Sudoku.Rows[row].Contains(i) && 
                            !Sudoku.Columns[column].Contains(i) && 
                            !Sudoku.Blocks[row / (uint)Sudoku.BlockSize, column / (uint)Sudoku.BlockSize].Contains(i))
                        {
                            entries.AddLast(i);
                        }
                    }

                    matrix[row, column] = entries; //set the matrix to the entries in case a new list has been generated
                }
            }
        }

        /// <summary>
        /// Method that tries to find the next definitive number
        /// </summary>
        /// <returns> True if a definitive has been set </returns>
        protected virtual bool TrySetNextNumber()
        {
            //search for a cell with only one matrix entry
            for (int row = 0; row < Sudoku.Size; row++)
            {
                for (int column = 0; column < Sudoku.Size; column++)
                {
                    if (matrix[row, column].Count == 1)
                    {
                        SetCell(row, column, matrix[row, column].First.Value);
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Sets the value for a cell
        /// </summary>
        /// <param name="row"> The row-index of the cell </param>
        /// <param name="column"> The column-index of the cell </param>
        /// <param name="value"> The value the cell should be set to </param>
        protected void SetCell(in int row, in int column, in uint value)
        {
            Sudoku.Cells[row, column].Value = value;

            //update the matrix
            //...clear the cell that has been assigned a value
            matrix[row, column].Clear();

            //...remove the number from all cells in the same row or column
            for(int i = 0; i < Sudoku.Size; i++)
            {
                matrix[row, i].Remove(value);
                matrix[i, column].Remove(value);
            }

            //...remove the number from the block
            int blockRow = row / Sudoku.BlockSize;
            int blockColumn = column / Sudoku.BlockSize;

            for(int i = blockRow * Sudoku.BlockSize; i < (blockRow + 1) * Sudoku.BlockSize; i++)
            {
                for (int j = blockColumn * Sudoku.BlockSize; j < (blockColumn + 1) * Sudoku.BlockSize; j++)
                {
                    matrix[i, j].Remove(value);
                }
            }

        }

        /// <summary>
        /// Check if the sudoku has been completed
        /// </summary>
        /// <returns></returns>
        protected virtual bool IsCompleted()
        {
            for (int row = 0; row < Sudoku.Size; row++)
            {
                for (int column = 0; column < Sudoku.Size; column++)
                {
                    if(matrix[row, column]?.Count != 0)
                    {
                        return false;
                    }
                }
            }

            if(!Sudoku.IsCompleted())
            {
                throw new Exception("Matrix Solver thinks the Sudoku has been completed but the SudokuChecker doesn't agree with that! The current state of the sudoku is: \n" + Sudoku.ToString());
            }

            return true;
        }
    }
}
