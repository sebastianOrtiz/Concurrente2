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

        private delegate void DelegateCambiar(string s);

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

            //net.Read(msgDataBytes, 0, dataLen);
            this.safeRead(msgDataBytes, dataLen);

            MemoryStream ms = new MemoryStream(msgDataBytes);
            ms.Position = 0;

            Estado o = (Estado) serializer.Deserialize(ms);
            this.procesar(o);
        }

        private void safeRead(byte[] userData, int len) {
            int dataRead = 0;
            do {
                dataRead += net.Read(userData, dataRead, len - dataRead);
            } while (dataRead < len);
        }

        public void enviar(Estado o) {
            //Escribir
            byte[] userDataBytes;
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(ms, o);
            userDataBytes = ms.ToArray();

            byte[] userDataLen = BitConverter.GetBytes((Int32) userDataBytes.Length);

            Console.WriteLine(userDataBytes.Length);
            //Console.WriteLine();

            net.Write(userDataLen, 0, 4);
            net.Write(userDataBytes, 0, userDataBytes.Length);
        }

        public void escuchar() {
            while (this.conectado) {
                this.recibir();
            }
        }

        public void procesar(Estado e) {
            Console.WriteLine(e.TEspera);
            if (e.Conectar) {
                this.vista.Identificador = e.Id;
                Console.WriteLine("id: {0} mensaje: {1}", e.Id, e.Texto);
            } else if (e.TEspera >= 1 && e.TEspera <= 5) {
                Console.WriteLine("Inicia en {0}", e.TEspera);
                // Mostrar tiempo de espera
            } else if (e.Biscochos == null) {
                if (this.vista.InvokeRequired) {
                    this.vista.Invoke(new DelegateCambiar(this.cambiarTexto), new object[] { e.Texto });
                } else {
                    this.vista.recibirMensaje(e.Texto);
                }
            } else {
                VistaJuegoOnline.colaDeEstados.Enqueue(e);
            }
        }

        private void cambiarTexto(string st) {
            this.vista.recibirMensaje(st);
        }

        public bool Conectado {
            get { return conectado; }
            set { conectado = value; }
        }
    }
}
