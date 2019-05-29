namespace SwJugueriaAgustin.Formularios.Reportes
{
    partial class FrmCuadreAlmacen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.dgvMañana = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cnCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSaldoInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDescarte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSalidaVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCantidadCerrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSobrante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMañana)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMostrar
            // 
            this.btnMostrar.BackColor = System.Drawing.Color.White;
            this.btnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMostrar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrar.ForeColor = System.Drawing.Color.Black;
            this.btnMostrar.Image = global::SwJugueriaAgustin.Properties.Resources.buscar;
            this.btnMostrar.Location = new System.Drawing.Point(302, 22);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(172, 73);
            this.btnMostrar.TabIndex = 23;
            this.btnMostrar.Text = "&Buscar";
            this.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMostrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMostrar.UseVisualStyleBackColor = false;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // dgvMañana
            // 
            this.dgvMañana.AllowUserToAddRows = false;
            this.dgvMañana.AllowUserToDeleteRows = false;
            this.dgvMañana.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMañana.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMañana.BackgroundColor = System.Drawing.Color.White;
            this.dgvMañana.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMañana.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMañana.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMañana.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnCodigo,
            this.cnInsumo,
            this.cnSaldoInicial,
            this.cnEntrada,
            this.cnDescarte,
            this.cnSalidaVenta,
            this.cnSaldo,
            this.cnCantidadCerrada,
            this.cnSobrante});
            this.dgvMañana.EnableHeadersVisualStyles = false;
            this.dgvMañana.Location = new System.Drawing.Point(16, 145);
            this.dgvMañana.Name = "dgvMañana";
            this.dgvMañana.ReadOnly = true;
            this.dgvMañana.RowHeadersVisible = false;
            this.dgvMañana.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMañana.Size = new System.Drawing.Size(905, 243);
            this.dgvMañana.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(74, 50);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(187, 23);
            this.dtpFecha.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "Mañana:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSucursal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 84);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscador:";
            // 
            // cboSucursal
            // 
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(74, 20);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(187, 23);
            this.cboSucursal.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Sucursal:";
            // 
            // cnCodigo
            // 
            this.cnCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnCodigo.HeaderText = "Codigo";
            this.cnCodigo.Name = "cnCodigo";
            this.cnCodigo.ReadOnly = true;
            this.cnCodigo.Visible = false;
            this.cnCodigo.Width = 65;
            // 
            // cnInsumo
            // 
            this.cnInsumo.HeaderText = "Insumo";
            this.cnInsumo.Name = "cnInsumo";
            this.cnInsumo.ReadOnly = true;
            // 
            // cnSaldoInicial
            // 
            this.cnSaldoInicial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnSaldoInicial.HeaderText = "SaldoInicial";
            this.cnSaldoInicial.Name = "cnSaldoInicial";
            this.cnSaldoInicial.ReadOnly = true;
            // 
            // cnEntrada
            // 
            this.cnEntrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnEntrada.HeaderText = "Entrada";
            this.cnEntrada.Name = "cnEntrada";
            this.cnEntrada.ReadOnly = true;
            // 
            // cnDescarte
            // 
            this.cnDescarte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnDescarte.HeaderText = "Salida";
            this.cnDescarte.Name = "cnDescarte";
            this.cnDescarte.ReadOnly = true;
            // 
            // cnSalidaVenta
            // 
            this.cnSalidaVenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnSalidaVenta.HeaderText = "SalidaVenta";
            this.cnSalidaVenta.Name = "cnSalidaVenta";
            this.cnSalidaVenta.ReadOnly = true;
            // 
            // cnSaldo
            // 
            this.cnSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnSaldo.HeaderText = "Saldo Sistema";
            this.cnSaldo.Name = "cnSaldo";
            this.cnSaldo.ReadOnly = true;
            // 
            // cnCantidadCerrada
            // 
            this.cnCantidadCerrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnCantidadCerrada.HeaderText = "Saldo Real";
            this.cnCantidadCerrada.Name = "cnCantidadCerrada";
            this.cnCantidadCerrada.ReadOnly = true;
            // 
            // cnSobrante
            // 
            this.cnSobrante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnSobrante.HeaderText = "Faltante";
            this.cnSobrante.Name = "cnSobrante";
            this.cnSobrante.ReadOnly = true;
            // 
            // FrmCuadreAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(929, 400);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.dgvMañana);
            this.Name = "FrmCuadreAlmacen";
            this.Text = "Cuadre Almacen";
            this.Load += new System.EventHandler(this.FrmCuadreAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMañana)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.DataGridView dgvMañana;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSaldoInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDescarte;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSalidaVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCantidadCerrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSobrante;
    }
}