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

namespace Player1 {
    public partial class Jogo : KryptonForm {
        TcpClient tcpClient = new TcpClient("127.0.0.1", 1234);
        public Jogo() {
            InitializeComponent();
            ButtonClicado();

            try {
                Read(tcpClient);
                KryptonMessageBox.Show("Conectado ao servidor como " + id);
            } catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }
        public static string id;
        private void Jogo_Load(object sender, EventArgs e) {
            buttonAtacar.Enabled = false;
            timer1.Start();

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

        static void Read(object obj) {
            TcpClient tcpClient = (TcpClient)obj;
            StreamReader sReader = new StreamReader(tcpClient.GetStream());

            try {
                string message = sReader.ReadLine();
                if (message == "Servidor cheio!") {
                    KryptonMessageBox.Show("Erro, servidor cheio!");
                }
                if (message.Substring(0, 4) == "OLA ") {
                    id = message.Substring(9, 9);
                }

            } catch (Exception e) {
                KryptonMessageBox.Show(e.Message);
            }
        }

        int jogadas = 0;
        int vidas = 3;
        int barcos = 0;
        string botaoTexto;

        List<KryptonButton> botoes = new List<KryptonButton>();

        private void buttonAtacar_Click(object sender, EventArgs e) {
            Atacar();
        }

        private void ButtonClicado() {
            var buttons = PanelButtonsCHK.Controls.OfType<KryptonButton>();

            foreach (var button in buttons) {
                button.Click += PosicionarBarco;
            }

        }

        private void PosicionarBarco(object sender, EventArgs args) {
            var button = sender as KryptonButton;
            if (barcos < 3) {
                button.StateCommon.Back.ImageStyle = PaletteImageStyle.Stretch;
                button.StateCommon.Back.Image = Properties.Resources.BattleShip;
                botoes.Add(button);
            }

            barcos++;

            if (barcos == 3) {
                buttonAtacar.Enabled = true;
                KryptonMessageBox.Show("Posicionou todos os barcos disponiveis {3}");
            }
        }


        private HashSet<string> jogadasFeitas = new HashSet<string>();
        private bool minhaVez = true;

        private void Atacar() {
            if (minhaVez) {
                if (jogadas < 3) {
                    if (comboBoxEscolha.SelectedIndex != -1) {
                        string jogada = comboBoxEscolha.SelectedItem.ToString();
                        if (!jogadasFeitas.Contains(jogada)) {
                            try {
                                StreamWriter sWriter = new StreamWriter(tcpClient.GetStream());
                                if (id != "") {
                                    sWriter.WriteLine(id + ": " + jogada);
                                } else {
                                    sWriter.WriteLine(jogada);
                                }
                                sWriter.Flush();
                                KryptonMessageBox.Show("Atacou o inimigo na posição: " + jogada);
                            } catch (Exception ex) { Console.WriteLine(ex.Message); }
                            jogadasFeitas.Add(jogada);
                            jogadas++;
                            minhaVez = false;
                        } else {
                            KryptonMessageBox.Show("Você já atacou essa posição, escolha outra");
                        }
                    } else {
                        KryptonMessageBox.Show("Selecione um valor da combobox para atacar");
                    }
                } else if (jogadas >= 3) {
                    KryptonMessageBox.Show("Já usou todos os ataques disponiveis {3} ");
                }
            } else {
                KryptonMessageBox.Show("Aguarde sua vez de atacar");
            }
        }


        private void Atacado() {
            StreamReader reader = new StreamReader(tcpClient.GetStream());
            StreamWriter sWriter = new StreamWriter(tcpClient.GetStream());

            while (true) {
                try {
                    string resposta = reader.ReadLine();

                    if (resposta == null) {
                        // Conexão fechada pelo server
                        break;
                    }

                    if (resposta.StartsWith("JOGADOR 2: ")) {
                        // O outro player fez um ataque
                        string posicao = resposta.Substring(12);

                        bool acertou = false;

                        foreach (var button in botoes) {
                            if (button.Text.EndsWith(posicao)) {
                                // Caso o player acerte num barco
                                button.StateCommon.Back.ImageStyle = PaletteImageStyle.Stretch;
                                button.StateCommon.Back.Image = Properties.Resources.fogo;
                                botaoTexto = button.Text;
                                vidas--;
                                acertou = true;
                                break;
                            }
                        }

                        if (acertou) {
                            // O player atingiu um dos barcos
                            KryptonMessageBox.Show("O inimigo atacou na posição " + posicao + " e acertou!");
                        } else {
                            // O player falhou os barcos
                            KryptonMessageBox.Show("O inimigo atacou na posição " + posicao + " e errou!");
                        }

                        if (vidas == 0) {
                            // Todos os barcos foram destruídos
                            KryptonMessageBox.Show("Todos os barcos foram destruídos");
                            sWriter.WriteLine("Jogo finalizado - O Player 2 é o vencedor!");
                            sWriter.Flush();
                            break;
                        }
                    }

                } catch (IOException ex) {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            // Fechar a conexão com o server
            tcpClient.Close();
        }


        private async void timer1_Tick(object sender, EventArgs e) {
            await Task.Run(() => Atacado());
        }

    }
}