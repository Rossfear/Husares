namespace SwJugueriaAgustin.Formularios.Operaciones
{
    partial class FrmCambiarPass
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpassActual = new System.Windows.Forms.TextBox();
            this.txtnueva = new System.Windows.Forms.TextBox();
            this.txtconfrimar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contraseña Actual:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña Nueva:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirma Contraseña:";
            // 
            // txtpassActual
            // 
            this.txtpassActual.Location = new System.Drawing.Point(134, 54);
            this.txtpassActual.Name = "txtpassActual";
            this.txtpassActual.PasswordChar = '*';
            this.txtpassActual.Size = new System.Drawing.Size(162, 20);
            this.txtpassActual.TabIndex = 3;
            // 
            // txtnueva
            // 
            this.txtnueva.Location = new System.Drawing.Point(134, 94);
            this.txtnueva.Name = "txtnueva";
            this.txtnueva.PasswordChar = '*';
            this.txtnueva.Size = new System.Drawing.Size(162, 20);
            this.txtnueva.TabIndex = 4;
            // 
            // txtconfrimar
            // 
            this.txtconfrimar.Location = new System.Drawing.Point(134, 135);
            this.txtconfrimar.Name = "txtconfrimar";
            this.txtconfrimar.PasswordChar = '*';
            this.txtconfrimar.Size = new System.Drawing.Size(162, 20);
            this.txtconfrimar.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Usuario:";
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.Location = new System.Drawing.Point(131, 11);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(46, 13);
            this.lblusuario.TabIndex = 7;
            this.lblusuario.Text = "Usuario:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 58);
            this.button1.TabIndex = 8;
            this.button1.Text = "Cambiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmCambiarPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 459);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtconfrimar);
            this.Controls.Add(this.txtnueva);
            this.Controls.Add(this.txtpassActual);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmCambiarPass";
            this.Text = "FrmCambiarPass";
            this.Load += new System.EventHandler(this.FrmCambiarPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtpassActual;
        private System.Windows.Forms.TextBox txtnueva;
        private System.Windows.Forms.TextBox txtconfrimar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Button button1;
    }
}