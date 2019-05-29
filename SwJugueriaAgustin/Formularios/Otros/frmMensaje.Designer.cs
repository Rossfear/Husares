namespace SwJugueriaAgustin.Formularios
{
    partial class frmMensaje
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
            this.components = new System.ComponentModel.Container();
            this.lblmensaje = new System.Windows.Forms.Label();
            this.tmrCierre = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblmensaje
            // 
            this.lblmensaje.Font = new System.Drawing.Font("Cambria", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmensaje.Location = new System.Drawing.Point(12, 9);
            this.lblmensaje.Name = "lblmensaje";
            this.lblmensaje.Size = new System.Drawing.Size(407, 144);
            this.lblmensaje.TabIndex = 0;
            this.lblmensaje.Text = "Ingrese Cantidad";
            this.lblmensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrCierre
            // 
            this.tmrCierre.Interval = 2000;
            this.tmrCierre.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(426, 171);
            this.Controls.Add(this.lblmensaje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMensaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "San Aguistin";
            this.Load += new System.EventHandler(this.frmMensaje_Load);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label lblmensaje;
        public System.Windows.Forms.Timer tmrCierre;
    }
}