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
using PACMANv3.pkgVista;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Media;
using System.Net;
using System.Net.Sockets;

namespace PACMANv3
{
    public partial class Form1 : Form
    {
        private Juego juego;
        private List<Mapa> listadeMapasDificil;
        private List<Mapa> listadeMapasMedio;
        private List<Mapa> listadeMapasFacil;
        private List<String> nombresDeMapasDificil;
        private List<String> nombresDeMapasMedio;
        private List<String> nombresDeMapasFacil;
        private List<DatosJugador> datosJugadores;
        private SoundPlayer soundFondo;


        public Form1()
        {
            InitializeComponent();
            cmbSeleccionarDificultad.SelectedIndex = 0;
            listadeMapasDificil = new List<Mapa>();
            listadeMapasMedio = new List<Mapa>();
            listadeMapasFacil = new List<Mapa>();
            nombresDeMapasDificil = new List<string>();
            nombresDeMapasMedio = new List<string>();
            nombresDeMapasFacil = new List<string>();
            this.datosJugadores = new List<DatosJugador>();
            cargarDatosJugadores();
            cargarNombresDeMapas();
            cargarMapas();

            /* Conexión socket(envio y recibo)Socket sc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint direccion = new IPEndPoint(IPAddress.Loopback, 1339);

            try
            {
                sc.Connect(direccion);            
                Console.WriteLine("Conectado con exito");
                Mensaje m = new Mensaje("cliente", "hola!!");
                BinaryFormatter serializer = new BinaryFormatter();
                NetworkStream st = new NetworkStream(sc);
                serializer.Serialize(st, m);
                m = (Mensaje)serializer.Deserialize(st);
                Console.WriteLine("" + m.Nombre);
                Console.WriteLine("" + m.Texto);
                st.Close();
                sc.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine("Error: {0}", error.ToString());
            }*/
        }

        private void escribirJSONJugadores()
        {
            String js = JsonConvert.SerializeObject(datosJugadores);
            StreamWriter sw = File.CreateText("./../../ArchivosConf/DatosUsuarios/HistoricoDeUsuarios.data");
            sw.Write(js);
            sw.Close();
        }

        private void cargarDatosJugadores()
        {
            //LEYENDO JSON
            StreamReader sr;
            sr = File.OpenText("./../../ArchivosConf/DatosUsuarios/HistoricoDeUsuarios.data");
            String entrada = sr.ReadToEnd();
            if (entrada != "")
            {
                this.datosJugadores = JsonConvert.DeserializeObject<List<DatosJugador>>(entrada);
            }
            sr.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carYReproducir();
        }

        private void carYReproducir()
        {
            this.soundFondo = new SoundPlayer(Properties.Resources.nocheDeAcosador);
            this.soundFondo.Load();
            this.soundFondo.PlayLooping();
        }

        private void cargarNombresDeMapas()
        {
            StreamReader sr = new StreamReader("./../../ArchivosConf/Config/nombreMapasDificil.conf");
            String linea;
            linea = sr.ReadLine();
            while (linea != null)
            {
                nombresDeMapasDificil.Add(linea);
                linea = sr.ReadLine();
            }
            sr = new StreamReader("./../../ArchivosConf/Config/nombreMapasMedio.conf");
            linea = sr.ReadLine();
            while (linea != null)
            {
                nombresDeMapasMedio.Add(linea);
                linea = sr.ReadLine();
            }

            sr = new StreamReader("./../../ArchivosConf/Config/nombreMapasFacil.conf");
            linea = sr.ReadLine();
            while (linea != null)
            {
                nombresDeMapasFacil.Add(linea);
                linea = sr.ReadLine();
            }
            sr.Close();
        }

