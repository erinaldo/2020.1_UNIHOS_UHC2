namespace Uni_Hospitalar_Controle_PE.UHC.Login
{
    partial class frmLogin
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
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.lblVersao = new System.Windows.Forms.Label();
            this.btnLimparLogin = new System.Windows.Forms.PictureBox();
            this.btnLimparSenha = new System.Windows.Forms.PictureBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gpbUnidade = new System.Windows.Forms.GroupBox();
            this.rdbSP = new System.Windows.Forms.RadioButton();
            this.rdbCE = new System.Windows.Forms.RadioButton();
            this.rdbPE = new System.Windows.Forms.RadioButton();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimparLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimparSenha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gpbUnidade.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(217, 190);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(202, 20);
            this.txtLogin.TabIndex = 0;
            this.txtLogin.TextChanged += new System.EventHandler(this.txtLogin_TextChanged);
            this.txtLogin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLoginSenha_KeyUp);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(217, 227);
            this.txtSenha.MaxLength = 6;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(202, 20);
            this.txtSenha.TabIndex = 1;
            this.txtSenha.TextChanged += new System.EventHandler(this.txtSenha_TextChanged);
            this.txtSenha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtLoginSenha_KeyUp);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(214, 174);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(38, 13);
            this.lblLogin.TabIndex = 2;
            this.lblLogin.Text = "Login";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.BackColor = System.Drawing.Color.Transparent;
            this.lblSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.Location = new System.Drawing.Point(214, 213);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(43, 13);
            this.lblSenha.TabIndex = 3;
            this.lblSenha.Text = "Senha";
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.BackColor = System.Drawing.Color.Transparent;
            this.lblVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersao.Location = new System.Drawing.Point(289, 295);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(79, 13);
            this.lblVersao.TabIndex = 7;
            this.lblVersao.Text = "Versão 5.0.6";
            // 
            // btnLimparLogin
            // 
            this.btnLimparLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLimparLogin.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.button_Limpar;
            this.btnLimparLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimparLogin.Location = new System.Drawing.Point(425, 188);
            this.btnLimparLogin.Name = "btnLimparLogin";
            this.btnLimparLogin.Size = new System.Drawing.Size(23, 25);
            this.btnLimparLogin.TabIndex = 8;
            this.btnLimparLogin.TabStop = false;
            this.btnLimparLogin.Tag = "";
            this.btnLimparLogin.Click += new System.EventHandler(this.btnLimparLogin_Click);
            this.btnLimparLogin.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnLimparLogin.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // btnLimparSenha
            // 
            this.btnLimparSenha.BackColor = System.Drawing.Color.Transparent;
            this.btnLimparSenha.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.button_Limpar;
            this.btnLimparSenha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimparSenha.Location = new System.Drawing.Point(425, 224);
            this.btnLimparSenha.Name = "btnLimparSenha";
            this.btnLimparSenha.Size = new System.Drawing.Size(23, 25);
            this.btnLimparSenha.TabIndex = 9;
            this.btnLimparSenha.TabStop = false;
            this.btnLimparSenha.Click += new System.EventHandler(this.btnLimparSenha_Click);
            this.btnLimparSenha.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.btnLimparSenha.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(209, 258);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(77, 13);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Pernambuco";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.button_GLPI;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(568, 412);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 34);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnSuporte_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.btn_MouseHover);
            // 
            // gpbUnidade
            // 
            this.gpbUnidade.Controls.Add(this.rdbSP);
            this.gpbUnidade.Controls.Add(this.rdbCE);
            this.gpbUnidade.Controls.Add(this.rdbPE);
            this.gpbUnidade.Location = new System.Drawing.Point(255, 132);
            this.gpbUnidade.Name = "gpbUnidade";
            this.gpbUnidade.Size = new System.Drawing.Size(137, 34);
            this.gpbUnidade.TabIndex = 14;
            this.gpbUnidade.TabStop = false;
            this.gpbUnidade.Text = "Unidade";
            // 
            // rdbSP
            // 
            this.rdbSP.AutoSize = true;
            this.rdbSP.Location = new System.Drawing.Point(92, 14);
            this.rdbSP.Name = "rdbSP";
            this.rdbSP.Size = new System.Drawing.Size(39, 17);
            this.rdbSP.TabIndex = 2;
            this.rdbSP.Text = "SP";
            this.rdbSP.UseVisualStyleBackColor = true;
            // 
            // rdbCE
            // 
            this.rdbCE.AutoSize = true;
            this.rdbCE.Location = new System.Drawing.Point(47, 14);
            this.rdbCE.Name = "rdbCE";
            this.rdbCE.Size = new System.Drawing.Size(39, 17);
            this.rdbCE.TabIndex = 1;
            this.rdbCE.Text = "CE";
            this.rdbCE.UseVisualStyleBackColor = true;
            // 
            // rdbPE
            // 
            this.rdbPE.AutoSize = true;
            this.rdbPE.Checked = true;
            this.rdbPE.Location = new System.Drawing.Point(9, 14);
            this.rdbPE.Name = "rdbPE";
            this.rdbPE.Size = new System.Drawing.Size(39, 17);
            this.rdbPE.TabIndex = 0;
            this.rdbPE.TabStop = true;
            this.rdbPE.Text = "PE";
            this.rdbPE.UseVisualStyleBackColor = true;
            // 
            // btnEntrar
            // 
            this.btnEntrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEntrar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnEntrar.ForeColor = System.Drawing.Color.White;
            this.btnEntrar.Location = new System.Drawing.Point(383, 253);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(64, 23);
            this.btnEntrar.TabIndex = 40;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(313, 253);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(64, 23);
            this.btnFechar.TabIndex = 39;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.Tela_Login;
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gpbUnidade);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnLimparSenha);
            this.Controls.Add(this.btnLimparLogin);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnLimparLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimparSenha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gpbUnidade.ResumeLayout(false);
            this.gpbUnidade.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.PictureBox btnLimparLogin;
        private System.Windows.Forms.PictureBox btnLimparSenha;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gpbUnidade;
        private System.Windows.Forms.RadioButton rdbSP;
        private System.Windows.Forms.RadioButton rdbCE;
        private System.Windows.Forms.RadioButton rdbPE;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.Button btnFechar;
    }
}