using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PACMANv3.pkgVista;
using PACMANv3.pkgModelo;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Threading;

namespace PACMANv3.pkgVista {
    /// <summary>
    /// Vista en la que se pueden crear mapas a partir de una cantidad de fias y columnas
    /// </summary>
    public partial class VistaCreacionDeMapas : Form {

        private Mapa mapa;
        private int filas;
        private int columnas;
        private int nivel;
        private string nombre;
        private string dificultad;
        private Boolean evaluarMatriz = true;

        /// <summary>
        /// Contructor de la VistaCreacionDeMapas
        /// </summary>
        public VistaCreacionDeMapas() {

            InitializeComponent();
            this.nombre = "";
            btnGuarConfDeMapa.Enabled = false;
            btnListo.Enabled = false;
            btnModificarCeldas.Enabled = false;
            this.cmbDificultad.SelectedIndex = 0;
            this.cmbNivel.SelectedIndex = 0;
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Nombre
        /// </summary>
        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Metodo accesor y mutador del atributo Mapa
        /// </summary>
        internal Mapa Mapa {
            get { return mapa; }
            set { mapa = value; }
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

        /// <summary>
        /// Metodo accesor y mutador del atributo Nivel
        /// </summary>
        public int Nivel {
            get { return nivel; }
            set { nivel = value; }
        }

        /// <summary>
        /// Metodo que evalua los campos del grid en busca de errores a la hora de hacer la concepcion del mapa y dando formato a las celdas
        /// </summary>
        private void evaluarMCamposMatriz() {
            while (evaluarMatriz) {
                for (int i = 0; i < columnas; i++) {
                    for (int j = 0; j < filas; j++) {
                        if (grdMapa[i, j].Value.ToString().Count() > 1) {
                            grdMapa[i, j].Value = grdMapa[i, j].Value.ToString().ToCharArray()[0].ToString().ToUpper();
                        } 
                        if (!grdMapa[i, j].Value.ToString().ToUpper().Equals("X") && !grdMapa[i, j].Value.ToString().ToUpper().Equals("Y") && !grdMapa[i, j].Value.ToString().ToUpper().Equals("O")) {
                            grdMapa[i, j].Value = "X";
                        }
                        if (grdMapa[i, j].Value.ToString().ToUpper().Equals("X")) {
                            grdMapa[i, j].Style.ForeColor = Color.White;
                            grdMapa[i, j].Style.BackColor = Color.Red;
                        } else if (grdMapa[i, j].Value.ToString().ToUpper().Equals("Y")) {
                            grdMapa[i, j].Style.ForeColor = Color.Black;
                            grdMapa[i, j].Style.BackColor = Color.Yellow;
                        } else if (grdMapa[i, j].Value.ToString().ToUpper().Equals("O")) {
                            grdMapa[i, j].Style.ForeColor = Color.Black;
                            grdMapa[i, j].Style.BackColor = Color.White;
                        }
                    }
                }
                Thread.Sleep(150);
            }

        }

        
        private void btnAceptarConf_Click(object sender, EventArgs e) {
            if (txtNombre.Text != "" && cmbDificultad.SelectedIndex > -1 && cmbNivel.SelectedIndex > -1) {
                filas = (int)nudFilas.Value + 5;
                columnas = (int)nudColumnas.Value + 5;

                nivel = int.Parse(cmbNivel.SelectedItem.ToString());
                nombre = txtNombre.Text;
                dificultad = cmbDificultad.SelectedItem.ToString();
                mapa = new Mapa(filas, columnas, nivel, nombre, dificultad);


                for (int i = 0; i < columnas; i++) {
                    grdMapa.Columns.Add(new DataGridViewTextBoxColumn());
                    grdMapa.Columns[i].Width = 25;

                    grdMapa.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                for (int i = 0; i < filas; i++) {
                    grdMapa.Rows.Add(new DataGridViewTextBoxCell());
                    grdMapa[0, i].Value = null;

                }

                for (int i = 0; i < filas; i++) {
                    for (int j = 0; j < columnas; j++) {
                        grdMapa[j, i].Value = "x";
                    }
                }
                int ic = (filas - 5) / 2;
                int jc = (columnas - 5) / 2;
                String[,] centro = generarCentroAleatorio();
                for (int i = 0; i < 5; i++) {
                    for (int j = 0; j < 5; j++) {
                        grdMapa[jc + i, ic + j].ReadOnly = true;
                        grdMapa[jc + i, ic + j].Value = centro[i, j];
                    }
                }
                btnAceptarConf.Enabled = false;
                txtNombre.Enabled = false;
                nudFilas.Enabled = false;
                nudColumnas.Enabled = false;
                cmbDificultad.Enabled = false;
                cmbNivel.Enabled = false;
                btnGuarConfDeMapa.Enabled = true;
                grdMapa.Visible = true;

                new Thread(evaluarMCamposMatriz).Start();
            } else {
                MessageBox.Show("Debe llenar todos los datos");
            }
        }

        /// <summary>
        /// Genera una matriz de 5x5 que hara de centro del mapa
        /// </summary>
        /// <returns>Retorna una matriz de 5x5</returns>
        private String[,] generarCentroAleatorio() {
            String[,] centro = new String[5, 5];
            Random nRand = new Random();
            int n = nRand.Next(1, 4);
            for (int i = 1; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    centro[i, j] = "x";
                }
            }

            for (int i = 0; i < 4; i++) {
                centro[0, i] = "o";
                centro[i, 4] = "o";
                centro[4, 4 - i] = "o";
                centro[4 - i, 0] = "o";
            }

            centro[2, 2] = "y";
            if (n == 1) { //arriba
                centro[1, 2] = "y";
            } else if (n == 2) { //abajo
                centro[3, 2] = "y";
            } else if (n == 3) { //derecha
                centro[2, 3] = "y";
            } else if (n == 4) { //izquierda
                centro[2, 1] = "y";
            }
            return centro;

        }

        /// <summary>
        /// Escribe el nombre del nuevo mapa en los archos de configuracion
        /// </summary>
        private void escribirNombreEnListaDeNombreMapas() {


            StreamReader sr = File.OpenText("./../../ArchivosConf/Config/nombreMapas" + mapa.Dificultad + ".conf");
            String entrada = sr.ReadToEnd();
            sr.Close();
            StreamWriter sw = new StreamWriter("./../../ArchivosConf/Config/nombreMapas" + mapa.Dificultad + ".conf");
            sw.WriteLine(entrada + mapa.Nombre);
            sw.Close();

        }

        /// <summary>
        /// Escribe un nuevo archovo JSON que representa a el nuevo mapa
        /// </summary>
        private void escribirJSONMapa() {
            String js = JsonConvert.SerializeObject(mapa);
            StreamWriter sr = File.CreateText("./../../ArchivosConf/Maps/" + mapa.Nombre + ".map");
            sr.Write(js);
            sr.Close();
        }

        private void btnListo_Click(object sender, EventArgs e) {
            evaluarMatriz = false;
            escribirNombreEnListaDeNombreMapas();
            escribirJSONMapa();

            this.Visible = false;
        }

        private void grdMapa_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }


        private void soloPermitirNumeros(object sender, KeyPressEventArgs e) {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnGuarConfDeMapa_Click(object sender, EventArgs e) {
            string[,] valoresMapa = new string[filas, columnas];
            for (int i = 0; i < columnas; i++) {
                for (int j = 0; j < filas; j++) {
                    if (grdMapa[i, 0].Value != null) {
                        valoresMapa[j, i] = grdMapa[i, j].Value.ToString().ToUpper();
                    }
                }
            }

            mapa.Arreglo = valoresMapa;
            mapa.crearMapa();
            btnListo.Enabled = true;
            btnModificarCeldas.Enabled = true;
            btnGuarConfDeMapa.Enabled = false;
        }



        private void btnModificarCeldas_Click(object sender, EventArgs e) {
            btnListo.Enabled = false;
            btnGuarConfDeMapa.Enabled = true;
            btnModificarCeldas.Enabled = false;
        }
    }
}
