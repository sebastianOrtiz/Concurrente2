using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMANv3.pkgModelo {
    [Serializable()]
    class Mensaje {
        private int id;
        private string nombre;
        private string texto;
        private bool conectar;

        public Mensaje(int id, string nombre, string mensaje) {
            this.id = id;
            this.nombre = nombre;
            this.texto = mensaje;
            this.conectar = false;
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
    }
}
