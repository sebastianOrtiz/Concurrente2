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
        private Socket sc;
        private NetworkStream nst;
        private static BinaryFormatter bnFm = new BinaryFormatter();
        private VistaJuegoOnline vista;
        private Thread th;

        public Cliente(Socket sc, NetworkStream nst, VistaJuegoOnline vista)
        {
            this.sc = sc;
            this.nst = nst;
            this.vista = vista;
            this.th = new Thread(this.escuchar);
        }

        private void escuchar()
        {

        }
    }
}
