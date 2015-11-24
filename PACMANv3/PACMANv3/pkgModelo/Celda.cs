using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PACMANv3.pkgModelo {
    /// <summary>
    /// Clase que representa una celda en la matriz del mapa
    /// </summary>
    [Serializable()]
    public class Celda {
        private string valor;
        private int x;
        private int y;
        private int width;
        private int heiht;
        private bool sePuedePasar;
        private Biscocho bisc;


        /// <summary>
        /// Metodo contructor de la clase celda
        /// </summary>
        /// <param name="valor">El valor cambia entre O si se puede pasar, X si no y Y si es lugar de nacimiento de los fantasmas</param>
        /// <param name="x">Posicion en el eje coordenado X de la celda</param>
        /// <param name="y">Posicion en el eje coordenado Y de la celda</param>
        /// <param name="lado">Es para asignar el ancho y alto de la celda</param>
        public Celda(string valor, int x, int y, int lado) {
            this.valor = valor;
            this.x = x;
            this.y = y;
            this.width = lado;
            this.heiht = lado;
            this.sePuedePasar = evaluarPasar();
        }

        /// <summary>
        /// Ecalua si se puede pasar por esa celda
        /// </summary>
        /// <returns>Devuelve un valor Booleano true si se puede pasar</returns>
        private bool evaluarPasar() {
            bool p = false;
            if (this.valor == "O") {
                p = true;
                bisc = new Biscocho(1,this.x,this.y,19,19);
            } else if (this.valor == "Y") {
                bisc = new Biscocho(1, this.x, this.y, 19, 19);
                bisc.Estado = false;
                p = true;
            } else if (this.valor == "X") {
                p = false;
            } else {
                p = false;
                System.Windows.Forms.MessageBox.Show(this.valor + " no es valido");
            }
            return p;
        }

        /// <summary>
        /// Accesor y mutador de el atributo Bisc
        /// </summary>
        internal Biscocho Bisc {
            get { return bisc; }
            set { bisc = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo SePuedePasar
        /// </summary>
        public bool SePuedePasar {
            get { return sePuedePasar; }
            set { sePuedePasar = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Heiht
        /// </summary>
        public int Heiht {
            get { return heiht; }
            set { heiht = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Width
        /// </summary>
        public int Width {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Y
        /// </summary>
        public int Y {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo X
        /// </summary>
        public int X {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Valor
        /// </summary>
        public string Valor {
            get { return valor; }
            set { valor = value; }
        }

    }
}
