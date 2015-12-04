using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PACMANv3.pkgModelo;
using System.Reflection;
using System.Speech.Recognition;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Threading;
using System.Drawing.Imaging;

namespace PACMANv3.pkgVista {
    public partial class VistaJuegoOnline : Form {
        private Mapa mapa;
        public static Queue<Estado> colaDeEstados;
        private Estado estadoActual;
        private Image[] imagenPared;
        private Image imgGameOver;
        private Image imgVictoria;
        private Image imgDerrota;
        private Image imgFruta;
        private int jugando;
        private int identificador;
        private Boolean entradaPorVoz;
        private SpeechRecognitionEngine escucha;
        //private List<Estado> mensajes;

        private List<Mapa> listaDeMapas;
        private List<string> nombresDeMapas;

        private Cliente usuario;

        public VistaJuegoOnline() {
            InitializeComponent();

            this.listaDeMapas = new List<Mapa>();
            this.nombresDeMapas = new List<string>();

            colaDeEstados = new Queue<Estado>();
            this.cargarRecursos();
            this.jugando = 1;
            cargarNombresDeMapas();
            cargarMapas();
            generarEstadoActual();
            new Thread(cicloJuego).Start();
        }

        private void cargarNombresDeMapas() {
            StreamReader sr = new StreamReader("./../../ArchivosConf/Config/nombresMapas.conf");
            string linea;
            linea = sr.ReadLine();
            while (linea != null) {
                nombresDeMapas.Add(linea);
                linea = sr.ReadLine();
            }
            sr.Close();
            //this.cargarMapasEnCombobox();
        }

