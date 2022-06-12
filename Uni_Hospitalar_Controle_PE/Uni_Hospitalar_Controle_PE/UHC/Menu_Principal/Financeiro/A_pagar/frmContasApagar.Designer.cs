namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.A_pagar
{
    partial class frmContasApagar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblTop10Cap = new System.Windows.Forms.Label();
            this.lblAno = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gRanking = new LiveCharts.WinForms.CartesianChart();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.gpbRanking = new System.Windows.Forms.GroupBox();
            this.dgvRanking = new System.Windows.Forms.DataGridView();
            this.btnExportarGrafico = new System.Windows.Forms.Button();
            this.btnExportarCAP = new System.Windows.Forms.Button();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.lblCAP = new System.Windows.Forms.Label();
            this.lblDtCorte = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.txtCAP = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cbxTipoDaBusca = new System.Windows.Forms.ComboBox();
            this.gpbValores = new System.Windows.Forms.GroupBox();
            this.mtxValorFinal = new System.Windows.Forms.TextBox();
            this.mtxValorInicial = new System.Windows.Forms.TextBox();
            this.chkValor = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCod = new System.Windows.Forms.Label();
            this.lblTipoDaBusca = new System.Windows.Forms.Label();
            this.gpbVencimento = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDtVencFinal = new System.Windows.Forms.DateTimePicker();
            this.chkVencimento = new System.Windows.Forms.CheckBox();
            this.dtpDtVencInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpDatCorte = new System.Windows.Forms.DateTimePicker();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.gpbCap = new System.Windows.Forms.GroupBox();
            this.chkTransportadora = new System.Windows.Forms.CheckBox();
            this.chkFornecedor = new System.Windows.Forms.CheckBox();
            this.chkFavorecido = new System.Windows.Forms.CheckBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.gpbRanking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).BeginInit();
            this.gpbFiltros.SuspendLayout();
            this.gpbValores.SuspendLayout();
            this.gpbVencimento.SuspendLayout();
            this.gpbCap.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel1.Controls.Add(this.lblTop10Cap);
            this.splitContainer1.Panel1.Controls.Add(this.lblAno);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1908, 866);
            this.splitContainer1.SplitterDistance = 45;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblTop10Cap
            // 
            this.lblTop10Cap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblTop10Cap.AutoSize = true;
            this.lblTop10Cap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTop10Cap.Location = new System.Drawing.Point(872, 16);
            this.lblTop10Cap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTop10Cap.Name = "lblTop10Cap";
            this.lblTop10Cap.Size = new System.Drawing.Size(98, 16);
            this.lblTop10Cap.TabIndex = 3;
            this.lblTop10Cap.Text = "Top 10 - CAP";
            this.lblTop10Cap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.BackColor = System.Drawing.Color.Gainsboro;
            this.lblAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAno.Location = new System.Drawing.Point(4, 7);
            this.lblAno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(173, 25);
            this.lblAno.TabIndex = 2;
            this.lblAno.Text = "Contas a pagar";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gRanking);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1908, 816);
            this.splitContainer2.SplitterDistance = 372;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 1;
            // 
            // gRanking
            // 
            this.gRanking.BackColor = System.Drawing.Color.Transparent;
            this.gRanking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gRanking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gRanking.Location = new System.Drawing.Point(0, 0);
            this.gRanking.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gRanking.Name = "gRanking";
            this.gRanking.Size = new System.Drawing.Size(1906, 370);
            this.gRanking.TabIndex = 0;
            this.gRanking.Text = "gRanking";
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer3.Panel1.Controls.Add(this.dgvDados);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer3.Panel2.Controls.Add(this.btnFechar);
            this.splitContainer3.Panel2.Controls.Add(this.gpbRanking);
            this.splitContainer3.Panel2.Controls.Add(this.btnExportarGrafico);
            this.splitContainer3.Panel2.Controls.Add(this.btnExportarCAP);
            this.splitContainer3.Panel2.Controls.Add(this.gpbFiltros);
            this.splitContainer3.Size = new System.Drawing.Size(1908, 439);
            this.splitContainer3.SplitterDistance = 856;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 2;
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
            this.dgvDados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.RowHeadersWidth = 51;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(854, 437);
            this.dgvDados.TabIndex = 2;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(932, 387);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(97, 42);
            this.btnFechar.TabIndex = 6;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.BtnFechar_Click);
            // 
            // gpbRanking
            // 
            this.gpbRanking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbRanking.BackColor = System.Drawing.Color.Transparent;
            this.gpbRanking.Controls.Add(this.dgvRanking);
            this.gpbRanking.Location = new System.Drawing.Point(0, 0);
            this.gpbRanking.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbRanking.Name = "gpbRanking";
            this.gpbRanking.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbRanking.Size = new System.Drawing.Size(465, 429);
            this.gpbRanking.TabIndex = 1;
            this.gpbRanking.TabStop = false;
            this.gpbRanking.Text = "Ranking";
            // 
            // dgvRanking
            // 
            this.dgvRanking.AllowUserToAddRows = false;
            this.dgvRanking.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvRanking.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRanking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRanking.Location = new System.Drawing.Point(4, 19);
            this.dgvRanking.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvRanking.Name = "dgvRanking";
            this.dgvRanking.ReadOnly = true;
            this.dgvRanking.RowHeadersVisible = false;
            this.dgvRanking.RowHeadersWidth = 51;
            this.dgvRanking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRanking.Size = new System.Drawing.Size(457, 406);
            this.dgvRanking.TabIndex = 3;
            // 
            // btnExportarGrafico
            // 
            this.btnExportarGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarGrafico.BackColor = System.Drawing.Color.Firebrick;
            this.btnExportarGrafico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarGrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarGrafico.ForeColor = System.Drawing.Color.White;
            this.btnExportarGrafico.Location = new System.Drawing.Point(725, 387);
            this.btnExportarGrafico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportarGrafico.Name = "btnExportarGrafico";
            this.btnExportarGrafico.Size = new System.Drawing.Size(199, 42);
            this.btnExportarGrafico.TabIndex = 5;
            this.btnExportarGrafico.Text = "Exportar Gráfico";
            this.btnExportarGrafico.UseVisualStyleBackColor = false;
            this.btnExportarGrafico.Click += new System.EventHandler(this.BtnExportarGrafico_Click);
            // 
            // btnExportarCAP
            // 
            this.btnExportarCAP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarCAP.BackColor = System.Drawing.Color.Firebrick;
            this.btnExportarCAP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarCAP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarCAP.ForeColor = System.Drawing.Color.White;
            this.btnExportarCAP.Location = new System.Drawing.Point(508, 387);
            this.btnExportarCAP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportarCAP.Name = "btnExportarCAP";
            this.btnExportarCAP.Size = new System.Drawing.Size(215, 42);
            this.btnExportarCAP.TabIndex = 2;
            this.btnExportarCAP.Text = "Exportar CAP";
            this.btnExportarCAP.UseVisualStyleBackColor = false;
            this.btnExportarCAP.Click += new System.EventHandler(this.BtnExportarCAP_Click);
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbFiltros.BackColor = System.Drawing.Color.Transparent;
            this.gpbFiltros.Controls.Add(this.lblCAP);
            this.gpbFiltros.Controls.Add(this.lblDtCorte);
            this.gpbFiltros.Controls.Add(this.txtDescricao);
            this.gpbFiltros.Controls.Add(this.txtCAP);
            this.gpbFiltros.Controls.Add(this.txtCodigo);
            this.gpbFiltros.Controls.Add(this.cbxTipoDaBusca);
            this.gpbFiltros.Controls.Add(this.gpbValores);
            this.gpbFiltros.Controls.Add(this.lblCod);
            this.gpbFiltros.Controls.Add(this.lblTipoDaBusca);
            this.gpbFiltros.Controls.Add(this.gpbVencimento);
            this.gpbFiltros.Controls.Add(this.dtpDatCorte);
            this.gpbFiltros.Controls.Add(this.lblDescricao);
            this.gpbFiltros.Controls.Add(this.lblTitulo);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.gpbCap);
            this.gpbFiltros.Controls.Add(this.txtTitulo);
            this.gpbFiltros.Location = new System.Drawing.Point(477, 2);
            this.gpbFiltros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbFiltros.Size = new System.Drawing.Size(552, 292);
            this.gpbFiltros.TabIndex = 0;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // lblCAP
            // 
            this.lblCAP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCAP.AutoSize = true;
            this.lblCAP.Location = new System.Drawing.Point(16, 234);
            this.lblCAP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCAP.Name = "lblCAP";
            this.lblCAP.Size = new System.Drawing.Size(69, 16);
            this.lblCAP.TabIndex = 61;
            this.lblCAP.Text = "Valor CAP";
            // 
            // lblDtCorte
            // 
            this.lblDtCorte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDtCorte.AutoSize = true;
            this.lblDtCorte.Location = new System.Drawing.Point(8, 20);
            this.lblDtCorte.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDtCorte.Name = "lblDtCorte";
            this.lblDtCorte.Size = new System.Drawing.Size(88, 16);
            this.lblDtCorte.TabIndex = 48;
            this.lblDtCorte.Text = "Data de corte";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescricao.Location = new System.Drawing.Point(80, 89);
            this.txtDescricao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(321, 22);
            this.txtDescricao.TabIndex = 53;
            this.txtDescricao.TextChanged += new System.EventHandler(this.TxtDescricao_TextChanged);
            this.txtDescricao.Enter += new System.EventHandler(this.TxtDescricao_Enter);
            this.txtDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarComEnter);
            // 
            // txtCAP
            // 
            this.txtCAP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCAP.Location = new System.Drawing.Point(20, 254);
            this.txtCAP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCAP.Name = "txtCAP";
            this.txtCAP.ReadOnly = true;
            this.txtCAP.Size = new System.Drawing.Size(144, 22);
            this.txtCAP.TabIndex = 60;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCodigo.Location = new System.Drawing.Point(13, 89);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(57, 22);
            this.txtCodigo.TabIndex = 54;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCod_TextChanged);
            this.txtCodigo.Enter += new System.EventHandler(this.TxtCodigo_Enter);
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarComEnter);
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // cbxTipoDaBusca
            // 
            this.cbxTipoDaBusca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbxTipoDaBusca.FormattingEnabled = true;
            this.cbxTipoDaBusca.Location = new System.Drawing.Point(411, 89);
            this.cbxTipoDaBusca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxTipoDaBusca.Name = "cbxTipoDaBusca";
            this.cbxTipoDaBusca.Size = new System.Drawing.Size(133, 24);
            this.cbxTipoDaBusca.TabIndex = 52;
            this.cbxTipoDaBusca.SelectedIndexChanged += new System.EventHandler(this.cbxTipoDaBusca_SelectedIndexChanged);
            // 
            // gpbValores
            // 
            this.gpbValores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpbValores.Controls.Add(this.mtxValorFinal);
            this.gpbValores.Controls.Add(this.mtxValorInicial);
            this.gpbValores.Controls.Add(this.chkValor);
            this.gpbValores.Controls.Add(this.label7);
            this.gpbValores.Location = new System.Drawing.Point(31, 123);
            this.gpbValores.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbValores.Name = "gpbValores";
            this.gpbValores.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbValores.Size = new System.Drawing.Size(153, 111);
            this.gpbValores.TabIndex = 50;
            this.gpbValores.TabStop = false;
            this.gpbValores.Text = "Valores";
            // 
            // mtxValorFinal
            // 
            this.mtxValorFinal.Location = new System.Drawing.Point(8, 75);
            this.mtxValorFinal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mtxValorFinal.Name = "mtxValorFinal";
            this.mtxValorFinal.Size = new System.Drawing.Size(132, 22);
            this.mtxValorFinal.TabIndex = 17;
            this.mtxValorFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarComEnter);
            this.mtxValorFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Valor_Com_Virgula_KeyPress);
            // 
            // mtxValorInicial
            // 
            this.mtxValorInicial.Location = new System.Drawing.Point(8, 27);
            this.mtxValorInicial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mtxValorInicial.Name = "mtxValorInicial";
            this.mtxValorInicial.Size = new System.Drawing.Size(132, 22);
            this.mtxValorInicial.TabIndex = 16;
            this.mtxValorInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarComEnter);
            this.mtxValorInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Valor_Com_Virgula_KeyPress);
            // 
            // chkValor
            // 
            this.chkValor.AutoSize = true;
            this.chkValor.Location = new System.Drawing.Point(63, 0);
            this.chkValor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkValor.Name = "chkValor";
            this.chkValor.Size = new System.Drawing.Size(15, 14);
            this.chkValor.TabIndex = 15;
            this.chkValor.UseVisualStyleBackColor = true;
            this.chkValor.CheckedChanged += new System.EventHandler(this.chkValor_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 54);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Até";
            // 
            // lblCod
            // 
            this.lblCod.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(13, 69);
            this.lblCod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(51, 16);
            this.lblCod.TabIndex = 55;
            this.lblCod.Text = "Código";
            // 
            // lblTipoDaBusca
            // 
            this.lblTipoDaBusca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTipoDaBusca.AutoSize = true;
            this.lblTipoDaBusca.Location = new System.Drawing.Point(404, 69);
            this.lblTipoDaBusca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoDaBusca.Name = "lblTipoDaBusca";
            this.lblTipoDaBusca.Size = new System.Drawing.Size(94, 16);
            this.lblTipoDaBusca.TabIndex = 56;
            this.lblTipoDaBusca.Text = "Tipo da busca";
            // 
            // gpbVencimento
            // 
            this.gpbVencimento.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpbVencimento.Controls.Add(this.label6);
            this.gpbVencimento.Controls.Add(this.dtpDtVencFinal);
            this.gpbVencimento.Controls.Add(this.chkVencimento);
            this.gpbVencimento.Controls.Add(this.dtpDtVencInicial);
            this.gpbVencimento.Location = new System.Drawing.Point(383, 123);
            this.gpbVencimento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbVencimento.Name = "gpbVencimento";
            this.gpbVencimento.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbVencimento.Size = new System.Drawing.Size(147, 111);
            this.gpbVencimento.TabIndex = 51;
            this.gpbVencimento.TabStop = false;
            this.gpbVencimento.Text = "Vencimento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 53);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Até";
            // 
            // dtpDtVencFinal
            // 
            this.dtpDtVencFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtVencFinal.Location = new System.Drawing.Point(8, 75);
            this.dtpDtVencFinal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDtVencFinal.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpDtVencFinal.Name = "dtpDtVencFinal";
            this.dtpDtVencFinal.Size = new System.Drawing.Size(125, 22);
            this.dtpDtVencFinal.TabIndex = 14;
            this.dtpDtVencFinal.Value = new System.DateTime(2019, 8, 28, 0, 0, 0, 0);
            this.dtpDtVencFinal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarComEnter);
            // 
            // chkVencimento
            // 
            this.chkVencimento.AutoSize = true;
            this.chkVencimento.Location = new System.Drawing.Point(89, 0);
            this.chkVencimento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkVencimento.Name = "chkVencimento";
            this.chkVencimento.Size = new System.Drawing.Size(15, 14);
            this.chkVencimento.TabIndex = 13;
            this.chkVencimento.UseVisualStyleBackColor = true;
            this.chkVencimento.CheckedChanged += new System.EventHandler(this.chkVencimento_CheckedChanged);
            // 
            // dtpDtVencInicial
            // 
            this.dtpDtVencInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtVencInicial.Location = new System.Drawing.Point(8, 25);
            this.dtpDtVencInicial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDtVencInicial.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpDtVencInicial.Name = "dtpDtVencInicial";
            this.dtpDtVencInicial.Size = new System.Drawing.Size(125, 22);
            this.dtpDtVencInicial.TabIndex = 13;
            this.dtpDtVencInicial.Value = new System.DateTime(2019, 8, 28, 0, 0, 0, 0);
            this.dtpDtVencInicial.ValueChanged += new System.EventHandler(this.DtpDtVencInicial_ValueChanged);
            this.dtpDtVencInicial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarComEnter);
            // 
            // dtpDatCorte
            // 
            this.dtpDatCorte.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpDatCorte.Location = new System.Drawing.Point(13, 39);
            this.dtpDatCorte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDatCorte.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpDatCorte.Name = "dtpDatCorte";
            this.dtpDatCorte.Size = new System.Drawing.Size(313, 22);
            this.dtpDatCorte.TabIndex = 47;
            this.dtpDatCorte.Value = new System.DateTime(2019, 8, 28, 0, 0, 0, 0);
            this.dtpDatCorte.ValueChanged += new System.EventHandler(this.dtpDatCorte_ValueChanged);
            // 
            // lblDescricao
            // 
            this.lblDescricao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(76, 69);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(69, 16);
            this.lblDescricao.TabIndex = 57;
            this.lblDescricao.Text = "Descrição";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(332, 20);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(40, 16);
            this.lblTitulo.TabIndex = 59;
            this.lblTitulo.Text = "Título";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(391, 241);
            this.btnPesquisar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(155, 46);
            this.btnPesquisar.TabIndex = 46;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // gpbCap
            // 
            this.gpbCap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpbCap.Controls.Add(this.chkTransportadora);
            this.gpbCap.Controls.Add(this.chkFornecedor);
            this.gpbCap.Controls.Add(this.chkFavorecido);
            this.gpbCap.Location = new System.Drawing.Point(205, 123);
            this.gpbCap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbCap.Name = "gpbCap";
            this.gpbCap.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbCap.Size = new System.Drawing.Size(153, 111);
            this.gpbCap.TabIndex = 49;
            this.gpbCap.TabStop = false;
            this.gpbCap.Text = "Cap";
            // 
            // chkTransportadora
            // 
            this.chkTransportadora.AutoSize = true;
            this.chkTransportadora.Checked = true;
            this.chkTransportadora.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTransportadora.Location = new System.Drawing.Point(8, 81);
            this.chkTransportadora.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTransportadora.Name = "chkTransportadora";
            this.chkTransportadora.Size = new System.Drawing.Size(120, 20);
            this.chkTransportadora.TabIndex = 2;
            this.chkTransportadora.Text = "Transportadora";
            this.chkTransportadora.UseVisualStyleBackColor = true;
            this.chkTransportadora.CheckedChanged += new System.EventHandler(this.chkTransportadora_CheckedChanged);
            // 
            // chkFornecedor
            // 
            this.chkFornecedor.AutoSize = true;
            this.chkFornecedor.Checked = true;
            this.chkFornecedor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFornecedor.Location = new System.Drawing.Point(8, 53);
            this.chkFornecedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkFornecedor.Name = "chkFornecedor";
            this.chkFornecedor.Size = new System.Drawing.Size(96, 20);
            this.chkFornecedor.TabIndex = 1;
            this.chkFornecedor.Text = "Fornecedor";
            this.chkFornecedor.UseVisualStyleBackColor = true;
            this.chkFornecedor.CheckedChanged += new System.EventHandler(this.chkFornecedor_CheckedChanged);
            // 
            // chkFavorecido
            // 
            this.chkFavorecido.AutoSize = true;
            this.chkFavorecido.Checked = true;
            this.chkFavorecido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFavorecido.Location = new System.Drawing.Point(8, 25);
            this.chkFavorecido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkFavorecido.Name = "chkFavorecido";
            this.chkFavorecido.Size = new System.Drawing.Size(95, 20);
            this.chkFavorecido.TabIndex = 0;
            this.chkFavorecido.Text = "Favorecido";
            this.chkFavorecido.UseVisualStyleBackColor = true;
            this.chkFavorecido.CheckedChanged += new System.EventHandler(this.chkFavorecido_CheckedChanged);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTitulo.Location = new System.Drawing.Point(336, 39);
            this.txtTitulo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(208, 22);
            this.txtTitulo.TabIndex = 58;
            this.txtTitulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PesquisarComEnter);
            // 
            // frmContasApagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1908, 866);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmContasApagar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contas a pagar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmContasApagar_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmContasApagar_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.gpbRanking.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).EndInit();
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            this.gpbValores.ResumeLayout(false);
            this.gpbValores.PerformLayout();
            this.gpbVencimento.ResumeLayout(false);
            this.gpbVencimento.PerformLayout();
            this.gpbCap.ResumeLayout(false);
            this.gpbCap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.GroupBox gpbRanking;
        private System.Windows.Forms.Label lblCAP;
        private System.Windows.Forms.Label lblDtCorte;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.TextBox txtCAP;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ComboBox cbxTipoDaBusca;
        private System.Windows.Forms.GroupBox gpbValores;
        private System.Windows.Forms.CheckBox chkValor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.Label lblTipoDaBusca;
        private System.Windows.Forms.GroupBox gpbVencimento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDtVencFinal;
        private System.Windows.Forms.CheckBox chkVencimento;
        private System.Windows.Forms.DateTimePicker dtpDtVencInicial;
        private System.Windows.Forms.DateTimePicker dtpDatCorte;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.GroupBox gpbCap;
        private System.Windows.Forms.CheckBox chkTransportadora;
        private System.Windows.Forms.CheckBox chkFornecedor;
        private System.Windows.Forms.CheckBox chkFavorecido;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblAno;
        private LiveCharts.WinForms.CartesianChart gRanking;
        private System.Windows.Forms.Button btnExportarCAP;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.DataGridView dgvRanking;
        private System.Windows.Forms.Label lblTop10Cap;
        private System.Windows.Forms.TextBox mtxValorFinal;
        private System.Windows.Forms.TextBox mtxValorInicial;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnExportarGrafico;
    }
}