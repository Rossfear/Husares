namespace SwJugueriaAgustin.Formularios
{
    partial class frmBuscarDni
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_dni = new System.Windows.Forms.TextBox();
            this.txt_cod = new System.Windows.Forms.TextBox();
            this.txt_tel = new System.Windows.Forms.TextBox();
            this.txt_cliente = new System.Windows.Forms.TextBox();
            this.bto_agregar = new System.Windows.Forms.Button();
            this.pictureCapcha = new System.Windows.Forms.PictureBox();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txt_direccion = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.chbManual = new System.Windows.Forms.CheckBox();
            this.chHabilitar = new System.Windows.Forms.CheckBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.chProveedor = new System.Windows.Forms.CheckBox();
            this.btnCapcher = new System.Windows.Forms.Button();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTeclado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCapcha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::SwJugueriaAgustin.Properties.Resources.logo_reniec;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1011, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(22, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "D.N.I:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(22, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Codigo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.Location = new System.Drawing.Point(22, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Telefono:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.Location = new System.Drawing.Point(22, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nombre:";
            // 
            // txt_dni
            // 
            this.txt_dni.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txt_dni.Location = new System.Drawing.Point(237, 174);
            this.txt_dni.Name = "txt_dni";
            this.txt_dni.Size = new System.Drawing.Size(211, 36);
            this.txt_dni.TabIndex = 5;
            // 
            // txt_cod
            // 
            this.txt_cod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_cod.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txt_cod.Location = new System.Drawing.Point(237, 222);
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.Size = new System.Drawing.Size(211, 36);
            this.txt_cod.TabIndex = 6;
            this.txt_cod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cod_KeyDown);
            // 
            // txt_tel
            // 
            this.txt_tel.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txt_tel.Location = new System.Drawing.Point(237, 316);
            this.txt_tel.Name = "txt_tel";
            this.txt_tel.Size = new System.Drawing.Size(766, 36);
            this.txt_tel.TabIndex = 8;
            // 
            // txt_cliente
            // 
            this.txt_cliente.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txt_cliente.Location = new System.Drawing.Point(237, 269);
            this.txt_cliente.Name = "txt_cliente";
            this.txt_cliente.ReadOnly = true;
            this.txt_cliente.Size = new System.Drawing.Size(491, 36);
            this.txt_cliente.TabIndex = 7;
            // 
            // bto_agregar
            // 
            this.bto_agregar.BackColor = System.Drawing.Color.Blue;
            this.bto_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bto_agregar.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bto_agregar.ForeColor = System.Drawing.Color.White;
            this.bto_agregar.Location = new System.Drawing.Point(278, 472);
            this.bto_agregar.Name = "bto_agregar";
            this.bto_agregar.Size = new System.Drawing.Size(725, 74);
            this.bto_agregar.TabIndex = 9;
            this.bto_agregar.Text = ".:: &Agregar ::.";
            this.bto_agregar.UseVisualStyleBackColor = false;
            this.bto_agregar.Click += new System.EventHandler(this.bto_guardar_Click);
            // 
            // pictureCapcha
            // 
            this.pictureCapcha.Location = new System.Drawing.Point(566, 177);
            this.pictureCapcha.Name = "pictureCapcha";
            this.pictureCapcha.Size = new System.Drawing.Size(209, 84);
            this.pictureCapcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCapcha.TabIndex = 10;
            this.pictureCapcha.TabStop = false;
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label5.Location = new System.Drawing.Point(22, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "Dirección:";
            // 
            // txt_direccion
            // 
            this.txt_direccion.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txt_direccion.Location = new System.Drawing.Point(237, 363);
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(766, 36);
            this.txt_direccion.TabIndex = 8;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(12, 472);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(260, 74);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = ".:: &Salir ::.";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // chbManual
            // 
            this.chbManual.AutoSize = true;
            this.chbManual.Font = new System.Drawing.Font("Cambria", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.chbManual.ForeColor = System.Drawing.Color.Blue;
            this.chbManual.Location = new System.Drawing.Point(14, 6);
            this.chbManual.Name = "chbManual";
            this.chbManual.Size = new System.Drawing.Size(200, 30);
            this.chbManual.TabIndex = 12;
            this.chbManual.Text = "Ingresar Manual";
            this.chbManual.UseVisualStyleBackColor = true;
            this.chbManual.CheckedChanged += new System.EventHandler(this.chbManual_CheckedChanged);
            // 
            // chHabilitar
            // 
            this.chHabilitar.AutoSize = true;
            this.chHabilitar.Font = new System.Drawing.Font("Cambria", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.chHabilitar.ForeColor = System.Drawing.Color.Blue;
            this.chHabilitar.Location = new System.Drawing.Point(747, 275);
            this.chHabilitar.Name = "chHabilitar";
            this.chHabilitar.Size = new System.Drawing.Size(123, 30);
            this.chHabilitar.TabIndex = 13;
            this.chHabilitar.Text = "Habilitar";
            this.chHabilitar.UseVisualStyleBackColor = true;
            this.chHabilitar.CheckedChanged += new System.EventHandler(this.chHabilitar_CheckedChanged);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = global::SwJugueriaAgustin.Properties.Resources.check_128;
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultar.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Location = new System.Drawing.Point(454, 172);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(89, 86);
            this.btnConsultar.TabIndex = 29;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // chProveedor
            // 
            this.chProveedor.AutoSize = true;
            this.chProveedor.Font = new System.Drawing.Font("Cambria", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.chProveedor.ForeColor = System.Drawing.Color.Blue;
            this.chProveedor.Location = new System.Drawing.Point(14, 42);
            this.chProveedor.Name = "chProveedor";
            this.chProveedor.Size = new System.Drawing.Size(134, 30);
            this.chProveedor.TabIndex = 32;
            this.chProveedor.Text = "Proveedor";
            this.chProveedor.UseVisualStyleBackColor = true;
            // 
            // btnCapcher
            // 
            this.btnCapcher.BackgroundImage = global::SwJugueriaAgustin.Properties.Resources.actualizar;
            this.btnCapcher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCapcher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapcher.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapcher.Location = new System.Drawing.Point(781, 175);
            this.btnCapcher.Name = "btnCapcher";
            this.btnCapcher.Size = new System.Drawing.Size(89, 86);
            this.btnCapcher.TabIndex = 33;
            this.btnCapcher.UseVisualStyleBackColor = true;
            this.btnCapcher.Click += new System.EventHandler(this.btnCapcher_Click);
            // 
            // txtReferencia
            // 
            this.txtReferencia.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txtReferencia.Location = new System.Drawing.Point(237, 416);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(766, 36);
            this.txtReferencia.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label6.Location = new System.Drawing.Point(22, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 28);
            this.label6.TabIndex = 34;
            this.label6.Text = "Referencia:";
            // 
            // btnTeclado
            // 
            this.btnTeclado.BackColor = System.Drawing.Color.Silver;
            this.btnTeclado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTeclado.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeclado.ForeColor = System.Drawing.Color.Black;
            this.btnTeclado.Image = global::SwJugueriaAgustin.Properties.Resources.teclado2;
            this.btnTeclado.Location = new System.Drawing.Point(882, 175);
            this.btnTeclado.Name = "btnTeclado";
            this.btnTeclado.Size = new System.Drawing.Size(121, 85);
            this.btnTeclado.TabIndex = 36;
            this.btnTeclado.Text = "Teclado";
            this.btnTeclado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTeclado.UseVisualStyleBackColor = false;
            this.btnTeclado.Click += new System.EventHandler(this.btnTeclado_Click);
            // 
            // frmBuscarDni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(1011, 558);
            this.Controls.Add(this.btnTeclado);
            this.Controls.Add(this.txtReferencia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCapcher);
            this.Controls.Add(this.chProveedor);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.chHabilitar);
            this.Controls.Add(this.chbManual);
            this.Controls.Add(this.pictureCapcha);
            this.Controls.Add(this.bto_agregar);
            this.Controls.Add(this.txt_direccion);
            this.Controls.Add(this.txt_tel);
            this.Controls.Add(this.txt_cliente);
            this.Controls.Add(this.txt_cod);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_dni);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSalir);
            this.Name = "frmBuscarDni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: BUSCAR DNI";
            this.Load += new System.EventHandler(this.frmBuscarDni_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCapcha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_cod;
        private System.Windows.Forms.TextBox txt_tel;
        private System.Windows.Forms.Button bto_agregar;
        private System.Windows.Forms.PictureBox pictureCapcha;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.TextBox txt_direccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox chbManual;
        public System.Windows.Forms.TextBox txt_dni;
        private System.Windows.Forms.CheckBox chHabilitar;
        private System.Windows.Forms.Button btnConsultar;
        public System.Windows.Forms.TextBox txt_cliente;
        public System.Windows.Forms.CheckBox chProveedor;
        private System.Windows.Forms.Button btnCapcher;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTeclado;
    }
}