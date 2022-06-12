namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Precificacao
{
    partial class frmConsultarPrecos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtLocalizacao = new System.Windows.Forms.TextBox();
            this.lblLocalizacao = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.btnPreencherFabricante = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.gpbEstoque = new System.Windows.Forms.GroupBox();
            this.chkNão = new System.Windows.Forms.CheckBox();
            this.chkSim = new System.Windows.Forms.CheckBox();
            this.gpbTipo = new System.Windows.Forms.GroupBox();
            this.chkHospitalar = new System.Windows.Forms.CheckBox();
            this.chkOncologico = new System.Windows.Forms.CheckBox();
            this.txtGenerico = new System.Windows.Forms.TextBox();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.txtCodProduto = new System.Windows.Forms.TextBox();
            this.lblGenerico = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.txtCodFabricante = new System.Windows.Forms.TextBox();
            this.lblConsultaDePrecos = new System.Windows.Forms.Label();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherFabricante)).BeginInit();
            this.gpbEstoque.SuspendLayout();
            this.gpbTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtLocalizacao);
            this.splitContainer1.Panel1.Controls.Add(this.lblLocalizacao);
            this.splitContainer1.Panel1.Controls.Add(this.txtTipo);
            this.splitContainer1.Panel1.Controls.Add(this.lblTipo);
            this.splitContainer1.Panel1.Controls.Add(this.gpbFiltros);
            this.splitContainer1.Panel1.Controls.Add(this.lblConsultaDePrecos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDados);
            this.splitContainer1.Size = new System.Drawing.Size(1119, 573);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtLocalizacao
            // 
            this.txtLocalizacao.Location = new System.Drawing.Point(672, 117);
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.ReadOnly = true;
            this.txtLocalizacao.Size = new System.Drawing.Size(234, 20);
            this.txtLocalizacao.TabIndex = 51;
            this.txtLocalizacao.TabStop = false;
            // 
            // lblLocalizacao
            // 
            this.lblLocalizacao.AutoSize = true;
            this.lblLocalizacao.Location = new System.Drawing.Point(669, 101);
            this.lblLocalizacao.Name = "lblLocalizacao";
            this.lblLocalizacao.Size = new System.Drawing.Size(64, 13);
            this.lblLocalizacao.TabIndex = 52;
            this.lblLocalizacao.Text = "Localização";
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(672, 79);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.ReadOnly = true;
            this.txtTipo.Size = new System.Drawing.Size(234, 20);
            this.txtTipo.TabIndex = 49;
            this.txtTipo.TabStop = false;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(669, 63);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 50;
            this.lblTipo.Text = "Tipo";
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.btnPreencherFabricante);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.gpbEstoque);
            this.gpbFiltros.Controls.Add(this.gpbTipo);
            this.gpbFiltros.Controls.Add(this.txtGenerico);
            this.gpbFiltros.Controls.Add(this.lblFabricante);
            this.gpbFiltros.Controls.Add(this.txtCodProduto);
            this.gpbFiltros.Controls.Add(this.lblGenerico);
            this.gpbFiltros.Controls.Add(this.txtProduto);
            this.gpbFiltros.Controls.Add(this.lblProduto);
            this.gpbFiltros.Controls.Add(this.txtFabricante);
            this.gpbFiltros.Controls.Add(this.txtCodFabricante);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 34);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(562, 142);
            this.gpbFiltros.TabIndex = 14;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // btnPreencherFabricante
            // 
            this.btnPreencherFabricante.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherFabricante.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherFabricante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherFabricante.Location = new System.Drawing.Point(338, 104);
            this.btnPreencherFabricante.Name = "btnPreencherFabricante";
            this.btnPreencherFabricante.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherFabricante.TabIndex = 27;
            this.btnPreencherFabricante.TabStop = false;
            this.btnPreencherFabricante.Click += new System.EventHandler(this.BtnPreencherFabricante_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(476, 104);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 32);
            this.btnPesquisar.TabIndex = 48;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // gpbEstoque
            // 
            this.gpbEstoque.Controls.Add(this.chkNão);
            this.gpbEstoque.Controls.Add(this.chkSim);
            this.gpbEstoque.Location = new System.Drawing.Point(370, 14);
            this.gpbEstoque.Name = "gpbEstoque";
            this.gpbEstoque.Size = new System.Drawing.Size(88, 64);
            this.gpbEstoque.TabIndex = 15;
            this.gpbEstoque.TabStop = false;
            this.gpbEstoque.Text = "Estoque";
            // 
            // chkNão
            // 
            this.chkNão.AutoSize = true;
            this.chkNão.Checked = true;
            this.chkNão.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNão.Location = new System.Drawing.Point(6, 41);
            this.chkNão.Name = "chkNão";
            this.chkNão.Size = new System.Drawing.Size(46, 17);
            this.chkNão.TabIndex = 3;
            this.chkNão.Text = "Não";
            this.chkNão.UseVisualStyleBackColor = true;
            this.chkNão.CheckedChanged += new System.EventHandler(this.ChkNão_CheckedChanged);
            // 
            // chkSim
            // 
            this.chkSim.AutoSize = true;
            this.chkSim.Checked = true;
            this.chkSim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSim.Location = new System.Drawing.Point(6, 19);
            this.chkSim.Name = "chkSim";
            this.chkSim.Size = new System.Drawing.Size(43, 17);
            this.chkSim.TabIndex = 2;
            this.chkSim.Text = "Sim";
            this.chkSim.UseVisualStyleBackColor = true;
            this.chkSim.CheckedChanged += new System.EventHandler(this.ChkSim_CheckedChanged);
            // 
            // gpbTipo
            // 
            this.gpbTipo.Controls.Add(this.chkHospitalar);
            this.gpbTipo.Controls.Add(this.chkOncologico);
            this.gpbTipo.Location = new System.Drawing.Point(464, 14);
            this.gpbTipo.Name = "gpbTipo";
            this.gpbTipo.Size = new System.Drawing.Size(88, 64);
            this.gpbTipo.TabIndex = 14;
            this.gpbTipo.TabStop = false;
            this.gpbTipo.Text = "Tipo";
            // 
            // chkHospitalar
            // 
            this.chkHospitalar.AutoSize = true;
            this.chkHospitalar.Checked = true;
            this.chkHospitalar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHospitalar.Location = new System.Drawing.Point(6, 41);
            this.chkHospitalar.Name = "chkHospitalar";
            this.chkHospitalar.Size = new System.Drawing.Size(73, 17);
            this.chkHospitalar.TabIndex = 1;
            this.chkHospitalar.Text = "Hospitalar";
            this.chkHospitalar.UseVisualStyleBackColor = true;
            this.chkHospitalar.CheckedChanged += new System.EventHandler(this.ChkHospitalar_CheckedChanged);
            // 
            // chkOncologico
            // 
            this.chkOncologico.AutoSize = true;
            this.chkOncologico.Checked = true;
            this.chkOncologico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOncologico.Location = new System.Drawing.Point(6, 19);
            this.chkOncologico.Name = "chkOncologico";
            this.chkOncologico.Size = new System.Drawing.Size(80, 17);
            this.chkOncologico.TabIndex = 0;
            this.chkOncologico.Text = "Oncológico";
            this.chkOncologico.UseVisualStyleBackColor = true;
            this.chkOncologico.CheckedChanged += new System.EventHandler(this.ChkOncologico_CheckedChanged);
            // 
            // txtGenerico
            // 
            this.txtGenerico.Location = new System.Drawing.Point(6, 68);
            this.txtGenerico.Name = "txtGenerico";
            this.txtGenerico.Size = new System.Drawing.Size(331, 20);
            this.txtGenerico.TabIndex = 7;
            this.txtGenerico.TextChanged += new System.EventHandler(this.TxtGenerico_TextChanged);
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(3, 88);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(57, 13);
            this.lblFabricante.TabIndex = 13;
            this.lblFabricante.Text = "Fabricante";
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Location = new System.Drawing.Point(6, 30);
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.Size = new System.Drawing.Size(42, 20);
            this.txtCodProduto.TabIndex = 5;
            this.txtCodProduto.TextChanged += new System.EventHandler(this.TxtCodProduto_TextChanged);
            this.txtCodProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // lblGenerico
            // 
            this.lblGenerico.AutoSize = true;
            this.lblGenerico.Location = new System.Drawing.Point(3, 52);
            this.lblGenerico.Name = "lblGenerico";
            this.lblGenerico.Size = new System.Drawing.Size(50, 13);
            this.lblGenerico.TabIndex = 12;
            this.lblGenerico.Text = "Genérico";
            // 
            // txtProduto
            // 
            this.txtProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProduto.Location = new System.Drawing.Point(54, 30);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(283, 20);
            this.txtProduto.TabIndex = 6;
            this.txtProduto.TextChanged += new System.EventHandler(this.TxtProduto_TextChanged);
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(3, 14);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(44, 13);
            this.lblProduto.TabIndex = 11;
            this.lblProduto.Text = "Produto";
            // 
            // txtFabricante
            // 
            this.txtFabricante.Location = new System.Drawing.Point(54, 104);
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.ReadOnly = true;
            this.txtFabricante.Size = new System.Drawing.Size(283, 20);
            this.txtFabricante.TabIndex = 10;
            this.txtFabricante.TabStop = false;
            // 
            // txtCodFabricante
            // 
            this.txtCodFabricante.Location = new System.Drawing.Point(6, 104);
            this.txtCodFabricante.Name = "txtCodFabricante";
            this.txtCodFabricante.Size = new System.Drawing.Size(42, 20);
            this.txtCodFabricante.TabIndex = 9;
            this.txtCodFabricante.TextChanged += new System.EventHandler(this.TxtCodFabricante_TextChanged);
            this.txtCodFabricante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // lblConsultaDePrecos
            // 
            this.lblConsultaDePrecos.AutoSize = true;
            this.lblConsultaDePrecos.BackColor = System.Drawing.Color.Gainsboro;
            this.lblConsultaDePrecos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultaDePrecos.Location = new System.Drawing.Point(7, 6);
            this.lblConsultaDePrecos.Name = "lblConsultaDePrecos";
            this.lblConsultaDePrecos.Size = new System.Drawing.Size(216, 25);
            this.lblConsultaDePrecos.TabIndex = 4;
            this.lblConsultaDePrecos.Text = "Consulta de preços";
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(1119, 370);
            this.dgvDados.TabIndex = 2;
            this.dgvDados.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDados_CellEnter);
            this.dgvDados.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvDados_CellMouseDoubleClick);
            // 
            // frmConsultarPrecos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 573);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmConsultarPrecos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Precificação";
            this.Load += new System.EventHandler(this.FrmConsultarPrecos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultarPrecos_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherFabricante)).EndInit();
            this.gpbEstoque.ResumeLayout(false);
            this.gpbEstoque.PerformLayout();
            this.gpbTipo.ResumeLayout(false);
            this.gpbTipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.TextBox txtFabricante;
        private System.Windows.Forms.TextBox txtCodFabricante;
        private System.Windows.Forms.TextBox txtGenerico;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.TextBox txtCodProduto;
        private System.Windows.Forms.Label lblConsultaDePrecos;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.Label lblGenerico;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.GroupBox gpbEstoque;
        private System.Windows.Forms.GroupBox gpbTipo;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.PictureBox btnPreencherFabricante;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.CheckBox chkNão;
        private System.Windows.Forms.CheckBox chkSim;
        private System.Windows.Forms.CheckBox chkHospitalar;
        private System.Windows.Forms.CheckBox chkOncologico;
        private System.Windows.Forms.TextBox txtLocalizacao;
        private System.Windows.Forms.Label lblLocalizacao;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label lblTipo;
    }
}