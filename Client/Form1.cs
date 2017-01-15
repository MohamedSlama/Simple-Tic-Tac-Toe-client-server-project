using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicketLibrary;

using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting;

namespace Client
{
    public partial class Form1 : Form
    {
        HttpChannel channel;
        int rows = 3;
        int cols = 3;
        RoomState state;
        
        public Form1()
        {
            InitializeComponent();

            channel = new HttpChannel();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
           if(ConnectBtn.Text.Trim()=="Disconnect")
           {
               //Disconnect
               ChannelServices.UnregisterChannel(channel);

               ConnectBtn.Text = "Connect";
               groupBox1.Text = "Disconnect";
               groupBox1.Enabled = false;
               timer1.Enabled = false;
           }
           else
           {
               //Connect
               ChannelServices.RegisterChannel(channel, false);

               //Get Object of class
               Type share = typeof(RoomState);

               state = (RoomState)Activator.GetObject(share, "http://localhost:50329/CinemaRoom");
               if(state!=null)
               {
                   if (state.seats == null)
                       state.Init(rows, cols);

                   
                   //Draw table
                   ticketUserControl1.DrawTable(rows, cols);
                   ColorizeSeats(state.seats);

                   //Button Click
                   foreach (Label item in ticketUserControl1.tableLayoutPanel1.Controls)
                   {
                       item.Click += new EventHandler(ItemClick);
                   }
                   
                   timer1.Enabled = true;
                   ConnectBtn.Text = "Disconnect";
                   groupBox1.Text = "Connect";
                   groupBox1.Enabled = true;
               }
           }
        }
        string ownerName;

        private void ItemClick(object sender, EventArgs e)
        {
            Label Lab = (Label)sender;
            //if (state.getTurn() == false)
              //  NameTxt.Text = "X";
            //else
              //  NameTxt.Text = "O";

            CellLocation tag = (CellLocation)Lab.Tag;

            if (NameTxt.Text.Trim() == "" || (NameTxt.Text.Trim() != "X" && NameTxt.Text.Trim() != "O"))
            {
                MessageBox.Show("Please, insert name first");
                NameTxt.Focus();
                return;
            }

            if (state.getTurn() == false && NameTxt.Text == "X" || state.getTurn() == true && NameTxt.Text == "O")
            {
                if (state != null)
                {
                    ownerName = NameTxt.Text.Trim();
                    NameTxt.Enabled = false;
                    int row = (int)tag.row;
                    int col = (int)tag.col;

                    Label l = (Label)ticketUserControl1.tableLayoutPanel1.GetControlFromPosition(col, row);

                    if (state.setSeats(NameTxt.Text.Trim(), row, col, GetRandomColor(NameTxt.Text)))
                    {
                        state.setTurn();
                        check();
                    }
                    else
                        MessageBox.Show("Already booked");

                    l.BackColor = state.getSeatOwnerColor(row, col);
                }
            }
            else
            {
                MessageBox.Show("Opponent Move!!");
                return;
            }
        }

        private void ColorizeSeats(SingleSeatState[,] singleSeatState)
        {
            for (int i = 0; i < singleSeatState.GetLength(0); i++)
            {
                for (int j = 0; j < singleSeatState.GetLength(1); j++)
                {
                    Label l = (Label)ticketUserControl1.tableLayoutPanel1.GetControlFromPosition(j, i);
                    if (!singleSeatState[i, j].isAvailable)
                        l.BackColor = state.getSeatOwnerColor(i,j);
                    else
                        l.BackColor = Color.White;

                }
            }
        }

        private List<bool> X;
        private List<bool> O;
        void check()
        {
            X = new List<bool>();
            O = new List<bool>();
            CellLocation tag ;
           foreach (Label item in ticketUserControl1.tableLayoutPanel1.Controls)
           {
               tag = (CellLocation)item.Tag;
               string owner = state.getSeatOwner(tag.row, tag.col);
               if (owner != string.Empty)
               {
                   if (owner == "X")
                   {
                       //X list
                      // X.Add(3 * tag.row + tag.col);
                       //O.Add(0);

                       X.Add(true);
                       O.Add(false);
                   }
                   else if (owner == "O")
                   {
                       //O List

                       //O.Add(3 * tag.row + tag.col);
                       //X.Add(0);
                       O.Add(true);
                       X.Add(false);
                       
                   }
               }
               else
               {
                   X.Add(false);
                   O.Add(false);
               }
           }
           

            //Horizontal
           if (X[0] & X[1] & X[2] == true || X[3] & X[4] & X[5] == true || X[6] & X[7] & X[8] == true)
               MessageBox.Show("X win","Game Over");
           else if (O[0] & O[1] & O[2] == true || O[3] & O[4] & O[5] == true || O[6] & O[7] & O[8] == true)
               MessageBox.Show("O win", "Game Over");

            //Vertical
           else if (X[0] & X[3] & X[6] == true || X[1] & X[4] & X[7] == true || X[2] & X[5] & X[8] == true)
               MessageBox.Show("X win", "Game Over");
           else if (O[0] & O[3] & O[6] == true || O[1] & O[4] & O[7] == true || O[2] & O[5] & O[8] == true)
               MessageBox.Show("O win", "Game Over");

            //Diagonal
           else if (X[0] & X[4] & X[8] == true || X[2] & X[4] & X[6] == true)
               MessageBox.Show("X win", "Game Over");
           else if (O[0] & O[4] & O[8] == true || O[2] & O[4] & O[6] == true)
               MessageBox.Show("O win", "Game Over");

           X = null;
           O = null;
        }

        public Color GetRandomColor(string name)
        {
            if (NameTxt.Text == "X")
                return Color.Red;
            else if (NameTxt.Text == "O")
                return Color.Blue;
            else
                return Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(state!=null)
            {
                SingleSeatState[,] seats = state.GetAllSeats();
                ColorizeSeats(seats);
            }
        }



    }
}
