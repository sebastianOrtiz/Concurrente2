using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMANv3.pkgModelo {
    [Serializable()]
    public class Estado {
        private List<PacMan> jugadores;
        private List<Fantasma> fantasmas;
        private Biscocho[,] biscochos;

        //Mensajes

        private int id;
        private string nombre;
        private string texto;
        private bool conectar;
        private int direccion;
        private int tEspera;

        public Estado() {

        }

        public Estado(List<PacMan> jugadores, List<Fantasma> fantasmas, Biscocho[,] biscochos) {
            this.jugadores = jugadores;
            this.fantasmas = fantasmas;
            this.biscochos = biscochos;
        }

        public Estado(int id, string nombre, string mensaje, int dir) {
            this.id = id;
            this.nombre = nombre;
            this.texto = mensaje;
            this.conectar = false;
            this.direccion = dir;
            this.tEspera = 0;
        }
        public Biscocho[,] Biscochos {
            get { return biscochos; }
            set { biscochos = value; }
        }

        public List<Fantasma> Fantasmas {
            get { return fantasmas; }
            set { fantasmas = value; }
        }

        public List<PacMan> Jugadores {
            get { return jugadores; }
            set { jugadores = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Id
        /// </summary>
        public int Id {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Nombre
        /// </summary>
        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Texto
        /// </summary>
        public string Texto {
            get { return texto; }
            set { texto = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Conectar
        /// </summary>
        public bool Conectar {
            get { return conectar; }
            set { conectar = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Direccion
        /// </summary>
        public int Direccion {
            get { return direccion; }
            set { direccion = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo TEspera
        /// </summary>
        public int TEspera {
            get { return tEspera; }
            set { tEspera = value; }
        }
    }
}
