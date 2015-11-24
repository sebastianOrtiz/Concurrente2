namespace PACMANv3.pkgVista {
    partial class VistaCreacionDeMapas {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaCreacionDeMapas));
            this.lblFilasMapas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptarConf = new System.Windows.Forms.Button();
            this.cmbNivel = new System.Windows.Forms.ComboBox();
            this.lblDificultad = new System.Windows.Forms.Label();
            this.grdMapa = new System.Windows.Forms.DataGridView();
            this.btnListo = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.cmbDificultad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuarConfDeMapa = new System.Windows.Forms.Button();
            this.btnModificarCeldas = new System.Windows.Forms.Button();
            this.nudFilas = new System.Windows.Forms.NumericUpDown();
            this.nudColumnas = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.grdMapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFilas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumnas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFilasMapas
            // 
            this.lblFilasMapas.AutoSize = true;
            this.lblFilasMapas.ForeColor = System.Drawing.Color.White;
            this.lblFilasMapas.Location = new System.Drawing.Point(377, 12);
            this.lblFilasMapas.Name = "lblFilasMapas";
            this.lblFilasMapas.Size = new System.Drawing.Size(64, 13);
            this.lblFilasMapas.TabIndex = 2;
            this.lblFilasMapas.Text = "Filas (---) 5 +";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(498, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Columnas (|||) 5 +";
            // 
            // btnAceptarConf
            // 
            this.btnAceptarConf.BackColor = System.Drawing.Color.White;
            this.btnAceptarConf.Location = new System.Drawing.Point(636, 6);
            this.btnAceptarConf.Name = "btnAceptarConf";
            this.btnAceptarConf.Size = new System.Drawing.Size(66, 24);
            this.btnAceptarConf.TabIndex = 4;
            this.btnAceptarConf.Text = "Aceptar";
            this.btnAceptarConf.UseVisualStyleBackColor = false;
            this.btnAceptarConf.Click += new System.EventHandler(this.btnAceptarConf_Click);
            // 
            // cmbNivel
            // 
            this.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNivel.FormattingEnabled = true;
            this.cmbNivel.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cmbNivel.Location = new System.Drawing.Point(176, 9);
            this.cmbNivel.Name = "cmbNivel";
            this.cmbNivel.Size = new System.Drawing.Size(39, 21);
            this.cmbNivel.TabIndex = 5;
            // 
            // lblDificultad
            // 
            this.lblDificultad.AutoSize = true;
            this.lblDificultad.ForeColor = System.Drawing.Color.White;
            this.lblDificultad.Location = new System.Drawing.Point(139, 12);
            this.lblDificultad.Name = "lblDificultad";
            this.lblDificultad.Size = new System.Drawing.Size(31, 13);
            this.lblDificultad.TabIndex = 6;
            this.lblDificultad.Text = "Nivel";
            // 
            // grdMapa
            // 
            this.grdMapa.AllowUserToAddRows = false;
            this.grdMapa.AllowUserToDeleteRows = false;
            this.grdMapa.AllowUserToResizeColumns = false;
            this.grdMapa.AllowUserToResizeRows = false;
            this.grdMapa.BackgroundColor = System.Drawing.Color.Black;
            this.grdMapa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grdMapa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMapa.ColumnHeadersVisible = false;
            this.grdMapa.Cursor = System.Windows.Forms.Cursors.Arrow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdMapa.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdMapa.Location = new System.Drawing.Point(11, 36);
            this.grdMapa.Name = "grdMapa";
            this.grdMapa.RowHeadersVisible = false;
            this.grdMapa.Size = new System.Drawing.Size(684, 469);
            this.grdMapa.TabIndex = 7;
            this.grdMapa.Visible = false;
            this.grdMapa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMapa_CellContentClick);
            // 
            // btnListo
            // 
            this.btnListo.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnListo.Location = new System.Drawing.Point(479, 511);
            this.btnListo.Name = "btnListo";
            this.btnListo.Size = new System.Drawing.Size(216, 23);
            this.btnListo.TabIndex = 8;
            this.btnListo.Text = "Listo";
            this.btnListo.UseVisualStyleBackColor = true;
            this.btnListo.Click += new System.EventHandler(this.btnListo_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(59, 9);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(69, 20);
            this.txtNombre.TabIndex = 9;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(9, 12);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "Nombre";
            // 
            // cmbDificultad
            // 
            this.cmbDificultad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDificultad.FormattingEnabled = true;
            this.cmbDificultad.Items.AddRange(new object[] {
            "Facil",
            "Medio",
            "Dificil"});
            this.cmbDificultad.Location = new System.Drawing.Point(278, 9);
            this.cmbDificultad.Name = "cmbDificultad";
            this.cmbDificultad.Size = new System.Drawing.Size(93, 21);
            this.cmbDificultad.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(221, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Dificultad";
            // 
            // btnGuarConfDeMapa
            // 
            this.btnGuarConfDeMapa.Location = new System.Drawing.Point(12, 511);
            this.btnGuarConfDeMapa.Name = "btnGuarConfDeMapa";
            this.btnGuarConfDeMapa.Size = new System.Drawing.Size(228, 23);
            this.btnGuarConfDeMapa.TabIndex = 13;
            this.btnGuarConfDeMapa.Text = "Guardar configuracion de Mapa";
            this.btnGuarConfDeMapa.UseVisualStyleBackColor = true;
            this.btnGuarConfDeMapa.Click += new System.EventHandler(this.btnGuarConfDeMapa_Click);
            // 
            // btnModificarCeldas
            // 
            this.btnModificarCeldas.Location = new System.Drawing.Point(246, 511);
            this.btnModificarCeldas.Name = "btnModificarCeldas";
            this.btnModificarCeldas.Size = new System.Drawing.Size(227, 23);
            this.btnModificarCeldas.TabIndex = 14;
            this.btnModificarCeldas.Text = "Modificar Celdas";
            this.btnModificarCeldas.UseVisualStyleBackColor = true;
            this.btnModificarCeldas.Click += new System.EventHandler(this.btnModificarCeldas_Click);
            // 
            // nudFilas
            // 
            this.nudFilas.Location = new System.Drawing.Point(447, 9);
            this.nudFilas.Name = "nudFilas";
            this.nudFilas.Size = new System.Drawing.Size(44, 20);
            this.nudFilas.TabIndex = 15;
            // 
            // nudColumnas
            // 
            this.nudColumnas.Location = new System.Drawing.Point(590, 9);
            this.nudColumnas.Name = "nudColumnas";
            this.nudColumnas.Size = new System.Drawing.Size(40, 20);
            this.nudColumnas.TabIndex = 16;
            // 
            // VistaCreacionDeMapas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(708, 546);
            this.Controls.Add(this.nudColumnas);
            this.Controls.Add(this.nudFilas);
            this.Controls.Add(this.btnModificarCeldas);
            this.Controls.Add(this.btnGuarConfDeMapa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDificultad);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnListo);
            this.Controls.Add(this.grdMapa);
            this.Controls.Add(this.lblDificultad);
            this.Controls.Add(this.cmbNivel);
            this.Controls.Add(this.btnAceptarConf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFilasMapas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VistaCreacionDeMapas";
            this.Text = "VistaCreacionDeMapas";
            ((System.ComponentModel.ISupportInitialize)(this.grdMapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFilas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudColumnas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFilasMapas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptarConf;
        private System.Windows.Forms.ComboBox cmbNivel;
        private System.Windows.Forms.Label lblDificultad;
        private System.Windows.Forms.DataGridView grdMapa;
        private System.Windows.Forms.Button btnListo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.ComboBox cmbDificultad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuarConfDeMapa;
        private System.Windows.Forms.Button btnModificarCeldas;
        private System.Windows.Forms.NumericUpDown nudFilas;
        private System.Windows.Forms.NumericUpDown nudColumnas;
    }
}