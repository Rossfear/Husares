namespace SwJugueriaAgustin.Formularios
{
    partial class frmBuscarRuc
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
            this.bto_agregar = new System.Windows.Forms.Button();
            this.txt_direccion = new System.Windows.Forms.TextBox();
            this.txt_tel = new System.Windows.Forms.TextBox();
            this.txtrazonsocial = new System.Windows.Forms.TextBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtruc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.pictureCapcha = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.chHabilitar = new System.Windows.Forms.CheckBox();
            this.txtReferecia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCapcha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // bto_agregar
            // 
            this.bto_agregar.BackColor = System.Drawing.Color.Teal;
            this.bto_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bto_agregar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bto_agregar.ForeColor = System.Drawing.Color.White;
            this.bto_agregar.Location = new System.Drawing.Point(204, 386);
            this.bto_agregar.Name = "bto_agregar";
            this.bto_agregar.Size = new System.Drawing.Size(469, 67);
            this.bto_agregar.TabIndex = 25;
            this.bto_agregar.Text = ".:: &Agregar ::.";
            this.bto_agregar.UseVisualStyleBackColor = false;
            this.bto_agregar.Click += new System.EventHandler(this.bto_agregar_Click);
            // 
            // txt_direccion
            // 
            this.txt_direccion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_direccion.Location = new System.Drawing.Point(101, 262);
            this.txt_direccion.Multiline = true;
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(572, 53);
            this.txt_direccion.TabIndex = 23;
            this.txt_direccion.Click += new System.EventHandler(this.txt_cod_Click);
            // 
            // txt_tel
            // 
            this.txt_tel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tel.Location = new System.Drawing.Point(101, 231);
            this.txt_tel.Name = "txt_tel";
            this.txt_tel.Size = new System.Drawing.Size(253, 25);
            this.txt_tel.TabIndex = 24;
            this.txt_tel.Click += new System.EventHandler(this.txt_cod_Click);
            // 
            // txtrazonsocial
            // 
            this.txtrazonsocial.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrazonsocial.Location = new System.Drawing.Point(101, 198);
            this.txtrazonsocial.Name = "txtrazonsocial";
            this.txtrazonsocial.ReadOnly = true;
            this.txtrazonsocial.Size = new System.Drawing.Size(492, 25);
            this.txtrazonsocial.TabIndex = 22;
            this.txtrazonsocial.Click += new System.EventHandler(this.txt_cod_Click);
            // 
            // txt_cod
            // 
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cod.Location = new System.Drawing.Point(101, 166);
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(253, 25);
            this.txt_cod.TabIndex = 21;
            this.txt_cod.Click += new System.EventHandler(this.txt_cod_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Dirección:";
            // 
            // txtruc
            // 
            this.txtruc.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtruc.Location = new System.Drawing.Point(101, 137);
            this.txtruc.Name = "txtruc";
            this.txtruc.Size = new System.Drawing.Size(253, 25);
            this.txtruc.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 19;
            this.label3.Text = "Telefono:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Razón Social:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Codigo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "RUC:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Brown;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(10, 386);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(188, 67);
            this.btnSalir.TabIndex = 27;
            this.btnSalir.Text = ".:: &Salir ::.";
            this.btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = global::SwJugueriaAgustin.Properties.Resources.check_128;
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(360, 136);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(69, 60);
            this.btnConsultar.TabIndex = 28;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // pictureCapcha
            // 
            this.pictureCapcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureCapcha.Location = new System.Drawing.Point(441, 137);
            this.pictureCapcha.Name = "pictureCapcha";
            this.pictureCapcha.Size = new System.Drawing.Size(152, 60);
            this.pictureCapcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCapcha.TabIndex = 26;
            this.pictureCapcha.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SwJugueriaAgustin.Properties.Resources.Sunat_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(101, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(454, 126);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Image = global::SwJugueriaAgustin.Properties.Resources.actualizar;
            this.pictureBox3.Location = new System.Drawing.Point(599, 138);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(74, 59);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // chHabilitar
            // 
            this.chHabilitar.AutoSize = true;
            this.chHabilitar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chHabilitar.ForeColor = System.Drawing.Color.Blue;
            this.chHabilitar.Location = new System.Drawing.Point(599, 199);
            this.chHabilitar.Name = "chHabilitar";
            this.chHabilitar.Size = new System.Drawing.Size(87, 24);
            this.chHabilitar.TabIndex = 30;
            this.chHabilitar.Text = "Habilitar";
            this.chHabilitar.UseVisualStyleBackColor = true;
            this.chHabilitar.CheckedChanged += new System.EventHandler(this.chHabilitar_CheckedChanged);
            // 
            // txtReferecia
            // 
            this.txtReferecia.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferecia.Location = new System.Drawing.Point(101, 321);
            this.txtReferecia.Multiline = true;
            this.txtReferecia.Name = "txtReferecia";
            this.txtReferecia.Size = new System.Drawing.Size(572, 59);
            this.txtReferecia.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "Referencia:";
            // 
            // frmBuscarRuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(683, 464);
            this.Controls.Add(this.txtReferecia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chHabilitar);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.pictureCapcha);
            this.Controls.Add(this.bto_agregar);
            this.Controls.Add(this.txt_direccion);
            this.Controls.Add(this.txt_tel);
            this.Controls.Add(this.txtrazonsocial);
            this.Controls.Add(this.txt_cod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtruc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmBuscarRuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: BUSCAR RUC";
            this.Load += new System.EventHandler(this.frmBuscarRuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCapcha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureCapcha;
        private System.Windows.Forms.Button bto_agregar;
        private System.Windows.Forms.TextBox txt_direccion;
        private System.Windows.Forms.TextBox txt_tel;
        private System.Windows.Forms.TextBox txt_cod;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtruc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.CheckBox chHabilitar;
        public System.Windows.Forms.TextBox txtrazonsocial;
        private System.Windows.Forms.TextBox txtReferecia;
        private System.Windows.Forms.Label label6;
    }
}