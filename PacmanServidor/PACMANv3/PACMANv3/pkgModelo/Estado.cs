using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMANv3.pkgModelo {
    public class Estado {
        private List<PacMan> jugadores;
        private List<Fantasma> fantasmas;
        private Mapa mapa;

        public Estado(List<PacMan> jugadores, List<Fantasma> fantasmas, Mapa mapa) {
            this.jugadores = jugadores;
            this.fantasmas = fantasmas;
            this.mapa = mapa;
        }

        public Mapa Mapa {
            get { return mapa; }
            set { mapa = value; }
        }

        public List<Fantasma> Fantasmas {
            get { return fantasmas; }
            set { fantasmas = value; }
        }

        public List<PacMan> Jugadores {
            get { return jugadores; }
            set { jugadores = value; }
        }
    }
}
