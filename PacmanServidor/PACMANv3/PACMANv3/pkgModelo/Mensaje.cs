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

        public Mensaje(int id, string nombre, string mensaje) {
            this.id = id;
            this.nombre = nombre;
            this.texto = mensaje;
        }

        /// <summary>
        /// Accesor y mutador de el atributo Nombre
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
        /// Accesor y mutador de el atributo Mensaje
        /// </summary>
        public string Texto {
            get { return texto; }
            set { texto = value; }
        }
    }
}
