namespace SwJugueriaAgustin.Formularios.Almacen
{
    partial class FrmAtenderPedido
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
            this.dgvAtendiendoInsumo = new System.Windows.Forms.DataGridView();
            this.cnCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvListaInsumo = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAlmacenReceptor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAlmacenEmisor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxDatosTienda = new System.Windows.Forms.GroupBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFechaApertura = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtendiendoInsumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaInsumo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbxDatosTienda.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAtendiendoInsumo
            // 
            this.dgvAtendiendoInsumo.AllowUserToAddRows = false;
            this.dgvAtendiendoInsumo.AllowUserToDeleteRows = false;
            this.dgvAtendiendoInsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAtendiendoInsumo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvAtendiendoInsumo.BackgroundColor = System.Drawing.Color.White;
            this.dgvAtendiendoInsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAtendiendoInsumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnCodigo,
            this.cnInsumo,
            this.cnCantidad});
            this.dgvAtendiendoInsumo.Location = new System.Drawing.Point(525, 77);
            this.dgvAtendiendoInsumo.MultiSelect = false;
            this.dgvAtendiendoInsumo.Name = "dgvAtendiendoInsumo";
            this.dgvAtendiendoInsumo.Size = new System.Drawing.Size(449, 353);
            this.dgvAtendiendoInsumo.TabIndex = 39;
            this.dgvAtendiendoInsumo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAtendiendoInsumo_CellClick);
            // 
            // cnCodigo
            // 
            this.cnCodigo.HeaderText = "Codigo";
            this.cnCodigo.Name = "cnCodigo";
            this.cnCodigo.Visible = false;
            this.cnCodigo.Width = 65;
            // 
            // cnInsumo
            // 
            this.cnInsumo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnInsumo.HeaderText = "Insumo";
            this.cnInsumo.Name = "cnInsumo";
            this.cnInsumo.Width = 200;
            // 
            // cnCantidad
            // 
            this.cnCantidad.HeaderText = "Cantidad";
            this.cnCantidad.Name = "cnCantidad";
            this.cnCantidad.Width = 74;
            // 
            // dgvListaInsumo
            // 
            this.dgvListaInsumo.AllowUserToAddRows = false;
            this.dgvListaInsumo.AllowUserToDeleteRows = false;
            this.dgvListaInsumo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvListaInsumo.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaInsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaInsumo.Location = new System.Drawing.Point(12, 77);
            this.dgvListaInsumo.MultiSelect = false;
            this.dgvListaInsumo.Name = "dgvListaInsumo";
            this.dgvListaInsumo.ReadOnly = true;
            this.dgvListaInsumo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaInsumo.Size = new System.Drawing.Size(507, 353);
            this.dgvListaInsumo.TabIndex = 40;
            this.dgvListaInsumo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListaInsumo_KeyDown);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Ivory;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::SwJugueriaAgustin.Properties.Resources.SAVE_FOR;
            this.button1.Location = new System.Drawing.Point(245, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(729, 59);
            this.button1.TabIndex = 44;
            this.button1.Text = "Registrar Atención";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAlmacenReceptor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblAlmacenEmisor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(961, 58);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos:";
            // 
            // lblAlmacenReceptor
            // 
            this.lblAlmacenReceptor.AutoSize = true;
            this.lblAlmacenReceptor.Location = new System.Drawing.Point(622, 27);
            this.lblAlmacenReceptor.Name = "lblAlmacenReceptor";
            this.lblAlmacenReceptor.Size = new System.Drawing.Size(52, 15);
            this.lblAlmacenReceptor.TabIndex = 0;
            this.lblAlmacenReceptor.Text = "---------";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Almacen Receptor:";
            // 
            // lblAlmacenEmisor
            // 
            this.lblAlmacenEmisor.AutoSize = true;
            this.lblAlmacenEmisor.Location = new System.Drawing.Point(125, 27);
            this.lblAlmacenEmisor.Name = "lblAlmacenEmisor";
            this.lblAlmacenEmisor.Size = new System.Drawing.Size(52, 15);
            this.lblAlmacenEmisor.TabIndex = 0;
            this.lblAlmacenEmisor.Text = "---------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Almacen Emisor:";
            // 
            // gbxDatosTienda
            // 
            this.gbxDatosTienda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxDatosTienda.Controls.Add(this.lblAlmacen);
            this.gbxDatosTienda.Controls.Add(this.label11);
            this.gbxDatosTienda.Controls.Add(this.label8);
            this.gbxDatosTienda.Controls.Add(this.lblFechaApertura);
            this.gbxDatosTienda.Controls.Add(this.lblTurno);
            this.gbxDatosTienda.Controls.Add(this.label9);
            this.gbxDatosTienda.ForeColor = System.Drawing.Color.Black;
            this.gbxDatosTienda.Location = new System.Drawing.Point(13, 434);
            this.gbxDatosTienda.Name = "gbxDatosTienda";
            this.gbxDatosTienda.Size = new System.Drawing.Size(226, 82);
            this.gbxDatosTienda.TabIndex = 63;
            this.gbxDatosTienda.TabStop = false;
            this.gbxDatosTienda.Text = "Apertura Almacen:";
            this.gbxDatosTienda.Visible = false;
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlmacen.ForeColor = System.Drawing.Color.Black;
            this.lblAlmacen.Location = new System.Drawing.Point(114, 58);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(60, 17);
            this.lblAlmacen.TabIndex = 68;
            this.lblAlmacen.Text = "Almacen";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(6, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 17);
            this.label11.TabIndex = 67;
            this.label11.Text = "Almacen:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(6, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 17);
            this.label8.TabIndex = 64;
            this.label8.Text = "Turno:";
            // 
            // lblFechaApertura
            // 
            this.lblFechaApertura.AutoSize = true;
            this.lblFechaApertura.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaApertura.ForeColor = System.Drawing.Color.Black;
            this.lblFechaApertura.Location = new System.Drawing.Point(114, 38);
            this.lblFechaApertura.Name = "lblFechaApertura";
            this.lblFechaApertura.Size = new System.Drawing.Size(68, 17);
            this.lblFechaApertura.TabIndex = 66;
            this.lblFechaApertura.Text = "01-01-2001";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurno.ForeColor = System.Drawing.Color.Black;
            this.lblTurno.Location = new System.Drawing.Point(114, 16);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(67, 17);
            this.lblTurno.TabIndex = 65;
            this.lblTurno.Text = "MAÑANA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 17);
            this.label9.TabIndex = 63;
            this.label9.Text = "Fecha Almacen:";
            // 
            // FrmAtenderPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(986, 521);
            this.Controls.Add(this.gbxDatosTienda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvListaInsumo);
            this.Controls.Add(this.dgvAtendiendoInsumo);
            this.Name = "FrmAtenderPedido";
            this.Text = "Atender Pedido";
            this.Load += new System.EventHandler(this.FrmAtenderPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtendiendoInsumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaInsumo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxDatosTienda.ResumeLayout(false);
            this.gbxDatosTienda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvAtendiendoInsumo;
        private System.Windows.Forms.DataGridView dgvListaInsumo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblAlmacenReceptor;
        public System.Windows.Forms.Label lblAlmacenEmisor;
        private System.Windows.Forms.GroupBox gbxDatosTienda;
        public System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblFechaApertura;
        public System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCantidad;
    }
}