using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;

namespace Servidor {
    class Program {
        private static TcpListener tcpListener;
        private static List<TcpClient> tcpClientes = new List<TcpClient>();
        private static bool player1Turn = true;

        static void Main(string[] args) {
            tcpListener = new TcpListener(IPAddress.Any, 1234);
            tcpListener.Start();

            Console.WriteLine("Servidor Batalha Naval inicializado :)");

            while (true) {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                tcpClientes.Add(tcpClient);
                if (tcpClientes.Count == 1) {
                    Console.WriteLine(tcpClientes.Count + " cliente conectado");
                } else if (tcpClientes.Count > 1) {
                    Console.WriteLine(tcpClientes.Count + " clientes conectados");
                }
                Thread thread = new Thread(ClientListener);
                thread.Start(tcpClient);
            }
        }

        public static void ClientListener(object obj) {
            if (tcpClientes.Count > 0 && tcpClientes.Count < 3) {
                StreamWriter sWriter = new StreamWriter(tcpClientes[tcpClientes.Count - 1].GetStream());
                sWriter.WriteLine("OLA ÉS O JOGADOR " + tcpClientes.Count.ToString());
                sWriter.Flush();
                if (tcpClientes.Count == 2) {
                    BroadCast("1");
                }
            } else if (tcpClientes.Count >= 3) {
                StreamWriter sWriter = new StreamWriter(tcpClientes[tcpClientes.Count - 1].GetStream());
                sWriter.WriteLine("Servidor cheio!");
                sWriter.Flush();
            }
            TcpClient tcpClient = (TcpClient)obj;
            try {
                StreamReader reader = new StreamReader(tcpClient.GetStream());
                while (true) {
                    string message = reader.ReadLine();

                    Console.WriteLine(message);
                    BroadCast(message);

                    if (message.StartsWith("Player1") && player1Turn) {
                        // Vez player1
                        player1Turn = false;
                        BroadCast("Player2's turn");
                    } else if (message.StartsWith("Player2") && !player1Turn) {
                        // Vez player2
                        player1Turn = true;
                        BroadCast("Player1's turn");
                    }
                }
            } catch (InvalidOperationException) {
            }
        }
        public static void BroadCast(string msg) {
            foreach (TcpClient client in tcpClientes) {
                StreamWriter sWriter = new StreamWriter(client.GetStream());
                sWriter.WriteLine(msg);
                sWriter.Flush();
            }
        }
    }
}

