using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress IP = host.AddressList[0];
            IPEndPoint EndPoint = new IPEndPoint(IP, 11000);

            try
            {
                Socket listener = new Socket(IP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(EndPoint);
                listener.Listen(100);

                Socket handler = listener.Accept();


                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Hide();
            Jogo jogo = new Jogo();
            jogo.Show();
        }
    }
}
