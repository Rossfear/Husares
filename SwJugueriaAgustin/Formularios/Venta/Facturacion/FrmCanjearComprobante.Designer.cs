namespace SwJugueriaAgustin.Formularios.Operaciones
{
    partial class FrmCanjearComprobante
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCanjearComprobante));
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.dgvDetalleVenta = new System.Windows.Forms.DataGridView();
            this.btnCancelarPedido = new System.Windows.Forms.Button();
            this.btnRegistrarVenta = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.labelDNIRUC = new System.Windows.Forms.Label();
            this.txtNroDocumento = new System.Windows.Forms.TextBox();
            this.btnIngresoManual = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblComprobante = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblSerie = new System.Windows.Forms.Label();
            this.btnTicket = new System.Windows.Forms.Button();
            this.btnBoleta = new System.Windows.Forms.Button();
            this.btnFactura = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNroComanda = new System.Windows.Forms.Label();
            this.btnTeclado = new System.Windows.Forms.Button();
            this.chbxPorConsumo = new System.Windows.Forms.CheckBox();
            this.lblTipoPago = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pdTicketVentaT = new System.Drawing.Printing.PrintDocument();
            this.pdFacturaT = new System.Drawing.Printing.PrintDocument();
            this.pdBoletaT = new System.Drawing.Printing.PrintDocument();
            this.btnFacturaB = new System.Windows.Forms.Button();
            this.btnBoletaB = new System.Windows.Forms.Button();
            this.btnTickeB = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSerieActual = new System.Windows.Forms.Label();
            this.lblNumeroActual = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ppdVer = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(337, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Numero";
            // 
            // txtNumero
            // 
            this.txtNumero.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(341, 36);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(173, 45);
            this.txtNumero.TabIndex = 9;
            this.txtNumero.Click += new System.EventHandler(this.txtNumero_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(227, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Serie";
            // 
            // txtSerie
            // 
            this.txtSerie.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(226, 36);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.ReadOnly = true;
            this.txtSerie.Size = new System.Drawing.Size(89, 45);
            this.txtSerie.TabIndex = 6;
            this.txtSerie.Click += new System.EventHandler(this.txtSerie_Click);
            // 
            // dgvDetalleVenta
            // 
            this.dgvDetalleVenta.AllowUserToAddRows = false;
            this.dgvDetalleVenta.AllowUserToDeleteRows = false;
            this.dgvDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleVenta.Location = new System.Drawing.Point(12, 149);
            this.dgvDetalleVenta.Name = "dgvDetalleVenta";
            this.dgvDetalleVenta.ReadOnly = true;
            this.dgvDetalleVenta.Size = new System.Drawing.Size(526, 241);
            this.dgvDetalleVenta.TabIndex = 12;
            // 
            // btnCancelarPedido
            // 
            this.btnCancelarPedido.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelarPedido.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarPedido.ForeColor = System.Drawing.Color.White;
            this.btnCancelarPedido.Location = new System.Drawing.Point(23, 354);
            this.btnCancelarPedido.Name = "btnCancelarPedido";
            this.btnCancelarPedido.Size = new System.Drawing.Size(161, 87);
            this.btnCancelarPedido.TabIndex = 37;
            this.btnCancelarPedido.Text = "CANCELAR";
            this.btnCancelarPedido.UseVisualStyleBackColor = false;
            this.btnCancelarPedido.Click += new System.EventHandler(this.btnCancelarPedido_Click);
            // 
            // btnRegistrarVenta
            // 
            this.btnRegistrarVenta.BackColor = System.Drawing.Color.Teal;
            this.btnRegistrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistrarVenta.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarVenta.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarVenta.Location = new System.Drawing.Point(190, 354);
            this.btnRegistrarVenta.Name = "btnRegistrarVenta";
            this.btnRegistrarVenta.Size = new System.Drawing.Size(440, 87);
            this.btnRegistrarVenta.TabIndex = 28;
            this.btnRegistrarVenta.Text = "CANJEAR COMPROBANTE";
            this.btnRegistrarVenta.UseVisualStyleBackColor = false;
            this.btnRegistrarVenta.Click += new System.EventHandler(this.btnRegistrarVenta_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtCliente);
            this.groupBox5.Controls.Add(this.labelDNIRUC);
            this.groupBox5.Controls.Add(this.txtNroDocumento);
            this.groupBox5.Location = new System.Drawing.Point(24, 217);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(518, 114);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Pago Con:";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(2, 71);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(512, 29);
            this.txtCliente.TabIndex = 27;
            this.txtCliente.Text = "CLIENTES VARIOS";
            this.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelDNIRUC
            // 
            this.labelDNIRUC.AutoSize = true;
            this.labelDNIRUC.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDNIRUC.Location = new System.Drawing.Point(11, 17);
            this.labelDNIRUC.Name = "labelDNIRUC";
            this.labelDNIRUC.Size = new System.Drawing.Size(78, 29);
            this.labelDNIRUC.TabIndex = 26;
            this.labelDNIRUC.Text = "D.N.I:";
            this.labelDNIRUC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNroDocumento
            // 
            this.txtNroDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroDocumento.Location = new System.Drawing.Point(156, 19);
            this.txtNroDocumento.Name = "txtNroDocumento";
            this.txtNroDocumento.Size = new System.Drawing.Size(316, 31);
            this.txtNroDocumento.TabIndex = 0;
            this.txtNroDocumento.Text = "0";
            this.txtNroDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNroDocumento.Click += new System.EventHandler(this.txtNroDocumento_Click);
            // 
            // btnIngresoManual
            // 
            this.btnIngresoManual.BackColor = System.Drawing.Color.Teal;
            this.btnIngresoManual.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIngresoManual.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresoManual.ForeColor = System.Drawing.Color.White;
            this.btnIngresoManual.Image = global::SwJugueriaAgustin.Properties.Resources.Proveedor;
            this.btnIngresoManual.Location = new System.Drawing.Point(12, 396);
            this.btnIngresoManual.Name = "btnIngresoManual";
            this.btnIngresoManual.Size = new System.Drawing.Size(526, 71);
            this.btnIngresoManual.TabIndex = 47;
            this.btnIngresoManual.Text = "Registrar Cliente - Manual";
            this.btnIngresoManual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngresoManual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIngresoManual.UseVisualStyleBackColor = false;
            this.btnIngresoManual.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblComprobante);
            this.groupBox4.Controls.Add(this.lblNumero);
            this.groupBox4.Controls.Add(this.lblSerie);
            this.groupBox4.Location = new System.Drawing.Point(318, 57);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(270, 74);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Serie - Número:";
            // 
            // lblComprobante
            // 
            this.lblComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComprobante.Location = new System.Drawing.Point(217, 18);
            this.lblComprobante.Name = "lblComprobante";
            this.lblComprobante.Size = new System.Drawing.Size(40, 42);
            this.lblComprobante.TabIndex = 19;
            this.lblComprobante.Text = "B";
            this.lblComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumero
            // 
            this.lblNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.Location = new System.Drawing.Point(90, 19);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(120, 41);
            this.lblNumero.TabIndex = 18;
            this.lblNumero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSerie
            // 
            this.lblSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerie.Location = new System.Drawing.Point(8, 18);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(76, 42);
            this.lblSerie.TabIndex = 17;
            this.lblSerie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTicket
            // 
            this.btnTicket.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTicket.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTicket.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTicket.Location = new System.Drawing.Point(208, 60);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(84, 72);
            this.btnTicket.TabIndex = 31;
            this.btnTicket.Text = "T";
            this.btnTicket.UseVisualStyleBackColor = false;
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // btnBoleta
            // 
            this.btnBoleta.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBoleta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBoleta.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoleta.Location = new System.Drawing.Point(112, 59);
            this.btnBoleta.Name = "btnBoleta";
            this.btnBoleta.Size = new System.Drawing.Size(90, 72);
            this.btnBoleta.TabIndex = 30;
            this.btnBoleta.Text = "B";
            this.btnBoleta.UseVisualStyleBackColor = false;
            this.btnBoleta.Click += new System.EventHandler(this.btnBoleta_Click);
            // 
            // btnFactura
            // 
            this.btnFactura.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFactura.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFactura.Location = new System.Drawing.Point(21, 60);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(84, 72);
            this.btnFactura.TabIndex = 29;
            this.btnFactura.Text = "F";
            this.btnFactura.UseVisualStyleBackColor = false;
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblNroComanda);
            this.groupBox2.Controls.Add(this.btnTeclado);
            this.groupBox2.Controls.Add(this.chbxPorConsumo);
            this.groupBox2.Controls.Add(this.lblTipoPago);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnRegistrarVenta);
            this.groupBox2.Controls.Add(this.btnCancelarPedido);
            this.groupBox2.Controls.Add(this.btnFactura);
            this.groupBox2.Controls.Add(this.btnBoleta);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.btnTicket);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Location = new System.Drawing.Point(564, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(637, 453);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Canjear";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(351, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 16);
            this.label6.TabIndex = 50;
            this.label6.Text = "Nro Comanda:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNroComanda
            // 
            this.lblNroComanda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNroComanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroComanda.Location = new System.Drawing.Point(464, 20);
            this.lblNroComanda.Name = "lblNroComanda";
            this.lblNroComanda.Size = new System.Drawing.Size(124, 28);
            this.lblNroComanda.TabIndex = 49;
            this.lblNroComanda.Text = "0";
            this.lblNroComanda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTeclado
            // 
            this.btnTeclado.BackColor = System.Drawing.Color.Silver;
            this.btnTeclado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTeclado.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeclado.ForeColor = System.Drawing.Color.Black;
            this.btnTeclado.Image = global::SwJugueriaAgustin.Properties.Resources.teclado2;
            this.btnTeclado.Location = new System.Drawing.Point(548, 219);
            this.btnTeclado.Name = "btnTeclado";
            this.btnTeclado.Size = new System.Drawing.Size(82, 103);
            this.btnTeclado.TabIndex = 48;
            this.btnTeclado.Text = "Teclado";
            this.btnTeclado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTeclado.UseVisualStyleBackColor = false;
            this.btnTeclado.Click += new System.EventHandler(this.btnTeclado_Click);
            // 
            // chbxPorConsumo
            // 
            this.chbxPorConsumo.AutoSize = true;
            this.chbxPorConsumo.BackColor = System.Drawing.Color.White;
            this.chbxPorConsumo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbxPorConsumo.Location = new System.Drawing.Point(29, 19);
            this.chbxPorConsumo.Name = "chbxPorConsumo";
            this.chbxPorConsumo.Size = new System.Drawing.Size(164, 34);
            this.chbxPorConsumo.TabIndex = 40;
            this.chbxPorConsumo.Text = "Por Consumo";
            this.chbxPorConsumo.UseVisualStyleBackColor = false;
            // 
            // lblTipoPago
            // 
            this.lblTipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoPago.Location = new System.Drawing.Point(453, 159);
            this.lblTipoPago.Name = "lblTipoPago";
            this.lblTipoPago.ReadOnly = true;
            this.lblTipoPago.Size = new System.Drawing.Size(131, 31);
            this.lblTipoPago.TabIndex = 38;
            this.lblTipoPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(359, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 21);
            this.label4.TabIndex = 39;
            this.label4.Text = "Tipo Pago:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(92, 155);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.ReadOnly = true;
            this.lblTotal.Size = new System.Drawing.Size(116, 31);
            this.lblTotal.TabIndex = 28;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "Total:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pdTicketVentaT
            // 
            this.pdTicketVentaT.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdTicketVentaT_PrintPage);
            // 
            // pdFacturaT
            // 
            this.pdFacturaT.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdFacturaT_PrintPage);
            // 
            // pdBoletaT
            // 
            this.pdBoletaT.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdBoletaT_PrintPage);
            // 
            // btnFacturaB
            // 
            this.btnFacturaB.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFacturaB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFacturaB.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturaB.Location = new System.Drawing.Point(6, 23);
            this.btnFacturaB.Name = "btnFacturaB";
            this.btnFacturaB.Size = new System.Drawing.Size(68, 58);
            this.btnFacturaB.TabIndex = 40;
            this.btnFacturaB.Text = "F";
            this.btnFacturaB.UseVisualStyleBackColor = false;
            this.btnFacturaB.Click += new System.EventHandler(this.btnFacturaB_Click);
            // 
            // btnBoletaB
            // 
            this.btnBoletaB.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBoletaB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBoletaB.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBoletaB.Location = new System.Drawing.Point(79, 23);
            this.btnBoletaB.Name = "btnBoletaB";
            this.btnBoletaB.Size = new System.Drawing.Size(68, 58);
            this.btnBoletaB.TabIndex = 41;
            this.btnBoletaB.Text = "B";
            this.btnBoletaB.UseVisualStyleBackColor = false;
            this.btnBoletaB.Click += new System.EventHandler(this.btnBoletaB_Click);
            // 
            // btnTickeB
            // 
            this.btnTickeB.BackColor = System.Drawing.Color.Gainsboro;
            this.btnTickeB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTickeB.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTickeB.Location = new System.Drawing.Point(152, 23);
            this.btnTickeB.Name = "btnTickeB";
            this.btnTickeB.Size = new System.Drawing.Size(68, 58);
            this.btnTickeB.TabIndex = 42;
            this.btnTickeB.Text = "T";
            this.btnTickeB.UseVisualStyleBackColor = false;
            this.btnTickeB.Click += new System.EventHandler(this.btnTickeB_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTickeB);
            this.groupBox1.Controls.Add(this.btnFacturaB);
            this.groupBox1.Controls.Add(this.btnBoletaB);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSerie);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 95);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscardor:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(21, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 43);
            this.button1.TabIndex = 40;
            this.button1.Text = "VISTA PREVIA";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 43;
            this.label5.Text = "Serie:";
            // 
            // lblSerieActual
            // 
            this.lblSerieActual.AutoSize = true;
            this.lblSerieActual.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerieActual.Location = new System.Drawing.Point(63, 124);
            this.lblSerieActual.Name = "lblSerieActual";
            this.lblSerieActual.Size = new System.Drawing.Size(25, 20);
            this.lblSerieActual.TabIndex = 44;
            this.lblSerieActual.Text = "00";
            // 
            // lblNumeroActual
            // 
            this.lblNumeroActual.AutoSize = true;
            this.lblNumeroActual.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroActual.Location = new System.Drawing.Point(196, 126);
            this.lblNumeroActual.Name = "lblNumeroActual";
            this.lblNumeroActual.Size = new System.Drawing.Size(73, 20);
            this.lblNumeroActual.TabIndex = 46;
            this.lblNumeroActual.Text = "00000000";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(124, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 45;
            this.label8.Text = "Numero:";
            // 
            // ppdVer
            // 
            this.ppdVer.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdVer.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdVer.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdVer.Enabled = true;
            this.ppdVer.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdVer.Icon")));
            this.ppdVer.Name = "ppdVer";
            this.ppdVer.Visible = false;
            // 
            // FrmCanjearComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1213, 471);
            this.Controls.Add(this.btnIngresoManual);
            this.Controls.Add(this.lblNumeroActual);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblSerieActual);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvDetalleVenta);
            this.Name = "FrmCanjearComprobante";
            this.Text = "Cambiar Comprobante";
            this.Load += new System.EventHandler(this.FrmCanjearComprobante_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleVenta)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.DataGridView dgvDetalleVenta;
        private System.Windows.Forms.Button btnCancelarPedido;
        private System.Windows.Forms.Button btnRegistrarVenta;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label labelDNIRUC;
        private System.Windows.Forms.TextBox txtNroDocumento;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblComprobante;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnBoleta;
        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lblTipoPago;
        private System.Windows.Forms.Label label4;
        private System.Drawing.Printing.PrintDocument pdTicketVentaT;
        private System.Drawing.Printing.PrintDocument pdFacturaT;
        private System.Drawing.Printing.PrintDocument pdBoletaT;
        private System.Windows.Forms.Button btnFacturaB;
        private System.Windows.Forms.Button btnBoletaB;
        private System.Windows.Forms.Button btnTickeB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSerieActual;
        private System.Windows.Forms.Label lblNumeroActual;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PrintPreviewDialog ppdVer;
        private System.Windows.Forms.CheckBox chbxPorConsumo;
        private System.Windows.Forms.Button btnIngresoManual;
        private System.Windows.Forms.Button btnTeclado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblNroComanda;
    }
}