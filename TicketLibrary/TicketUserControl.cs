using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketLibrary
{
    public partial class TicketUserControl : UserControl
    {
        public TicketUserControl()
        {
            InitializeComponent();
        }

        Label[,] seatsLbl = null;

        public void DrawTable(int rows,int cols)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = rows;
            tableLayoutPanel1.ColumnCount = cols;

            seatsLbl = new Label[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    seatsLbl[i, j] = new Label();
                    seatsLbl[i, j].AutoSize = false;
                    seatsLbl[i, j].Width = 25;
                    seatsLbl[i, j].Height = 25;

                    seatsLbl[i, j].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                    seatsLbl[i, j].Tag = new CellLocation() { row=i,col=j};
                    tableLayoutPanel1.Controls.Add(seatsLbl[i, j]);
                    
                }
            }
            
            tableLayoutPanel1.RowStyles.Clear();

            for (int i = 0; i < rows; i++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            tableLayoutPanel1.ColumnStyles.Clear();

            for (int i = 0; i < cols; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }
        }

    }
}
