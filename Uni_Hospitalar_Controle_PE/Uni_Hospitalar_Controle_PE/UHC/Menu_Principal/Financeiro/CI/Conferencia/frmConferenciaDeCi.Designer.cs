namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.CI
{
    partial class frmConferenciaDeCi
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
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.txtNFOrigem = new System.Windows.Forms.TextBox();
            this.lblNFOrigem = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnPreencherTransportadora = new System.Windows.Forms.PictureBox();
            this.btnPreencherCliente = new System.Windows.Forms.PictureBox();
            this.txtNFrefat = new System.Windows.Forms.TextBox();
            this.gpbStatus = new System.Windows.Forms.GroupBox();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.rdbConcluido = new System.Windows.Forms.RadioButton();
            this.rdbAguardandoFinanceiro = new System.Windows.Forms.RadioButton();
            this.rdbPendente = new System.Windows.Forms.RadioButton();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtNocorrencia = new System.Windows.Forms.TextBox();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.lblNocorrencia = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.lblNFrefat = new System.Windows.Forms.Label();
            this.txtCodTransportadora = new System.Windows.Forms.TextBox();
            this.txtNFdevol = new System.Windows.Forms.TextBox();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.lblNFdevol = new System.Windows.Forms.Label();
            this.lblConferenciaDeCi = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.imgVerde = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblConcluido = new System.Windows.Forms.Label();
            this.lblPendente = new System.Windows.Forms.Label();
            this.lblAguardandoFinanceiro = new System.Windows.Forms.Label();
            this.lsbNF_Devolucao = new System.Windows.Forms.ListBox();
            this.lblNotasDeDevolucao = new System.Windows.Forms.Label();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherTransportadora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).BeginInit();
            this.gpbStatus.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVerde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.txtNFOrigem);
            this.gpbFiltros.Controls.Add(this.lblNFOrigem);
            this.gpbFiltros.Controls.Add(this.btnLimpar);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.btnPreencherTransportadora);
            this.gpbFiltros.Controls.Add(this.btnPreencherCliente);
            this.gpbFiltros.Controls.Add(this.txtNFrefat);
            this.gpbFiltros.Controls.Add(this.gpbStatus);
            this.gpbFiltros.Controls.Add(this.lblCliente);
            this.gpbFiltros.Controls.Add(this.txtNocorrencia);
            this.gpbFiltros.Controls.Add(this.txtCodCliente);
            this.gpbFiltros.Controls.Add(this.lblNocorrencia);
            this.gpbFiltros.Controls.Add(this.txtCliente);
            this.gpbFiltros.Controls.Add(this.lblTransportadora);
            this.gpbFiltros.Controls.Add(this.lblNFrefat);
            this.gpbFiltros.Controls.Add(this.txtCodTransportadora);
            this.gpbFiltros.Controls.Add(this.txtNFdevol);
            this.gpbFiltros.Controls.Add(this.txtTransportadora);
            this.gpbFiltros.Controls.Add(this.lblNFdevol);
            this.gpbFiltros.Location = new System.Drawing.Point(7, 33);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(625, 150);
            this.gpbFiltros.TabIndex = 17;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // txtNFOrigem
            // 
            this.txtNFOrigem.Location = new System.Drawing.Point(201, 119);
            this.txtNFOrigem.Name = "txtNFOrigem";
            this.txtNFOrigem.Size = new System.Drawing.Size(52, 20);
            this.txtNFOrigem.TabIndex = 52;
            this.txtNFOrigem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            this.txtNFOrigem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pesquisarComEnter_KeyUp);
            // 
            // lblNFOrigem
            // 
            this.lblNFOrigem.AutoSize = true;
            this.lblNFOrigem.Location = new System.Drawing.Point(201, 102);
            this.lblNFOrigem.Name = "lblNFOrigem";
            this.lblNFOrigem.Size = new System.Drawing.Size(57, 13);
            this.lblNFOrigem.TabIndex = 51;
            this.lblNFOrigem.Text = "NF Origem";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.BackColor = System.Drawing.Color.Gray;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.ForeColor = System.Drawing.Color.White;
            this.btnLimpar.Location = new System.Drawing.Point(448, 107);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(80, 37);
            this.btnLimpar.TabIndex = 50;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(534, 107);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 37);
            this.btnPesquisar.TabIndex = 49;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnPreencherTransportadora
            // 
            this.btnPreencherTransportadora.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherTransportadora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherTransportadora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherTransportadora.Location = new System.Drawing.Point(385, 78);
            this.btnPreencherTransportadora.Name = "btnPreencherTransportadora";
            this.btnPreencherTransportadora.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherTransportadora.TabIndex = 17;
            this.btnPreencherTransportadora.TabStop = false;
            this.btnPreencherTransportadora.Click += new System.EventHandler(this.btnPreencherTransportadora_Click);
            // 
            // btnPreencherCliente
            // 
            this.btnPreencherCliente.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherCliente.Location = new System.Drawing.Point(385, 34);
            this.btnPreencherCliente.Name = "btnPreencherCliente";
            this.btnPreencherCliente.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherCliente.TabIndex = 16;
            this.btnPreencherCliente.TabStop = false;
            this.btnPreencherCliente.Click += new System.EventHandler(this.btnPreencherCliente_Click);
            // 
            // txtNFrefat
            // 
            this.txtNFrefat.Location = new System.Drawing.Point(68, 119);
            this.txtNFrefat.Name = "txtNFrefat";
            this.txtNFrefat.Size = new System.Drawing.Size(52, 20);
            this.txtNFrefat.TabIndex = 11;
            this.txtNFrefat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            this.txtNFrefat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pesquisarComEnter_KeyUp);
            // 
            // gpbStatus
            // 
            this.gpbStatus.Controls.Add(this.chkStatus);
            this.gpbStatus.Controls.Add(this.rdbConcluido);
            this.gpbStatus.Controls.Add(this.rdbAguardandoFinanceiro);
            this.gpbStatus.Controls.Add(this.rdbPendente);
            this.gpbStatus.Location = new System.Drawing.Point(471, 13);
            this.gpbStatus.Name = "gpbStatus";
            this.gpbStatus.Size = new System.Drawing.Size(143, 81);
            this.gpbStatus.TabIndex = 14;
            this.gpbStatus.TabStop = false;
            this.gpbStatus.Text = "Status";
            this.gpbStatus.Visible = false;
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Location = new System.Drawing.Point(41, 0);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(15, 14);
            this.chkStatus.TabIndex = 15;
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // rdbConcluido
            // 
            this.rdbConcluido.AutoSize = true;
            this.rdbConcluido.Enabled = false;
            this.rdbConcluido.Location = new System.Drawing.Point(6, 52);
            this.rdbConcluido.Name = "rdbConcluido";
            this.rdbConcluido.Size = new System.Drawing.Size(74, 17);
            this.rdbConcluido.TabIndex = 2;
            this.rdbConcluido.Text = "Concluído";
            this.rdbConcluido.UseVisualStyleBackColor = true;
            // 
            // rdbAguardandoFinanceiro
            // 
            this.rdbAguardandoFinanceiro.AutoSize = true;
            this.rdbAguardandoFinanceiro.Enabled = false;
            this.rdbAguardandoFinanceiro.Location = new System.Drawing.Point(6, 34);
            this.rdbAguardandoFinanceiro.Name = "rdbAguardandoFinanceiro";
            this.rdbAguardandoFinanceiro.Size = new System.Drawing.Size(132, 17);
            this.rdbAguardandoFinanceiro.TabIndex = 1;
            this.rdbAguardandoFinanceiro.Text = "Aguardando financeiro";
            this.rdbAguardandoFinanceiro.UseVisualStyleBackColor = true;
            // 
            // rdbPendente
            // 
            this.rdbPendente.AutoSize = true;
            this.rdbPendente.Enabled = false;
            this.rdbPendente.Location = new System.Drawing.Point(6, 16);
            this.rdbPendente.Name = "rdbPendente";
            this.rdbPendente.Size = new System.Drawing.Size(71, 17);
            this.rdbPendente.TabIndex = 0;
            this.rdbPendente.Text = "Pendente";
            this.rdbPendente.UseVisualStyleBackColor = true;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(7, 17);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente";
            this.lblCliente.Click += new System.EventHandler(this.lblCliente_Click);
            // 
            // txtNocorrencia
            // 
            this.txtNocorrencia.Location = new System.Drawing.Point(126, 119);
            this.txtNocorrencia.Name = "txtNocorrencia";
            this.txtNocorrencia.Size = new System.Drawing.Size(69, 20);
            this.txtNocorrencia.TabIndex = 13;
            this.txtNocorrencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            this.txtNocorrencia.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pesquisarComEnter_KeyUp);
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(10, 34);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(44, 20);
            this.txtCodCliente.TabIndex = 3;
            this.txtCodCliente.TextChanged += new System.EventHandler(this.txtCodCliente_TextChanged);
            this.txtCodCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            this.txtCodCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pesquisarComEnter_KeyUp);
            // 
            // lblNocorrencia
            // 
            this.lblNocorrencia.AutoSize = true;
            this.lblNocorrencia.Location = new System.Drawing.Point(123, 102);
            this.lblNocorrencia.Name = "lblNocorrencia";
            this.lblNocorrencia.Size = new System.Drawing.Size(72, 13);
            this.lblNocorrencia.TabIndex = 12;
            this.lblNocorrencia.Text = "Nº ocorrência";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(60, 34);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(324, 20);
            this.txtCliente.TabIndex = 4;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            this.txtCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pesquisarComEnter_KeyUp);
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(7, 61);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(79, 13);
            this.lblTransportadora.TabIndex = 5;
            this.lblTransportadora.Text = "Transportadora";
            // 
            // lblNFrefat
            // 
            this.lblNFrefat.AutoSize = true;
            this.lblNFrefat.Location = new System.Drawing.Point(67, 102);
            this.lblNFrefat.Name = "lblNFrefat";
            this.lblNFrefat.Size = new System.Drawing.Size(53, 13);
            this.lblNFrefat.TabIndex = 10;
            this.lblNFrefat.Text = "NF Refat.";
            // 
            // txtCodTransportadora
            // 
            this.txtCodTransportadora.Location = new System.Drawing.Point(10, 78);
            this.txtCodTransportadora.Name = "txtCodTransportadora";
            this.txtCodTransportadora.Size = new System.Drawing.Size(44, 20);
            this.txtCodTransportadora.TabIndex = 6;
            this.txtCodTransportadora.TextChanged += new System.EventHandler(this.txtCodTransportadora_TextChanged);
            this.txtCodTransportadora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            this.txtCodTransportadora.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pesquisarComEnter_KeyUp);
            // 
            // txtNFdevol
            // 
            this.txtNFdevol.Location = new System.Drawing.Point(10, 119);
            this.txtNFdevol.Name = "txtNFdevol";
            this.txtNFdevol.Size = new System.Drawing.Size(52, 20);
            this.txtNFdevol.TabIndex = 9;
            this.txtNFdevol.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            this.txtNFdevol.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pesquisarComEnter_KeyUp);
            // 
            // txtTransportadora
            // 
            this.txtTransportadora.Location = new System.Drawing.Point(60, 78);
            this.txtTransportadora.Name = "txtTransportadora";
            this.txtTransportadora.ReadOnly = true;
            this.txtTransportadora.Size = new System.Drawing.Size(324, 20);
            this.txtTransportadora.TabIndex = 7;
            this.txtTransportadora.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pesquisarComEnter_KeyUp);
            // 
            // lblNFdevol
            // 
            this.lblNFdevol.AutoSize = true;
            this.lblNFdevol.Location = new System.Drawing.Point(7, 102);
            this.lblNFdevol.Name = "lblNFdevol";
            this.lblNFdevol.Size = new System.Drawing.Size(55, 13);
            this.lblNFdevol.TabIndex = 8;
            this.lblNFdevol.Text = "NF Devol.";
            // 
            // lblConferenciaDeCi
            // 
            this.lblConferenciaDeCi.AutoSize = true;
            this.lblConferenciaDeCi.BackColor = System.Drawing.Color.Gainsboro;
            this.lblConferenciaDeCi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConferenciaDeCi.Location = new System.Drawing.Point(3, 5);
            this.lblConferenciaDeCi.Name = "lblConferenciaDeCi";
            this.lblConferenciaDeCi.Size = new System.Drawing.Size(201, 25);
            this.lblConferenciaDeCi.TabIndex = 16;
            this.lblConferenciaDeCi.Text = "Conferência de CI";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.dgvDados);
            this.panel1.Location = new System.Drawing.Point(8, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1384, 495);
            this.panel1.TabIndex = 18;
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
            this.dgvDados.Size = new System.Drawing.Size(1384, 495);
            this.dgvDados.TabIndex = 2;
            this.dgvDados.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDados_CellEnter);
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvDados_ColumnHeaderMouseClick);
            this.dgvDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDados_MouseDoubleClick);
            // 
            // imgVerde
            // 
            this.imgVerde.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.imgCorVerde;
            this.imgVerde.Location = new System.Drawing.Point(657, 166);
            this.imgVerde.Name = "imgVerde";
            this.imgVerde.Size = new System.Drawing.Size(18, 17);
            this.imgVerde.TabIndex = 19;
            this.imgVerde.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.imgCorVermelho;
            this.pictureBox1.Location = new System.Drawing.Point(824, 166);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 17);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.imgCorCinza;
            this.pictureBox2.Location = new System.Drawing.Point(741, 166);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 17);
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // lblConcluido
            // 
            this.lblConcluido.AutoSize = true;
            this.lblConcluido.Location = new System.Drawing.Point(679, 168);
            this.lblConcluido.Name = "lblConcluido";
            this.lblConcluido.Size = new System.Drawing.Size(56, 13);
            this.lblConcluido.TabIndex = 22;
            this.lblConcluido.Text = "Concluído";
            // 
            // lblPendente
            // 
            this.lblPendente.AutoSize = true;
            this.lblPendente.Location = new System.Drawing.Point(765, 168);
            this.lblPendente.Name = "lblPendente";
            this.lblPendente.Size = new System.Drawing.Size(53, 13);
            this.lblPendente.TabIndex = 23;
            this.lblPendente.Text = "Pendente";
            // 
            // lblAguardandoFinanceiro
            // 
            this.lblAguardandoFinanceiro.AutoSize = true;
            this.lblAguardandoFinanceiro.Location = new System.Drawing.Point(848, 168);
            this.lblAguardandoFinanceiro.Name = "lblAguardandoFinanceiro";
            this.lblAguardandoFinanceiro.Size = new System.Drawing.Size(114, 13);
            this.lblAguardandoFinanceiro.TabIndex = 24;
            this.lblAguardandoFinanceiro.Text = "Aguardando financeiro";
            // 
            // lsbNF_Devolucao
            // 
            this.lsbNF_Devolucao.FormattingEnabled = true;
            this.lsbNF_Devolucao.Location = new System.Drawing.Point(638, 72);
            this.lsbNF_Devolucao.Name = "lsbNF_Devolucao";
            this.lsbNF_Devolucao.Size = new System.Drawing.Size(68, 43);
            this.lsbNF_Devolucao.TabIndex = 25;
            // 
            // lblNotasDeDevolucao
            // 
            this.lblNotasDeDevolucao.AutoSize = true;
            this.lblNotasDeDevolucao.Location = new System.Drawing.Point(638, 56);
            this.lblNotasDeDevolucao.Name = "lblNotasDeDevolucao";
            this.lblNotasDeDevolucao.Size = new System.Drawing.Size(109, 13);
            this.lblNotasDeDevolucao.TabIndex = 26;
            this.lblNotasDeDevolucao.Text = "Nota(s) de devolução";
            // 
            // frmConferenciaDeCi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1404, 696);
            this.Controls.Add(this.lblNotasDeDevolucao);
            this.Controls.Add(this.lsbNF_Devolucao);
            this.Controls.Add(this.lblAguardandoFinanceiro);
            this.Controls.Add(this.lblPendente);
            this.Controls.Add(this.lblConcluido);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.imgVerde);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gpbFiltros);
            this.Controls.Add(this.lblConferenciaDeCi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmConferenciaDeCi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConferenciaDeCi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConferenciaDeCi_KeyDown);
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherTransportadora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).EndInit();
            this.gpbStatus.ResumeLayout(false);
            this.gpbStatus.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgVerde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.PictureBox btnPreencherTransportadora;
        private System.Windows.Forms.PictureBox btnPreencherCliente;
        private System.Windows.Forms.TextBox txtNFrefat;
        private System.Windows.Forms.GroupBox gpbStatus;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.RadioButton rdbConcluido;
        private System.Windows.Forms.RadioButton rdbAguardandoFinanceiro;
        private System.Windows.Forms.RadioButton rdbPendente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtNocorrencia;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.Label lblNocorrencia;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.Label lblNFrefat;
        private System.Windows.Forms.TextBox txtCodTransportadora;
        private System.Windows.Forms.TextBox txtNFdevol;
        private System.Windows.Forms.TextBox txtTransportadora;
        private System.Windows.Forms.Label lblNFdevol;
        private System.Windows.Forms.Label lblConferenciaDeCi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.PictureBox imgVerde;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblConcluido;
        private System.Windows.Forms.Label lblPendente;
        private System.Windows.Forms.Label lblAguardandoFinanceiro;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.ListBox lsbNF_Devolucao;
        private System.Windows.Forms.Label lblNotasDeDevolucao;
        private System.Windows.Forms.TextBox txtNFOrigem;
        private System.Windows.Forms.Label lblNFOrigem;
    }
}