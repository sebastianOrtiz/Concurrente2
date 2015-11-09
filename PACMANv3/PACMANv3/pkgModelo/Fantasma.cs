using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PACMANv3.pkgModelo {
    /// <summary>
    /// Clase que representa un enemigo en el juego
    /// </summary>
    public class Fantasma {
        private Image imgActual;
        private Image[] imgArriba;
        private Image[] imgAbajo;
        private Image[] imgDerecha;
        private Image[] imgIzquierda;
        private Image[] imgVulnerable;
        private int direccion; //1 arriba, 2 abajo, 3 derecha , 4 izquierda
        private int estado;//1 vivo, 2 vulnerable, 3 muerto, 4 fin del juego
        private int poder;
        private String nombreFantasma;
        private int windth;
        private int height;
        private int x;
        private int y;
        private int velocidad;
        private int nivel;
        private int dificultad;//1 Facil, 2 Medio, 3 Dificil
        private Mapa mapaActual;
        private int iAct;
        private int jAct;
        private int imagenActual;
        private Random randCambairDir;



        /// <summary>
        /// Metodo contructor de la clase Fantasma
        /// </summary>
        /// <param name="direccion">Inica la direccion actual del fantasma</param>
        /// <param name="fantasma">Nombre que identifica al fantasma, puede ser ROJO, AZUL, NARANJA o ROSA</param>
        /// <param name="lado">Asigna el ancho y alto de la imagen del fantasma</param>
        /// <param name="x">Posicion en el eje coordenado X del fantasma</param>
        /// <param name="y">Posicion en el eje coordenado Y del fantasma</param>
        /// <param name="nivel">Nivel del tablero de juego actual</param>
        /// <param name="dificultad">Dificultad de juego Actual</param>
        /// <param name="m">Mapa actual en el que se esta juagdo</param>
        /// <param name="i">Posicion de la fila en la que se encuentra actualmente el fantasma</param>
        /// <param name="j">Posicion de la columna en la que se encuentra actualmente el fantasma</param>
        public Fantasma(int direccion, String fantasma, int lado, int x, int y, int nivel, String dificultad, Mapa m, int i, int j) {
            this.direccion = direccion;
            this.estado = 1;
            this.nombreFantasma = fantasma;
            this.windth = lado;
            this.height = lado;
            this.x = x;
            this.y = y;
            this.nivel = nivel;
            this.mapaActual = m;
            configuracionInicialDeFantasma(fantasma, nivel, dificultad);
            this.iAct = i;
            this.jAct = j;
            this.imagenActual = 0;
            this.randCambairDir = new Random(DateTime.Now.Millisecond);
        }

        /// <summary>
        /// Metodo para configurar otros parametros iniciales del fantasma
        /// </summary>
        /// <param name="fantasma">Nombre identificador del fantasma</param>
        /// <param name="nivel">Nivel actual de juego</param>
        /// <param name="dificultad">Dificultad actual de juego</param>
        private void configuracionInicialDeFantasma(String fantasma, int nivel, String dificultad) {
            //Configuacion de Imagenes
            imgArriba = new Image[2];
            imgAbajo = new Image[2];
            imgDerecha = new Image[2];
            imgIzquierda = new Image[2];
            imgVulnerable = new Image[2];

            switch ((fantasma.ToUpper())) {
                case "ROJO":
                    this.imgAbajo[0] = Properties.Resources.ROJOAbajo1;
                    this.imgAbajo[1] = Properties.Resources.ROJOAbajo2;
                    this.imgArriba[0] = Properties.Resources.ROJOArriba1;
                    this.imgArriba[1] = Properties.Resources.ROJOArriba2;
                    this.imgDerecha[0] = Properties.Resources.ROJODerecha1;
                    this.imgDerecha[1] = Properties.Resources.ROJODerecha2;
                    this.imgIzquierda[0] = Properties.Resources.ROJOIzquierda1;
                    this.imgIzquierda[1] = Properties.Resources.ROJOIzquierda2;
                    this.imgVulnerable[0] = Properties.Resources.ROJOMuerto1;
                    this.imgVulnerable[1] = Properties.Resources.ROJOMuerto2;
                    break;
                case "AZUL":
                    this.imgAbajo[0] = Properties.Resources.AZULAbajo1;
                    this.imgAbajo[1] = Properties.Resources.AZULAbajo2;
                    this.imgArriba[0] = Properties.Resources.AZULArriba1;
                    this.imgArriba[1] = Properties.Resources.AZULArriba2;
                    this.imgDerecha[0] = Properties.Resources.AZULDerecha1;
                    this.imgDerecha[1] = Properties.Resources.AZULDerecha2;
                    this.imgIzquierda[0] = Properties.Resources.AZULIzquierda1;
                    this.imgIzquierda[1] = Properties.Resources.AZULIzquierda2;
                    this.imgVulnerable[0] = Properties.Resources.AZULMuerto1;
                    this.imgVulnerable[1] = Properties.Resources.AZULMuerto2;
                    break;
                case "NARANJA":
                    this.imgAbajo[0] = Properties.Resources.NARANJAAbajo1;
                    this.imgAbajo[1] = Properties.Resources.NARANJAAbajo2;
                    this.imgArriba[0] = Properties.Resources.NARANJAArriba1;
                    this.imgArriba[1] = Properties.Resources.NARANJAArriba2;
                    this.imgDerecha[0] = Properties.Resources.NARANJADerecha1;
                    this.imgDerecha[1] = Properties.Resources.NARANJADerecha2;
                    this.imgIzquierda[0] = Properties.Resources.NARANJAIzquierda1;
                    this.imgIzquierda[1] = Properties.Resources.NARANJAIzquierda2;
                    this.imgVulnerable[0] = Properties.Resources.NARANJAMuerto1;
                    this.imgVulnerable[1] = Properties.Resources.NARANJAMuerto2;
                    break;
                case "ROSA":
                    this.imgAbajo[0] = Properties.Resources.ROSAAbajo1;
                    this.imgAbajo[1] = Properties.Resources.ROSAAbajo2;
                    this.imgArriba[0] = Properties.Resources.ROSAArriba1;
                    this.imgArriba[1] = Properties.Resources.ROSAArriba2;
                    this.imgDerecha[0] = Properties.Resources.ROSADerecha1;
                    this.imgDerecha[1] = Properties.Resources.ROSADerecha2;
                    this.imgIzquierda[0] = Properties.Resources.ROSAIzquierda1;
                    this.imgIzquierda[1] = Properties.Resources.ROSAIzquierda2;
                    this.imgVulnerable[0] = Properties.Resources.ROSAMuerto1;
                    this.imgVulnerable[1] = Properties.Resources.ROSAMuerto2;
                    break;
            }


            //Configuracion de imagen inicial respecto a la direccion
            switch (direccion) {
                case 1:
                    this.ImgActual = imgArriba[0];
                    break;
                case 2:
                    this.ImgActual = imgAbajo[0];
                    break;
                case 3:
                    this.ImgActual = imgDerecha[0];
                    break;
                case 4:
                    this.ImgActual = imgIzquierda[0];
                    break;
            }
            //Configuracion de dificultad
            switch (dificultad) {
                case "Facil":
                    this.dificultad = 1;
                    break;
                case "Medio":
                    this.dificultad = 2;
                    break;
                case "Dificil":
                    this.dificultad = 3;
                    break;
            }
            //Configuracion de poder y velocidad
            if (nivel == 1) {
                if (fantasma.ToUpper().Equals("ROJO")) {
                    this.velocidad = 2;
                    this.poder = 1;
                } else if (fantasma.ToUpper().Equals("ROSA")) {
                    this.velocidad = 1;
                    this.poder = 2;
                } else if (fantasma.ToUpper().Equals("NARANJA")) {
                    this.velocidad = 1;
                    this.poder = 1;
                } else if (fantasma.ToUpper().Equals("AZUL")) {
                    this.velocidad = 2;
                    this.poder = 1;
                }
            } else if (nivel == 2) {
                if (fantasma.ToUpper().Equals("ROJO")) {
                    this.velocidad = 4;
                    this.poder = 3;
                } else if (fantasma.ToUpper().Equals("ROSA")) {
                    this.velocidad = 2;
                    this.poder = 2;
                } else if (fantasma.ToUpper().Equals("NARANJA")) {
                    this.velocidad = 1;
                    this.poder = 2;
                } else if (fantasma.ToUpper().Equals("AZUL")) {
                    this.velocidad = 2;
                    this.poder = 1;
                }
            } else if (nivel == 3) {
                if (fantasma.ToUpper().Equals("ROJO")) {
                    this.velocidad = 5;
                    this.poder = 3;
                } else if (fantasma.ToUpper().Equals("ROSA")) {
                    this.velocidad = 3;
                    this.poder = 3;
                } else if (fantasma.ToUpper().Equals("NARANJA")) {
                    this.velocidad = 1;
                    this.poder = 2;
                } else if (fantasma.ToUpper().Equals("AZUL")) {
                    this.velocidad = 2;
                    this.poder = 2;
                }
            }
            this.velocidad = this.velocidad / 2;
            if (this.velocidad < 1) {
                this.velocidad = 1;
            }

        }

        /// <summary>
        /// Aumenta la velocidad del fantasma en 1/2 de la velocidad actual
        /// </summary>
        public void aumentarVelocidad() {
            int aumento = this.velocidad / 2;
            if (aumento == 0) {
                aumento = 1;
            }
            this.velocidad += aumento;
        }

        /// <summary>
        /// Desordena una lista de numeros enteros
        /// </summary>
        /// <param name="input">Lista entrante</param>
        /// <returns>Retorna una nueva lista desordenada</returns>
        public static List<int> desordenarLista(List<int> input) {
            List<int> arr = input;
            List<int> arrDes = new List<int>();

            Random randNum = new Random();
            while (arr.Count > 0) {
                int val = randNum.Next(0, arr.Count - 1);
                arrDes.Add(arr[val]);
                arr.RemoveAt(val);
            }

            return arrDes;
        }

        /// <summary>
        /// Crea una lista con la posibles direcciones del fantasma dependiendo del lugar de la matriz del mapa en la cual se encuentre
        /// </summary>
        /// <returns>Retorna una lista de enteros con las direcciones posibles</returns>
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

            return desordenarLista(listaDeDireccionesPosibles); ;
        }

        /// <summary>
        /// Metodo para calcular un numero lo mas aleatorio posible para que los fantasmas no siempre tomen la misma direccion
        /// </summary>
        /// <param name="hasta">Limite superior del random</param>
        /// <returns></returns>
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
        /// Cambia la direccion del fantasma por una de las posibles direcciones de la lista dada por un indice random, este metodo se aplicara cuando los fantasmas no tengan para donde moverse
        /// </summary>
        private void cambiarDirecion() {
            List<int> list = direccionesPosibles();
            int ind = calcularRandom(list.Count);
            this.direccion = list.ElementAt(ind);
        }

        /// <summary>
        /// Cambia la direccion del fantasma por una de las posibles direcciones de la lista dada por un indice random, a diferencia del metodo anterior este se usa en cada movimiento del fantasma para que si dado el caso el fantasma esta en una especie de tunel no este calculando a donde movers cada vez que cambia de posicion en el tunel
        /// </summary>
        private void cambiarDirecionMasDe2() {
            List<int> list = direccionesPosibles();
            if (list.Count > 2) {
                int ind = calcularRandom(list.Count);
                this.direccion = list.ElementAt(ind);
            }

        }

        /// <summary>
        /// Cambia el indice de la imagen actual del fantasma 
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
        /// Evalua si un fantasma aun se puede mover en su direccion actual
        /// </summary>
        /// <returns>Retorna un valor Booleano true si se puede seguir moviendo en la direccion actual</returns>
        private Boolean sePuedeMover() {
            switch (this.direccion) {
                case 1:
                    if ((iAct - 1) >= 0 && mapaActual.MatrizDiseño[iAct - 1, jAct].SePuedePasar) {
                        return true;
                    }
                    break;
                case 2:
                    if ((iAct + 1) < mapaActual.Filas && mapaActual.MatrizDiseño[iAct + 1, jAct].SePuedePasar) {
                        return true;
                    }
                    break;
                case 3:
                    if ((jAct + 1) < mapaActual.Columnas && mapaActual.MatrizDiseño[iAct, jAct + 1].SePuedePasar) {
                        return true;
                    }
                    break;
                case 4:
                    if ((jAct - 1) >= 0 && mapaActual.MatrizDiseño[iAct, jAct - 1].SePuedePasar) {
                        return true;
                    }
                    break;
            }
            return false;
        }

        /// <summary>
        /// Metodo que hace una iteracion de movimiento del fantasma, decide si se puede mover y de no ser asi calcula una nueva direccion
        /// </summary>
        public void mover() {
            if (sePuedeMover()) {
                switch (this.direccion) {
                    case 1:
                        if (this.estado == 1) {
                            this.imgActual = this.imgArriba[setImagen()];
                        } else if (this.estado == 2) {
                            this.imgActual = this.imgVulnerable[setImagen()];
                        }

                        if ((this.y - this.velocidad) < mapaActual.MatrizDiseño[iAct - 1, jAct].Y) {
                            this.y = mapaActual.MatrizDiseño[iAct - 1, jAct].Y;
                            iAct = iAct - 1;
                            cambiarDirecionMasDe2();
                        } else {
                            this.y -= this.velocidad;
                        }
                        break;
                    case 2:
                        if (this.estado == 1) {
                            this.imgActual = this.imgAbajo[setImagen()];
                        } else if (this.estado == 2) {
                            this.imgActual = this.imgVulnerable[setImagen()];
                        }

                        if ((this.y + this.velocidad) > mapaActual.MatrizDiseño[iAct + 1, jAct].Y) {
                            this.y = mapaActual.MatrizDiseño[iAct + 1, jAct].Y;
                            iAct = iAct + 1;
                            cambiarDirecionMasDe2();
                        } else {
                            this.y += this.velocidad;
                        }
                        break;
                    case 3:
                        if (this.estado == 1) {
                            this.imgActual = this.imgDerecha[setImagen()];
                        } else if (this.estado == 2) {
                            this.imgActual = this.imgVulnerable[setImagen()];
                        }

                        if ((this.x + this.velocidad) > mapaActual.MatrizDiseño[iAct, jAct + 1].X) {
                            this.x = mapaActual.MatrizDiseño[iAct, jAct + 1].X;
                            jAct = jAct + 1;
                            cambiarDirecionMasDe2();
                        } else {
                            this.x += this.velocidad;
                        }
                        break;
                    case 4:
                        if (this.estado == 1) {
                            this.imgActual = this.imgIzquierda[setImagen()];
                        } else if (this.estado == 2) {
                            this.imgActual = this.imgVulnerable[setImagen()];
                        }

                        if ((this.x - this.velocidad) < mapaActual.MatrizDiseño[iAct, jAct - 1].X) {
                            this.x = mapaActual.MatrizDiseño[iAct, jAct - 1].X;
                            jAct = jAct - 1;
                            cambiarDirecionMasDe2();
                        } else {
                            this.x -= this.velocidad;
                        }
                        break;
                }
            } else {
                this.cambiarDirecion();
            }
        }

        /// <summary>
        /// Vuelve al fantasma vulnerable
        /// </summary>
        public void volverVulnerable() {
            this.estado = 2;
        }

        /// <summary>
        /// Quita la vulnerabilidad al fantasma
        /// </summary>
        public void quitarVulnerabilidad() {
            this.estado = 1;
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo iAct
        /// </summary>
        public int IAct {
            get { return iAct; }
            set { iAct = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo jAct
        /// </summary>
        public int JAct {
            get { return jAct; }
            set { jAct = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo mapaActual
        /// </summary>
        public Mapa MapaActual {
            get { return mapaActual; }
            set { mapaActual = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo dificultad
        /// </summary>
        public int Dificultad {
            get { return dificultad; }
            set { dificultad = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo nivel
        /// </summary>
        public int Nivel {
            get { return nivel; }
            set { nivel = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo velocidad
        /// </summary>
        public int Velocidad {
            get { return velocidad; }
            set { velocidad = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Y
        /// </summary>
        public int Y {
            get { return y; }
            set { y = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo X
        /// </summary>
        public int X {
            get { return x; }
            set { x = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo height
        /// </summary>
        public int Height {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo width
        /// </summary>
        public int Windth {
            get { return windth; }
            set { windth = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo nombreFantasma
        /// </summary>
        public string nomreFantasma {
            get { return nombreFantasma; }
            set { nombreFantasma = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo poder
        /// </summary>
        public int Poder {
            get { return poder; }
            set { poder = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo randCambairDir
        /// </summary>
        public Random RandCambairDir {
            get { return randCambairDir; }
            set { randCambairDir = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo estado
        /// </summary>
        public int Estado {
            get { return estado; }
            set { estado = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Direccion
        /// </summary>
        public int Direccion {
            get { return direccion; }
            set { direccion = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo imgActual
        /// </summary>
        public Image ImgActual {
            get { return imgActual; }
            set { imgActual = value; }
        }
    }
}
