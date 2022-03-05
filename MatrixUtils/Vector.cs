using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MatrixUtils
{
    [Serializable]
    public struct Vector : IEquatable<Vector>
    {
        #region Properties

        private float[] _components;

        public float this[int index]
        {
            get => _components[index];
            set => _components[index] = value;
        }

        public int Dimensions => _components.Length;
        public float SqrMagnitude => _components.AsParallel().Sum(e => e * e);
        public float Magnitude => MathF.Sqrt(SqrMagnitude);

        public Vector Normalized => Normalize();

        #endregion

        #region Constructor

        public Vector(int size)
        {
            _components = new float[size];
        }

        public Vector(params float[] components)
        {
            this._components = components;
        }

        


        #endregion

        #region Operators

        //Implicit Conversation

        public static implicit operator float[](Vector vector) => vector._components;
        public static implicit operator Vector(float[] components) => new Vector(components);

        //Comparision Operators

        public static bool operator ==(Vector a, Vector b) => a.Equals(b);
        public static bool operator !=(Vector a, Vector b) => !(a == b);

        // Scalar Operators
        public static Vector operator +(Vector vector, float s) => vector.Foreach(c => c + s);
        public static Vector operator -(Vector vector, float s) => vector.Foreach(c => c - s);
        public static Vector operator *(Vector vector, float s) => vector.Foreach(c => c * s);
        public static Vector operator /(Vector vector, float s) => vector.Foreach(c => c / s);

        //Vector Operators
        public static Vector operator +(Vector a, Vector b) => 
            a.CheckSize(b).Foreach((index, value) => value + b[index]);
        
        public static Vector operator -(Vector a, Vector b) =>
            a.CheckSize(b).Foreach((index, value) => value - b[index]);
        
        public static Vector operator *(Vector a, Vector b)=>
            a.CheckSize(b).Foreach((index, value) => value * b[index]);

        public static Vector operator /(Vector a, Vector b) =>
            a.CheckSize(b).Foreach((index, value) => value / b[index]);


        #endregion


        #region public Methods

        public Vector Normalize()
        {
            var mag = Magnitude;
            return Foreach(value => value / mag);
        }

        public float Dot(Vector other)
        {
            return (this * other)._components.AsParallel().Sum();
        }

        public override string ToString()
        {
            return "{" + string.Join(" : ", _components.AsParallel().Select(e => e.ToString())) + "}";
        }
        public bool Equals(Vector other)
        {
            return _components.AsParallel().SequenceEqual(other._components.AsParallel());
        }
        public override bool Equals(object obj)
        {
            return obj is Vector && Equals((Vector)obj);
        }
        public override int GetHashCode()
        {
            return _components.GetHashCode();
        }

        #endregion

        #region private Methods

        private Vector Foreach(IndexedComponentFunction componentFunction) => _components.AsParallel().Select((value, index) => componentFunction(index,value)).ToArray();
        private Vector Foreach(ComponentFunction componentFunction) => _components.AsParallel().Select(value => componentFunction(value)).ToArray();
        
        private Vector CheckSize(Vector b)
        {
            if (Dimensions != b.Dimensions)
                throw new ArgumentException("The length of Vectors need to be equal!");
            return this;
        }

        #endregion
    }
}
