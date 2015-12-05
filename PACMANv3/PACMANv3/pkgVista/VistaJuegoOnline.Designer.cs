namespace PACMANv3.pkgVista
{
    partial class VistaJuegoOnline
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.rTMensajes = new System.Windows.Forms.RichTextBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.btnEnviarMensaje = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(65, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 468);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.pintar);
            // 
            // rTMensajes
            // 
            this.rTMensajes.Location = new System.Drawing.Point(609, 40);
            this.rTMensajes.Name = "rTMensajes";
            this.rTMensajes.Size = new System.Drawing.Size(268, 343);
            this.rTMensajes.TabIndex = 2;
            this.rTMensajes.Text = "";
            this.rTMensajes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cambiarDireccionPacman);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(609, 389);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(268, 20);
            this.txtMensaje.TabIndex = 3;
            this.txtMensaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cambiarDireccionPacman);
            // 
            // btnEnviarMensaje
            // 
            this.btnEnviarMensaje.BackColor = System.Drawing.Color.White;
            this.btnEnviarMensaje.Location = new System.Drawing.Point(609, 416);
            this.btnEnviarMensaje.Name = "btnEnviarMensaje";
            this.btnEnviarMensaje.Size = new System.Drawing.Size(268, 23);
            this.btnEnviarMensaje.TabIndex = 4;
            this.btnEnviarMensaje.Text = "Enviar";
            this.btnEnviarMensaje.UseVisualStyleBackColor = false;
            this.btnEnviarMensaje.Click += new System.EventHandler(this.btnEnviarMensaje_Click);
            this.btnEnviarMensaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cambiarDireccionPacman);
            // 
            // VistaJuegoOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(889, 563);
            this.Controls.Add(this.btnEnviarMensaje);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.rTMensajes);
            this.Controls.Add(this.panel1);
            this.Name = "VistaJuegoOnline";
            this.Text = "VistaJuegoOnline";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VistaJuegoOnline_FormClosing);
            this.Load += new System.EventHandler(this.VistaJuegoOnline_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cambiarDireccionPacman);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rTMensajes;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btnEnviarMensaje;
    }
}