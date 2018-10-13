using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZenDoku.Solver;
using ZenDoku.Structure;
using ZenDoku.Util;

namespace SudokuTest
{
    /// <summary>
    /// Interaction logic for SudokuSolver.xaml
    /// </summary>
    public partial class SudokuSolver : Window
    {
        private const int size = 9; //the size of the sudoku
        private TextBox[,] textBoxes; //reference to all the textboxes representing the cells of the sudoku

        private uint[,] test =
        {
            { 0,0,0,    6,0,7,  0,0,0 },
            { 6,9,0,    0,0,5,  1,0,0 },
            { 7,0,0,    2,3,0,  0,4,0 },

            { 3,0,1,    5,0,0,  0,0,4 },
            { 8,0,0,    0,9,0,  5,7,0 },
            { 0,0,0,    0,0,0,  2,0,3 },

            { 2,0,0,    0,0,0,  0,0,0 },
            { 5,8,0,    0,2,3,  7,6,0 },
            { 1,0,6,    7,8,0,  0,5,2 }
        };

        private uint[,] hard_test =
        {
            { 0,9,0,    0,0,1,  4,0,5 },
            { 0,0,0,    0,0,4,  7,0,8 },
            { 5,0,0,    3,0,0,  0,0,0 },

            { 7,8,0,    0,0,0,  6,0,0 },
            { 0,0,0,    0,5,0,  0,0,0 },
            { 0,0,2,    0,0,0,  0,4,7 },

            { 0,0,0,    0,0,6,  0,0,2 },
            { 2,0,5,    1,0,0,  0,0,0 },
            { 3,0,1,    2,0,0,  0,8,0 }
        };

        public SudokuSolver()
        {
            InitializeComponent();

            textBoxes = new TextBox[size, size];

            for(int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    TextBox box = new TextBox();

                    box.VerticalContentAlignment = VerticalAlignment.Center;
                    box.HorizontalContentAlignment = HorizontalAlignment.Center;
                    box.FontSize = 50;

                    box.Text = test[i, j] == 0 ? "" : test[i, j].ToString();

                    box.GotFocus += Box_GotFocus;

                    Grid.SetRow(box, i);
                    Grid.SetColumn(box, j);

                    textBoxes[i, j] = box;
                    Grid_Sudoku.Children.Add(box);
                }
            }

        }

        //clears the textbox whenever it gets the focus
        private void Box_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Text = "";
        }

        private void Btn_Solve_Click(object sender, RoutedEventArgs e)
        {
            //generate the sudoku from the textboxes
            var cells = new ICell[size, size];

            textBoxes.ForEach((TextBox textbox, RowColumnPointer pointer) => {
                cells[pointer.Row, pointer.Column] = new Cell(textbox.Text.Equals("") ? 0 : uint.Parse(textbox.Text));
            });

            var sudoku = new Sudoku(cells);

            //solves the sudoku
            var solver = new MatrixSolver(sudoku);
            solver.Solve();

            //set the textboxes to the solved values
            textBoxes.ForEach((TextBox textbox, RowColumnPointer pointer) => {
                textbox.Text = solver.Sudoku.Cells[pointer.Row, pointer.Column].Value.ToString();
            });
        }
    }
}
