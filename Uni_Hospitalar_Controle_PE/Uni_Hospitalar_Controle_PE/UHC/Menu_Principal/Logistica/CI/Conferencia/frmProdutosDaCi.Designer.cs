namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Conferencia
{
    partial class frmProdutosDaCi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lsbNFdevolucao = new System.Windows.Forms.ListBox();
            this.gpbNF = new System.Windows.Forms.GroupBox();
            this.lblRespostaSetor = new System.Windows.Forms.Label();
            this.lblSetor = new System.Windows.Forms.Label();
            this.lblRespostaO = new System.Windows.Forms.Label();
            this.lblOperacao = new System.Windows.Forms.Label();
            this.lblRespostaRetorno = new System.Windows.Forms.Label();
            this.lblRetornoFisico = new System.Windows.Forms.Label();
            this.txtNForigem = new System.Windows.Forms.TextBox();
            this.lblOrigem = new System.Windows.Forms.Label();
            this.lblDevolucao = new System.Windows.Forms.Label();
            this.lblRefatura = new System.Windows.Forms.Label();
            this.txtNFrefatura = new System.Windows.Forms.TextBox();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.txtCodTransportadora = new System.Windows.Forms.TextBox();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNocorrencia = new System.Windows.Forms.Label();
            this.lblCI = new System.Windows.Forms.Label();
            this.gpbDadosEsquerda = new System.Windows.Forms.GroupBox();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.gpbQuantidade = new System.Windows.Forms.GroupBox();
            this.dgvDados2 = new System.Windows.Forms.DataGridView();
            this.gpbResultante = new System.Windows.Forms.GroupBox();
            this.dgvDados3 = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.chkRecebimentoTotal = new System.Windows.Forms.CheckBox();
            this.gpbNF.SuspendLayout();
            this.gpbDadosEsquerda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.gpbQuantidade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados2)).BeginInit();
            this.gpbResultante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados3)).BeginInit();
            this.SuspendLayout();
            // 
            // lsbNFdevolucao
            // 
            this.lsbNFdevolucao.FormattingEnabled = true;
            this.lsbNFdevolucao.Location = new System.Drawing.Point(9, 29);
            this.lsbNFdevolucao.Name = "lsbNFdevolucao";
            this.lsbNFdevolucao.Size = new System.Drawing.Size(73, 108);
            this.lsbNFdevolucao.TabIndex = 0;
            // 
            // gpbNF
            // 
            this.gpbNF.Controls.Add(this.lblRespostaSetor);
            this.gpbNF.Controls.Add(this.lblSetor);
            this.gpbNF.Controls.Add(this.lblRespostaO);
            this.gpbNF.Controls.Add(this.lblOperacao);
            this.gpbNF.Controls.Add(this.lblRespostaRetorno);
            this.gpbNF.Controls.Add(this.lblRetornoFisico);
            this.gpbNF.Controls.Add(this.txtNForigem);
            this.gpbNF.Controls.Add(this.lblOrigem);
            this.gpbNF.Controls.Add(this.lblDevolucao);
            this.gpbNF.Controls.Add(this.lsbNFdevolucao);
            this.gpbNF.Location = new System.Drawing.Point(12, 12);
            this.gpbNF.Name = "gpbNF";
            this.gpbNF.Size = new System.Drawing.Size(168, 183);
            this.gpbNF.TabIndex = 1;
            this.gpbNF.TabStop = false;
            this.gpbNF.Text = "NF";
            // 
            // lblRespostaSetor
            // 
            this.lblRespostaSetor.AutoSize = true;
            this.lblRespostaSetor.Location = new System.Drawing.Point(88, 117);
            this.lblRespostaSetor.Name = "lblRespostaSetor";
            this.lblRespostaSetor.Size = new System.Drawing.Size(68, 13);
            this.lblRespostaSetor.TabIndex = 11;
            this.lblRespostaSetor.Text = "RespostaSet";
            // 
            // lblSetor
            // 
            this.lblSetor.AutoSize = true;
            this.lblSetor.Location = new System.Drawing.Point(88, 104);
            this.lblSetor.Name = "lblSetor";
            this.lblSetor.Size = new System.Drawing.Size(32, 13);
            this.lblSetor.TabIndex = 10;
            this.lblSetor.Text = "Setor";
            // 
            // lblRespostaO
            // 
            this.lblRespostaO.AutoSize = true;
            this.lblRespostaO.Location = new System.Drawing.Point(88, 42);
            this.lblRespostaO.Name = "lblRespostaO";
            this.lblRespostaO.Size = new System.Drawing.Size(61, 13);
            this.lblRespostaO.TabIndex = 9;
            this.lblRespostaO.Text = "RespotaOp";
            // 
            // lblOperacao
            // 
            this.lblOperacao.AutoSize = true;
            this.lblOperacao.Location = new System.Drawing.Point(88, 29);
            this.lblOperacao.Name = "lblOperacao";
            this.lblOperacao.Size = new System.Drawing.Size(54, 13);
            this.lblOperacao.TabIndex = 8;
            this.lblOperacao.Text = "Operação";
            // 
            // lblRespostaRetorno
            // 
            this.lblRespostaRetorno.AutoSize = true;
            this.lblRespostaRetorno.Location = new System.Drawing.Point(88, 79);
            this.lblRespostaRetorno.Name = "lblRespostaRetorno";
            this.lblRespostaRetorno.Size = new System.Drawing.Size(69, 13);
            this.lblRespostaRetorno.TabIndex = 7;
            this.lblRespostaRetorno.Text = "RespostaRet";
            // 
            // lblRetornoFisico
            // 
            this.lblRetornoFisico.AutoSize = true;
            this.lblRetornoFisico.Location = new System.Drawing.Point(88, 66);
            this.lblRetornoFisico.Name = "lblRetornoFisico";
            this.lblRetornoFisico.Size = new System.Drawing.Size(74, 13);
            this.lblRetornoFisico.TabIndex = 6;
            this.lblRetornoFisico.Text = "Retorno físico";
            // 
            // txtNForigem
            // 
            this.txtNForigem.Location = new System.Drawing.Point(9, 156);
            this.txtNForigem.Name = "txtNForigem";
            this.txtNForigem.ReadOnly = true;
            this.txtNForigem.Size = new System.Drawing.Size(153, 20);
            this.txtNForigem.TabIndex = 5;
            // 
            // lblOrigem
            // 
            this.lblOrigem.AutoSize = true;
            this.lblOrigem.Location = new System.Drawing.Point(6, 140);
            this.lblOrigem.Name = "lblOrigem";
            this.lblOrigem.Size = new System.Drawing.Size(43, 13);
            this.lblOrigem.TabIndex = 3;
            this.lblOrigem.Text = "Origem:";
            // 
            // lblDevolucao
            // 
            this.lblDevolucao.AutoSize = true;
            this.lblDevolucao.Location = new System.Drawing.Point(6, 14);
            this.lblDevolucao.Name = "lblDevolucao";
            this.lblDevolucao.Size = new System.Drawing.Size(59, 13);
            this.lblDevolucao.TabIndex = 1;
            this.lblDevolucao.Text = "Devolução";
            // 
            // lblRefatura
            // 
            this.lblRefatura.AutoSize = true;
            this.lblRefatura.Location = new System.Drawing.Point(186, 152);
            this.lblRefatura.Name = "lblRefatura";
            this.lblRefatura.Size = new System.Drawing.Size(51, 13);
            this.lblRefatura.TabIndex = 2;
            this.lblRefatura.Text = "Refatura:";
            // 
            // txtNFrefatura
            // 
            this.txtNFrefatura.Location = new System.Drawing.Point(186, 168);
            this.txtNFrefatura.Name = "txtNFrefatura";
            this.txtNFrefatura.ReadOnly = true;
            this.txtNFrefatura.Size = new System.Drawing.Size(71, 20);
            this.txtNFrefatura.TabIndex = 4;
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(186, 41);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.ReadOnly = true;
            this.txtCodCliente.Size = new System.Drawing.Size(50, 20);
            this.txtCodCliente.TabIndex = 6;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(183, 25);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 5;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(242, 41);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(528, 20);
            this.txtCliente.TabIndex = 7;
            // 
            // txtTransportadora
            // 
            this.txtTransportadora.Location = new System.Drawing.Point(242, 84);
            this.txtTransportadora.Name = "txtTransportadora";
            this.txtTransportadora.ReadOnly = true;
            this.txtTransportadora.Size = new System.Drawing.Size(528, 20);
            this.txtTransportadora.TabIndex = 10;
            // 
            // txtCodTransportadora
            // 
            this.txtCodTransportadora.Location = new System.Drawing.Point(186, 84);
            this.txtCodTransportadora.Name = "txtCodTransportadora";
            this.txtCodTransportadora.ReadOnly = true;
            this.txtCodTransportadora.Size = new System.Drawing.Size(50, 20);
            this.txtCodTransportadora.TabIndex = 9;
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(183, 68);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(79, 13);
            this.lblTransportadora.TabIndex = 8;
            this.lblTransportadora.Text = "Transportadora";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(186, 129);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ReadOnly = true;
            this.txtMotivo.Size = new System.Drawing.Size(584, 20);
            this.txtMotivo.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Motivo";
            // 
            // lblNocorrencia
            // 
            this.lblNocorrencia.AutoSize = true;
            this.lblNocorrencia.Location = new System.Drawing.Point(331, 9);
            this.lblNocorrencia.Name = "lblNocorrencia";
            this.lblNocorrencia.Size = new System.Drawing.Size(75, 13);
            this.lblNocorrencia.TabIndex = 13;
            this.lblNocorrencia.Text = "Nº ocorrência:";
            // 
            // lblCI
            // 
            this.lblCI.AutoSize = true;
            this.lblCI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCI.Location = new System.Drawing.Point(403, 7);
            this.lblCI.Name = "lblCI";
            this.lblCI.Size = new System.Drawing.Size(32, 16);
            this.lblCI.TabIndex = 14;
            this.lblCI.Text = "123";
            // 
            // gpbDadosEsquerda
            // 
            this.gpbDadosEsquerda.Controls.Add(this.dgvDados);
            this.gpbDadosEsquerda.Location = new System.Drawing.Point(12, 202);
            this.gpbDadosEsquerda.Name = "gpbDadosEsquerda";
            this.gpbDadosEsquerda.Size = new System.Drawing.Size(478, 214);
            this.gpbDadosEsquerda.TabIndex = 15;
            this.gpbDadosEsquerda.TabStop = false;
            this.gpbDadosEsquerda.Text = "Descritivo";
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
            this.dgvDados.Location = new System.Drawing.Point(3, 16);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(472, 195);
            this.dgvDados.TabIndex = 2;
            // 
            // gpbQuantidade
            // 
            this.gpbQuantidade.Controls.Add(this.dgvDados2);
            this.gpbQuantidade.Location = new System.Drawing.Point(496, 202);
            this.gpbQuantidade.Name = "gpbQuantidade";
            this.gpbQuantidade.Size = new System.Drawing.Size(76, 214);
            this.gpbQuantidade.TabIndex = 16;
            this.gpbQuantidade.TabStop = false;
            this.gpbQuantidade.Text = "Quantidade";
            // 
            // dgvDados2
            // 
            this.dgvDados2.AllowUserToAddRows = false;
            this.dgvDados2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDados2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados2.Location = new System.Drawing.Point(3, 16);
            this.dgvDados2.Name = "dgvDados2";
            this.dgvDados2.RowHeadersVisible = false;
            this.dgvDados2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDados2.Size = new System.Drawing.Size(70, 195);
            this.dgvDados2.TabIndex = 2;
            this.dgvDados2.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados2_CellEnter);
            this.dgvDados2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dgvDados2_Scroll);
            // 
            // gpbResultante
            // 
            this.gpbResultante.Controls.Add(this.dgvDados3);
            this.gpbResultante.Location = new System.Drawing.Point(578, 202);
            this.gpbResultante.Name = "gpbResultante";
            this.gpbResultante.Size = new System.Drawing.Size(192, 214);
            this.gpbResultante.TabIndex = 16;
            this.gpbResultante.TabStop = false;
            this.gpbResultante.Text = "Resultante";
            // 
            // dgvDados3
            // 
            this.dgvDados3.AllowUserToAddRows = false;
            this.dgvDados3.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDados3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados3.Location = new System.Drawing.Point(3, 16);
            this.dgvDados3.Name = "dgvDados3";
            this.dgvDados3.ReadOnly = true;
            this.dgvDados3.RowHeadersVisible = false;
            this.dgvDados3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvDados3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados3.Size = new System.Drawing.Size(186, 195);
            this.dgvDados3.TabIndex = 2;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.IndianRed;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(683, 422);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(84, 34);
            this.btnConfirmar.TabIndex = 50;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // chkRecebimentoTotal
            // 
            this.chkRecebimentoTotal.AutoSize = true;
            this.chkRecebimentoTotal.Location = new System.Drawing.Point(499, 178);
            this.chkRecebimentoTotal.Name = "chkRecebimentoTotal";
            this.chkRecebimentoTotal.Size = new System.Drawing.Size(176, 17);
            this.chkRecebimentoTotal.TabIndex = 51;
            this.chkRecebimentoTotal.Text = "Recebimento Total de Produtos";
            this.chkRecebimentoTotal.UseVisualStyleBackColor = true;
            this.chkRecebimentoTotal.CheckedChanged += new System.EventHandler(this.ChkRecebimentoTotal_CheckedChanged);
            // 
            // frmProdutosDaCi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(775, 462);
            this.Controls.Add(this.chkRecebimentoTotal);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.gpbResultante);
            this.Controls.Add(this.gpbQuantidade);
            this.Controls.Add(this.gpbDadosEsquerda);
            this.Controls.Add(this.lblCI);
            this.Controls.Add(this.lblNocorrencia);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTransportadora);
            this.Controls.Add(this.txtCodTransportadora);
            this.Controls.Add(this.lblTransportadora);
            this.Controls.Add(this.txtNFrefatura);
            this.Controls.Add(this.lblRefatura);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtCodCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.gpbNF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmProdutosDaCi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CI";
            this.Load += new System.EventHandler(this.frmProdutosDaCi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProdutosDaCi_KeyDown);
            this.gpbNF.ResumeLayout(false);
            this.gpbNF.PerformLayout();
            this.gpbDadosEsquerda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.gpbQuantidade.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados2)).EndInit();
            this.gpbResultante.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbNFdevolucao;
        private System.Windows.Forms.GroupBox gpbNF;
        private System.Windows.Forms.Label lblRespostaSetor;
        private System.Windows.Forms.Label lblSetor;
        private System.Windows.Forms.Label lblRespostaO;
        private System.Windows.Forms.Label lblOperacao;
        private System.Windows.Forms.Label lblRespostaRetorno;
        private System.Windows.Forms.Label lblRetornoFisico;
        private System.Windows.Forms.TextBox txtNForigem;
        private System.Windows.Forms.Label lblOrigem;
        private System.Windows.Forms.Label lblDevolucao;
        private System.Windows.Forms.Label lblRefatura;
        private System.Windows.Forms.TextBox txtNFrefatura;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtTransportadora;
        private System.Windows.Forms.TextBox txtCodTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNocorrencia;
        private System.Windows.Forms.Label lblCI;
        private System.Windows.Forms.GroupBox gpbDadosEsquerda;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.GroupBox gpbQuantidade;
        private System.Windows.Forms.GroupBox gpbResultante;
        private System.Windows.Forms.DataGridView dgvDados3;
        private System.Windows.Forms.DataGridView dgvDados2;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.CheckBox chkRecebimentoTotal;
    }
}