﻿using System;
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

namespace PACMANv3.pkgVista
{
    public partial class VistaJuegoOnline : Form
    {
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
        private List<Mensaje> mensajes;

        public VistaJuegoOnline()
        {
            InitializeComponent();
            colaDeEstados = new Queue<Estado>();
            this.cargarRecursos();
        }

        private void cargarRecursos()
        {
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

        private void pintar(object sender, PaintEventArgs e)
        {
            if (estadoActual != null)
            {
                Graphics g = e.Graphics;
                if (this.jugando == 1)
                {

                    if (this.mapa != null)
                    {
                        graficarMapa(this.mapa, g);
                        dibujarControno(this.mapa, g);
                        graficarBiscochos(this.mapa, g);
                        foreach (Fantasma fantasma in this.estadoActual.Fantasmas)
                        {
                            g.DrawImage(fantasma.ImgActual, fantasma.X, fantasma.Y, fantasma.Windth, fantasma.Height);
                        }
                        foreach (PacMan jugador in this.estadoActual.Jugadores)
                        {
                            g.DrawImage(jugador.ImgActual, jugador.X, jugador.Y, jugador.Windth, jugador.Height);
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
                }
                else if (this.jugando == 2)
                {
                    //accionesFinDelJuego();
                    g.DrawImage(imgGameOver, 0, 87, 596, 200);
                    g.DrawImage(imgVictoria, 10, 260, 596, 56);



                }
                else if (this.jugando == 3)
                {
                    //accionesFinDelJuego();
                    g.DrawImage(imgGameOver, 0, 87, 596, 200);
                    g.DrawImage(imgDerrota, 10, 260, 596, 56);
                }
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

        public void definirEntrada(Boolean entrada)
        {
            this.entradaPorVoz = entrada;
        }

        private void dibujarControno(Mapa m, Graphics g)
        {
            Point psi = new Point(m.MatrizDiseño[0, 0].X - 1, m.MatrizDiseño[0, 0].Y - 1);
            Point psd = new Point(m.MatrizDiseño[0, m.Columnas - 1].X + 20, m.MatrizDiseño[0, m.Columnas - 1].Y - 1);
            Point pii = new Point(m.MatrizDiseño[m.Filas - 1, 0].X - 1, m.MatrizDiseño[m.Filas - 1, 0].Y + 20);
            Point pid = new Point(m.MatrizDiseño[m.Filas - 1, m.Columnas - 1].X + 20, m.MatrizDiseño[m.Filas - 1, m.Columnas - 1].Y + 20);

            g.DrawLine(new Pen(Brushes.White, 1), psi, psd);
            g.DrawLine(new Pen(Brushes.White, 1), psi, pii);
            g.DrawLine(new Pen(Brushes.White, 1), pii, pid);
            g.DrawLine(new Pen(Brushes.White, 1), psd, pid);
        }

        private void graficarBiscochos(Mapa m, Graphics g)
        {
            foreach (Celda celda in m.MatrizDiseño)
            {
                if (celda.SePuedePasar && celda.Valor == "O" && celda.Bisc.Estado)
                {
                    switch (celda.Bisc.Tipo)
                    {
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

        private void graficarMapa(Mapa m, Graphics g)
        {
            dibujarControno(m, g);
            if (m.Dificultad == "Facil")
            {
                foreach (Celda celda in m.MatrizDiseño)
                {
                    if (!celda.SePuedePasar)
                    {
                        g.DrawImage(imagenPared[0], celda.X, celda.Y, celda.Width, celda.Heiht);
                    }
                }
            }
            else if (m.Dificultad == "Medio")
            {
                foreach (Celda celda in m.MatrizDiseño)
                {
                    if (!celda.SePuedePasar)
                    {
                        g.DrawImage(imagenPared[3], celda.X, celda.Y, celda.Width, celda.Heiht);
                    }
                }
            }
            else if (m.Dificultad == "Dificil")
            {
                foreach (Celda celda in m.MatrizDiseño)
                {
                    if (!celda.SePuedePasar)
                    {
                        g.DrawImage(imagenPared[2], celda.X, celda.Y, celda.Width, celda.Heiht);
                    }
                }
            }
        }

        private void graficarPanel()
        {
            panel1.Invalidate();
        }

        private void cicloJuego()
        {
            long ultimo = Environment.TickCount;
            long cronometro = Environment.TickCount;
            double milisegundo = 1000 / 60;
            double cambio = 0;
            int cuadros = 0;
            int actualizaciones = 0;
            while (jugando == 1)
            {
                long ahora = Environment.TickCount;
                cambio += (ahora - ultimo) / milisegundo;
                ultimo = ahora;
                while (cambio >= 1)
                {
                    if (this.jugando == 1)
                    {
                        this.cambierEstadoActual();
                        //Juego.actualizar();
                    }

                    actualizaciones++;
                    cambio--;
                }
                graficarPanel();
                cuadros++;
                if (Environment.TickCount - cronometro > 1000)
                {
                    cronometro += 1000;
                    cuadros = 0;
                    actualizaciones = 0;
                }
            }
        }

        private void cambierEstadoActual()
        {
            this.estadoActual = colaDeEstados.Dequeue();
        }

        /*public void actualizarChat(Mensaje m)
        {
            this.mensajes.Add(m);
            /*
             * 
             * ACTUALIZAR CHAT
             * 
             
        }*/

        private void VistaJuegoOnline_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panel1, new object[] { true });
        }
    }
}