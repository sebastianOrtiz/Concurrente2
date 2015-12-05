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
            this.lblPuntosYo = new System.Windows.Forms.Label();
            this.lblPuntosEnemigos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(127, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 468);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.pintar);
            // 
            // rTMensajes
            // 
            this.rTMensajes.Enabled = false;
            this.rTMensajes.Location = new System.Drawing.Point(650, 40);
            this.rTMensajes.Name = "rTMensajes";
            this.rTMensajes.Size = new System.Drawing.Size(268, 343);
            this.rTMensajes.TabIndex = 2;
            this.rTMensajes.Text = "";
            this.rTMensajes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cambiarDireccionPacman);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(650, 389);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(268, 20);
            this.txtMensaje.TabIndex = 3;
            this.txtMensaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cambiarDireccionPacman);
            // 
            // btnEnviarMensaje
            // 
            this.btnEnviarMensaje.BackColor = System.Drawing.Color.White;
            this.btnEnviarMensaje.Location = new System.Drawing.Point(650, 416);
            this.btnEnviarMensaje.Name = "btnEnviarMensaje";
            this.btnEnviarMensaje.Size = new System.Drawing.Size(268, 23);
            this.btnEnviarMensaje.TabIndex = 4;
            this.btnEnviarMensaje.Text = "Enviar";
            this.btnEnviarMensaje.UseVisualStyleBackColor = false;
            this.btnEnviarMensaje.Click += new System.EventHandler(this.btnEnviarMensaje_Click);
            this.btnEnviarMensaje.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cambiarDireccionPacman);
            // 
            // lblPuntosYo
            // 
            this.lblPuntosYo.AutoSize = true;
            this.lblPuntosYo.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntosYo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPuntosYo.Location = new System.Drawing.Point(12, 40);
            this.lblPuntosYo.Name = "lblPuntosYo";
            this.lblPuntosYo.Size = new System.Drawing.Size(63, 17);
            this.lblPuntosYo.TabIndex = 5;
            this.lblPuntosYo.Text = "PUNTOS";
            // 
            // lblPuntosEnemigos
            // 
            this.lblPuntosEnemigos.AutoSize = true;
            this.lblPuntosEnemigos.Font = new System.Drawing.Font("Ravie", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuntosEnemigos.ForeColor = System.Drawing.Color.Red;
            this.lblPuntosEnemigos.Location = new System.Drawing.Point(12, 57);
            this.lblPuntosEnemigos.Name = "lblPuntosEnemigos";
            this.lblPuntosEnemigos.Size = new System.Drawing.Size(63, 17);
            this.lblPuntosEnemigos.TabIndex = 6;
            this.lblPuntosEnemigos.Text = "PUNTOS";
            // 
            // VistaJuegoOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(930, 563);
            this.Controls.Add(this.lblPuntosEnemigos);
            this.Controls.Add(this.lblPuntosYo);
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
        private System.Windows.Forms.Label lblPuntosYo;
        private System.Windows.Forms.Label lblPuntosEnemigos;
    }
}