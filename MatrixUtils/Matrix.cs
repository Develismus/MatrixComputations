using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixUtils
{
    public struct Matrix
    {
        #region Properties

        private float[][] _components;
        public float[][] Values => _components;
        public int Size => Rows * Columns;
        public int Rows => _components.Length;
        public int Columns => _components[0].Length;

        public float[] this[int index] => _components[index];

        #endregion

        #region Constructor

        public Matrix(int size)
        {
            _components = new float[size][];
            for (int i = 0; i < size; i++)
                _components[i] = new float[size];
        }

        public Matrix(int rows, int columns)
        {
            _components = new float[rows][];
            for (int i = 0;i < rows;i++)
                _components[i] = new float[columns];
        }

        public Matrix(Matrix matrix)
        {
            _components = matrix._components;
        }

        public Matrix( float[][] values)
        {
            _components = values;
        }

        public Matrix(params Vector[] vectors)
        {
            _components =  Array.ConvertAll<Vector,float[]>(vectors,input => input);
        }

        public Matrix(IEnumerable<float[]> values)
        {
            _components = values.ToArray();
        }

        #endregion

        #region Operators

        #region Implicit Conversions

        public static implicit operator float[][](Matrix matrix) => matrix._components;
        public static implicit operator Matrix(float[][] components) => new (components);

        #endregion


        #region Scalar Operators

        public static Matrix operator +(Matrix a, float s) => a.Foreach(comp => comp + s);
        
        public static Matrix operator -(Matrix a, float s) => a.Foreach(comp => comp - s);

        public static Matrix operator *(Matrix a, float s) => a.Foreach(comp => comp * s);
        
        public static Matrix operator /(Matrix a, float s)=> a.Foreach(comp => comp / s);

        #endregion


        #region Matrix Operations

        public static Matrix operator +(Matrix a, Matrix b) =>
            a.CheckSize(b).Foreach((row, col, value) => value + b[row][col]);

        public static Matrix operator -(Matrix a, Matrix b) =>
            a.CheckSize(b).Foreach((row, col, value) => value - b[row][col]);

        #endregion




        #endregion


        #region Public Methods




        #endregion

        #region private Method

        private Matrix Foreach(Indexed2DComponentFunction componentAction)
        {
            var act = _components;
            var result = new Matrix(Rows,Columns);

            Parallel.For(0, result.Size, i =>
            {
                int row = i % result.Columns;
                int column = i / result.Columns; 
                result[row][column] = componentAction(row,column,act[row][column]);
            });
            return result;
        }

        private Matrix Foreach(ComponentFunction componentAction)
        {
            var matrix = this;

            Parallel.For(0, matrix.Size, i =>
            {
                int row = i % matrix.Columns;
                int column = i / matrix.Columns;
                matrix[row][column] = componentAction(matrix[row][column]);
            });

            return matrix;
        }


        private Matrix CheckSize(Matrix other)
        {
            if (Rows != other.Rows || Columns != other.Columns)
                throw new ArgumentException(
                    $"Both matrices need to be of the same Size!: this.[{Columns}:{Rows}]  other.[{other.Columns}:{other.Rows}]");
            return this;
        }

        #endregion
    }
}