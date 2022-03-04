using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatrixUtils;

namespace Matrizen
{
    public partial class Form1 : Form
    {

        private MatrixBase inputMatrix;
        private Button[,] buttons;


        public Form1()
        {
            InitializeComponent();

            inputMatrix = new MatrixBase(4);
            GenerateInputGrid(4);

            //MatrixToDataGrid(matrix);
        }


        private void GenerateInputGrid(int size)
        {
            InputTable.RowCount = size;
            InputTable.ColumnCount = size;

            InputTable.RowStyles.Clear();
            InputTable.ColumnStyles.Clear();

            buttons = new Button[size,size];

            for (int i = 0; i < size; i++)
            {
                InputTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / size));
                InputTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / size));
            }

            for (int i = 0; i < size * size; i++)
            {

                var x = i % size;
                var y = i / size;

                var b = new Button();
                b.Text = "0";
                b.Name = $"{(char)(x + 65)}:{(char)(y + 65)}";
                b.Size = InputTable.Size / size;
                b.BackColor = Color.IndianRed;

                if (x == y) 
                    b.Enabled = false;
                else
                    b.Click += (sender, args) =>
                    {
                        if (b.Text == "0")
                        {
                            buttons[x, y].Text = buttons[y, x].Text = "1";
                            buttons[x, y].BackColor = buttons[y, x].BackColor = Color.LightGreen;
                        }
                        else
                        {
                            buttons[x, y].Text = buttons[y, x].Text = "0";
                            buttons[x, y].BackColor = buttons[y, x].BackColor = Color.IndianRed;
                        }
                        inputMatrix[x][y] = inputMatrix[y][x] = float.Parse(b.Text);

                        SetPotencyMatrixView(ComputePotencyMatrix(inputMatrix));
                    };
                buttons[x,y] = b;


                InputTable.Controls.Add(b);
            }
        }

        private void SetPotencyMatrixView(MatrixBase matrix)
        {
            potencyMatrix.ColumnCount = potencyMatrix.RowCount = matrix.Size;

            potencyMatrix.RowStyles.Clear();
            potencyMatrix.ColumnStyles.Clear();

            for (int i = 0; i < matrix.Size; i++)
            {
                potencyMatrix.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / matrix.Size));
                potencyMatrix.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / matrix.Size));
            }
            potencyMatrix.Controls.Clear();

            for (int i = 0; i < matrix.Size * matrix.Size; i++)
            {
                var x = i % matrix.Size;
                var y = i / matrix.Size;

                var b = new Label();
                b.Text = $"{matrix[x][y].ToString("N2")}";
                b.Name = $"{(char)(x + 65)}:{(char)(y + 65)}";
                b.BorderStyle = BorderStyle.Fixed3D;
                b.TextAlign = ContentAlignment.MiddleCenter;
                b.Size = InputTable.Size / matrix.Size;

                potencyMatrix.Controls.Add(b,x,y);
            }
        }

        private MatrixBase ComputePotencyMatrix(MatrixBase matrix)
        {
            var res = new MatrixBase(matrix);

            for (int i = 0; i < matrix.Size; i++)
            {
                res *= matrix;
            }
            return res;
        }
    }
}
