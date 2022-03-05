using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixUtils;
using Xunit;
using Xunit.Abstractions;

namespace MatrizenTest
{
    public class VectorTests
    {

        private readonly ITestOutputHelper _output;


        public VectorTests(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public void ScalarOperations()
        {
            var testVec = new Vector(2, 2, 2, 2);

            Assert.Equal(new Vector(4,4,4,4), testVec + 2);
            Assert.Equal(new Vector(4,4,4,4), testVec * 2);
            Assert.Equal(new Vector(1,1,1,1), testVec / 2);
            Assert.Equal(new Vector(0, 0, 0, 0), testVec - 2);
        }

        [Fact]
        public void VectorOperations()
        {
            var invector =    new Vector(2,3,2,5);
            var otherVector = new Vector(3,4,3,4);

            Assert.Equal(new Vector(5,7,5,9), invector  + otherVector);
            Assert.Equal(new Vector(-1,-1,-1,1), invector  - otherVector);
            Assert.Equal(new Vector(6,12,6,20), invector  * otherVector);
            Assert.Equal(new Vector(2/3f,3/4f,2/3f,5/4f), invector  / otherVector);
        }

        [Fact]
        public void Comparison()
        {
            var invector = new Vector(2, 3, 2, 5);
            var otherVector = new Vector(3, 4, 3, 4);

            Assert.True(invector != otherVector);
            Assert.False(invector == otherVector);
            Assert.True(new Vector(2,2,2,2) == new Vector(4-2,2,8-6,2));

        }

        [Fact]
        public void Functions()
        {
            var invector = new Vector(2, 2, 2, 2);

            var otherVector = new Vector(3, 4, 3, 4);

            //Normalization
            Assert.Equal(new Vector(.5f,.5f,.5f,.5f),invector.Normalized);

            //Magnitude
            Assert.Equal(4,invector.Magnitude);

            //SquareMagnitude
            Assert.Equal(16, invector.SqrMagnitude);

            var dot = 2 * 3 + 2 * 4 + 2 * 3 + 2 * 4;

            Assert.Equal(dot, invector.Dot(otherVector));

        }


        [Fact]
        public void DifferentSizeException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Vector c = new Vector(2, 2, 2) + new Vector(4, 4, 4, 4);
            });
        }
    }
}
