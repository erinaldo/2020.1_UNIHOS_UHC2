namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Canhotos.Controle_Canhotos
{
    partial class frmControleCanhotos
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
            this.clbNotas = new System.Windows.Forms.CheckedListBox();
            this.lblAno = new System.Windows.Forms.Label();
            this.gpbInfo = new System.Windows.Forms.GroupBox();
            this.lblRegistroCanhoto = new System.Windows.Forms.Label();
            this.txtRegistroCanhoto = new System.Windows.Forms.TextBox();
            this.lblDatTransacao = new System.Windows.Forms.Label();
            this.txtDatTransacao = new System.Windows.Forms.TextBox();
            this.lblDatColeta = new System.Windows.Forms.Label();
            this.txtDatColeta = new System.Windows.Forms.TextBox();
            this.txtTransp = new System.Windows.Forms.TextBox();
            this.lblTransp = new System.Windows.Forms.Label();
            this.txtCodTransp = new System.Windows.Forms.TextBox();
            this.txtClienteInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCFOP = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDatEmissao = new System.Windows.Forms.Label();
            this.txtCodClienteInfo = new System.Windows.Forms.TextBox();
            this.txtCFOP = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtDat_Emissao = new System.Windows.Forms.TextBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.btnPreencherTransportadora = new System.Windows.Forms.PictureBox();
            this.btnPreencherCliente = new System.Windows.Forms.PictureBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblNF = new System.Windows.Forms.Label();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.lblDat_Emissao = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.dtpDtFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpDtInicial = new System.Windows.Forms.DateTimePicker();
            this.txtCodTransportadora = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCodCliente = new System.Windows.Forms.Label();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.btnFecharExportar = new System.Windows.Forms.Button();
            this.dtpDataEntrega = new System.Windows.Forms.DateTimePicker();
            this.gpbDataEntrega = new System.Windows.Forms.GroupBox();
            this.chkDataEntrega = new System.Windows.Forms.CheckBox();
            this.chkHelp = new System.Windows.Forms.CheckBox();
            this.lblAjudaDataDeEntrega = new System.Windows.Forms.Label();
            this.lblAjudaFiltros = new System.Windows.Forms.Label();
            this.lblAjudaInformacoes = new System.Windows.Forms.Label();
            this.gpbInfo.SuspendLayout();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherTransportadora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).BeginInit();
            this.gpbDataEntrega.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbNotas
            // 
            this.clbNotas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clbNotas.FormattingEnabled = true;
            this.clbNotas.Location = new System.Drawing.Point(12, 46);
            this.clbNotas.Name = "clbNotas";
            this.clbNotas.Size = new System.Drawing.Size(142, 409);
            this.clbNotas.TabIndex = 0;
            this.clbNotas.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ClbNotas_ItemCheck);
            this.clbNotas.SelectedIndexChanged += new System.EventHandler(this.ClbNotas_SelectedIndexChanged);
            this.clbNotas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClbNotas_KeyDown);
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.BackColor = System.Drawing.Color.Gainsboro;
            this.lblAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAno.Location = new System.Drawing.Point(7, 9);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(237, 25);
            this.lblAno.TabIndex = 3;
            this.lblAno.Text = "Controle de canhotos";
            // 
            // gpbInfo
            // 
            this.gpbInfo.Controls.Add(this.lblAjudaInformacoes);
            this.gpbInfo.Controls.Add(this.lblRegistroCanhoto);
            this.gpbInfo.Controls.Add(this.txtRegistroCanhoto);
            this.gpbInfo.Controls.Add(this.lblDatTransacao);
            this.gpbInfo.Controls.Add(this.txtDatTransacao);
            this.gpbInfo.Controls.Add(this.lblDatColeta);
            this.gpbInfo.Controls.Add(this.txtDatColeta);
            this.gpbInfo.Controls.Add(this.txtTransp);
            this.gpbInfo.Controls.Add(this.lblTransp);
            this.gpbInfo.Controls.Add(this.txtCodTransp);
            this.gpbInfo.Controls.Add(this.txtClienteInfo);
            this.gpbInfo.Controls.Add(this.label1);
            this.gpbInfo.Controls.Add(this.lblCFOP);
            this.gpbInfo.Controls.Add(this.lblEstado);
            this.gpbInfo.Controls.Add(this.txtUF);
            this.gpbInfo.Controls.Add(this.lblStatus);
            this.gpbInfo.Controls.Add(this.lblDatEmissao);
            this.gpbInfo.Controls.Add(this.txtCodClienteInfo);
            this.gpbInfo.Controls.Add(this.txtCFOP);
            this.gpbInfo.Controls.Add(this.txtStatus);
            this.gpbInfo.Controls.Add(this.txtDat_Emissao);
            this.gpbInfo.Controls.Add(this.lblNota);
            this.gpbInfo.Location = new System.Drawing.Point(160, 46);
            this.gpbInfo.Name = "gpbInfo";
            this.gpbInfo.Size = new System.Drawing.Size(700, 175);
            this.gpbInfo.TabIndex = 5;
            this.gpbInfo.TabStop = false;
            this.gpbInfo.Text = "Informações";
            // 
            // lblRegistroCanhoto
            // 
            this.lblRegistroCanhoto.AutoSize = true;
            this.lblRegistroCanhoto.Location = new System.Drawing.Point(550, 126);
            this.lblRegistroCanhoto.Name = "lblRegistroCanhoto";
            this.lblRegistroCanhoto.Size = new System.Drawing.Size(104, 13);
            this.lblRegistroCanhoto.TabIndex = 24;
            this.lblRegistroCanhoto.Text = "Registro do Canhoto";
            // 
            // txtRegistroCanhoto
            // 
            this.txtRegistroCanhoto.Location = new System.Drawing.Point(553, 142);
            this.txtRegistroCanhoto.Name = "txtRegistroCanhoto";
            this.txtRegistroCanhoto.ReadOnly = true;
            this.txtRegistroCanhoto.Size = new System.Drawing.Size(132, 20);
            this.txtRegistroCanhoto.TabIndex = 23;
            this.txtRegistroCanhoto.TabStop = false;
            // 
            // lblDatTransacao
            // 
            this.lblDatTransacao.AutoSize = true;
            this.lblDatTransacao.Location = new System.Drawing.Point(550, 86);
            this.lblDatTransacao.Name = "lblDatTransacao";
            this.lblDatTransacao.Size = new System.Drawing.Size(81, 13);
            this.lblDatTransacao.TabIndex = 22;
            this.lblDatTransacao.Text = "Dat. Transação";
            // 
            // txtDatTransacao
            // 
            this.txtDatTransacao.Location = new System.Drawing.Point(553, 102);
            this.txtDatTransacao.Name = "txtDatTransacao";
            this.txtDatTransacao.ReadOnly = true;
            this.txtDatTransacao.Size = new System.Drawing.Size(132, 20);
            this.txtDatTransacao.TabIndex = 21;
            this.txtDatTransacao.TabStop = false;
            // 
            // lblDatColeta
            // 
            this.lblDatColeta.AutoSize = true;
            this.lblDatColeta.Location = new System.Drawing.Point(550, 46);
            this.lblDatColeta.Name = "lblDatColeta";
            this.lblDatColeta.Size = new System.Drawing.Size(60, 13);
            this.lblDatColeta.TabIndex = 20;
            this.lblDatColeta.Text = "Dat. Coleta";
            // 
            // txtDatColeta
            // 
            this.txtDatColeta.Location = new System.Drawing.Point(553, 62);
            this.txtDatColeta.Name = "txtDatColeta";
            this.txtDatColeta.ReadOnly = true;
            this.txtDatColeta.Size = new System.Drawing.Size(132, 20);
            this.txtDatColeta.TabIndex = 19;
            this.txtDatColeta.TabStop = false;
            // 
            // txtTransp
            // 
            this.txtTransp.Location = new System.Drawing.Point(56, 142);
            this.txtTransp.Name = "txtTransp";
            this.txtTransp.ReadOnly = true;
            this.txtTransp.Size = new System.Drawing.Size(491, 20);
            this.txtTransp.TabIndex = 18;
            this.txtTransp.TabStop = false;
            // 
            // lblTransp
            // 
            this.lblTransp.AutoSize = true;
            this.lblTransp.Location = new System.Drawing.Point(3, 126);
            this.lblTransp.Name = "lblTransp";
            this.lblTransp.Size = new System.Drawing.Size(79, 13);
            this.lblTransp.TabIndex = 17;
            this.lblTransp.Text = "Transportadora";
            // 
            // txtCodTransp
            // 
            this.txtCodTransp.Location = new System.Drawing.Point(6, 142);
            this.txtCodTransp.Name = "txtCodTransp";
            this.txtCodTransp.ReadOnly = true;
            this.txtCodTransp.Size = new System.Drawing.Size(44, 20);
            this.txtCodTransp.TabIndex = 16;
            this.txtCodTransp.TabStop = false;
            // 
            // txtClienteInfo
            // 
            this.txtClienteInfo.Location = new System.Drawing.Point(56, 102);
            this.txtClienteInfo.Name = "txtClienteInfo";
            this.txtClienteInfo.ReadOnly = true;
            this.txtClienteInfo.Size = new System.Drawing.Size(491, 20);
            this.txtClienteInfo.TabIndex = 15;
            this.txtClienteInfo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cliente";
            // 
            // lblCFOP
            // 
            this.lblCFOP.AutoSize = true;
            this.lblCFOP.Location = new System.Drawing.Point(235, 46);
            this.lblCFOP.Name = "lblCFOP";
            this.lblCFOP.Size = new System.Drawing.Size(40, 13);
            this.lblCFOP.TabIndex = 13;
            this.lblCFOP.Text = "Estado";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(188, 46);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 12;
            this.lblEstado.Text = "Estado";
            // 
            // txtUF
            // 
            this.txtUF.Location = new System.Drawing.Point(191, 62);
            this.txtUF.Name = "txtUF";
            this.txtUF.ReadOnly = true;
            this.txtUF.Size = new System.Drawing.Size(41, 20);
            this.txtUF.TabIndex = 11;
            this.txtUF.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(141, 46);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status";
            // 
            // lblDatEmissao
            // 
            this.lblDatEmissao.AutoSize = true;
            this.lblDatEmissao.Location = new System.Drawing.Point(3, 46);
            this.lblDatEmissao.Name = "lblDatEmissao";
            this.lblDatEmissao.Size = new System.Drawing.Size(69, 13);
            this.lblDatEmissao.TabIndex = 9;
            this.lblDatEmissao.Text = "Dat. Emissão";
            // 
            // txtCodClienteInfo
            // 
            this.txtCodClienteInfo.Location = new System.Drawing.Point(6, 102);
            this.txtCodClienteInfo.Name = "txtCodClienteInfo";
            this.txtCodClienteInfo.ReadOnly = true;
            this.txtCodClienteInfo.Size = new System.Drawing.Size(44, 20);
            this.txtCodClienteInfo.TabIndex = 4;
            this.txtCodClienteInfo.TabStop = false;
            // 
            // txtCFOP
            // 
            this.txtCFOP.Location = new System.Drawing.Point(238, 62);
            this.txtCFOP.Name = "txtCFOP";
            this.txtCFOP.ReadOnly = true;
            this.txtCFOP.Size = new System.Drawing.Size(309, 20);
            this.txtCFOP.TabIndex = 3;
            this.txtCFOP.TabStop = false;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(144, 62);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(41, 20);
            this.txtStatus.TabIndex = 2;
            this.txtStatus.TabStop = false;
            // 
            // txtDat_Emissao
            // 
            this.txtDat_Emissao.Location = new System.Drawing.Point(6, 62);
            this.txtDat_Emissao.Name = "txtDat_Emissao";
            this.txtDat_Emissao.ReadOnly = true;
            this.txtDat_Emissao.Size = new System.Drawing.Size(132, 20);
            this.txtDat_Emissao.TabIndex = 1;
            this.txtDat_Emissao.TabStop = false;
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNota.Location = new System.Drawing.Point(6, 16);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(0, 24);
            this.lblNota.TabIndex = 0;
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.lblAjudaFiltros);
            this.gpbFiltros.Controls.Add(this.btnPreencherTransportadora);
            this.gpbFiltros.Controls.Add(this.btnPreencherCliente);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.lblNF);
            this.gpbFiltros.Controls.Add(this.txtNF);
            this.gpbFiltros.Controls.Add(this.lblDat_Emissao);
            this.gpbFiltros.Controls.Add(this.label6);
            this.gpbFiltros.Controls.Add(this.txtTransportadora);
            this.gpbFiltros.Controls.Add(this.lblTransportadora);
            this.gpbFiltros.Controls.Add(this.dtpDtFinal);
            this.gpbFiltros.Controls.Add(this.dtpDtInicial);
            this.gpbFiltros.Controls.Add(this.txtCodTransportadora);
            this.gpbFiltros.Controls.Add(this.txtCliente);
            this.gpbFiltros.Controls.Add(this.lblCodCliente);
            this.gpbFiltros.Controls.Add(this.txtCodCliente);
            this.gpbFiltros.Location = new System.Drawing.Point(160, 227);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(557, 168);
            this.gpbFiltros.TabIndex = 6;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // btnPreencherTransportadora
            // 
            this.btnPreencherTransportadora.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherTransportadora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherTransportadora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherTransportadora.Location = new System.Drawing.Point(527, 81);
            this.btnPreencherTransportadora.Name = "btnPreencherTransportadora";
            this.btnPreencherTransportadora.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherTransportadora.TabIndex = 49;
            this.btnPreencherTransportadora.TabStop = false;
            this.btnPreencherTransportadora.Click += new System.EventHandler(this.BtnProcurarTransportadora_Click);
            // 
            // btnPreencherCliente
            // 
            this.btnPreencherCliente.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherCliente.Location = new System.Drawing.Point(527, 41);
            this.btnPreencherCliente.Name = "btnPreencherCliente";
            this.btnPreencherCliente.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherCliente.TabIndex = 48;
            this.btnPreencherCliente.TabStop = false;
            this.btnPreencherCliente.Click += new System.EventHandler(this.btnPreencherCliente_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(467, 118);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 37);
            this.btnPesquisar.TabIndex = 5;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // lblNF
            // 
            this.lblNF.AutoSize = true;
            this.lblNF.Location = new System.Drawing.Point(314, 114);
            this.lblNF.Name = "lblNF";
            this.lblNF.Size = new System.Drawing.Size(21, 13);
            this.lblNF.TabIndex = 24;
            this.lblNF.Text = "NF";
            // 
            // txtNF
            // 
            this.txtNF.Location = new System.Drawing.Point(341, 114);
            this.txtNF.Name = "txtNF";
            this.txtNF.Size = new System.Drawing.Size(71, 20);
            this.txtNF.TabIndex = 4;
            this.txtNF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_PesquisaComEnter_KeyDown);
            this.txtNF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // lblDat_Emissao
            // 
            this.lblDat_Emissao.AutoSize = true;
            this.lblDat_Emissao.Location = new System.Drawing.Point(3, 114);
            this.lblDat_Emissao.Name = "lblDat_Emissao";
            this.lblDat_Emissao.Size = new System.Drawing.Size(69, 13);
            this.lblDat_Emissao.TabIndex = 22;
            this.lblDat_Emissao.Text = "Dat. Emissão";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(173, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Até";
            // 
            // txtTransportadora
            // 
            this.txtTransportadora.Location = new System.Drawing.Point(56, 83);
            this.txtTransportadora.Name = "txtTransportadora";
            this.txtTransportadora.ReadOnly = true;
            this.txtTransportadora.Size = new System.Drawing.Size(465, 20);
            this.txtTransportadora.TabIndex = 18;
            this.txtTransportadora.TabStop = false;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(3, 67);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(79, 13);
            this.lblTransportadora.TabIndex = 17;
            this.lblTransportadora.Text = "Transportadora";
            // 
            // dtpDtFinal
            // 
            this.dtpDtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtFinal.Location = new System.Drawing.Point(200, 114);
            this.dtpDtFinal.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpDtFinal.Name = "dtpDtFinal";
            this.dtpDtFinal.Size = new System.Drawing.Size(95, 20);
            this.dtpDtFinal.TabIndex = 3;
            this.dtpDtFinal.Value = new System.DateTime(2019, 8, 28, 0, 0, 0, 0);
            // 
            // dtpDtInicial
            // 
            this.dtpDtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtInicial.Location = new System.Drawing.Point(73, 114);
            this.dtpDtInicial.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpDtInicial.Name = "dtpDtInicial";
            this.dtpDtInicial.Size = new System.Drawing.Size(95, 20);
            this.dtpDtInicial.TabIndex = 2;
            this.dtpDtInicial.Value = new System.DateTime(2019, 8, 28, 0, 0, 0, 0);
            // 
            // txtCodTransportadora
            // 
            this.txtCodTransportadora.Location = new System.Drawing.Point(6, 83);
            this.txtCodTransportadora.Name = "txtCodTransportadora";
            this.txtCodTransportadora.Size = new System.Drawing.Size(44, 20);
            this.txtCodTransportadora.TabIndex = 1;
            this.txtCodTransportadora.TextChanged += new System.EventHandler(this.TxtCodTransportadora_TextChanged);
            this.txtCodTransportadora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_PesquisaComEnter_KeyDown);
            this.txtCodTransportadora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(56, 43);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(465, 20);
            this.txtCliente.TabIndex = 15;
            this.txtCliente.TabStop = false;
            // 
            // lblCodCliente
            // 
            this.lblCodCliente.AutoSize = true;
            this.lblCodCliente.Location = new System.Drawing.Point(3, 27);
            this.lblCodCliente.Name = "lblCodCliente";
            this.lblCodCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCodCliente.TabIndex = 14;
            this.lblCodCliente.Text = "Cliente";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(6, 43);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(44, 20);
            this.txtCodCliente.TabIndex = 0;
            this.txtCodCliente.TextChanged += new System.EventHandler(this.txtCodCliente_TextChanged);
            this.txtCodCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_PesquisaComEnter_KeyDown);
            this.txtCodCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // btnFecharExportar
            // 
            this.btnFecharExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFecharExportar.BackColor = System.Drawing.Color.Gray;
            this.btnFecharExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFecharExportar.ForeColor = System.Drawing.Color.White;
            this.btnFecharExportar.Location = new System.Drawing.Point(774, 418);
            this.btnFecharExportar.Name = "btnFecharExportar";
            this.btnFecharExportar.Size = new System.Drawing.Size(80, 37);
            this.btnFecharExportar.TabIndex = 1;
            this.btnFecharExportar.Text = "Fechar";
            this.btnFecharExportar.UseVisualStyleBackColor = false;
            this.btnFecharExportar.Click += new System.EventHandler(this.BtnFecharExportar_Click);
            // 
            // dtpDataEntrega
            // 
            this.dtpDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataEntrega.Location = new System.Drawing.Point(6, 19);
            this.dtpDataEntrega.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpDataEntrega.Name = "dtpDataEntrega";
            this.dtpDataEntrega.Size = new System.Drawing.Size(95, 20);
            this.dtpDataEntrega.TabIndex = 7;
            this.dtpDataEntrega.Value = new System.DateTime(2019, 8, 28, 0, 0, 0, 0);
            // 
            // gpbDataEntrega
            // 
            this.gpbDataEntrega.Controls.Add(this.chkDataEntrega);
            this.gpbDataEntrega.Controls.Add(this.dtpDataEntrega);
            this.gpbDataEntrega.Location = new System.Drawing.Point(170, 402);
            this.gpbDataEntrega.Name = "gpbDataEntrega";
            this.gpbDataEntrega.Size = new System.Drawing.Size(114, 53);
            this.gpbDataEntrega.TabIndex = 51;
            this.gpbDataEntrega.TabStop = false;
            this.gpbDataEntrega.Text = "Data entrega";
            // 
            // chkDataEntrega
            // 
            this.chkDataEntrega.AutoSize = true;
            this.chkDataEntrega.Location = new System.Drawing.Point(75, 0);
            this.chkDataEntrega.Name = "chkDataEntrega";
            this.chkDataEntrega.Size = new System.Drawing.Size(15, 14);
            this.chkDataEntrega.TabIndex = 52;
            this.chkDataEntrega.UseVisualStyleBackColor = true;
            this.chkDataEntrega.CheckedChanged += new System.EventHandler(this.chkDataEntrega_CheckedChanged);
            // 
            // chkHelp
            // 
            this.chkHelp.AutoSize = true;
            this.chkHelp.Location = new System.Drawing.Point(784, 9);
            this.chkHelp.Name = "chkHelp";
            this.chkHelp.Size = new System.Drawing.Size(70, 17);
            this.chkHelp.TabIndex = 53;
            this.chkHelp.Text = "Ajude-me";
            this.chkHelp.UseVisualStyleBackColor = true;
            this.chkHelp.CheckedChanged += new System.EventHandler(this.chkHelp_CheckedChanged);
            // 
            // lblAjudaDataDeEntrega
            // 
            this.lblAjudaDataDeEntrega.AutoSize = true;
            this.lblAjudaDataDeEntrega.ForeColor = System.Drawing.Color.Red;
            this.lblAjudaDataDeEntrega.Location = new System.Drawing.Point(290, 418);
            this.lblAjudaDataDeEntrega.Name = "lblAjudaDataDeEntrega";
            this.lblAjudaDataDeEntrega.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAjudaDataDeEntrega.Size = new System.Drawing.Size(348, 13);
            this.lblAjudaDataDeEntrega.TabIndex = 54;
            this.lblAjudaDataDeEntrega.Text = "Atenção!! A data marcada será aplicada à todos os canhotos marcados.";
            // 
            // lblAjudaFiltros
            // 
            this.lblAjudaFiltros.AutoSize = true;
            this.lblAjudaFiltros.ForeColor = System.Drawing.Color.Red;
            this.lblAjudaFiltros.Location = new System.Drawing.Point(56, 16);
            this.lblAjudaFiltros.Name = "lblAjudaFiltros";
            this.lblAjudaFiltros.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAjudaFiltros.Size = new System.Drawing.Size(457, 13);
            this.lblAjudaFiltros.TabIndex = 55;
            this.lblAjudaFiltros.Text = "Filtros para pesquisa dos canhotos, ao modificar essas configurações a lista ao l" +
    "ado irá atualizar";
            // 
            // lblAjudaInformacoes
            // 
            this.lblAjudaInformacoes.AutoSize = true;
            this.lblAjudaInformacoes.ForeColor = System.Drawing.Color.Red;
            this.lblAjudaInformacoes.Location = new System.Drawing.Point(238, 24);
            this.lblAjudaInformacoes.Name = "lblAjudaInformacoes";
            this.lblAjudaInformacoes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblAjudaInformacoes.Size = new System.Drawing.Size(164, 13);
            this.lblAjudaInformacoes.TabIndex = 56;
            this.lblAjudaInformacoes.Text = "Informações da nota selecionada";
            // 
            // frmControleCanhotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 466);
            this.Controls.Add(this.lblAjudaDataDeEntrega);
            this.Controls.Add(this.chkHelp);
            this.Controls.Add(this.gpbDataEntrega);
            this.Controls.Add(this.btnFecharExportar);
            this.Controls.Add(this.gpbFiltros);
            this.Controls.Add(this.gpbInfo);
            this.Controls.Add(this.lblAno);
            this.Controls.Add(this.clbNotas);
            this.KeyPreview = true;
            this.Name = "frmControleCanhotos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Canhotos";
            this.Load += new System.EventHandler(this.FrmControleCanhotos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmControleDeCanhotos_KeyDown);
            this.gpbInfo.ResumeLayout(false);
            this.gpbInfo.PerformLayout();
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherTransportadora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).EndInit();
            this.gpbDataEntrega.ResumeLayout(false);
            this.gpbDataEntrega.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbNotas;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.GroupBox gpbInfo;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TextBox txtDat_Emissao;
        private System.Windows.Forms.TextBox txtCodClienteInfo;
        private System.Windows.Forms.TextBox txtCFOP;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblDatEmissao;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCFOP;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.TextBox txtClienteInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRegistroCanhoto;
        private System.Windows.Forms.TextBox txtRegistroCanhoto;
        private System.Windows.Forms.Label lblDatTransacao;
        private System.Windows.Forms.TextBox txtDatTransacao;
        private System.Windows.Forms.Label lblDatColeta;
        private System.Windows.Forms.TextBox txtDatColeta;
        private System.Windows.Forms.TextBox txtTransp;
        private System.Windows.Forms.Label lblTransp;
        private System.Windows.Forms.TextBox txtCodTransp;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.TextBox txtTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.TextBox txtCodTransportadora;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblCodCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDtFinal;
        private System.Windows.Forms.DateTimePicker dtpDtInicial;
        private System.Windows.Forms.Label lblDat_Emissao;
        private System.Windows.Forms.Label lblNF;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnFecharExportar;
        private System.Windows.Forms.PictureBox btnPreencherTransportadora;
        private System.Windows.Forms.PictureBox btnPreencherCliente;
        private System.Windows.Forms.DateTimePicker dtpDataEntrega;
        private System.Windows.Forms.GroupBox gpbDataEntrega;
        private System.Windows.Forms.CheckBox chkDataEntrega;
        private System.Windows.Forms.CheckBox chkHelp;
        private System.Windows.Forms.Label lblAjudaDataDeEntrega;
        private System.Windows.Forms.Label lblAjudaInformacoes;
        private System.Windows.Forms.Label lblAjudaFiltros;
    }
}