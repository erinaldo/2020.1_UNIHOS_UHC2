namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci
{
    partial class frmCriarCi
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
            this.gpbTipoOperacao = new System.Windows.Forms.GroupBox();
            this.rdbDevParcial = new System.Windows.Forms.RadioButton();
            this.rdbDevTotal = new System.Windows.Forms.RadioButton();
            this.lblCriarCi = new System.Windows.Forms.Label();
            this.btnPreencherTransportadora = new System.Windows.Forms.PictureBox();
            this.btnPreencherCliente = new System.Windows.Forms.PictureBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodCliente = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.txtCodTransportadora = new System.Windows.Forms.TextBox();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.gpbInformações = new System.Windows.Forms.GroupBox();
            this.gpbRetornoFisico = new System.Windows.Forms.GroupBox();
            this.rdbNao = new System.Windows.Forms.RadioButton();
            this.rdbSim = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLimparNForigem = new System.Windows.Forms.PictureBox();
            this.lblNForigem = new System.Windows.Forms.Label();
            this.lblNFdevol = new System.Windows.Forms.Label();
            this.clbNFdevol = new System.Windows.Forms.CheckedListBox();
            this.txtNFrefatura = new System.Windows.Forms.TextBox();
            this.txtNForigem = new System.Windows.Forms.TextBox();
            this.cbxMotivo = new System.Windows.Forms.ComboBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.lblObservacao = new System.Windows.Forms.Label();
            this.lblSetor = new System.Windows.Forms.Label();
            this.cbxSetor = new System.Windows.Forms.ComboBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnCriarCi = new System.Windows.Forms.Button();
            this.gpbTipoOperacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherTransportadora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).BeginInit();
            this.gpbInformações.SuspendLayout();
            this.gpbRetornoFisico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimparNForigem)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbTipoOperacao
            // 
            this.gpbTipoOperacao.Controls.Add(this.rdbDevParcial);
            this.gpbTipoOperacao.Controls.Add(this.rdbDevTotal);
            this.gpbTipoOperacao.Location = new System.Drawing.Point(5, 35);
            this.gpbTipoOperacao.Name = "gpbTipoOperacao";
            this.gpbTipoOperacao.Size = new System.Drawing.Size(242, 71);
            this.gpbTipoOperacao.TabIndex = 0;
            this.gpbTipoOperacao.TabStop = false;
            this.gpbTipoOperacao.Text = "Tipo de operação";
            // 
            // rdbDevParcial
            // 
            this.rdbDevParcial.AutoSize = true;
            this.rdbDevParcial.Location = new System.Drawing.Point(8, 43);
            this.rdbDevParcial.Name = "rdbDevParcial";
            this.rdbDevParcial.Size = new System.Drawing.Size(111, 17);
            this.rdbDevParcial.TabIndex = 1;
            this.rdbDevParcial.TabStop = true;
            this.rdbDevParcial.Text = "Devolução parcial";
            this.rdbDevParcial.UseVisualStyleBackColor = true;
            // 
            // rdbDevTotal
            // 
            this.rdbDevTotal.AutoSize = true;
            this.rdbDevTotal.Location = new System.Drawing.Point(8, 20);
            this.rdbDevTotal.Name = "rdbDevTotal";
            this.rdbDevTotal.Size = new System.Drawing.Size(100, 17);
            this.rdbDevTotal.TabIndex = 0;
            this.rdbDevTotal.TabStop = true;
            this.rdbDevTotal.Text = "Devolução total";
            this.rdbDevTotal.UseVisualStyleBackColor = true;
            // 
            // lblCriarCi
            // 
            this.lblCriarCi.AutoSize = true;
            this.lblCriarCi.BackColor = System.Drawing.Color.Gainsboro;
            this.lblCriarCi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCriarCi.Location = new System.Drawing.Point(0, 4);
            this.lblCriarCi.Name = "lblCriarCi";
            this.lblCriarCi.Size = new System.Drawing.Size(92, 25);
            this.lblCriarCi.TabIndex = 2;
            this.lblCriarCi.Text = "Criar CI";
            // 
            // btnPreencherTransportadora
            // 
            this.btnPreencherTransportadora.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherTransportadora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherTransportadora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherTransportadora.Location = new System.Drawing.Point(466, 138);
            this.btnPreencherTransportadora.Name = "btnPreencherTransportadora";
            this.btnPreencherTransportadora.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherTransportadora.TabIndex = 25;
            this.btnPreencherTransportadora.TabStop = false;
            this.btnPreencherTransportadora.Click += new System.EventHandler(this.btnPreencherTransportadora_Click);
            // 
            // btnPreencherCliente
            // 
            this.btnPreencherCliente.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherCliente.Location = new System.Drawing.Point(466, 31);
            this.btnPreencherCliente.Name = "btnPreencherCliente";
            this.btnPreencherCliente.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherCliente.TabIndex = 24;
            this.btnPreencherCliente.TabStop = false;
            this.btnPreencherCliente.Click += new System.EventHandler(this.btnPreencherCliente_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(6, 16);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 18;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCodCliente
            // 
            this.txtCodCliente.Location = new System.Drawing.Point(9, 33);
            this.txtCodCliente.Name = "txtCodCliente";
            this.txtCodCliente.Size = new System.Drawing.Size(44, 20);
            this.txtCodCliente.TabIndex = 0;
            this.txtCodCliente.TextChanged += new System.EventHandler(this.txtCodCliente_TextChanged);
            this.txtCodCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(59, 33);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(401, 20);
            this.txtCliente.TabIndex = 1;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(138, 122);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(130, 13);
            this.lblTransportadora.TabIndex = 21;
            this.lblTransportadora.Text = "Transportadora de retorno";
            // 
            // txtCodTransportadora
            // 
            this.txtCodTransportadora.Location = new System.Drawing.Point(141, 138);
            this.txtCodTransportadora.Name = "txtCodTransportadora";
            this.txtCodTransportadora.Size = new System.Drawing.Size(44, 20);
            this.txtCodTransportadora.TabIndex = 5;
            this.txtCodTransportadora.TextChanged += new System.EventHandler(this.txtCodTransportadora_TextChanged);
            this.txtCodTransportadora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // txtTransportadora
            // 
            this.txtTransportadora.Location = new System.Drawing.Point(191, 138);
            this.txtTransportadora.Name = "txtTransportadora";
            this.txtTransportadora.ReadOnly = true;
            this.txtTransportadora.Size = new System.Drawing.Size(269, 20);
            this.txtTransportadora.TabIndex = 6;
            // 
            // gpbInformações
            // 
            this.gpbInformações.Controls.Add(this.gpbRetornoFisico);
            this.gpbInformações.Controls.Add(this.label1);
            this.gpbInformações.Controls.Add(this.btnPreencherTransportadora);
            this.gpbInformações.Controls.Add(this.lblTransportadora);
            this.gpbInformações.Controls.Add(this.btnLimparNForigem);
            this.gpbInformações.Controls.Add(this.lblNForigem);
            this.gpbInformações.Controls.Add(this.txtTransportadora);
            this.gpbInformações.Controls.Add(this.lblNFdevol);
            this.gpbInformações.Controls.Add(this.txtCliente);
            this.gpbInformações.Controls.Add(this.btnPreencherCliente);
            this.gpbInformações.Controls.Add(this.lblCliente);
            this.gpbInformações.Controls.Add(this.txtCodCliente);
            this.gpbInformações.Controls.Add(this.clbNFdevol);
            this.gpbInformações.Controls.Add(this.txtNFrefatura);
            this.gpbInformações.Controls.Add(this.txtNForigem);
            this.gpbInformações.Controls.Add(this.txtCodTransportadora);
            this.gpbInformações.Location = new System.Drawing.Point(253, 35);
            this.gpbInformações.Name = "gpbInformações";
            this.gpbInformações.Size = new System.Drawing.Size(498, 171);
            this.gpbInformações.TabIndex = 3;
            this.gpbInformações.TabStop = false;
            this.gpbInformações.Text = "Informações";
            // 
            // gpbRetornoFisico
            // 
            this.gpbRetornoFisico.Controls.Add(this.rdbNao);
            this.gpbRetornoFisico.Controls.Add(this.rdbSim);
            this.gpbRetornoFisico.Enabled = false;
            this.gpbRetornoFisico.Location = new System.Drawing.Point(385, 59);
            this.gpbRetornoFisico.Name = "gpbRetornoFisico";
            this.gpbRetornoFisico.Size = new System.Drawing.Size(107, 33);
            this.gpbRetornoFisico.TabIndex = 2;
            this.gpbRetornoFisico.TabStop = false;
            this.gpbRetornoFisico.Text = "Retorno físico";
            // 
            // rdbNao
            // 
            this.rdbNao.AutoSize = true;
            this.rdbNao.Location = new System.Drawing.Point(54, 13);
            this.rdbNao.Name = "rdbNao";
            this.rdbNao.Size = new System.Drawing.Size(45, 17);
            this.rdbNao.TabIndex = 1;
            this.rdbNao.TabStop = true;
            this.rdbNao.Text = "Não";
            this.rdbNao.UseVisualStyleBackColor = true;
            // 
            // rdbSim
            // 
            this.rdbSim.AutoSize = true;
            this.rdbSim.Location = new System.Drawing.Point(6, 13);
            this.rdbSim.Name = "rdbSim";
            this.rdbSim.Size = new System.Drawing.Size(42, 17);
            this.rdbSim.TabIndex = 0;
            this.rdbSim.TabStop = true;
            this.rdbSim.Text = "Sim";
            this.rdbSim.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "NF de refatura";
            // 
            // btnLimparNForigem
            // 
            this.btnLimparNForigem.BackColor = System.Drawing.Color.Transparent;
            this.btnLimparNForigem.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLimparVemelho;
            this.btnLimparNForigem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimparNForigem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimparNForigem.Location = new System.Drawing.Point(466, 95);
            this.btnLimparNForigem.Name = "btnLimparNForigem";
            this.btnLimparNForigem.Size = new System.Drawing.Size(26, 22);
            this.btnLimparNForigem.TabIndex = 29;
            this.btnLimparNForigem.TabStop = false;
            this.btnLimparNForigem.Click += new System.EventHandler(this.btnLimparNForigem_Click);
            // 
            // lblNForigem
            // 
            this.lblNForigem.AutoSize = true;
            this.lblNForigem.Location = new System.Drawing.Point(216, 79);
            this.lblNForigem.Name = "lblNForigem";
            this.lblNForigem.Size = new System.Drawing.Size(75, 13);
            this.lblNForigem.TabIndex = 28;
            this.lblNForigem.Text = "NFs de origem";
            // 
            // lblNFdevol
            // 
            this.lblNFdevol.AutoSize = true;
            this.lblNFdevol.Location = new System.Drawing.Point(6, 63);
            this.lblNFdevol.Name = "lblNFdevol";
            this.lblNFdevol.Size = new System.Drawing.Size(94, 13);
            this.lblNFdevol.TabIndex = 26;
            this.lblNFdevol.Text = "NFs de devolução";
            // 
            // clbNFdevol
            // 
            this.clbNFdevol.FormattingEnabled = true;
            this.clbNFdevol.Location = new System.Drawing.Point(9, 79);
            this.clbNFdevol.Name = "clbNFdevol";
            this.clbNFdevol.Size = new System.Drawing.Size(120, 79);
            this.clbNFdevol.TabIndex = 2;
            this.clbNFdevol.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbNFdevol_ItemCheck);
            // 
            // txtNFrefatura
            // 
            this.txtNFrefatura.Location = new System.Drawing.Point(141, 95);
            this.txtNFrefatura.Name = "txtNFrefatura";
            this.txtNFrefatura.Size = new System.Drawing.Size(72, 20);
            this.txtNFrefatura.TabIndex = 3;
            this.txtNFrefatura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // txtNForigem
            // 
            this.txtNForigem.Location = new System.Drawing.Point(219, 95);
            this.txtNForigem.Name = "txtNForigem";
            this.txtNForigem.ReadOnly = true;
            this.txtNForigem.Size = new System.Drawing.Size(241, 20);
            this.txtNForigem.TabIndex = 4;
            // 
            // cbxMotivo
            // 
            this.cbxMotivo.FormattingEnabled = true;
            this.cbxMotivo.Location = new System.Drawing.Point(5, 129);
            this.cbxMotivo.Name = "cbxMotivo";
            this.cbxMotivo.Size = new System.Drawing.Size(242, 21);
            this.cbxMotivo.TabIndex = 1;
            this.cbxMotivo.SelectedIndexChanged += new System.EventHandler(this.cbxMotivo_SelectedIndexChanged);
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(2, 114);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(39, 13);
            this.lblMotivo.TabIndex = 32;
            this.lblMotivo.Text = "Motivo";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(6, 212);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(745, 136);
            this.txtObservacao.TabIndex = 4;
            // 
            // lblObservacao
            // 
            this.lblObservacao.AutoSize = true;
            this.lblObservacao.Location = new System.Drawing.Point(3, 196);
            this.lblObservacao.Name = "lblObservacao";
            this.lblObservacao.Size = new System.Drawing.Size(65, 13);
            this.lblObservacao.TabIndex = 33;
            this.lblObservacao.Text = "Observação";
            // 
            // lblSetor
            // 
            this.lblSetor.AutoSize = true;
            this.lblSetor.Location = new System.Drawing.Point(3, 157);
            this.lblSetor.Name = "lblSetor";
            this.lblSetor.Size = new System.Drawing.Size(69, 13);
            this.lblSetor.TabIndex = 35;
            this.lblSetor.Text = "Responsável";
            // 
            // cbxSetor
            // 
            this.cbxSetor.FormattingEnabled = true;
            this.cbxSetor.Location = new System.Drawing.Point(6, 172);
            this.cbxSetor.Name = "cbxSetor";
            this.cbxSetor.Size = new System.Drawing.Size(241, 21);
            this.cbxSetor.TabIndex = 2;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.BackColor = System.Drawing.Color.Gray;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.ForeColor = System.Drawing.Color.White;
            this.btnLimpar.Location = new System.Drawing.Point(599, 354);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(73, 34);
            this.btnLimpar.TabIndex = 40;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnCriarCi
            // 
            this.btnCriarCi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCriarCi.BackColor = System.Drawing.Color.IndianRed;
            this.btnCriarCi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriarCi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriarCi.ForeColor = System.Drawing.Color.White;
            this.btnCriarCi.Location = new System.Drawing.Point(678, 354);
            this.btnCriarCi.Name = "btnCriarCi";
            this.btnCriarCi.Size = new System.Drawing.Size(73, 34);
            this.btnCriarCi.TabIndex = 41;
            this.btnCriarCi.Text = "Criar CI";
            this.btnCriarCi.UseVisualStyleBackColor = false;
            this.btnCriarCi.Click += new System.EventHandler(this.btnCriarCi_Click);
            // 
            // frmCriarCi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(757, 392);
            this.Controls.Add(this.btnCriarCi);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.lblSetor);
            this.Controls.Add(this.lblObservacao);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.gpbInformações);
            this.Controls.Add(this.lblCriarCi);
            this.Controls.Add(this.gpbTipoOperacao);
            this.Controls.Add(this.cbxMotivo);
            this.Controls.Add(this.cbxSetor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmCriarCi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CI";
            this.Load += new System.EventHandler(this.frmCriarCi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCriarCi_KeyDown);
            this.gpbTipoOperacao.ResumeLayout(false);
            this.gpbTipoOperacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherTransportadora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).EndInit();
            this.gpbInformações.ResumeLayout(false);
            this.gpbInformações.PerformLayout();
            this.gpbRetornoFisico.ResumeLayout(false);
            this.gpbRetornoFisico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimparNForigem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbTipoOperacao;
        private System.Windows.Forms.Label lblCriarCi;
        private System.Windows.Forms.RadioButton rdbDevParcial;
        private System.Windows.Forms.RadioButton rdbDevTotal;
        private System.Windows.Forms.PictureBox btnPreencherTransportadora;
        private System.Windows.Forms.PictureBox btnPreencherCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCodCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.TextBox txtCodTransportadora;
        private System.Windows.Forms.TextBox txtTransportadora;
        private System.Windows.Forms.GroupBox gpbInformações;
        private System.Windows.Forms.PictureBox btnLimparNForigem;
        private System.Windows.Forms.Label lblNForigem;
        private System.Windows.Forms.TextBox txtNForigem;
        private System.Windows.Forms.Label lblNFdevol;
        private System.Windows.Forms.CheckedListBox clbNFdevol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNFrefatura;
        private System.Windows.Forms.ComboBox cbxMotivo;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label lblObservacao;
        private System.Windows.Forms.Label lblSetor;
        private System.Windows.Forms.ComboBox cbxSetor;
        private System.Windows.Forms.GroupBox gpbRetornoFisico;
        private System.Windows.Forms.RadioButton rdbNao;
        private System.Windows.Forms.RadioButton rdbSim;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnCriarCi;
    }
}