using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MatrixUtils;

namespace Matrizen
{
    public partial class MatrixView : UserControl
    {
        private MatrixBase _matrix;

        public MatrixView()
        {
            InitializeComponent();
            _matrix = new MatrixBase(0);
        }

        public MatrixView(MatrixBase matrix) : this()
        {
            _matrix = matrix;
        }

        public void SetMatrix()
        {}

    }
}
