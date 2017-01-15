using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{
    public class RoomState:MarshalByRefObject
    {
        public SingleSeatState[,] seats;

        public void Init(int rows,int cols)
        {
            seats = new SingleSeatState[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    seats[i,j]=new SingleSeatState();
                    seats[i, j].isAvailable = true;
                }
            }
        }
        
        public bool setSeats(string ownerName,int row,int col,Color color)
        {
            lock(typeof(RoomState))
            {
                if (!seats[row, col].isAvailable)
                    return false;

                seats[row, col].SetOwner(ownerName,color);
                return true;
            }
        }
        public bool getTurn()
        {
            return seats[0, 0].Turn;
        }

        public void setTurn()
        {
            seats[0, 0].setTurn();
        }
        
        
        public bool RemoveSeats(int row, int col,string ownerName)
        {
            lock (typeof(RoomState))
            {
                if (!seats[row, col].isAvailable && ownerName == seats[row, col].OwnerName)
                {
                        seats[row, col].RemoveOwner();
                        return true;
                }

                else return false;
            }
        }

        public SingleSeatState[,] GetAllSeats()
        {
            return seats;
        }


        public string getSeatOwner(int row,int col)
        {
            lock (typeof(RoomState))
            {
                if (!seats[row, col].isAvailable)
                    return seats[row, col].OwnerName;
                else
                    return string.Empty;
            }
        }
        public Color getSeatOwnerColor(int row, int col)
        {
            lock (typeof(RoomState))
            {
                if (!seats[row, col].isAvailable)
                    return seats[row, col].OwnerColor;
                else
                    return Color.Black;
            }
        }
    }
}
