using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

using TicketLibrary;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            StartServer();
        }

        void StartServer()
        {
            HttpChannel channel = new HttpChannel(50329);

            ChannelServices.RegisterChannel(channel, false);

            Type shared = typeof(RoomState);

            RemotingConfiguration.RegisterWellKnownServiceType(shared, 
                "CinemaRoom", WellKnownObjectMode.Singleton);
        }
    }
}
