namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Recebimento.Contas_a_receber
{
    partial class frmCARinformacoesGerenceiais
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnResetar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.lblGrupoClientes = new System.Windows.Forms.Label();
            this.lsbGrupoClientes = new System.Windows.Forms.ListBox();
            this.dtpDat_Relatorio = new System.Windows.Forms.DateTimePicker();
            this.gpbGrupo = new System.Windows.Forms.GroupBox();
            this.chkPublico = new System.Windows.Forms.CheckBox();
            this.chkPrivado = new System.Windows.Forms.CheckBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnPreencherCliente = new System.Windows.Forms.PictureBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.btnExportarGraficoPizza = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.lblVencimentoPorPeriodo = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.gPieVencimentos = new LiveCharts.WinForms.PieChart();
            this.btnVisualizarComposicao = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gpbGrupo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnVisualizarComposicao);
            this.splitContainer1.Panel2.Controls.Add(this.btnFechar);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1560, 879);
            this.splitContainer1.SplitterDistance = 807;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnResetar);
            this.splitContainer2.Panel1.Controls.Add(this.btnDeletar);
            this.splitContainer2.Panel1.Controls.Add(this.btnExportarPDF);
            this.splitContainer2.Panel1.Controls.Add(this.lblGrupoClientes);
            this.splitContainer2.Panel1.Controls.Add(this.lsbGrupoClientes);
            this.splitContainer2.Panel1.Controls.Add(this.dtpDat_Relatorio);
            this.splitContainer2.Panel1.Controls.Add(this.gpbGrupo);
            this.splitContainer2.Panel1.Controls.Add(this.txtCliente);
            this.splitContainer2.Panel1.Controls.Add(this.btnPreencherCliente);
            this.splitContainer2.Panel1.Controls.Add(this.lblCliente);
            this.splitContainer2.Panel1.Controls.Add(this.txtCodCliente);
            this.splitContainer2.Panel1.Controls.Add(this.btnExportarGraficoPizza);
            this.splitContainer2.Panel1.Controls.Add(this.btnExportarExcel);
            this.splitContainer2.Panel1.Controls.Add(this.lblVencimentoPorPeriodo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1560, 807);
            this.splitContainer2.SplitterDistance = 158;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnResetar
            // 
            this.btnResetar.Location = new System.Drawing.Point(781, 69);
            this.btnResetar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnResetar.Name = "btnResetar";
            this.btnResetar.Size = new System.Drawing.Size(100, 28);
            this.btnResetar.TabIndex = 76;
            this.btnResetar.Text = "Resetar";
            this.btnResetar.UseVisualStyleBackColor = true;
            this.btnResetar.Click += new System.EventHandler(this.btnResetar_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(781, 111);
            this.btnDeletar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(100, 28);
            this.btnDeletar.TabIndex = 75;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarPDF.BackColor = System.Drawing.Color.Tomato;
            this.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportarPDF.Location = new System.Drawing.Point(1376, 15);
            this.btnExportarPDF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(168, 42);
            this.btnExportarPDF.TabIndex = 74;
            this.btnExportarPDF.Text = "Exportar PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = false;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // lblGrupoClientes
            // 
            this.lblGrupoClientes.AutoSize = true;
            this.lblGrupoClientes.Location = new System.Drawing.Point(615, 49);
            this.lblGrupoClientes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGrupoClientes.Name = "lblGrupoClientes";
            this.lblGrupoClientes.Size = new System.Drawing.Size(95, 16);
            this.lblGrupoClientes.TabIndex = 73;
            this.lblGrupoClientes.Text = "Grupo Clientes";
            // 
            // lsbGrupoClientes
            // 
            this.lsbGrupoClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lsbGrupoClientes.FormattingEnabled = true;
            this.lsbGrupoClientes.ItemHeight = 16;
            this.lsbGrupoClientes.Location = new System.Drawing.Point(613, 69);
            this.lsbGrupoClientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lsbGrupoClientes.Name = "lsbGrupoClientes";
            this.lsbGrupoClientes.Size = new System.Drawing.Size(159, 52);
            this.lsbGrupoClientes.TabIndex = 72;
            // 
            // dtpDat_Relatorio
            // 
            this.dtpDat_Relatorio.Enabled = false;
            this.dtpDat_Relatorio.Location = new System.Drawing.Point(425, 15);
            this.dtpDat_Relatorio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDat_Relatorio.Name = "dtpDat_Relatorio";
            this.dtpDat_Relatorio.Size = new System.Drawing.Size(297, 22);
            this.dtpDat_Relatorio.TabIndex = 67;
            // 
            // gpbGrupo
            // 
            this.gpbGrupo.Controls.Add(this.chkPublico);
            this.gpbGrupo.Controls.Add(this.chkPrivado);
            this.gpbGrupo.Location = new System.Drawing.Point(23, 96);
            this.gpbGrupo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbGrupo.Name = "gpbGrupo";
            this.gpbGrupo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gpbGrupo.Size = new System.Drawing.Size(183, 50);
            this.gpbGrupo.TabIndex = 66;
            this.gpbGrupo.TabStop = false;
            this.gpbGrupo.Text = "Esfera do Cliente";
            // 
            // chkPublico
            // 
            this.chkPublico.AutoSize = true;
            this.chkPublico.Checked = true;
            this.chkPublico.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPublico.Location = new System.Drawing.Point(93, 20);
            this.chkPublico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPublico.Name = "chkPublico";
            this.chkPublico.Size = new System.Drawing.Size(74, 20);
            this.chkPublico.TabIndex = 1;
            this.chkPublico.Text = "Público";
            this.chkPublico.UseVisualStyleBackColor = true;
            this.chkPublico.CheckedChanged += new System.EventHandler(this.chkPublico_CheckedChanged);
            // 
            // chkPrivado
            // 
            this.chkPrivado.AutoSize = true;
            this.chkPrivado.Checked = true;
            this.chkPrivado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrivado.Location = new System.Drawing.Point(4, 20);
            this.chkPrivado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPrivado.Name = "chkPrivado";
            this.chkPrivado.Size = new System.Drawing.Size(76, 20);
            this.chkPrivado.TabIndex = 0;
            this.chkPrivado.Text = "Privado";
            this.chkPrivado.UseVisualStyleBackColor = true;
            this.chkPrivado.CheckedChanged += new System.EventHandler(this.chkPrivado_CheckedChanged);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(88, 69);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(459, 22);
            this.txtCliente.TabIndex = 63;
            this.txtCliente.TabStop = false;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // btnPreencherCliente
            // 
            this.btnPreencherCliente.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherCliente.Location = new System.Drawing.Point(556, 69);
            this.btnPreencherCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPreencherCliente.Name = "btnPreencherCliente";
            this.btnPreencherCliente.Size = new System.Drawing.Size(35, 27);
            this.btnPreencherCliente.TabIndex = 65;
            this.btnPreencherCliente.TabStop = false;
            this.btnPreencherCliente.Click += new System.EventHandler(this.btnPreencherCliente_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(17, 48);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(48, 16);
            this.lblCliente.TabIndex = 64;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(21, 69);
            this.txtCodCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(57, 22);
            this.txtCodCliente.TabIndex = 62;
            this.txtCodCliente.TextChanged += new System.EventHandler(this.txtCodCliente_TextChanged);
            // 
            // btnExportarGraficoPizza
            // 
            this.btnExportarGraficoPizza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarGraficoPizza.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExportarGraficoPizza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarGraficoPizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarGraficoPizza.ForeColor = System.Drawing.Color.White;
            this.btnExportarGraficoPizza.Location = new System.Drawing.Point(1376, 59);
            this.btnExportarGraficoPizza.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportarGraficoPizza.Name = "btnExportarGraficoPizza";
            this.btnExportarGraficoPizza.Size = new System.Drawing.Size(168, 42);
            this.btnExportarGraficoPizza.TabIndex = 50;
            this.btnExportarGraficoPizza.Text = "Exportar Gráfico";
            this.btnExportarGraficoPizza.UseVisualStyleBackColor = false;
            this.btnExportarGraficoPizza.Click += new System.EventHandler(this.btnExportarGraficoPizza_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Location = new System.Drawing.Point(1376, 103);
            this.btnExportarExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(168, 42);
            this.btnExportarExcel.TabIndex = 49;
            this.btnExportarExcel.Text = "Exportar Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // lblVencimentoPorPeriodo
            // 
            this.lblVencimentoPorPeriodo.AutoSize = true;
            this.lblVencimentoPorPeriodo.BackColor = System.Drawing.Color.Gainsboro;
            this.lblVencimentoPorPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVencimentoPorPeriodo.Location = new System.Drawing.Point(16, 11);
            this.lblVencimentoPorPeriodo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVencimentoPorPeriodo.Name = "lblVencimentoPorPeriodo";
            this.lblVencimentoPorPeriodo.Size = new System.Drawing.Size(325, 31);
            this.lblVencimentoPorPeriodo.TabIndex = 18;
            this.lblVencimentoPorPeriodo.Text = "Vencimento por Período";
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
            this.splitContainer3.Panel1.Controls.Add(this.dgvDados);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gPieVencimentos);
            this.splitContainer3.Size = new System.Drawing.Size(1560, 644);
            this.splitContainer3.SplitterDistance = 405;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDados.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.RowHeadersWidth = 51;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(403, 642);
            this.dgvDados.TabIndex = 4;
            // 
            // gPieVencimentos
            // 
            this.gPieVencimentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gPieVencimentos.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.gPieVencimentos.Location = new System.Drawing.Point(5, 4);
            this.gPieVencimentos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gPieVencimentos.MaximumSize = new System.Drawing.Size(1209, 1033);
            this.gPieVencimentos.Name = "gPieVencimentos";
            this.gPieVencimentos.Size = new System.Drawing.Size(1128, 640);
            this.gPieVencimentos.TabIndex = 49;
            // 
            // btnVisualizarComposicao
            // 
            this.btnVisualizarComposicao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVisualizarComposicao.BackColor = System.Drawing.Color.Gray;
            this.btnVisualizarComposicao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualizarComposicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizarComposicao.ForeColor = System.Drawing.Color.White;
            this.btnVisualizarComposicao.Location = new System.Drawing.Point(4, 22);
            this.btnVisualizarComposicao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVisualizarComposicao.Name = "btnVisualizarComposicao";
            this.btnVisualizarComposicao.Size = new System.Drawing.Size(224, 42);
            this.btnVisualizarComposicao.TabIndex = 11;
            this.btnVisualizarComposicao.Text = "Visualizar Composição";
            this.btnVisualizarComposicao.UseVisualStyleBackColor = false;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(1459, 22);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(97, 42);
            this.btnFechar.TabIndex = 10;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmCARinformacoesGerenceiais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1560, 879);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmCARinformacoesGerenceiais";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informações Gerenciais";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCARinformacoesGerenceiais_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gpbGrupo.ResumeLayout(false);
            this.gpbGrupo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Label lblVencimentoPorPeriodo;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnExportarGraficoPizza;
        private System.Windows.Forms.Button btnFechar;
        private LiveCharts.WinForms.PieChart gPieVencimentos;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Label lblGrupoClientes;
        private System.Windows.Forms.ListBox lsbGrupoClientes;
        private System.Windows.Forms.DateTimePicker dtpDat_Relatorio;
        private System.Windows.Forms.GroupBox gpbGrupo;
        private System.Windows.Forms.CheckBox chkPublico;
        private System.Windows.Forms.CheckBox chkPrivado;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.PictureBox btnPreencherCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.Button btnVisualizarComposicao;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnResetar;
    }
}