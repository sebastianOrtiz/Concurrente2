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

namespace PACMANv3 {
    public partial class Form1 : Form {
        private Juego juego;
        private List<Mapa> listaDeMapas;
        private List<String> nombresDeMapas;
        private List<DatosJugador> datosJugadores;
        private SoundPlayer soundFondo;
        private Mapa mapaAJugar;

        private Servidor servidor;

        public Form1() {
            InitializeComponent();
            cmbSeleccionarDificultad.SelectedIndex = 0;

            this.listaDeMapas = new List<Mapa>();
            this.nombresDeMapas = new List<String>();
            this.datosJugadores = new List<DatosJugador>();
            cargarDatosJugadores();
            cargarNombresDeMapas();
            cargarMapas();

            //this.socket();
            this.servidor = new Servidor(1, "127.0.0.1");
            new Thread(this.servidor.run).Start();
        }

        public void cargarMapasEnCombobox() {

            foreach (String nombre in nombresDeMapas) {
                cmbSeleccionMapa.Items.Add(nombre);
                cmbSeleccionMapa.SelectedIndex = 0;
            }
        }

        private void escribirJSONJugadores() {
            String js = JsonConvert.SerializeObject(datosJugadores);
            StreamWriter sw = File.CreateText("./../../ArchivosConf/DatosUsuarios/HistoricoDeUsuarios.data");
            sw.Write(js);
            sw.Close();
        }

        private void cargarDatosJugadores() {
            //LEYENDO JSON
            StreamReader sr;
            sr = File.OpenText("./../../ArchivosConf/DatosUsuarios/HistoricoDeUsuarios.data");
            String entrada = sr.ReadToEnd();
            if (entrada != "") {
                this.datosJugadores = JsonConvert.DeserializeObject<List<DatosJugador>>(entrada);
            }
            sr.Close();


        }

        private void Form1_Load(object sender, EventArgs e) {
            carYReproducir();
        }

        private void carYReproducir() {
            this.soundFondo = new SoundPlayer(Properties.Resources.nocheDeAcosador);
            this.soundFondo.Load();
            this.soundFondo.PlayLooping();
        }

        private void cargarNombresDeMapas() {
            StreamReader sr = new StreamReader("./../../ArchivosConf/Config/nombresMapas.conf");
            String linea;
            linea = sr.ReadLine();
            while (linea != null) {
                nombresDeMapas.Add(linea);
                linea = sr.ReadLine();
            }
            sr.Close();
            this.cargarMapasEnCombobox();
        }

        private void cargarMapas() {
            //LEYENDO JSON
            StreamReader sr;
            foreach (String nombreMapa in nombresDeMapas) {
                sr = File.OpenText("./../../ArchivosConf/Maps/" + nombreMapa + ".map");
                String entrada = sr.ReadToEnd();
                if (entrada != "") {
                    Mapa nMap = JsonConvert.DeserializeObject<Mapa>(entrada);
                    nMap.MatrizDiseño = new Celda[nMap.Filas, nMap.Columnas];
                    nMap.crearMapa();
                    listaDeMapas.Add(nMap);
                }
            }
        }

