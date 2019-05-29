namespace SwJugueriaAgustin.Formularios
{
    partial class FrmAddCompra
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCorrelativo = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.cnCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPreCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnAfecto = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aFECTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iNAFECTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qUITARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBaseGravada = new System.Windows.Forms.TextBox();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtpFechaComprobante = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cbxTipoComprobante = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblIGV = new System.Windows.Forms.TextBox();
            this.chbxAumentarStock = new System.Windows.Forms.CheckBox();
            this.cbxAlmacen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTipoCambio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBaseNoGravada = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chbxConIGV = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.cbxMoneda = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOtrosTributos = new System.Windows.Forms.TextBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtISC = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIDComproEditada = new System.Windows.Forms.Label();
            this.labelComproEditada = new System.Windows.Forms.Label();
            this.lblAño = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCorrelativo
            // 
            this.txtCorrelativo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorrelativo.ForeColor = System.Drawing.Color.Blue;
            this.txtCorrelativo.Location = new System.Drawing.Point(234, 132);
            this.txtCorrelativo.Name = "txtCorrelativo";
            this.txtCorrelativo.Size = new System.Drawing.Size(153, 25);
            this.txtCorrelativo.TabIndex = 11;
            this.txtCorrelativo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCorrelativo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnum_KeyDown);
            // 
            // txtSerie
            // 
            this.txtSerie.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.ForeColor = System.Drawing.Color.Blue;
            this.txtSerie.Location = new System.Drawing.Point(149, 132);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(79, 25);
            this.txtSerie.TabIndex = 9;
            this.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSerie.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerie_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 15);
            this.label14.TabIndex = 8;
            this.label14.Text = "Serie - Numero:";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnCodigo,
            this.cnProducto,
            this.cnCantidad,
            this.cPreCompra,
            this.cnImporte,
            this.cnAfecto});
            this.dgvDetalle.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(12, 367);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(662, 233);
            this.dgvDetalle.TabIndex = 8;
            this.dgvDetalle.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeatalle_CellClick);
            this.dgvDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellEndEdit);
            // 
            // cnCodigo
            // 
            this.cnCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnCodigo.HeaderText = "Cod. Insumo.";
            this.cnCodigo.Name = "cnCodigo";
            this.cnCodigo.ReadOnly = true;
            this.cnCodigo.Visible = false;
            this.cnCodigo.Width = 120;
            // 
            // cnProducto
            // 
            this.cnProducto.HeaderText = "Insumo";
            this.cnProducto.Name = "cnProducto";
            this.cnProducto.ReadOnly = true;
            // 
            // cnCantidad
            // 
            this.cnCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnCantidad.HeaderText = "Cantidad";
            this.cnCantidad.Name = "cnCantidad";
            this.cnCantidad.ReadOnly = true;
            this.cnCantidad.Width = 80;
            // 
            // cPreCompra
            // 
            this.cPreCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cPreCompra.HeaderText = "Precio Compra";
            this.cPreCompra.MinimumWidth = 50;
            this.cPreCompra.Name = "cPreCompra";
            this.cPreCompra.ReadOnly = true;
            this.cPreCompra.Width = 80;
            // 
            // cnImporte
            // 
            this.cnImporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnImporte.HeaderText = "Importe";
            this.cnImporte.Name = "cnImporte";
            this.cnImporte.ReadOnly = true;
            this.cnImporte.Width = 80;
            // 
            // cnAfecto
            // 
            this.cnAfecto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnAfecto.HeaderText = "Afecto";
            this.cnAfecto.Name = "cnAfecto";
            this.cnAfecto.ReadOnly = true;
            this.cnAfecto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cnAfecto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cnAfecto.Width = 65;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aFECTOToolStripMenuItem,
            this.iNAFECTOToolStripMenuItem,
            this.qUITARToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 70);
            // 
            // aFECTOToolStripMenuItem
            // 
            this.aFECTOToolStripMenuItem.Name = "aFECTOToolStripMenuItem";
            this.aFECTOToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.aFECTOToolStripMenuItem.Text = "AFECTO";
            this.aFECTOToolStripMenuItem.Click += new System.EventHandler(this.aFECTOToolStripMenuItem_Click);
            // 
            // iNAFECTOToolStripMenuItem
            // 
            this.iNAFECTOToolStripMenuItem.Name = "iNAFECTOToolStripMenuItem";
            this.iNAFECTOToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.iNAFECTOToolStripMenuItem.Text = "INAFECTO";
            this.iNAFECTOToolStripMenuItem.Click += new System.EventHandler(this.iNAFECTOToolStripMenuItem_Click);
            // 
            // qUITARToolStripMenuItem
            // 
            this.qUITARToolStripMenuItem.Name = "qUITARToolStripMenuItem";
            this.qUITARToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.qUITARToolStripMenuItem.Text = "QUITAR";
            this.qUITARToolStripMenuItem.Click += new System.EventHandler(this.qUITARToolStripMenuItem_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.Location = new System.Drawing.Point(12, 131);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(662, 206);
            this.dgvProductos.TabIndex = 1;
            this.dgvProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProductos_KeyDown);
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtNombre.Location = new System.Drawing.Point(149, 192);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(238, 25);
            this.txtNombre.TabIndex = 15;
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nombre(s):";
            // 
            // txtNumero
            // 
            this.txtNumero.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtNumero.Location = new System.Drawing.Point(149, 161);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(238, 25);
            this.txtNumero.TabIndex = 13;
            this.txtNumero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "RUC/DNI + Enter";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 348);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(123, 17);
            this.label16.TabIndex = 7;
            this.label16.Text = "Detalle de Compra";
            // 
            // txtBaseGravada
            // 
            this.txtBaseGravada.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBaseGravada.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtBaseGravada.ForeColor = System.Drawing.Color.Black;
            this.txtBaseGravada.Location = new System.Drawing.Point(152, 69);
            this.txtBaseGravada.Name = "txtBaseGravada";
            this.txtBaseGravada.Size = new System.Drawing.Size(165, 25);
            this.txtBaseGravada.TabIndex = 19;
            this.txtBaseGravada.Text = "0.00";
            this.txtBaseGravada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // dtpFechaComprobante
            // 
            this.dtpFechaComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpFechaComprobante.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaComprobante.Location = new System.Drawing.Point(149, 20);
            this.dtpFechaComprobante.Name = "dtpFechaComprobante";
            this.dtpFechaComprobante.Size = new System.Drawing.Size(238, 23);
            this.dtpFechaComprobante.TabIndex = 3;
            this.dtpFechaComprobante.ValueChanged += new System.EventHandler(this.dtpFechaComprobante_ValueChanged);
            this.dtpFechaComprobante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFechaComprobante_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Fecha Comprobante:";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(149, 46);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(238, 23);
            this.dtpFechaVencimiento.TabIndex = 5;
            this.dtpFechaVencimiento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpFechaVencimiento_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(13, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(115, 15);
            this.label18.TabIndex = 4;
            this.label18.Text = "Fecha Vencimeinto:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(13, 108);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 15);
            this.label19.TabIndex = 6;
            this.label19.Text = "Tipo de Comprobante:";
            // 
            // cbxTipoComprobante
            // 
            this.cbxTipoComprobante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxTipoComprobante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTipoComprobante.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cbxTipoComprobante.FormattingEnabled = true;
            this.cbxTipoComprobante.Location = new System.Drawing.Point(149, 103);
            this.cbxTipoComprobante.Name = "cbxTipoComprobante";
            this.cbxTipoComprobante.Size = new System.Drawing.Size(238, 25);
            this.cbxTipoComprobante.TabIndex = 7;
            this.cbxTipoComprobante.SelectedIndexChanged += new System.EventHandler(this.cbxTipoComprobante_SelectedIndexChanged);
            this.cbxTipoComprobante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxTipoComprobante_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(17, 107);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 15);
            this.label17.TabIndex = 16;
            this.label17.Text = "I.G.V:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(15, 73);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 15);
            this.label20.TabIndex = 18;
            this.label20.Text = "Base Gravada:";
            // 
            // lblIGV
            // 
            this.lblIGV.BackColor = System.Drawing.Color.Gainsboro;
            this.lblIGV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIGV.ForeColor = System.Drawing.Color.Black;
            this.lblIGV.Location = new System.Drawing.Point(152, 100);
            this.lblIGV.Name = "lblIGV";
            this.lblIGV.Size = new System.Drawing.Size(167, 25);
            this.lblIGV.TabIndex = 17;
            this.lblIGV.Text = "0.00";
            this.lblIGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chbxAumentarStock
            // 
            this.chbxAumentarStock.AutoSize = true;
            this.chbxAumentarStock.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxAumentarStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chbxAumentarStock.Location = new System.Drawing.Point(131, 222);
            this.chbxAumentarStock.Name = "chbxAumentarStock";
            this.chbxAumentarStock.Size = new System.Drawing.Size(256, 29);
            this.chbxAumentarStock.TabIndex = 22;
            this.chbxAumentarStock.Text = "Aumentar Stock Almacen";
            this.chbxAumentarStock.UseVisualStyleBackColor = true;
            // 
            // cbxAlmacen
            // 
            this.cbxAlmacen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxAlmacen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxAlmacen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cbxAlmacen.FormattingEnabled = true;
            this.cbxAlmacen.Location = new System.Drawing.Point(149, 74);
            this.cbxAlmacen.Name = "cbxAlmacen";
            this.cbxAlmacen.Size = new System.Drawing.Size(238, 25);
            this.cbxAlmacen.TabIndex = 21;
            this.cbxAlmacen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxTienda_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Almacen:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtProducto);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(662, 55);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscador de Insumo";
            // 
            // txtProducto
            // 
            this.txtProducto.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProducto.Location = new System.Drawing.Point(6, 20);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(646, 25);
            this.txtProducto.TabIndex = 0;
            this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
            this.txtProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProducto_KeyDown);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Teal;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(803, 538);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(282, 72);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "&Guardar Compra";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Brown;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(686, 538);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(111, 72);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(152, 236);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(167, 23);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "00.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Moneda:";
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTipoCambio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTipoCambio.ForeColor = System.Drawing.Color.Black;
            this.txtTipoCambio.Location = new System.Drawing.Point(224, 13);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Size = new System.Drawing.Size(94, 25);
            this.txtTipoCambio.TabIndex = 25;
            this.txtTipoCambio.Text = "1";
            this.txtTipoCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTipoCambio.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Base No Gravada:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "I.S.C:";
            // 
            // txtBaseNoGravada
            // 
            this.txtBaseNoGravada.BackColor = System.Drawing.Color.Gainsboro;
            this.txtBaseNoGravada.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtBaseNoGravada.ForeColor = System.Drawing.Color.Black;
            this.txtBaseNoGravada.Location = new System.Drawing.Point(151, 41);
            this.txtBaseNoGravada.Name = "txtBaseNoGravada";
            this.txtBaseNoGravada.Size = new System.Drawing.Size(166, 25);
            this.txtBaseNoGravada.TabIndex = 17;
            this.txtBaseNoGravada.Text = "0.00";
            this.txtBaseNoGravada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Otros Tributos:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chbxConIGV);
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Controls.Add(this.lblImpuesto);
            this.groupBox4.Controls.Add(this.cbxMoneda);
            this.groupBox4.Controls.Add(this.txtTipoCambio);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtOtrosTributos);
            this.groupBox4.Controls.Add(this.txtDescuento);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtISC);
            this.groupBox4.Controls.Add(this.lblTotal);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtBaseGravada);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.txtBaseNoGravada);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.lblIGV);
            this.groupBox4.Location = new System.Drawing.Point(686, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(396, 264);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Facturacion";
            // 
            // chbxConIGV
            // 
            this.chbxConIGV.AutoSize = true;
            this.chbxConIGV.Checked = true;
            this.chbxConIGV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxConIGV.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxConIGV.Location = new System.Drawing.Point(322, 16);
            this.chbxConIGV.Name = "chbxConIGV";
            this.chbxConIGV.Size = new System.Drawing.Size(76, 21);
            this.chbxConIGV.TabIndex = 48;
            this.chbxConIGV.Text = "Con IGV";
            this.chbxConIGV.UseVisualStyleBackColor = true;
            this.chbxConIGV.CheckedChanged += new System.EventHandler(this.chbxConIGV_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(59, 107);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(26, 13);
            this.linkLabel1.TabIndex = 47;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Act.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.AutoSize = true;
            this.lblImpuesto.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpuesto.Location = new System.Drawing.Point(85, 105);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new System.Drawing.Size(32, 17);
            this.lblImpuesto.TabIndex = 46;
            this.lblImpuesto.Text = "0.18";
            // 
            // cbxMoneda
            // 
            this.cbxMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMoneda.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMoneda.FormattingEnabled = true;
            this.cbxMoneda.Items.AddRange(new object[] {
            "S",
            "D"});
            this.cbxMoneda.Location = new System.Drawing.Point(149, 13);
            this.cbxMoneda.Name = "cbxMoneda";
            this.cbxMoneda.Size = new System.Drawing.Size(69, 25);
            this.cbxMoneda.TabIndex = 37;
            this.cbxMoneda.Text = "S";
            this.cbxMoneda.SelectedIndexChanged += new System.EventHandler(this.cbxMoneda_SelectedIndexChanged);
            this.cbxMoneda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxMoneda_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 239);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 15);
            this.label11.TabIndex = 29;
            this.label11.Text = "Total:";
            // 
            // txtOtrosTributos
            // 
            this.txtOtrosTributos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtrosTributos.ForeColor = System.Drawing.Color.Black;
            this.txtOtrosTributos.Location = new System.Drawing.Point(154, 166);
            this.txtOtrosTributos.Name = "txtOtrosTributos";
            this.txtOtrosTributos.Size = new System.Drawing.Size(165, 25);
            this.txtOtrosTributos.TabIndex = 28;
            this.txtOtrosTributos.Text = "0";
            this.txtOtrosTributos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOtrosTributos.TextChanged += new System.EventHandler(this.txtOtrosTributos_TextChanged);
            this.txtOtrosTributos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOtrosTributos_KeyDown);
            // 
            // txtDescuento
            // 
            this.txtDescuento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.ForeColor = System.Drawing.Color.Black;
            this.txtDescuento.Location = new System.Drawing.Point(153, 134);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(166, 25);
            this.txtDescuento.TabIndex = 27;
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            this.txtDescuento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescuento_KeyDown);
            // 
            // txtISC
            // 
            this.txtISC.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtISC.ForeColor = System.Drawing.Color.Black;
            this.txtISC.Location = new System.Drawing.Point(153, 201);
            this.txtISC.Name = "txtISC";
            this.txtISC.Size = new System.Drawing.Size(166, 25);
            this.txtISC.TabIndex = 26;
            this.txtISC.Text = "0";
            this.txtISC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtISC.TextChanged += new System.EventHandler(this.txtISC_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "Descuento";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtNombre);
            this.groupBox5.Controls.Add(this.dtpFechaComprobante);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.chbxAumentarStock);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.cbxAlmacen);
            this.groupBox5.Controls.Add(this.dtpFechaVencimiento);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtNumero);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.txtSerie);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.cbxTipoComprobante);
            this.groupBox5.Controls.Add(this.txtCorrelativo);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Location = new System.Drawing.Point(686, 5);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(394, 257);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Datos Generales:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblIDComproEditada);
            this.groupBox1.Controls.Add(this.labelComproEditada);
            this.groupBox1.Controls.Add(this.lblAño);
            this.groupBox1.Controls.Add(this.lblMes);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(18, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 59);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registro Compra:";
            // 
            // lblIDComproEditada
            // 
            this.lblIDComproEditada.AutoSize = true;
            this.lblIDComproEditada.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDComproEditada.Location = new System.Drawing.Point(572, 27);
            this.lblIDComproEditada.Name = "lblIDComproEditada";
            this.lblIDComproEditada.Size = new System.Drawing.Size(45, 20);
            this.lblIDComproEditada.TabIndex = 28;
            this.lblIDComproEditada.Text = "0000";
            this.lblIDComproEditada.Visible = false;
            // 
            // labelComproEditada
            // 
            this.labelComproEditada.AutoSize = true;
            this.labelComproEditada.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComproEditada.Location = new System.Drawing.Point(450, 29);
            this.labelComproEditada.Name = "labelComproEditada";
            this.labelComproEditada.Size = new System.Drawing.Size(94, 15);
            this.labelComproEditada.TabIndex = 27;
            this.labelComproEditada.Text = "Compra Editada:";
            this.labelComproEditada.Visible = false;
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAño.Location = new System.Drawing.Point(265, 27);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(45, 20);
            this.lblAño.TabIndex = 26;
            this.lblAño.Text = "0000";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.Location = new System.Drawing.Point(55, 27);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(58, 20);
            this.lblMes.TabIndex = 25;
            this.lblMes.Text = "ENERO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(227, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = "Año:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Mes:";
            // 
            // FrmAddCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1093, 624);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.dgvProductos);
            this.Name = "FrmAddCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".: Registro de Compra :.";
            this.Load += new System.EventHandler(this.frmCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ErrorProvider error;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.ComboBox cbxMoneda;
        public System.Windows.Forms.Label lblImpuesto;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aFECTOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iNAFECTOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qUITARToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPreCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnImporte;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cnAfecto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblAño;
        public System.Windows.Forms.Label lblMes;
        public System.Windows.Forms.Label lblIDComproEditada;
        public System.Windows.Forms.Label labelComproEditada;
        public System.Windows.Forms.TextBox txtNombre;
        public System.Windows.Forms.TextBox txtNumero;
        public System.Windows.Forms.TextBox txtCorrelativo;
        public System.Windows.Forms.TextBox txtSerie;
        public System.Windows.Forms.ComboBox cbxTipoComprobante;
        public System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        public System.Windows.Forms.DateTimePicker dtpFechaComprobante;
        public System.Windows.Forms.ComboBox cbxAlmacen;
        public System.Windows.Forms.CheckBox chbxAumentarStock;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.DataGridView dgvDetalle;
        public System.Windows.Forms.TextBox txtBaseGravada;
        public System.Windows.Forms.TextBox lblIGV;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.TextBox txtTipoCambio;
        public System.Windows.Forms.TextBox txtBaseNoGravada;
        public System.Windows.Forms.TextBox txtOtrosTributos;
        public System.Windows.Forms.TextBox txtDescuento;
        public System.Windows.Forms.TextBox txtISC;
        public System.Windows.Forms.CheckBox chbxConIGV;
    }
}