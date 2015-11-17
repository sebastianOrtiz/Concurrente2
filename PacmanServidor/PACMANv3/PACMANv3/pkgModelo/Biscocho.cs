using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMANv3.pkgModelo {
    /// <summary>
    /// Clase que representa las galletas, las super galletas y las frutas
    /// </summary>
    public class Biscocho {
        private int tipo; //1 Galletanomal, 2 Galleta Grande, 3 Fruta
        private int x;
        private int y;
        private Boolean estado;
        private int width;
        private int height;
        //
        /// <summary>
        /// Metodo Constructor de la clase Biscocho
        /// </summary>
        /// <param name="tipo">Tipo de biscocho 1 normal, 2 super galleta y 3 fruta</param>
        /// <param name="x">Posicion en el eje coordenado X del biscocho</param>
        /// <param name="y">Posicion en el eje coordenado Y del biscocho</param>
        /// <param name="w">Ancho del biscocho</param>
        /// <param name="h">Alto del biscocho</param>
        public Biscocho(int tipo, int x, int y, int w, int h) {
            this.tipo = tipo;
            this.width = w;
            this.height = h;
            if (tipo == 3) {
                this.x = x;
                this.y = y;
                this.estado = false;
            } else if (tipo == 2) {
                this.x = x + (width / 4);
                this.y = y + (height / 4);
                this.estado = true;
            } else {
                this.x = x + (width / 2) - 2;
                this.y = y + (height / 2) - 2;
                this.estado = true;
            }

        }

        /// <summary>
        /// Cambia el biscocho a tipo 2 y lo redimenciona
        /// </summary>
        public void cambiarATipo2() {
            this.tipo = 2;
            this.x = (x - (width / 2) + 2) + (width / 4) + 2;
            this.y = (y - (height / 2) + 2) + (height / 4 + 2);


        }

        /// <summary>
        /// Cambia el biscocho a tipo 3 y lo redimenciona
        /// </summary>
        /// <param name="x">Posicion en el eje coordenado X del biscocho</param>
        /// <param name="y">Posicion en el eje coordenado Y del biscocho</param>
        public void cambiarATipo3(int x, int y) {
            this.tipo = 3;
            this.x = x;
            this.y = y;
            this.estado = true;


        }

        /// <summary>
        /// Accesor y mutador de el atributo Height
        /// </summary>
        public int Height {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Width
        /// </summary>
        public int Width {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Accesor y mutador de el atributo Estado
        /// </summary>
        public Boolean Estado {
            get { return estado; }
            set { estado = value; }
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

        //Accesor y mutador de el atributo Tipo
        public int Tipo {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}