        private void btnAceptarConfigInicial_Click(object sender, EventArgs e) {
            if (cmbSeleccionMapa.SelectedIndex > -1) {
                if (txtNombreJu.Text != null && cmbSeleccionarDificultad.SelectedIndex > -1) {
                    String dificultad = cmbSeleccionarDificultad.SelectedItem.ToString();
                    DatosJugador nuevoJugador = new DatosJugador(txtNombreJu.Text, dificultad);
                    Boolean entradaPorVoz;
                    if (rBtnVoz.Checked) {
                        entradaPorVoz = true;
                    } else {
                        entradaPorVoz = false;
                    }

                    juego = new Juego(mapaAJugar, dificultad, nuevoJugador, entradaPorVoz, (int) nudVidasPacman.Value, (int) nudHPPacman.Value);

                    VistaJuego vj = new VistaJuego();
                    vj.definirEntrada(entradaPorVoz);
                    if (entradaPorVoz) {
                        vj.iniciarReconocedor();
                    }
                    vj.crearJuego(this.juego);
                    DialogResult res = vj.ShowDialog();

                    if (res == DialogResult.OK) {
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
                } else {
                    MessageBox.Show("No hay nombre o nivel de dificultad seleccionado");
                }
            } else {
                MessageBox.Show("Seleccione un Mapa");
            }

        }

        private void listarDatosJugadores() {
            String datNom = "";
            String datdif = "";
            String datpts = "";
            String datfecha = "";
            for (int i = 0; i < this.datosJugadores.Count; i++) {
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

        private void btnCrearMapa_Click(object sender, EventArgs e) {
            VistaCreacionDeMapas nuevaVen = new VistaCreacionDeMapas();
            DialogResult res = nuevaVen.ShowDialog();

            if (res == DialogResult.OK) {
                //Mapa nMapa = nuevaVen.Mapa;
                listaDeMapas.Add(nuevaVen.Mapa);
            }
        }

        private void ordenarDescendente() {
            DatosJugador[] arrJug = this.datosJugadores.ToArray();
            for (int i = 0; i < arrJug.Length; i++) {
                for (int j = i + 1; j < arrJug.Length; j++) {
                    if (arrJug[i].Puntaje < arrJug[j].Puntaje) {
                        DatosJugador aux = arrJug[i];
                        arrJug[i] = arrJug[j];
                        arrJug[j] = aux;
                    }
                }
            }
            this.datosJugadores.Clear();
            this.datosJugadores.AddRange(arrJug);
        }

        private void btnAceptarDatos_Click(object sender, EventArgs e) {
            escribirJSONJugadores();
            this.panelPuntajes.Visible = false;
            this.panelConfigInicio.Visible = true;
        }

        private void btnIntPuntajes_Click(object sender, EventArgs e) {
            this.ordenarDescendente();
            this.listarDatosJugadores();
            this.panelConfigInicio.Visible = false;
            this.panelPuntajes.Visible = true;
        }

        private void btnEditarMapa_Click(object sender, EventArgs e) {
            VistaEdicionDeMapas ve = new VistaEdicionDeMapas();
            List<String> lista = new List<string>();
            List<Mapa> todosLosMapas = new List<Mapa>();
            todosLosMapas.AddRange(listaDeMapas);
            lista.AddRange(nombresDeMapas);
            ve.cargarMapasEnElEditor(lista, todosLosMapas);
            DialogResult res = ve.ShowDialog();

            if (res == DialogResult.OK) {
                Mapa nuevoMapa = ve.MapaNuevo;
                Mapa[] arrayMapas;
                arrayMapas = listaDeMapas.ToArray();
                for (int i = 0; i < arrayMapas.Length; i++) {
                    if (arrayMapas[i].Nombre.Equals(nuevoMapa.Nombre)) {
                        arrayMapas[i] = nuevoMapa;
                        break;
                    }
                }
                listaDeMapas.Clear();
                listaDeMapas.AddRange(arrayMapas);
            }
        }

        private void cmbSeleccionMapa_SelectionChangeCommitted(object sender, EventArgs e) {
            foreach (Mapa mapa in this.listaDeMapas) {
                if (mapa.Nombre.Equals(cmbSeleccionMapa.SelectedItem.ToString())) {
                    this.mapaAJugar = mapa;
                    break;
                }
            }
        }



        private void socket() {
            TcpListener server = new TcpListener(IPAddress.Loopback, 1339);
            server.Start();
            Console.WriteLine("esperando");
            TcpClient client = server.AcceptTcpClient();
            NetworkStream net = client.GetStream();

            BinaryFormatter serializer = new BinaryFormatter();
            Console.WriteLine(net.ReadTimeout);

            /*** Leer ***/
            byte[] msgDataLen = new byte[4];
            net.Read(msgDataLen, 0, 4);

            int dataLen = BitConverter.ToInt32(msgDataLen, 0);
            Console.WriteLine("tamaño leido {0}", dataLen);
            Console.WriteLine("esperando datos");
            byte[] msgDataBytes = new byte[dataLen];
            net.Read(msgDataBytes, 0, dataLen);
            MemoryStream ms = new MemoryStream(msgDataBytes);
            ms.Position = 0;
            Mensaje m = (Mensaje) serializer.Deserialize(ms);
            Console.WriteLine(m.Nombre);
            Console.WriteLine(m.Texto);
            /*** ***/

            /*//Conexión socket(envio y recibo)
            ss = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint direccion = new IPEndPoint(IPAddress.Loopback, 1339);
            try
            {
                ss.Bind(direccion);
                Console.WriteLine("Escuchando");
                ss.Listen(1);
                Console.WriteLine("Esperando");
                Socket sc = ss.Accept();
                BinaryFormatter serializer = new BinaryFormatter();

                Mensaje m = null;
                NetworkStream net = new NetworkStream(sc);

                /*m = (Mensaje)serializer.Deserialize(net);
                Console.WriteLine("" + m.Nombre);
                Console.WriteLine("" + m.Texto);*/

            /*m = new Mensaje("servidor", "mundo!!");
            serializer.Serialize(net, m);*/

            /*** Leer ***/
            /*byte[] msgDataLen = new byte[4];
            net.Read(msgDataLen, 0, 4);

            int dataLen = BitConverter.ToInt32(msgDataLen, 0);
            Console.WriteLine("tamaño leido {0}", dataLen);
            Console.WriteLine("esperando datos");
            byte[] msgDataBytes = new byte[dataLen];
            net.Read(msgDataBytes, 0, dataLen);
            /*** ***/

            /*MemoryStream ms = new MemoryStream(msgDataBytes);
            serializer.Serialize(ms, m);
            msgDataBytes = ms.ToArray();

            byte[] msgDataLen = BitConverter.GetBytes((Int32)msgDataBytes.Length);
            net.Write(msgDataLen, 0, 4);
            net.Write(msgDataBytes, 0, msgDataBytes.Length);*/

            /*net.Close();
            sc.Close();
            ss.Close();
            Console.WriteLine("Cerrando conexion");
        }
        catch (Exception error)
        {
            Console.WriteLine("Error: {0}", error.ToString());
        }*/

            //-------------------------------------------------

            //Conexión socket(envio y recibo)
            /*Socket sc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            this.servidor.terminarHilos();
        }

    }
}
