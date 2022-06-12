namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Recebimento.Contas_a_receber
{
    partial class frmContasAreceber
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblTop10Car = new System.Windows.Forms.Label();
            this.lblContasAreceber = new System.Windows.Forms.Label();
            this.gRanking = new LiveCharts.WinForms.CartesianChart();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.dgvRanking = new System.Windows.Forms.DataGridView();
            this.btnInformacoesGerenciais = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnExportarGrafico = new System.Windows.Forms.Button();
            this.btnExportarCAR = new System.Windows.Forms.Button();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.lblCAR = new System.Windows.Forms.Label();
            this.txtCAR = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblDtCorte = new System.Windows.Forms.Label();
            this.dtpDatCorte = new System.Windows.Forms.DateTimePicker();
            this.gpbAreceber = new System.Windows.Forms.GroupBox();
            this.gpbRanking = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).BeginInit();
            this.gpbFiltros.SuspendLayout();
            this.gpbAreceber.SuspendLayout();
            this.gpbRanking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1761, 870);
            this.splitContainer1.SplitterDistance = 326;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblTop10Car);
            this.splitContainer2.Panel1.Controls.Add(this.lblContasAreceber);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gRanking);
            this.splitContainer2.Size = new System.Drawing.Size(1761, 326);
            this.splitContainer2.SplitterDistance = 48;
            this.splitContainer2.TabIndex = 1;
            // 
            // lblTop10Car
            // 
            this.lblTop10Car.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblTop10Car.AutoSize = true;
            this.lblTop10Car.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTop10Car.Location = new System.Drawing.Point(832, 15);
            this.lblTop10Car.Name = "lblTop10Car";
            this.lblTop10Car.Size = new System.Drawing.Size(99, 16);
            this.lblTop10Car.TabIndex = 4;
            this.lblTop10Car.Text = "Top 10 - CAR";
            this.lblTop10Car.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblContasAreceber
            // 
            this.lblContasAreceber.AutoSize = true;
            this.lblContasAreceber.BackColor = System.Drawing.Color.Gainsboro;
            this.lblContasAreceber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContasAreceber.Location = new System.Drawing.Point(12, 9);
            this.lblContasAreceber.Name = "lblContasAreceber";
            this.lblContasAreceber.Size = new System.Drawing.Size(193, 25);
            this.lblContasAreceber.TabIndex = 3;
            this.lblContasAreceber.Text = "Contas a receber";
            // 
            // gRanking
            // 
            this.gRanking.BackColor = System.Drawing.Color.Transparent;
            this.gRanking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gRanking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gRanking.Location = new System.Drawing.Point(0, 0);
            this.gRanking.Name = "gRanking";
            this.gRanking.Size = new System.Drawing.Size(1761, 274);
            this.gRanking.TabIndex = 1;
            this.gRanking.Text = "gRanking";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnInformacoesGerenciais);
            this.splitContainer3.Panel2.Controls.Add(this.btnFechar);
            this.splitContainer3.Panel2.Controls.Add(this.btnExportarGrafico);
            this.splitContainer3.Panel2.Controls.Add(this.btnExportarCAR);
            this.splitContainer3.Panel2.Controls.Add(this.gpbFiltros);
            this.splitContainer3.Size = new System.Drawing.Size(1761, 540);
            this.splitContainer3.SplitterDistance = 1514;
            this.splitContainer3.TabIndex = 0;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(3, 16);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.RowHeadersWidth = 51;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(1184, 511);
            this.dgvDados.TabIndex = 3;
            // 
            // dgvRanking
            // 
            this.dgvRanking.AllowUserToAddRows = false;
            this.dgvRanking.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvRanking.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRanking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRanking.Location = new System.Drawing.Point(3, 16);
            this.dgvRanking.Name = "dgvRanking";
            this.dgvRanking.ReadOnly = true;
            this.dgvRanking.RowHeadersVisible = false;
            this.dgvRanking.RowHeadersWidth = 51;
            this.dgvRanking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRanking.Size = new System.Drawing.Size(302, 511);
            this.dgvRanking.TabIndex = 3;
            // 
            // btnInformacoesGerenciais
            // 
            this.btnInformacoesGerenciais.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInformacoesGerenciais.BackColor = System.Drawing.Color.Firebrick;
            this.btnInformacoesGerenciais.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformacoesGerenciais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInformacoesGerenciais.ForeColor = System.Drawing.Color.White;
            this.btnInformacoesGerenciais.Location = new System.Drawing.Point(1, 168);
            this.btnInformacoesGerenciais.Name = "btnInformacoesGerenciais";
            this.btnInformacoesGerenciais.Size = new System.Drawing.Size(224, 39);
            this.btnInformacoesGerenciais.TabIndex = 10;
            this.btnInformacoesGerenciais.Text = "Info. Gerenciais";
            this.btnInformacoesGerenciais.UseVisualStyleBackColor = false;
            this.btnInformacoesGerenciais.Click += new System.EventHandler(this.btnInformacoesGerenciais_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(158, 499);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(73, 34);
            this.btnFechar.TabIndex = 9;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.BtnFechar_Click);
            // 
            // btnExportarGrafico
            // 
            this.btnExportarGrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarGrafico.BackColor = System.Drawing.Color.Firebrick;
            this.btnExportarGrafico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarGrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarGrafico.ForeColor = System.Drawing.Color.White;
            this.btnExportarGrafico.Location = new System.Drawing.Point(1, 213);
            this.btnExportarGrafico.Name = "btnExportarGrafico";
            this.btnExportarGrafico.Size = new System.Drawing.Size(224, 39);
            this.btnExportarGrafico.TabIndex = 7;
            this.btnExportarGrafico.Text = "Exportar Gráfico";
            this.btnExportarGrafico.UseVisualStyleBackColor = false;
            this.btnExportarGrafico.Click += new System.EventHandler(this.BtnExportarGrafico_Click);
            // 
            // btnExportarCAR
            // 
            this.btnExportarCAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarCAR.BackColor = System.Drawing.Color.Firebrick;
            this.btnExportarCAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarCAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarCAR.ForeColor = System.Drawing.Color.White;
            this.btnExportarCAR.Location = new System.Drawing.Point(1, 258);
            this.btnExportarCAR.Name = "btnExportarCAR";
            this.btnExportarCAR.Size = new System.Drawing.Size(224, 39);
            this.btnExportarCAR.TabIndex = 6;
            this.btnExportarCAR.Text = "Exportar CAR";
            this.btnExportarCAR.UseVisualStyleBackColor = false;
            this.btnExportarCAR.Click += new System.EventHandler(this.BtnExportarCAR_Click);
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbFiltros.BackColor = System.Drawing.Color.Transparent;
            this.gpbFiltros.Controls.Add(this.lblCAR);
            this.gpbFiltros.Controls.Add(this.txtCAR);
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.lblTitulo);
            this.gpbFiltros.Controls.Add(this.txtTitulo);
            this.gpbFiltros.Controls.Add(this.lblDtCorte);
            this.gpbFiltros.Controls.Add(this.dtpDatCorte);
            this.gpbFiltros.Location = new System.Drawing.Point(1, 3);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(230, 159);
            this.gpbFiltros.TabIndex = 1;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // lblCAR
            // 
            this.lblCAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCAR.AutoSize = true;
            this.lblCAR.Location = new System.Drawing.Point(3, 107);
            this.lblCAR.Name = "lblCAR";
            this.lblCAR.Size = new System.Drawing.Size(56, 13);
            this.lblCAR.TabIndex = 64;
            this.lblCAR.Text = "Valor CAR";
            // 
            // txtCAR
            // 
            this.txtCAR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCAR.Location = new System.Drawing.Point(6, 123);
            this.txtCAR.Name = "txtCAR";
            this.txtCAR.ReadOnly = true;
            this.txtCAR.Size = new System.Drawing.Size(132, 20);
            this.txtCAR.TabIndex = 63;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(144, 106);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 37);
            this.btnPesquisar.TabIndex = 62;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(3, 61);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(35, 13);
            this.lblTitulo.TabIndex = 61;
            this.lblTitulo.Text = "Título";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitulo.Location = new System.Drawing.Point(6, 77);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(218, 20);
            this.txtTitulo.TabIndex = 60;
            this.txtTitulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTitulo_KeyDown);
            // 
            // lblDtCorte
            // 
            this.lblDtCorte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDtCorte.AutoSize = true;
            this.lblDtCorte.Location = new System.Drawing.Point(6, 17);
            this.lblDtCorte.Name = "lblDtCorte";
            this.lblDtCorte.Size = new System.Drawing.Size(72, 13);
            this.lblDtCorte.TabIndex = 50;
            this.lblDtCorte.Text = "Data de corte";
            // 
            // dtpDatCorte
            // 
            this.dtpDatCorte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDatCorte.Location = new System.Drawing.Point(6, 33);
            this.dtpDatCorte.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpDatCorte.Name = "dtpDatCorte";
            this.dtpDatCorte.Size = new System.Drawing.Size(218, 20);
            this.dtpDatCorte.TabIndex = 49;
            this.dtpDatCorte.Value = new System.DateTime(2019, 8, 28, 0, 0, 0, 0);
            // 
            // gpbAreceber
            // 
            this.gpbAreceber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbAreceber.Controls.Add(this.dgvDados);
            this.gpbAreceber.Location = new System.Drawing.Point(3, 3);
            this.gpbAreceber.Name = "gpbAreceber";
            this.gpbAreceber.Size = new System.Drawing.Size(1190, 530);
            this.gpbAreceber.TabIndex = 0;
            this.gpbAreceber.TabStop = false;
            this.gpbAreceber.Text = "A receber";
            // 
            // gpbRanking
            // 
            this.gpbRanking.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbRanking.Controls.Add(this.dgvRanking);
            this.gpbRanking.Location = new System.Drawing.Point(3, 3);
            this.gpbRanking.Name = "gpbRanking";
            this.gpbRanking.Size = new System.Drawing.Size(308, 530);
            this.gpbRanking.TabIndex = 4;
            this.gpbRanking.TabStop = false;
            this.gpbRanking.Text = "Ranking";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.gpbAreceber);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.gpbRanking);
            this.splitContainer4.Size = new System.Drawing.Size(1514, 540);
            this.splitContainer4.SplitterDistance = 1196;
            this.splitContainer4.TabIndex = 0;
            // 
            // frmContasAreceber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1761, 870);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmContasAreceber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contas a receber";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmContasAreceber_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmContasAreceber_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRanking)).EndInit();
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            this.gpbAreceber.ResumeLayout(false);
            this.gpbRanking.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label lblContasAreceber;
        private LiveCharts.WinForms.CartesianChart gRanking;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.DataGridView dgvRanking;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Label lblDtCorte;
        private System.Windows.Forms.DateTimePicker dtpDatCorte;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label lblCAR;
        private System.Windows.Forms.TextBox txtCAR;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnExportarGrafico;
        private System.Windows.Forms.Button btnExportarCAR;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblTop10Car;
        private System.Windows.Forms.Button btnInformacoesGerenciais;
        private System.Windows.Forms.GroupBox gpbRanking;
        private System.Windows.Forms.GroupBox gpbAreceber;
        private System.Windows.Forms.SplitContainer splitContainer4;
    }
}