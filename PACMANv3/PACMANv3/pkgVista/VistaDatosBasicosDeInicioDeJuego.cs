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

namespace PACMANv3.pkgVista {
    public partial class VistaDatosBasicosDeInicioDeJuego : Form {
        private DatosJugador nuevoJugador;
        private string dificultad;
        private Boolean entradaPorVoz;
        
        public VistaDatosBasicosDeInicioDeJuego() {
            InitializeComponent();
        }

        public Boolean EntradaPorVoz {
            get { return entradaPorVoz; }
            set { entradaPorVoz = value; }
        }

        public string Dificultad {
            get { return dificultad; }
            set { dificultad = value; }
        }

        internal DatosJugador NuevoJugador {
            get { return nuevoJugador; }
            set { nuevoJugador = value; }
        }

        private void btnAceptarConfigInicial_Click(object sender, EventArgs e) {
            if (txtNombreJu.Text != null && cmbSeleccionarDificultad.SelectedIndex > -1) {
                nuevoJugador = new DatosJugador(txtNombreJu.Text);
                dificultad = cmbSeleccionarDificultad.SelectedItem.ToString();
                if (rBtnVoz.Checked) {
                    entradaPorVoz = true;
                } else {
                    entradaPorVoz = false;
                }
                this.Visible = false;
            } else {
                MessageBox.Show("No hay nombre o nivel de dificultad seleccionado");
            }
        }
        
    }
}
