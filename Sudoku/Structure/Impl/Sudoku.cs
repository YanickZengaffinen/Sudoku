using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Structure
{
    /// <summary>
    /// Basic implementation of an <see cref="ISudoku"/>
    /// </summary>
    public class Sudoku : ISudoku
    {

        public IBlock[,] Blocks { get; }
        public ICell[,] Cells { get; }

        public int BlockSize { get; }
        public int Size { get; }

        /// <summary>
        /// C'tor that generates a brand new Sudoku
        /// </summary>
        /// <param name="blocks">How many blocks in width as well as length will this sudoku be made of?</param>
        /// <param name="blockSize"> The size of one block </param>
        public Sudoku(in int blocks, in int blockSize)
        {
            this.BlockSize = blockSize;
            this.Size = blocks * blockSize;

            this.Blocks = new IBlock[blocks, blocks];
            this.Cells = new ICell[this.Size, this.Size];

            //Initialize the blocks
            for(int row = 0; row < blocks; row++)
            {
                for(int column = 0; column < blocks; column++)
                {
                    //Initialize the cells of this block
                    var cells = new ICell[blockSize, blockSize];

                    for (int i = 0; i < blockSize; i++)
                    {
                        for (int j = 0; j < blockSize; j++)
                        {
                            var cell = new Cell();

                            Cells[row * blockSize + i, column * blockSize + j] = cell;
                            cells[i, j] = cell;
                        }
                    }

                    Blocks[row, column] = new Block(ref cells);
                }
            }
        }

        //TODO: Should we do a boundscheck?
        public ICell this[in int row, in int column] {
            get => Cells[row, column];
        }

        //TODO: Should we do a boundscheck?
        public IBlock GetBlock(in int row, in int column) => Blocks[row, column];

        //TODO: Should we do a boundscheck?
        public IEnumerable<ICell> GetColumn(in int column)
        {
            var rVal = new ICell[Size];

            for(int row = 0; row < Size; row++)
            {
                rVal[row] = this[row, column];
            }

            return rVal;
        }

        //TODO: Should we do a boundscheck?
        public IEnumerable<ICell> GetRow(in int row)
        {
            var rVal = new ICell[Size];

            for(int column = 0; column < Size; column++)
            {
                rVal[column] = this[row, column];
            }

            return rVal;
        }
    }
}
