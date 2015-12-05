using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Media;

namespace PACMANv3.pkgModelo {
    /// <summary>
    /// Clase juego que representa un juego con una dificultad y un jugador definidos
    /// </summary>
    public class Juego {
        private Mapa mapa;
        private string dificultad;
        private List<Fantasma> fantasmas;
        private List<PacMan> pacMans;

        private Boolean estadoDelJuego;
        private int jugando; //1 jugando, 2 gano, 3 perdio
        private Random r;
        private int segundos;
        private Point posFrut;
        private int tiempoFantasmasVulnerables;
        private int tiempoAumentoVel;
        private int tiempoFrutilla;
        private int tiempoFrutaViva;
        private SoundPlayer reproductor;
        private int iFrut;
        private int jFrut;
        private int jugadores;
        //KMZWA8AWAA
        /// <summary>
        /// Constructor de la clase Juego
        /// </summary>
        /// <param name="mapas">Lista de mapas que se usaran en el juego</param>
        /// <param name="dificultad">Dificultad de juego</param>
        /// <param name="jugador">Datos del jugador</param>
        /// <param name="entradaVoz">Vaor booleano que indica el metodo de entrada del juego (Voz o teclado)</param>
        /// <param name="vidasPac">Vidas del jugador</param>
        /// <param name="hpPac">Valor de cada vida del Jugador</param>
        public Juego(Mapa mapa, String dificultad, int jugadores) {
            this.mapa = mapa;
            this.fantasmas = new List<Fantasma>();
            this.pacMans = new List<PacMan>();
            this.dificultad = dificultad;
            this.jugadores = jugadores;
            this.r = new Random();
            this.configurarJuego();
            this.estadoDelJuego = true;
            this.jugando = 1;
            this.tiempoFantasmasVulnerables = 0;
            this.tiempoAumentoVel = 0;
            this.tiempoFrutilla = 0;
            this.tiempoFrutaViva = 0;
            this.segundos = 0;
            this.iFrut = -1;
            this.jFrut = -1;

        }

        public Biscocho[,] obtenerBiscochos() {
            Biscocho[,] biscochos = new Biscocho[mapa.Filas, mapa.Columnas];
            for (int i = 0; i < mapa.Filas; i++) {
                for (int j = 0; j < mapa.Columnas; j++) {
                    biscochos[i, j] = mapa.MatrizDiseño[i, j].Bisc;
                }
            }
            return biscochos;
        }

