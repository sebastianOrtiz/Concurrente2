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
        private Mapa mapaActual;
        //private List<Mapa> listaDeMapaslvl1;
        //private List<Mapa> listaDeMapaslvl2;
        //private List<Mapa> listaDeMapaslvl3;
        //private Mapa lvl1;
        //private Mapa lvl2;
        //private Mapa lvl3;
        private string dificultad;
        private DatosJugador datosJugador;
        private Boolean entradaPorVoz;
        private List<Fantasma> fantasmasLvl1;
        //private List<Fantasma> fantasmasLvl2;
        //private List<Fantasma> fantasmasLvl3;
        private PacMan pacMan;
        private int nivelActual;
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
        public Juego(Mapa mapa, String dificultad, DatosJugador jugador, Boolean entradaVoz, int vidasPac, int hpPac) {
            //this.listaDeMapaslvl1 = new List<Mapa>();
            //this.listaDeMapaslvl2 = new List<Mapa>();
            //this.listaDeMapaslvl3 = new List<Mapa>();
            this.mapaActual = mapa;
            this.fantasmasLvl1 = new List<Fantasma>();
            //this.fantasmasLvl2 = new List<Fantasma>();
            //this.fantasmasLvl3 = new List<Fantasma>();
            //this.separarMapasPorNivel(mapas);
            this.dificultad = dificultad;
            this.datosJugador = jugador;
            this.entradaPorVoz = entradaVoz;
            this.nivelActual = 1;
            this.r = new Random();
            this.configurarJuego(vidasPac, hpPac);
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

        /// <summary>
        /// Cambia el nivel del juego, cambia el mapa y demas banderas de estado
        /// </summary>
        //public void cambiarNivel() {
        //    this.nivelActual++;
        //    if (this.nivelActual == 4) {
        //        this.jugando = 2;
        //    } else {
        //        this.mapaActual = this.siguienteNivel();
        //        this.hubicarComodines();
        //        this.pacMan.cambiarNivel(this.mapaActual, this.velocidadMayor());
        //        this.tiempoAumentoVel = 0;
        //        this.tiempoFantasmasVulnerables = 0;
        //        this.tiempoFrutilla = 0;
        //        this.tiempoFrutaViva = 0;
        //        rehubicarPacman();

        //    }

        //}


        /// <summary>
        /// Evalua si aun hay galletas en el tablero actual
        /// </summary>
        /// <returns>Retorna un valor true si aun hay galletas en el tablero</returns>
        private Boolean hayBiscochos() {
            foreach (Celda cel in this.mapaActual.MatrizDiseño) {
                if (cel.Bisc != null && cel.Bisc.Estado) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Evalua el nivel actual y asigna el nuevo tablero
        /// </summary>
        /// <returns>Retorna el tablero del siguiente nivel</returns>
        //private Mapa siguienteNivel() {
        //    Mapa m = lvl3;
        //    switch (this.nivelActual) {
        //        case 1:
        //            m = lvl1;
        //            break;
        //        case 2:
        //            m = lvl2;
        //            break;
        //        case 3:
        //            m = lvl3;
        //            break;
        //    }
        //    return m;

        //}

        /// <summary>
        /// Calcula intersecciones entre el PacMan y un fantasma ejecutando acciones dependiendo del estado del fantasma
        /// </summary>
        /// <param name="fant">Fantasma al que se le evaluara la colision</param>
        private void interseccionPacmanFantasma(Fantasma fant) {
            //Colision por la izquierda
            if ((this.pacMan.X <= (fant.X + fant.Windth) && (this.pacMan.X + 10) >= (fant.X + fant.Windth)) && (this.pacMan.Y >= fant.Y && this.pacMan.Y <= fant.Y + fant.Height || this.pacMan.Y + this.pacMan.Height >= fant.Y && this.pacMan.Y <= fant.Y + fant.Height)) {
                if (fant.Estado == 2) {
                    this.rehubicarFantasmas(fant);
                    fant.quitarVulnerabilidad();
                } else {
                    this.rehubicarPacman();
                    if (this.pacMan.disminuirVida(fant.Poder) <= 0) {
                        this.jugando = 3;
                    }
                }
                sonido(2);

            } //Colision por la derecha
            else if (((this.pacMan.X + this.pacMan.Windth) >= fant.X && (this.pacMan.X + this.pacMan.Windth - 10) <= fant.X) && (this.pacMan.Y >= fant.Y && this.pacMan.Y <= fant.Y + fant.Height || this.pacMan.Y + this.pacMan.Height >= fant.Y && this.pacMan.Y <= fant.Y + fant.Height)) {
                if (fant.Estado == 2) {
                    this.rehubicarFantasmas(fant);
                    fant.quitarVulnerabilidad();
                } else {
                    this.rehubicarPacman();
                    if (this.pacMan.disminuirVida(fant.Poder) <= 0) {
                        this.jugando = 3;
                    }
                }
                sonido(2);
            } //Colision por la arriba
            else if ((this.pacMan.Y <= (fant.Y + fant.Height) && (this.pacMan.Y + 10) >= (fant.Y + fant.Height)) && (this.pacMan.X >= fant.X && this.pacMan.X <= fant.X + fant.Windth || this.pacMan.X + this.pacMan.Windth >= fant.X && this.pacMan.X <= fant.X + fant.Windth)) {
                if (fant.Estado == 2) {
                    this.rehubicarFantasmas(fant);
                    fant.quitarVulnerabilidad();
                } else {
                    this.rehubicarPacman();
                    if (this.pacMan.disminuirVida(fant.Poder) <= 0) {
                        this.jugando = 3;
                    }
                }
                sonido(2);
            } //Colision por la abajo
            else if (((this.pacMan.Y + this.pacMan.Height) >= fant.Y && (this.pacMan.Y + this.pacMan.Height - 10) <= fant.Y) && (this.pacMan.X >= fant.X && this.pacMan.X <= fant.X + fant.Windth || this.pacMan.X + this.pacMan.Windth >= fant.X && this.pacMan.X <= fant.X + fant.Windth)) {
                if (fant.Estado == 2) {

                    this.rehubicarFantasmas(fant);
                    fant.quitarVulnerabilidad();

                } else {
                    this.rehubicarPacman();
                    if (this.pacMan.disminuirVida(fant.Poder) <= 0) {
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
            foreach (Fantasma fantasma in this.fantasmasLvl1) {
                this.interseccionPacmanFantasma(fantasma);
            }
        }

        /// <summary>
        /// Aumenta la velocidad de todos los fantasmas y pacman
        /// </summary>
        private void aumentarVelocidad() {
            foreach (Fantasma fantasma in this.fantasmasLvl1) {
                fantasma.aumentarVelocidad();
            }
            this.pacMan.aumentarVelocidad();
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
            foreach (Fantasma fantasma in this.fantasmasLvl1) {
                fantasma.volverVulnerable();
            }
        }


        /// <summary>
        /// Vuelve a los fantasmas a la normalidad una evz se acaba el tiempo
        /// </summary>
        private void quitarVulnerables() {
            foreach (Fantasma fantasma in this.fantasmasLvl1) {
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
                this.pacMan.mover();
                if (mapaActual.MatrizDiseño[this.pacMan.IAct, this.pacMan.JAct].Bisc != null && mapaActual.MatrizDiseño[this.pacMan.IAct, this.pacMan.JAct].Bisc.Estado) {
                    if (mapaActual.MatrizDiseño[this.pacMan.IAct, this.pacMan.JAct].Bisc.Tipo == 3) {
                        sonido(4);
                        this.datosJugador.aumentarPuntaje(100);
                    } else if (mapaActual.MatrizDiseño[this.pacMan.IAct, this.pacMan.JAct].Bisc.Tipo == 2) {
                        sonido(3);
                        this.datosJugador.aumentarPuntaje(this.pacMan.Velocidad * this.nivelActual);
                        this.tiempoFantasmasVulnerables = 0;
                        this.tiempoFantasmasVulnerables++;
                        this.volverVulnerables();
                    } else if (mapaActual.MatrizDiseño[this.pacMan.IAct, this.pacMan.JAct].Bisc.Tipo == 1) {
                        sonido(1);
                        this.datosJugador.aumentarPuntaje(this.pacMan.Velocidad * this.nivelActual);
                    }

                    mapaActual.MatrizDiseño[this.pacMan.IAct, this.pacMan.JAct].Bisc.Estado = false;

                }
                this.evaluarColisiones();


                foreach (Fantasma fantasma in this.fantasmasLvl1) {
                    fantasma.mover();
                }

            } else {
                //this.cambiarNivel();
            }

        }

        /// <summary>
        /// Metodo que llama a una iteracion de juego
        /// </summary>
        public void actualizar() {
            this.iteracionLoopDelJuego();
        }

        /// <summary>
        /// Separa los mapas que llegan a juego por nivel para un facil manejo
        /// </summary>
        /// <param name="mapasAOrganizar">Lista de mapas que entran al juego</param>
        //private void separarMapasPorNivel(List<Mapa> mapasAOrganizar) {
        //    foreach (Mapa map in mapasAOrganizar) {
        //        if (map.Nivel == 1) {
        //            listaDeMapaslvl1.Add(map);
        //        } else if (map.Nivel == 2) {
        //            listaDeMapaslvl2.Add(map);
        //        } else if (map.Nivel == 3) {
        //            listaDeMapaslvl3.Add(map);
        //        }

        //    }
        //}

        /// <summary>
        /// Hace la configuracion basica del juego, crea los fantasmas y les da posiciones iniciales al igualq ue al pacman, crea las galletas y hubica los comodines
        /// </summary>
        /// <param name="vid"></param>
        /// <param name="hp"></param>
        private void configurarJuego(int vid, int hp) {
            if (this.mapaActual != null) {
                Random rdm = new Random();
                //Lvl1 = listaDeMapaslvl1.ElementAt(rdm.Next(0, listaDeMapaslvl1.Count));
                //Lvl2 = listaDeMapaslvl2.ElementAt(rdm.Next(0, listaDeMapaslvl2.Count));
                //Lvl3 = listaDeMapaslvl3.ElementAt(rdm.Next(0, listaDeMapaslvl3.Count));


                //mapaActual = Lvl1;

                Point[] centro = mapaActual.posicionInicalFantasmas();
                int dirSalida = mapaActual.direccionDeSalidaDelFantasma();
                //Point[] centrolvl2 = Lvl2.posicionInicalFantasmas();
                //int dirSalidalvl2 = Lvl2.direccionDeSalidaDelFantasma();
                //Point[] centrolvl3 = Lvl3.posicionInicalFantasmas();
                //int dirSalidalvl3 = Lvl3.direccionDeSalidaDelFantasma();

                switch (this.dificultad) {
                    case "Facil":
                        //Fantasmas del nivel 1: 1 Rojo, 1 Rosa, 1 Naranja, 2 Azul
                        fantasmasLvl1.Add(new Fantasma(dirSalida, "Rojo", 19, centro[1].X, centro[1].Y, 1, this.dificultad, mapaActual, centro[0].X, centro[0].Y));
                        fantasmasLvl1.Add(new Fantasma(dirSalida, "Rosa", 19, centro[1].X, centro[1].Y, 1, this.dificultad, mapaActual, centro[0].X, centro[0].Y));
                        fantasmasLvl1.Add(new Fantasma(dirSalida, "Naranja", 19, centro[1].X, centro[1].Y, 1, this.dificultad, mapaActual, centro[0].X, centro[0].Y));
                        for (int i = 0; i < 2; i++) {
                            fantasmasLvl1.Add(new Fantasma(dirSalida, "Azul", 19, centro[1].X, centro[1].Y, 1, this.dificultad, mapaActual, centro[0].X, centro[0].Y));
                        }
                        break;
                    case "Medio":
                        //Fantasmas del nivel 2: 2 Rojo, 2 Rosa, 2 Naranja, 2 Azul
                        for (int i = 0; i < 2; i++) {
                            fantasmasLvl1.Add(new Fantasma(dirSalida, "Rojo", 19, centro[1].X, centro[1].Y, 1, this.dificultad, mapaActual, centro[0].X, centro[0].Y));
                            fantasmasLvl1.Add(new Fantasma(dirSalida, "Rosa", 19, centro[1].X, centro[1].Y, 1, this.dificultad, mapaActual, centro[0].X, centro[0].Y));
                            fantasmasLvl1.Add(new Fantasma(dirSalida, "Naranja", 19, centro[1].X, centro[1].Y, 1, this.dificultad, mapaActual, centro[0].X, centro[0].Y));
                            fantasmasLvl1.Add(new Fantasma(dirSalida, "Azul", 19, centro[1].X, centro[1].Y, 1, this.dificultad, mapaActual, centro[0].X, centro[0].Y));
                        }
                        break;
                    case "Dificil":
                        //Fantasmas del nivel 3: 2 Rojo, 2 Rosa, 3 Naranja, 3 Azul
                        for (int i = 0; i < 2; i++) {
                            fantasmasLvl1.Add(new Fantasma(dirSalida, "Rojo", 19, centro[1].X, centro[1].Y, 1, this.dificultad, mapaActual, centro[0].X, centro[0].Y));
                            fantasmasLvl1.Add(new Fantasma(dirSalida, "Rosa", 19, centro[1].X, centro[1].Y, 1, this.dificultad, mapaActual, centro[0].X, centro[0].Y));
                        }
                        for (int i = 0; i < 3; i++) {
                            fantasmasLvl1.Add(new Fantasma(dirSalida, "Naranja", 19, centro[1].X, centro[1].Y, 1, this.dificultad, mapaActual, centro[0].X, centro[0].Y));
                            fantasmasLvl1.Add(new Fantasma(dirSalida, "Azul", 19, centro[1].X, centro[1].Y, 1, this.dificultad, mapaActual, centro[0].X, centro[0].Y));
                        }
                        break;
                }



                hubicarPacmanEnMapaActualInicial(vid, hp);
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

            int filasAct = mapaActual.Filas;
            int columnasAct = mapaActual.Columnas;
            while (cantComodines > 0) {
                int ni = this.r.Next(filasAct);
                int nj = this.r.Next(columnasAct);
                if (this.mapaActual.MatrizDiseño[ni, nj].SePuedePasar && this.mapaActual.MatrizDiseño[ni, nj].Bisc.Tipo == 1) {
                    this.mapaActual.MatrizDiseño[ni, nj].Bisc.cambiarATipo2();
                    cantComodines--;
                }
            }

        }

        /// <summary>
        /// Desaparece la fruta cuando se cumple el tiempo
        /// </summary>
        public void quitarFrutilla() {
            mapaActual.MatrizDiseño[iFrut, jFrut].Bisc.Estado = false;
        }

        /// <summary>
        /// Hubica una fruta aleatoriamente entre los espacio vacios del mapa
        /// </summary>
        public void hubicarFrutilla() {
            int filasAct = mapaActual.Filas;
            int columnasAct = mapaActual.Columnas;
            List<Point> posibles = new List<Point>();

            for (int i = 0; i < filasAct; i++) {
                for (int j = 0; j < columnasAct; j++) {
                    if (!mapaActual.MatrizDiseño[i, j].Valor.Equals("Y") && mapaActual.MatrizDiseño[i, j].Bisc != null && !mapaActual.MatrizDiseño[i, j].Bisc.Estado) {
                        posibles.Add(new Point(i, j));
                    }
                }
            }
            Point p = posibles.ElementAt(r.Next(0, posibles.Count));
            this.iFrut = p.X;
            this.jFrut = p.Y;
            mapaActual.MatrizDiseño[iFrut, jFrut].Bisc.cambiarATipo3(mapaActual.MatrizDiseño[iFrut, jFrut].X, mapaActual.MatrizDiseño[iFrut, jFrut].Y);

        }

        /// <summary>
        /// Da la posicion inicial al pacman
        /// </summary>
        /// <param name="vidas">Cantidad de vidas de PacMan</param>
        /// <param name="hp">Valor de cada Vida de PacMan</param>
        private void hubicarPacmanEnMapaActualInicial(int vidas, int hp) {
            Point[] posCaman = mapaActual.posicionInicialPacMan();
            posFrut = posCaman[0];
            //mapaActual.MatrizDiseño[posFrut.X, posFrut.Y].Bisc.Estado = false;
            pacMan = new PacMan(19, posCaman[1].X, posCaman[1].Y, this.velocidadMayor(), this.NivelActual, mapaActual, vidas, hp, posCaman[0].X, posCaman[0].Y);
        }

        /// <summary>
        /// Calcula la mayor velocidad de los fantasmas la cual sera la velocidad de Pacman
        /// </summary>
        /// <returns>Retorna la mayor velocidad</returns>
        private int velocidadMayor() {
            int vel = fantasmasLvl1.ElementAt(0).Velocidad;
            return vel;
        }

        /// <summary>
        /// Rehubica un fantasma en la posicion central del mapa
        /// </summary>
        /// <param name="fant">Fantasma a rehubicar</param>
        private void rehubicarFantasmas(Fantasma fant) {
            Point[] cords = mapaActual.posicionInicalFantasmas();
            fant.IAct = cords[0].X;
            fant.JAct = cords[0].Y;
            fant.X = cords[1].X;
            fant.Y = cords[1].Y;
        }

        /// <summary>
        /// Rehubica a PacMan en su posicion inicial
        /// </summary>
        private void rehubicarPacman() {
            pacMan.vaciarOrdenes();
            Point[] posCaman = mapaActual.posicionInicialPacMan();
            pacMan.IAct = posCaman[0].X;
            pacMan.JAct = posCaman[0].Y;
            pacMan.X = posCaman[1].X;
            pacMan.Y = posCaman[1].Y;
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo nivelActual
        /// </summary>
        public int NivelActual {
            get { return nivelActual; }
            set { nivelActual = value; }
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
        internal PacMan PacMan {
            get { return pacMan; }
            set { pacMan = value; }
        }


        /// <summary>
        /// Metodo accesor y mutador del atributo FantasmasLvl1
        /// </summary>
        public List<Fantasma> FantasmasLvl1 {
            get { return fantasmasLvl1; }
            set { fantasmasLvl1 = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo EntradaPorVoz 
        /// </summary>
        public Boolean EntradaPorVoz {
            get { return entradaPorVoz; }
            set { entradaPorVoz = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo DatosJugador
        /// </summary>
        public DatosJugador DatosJugador {
            get { return datosJugador; }
            set { datosJugador = value; }
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
        /// Metodo accesor y mutador del atributo MapaActual
        /// </summary>
        public Mapa MapaActual {
            get { return mapaActual; }
            set { mapaActual = value; }
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
