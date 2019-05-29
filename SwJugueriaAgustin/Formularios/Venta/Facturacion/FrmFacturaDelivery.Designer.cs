﻿namespace SwJugueriaAgustin.Formularios.Operaciones
{
    partial class FrmFacturaDelivery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFacturaDelivery));
            this.label1 = new System.Windows.Forms.Label();
            this.cboComprobante = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefono1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTipoPago = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFechaCaja = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtDescuentoSoles = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDescuentoPorc = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.lblCambio = new System.Windows.Forms.Label();
            this.cboTipoImpresion = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblIgv = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNroIdentidad = new System.Windows.Forms.TextBox();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblMozo = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblMesa = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ppDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.dgvPedido = new System.Windows.Forms.DataGridView();
            this.cnImprimido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cnCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnPlato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCombo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnIDPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnIDPresentacionCombo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdBar = new System.Drawing.Printing.PrintDocument();
            this.pdCocina = new System.Drawing.Printing.PrintDocument();
            this.btnView = new System.Windows.Forms.Button();
            this.pdComandaDelivery = new System.Drawing.Printing.PrintDocument();
            this.txtTelefono2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblComanda = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.pdHorno = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comprobante:";
            // 
            // cboComprobante
            // 
            this.cboComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComprobante.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboComprobante.FormattingEnabled = true;
            this.cboComprobante.Location = new System.Drawing.Point(129, 43);
            this.cboComprobante.Name = "cboComprobante";
            this.cboComprobante.Size = new System.Drawing.Size(255, 24);
            this.cboComprobante.TabIndex = 2;
            this.cboComprobante.SelectionChangeCommitted += new System.EventHandler(this.cboComprobante_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Serie - Número:";
            // 
            // txtSerie
            // 
            this.txtSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(129, 70);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.ReadOnly = true;
            this.txtSerie.Size = new System.Drawing.Size(68, 22);
            this.txtSerie.TabIndex = 4;
            // 
            // txtNumero
            // 
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Location = new System.Drawing.Point(208, 70);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(176, 22);
            this.txtNumero.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Telefonos:";
            // 
            // txtTelefono1
            // 
            this.txtTelefono1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono1.Location = new System.Drawing.Point(134, 71);
            this.txtTelefono1.Name = "txtTelefono1";
            this.txtTelefono1.Size = new System.Drawing.Size(119, 22);
            this.txtTelefono1.TabIndex = 7;
            this.txtTelefono1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroCliente_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nro Identidad:";
            // 
            // cboTipoPago
            // 
            this.cboTipoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoPago.FormattingEnabled = true;
            this.cboTipoPago.Location = new System.Drawing.Point(129, 96);
            this.cboTipoPago.Name = "cboTipoPago";
            this.cboTipoPago.Size = new System.Drawing.Size(255, 24);
            this.cboTipoPago.TabIndex = 11;
            this.cboTipoPago.SelectionChangeCommitted += new System.EventHandler(this.cboTipoPago_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tipo Pago:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Fecha Caja:";
            // 
            // lblFechaCaja
            // 
            this.lblFechaCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFechaCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaCaja.Location = new System.Drawing.Point(134, 46);
            this.lblFechaCaja.Name = "lblFechaCaja";
            this.lblFechaCaja.Size = new System.Drawing.Size(82, 21);
            this.lblFechaCaja.TabIndex = 13;
            this.lblFechaCaja.Text = "00/00/0000";
            this.lblFechaCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistrar.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(743, 524);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(247, 56);
            this.btnRegistrar.TabIndex = 14;
            this.btnRegistrar.Text = "&Completar Venta e Imprimir";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 83);
            this.panel1.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(6, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(392, 40);
            this.label8.TabIndex = 16;
            this.label8.Text = "Facturación: Venta Delivery";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtDescuentoSoles);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtDescuentoPorc);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtEfectivo);
            this.groupBox1.Controls.Add(this.lblCambio);
            this.groupBox1.Controls.Add(this.cboTipoImpresion);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtSerie);
            this.groupBox1.Controls.Add(this.lblIgv);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblSubTotal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboTipoPago);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.cboComprobante);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(590, 250);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 270);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facturacion:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(258, 124);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(28, 21);
            this.label18.TabIndex = 37;
            this.label18.Text = "s./";
            // 
            // txtDescuentoSoles
            // 
            this.txtDescuentoSoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuentoSoles.Location = new System.Drawing.Point(287, 125);
            this.txtDescuentoSoles.Name = "txtDescuentoSoles";
            this.txtDescuentoSoles.Size = new System.Drawing.Size(97, 22);
            this.txtDescuentoSoles.TabIndex = 36;
            this.txtDescuentoSoles.Text = "0";
            this.txtDescuentoSoles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescuentoSoles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescuentoSoles_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(201, 124);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 21);
            this.label20.TabIndex = 35;
            this.label20.Text = "%";
            // 
            // txtDescuentoPorc
            // 
            this.txtDescuentoPorc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuentoPorc.Location = new System.Drawing.Point(130, 125);
            this.txtDescuentoPorc.Name = "txtDescuentoPorc";
            this.txtDescuentoPorc.Size = new System.Drawing.Size(69, 22);
            this.txtDescuentoPorc.TabIndex = 34;
            this.txtDescuentoPorc.Text = "0";
            this.txtDescuentoPorc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescuentoPorc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescuentoPorc_KeyDown);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(9, 128);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 17);
            this.label21.TabIndex = 33;
            this.label21.Text = "Descuento:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 17);
            this.label12.TabIndex = 29;
            this.label12.Text = "Tipo de Impresión:";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.Location = new System.Drawing.Point(129, 236);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(87, 22);
            this.txtEfectivo.TabIndex = 22;
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEfectivo.TextChanged += new System.EventHandler(this.txtEfectivo_TextChanged);
            // 
            // lblCambio
            // 
            this.lblCambio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.Location = new System.Drawing.Point(286, 236);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(98, 21);
            this.lblCambio.TabIndex = 21;
            this.lblCambio.Text = "0.00";
            this.lblCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTipoImpresion
            // 
            this.cboTipoImpresion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoImpresion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipoImpresion.FormattingEnabled = true;
            this.cboTipoImpresion.Items.AddRange(new object[] {
            "DETALLADO",
            "POR CONSUMO"});
            this.cboTipoImpresion.Location = new System.Drawing.Point(130, 16);
            this.cboTipoImpresion.Name = "cboTipoImpresion";
            this.cboTipoImpresion.Size = new System.Drawing.Size(255, 24);
            this.cboTipoImpresion.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(222, 239);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 17);
            this.label15.TabIndex = 20;
            this.label15.Text = "Cambio:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 240);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 17);
            this.label13.TabIndex = 18;
            this.label13.Text = "Pago Con:";
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTotal.Location = new System.Drawing.Point(129, 200);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(255, 32);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Total (s./):";
            // 
            // lblIgv
            // 
            this.lblIgv.BackColor = System.Drawing.Color.White;
            this.lblIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblIgv.Location = new System.Drawing.Point(129, 176);
            this.lblIgv.Name = "lblIgv";
            this.lblIgv.Size = new System.Drawing.Size(255, 21);
            this.lblIgv.TabIndex = 8;
            this.lblIgv.Text = "0.00";
            this.lblIgv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.BackColor = System.Drawing.Color.White;
            this.lblSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblSubTotal.Location = new System.Drawing.Point(129, 151);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(255, 21);
            this.lblSubTotal.TabIndex = 7;
            this.lblSubTotal.Text = "0.00";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "SubTotal:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "I.G.V:";
            // 
            // txtNroIdentidad
            // 
            this.txtNroIdentidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroIdentidad.Location = new System.Drawing.Point(134, 123);
            this.txtNroIdentidad.Name = "txtNroIdentidad";
            this.txtNroIdentidad.Size = new System.Drawing.Size(255, 22);
            this.txtNroIdentidad.TabIndex = 36;
            // 
            // txtReferencia
            // 
            this.txtReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferencia.Location = new System.Drawing.Point(134, 193);
            this.txtReferencia.Multiline = true;
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(255, 37);
            this.txtReferencia.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 193);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 17);
            this.label17.TabIndex = 32;
            this.label17.Text = "Referencia:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(134, 149);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(255, 37);
            this.txtDireccion.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(11, 156);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 17);
            this.label16.TabIndex = 30;
            this.label16.Text = "Direccion:";
            // 
            // lblMozo
            // 
            this.lblMozo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMozo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMozo.Location = new System.Drawing.Point(277, 22);
            this.lblMozo.Name = "lblMozo";
            this.lblMozo.Size = new System.Drawing.Size(112, 21);
            this.lblMozo.TabIndex = 27;
            this.lblMozo.Text = "Mozo A";
            this.lblMozo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(224, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 17);
            this.label14.TabIndex = 26;
            this.label14.Text = "Mozo:";
            // 
            // lblMesa
            // 
            this.lblMesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesa.Location = new System.Drawing.Point(134, 22);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(69, 21);
            this.lblMesa.TabIndex = 25;
            this.lblMesa.Text = "Mesa 00";
            this.lblMesa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 17);
            this.label11.TabIndex = 24;
            this.label11.Text = "Mesa:";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.Location = new System.Drawing.Point(135, 97);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(254, 22);
            this.txtCliente.TabIndex = 23;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(590, 524);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(137, 56);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            // dgvPedido
            // 
            this.dgvPedido.AllowUserToAddRows = false;
            this.dgvPedido.AllowUserToDeleteRows = false;
            this.dgvPedido.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnImprimido,
            this.cnCodigo,
            this.cnPlato,
            this.cnDescripcion,
            this.cnCombo,
            this.cnCantidad,
            this.cnPrecio,
            this.cnImporte,
            this.cnIDPedido,
            this.cnCategoria,
            this.cnCosto,
            this.cnIDPresentacionCombo});
            this.dgvPedido.Location = new System.Drawing.Point(12, 99);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedido.Size = new System.Drawing.Size(572, 468);
            this.dgvPedido.TabIndex = 25;
            this.dgvPedido.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedido_CellClick);
            // 
            // cnImprimido
            // 
            this.cnImprimido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnImprimido.HeaderText = "Impri.";
            this.cnImprimido.Name = "cnImprimido";
            this.cnImprimido.ReadOnly = true;
            this.cnImprimido.Width = 50;
            // 
            // cnCodigo
            // 
            this.cnCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnCodigo.HeaderText = "Codigo";
            this.cnCodigo.Name = "cnCodigo";
            this.cnCodigo.ReadOnly = true;
            this.cnCodigo.Visible = false;
            this.cnCodigo.Width = 55;
            // 
            // cnPlato
            // 
            this.cnPlato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnPlato.HeaderText = "Plato";
            this.cnPlato.Name = "cnPlato";
            this.cnPlato.ReadOnly = true;
            this.cnPlato.Width = 180;
            // 
            // cnDescripcion
            // 
            this.cnDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnDescripcion.HeaderText = "Descripcion";
            this.cnDescripcion.Name = "cnDescripcion";
            this.cnDescripcion.Width = 80;
            // 
            // cnCombo
            // 
            this.cnCombo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnCombo.HeaderText = "Combo";
            this.cnCombo.Name = "cnCombo";
            this.cnCombo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cnCombo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cnCombo.Width = 65;
            // 
            // cnCantidad
            // 
            this.cnCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnCantidad.HeaderText = "Cantidad";
            this.cnCantidad.Name = "cnCantidad";
            this.cnCantidad.ReadOnly = true;
            this.cnCantidad.Width = 55;
            // 
            // cnPrecio
            // 
            this.cnPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnPrecio.HeaderText = "Precio";
            this.cnPrecio.Name = "cnPrecio";
            this.cnPrecio.ReadOnly = true;
            this.cnPrecio.Width = 55;
            // 
            // cnImporte
            // 
            this.cnImporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnImporte.HeaderText = "Importe";
            this.cnImporte.Name = "cnImporte";
            this.cnImporte.ReadOnly = true;
            this.cnImporte.Width = 80;
            // 
            // cnIDPedido
            // 
            this.cnIDPedido.HeaderText = "CodPedido";
            this.cnIDPedido.Name = "cnIDPedido";
            this.cnIDPedido.ReadOnly = true;
            this.cnIDPedido.Visible = false;
            // 
            // cnCategoria
            // 
            this.cnCategoria.HeaderText = "Categoria";
            this.cnCategoria.Name = "cnCategoria";
            this.cnCategoria.ReadOnly = true;
            this.cnCategoria.Visible = false;
            // 
            // cnCosto
            // 
            this.cnCosto.HeaderText = "Costo";
            this.cnCosto.Name = "cnCosto";
            this.cnCosto.ReadOnly = true;
            this.cnCosto.Visible = false;
            // 
            // cnIDPresentacionCombo
            // 
            this.cnIDPresentacionCombo.HeaderText = "IDPresentacionCombo";
            this.cnIDPresentacionCombo.Name = "cnIDPresentacionCombo";
            this.cnIDPresentacionCombo.Visible = false;
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
            this.btnView.BackColor = System.Drawing.Color.SeaGreen;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(459, 504);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(112, 37);
            this.btnView.TabIndex = 37;
            this.btnView.Text = "Vista Previa";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // pdComandaDelivery
            // 
            this.pdComandaDelivery.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdPreCuenta_PrintPage);
            // 
            // txtTelefono2
            // 
            this.txtTelefono2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono2.Location = new System.Drawing.Point(259, 71);
            this.txtTelefono2.Name = "txtTelefono2";
            this.txtTelefono2.Size = new System.Drawing.Size(132, 22);
            this.txtTelefono2.TabIndex = 7;
            this.txtTelefono2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroCliente_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNroIdentidad);
            this.groupBox2.Controls.Add(this.txtDireccion);
            this.groupBox2.Controls.Add(this.txtTelefono1);
            this.groupBox2.Controls.Add(this.txtTelefono2);
            this.groupBox2.Controls.Add(this.lblComanda);
            this.groupBox2.Controls.Add(this.lblMozo);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.txtReferencia);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.lblMesa);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCliente);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.lblFechaCaja);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(590, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 239);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Complementarios:";
            // 
            // lblComanda
            // 
            this.lblComanda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblComanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComanda.Location = new System.Drawing.Point(277, 47);
            this.lblComanda.Name = "lblComanda";
            this.lblComanda.Size = new System.Drawing.Size(112, 21);
            this.lblComanda.TabIndex = 27;
            this.lblComanda.Text = "C - 0";
            this.lblComanda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(223, 48);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 17);
            this.label22.TabIndex = 26;
            this.label22.Text = "N° Com:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(11, 102);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 17);
            this.label19.TabIndex = 8;
            this.label19.Text = "Cliente:";
            // 
            // pdHorno
            // 
            this.pdHorno.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdHorno_PrintPage);
            // 
            // FrmFacturaDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(999, 584);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dgvPedido);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmFacturaDelivery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".::Facturar::.";
            this.Load += new System.EventHandler(this.FrmFacturar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboComprobante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelefono1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTipoPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFechaCaja;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblIgv;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.PrintPreviewDialog ppDialog;
        public System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label lblMesa;
        public System.Windows.Forms.Label lblMozo;
        private System.Windows.Forms.Label label14;
        private System.Drawing.Printing.PrintDocument pdBar;
        private System.Drawing.Printing.PrintDocument pdCocina;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboTipoImpresion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtNroIdentidad;
        private System.Windows.Forms.Button btnView;
        private System.Drawing.Printing.PrintDocument pdComandaDelivery;
        private System.Windows.Forms.TextBox txtTelefono2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtDescuentoSoles;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDescuentoPorc;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label lblComanda;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cnImprimido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnPlato;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDescripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cnCombo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnIDPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnIDPresentacionCombo;
        private System.Drawing.Printing.PrintDocument pdHorno;
    }
}