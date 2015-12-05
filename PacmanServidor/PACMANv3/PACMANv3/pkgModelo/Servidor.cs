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
        private static VistaJuego vJuego;

        public static BinaryFormatter serializer = new BinaryFormatter();
        private static List<UsuarioServidor> usuarios = new List<UsuarioServidor>();

        public Servidor(int cantJugadores, string ipAddress, Form1 vista, VistaJuego visJuego) {
            this.vista = vista;
            vJuego = visJuego;
            this.cantTotalJugadores = cantJugadores;
            this.server = new TcpListener(IPAddress.Parse(ipAddress), 1339);
            //this.server = new TcpListener(IPAddress.Loopback, 1339);
        }

        private void atender() {
            int conectados = 0;

            conectados = usuarios.Count;
            while (this.conectado && conectados < this.cantTotalJugadores) {
                TcpClient client = server.AcceptTcpClient();

                UsuarioServidor usv = new UsuarioServidor(usuarios.Count + 1, client);
                usv.enviarId();
                usv.enviar(this.vista.MapaAJugar);
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
                    vJuego.cambiarDirPacman(usv.Id, o.Direccion);
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

        private void enviarMapa() {
            foreach (UsuarioServidor usv in usuarios) {
                usv.enviar(this.vista.MapaAJugar);
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
            Console.WriteLine("Servidor iniciado");

            //while (this.conectado) {
            this.atender();
            this.cuentaRegresiva();
            //this.enviarMapa();
            Estado m = new Estado();
            m.Texto = "Inicia juego";
            enviarTodos(m);
            this.vista.iniciarJuego();
            //}
        }
    }
}
