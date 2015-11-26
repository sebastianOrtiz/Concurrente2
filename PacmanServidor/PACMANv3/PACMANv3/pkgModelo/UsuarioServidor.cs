using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PACMANv3.pkgModelo {
    class UsuarioServidor {
        private int id;
        private NetworkStream net;
        private TcpClient client;
        private bool conectado;

        public UsuarioServidor(int id, TcpClient tcpC) {
            this.id = id;
            this.client = tcpC;
            this.net = this.client.GetStream();
            this.conectado = true;
        }

        public void atender() {
            //Leer
            byte[] msgDataLen = new byte[4];
            net.Read(msgDataLen, 0, 4);

            int dataLen = BitConverter.ToInt32(msgDataLen, 0);
            Console.WriteLine("tamaño leido {0}", dataLen);
            Console.WriteLine("esperando datos");
            byte[] msgDataBytes = new byte[dataLen];
            net.Read(msgDataBytes, 0, dataLen);
            MemoryStream ms = new MemoryStream(msgDataBytes);
            ms.Position = 0;

            Object o = Servidor.serializer.Deserialize(ms);
            if (o.GetType() == typeof(Mensaje)) {
                Servidor.enviarMensaje((Mensaje) o);
            } else if (o.GetType() == typeof(Estado)) {

            }
        }

        public void enviar(Object o) {
            //Escribir
            byte[] userDataBytes;
            MemoryStream ms = new MemoryStream();
            Servidor.serializer.Serialize(ms, o);
            userDataBytes = ms.ToArray();

            byte[] userDataLen = BitConverter.GetBytes((Int32) userDataBytes.Length);
            net.Write(userDataLen, 0, 4);
            net.Write(userDataBytes, 0, userDataBytes.Length);
        }

        /*public void enviar(Mensaje m) {
            //Escribir
            byte[] userDataBytes;
            MemoryStream ms = new MemoryStream();
            Servidor.serializer.Serialize(ms, m);
            userDataBytes = ms.ToArray();

            byte[] userDataLen = BitConverter.GetBytes((Int32) userDataBytes.Length);
            net.Write(userDataLen, 0, 4);
            net.Write(userDataBytes, 0, userDataBytes.Length);
        }

        public void enviar(Estado es) {
            //Escribir
            byte[] userDataBytes;
            MemoryStream ms = new MemoryStream();
            Servidor.serializer.Serialize(ms, es);
            userDataBytes = ms.ToArray();

            byte[] userDataLen = BitConverter.GetBytes((Int32) userDataBytes.Length);
            net.Write(userDataLen, 0, 4);
            net.Write(userDataBytes, 0, userDataBytes.Length);
        }*/

        public int Id {
            get { return id; }
        }

        public bool Conectado {
            get { return conectado; }
            set { conectado = value; }
        }
    }
}
