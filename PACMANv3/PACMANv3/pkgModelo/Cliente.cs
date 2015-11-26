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

namespace PACMANv3.pkgModelo
{
    class Cliente
    {
        private TcpClient sc;
        private NetworkStream net;
        private VistaJuegoOnline vista;

        private static BinaryFormatter bnFm = new BinaryFormatter();

        public Cliente(TcpClient sc, VistaJuegoOnline vista)
        {
            this.sc = sc;
            this.net = sc.GetStream();
            this.vista = vista;
        }

        private void escuchar()
        {

        }
    }
}
