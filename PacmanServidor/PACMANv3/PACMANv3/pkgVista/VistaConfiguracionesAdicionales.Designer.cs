namespace PACMANv3.pkgVista {
    partial class VistaConfiguracionesAdicionales {
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
            this.lblHPPACMAN = new System.Windows.Forms.Label();
            this.lblNumVidas = new System.Windows.Forms.Label();
            this.txtHPPACKMAN = new System.Windows.Forms.TextBox();
            this.txtNumVidas = new System.Windows.Forms.TextBox();
            this.btnAceptarConfigAdicionales = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHPPACMAN
            // 
            this.lblHPPACMAN.AutoSize = true;
            this.lblHPPACMAN.Location = new System.Drawing.Point(13, 13);
            this.lblHPPACMAN.Name = "lblHPPACMAN";
            this.lblHPPACMAN.Size = new System.Drawing.Size(85, 13);
            this.lblHPPACMAN.TabIndex = 0;
            this.lblHPPACMAN.Text = "HP de PACMAN";
            // 
            // lblNumVidas
            // 
            this.lblNumVidas.AutoSize = true;
            this.lblNumVidas.Location = new System.Drawing.Point(133, 13);
            this.lblNumVidas.Name = "lblNumVidas";
            this.lblNumVidas.Size = new System.Drawing.Size(88, 13);
            this.lblNumVidas.TabIndex = 1;
            this.lblNumVidas.Text = "Numero de Vidas";
            // 
            // txtHPPACKMAN
            // 
            this.txtHPPACKMAN.Location = new System.Drawing.Point(13, 30);
            this.txtHPPACKMAN.Name = "txtHPPACKMAN";
            this.txtHPPACKMAN.Size = new System.Drawing.Size(100, 20);
            this.txtHPPACKMAN.TabIndex = 2;
            // 
            // txtNumVidas
            // 
            this.txtNumVidas.Location = new System.Drawing.Point(136, 30);
            this.txtNumVidas.Name = "txtNumVidas";
            this.txtNumVidas.Size = new System.Drawing.Size(100, 20);
            this.txtNumVidas.TabIndex = 3;
            // 
            // btnAceptarConfigAdicionales
            // 
            this.btnAceptarConfigAdicionales.Location = new System.Drawing.Point(16, 56);
            this.btnAceptarConfigAdicionales.Name = "btnAceptarConfigAdicionales";
            this.btnAceptarConfigAdicionales.Size = new System.Drawing.Size(220, 23);
            this.btnAceptarConfigAdicionales.TabIndex = 4;
            this.btnAceptarConfigAdicionales.Text = "Aceptar";
            this.btnAceptarConfigAdicionales.UseVisualStyleBackColor = true;
            // 
            // VistaConfiguracionesAdicionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 89);
            this.Controls.Add(this.btnAceptarConfigAdicionales);
            this.Controls.Add(this.txtNumVidas);
            this.Controls.Add(this.txtHPPACKMAN);
            this.Controls.Add(this.lblNumVidas);
            this.Controls.Add(this.lblHPPACMAN);
            this.Name = "VistaConfiguracionesAdicionales";
            this.Text = "VistaConfiguracionesAdicionales";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHPPACMAN;
        private System.Windows.Forms.Label lblNumVidas;
        private System.Windows.Forms.TextBox txtHPPACKMAN;
        private System.Windows.Forms.TextBox txtNumVidas;
        private System.Windows.Forms.Button btnAceptarConfigAdicionales;
    }
}