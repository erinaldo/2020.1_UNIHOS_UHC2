namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Canhotos
{
    partial class frmCadastrarEmailTransportadora
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
            this.btnProcurarTransportadora = new System.Windows.Forms.PictureBox();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.txtCodTransportadora = new System.Windows.Forms.TextBox();
            this.lblConfigurarPercentualCidade = new System.Windows.Forms.Label();
            this.lsbEmail = new System.Windows.Forms.ListBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnAdicionarEmail = new System.Windows.Forms.Button();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcurarTransportadora)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcurarTransportadora
            // 
            this.btnProcurarTransportadora.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnProcurarTransportadora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProcurarTransportadora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurarTransportadora.Location = new System.Drawing.Point(328, 60);
            this.btnProcurarTransportadora.Name = "btnProcurarTransportadora";
            this.btnProcurarTransportadora.Size = new System.Drawing.Size(25, 23);
            this.btnProcurarTransportadora.TabIndex = 75;
            this.btnProcurarTransportadora.TabStop = false;
            this.btnProcurarTransportadora.Click += new System.EventHandler(this.btnProcurarTransportadora_Click);
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(16, 47);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(79, 13);
            this.lblTransportadora.TabIndex = 72;
            this.lblTransportadora.Text = "Transportadora";
            // 
            // txtTransportadora
            // 
            this.txtTransportadora.Location = new System.Drawing.Point(73, 63);
            this.txtTransportadora.Name = "txtTransportadora";
            this.txtTransportadora.ReadOnly = true;
            this.txtTransportadora.Size = new System.Drawing.Size(249, 20);
            this.txtTransportadora.TabIndex = 1;
            // 
            // txtCodTransportadora
            // 
            this.txtCodTransportadora.Location = new System.Drawing.Point(19, 63);
            this.txtCodTransportadora.MaxLength = 5;
            this.txtCodTransportadora.Name = "txtCodTransportadora";
            this.txtCodTransportadora.Size = new System.Drawing.Size(48, 20);
            this.txtCodTransportadora.TabIndex = 0;
            this.txtCodTransportadora.TextChanged += new System.EventHandler(this.txtCodTransportadora_TextChanged);
            this.txtCodTransportadora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodTransportadora_KeyDown);
            // 
            // lblConfigurarPercentualCidade
            // 
            this.lblConfigurarPercentualCidade.AutoSize = true;
            this.lblConfigurarPercentualCidade.BackColor = System.Drawing.Color.Gainsboro;
            this.lblConfigurarPercentualCidade.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Bold);
            this.lblConfigurarPercentualCidade.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblConfigurarPercentualCidade.Location = new System.Drawing.Point(15, 9);
            this.lblConfigurarPercentualCidade.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblConfigurarPercentualCidade.Name = "lblConfigurarPercentualCidade";
            this.lblConfigurarPercentualCidade.Size = new System.Drawing.Size(211, 33);
            this.lblConfigurarPercentualCidade.TabIndex = 0;
            this.lblConfigurarPercentualCidade.Text = "Cadastrar e-mail";
            // 
            // lsbEmail
            // 
            this.lsbEmail.FormattingEnabled = true;
            this.lsbEmail.Location = new System.Drawing.Point(19, 138);
            this.lsbEmail.Name = "lsbEmail";
            this.lsbEmail.Size = new System.Drawing.Size(334, 95);
            this.lsbEmail.TabIndex = 4;
            this.lsbEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsbEmail_KeyDown);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(19, 112);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(254, 20);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmail_KeyDown);
            // 
            // btnAdicionarEmail
            // 
            this.btnAdicionarEmail.Location = new System.Drawing.Point(279, 112);
            this.btnAdicionarEmail.Name = "btnAdicionarEmail";
            this.btnAdicionarEmail.Size = new System.Drawing.Size(66, 23);
            this.btnAdicionarEmail.TabIndex = 3;
            this.btnAdicionarEmail.Text = "Adicionar";
            this.btnAdicionarEmail.UseVisualStyleBackColor = true;
            this.btnAdicionarEmail.Click += new System.EventHandler(this.btnAdicionarEmail_Click);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(16, 96);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 79;
            this.lblEmail.Text = "Email";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(287, 239);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(66, 23);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(215, 239);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(66, 23);
            this.btnFechar.TabIndex = 6;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmCadastrarEmailTransportadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 274);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.btnAdicionarEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lsbEmail);
            this.Controls.Add(this.btnProcurarTransportadora);
            this.Controls.Add(this.lblTransportadora);
            this.Controls.Add(this.txtTransportadora);
            this.Controls.Add(this.txtCodTransportadora);
            this.Controls.Add(this.lblConfigurarPercentualCidade);
            this.MaximizeBox = false;
            this.Name = "frmCadastrarEmailTransportadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastrar e-mail de transportadora";
            this.Load += new System.EventHandler(this.frmCadastrarEmailTransportadora_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCadastrarEmailTransportadora_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnProcurarTransportadora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnProcurarTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.TextBox txtTransportadora;
        public System.Windows.Forms.TextBox txtCodTransportadora;
        private System.Windows.Forms.Label lblConfigurarPercentualCidade;
        private System.Windows.Forms.ListBox lsbEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnAdicionarEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnFechar;
    }
}