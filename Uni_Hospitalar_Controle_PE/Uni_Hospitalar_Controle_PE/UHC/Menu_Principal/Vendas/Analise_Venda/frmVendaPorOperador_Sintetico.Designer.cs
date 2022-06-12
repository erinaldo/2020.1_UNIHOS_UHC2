
namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Analise_Venda
{
    partial class frmVendaPorOperador_Sintetico
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblConsultaDePrecos = new System.Windows.Forms.Label();
            this.btnPreencherCliente = new System.Windows.Forms.PictureBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.pcbPreencherProduto = new System.Windows.Forms.PictureBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtCodProduto = new System.Windows.Forms.TextBox();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.lblOperador = new System.Windows.Forms.Label();
            this.txtCodOperador = new System.Windows.Forms.TextBox();
            this.txtOperador = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.dtpDatInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpDatFinal = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPreencherProduto)).BeginInit();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblConsultaDePrecos
            // 
            this.lblConsultaDePrecos.AutoSize = true;
            this.lblConsultaDePrecos.BackColor = System.Drawing.Color.Gainsboro;
            this.lblConsultaDePrecos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultaDePrecos.Location = new System.Drawing.Point(7, 9);
            this.lblConsultaDePrecos.Name = "lblConsultaDePrecos";
            this.lblConsultaDePrecos.Size = new System.Drawing.Size(202, 25);
            this.lblConsultaDePrecos.TabIndex = 16;
            this.lblConsultaDePrecos.Text = "Vendas Sintéticas";
            // 
            // btnPreencherCliente
            // 
            this.btnPreencherCliente.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherCliente.Location = new System.Drawing.Point(383, 33);
            this.btnPreencherCliente.Name = "btnPreencherCliente";
            this.btnPreencherCliente.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherCliente.TabIndex = 57;
            this.btnPreencherCliente.TabStop = false;
            this.btnPreencherCliente.Click += new System.EventHandler(this.btnPreencherCliente_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(5, 17);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 54;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(6, 33);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(44, 20);
            this.txtCodCliente.TabIndex = 55;
            this.txtCodCliente.TextChanged += new System.EventHandler(this.txtCodCliente_TextChanged);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(53, 33);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(324, 20);
            this.txtCliente.TabIndex = 56;
            // 
            // pcbPreencherProduto
            // 
            this.pcbPreencherProduto.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.pcbPreencherProduto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbPreencherProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbPreencherProduto.Location = new System.Drawing.Point(383, 72);
            this.pcbPreencherProduto.Name = "pcbPreencherProduto";
            this.pcbPreencherProduto.Size = new System.Drawing.Size(26, 22);
            this.pcbPreencherProduto.TabIndex = 66;
            this.pcbPreencherProduto.TabStop = false;
            this.pcbPreencherProduto.Click += new System.EventHandler(this.pcbPreencherProduto_Click);
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(5, 56);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(44, 13);
            this.lblProduto.TabIndex = 63;
            this.lblProduto.Text = "Produto";
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Location = new System.Drawing.Point(6, 72);
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.Size = new System.Drawing.Size(44, 20);
            this.txtCodProduto.TabIndex = 64;
            this.txtCodProduto.TextChanged += new System.EventHandler(this.txtCodProduto_TextChanged);
            // 
            // txtProduto
            // 
            this.txtProduto.Location = new System.Drawing.Point(53, 72);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.ReadOnly = true;
            this.txtProduto.Size = new System.Drawing.Size(324, 20);
            this.txtProduto.TabIndex = 65;
            // 
            // lblOperador
            // 
            this.lblOperador.AutoSize = true;
            this.lblOperador.Location = new System.Drawing.Point(3, 95);
            this.lblOperador.Name = "lblOperador";
            this.lblOperador.Size = new System.Drawing.Size(51, 13);
            this.lblOperador.TabIndex = 67;
            this.lblOperador.Text = "Operador";
            // 
            // txtCodOperador
            // 
            this.txtCodOperador.Location = new System.Drawing.Point(5, 111);
            this.txtCodOperador.Name = "txtCodOperador";
            this.txtCodOperador.Size = new System.Drawing.Size(44, 20);
            this.txtCodOperador.TabIndex = 68;
            this.txtCodOperador.TextChanged += new System.EventHandler(this.txtCodOperador_TextChanged);
            // 
            // txtOperador
            // 
            this.txtOperador.Location = new System.Drawing.Point(52, 111);
            this.txtOperador.Name = "txtOperador";
            this.txtOperador.ReadOnly = true;
            this.txtOperador.Size = new System.Drawing.Size(145, 20);
            this.txtOperador.TabIndex = 69;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(329, 137);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 32);
            this.btnPesquisar.TabIndex = 71;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // dtpDatInicial
            // 
            this.dtpDatInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatInicial.Location = new System.Drawing.Point(209, 111);
            this.dtpDatInicial.Name = "dtpDatInicial";
            this.dtpDatInicial.Size = new System.Drawing.Size(97, 20);
            this.dtpDatInicial.TabIndex = 72;
            // 
            // dtpDatFinal
            // 
            this.dtpDatFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatFinal.Location = new System.Drawing.Point(312, 111);
            this.dtpDatFinal.Name = "dtpDatFinal";
            this.dtpDatFinal.Size = new System.Drawing.Size(97, 20);
            this.dtpDatFinal.TabIndex = 73;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Location = new System.Drawing.Point(207, 96);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(45, 13);
            this.lblPeriodo.TabIndex = 74;
            this.lblPeriodo.Text = "Período";
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.lblPeriodo);
            this.gpbFiltros.Controls.Add(this.txtCliente);
            this.gpbFiltros.Controls.Add(this.dtpDatFinal);
            this.gpbFiltros.Controls.Add(this.txtCodCliente);
            this.gpbFiltros.Controls.Add(this.dtpDatInicial);
            this.gpbFiltros.Controls.Add(this.lblCliente);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.btnPreencherCliente);
            this.gpbFiltros.Controls.Add(this.lblOperador);
            this.gpbFiltros.Controls.Add(this.txtCodOperador);
            this.gpbFiltros.Controls.Add(this.txtOperador);
            this.gpbFiltros.Controls.Add(this.pcbPreencherProduto);
            this.gpbFiltros.Controls.Add(this.txtProduto);
            this.gpbFiltros.Controls.Add(this.lblProduto);
            this.gpbFiltros.Controls.Add(this.txtCodProduto);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 37);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(424, 185);
            this.gpbFiltros.TabIndex = 75;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(12, 228);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(424, 302);
            this.dgvDados.TabIndex = 76;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnFechar.Location = new System.Drawing.Point(333, 536);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(103, 38);
            this.btnFechar.TabIndex = 77;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmVendaPorOperador_Sintetico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 577);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.lblConsultaDePrecos);
            this.Controls.Add(this.gpbFiltros);
            this.Name = "frmVendaPorOperador_Sintetico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendas por Operador - Sintético";
            this.Load += new System.EventHandler(this.frmVendaPorOperador_Sintetico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbPreencherProduto)).EndInit();
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConsultaDePrecos;
        private System.Windows.Forms.PictureBox btnPreencherCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.PictureBox pcbPreencherProduto;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.TextBox txtCodProduto;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Label lblOperador;
        private System.Windows.Forms.TextBox txtCodOperador;
        private System.Windows.Forms.TextBox txtOperador;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DateTimePicker dtpDatInicial;
        private System.Windows.Forms.DateTimePicker dtpDatFinal;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnFechar;
    }
}