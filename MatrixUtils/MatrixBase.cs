using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixUtils
{
    public class MatrixBase
    {
        #region Properties

        private float[][] values;

        public float[][] Values => values;

        public float GetValue(int x, int y) => values[x][y];
        public void SetValue(int x, int y, float value) => values[x][y] = value;

        public int Size => values.Length;

        public float[] this[int index] => values[index];


        #endregion

        #region Contructor

        public MatrixBase(int size)
        {
            values = new float[size][];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = new float[size];
            }
        }

        public MatrixBase(MatrixBase input)
        {
            values = input.values;
        }

        public MatrixBase(float[][] input)
        {
            values = input;
        }


        #endregion

        #region bullshit
        /*
         for (int r = 0; r < size; r++) {
            for (int c = r; c < size; c++) {
                if (r == c) {
                    wMatrix.insertInto(r, c, 1);
                    dMatrix.insertInto(r, c, 0);
                } else if (getValue(r, c) > 0) {
                    wMatrix.insertInto(r, c, 1);
                    wMatrix.insertInto(c, r, 1);
                    dMatrix.insertInto(r, c, 1);
                    dMatrix.insertInto(c, r, 1);
                } else if (getValue(r, c) == 0) {
                    dMatrix.insertInto(r, c, -1);
                    dMatrix.insertInto(c, r, -1);
                    if (pMatrix[r][c] > 0 && dMatrix.getValue(r, c) == 0) {
                        dMatrix.insertInto(r, c, recCounter);
                        dMatrix.insertInto(c, r, recCounter);
                    }
                }
            }
        }
         */
        #endregion

        #region Operators

        public static MatrixBase operator +(MatrixBase a, MatrixBase b)
        {
            var size = a.values.Length;

            var result = new MatrixBase(size);

            for (var i = 0; i < size * size; i++)
            {
                var x = i % size;
                var y = i / size;

                result.SetValue(x, y, a.values[x][y] + b.values[x][y]);
            }
            return result;
        }

        public static MatrixBase operator -(MatrixBase a, MatrixBase b)
        {
            var size = a.values.Length;

            var result = new MatrixBase(size);

            for (var i = 0; i < size * size; i++)
            {
                var x = i % size;
                var y = i / size;

                result.SetValue(x, y, a.values[x][y] - b.values[x][y]);
            }
            return result;
        }


        public static MatrixBase operator *(MatrixBase a, MatrixBase b) => Multiply(a, b);

        public static MatrixBase operator /(MatrixBase a, MatrixBase b) => Multiply(a, b, true);


        public static MatrixBase operator !(MatrixBase input)
        {
            var res = new MatrixBase(input.Size);

            for (int i = 0; i < input.Size * input.Size; i++)
            {
                var x = i % input.Size;
                var y = i / input.Size;

                res.values[x][y] = input.values[x][y] * -1;
            }

            return res;
        }

        #endregion

        #region public Methods


        public MatrixBase Power(int power)
        {
            var res = new MatrixBase(this);

            for (int i = 0; i < power; i++)
            {
                res *= this;
            }
            return res;
        }

        #endregion



        #region private Methods
        private static MatrixBase Multiply(MatrixBase a, MatrixBase b, bool invertB = false)
        {
            var size = a.values.Length;
            var result = new MatrixBase(size);

            for (var i = 0; i < size * size; i++)
            {
                var row = i % size;
                var column = i / size;
                var value = 0f;

                for (var inner = 0; inner < size; inner++)
                {
                    value += a.values[row][inner] * b.values[inner][column] * (invertB ? -1f : 1f);
                }

                result.SetValue(row, column, value);
            }
            return result;
        }
        #endregion

    }

}
