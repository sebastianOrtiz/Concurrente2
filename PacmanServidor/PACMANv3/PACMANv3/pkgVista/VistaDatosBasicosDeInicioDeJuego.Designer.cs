namespace PACMANv3.pkgVista {
    partial class VistaDatosBasicosDeInicioDeJuego {
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
            this.rBtnTeclado = new System.Windows.Forms.RadioButton();
            this.rBtnVoz = new System.Windows.Forms.RadioButton();
            this.lblMetodoDeEntrada = new System.Windows.Forms.Label();
            this.lblNombreJugador = new System.Windows.Forms.Label();
            this.cmbSeleccionarDificultad = new System.Windows.Forms.ComboBox();
            this.lblDificultad = new System.Windows.Forms.Label();
            this.btnAceptarConfigInicial = new System.Windows.Forms.Button();
            this.txtNombreJu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rBtnTeclado
            // 
            this.rBtnTeclado.AutoSize = true;
            this.rBtnTeclado.Location = new System.Drawing.Point(257, 29);
            this.rBtnTeclado.Name = "rBtnTeclado";
            this.rBtnTeclado.Size = new System.Drawing.Size(64, 17);
            this.rBtnTeclado.TabIndex = 0;
            this.rBtnTeclado.TabStop = true;
            this.rBtnTeclado.Text = "Teclado";
            this.rBtnTeclado.UseVisualStyleBackColor = true;
            // 
            // rBtnVoz
            // 
            this.rBtnVoz.AutoSize = true;
            this.rBtnVoz.Location = new System.Drawing.Point(327, 29);
            this.rBtnVoz.Name = "rBtnVoz";
            this.rBtnVoz.Size = new System.Drawing.Size(43, 17);
            this.rBtnVoz.TabIndex = 1;
            this.rBtnVoz.TabStop = true;
            this.rBtnVoz.Text = "Voz";
            this.rBtnVoz.UseVisualStyleBackColor = true;
            // 
            // lblMetodoDeEntrada
            // 
            this.lblMetodoDeEntrada.AutoSize = true;
            this.lblMetodoDeEntrada.Location = new System.Drawing.Point(254, 9);
            this.lblMetodoDeEntrada.Name = "lblMetodoDeEntrada";
            this.lblMetodoDeEntrada.Size = new System.Drawing.Size(100, 13);
            this.lblMetodoDeEntrada.TabIndex = 2;
            this.lblMetodoDeEntrada.Text = "Metodo de entrada:";
            // 
            // lblNombreJugador
            // 
            this.lblNombreJugador.AutoSize = true;
            this.lblNombreJugador.Location = new System.Drawing.Point(13, 9);
            this.lblNombreJugador.Name = "lblNombreJugador";
            this.lblNombreJugador.Size = new System.Drawing.Size(105, 13);
            this.lblNombreJugador.TabIndex = 3;
            this.lblNombreJugador.Text = "Nombre del Jugador:";
            // 
            // cmbSeleccionarDificultad
            // 
            this.cmbSeleccionarDificultad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeleccionarDificultad.FormattingEnabled = true;
            this.cmbSeleccionarDificultad.Items.AddRange(new object[] {
            "Facil",
            "Medio",
            "Dificil"});
            this.cmbSeleccionarDificultad.Location = new System.Drawing.Point(123, 27);
            this.cmbSeleccionarDificultad.Name = "cmbSeleccionarDificultad";
            this.cmbSeleccionarDificultad.Size = new System.Drawing.Size(121, 21);
            this.cmbSeleccionarDificultad.TabIndex = 5;
            // 
            // lblDificultad
            // 
            this.lblDificultad.AutoSize = true;
            this.lblDificultad.Location = new System.Drawing.Point(123, 9);
            this.lblDificultad.Name = "lblDificultad";
            this.lblDificultad.Size = new System.Drawing.Size(108, 13);
            this.lblDificultad.TabIndex = 6;
            this.lblDificultad.Text = "Seleccione dificultad:";
            // 
            // btnAceptarConfigInicial
            // 
            this.btnAceptarConfigInicial.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptarConfigInicial.Location = new System.Drawing.Point(16, 56);
            this.btnAceptarConfigInicial.Name = "btnAceptarConfigInicial";
            this.btnAceptarConfigInicial.Size = new System.Drawing.Size(354, 23);
            this.btnAceptarConfigInicial.TabIndex = 7;
            this.btnAceptarConfigInicial.Text = "Aceptar";
            this.btnAceptarConfigInicial.UseVisualStyleBackColor = true;
            this.btnAceptarConfigInicial.Click += new System.EventHandler(this.btnAceptarConfigInicial_Click);
            // 
            // txtNombreJu
            // 
            this.txtNombreJu.Location = new System.Drawing.Point(16, 29);
            this.txtNombreJu.Name = "txtNombreJu";
            this.txtNombreJu.Size = new System.Drawing.Size(100, 20);
            this.txtNombreJu.TabIndex = 8;
            // 
            // VistaDatosBasicosDeInicioDeJuego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 87);
            this.Controls.Add(this.txtNombreJu);
            this.Controls.Add(this.btnAceptarConfigInicial);
            this.Controls.Add(this.lblDificultad);
            this.Controls.Add(this.cmbSeleccionarDificultad);
            this.Controls.Add(this.lblNombreJugador);
            this.Controls.Add(this.lblMetodoDeEntrada);
            this.Controls.Add(this.rBtnVoz);
            this.Controls.Add(this.rBtnTeclado);
            this.Name = "VistaDatosBasicosDeInicioDeJuego";
            this.Text = "VistaDatosBasicosDeInicioDeJuego";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rBtnTeclado;
        private System.Windows.Forms.RadioButton rBtnVoz;
        private System.Windows.Forms.Label lblMetodoDeEntrada;
        private System.Windows.Forms.Label lblNombreJugador;
        private System.Windows.Forms.TextBox txtNombreJugador;
        private System.Windows.Forms.ComboBox cmbSeleccionarDificultad;
        private System.Windows.Forms.Label lblDificultad;
        private System.Windows.Forms.Button btnAceptarConfigInicial;
        private System.Windows.Forms.TextBox txtNombreJu;

  
    }
}