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
            var testMatrix = new Matrix(new[]
            {
                new []{0f, 1f, 0f, 0f},
                new []{1f, 0f, 1f, 0f},
                new []{0f, 1f, 0f, 0f},
                new []{0f, 0f, 0f, 0f}
            });

            var controlMatrix = new Matrix(new[]
            {
                new []{9f, 10f, 9f, 9f},
                new []{10f, 9f, 10f, 9f},
                new []{9f, 10f, 9f, 9f},
                new []{9f, 9f, 9f, 9f}
            });

            testMatrix += 9f;

            Assert.Equal(controlMatrix.Values, testMatrix.Values);

        }

        [Fact]
        public void ScalarSubtraction()
        {
            var controlMatrix = new Matrix(new[]
            {
                new []{0f, 1f, 0f, 0f},
                new []{1f, 0f, 1f, 0f},
                new []{0f, 1f, 0f, 0f},
                new []{0f, 0f, 0f, 0f}
            });

            var testMatrix = new Matrix(new[]
            {
                new []{9f, 10f, 9f, 9f},
                new []{10f, 9f, 10f, 9f},
                new []{9f, 10f, 9f, 9f},
                new []{9f, 9f, 9f, 9f}
            });

            testMatrix -= 9f;

            Assert.Equal(controlMatrix.Values, testMatrix.Values);

        }

        [Fact]
        public void ScalarMultiplication()
        {
            var controlMatrix = new Matrix(new[]
            {
                new []{0f, 2f, 0f, 0f},
                new []{2f, 0f, 2f, 0f},
                new []{0f, 2f, 0f, 0f},
                new []{0f, 0f, 0f, 0f}
            });

            var testMatrix = new Matrix(new[]
            {
                new []{0f, 1f, 0f, 0f},
                new []{1f, 0f, 1f, 0f},
                new []{0f, 1f, 0f, 0f},
                new []{0f, 0f, 0f, 0f}
            });

            testMatrix *= 2f;

            Assert.Equal(controlMatrix.Values, testMatrix.Values);

        }

        [Fact]
        public void ScalarDivision()
        {
            var controlMatrix = new Matrix(new[]
            {
                new []{0f, 5f, 0f, 0f},
                new []{5f, 0f, 5f, 0f},
                new []{0f, 5f, 0f, 0f},
                new []{0f, 0f, 0f, 0f}
            });

            var testMatrix = new Matrix(new[]
            {
                new []{0f, 10f, 0f, 0f},
                new []{10f, 0f, 10f, 0f},
                new []{0f, 10f, 0f, 0f},
                new []{0f, 0f, 0f, 0f}
            });

            testMatrix /= 2f;

            Assert.Equal(controlMatrix.Values, testMatrix.Values);

        }

    }
}
