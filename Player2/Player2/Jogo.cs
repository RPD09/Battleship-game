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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Player2
{
    public partial class Jogo : KryptonForm
    {
        TcpClient tcpClient = new TcpClient("127.0.0.1", 1234);
        public Jogo()
        {
            InitializeComponent();
            ButtonClicado();

            try
            {
                Read(tcpClient);
                KryptonMessageBox.Show("Conectado ao servidor como " + id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static string id;
        private void Jogo_Load(object sender, EventArgs e)
        {
            this.Text = id;
            comboBoxEscolha.Items[0] = W1.Text;
            comboBoxEscolha.Items[1] = W2.Text;
            comboBoxEscolha.Items[2] = W3.Text;
            comboBoxEscolha.Items[3] = W4.Text;
            comboBoxEscolha.Items[4] = X1.Text;
            comboBoxEscolha.Items[5] = X2.Text;
            comboBoxEscolha.Items[6] = X3.Text;
            comboBoxEscolha.Items[7] = X4.Text;
            comboBoxEscolha.Items[8] = Y1.Text;
            comboBoxEscolha.Items[9] = Y2.Text;
            comboBoxEscolha.Items[10] = Y3.Text;
            comboBoxEscolha.Items[11] = Y4.Text;
            comboBoxEscolha.Items[12] = Z1.Text;
            comboBoxEscolha.Items[13] = Z2.Text;
            comboBoxEscolha.Items[14] = Z3.Text;
            comboBoxEscolha.Items[15] = Z4.Text;

        }

        static void Read(object obj)
        {
            TcpClient tcpClient = (TcpClient)obj;
            StreamReader sReader = new StreamReader(tcpClient.GetStream());

            try
            {
                string message = sReader.ReadLine();
                if (message == "Servidor cheio!")
                {
                    KryptonMessageBox.Show("Erro, servidor cheio!");
                }

                if (message.Substring(0, 4) == "OLA ")
                {
                    id = message.Substring(9, 9);
                }

            }
            catch (Exception e)
            {
                KryptonMessageBox.Show(e.Message);
            }
        }

        int jogadas = 0;
        int vidas = 3;
        int barcos = 0;
        string botaoTexto;

        List<KryptonButton> botoes = new List<KryptonButton>();

        private void buttonAtacar_Click(object sender, EventArgs e)
        {
            Atacar();
            Atacado();
        }

        private void ButtonClicado()
        {
            var buttons = PanelButtonsCHK.Controls.OfType<KryptonButton>();

            foreach (var button in buttons)
            {
                button.Click += PosicionarBarco;
            }

        }

        private void PosicionarBarco(object sender, EventArgs args)
        {
            var button = sender as KryptonButton;
            if (barcos < 3)
            {
                button.StateCommon.Back.ImageStyle = PaletteImageStyle.Stretch;
                button.StateCommon.Back.Image = Properties.Resources.BattleShip;
                botoes.Add(button);
            }
            else if (barcos == 3)
            {
                KryptonMessageBox.Show("Já posicionou todos os barcos disponiveis {3}");
            }
            barcos++;
        }

        private void Atacar()
        {
            if (jogadas < 3)
            {
                if (comboBoxEscolha.SelectedIndex != -1)
                {
                    try
                    {
                        StreamWriter sWriter = new StreamWriter(tcpClient.GetStream());
                        string jogada = comboBoxEscolha.SelectedItem.ToString();
                        if (id != "")
                        {
                            sWriter.WriteLine(id + ": " + jogada);
                        }
                        else
                        {
                            sWriter.WriteLine(jogada);
                        }
                        sWriter.Flush();
                        KryptonMessageBox.Show("Atacou o inimigo na posição: " + comboBoxEscolha.SelectedItem.ToString());
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                    jogadas++;
                }
                else
                {
                    KryptonMessageBox.Show("Selecione um valor da combobox para atacar");
                }
            }
            else if (jogadas > 3)
            {
                KryptonMessageBox.Show("Já usou todos os ataques disponiveis {3} ");
            }
        }

        private void Atacado()
        {
            var button = PanelButtonsCHK.Controls.OfType<KryptonButton>();

            StreamReader reader = new StreamReader(tcpClient.GetStream());
            StreamWriter sWriter = new StreamWriter(tcpClient.GetStream());

            string resposta = reader.ReadLine();
            string jogada;

            foreach (var buttons in button)
            {
                if (buttons.StateCommon.Back.Image != null)
                {
                    if(resposta == "JOGADOR 1: " + buttons.Text)
                    {
                        if (vidas > 1)
                        {
                            buttons.StateCommon.Back.ImageStyle = PaletteImageStyle.Stretch;
                            buttons.StateCommon.Back.Image = Properties.Resources.fogo;
                            jogada = "O Jogador " + id + " foi atingido na posição " + buttons.Text + " e está agora com " + vidas + " vidas!";
                            botaoTexto = buttons.Text;
                            vidas--;
                        }
                        else
                        {
                            KryptonMessageBox.Show("Não tem mais barcos");
                        }
                    }
                }
            }
        }
    }
}
