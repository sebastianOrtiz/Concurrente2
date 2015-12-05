using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PACMANv3.pkgVista;

namespace PACMANv3.pkgModelo {

    class Servidor {
        private TcpListener server;
        private Thread th;
        private int cantTotalJugadores;
        private bool conectado;
        private Form1 vista;

        public static BinaryFormatter serializer = new BinaryFormatter();
        private static List<UsuarioServidor> usuarios = new List<UsuarioServidor>();

        public Servidor(int cantJugadores, string ipAddress, Form1 vista) {
            this.vista = vista;
            this.cantTotalJugadores = cantJugadores;
            this.server = new TcpListener(IPAddress.Parse(ipAddress), 1339);
            Console.WriteLine(this.server);
            //this.server = new TcpListener(IPAddress.Loopback, 1339);
        }

        private void atender() {
            int conectados = 0;

            conectados = usuarios.Count;
            while (this.conectado && conectados < this.cantTotalJugadores) {
                TcpClient client = server.AcceptTcpClient();

                UsuarioServidor usv = new UsuarioServidor(usuarios.Count + 1, client);
                usv.enviarId();
                usuarios.Add(usv);

                new Thread(usv.atender).Start();
                conectados = usuarios.Count;
            }
        }

        private void cuentaRegresiva() {
            int espera = 5;
            Estado m;
            while (espera > 0) {
                m = new Estado();
                m.TEspera = espera;
                enviarTodos(m);
                Console.WriteLine(m.TEspera);
                Thread.Sleep(1000);
                --espera;
            }
        }

        public static void enviarTodos(Estado o) {
            //Console.WriteLine("usuario: {1}, mensaje: {0}", o.Texto, o.Nombre);
            if (o.Direccion > 0) {
                foreach (UsuarioServidor usv in usuarios) {
                    Console.WriteLine("usuario {0}: Envia direccion {1}", usv.Id, o.Direccion);
                }
            } else if (o.Direccion == 0) {
                foreach (UsuarioServidor usv in usuarios) {
                    if (usv.Id != o.Id) {
                        Console.WriteLine("usuario {0}: {1}", usv.Id, o.Texto);
                        usv.enviar(o);
                    }
                }
            }
        }

        public void terminarHilos() {
            this.conectado = false;
            foreach (UsuarioServidor usv in usuarios) {
                usv.Conectado = false;
            }
        }

        public void run() {
            this.conectado = true;
            server.Start();

            //while (this.conectado) {
            this.atender();
            this.cuentaRegresiva();
            Estado m = new Estado();
            m.Texto = "Inicia juego";
            enviarTodos(m);
            this.vista.iniciarJuego();
            //}
        }
    }
}
