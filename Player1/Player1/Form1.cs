using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Conectar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Jogo jogo = new Jogo();
                jogo.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_instrucoes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instrucoes instrucoes = new Instrucoes();
            instrucoes.Show();
        }
    }
}
