using System;
using MatrixUtils;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace MatrizenTest
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _output;


        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }




        [Fact]
        public void Test1()
        {
            var testMatrix = new MatrixBase(new []
            {
                new []{0f, 1f, 0f, 0f},
                new []{1f, 0f, 1f, 0f},
                new []{0f, 1f, 0f, 0f},
                new []{0f, 0f, 0f, 0f}
            });

            var controlMatrix = new MatrixBase(new[]
            {
                new []{2f, 0f, 2f, 0f},
                new []{0f, 4f, 0f, 0f},
                new []{2f, 0f, 2f, 0f},
                new []{0f, 0f, 0f, 0f}
            });

            var res = testMatrix.Power(4);

            _output.WriteLine($"{nameof(res)}\n" + res);
            _output.WriteLine($"{nameof(controlMatrix)}\n" + controlMatrix);

            Assert.Equal(controlMatrix.Values,res.Values);
        }

        [Fact]
        public void Multiply2x2()
        {
            var testMatrix = new MatrixBase(new[]
            {
                new []{1f,2f},
                new []{-1f,3f}
            });

            var controlMatrix = new MatrixBase(new[]
            {
                new []{-1f,8f},
                new []{-4f,7f}
            });

            Assert.Equal(controlMatrix.Values, (testMatrix * testMatrix).Values);


        }

        [Fact]
        public void Multiply4x4()
        {
            var testMatrix = new MatrixBase(new[]
            {
                new []{0f, 1f, 0f, 0f},
                new []{1f, 0f, 1f, 0f},
                new []{0f, 1f, 0f, 0f},
                new []{0f, 0f, 0f, 0f}
            });

            var controlMatrix = new MatrixBase(new[]
            {
                new []{1f, 0f, 1f, 0f},
                new []{0f, 2f, 0f, 0f},
                new []{1f, 0f, 1f, 0f},
                new []{0f, 0f, 0f, 0f}
            });

            Assert.Equal(controlMatrix.Values, (testMatrix * testMatrix).Values);
        }
    }
}
