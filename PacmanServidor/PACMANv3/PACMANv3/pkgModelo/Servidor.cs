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

namespace PACMANv3.pkgModelo
{

    class Servidor
    {
        private Socket ss;
        private int cantJugadores;
        private Thread th;

        public Servidor(int cantJugadores)
        {
            this.cantJugadores = cantJugadores;
            this.ss = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint direccion;
            //direccion = new IPEndPoint(IPAddress.Parse(''), 1339);
            direccion = new IPEndPoint(IPAddress.Loopback, 1339);
            ss.Bind(direccion);
            ss.Listen(this.cantJugadores);
        }

        private void atender()
        {
            
        }
    }
}
