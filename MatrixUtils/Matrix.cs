using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MatrixUtils.Utils;
using Microsoft.VisualBasic.CompilerServices;

namespace MatrixUtils
{
    public struct Matrix : IEquatable<Matrix>
    {
        #region Properties

        private float[] _components;
        public int Size => _components.Length;
        public int Rows => Size / Columns;
        public int Columns { get; }

        public bool IsSquared => Rows == Columns;

        public float this[int row,int column] 
        {
            get => _components[row * Columns + column];
            set => _components[row * Columns + column] = value;
        }

        #endregion

        #region Constructor

        public Matrix(int rows, int columns)
        {
            _components = new float[rows * columns];
            Columns = columns;
        }

        public Matrix(int size) : this(size,size)
        {
        }

        public Matrix(Matrix matrix)
        {
            _components = matrix._components;
            Columns = matrix.Columns;
        }

        public Matrix(float[,] values)
        {
            var arr = new float[values.Length];
            ParallelUtils.For2D(0,values.Length,values.GetLength(1), (row, col) =>
                arr[row * values.GetLength(1) + col] = values[row,col]);
            _components = arr;
            Columns = values.GetLength(1);
        }

        public Matrix(int columns, Vector vector) : this(columns, (float[])vector)
        {
        }

        public Matrix(int columns,params float[] values)
        {
            if (values.Length % columns != 0)
                throw new ArgumentOutOfRangeException(
                    "the dimensions of the vector need to be a multible of parameter columns! \n" +
                    $"Columns : {columns} => values.Length : {values.Length}");

            _components = values;
            Columns = columns;
        }

        #endregion

        #region Operators

        #region Implicit Conversions

        public static implicit operator float[](Matrix matrix) => matrix._components;

        #endregion


        #region Scalar Operators

        public static Matrix operator +(Matrix a, float s) => a.Foreach(comp => comp + s);
        
        public static Matrix operator -(Matrix a, float s) => a.Foreach(comp => comp - s);

        public static Matrix operator *(Matrix a, float s) => a.Foreach(comp => comp * s);
        
        public static Matrix operator /(Matrix a, float s)=> a.Foreach(comp => comp / s);

        #endregion


        #region Matrix Operations

        public static Matrix operator +(Matrix a, Matrix b) =>
            a.CheckSize(b).Foreach((row, col, value) => value + b[row,col]);

        public static Matrix operator -(Matrix a, Matrix b) =>
            a.CheckSize(b).Foreach((row, col, value) => value - b[row,col]);

        public static Matrix operator *(Matrix a, Matrix b)
        {
            a.CheckColumnToRow(b);
            var res = new Matrix(a.Rows, b.Columns);
            return res.Foreach((row, col, value) =>
            {
                for (int i = 0; i < a.Columns; i++)
                    value += a[row,i] * b[i,col];
                return value;
            });
        }

        public static Matrix operator ~(Matrix matrix)
        {
            return new Matrix();
        }


        #endregion




        #endregion


        #region Public Methods

        public float Determine()
        {
            if (!IsSquared) new ArgumentException("The Matrix need to be Squared!");

        }


        public Matrix Reduce(int row, int column)
        {
            var act = this;
            var result = new Matrix(Rows -1, Columns -1);
            return result.Foreach((col, r,_) => 
                act[r >= row ? r + 1 : r,col >= column ? col + 1 : col]);
        }



        #region object overrides & Equatable Implementation
        public bool Equals(Matrix other)
        {
            if (Rows != other.Rows || Columns != other.Columns) return false;
            return _components.AsParallel().SequenceEqual(other._components.AsParallel());
        }

        public override bool Equals(object? obj)
        {
            if (obj is Matrix matrix) return Equals(matrix);
            if (obj is float[][] components) return Equals(components);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }

        public override string ToString()
        {
            var s = new StringBuilder("\n");
            for (int i = 0; i < Rows; i++)
                s.AppendLine(string.Join(" : ", _components.Skip(i * Columns).Take(Columns)));
            return s.ToString();
        } 
        #endregion

        #endregion

        #region private Method

        private Matrix Foreach(Indexed2DComponentFunction componentAction)
        {
            var columns = Columns;
            return new Matrix(columns, _components.AsParallel().Select((f, i) =>
                    componentAction(i % columns, i / columns, f)).ToArray());
        }

        private Matrix Foreach(ComponentFunction componentAction) => new (Columns,
            _components.AsParallel().Select(f => componentAction(f)).ToArray());

        public float Determine2By2()
        {
            if (!IsSquared || Columns != 2)
                throw new ArithmeticException("the matrix need to be a 2x2!");
            return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];
        }

        public float Determine3By3()
        {
            if (!IsSquared || Columns != 3)
                throw new ArithmeticException("the matrix need to be a 3x3!");
            return this[0, 0] * this[1, 1] * this[2, 2] +
                   this[0, 1] * this[1, 2] * this[2, 0] +
                   this[0, 2] * this[1, 0] * this[2, 1] -
                   
                   this[0, 2] * this[1, 1] * this[2,0] -
                   this[0, 1] * this[1, 0] * this[2,2] -
                   this[0, 0] * this[1, 2] * this[2,1];
        }

        private Matrix CheckColumnToRow(Matrix other)
        {
            if (!CompareColumnToRowCount(this,other))
                throw new ArgumentException(
                    $"Columns of A need to be equal to rows of B: a.[{Columns}:{Rows}]  b.[{other.Columns}:{other.Rows}]");
            return this;
        }

        private Matrix CheckSize(Matrix other)
        {
            if (!CompareSize(this,other))
                throw new ArgumentException(
                    $"Both matrices need to be of the same Size!: a.[{Columns}:{Rows}]  b.[{other.Columns}:{other.Rows}]");
            return this;
        }
        private static bool CompareColumnToRowCount(Matrix a, Matrix b) => a.Columns == b.Rows;
        private static bool CompareSize(Matrix a,Matrix b) => a.Rows == b.Rows && a.Columns == b.Columns;

        #endregion
    }
}