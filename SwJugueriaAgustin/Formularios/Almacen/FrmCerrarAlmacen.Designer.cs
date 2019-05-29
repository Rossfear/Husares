namespace SwJugueriaAgustin.Formularios.Operaciones
{
    partial class FrmCerrarAlmacen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCerrarAlmacen));
            this.btnCerrarAlmacen = new System.Windows.Forms.Button();
            this.btnCancela = new System.Windows.Forms.Button();
            this.dgvInsumo = new System.Windows.Forms.DataGridView();
            this.cnCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnIDInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnInsumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSaldoInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDescarte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSalidaVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSaldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCantidadCerrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnSobrante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnEspecificar = new System.Windows.Forms.DataGridViewImageColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.actualizarCantidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFechaApertura = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pdCerrarAlmacen = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.txtCajero = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrarAlmacen
            // 
            this.btnCerrarAlmacen.BackColor = System.Drawing.Color.White;
            this.btnCerrarAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrarAlmacen.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.btnCerrarAlmacen.ForeColor = System.Drawing.Color.Black;
            this.btnCerrarAlmacen.Image = global::SwJugueriaAgustin.Properties.Resources.close;
            this.btnCerrarAlmacen.Location = new System.Drawing.Point(20, 199);
            this.btnCerrarAlmacen.Name = "btnCerrarAlmacen";
            this.btnCerrarAlmacen.Size = new System.Drawing.Size(292, 76);
            this.btnCerrarAlmacen.TabIndex = 6;
            this.btnCerrarAlmacen.Text = "4. Cerrar Almacen";
            this.btnCerrarAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarAlmacen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarAlmacen.UseVisualStyleBackColor = false;
            this.btnCerrarAlmacen.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnCancela
            // 
            this.btnCancela.BackColor = System.Drawing.Color.White;
            this.btnCancela.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancela.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.btnCancela.ForeColor = System.Drawing.Color.Black;
            this.btnCancela.Image = global::SwJugueriaAgustin.Properties.Resources.CANCEL_FORMULARIO;
            this.btnCancela.Location = new System.Drawing.Point(20, 444);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(292, 76);
            this.btnCancela.TabIndex = 9;
            this.btnCancela.Text = "&Cancelar";
            this.btnCancela.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancela.UseVisualStyleBackColor = false;
            this.btnCancela.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvInsumo
            // 
            this.dgvInsumo.AllowUserToAddRows = false;
            this.dgvInsumo.AllowUserToDeleteRows = false;
            this.dgvInsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInsumo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInsumo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvInsumo.BackgroundColor = System.Drawing.Color.White;
            this.dgvInsumo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInsumo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnCodigo,
            this.cnIDInsumo,
            this.cnInsumo,
            this.cnSaldoInicial,
            this.cnEntrada,
            this.cnDescarte,
            this.cnSalidaVenta,
            this.cnSaldo,
            this.cnCantidadCerrada,
            this.cnSobrante,
            this.cnEspecificar});
            this.dgvInsumo.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvInsumo.EnableHeadersVisualStyles = false;
            this.dgvInsumo.Location = new System.Drawing.Point(331, 78);
            this.dgvInsumo.Name = "dgvInsumo";
            this.dgvInsumo.RowHeadersVisible = false;
            this.dgvInsumo.Size = new System.Drawing.Size(924, 555);
            this.dgvInsumo.TabIndex = 14;
            this.dgvInsumo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInsumo_CellClick);
            this.dgvInsumo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInsumo_CellEndEdit);
            // 
            // cnCodigo
            // 
            this.cnCodigo.DataPropertyName = "IDStockAlmacen";
            this.cnCodigo.HeaderText = "IDStockAlmacen";
            this.cnCodigo.Name = "cnCodigo";
            this.cnCodigo.Visible = false;
            // 
            // cnIDInsumo
            // 
            this.cnIDInsumo.DataPropertyName = "IDInsumo";
            this.cnIDInsumo.HeaderText = "IDInsumo";
            this.cnIDInsumo.Name = "cnIDInsumo";
            this.cnIDInsumo.Visible = false;
            // 
            // cnInsumo
            // 
            this.cnInsumo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnInsumo.DataPropertyName = "Insumo";
            this.cnInsumo.HeaderText = "Insumo";
            this.cnInsumo.Name = "cnInsumo";
            this.cnInsumo.ReadOnly = true;
            this.cnInsumo.Width = 350;
            // 
            // cnSaldoInicial
            // 
            this.cnSaldoInicial.DataPropertyName = "SaldoInicial";
            this.cnSaldoInicial.HeaderText = "SaldoInicial";
            this.cnSaldoInicial.Name = "cnSaldoInicial";
            this.cnSaldoInicial.ReadOnly = true;
            // 
            // cnEntrada
            // 
            this.cnEntrada.DataPropertyName = "CantidadEntrada";
            this.cnEntrada.HeaderText = "Entrada";
            this.cnEntrada.Name = "cnEntrada";
            this.cnEntrada.ReadOnly = true;
            // 
            // cnDescarte
            // 
            this.cnDescarte.DataPropertyName = "CantidadSalida";
            this.cnDescarte.HeaderText = "Salida";
            this.cnDescarte.Name = "cnDescarte";
            this.cnDescarte.ReadOnly = true;
            // 
            // cnSalidaVenta
            // 
            this.cnSalidaVenta.DataPropertyName = "CantidadVenta";
            this.cnSalidaVenta.HeaderText = "SalidaVenta";
            this.cnSalidaVenta.Name = "cnSalidaVenta";
            this.cnSalidaVenta.ReadOnly = true;
            // 
            // cnSaldo
            // 
            this.cnSaldo.DataPropertyName = "SaldoSistema";
            this.cnSaldo.HeaderText = "Saldo Sistema";
            this.cnSaldo.Name = "cnSaldo";
            this.cnSaldo.ReadOnly = true;
            // 
            // cnCantidadCerrada
            // 
            this.cnCantidadCerrada.HeaderText = "Saldo Real";
            this.cnCantidadCerrada.Name = "cnCantidadCerrada";
            // 
            // cnSobrante
            // 
            this.cnSobrante.HeaderText = "Faltante";
            this.cnSobrante.Name = "cnSobrante";
            this.cnSobrante.ReadOnly = true;
            // 
            // cnEspecificar
            // 
            this.cnEspecificar.HeaderText = "Especificar";
            this.cnEspecificar.Image = global::SwJugueriaAgustin.Properties.Resources.check;
            this.cnEspecificar.Name = "cnEspecificar";
            this.cnEspecificar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cnEspecificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizarCantidadesToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 26);
            // 
            // actualizarCantidadesToolStripMenuItem
            // 
            this.actualizarCantidadesToolStripMenuItem.Name = "actualizarCantidadesToolStripMenuItem";
            this.actualizarCantidadesToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.actualizarCantidadesToolStripMenuItem.Text = "Actualizar Cantidades";
            this.actualizarCantidadesToolStripMenuItem.Click += new System.EventHandler(this.actualizarCantidadesToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Fecha Apertura:";
            // 
            // lblFechaApertura
            // 
            this.lblFechaApertura.AutoSize = true;
            this.lblFechaApertura.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.lblFechaApertura.Location = new System.Drawing.Point(110, 45);
            this.lblFechaApertura.Name = "lblFechaApertura";
            this.lblFechaApertura.Size = new System.Drawing.Size(64, 16);
            this.lblFechaApertura.TabIndex = 18;
            this.lblFechaApertura.Text = "01-01-2001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Almacen:";
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.lblAlmacen.Location = new System.Drawing.Point(76, 23);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(24, 16);
            this.lblAlmacen.TabIndex = 20;
            this.lblAlmacen.Text = "----";
            // 
            // btnMostrar
            // 
            this.btnMostrar.BackColor = System.Drawing.Color.White;
            this.btnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMostrar.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.btnMostrar.ForeColor = System.Drawing.Color.Black;
            this.btnMostrar.Image = global::SwJugueriaAgustin.Properties.Resources.buscar;
            this.btnMostrar.Location = new System.Drawing.Point(20, 118);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(292, 75);
            this.btnMostrar.TabIndex = 21;
            this.btnMostrar.Text = "1. Mostrar Insumos";
            this.btnMostrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMostrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMostrar.UseVisualStyleBackColor = false;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImprimir.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Image = global::SwJugueriaAgustin.Properties.Resources.if_emblem_print_24705;
            this.btnImprimir.Location = new System.Drawing.Point(20, 281);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(292, 76);
            this.btnImprimir.TabIndex = 22;
            this.btnImprimir.Text = "3. Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // pdCerrarAlmacen
            // 
            this.pdCerrarAlmacen.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdCerrarAlmacen_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // txtCajero
            // 
            this.txtCajero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCajero.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.txtCajero.Location = new System.Drawing.Point(11, 23);
            this.txtCajero.Name = "txtCajero";
            this.txtCajero.Size = new System.Drawing.Size(895, 21);
            this.txtCajero.TabIndex = 25;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblAlmacen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblFechaApertura);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(20, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 91);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.label3.Location = new System.Drawing.Point(10, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "Estado:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.lblEstado.Location = new System.Drawing.Point(110, 65);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(28, 16);
            this.lblEstado.TabIndex = 22;
            this.lblEstado.Text = "-----";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.label5.Location = new System.Drawing.Point(1130, 638);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 16);
            this.label5.TabIndex = 23;
            this.label5.Text = "2. Especificar Productos";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtCajero);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(331, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(921, 60);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Responsable:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.White;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnActualizar.Font = new System.Drawing.Font("Century Gothic", 8.25F);
            this.btnActualizar.ForeColor = System.Drawing.Color.Black;
            this.btnActualizar.Location = new System.Drawing.Point(20, 363);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(292, 75);
            this.btnActualizar.TabIndex = 29;
            this.btnActualizar.Text = "4.Actualizar a Todos";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // FrmCerrarAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 665);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.dgvInsumo);
            this.Controls.Add(this.btnCancela);
            this.Controls.Add(this.btnCerrarAlmacen);
            this.Name = "FrmCerrarAlmacen";
            this.Text = ".::Cerrar Almacen::.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAbrirAlmacen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsumo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCerrarAlmacen;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.DataGridView dgvInsumo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFechaApertura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Drawing.Printing.PrintDocument pdCerrarAlmacen;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.TextBox txtCajero;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actualizarCantidadesToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnIDInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnInsumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSaldoInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDescarte;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSalidaVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCantidadCerrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnSobrante;
        private System.Windows.Forms.DataGridViewImageColumn cnEspecificar;
        private System.Windows.Forms.Button btnActualizar;
    }
}