        private void cargarMapas()
        {
            //LEYENDO JSON
            StreamReader sr;
            foreach (String nombreMapa in nombresDeMapasDificil)
            {
                sr = File.OpenText("./../../ArchivosConf/Maps/" + nombreMapa + ".map");
                String entrada = sr.ReadToEnd();
                if (entrada != "")
                {
                    Mapa nMap = JsonConvert.DeserializeObject<Mapa>(entrada);
                    nMap.MatrizDiseño = new Celda[nMap.Filas, nMap.Columnas];
                    nMap.crearMapa();
                    listadeMapasDificil.Add(nMap);
                }
            }
            foreach (String nombreMapa in nombresDeMapasMedio)
            {
                sr = File.OpenText("./../../ArchivosConf/Maps/" + nombreMapa + ".map");
                String entrada = sr.ReadToEnd();
                if (entrada != "")
                {
                    Mapa nMap = JsonConvert.DeserializeObject<Mapa>(entrada);
                    nMap.MatrizDiseño = new Celda[nMap.Filas, nMap.Columnas];
                    nMap.crearMapa();
                    listadeMapasMedio.Add(nMap);
                }
            }
            foreach (String nombreMapa in nombresDeMapasFacil)
            {
                sr = File.OpenText("./../../ArchivosConf/Maps/" + nombreMapa + ".map");
                String entrada = sr.ReadToEnd();
                if (entrada != "")
                {
                    Mapa nMap = JsonConvert.DeserializeObject<Mapa>(entrada);
                    nMap.MatrizDiseño = new Celda[nMap.Filas, nMap.Columnas];
                    nMap.crearMapa();
                    listadeMapasFacil.Add(nMap);
                }
            }
        }

        private void btnAceptarConfigInicial_Click(object sender, EventArgs e)
        {
            if (txtNombreJu.Text != null && cmbSeleccionarDificultad.SelectedIndex > -1)
            {
                String dificultad = cmbSeleccionarDificultad.SelectedItem.ToString();
                DatosJugador nuevoJugador = new DatosJugador(txtNombreJu.Text, dificultad);
                Boolean entradaPorVoz;
                if (rBtnVoz.Checked)
                {
                    entradaPorVoz = true;
                }
                else
                {
                    entradaPorVoz = false;
                }

                if (dificultad == "Facil")
                {
                    juego = new Juego(listadeMapasFacil, dificultad, nuevoJugador, entradaPorVoz, (int)nudVidasPacman.Value, (int)nudHPPacman.Value);
                }
                else if (dificultad == "Medio")
                {
                    juego = new Juego(listadeMapasMedio, dificultad, nuevoJugador, entradaPorVoz, (int)nudVidasPacman.Value, (int)nudHPPacman.Value);
                }
                else if (dificultad == "Dificil")
                {
                    juego = new Juego(listadeMapasDificil, dificultad, nuevoJugador, entradaPorVoz, (int)nudVidasPacman.Value, (int)nudHPPacman.Value);

                }

                VistaJuego vj = new VistaJuego();
                vj.definirEntrada(entradaPorVoz);
                if (entradaPorVoz)
                {
                    vj.iniciarReconocedor();
                }
                vj.crearJuego(this.juego);
                DialogResult res = vj.ShowDialog();

                if (res == DialogResult.OK)
                {
                    carYReproducir();
                    DatosJugador jugadorEntrante = vj.Juego.DatosJugador;
                    jugadorEntrante.Fecha = DateTime.Now.ToString();
                    this.datosJugadores.Add(jugadorEntrante);
                    this.ordenarDescendente();
                    this.panelConfigInicio.Visible = false;
                    this.panelPuntajes.Visible = true;
                    this.listarDatosJugadores();
                    this.cargarMapas();
                }
            }
            else
            {
                MessageBox.Show("No hay nombre o nivel de dificultad seleccionado");
            }
        }

        private void listarDatosJugadores()
        {
            String datNom = "";
            String datdif = "";
            String datpts = "";
            String datfecha = "";
            for (int i = 0; i < this.datosJugadores.Count; i++)
            {
                datNom += (i + 1) + "- " + this.datosJugadores.ElementAt(i).Nombre + "\n";
                datdif += this.datosJugadores.ElementAt(i).Dificultad + "\n";
                datpts += this.datosJugadores.ElementAt(i).Puntaje + " pts\n";
                datfecha += this.datosJugadores.ElementAt(i).Fecha + "\n";
            }
            lblListadoDatos.Text = datNom;
            lblPtsDat.Text = datpts;
            lblDifDatos.Text = datdif;
            lblFechaDat.Text = datfecha;

        }

