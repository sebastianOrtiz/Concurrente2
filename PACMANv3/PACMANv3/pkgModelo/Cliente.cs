﻿using System;
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
        private TcpClient scM;
        private NetworkStream net;
        private NetworkStream netM;
        private VistaJuegoOnline vista;
        private bool conectado;

        private static BinaryFormatter serializer = new BinaryFormatter();

        private delegate void DelegateCambiar(string s);

        public Cliente(string ipAddress, int port, VistaJuegoOnline vista) {
            this.sc = new TcpClient(ipAddress, port);
            this.scM = new TcpClient(ipAddress, 6000);
            this.net = sc.GetStream();
            this.netM = scM.GetStream();
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
            this.safeRead(msgDataBytes, dataLen, net);

            MemoryStream ms = new MemoryStream(msgDataBytes);
            ms.Position = 0;

            Estado o = (Estado)serializer.Deserialize(ms);

            if (o.TEspera == 5) {
                this.vista.TiempoEspera = 5;
                this.vista.Jugando = 5;
            }
            if (this.vista.TiempoEspera > -1) {
                this.vista.TiempoEspera = o.TEspera;
                this.procesar(o);
            }
                

            //this.recibirMapa();
            if (o.TEspera == 0) {
                this.vista.Jugando = 1;
            }
            

        }

        public void recibirM() {
            //Leer
            byte[] msgDataLen = new byte[4];
            netM.Read(msgDataLen, 0, 4);

            int dataLen = BitConverter.ToInt32(msgDataLen, 0);

            byte[] msgDataBytes = new byte[dataLen];

            //net.Read(msgDataBytes, 0, dataLen);
            this.safeRead(msgDataBytes, dataLen, netM);

            MemoryStream ms = new MemoryStream(msgDataBytes);
            ms.Position = 0;

            Estado o = (Estado)serializer.Deserialize(ms);
            this.procesarM(o);
        }

        private void safeRead(byte[] userData, int len, NetworkStream ns) {
            int dataRead = 0;
            do {
                dataRead += ns.Read(userData, dataRead, len - dataRead);
            } while (dataRead < len);
        }

        private void recibirMapa() {
            //Leer
            byte[] msgDataLen = new byte[4];
            net.Read(msgDataLen, 0, 4);

            int dataLen = BitConverter.ToInt32(msgDataLen, 0);

            byte[] msgDataBytes = new byte[dataLen];

            //net.Read(msgDataBytes, 0, dataLen);
            this.safeRead(msgDataBytes, dataLen, net);

            MemoryStream ms = new MemoryStream(msgDataBytes);
            ms.Position = 0;

            Mapa m = (Mapa)serializer.Deserialize(ms);
            this.vista.MapaAct = m;
        }

        public void enviar(Estado o) {
            //Escribir
            byte[] userDataBytes;
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(ms, o);
            userDataBytes = ms.ToArray();

            byte[] userDataLen = BitConverter.GetBytes((Int32)userDataBytes.Length);

            //Console.WriteLine(userDataBytes.Length);

            net.Write(userDataLen, 0, 4);
            net.Write(userDataBytes, 0, userDataBytes.Length);
        }

        public void enviarM(Estado o) {
            //Escribir
            byte[] userDataBytes;
            MemoryStream ms = new MemoryStream();
            serializer.Serialize(ms, o);
            userDataBytes = ms.ToArray();

            byte[] userDataLen = BitConverter.GetBytes((Int32)userDataBytes.Length);

            //Console.WriteLine(userDataBytes.Length);

            netM.Write(userDataLen, 0, 4);
            netM.Write(userDataBytes, 0, userDataBytes.Length);
        }

        public void escuchar() {
            while (this.conectado) {
                this.recibir();
            }
        }

        public void escucharMensajes() {
            while (this.conectado) {
                this.recibirM();
            }
        }

        public void procesar(Estado e) {
            //Console.WriteLine(e.TEspera);
            if (e.Conectar) {
                this.vista.Identificador = e.Id;
                Console.WriteLine("id: {0} mensaje: {1}", e.Id, e.Texto);
                this.recibirMapa();
            } else if (e.TEspera >= 1 && e.TEspera <= 5) {
                Console.WriteLine("Inicia en {0}", e.TEspera);
                // Mostrar tiempo de espera
            } else if (e.Biscochos == null) {
                //if (this.vista.InvokeRequired) {
                //    this.vista.Invoke(new DelegateCambiar(this.cambiarTexto), new object[] { (e.Nombre + ": " + e.Texto) });
                //} else {
                //    this.vista.recibirMensaje(e.Texto);
                //}
            } else {
                VistaJuegoOnline.colaDeEstados.Enqueue(e);
            }
        }

        public void procesarM(Estado e) {
            if (this.vista.InvokeRequired) {
                this.vista.Invoke(new DelegateCambiar(this.cambiarTexto), new object[] { (e.Nombre + ": " + e.Texto) });
            } else {
                this.vista.recibirMensaje(e.Texto);
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
