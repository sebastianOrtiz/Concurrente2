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
    class Cliente {
        private TcpClient sc;
        private NetworkStream net;
        private VistaJuegoOnline vista;
        private bool conectado;

        private static BinaryFormatter serializer = new BinaryFormatter();

        public Cliente(string ipAddress, int port, VistaJuegoOnline vista) {
            this.sc = new TcpClient(ipAddress, port);
            this.net = sc.GetStream();
            this.vista = vista;
            this.conectado = false;
        }

        public void recibir() {
            //Leer
            byte[] msgDataLen = new byte[4];
            net.Read(msgDataLen, 0, 4);

            int dataLen = BitConverter.ToInt32(msgDataLen, 0);

            byte[] msgDataBytes = new byte[dataLen];
            net.Read(msgDataBytes, 0, dataLen);
            MemoryStream ms = new MemoryStream(msgDataBytes);
            ms.Position = 0;

            Object o = serializer.Deserialize(ms);
            this.procesar(o);
        }

        public void enviar(Object o) {
            //Escribir
            byte[] userDataBytes;
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(ms, o);
            userDataBytes = ms.ToArray();

            byte[] userDataLen = BitConverter.GetBytes((Int32)userDataBytes.Length);
            net.Write(userDataLen, 0, 4);
            net.Write(userDataBytes, 0, userDataLen.Length);
        }

        public void escuchar() {
            while (this.conectado) {
                this.recibir();
            }
        }

        public void procesar(Object o) {
            if (o.GetType() == typeof(Mensaje)) {
                Mensaje m = (Mensaje)o;
                Console.WriteLine(m.TEspera);
                if (m.Conectar) {
                    this.vista.Identificador = m.Id;
                    Console.WriteLine("id: {0} mensaje: {1}", m.Id, m.Texto);

                } else if (m.TEspera >= 1 && m.TEspera <= 5) {
                    Console.WriteLine("Inicia en {0}", m.TEspera);
                    // Mostrar tiempo de espera
                } else {
                    /* RECIBIR MENSAJES CHAT */
                }
            } else if (o.GetType() == typeof(Estado)) {
                VistaJuegoOnline.colaDeEstados.Enqueue((Estado)o);
            }
        }

        public bool Conectado {
            get { return conectado; }
            set { conectado = value; }
        }
    }
}
