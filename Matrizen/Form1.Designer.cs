namespace Matrizen
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputTable = new System.Windows.Forms.TableLayoutPanel();
            this.potencyMatrix = new System.Windows.Forms.TableLayoutPanel();
            this.DistanceMatrix = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // InputTable
            // 
            this.InputTable.ColumnCount = 2;
            this.InputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.InputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.InputTable.Location = new System.Drawing.Point(144, 12);
            this.InputTable.Name = "InputTable";
            this.InputTable.RowCount = 2;
            this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.InputTable.Size = new System.Drawing.Size(250, 250);
            this.InputTable.TabIndex = 0;
            // 
            // potencyMatrix
            // 
            this.potencyMatrix.ColumnCount = 2;
            this.potencyMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.potencyMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.potencyMatrix.Location = new System.Drawing.Point(144, 317);
            this.potencyMatrix.Name = "potencyMatrix";
            this.potencyMatrix.RowCount = 2;
            this.potencyMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.potencyMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.potencyMatrix.Size = new System.Drawing.Size(250, 250);
            this.potencyMatrix.TabIndex = 1;
            // 
            // DistanceMatrix
            // 
            this.DistanceMatrix.ColumnCount = 2;
            this.DistanceMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DistanceMatrix.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DistanceMatrix.Location = new System.Drawing.Point(439, 317);
            this.DistanceMatrix.Name = "DistanceMatrix";
            this.DistanceMatrix.RowCount = 2;
            this.DistanceMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DistanceMatrix.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DistanceMatrix.Size = new System.Drawing.Size(250, 250);
            this.DistanceMatrix.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Location = new System.Drawing.Point(731, 317);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(250, 250);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 590);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.DistanceMatrix);
            this.Controls.Add(this.potencyMatrix);
            this.Controls.Add(this.InputTable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel InputTable;
        private System.Windows.Forms.TableLayoutPanel potencyMatrix;
        private System.Windows.Forms.TableLayoutPanel DistanceMatrix;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
    }
}
