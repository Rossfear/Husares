namespace SwJugueriaAgustin.Formularios
{
    partial class frmReimprimir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReimprimir));
            this.dgvPedido = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblguion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pdComprobante = new System.Drawing.Printing.PrintDocument();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTipoPago = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNroCliente = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTipoVenta = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblMozo = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblZona = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblComanda = new System.Windows.Forms.Label();
            this.lblMesa = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cboTipoImpresion = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblTipoComprobante = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ppDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.chbxPrintBar_Cocina = new System.Windows.Forms.CheckBox();
            this.pdBar = new System.Drawing.Printing.PrintDocument();
            this.pdCocina = new System.Drawing.Printing.PrintDocument();
            this.btnView = new System.Windows.Forms.Button();
            this.chbxComandaDelivery = new System.Windows.Forms.CheckBox();
            this.pdComandaDelivery = new System.Drawing.Printing.PrintDocument();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDescuentoSoles = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblIgv = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblPagoCon = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.chbxComprobante = new System.Windows.Forms.CheckBox();
            this.pdHorno = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPedido
            // 
            this.dgvPedido.AllowUserToAddRows = false;
            this.dgvPedido.AllowUserToDeleteRows = false;
            this.dgvPedido.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedido.Location = new System.Drawing.Point(278, 259);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.ReadOnly = true;
            this.dgvPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedido.Size = new System.Drawing.Size(730, 114);
            this.dgvPedido.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Cambria", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(26, 89);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(232, 65);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(98, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Numero";
            // 
            // txtNumero
            // 
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtNumero.Location = new System.Drawing.Point(101, 41);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(152, 22);
            this.txtNumero.TabIndex = 9;
            // 
            // lblguion
            // 
            this.lblguion.AutoSize = true;
            this.lblguion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblguion.Location = new System.Drawing.Point(83, 44);
            this.lblguion.Name = "lblguion";
            this.lblguion.Size = new System.Drawing.Size(12, 16);
            this.lblguion.TabIndex = 8;
            this.lblguion.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Serie";
            // 
            // txtSerie
            // 
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtSerie.Location = new System.Drawing.Point(21, 41);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(56, 22);
            this.txtSerie.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(14, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tipo Comprob:";
            // 
            // pdComprobante
            // 
            this.pdComprobante.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdBoletaT_PrintPage);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(20, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 14;
            this.label4.Text = "Cliente:";
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblTotal.Location = new System.Drawing.Point(110, 104);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(128, 25);
            this.lblTotal.TabIndex = 17;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.Location = new System.Drawing.Point(10, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Total:";
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboTipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboTipoPago.ForeColor = System.Drawing.Color.Blue;
            this.cboTipoPago.Location = new System.Drawing.Point(116, 77);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(220, 25);
            this.cboTipoPago.TabIndex = 19;
            this.cboTipoPago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label7.Location = new System.Drawing.Point(14, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Tipo Pago:";
            // 
            // txtNroCliente
            // 
            this.txtNroCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNroCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtNroCliente.ForeColor = System.Drawing.Color.Blue;
            this.txtNroCliente.Location = new System.Drawing.Point(123, 21);
            this.txtNroCliente.Name = "txtNroCliente";
            this.txtNroCliente.Size = new System.Drawing.Size(248, 25);
            this.txtNroCliente.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label8.Location = new System.Drawing.Point(20, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "N° Documento:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Teal;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Location = new System.Drawing.Point(484, 379);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(524, 57);
            this.btnImprimir.TabIndex = 22;
            this.btnImprimir.Text = "Reimprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTipoVenta);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblMozo);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblZona);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblComanda);
            this.groupBox1.Controls.Add(this.lblMesa);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.cboTipoImpresion);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblFecha);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblHora);
            this.groupBox1.Controls.Add(this.lblTipoComprobante);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboTipoPago);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(278, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(353, 202);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Comprobante";
            // 
            // lblTipoVenta
            // 
            this.lblTipoVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTipoVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTipoVenta.ForeColor = System.Drawing.Color.Blue;
            this.lblTipoVenta.Location = new System.Drawing.Point(262, 167);
            this.lblTipoVenta.Name = "lblTipoVenta";
            this.lblTipoVenta.Size = new System.Drawing.Size(74, 25);
            this.lblTipoVenta.TabIndex = 43;
            this.lblTipoVenta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label12.Location = new System.Drawing.Point(195, 171);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 16);
            this.label12.TabIndex = 42;
            this.label12.Text = "T. Venta:";
            // 
            // lblMozo
            // 
            this.lblMozo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMozo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblMozo.ForeColor = System.Drawing.Color.Blue;
            this.lblMozo.Location = new System.Drawing.Point(116, 165);
            this.lblMozo.Name = "lblMozo";
            this.lblMozo.Size = new System.Drawing.Size(79, 25);
            this.lblMozo.TabIndex = 41;
            this.lblMozo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label16.Location = new System.Drawing.Point(20, 170);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 16);
            this.label16.TabIndex = 40;
            this.label16.Text = "Mozo:";
            // 
            // lblZona
            // 
            this.lblZona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblZona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblZona.ForeColor = System.Drawing.Color.Blue;
            this.lblZona.Location = new System.Drawing.Point(116, 135);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(79, 25);
            this.lblZona.TabIndex = 39;
            this.lblZona.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label11.Location = new System.Drawing.Point(20, 140);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 16);
            this.label11.TabIndex = 38;
            this.label11.Text = "Zona:";
            // 
            // lblComanda
            // 
            this.lblComanda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblComanda.ForeColor = System.Drawing.Color.Blue;
            this.lblComanda.Location = new System.Drawing.Point(262, 106);
            this.lblComanda.Name = "lblComanda";
            this.lblComanda.Size = new System.Drawing.Size(74, 25);
            this.lblComanda.TabIndex = 37;
            this.lblComanda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMesa
            // 
            this.lblMesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblMesa.ForeColor = System.Drawing.Color.Blue;
            this.lblMesa.Location = new System.Drawing.Point(262, 136);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(74, 25);
            this.lblMesa.TabIndex = 37;
            this.lblMesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label18.Location = new System.Drawing.Point(197, 111);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 16);
            this.label18.TabIndex = 34;
            this.label18.Text = "Comanda:";
            // 
            // cboTipoImpresion
            // 
            this.cboTipoImpresion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cboTipoImpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cboTipoImpresion.ForeColor = System.Drawing.Color.Blue;
            this.cboTipoImpresion.Location = new System.Drawing.Point(116, 106);
            this.cboTipoImpresion.Name = "cboTipoImpresion";
            this.cboTipoImpresion.Size = new System.Drawing.Size(79, 25);
            this.cboTipoImpresion.TabIndex = 36;
            this.cboTipoImpresion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label10.Location = new System.Drawing.Point(197, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 16);
            this.label10.TabIndex = 34;
            this.label10.Text = "Mesa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.Location = new System.Drawing.Point(16, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Tipo Impresion:";
            // 
            // lblFecha
            // 
            this.lblFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblFecha.ForeColor = System.Drawing.Color.Blue;
            this.lblFecha.Location = new System.Drawing.Point(116, 18);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(100, 25);
            this.lblFecha.TabIndex = 33;
            this.lblFecha.Text = "00/00/0000";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label14.Location = new System.Drawing.Point(14, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 16);
            this.label14.TabIndex = 32;
            this.label14.Text = "Fecha - Hora:";
            // 
            // lblHora
            // 
            this.lblHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblHora.ForeColor = System.Drawing.Color.Blue;
            this.lblHora.Location = new System.Drawing.Point(237, 18);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(97, 25);
            this.lblHora.TabIndex = 31;
            this.lblHora.Text = "00:00:00";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTipoComprobante
            // 
            this.lblTipoComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTipoComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTipoComprobante.ForeColor = System.Drawing.Color.Blue;
            this.lblTipoComprobante.Location = new System.Drawing.Point(116, 48);
            this.lblTipoComprobante.Name = "lblTipoComprobante";
            this.lblTipoComprobante.Size = new System.Drawing.Size(220, 25);
            this.lblTipoComprobante.TabIndex = 27;
            this.lblTipoComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReferencia);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtCliente);
            this.groupBox2.Controls.Add(this.lblTelefono);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtDireccion);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtNroCliente);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(637, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 199);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Cliente";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferencia.Location = new System.Drawing.Point(123, 148);
            this.txtReferencia.Multiline = true;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.ReadOnly = true;
            this.txtReferencia.Size = new System.Drawing.Size(248, 36);
            this.txtReferencia.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label15.Location = new System.Drawing.Point(20, 151);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 16);
            this.label15.TabIndex = 30;
            this.label15.Text = "Referencia:";
            // 
            // txtCliente
            // 
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCliente.ForeColor = System.Drawing.Color.Blue;
            this.txtCliente.Location = new System.Drawing.Point(123, 77);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(248, 25);
            this.txtCliente.TabIndex = 29;
            // 
            // lblTelefono
            // 
            this.lblTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTelefono.ForeColor = System.Drawing.Color.Blue;
            this.lblTelefono.Location = new System.Drawing.Point(123, 48);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(248, 25);
            this.lblTelefono.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label13.Location = new System.Drawing.Point(20, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 16);
            this.label13.TabIndex = 26;
            this.label13.Text = "Telefono:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(123, 106);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(248, 36);
            this.txtDireccion.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label9.Location = new System.Drawing.Point(20, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "Direccion:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(278, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 57);
            this.button1.TabIndex = 27;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ppDialog
            // 
            this.ppDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.ppDialog.Enabled = true;
            this.ppDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("ppDialog.Icon")));
            this.ppDialog.Name = "ppDialog";
            this.ppDialog.Visible = false;
            // 
            // chbxPrintBar_Cocina
            // 
            this.chbxPrintBar_Cocina.AutoSize = true;
            this.chbxPrintBar_Cocina.BackColor = System.Drawing.Color.White;
            this.chbxPrintBar_Cocina.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxPrintBar_Cocina.ForeColor = System.Drawing.Color.DarkRed;
            this.chbxPrintBar_Cocina.Location = new System.Drawing.Point(479, 217);
            this.chbxPrintBar_Cocina.Name = "chbxPrintBar_Cocina";
            this.chbxPrintBar_Cocina.Size = new System.Drawing.Size(260, 34);
            this.chbxPrintBar_Cocina.TabIndex = 28;
            this.chbxPrintBar_Cocina.Text = "Reimprimir Bar / Cocina";
            this.chbxPrintBar_Cocina.UseVisualStyleBackColor = false;
            // 
            // pdBar
            // 
            this.pdBar.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdBar_PrintPage);
            // 
            // pdCocina
            // 
            this.pdCocina.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdCocina_PrintPage);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.Teal;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Font = new System.Drawing.Font("Cambria", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(11, 374);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(247, 56);
            this.btnView.TabIndex = 29;
            this.btnView.Text = "Vista Previa";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // chbxComandaDelivery
            // 
            this.chbxComandaDelivery.AutoSize = true;
            this.chbxComandaDelivery.BackColor = System.Drawing.Color.White;
            this.chbxComandaDelivery.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxComandaDelivery.ForeColor = System.Drawing.Color.DarkRed;
            this.chbxComandaDelivery.Location = new System.Drawing.Point(780, 217);
            this.chbxComandaDelivery.Name = "chbxComandaDelivery";
            this.chbxComandaDelivery.Size = new System.Drawing.Size(208, 34);
            this.chbxComandaDelivery.TabIndex = 30;
            this.chbxComandaDelivery.Text = "Comanda Delivery";
            this.chbxComandaDelivery.UseVisualStyleBackColor = false;
            this.chbxComandaDelivery.Visible = false;
            // 
            // pdComandaDelivery
            // 
            this.pdComandaDelivery.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdPreCuenta_PrintPage);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblVuelto);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtDescuentoSoles);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.lblSubTotal);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.lblIgv);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.lblPagoCon);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.lblTotal);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(11, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(247, 194);
            this.groupBox3.TabIndex = 32;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Facturación:";
            // 
            // lblVuelto
            // 
            this.lblVuelto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblVuelto.ForeColor = System.Drawing.Color.Blue;
            this.lblVuelto.Location = new System.Drawing.Point(110, 163);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(128, 25);
            this.lblVuelto.TabIndex = 19;
            this.lblVuelto.Text = "0.00";
            this.lblVuelto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label23.Location = new System.Drawing.Point(10, 167);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(49, 16);
            this.label23.TabIndex = 18;
            this.label23.Text = "Vuelto:";
            // 
            // txtDescuentoSoles
            // 
            this.txtDescuentoSoles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescuentoSoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtDescuentoSoles.ForeColor = System.Drawing.Color.Blue;
            this.txtDescuentoSoles.Location = new System.Drawing.Point(110, 19);
            this.txtDescuentoSoles.Name = "txtDescuentoSoles";
            this.txtDescuentoSoles.Size = new System.Drawing.Size(128, 25);
            this.txtDescuentoSoles.TabIndex = 17;
            this.txtDescuentoSoles.Text = "0.00";
            this.txtDescuentoSoles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label21.Location = new System.Drawing.Point(10, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 16);
            this.label21.TabIndex = 16;
            this.label21.Text = "Descuento:";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblSubTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblSubTotal.Location = new System.Drawing.Point(110, 47);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(128, 25);
            this.lblSubTotal.TabIndex = 17;
            this.lblSubTotal.Text = "0.00";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label19.Location = new System.Drawing.Point(10, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 16);
            this.label19.TabIndex = 16;
            this.label19.Text = "SubTotal:";
            // 
            // lblIgv
            // 
            this.lblIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblIgv.ForeColor = System.Drawing.Color.Blue;
            this.lblIgv.Location = new System.Drawing.Point(110, 76);
            this.lblIgv.Name = "lblIgv";
            this.lblIgv.Size = new System.Drawing.Size(128, 25);
            this.lblIgv.TabIndex = 17;
            this.lblIgv.Text = "0.00";
            this.lblIgv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label17.Location = new System.Drawing.Point(13, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 16);
            this.label17.TabIndex = 16;
            this.label17.Text = "Igv:";
            // 
            // lblPagoCon
            // 
            this.lblPagoCon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPagoCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPagoCon.ForeColor = System.Drawing.Color.Blue;
            this.lblPagoCon.Location = new System.Drawing.Point(110, 133);
            this.lblPagoCon.Name = "lblPagoCon";
            this.lblPagoCon.Size = new System.Drawing.Size(128, 25);
            this.lblPagoCon.TabIndex = 17;
            this.lblPagoCon.Text = "0.00";
            this.lblPagoCon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label22.Location = new System.Drawing.Point(10, 137);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 16);
            this.label22.TabIndex = 16;
            this.label22.Text = "Pago Con:";
            // 
            // chbxComprobante
            // 
            this.chbxComprobante.AutoSize = true;
            this.chbxComprobante.BackColor = System.Drawing.Color.White;
            this.chbxComprobante.Checked = true;
            this.chbxComprobante.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxComprobante.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxComprobante.ForeColor = System.Drawing.Color.DarkRed;
            this.chbxComprobante.Location = new System.Drawing.Point(278, 217);
            this.chbxComprobante.Name = "chbxComprobante";
            this.chbxComprobante.Size = new System.Drawing.Size(166, 34);
            this.chbxComprobante.TabIndex = 33;
            this.chbxComprobante.Text = "Comprobante";
            this.chbxComprobante.UseVisualStyleBackColor = false;
            // 
            // pdHorno
            // 
            this.pdHorno.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdHorno_PrintPage);
            // 
            // frmReimprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1028, 446);
            this.Controls.Add(this.chbxComprobante);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.chbxComandaDelivery);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.chbxPrintBar_Cocina);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblguion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.dgvPedido);
            this.Name = "frmReimprimir";
            this.Text = ".::Reimprimir";
            this.Load += new System.EventHandler(this.frmReimprimir_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblguion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label2;
        private System.Drawing.Printing.PrintDocument pdComprobante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label cboTipoPago;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtNroCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTipoComprobante;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label txtCliente;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PrintPreviewDialog ppDialog;
        private System.Windows.Forms.CheckBox chbxPrintBar_Cocina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Drawing.Printing.PrintDocument pdBar;
        private System.Drawing.Printing.PrintDocument pdCocina;
        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.Label cboTipoImpresion;
        private System.Windows.Forms.Label lblZona;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.CheckBox chbxComandaDelivery;
        private System.Drawing.Printing.PrintDocument pdComandaDelivery;
        private System.Windows.Forms.Label lblMozo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblTipoVenta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label txtDescuentoSoles;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblIgv;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chbxComprobante;
        private System.Windows.Forms.Label lblComanda;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblPagoCon;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblVuelto;
        private System.Windows.Forms.Label label23;
        private System.Drawing.Printing.PrintDocument pdHorno;
    }
}