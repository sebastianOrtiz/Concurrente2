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

namespace PACMANv3.pkgModelo {

    class Servidor {
        private TcpListener server;
        private Thread th;
        private int cantTotalJugadores;
        private bool conectado;

        public static BinaryFormatter serializer = new BinaryFormatter();
        private static List<UsuarioServidor> usuarios = new List<UsuarioServidor>();

        public Servidor(int cantJugadores, string ipAddress) {
            this.cantTotalJugadores = cantJugadores;
            //this.server = new TcpListener(IPAddress.Parse(ipAddress), 1339);
            this.server = new TcpListener(IPAddress.Loopback, 1339);
        }

        public void atender() {
            this.conectado = true;
            server.Start();

            while (this.conectado) {
                while (this.conectado && usuarios.Count < this.cantTotalJugadores) {
                    TcpClient client = server.AcceptTcpClient();

                    UsuarioServidor usv = new UsuarioServidor(usuarios.Count, client);
                    usv.enviarId();
                    usuarios.Add(usv);

                    new Thread(usv.atender).Start();
                }
            }
        }

        public static void enviarTodos(Object o) {
            if (o.GetType() == typeof(Mensaje)) {
                Mensaje m = (Mensaje) o;
                foreach (UsuarioServidor usv in usuarios) {
                    if (usv.Id != m.Id) {
                        usv.enviar(m);
                    }
                }
            } else if (o.GetType() == typeof(Estado)) {

            }
        }

        public void terminarHilos() {
            this.conectado = false;
            foreach (UsuarioServidor usv in usuarios) {
                usv.Conectado = false;
            }
        }
    }
}
