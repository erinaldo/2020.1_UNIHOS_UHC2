namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Fretes.ConferenciaDeFretes
{
    partial class frmNewConferenciaFretes
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
            this.lblHelpObservacao = new System.Windows.Forms.Label();
            this.lblHelpObsFiltroData = new System.Windows.Forms.Label();
            this.lblHelpPadrao = new System.Windows.Forms.Label();
            this.lblHelpCalculoPercentual = new System.Windows.Forms.Label();
            this.lblHelpCalculadoraPercentual = new System.Windows.Forms.Label();
            this.lblHelpImportar = new System.Windows.Forms.Label();
            this.chkHelp = new System.Windows.Forms.CheckBox();
            this.txtPorcentagemValor = new System.Windows.Forms.TextBox();
            this.lsbExcept = new System.Windows.Forms.ListBox();
            this.chkCalculadora = new System.Windows.Forms.CheckBox();
            this.gpbCalculadoraPercent = new System.Windows.Forms.GroupBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.txtPercentCalc = new System.Windows.Forms.TextBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.btnAddObs = new System.Windows.Forms.Button();
            this.lblObservacaoPadrao = new System.Windows.Forms.Label();
            this.txtObsPadrao = new System.Windows.Forms.TextBox();
            this.btnMarcar = new System.Windows.Forms.Button();
            this.lblConferenciaDeFretes = new System.Windows.Forms.Label();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.lblHelpFiltrosPesquisa = new System.Windows.Forms.Label();
            this.btnImportar = new System.Windows.Forms.Button();
            this.lblNF = new System.Windows.Forms.Label();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.btnRecalc = new System.Windows.Forms.Button();
            this.lblHelpRecalcular = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtTotalFrete = new System.Windows.Forms.TextBox();
            this.lblTotalFrete = new System.Windows.Forms.Label();
            this.dtpDtFinal = new System.Windows.Forms.DateTimePicker();
            this.btnProcurarTransportadora = new System.Windows.Forms.PictureBox();
            this.dtpDtInicial = new System.Windows.Forms.DateTimePicker();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.lblDtFinal = new System.Windows.Forms.Label();
            this.txtCodTransportadora = new System.Windows.Forms.TextBox();
            this.lblDtInicial = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.lblHelpValoresAlterados = new System.Windows.Forms.Label();
            this.lblHelpObsCores = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpbCalculadoraPercent.SuspendLayout();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcurarTransportadora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblHelpObservacao);
            this.splitContainer1.Panel1.Controls.Add(this.lblHelpObsFiltroData);
            this.splitContainer1.Panel1.Controls.Add(this.lblHelpPadrao);
            this.splitContainer1.Panel1.Controls.Add(this.lblHelpCalculoPercentual);
            this.splitContainer1.Panel1.Controls.Add(this.lblHelpCalculadoraPercentual);
            this.splitContainer1.Panel1.Controls.Add(this.lblHelpImportar);
            this.splitContainer1.Panel1.Controls.Add(this.chkHelp);
            this.splitContainer1.Panel1.Controls.Add(this.txtPorcentagemValor);
            this.splitContainer1.Panel1.Controls.Add(this.lsbExcept);
            this.splitContainer1.Panel1.Controls.Add(this.chkCalculadora);
            this.splitContainer1.Panel1.Controls.Add(this.gpbCalculadoraPercent);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddObs);
            this.splitContainer1.Panel1.Controls.Add(this.lblObservacaoPadrao);
            this.splitContainer1.Panel1.Controls.Add(this.txtObsPadrao);
            this.splitContainer1.Panel1.Controls.Add(this.btnMarcar);
            this.splitContainer1.Panel1.Controls.Add(this.lblConferenciaDeFretes);
            this.splitContainer1.Panel1.Controls.Add(this.gpbFiltros);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1035, 654);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblHelpObservacao
            // 
            this.lblHelpObservacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHelpObservacao.AutoSize = true;
            this.lblHelpObservacao.ForeColor = System.Drawing.Color.Red;
            this.lblHelpObservacao.Location = new System.Drawing.Point(885, 94);
            this.lblHelpObservacao.Name = "lblHelpObservacao";
            this.lblHelpObservacao.Size = new System.Drawing.Size(135, 13);
            this.lblHelpObservacao.TabIndex = 80;
            this.lblHelpObservacao.Text = "O campo pode ser alterado";
            // 
            // lblHelpObsFiltroData
            // 
            this.lblHelpObsFiltroData.AutoSize = true;
            this.lblHelpObsFiltroData.ForeColor = System.Drawing.Color.Red;
            this.lblHelpObsFiltroData.Location = new System.Drawing.Point(102, 187);
            this.lblHelpObsFiltroData.Name = "lblHelpObsFiltroData";
            this.lblHelpObsFiltroData.Size = new System.Drawing.Size(248, 13);
            this.lblHelpObsFiltroData.TabIndex = 75;
            this.lblHelpObsFiltroData.Text = "Obs.: Todos os filtros respeitam o intervalo da data.";
            // 
            // lblHelpPadrao
            // 
            this.lblHelpPadrao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHelpPadrao.AutoSize = true;
            this.lblHelpPadrao.ForeColor = System.Drawing.Color.Red;
            this.lblHelpPadrao.Location = new System.Drawing.Point(778, 29);
            this.lblHelpPadrao.Name = "lblHelpPadrao";
            this.lblHelpPadrao.Size = new System.Drawing.Size(146, 13);
            this.lblHelpPadrao.TabIndex = 79;
            this.lblHelpPadrao.Text = "Selecione uma opção padrão";
            // 
            // lblHelpCalculoPercentual
            // 
            this.lblHelpCalculoPercentual.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblHelpCalculoPercentual.AutoSize = true;
            this.lblHelpCalculoPercentual.ForeColor = System.Drawing.Color.Red;
            this.lblHelpCalculoPercentual.Location = new System.Drawing.Point(532, 168);
            this.lblHelpCalculoPercentual.Name = "lblHelpCalculoPercentual";
            this.lblHelpCalculoPercentual.Size = new System.Drawing.Size(200, 13);
            this.lblHelpCalculoPercentual.TabIndex = 78;
            this.lblHelpCalculoPercentual.Text = "Mostra o % calculado em cima do Vlr. NF";
            // 
            // lblHelpCalculadoraPercentual
            // 
            this.lblHelpCalculadoraPercentual.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblHelpCalculadoraPercentual.AutoSize = true;
            this.lblHelpCalculadoraPercentual.ForeColor = System.Drawing.Color.Red;
            this.lblHelpCalculadoraPercentual.Location = new System.Drawing.Point(424, 112);
            this.lblHelpCalculadoraPercentual.Name = "lblHelpCalculadoraPercentual";
            this.lblHelpCalculadoraPercentual.Size = new System.Drawing.Size(162, 13);
            this.lblHelpCalculadoraPercentual.TabIndex = 77;
            this.lblHelpCalculadoraPercentual.Text = "Importar layout de transportadora";
            // 
            // lblHelpImportar
            // 
            this.lblHelpImportar.AutoSize = true;
            this.lblHelpImportar.ForeColor = System.Drawing.Color.Red;
            this.lblHelpImportar.Location = new System.Drawing.Point(244, 37);
            this.lblHelpImportar.Name = "lblHelpImportar";
            this.lblHelpImportar.Size = new System.Drawing.Size(162, 13);
            this.lblHelpImportar.TabIndex = 74;
            this.lblHelpImportar.Text = "Importar layout de transportadora";
            // 
            // chkHelp
            // 
            this.chkHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHelp.AutoSize = true;
            this.chkHelp.Location = new System.Drawing.Point(953, 9);
            this.chkHelp.Name = "chkHelp";
            this.chkHelp.Size = new System.Drawing.Size(70, 17);
            this.chkHelp.TabIndex = 73;
            this.chkHelp.Text = "Ajude-me";
            this.chkHelp.UseVisualStyleBackColor = true;
            this.chkHelp.CheckedChanged += new System.EventHandler(this.chkHelp_CheckedChanged);
            // 
            // txtPorcentagemValor
            // 
            this.txtPorcentagemValor.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPorcentagemValor.Location = new System.Drawing.Point(532, 184);
            this.txtPorcentagemValor.Name = "txtPorcentagemValor";
            this.txtPorcentagemValor.ReadOnly = true;
            this.txtPorcentagemValor.Size = new System.Drawing.Size(79, 20);
            this.txtPorcentagemValor.TabIndex = 71;
            // 
            // lsbExcept
            // 
            this.lsbExcept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbExcept.FormattingEnabled = true;
            this.lsbExcept.Items.AddRange(new object[] {
            "Exceção: Percentual aplicado 2,00 %",
            "Exceção: Frete negociado"});
            this.lsbExcept.Location = new System.Drawing.Point(778, 45);
            this.lsbExcept.Name = "lsbExcept";
            this.lsbExcept.Size = new System.Drawing.Size(245, 43);
            this.lsbExcept.TabIndex = 72;
            this.lsbExcept.SelectedIndexChanged += new System.EventHandler(this.lsbExcept_SelectedIndexChanged);
            // 
            // chkCalculadora
            // 
            this.chkCalculadora.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCalculadora.AutoSize = true;
            this.chkCalculadora.Location = new System.Drawing.Point(506, 127);
            this.chkCalculadora.Name = "chkCalculadora";
            this.chkCalculadora.Size = new System.Drawing.Size(15, 14);
            this.chkCalculadora.TabIndex = 71;
            this.chkCalculadora.UseVisualStyleBackColor = true;
            this.chkCalculadora.CheckedChanged += new System.EventHandler(this.chkCalculadora_CheckedChanged);
            // 
            // gpbCalculadoraPercent
            // 
            this.gpbCalculadoraPercent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gpbCalculadoraPercent.Controls.Add(this.txtResultado);
            this.gpbCalculadoraPercent.Controls.Add(this.txtPercentCalc);
            this.gpbCalculadoraPercent.Controls.Add(this.lblPercent);
            this.gpbCalculadoraPercent.Location = new System.Drawing.Point(427, 128);
            this.gpbCalculadoraPercent.Name = "gpbCalculadoraPercent";
            this.gpbCalculadoraPercent.Size = new System.Drawing.Size(99, 80);
            this.gpbCalculadoraPercent.TabIndex = 70;
            this.gpbCalculadoraPercent.TabStop = false;
            this.gpbCalculadoraPercent.Text = "Calculadora";
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(6, 55);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(79, 20);
            this.txtResultado.TabIndex = 70;
            // 
            // txtPercentCalc
            // 
            this.txtPercentCalc.Location = new System.Drawing.Point(6, 19);
            this.txtPercentCalc.Name = "txtPercentCalc";
            this.txtPercentCalc.Size = new System.Drawing.Size(38, 20);
            this.txtPercentCalc.TabIndex = 68;
            this.txtPercentCalc.TextChanged += new System.EventHandler(this.txtPercentCalc_TextChanged);
            this.txtPercentCalc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumerosDecimais_KeyPress);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(50, 22);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(15, 13);
            this.lblPercent.TabIndex = 69;
            this.lblPercent.Text = "%";
            // 
            // btnAddObs
            // 
            this.btnAddObs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddObs.Location = new System.Drawing.Point(935, 185);
            this.btnAddObs.Name = "btnAddObs";
            this.btnAddObs.Size = new System.Drawing.Size(88, 23);
            this.btnAddObs.TabIndex = 67;
            this.btnAddObs.Text = "Add Obs";
            this.btnAddObs.UseVisualStyleBackColor = true;
            this.btnAddObs.Click += new System.EventHandler(this.btnAddObs_Click);
            // 
            // lblObservacaoPadrao
            // 
            this.lblObservacaoPadrao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblObservacaoPadrao.AutoSize = true;
            this.lblObservacaoPadrao.Location = new System.Drawing.Point(778, 91);
            this.lblObservacaoPadrao.Name = "lblObservacaoPadrao";
            this.lblObservacaoPadrao.Size = new System.Drawing.Size(101, 13);
            this.lblObservacaoPadrao.TabIndex = 66;
            this.lblObservacaoPadrao.Text = "Observação padrão";
            // 
            // txtObsPadrao
            // 
            this.txtObsPadrao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtObsPadrao.Location = new System.Drawing.Point(778, 110);
            this.txtObsPadrao.Multiline = true;
            this.txtObsPadrao.Name = "txtObsPadrao";
            this.txtObsPadrao.Size = new System.Drawing.Size(245, 69);
            this.txtObsPadrao.TabIndex = 65;
            // 
            // btnMarcar
            // 
            this.btnMarcar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMarcar.Location = new System.Drawing.Point(875, 185);
            this.btnMarcar.Name = "btnMarcar";
            this.btnMarcar.Size = new System.Drawing.Size(54, 23);
            this.btnMarcar.TabIndex = 64;
            this.btnMarcar.Text = "Marcar";
            this.btnMarcar.UseVisualStyleBackColor = true;
            this.btnMarcar.Click += new System.EventHandler(this.btnMarcar_Click);
            // 
            // lblConferenciaDeFretes
            // 
            this.lblConferenciaDeFretes.AutoSize = true;
            this.lblConferenciaDeFretes.BackColor = System.Drawing.Color.Gainsboro;
            this.lblConferenciaDeFretes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConferenciaDeFretes.Location = new System.Drawing.Point(8, 9);
            this.lblConferenciaDeFretes.Name = "lblConferenciaDeFretes";
            this.lblConferenciaDeFretes.Size = new System.Drawing.Size(246, 25);
            this.lblConferenciaDeFretes.TabIndex = 19;
            this.lblConferenciaDeFretes.Text = "Conferência de Fretes";
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.lblHelpFiltrosPesquisa);
            this.gpbFiltros.Controls.Add(this.btnImportar);
            this.gpbFiltros.Controls.Add(this.lblNF);
            this.gpbFiltros.Controls.Add(this.txtNF);
            this.gpbFiltros.Controls.Add(this.btnRecalc);
            this.gpbFiltros.Controls.Add(this.lblHelpRecalcular);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.txtTotalFrete);
            this.gpbFiltros.Controls.Add(this.lblTotalFrete);
            this.gpbFiltros.Controls.Add(this.dtpDtFinal);
            this.gpbFiltros.Controls.Add(this.btnProcurarTransportadora);
            this.gpbFiltros.Controls.Add(this.dtpDtInicial);
            this.gpbFiltros.Controls.Add(this.lblTransportadora);
            this.gpbFiltros.Controls.Add(this.txtTransportadora);
            this.gpbFiltros.Controls.Add(this.lblDtFinal);
            this.gpbFiltros.Controls.Add(this.txtCodTransportadora);
            this.gpbFiltros.Controls.Add(this.lblDtInicial);
            this.gpbFiltros.Location = new System.Drawing.Point(3, 43);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(347, 141);
            this.gpbFiltros.TabIndex = 0;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // lblHelpFiltrosPesquisa
            // 
            this.lblHelpFiltrosPesquisa.AutoSize = true;
            this.lblHelpFiltrosPesquisa.ForeColor = System.Drawing.Color.Red;
            this.lblHelpFiltrosPesquisa.Location = new System.Drawing.Point(92, 15);
            this.lblHelpFiltrosPesquisa.Name = "lblHelpFiltrosPesquisa";
            this.lblHelpFiltrosPesquisa.Size = new System.Drawing.Size(103, 13);
            this.lblHelpFiltrosPesquisa.TabIndex = 76;
            this.lblHelpFiltrosPesquisa.Text = "Filtros para pesquisa";
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnImportar.BackColor = System.Drawing.Color.Gray;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F);
            this.btnImportar.ForeColor = System.Drawing.Color.White;
            this.btnImportar.Location = new System.Drawing.Point(244, 10);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(66, 22);
            this.btnImportar.TabIndex = 63;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // lblNF
            // 
            this.lblNF.AutoSize = true;
            this.lblNF.Location = new System.Drawing.Point(217, 59);
            this.lblNF.Name = "lblNF";
            this.lblNF.Size = new System.Drawing.Size(21, 13);
            this.lblNF.TabIndex = 62;
            this.lblNF.Text = "NF";
            // 
            // txtNF
            // 
            this.txtNF.Location = new System.Drawing.Point(217, 74);
            this.txtNF.MaxLength = 10;
            this.txtNF.Name = "txtNF";
            this.txtNF.Size = new System.Drawing.Size(63, 20);
            this.txtNF.TabIndex = 3;
            this.txtNF.TextChanged += new System.EventHandler(this.txtNF_TextChanged);
            // 
            // btnRecalc
            // 
            this.btnRecalc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecalc.Location = new System.Drawing.Point(134, 113);
            this.btnRecalc.Name = "btnRecalc";
            this.btnRecalc.Size = new System.Drawing.Size(54, 23);
            this.btnRecalc.TabIndex = 5;
            this.btnRecalc.Text = "Recalc";
            this.btnRecalc.UseVisualStyleBackColor = true;
            this.btnRecalc.Click += new System.EventHandler(this.btnRecalc_Click);
            // 
            // lblHelpRecalcular
            // 
            this.lblHelpRecalcular.AutoSize = true;
            this.lblHelpRecalcular.ForeColor = System.Drawing.Color.Red;
            this.lblHelpRecalcular.Location = new System.Drawing.Point(135, 99);
            this.lblHelpRecalcular.Name = "lblHelpRecalcular";
            this.lblHelpRecalcular.Size = new System.Drawing.Size(103, 13);
            this.lblHelpRecalcular.TabIndex = 76;
            this.lblHelpRecalcular.Text = "Recalcular valor Uni";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(261, 98);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 37);
            this.btnPesquisar.TabIndex = 4;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtTotalFrete
            // 
            this.txtTotalFrete.Location = new System.Drawing.Point(7, 115);
            this.txtTotalFrete.Name = "txtTotalFrete";
            this.txtTotalFrete.ReadOnly = true;
            this.txtTotalFrete.Size = new System.Drawing.Size(121, 20);
            this.txtTotalFrete.TabIndex = 10;
            // 
            // lblTotalFrete
            // 
            this.lblTotalFrete.AutoSize = true;
            this.lblTotalFrete.Location = new System.Drawing.Point(4, 99);
            this.lblTotalFrete.Name = "lblTotalFrete";
            this.lblTotalFrete.Size = new System.Drawing.Size(58, 13);
            this.lblTotalFrete.TabIndex = 59;
            this.lblTotalFrete.Text = "Total Frete";
            // 
            // dtpDtFinal
            // 
            this.dtpDtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtFinal.Location = new System.Drawing.Point(112, 74);
            this.dtpDtFinal.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpDtFinal.Name = "dtpDtFinal";
            this.dtpDtFinal.Size = new System.Drawing.Size(99, 20);
            this.dtpDtFinal.TabIndex = 2;
            this.dtpDtFinal.Value = new System.DateTime(2019, 8, 14, 0, 0, 0, 0);
            this.dtpDtFinal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pesquisarComEnter_KeyUp);
            // 
            // btnProcurarTransportadora
            // 
            this.btnProcurarTransportadora.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnProcurarTransportadora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProcurarTransportadora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurarTransportadora.Location = new System.Drawing.Point(316, 32);
            this.btnProcurarTransportadora.Name = "btnProcurarTransportadora";
            this.btnProcurarTransportadora.Size = new System.Drawing.Size(25, 23);
            this.btnProcurarTransportadora.TabIndex = 56;
            this.btnProcurarTransportadora.TabStop = false;
            this.btnProcurarTransportadora.Click += new System.EventHandler(this.btnProcurarTransportadora_Click);
            // 
            // dtpDtInicial
            // 
            this.dtpDtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtInicial.Location = new System.Drawing.Point(7, 74);
            this.dtpDtInicial.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpDtInicial.Name = "dtpDtInicial";
            this.dtpDtInicial.Size = new System.Drawing.Size(99, 20);
            this.dtpDtInicial.TabIndex = 1;
            this.dtpDtInicial.Value = new System.DateTime(2019, 8, 14, 0, 0, 0, 0);
            this.dtpDtInicial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pesquisarComEnter_KeyUp);
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(7, 19);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(79, 13);
            this.lblTransportadora.TabIndex = 2;
            this.lblTransportadora.Text = "Transportadora";
            // 
            // txtTransportadora
            // 
            this.txtTransportadora.Location = new System.Drawing.Point(61, 35);
            this.txtTransportadora.Name = "txtTransportadora";
            this.txtTransportadora.ReadOnly = true;
            this.txtTransportadora.Size = new System.Drawing.Size(249, 20);
            this.txtTransportadora.TabIndex = 6;
            this.txtTransportadora.TextChanged += new System.EventHandler(this.txtTransportadora_TextChanged);
            // 
            // lblDtFinal
            // 
            this.lblDtFinal.AutoSize = true;
            this.lblDtFinal.Location = new System.Drawing.Point(109, 59);
            this.lblDtFinal.Name = "lblDtFinal";
            this.lblDtFinal.Size = new System.Drawing.Size(43, 13);
            this.lblDtFinal.TabIndex = 53;
            this.lblDtFinal.Text = "Dt. final";
            // 
            // txtCodTransportadora
            // 
            this.txtCodTransportadora.Location = new System.Drawing.Point(7, 35);
            this.txtCodTransportadora.MaxLength = 5;
            this.txtCodTransportadora.Name = "txtCodTransportadora";
            this.txtCodTransportadora.Size = new System.Drawing.Size(48, 20);
            this.txtCodTransportadora.TabIndex = 0;
            this.txtCodTransportadora.TextChanged += new System.EventHandler(this.txtCodTransportadora_TextChanged);
            this.txtCodTransportadora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            this.txtCodTransportadora.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pesquisarComEnter_KeyUp);
            // 
            // lblDtInicial
            // 
            this.lblDtInicial.AutoSize = true;
            this.lblDtInicial.Location = new System.Drawing.Point(7, 58);
            this.lblDtInicial.Name = "lblDtInicial";
            this.lblDtInicial.Size = new System.Drawing.Size(50, 13);
            this.lblDtInicial.TabIndex = 50;
            this.lblDtInicial.Text = "Dt. inicial";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvDados);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lblHelpValoresAlterados);
            this.splitContainer2.Panel2.Controls.Add(this.lblHelpObsCores);
            this.splitContainer2.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer2.Panel2.Controls.Add(this.btnSalvar);
            this.splitContainer2.Size = new System.Drawing.Size(1035, 430);
            this.splitContainer2.SplitterDistance = 377;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToOrderColumns = true;
            this.dgvDados.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(1035, 377);
            this.dgvDados.TabIndex = 2;
            this.dgvDados.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellEndEdit);
            this.dgvDados.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellEnter);
            this.dgvDados.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellLeave);
            this.dgvDados.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_CellMouseDoubleClick);
            // 
            // lblHelpValoresAlterados
            // 
            this.lblHelpValoresAlterados.AutoSize = true;
            this.lblHelpValoresAlterados.ForeColor = System.Drawing.Color.Red;
            this.lblHelpValoresAlterados.Location = new System.Drawing.Point(7, 23);
            this.lblHelpValoresAlterados.Name = "lblHelpValoresAlterados";
            this.lblHelpValoresAlterados.Size = new System.Drawing.Size(437, 13);
            this.lblHelpValoresAlterados.TabIndex = 82;
            this.lblHelpValoresAlterados.Text = "Apenas os campos Vlr. UNI, Num. CTR e Observação são armazenados quando alterados" +
    ".";
            // 
            // lblHelpObsCores
            // 
            this.lblHelpObsCores.AutoSize = true;
            this.lblHelpObsCores.ForeColor = System.Drawing.Color.Red;
            this.lblHelpObsCores.Location = new System.Drawing.Point(5, 5);
            this.lblHelpObsCores.Name = "lblHelpObsCores";
            this.lblHelpObsCores.Size = new System.Drawing.Size(715, 13);
            this.lblHelpObsCores.TabIndex = 81;
            this.lblHelpObsCores.Text = "Marcações amarelas significam que o trecho está apto a ser salvo, marcações verme" +
    "lhas indicam que há problemas e é necessário marcar para salvar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(867, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(948, 14);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // frmNewConferenciaFretes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1035, 654);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmNewConferenciaFretes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conferência de fretes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNewConferenciaFretes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNewConferenciaFretes_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpbCalculadoraPercent.ResumeLayout(false);
            this.gpbCalculadoraPercent.PerformLayout();
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcurarTransportadora)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtTotalFrete;
        private System.Windows.Forms.Label lblTotalFrete;
        private System.Windows.Forms.DateTimePicker dtpDtFinal;
        private System.Windows.Forms.PictureBox btnProcurarTransportadora;
        private System.Windows.Forms.DateTimePicker dtpDtInicial;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.TextBox txtTransportadora;
        private System.Windows.Forms.Label lblDtFinal;
        private System.Windows.Forms.TextBox txtCodTransportadora;
        private System.Windows.Forms.Label lblDtInicial;
        private System.Windows.Forms.Label lblConferenciaDeFretes;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnRecalc;
        private System.Windows.Forms.Label lblNF;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnMarcar;
        private System.Windows.Forms.Button btnAddObs;
        private System.Windows.Forms.Label lblObservacaoPadrao;
        private System.Windows.Forms.TextBox txtObsPadrao;
        private System.Windows.Forms.ListBox lsbExcept;
        private System.Windows.Forms.CheckBox chkCalculadora;
        private System.Windows.Forms.GroupBox gpbCalculadoraPercent;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.TextBox txtPercentCalc;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.TextBox txtPorcentagemValor;
        private System.Windows.Forms.Label lblHelpObservacao;
        private System.Windows.Forms.Label lblHelpObsFiltroData;
        private System.Windows.Forms.Label lblHelpPadrao;
        private System.Windows.Forms.Label lblHelpCalculoPercentual;
        private System.Windows.Forms.Label lblHelpCalculadoraPercentual;
        private System.Windows.Forms.Label lblHelpImportar;
        private System.Windows.Forms.CheckBox chkHelp;
        private System.Windows.Forms.Label lblHelpFiltrosPesquisa;
        private System.Windows.Forms.Label lblHelpRecalcular;
        private System.Windows.Forms.Label lblHelpValoresAlterados;
        private System.Windows.Forms.Label lblHelpObsCores;
    }
}