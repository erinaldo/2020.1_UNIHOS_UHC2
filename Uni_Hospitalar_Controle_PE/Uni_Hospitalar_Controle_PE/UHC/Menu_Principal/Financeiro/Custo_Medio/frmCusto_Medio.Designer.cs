namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Custo_Medio
{
    partial class frmCusto_Medio
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
            this.lblAjudaExportar = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblAjuda_InfoTela = new System.Windows.Forms.Label();
            this.lblAjuda_TransitoRelatorio = new System.Windows.Forms.Label();
            this.chkHelp = new System.Windows.Forms.CheckBox();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.lblAjuda_Filtrar_Clientes = new System.Windows.Forms.Label();
            this.lblAjuda_CFOP = new System.Windows.Forms.Label();
            this.lblAjuda_Cliente = new System.Windows.Forms.Label();
            this.lblAjuda_TipoRelatorio = new System.Windows.Forms.Label();
            this.lblAjuda_UltimaAtt = new System.Windows.Forms.Label();
            this.lblAtt = new System.Windows.Forms.Label();
            this.lblAjuda_Custo0 = new System.Windows.Forms.Label();
            this.lblAjuda_Produto = new System.Windows.Forms.Label();
            this.pcbAnalitico = new System.Windows.Forms.ProgressBar();
            this.pcbSintetico = new System.Windows.Forms.ProgressBar();
            this.clbCFOP = new System.Windows.Forms.CheckedListBox();
            this.dtpDatCorte = new System.Windows.Forms.DateTimePicker();
            this.btnPreencherCliente = new System.Windows.Forms.PictureBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.lblCFOP = new System.Windows.Forms.Label();
            this.lblDtCorte = new System.Windows.Forms.Label();
            this.lblNF = new System.Windows.Forms.Label();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.lblFabricante = new System.Windows.Forms.Label();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.txtCodProduto = new System.Windows.Forms.TextBox();
            this.lblProduto = new System.Windows.Forms.Label();
            this.chkMostrarNulos = new System.Windows.Forms.CheckBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.gpbTipoRelatorio = new System.Windows.Forms.GroupBox();
            this.rdbAnalitico = new System.Windows.Forms.RadioButton();
            this.rdbSintetico = new System.Windows.Forms.RadioButton();
            this.tbcCusto = new System.Windows.Forms.TabControl();
            this.pagAnalitico = new System.Windows.Forms.TabPage();
            this.dgvCustoAnalitico = new System.Windows.Forms.DataGridView();
            this.tabSintetico = new System.Windows.Forms.TabPage();
            this.dgvCustoSintetico = new System.Windows.Forms.DataGridView();
            this.chkMensal = new System.Windows.Forms.CheckBox();
            this.lblHelpMensal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).BeginInit();
            this.gpbTipoRelatorio.SuspendLayout();
            this.tbcCusto.SuspendLayout();
            this.pagAnalitico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustoAnalitico)).BeginInit();
            this.tabSintetico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustoSintetico)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblAjudaExportar);
            this.splitContainer1.Panel1.Controls.Add(this.btnExportar);
            this.splitContainer1.Panel1.Controls.Add(this.lblAjuda_InfoTela);
            this.splitContainer1.Panel1.Controls.Add(this.lblAjuda_TransitoRelatorio);
            this.splitContainer1.Panel1.Controls.Add(this.chkHelp);
            this.splitContainer1.Panel1.Controls.Add(this.gpbFiltros);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbcCusto);
            this.splitContainer1.Size = new System.Drawing.Size(1182, 619);
            this.splitContainer1.SplitterDistance = 304;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblAjudaExportar
            // 
            this.lblAjudaExportar.AutoSize = true;
            this.lblAjudaExportar.ForeColor = System.Drawing.Color.Red;
            this.lblAjudaExportar.Location = new System.Drawing.Point(617, 44);
            this.lblAjudaExportar.Name = "lblAjudaExportar";
            this.lblAjudaExportar.Size = new System.Drawing.Size(299, 13);
            this.lblAjudaExportar.TabIndex = 75;
            this.lblAjudaExportar.Text = "Para exportar em excel gere as duas modalidades de relatório.";
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(617, 17);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(73, 24);
            this.btnExportar.TabIndex = 74;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblAjuda_InfoTela
            // 
            this.lblAjuda_InfoTela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAjuda_InfoTela.AutoSize = true;
            this.lblAjuda_InfoTela.ForeColor = System.Drawing.Color.Red;
            this.lblAjuda_InfoTela.Location = new System.Drawing.Point(657, 280);
            this.lblAjuda_InfoTela.Name = "lblAjuda_InfoTela";
            this.lblAjuda_InfoTela.Size = new System.Drawing.Size(508, 13);
            this.lblAjuda_InfoTela.TabIndex = 71;
            this.lblAjuda_InfoTela.Text = "Obs.: Se o filtro for por NF, o custo pesquisado será o equivalente ao período em" +
    " que a mesma foi emitida.";
            // 
            // lblAjuda_TransitoRelatorio
            // 
            this.lblAjuda_TransitoRelatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAjuda_TransitoRelatorio.AutoSize = true;
            this.lblAjuda_TransitoRelatorio.ForeColor = System.Drawing.Color.Red;
            this.lblAjuda_TransitoRelatorio.Location = new System.Drawing.Point(3, 292);
            this.lblAjuda_TransitoRelatorio.Name = "lblAjuda_TransitoRelatorio";
            this.lblAjuda_TransitoRelatorio.Size = new System.Drawing.Size(295, 13);
            this.lblAjuda_TransitoRelatorio.TabIndex = 69;
            this.lblAjuda_TransitoRelatorio.Text = "Cliente nas abas para visualizar os tipos distintos de relatórios";
            // 
            // chkHelp
            // 
            this.chkHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHelp.AutoSize = true;
            this.chkHelp.Location = new System.Drawing.Point(1108, 3);
            this.chkHelp.Name = "chkHelp";
            this.chkHelp.Size = new System.Drawing.Size(70, 17);
            this.chkHelp.TabIndex = 1;
            this.chkHelp.Text = "Ajude-me";
            this.chkHelp.UseVisualStyleBackColor = true;
            this.chkHelp.CheckedChanged += new System.EventHandler(this.chkHelp_CheckedChanged);
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.lblHelpMensal);
            this.gpbFiltros.Controls.Add(this.chkMensal);
            this.gpbFiltros.Controls.Add(this.lblAjuda_Filtrar_Clientes);
            this.gpbFiltros.Controls.Add(this.lblAjuda_CFOP);
            this.gpbFiltros.Controls.Add(this.lblAjuda_Cliente);
            this.gpbFiltros.Controls.Add(this.lblAjuda_TipoRelatorio);
            this.gpbFiltros.Controls.Add(this.lblAjuda_UltimaAtt);
            this.gpbFiltros.Controls.Add(this.lblAtt);
            this.gpbFiltros.Controls.Add(this.lblAjuda_Custo0);
            this.gpbFiltros.Controls.Add(this.lblAjuda_Produto);
            this.gpbFiltros.Controls.Add(this.pcbAnalitico);
            this.gpbFiltros.Controls.Add(this.pcbSintetico);
            this.gpbFiltros.Controls.Add(this.clbCFOP);
            this.gpbFiltros.Controls.Add(this.dtpDatCorte);
            this.gpbFiltros.Controls.Add(this.btnPreencherCliente);
            this.gpbFiltros.Controls.Add(this.lblCliente);
            this.gpbFiltros.Controls.Add(this.txtCodCliente);
            this.gpbFiltros.Controls.Add(this.txtCliente);
            this.gpbFiltros.Controls.Add(this.txtProduto);
            this.gpbFiltros.Controls.Add(this.lblCFOP);
            this.gpbFiltros.Controls.Add(this.lblDtCorte);
            this.gpbFiltros.Controls.Add(this.lblNF);
            this.gpbFiltros.Controls.Add(this.txtNF);
            this.gpbFiltros.Controls.Add(this.lblFabricante);
            this.gpbFiltros.Controls.Add(this.txtFabricante);
            this.gpbFiltros.Controls.Add(this.txtCodProduto);
            this.gpbFiltros.Controls.Add(this.lblProduto);
            this.gpbFiltros.Controls.Add(this.chkMostrarNulos);
            this.gpbFiltros.Controls.Add(this.btnFiltrar);
            this.gpbFiltros.Controls.Add(this.gpbTipoRelatorio);
            this.gpbFiltros.Location = new System.Drawing.Point(11, 12);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(600, 189);
            this.gpbFiltros.TabIndex = 0;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // lblAjuda_Filtrar_Clientes
            // 
            this.lblAjuda_Filtrar_Clientes.AutoSize = true;
            this.lblAjuda_Filtrar_Clientes.ForeColor = System.Drawing.Color.Red;
            this.lblAjuda_Filtrar_Clientes.Location = new System.Drawing.Point(427, 95);
            this.lblAjuda_Filtrar_Clientes.Name = "lblAjuda_Filtrar_Clientes";
            this.lblAjuda_Filtrar_Clientes.Size = new System.Drawing.Size(71, 13);
            this.lblAjuda_Filtrar_Clientes.TabIndex = 73;
            this.lblAjuda_Filtrar_Clientes.Text = "Filtrar clientes";
            // 
            // lblAjuda_CFOP
            // 
            this.lblAjuda_CFOP.AutoSize = true;
            this.lblAjuda_CFOP.ForeColor = System.Drawing.Color.Red;
            this.lblAjuda_CFOP.Location = new System.Drawing.Point(521, 16);
            this.lblAjuda_CFOP.Name = "lblAjuda_CFOP";
            this.lblAjuda_CFOP.Size = new System.Drawing.Size(78, 13);
            this.lblAjuda_CFOP.TabIndex = 70;
            this.lblAjuda_CFOP.Text = "Filtra por CFOP";
            // 
            // lblAjuda_Cliente
            // 
            this.lblAjuda_Cliente.AutoSize = true;
            this.lblAjuda_Cliente.ForeColor = System.Drawing.Color.Red;
            this.lblAjuda_Cliente.Location = new System.Drawing.Point(6, 88);
            this.lblAjuda_Cliente.Name = "lblAjuda_Cliente";
            this.lblAjuda_Cliente.Size = new System.Drawing.Size(127, 13);
            this.lblAjuda_Cliente.TabIndex = 72;
            this.lblAjuda_Cliente.Text = "Digite o código do cliente";
            // 
            // lblAjuda_TipoRelatorio
            // 
            this.lblAjuda_TipoRelatorio.AutoSize = true;
            this.lblAjuda_TipoRelatorio.ForeColor = System.Drawing.Color.Red;
            this.lblAjuda_TipoRelatorio.Location = new System.Drawing.Point(323, 131);
            this.lblAjuda_TipoRelatorio.Name = "lblAjuda_TipoRelatorio";
            this.lblAjuda_TipoRelatorio.Size = new System.Drawing.Size(149, 13);
            this.lblAjuda_TipoRelatorio.TabIndex = 71;
            this.lblAjuda_TipoRelatorio.Text = "Selecione o relatório desejado";
            // 
            // lblAjuda_UltimaAtt
            // 
            this.lblAjuda_UltimaAtt.AutoSize = true;
            this.lblAjuda_UltimaAtt.ForeColor = System.Drawing.Color.Red;
            this.lblAjuda_UltimaAtt.Location = new System.Drawing.Point(6, 152);
            this.lblAjuda_UltimaAtt.Name = "lblAjuda_UltimaAtt";
            this.lblAjuda_UltimaAtt.Size = new System.Drawing.Size(155, 13);
            this.lblAjuda_UltimaAtt.TabIndex = 68;
            this.lblAjuda_UltimaAtt.Text = "Data da última atualização feita";
            // 
            // lblAtt
            // 
            this.lblAtt.AutoSize = true;
            this.lblAtt.Location = new System.Drawing.Point(6, 165);
            this.lblAtt.Name = "lblAtt";
            this.lblAtt.Size = new System.Drawing.Size(99, 13);
            this.lblAtt.TabIndex = 2;
            this.lblAtt.Text = "Última atualização: ";
            // 
            // lblAjuda_Custo0
            // 
            this.lblAjuda_Custo0.AutoSize = true;
            this.lblAjuda_Custo0.ForeColor = System.Drawing.Color.Red;
            this.lblAjuda_Custo0.Location = new System.Drawing.Point(288, 152);
            this.lblAjuda_Custo0.Name = "lblAjuda_Custo0";
            this.lblAjuda_Custo0.Size = new System.Drawing.Size(236, 13);
            this.lblAjuda_Custo0.TabIndex = 67;
            this.lblAjuda_Custo0.Text = "Mostra produtos com custo sintético 0 (Sintético)";
            // 
            // lblAjuda_Produto
            // 
            this.lblAjuda_Produto.AutoSize = true;
            this.lblAjuda_Produto.ForeColor = System.Drawing.Color.Red;
            this.lblAjuda_Produto.Location = new System.Drawing.Point(56, 16);
            this.lblAjuda_Produto.Name = "lblAjuda_Produto";
            this.lblAjuda_Produto.Size = new System.Drawing.Size(146, 13);
            this.lblAjuda_Produto.TabIndex = 2;
            this.lblAjuda_Produto.Text = "Digite a descrição do produto";
            // 
            // pcbAnalitico
            // 
            this.pcbAnalitico.Location = new System.Drawing.Point(317, 147);
            this.pcbAnalitico.Name = "pcbAnalitico";
            this.pcbAnalitico.Size = new System.Drawing.Size(74, 23);
            this.pcbAnalitico.TabIndex = 66;
            // 
            // pcbSintetico
            // 
            this.pcbSintetico.Location = new System.Drawing.Point(396, 147);
            this.pcbSintetico.Name = "pcbSintetico";
            this.pcbSintetico.Size = new System.Drawing.Size(74, 23);
            this.pcbSintetico.TabIndex = 2;
            this.pcbSintetico.SizeChanged += new System.EventHandler(this.pcbSintetico_SizeChanged);
            // 
            // clbCFOP
            // 
            this.clbCFOP.FormattingEnabled = true;
            this.clbCFOP.Location = new System.Drawing.Point(476, 31);
            this.clbCFOP.Name = "clbCFOP";
            this.clbCFOP.Size = new System.Drawing.Size(120, 109);
            this.clbCFOP.TabIndex = 65;
            // 
            // dtpDatCorte
            // 
            this.dtpDatCorte.Location = new System.Drawing.Point(8, 117);
            this.dtpDatCorte.Name = "dtpDatCorte";
            this.dtpDatCorte.Size = new System.Drawing.Size(245, 20);
            this.dtpDatCorte.TabIndex = 64;
            // 
            // btnPreencherCliente
            // 
            this.btnPreencherCliente.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherCliente.Location = new System.Drawing.Point(444, 72);
            this.btnPreencherCliente.Name = "btnPreencherCliente";
            this.btnPreencherCliente.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherCliente.TabIndex = 63;
            this.btnPreencherCliente.TabStop = false;
            this.btnPreencherCliente.Click += new System.EventHandler(this.btnPreencherCliente_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(5, 55);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 60;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(8, 72);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(44, 20);
            this.txtCodCliente.TabIndex = 61;
            this.txtCodCliente.TextChanged += new System.EventHandler(this.txtCodCliente_TextChanged);
            this.txtCodCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(56, 72);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(382, 20);
            this.txtCliente.TabIndex = 62;
            // 
            // txtProduto
            // 
            this.txtProduto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtProduto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtProduto.Location = new System.Drawing.Point(56, 31);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(221, 20);
            this.txtProduto.TabIndex = 59;
            this.txtProduto.TextChanged += new System.EventHandler(this.txtProduto_TextChanged);
            // 
            // lblCFOP
            // 
            this.lblCFOP.AutoSize = true;
            this.lblCFOP.Location = new System.Drawing.Point(473, 13);
            this.lblCFOP.Name = "lblCFOP";
            this.lblCFOP.Size = new System.Drawing.Size(35, 13);
            this.lblCFOP.TabIndex = 54;
            this.lblCFOP.Text = "CFOP";
            // 
            // lblDtCorte
            // 
            this.lblDtCorte.Location = new System.Drawing.Point(6, 101);
            this.lblDtCorte.Name = "lblDtCorte";
            this.lblDtCorte.Size = new System.Drawing.Size(72, 13);
            this.lblDtCorte.TabIndex = 52;
            this.lblDtCorte.Text = "Data de corte";
            // 
            // lblNF
            // 
            this.lblNF.AutoSize = true;
            this.lblNF.Location = new System.Drawing.Point(256, 101);
            this.lblNF.Name = "lblNF";
            this.lblNF.Size = new System.Drawing.Size(21, 13);
            this.lblNF.TabIndex = 33;
            this.lblNF.Text = "NF";
            // 
            // txtNF
            // 
            this.txtNF.Location = new System.Drawing.Point(259, 117);
            this.txtNF.Name = "txtNF";
            this.txtNF.Size = new System.Drawing.Size(52, 20);
            this.txtNF.TabIndex = 32;
            this.txtNF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // lblFabricante
            // 
            this.lblFabricante.AutoSize = true;
            this.lblFabricante.Location = new System.Drawing.Point(282, 15);
            this.lblFabricante.Name = "lblFabricante";
            this.lblFabricante.Size = new System.Drawing.Size(57, 13);
            this.lblFabricante.TabIndex = 30;
            this.lblFabricante.Text = "Fabricante";
            // 
            // txtFabricante
            // 
            this.txtFabricante.Location = new System.Drawing.Point(283, 31);
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.ReadOnly = true;
            this.txtFabricante.Size = new System.Drawing.Size(155, 20);
            this.txtFabricante.TabIndex = 29;
            this.txtFabricante.TabStop = false;
            // 
            // txtCodProduto
            // 
            this.txtCodProduto.Location = new System.Drawing.Point(8, 31);
            this.txtCodProduto.Name = "txtCodProduto";
            this.txtCodProduto.ReadOnly = true;
            this.txtCodProduto.Size = new System.Drawing.Size(42, 20);
            this.txtCodProduto.TabIndex = 12;
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(5, 15);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(44, 13);
            this.lblProduto.TabIndex = 14;
            this.lblProduto.Text = "Produto";
            // 
            // chkMostrarNulos
            // 
            this.chkMostrarNulos.AutoSize = true;
            this.chkMostrarNulos.Location = new System.Drawing.Point(222, 139);
            this.chkMostrarNulos.Name = "chkMostrarNulos";
            this.chkMostrarNulos.Size = new System.Drawing.Size(89, 17);
            this.chkMostrarNulos.TabIndex = 4;
            this.chkMostrarNulos.Text = "Mostrar nulos";
            this.chkMostrarNulos.UseVisualStyleBackColor = true;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(476, 143);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(115, 35);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // gpbTipoRelatorio
            // 
            this.gpbTipoRelatorio.Controls.Add(this.rdbAnalitico);
            this.gpbTipoRelatorio.Controls.Add(this.rdbSintetico);
            this.gpbTipoRelatorio.Location = new System.Drawing.Point(317, 101);
            this.gpbTipoRelatorio.Name = "gpbTipoRelatorio";
            this.gpbTipoRelatorio.Size = new System.Drawing.Size(153, 41);
            this.gpbTipoRelatorio.TabIndex = 2;
            this.gpbTipoRelatorio.TabStop = false;
            this.gpbTipoRelatorio.Text = "Tipo do Relatório";
            this.gpbTipoRelatorio.Enter += new System.EventHandler(this.gpbTipoRelatorio_Enter);
            // 
            // rdbAnalitico
            // 
            this.rdbAnalitico.AutoSize = true;
            this.rdbAnalitico.Checked = true;
            this.rdbAnalitico.Location = new System.Drawing.Point(6, 15);
            this.rdbAnalitico.Name = "rdbAnalitico";
            this.rdbAnalitico.Size = new System.Drawing.Size(67, 17);
            this.rdbAnalitico.TabIndex = 1;
            this.rdbAnalitico.TabStop = true;
            this.rdbAnalitico.Text = "Analítico";
            this.rdbAnalitico.UseVisualStyleBackColor = true;
            this.rdbAnalitico.CheckedChanged += new System.EventHandler(this.rdbAnalitico_CheckedChanged);
            // 
            // rdbSintetico
            // 
            this.rdbSintetico.AutoSize = true;
            this.rdbSintetico.Location = new System.Drawing.Point(79, 15);
            this.rdbSintetico.Name = "rdbSintetico";
            this.rdbSintetico.Size = new System.Drawing.Size(66, 17);
            this.rdbSintetico.TabIndex = 0;
            this.rdbSintetico.Text = "Sintético";
            this.rdbSintetico.UseVisualStyleBackColor = true;
            this.rdbSintetico.CheckedChanged += new System.EventHandler(this.rdbSintetico_CheckedChanged);
            // 
            // tbcCusto
            // 
            this.tbcCusto.Controls.Add(this.pagAnalitico);
            this.tbcCusto.Controls.Add(this.tabSintetico);
            this.tbcCusto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcCusto.Location = new System.Drawing.Point(0, 0);
            this.tbcCusto.Name = "tbcCusto";
            this.tbcCusto.SelectedIndex = 0;
            this.tbcCusto.Size = new System.Drawing.Size(1182, 311);
            this.tbcCusto.TabIndex = 0;
            // 
            // pagAnalitico
            // 
            this.pagAnalitico.Controls.Add(this.dgvCustoAnalitico);
            this.pagAnalitico.Location = new System.Drawing.Point(4, 22);
            this.pagAnalitico.Name = "pagAnalitico";
            this.pagAnalitico.Padding = new System.Windows.Forms.Padding(3);
            this.pagAnalitico.Size = new System.Drawing.Size(1174, 285);
            this.pagAnalitico.TabIndex = 0;
            this.pagAnalitico.Text = "Custo Analítico";
            this.pagAnalitico.UseVisualStyleBackColor = true;
            // 
            // dgvCustoAnalitico
            // 
            this.dgvCustoAnalitico.AllowUserToAddRows = false;
            this.dgvCustoAnalitico.AllowUserToDeleteRows = false;
            this.dgvCustoAnalitico.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCustoAnalitico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustoAnalitico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustoAnalitico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustoAnalitico.Location = new System.Drawing.Point(3, 3);
            this.dgvCustoAnalitico.Name = "dgvCustoAnalitico";
            this.dgvCustoAnalitico.ReadOnly = true;
            this.dgvCustoAnalitico.RowHeadersVisible = false;
            this.dgvCustoAnalitico.Size = new System.Drawing.Size(1168, 279);
            this.dgvCustoAnalitico.TabIndex = 1;
            // 
            // tabSintetico
            // 
            this.tabSintetico.Controls.Add(this.dgvCustoSintetico);
            this.tabSintetico.Location = new System.Drawing.Point(4, 22);
            this.tabSintetico.Name = "tabSintetico";
            this.tabSintetico.Padding = new System.Windows.Forms.Padding(3);
            this.tabSintetico.Size = new System.Drawing.Size(1174, 285);
            this.tabSintetico.TabIndex = 1;
            this.tabSintetico.Text = "Custo Sintético";
            this.tabSintetico.UseVisualStyleBackColor = true;
            // 
            // dgvCustoSintetico
            // 
            this.dgvCustoSintetico.AllowUserToAddRows = false;
            this.dgvCustoSintetico.AllowUserToDeleteRows = false;
            this.dgvCustoSintetico.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCustoSintetico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustoSintetico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustoSintetico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustoSintetico.Location = new System.Drawing.Point(3, 3);
            this.dgvCustoSintetico.Name = "dgvCustoSintetico";
            this.dgvCustoSintetico.ReadOnly = true;
            this.dgvCustoSintetico.RowHeadersVisible = false;
            this.dgvCustoSintetico.Size = new System.Drawing.Size(1168, 279);
            this.dgvCustoSintetico.TabIndex = 1;
            // 
            // chkMensal
            // 
            this.chkMensal.AutoSize = true;
            this.chkMensal.Checked = true;
            this.chkMensal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMensal.Location = new System.Drawing.Point(222, 157);
            this.chkMensal.Name = "chkMensal";
            this.chkMensal.Size = new System.Drawing.Size(60, 17);
            this.chkMensal.TabIndex = 76;
            this.chkMensal.Text = "Mensal";
            this.chkMensal.UseVisualStyleBackColor = true;
            // 
            // lblHelpMensal
            // 
            this.lblHelpMensal.AutoSize = true;
            this.lblHelpMensal.ForeColor = System.Drawing.Color.Red;
            this.lblHelpMensal.Location = new System.Drawing.Point(236, 173);
            this.lblHelpMensal.Name = "lblHelpMensal";
            this.lblHelpMensal.Size = new System.Drawing.Size(259, 13);
            this.lblHelpMensal.TabIndex = 77;
            this.lblHelpMensal.Text = "Reduz a quantidade limite de campos para o sintético";
            this.lblHelpMensal.Click += new System.EventHandler(this.label1_Click);
            // 
            // frmCusto_Medio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 619);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmCusto_Medio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custo médio";
            this.Load += new System.EventHandler(this.frmCusto_Medio_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).EndInit();
            this.gpbTipoRelatorio.ResumeLayout(false);
            this.gpbTipoRelatorio.PerformLayout();
            this.tbcCusto.ResumeLayout(false);
            this.pagAnalitico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustoAnalitico)).EndInit();
            this.tabSintetico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustoSintetico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tbcCusto;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Label lblCFOP;
        private System.Windows.Forms.Label lblDtCorte;
        private System.Windows.Forms.Label lblNF;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.Label lblFabricante;
        private System.Windows.Forms.TextBox txtFabricante;
        private System.Windows.Forms.TextBox txtCodProduto;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.CheckBox chkMostrarNulos;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.GroupBox gpbTipoRelatorio;
        private System.Windows.Forms.RadioButton rdbAnalitico;
        private System.Windows.Forms.RadioButton rdbSintetico;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.CheckBox chkHelp;
        private System.Windows.Forms.PictureBox btnPreencherCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.DateTimePicker dtpDatCorte;
        private System.Windows.Forms.TabPage pagAnalitico;
        private System.Windows.Forms.DataGridView dgvCustoAnalitico;
        private System.Windows.Forms.TabPage tabSintetico;
        private System.Windows.Forms.DataGridView dgvCustoSintetico;
        private System.Windows.Forms.CheckedListBox clbCFOP;
        private System.Windows.Forms.ProgressBar pcbAnalitico;
        private System.Windows.Forms.ProgressBar pcbSintetico;
        private System.Windows.Forms.Label lblAtt;
        private System.Windows.Forms.Label lblAjuda_Custo0;
        private System.Windows.Forms.Label lblAjuda_Produto;
        private System.Windows.Forms.Label lblAjuda_InfoTela;
        private System.Windows.Forms.Label lblAjuda_CFOP;
        private System.Windows.Forms.Label lblAjuda_TransitoRelatorio;
        private System.Windows.Forms.Label lblAjuda_Filtrar_Clientes;
        private System.Windows.Forms.Label lblAjuda_Cliente;
        private System.Windows.Forms.Label lblAjuda_TipoRelatorio;
        private System.Windows.Forms.Label lblAjuda_UltimaAtt;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Label lblAjudaExportar;
        private System.Windows.Forms.CheckBox chkMensal;
        private System.Windows.Forms.Label lblHelpMensal;
    }
}