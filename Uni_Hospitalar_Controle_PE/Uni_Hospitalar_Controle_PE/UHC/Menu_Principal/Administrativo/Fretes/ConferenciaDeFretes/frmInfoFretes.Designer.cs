namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Fretes.ConferenciaDeFretes
{
    partial class frmInfoFretes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblExportar = new System.Windows.Forms.Label();
            this.btnGrafico = new System.Windows.Forms.Button();
            this.btnAbrirExcel = new System.Windows.Forms.Button();
            this.lblConferenciaDeFretes = new System.Windows.Forms.Label();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxParamData = new System.Windows.Forms.ComboBox();
            this.txtCTR = new System.Windows.Forms.TextBox();
            this.lblCTR = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtTotalFrete = new System.Windows.Forms.TextBox();
            this.lblTotalFrete = new System.Windows.Forms.Label();
            this.dtpDtFinal = new System.Windows.Forms.DateTimePicker();
            this.btnProcurarTransportadora = new System.Windows.Forms.PictureBox();
            this.dtpDtInicial = new System.Windows.Forms.DateTimePicker();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.lblDtFinal = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtCodTransportadora = new System.Windows.Forms.TextBox();
            this.lblDtInicial = new System.Windows.Forms.Label();
            this.gFreteXTransportadora = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbcAnaliSinte = new System.Windows.Forms.TabControl();
            this.tabSintetico = new System.Windows.Forms.TabPage();
            this.dgvSintetico = new System.Windows.Forms.DataGridView();
            this.tabAnalitco = new System.Windows.Forms.TabPage();
            this.dgvAnalitico = new System.Windows.Forms.DataGridView();
            this.lblAbrir = new System.Windows.Forms.Label();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcurarTransportadora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gFreteXTransportadora)).BeginInit();
            this.tbcAnaliSinte.SuspendLayout();
            this.tabSintetico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSintetico)).BeginInit();
            this.tabAnalitco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalitico)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbcAnaliSinte);
            this.splitContainer1.Size = new System.Drawing.Size(1041, 541);
            this.splitContainer1.SplitterDistance = 185;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnExportarExcel);
            this.splitContainer2.Panel1.Controls.Add(this.lblAbrir);
            this.splitContainer2.Panel1.Controls.Add(this.lblExportar);
            this.splitContainer2.Panel1.Controls.Add(this.btnGrafico);
            this.splitContainer2.Panel1.Controls.Add(this.btnAbrirExcel);
            this.splitContainer2.Panel1.Controls.Add(this.lblConferenciaDeFretes);
            this.splitContainer2.Panel1.Controls.Add(this.gpbFiltros);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gFreteXTransportadora);
            this.splitContainer2.Size = new System.Drawing.Size(1041, 185);
            this.splitContainer2.SplitterDistance = 364;
            this.splitContainer2.TabIndex = 1;
            // 
            // lblExportar
            // 
            this.lblExportar.AutoSize = true;
            this.lblExportar.Location = new System.Drawing.Point(241, 3);
            this.lblExportar.Name = "lblExportar";
            this.lblExportar.Size = new System.Drawing.Size(46, 13);
            this.lblExportar.TabIndex = 23;
            this.lblExportar.Text = "Exportar";
            // 
            // btnGrafico
            // 
            this.btnGrafico.Location = new System.Drawing.Point(296, 16);
            this.btnGrafico.Name = "btnGrafico";
            this.btnGrafico.Size = new System.Drawing.Size(57, 22);
            this.btnGrafico.TabIndex = 22;
            this.btnGrafico.Text = "Gráfico";
            this.btnGrafico.UseVisualStyleBackColor = true;
            this.btnGrafico.Click += new System.EventHandler(this.btnGrafico_Click);
            // 
            // btnAbrirExcel
            // 
            this.btnAbrirExcel.Location = new System.Drawing.Point(176, 16);
            this.btnAbrirExcel.Name = "btnAbrirExcel";
            this.btnAbrirExcel.Size = new System.Drawing.Size(57, 22);
            this.btnAbrirExcel.TabIndex = 21;
            this.btnAbrirExcel.Text = "Excel";
            this.btnAbrirExcel.UseVisualStyleBackColor = true;
            this.btnAbrirExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // lblConferenciaDeFretes
            // 
            this.lblConferenciaDeFretes.AutoSize = true;
            this.lblConferenciaDeFretes.BackColor = System.Drawing.Color.Gainsboro;
            this.lblConferenciaDeFretes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConferenciaDeFretes.Location = new System.Drawing.Point(10, 7);
            this.lblConferenciaDeFretes.Name = "lblConferenciaDeFretes";
            this.lblConferenciaDeFretes.Size = new System.Drawing.Size(125, 25);
            this.lblConferenciaDeFretes.TabIndex = 20;
            this.lblConferenciaDeFretes.Text = "Info Fretes";
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.label1);
            this.gpbFiltros.Controls.Add(this.cbxParamData);
            this.gpbFiltros.Controls.Add(this.txtCTR);
            this.gpbFiltros.Controls.Add(this.lblCTR);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.txtTotalFrete);
            this.gpbFiltros.Controls.Add(this.lblTotalFrete);
            this.gpbFiltros.Controls.Add(this.dtpDtFinal);
            this.gpbFiltros.Controls.Add(this.btnProcurarTransportadora);
            this.gpbFiltros.Controls.Add(this.dtpDtInicial);
            this.gpbFiltros.Controls.Add(this.lblTransportadora);
            this.gpbFiltros.Controls.Add(this.txtTransportadora);
            this.gpbFiltros.Controls.Add(this.lblDtFinal);
            this.gpbFiltros.Controls.Add(this.txtNota);
            this.gpbFiltros.Controls.Add(this.lblNota);
            this.gpbFiltros.Controls.Add(this.txtCodTransportadora);
            this.gpbFiltros.Controls.Add(this.lblDtInicial);
            this.gpbFiltros.Location = new System.Drawing.Point(8, 35);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(347, 141);
            this.gpbFiltros.TabIndex = 19;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Parâmetro de data";
            // 
            // cbxParamData
            // 
            this.cbxParamData.FormattingEnabled = true;
            this.cbxParamData.Items.AddRange(new object[] {
            "Data Emissão",
            "Data Registro"});
            this.cbxParamData.Location = new System.Drawing.Point(134, 114);
            this.cbxParamData.Name = "cbxParamData";
            this.cbxParamData.Size = new System.Drawing.Size(113, 21);
            this.cbxParamData.TabIndex = 63;
            this.cbxParamData.Text = "Data Emissão";
            // 
            // txtCTR
            // 
            this.txtCTR.Location = new System.Drawing.Point(277, 74);
            this.txtCTR.Name = "txtCTR";
            this.txtCTR.Size = new System.Drawing.Size(54, 20);
            this.txtCTR.TabIndex = 61;
            this.txtCTR.TextChanged += new System.EventHandler(this.txtCTR_TextChanged);
            this.txtCTR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCTR_KeyDown);
            this.txtCTR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // lblCTR
            // 
            this.lblCTR.AutoSize = true;
            this.lblCTR.Location = new System.Drawing.Point(276, 58);
            this.lblCTR.Name = "lblCTR";
            this.lblCTR.Size = new System.Drawing.Size(29, 13);
            this.lblCTR.TabIndex = 62;
            this.lblCTR.Text = "CTR";
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
            this.btnPesquisar.TabIndex = 60;
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
            this.dtpDtFinal.TabIndex = 8;
            this.dtpDtFinal.Value = new System.DateTime(2019, 8, 14, 0, 0, 0, 0);
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
            this.dtpDtInicial.TabIndex = 7;
            this.dtpDtInicial.Value = new System.DateTime(2019, 8, 14, 0, 0, 0, 0);
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
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(217, 74);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(54, 20);
            this.txtNota.TabIndex = 9;
            this.txtNota.TextChanged += new System.EventHandler(this.txtNota_TextChanged);
            this.txtNota.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNota_KeyDown);
            this.txtNota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(217, 58);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(30, 13);
            this.lblNota.TabIndex = 54;
            this.lblNota.Text = "Nota";
            // 
            // txtCodTransportadora
            // 
            this.txtCodTransportadora.Location = new System.Drawing.Point(7, 35);
            this.txtCodTransportadora.MaxLength = 5;
            this.txtCodTransportadora.Name = "txtCodTransportadora";
            this.txtCodTransportadora.Size = new System.Drawing.Size(48, 20);
            this.txtCodTransportadora.TabIndex = 5;
            this.txtCodTransportadora.TextChanged += new System.EventHandler(this.txtCodTransportadora_TextChanged);
            this.txtCodTransportadora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
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
            // gFreteXTransportadora
            // 
            this.gFreteXTransportadora.BackColor = System.Drawing.Color.Transparent;
            this.gFreteXTransportadora.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.gFreteXTransportadora.ChartAreas.Add(chartArea1);
            this.gFreteXTransportadora.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.gFreteXTransportadora.Legends.Add(legend1);
            this.gFreteXTransportadora.Location = new System.Drawing.Point(0, 0);
            this.gFreteXTransportadora.Name = "gFreteXTransportadora";
            this.gFreteXTransportadora.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "DrawSideBySide=True, DrawingStyle=Emboss";
            series1.EmptyPointStyle.CustomProperties = "DrawingStyle=Emboss";
            series1.EmptyPointStyle.LabelBorderWidth = 0;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            series1.IsValueShownAsLabel = true;
            series1.IsXValueIndexed = true;
            series1.Label = "#VAL{C}";
            series1.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.Legend = "Legend1";
            series1.Name = "Valor Frete";
            series1.SmartLabelStyle.CalloutLineWidth = 0;
            this.gFreteXTransportadora.Series.Add(series1);
            this.gFreteXTransportadora.Size = new System.Drawing.Size(669, 181);
            this.gFreteXTransportadora.TabIndex = 1;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Titulo_Chart";
            title1.ShadowColor = System.Drawing.Color.Gray;
            title1.Text = "Frete x Transportadora";
            this.gFreteXTransportadora.Titles.Add(title1);
            // 
            // tbcAnaliSinte
            // 
            this.tbcAnaliSinte.Controls.Add(this.tabSintetico);
            this.tbcAnaliSinte.Controls.Add(this.tabAnalitco);
            this.tbcAnaliSinte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcAnaliSinte.Location = new System.Drawing.Point(0, 0);
            this.tbcAnaliSinte.Name = "tbcAnaliSinte";
            this.tbcAnaliSinte.SelectedIndex = 0;
            this.tbcAnaliSinte.Size = new System.Drawing.Size(1037, 348);
            this.tbcAnaliSinte.TabIndex = 1;
            // 
            // tabSintetico
            // 
            this.tabSintetico.Controls.Add(this.dgvSintetico);
            this.tabSintetico.Location = new System.Drawing.Point(4, 22);
            this.tabSintetico.Name = "tabSintetico";
            this.tabSintetico.Padding = new System.Windows.Forms.Padding(3);
            this.tabSintetico.Size = new System.Drawing.Size(1029, 322);
            this.tabSintetico.TabIndex = 0;
            this.tabSintetico.Text = "Sintético";
            this.tabSintetico.UseVisualStyleBackColor = true;
            // 
            // dgvSintetico
            // 
            this.dgvSintetico.AllowUserToAddRows = false;
            this.dgvSintetico.AllowUserToDeleteRows = false;
            this.dgvSintetico.AllowUserToOrderColumns = true;
            this.dgvSintetico.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvSintetico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSintetico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSintetico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSintetico.Location = new System.Drawing.Point(3, 3);
            this.dgvSintetico.Name = "dgvSintetico";
            this.dgvSintetico.RowHeadersVisible = false;
            this.dgvSintetico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSintetico.Size = new System.Drawing.Size(1023, 316);
            this.dgvSintetico.TabIndex = 0;
            // 
            // tabAnalitco
            // 
            this.tabAnalitco.Controls.Add(this.dgvAnalitico);
            this.tabAnalitco.Location = new System.Drawing.Point(4, 22);
            this.tabAnalitco.Name = "tabAnalitco";
            this.tabAnalitco.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnalitco.Size = new System.Drawing.Size(1029, 322);
            this.tabAnalitco.TabIndex = 1;
            this.tabAnalitco.Text = "Analítico";
            this.tabAnalitco.UseVisualStyleBackColor = true;
            // 
            // dgvAnalitico
            // 
            this.dgvAnalitico.AllowUserToAddRows = false;
            this.dgvAnalitico.AllowUserToDeleteRows = false;
            this.dgvAnalitico.AllowUserToOrderColumns = true;
            this.dgvAnalitico.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAnalitico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAnalitico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalitico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnalitico.Location = new System.Drawing.Point(3, 3);
            this.dgvAnalitico.Name = "dgvAnalitico";
            this.dgvAnalitico.RowHeadersVisible = false;
            this.dgvAnalitico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvAnalitico.Size = new System.Drawing.Size(1023, 316);
            this.dgvAnalitico.TabIndex = 1;
            // 
            // lblAbrir
            // 
            this.lblAbrir.AutoSize = true;
            this.lblAbrir.Location = new System.Drawing.Point(188, 3);
            this.lblAbrir.Name = "lblAbrir";
            this.lblAbrir.Size = new System.Drawing.Size(28, 13);
            this.lblAbrir.TabIndex = 24;
            this.lblAbrir.Text = "Abrir";
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Location = new System.Drawing.Point(236, 16);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(57, 22);
            this.btnExportarExcel.TabIndex = 25;
            this.btnExportarExcel.Text = "Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // frmInfoFretes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 541);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmInfoFretes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Info Fretes";
            this.Load += new System.EventHandler(this.frmInfoFretes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmNewConferenciaFretes_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcurarTransportadora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gFreteXTransportadora)).EndInit();
            this.tbcAnaliSinte.ResumeLayout(false);
            this.tabSintetico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSintetico)).EndInit();
            this.tabAnalitco.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalitico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblConferenciaDeFretes;
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
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TextBox txtCodTransportadora;
        private System.Windows.Forms.Label lblDtInicial;
        private System.Windows.Forms.TextBox txtCTR;
        private System.Windows.Forms.Label lblCTR;
        private System.Windows.Forms.DataVisualization.Charting.Chart gFreteXTransportadora;
        private System.Windows.Forms.TabControl tbcAnaliSinte;
        private System.Windows.Forms.TabPage tabSintetico;
        private System.Windows.Forms.DataGridView dgvSintetico;
        private System.Windows.Forms.TabPage tabAnalitco;
        private System.Windows.Forms.DataGridView dgvAnalitico;
        private System.Windows.Forms.Button btnGrafico;
        private System.Windows.Forms.Button btnAbrirExcel;
        private System.Windows.Forms.Label lblExportar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxParamData;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Label lblAbrir;
    }
}