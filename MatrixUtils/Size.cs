using System;
using Microsoft.VisualBasic.CompilerServices;

namespace MatrixUtils
{
    public struct Size : IEquatable<Size>, IComparable<Size>
    {
        public int Width { get; }
        public int Height { get; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }
        
        public bool Equals(Size other)
        {
            return Height == other.Height && Width == other.Width;
        }
        public override bool Equals(object obj)
        {
            if (obj is Size size)
                return Equals(size);
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Width, Height);
        }

        public int CompareTo(Size other)
        {
            if (Height > other.Height && Width > other.Width) return 1;
            return Equals(other) ? 0 : -1;
        }

        #region Comparision Operators

        public static bool operator ==(Size left, Size right) => left.Equals(right);
        public static bool operator !=(Size left, Size right) => !(left == right);
        public static bool operator <(Size left, Size right) => left.CompareTo(right) < 0;
        public static bool operator <=(Size left, Size right) => left.CompareTo(right) <= 0;
        public static bool operator >(Size left, Size right) => left.CompareTo(right) > 0;
        public static bool operator >=(Size left, Size right) => left.CompareTo(right) >= 0;

        #endregion

        #region Operations
        
        public static Size operator+(Size size, int value) => new (size.Width + value, size.Height + value);
        public static Size operator-(Size size, int value) => new (size.Width - value, size.Height - value);
        public static Size operator*(Size size, int value) => new (size.Width * value, size.Height * value);
        public static Size operator/(Size size, int value) => new (size.Width / value, size.Height / value);


        public static Size operator +(Size a, Size b) => new (a.Width + b.Width, a.Height + b.Height);
        public static Size operator -(Size a, Size b) => new (a.Width - b.Width, a.Height - b.Height);
        public static Size operator *(Size a, Size b) => new (a.Width * b.Width, a.Height * b.Height);
        public static Size operator /(Size a, Size b) => new (a.Width / b.Width, a.Height / b.Height);


        #endregion

    }
}