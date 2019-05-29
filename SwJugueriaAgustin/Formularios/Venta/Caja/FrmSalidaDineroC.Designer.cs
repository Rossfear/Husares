namespace SwJugueriaAgustin.Formularios.Operaciones
{
    partial class FrmSalidaDinero
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
            this.dgvSalidaDinero = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblFechaCaja = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxData = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnEgreso = new System.Windows.Forms.RadioButton();
            this.rbtnIngreso = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnVentaDelivery = new System.Windows.Forms.RadioButton();
            this.rbtnVentaSalon = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblIngreso = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblEgreso = new System.Windows.Forms.Label();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidaDinero)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.gbxData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSalidaDinero
            // 
            this.dgvSalidaDinero.AllowUserToAddRows = false;
            this.dgvSalidaDinero.AllowUserToDeleteRows = false;
            this.dgvSalidaDinero.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSalidaDinero.BackgroundColor = System.Drawing.Color.White;
            this.dgvSalidaDinero.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalidaDinero.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvSalidaDinero.Location = new System.Drawing.Point(380, 12);
            this.dgvSalidaDinero.Name = "dgvSalidaDinero";
            this.dgvSalidaDinero.ReadOnly = true;
            this.dgvSalidaDinero.Size = new System.Drawing.Size(562, 417);
            this.dgvSalidaDinero.TabIndex = 15;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            this.editarToolStripMenuItem.Click += new System.EventHandler(this.editarToolStripMenuItem_Click);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtMotivo.Location = new System.Drawing.Point(121, 94);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(223, 83);
            this.txtMotivo.TabIndex = 13;
            // 
            // lblFechaCaja
            // 
            this.lblFechaCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFechaCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblFechaCaja.Location = new System.Drawing.Point(121, 29);
            this.lblFechaCaja.Name = "lblFechaCaja";
            this.lblFechaCaja.Size = new System.Drawing.Size(223, 20);
            this.lblFechaCaja.TabIndex = 12;
            this.lblFechaCaja.Text = "00-00-0000";
            this.lblFechaCaja.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMonto
            // 
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtMonto.Location = new System.Drawing.Point(121, 187);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(223, 22);
            this.txtMonto.TabIndex = 11;
            this.txtMonto.Text = "0";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(16, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fecha de Caja:";
            // 
            // gbxData
            // 
            this.gbxData.Controls.Add(this.label1);
            this.gbxData.Controls.Add(this.rbtnEgreso);
            this.gbxData.Controls.Add(this.rbtnIngreso);
            this.gbxData.Controls.Add(this.label4);
            this.gbxData.Controls.Add(this.label3);
            this.gbxData.Controls.Add(this.lblFechaCaja);
            this.gbxData.Controls.Add(this.label2);
            this.gbxData.Controls.Add(this.txtMotivo);
            this.gbxData.Controls.Add(this.txtMonto);
            this.gbxData.Location = new System.Drawing.Point(12, 74);
            this.gbxData.Name = "gbxData";
            this.gbxData.Size = new System.Drawing.Size(350, 224);
            this.gbxData.TabIndex = 18;
            this.gbxData.TabStop = false;
            this.gbxData.Text = "Datos Salida:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(16, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Movimiento:";
            // 
            // rbtnEgreso
            // 
            this.rbtnEgreso.AutoSize = true;
            this.rbtnEgreso.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnEgreso.ForeColor = System.Drawing.Color.Black;
            this.rbtnEgreso.Location = new System.Drawing.Point(218, 61);
            this.rbtnEgreso.Name = "rbtnEgreso";
            this.rbtnEgreso.Size = new System.Drawing.Size(65, 21);
            this.rbtnEgreso.TabIndex = 15;
            this.rbtnEgreso.TabStop = true;
            this.rbtnEgreso.Text = "Egreso";
            this.rbtnEgreso.UseVisualStyleBackColor = true;
            // 
            // rbtnIngreso
            // 
            this.rbtnIngreso.AutoSize = true;
            this.rbtnIngreso.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnIngreso.ForeColor = System.Drawing.Color.Black;
            this.rbtnIngreso.Location = new System.Drawing.Point(121, 61);
            this.rbtnIngreso.Name = "rbtnIngreso";
            this.rbtnIngreso.Size = new System.Drawing.Size(69, 21);
            this.rbtnIngreso.TabIndex = 12;
            this.rbtnIngreso.TabStop = true;
            this.rbtnIngreso.Text = "Ingreso";
            this.rbtnIngreso.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(16, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Monto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(16, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Motivo:";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.Color.White;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnGuardar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.Black;
            this.BtnGuardar.Image = global::SwJugueriaAgustin.Properties.Resources.SAVE_FOR;
            this.BtnGuardar.Location = new System.Drawing.Point(133, 317);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(116, 44);
            this.BtnGuardar.TabIndex = 80;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.BackColor = System.Drawing.Color.White;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCancelar.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.Black;
            this.BtnCancelar.Image = global::SwJugueriaAgustin.Properties.Resources.CANCEL_FORMULARIO;
            this.BtnCancelar.Location = new System.Drawing.Point(255, 317);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(107, 44);
            this.BtnCancelar.TabIndex = 81;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCancelar.UseVisualStyleBackColor = false;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.BackColor = System.Drawing.Color.White;
            this.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnNuevo.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevo.ForeColor = System.Drawing.Color.Black;
            this.BtnNuevo.Image = global::SwJugueriaAgustin.Properties.Resources.NUEVO_FORMULARIO;
            this.BtnNuevo.Location = new System.Drawing.Point(12, 317);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(115, 44);
            this.BtnNuevo.TabIndex = 83;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNuevo.UseVisualStyleBackColor = false;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnVentaDelivery);
            this.groupBox1.Controls.Add(this.rbtnVentaSalon);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 58);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Caja:";
            // 
            // rbtnVentaDelivery
            // 
            this.rbtnVentaDelivery.AutoSize = true;
            this.rbtnVentaDelivery.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.rbtnVentaDelivery.ForeColor = System.Drawing.Color.Black;
            this.rbtnVentaDelivery.Location = new System.Drawing.Point(195, 24);
            this.rbtnVentaDelivery.Name = "rbtnVentaDelivery";
            this.rbtnVentaDelivery.Size = new System.Drawing.Size(75, 21);
            this.rbtnVentaDelivery.TabIndex = 11;
            this.rbtnVentaDelivery.TabStop = true;
            this.rbtnVentaDelivery.Text = "Delivery";
            this.rbtnVentaDelivery.UseVisualStyleBackColor = true;
            this.rbtnVentaDelivery.CheckedChanged += new System.EventHandler(this.rbtnVentaSalon_CheckedChanged);
            // 
            // rbtnVentaSalon
            // 
            this.rbtnVentaSalon.AutoSize = true;
            this.rbtnVentaSalon.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnVentaSalon.ForeColor = System.Drawing.Color.Black;
            this.rbtnVentaSalon.Location = new System.Drawing.Point(63, 23);
            this.rbtnVentaSalon.Name = "rbtnVentaSalon";
            this.rbtnVentaSalon.Size = new System.Drawing.Size(99, 21);
            this.rbtnVentaSalon.TabIndex = 10;
            this.rbtnVentaSalon.TabStop = true;
            this.rbtnVentaSalon.Text = "Venta Salon";
            this.rbtnVentaSalon.UseVisualStyleBackColor = true;
            this.rbtnVentaSalon.CheckedChanged += new System.EventHandler(this.rbtnVentaSalon_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblIngreso);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(712, 432);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(112, 57);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ingreso:";
            // 
            // lblIngreso
            // 
            this.lblIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblIngreso.Location = new System.Drawing.Point(9, 22);
            this.lblIngreso.Name = "lblIngreso";
            this.lblIngreso.Size = new System.Drawing.Size(98, 20);
            this.lblIngreso.TabIndex = 17;
            this.lblIngreso.Text = "0.00";
            this.lblIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblEgreso);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(830, 432);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(112, 57);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Egreso:";
            // 
            // lblEgreso
            // 
            this.lblEgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEgreso.Location = new System.Drawing.Point(9, 22);
            this.lblEgreso.Name = "lblEgreso";
            this.lblEgreso.Size = new System.Drawing.Size(98, 20);
            this.lblEgreso.TabIndex = 17;
            this.lblEgreso.Text = "0.00";
            this.lblEgreso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // FrmSalidaDinero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(954, 492);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.gbxData);
            this.Controls.Add(this.dgvSalidaDinero);
            this.Name = "FrmSalidaDinero";
            this.Text = ".::Salida Dinero::.";
            this.Load += new System.EventHandler(this.FrmSalidaDinero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidaDinero)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.gbxData.ResumeLayout(false);
            this.gbxData.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvSalidaDinero;
        private System.Windows.Forms.TextBox txtMotivo;
        public System.Windows.Forms.Label lblFechaCaja;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbxData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnVentaDelivery;
        private System.Windows.Forms.RadioButton rbtnVentaSalon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnEgreso;
        private System.Windows.Forms.RadioButton rbtnIngreso;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Label lblIngreso;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.Label lblEgreso;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
    }
}