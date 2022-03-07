using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixUtils.Utils
{
    public static class ParallelUtils
    {
        public static void For2D(int fromInclusive, int toExclusive, int ColumnCount, Index2DIterationDelegate action) =>
            Parallel.For(fromInclusive, toExclusive, i =>
            {
                var column = i % ColumnCount;
                var row = i / ColumnCount;
                action(row, column);
            });
    }
}
