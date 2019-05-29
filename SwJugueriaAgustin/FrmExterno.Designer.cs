namespace SwJugueriaAgustin
{
    partial class FrmExterno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmExterno));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.dgvPedido = new System.Windows.Forms.DataGridView();
            this.cnImprimido = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cnCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnPlato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnIDPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ppDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 44);
            this.button2.TabIndex = 2;
            this.button2.Text = "Vista Previa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // dgvPedido
            // 
            this.dgvPedido.AllowUserToOrderColumns = true;
            this.dgvPedido.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cnImprimido,
            this.cnCodigo,
            this.cnPlato,
            this.cnDescripcion,
            this.cnCantidad,
            this.cnPrecio,
            this.cnImporte,
            this.cnIDPedido,
            this.cnCategoria,
            this.cnCosto});
            this.dgvPedido.Location = new System.Drawing.Point(23, 78);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedido.Size = new System.Drawing.Size(113, 55);
            this.dgvPedido.TabIndex = 26;
            // 
            // cnImprimido
            // 
            this.cnImprimido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnImprimido.HeaderText = "Impri.";
            this.cnImprimido.Name = "cnImprimido";
            this.cnImprimido.Width = 50;
            // 
            // cnCodigo
            // 
            this.cnCodigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnCodigo.HeaderText = "Codigo";
            this.cnCodigo.Name = "cnCodigo";
            this.cnCodigo.ReadOnly = true;
            this.cnCodigo.Visible = false;
            this.cnCodigo.Width = 50;
            // 
            // cnPlato
            // 
            this.cnPlato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnPlato.HeaderText = "Plato";
            this.cnPlato.Name = "cnPlato";
            this.cnPlato.Width = 300;
            // 
            // cnDescripcion
            // 
            this.cnDescripcion.HeaderText = "Descripcion";
            this.cnDescripcion.Name = "cnDescripcion";
            // 
            // cnCantidad
            // 
            this.cnCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnCantidad.HeaderText = "Cantidad";
            this.cnCantidad.Name = "cnCantidad";
            this.cnCantidad.Width = 50;
            // 
            // cnPrecio
            // 
            this.cnPrecio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnPrecio.HeaderText = "Precio";
            this.cnPrecio.Name = "cnPrecio";
            this.cnPrecio.Width = 60;
            // 
            // cnImporte
            // 
            this.cnImporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnImporte.HeaderText = "Importe";
            this.cnImporte.Name = "cnImporte";
            this.cnImporte.Width = 60;
            // 
            // cnIDPedido
            // 
            this.cnIDPedido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cnIDPedido.HeaderText = "CodPedido";
            this.cnIDPedido.Name = "cnIDPedido";
            this.cnIDPedido.Visible = false;
            this.cnIDPedido.Width = 50;
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SwJugueriaAgustin.Properties.Resources.LOGO_TABERNA_SISTEMA;
            this.pictureBox1.Location = new System.Drawing.Point(12, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
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
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(236, 78);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.Size = new System.Drawing.Size(552, 310);
            this.dgvDatos.TabIndex = 28;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(649, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 44);
            this.button3.TabIndex = 29;
            this.button3.Text = "migrar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmExterno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvPedido);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FrmExterno";
            this.Text = "FrmExterno";
            this.Load += new System.EventHandler(this.FrmExterno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        public System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PrintPreviewDialog ppDialog;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cnImprimido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnPlato;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnIDPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnCosto;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button button3;
    }
}