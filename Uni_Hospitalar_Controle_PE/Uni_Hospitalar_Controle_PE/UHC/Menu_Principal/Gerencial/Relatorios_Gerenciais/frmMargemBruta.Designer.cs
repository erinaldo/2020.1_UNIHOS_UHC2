namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Gerencial.Relatorios_Gerenciais
{
    partial class frmMargemBruta
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
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnFabricantes = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.lblConferenciaDeFretes = new System.Windows.Forms.Label();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnPublico = new System.Windows.Forms.Button();
            this.btnPrivado = new System.Windows.Forms.Button();
            this.mtxAno = new System.Windows.Forms.MaskedTextBox();
            this.rdbMensal = new System.Windows.Forms.RadioButton();
            this.rdbAnual = new System.Windows.Forms.RadioButton();
            this.lblAno = new System.Windows.Forms.Label();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.chkDataCorte = new System.Windows.Forms.CheckBox();
            this.lblDtpCorte = new System.Windows.Forms.Label();
            this.dtpCorte = new System.Windows.Forms.DateTimePicker();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.mtxTop = new System.Windows.Forms.MaskedTextBox();
            this.lblTop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.lblGraficos = new System.Windows.Forms.Label();
            this.lblGraficoComp = new System.Windows.Forms.Label();
            this.cbxProdutosRelatoriosEspeciais = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvRelatorios = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorios)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProdutos
            // 
            this.btnProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnProdutos.ForeColor = System.Drawing.Color.White;
            this.btnProdutos.Location = new System.Drawing.Point(293, 124);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(163, 43);
            this.btnProdutos.TabIndex = 5;
            this.btnProdutos.Text = "Produtos";
            this.btnProdutos.UseVisualStyleBackColor = false;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // btnFabricantes
            // 
            this.btnFabricantes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFabricantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFabricantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFabricantes.ForeColor = System.Drawing.Color.White;
            this.btnFabricantes.Location = new System.Drawing.Point(743, 124);
            this.btnFabricantes.Name = "btnFabricantes";
            this.btnFabricantes.Size = new System.Drawing.Size(163, 43);
            this.btnFabricantes.TabIndex = 7;
            this.btnFabricantes.Text = "Fabricantes";
            this.btnFabricantes.UseVisualStyleBackColor = false;
            this.btnFabricantes.Click += new System.EventHandler(this.btnFabricantes_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Location = new System.Drawing.Point(462, 124);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(163, 43);
            this.btnClientes.TabIndex = 8;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // lblConferenciaDeFretes
            // 
            this.lblConferenciaDeFretes.AutoSize = true;
            this.lblConferenciaDeFretes.BackColor = System.Drawing.Color.Gainsboro;
            this.lblConferenciaDeFretes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConferenciaDeFretes.Location = new System.Drawing.Point(7, 9);
            this.lblConferenciaDeFretes.Name = "lblConferenciaDeFretes";
            this.lblConferenciaDeFretes.Size = new System.Drawing.Size(261, 25);
            this.lblConferenciaDeFretes.TabIndex = 20;
            this.lblConferenciaDeFretes.Text = "Relatório Margem Bruta";
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(12, 175);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDados.Size = new System.Drawing.Size(1019, 506);
            this.dgvDados.TabIndex = 21;
            this.dgvDados.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDados_CellMouseDoubleClick);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnFechar.Location = new System.Drawing.Point(928, 687);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(103, 38);
            this.btnFechar.TabIndex = 22;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnPublico
            // 
            this.btnPublico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPublico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublico.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnPublico.ForeColor = System.Drawing.Color.White;
            this.btnPublico.Location = new System.Drawing.Point(631, 146);
            this.btnPublico.Name = "btnPublico";
            this.btnPublico.Size = new System.Drawing.Size(106, 21);
            this.btnPublico.TabIndex = 24;
            this.btnPublico.Text = "Público";
            this.btnPublico.UseVisualStyleBackColor = false;
            this.btnPublico.Click += new System.EventHandler(this.btnPublico_Click);
            // 
            // btnPrivado
            // 
            this.btnPrivado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrivado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrivado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnPrivado.ForeColor = System.Drawing.Color.White;
            this.btnPrivado.Location = new System.Drawing.Point(631, 124);
            this.btnPrivado.Name = "btnPrivado";
            this.btnPrivado.Size = new System.Drawing.Size(106, 21);
            this.btnPrivado.TabIndex = 25;
            this.btnPrivado.Text = "Privado";
            this.btnPrivado.UseVisualStyleBackColor = false;
            this.btnPrivado.Click += new System.EventHandler(this.btnPrivado_Click);
            // 
            // mtxAno
            // 
            this.mtxAno.Location = new System.Drawing.Point(74, 30);
            this.mtxAno.Name = "mtxAno";
            this.mtxAno.Size = new System.Drawing.Size(59, 20);
            this.mtxAno.TabIndex = 26;
            // 
            // rdbMensal
            // 
            this.rdbMensal.AutoSize = true;
            this.rdbMensal.Checked = true;
            this.rdbMensal.Location = new System.Drawing.Point(9, 30);
            this.rdbMensal.Name = "rdbMensal";
            this.rdbMensal.Size = new System.Drawing.Size(59, 17);
            this.rdbMensal.TabIndex = 27;
            this.rdbMensal.TabStop = true;
            this.rdbMensal.Text = "Mensal";
            this.rdbMensal.UseVisualStyleBackColor = true;
            this.rdbMensal.CheckedChanged += new System.EventHandler(this.rdbMensal_CheckedChanged);
            // 
            // rdbAnual
            // 
            this.rdbAnual.AutoSize = true;
            this.rdbAnual.Location = new System.Drawing.Point(9, 52);
            this.rdbAnual.Name = "rdbAnual";
            this.rdbAnual.Size = new System.Drawing.Size(52, 17);
            this.rdbAnual.TabIndex = 28;
            this.rdbAnual.Text = "Anual";
            this.rdbAnual.UseVisualStyleBackColor = true;
            this.rdbAnual.CheckedChanged += new System.EventHandler(this.rdbAnual_CheckedChanged);
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Location = new System.Drawing.Point(71, 14);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(26, 13);
            this.lblAno.TabIndex = 29;
            this.lblAno.Text = "Ano";
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.chkDataCorte);
            this.gpbFiltros.Controls.Add(this.lblDtpCorte);
            this.gpbFiltros.Controls.Add(this.dtpCorte);
            this.gpbFiltros.Controls.Add(this.lblDescricao);
            this.gpbFiltros.Controls.Add(this.txtDescricao);
            this.gpbFiltros.Controls.Add(this.mtxTop);
            this.gpbFiltros.Controls.Add(this.lblTop);
            this.gpbFiltros.Controls.Add(this.label1);
            this.gpbFiltros.Controls.Add(this.rdbAnual);
            this.gpbFiltros.Controls.Add(this.rdbMensal);
            this.gpbFiltros.Controls.Add(this.mtxAno);
            this.gpbFiltros.Controls.Add(this.lblAno);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 37);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(275, 132);
            this.gpbFiltros.TabIndex = 30;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            // 
            // chkDataCorte
            // 
            this.chkDataCorte.AutoSize = true;
            this.chkDataCorte.Location = new System.Drawing.Point(180, 76);
            this.chkDataCorte.Name = "chkDataCorte";
            this.chkDataCorte.Size = new System.Drawing.Size(15, 14);
            this.chkDataCorte.TabIndex = 41;
            this.chkDataCorte.UseVisualStyleBackColor = true;
            this.chkDataCorte.CheckedChanged += new System.EventHandler(this.chkDataCorte_CheckedChanged);
            // 
            // lblDtpCorte
            // 
            this.lblDtpCorte.AutoSize = true;
            this.lblDtpCorte.Location = new System.Drawing.Point(75, 57);
            this.lblDtpCorte.Name = "lblDtpCorte";
            this.lblDtpCorte.Size = new System.Drawing.Size(58, 13);
            this.lblDtpCorte.TabIndex = 40;
            this.lblDtpCorte.Text = "Data Corte";
            // 
            // dtpCorte
            // 
            this.dtpCorte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCorte.Location = new System.Drawing.Point(74, 73);
            this.dtpCorte.Name = "dtpCorte";
            this.dtpCorte.Size = new System.Drawing.Size(100, 20);
            this.dtpCorte.TabIndex = 39;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(6, 80);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(55, 13);
            this.lblDescricao.TabIndex = 38;
            this.lblDescricao.Text = "Descricao";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(9, 99);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(260, 20);
            this.txtDescricao.TabIndex = 37;
            // 
            // mtxTop
            // 
            this.mtxTop.Location = new System.Drawing.Point(140, 30);
            this.mtxTop.Name = "mtxTop";
            this.mtxTop.Size = new System.Drawing.Size(59, 20);
            this.mtxTop.TabIndex = 35;
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(137, 14);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(26, 13);
            this.lblTop.TabIndex = 36;
            this.lblTop.Text = "Top";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Modalidade";
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Location = new System.Drawing.Point(919, 7);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(112, 34);
            this.btnExportarExcel.TabIndex = 49;
            this.btnExportarExcel.Text = "Exportar excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // lblGraficos
            // 
            this.lblGraficos.AutoSize = true;
            this.lblGraficos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraficos.ForeColor = System.Drawing.Color.Red;
            this.lblGraficos.Location = new System.Drawing.Point(293, 24);
            this.lblGraficos.Name = "lblGraficos";
            this.lblGraficos.Size = new System.Drawing.Size(359, 31);
            this.lblGraficos.TabIndex = 50;
            this.lblGraficos.Text = "GRÁFICOS DISPONÍVEIS";
            // 
            // lblGraficoComp
            // 
            this.lblGraficoComp.AutoSize = true;
            this.lblGraficoComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGraficoComp.ForeColor = System.Drawing.Color.Black;
            this.lblGraficoComp.Location = new System.Drawing.Point(296, 54);
            this.lblGraficoComp.Name = "lblGraficoComp";
            this.lblGraficoComp.Size = new System.Drawing.Size(382, 16);
            this.lblGraficoComp.TabIndex = 51;
            this.lblGraficoComp.Text = "Clique duas vezes no dado desejado para abrir a visualização";
            // 
            // cbxProdutosRelatoriosEspeciais
            // 
            this.cbxProdutosRelatoriosEspeciais.FormattingEnabled = true;
            this.cbxProdutosRelatoriosEspeciais.Location = new System.Drawing.Point(293, 97);
            this.cbxProdutosRelatoriosEspeciais.Name = "cbxProdutosRelatoriosEspeciais";
            this.cbxProdutosRelatoriosEspeciais.Size = new System.Drawing.Size(163, 21);
            this.cbxProdutosRelatoriosEspeciais.TabIndex = 52;
            this.cbxProdutosRelatoriosEspeciais.SelectedIndexChanged += new System.EventHandler(this.cbxProdutosRelatoriosEspeciais_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Relatórios especiais";
            // 
            // dgvRelatorios
            // 
            this.dgvRelatorios.AllowUserToAddRows = false;
            this.dgvRelatorios.AllowUserToDeleteRows = false;
            this.dgvRelatorios.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvRelatorios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRelatorios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRelatorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelatorios.Location = new System.Drawing.Point(799, 9);
            this.dgvRelatorios.Name = "dgvRelatorios";
            this.dgvRelatorios.RowHeadersVisible = false;
            this.dgvRelatorios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRelatorios.Size = new System.Drawing.Size(114, 42);
            this.dgvRelatorios.TabIndex = 54;
            // 
            // frmMargemBruta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 731);
            this.Controls.Add(this.dgvRelatorios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxProdutosRelatoriosEspeciais);
            this.Controls.Add(this.lblGraficoComp);
            this.Controls.Add(this.lblGraficos);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.gpbFiltros);
            this.Controls.Add(this.btnPrivado);
            this.Controls.Add(this.btnPublico);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.lblConferenciaDeFretes);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnFabricantes);
            this.Controls.Add(this.btnProdutos);
            this.Name = "frmMargemBruta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Margem Bruta";
            this.Load += new System.EventHandler(this.frmMargemBruta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelatorios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Button btnFabricantes;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Label lblConferenciaDeFretes;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnPublico;
        private System.Windows.Forms.Button btnPrivado;
        private System.Windows.Forms.MaskedTextBox mtxAno;
        private System.Windows.Forms.RadioButton rdbMensal;
        private System.Windows.Forms.RadioButton rdbAnual;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.MaskedTextBox mtxTop;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label lblGraficos;
        private System.Windows.Forms.Label lblGraficoComp;
        private System.Windows.Forms.CheckBox chkDataCorte;
        private System.Windows.Forms.Label lblDtpCorte;
        private System.Windows.Forms.DateTimePicker dtpCorte;
        private System.Windows.Forms.ComboBox cbxProdutosRelatoriosEspeciais;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvRelatorios;
    }
}