using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixUtils;
using Xunit;
using Xunit.Abstractions;

namespace MatrizenTest
{
    public class MatrixScalarTests
    {
        private readonly ITestOutputHelper _output;


        public MatrixScalarTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ScalarAddition()
        {
            var testMatrix = new Matrix(4, new Vector(
                0, 1, 0, 0, 
                1, 0, 1, 0, 
                0, 1, 0, 0, 
                0, 0, 0, 0));


            var controlMatrix = new Matrix(4, new Vector(
                9, 10, 9, 9,
                10, 9, 10, 9,
                9, 10, 9, 9,
                9, 9, 9, 9));

            testMatrix += 9f;

            Assert.Equal(controlMatrix, testMatrix);

        }

        [Fact]
        public void ScalarSubtraction()
        {
            var controlMatrix = new Matrix(4, new Vector(
                0, 1, 0, 0,
                1, 0, 1, 0,
                0, 1, 0, 0,
                0, 0, 0, 0));


            var testMatrix = new Matrix(4, new Vector(
                9, 10, 9, 9,
                10, 9, 10, 9,
                9, 10, 9, 9,
                9, 9, 9, 9));

            testMatrix -= 9f;

            Assert.Equal(controlMatrix, testMatrix);

        }

        [Fact]
        public void ScalarMultiplication()
        {
            var controlMatrix = new Matrix(4, new Vector(
                0, 2, 0, 0,
                2, 0, 2, 0,
                0, 2, 0, 0,
                0, 0, 0, 0));

            var testMatrix = new Matrix(4, new Vector(
                0, 1, 0, 0,
                1, 0, 1, 0,
                0, 1, 0, 0,
                0, 0, 0, 0));

            testMatrix *= 2f;

            Assert.Equal(controlMatrix, testMatrix);

        }

        [Fact]
        public void ScalarDivision()
        {
            var controlMatrix = new Matrix(4, new Vector(
                0, 2, 0, 0,
                2, 0, 2, 0,
                0, 2, 0, 0,
                0, 0, 0, 0));

            var testMatrix = new Matrix(4, new Vector(
                0, 10, 0, 0,
                10, 0, 10, 0,
                0, 10, 0, 0,
                0, 0, 0, 0));

            testMatrix /= 5f;

            Assert.Equal(controlMatrix, testMatrix);

        }

        [Fact]
        public void Multiply4x4()
        {
            var testMatrix = new Matrix(4, new Vector(
                0, 1, 0, 0,
                1, 0, 1, 0,
                0, 1, 0, 0,
                0, 0, 0, 0));

            var controlMatrix = new Matrix(4, new Vector(
                1, 0, 1, 0,
                0, 2, 0, 0,
                1, 0, 1, 0,
                0, 0, 0, 0));

            var controlMatrix2 = new Matrix(4, new Vector(
                2, 0, 2, 0,
                0, 4, 0, 0,
                2, 0, 2, 0,
                0, 0, 0, 0));

            Assert.Equal(controlMatrix, (testMatrix * testMatrix));
            Assert.Equal(controlMatrix2, (testMatrix * testMatrix)* (testMatrix * testMatrix));
        }


        [Fact]
        public void Reduce()
        {
            var testMatrix = new Matrix(4,new Vector(
                    2, 3, 4, 5,
                6, 7, 8, 9,
                10,11,12,13,
                14,15,16,17));

            var controlMatrix = new Matrix(3,new Vector(
                    2,4,5,
                10,12,13,
                14,16,17));

            var controlMatrix2 = new Matrix(3, new Vector(
                2, 4, 5,
                10, 12, 13,
                14, 16, 17));


            Assert.Equal(controlMatrix2, testMatrix.Reduce(1,1));

        }

        [Fact]
        public void Determine3by3()
        {
            var testMatrix = new Matrix(3, new Vector(
                13, 16, 29,
                4, 12, 50,
                3, 13, 21));

            Assert.Equal(-3654f, testMatrix.Determine3By3());
        }

        [Fact]
        public void ToVector()
        {
            var Matrix = new Matrix(3, new Vector(
                2, 4, 5,
                10, 12, 13,
                14, 16, 17));

            var Vector = new Vector(2, 4, 5, 10, 12, 13, 14, 16, 17);

            Assert.Equal((float[])Vector, Matrix);

        }

    }
}