        private void cargarMapas() {
            //LEYENDO JSON
            StreamReader sr;
            foreach (string nombreMapa in nombresDeMapas) {
                sr = File.OpenText("./../../ArchivosConf/Maps/" + nombreMapa + ".map");
                string entrada = sr.ReadToEnd();
                if (entrada != "") {
                    Mapa nMap = JsonConvert.DeserializeObject<Mapa>(entrada);
                    nMap.MatrizDiseño = new Celda[nMap.Filas, nMap.Columnas];
                    nMap.crearMapa();
                    listaDeMapas.Add(nMap);
                }
            }
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

        private void generarEstadoActual() {
            this.mapa = listaDeMapas.ElementAt(0);


            Point[] centro = mapa.posicionInicalFantasmas();
            int dirSalida = mapa.direccionDeSalidaDelFantasma();

            List<Fantasma> fantasmas = new List<Fantasma>();
            for (int i = 0; i < 2; i++) {
                fantasmas.Add(new Fantasma(dirSalida, "Rojo", 19, centro[1].X, centro[1].Y, 1, "Facil", mapa, centro[0].X, centro[0].Y));
                fantasmas.Add(new Fantasma(dirSalida, "Rosa", 19, centro[1].X, centro[1].Y, 1, "Facil", mapa, centro[0].X, centro[0].Y));
                fantasmas.Add(new Fantasma(dirSalida, "Naranja", 19, centro[1].X, centro[1].Y, 1, "Facil", mapa, centro[0].X, centro[0].Y));
                fantasmas.Add(new Fantasma(dirSalida, "Azul", 19, centro[1].X, centro[1].Y, 1, "Facil", mapa, centro[0].X, centro[0].Y));
            }

            for (int i = 0; i < 30; i++) {
                List<PacMan> pacmans = new List<PacMan>();
                Point[] posCaman = this.mapa.posicionInicialPacMan();
                PacMan p = new PacMan(19, posCaman[1].X + i, posCaman[1].Y, 3, 1, mapa, 5, 5, posCaman[0].X, posCaman[0].Y);
                p.Identificador = 0;
                PacMan p1 = new PacMan(19, posCaman[1].X, posCaman[1].Y - i, 3, 1, mapa, 5, 5, posCaman[0].X, posCaman[0].Y);
                p1.Identificador = 1;
                PacMan p2 = new PacMan(19, posCaman[1].X - i, posCaman[1].Y, 3, 1, mapa, 5, 5, posCaman[0].X, posCaman[0].Y);
                p2.Identificador = 2;
                pacmans.Add(p);
                pacmans.Add(p1);
                pacmans.Add(p2);
                Estado est = new Estado(pacmans, fantasmas, obtenerBiscochos());

                colaDeEstados.Enqueue(est);
                //pacmans.ElementAt(0).mover();
            }


            //estadoActual = est;
            //this.graficarPanel();
        }

        private void cargarRecursos() {

            this.imagenPared = new Image[10];
            imagenPared[0] = Properties.Resources.pared1;
            imagenPared[0] = Properties.Resources.pared1;
            imagenPared[1] = Properties.Resources.pared2;
            imagenPared[2] = Properties.Resources.pared3;
            imagenPared[3] = Properties.Resources.pared4;
            imagenPared[4] = Properties.Resources.pared5;
            imagenPared[5] = Properties.Resources.pared6;
            imagenPared[6] = Properties.Resources.pared7;
            imagenPared[7] = Properties.Resources.pared8;
            imagenPared[8] = Properties.Resources.pared9;
            imagenPared[9] = Properties.Resources.pared10;
            imgGameOver = Properties.Resources.gameOver;
            imgVictoria = Properties.Resources.victoria;
            imgDerrota = Properties.Resources.derrota;
            imgFruta = Properties.Resources.fruta;
        }

        //private void refrescarTextos()
        //{
        //    this.lblPuntaje.Text = "Puntos: " + this.Juego.DatosJugador.Puntaje + "";
        //    this.lblOrdenesEnCola.Text = "Ordenes en cola:\n" + this.Juego.PacMans.ElementAt(0).listarOrdenesActuales();
        //    this.lblTiempo.Text = "Tiempo: " + this.Juego.obtenerTiempo();
        //    this.lblVidasPac.Text = this.Juego.PacMans.ElementAt(0).estadoDeVida();
        //    this.lblNombreJugador.Text = this.Juego.DatosJugador.Nombre;
        //}

        private void graficarEstadoActual(Graphics g) {
            if (this.jugando == 1) {

                if (this.mapa != null) {
                    graficarMapa(this.mapa, g);
                    dibujarControno(this.mapa, g);
                    graficarBiscochos(this.mapa, g);
                    foreach (Fantasma fantasma in this.estadoActual.Fantasmas) {
                        g.DrawImage(fantasma.ImgActual, fantasma.X, fantasma.Y, fantasma.Windth, fantasma.Height);
                    }
                    foreach (PacMan jugador in this.estadoActual.Jugadores) {
                        if (jugador.Identificador == this.identificador) {
                            g.DrawImage(jugador.ImgActual, jugador.X, jugador.Y, jugador.Windth, jugador.Height);
                            g.DrawImage(jugador.obtenerCamisetaVerde(), jugador.X, jugador.Y, jugador.Windth, jugador.Height);
                        } else {
                            g.DrawImage(jugador.ImgActual, jugador.X, jugador.Y, jugador.Windth, jugador.Height);
                            g.DrawImage(jugador.obtenerCamisetaRoja(), jugador.X, jugador.Y, jugador.Windth, jugador.Height);
                        }

                    }


                    //if (this.lblPuntaje.InvokeRequired)
                    //{
                    //    this.lblPuntaje.Invoke(new DelegadoPuntuacion(this.refrescarTextos));
                    //}
                    //else
                    //{
                    //    this.refrescarTextos();
                    //}
                }
            } else if (this.jugando == 2) {
                //accionesFinDelJuego();
                g.DrawImage(imgGameOver, 0, 87, 596, 200);
                g.DrawImage(imgVictoria, 10, 260, 596, 56);



            } else if (this.jugando == 3) {
                //accionesFinDelJuego();
                g.DrawImage(imgGameOver, 0, 87, 596, 200);
                g.DrawImage(imgDerrota, 10, 260, 596, 56);
            }
        }


        private void pintar(object sender, PaintEventArgs e) {
            if (estadoActual != null) {
                Graphics g = e.Graphics;
                this.graficarEstadoActual(g);
            }
        }


        //private void accionesFinDelJuego()
        //{
        //    if (sonidoFinJuego)
        //    {
        //        if (this.Juego.Jugando == 2)
        //        {
        //            sonido(1);
        //            this.sonidoFinJuego = false;
        //        }
        //        else if (this.Juego.Jugando == 3)
        //        {
        //            sonido(2);
        //            this.sonidoFinJuego = false;
        //        }
        //    }
        //    lblNombreFinal.Text = Juego.DatosJugador.Nombre;
        //    lblPuntosFinal.Text = Juego.DatosJugador.Puntaje + " pts";
        //    panel1.Left = 80;
        //    panel1.Top = 50;
        //    panel1.Height = 390;
        //    this.lblNombreJugador.Visible = false;
        //    this.lblOrdenesEnCola.Visible = false;
        //    this.lblPalabra.Visible = false;
        //    this.lblPuntaje.Visible = false;
        //    this.lblTiempo.Visible = false;
        //    this.lblVidasPac.Visible = false;
        //    this.btnGuardarPuntuacion.Visible = true;
        //    this.lblPuntosFinal.Visible = true;
        //    this.lblNombreFinal.Visible = true;
        //    this.juego.EstadoDelJuego = false;
        //}

        /*private void cambiarDireccionPacman(object sender, KeyEventArgs e)
        {
            if (this.estadoActual != null)
            {
                if (!this.entradaPorVoz)
                {
                    switch (e.KeyData)
                    {
                        case Keys.Up:
                            this.Juego.PacMans.ElementAt(0).adicionarOrden(1);
                            break;
                        case Keys.Down:
                            this.Juego.PacMans.ElementAt(0).adicionarOrden(2);
                            break;
                        case Keys.Right:
                            this.Juego.PacMans.ElementAt(0).adicionarOrden(3);
                            break;
                        case Keys.Left:
                            this.Juego.PacMans.ElementAt(0).adicionarOrden(4);
                            break;
                        case Keys.F1:
                            this.jugando = 2;
                            break;
                        case Keys.F2:
                            this.jugando = 3;
                            break;
                        case Keys.F4:
                            this.juego.hubicarFrutilla();
                            break;

                    }
                }
            }
        }*/

        /*public void iniciarReconocedor()
        {
            try
            {
                escucha.SetInputToDefaultAudioDevice();
                escucha.LoadGrammar(new DictationGrammar());
                escucha.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(lector);
                escucha.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("No se puede abrir mas de una vez");
            }
        }*/

        /*public void lector(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (RecognizedWordUnit palabra in e.Result.Words)
            {
                lblPalabra.Text = palabra.Text;
                if (palabra.Text == "izquierda")
                {
                    this.Juego.PacMans.ElementAt(0).adicionarOrden(4);
                }
                else if (palabra.Text == "derecha")
                {
                    this.Juego.PacMans.ElementAt(0).adicionarOrden(3);
                }
                else if (palabra.Text == "arriba")
                {
                    this.Juego.PacMans.ElementAt(0).adicionarOrden(1);
                }
                else if (palabra.Text == "abajo")
                {
                    this.Juego.PacMans.ElementAt(0).adicionarOrden(2);
                }
            }
        }*/

        public void definirEntrada(Boolean entrada) {
            this.entradaPorVoz = entrada;
        }

        private void dibujarControno(Mapa m, Graphics g) {
            Point psi = new Point(m.MatrizDiseño[0, 0].X - 1, m.MatrizDiseño[0, 0].Y - 1);
            Point psd = new Point(m.MatrizDiseño[0, m.Columnas - 1].X + 20, m.MatrizDiseño[0, m.Columnas - 1].Y - 1);
            Point pii = new Point(m.MatrizDiseño[m.Filas - 1, 0].X - 1, m.MatrizDiseño[m.Filas - 1, 0].Y + 20);
            Point pid = new Point(m.MatrizDiseño[m.Filas - 1, m.Columnas - 1].X + 20, m.MatrizDiseño[m.Filas - 1, m.Columnas - 1].Y + 20);

            g.DrawLine(new Pen(Brushes.White, 1), psi, psd);
            g.DrawLine(new Pen(Brushes.White, 1), psi, pii);
            g.DrawLine(new Pen(Brushes.White, 1), pii, pid);
            g.DrawLine(new Pen(Brushes.White, 1), psd, pid);
        }

        private void graficarBiscochos(Mapa m, Graphics g) {
            foreach (Celda celda in m.MatrizDiseño) {
                if (celda.SePuedePasar && celda.Valor == "O" && celda.Bisc.Estado) {
                    switch (celda.Bisc.Tipo) {
                        case 1:
                            g.FillEllipse(Brushes.White, celda.Bisc.X, celda.Bisc.Y, 3, 3);
                            break;
                        case 2:
                            g.FillEllipse(Brushes.White, celda.Bisc.X, celda.Bisc.Y, 8, 8);
                            break;
                        case 3:
                            g.DrawImage(imgFruta, celda.Bisc.X, celda.Bisc.Y, 20, 20);
                            break;
                    }
                }
            }
        }

        private void graficarMapa(Mapa m, Graphics g) {
            dibujarControno(m, g);
            if (m.Dificultad == "Facil") {
                foreach (Celda celda in m.MatrizDiseño) {
                    if (!celda.SePuedePasar) {
                        g.DrawImage(imagenPared[0], celda.X, celda.Y, celda.Width, celda.Heiht);
                    }
                }
            } else if (m.Dificultad == "Medio") {
                foreach (Celda celda in m.MatrizDiseño) {
                    if (!celda.SePuedePasar) {
                        g.DrawImage(imagenPared[3], celda.X, celda.Y, celda.Width, celda.Heiht);
                    }
                }
            } else if (m.Dificultad == "Dificil") {
                foreach (Celda celda in m.MatrizDiseño) {
                    if (!celda.SePuedePasar) {
                        g.DrawImage(imagenPared[2], celda.X, celda.Y, celda.Width, celda.Heiht);
                    }
                }
            }
        }

        private void graficarPanel() {
            panel1.Invalidate();
        }

        private void cicloJuego() {
            while (jugando == 1) {
                this.cambierEstadoActual();
                this.graficarPanel();
                Thread.Sleep(100);
            }

            //long ultimo = Environment.TickCount;
            //long cronometro = Environment.TickCount;
            //double milisegundo = 1000 / 60;
            //double cambio = 0;
            //int cuadros = 0;
            //int actualizaciones = 0;
            //while (jugando == 1) {
            //    long ahora = Environment.TickCount;
            //    cambio += (ahora - ultimo) / milisegundo;
            //    ultimo = ahora;
            //    while (cambio >= 1) {
            //        if (this.jugando == 1) {
            //            this.cambierEstadoActual();
            //            //Juego.actualizar();
            //        }

            //        actualizaciones++;
            //        cambio--;
            //    }
            //    //this.cambierEstadoActual();
            //    graficarPanel();
            //    cuadros++;
            //    if (Environment.TickCount - cronometro > 1000) {
            //        cronometro += 1000;
            //        cuadros = 0;
            //        actualizaciones = 0;
            //    }
            //}
        }

        private void cambierEstadoActual() {
            if (colaDeEstados.Count > 0) {
                this.estadoActual = colaDeEstados.Dequeue();
            }

        }

        /*public void actualizarChat(Mensaje m)
        {
            this.mensajes.Add(m);
            /*
             * 
             * ACTUALIZAR CHAT
             * 
             
        }*/

        public void conectar(string ipAddress, int port) {
            this.usuario = new Cliente(ipAddress, port, this);
            this.usuario.Conectado = true;
            new Thread(this.usuario.escuchar).Start();
        }

        private void terminarHilos() {
            this.usuario.Conectado = false;
        }

        private void VistaJuegoOnline_Load(object sender, EventArgs e) {
            DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel1, new object[] { true });
        }

        private void button1_Click(object sender, EventArgs e) {
            this.cambierEstadoActual();
            this.graficarPanel();
        }

        private void VistaJuegoOnline_FormClosing(object sender, FormClosingEventArgs e) {
            this.terminarHilos();
        }

        public int Identificador {
            get { return identificador; }
            set { identificador = value; }
        }

        public void recibirMensaje(string m) {
            this.rTMensajes.Text += m + "\n";
        }

        private void btnEnviarMensaje_Click(object sender, EventArgs e) {
            string mensaje = txtMensaje.Text;
            if (mensaje != "") {
                Estado m = new Estado(this.identificador, ("usuario " + this.identificador), mensaje, 0);
                this.rTMensajes.Text += "Yo:" + mensaje + "\n";
                this.usuario.enviar(m);
            }
        }
    }
}