        private void btnCrearMapa_Click(object sender, EventArgs e)
        {
            VistaCreacionDeMapas nuevaVen = new VistaCreacionDeMapas();
            DialogResult res = nuevaVen.ShowDialog();

            if (res == DialogResult.OK)
            {
                Mapa nMapa = nuevaVen.Mapa;
                if (nMapa.Dificultad == "Dificil")
                {
                    listadeMapasDificil.Add(nMapa);
                }
                else if (nMapa.Dificultad == "Medio")
                {
                    listadeMapasMedio.Add(nMapa);
                }
                else if (nMapa.Dificultad == "Facil")
                {
                    listadeMapasFacil.Add(nMapa);
                }
            }
        }

        private void ordenarDescendente()
        {
            DatosJugador[] arrJug = this.datosJugadores.ToArray();
            for (int i = 0; i < arrJug.Length; i++)
            {
                for (int j = i + 1; j < arrJug.Length; j++)
                {
                    if (arrJug[i].Puntaje < arrJug[j].Puntaje)
                    {
                        DatosJugador aux = arrJug[i];
                        arrJug[i] = arrJug[j];
                        arrJug[j] = aux;
                    }
                }
            }
            this.datosJugadores.Clear();
            this.datosJugadores.AddRange(arrJug);
        }

        private void btnAceptarDatos_Click(object sender, EventArgs e)
        {
            escribirJSONJugadores();
            this.panelPuntajes.Visible = false;
            this.panelConfigInicio.Visible = true;
        }

        private void btnIntPuntajes_Click(object sender, EventArgs e)
        {
            this.ordenarDescendente();
            this.listarDatosJugadores();
            this.panelConfigInicio.Visible = false;
            this.panelPuntajes.Visible = true;
        }

        private void btnEditarMapa_Click(object sender, EventArgs e)
        {
            VistaEdicionDeMapas ve = new VistaEdicionDeMapas();
            List<String> lista = new List<string>();
            List<Mapa> todosLosMapas = new List<Mapa>();
            todosLosMapas.AddRange(listadeMapasFacil);
            todosLosMapas.AddRange(listadeMapasMedio);
            todosLosMapas.AddRange(listadeMapasDificil);
            lista.AddRange(nombresDeMapasFacil);
            lista.AddRange(nombresDeMapasMedio);
            lista.AddRange(nombresDeMapasDificil);
            ve.cargarMapasEnElEditor(lista, todosLosMapas);
            DialogResult res = ve.ShowDialog();

            if (res == DialogResult.OK)
            {
                Mapa nuevoMapa = ve.MapaNuevo;
                Mapa[] arrayMapas;
                if (nuevoMapa.Dificultad == "Dificil")
                {
                    arrayMapas = listadeMapasDificil.ToArray();
                    for (int i = 0; i < arrayMapas.Length; i++)
                    {
                        if (arrayMapas[i].Nombre.Equals(nuevoMapa.Nombre))
                        {
                            arrayMapas[i] = nuevoMapa;
                            break;
                        }
                    }
                    listadeMapasDificil.Clear();
                    listadeMapasDificil.AddRange(arrayMapas);
                }
                else if (nuevoMapa.Dificultad == "Medio")
                {
                    arrayMapas = listadeMapasMedio.ToArray();
                    for (int i = 0; i < arrayMapas.Length; i++)
                    {
                        if (arrayMapas[i].Nombre.Equals(nuevoMapa.Nombre))
                        {
                            arrayMapas[i] = nuevoMapa;
                            break;
                        }
                    }
                    listadeMapasMedio.Clear();
                    listadeMapasMedio.AddRange(arrayMapas);
                }
                else if (nuevoMapa.Dificultad == "Facil")
                {
                    arrayMapas = listadeMapasFacil.ToArray();
                    for (int i = 0; i < arrayMapas.Length; i++)
                    {
                        if (arrayMapas[i].Nombre.Equals(nuevoMapa.Nombre))
                        {
                            arrayMapas[i] = nuevoMapa;
                            break;
                        }
                    }
                    listadeMapasFacil.Clear();
                    listadeMapasFacil.AddRange(arrayMapas);
                }
            }
        }
    }
}
