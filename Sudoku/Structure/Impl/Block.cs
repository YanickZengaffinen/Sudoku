﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Structure
{
    /// <summary>
    /// Basic implementation of an <see cref="IBlock"/>
    /// </summary>
    public class Block : IBlock
    {
        public ICell[,] Cells { get; }

        public int Size { get; }

        /// <summary>
        /// C'tor that generates a brand new block
        /// </summary>
        /// <param name="size"> The dimension of this block </param>
        public Block(in int size)
        {
            this.Size = size;

            //Initialization of the cells
            Cells = new ICell[size, size];

            for(int row = 0; row < size; row++)
            {
                for(int column = 0; column < size; column++)
                {
                    Cells[row, column] = new Cell();
                }
            }
        }

        /// <summary>
        /// C'tor that generates a block from a list of existing cells
        /// </summary>
        /// <param name="cells"></param>
        public Block(ref ICell[,] cells)
        {
            this.Size = cells.GetLength(0);

            this.Cells = cells;
        }

        public ICell this[in int row, in int column] {
            get => Cells[row, column];
        }

    }
}
