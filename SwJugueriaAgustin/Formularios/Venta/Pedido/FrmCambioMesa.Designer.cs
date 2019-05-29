namespace SwJugueriaAgustin.Formularios.Operaciones
{
    partial class FrmCambioMesa
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvPedidoMA = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMesaA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboZonaA = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPedidoMN = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMesaN = new System.Windows.Forms.ComboBox();
            this.cboZonaN = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTrasladarMesa = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoMA)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoMN)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPedidoMA);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboMesaA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboZonaA);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 361);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mesa Actual";
            // 
            // dgvPedidoMA
            // 
            this.dgvPedidoMA.AllowUserToAddRows = false;
            this.dgvPedidoMA.AllowUserToDeleteRows = false;
            this.dgvPedidoMA.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidoMA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoMA.Location = new System.Drawing.Point(20, 161);
            this.dgvPedidoMA.Name = "dgvPedidoMA";
            this.dgvPedidoMA.ReadOnly = true;
            this.dgvPedidoMA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidoMA.Size = new System.Drawing.Size(363, 185);
            this.dgvPedidoMA.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mesa:";
            // 
            // cboMesaA
            // 
            this.cboMesaA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesaA.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMesaA.FormattingEnabled = true;
            this.cboMesaA.Location = new System.Drawing.Point(74, 86);
            this.cboMesaA.Name = "cboMesaA";
            this.cboMesaA.Size = new System.Drawing.Size(309, 45);
            this.cboMesaA.TabIndex = 6;
            this.cboMesaA.SelectedValueChanged += new System.EventHandler(this.cboMesaA_SelectedValueChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zona:";
            // 
            // cboZonaA
            // 
            this.cboZonaA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZonaA.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboZonaA.FormattingEnabled = true;
            this.cboZonaA.Location = new System.Drawing.Point(74, 30);
            this.cboZonaA.Name = "cboZonaA";
            this.cboZonaA.Size = new System.Drawing.Size(309, 45);
            this.cboZonaA.TabIndex = 4;
            this.cboZonaA.SelectionChangeCommitted += new System.EventHandler(this.cboZonaA_SelectionChangeCommitted);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPedidoMN);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboMesaN);
            this.groupBox2.Controls.Add(this.cboZonaN);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(639, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(398, 361);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Futura Mesa";
            // 
            // dgvPedidoMN
            // 
            this.dgvPedidoMN.AllowUserToAddRows = false;
            this.dgvPedidoMN.AllowUserToDeleteRows = false;
            this.dgvPedidoMN.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidoMN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoMN.Location = new System.Drawing.Point(22, 161);
            this.dgvPedidoMN.Name = "dgvPedidoMN";
            this.dgvPedidoMN.ReadOnly = true;
            this.dgvPedidoMN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedidoMN.Size = new System.Drawing.Size(363, 185);
            this.dgvPedidoMN.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Mesa:";
            // 
            // cboMesaN
            // 
            this.cboMesaN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesaN.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold);
            this.cboMesaN.FormattingEnabled = true;
            this.cboMesaN.Location = new System.Drawing.Point(76, 82);
            this.cboMesaN.Name = "cboMesaN";
            this.cboMesaN.Size = new System.Drawing.Size(309, 45);
            this.cboMesaN.TabIndex = 30;
            this.cboMesaN.SelectedValueChanged += new System.EventHandler(this.cboMesaN_SelectedValueChanged);
            // 
            // cboZonaN
            // 
            this.cboZonaN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZonaN.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold);
            this.cboZonaN.FormattingEnabled = true;
            this.cboZonaN.Location = new System.Drawing.Point(76, 31);
            this.cboZonaN.Name = "cboZonaN";
            this.cboZonaN.Size = new System.Drawing.Size(309, 45);
            this.cboZonaN.TabIndex = 28;
            this.cboZonaN.SelectionChangeCommitted += new System.EventHandler(this.cboZonaN_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Zona:";
            // 
            // btnTrasladarMesa
            // 
            this.btnTrasladarMesa.BackColor = System.Drawing.Color.Teal;
            this.btnTrasladarMesa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTrasladarMesa.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrasladarMesa.ForeColor = System.Drawing.Color.White;
            this.btnTrasladarMesa.Image = global::SwJugueriaAgustin.Properties.Resources.rigth;
            this.btnTrasladarMesa.Location = new System.Drawing.Point(453, 64);
            this.btnTrasladarMesa.Name = "btnTrasladarMesa";
            this.btnTrasladarMesa.Size = new System.Drawing.Size(152, 120);
            this.btnTrasladarMesa.TabIndex = 2;
            this.btnTrasladarMesa.Text = "Trasladar Mesa";
            this.btnTrasladarMesa.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTrasladarMesa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTrasladarMesa.UseVisualStyleBackColor = false;
            this.btnTrasladarMesa.Click += new System.EventHandler(this.btnTrasladarMesa_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::SwJugueriaAgustin.Properties.Resources.salida;
            this.button1.Location = new System.Drawing.Point(453, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 96);
            this.button1.TabIndex = 3;
            this.button1.Text = "Salir";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmCambioMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1074, 415);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTrasladarMesa);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmCambioMesa";
            this.Text = ".::Cambio Mesa::.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCambioMesa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoMA)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoMN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboMesaA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboZonaA;
        public System.Windows.Forms.DataGridView dgvPedidoMA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMesaN;
        private System.Windows.Forms.ComboBox cboZonaN;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView dgvPedidoMN;
        private System.Windows.Forms.Button btnTrasladarMesa;
        private System.Windows.Forms.Button button1;
    }
}