using System;
using MatrixUtils;
using Xunit;

namespace MatrizenTest
{
    public class UnitTest1
    {
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

            Assert.Equal(controlMatrix.Values,res.Values);

        }
    }
}
