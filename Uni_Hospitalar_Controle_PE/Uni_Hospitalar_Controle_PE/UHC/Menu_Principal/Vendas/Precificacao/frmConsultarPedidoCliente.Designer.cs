namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Precificacao
{
    partial class frmConsultarPedidoCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.btnContratos = new System.Windows.Forms.Button();
            this.btnPreencherCliente = new System.Windows.Forms.PictureBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblPedidoCliente = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtPedidoCliente = new System.Windows.Forms.TextBox();
            this.lblConsultaDePrecos = new System.Windows.Forms.Label();
            this.dgvProdutosNF = new System.Windows.Forms.DataGridView();
            this.lblProdutosNF = new System.Windows.Forms.Label();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.lblDados = new System.Windows.Forms.Label();
            this.chkHelp = new System.Windows.Forms.CheckBox();
            this.lblAjudaPedidoCliente = new System.Windows.Forms.Label();
            this.lblAjudaCodCliente = new System.Windows.Forms.Label();
            this.lblAjudaFiltrarClientes = new System.Windows.Forms.Label();
            this.lblAjudaContratos = new System.Windows.Forms.Label();
            this.lblAjudaConsulta = new System.Windows.Forms.Label();
            this.lblAjudaNF = new System.Windows.Forms.Label();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosNF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.lblAjudaCodCliente);
            this.gpbFiltros.Controls.Add(this.lblAjudaPedidoCliente);
            this.gpbFiltros.Controls.Add(this.btnContratos);
            this.gpbFiltros.Controls.Add(this.btnPreencherCliente);
            this.gpbFiltros.Controls.Add(this.lblCliente);
            this.gpbFiltros.Controls.Add(this.txtCodCliente);
            this.gpbFiltros.Controls.Add(this.txtCliente);
            this.gpbFiltros.Controls.Add(this.lblPedidoCliente);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.txtPedidoCliente);
            this.gpbFiltros.Location = new System.Drawing.Point(17, 37);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(422, 142);
            this.gpbFiltros.TabIndex = 16;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // btnContratos
            // 
            this.btnContratos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnContratos.BackColor = System.Drawing.Color.IndianRed;
            this.btnContratos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContratos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnContratos.ForeColor = System.Drawing.Color.White;
            this.btnContratos.Location = new System.Drawing.Point(243, 104);
            this.btnContratos.Name = "btnContratos";
            this.btnContratos.Size = new System.Drawing.Size(80, 32);
            this.btnContratos.TabIndex = 54;
            this.btnContratos.Text = "Contratos";
            this.btnContratos.UseVisualStyleBackColor = false;
            this.btnContratos.Click += new System.EventHandler(this.btnContratos_Click);
            // 
            // btnPreencherCliente
            // 
            this.btnPreencherCliente.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherCliente.Location = new System.Drawing.Point(383, 72);
            this.btnPreencherCliente.Name = "btnPreencherCliente";
            this.btnPreencherCliente.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherCliente.TabIndex = 53;
            this.btnPreencherCliente.TabStop = false;
            this.btnPreencherCliente.Click += new System.EventHandler(this.btnPreencherCliente_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(5, 56);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 50;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(6, 72);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(44, 20);
            this.txtCodCliente.TabIndex = 51;
            this.txtCodCliente.TextChanged += new System.EventHandler(this.txtCodCliente_TextChanged);
            this.txtCodCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPedidoCliente_KeyDown);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(53, 72);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(324, 20);
            this.txtCliente.TabIndex = 52;
            // 
            // lblPedidoCliente
            // 
            this.lblPedidoCliente.AutoSize = true;
            this.lblPedidoCliente.Location = new System.Drawing.Point(5, 14);
            this.lblPedidoCliente.Name = "lblPedidoCliente";
            this.lblPedidoCliente.Size = new System.Drawing.Size(75, 13);
            this.lblPedidoCliente.TabIndex = 49;
            this.lblPedidoCliente.Text = "Pedido Cliente";
            this.lblPedidoCliente.Click += new System.EventHandler(this.lblPedidoCliente_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(329, 104);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 32);
            this.btnPesquisar.TabIndex = 48;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtPedidoCliente
            // 
            this.txtPedidoCliente.Location = new System.Drawing.Point(6, 30);
            this.txtPedidoCliente.Name = "txtPedidoCliente";
            this.txtPedidoCliente.Size = new System.Drawing.Size(121, 20);
            this.txtPedidoCliente.TabIndex = 7;
            this.txtPedidoCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPedidoCliente_KeyDown);
            // 
            // lblConsultaDePrecos
            // 
            this.lblConsultaDePrecos.AutoSize = true;
            this.lblConsultaDePrecos.BackColor = System.Drawing.Color.Gainsboro;
            this.lblConsultaDePrecos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultaDePrecos.Location = new System.Drawing.Point(12, 9);
            this.lblConsultaDePrecos.Name = "lblConsultaDePrecos";
            this.lblConsultaDePrecos.Size = new System.Drawing.Size(216, 25);
            this.lblConsultaDePrecos.TabIndex = 15;
            this.lblConsultaDePrecos.Text = "Consulta de preços";
            // 
            // dgvProdutosNF
            // 
            this.dgvProdutosNF.AllowUserToAddRows = false;
            this.dgvProdutosNF.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvProdutosNF.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProdutosNF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProdutosNF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutosNF.Location = new System.Drawing.Point(621, 37);
            this.dgvProdutosNF.Name = "dgvProdutosNF";
            this.dgvProdutosNF.ReadOnly = true;
            this.dgvProdutosNF.RowHeadersVisible = false;
            this.dgvProdutosNF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutosNF.Size = new System.Drawing.Size(450, 547);
            this.dgvProdutosNF.TabIndex = 17;
            // 
            // lblProdutosNF
            // 
            this.lblProdutosNF.AutoSize = true;
            this.lblProdutosNF.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdutosNF.Location = new System.Drawing.Point(618, 10);
            this.lblProdutosNF.Name = "lblProdutosNF";
            this.lblProdutosNF.Size = new System.Drawing.Size(156, 24);
            this.lblProdutosNF.TabIndex = 50;
            this.lblProdutosNF.Text = "Produtos da NF";
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(12, 233);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(603, 351);
            this.dgvDados.TabIndex = 51;
            this.dgvDados.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_RowEnter);
            // 
            // lblDados
            // 
            this.lblDados.AutoSize = true;
            this.lblDados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDados.Location = new System.Drawing.Point(8, 205);
            this.lblDados.Name = "lblDados";
            this.lblDados.Size = new System.Drawing.Size(185, 24);
            this.lblDados.TabIndex = 52;
            this.lblDados.Text = "Dados da Consulta";
            // 
            // chkHelp
            // 
            this.chkHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHelp.AutoSize = true;
            this.chkHelp.Location = new System.Drawing.Point(1001, 9);
            this.chkHelp.Name = "chkHelp";
            this.chkHelp.Size = new System.Drawing.Size(70, 17);
            this.chkHelp.TabIndex = 53;
            this.chkHelp.Text = "Ajude-me";
            this.chkHelp.UseVisualStyleBackColor = true;
            this.chkHelp.CheckedChanged += new System.EventHandler(this.chkHelp_CheckedChanged);
            // 
            // lblAjudaPedidoCliente
            // 
            this.lblAjudaPedidoCliente.AutoSize = true;
            this.lblAjudaPedidoCliente.ForeColor = System.Drawing.Color.Red;
            this.lblAjudaPedidoCliente.Location = new System.Drawing.Point(133, 30);
            this.lblAjudaPedidoCliente.Name = "lblAjudaPedidoCliente";
            this.lblAjudaPedidoCliente.Size = new System.Drawing.Size(237, 13);
            this.lblAjudaPedidoCliente.TabIndex = 54;
            this.lblAjudaPedidoCliente.Text = "Consultar pelo pedido que teve origem do cliente";
            // 
            // lblAjudaCodCliente
            // 
            this.lblAjudaCodCliente.AutoSize = true;
            this.lblAjudaCodCliente.ForeColor = System.Drawing.Color.Red;
            this.lblAjudaCodCliente.Location = new System.Drawing.Point(5, 94);
            this.lblAjudaCodCliente.Name = "lblAjudaCodCliente";
            this.lblAjudaCodCliente.Size = new System.Drawing.Size(147, 13);
            this.lblAjudaCodCliente.TabIndex = 55;
            this.lblAjudaCodCliente.Text = "Filtro para o código do Cliente";
            // 
            // lblAjudaFiltrarClientes
            // 
            this.lblAjudaFiltrarClientes.AutoSize = true;
            this.lblAjudaFiltrarClientes.ForeColor = System.Drawing.Color.Red;
            this.lblAjudaFiltrarClientes.Location = new System.Drawing.Point(400, 93);
            this.lblAjudaFiltrarClientes.Name = "lblAjudaFiltrarClientes";
            this.lblAjudaFiltrarClientes.Size = new System.Drawing.Size(254, 13);
            this.lblAjudaFiltrarClientes.TabIndex = 56;
            this.lblAjudaFiltrarClientes.Text = "Consulta cliente pela razão social, descrição ou cnpj";
            // 
            // lblAjudaContratos
            // 
            this.lblAjudaContratos.AutoSize = true;
            this.lblAjudaContratos.ForeColor = System.Drawing.Color.Red;
            this.lblAjudaContratos.Location = new System.Drawing.Point(257, 176);
            this.lblAjudaContratos.Name = "lblAjudaContratos";
            this.lblAjudaContratos.Size = new System.Drawing.Size(159, 13);
            this.lblAjudaContratos.TabIndex = 57;
            this.lblAjudaContratos.Text = "Consulta os contratos existentes";
            // 
            // lblAjudaConsulta
            // 
            this.lblAjudaConsulta.AutoSize = true;
            this.lblAjudaConsulta.ForeColor = System.Drawing.Color.Red;
            this.lblAjudaConsulta.Location = new System.Drawing.Point(199, 216);
            this.lblAjudaConsulta.Name = "lblAjudaConsulta";
            this.lblAjudaConsulta.Size = new System.Drawing.Size(175, 13);
            this.lblAjudaConsulta.TabIndex = 58;
            this.lblAjudaConsulta.Text = "Informações referentes aos pedidos";
            // 
            // lblAjudaNF
            // 
            this.lblAjudaNF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAjudaNF.AutoSize = true;
            this.lblAjudaNF.ForeColor = System.Drawing.Color.Red;
            this.lblAjudaNF.Location = new System.Drawing.Point(778, 21);
            this.lblAjudaNF.Name = "lblAjudaNF";
            this.lblAjudaNF.Size = new System.Drawing.Size(65, 13);
            this.lblAjudaNF.TabIndex = 59;
            this.lblAjudaNF.Text = "Itens por NF";
            // 
            // frmConsultarPedidoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1083, 596);
            this.Controls.Add(this.lblAjudaNF);
            this.Controls.Add(this.lblAjudaConsulta);
            this.Controls.Add(this.lblAjudaContratos);
            this.Controls.Add(this.lblAjudaFiltrarClientes);
            this.Controls.Add(this.chkHelp);
            this.Controls.Add(this.lblDados);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.lblProdutosNF);
            this.Controls.Add(this.dgvProdutosNF);
            this.Controls.Add(this.gpbFiltros);
            this.Controls.Add(this.lblConsultaDePrecos);
            this.Name = "frmConsultarPedidoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Pedido do Cliente";
            this.Load += new System.EventHandler(this.frmConsultarPedidoCliente_Load);
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosNF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Label lblPedidoCliente;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtPedidoCliente;
        private System.Windows.Forms.Label lblConsultaDePrecos;
        private System.Windows.Forms.PictureBox btnPreencherCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnContratos;
        private System.Windows.Forms.DataGridView dgvProdutosNF;
        private System.Windows.Forms.Label lblProdutosNF;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Label lblDados;
        private System.Windows.Forms.CheckBox chkHelp;
        private System.Windows.Forms.Label lblAjudaCodCliente;
        private System.Windows.Forms.Label lblAjudaPedidoCliente;
        private System.Windows.Forms.Label lblAjudaFiltrarClientes;
        private System.Windows.Forms.Label lblAjudaContratos;
        private System.Windows.Forms.Label lblAjudaConsulta;
        private System.Windows.Forms.Label lblAjudaNF;
    }
}