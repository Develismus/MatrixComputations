using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixUtils
{
    public delegate float IndexedComponentFunction(int index, float value);

    public delegate float Indexed2DComponentFunction(int row, int col, float value);

    public delegate float ComponentFunction(float value);

    public delegate bool IndexedEquatableComponentFunction(int row, int col, float value);



    public delegate void Index2DIterationDelegate(int row, int col);

}
