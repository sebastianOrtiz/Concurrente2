using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Drawing;

namespace PACMANv3.pkgModelo {
    /// <summary>
    /// Representa un tablero de juego
    /// </summary>
    public class Mapa {
        private Celda[,] matrizDiseño;
        private int filas;
        private int columnas;
        private int nivel;
        private string nombre;
        private string dificultad;
        private String[,] arreglo;

        /// <summary>
        /// Contructor vacio utilizado para recontruit un mapa desde un archivo JSON
        /// </summary>
        public Mapa() {
            
        }

        /// <summary>
        /// Constructor de la clase mapa
        /// </summary>
        /// <param name="filas">Cantidad de filas del mapa</param>
        /// <param name="columnas">Cantidad de columnas del mapa</param>
        /// <param name="nivel">Nivel de mapa</param>
        /// <param name="nombre">Nombre del mapa</param>
        /// <param name="dificultad">Dificultad del mapa</param>
        public Mapa(int filas, int columnas, int nivel, string nombre, string dificultad) {
            this.filas = filas;
            this.columnas = columnas;
            this.nivel = nivel;
            this.nombre = nombre;
            this.dificultad = dificultad;
            this.MatrizDiseño = new Celda[filas, columnas];
        }

        /// <summary>
        /// Calcula el centro del mapa el cual sera la posicio inicial de los fantasmas
        /// </summary>
        /// <returns>retorna 2 puntos uno con las posiciones X y Y del centro y otra con la I y J de la fila y columna del centro del mapa</returns>
        public Point[] posicionInicalFantasmas() {
            Point [] pts = new Point[2];
            pts[0] = new Point(filas / 2, columnas / 2);
            pts[1] = new Point(matrizDiseño[filas / 2, columnas / 2].X, matrizDiseño[filas / 2, columnas / 2].Y);
            return pts;
        }

        /// <summary>
        /// Calcula la direccion en la que deben salir los fantasmas dependiendo de la direccion de salida del centro
        /// </summary>
        /// <returns>Retorna un valor entero que representa la direccion</returns>
        public int direccionDeSalidaDelFantasma() {
            //1 arriba, 2 abajo, 3 derecha , 4 izquierda
            int i = filas / 2;
            int j = columnas / 2;
            int dir = -1;
            if (arreglo[i - 1, j] == "Y") {
                dir = 1;
            } else if (arreglo[i + 1, j] == "Y") {
                dir = 2;
            } else if (arreglo[i, j - 1] == "Y") {
                dir = 4;
            } else if (arreglo[i, j + 1] == "Y") {
                dir = 3;
            }
            return dir;
        }

        /// <summary>
        /// Calcula la posicion inicial de pacman siendo esta la direccion opuesta la salida de los fantasmas
        /// </summary>
        /// <returns>retorna 2 puntos uno con las posiciones X y Y del centro y otra con la I y J de la fila y columna del centro del mapa</returns>
        public Point[] posicionInicialPacMan() {
            int i = filas / 2;
            int j = columnas / 2;
            Point p = new Point(-1,-1);
            Point p2 = new Point(-1,-1);
            if (arreglo[i - 1, j] == "Y") {
                p.X = matrizDiseño[i + 2, j].X;
                p.Y = matrizDiseño[i + 2, j].Y;
                p2 = new Point(i + 2, j);
            } else if (arreglo[i + 1, j] == "Y") {
                p.X = matrizDiseño[i - 2, j].X;
                p.Y = matrizDiseño[i - 2, j].Y;
                p2 = new Point(i - 2, j);
            } else if (arreglo[i, j - 1] == "Y") {
                p.X = matrizDiseño[i, j + 2].X;
                p.Y = matrizDiseño[i, j + 2].Y;
                p2 = new Point(i, j + 2);
            } else if (arreglo[i, j + 1] == "Y") {
                p.X = matrizDiseño[i, j - 2].X;
                p.Y = matrizDiseño[i, j - 2].Y;
                p2 = new Point(i, j - 2);
            }

            Point[] pts = new Point[2];
            pts[0] = p2;
            pts[1] = p;
            return pts;
        }

        /// <summary>
        /// Crea las celdas del mapa a partir de una matriz de Strings compuesta con Y, O y X
        /// </summary>
        public void crearMapa() {
            if (arreglo != null) {
                int x = 40;
                int y = 40;
                for (int i = 0; i < this.filas; i++) {
                    for (int j = 0; j < this.columnas; j++) {
                        //Console.WriteLine(arreglo[i, j]);
                        this.matrizDiseño[i, j] = new Celda(arreglo[i, j], x, y, 20);
                        x += 20;
                    }
                    x = 40;
                    y += 20;
                }
            }

        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Arreglo que es la matriz de Strings a partir de la cual se contrulle el mapa
        /// </summary>
        public String[,] Arreglo {
            get { return arreglo; }
            set { arreglo = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Dificultad
        /// </summary>
        public string Dificultad {
            get { return dificultad; }
            set { dificultad = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Nombre 
        /// </summary>
        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Nivel
        /// </summary>
        public int Nivel {
            get { return nivel; }
            set { nivel = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo MatrizDiseño, la sentencia [JsonIgnoreAttribute] hace que este atributo sea ignorado a la hora de crear su representacion en JSON
        /// </summary>
        [JsonIgnoreAttribute]
        public Celda[,] MatrizDiseño {
            get { return matrizDiseño; }
            set { matrizDiseño = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Filas
        /// </summary>
        public int Filas {
            get { return filas; }
            set { filas = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Columnas
        /// </summary>
        public int Columnas {
            get { return columnas; }
            set { columnas = value; }
        }
    }
}
