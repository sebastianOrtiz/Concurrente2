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

        public static BinaryFormatter serializer = new BinaryFormatter();
        private static List<UsuarioServidor> usuarios = new List<UsuarioServidor>();

        public Servidor(int cantJugadores) {
            this.cantTotalJugadores = cantJugadores;
            this.server = new TcpListener(IPAddress.Loopback, 1339);
        }

        private void atender() {
            server.Start();
            while (usuarios.Count < this.cantTotalJugadores) {
                TcpClient client = server.AcceptTcpClient();

                UsuarioServidor usv = new UsuarioServidor(usuarios.Count, client);
                usuarios.Add(usv);

                new Thread(usv.atender).Start();
            }
        }

        public static void enviarMensaje(Mensaje m) {
            foreach (UsuarioServidor usv in usuarios) {
                if (usv.Id != m.Id) {
                    usv.enviar(m);
                }
            }
        }
    }
}
