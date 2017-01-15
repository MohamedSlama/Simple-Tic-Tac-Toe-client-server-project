using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{
    public class SingleSeatState:MarshalByRefObject
    {
        public string OwnerName { get; set; }
        public Color OwnerColor { get; set; }
        public bool isAvailable { get; set; }
        public bool Turn {get; set;}

        public void SetOwner(string ownerName,Color color)
        {
            OwnerName = ownerName;
            OwnerColor = color;
            isAvailable = false;
            
        }
        public void RemoveOwner()
        {
            OwnerName = "";
            OwnerColor = Color.White;
            isAvailable = true;
        }
        public void setTurn()
        {
            Turn = !Turn;
        }

    }
}
