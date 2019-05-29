namespace SwJugueriaAgustin.Formularios.Venta.Pedido
{
    partial class FrmPedidoTactil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPedidoTactil));
            this.flpCategoria = new System.Windows.Forms.FlowLayoutPanel();
            this.flpSubCategoria = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNumeroC = new System.Windows.Forms.Label();
            this.lblSerieC = new System.Windows.Forms.Label();
            this.lblMozo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMesa = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flpProducto = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvPedido = new System.Windows.Forms.DataGridView();
            this.pdPreCuenta = new System.Drawing.Printing.PrintDocument();
            this.pdBar = new System.Drawing.Printing.PrintDocument();
            this.pdCocina = new System.Drawing.Printing.PrintDocument();
            this.ppdView = new System.Windows.Forms.PrintPreviewDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPreCuenta = new System.Windows.Forms.Button();
            this.btnAnularPedido = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSolicitarPedido = new System.Windows.Forms.Button();
            this.btnCargarMozo = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnMas = new System.Windows.Forms.Button();
            this.btnMenos = new System.Windows.Forms.Button();
            this.btnDescripcion = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpCategoria
            // 
            this.flpCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpCategoria.Location = new System.Drawing.Point(0, 0);
            this.flpCategoria.Name = "flpCategoria";
            this.flpCategoria.Size = new System.Drawing.Size(317, 89);
            this.flpCategoria.TabIndex = 0;
            // 
            // flpSubCategoria
            // 
            this.flpSubCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flpSubCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSubCategoria.Location = new System.Drawing.Point(0, 95);
            this.flpSubCategoria.Name = "flpSubCategoria";
            this.flpSubCategoria.Size = new System.Drawing.Size(317, 650);
            this.flpSubCategoria.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.lblNumeroC);
            this.groupBox2.Controls.Add(this.lblSerieC);
            this.groupBox2.Controls.Add(this.lblMozo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblMesa);
            this.groupBox2.Controls.Add(this.lblTotal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(1036, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 85);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos:";
            // 
            // lblNumeroC
            // 
            this.lblNumeroC.BackColor = System.Drawing.Color.White;
            this.lblNumeroC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNumeroC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroC.Location = new System.Drawing.Point(110, 51);
            this.lblNumeroC.Name = "lblNumeroC";
            this.lblNumeroC.Size = new System.Drawing.Size(79, 21);
            this.lblNumeroC.TabIndex = 15;
            this.lblNumeroC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSerieC
            // 
            this.lblSerieC.BackColor = System.Drawing.Color.White;
            this.lblSerieC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSerieC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerieC.Location = new System.Drawing.Point(61, 51);
            this.lblSerieC.Name = "lblSerieC";
            this.lblSerieC.Size = new System.Drawing.Size(48, 21);
            this.lblSerieC.TabIndex = 14;
            this.lblSerieC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMozo
            // 
            this.lblMozo.BackColor = System.Drawing.Color.White;
            this.lblMozo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMozo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMozo.Location = new System.Drawing.Point(236, 23);
            this.lblMozo.Name = "lblMozo";
            this.lblMozo.Size = new System.Drawing.Size(76, 21);
            this.lblMozo.TabIndex = 12;
            this.lblMozo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "N°:";
            // 
            // lblMesa
            // 
            this.lblMesa.BackColor = System.Drawing.Color.White;
            this.lblMesa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesa.Location = new System.Drawing.Point(63, 23);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(126, 21);
            this.lblMesa.TabIndex = 11;
            this.lblMesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(235, 51);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 21);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mesa:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mozo:";
            // 
            // flpProducto
            // 
            this.flpProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpProducto.Location = new System.Drawing.Point(321, 1);
            this.flpProducto.Name = "flpProducto";
            this.flpProducto.Size = new System.Drawing.Size(1045, 280);
            this.flpProducto.TabIndex = 0;
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
            this.cnCodPedido,
            this.cnCategoria,
            this.cnCosto});
            this.dgvPedido.Location = new System.Drawing.Point(323, 380);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedido.Size = new System.Drawing.Size(702, 357);
            this.dgvPedido.TabIndex = 22;
            this.dgvPedido.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedido_CellClick);
            // 
            // pdPreCuenta
            // 
            this.pdPreCuenta.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdPreCuenta_PrintPage);
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
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::SwJugueriaAgustin.Properties.Resources.update_print;
            this.button1.Location = new System.Drawing.Point(322, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 60);
            this.button1.TabIndex = 25;
            this.button1.Text = "No Imprimio";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPreCuenta
            // 
            this.btnPreCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreCuenta.BackColor = System.Drawing.Color.White;
            this.btnPreCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPreCuenta.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreCuenta.ForeColor = System.Drawing.Color.Black;
            this.btnPreCuenta.Image = global::SwJugueriaAgustin.Properties.Resources.if_emblem_print_24705;
            this.btnPreCuenta.Location = new System.Drawing.Point(18, 187);
            this.btnPreCuenta.Name = "btnPreCuenta";
            this.btnPreCuenta.Size = new System.Drawing.Size(137, 70);
            this.btnPreCuenta.TabIndex = 27;
            this.btnPreCuenta.Text = "PreCuenta";
            this.btnPreCuenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreCuenta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreCuenta.UseVisualStyleBackColor = false;
            this.btnPreCuenta.Click += new System.EventHandler(this.btnPreCuenta_Click);
            // 
            // btnAnularPedido
            // 
            this.btnAnularPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnularPedido.BackColor = System.Drawing.Color.White;
            this.btnAnularPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnularPedido.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnularPedido.ForeColor = System.Drawing.Color.Tomato;
            this.btnAnularPedido.Image = global::SwJugueriaAgustin.Properties.Resources.CANCEL_FORMULARIO;
            this.btnAnularPedido.Location = new System.Drawing.Point(169, 188);
            this.btnAnularPedido.Name = "btnAnularPedido";
            this.btnAnularPedido.Size = new System.Drawing.Size(137, 70);
            this.btnAnularPedido.TabIndex = 26;
            this.btnAnularPedido.Text = "Anular Pedido";
            this.btnAnularPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnularPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnularPedido.UseVisualStyleBackColor = false;
            this.btnAnularPedido.Click += new System.EventHandler(this.btnAnularPedido_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Image = global::SwJugueriaAgustin.Properties.Resources.salida;
            this.btnCancelar.Location = new System.Drawing.Point(13, 273);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(288, 70);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Salir";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSolicitarPedido
            // 
            this.btnSolicitarPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSolicitarPedido.BackColor = System.Drawing.Color.White;
            this.btnSolicitarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSolicitarPedido.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolicitarPedido.ForeColor = System.Drawing.Color.Black;
            this.btnSolicitarPedido.Image = global::SwJugueriaAgustin.Properties.Resources.SAVE_FOR;
            this.btnSolicitarPedido.Location = new System.Drawing.Point(21, 103);
            this.btnSolicitarPedido.Name = "btnSolicitarPedido";
            this.btnSolicitarPedido.Size = new System.Drawing.Size(285, 67);
            this.btnSolicitarPedido.TabIndex = 23;
            this.btnSolicitarPedido.Text = "Realizar Pedido";
            this.btnSolicitarPedido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSolicitarPedido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSolicitarPedido.UseVisualStyleBackColor = false;
            this.btnSolicitarPedido.Click += new System.EventHandler(this.btnSolicitarPedido_Click);
            // 
            // btnCargarMozo
            // 
            this.btnCargarMozo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarMozo.BackColor = System.Drawing.Color.White;
            this.btnCargarMozo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargarMozo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarMozo.ForeColor = System.Drawing.Color.Black;
            this.btnCargarMozo.Image = global::SwJugueriaAgustin.Properties.Resources.if_2_330395;
            this.btnCargarMozo.Location = new System.Drawing.Point(21, 22);
            this.btnCargarMozo.Name = "btnCargarMozo";
            this.btnCargarMozo.Size = new System.Drawing.Size(285, 70);
            this.btnCargarMozo.TabIndex = 20;
            this.btnCargarMozo.Text = "Cargar Mozo";
            this.btnCargarMozo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCargarMozo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCargarMozo.UseVisualStyleBackColor = false;
            this.btnCargarMozo.Click += new System.EventHandler(this.btnCargarMozo_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Image = global::SwJugueriaAgustin.Properties.Resources.if_flat_style_circle_delete_trash_1312512__1_;
            this.button2.Location = new System.Drawing.Point(476, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 60);
            this.button2.TabIndex = 29;
            this.button2.Text = "Quitar Plato";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnMas
            // 
            this.btnMas.BackColor = System.Drawing.Color.White;
            this.btnMas.BackgroundImage = global::SwJugueriaAgustin.Properties.Resources.masverde;
            this.btnMas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMas.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnMas.ForeColor = System.Drawing.Color.White;
            this.btnMas.Location = new System.Drawing.Point(935, 297);
            this.btnMas.Name = "btnMas";
            this.btnMas.Size = new System.Drawing.Size(89, 54);
            this.btnMas.TabIndex = 31;
            this.btnMas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMas.UseVisualStyleBackColor = false;
            this.btnMas.Click += new System.EventHandler(this.btnMas_Click);
            // 
            // btnMenos
            // 
            this.btnMenos.BackColor = System.Drawing.Color.White;
            this.btnMenos.BackgroundImage = global::SwJugueriaAgustin.Properties.Resources.menos;
            this.btnMenos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMenos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMenos.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnMenos.ForeColor = System.Drawing.Color.White;
            this.btnMenos.Location = new System.Drawing.Point(840, 297);
            this.btnMenos.Name = "btnMenos";
            this.btnMenos.Size = new System.Drawing.Size(89, 54);
            this.btnMenos.TabIndex = 30;
            this.btnMenos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMenos.UseVisualStyleBackColor = false;
            this.btnMenos.Click += new System.EventHandler(this.btnMenos_Click);
            // 
            // btnDescripcion
            // 
            this.btnDescripcion.BackColor = System.Drawing.Color.White;
            this.btnDescripcion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDescripcion.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescripcion.ForeColor = System.Drawing.Color.Black;
            this.btnDescripcion.Image = global::SwJugueriaAgustin.Properties.Resources.EDIT;
            this.btnDescripcion.Location = new System.Drawing.Point(630, 295);
            this.btnDescripcion.Name = "btnDescripcion";
            this.btnDescripcion.Size = new System.Drawing.Size(128, 60);
            this.btnDescripcion.TabIndex = 32;
            this.btnDescripcion.Text = "Descripcion";
            this.btnDescripcion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDescripcion.UseVisualStyleBackColor = false;
            this.btnDescripcion.Click += new System.EventHandler(this.btnDescripcion_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnCargarMozo);
            this.groupBox1.Controls.Add(this.btnSolicitarPedido);
            this.groupBox1.Controls.Add(this.btnPreCuenta);
            this.groupBox1.Controls.Add(this.btnAnularPedido);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(1036, 376);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 361);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones:";
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
            this.cnPlato.Width = 250;
            // 
            // cnDescripcion
            // 
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
            this.cnCantidad.HeaderText = "Cant.";
            this.cnCantidad.Name = "cnCantidad";
            this.cnCantidad.ReadOnly = true;
            this.cnCantidad.Width = 60;
            // 
            // cnPrecio
            // 
            this.cnPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnPrecio.HeaderText = "Precio";
            this.cnPrecio.Name = "cnPrecio";
            this.cnPrecio.ReadOnly = true;
            this.cnPrecio.Width = 60;
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
            this.cnCategoria.Visible = false;
            // 
            // cnCosto
            // 
            this.cnCosto.HeaderText = "Costo";
            this.cnCosto.Name = "cnCosto";
            this.cnCosto.Visible = false;
            // 
            // FrmPedidoTactil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1370, 745);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDescripcion);
            this.Controls.Add(this.btnMas);
            this.Controls.Add(this.btnMenos);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvPedido);
            this.Controls.Add(this.flpProducto);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.flpSubCategoria);
            this.Controls.Add(this.flpCategoria);
            this.Name = "FrmPedidoTactil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedido";
            this.Load += new System.EventHandler(this.FrmPedidoTactil_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCategoria;
        private System.Windows.Forms.FlowLayoutPanel flpSubCategoria;
        private System.Windows.Forms.Button btnCargarMozo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMozo;
        public System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpProducto;
        public System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnSolicitarPedido;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.Button btnPreCuenta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAnularPedido;
        private System.Drawing.Printing.PrintDocument pdPreCuenta;
        private System.Drawing.Printing.PrintDocument pdBar;
        private System.Drawing.Printing.PrintDocument pdCocina;
        private System.Windows.Forms.PrintPreviewDialog ppdView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnMas;
        private System.Windows.Forms.Button btnMenos;
        private System.Windows.Forms.Button btnDescripcion;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lblNumeroC;
        public System.Windows.Forms.Label lblSerieC;
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
    }
}