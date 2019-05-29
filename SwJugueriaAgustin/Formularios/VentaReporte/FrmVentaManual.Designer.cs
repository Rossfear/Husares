namespace SwJugueriaAgustin.Formularios.VentaReporte
{
    partial class FrmVentaManual
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
            this.dgvListas = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTipoVenta = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBusacar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIMonto = new System.Windows.Forms.TextBox();
            this.txtIAgua = new System.Windows.Forms.TextBox();
            this.txtIGaseosaMedioLitro = new System.Windows.Forms.TextBox();
            this.txtIGaseosaLitroMedio = new System.Windows.Forms.TextBox();
            this.txtICantidadPollo = new System.Windows.Forms.TextBox();
            this.cboSucursal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListas
            // 
            this.dgvListas.AllowUserToAddRows = false;
            this.dgvListas.AllowUserToDeleteRows = false;
            this.dgvListas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListas.Location = new System.Drawing.Point(12, 79);
            this.dgvListas.Name = "dgvListas";
            this.dgvListas.ReadOnly = true;
            this.dgvListas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListas.Size = new System.Drawing.Size(843, 279);
            this.dgvListas.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSucursal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboTipoVenta);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 61);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar:";
            // 
            // cboTipoVenta
            // 
            this.cboTipoVenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoVenta.FormattingEnabled = true;
            this.cboTipoVenta.Items.AddRange(new object[] {
            "VENTA SALON",
            "DELIVERY"});
            this.cboTipoVenta.Location = new System.Drawing.Point(483, 24);
            this.cboTipoVenta.Name = "cboTipoVenta";
            this.cboTipoVenta.Size = new System.Drawing.Size(144, 23);
            this.cboTipoVenta.TabIndex = 2;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(270, 21);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(132, 23);
            this.dtpFecha.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo Venta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha:";
            // 
            // btnBusacar
            // 
            this.btnBusacar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBusacar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBusacar.Image = global::SwJugueriaAgustin.Properties.Resources.buscar;
            this.btnBusacar.Location = new System.Drawing.Point(658, 20);
            this.btnBusacar.Name = "btnBusacar";
            this.btnBusacar.Size = new System.Drawing.Size(111, 53);
            this.btnBusacar.TabIndex = 3;
            this.btnBusacar.Text = "Buscar";
            this.btnBusacar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBusacar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBusacar.UseVisualStyleBackColor = true;
            this.btnBusacar.Click += new System.EventHandler(this.btnBusacar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtIMonto);
            this.groupBox2.Controls.Add(this.txtIAgua);
            this.groupBox2.Controls.Add(this.txtIGaseosaMedioLitro);
            this.groupBox2.Controls.Add(this.txtIGaseosaLitroMedio);
            this.groupBox2.Controls.Add(this.txtICantidadPollo);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(192, 372);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(663, 79);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Información:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(565, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 15);
            this.label13.TabIndex = 8;
            this.label13.Text = "Monto:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(450, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 15);
            this.label12.TabIndex = 8;
            this.label12.Text = "Agua:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(300, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 15);
            this.label11.TabIndex = 8;
            this.label11.Text = "Gaseosa 1/2:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(169, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Gaseosa 1.5:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Cantidad Pollo:";
            // 
            // txtIMonto
            // 
            this.txtIMonto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIMonto.Location = new System.Drawing.Point(532, 38);
            this.txtIMonto.Name = "txtIMonto";
            this.txtIMonto.ReadOnly = true;
            this.txtIMonto.Size = new System.Drawing.Size(109, 25);
            this.txtIMonto.TabIndex = 1;
            // 
            // txtIAgua
            // 
            this.txtIAgua.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIAgua.Location = new System.Drawing.Point(417, 38);
            this.txtIAgua.Name = "txtIAgua";
            this.txtIAgua.ReadOnly = true;
            this.txtIAgua.Size = new System.Drawing.Size(109, 25);
            this.txtIAgua.TabIndex = 1;
            // 
            // txtIGaseosaMedioLitro
            // 
            this.txtIGaseosaMedioLitro.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIGaseosaMedioLitro.Location = new System.Drawing.Point(287, 38);
            this.txtIGaseosaMedioLitro.Name = "txtIGaseosaMedioLitro";
            this.txtIGaseosaMedioLitro.ReadOnly = true;
            this.txtIGaseosaMedioLitro.Size = new System.Drawing.Size(125, 25);
            this.txtIGaseosaMedioLitro.TabIndex = 1;
            // 
            // txtIGaseosaLitroMedio
            // 
            this.txtIGaseosaLitroMedio.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIGaseosaLitroMedio.Location = new System.Drawing.Point(155, 38);
            this.txtIGaseosaLitroMedio.Name = "txtIGaseosaLitroMedio";
            this.txtIGaseosaLitroMedio.ReadOnly = true;
            this.txtIGaseosaLitroMedio.Size = new System.Drawing.Size(125, 25);
            this.txtIGaseosaLitroMedio.TabIndex = 1;
            // 
            // txtICantidadPollo
            // 
            this.txtICantidadPollo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtICantidadPollo.Location = new System.Drawing.Point(15, 38);
            this.txtICantidadPollo.Name = "txtICantidadPollo";
            this.txtICantidadPollo.ReadOnly = true;
            this.txtICantidadPollo.Size = new System.Drawing.Size(125, 25);
            this.txtICantidadPollo.TabIndex = 1;
            // 
            // cboSucursal
            // 
            this.cboSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSucursal.FormattingEnabled = true;
            this.cboSucursal.Location = new System.Drawing.Point(73, 24);
            this.cboSucursal.Name = "cboSucursal";
            this.cboSucursal.Size = new System.Drawing.Size(127, 23);
            this.cboSucursal.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Sucursal:";
            // 
            // FrmVentaManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(867, 463);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnBusacar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvListas);
            this.Name = "FrmVentaManual";
            this.Text = "Venta Manual";
            this.Load += new System.EventHandler(this.FrmVentaManual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipoVenta;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBusacar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIMonto;
        private System.Windows.Forms.TextBox txtIAgua;
        private System.Windows.Forms.TextBox txtIGaseosaMedioLitro;
        private System.Windows.Forms.TextBox txtIGaseosaLitroMedio;
        private System.Windows.Forms.TextBox txtICantidadPollo;
        private System.Windows.Forms.ComboBox cboSucursal;
        private System.Windows.Forms.Label label3;
    }
}