        public Estado generarEstado() {
            Estado nuevoEstado = new Estado(this.pacMans, this.fantasmas, this.obtenerBiscochos());
            return nuevoEstado;
        }
        /// <summary>
        /// Evalua si aun hay galletas en el tablero actual
        /// </summary>
        /// <returns>Retorna un valor true si aun hay galletas en el tablero</returns>
        private Boolean hayBiscochos() {
            foreach (Celda cel in this.mapa.MatrizDiseño) {
                if (cel.Bisc != null && cel.Bisc.Estado) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Calcula intersecciones entre el PacMan y un fantasma ejecutando acciones dependiendo del estado del fantasma
        /// </summary>
        /// <param name="fant">Fantasma al que se le evaluara la colision</param>
        private void interseccionPacmanFantasma(Fantasma fant, PacMan pac) {
            //Colision por la izquierda
            if ((pac.X <= (fant.X + fant.Windth) && (pac.X + 10) >= (fant.X + fant.Windth)) && (pac.Y >= fant.Y && pac.Y <= fant.Y + fant.Height || pac.Y + pac.Height >= fant.Y && pac.Y <= fant.Y + fant.Height)) {
                if (fant.Estado == 2) {
                    this.rehubicarFantasmas(fant);
                    fant.quitarVulnerabilidad();
                } else {
                    this.rehubicarPacman(pac);
                    if (pac.disminuirVida(fant.Poder) <= 0) {
                        this.jugando = 3;
                    }
                }
                sonido(2);

            } //Colision por la derecha
            else if (((pac.X + pac.Windth) >= fant.X && (pac.X + pac.Windth - 10) <= fant.X) && (pac.Y >= fant.Y && pac.Y <= fant.Y + fant.Height || pac.Y + pac.Height >= fant.Y && pac.Y <= fant.Y + fant.Height)) {
                if (fant.Estado == 2) {
                    this.rehubicarFantasmas(fant);
                    fant.quitarVulnerabilidad();
                } else {
                    this.rehubicarPacman(pac);
                    if (pac.disminuirVida(fant.Poder) <= 0) {
                        this.jugando = 3;
                    }
                }
                sonido(2);
            } //Colision por la arriba
            else if ((pac.Y <= (fant.Y + fant.Height) && (pac.Y + 10) >= (fant.Y + fant.Height)) && (pac.X >= fant.X && pac.X <= fant.X + fant.Windth || pac.X + pac.Windth >= fant.X && pac.X <= fant.X + fant.Windth)) {
                if (fant.Estado == 2) {
                    this.rehubicarFantasmas(fant);
                    fant.quitarVulnerabilidad();
                } else {
                    this.rehubicarPacman(pac);
                    if (pac.disminuirVida(fant.Poder) <= 0) {
                        this.jugando = 3;
                    }
                }
                sonido(2);
            } //Colision por la abajo
            else if (((pac.Y + pac.Height) >= fant.Y && (pac.Y + pac.Height - 10) <= fant.Y) && (pac.X >= fant.X && pac.X <= fant.X + fant.Windth || pac.X + pac.Windth >= fant.X && pac.X <= fant.X + fant.Windth)) {
                if (fant.Estado == 2) {

                    this.rehubicarFantasmas(fant);
                    fant.quitarVulnerabilidad();

                } else {
                    this.rehubicarPacman(pac);
                    if (pac.disminuirVida(fant.Poder) <= 0) {
                        this.jugando = 3;
                    }
                }
                sonido(2);
            }
        }

        /// <summary>
        /// Evalua todas las colisiones del PacMan con los fantasmas
        /// </summary>
        private void evaluarColisiones() {
            foreach (Fantasma fantasma in this.fantasmas) {
                foreach (PacMan pacman in this.pacMans) {
                    this.interseccionPacmanFantasma(fantasma, pacman);
                }
            }
        }

        /// <summary>
        /// Aumenta la velocidad de todos los fantasmas y pacman
        /// </summary>
        private void aumentarVelocidad() {
            foreach (Fantasma fantasma in this.fantasmas) {
                fantasma.aumentarVelocidad();
            }
            foreach (PacMan pacman in this.pacMans) {
                pacman.aumentarVelocidad();
            }

        }

        /// <summary>
        /// Aumenta el tiempo de juego actual ademas de otras variables que indican diferentes eventos en el juego
        /// </summary>
        public void aumentarSegundos() {
            while (this.estadoDelJuego) {
                this.segundos++;
                this.tiempoAumentoVel++;
                this.tiempoFrutilla++;
                if (this.tiempoFantasmasVulnerables > 0 && this.tiempoFantasmasVulnerables < 11) {
                    this.tiempoFantasmasVulnerables++;
                } else {
                    this.tiempoFantasmasVulnerables = 0;
                    this.quitarVulnerables();
                }
                if (tiempoAumentoVel == 30) {
                    this.aumentarVelocidad();
                    tiempoAumentoVel = 0;
                }
                if (tiempoFrutilla == 60) {
                    hubicarFrutilla();
                    tiempoFrutaViva++;
                    tiempoFrutilla = 0;
                    sonido(3);
                }
                if (tiempoFrutaViva > 0 && tiempoFrutaViva < 11) {
                    tiempoFrutaViva++;
                    if (tiempoFrutaViva == 11) {
                        tiempoFrutaViva = 0;
                        quitarFrutilla();
                    }
                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Crea una representacion en forma de cadena del tiempo de juego el tiempo restante para el aumento de velocidad y el tiempo que los fantasmas estan vulnerables
        /// </summary>
        /// <returns>Retorna una cadena de texto</returns>
        public String obtenerTiempo() {
            String tiempo = "";
            if ((this.segundos / 60) / 10 < 1) {
                tiempo = "0" + (this.segundos / 60) + ":";
            } else {
                tiempo = (this.segundos / 60) + ":";
            }
            if ((this.segundos % 60) / 10 < 1) {
                tiempo += "0" + this.segundos % 60;
            } else {
                tiempo += this.segundos % 60;
            }
            tiempo += "\nAumento de velocidad en: " + (30 - tiempoAumentoVel);
            if (tiempoFantasmasVulnerables > 0) {
                tiempo += "\nVulerables durante: " + (11 - tiempoFantasmasVulnerables);
            }
            return tiempo;
        }

        /// <summary>
        /// Vuelve vulnerables a los fantasmas cuando pacman come una super galleta
        /// </summary>
        private void volverVulnerables() {
            foreach (Fantasma fantasma in this.fantasmas) {
                fantasma.volverVulnerable();
            }
        }


        /// <summary>
        /// Vuelve a los fantasmas a la normalidad una evz se acaba el tiempo
        /// </summary>
        private void quitarVulnerables() {
            foreach (Fantasma fantasma in this.fantasmas) {
                fantasma.quitarVulnerabilidad();
            }
        }

        /// <summary>
        /// Reproduce un sonido dependiendo el valor ingresado
        /// </summary>
        /// <param name="n">indica el sonido que se desea reproducir 1- comer galleta normal, 2- colision entre fantasma y pacman, 3- comer super galleta y salida de fruta, 4- comer una fruta</param>
        private void sonido(int n) {
            this.reproductor = new SoundPlayer();
            switch (n) {
                case 1:
                    this.reproductor = new SoundPlayer(Properties.Resources.bomb);
                    break;
                case 2:
                    this.reproductor = new SoundPlayer(Properties.Resources.corte);
                    break;
                case 3:
                    this.reproductor = new SoundPlayer(Properties.Resources.superPastilla);
                    break;
                case 4:
                    this.reproductor = new SoundPlayer(Properties.Resources.soundFrutilla);
                    break;
            }

            this.reproductor.Load();
            this.reproductor.Play();
        }

        /// <summary>
        /// Ejecuta todas las acciones que se hacen en una sola iteracion de juego, mover a los fantasmas y pacman, evaluar colisiones cambiar posicions comer galletas
        /// </summary>
        public void iteracionLoopDelJuego() {
            if (this.jugando == 1 && this.hayBiscochos()) {
                this.moverPacMans();
                foreach (PacMan pacman in this.pacMans) {
                    if (mapa.MatrizDiseño[pacman.IAct, pacman.JAct].Bisc != null && mapa.MatrizDiseño[pacman.IAct, pacman.JAct].Bisc.Estado) {
                        if (mapa.MatrizDiseño[pacman.IAct, pacman.JAct].Bisc.Tipo == 3) {
                            sonido(4);
                            pacman.aumentarPuntaje(100);
                        } else if (mapa.MatrizDiseño[pacman.IAct, pacman.JAct].Bisc.Tipo == 2) {
                            sonido(3);
                            pacman.aumentarPuntaje(pacman.Velocidad * 2);
                            this.tiempoFantasmasVulnerables = 0;
                            this.tiempoFantasmasVulnerables++;
                            this.volverVulnerables();
                        } else if (mapa.MatrizDiseño[pacman.IAct, pacman.JAct].Bisc.Tipo == 1) {
                            sonido(1);
                            pacman.aumentarPuntaje(pacman.Velocidad * 2);
                        }

                        mapa.MatrizDiseño[pacman.IAct, pacman.JAct].Bisc.Estado = false;

                    }
                    this.evaluarColisiones();
                    this.moverFantasmas();
                }


            } else {

            }

        }

        private void moverFantasmas() {
            foreach (Fantasma fantasma in this.fantasmas) {
                fantasma.mover();
            }
        }

        private void moverPacMans() {
            foreach (PacMan pacman in this.pacMans) {
                pacman.mover();
            }
        }
        /// <summary>
        /// Metodo que llama a una iteracion de juego
        /// </summary>
        public void actualizar() {
            this.iteracionLoopDelJuego();
        }

        /// <summary>
        /// Hace la configuracion basica del juego, crea los fantasmas y les da posiciones iniciales al igualq ue al pacman, crea las galletas y hubica los comodines
        /// </summary>
        /// <param name="vid"></param>
        /// <param name="hp"></param>
        private void configurarJuego() {
            if (this.mapa != null) {
                Random rdm = new Random();
                Point[] centro = mapa.posicionInicalFantasmas();
                int dirSalida = mapa.direccionDeSalidaDelFantasma();
                switch (this.dificultad) {
                    case "Facil":
                        //Fantasmas del nivel Facl: 1 Rojo, 1 Rosa, 1 Naranja, 2 Azul
                        fantasmas.Add(new Fantasma(dirSalida, "Rojo", 19, centro[1].X, centro[1].Y, this.dificultad, mapa, centro[0].X, centro[0].Y));
                        fantasmas.Add(new Fantasma(dirSalida, "Rosa", 19, centro[1].X, centro[1].Y, this.dificultad, mapa, centro[0].X, centro[0].Y));
                        fantasmas.Add(new Fantasma(dirSalida, "Naranja", 19, centro[1].X, centro[1].Y, this.dificultad, mapa, centro[0].X, centro[0].Y));
                        for (int i = 0; i < 2; i++) {
                            fantasmas.Add(new Fantasma(dirSalida, "Azul", 19, centro[1].X, centro[1].Y, this.dificultad, mapa, centro[0].X, centro[0].Y));
                        }
                        break;
                    case "Medio":
                        //Fantasmas del nivel Medio: 2 Rojo, 2 Rosa, 2 Naranja, 2 Azul
                        for (int i = 0; i < 2; i++) {
                            fantasmas.Add(new Fantasma(dirSalida, "Rojo", 19, centro[1].X, centro[1].Y, this.dificultad, mapa, centro[0].X, centro[0].Y));
                            fantasmas.Add(new Fantasma(dirSalida, "Rosa", 19, centro[1].X, centro[1].Y, this.dificultad, mapa, centro[0].X, centro[0].Y));
                            fantasmas.Add(new Fantasma(dirSalida, "Naranja", 19, centro[1].X, centro[1].Y, this.dificultad, mapa, centro[0].X, centro[0].Y));
                            fantasmas.Add(new Fantasma(dirSalida, "Azul", 19, centro[1].X, centro[1].Y, this.dificultad, mapa, centro[0].X, centro[0].Y));
                        }
                        break;
                    case "Dificil":
                        //Fantasmas del nivel Dificl: 2 Rojo, 2 Rosa, 3 Naranja, 3 Azul
                        for (int i = 0; i < 2; i++) {
                            fantasmas.Add(new Fantasma(dirSalida, "Rojo", 19, centro[1].X, centro[1].Y, this.dificultad, mapa, centro[0].X, centro[0].Y));
                            fantasmas.Add(new Fantasma(dirSalida, "Rosa", 19, centro[1].X, centro[1].Y, this.dificultad, mapa, centro[0].X, centro[0].Y));
                        }
                        for (int i = 0; i < 3; i++) {
                            fantasmas.Add(new Fantasma(dirSalida, "Naranja", 19, centro[1].X, centro[1].Y, this.dificultad, mapa, centro[0].X, centro[0].Y));
                            fantasmas.Add(new Fantasma(dirSalida, "Azul", 19, centro[1].X, centro[1].Y, this.dificultad, mapa, centro[0].X, centro[0].Y));
                        }
                        break;
                }



                Point[] posCaman = mapa.posicionInicialPacMan();
                posFrut = posCaman[0];
                //mapaActual.MatrizDiseño[posFrut.X, posFrut.Y].Bisc.Estado = false;
                for (int i = 0; i < jugadores; i++) {
                    pacMans.Add(new PacMan(19, posCaman[1].X, posCaman[1].Y, this.velocidadMayor(), 1, mapa, 5, 5, posCaman[0].X, posCaman[0].Y,(i+1)));
                    
                }
                hubicarComodines();
            } else {

            }
        }

        /// <summary>
        /// Metodo que hubica aleatoriamente comodines en el mapa dependiendo del nive actual de juego
        /// </summary>
        public void hubicarComodines() {
            int cantComodines = 0;
            switch (this.dificultad) {
                case "Facil":
                    cantComodines = 5;
                    break;
                case "Medio":
                    cantComodines = 8;
                    break;
                case "Deficil":
                    cantComodines = 10;
                    break;
            }

            int filasAct = mapa.Filas;
            int columnasAct = mapa.Columnas;
            while (cantComodines > 0) {
                int ni = this.r.Next(filasAct);
                int nj = this.r.Next(columnasAct);
                if (this.mapa.MatrizDiseño[ni, nj].SePuedePasar && this.mapa.MatrizDiseño[ni, nj].Bisc.Tipo == 1) {
                    this.mapa.MatrizDiseño[ni, nj].Bisc.cambiarATipo2();
                    cantComodines--;
                }
            }

        }

        /// <summary>
        /// Desaparece la fruta cuando se cumple el tiempo
        /// </summary>
        public void quitarFrutilla() {
            mapa.MatrizDiseño[iFrut, jFrut].Bisc.Estado = false;
        }

        /// <summary>
        /// Hubica una fruta aleatoriamente entre los espacio vacios del mapa
        /// </summary>
        public void hubicarFrutilla() {
            int filasAct = mapa.Filas;
            int columnasAct = mapa.Columnas;
            List<Point> posibles = new List<Point>();

            for (int i = 0; i < filasAct; i++) {
                for (int j = 0; j < columnasAct; j++) {
                    if (!mapa.MatrizDiseño[i, j].Valor.Equals("Y") && mapa.MatrizDiseño[i, j].Bisc != null && !mapa.MatrizDiseño[i, j].Bisc.Estado) {
                        posibles.Add(new Point(i, j));
                    }
                }
            }
            Point p = posibles.ElementAt(r.Next(0, posibles.Count));
            this.iFrut = p.X;
            this.jFrut = p.Y;
            mapa.MatrizDiseño[iFrut, jFrut].Bisc.cambiarATipo3(mapa.MatrizDiseño[iFrut, jFrut].X, mapa.MatrizDiseño[iFrut, jFrut].Y);

        }

        /// <summary>
        /// Da la posicion inicial al pacman
        /// </summary>
        /// <param name="vidas">Cantidad de vidas de PacMan</param>
        /// <param name="hp">Valor de cada Vida de PacMan</param>
        //private void hubicarPacmanEnMapaActualInicial(int vidas, int hp) {
        //    Point[] posCaman = mapa.posicionInicialPacMan();
        //    posFrut = posCaman[0];
        //    //mapaActual.MatrizDiseño[posFrut.X, posFrut.Y].Bisc.Estado = false;
        //    pacMans.Add(new PacMan(19, posCaman[1].X, posCaman[1].Y, this.velocidadMayor(), 1, mapa, vidas, hp, posCaman[0].X, posCaman[0].Y));
        //}

        /// <summary>
        /// Calcula la mayor velocidad de los fantasmas la cual sera la velocidad de Pacman
        /// </summary>
        /// <returns>Retorna la mayor velocidad</returns>
        private int velocidadMayor() {
            int vel = fantasmas.ElementAt(0).Velocidad;
            return vel;
        }

        /// <summary>
        /// Rehubica un fantasma en la posicion central del mapa
        /// </summary>
        /// <param name="fant">Fantasma a rehubicar</param>
        private void rehubicarFantasmas(Fantasma fant) {
            Point[] cords = mapa.posicionInicalFantasmas();
            fant.IAct = cords[0].X;
            fant.JAct = cords[0].Y;
            fant.X = cords[1].X;
            fant.Y = cords[1].Y;
        }

        /// <summary>
        /// Rehubica a PacMan en su posicion inicial
        /// </summary>
        private void rehubicarPacman(PacMan pacMan) {
            pacMan.vaciarOrdenes();
            Point[] posCaman = mapa.posicionInicialPacMan();
            pacMan.IAct = posCaman[0].X;
            pacMan.JAct = posCaman[0].Y;
            pacMan.X = posCaman[1].X;
            pacMan.Y = posCaman[1].Y;
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo estadoJuego
        /// </summary>
        public Boolean EstadoDelJuego {
            get { return estadoDelJuego; }
            set { estadoDelJuego = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo PacMan
        /// </summary>
        internal List<PacMan> PacMans {
            get { return pacMans; }
            set { pacMans = value; }
        }


        /// <summary>
        /// Metodo accesor y mutador del atributo Fantasmas
        /// </summary>
        public List<Fantasma> Fantasmas {
            get { return fantasmas; }
            set { fantasmas = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Jugando
        /// </summary>
        public int Jugando {
            get { return jugando; }
            set { jugando = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Dificultad
        /// </summary>
        public string Dificultad {
            get { return dificultad; }
            set { dificultad = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Mapa
        /// </summary>
        public Mapa Mapa {
            get { return mapa; }
            set { mapa = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Segundos
        /// </summary>
        public int Segundos {
            get { return segundos; }
            set { segundos = value; }
        }
    }
}
