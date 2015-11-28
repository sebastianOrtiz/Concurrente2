using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PACMANv3.pkgModelo {
    /// <summary>
    /// Representa a pacman, el personaje que manipula el jugador dentro del juego
    /// </summary>
    [Serializable()]
    public class PacMan {
        private Image imgActual;
        private Image[] imgArriba;
        private Image[] imgAbajo;
        private Image[] imgDerecha;
        private Image[] imgIzquierda;
        private int direccion; //1 arriba, 2 abajo, 3 derecha , 4 izquierda
        private int windth;
        private int height;
        private int x;
        private int y;
        private int velocidad;
        private int nivel;
        private Mapa mapaActual;
        private int iAct;
        private int jAct;
        private int imagenActual;
        private int hp;
        private int hpTotal;
        private int vidas;
        private Queue<int> colaDeOrdenes;
        private Random randCambairDir;

        private int identificador;

        
        
        /// <summary>
        /// Constructor de la clase PacMan
        /// </summary>
        /// <param name="lado">Definira el ancho y alto del Pacman</param>
        /// <param name="x">Posicion en el eje coordenado X del Pacman</param>
        /// <param name="y">Posicion en el eje coordenado Y del Pacman</param>
        /// <param name="velocidad">Velocidad de desplazamiento del Pacman</param>
        /// <param name="nivel">Nivel actual del tablero</param>
        /// <param name="mapaActual">Tablero actual</param>
        /// <param name="vidas">Cantidad de vidas</param>
        /// <param name="hp">Valor de cada vida</param>
        /// <param name="i">Indica la posicion inicial en las filas de la matriz</param>
        /// <param name="j">Indica la posicion inicial en las columnas de la matriz</param>
        public PacMan(int lado, int x, int y, int velocidad, int nivel,  Mapa mapaActual, int vidas, int hp, int i, int j) {
            this.windth = lado;
            this.height = lado;
            this.x = x;
            this.y = y;
            this.velocidad = velocidad;
            this.nivel = nivel;
            this.mapaActual = mapaActual;
            this.vidas = vidas;
            this.hp = hp;
            this.hpTotal = hp;
            this.iAct = i;
            this.jAct = j;
            this.randCambairDir = new Random(DateTime.Now.Millisecond);
            this.configuracionInicialPacman();
        }

        /// <summary>
        /// Limpia la cola de ordenes que hay actualmente para pacman
        /// </summary>
        public void vaciarOrdenes() {
            this.colaDeOrdenes.Clear();
        }

        /// <summary>
        /// Cambia de nivel al personaje
        /// </summary>
        /// <param name="m">Mapa del siguiente nivel</param>
        /// <param name="vel">Velocidad inicial del personaje</param>
        public void cambiarNivel(Mapa m, int vel) {
            this.mapaActual = m;
            this.nivel++;
            this.velocidad = vel;
        }

        /// <summary>
        /// Representacion en forma de cadena de texto de la vida y el HP der personaje
        /// </summary>
        /// <returns>Retorna una cadena de texto</returns>
        public String estadoDeVida() {
            String s = "Vidas: " + this.vidas + "\nHP: ";
            for (int i = 0; i < hp; i++) {
                s += " |";
            }
            return s;
        }

        /// <summary>
        /// Disminuye la vida del personaje dado un valor entero que representa el daño
        /// </summary>
        /// <param name="dano">Cantidad de vida a rebajar</param>
        /// <returns></returns>
        public int disminuirVida(int dano) {
            int hpT = (this.vidas * this.hpTotal) + this.hp;
            hpT -= dano;
            this.vidas = hpT / this.hpTotal;
            this.hp = hpT % this.hpTotal;
            return hpT;
        }

        /// <summary>
        /// Configuraciones iniciales de pacman tales como sus imagenes y direccion inicial
        /// </summary>
        private void configuracionInicialPacman() {

            this.colaDeOrdenes = new Queue<int>();
            //Configuacion de Imagenes
            this.imgArriba = new Image[2];
            this.imgAbajo = new Image[2];
            this.imgDerecha = new Image[2];
            this.imgIzquierda = new Image[2];

            this.imgAbajo[0] = Properties.Resources.PACMANAbajo1;
            this.imgAbajo[1] = Properties.Resources.PACMANAbajo2;
            this.imgArriba[0] = Properties.Resources.PACMANArriba1;
            this.imgArriba[1] = Properties.Resources.PACMANArriba2;
            this.imgDerecha[0] = Properties.Resources.PACMANDerecha1;
            this.imgDerecha[1] = Properties.Resources.PACMANDerecha2;
            this.imgIzquierda[0] = Properties.Resources.PACMANIzquierda1;
            this.imgIzquierda[1] = Properties.Resources.PACMANIzquierda2;

            this.direccion = 3;

            
        }

        /// <summary>
        /// Cambia el indice de la imagen actual de pacman
        /// </summary>
        /// <returns></returns>
        private int setImagen() {
            if (this.imagenActual == 1) {
                this.imagenActual = 0;
            } else {
                this.imagenActual = 1;
            }
            return this.imagenActual;
        }

        /// <summary>
        /// Evalua si pacman se puede mover en su direccion actual
        /// </summary>
        /// <returns>Retorna un valor Booleando true si puede seguirse moviendo</returns>
        private Boolean sePuedeMover() {
            switch (this.direccion) {
                case 1:
                    if ((IAct - 1) >= 0 && mapaActual.MatrizDiseño[IAct - 1, JAct].SePuedePasar) {
                        return true;
                    }
                    break;
                case 2:
                    if ((IAct + 1) < mapaActual.Filas && mapaActual.MatrizDiseño[IAct + 1, JAct].SePuedePasar) {
                        return true;
                    }
                    break;
                case 3:
                    if ((JAct + 1) < mapaActual.Columnas && mapaActual.MatrizDiseño[IAct, JAct + 1].SePuedePasar) {
                        return true;
                    }
                    break;
                case 4:
                    if ((JAct - 1) >= 0 && mapaActual.MatrizDiseño[IAct, JAct - 1].SePuedePasar) {
                        return true;
                    }
                    break;
            }
            return false;
        }

        /// <summary>
        /// Evalua si pacman se puede mover en una direccion dada
        /// </summary>
        /// <param name="dir">Direccion a evaluar</param>
        /// <returns>Retorna un valor Booleano true si se puede mover en la direccion dada</returns>
        public Boolean sePuedeMover(int dir) {
            if (this.x == mapaActual.MatrizDiseño[iAct, jAct].X && this.y == mapaActual.MatrizDiseño[iAct, jAct].Y) {
                switch (dir) {
                    case 1:
                        if ((IAct - 1) >= 0 && mapaActual.MatrizDiseño[IAct - 1, JAct].SePuedePasar) {
                            return true;
                        }
                        break;
                    case 2:
                        if ((IAct + 1) < mapaActual.Filas && mapaActual.MatrizDiseño[IAct + 1, JAct].SePuedePasar) {
                            return true;
                        }
                        break;
                    case 3:
                        if ((JAct + 1) < mapaActual.Columnas && mapaActual.MatrizDiseño[IAct, JAct + 1].SePuedePasar) {
                            return true;
                        }
                        break;
                    case 4:
                        if ((JAct - 1) >= 0 && mapaActual.MatrizDiseño[IAct, JAct - 1].SePuedePasar) {
                            return true;
                        }
                        break;
                }
            }

            return false;
        }

        /// <summary>
        /// Ejecuta un movimiento del personaje, asi como su cambio de imagen y su direccion sea aleatoria o tomada de la cola de ordenes
        /// </summary>
        public void mover() {
            if (sePuedeMover()) {
                switch (this.direccion) {
                    case 1:
                        this.ImgActual = this.imgArriba[setImagen()];
                        if ((this.Y - this.velocidad) < mapaActual.MatrizDiseño[iAct - 1, jAct].Y) {
                            this.Y = mapaActual.MatrizDiseño[iAct - 1, jAct].Y;
                            iAct = iAct - 1;
                            if (colaDeOrdenes.Count > 0) {
                                if (sePuedeMover(colaDeOrdenes.Peek())) {
                                    this.direccion = colaDeOrdenes.Dequeue();
                                }
                            }
                        } else {
                            this.Y -= this.velocidad;
                        }
                        break;
                    case 2:
                        this.ImgActual = this.imgAbajo[setImagen()];
                        if ((this.Y + this.velocidad) > mapaActual.MatrizDiseño[iAct + 1, jAct].Y) {
                            this.Y = mapaActual.MatrizDiseño[iAct + 1, jAct].Y;
                            iAct = iAct + 1;
                            if (colaDeOrdenes.Count > 0) {
                                if (sePuedeMover(colaDeOrdenes.Peek())) {
                                    this.direccion = colaDeOrdenes.Dequeue();
                                }
                            }
                        } else {
                            this.Y += this.velocidad;
                        }
                        break;
                    case 3:
                        this.ImgActual = this.imgDerecha[setImagen()];
                        if ((this.X + this.velocidad) > mapaActual.MatrizDiseño[iAct, jAct + 1].X) {
                            this.X = mapaActual.MatrizDiseño[iAct, jAct + 1].X;
                            jAct = jAct + 1;
                            if (colaDeOrdenes.Count > 0) {
                                if (sePuedeMover(colaDeOrdenes.Peek())) {
                                    this.direccion = colaDeOrdenes.Dequeue();
                                }
                            }

                        } else {
                            this.X += this.velocidad;
                        }
                        break;
                    case 4:
                        this.ImgActual = this.imgIzquierda[setImagen()];
                        if ((this.X - this.velocidad) < mapaActual.MatrizDiseño[iAct, jAct - 1].X) {
                            this.X = mapaActual.MatrizDiseño[iAct, jAct - 1].X;
                            jAct = jAct - 1;
                            if (colaDeOrdenes.Count > 0) {
                                if (sePuedeMover(colaDeOrdenes.Peek())) {
                                    this.direccion = colaDeOrdenes.Dequeue();
                                }
                            }
                        } else {
                            this.X -= this.velocidad;
                        }
                        break;
                }
            } else {
                if (colaDeOrdenes.Count > 0) {
                    if (sePuedeMover(colaDeOrdenes.Peek())) {
                        this.direccion = colaDeOrdenes.Dequeue();
                    } else {
                        colaDeOrdenes.Dequeue();
                    }
                } else {
                    //this.cambiarDirecion();
                }
            }

        }

        /// <summary>
        /// Aumenta la velocidad de movimiento de pacman en 1/2 de la velocidad actual
        /// </summary>
        public void aumentarVelocidad() {
            int aumento = this.velocidad / 2;
            if (aumento == 0) {
                aumento = 1;
            }
            this.velocidad += aumento;
        }

        /// <summary>
        /// Adiciona una orden de direccion a la cola de ordenes
        /// </summary>
        /// <param name="orden">direccion</param>
        public void adicionarOrden(int orden) {
            this.colaDeOrdenes.Enqueue(orden);
        }

        /// <summary>
        /// Calcula una lista de direcciones posibles dependiendo de la posicion actual del pacman
        /// </summary>
        /// <returns>Retorna una lista con las direccione posibles</returns>
        private List<int> direccionesPosibles() {
            List<int> listaDeDireccionesPosibles = new List<int>();
            if ((iAct - 1) > -1) {
                if (mapaActual.MatrizDiseño[iAct - 1, jAct].SePuedePasar) {
                    listaDeDireccionesPosibles.Add(1);
                }
            }
            if ((iAct + 1) < mapaActual.Filas) {
                if (mapaActual.MatrizDiseño[iAct + 1, jAct].SePuedePasar) {
                    listaDeDireccionesPosibles.Add(2);
                }
            }

            if ((jAct + 1) < mapaActual.Columnas) {
                if (mapaActual.MatrizDiseño[iAct, jAct + 1].SePuedePasar) {
                    listaDeDireccionesPosibles.Add(3);
                }
            }
            if ((jAct - 1) > -1) {
                if (mapaActual.MatrizDiseño[iAct, jAct - 1].SePuedePasar) {
                    listaDeDireccionesPosibles.Add(4);
                }
            }

            return Fantasma.desordenarLista(listaDeDireccionesPosibles); ;
        }

        /// <summary>
        /// Calcula un valor aleatorio dado un limite
        /// </summary>
        /// <param name="hasta">limite del random</param>
        /// <returns>Retorna un numero aleatorio</returns>
        private int calcularRandom(int hasta) {
            int itera = randCambairDir.Next(randCambairDir.Next(randCambairDir.Next(80)));
            for (int i = 0; i < itera; i++) {
                randCambairDir.Next(hasta);
            }
            int seed = randCambairDir.Next(hasta);
            Random nuevo = new Random(seed);
            return nuevo.Next(hasta);
        }

        /// <summary>
        /// Cambia la direccion aleatoria de pacman segun la lista de posibles direcciones
        /// </summary>
        private void cambiarDirecion() {
            List<int> list = direccionesPosibles();
            int ind = calcularRandom(list.Count);
            this.direccion = list.ElementAt(ind);
        }

        /// <summary>
        /// Lista en forma de cadena de tecto las direcciones de la lista de ordenes
        /// </summary>
        /// <returns>Retorna una representacion en cadena de texto de la lista de ordenes</returns>
        public String listarOrdenesActuales() {
            String s = "";
            foreach (int ord in colaDeOrdenes) {
                switch (ord) {
                    case 1:
                        s += "Arriba\n";
                        break;
                    case 2:
                        s += "Abajo\n";
                        break;
                    case 3:
                        s += "Derecha\n";
                        break;
                    case 4:
                        s += "Izquierda\n";
                        break;
                }

            }
            return s;
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Velocidad
        /// </summary>
        public int Velocidad {
            get { return velocidad; }
            set { velocidad = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo IAct
        /// </summary>
        public int IAct {
            get { return iAct; }
            set { iAct = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo JAct
        /// </summary>
        public int JAct {
            get { return jAct; }
            set { jAct = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Windth
        /// </summary>
        public int Windth {
            get { return windth; }
            set { windth = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Height
        /// </summary>
        public int Height {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo X
        /// </summary>
        public int X {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Y
        /// </summary>
        public int Y {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo ImgActual
        /// </summary>
        public Image ImgActual {
            get { return imgActual; }
            set { imgActual = value; }
        }

        public int Identificador {
            get { return identificador; }
            set { identificador = value; }
        }
    }
}
