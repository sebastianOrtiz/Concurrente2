namespace PACMANv3.pkgVista {
    partial class VistaJuego {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaJuego));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGuardarPuntuacion = new System.Windows.Forms.Button();
            this.lblPuntaje = new System.Windows.Forms.Label();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblOrdenesEnCola = new System.Windows.Forms.Label();
            this.lblPalabra = new System.Windows.Forms.Label();
            this.lblVidasPac = new System.Windows.Forms.Label();
            this.lblNombreJugador = new System.Windows.Forms.Label();
            this.lblNombreFinal = new System.Windows.Forms.Label();
            this.lblPuntosFinal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(141, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 596);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.pintar);
            // 
            // btnGuardarPuntuacion
            // 
            this.btnGuardarPuntuacion.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGuardarPuntuacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarPuntuacion.Image = global::PACMANv3.Properties.Resources.guardar;
            this.btnGuardarPuntuacion.Location = new System.Drawing.Point(332, 483);
            this.btnGuardarPuntuacion.Name = "btnGuardarPuntuacion";
            this.btnGuardarPuntuacion.Size = new System.Drawing.Size(108, 118);
            this.btnGuardarPuntuacion.TabIndex = 0;
            this.btnGuardarPuntuacion.UseVisualStyleBackColor = true;
            this.btnGuardarPuntuacion.Visible = false;
            this.btnGuardarPuntuacion.Click += new System.EventHandler(this.btnGuardarPuntuacion_Click);
            // 
            // lblPuntaje
            // 
            this.lblPuntaje.AutoSize = true;
            this.lblPuntaje.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntaje.ForeColor = System.Drawing.Color.White;
            this.lblPuntaje.Location = new System.Drawing.Point(12, 59);
            this.lblPuntaje.Name = "lblPuntaje";
            this.lblPuntaje.Size = new System.Drawing.Size(92, 17);
            this.lblPuntaje.TabIndex = 1;
            this.lblPuntaje.Text = "Puntaje: ...";
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.ForeColor = System.Drawing.Color.White;
            this.lblTiempo.Location = new System.Drawing.Point(12, 9);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(84, 17);
            this.lblTiempo.TabIndex = 2;
            this.lblTiempo.Text = "Tiempo: ...";
            // 
            // lblOrdenesEnCola
            // 
            this.lblOrdenesEnCola.AutoSize = true;
            this.lblOrdenesEnCola.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrdenesEnCola.ForeColor = System.Drawing.Color.White;
            this.lblOrdenesEnCola.Location = new System.Drawing.Point(12, 76);
            this.lblOrdenesEnCola.Name = "lblOrdenesEnCola";
            this.lblOrdenesEnCola.Size = new System.Drawing.Size(123, 17);
            this.lblOrdenesEnCola.TabIndex = 3;
            this.lblOrdenesEnCola.Text = "Ordenes en cola:";
            // 
            // lblPalabra
            // 
            this.lblPalabra.AutoSize = true;
            this.lblPalabra.ForeColor = System.Drawing.Color.White;
            this.lblPalabra.Location = new System.Drawing.Point(598, 27);
            this.lblPalabra.Name = "lblPalabra";
            this.lblPalabra.Size = new System.Drawing.Size(35, 13);
            this.lblPalabra.TabIndex = 4;
            this.lblPalabra.Text = "label1";
            // 
            // lblVidasPac
            // 
            this.lblVidasPac.AutoSize = true;
            this.lblVidasPac.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVidasPac.ForeColor = System.Drawing.Color.White;
            this.lblVidasPac.Location = new System.Drawing.Point(217, 9);
            this.lblVidasPac.Name = "lblVidasPac";
            this.lblVidasPac.Size = new System.Drawing.Size(48, 17);
            this.lblVidasPac.TabIndex = 5;
            this.lblVidasPac.Text = "Vidas";
            // 
            // lblNombreJugador
            // 
            this.lblNombreJugador.AutoSize = true;
            this.lblNombreJugador.Font = new System.Drawing.Font("Ravie", 15F);
            this.lblNombreJugador.ForeColor = System.Drawing.Color.White;
            this.lblNombreJugador.Location = new System.Drawing.Point(309, 0);
            this.lblNombreJugador.Name = "lblNombreJugador";
            this.lblNombreJugador.Size = new System.Drawing.Size(119, 27);
            this.lblNombreJugador.TabIndex = 6;
            this.lblNombreJugador.Text = "Jugador";
            // 
            // lblNombreFinal
            // 
            this.lblNombreFinal.AutoSize = true;
            this.lblNombreFinal.BackColor = System.Drawing.Color.Black;
            this.lblNombreFinal.Font = new System.Drawing.Font("Ravie", 20F);
            this.lblNombreFinal.ForeColor = System.Drawing.Color.White;
            this.lblNombreFinal.Location = new System.Drawing.Point(177, 436);
            this.lblNombreFinal.Name = "lblNombreFinal";
            this.lblNombreFinal.Size = new System.Drawing.Size(149, 36);
            this.lblNombreFinal.TabIndex = 7;
            this.lblNombreFinal.Text = "nombre";
            this.lblNombreFinal.Visible = false;
            // 
            // lblPuntosFinal
            // 
            this.lblPuntosFinal.AutoSize = true;
            this.lblPuntosFinal.Font = new System.Drawing.Font("Ravie", 20F);
            this.lblPuntosFinal.ForeColor = System.Drawing.Color.White;
            this.lblPuntosFinal.Location = new System.Drawing.Point(455, 436);
            this.lblPuntosFinal.Name = "lblPuntosFinal";
            this.lblPuntosFinal.Size = new System.Drawing.Size(140, 36);
            this.lblPuntosFinal.TabIndex = 8;
            this.lblPuntosFinal.Text = "Puntos";
            this.lblPuntosFinal.Visible = false;
            // 
            // VistaJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(749, 667);
            this.Controls.Add(this.lblPuntosFinal);
            this.Controls.Add(this.lblNombreJugador);
            this.Controls.Add(this.lblNombreFinal);
            this.Controls.Add(this.btnGuardarPuntuacion);
            this.Controls.Add(this.lblVidasPac);
            this.Controls.Add(this.lblPalabra);
            this.Controls.Add(this.lblOrdenesEnCola);
            this.Controls.Add(this.lblTiempo);
            this.Controls.Add(this.lblPuntaje);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VistaJuego";
            this.Text = "VistaJuego";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cerrarForm);
            this.Load += new System.EventHandler(this.VistaJuego_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cambiarDireccionPacman);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPuntaje;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label lblOrdenesEnCola;
        private System.Windows.Forms.Label lblPalabra;
        private System.Windows.Forms.Label lblVidasPac;
        private System.Windows.Forms.Button btnGuardarPuntuacion;
        private System.Windows.Forms.Label lblNombreJugador;
        private System.Windows.Forms.Label lblNombreFinal;
        private System.Windows.Forms.Label lblPuntosFinal;
    }
}