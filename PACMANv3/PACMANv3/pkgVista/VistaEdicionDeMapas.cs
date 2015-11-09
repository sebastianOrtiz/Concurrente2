using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace PACMANv3.pkgModelo {
    public partial class VistaEdicionDeMapas : Form {
        private List<Mapa> todosLosMapas;
        private Mapa mapaAEditar;
        private Mapa mapaNuevo;
        private int filas;
        private int columnas;
        private String[,] matrizChars;
        private Boolean evaluarMatriz = true;

        public VistaEdicionDeMapas() {
            InitializeComponent();
        }

        public void cargarMapasEnElEditor(List<String> lista, List<Mapa> todosLosMapas) {
            this.todosLosMapas = todosLosMapas;
            foreach (String nombre in lista) {
                cmbMapas.Items.Add(nombre);
            }
        }

        private void cargarMatrizEnGrid() {

            for (int i = 0; i < this.columnas; i++) {
                grdValoresMapa.Columns.Add(new DataGridViewTextBoxColumn());
                grdValoresMapa.Columns[i].Width = 25;

                grdValoresMapa.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            for (int i = 0; i < this.filas - 1; i++) {
                grdValoresMapa.Rows.Add(new DataGridViewTextBoxCell());
                grdValoresMapa[0, i].Value = null;

            }

            for (int i = 0; i < this.filas; i++) {
                for (int j = 0; j < this.columnas; j++) {
                    grdValoresMapa[j, i].Value = this.matrizChars[i, j];
                }
            }

            int ic = (filas - 5) / 2;
            int jc = (columnas - 5) / 2;

            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 5; j++) {
                    grdValoresMapa[jc + i, ic + j].ReadOnly = true;
                }
            }
            new Thread(evaluarMCamposMatriz).Start();
        }

        private void cmbMapas_SelectionChangeCommitted(object sender, EventArgs e) {
            foreach (Mapa mapa in this.todosLosMapas) {
                if (mapa.Nombre.Equals(cmbMapas.SelectedItem.ToString())) {
                    this.mapaAEditar = mapa;
                    this.filas = this.mapaAEditar.Filas;
                    this.columnas = this.mapaAEditar.Columnas;
                    this.matrizChars = this.mapaAEditar.Arreglo;
                    this.cargarMatrizEnGrid();
                    this.cmbMapas.Enabled = false;
                    break;
                }
            }

        }

        private void escribirJSONMapa() {
            String js = JsonConvert.SerializeObject(this.mapaNuevo);
            StreamWriter sr = File.CreateText("./../../ArchivosConf/Maps/" + mapaNuevo.Nombre + ".map");
            sr.Write(js);
            sr.Close();
        }

        
        private void evaluarMCamposMatriz() {
            while (evaluarMatriz) {
                for (int i = 0; i < columnas; i++) {
                    for (int j = 0; j < filas; j++) {
                        if (grdValoresMapa[i, j].Value == null) {
                            grdValoresMapa[i, j].Value = "X";
                        }
                        if (grdValoresMapa[i, j].Value.ToString().Count() > 1) {
                            grdValoresMapa[i, j].Value = grdValoresMapa[i, j].Value.ToString().ToCharArray()[0].ToString().ToUpper();
                        }
                        if (!grdValoresMapa[i, j].Value.ToString().ToUpper().Equals("X") && !grdValoresMapa[i, j].Value.ToString().ToUpper().Equals("Y") && !grdValoresMapa[i, j].Value.ToString().ToUpper().Equals("O")) {
                            grdValoresMapa[i, j].Value = "X";
                        }
                        if (grdValoresMapa[i, j].Value.ToString().ToUpper().Equals("X")) {
                            grdValoresMapa[i, j].Style.ForeColor = Color.White;
                            grdValoresMapa[i, j].Style.BackColor = Color.Red;
                        } else if (grdValoresMapa[i, j].Value.ToString().ToUpper().Equals("Y")) {
                            grdValoresMapa[i, j].Style.ForeColor = Color.Black;
                            grdValoresMapa[i, j].Style.BackColor = Color.Yellow;
                        } else if (grdValoresMapa[i, j].Value.ToString().ToUpper().Equals("O")) {
                            grdValoresMapa[i, j].Style.ForeColor = Color.Black;
                            grdValoresMapa[i, j].Style.BackColor = Color.White;
                        }
                    }
                }
                Thread.Sleep(150);
            }
        }

        private void VistaEdicionDeMapas_FormClosing(object sender, FormClosingEventArgs e) {
            evaluarMatriz = false;
        }

        private void obtenerNuevaMatriz() {
            this.matrizChars = new string[filas, columnas];
            for (int i = 0; i < this.filas; i++) {
                for (int j = 0; j < this.columnas; j++) {
                    matrizChars[i, j] = grdValoresMapa[j, i].Value.ToString().ToUpper();
                }
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e) {
            this.MapaNuevo = new Mapa(this.filas, this.columnas, this.mapaAEditar.Nivel, this.mapaAEditar.Nombre, this.mapaAEditar.Dificultad);
            this.obtenerNuevaMatriz();
            this.MapaNuevo.Arreglo = this.matrizChars;
            this.MapaNuevo.MatrizDiseño = new Celda[MapaNuevo.Filas, MapaNuevo.Columnas];
            this.MapaNuevo.crearMapa();
            this.escribirJSONMapa();
            this.Close();
        }

        public Mapa MapaNuevo {
            get { return mapaNuevo; }
            set { mapaNuevo = value; }
        }

        private void btnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
