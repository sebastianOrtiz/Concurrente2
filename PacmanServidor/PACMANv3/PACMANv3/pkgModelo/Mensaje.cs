using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMANv3.pkgModelo
{
    [Serializable()]
    class Mensaje
    {
        private string nombre;
        private string texto;

        public Mensaje(string nombre, string mensaje)
        {
            this.nombre = nombre;
            this.texto = mensaje;
        }

        /// <summary>
        /// Accesor y mutador de el atributo Nombre
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Mensaje
        /// </summary>
        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }
    }
}
