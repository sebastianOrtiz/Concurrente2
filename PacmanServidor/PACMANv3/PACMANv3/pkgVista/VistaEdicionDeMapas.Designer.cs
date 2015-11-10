namespace PACMANv3.pkgModelo {
    partial class VistaEdicionDeMapas {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaEdicionDeMapas));
            this.cmbMapas = new System.Windows.Forms.ComboBox();
            this.grdValoresMapa = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMapaSelect = new System.Windows.Forms.Label();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdValoresMapa)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMapas
            // 
            this.cmbMapas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapas.FormattingEnabled = true;
            this.cmbMapas.Location = new System.Drawing.Point(277, 41);
            this.cmbMapas.Name = "cmbMapas";
            this.cmbMapas.Size = new System.Drawing.Size(155, 21);
            this.cmbMapas.TabIndex = 0;
            this.cmbMapas.SelectionChangeCommitted += new System.EventHandler(this.cmbMapas_SelectionChangeCommitted);
            // 
            // grdValoresMapa
            // 
            this.grdValoresMapa.BackgroundColor = System.Drawing.Color.Black;
            this.grdValoresMapa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdValoresMapa.ColumnHeadersVisible = false;
            this.grdValoresMapa.Location = new System.Drawing.Point(12, 70);
            this.grdValoresMapa.Name = "grdValoresMapa";
            this.grdValoresMapa.RowHeadersVisible = false;
            this.grdValoresMapa.Size = new System.Drawing.Size(651, 310);
            this.grdValoresMapa.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(284, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selecciona un Mapa";
            // 
            // labelMapaSelect
            // 
            this.labelMapaSelect.AutoSize = true;
            this.labelMapaSelect.Location = new System.Drawing.Point(333, 25);
            this.labelMapaSelect.Name = "labelMapaSelect";
            this.labelMapaSelect.Size = new System.Drawing.Size(35, 13);
            this.labelMapaSelect.TabIndex = 5;
            this.labelMapaSelect.Text = "label2";
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGuardarCambios.Location = new System.Drawing.Point(12, 386);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(346, 23);
            this.btnGuardarCambios.TabIndex = 6;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = true;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(364, 386);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(299, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // VistaEdicionDeMapas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(675, 421);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.labelMapaSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdValoresMapa);
            this.Controls.Add(this.cmbMapas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VistaEdicionDeMapas";
            this.Text = "VistaEdicionDeMapas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VistaEdicionDeMapas_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grdValoresMapa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMapas;
        private System.Windows.Forms.DataGridView grdValoresMapa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMapaSelect;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnCancelar;
    }
}