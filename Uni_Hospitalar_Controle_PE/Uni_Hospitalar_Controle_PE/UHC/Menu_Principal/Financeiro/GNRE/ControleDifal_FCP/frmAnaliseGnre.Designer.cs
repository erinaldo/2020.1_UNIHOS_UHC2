namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.GNRE.ControleDifal_FCP
{
    partial class frmAnaliseGnre
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
            this.pnlDados = new System.Windows.Forms.Panel();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.lblAnalise = new System.Windows.Forms.Label();
            this.txtUF = new System.Windows.Forms.TextBox();
            this.txtUFDesc = new System.Windows.Forms.TextBox();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.dtpDtFinal = new System.Windows.Forms.DateTimePicker();
            this.btnProcurarCliente = new System.Windows.Forms.PictureBox();
            this.dtpDtInicial = new System.Windows.Forms.DateTimePicker();
            this.lblEstado = new System.Windows.Forms.Label();
            this.gpbStatus = new System.Windows.Forms.GroupBox();
            this.chkNaoPago = new System.Windows.Forms.CheckBox();
            this.chkPago = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblDtFinal = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtCod_Cliente = new System.Windows.Forms.TextBox();
            this.lblDtInicial = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalDifal = new System.Windows.Forms.TextBox();
            this.lblTotalFCP = new System.Windows.Forms.Label();
            this.txtTotalFCP = new System.Windows.Forms.TextBox();
            this.lblDifalxUF = new System.Windows.Forms.Label();
            this.lblValoresEmMi = new System.Windows.Forms.Label();
            this.gMes = new LiveCharts.WinForms.CartesianChart();
            this.lblValoresEmMi2 = new System.Windows.Forms.Label();
            this.lblDifalXMes = new System.Windows.Forms.Label();
            this.cbxAno = new System.Windows.Forms.ComboBox();
            this.gEstados = new LiveCharts.WinForms.PieChart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExportarGraficoAno = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExportarGraficoUF = new System.Windows.Forms.Button();
            this.pnlDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcurarCliente)).BeginInit();
            this.gpbStatus.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDados
            // 
            this.pnlDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlDados.Controls.Add(this.btnExportarExcel);
            this.pnlDados.Controls.Add(this.dgvDados);
            this.pnlDados.Location = new System.Drawing.Point(12, 263);
            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Size = new System.Drawing.Size(884, 681);
            this.pnlDados.TabIndex = 0;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Location = new System.Drawing.Point(750, 644);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(112, 34);
            this.btnExportarExcel.TabIndex = 48;
            this.btnExportarExcel.Text = "Exportar excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
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
            this.dgvDados.Size = new System.Drawing.Size(884, 681);
            this.dgvDados.TabIndex = 3;
            this.dgvDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDados_MouseDoubleClick);
            // 
            // lblAnalise
            // 
            this.lblAnalise.AutoSize = true;
            this.lblAnalise.BackColor = System.Drawing.Color.Gainsboro;
            this.lblAnalise.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnalise.Location = new System.Drawing.Point(4, 4);
            this.lblAnalise.Name = "lblAnalise";
            this.lblAnalise.Size = new System.Drawing.Size(212, 25);
            this.lblAnalise.TabIndex = 17;
            this.lblAnalise.Text = "Análise Difal - FCP";
            // 
            // txtUF
            // 
            this.txtUF.Location = new System.Drawing.Point(6, 152);
            this.txtUF.MaxLength = 2;
            this.txtUF.Name = "txtUF";
            this.txtUF.Size = new System.Drawing.Size(26, 20);
            this.txtUF.TabIndex = 6;
            this.txtUF.TextChanged += new System.EventHandler(this.txtUF_TextChanged);
            this.txtUF.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PesquisaComEnter_KeyUp);
            // 
            // txtUFDesc
            // 
            this.txtUFDesc.Location = new System.Drawing.Point(38, 152);
            this.txtUFDesc.Name = "txtUFDesc";
            this.txtUFDesc.ReadOnly = true;
            this.txtUFDesc.Size = new System.Drawing.Size(123, 20);
            this.txtUFDesc.TabIndex = 19;
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.dtpDtFinal);
            this.gpbFiltros.Controls.Add(this.btnProcurarCliente);
            this.gpbFiltros.Controls.Add(this.dtpDtInicial);
            this.gpbFiltros.Controls.Add(this.lblEstado);
            this.gpbFiltros.Controls.Add(this.gpbStatus);
            this.gpbFiltros.Controls.Add(this.label2);
            this.gpbFiltros.Controls.Add(this.txtObservacao);
            this.gpbFiltros.Controls.Add(this.lblCliente);
            this.gpbFiltros.Controls.Add(this.txtCliente);
            this.gpbFiltros.Controls.Add(this.txtUFDesc);
            this.gpbFiltros.Controls.Add(this.txtUF);
            this.gpbFiltros.Controls.Add(this.lblDtFinal);
            this.gpbFiltros.Controls.Add(this.txtNota);
            this.gpbFiltros.Controls.Add(this.lblNota);
            this.gpbFiltros.Controls.Add(this.txtCod_Cliente);
            this.gpbFiltros.Controls.Add(this.lblDtInicial);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 32);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(465, 213);
            this.gpbFiltros.TabIndex = 0;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(374, 169);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 37);
            this.btnPesquisar.TabIndex = 50;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // dtpDtFinal
            // 
            this.dtpDtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtFinal.Location = new System.Drawing.Point(358, 73);
            this.dtpDtFinal.MinDate = new System.DateTime(2016, 6, 3, 0, 0, 0, 0);
            this.dtpDtFinal.Name = "dtpDtFinal";
            this.dtpDtFinal.Size = new System.Drawing.Size(96, 20);
            this.dtpDtFinal.TabIndex = 47;
            this.dtpDtFinal.Value = new System.DateTime(2019, 8, 14, 0, 0, 0, 0);
            this.dtpDtFinal.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PesquisaComEnter_KeyUp);
            // 
            // btnProcurarCliente
            // 
            this.btnProcurarCliente.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnProcurarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProcurarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurarCliente.Location = new System.Drawing.Point(324, 32);
            this.btnProcurarCliente.Name = "btnProcurarCliente";
            this.btnProcurarCliente.Size = new System.Drawing.Size(25, 23);
            this.btnProcurarCliente.TabIndex = 33;
            this.btnProcurarCliente.TabStop = false;
            this.btnProcurarCliente.Click += new System.EventHandler(this.btnProcurarCliente_Click);
            // 
            // dtpDtInicial
            // 
            this.dtpDtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtInicial.Location = new System.Drawing.Point(355, 35);
            this.dtpDtInicial.MinDate = new System.DateTime(2016, 6, 3, 0, 0, 0, 0);
            this.dtpDtInicial.Name = "dtpDtInicial";
            this.dtpDtInicial.Size = new System.Drawing.Size(99, 20);
            this.dtpDtInicial.TabIndex = 34;
            this.dtpDtInicial.Value = new System.DateTime(2019, 8, 14, 0, 0, 0, 0);
            this.dtpDtInicial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PesquisaComEnter_KeyUp);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(6, 136);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 31;
            this.lblEstado.Text = "Estado";
            // 
            // gpbStatus
            // 
            this.gpbStatus.Controls.Add(this.chkNaoPago);
            this.gpbStatus.Controls.Add(this.chkPago);
            this.gpbStatus.Location = new System.Drawing.Point(191, 139);
            this.gpbStatus.Name = "gpbStatus";
            this.gpbStatus.Size = new System.Drawing.Size(131, 68);
            this.gpbStatus.TabIndex = 9;
            this.gpbStatus.TabStop = false;
            this.gpbStatus.Text = "Status";
            // 
            // chkNaoPago
            // 
            this.chkNaoPago.AutoSize = true;
            this.chkNaoPago.Checked = true;
            this.chkNaoPago.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNaoPago.Location = new System.Drawing.Point(6, 41);
            this.chkNaoPago.Name = "chkNaoPago";
            this.chkNaoPago.Size = new System.Drawing.Size(73, 17);
            this.chkNaoPago.TabIndex = 1;
            this.chkNaoPago.Text = "Não pago";
            this.chkNaoPago.UseVisualStyleBackColor = true;
            // 
            // chkPago
            // 
            this.chkPago.AutoSize = true;
            this.chkPago.Checked = true;
            this.chkPago.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPago.Location = new System.Drawing.Point(6, 19);
            this.chkPago.Name = "chkPago";
            this.chkPago.Size = new System.Drawing.Size(51, 17);
            this.chkPago.TabIndex = 0;
            this.chkPago.Text = "Pago";
            this.chkPago.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Observação";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(6, 76);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(316, 57);
            this.txtObservacao.TabIndex = 4;
            this.txtObservacao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PesquisaComEnter_KeyUp);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(6, 16);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 27;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(60, 32);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(262, 20);
            this.txtCliente.TabIndex = 1;
            // 
            // lblDtFinal
            // 
            this.lblDtFinal.AutoSize = true;
            this.lblDtFinal.Location = new System.Drawing.Point(355, 58);
            this.lblDtFinal.Name = "lblDtFinal";
            this.lblDtFinal.Size = new System.Drawing.Size(43, 13);
            this.lblDtFinal.TabIndex = 20;
            this.lblDtFinal.Text = "Dt. final";
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(355, 113);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(65, 20);
            this.txtNota.TabIndex = 5;
            this.txtNota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            this.txtNota.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PesquisaComEnter_KeyUp);
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(355, 97);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(30, 13);
            this.lblNota.TabIndex = 25;
            this.lblNota.Text = "Nota";
            // 
            // txtCod_Cliente
            // 
            this.txtCod_Cliente.Location = new System.Drawing.Point(6, 32);
            this.txtCod_Cliente.MaxLength = 5;
            this.txtCod_Cliente.Name = "txtCod_Cliente";
            this.txtCod_Cliente.Size = new System.Drawing.Size(48, 20);
            this.txtCod_Cliente.TabIndex = 0;
            this.txtCod_Cliente.TextChanged += new System.EventHandler(this.txtCod_Cliente_TextChanged);
            this.txtCod_Cliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            this.txtCod_Cliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PesquisaComEnter_KeyUp);
            // 
            // lblDtInicial
            // 
            this.lblDtInicial.AutoSize = true;
            this.lblDtInicial.Location = new System.Drawing.Point(355, 19);
            this.lblDtInicial.Name = "lblDtInicial";
            this.lblDtInicial.Size = new System.Drawing.Size(50, 13);
            this.lblDtInicial.TabIndex = 3;
            this.lblDtInicial.Text = "Dt. inicial";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(897, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Total Difal";
            // 
            // txtTotalDifal
            // 
            this.txtTotalDifal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalDifal.Location = new System.Drawing.Point(900, 279);
            this.txtTotalDifal.Name = "txtTotalDifal";
            this.txtTotalDifal.ReadOnly = true;
            this.txtTotalDifal.Size = new System.Drawing.Size(117, 20);
            this.txtTotalDifal.TabIndex = 32;
            // 
            // lblTotalFCP
            // 
            this.lblTotalFCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalFCP.AutoSize = true;
            this.lblTotalFCP.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalFCP.Location = new System.Drawing.Point(1020, 263);
            this.lblTotalFCP.Name = "lblTotalFCP";
            this.lblTotalFCP.Size = new System.Drawing.Size(54, 13);
            this.lblTotalFCP.TabIndex = 35;
            this.lblTotalFCP.Text = "Total FCP";
            // 
            // txtTotalFCP
            // 
            this.txtTotalFCP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalFCP.Location = new System.Drawing.Point(1023, 279);
            this.txtTotalFCP.Name = "txtTotalFCP";
            this.txtTotalFCP.ReadOnly = true;
            this.txtTotalFCP.Size = new System.Drawing.Size(117, 20);
            this.txtTotalFCP.TabIndex = 34;
            // 
            // lblDifalxUF
            // 
            this.lblDifalxUF.AutoSize = true;
            this.lblDifalxUF.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblDifalxUF.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDifalxUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifalxUF.Location = new System.Drawing.Point(0, 0);
            this.lblDifalxUF.Name = "lblDifalxUF";
            this.lblDifalxUF.Size = new System.Drawing.Size(88, 20);
            this.lblDifalxUF.TabIndex = 41;
            this.lblDifalxUF.Text = "Difal x UF";
            // 
            // lblValoresEmMi
            // 
            this.lblValoresEmMi.AutoSize = true;
            this.lblValoresEmMi.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblValoresEmMi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblValoresEmMi.Location = new System.Drawing.Point(0, 20);
            this.lblValoresEmMi.Name = "lblValoresEmMi";
            this.lblValoresEmMi.Size = new System.Drawing.Size(73, 13);
            this.lblValoresEmMi.TabIndex = 43;
            this.lblValoresEmMi.Text = "Valores em Mi";
            // 
            // gMes
            // 
            this.gMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMes.Location = new System.Drawing.Point(0, 33);
            this.gMes.Name = "gMes";
            this.gMes.Size = new System.Drawing.Size(1171, 216);
            this.gMes.TabIndex = 44;
            this.gMes.ChildChanged += new System.EventHandler<System.Windows.Forms.Integration.ChildChangedEventArgs>(this.gMes_ChildChanged);
            // 
            // lblValoresEmMi2
            // 
            this.lblValoresEmMi2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblValoresEmMi2.Location = new System.Drawing.Point(0, 20);
            this.lblValoresEmMi2.Name = "lblValoresEmMi2";
            this.lblValoresEmMi2.Size = new System.Drawing.Size(1171, 13);
            this.lblValoresEmMi2.TabIndex = 46;
            this.lblValoresEmMi2.Text = "Valores em Mi";
            this.lblValoresEmMi2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDifalXMes
            // 
            this.lblDifalXMes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDifalXMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifalXMes.Location = new System.Drawing.Point(0, 0);
            this.lblDifalXMes.Name = "lblDifalXMes";
            this.lblDifalXMes.Size = new System.Drawing.Size(1171, 20);
            this.lblDifalXMes.TabIndex = 45;
            this.lblDifalXMes.Text = "Difal x Mês";
            this.lblDifalXMes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cbxAno
            // 
            this.cbxAno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxAno.FormattingEnabled = true;
            this.cbxAno.Location = new System.Drawing.Point(1529, 258);
            this.cbxAno.Name = "cbxAno";
            this.cbxAno.Size = new System.Drawing.Size(121, 21);
            this.cbxAno.TabIndex = 1;
            this.cbxAno.SelectedIndexChanged += new System.EventHandler(this.cbxAno_SelectedIndexChanged);
            // 
            // gEstados
            // 
            this.gEstados.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.gEstados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gEstados.Location = new System.Drawing.Point(0, 0);
            this.gEstados.MaximumSize = new System.Drawing.Size(907, 839);
            this.gEstados.Name = "gEstados";
            this.gEstados.Size = new System.Drawing.Size(748, 639);
            this.gEstados.TabIndex = 47;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.gMes);
            this.panel1.Controls.Add(this.lblValoresEmMi2);
            this.panel1.Controls.Add(this.lblDifalXMes);
            this.panel1.Location = new System.Drawing.Point(487, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1171, 249);
            this.panel1.TabIndex = 51;
            // 
            // btnExportarGraficoAno
            // 
            this.btnExportarGraficoAno.BackColor = System.Drawing.Color.Firebrick;
            this.btnExportarGraficoAno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarGraficoAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarGraficoAno.ForeColor = System.Drawing.Color.White;
            this.btnExportarGraficoAno.Location = new System.Drawing.Point(222, 2);
            this.btnExportarGraficoAno.Name = "btnExportarGraficoAno";
            this.btnExportarGraficoAno.Size = new System.Drawing.Size(126, 34);
            this.btnExportarGraficoAno.TabIndex = 51;
            this.btnExportarGraficoAno.Text = "Exp. Difal x Mês";
            this.btnExportarGraficoAno.UseVisualStyleBackColor = false;
            this.btnExportarGraficoAno.Click += new System.EventHandler(this.btnExportarGraficoAnu_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblValoresEmMi);
            this.panel2.Controls.Add(this.lblDifalxUF);
            this.panel2.Controls.Add(this.gEstados);
            this.panel2.Location = new System.Drawing.Point(902, 305);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(748, 639);
            this.panel2.TabIndex = 52;
            // 
            // btnExportarGraficoUF
            // 
            this.btnExportarGraficoUF.BackColor = System.Drawing.Color.Firebrick;
            this.btnExportarGraficoUF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarGraficoUF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarGraficoUF.ForeColor = System.Drawing.Color.White;
            this.btnExportarGraficoUF.Location = new System.Drawing.Point(351, 2);
            this.btnExportarGraficoUF.Name = "btnExportarGraficoUF";
            this.btnExportarGraficoUF.Size = new System.Drawing.Size(126, 34);
            this.btnExportarGraficoUF.TabIndex = 7;
            this.btnExportarGraficoUF.Text = "Exp. Difal x UF";
            this.btnExportarGraficoUF.UseVisualStyleBackColor = false;
            this.btnExportarGraficoUF.Click += new System.EventHandler(this.btnExportarGraficoUF_Click);
            // 
            // frmAnaliseGnre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1662, 956);
            this.Controls.Add(this.btnExportarGraficoUF);
            this.Controls.Add(this.btnExportarGraficoAno);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gpbFiltros);
            this.Controls.Add(this.cbxAno);
            this.Controls.Add(this.lblAnalise);
            this.Controls.Add(this.pnlDados);
            this.Controls.Add(this.lblTotalFCP);
            this.Controls.Add(this.txtTotalFCP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalDifal);
            this.KeyPreview = true;
            this.Name = "frmAnaliseGnre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle DIFAL - FCP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAnaliseGnre_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAnaliseGnre_KeyDown);
            this.pnlDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcurarCliente)).EndInit();
            this.gpbStatus.ResumeLayout(false);
            this.gpbStatus.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDados;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Label lblAnalise;
        private System.Windows.Forms.TextBox txtUF;
        private System.Windows.Forms.TextBox txtUFDesc;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.GroupBox gpbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TextBox txtCod_Cliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalDifal;
        private System.Windows.Forms.Label lblTotalFCP;
        private System.Windows.Forms.TextBox txtTotalFCP;
        private System.Windows.Forms.PictureBox btnProcurarCliente;
        private System.Windows.Forms.Label lblDifalxUF;
        private System.Windows.Forms.Label lblValoresEmMi;
        private LiveCharts.WinForms.CartesianChart gMes;
        private System.Windows.Forms.Label lblValoresEmMi2;
        private System.Windows.Forms.Label lblDifalXMes;
        private System.Windows.Forms.ComboBox cbxAno;
        private System.Windows.Forms.CheckBox chkNaoPago;
        private System.Windows.Forms.CheckBox chkPago;
        private System.Windows.Forms.Label lblDtFinal;
        private System.Windows.Forms.Label lblDtInicial;
        private System.Windows.Forms.DateTimePicker dtpDtFinal;
        private System.Windows.Forms.DateTimePicker dtpDtInicial;
        private LiveCharts.WinForms.PieChart gEstados;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnExportarGraficoUF;
        private System.Windows.Forms.Button btnExportarGraficoAno;
    }
}