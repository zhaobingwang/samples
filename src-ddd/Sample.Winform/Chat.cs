using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.Winform
{
    public partial class Chat : Form
    {
        HubConnection connection;
        public Chat()
        {
            InitializeComponent();

            connection = new HubConnection("http://localhost:5002/ChatHub");
            connection.Closed += Connection_Closed;
        }

        private async Task Connection_Closed()
        {
            await connection.Start();
        }

        private void Chat_Load(object sender, EventArgs e)
        {

        }
    }
}
