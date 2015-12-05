namespace PACMANv3 {
    partial class Form1 {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pruebasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAceptarConfigInicial = new System.Windows.Forms.Button();
            this.lblDificultad = new System.Windows.Forms.Label();
            this.cmbSeleccionarDificultad = new System.Windows.Forms.ComboBox();
            this.btnCrearMapa = new System.Windows.Forms.Button();
            this.btnEditarMapa = new System.Windows.Forms.Button();
            this.panelConfigInicio = new System.Windows.Forms.Panel();
            this.btnIniciarServ = new System.Windows.Forms.Button();
            this.lblNumJugadores = new System.Windows.Forms.Label();
            this.numDDJugadores = new System.Windows.Forms.NumericUpDown();
            this.lblSeleccioneMapa = new System.Windows.Forms.Label();
            this.cmbSeleccionMapa = new System.Windows.Forms.ComboBox();
            this.btnIntPuntajes = new System.Windows.Forms.Button();
            this.panelPuntajes = new System.Windows.Forms.Panel();
            this.lblFechaDat = new System.Windows.Forms.Label();
            this.lblPtsDat = new System.Windows.Forms.Label();
            this.lblDifDatos = new System.Windows.Forms.Label();
            this.btnAceptarDatos = new System.Windows.Forms.Button();
            this.lblListadoDatos = new System.Windows.Forms.Label();
            this.panelConfigInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDDJugadores)).BeginInit();
            this.panelPuntajes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pruebasToolStripMenuItem
            // 
            this.pruebasToolStripMenuItem.Name = "pruebasToolStripMenuItem";
            this.pruebasToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // btnAceptarConfigInicial
            // 
            this.btnAceptarConfigInicial.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnAceptarConfigInicial.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptarConfigInicial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarConfigInicial.Image = global::PACMANv3.Properties.Resources.BtnJugar;
            this.btnAceptarConfigInicial.Location = new System.Drawing.Point(438, 213);
            this.btnAceptarConfigInicial.Name = "btnAceptarConfigInicial";
            this.btnAceptarConfigInicial.Size = new System.Drawing.Size(224, 114);
            this.btnAceptarConfigInicial.TabIndex = 15;
            this.btnAceptarConfigInicial.UseVisualStyleBackColor = false;
            this.btnAceptarConfigInicial.Click += new System.EventHandler(this.btnAceptarConfigInicial_Click);
            // 
            // lblDificultad
            // 
            this.lblDificultad.AutoSize = true;
            this.lblDificultad.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblDificultad.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDificultad.ForeColor = System.Drawing.Color.White;
            this.lblDificultad.Location = new System.Drawing.Point(414, 117);
            this.lblDificultad.Name = "lblDificultad";
            this.lblDificultad.Size = new System.Drawing.Size(164, 17);
            this.lblDificultad.TabIndex = 14;
            this.lblDificultad.Text = "Seleccione dificultad:";
            // 
            // cmbSeleccionarDificultad
            // 
            this.cmbSeleccionarDificultad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeleccionarDificultad.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSeleccionarDificultad.FormattingEnabled = true;
            this.cmbSeleccionarDificultad.Items.AddRange(new object[] {
            "Facil",
            "Medio",
            "Dificil"});
            this.cmbSeleccionarDificultad.Location = new System.Drawing.Point(576, 114);
            this.cmbSeleccionarDificultad.Name = "cmbSeleccionarDificultad";
            this.cmbSeleccionarDificultad.Size = new System.Drawing.Size(203, 25);
            this.cmbSeleccionarDificultad.TabIndex = 13;
            // 
            // btnCrearMapa
            // 
            this.btnCrearMapa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearMapa.Image = global::PACMANv3.Properties.Resources.CrearMapa;
            this.btnCrearMapa.Location = new System.Drawing.Point(487, 324);
            this.btnCrearMapa.Name = "btnCrearMapa";
            this.btnCrearMapa.Size = new System.Drawing.Size(104, 105);
            this.btnCrearMapa.TabIndex = 21;
            this.btnCrearMapa.UseVisualStyleBackColor = true;
            this.btnCrearMapa.Click += new System.EventHandler(this.btnCrearMapa_Click);
            // 
            // btnEditarMapa
            // 
            this.btnEditarMapa.Image = global::PACMANv3.Properties.Resources.EditarMapa;
            this.btnEditarMapa.Location = new System.Drawing.Point(610, 324);
            this.btnEditarMapa.Name = "btnEditarMapa";
            this.btnEditarMapa.Size = new System.Drawing.Size(101, 105);
            this.btnEditarMapa.TabIndex = 22;
            this.btnEditarMapa.UseVisualStyleBackColor = true;
            this.btnEditarMapa.Click += new System.EventHandler(this.btnEditarMapa_Click);
            // 
            // panelConfigInicio
            // 
            this.panelConfigInicio.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelConfigInicio.BackgroundImage = global::PACMANv3.Properties.Resources.FondoInicioPacman;
            this.panelConfigInicio.Controls.Add(this.btnIniciarServ);
            this.panelConfigInicio.Controls.Add(this.lblNumJugadores);
            this.panelConfigInicio.Controls.Add(this.numDDJugadores);
            this.panelConfigInicio.Controls.Add(this.lblSeleccioneMapa);
            this.panelConfigInicio.Controls.Add(this.cmbSeleccionMapa);
            this.panelConfigInicio.Controls.Add(this.btnIntPuntajes);
            this.panelConfigInicio.Controls.Add(this.btnEditarMapa);
            this.panelConfigInicio.Controls.Add(this.btnCrearMapa);
            this.panelConfigInicio.Controls.Add(this.cmbSeleccionarDificultad);
            this.panelConfigInicio.Controls.Add(this.lblDificultad);
            this.panelConfigInicio.Controls.Add(this.btnAceptarConfigInicial);
            this.panelConfigInicio.Location = new System.Drawing.Point(-1, 1);
            this.panelConfigInicio.Name = "panelConfigInicio";
            this.panelConfigInicio.Size = new System.Drawing.Size(793, 458);
            this.panelConfigInicio.TabIndex = 23;
            // 
            // btnIniciarServ
            // 
            this.btnIniciarServ.BackColor = System.Drawing.Color.White;
            this.btnIniciarServ.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarServ.ForeColor = System.Drawing.Color.Black;
            this.btnIniciarServ.Location = new System.Drawing.Point(645, 20);
            this.btnIniciarServ.Name = "btnIniciarServ";
            this.btnIniciarServ.Size = new System.Drawing.Size(134, 23);
            this.btnIniciarServ.TabIndex = 28;
            this.btnIniciarServ.Text = "Iniciar Serrvidor";
            this.btnIniciarServ.UseVisualStyleBackColor = false;
            this.btnIniciarServ.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblNumJugadores
            // 
            this.lblNumJugadores.AutoSize = true;
            this.lblNumJugadores.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumJugadores.ForeColor = System.Drawing.Color.White;
            this.lblNumJugadores.Location = new System.Drawing.Point(468, 22);
            this.lblNumJugadores.Name = "lblNumJugadores";
            this.lblNumJugadores.Size = new System.Drawing.Size(100, 17);
            this.lblNumJugadores.TabIndex = 27;
            this.lblNumJugadores.Text = "Nº Jugadores";
            // 
            // numDDJugadores
            // 
            this.numDDJugadores.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDDJugadores.Location = new System.Drawing.Point(574, 20);
            this.numDDJugadores.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numDDJugadores.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDDJugadores.Name = "numDDJugadores";
            this.numDDJugadores.Size = new System.Drawing.Size(67, 22);
            this.numDDJugadores.TabIndex = 26;
            this.numDDJugadores.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSeleccioneMapa
            // 
            this.lblSeleccioneMapa.AutoSize = true;
            this.lblSeleccioneMapa.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccioneMapa.ForeColor = System.Drawing.Color.White;
            this.lblSeleccioneMapa.Location = new System.Drawing.Point(414, 53);
            this.lblSeleccioneMapa.Name = "lblSeleccioneMapa";
            this.lblSeleccioneMapa.Size = new System.Drawing.Size(153, 17);
            this.lblSeleccioneMapa.TabIndex = 25;
            this.lblSeleccioneMapa.Text = "Selecciona un Mapa:";
            // 
            // cmbSeleccionMapa
            // 
            this.cmbSeleccionMapa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeleccionMapa.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSeleccionMapa.FormattingEnabled = true;
            this.cmbSeleccionMapa.Location = new System.Drawing.Point(576, 50);
            this.cmbSeleccionMapa.Name = "cmbSeleccionMapa";
            this.cmbSeleccionMapa.Size = new System.Drawing.Size(203, 25);
            this.cmbSeleccionMapa.TabIndex = 24;
            this.cmbSeleccionMapa.SelectionChangeCommitted += new System.EventHandler(this.cmbSeleccionMapa_SelectionChangeCommitted);
            // 
            // btnIntPuntajes
            // 
            this.btnIntPuntajes.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnIntPuntajes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIntPuntajes.Image = global::PACMANv3.Properties.Resources.historial;
            this.btnIntPuntajes.Location = new System.Drawing.Point(372, 324);
            this.btnIntPuntajes.Name = "btnIntPuntajes";
            this.btnIntPuntajes.Size = new System.Drawing.Size(109, 105);
            this.btnIntPuntajes.TabIndex = 23;
            this.btnIntPuntajes.UseVisualStyleBackColor = false;
            this.btnIntPuntajes.Click += new System.EventHandler(this.btnIntPuntajes_Click);
            // 
            // panelPuntajes
            // 
            this.panelPuntajes.BackgroundImage = global::PACMANv3.Properties.Resources.FondoInicioPacman;
            this.panelPuntajes.Controls.Add(this.lblFechaDat);
            this.panelPuntajes.Controls.Add(this.lblPtsDat);
            this.panelPuntajes.Controls.Add(this.lblDifDatos);
            this.panelPuntajes.Controls.Add(this.btnAceptarDatos);
            this.panelPuntajes.Controls.Add(this.lblListadoDatos);
            this.panelPuntajes.Location = new System.Drawing.Point(-1, 1);
            this.panelPuntajes.Name = "panelPuntajes";
            this.panelPuntajes.Size = new System.Drawing.Size(173, 458);
            this.panelPuntajes.TabIndex = 23;
            this.panelPuntajes.Visible = false;
            // 
            // lblFechaDat
            // 
            this.lblFechaDat.AutoSize = true;
            this.lblFechaDat.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblFechaDat.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDat.ForeColor = System.Drawing.Color.White;
            this.lblFechaDat.Location = new System.Drawing.Point(624, 58);
            this.lblFechaDat.Name = "lblFechaDat";
            this.lblFechaDat.Size = new System.Drawing.Size(49, 17);
            this.lblFechaDat.TabIndex = 4;
            this.lblFechaDat.Text = "fecha";
            // 
            // lblPtsDat
            // 
            this.lblPtsDat.AutoSize = true;
            this.lblPtsDat.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblPtsDat.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPtsDat.ForeColor = System.Drawing.Color.White;
            this.lblPtsDat.Location = new System.Drawing.Point(535, 58);
            this.lblPtsDat.Name = "lblPtsDat";
            this.lblPtsDat.Size = new System.Drawing.Size(59, 17);
            this.lblPtsDat.TabIndex = 3;
            this.lblPtsDat.Text = "Puntos";
            // 
            // lblDifDatos
            // 
            this.lblDifDatos.AutoSize = true;
            this.lblDifDatos.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblDifDatos.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifDatos.ForeColor = System.Drawing.Color.White;
            this.lblDifDatos.Location = new System.Drawing.Point(484, 58);
            this.lblDifDatos.Name = "lblDifDatos";
            this.lblDifDatos.Size = new System.Drawing.Size(90, 17);
            this.lblDifDatos.TabIndex = 2;
            this.lblDifDatos.Text = "lblDifDatos";
            // 
            // btnAceptarDatos
            // 
            this.btnAceptarDatos.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnAceptarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptarDatos.Image = global::PACMANv3.Properties.Resources.inicio;
            this.btnAceptarDatos.Location = new System.Drawing.Point(365, 295);
            this.btnAceptarDatos.Name = "btnAceptarDatos";
            this.btnAceptarDatos.Size = new System.Drawing.Size(297, 124);
            this.btnAceptarDatos.TabIndex = 1;
            this.btnAceptarDatos.UseVisualStyleBackColor = false;
            this.btnAceptarDatos.Click += new System.EventHandler(this.btnAceptarDatos_Click);
            // 
            // lblListadoDatos
            // 
            this.lblListadoDatos.AutoSize = true;
            this.lblListadoDatos.BackColor = System.Drawing.SystemColors.ControlText;
            this.lblListadoDatos.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListadoDatos.ForeColor = System.Drawing.Color.White;
            this.lblListadoDatos.Location = new System.Drawing.Point(373, 58);
            this.lblListadoDatos.Name = "lblListadoDatos";
            this.lblListadoDatos.Size = new System.Drawing.Size(51, 17);
            this.lblListadoDatos.TabIndex = 0;
            this.lblListadoDatos.Text = "Datos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(790, 460);
            this.Controls.Add(this.panelPuntajes);
            this.Controls.Add(this.panelConfigInicio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelConfigInicio.ResumeLayout(false);
            this.panelConfigInicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDDJugadores)).EndInit();
            this.panelPuntajes.ResumeLayout(false);
            this.panelPuntajes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem pruebasToolStripMenuItem;
        private System.Windows.Forms.Button btnAceptarConfigInicial;
        private System.Windows.Forms.Label lblDificultad;
        private System.Windows.Forms.ComboBox cmbSeleccionarDificultad;
        private System.Windows.Forms.Button btnCrearMapa;
        private System.Windows.Forms.Button btnEditarMapa;
        private System.Windows.Forms.Panel panelConfigInicio;
        private System.Windows.Forms.Panel panelPuntajes;
        private System.Windows.Forms.Label lblListadoDatos;
        private System.Windows.Forms.Button btnAceptarDatos;
        private System.Windows.Forms.Button btnIntPuntajes;
        private System.Windows.Forms.Label lblFechaDat;
        private System.Windows.Forms.Label lblPtsDat;
        private System.Windows.Forms.Label lblDifDatos;
        private System.Windows.Forms.ComboBox cmbSeleccionMapa;
        private System.Windows.Forms.Label lblSeleccioneMapa;
        private System.Windows.Forms.Button btnIniciarServ;
        private System.Windows.Forms.Label lblNumJugadores;
        private System.Windows.Forms.NumericUpDown numDDJugadores;
    }
}

