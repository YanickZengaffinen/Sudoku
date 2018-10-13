using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZenDoku.Structure
{
    /// <summary>
    /// Basic implementation of an <see cref="ISudoku"/>
    /// </summary>
    public sealed class Sudoku : ISudoku
    {
        public ICell[,] Cells { get; }

        public IBlock[,] Blocks { get; }
        public ICellGroup[] Rows { get; }
        public ICellGroup[] Columns { get; }

        public int Size { get; }
        public int BlockSize { get; }
        public int BlockAmount { get; }


        /// <summary>
        /// C'tor that generates a brand new Sudoku
        /// </summary>
        /// <param name="size">How many cells does the sudoku have on every axis</param>
        public Sudoku(in int size, in uint defaultValue) : this(size)
        {
            this.Cells = new ICell[Size, Size];

            //Initialize new cells
            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    Cells[row, column] = new Cell(defaultValue);
                }
            }

            InitStructure();
        }

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="cells"> The cells of the sudoku </param>
        public Sudoku(ICell[,] cells) : this(cells.GetLength(0))
        {
            this.Cells = cells;

            InitStructure();
        }

        /// <summary>
        /// Private C'tor which sets up the sizes and creates the blocks/rows/columns array
        /// </summary>
        /// <param name="size"> The size of the sudoku </param>
        private Sudoku(in int size)
        {
            this.Size = size;
            this.BlockSize = (int)Math.Sqrt(Size);
            this.BlockAmount = Size / BlockSize;

            this.Blocks = new IBlock[BlockAmount, BlockAmount];
            this.Rows = new ICellGroup[Size];
            this.Columns = new ICellGroup[Size];
        }

        //TODO: Should we do a boundscheck?
        public ICell this[in int row, in int column] {
            get => Cells[row, column];
        }

        /// <summary>
        /// Initializes the rows/columns/blocks references
        /// </summary>
        private void InitStructure()
        {
            //rows
            for (int row = 0; row < Size; row++)
            {
                var rowCells = new ICell[Size];

                for (int column = 0; column < Size; column++)
                {
                    rowCells[column] = this[row, column];
                }

                Rows[row] = new Line(rowCells);
            }

            //columns
            for (int column = 0; column < Size; column++)
            {
                var columnCells = new ICell[Size];

                for (int row = 0; row < Size; row++)
                {
                    columnCells[row] = this[row, column];
                }

                Columns[column] = new Line(columnCells);
            }

            //blocks
            for (int row = 0; row < BlockAmount; row++)
            {
                for (int column = 0; column < BlockAmount; column++)
                {
                    var cells = new ICell[BlockSize, BlockSize];

                    for (int y = 0; y < BlockSize; y++)
                    {
                        for (int x = 0; x < BlockSize; x++)
                        {
                            cells[x, y] = this[row * BlockSize + y, column * BlockSize + x];
                        }
                    }

                    Blocks[row, column] = new Block(cells);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder rVal = new StringBuilder();
            rVal.AppendLine($"Sudoku {Size}x{Size}");

            for(int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    rVal.Append(Cells[row, column].Value).Append(" ");
                }

                rVal.Append("\n");
            }

            return rVal.ToString();
        }

        /// <summary>
        /// Clones the sudoku
        /// </summary>
        /// <returns> A deep clone of the sudoku </returns>
        public object Clone()
        {
            var cells = new ICell[Size,Size];

            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    cells[row, column] = new Cell(Cells[row, column].Value);
                }
            }

            return new Sudoku(cells);
        }
    }
}
