namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Pedido_OL
{
    partial class frmPedidoOLAche
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblDetalhesDoPedido = new System.Windows.Forms.Label();
            this.lblProdutosPedido = new System.Windows.Forms.Label();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblPedidoOL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPedidoOL = new System.Windows.Forms.TextBox();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.chkProblema = new System.Windows.Forms.CheckBox();
            this.chkNF = new System.Windows.Forms.CheckBox();
            this.btnPreencherCliente = new System.Windows.Forms.PictureBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblPedidoOLAche = new System.Windows.Forms.Label();
            this.dgvPedido = new System.Windows.Forms.DataGridView();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.DarkGray;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(1193, 620);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(73, 34);
            this.btnFechar.TabIndex = 20;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // lblDetalhesDoPedido
            // 
            this.lblDetalhesDoPedido.AutoSize = true;
            this.lblDetalhesDoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalhesDoPedido.Location = new System.Drawing.Point(6, 160);
            this.lblDetalhesDoPedido.Name = "lblDetalhesDoPedido";
            this.lblDetalhesDoPedido.Size = new System.Drawing.Size(218, 25);
            this.lblDetalhesDoPedido.TabIndex = 22;
            this.lblDetalhesDoPedido.Text = "Detalhes do Pedido";
            // 
            // lblProdutosPedido
            // 
            this.lblProdutosPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProdutosPedido.AutoSize = true;
            this.lblProdutosPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdutosPedido.Location = new System.Drawing.Point(683, 160);
            this.lblProdutosPedido.Name = "lblProdutosPedido";
            this.lblProdutosPedido.Size = new System.Drawing.Size(219, 25);
            this.lblProdutosPedido.TabIndex = 23;
            this.lblProdutosPedido.Text = "Pedidos do Produto";
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.lblPedidoOL);
            this.gpbFiltros.Controls.Add(this.label1);
            this.gpbFiltros.Controls.Add(this.txtPedidoOL);
            this.gpbFiltros.Controls.Add(this.txtNF);
            this.gpbFiltros.Controls.Add(this.chkProblema);
            this.gpbFiltros.Controls.Add(this.chkNF);
            this.gpbFiltros.Controls.Add(this.btnPreencherCliente);
            this.gpbFiltros.Controls.Add(this.lblCliente);
            this.gpbFiltros.Controls.Add(this.txtCodCliente);
            this.gpbFiltros.Controls.Add(this.txtCliente);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 45);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(516, 112);
            this.gpbFiltros.TabIndex = 24;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPesquisar.BackColor = System.Drawing.Color.DimGray;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(430, 68);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 34);
            this.btnPesquisar.TabIndex = 26;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // lblPedidoOL
            // 
            this.lblPedidoOL.AutoSize = true;
            this.lblPedidoOL.Location = new System.Drawing.Point(114, 56);
            this.lblPedidoOL.Name = "lblPedidoOL";
            this.lblPedidoOL.Size = new System.Drawing.Size(57, 13);
            this.lblPedidoOL.TabIndex = 25;
            this.lblPedidoOL.Text = "Pedido OL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "NF";
            // 
            // txtPedidoOL
            // 
            this.txtPedidoOL.Location = new System.Drawing.Point(117, 73);
            this.txtPedidoOL.Name = "txtPedidoOL";
            this.txtPedidoOL.Size = new System.Drawing.Size(100, 20);
            this.txtPedidoOL.TabIndex = 23;
            this.txtPedidoOL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // txtNF
            // 
            this.txtNF.Location = new System.Drawing.Point(11, 73);
            this.txtNF.Name = "txtNF";
            this.txtNF.Size = new System.Drawing.Size(100, 20);
            this.txtNF.TabIndex = 23;
            this.txtNF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // chkProblema
            // 
            this.chkProblema.AutoSize = true;
            this.chkProblema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkProblema.Location = new System.Drawing.Point(225, 85);
            this.chkProblema.Name = "chkProblema";
            this.chkProblema.Size = new System.Drawing.Size(70, 17);
            this.chkProblema.TabIndex = 22;
            this.chkProblema.Text = "Problema";
            this.chkProblema.UseVisualStyleBackColor = false;
            // 
            // chkNF
            // 
            this.chkNF.AutoSize = true;
            this.chkNF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkNF.Location = new System.Drawing.Point(225, 64);
            this.chkNF.Name = "chkNF";
            this.chkNF.Size = new System.Drawing.Size(77, 17);
            this.chkNF.TabIndex = 21;
            this.chkNF.Text = "NF Emitida";
            this.chkNF.UseVisualStyleBackColor = false;
            // 
            // btnPreencherCliente
            // 
            this.btnPreencherCliente.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherCliente.Location = new System.Drawing.Point(473, 31);
            this.btnPreencherCliente.Name = "btnPreencherCliente";
            this.btnPreencherCliente.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherCliente.TabIndex = 20;
            this.btnPreencherCliente.TabStop = false;
            this.btnPreencherCliente.Click += new System.EventHandler(this.btnPreencherCliente_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(8, 16);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 17;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(11, 33);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(44, 20);
            this.txtCodCliente.TabIndex = 18;
            this.txtCodCliente.TextChanged += new System.EventHandler(this.txtCodCliente_TextChanged);
            this.txtCodCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(61, 33);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(406, 20);
            this.txtCliente.TabIndex = 19;
            // 
            // lblPedidoOLAche
            // 
            this.lblPedidoOLAche.AutoSize = true;
            this.lblPedidoOLAche.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedidoOLAche.Location = new System.Drawing.Point(7, 9);
            this.lblPedidoOLAche.Name = "lblPedidoOLAche";
            this.lblPedidoOLAche.Size = new System.Drawing.Size(215, 25);
            this.lblPedidoOLAche.TabIndex = 25;
            this.lblPedidoOLAche.Text = "Pedido OL da Aché";
            // 
            // dgvPedido
            // 
            this.dgvPedido.AllowUserToAddRows = false;
            this.dgvPedido.AllowUserToDeleteRows = false;
            this.dgvPedido.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPedido.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedido.Location = new System.Drawing.Point(11, 188);
            this.dgvPedido.Name = "dgvPedido";
            this.dgvPedido.ReadOnly = true;
            this.dgvPedido.RowHeadersVisible = false;
            this.dgvPedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPedido.Size = new System.Drawing.Size(671, 405);
            this.dgvPedido.TabIndex = 26;
            this.dgvPedido.SelectionChanged += new System.EventHandler(this.dgvPedido_SelectionChanged);
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvProdutos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(688, 188);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.RowHeadersVisible = false;
            this.dgvProdutos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(578, 405);
            this.dgvProdutos.TabIndex = 27;
            // 
            // frmPedidoOLAche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 657);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.dgvPedido);
            this.Controls.Add(this.lblPedidoOLAche);
            this.Controls.Add(this.gpbFiltros);
            this.Controls.Add(this.lblProdutosPedido);
            this.Controls.Add(this.lblDetalhesDoPedido);
            this.Controls.Add(this.btnFechar);
            this.Name = "frmPedidoOLAche";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pedido OL Aché";
            this.Load += new System.EventHandler(this.frmPedidoOLAche_Load);
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblDetalhesDoPedido;
        private System.Windows.Forms.Label lblProdutosPedido;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Label lblPedidoOLAche;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblPedidoOL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPedidoOL;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.CheckBox chkProblema;
        private System.Windows.Forms.CheckBox chkNF;
        private System.Windows.Forms.PictureBox btnPreencherCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.DataGridView dgvPedido;
        private System.Windows.Forms.DataGridView dgvProdutos;
    }
}