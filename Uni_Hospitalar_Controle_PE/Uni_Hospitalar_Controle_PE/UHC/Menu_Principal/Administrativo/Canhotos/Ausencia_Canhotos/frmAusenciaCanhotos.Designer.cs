namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Canhotos.Ausencia_Canhotos
{
    partial class frmAusenciaCanhotos
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
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.lblEnvioTransp = new System.Windows.Forms.Label();
            this.btnEnviarEmail = new System.Windows.Forms.Button();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.gpbCanhotos = new System.Windows.Forms.GroupBox();
            this.chkRegNao = new System.Windows.Forms.CheckBox();
            this.chkRegSim = new System.Windows.Forms.CheckBox();
            this.lblDat_Emissao = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gpbPagamento = new System.Windows.Forms.GroupBox();
            this.chkPagNao = new System.Windows.Forms.CheckBox();
            this.chkPagSim = new System.Windows.Forms.CheckBox();
            this.gpbRomaneio = new System.Windows.Forms.GroupBox();
            this.chkRomNao = new System.Windows.Forms.CheckBox();
            this.chkRomSim = new System.Windows.Forms.CheckBox();
            this.dtpDtFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpDtInicial = new System.Windows.Forms.DateTimePicker();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.btnPreencherTransportadora = new System.Windows.Forms.PictureBox();
            this.txtCodTransportadora = new System.Windows.Forms.TextBox();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.lblConferenciaDeCi = new System.Windows.Forms.Label();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpbFiltros.SuspendLayout();
            this.gpbCanhotos.SuspendLayout();
            this.gpbPagamento.SuspendLayout();
            this.gpbRomaneio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherTransportadora)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnExportarExcel);
            this.splitContainer1.Panel1.Controls.Add(this.lblEnvioTransp);
            this.splitContainer1.Panel1.Controls.Add(this.btnEnviarEmail);
            this.splitContainer1.Panel1.Controls.Add(this.gpbFiltros);
            this.splitContainer1.Panel1.Controls.Add(this.lblConferenciaDeCi);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDados);
            this.splitContainer1.Size = new System.Drawing.Size(1442, 527);
            this.splitContainer1.SplitterDistance = 183;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Location = new System.Drawing.Point(1318, 142);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(112, 34);
            this.btnExportarExcel.TabIndex = 53;
            this.btnExportarExcel.Text = "Exportar excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // lblEnvioTransp
            // 
            this.lblEnvioTransp.AutoSize = true;
            this.lblEnvioTransp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnvioTransp.Location = new System.Drawing.Point(485, 96);
            this.lblEnvioTransp.Name = "lblEnvioTransp";
            this.lblEnvioTransp.Size = new System.Drawing.Size(0, 20);
            this.lblEnvioTransp.TabIndex = 52;
            // 
            // btnEnviarEmail
            // 
            this.btnEnviarEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEnviarEmail.Enabled = false;
            this.btnEnviarEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnEnviarEmail.ForeColor = System.Drawing.Color.White;
            this.btnEnviarEmail.Location = new System.Drawing.Point(485, 44);
            this.btnEnviarEmail.Name = "btnEnviarEmail";
            this.btnEnviarEmail.Size = new System.Drawing.Size(214, 37);
            this.btnEnviarEmail.TabIndex = 51;
            this.btnEnviarEmail.Text = "Enviar relação por e-mail para:";
            this.btnEnviarEmail.UseVisualStyleBackColor = false;
            this.btnEnviarEmail.Click += new System.EventHandler(this.BtnEnviarEmail_Click);
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.gpbCanhotos);
            this.gpbFiltros.Controls.Add(this.lblDat_Emissao);
            this.gpbFiltros.Controls.Add(this.label6);
            this.gpbFiltros.Controls.Add(this.gpbPagamento);
            this.gpbFiltros.Controls.Add(this.gpbRomaneio);
            this.gpbFiltros.Controls.Add(this.dtpDtFinal);
            this.gpbFiltros.Controls.Add(this.dtpDtInicial);
            this.gpbFiltros.Controls.Add(this.txtTransportadora);
            this.gpbFiltros.Controls.Add(this.btnPreencherTransportadora);
            this.gpbFiltros.Controls.Add(this.txtCodTransportadora);
            this.gpbFiltros.Controls.Add(this.lblTransportadora);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 36);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(467, 144);
            this.gpbFiltros.TabIndex = 24;
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
            this.btnPesquisar.Location = new System.Drawing.Point(378, 94);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 37);
            this.btnPesquisar.TabIndex = 50;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // gpbCanhotos
            // 
            this.gpbCanhotos.Controls.Add(this.chkRegNao);
            this.gpbCanhotos.Controls.Add(this.chkRegSim);
            this.gpbCanhotos.Location = new System.Drawing.Point(299, 71);
            this.gpbCanhotos.Name = "gpbCanhotos";
            this.gpbCanhotos.Size = new System.Drawing.Size(73, 60);
            this.gpbCanhotos.TabIndex = 28;
            this.gpbCanhotos.TabStop = false;
            this.gpbCanhotos.Text = "Canhoto";
            // 
            // chkRegNao
            // 
            this.chkRegNao.AutoSize = true;
            this.chkRegNao.Checked = true;
            this.chkRegNao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRegNao.Location = new System.Drawing.Point(7, 41);
            this.chkRegNao.Name = "chkRegNao";
            this.chkRegNao.Size = new System.Drawing.Size(46, 17);
            this.chkRegNao.TabIndex = 1;
            this.chkRegNao.Text = "Não";
            this.chkRegNao.UseVisualStyleBackColor = true;
            // 
            // chkRegSim
            // 
            this.chkRegSim.AutoSize = true;
            this.chkRegSim.Location = new System.Drawing.Point(7, 18);
            this.chkRegSim.Name = "chkRegSim";
            this.chkRegSim.Size = new System.Drawing.Size(43, 17);
            this.chkRegSim.TabIndex = 0;
            this.chkRegSim.Text = "Sim";
            this.chkRegSim.UseVisualStyleBackColor = true;
            // 
            // lblDat_Emissao
            // 
            this.lblDat_Emissao.AutoSize = true;
            this.lblDat_Emissao.Location = new System.Drawing.Point(3, 60);
            this.lblDat_Emissao.Name = "lblDat_Emissao";
            this.lblDat_Emissao.Size = new System.Drawing.Size(69, 13);
            this.lblDat_Emissao.TabIndex = 27;
            this.lblDat_Emissao.Text = "Dat. Emissão";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Até";
            // 
            // gpbPagamento
            // 
            this.gpbPagamento.Controls.Add(this.chkPagNao);
            this.gpbPagamento.Controls.Add(this.chkPagSim);
            this.gpbPagamento.Location = new System.Drawing.Point(130, 71);
            this.gpbPagamento.Name = "gpbPagamento";
            this.gpbPagamento.Size = new System.Drawing.Size(84, 60);
            this.gpbPagamento.TabIndex = 23;
            this.gpbPagamento.TabStop = false;
            this.gpbPagamento.Text = "Pagamento";
            // 
            // chkPagNao
            // 
            this.chkPagNao.AutoSize = true;
            this.chkPagNao.Checked = true;
            this.chkPagNao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPagNao.Location = new System.Drawing.Point(5, 41);
            this.chkPagNao.Name = "chkPagNao";
            this.chkPagNao.Size = new System.Drawing.Size(46, 17);
            this.chkPagNao.TabIndex = 3;
            this.chkPagNao.Text = "Não";
            this.chkPagNao.UseVisualStyleBackColor = true;
            // 
            // chkPagSim
            // 
            this.chkPagSim.AutoSize = true;
            this.chkPagSim.Checked = true;
            this.chkPagSim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPagSim.Location = new System.Drawing.Point(5, 18);
            this.chkPagSim.Name = "chkPagSim";
            this.chkPagSim.Size = new System.Drawing.Size(43, 17);
            this.chkPagSim.TabIndex = 2;
            this.chkPagSim.Text = "Sim";
            this.chkPagSim.UseVisualStyleBackColor = true;
            // 
            // gpbRomaneio
            // 
            this.gpbRomaneio.Controls.Add(this.chkRomNao);
            this.gpbRomaneio.Controls.Add(this.chkRomSim);
            this.gpbRomaneio.Location = new System.Drawing.Point(220, 71);
            this.gpbRomaneio.Name = "gpbRomaneio";
            this.gpbRomaneio.Size = new System.Drawing.Size(73, 60);
            this.gpbRomaneio.TabIndex = 22;
            this.gpbRomaneio.TabStop = false;
            this.gpbRomaneio.Text = "Romaneio";
            // 
            // chkRomNao
            // 
            this.chkRomNao.AutoSize = true;
            this.chkRomNao.Checked = true;
            this.chkRomNao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRomNao.Location = new System.Drawing.Point(7, 41);
            this.chkRomNao.Name = "chkRomNao";
            this.chkRomNao.Size = new System.Drawing.Size(46, 17);
            this.chkRomNao.TabIndex = 1;
            this.chkRomNao.Text = "Não";
            this.chkRomNao.UseVisualStyleBackColor = true;
            // 
            // chkRomSim
            // 
            this.chkRomSim.AutoSize = true;
            this.chkRomSim.Checked = true;
            this.chkRomSim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRomSim.Location = new System.Drawing.Point(7, 18);
            this.chkRomSim.Name = "chkRomSim";
            this.chkRomSim.Size = new System.Drawing.Size(43, 17);
            this.chkRomSim.TabIndex = 0;
            this.chkRomSim.Text = "Sim";
            this.chkRomSim.UseVisualStyleBackColor = true;
            // 
            // dtpDtFinal
            // 
            this.dtpDtFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtFinal.Location = new System.Drawing.Point(6, 111);
            this.dtpDtFinal.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpDtFinal.Name = "dtpDtFinal";
            this.dtpDtFinal.Size = new System.Drawing.Size(95, 20);
            this.dtpDtFinal.TabIndex = 25;
            this.dtpDtFinal.Value = new System.DateTime(2019, 8, 28, 0, 0, 0, 0);
            // 
            // dtpDtInicial
            // 
            this.dtpDtInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDtInicial.Location = new System.Drawing.Point(6, 76);
            this.dtpDtInicial.MinDate = new System.DateTime(2012, 1, 1, 0, 0, 0, 0);
            this.dtpDtInicial.Name = "dtpDtInicial";
            this.dtpDtInicial.Size = new System.Drawing.Size(95, 20);
            this.dtpDtInicial.TabIndex = 24;
            this.dtpDtInicial.Value = new System.DateTime(2019, 8, 28, 0, 0, 0, 0);
            // 
            // txtTransportadora
            // 
            this.txtTransportadora.Location = new System.Drawing.Point(55, 37);
            this.txtTransportadora.Name = "txtTransportadora";
            this.txtTransportadora.ReadOnly = true;
            this.txtTransportadora.Size = new System.Drawing.Size(371, 20);
            this.txtTransportadora.TabIndex = 20;
            this.txtTransportadora.TextChanged += new System.EventHandler(this.TxtTransportadora_TextChanged);
            // 
            // btnPreencherTransportadora
            // 
            this.btnPreencherTransportadora.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherTransportadora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherTransportadora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherTransportadora.Location = new System.Drawing.Point(432, 35);
            this.btnPreencherTransportadora.Name = "btnPreencherTransportadora";
            this.btnPreencherTransportadora.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherTransportadora.TabIndex = 21;
            this.btnPreencherTransportadora.TabStop = false;
            this.btnPreencherTransportadora.Click += new System.EventHandler(this.BtnPreencherTransportadora_Click);
            // 
            // txtCodTransportadora
            // 
            this.txtCodTransportadora.Location = new System.Drawing.Point(6, 37);
            this.txtCodTransportadora.Name = "txtCodTransportadora";
            this.txtCodTransportadora.Size = new System.Drawing.Size(44, 20);
            this.txtCodTransportadora.TabIndex = 19;
            this.txtCodTransportadora.TextChanged += new System.EventHandler(this.TxtCodTransportadora_TextChanged);
            this.txtCodTransportadora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(3, 20);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(79, 13);
            this.lblTransportadora.TabIndex = 18;
            this.lblTransportadora.Text = "Transportadora";
            // 
            // lblConferenciaDeCi
            // 
            this.lblConferenciaDeCi.AutoSize = true;
            this.lblConferenciaDeCi.BackColor = System.Drawing.Color.Gainsboro;
            this.lblConferenciaDeCi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConferenciaDeCi.Location = new System.Drawing.Point(12, 8);
            this.lblConferenciaDeCi.Name = "lblConferenciaDeCi";
            this.lblConferenciaDeCi.Size = new System.Drawing.Size(245, 25);
            this.lblConferenciaDeCi.TabIndex = 23;
            this.lblConferenciaDeCi.Text = "Ausência de canhotos";
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
            this.dgvDados.Size = new System.Drawing.Size(1442, 340);
            this.dgvDados.TabIndex = 3;
            // 
            // frmAusenciaCanhotos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 527);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmAusenciaCanhotos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Canhotos";
            this.Load += new System.EventHandler(this.FrmAusenciaCanhotos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAusenciaCanhotos_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            this.gpbCanhotos.ResumeLayout(false);
            this.gpbCanhotos.PerformLayout();
            this.gpbPagamento.ResumeLayout(false);
            this.gpbPagamento.PerformLayout();
            this.gpbRomaneio.ResumeLayout(false);
            this.gpbRomaneio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherTransportadora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Label lblDat_Emissao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gpbPagamento;
        private System.Windows.Forms.CheckBox chkPagNao;
        private System.Windows.Forms.CheckBox chkPagSim;
        private System.Windows.Forms.GroupBox gpbRomaneio;
        private System.Windows.Forms.CheckBox chkRomNao;
        private System.Windows.Forms.CheckBox chkRomSim;
        private System.Windows.Forms.DateTimePicker dtpDtFinal;
        private System.Windows.Forms.DateTimePicker dtpDtInicial;
        private System.Windows.Forms.TextBox txtTransportadora;
        private System.Windows.Forms.PictureBox btnPreencherTransportadora;
        private System.Windows.Forms.TextBox txtCodTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.Label lblConferenciaDeCi;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Button btnEnviarEmail;
        private System.Windows.Forms.GroupBox gpbCanhotos;
        private System.Windows.Forms.CheckBox chkRegNao;
        private System.Windows.Forms.CheckBox chkRegSim;
        private System.Windows.Forms.Label lblEnvioTransp;
        private System.Windows.Forms.Button btnExportarExcel;
    }
}