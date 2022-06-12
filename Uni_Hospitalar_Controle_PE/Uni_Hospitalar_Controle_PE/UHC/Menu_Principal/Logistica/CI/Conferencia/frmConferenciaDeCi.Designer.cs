namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Conferencia
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
            this.spcConferenciaDeCiFora = new System.Windows.Forms.SplitContainer();
            this.btnCriarCi = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.txtNF_Origem = new System.Windows.Forms.TextBox();
            this.lblNF_Origem = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnPreencherTransportadora = new System.Windows.Forms.PictureBox();
            this.btnPreencherCliente = new System.Windows.Forms.PictureBox();
            this.txtNFrefat = new System.Windows.Forms.TextBox();
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
            this.spcConferenciaDeCiDentro = new System.Windows.Forms.SplitContainer();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.lblAtrasada = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.chkPendente = new System.Windows.Forms.CheckBox();
            this.chkConcluido = new System.Windows.Forms.CheckBox();
            this.chkAguardandoFinanceiro = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.spcConferenciaDeCiFora)).BeginInit();
            this.spcConferenciaDeCiFora.Panel1.SuspendLayout();
            this.spcConferenciaDeCiFora.Panel2.SuspendLayout();
            this.spcConferenciaDeCiFora.SuspendLayout();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherTransportadora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcConferenciaDeCiDentro)).BeginInit();
            this.spcConferenciaDeCiDentro.Panel1.SuspendLayout();
            this.spcConferenciaDeCiDentro.Panel2.SuspendLayout();
            this.spcConferenciaDeCiDentro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // spcConferenciaDeCiFora
            // 
            this.spcConferenciaDeCiFora.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcConferenciaDeCiFora.Location = new System.Drawing.Point(0, 0);
            this.spcConferenciaDeCiFora.Name = "spcConferenciaDeCiFora";
            this.spcConferenciaDeCiFora.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcConferenciaDeCiFora.Panel1
            // 
            this.spcConferenciaDeCiFora.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.spcConferenciaDeCiFora.Panel1.Controls.Add(this.btnCriarCi);
            this.spcConferenciaDeCiFora.Panel1.Controls.Add(this.btnEditar);
            this.spcConferenciaDeCiFora.Panel1.Controls.Add(this.gpbFiltros);
            this.spcConferenciaDeCiFora.Panel1.Controls.Add(this.lblConferenciaDeCi);
            // 
            // spcConferenciaDeCiFora.Panel2
            // 
            this.spcConferenciaDeCiFora.Panel2.Controls.Add(this.spcConferenciaDeCiDentro);
            this.spcConferenciaDeCiFora.Size = new System.Drawing.Size(1084, 682);
            this.spcConferenciaDeCiFora.SplitterDistance = 186;
            this.spcConferenciaDeCiFora.TabIndex = 0;
            // 
            // btnCriarCi
            // 
            this.btnCriarCi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCriarCi.BackColor = System.Drawing.Color.IndianRed;
            this.btnCriarCi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriarCi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriarCi.ForeColor = System.Drawing.Color.White;
            this.btnCriarCi.Location = new System.Drawing.Point(975, 142);
            this.btnCriarCi.Name = "btnCriarCi";
            this.btnCriarCi.Size = new System.Drawing.Size(103, 38);
            this.btnCriarCi.TabIndex = 43;
            this.btnCriarCi.Text = "Criar CI";
            this.btnCriarCi.UseVisualStyleBackColor = false;
            this.btnCriarCi.Click += new System.EventHandler(this.btnCriarCi_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.Gray;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(866, 142);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(103, 38);
            this.btnEditar.TabIndex = 42;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.lblStatus);
            this.gpbFiltros.Controls.Add(this.chkAguardandoFinanceiro);
            this.gpbFiltros.Controls.Add(this.chkConcluido);
            this.gpbFiltros.Controls.Add(this.chkPendente);
            this.gpbFiltros.Controls.Add(this.txtNF_Origem);
            this.gpbFiltros.Controls.Add(this.lblNF_Origem);
            this.gpbFiltros.Controls.Add(this.btnLimpar);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.btnPreencherTransportadora);
            this.gpbFiltros.Controls.Add(this.btnPreencherCliente);
            this.gpbFiltros.Controls.Add(this.txtNFrefat);
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
            this.gpbFiltros.Size = new System.Drawing.Size(623, 150);
            this.gpbFiltros.TabIndex = 15;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // txtNF_Origem
            // 
            this.txtNF_Origem.Location = new System.Drawing.Point(201, 119);
            this.txtNF_Origem.Name = "txtNF_Origem";
            this.txtNF_Origem.Size = new System.Drawing.Size(69, 20);
            this.txtNF_Origem.TabIndex = 50;
            this.txtNF_Origem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            this.txtNF_Origem.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pesquisarComEnter_KeyUp);
            // 
            // lblNF_Origem
            // 
            this.lblNF_Origem.AutoSize = true;
            this.lblNF_Origem.Location = new System.Drawing.Point(198, 102);
            this.lblNF_Origem.Name = "lblNF_Origem";
            this.lblNF_Origem.Size = new System.Drawing.Size(57, 13);
            this.lblNF_Origem.TabIndex = 49;
            this.lblNF_Origem.Text = "NF Origem";
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
            this.btnLimpar.TabIndex = 48;
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
            this.btnPesquisar.TabIndex = 47;
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
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(7, 17);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente";
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
            this.lblConferenciaDeCi.TabIndex = 1;
            this.lblConferenciaDeCi.Text = "Conferência de CI";
            // 
            // spcConferenciaDeCiDentro
            // 
            this.spcConferenciaDeCiDentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcConferenciaDeCiDentro.Location = new System.Drawing.Point(0, 0);
            this.spcConferenciaDeCiDentro.Name = "spcConferenciaDeCiDentro";
            this.spcConferenciaDeCiDentro.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcConferenciaDeCiDentro.Panel1
            // 
            this.spcConferenciaDeCiDentro.Panel1.Controls.Add(this.dgvDados);
            // 
            // spcConferenciaDeCiDentro.Panel2
            // 
            this.spcConferenciaDeCiDentro.Panel2.Controls.Add(this.lblAtrasada);
            this.spcConferenciaDeCiDentro.Panel2.Controls.Add(this.pictureBox1);
            this.spcConferenciaDeCiDentro.Panel2.Controls.Add(this.btnFechar);
            this.spcConferenciaDeCiDentro.Size = new System.Drawing.Size(1084, 492);
            this.spcConferenciaDeCiDentro.SplitterDistance = 444;
            this.spcConferenciaDeCiDentro.TabIndex = 0;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(1084, 444);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvDados_ColumnHeaderMouseClick);
            this.dgvDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDados_MouseDoubleClick);
            // 
            // lblAtrasada
            // 
            this.lblAtrasada.AutoSize = true;
            this.lblAtrasada.Location = new System.Drawing.Point(34, 17);
            this.lblAtrasada.Name = "lblAtrasada";
            this.lblAtrasada.Size = new System.Drawing.Size(49, 13);
            this.lblAtrasada.TabIndex = 45;
            this.lblAtrasada.Text = "Atrasada";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.imgCorVermelho;
            this.pictureBox1.Location = new System.Drawing.Point(10, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 17);
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnFechar.Location = new System.Drawing.Point(975, 3);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(103, 38);
            this.btnFechar.TabIndex = 20;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // chkPendente
            // 
            this.chkPendente.AutoSize = true;
            this.chkPendente.Checked = true;
            this.chkPendente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPendente.Location = new System.Drawing.Point(475, 34);
            this.chkPendente.Name = "chkPendente";
            this.chkPendente.Size = new System.Drawing.Size(72, 17);
            this.chkPendente.TabIndex = 51;
            this.chkPendente.Text = "Pendente";
            this.chkPendente.UseVisualStyleBackColor = true;
            // 
            // chkConcluido
            // 
            this.chkConcluido.AutoSize = true;
            this.chkConcluido.Location = new System.Drawing.Point(475, 78);
            this.chkConcluido.Name = "chkConcluido";
            this.chkConcluido.Size = new System.Drawing.Size(75, 17);
            this.chkConcluido.TabIndex = 52;
            this.chkConcluido.Text = "Concluído";
            this.chkConcluido.UseVisualStyleBackColor = true;
            // 
            // chkAguardandoFinanceiro
            // 
            this.chkAguardandoFinanceiro.AutoSize = true;
            this.chkAguardandoFinanceiro.Location = new System.Drawing.Point(475, 55);
            this.chkAguardandoFinanceiro.Name = "chkAguardandoFinanceiro";
            this.chkAguardandoFinanceiro.Size = new System.Drawing.Size(136, 17);
            this.chkAguardandoFinanceiro.TabIndex = 53;
            this.chkAguardandoFinanceiro.Text = "Aguardando Financeiro";
            this.chkAguardandoFinanceiro.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(475, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 54;
            this.lblStatus.Text = "Status";
            // 
            // frmConferenciaDeCi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 682);
            this.Controls.Add(this.spcConferenciaDeCiFora);
            this.KeyPreview = true;
            this.Name = "frmConferenciaDeCi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CI";
            this.Load += new System.EventHandler(this.frmConferenciaDeCi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmConferenciaDeCi_KeyDown);
            this.spcConferenciaDeCiFora.Panel1.ResumeLayout(false);
            this.spcConferenciaDeCiFora.Panel1.PerformLayout();
            this.spcConferenciaDeCiFora.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcConferenciaDeCiFora)).EndInit();
            this.spcConferenciaDeCiFora.ResumeLayout(false);
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherTransportadora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).EndInit();
            this.spcConferenciaDeCiDentro.Panel1.ResumeLayout(false);
            this.spcConferenciaDeCiDentro.Panel2.ResumeLayout(false);
            this.spcConferenciaDeCiDentro.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcConferenciaDeCiDentro)).EndInit();
            this.spcConferenciaDeCiDentro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcConferenciaDeCiFora;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtNocorrencia;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.Label lblNocorrencia;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtNFrefat;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.Label lblNFrefat;
        private System.Windows.Forms.TextBox txtCodTransportadora;
        private System.Windows.Forms.TextBox txtNFdevol;
        private System.Windows.Forms.TextBox txtTransportadora;
        private System.Windows.Forms.Label lblNFdevol;
        private System.Windows.Forms.Label lblConferenciaDeCi;
        private System.Windows.Forms.SplitContainer spcConferenciaDeCiDentro;
        private System.Windows.Forms.PictureBox btnPreencherCliente;
        private System.Windows.Forms.PictureBox btnPreencherTransportadora;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnCriarCi;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblAtrasada;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNF_Origem;
        private System.Windows.Forms.Label lblNF_Origem;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkAguardandoFinanceiro;
        private System.Windows.Forms.CheckBox chkConcluido;
        private System.Windows.Forms.CheckBox chkPendente;
    }
}