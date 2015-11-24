using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMANv3.pkgModelo
{
    [Serializable()]
    public class Estado
    {
        private List<PacMan> jugadores;
        private List<Fantasma> fantasmas;
        private Biscocho[,] biscochos;

        public Estado(List<PacMan> jugadores, List<Fantasma> fantasmas, Biscocho[,] biscochos)
        {
            this.jugadores = jugadores;
            this.fantasmas = fantasmas;
            this.biscochos = biscochos;
        }

        public Biscocho[,] Biscochos
        {
            get { return biscochos; }
            set { biscochos = value; }
        }

        public List<Fantasma> Fantasmas
        {
            get { return fantasmas; }
            set { fantasmas = value; }
        }

        public List<PacMan> Jugadores
        {
            get { return jugadores; }
            set { jugadores = value; }
        }
    }
}
