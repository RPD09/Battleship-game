using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Player2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress IP = host.AddressList[0];
                IPEndPoint EndPoint = new IPEndPoint(IP, 11000);

                Socket Cliente = new Socket(IP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    Cliente.Connect(EndPoint);
                    labelCliente.Text = "Conectado ao jogo: " + Cliente.RemoteEndPoint.ToString();
                    this.Close();
                    Jogo jogo = new Jogo();
                    jogo.Show();
                    Cliente.Shutdown(SocketShutdown.Both);
                    Cliente.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
