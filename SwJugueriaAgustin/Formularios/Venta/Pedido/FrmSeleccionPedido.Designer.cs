namespace SwJugueriaAgustin.Formularios.Operaciones
{
    partial class FrmSeleccionPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionPedido));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPedido = new System.Windows.Forms.DataGridView();
            this.cnImprimido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cnCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnPlato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCombo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCodPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnIDPresentacionCombo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsListaPedido = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nOIMPRIMIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qUITARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNumeroC = new System.Windows.Forms.Label();
            this.lblSerieC = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblMozo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMesa = new System.Windows.Forms.Label();
            this.gbxAnulacion = new System.Windows.Forms.GroupBox();
            this.txtMotivoAnulacion = new System.Windows.Forms.TextBox();
            this.pdBar = new System.Drawing.Printing.PrintDocument();
            this.pdCocina = new System.Drawing.Printing.PrintDocument();
            this.ppdView = new System.Windows.Forms.PrintPreviewDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.pdPreCuenta = new System.Drawing.Printing.PrintDocument();
            this.btnVista = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.lblCodCliente = new System.Windows.Forms.Label();
            this.btnPreCuenta = new System.Windows.Forms.Button();
            this.btnAnularPedido = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCargarMozo = new System.Windows.Forms.Button();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnSolicitarPedido = new System.Windows.Forms.Button();
            this.dgvListaPlatos = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pdHorno = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            this.cmsListaPedido.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxAnulacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPlatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mozo:";
            // 
            // dgvPedido
            // 
            this.dgvPedido.AllowUserToAddRows = false;
            this.dgvPedido.AllowUserToDeleteRows = false;
            this.dgvPedido.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedido.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
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
            this.cnCodPedido,
            this.cnCategoria,
            this.cnCosto,
            this.cnIDPresentacionCombo});
            this.dgvPedido.ContextMenuStrip = this.cmsListaPedido;
            this.dgvPedido.Location = new System.Drawing.Point(9, 259);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.RowHeadersVisible = false;
            this.dgvPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedido.Size = new System.Drawing.Size(581, 184);
            this.dgvPedido.TabIndex = 2;
            this.dgvPedido.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedido_CellClick);
            this.dgvPedido.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedido_CellEndEdit);
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
            this.cnCodigo.Width = 65;
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
            this.cnDescripcion.Width = 90;
            // 
            // cnCombo
            // 
            this.cnCombo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnCombo.HeaderText = "Combo";
            this.cnCombo.Name = "cnCombo";
            this.cnCombo.ReadOnly = true;
            this.cnCombo.Width = 50;
            // 
            // cnCantidad
            // 
            this.cnCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnCantidad.HeaderText = "Cant.";
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
            this.cnPrecio.Width = 65;
            // 
            // cnImporte
            // 
            this.cnImporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnImporte.HeaderText = "Importe";
            this.cnImporte.Name = "cnImporte";
            this.cnImporte.ReadOnly = true;
            this.cnImporte.Width = 80;
            // 
            // cnCodPedido
            // 
            this.cnCodPedido.HeaderText = "CodPedido";
            this.cnCodPedido.Name = "cnCodPedido";
            this.cnCodPedido.ReadOnly = true;
            this.cnCodPedido.Visible = false;
            // 
            // cnCategoria
            // 
            this.cnCategoria.HeaderText = "Categoria";
            this.cnCategoria.Name = "cnCategoria";
            // 
            // cnCosto
            // 
            this.cnCosto.HeaderText = "Costo";
            this.cnCosto.Name = "cnCosto";
            this.cnCosto.Visible = false;
            // 
            // cnIDPresentacionCombo
            // 
            this.cnIDPresentacionCombo.HeaderText = "IDPresentacionCombo";
            this.cnIDPresentacionCombo.Name = "cnIDPresentacionCombo";
            this.cnIDPresentacionCombo.Visible = false;
            // 
            // cmsListaPedido
            // 
            this.cmsListaPedido.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nOIMPRIMIOToolStripMenuItem,
            this.qUITARToolStripMenuItem});
            this.cmsListaPedido.Name = "cmsListaPedido";
            this.cmsListaPedido.Size = new System.Drawing.Size(154, 48);
            // 
            // nOIMPRIMIOToolStripMenuItem
            // 
            this.nOIMPRIMIOToolStripMenuItem.Name = "nOIMPRIMIOToolStripMenuItem";
            this.nOIMPRIMIOToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.nOIMPRIMIOToolStripMenuItem.Text = "NO IMPRIMIO";
            this.nOIMPRIMIOToolStripMenuItem.Click += new System.EventHandler(this.nOIMPRIMIOToolStripMenuItem_Click);
            // 
            // qUITARToolStripMenuItem
            // 
            this.qUITARToolStripMenuItem.Name = "qUITARToolStripMenuItem";
            this.qUITARToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.qUITARToolStripMenuItem.Text = "QUITAR PLATO";
            this.qUITARToolStripMenuItem.Click += new System.EventHandler(this.qUITARToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mesa:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblNumeroC);
            this.groupBox2.Controls.Add(this.lblSerieC);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.lblMozo);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblMesa);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(593, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 96);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Pedido";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "N° Com:";
            // 
            // lblNumeroC
            // 
            this.lblNumeroC.BackColor = System.Drawing.Color.White;
            this.lblNumeroC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumeroC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroC.Location = new System.Drawing.Point(254, 21);
            this.lblNumeroC.Name = "lblNumeroC";
            this.lblNumeroC.Size = new System.Drawing.Size(88, 21);
            this.lblNumeroC.TabIndex = 13;
            this.lblNumeroC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSerieC
            // 
            this.lblSerieC.BackColor = System.Drawing.Color.White;
            this.lblSerieC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSerieC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerieC.Location = new System.Drawing.Point(204, 21);
            this.lblSerieC.Name = "lblSerieC";
            this.lblSerieC.Size = new System.Drawing.Size(48, 21);
            this.lblSerieC.TabIndex = 11;
            this.lblSerieC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(209, 57);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(133, 21);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMozo
            // 
            this.lblMozo.BackColor = System.Drawing.Color.White;
            this.lblMozo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMozo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMozo.Location = new System.Drawing.Point(60, 66);
            this.lblMozo.Name = "lblMozo";
            this.lblMozo.Size = new System.Drawing.Size(88, 21);
            this.lblMozo.TabIndex = 12;
            this.lblMozo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total:";
            // 
            // lblMesa
            // 
            this.lblMesa.BackColor = System.Drawing.Color.White;
            this.lblMesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesa.Location = new System.Drawing.Point(60, 21);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(88, 21);
            this.lblMesa.TabIndex = 11;
            this.lblMesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxAnulacion
            // 
            this.gbxAnulacion.Controls.Add(this.txtMotivoAnulacion);
            this.gbxAnulacion.Location = new System.Drawing.Point(785, 222);
            this.gbxAnulacion.Name = "gbxAnulacion";
            this.gbxAnulacion.Size = new System.Drawing.Size(163, 146);
            this.gbxAnulacion.TabIndex = 15;
            this.gbxAnulacion.TabStop = false;
            this.gbxAnulacion.Text = "Anulacion";
            // 
            // txtMotivoAnulacion
            // 
            this.txtMotivoAnulacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivoAnulacion.Location = new System.Drawing.Point(8, 18);
            this.txtMotivoAnulacion.Multiline = true;
            this.txtMotivoAnulacion.Name = "txtMotivoAnulacion";
            this.txtMotivoAnulacion.Size = new System.Drawing.Size(150, 111);
            this.txtMotivoAnulacion.TabIndex = 14;
            // 
            // pdBar
            // 
            this.pdBar.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdBar_PrintPage);
            // 
            // pdCocina
            // 
            this.pdCocina.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdCocina_PrintPage);
            // 
            // ppdView
            // 
            this.ppdView.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdView.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdView.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdView.Enabled = true;
            this.ppdView.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdView.Icon")));
            this.ppdView.Name = "ppdView";
            this.ppdView.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Lista de Plato Solicitados:";
            // 
            // pdPreCuenta
            // 
            this.pdPreCuenta.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdPreCuenta_PrintPage);
            // 
            // btnVista
            // 
            this.btnVista.BackColor = System.Drawing.Color.Teal;
            this.btnVista.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVista.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVista.ForeColor = System.Drawing.Color.White;
            this.btnVista.Location = new System.Drawing.Point(15, 204);
            this.btnVista.Name = "btnVista";
            this.btnVista.Size = new System.Drawing.Size(128, 34);
            this.btnVista.TabIndex = 22;
            this.btnVista.Text = "Vista Previa";
            this.btnVista.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVista.UseVisualStyleBackColor = false;
            this.btnVista.Click += new System.EventHandler(this.btnVista_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.BackColor = System.Drawing.Color.White;
            this.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(691, 11);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(251, 21);
            this.lblCliente.TabIndex = 13;
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCliente.Visible = false;
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(596, 16);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(42, 13);
            this.labelCliente.TabIndex = 13;
            this.labelCliente.Text = "Cliente:";
            this.labelCliente.Visible = false;
            // 
            // lblCodCliente
            // 
            this.lblCodCliente.BackColor = System.Drawing.Color.White;
            this.lblCodCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCodCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodCliente.Location = new System.Drawing.Point(643, 11);
            this.lblCodCliente.Name = "lblCodCliente";
            this.lblCodCliente.Size = new System.Drawing.Size(44, 21);
            this.lblCodCliente.TabIndex = 24;
            this.lblCodCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCodCliente.Visible = false;
            // 
            // btnPreCuenta
            // 
            this.btnPreCuenta.BackColor = System.Drawing.Color.White;
            this.btnPreCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreCuenta.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreCuenta.ForeColor = System.Drawing.Color.Black;
            this.btnPreCuenta.Image = global::SwJugueriaAgustin.Properties.Resources.if_emblem_print_24705;
            this.btnPreCuenta.Location = new System.Drawing.Point(785, 139);
            this.btnPreCuenta.Name = "btnPreCuenta";
            this.btnPreCuenta.Size = new System.Drawing.Size(163, 71);
            this.btnPreCuenta.TabIndex = 23;
            this.btnPreCuenta.Text = "Imprimir Pre-Cuenta";
            this.btnPreCuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreCuenta.UseVisualStyleBackColor = false;
            this.btnPreCuenta.Click += new System.EventHandler(this.btnPreCuenta_Click_1);
            // 
            // btnAnularPedido
            // 
            this.btnAnularPedido.BackColor = System.Drawing.Color.White;
            this.btnAnularPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnularPedido.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnularPedido.ForeColor = System.Drawing.Color.Tomato;
            this.btnAnularPedido.Image = global::SwJugueriaAgustin.Properties.Resources.CANCEL_FORMULARIO;
            this.btnAnularPedido.Location = new System.Drawing.Point(785, 376);
            this.btnAnularPedido.Name = "btnAnularPedido";
            this.btnAnularPedido.Size = new System.Drawing.Size(163, 67);
            this.btnAnularPedido.TabIndex = 13;
            this.btnAnularPedido.Text = "Anular Pedido";
            this.btnAnularPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnularPedido.UseVisualStyleBackColor = false;
            this.btnAnularPedido.Click += new System.EventHandler(this.btnAnularPedido_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Image = global::SwJugueriaAgustin.Properties.Resources.salida;
            this.btnCancelar.Location = new System.Drawing.Point(599, 376);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(180, 67);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCargarMozo
            // 
            this.btnCargarMozo.BackColor = System.Drawing.Color.White;
            this.btnCargarMozo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargarMozo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarMozo.ForeColor = System.Drawing.Color.Black;
            this.btnCargarMozo.Image = global::SwJugueriaAgustin.Properties.Resources.if_2_330395;
            this.btnCargarMozo.Location = new System.Drawing.Point(597, 139);
            this.btnCargarMozo.Name = "btnCargarMozo";
            this.btnCargarMozo.Size = new System.Drawing.Size(182, 70);
            this.btnCargarMozo.TabIndex = 19;
            this.btnCargarMozo.Text = "Cargar Mozo";
            this.btnCargarMozo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCargarMozo.UseVisualStyleBackColor = false;
            this.btnCargarMozo.Click += new System.EventHandler(this.btnCargarMozo_Click_1);
            // 
            // btnFacturar
            // 
            this.btnFacturar.BackColor = System.Drawing.Color.White;
            this.btnFacturar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFacturar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.ForeColor = System.Drawing.Color.Black;
            this.btnFacturar.Image = global::SwJugueriaAgustin.Properties.Resources.money_exit;
            this.btnFacturar.Location = new System.Drawing.Point(597, 298);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(182, 70);
            this.btnFacturar.TabIndex = 18;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFacturar.UseVisualStyleBackColor = false;
            this.btnFacturar.Visible = false;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnSolicitarPedido
            // 
            this.btnSolicitarPedido.BackColor = System.Drawing.Color.White;
            this.btnSolicitarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSolicitarPedido.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolicitarPedido.ForeColor = System.Drawing.Color.Black;
            this.btnSolicitarPedido.Image = global::SwJugueriaAgustin.Properties.Resources.SAVE_FOR;
            this.btnSolicitarPedido.Location = new System.Drawing.Point(597, 219);
            this.btnSolicitarPedido.Name = "btnSolicitarPedido";
            this.btnSolicitarPedido.Size = new System.Drawing.Size(182, 70);
            this.btnSolicitarPedido.TabIndex = 4;
            this.btnSolicitarPedido.Text = "Realizar - Guardar Pedido";
            this.btnSolicitarPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSolicitarPedido.UseVisualStyleBackColor = false;
            this.btnSolicitarPedido.Click += new System.EventHandler(this.btnSolicitarPedido_Click);
            // 
            // dgvListaPlatos
            // 
            this.dgvListaPlatos.AllowUserToAddRows = false;
            this.dgvListaPlatos.AllowUserToDeleteRows = false;
            this.dgvListaPlatos.BackgroundColor = System.Drawing.Color.White;
            this.dgvListaPlatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaPlatos.ContextMenuStrip = this.cmsListaPedido;
            this.dgvListaPlatos.Location = new System.Drawing.Point(15, 38);
            this.dgvListaPlatos.Name = "dgvListaPlatos";
            this.dgvListaPlatos.ReadOnly = true;
            this.dgvListaPlatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaPlatos.Size = new System.Drawing.Size(569, 164);
            this.dgvListaPlatos.TabIndex = 14;
            this.dgvListaPlatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaPlatos_CellContentDoubleClick);
            this.dgvListaPlatos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Buscar Plato:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(109, 11);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(475, 22);
            this.txtBuscar.TabIndex = 15;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged_1);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // pdHorno
            // 
            this.pdHorno.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdHorno_PrintPage);
            // 
            // FrmSeleccionPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(959, 455);
            this.Controls.Add(this.lblCodCliente);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.btnPreCuenta);
            this.Controls.Add(this.btnAnularPedido);
            this.Controls.Add(this.btnVista);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCargarMozo);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnSolicitarPedido);
            this.Controls.Add(this.gbxAnulacion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvListaPlatos);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvPedido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSeleccionPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección Pedido";
            this.Load += new System.EventHandler(this.SeleccionPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            this.cmsListaPedido.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxAnulacion.ResumeLayout(false);
            this.gbxAnulacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaPlatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMozo;
        public System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.Button btnAnularPedido;
        private System.Windows.Forms.TextBox txtMotivoAnulacion;
        private System.Windows.Forms.GroupBox gbxAnulacion;
        private System.Drawing.Printing.PrintDocument pdBar;
        private System.Drawing.Printing.PrintDocument pdCocina;
        public System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.PrintPreviewDialog ppdView;
        private System.Windows.Forms.ContextMenuStrip cmsListaPedido;
        private System.Windows.Forms.ToolStripMenuItem nOIMPRIMIOToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCargarMozo;
        public System.Windows.Forms.Button btnFacturar;
        public System.Windows.Forms.Button btnSolicitarPedido;
        private System.Windows.Forms.Button btnCancelar;
        private System.Drawing.Printing.PrintDocument pdPreCuenta;
        public System.Windows.Forms.Button btnVista;
        private System.Windows.Forms.ToolStripMenuItem qUITARToolStripMenuItem;
        public System.Windows.Forms.Button btnPreCuenta;
        public System.Windows.Forms.Label lblCliente;
        public System.Windows.Forms.Label labelCliente;
        public System.Windows.Forms.Label lblCodCliente;
        public System.Windows.Forms.Label lblTotal;
        public System.Windows.Forms.Label lblSerieC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dgvListaPlatos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscar;
        public System.Windows.Forms.Label lblNumeroC;
        private System.Drawing.Printing.PrintDocument pdHorno;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cnImprimido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnPlato;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDescripcion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cnCombo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCodPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnIDPresentacionCombo;
    }
}