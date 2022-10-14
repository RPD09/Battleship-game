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
using System.IO;

namespace Player2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_instrucoes_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instrucoes instrucoes = new Instrucoes();
            instrucoes.Show();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {

                this.Hide();
                Jogo jogo = new Jogo();
                jogo.Show();

        }       
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
