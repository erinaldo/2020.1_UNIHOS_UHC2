namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Usuarios
{
    partial class frmSelecionarPermissoes
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
            this.lblSelecionarPermissao = new System.Windows.Forms.Label();
            this.lsbListaPermissao = new System.Windows.Forms.ListBox();
            this.lsbAdicionaPermissoes = new System.Windows.Forms.ListBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.txtDescricaoRotina = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblSessao = new System.Windows.Forms.Label();
            this.txtSessao = new System.Windows.Forms.TextBox();
            this.chkPermissaoAdm = new System.Windows.Forms.CheckBox();
            this.lblRotinasAplicadas = new System.Windows.Forms.Label();
            this.lblListaDeRotinas = new System.Windows.Forms.Label();
            this.cbxSessao = new System.Windows.Forms.ComboBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblSetor = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.cbxSetor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblSelecionarPermissao
            // 
            this.lblSelecionarPermissao.AutoSize = true;
            this.lblSelecionarPermissao.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSelecionarPermissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelecionarPermissao.Location = new System.Drawing.Point(4, 3);
            this.lblSelecionarPermissao.Name = "lblSelecionarPermissao";
            this.lblSelecionarPermissao.Size = new System.Drawing.Size(239, 25);
            this.lblSelecionarPermissao.TabIndex = 3;
            this.lblSelecionarPermissao.Text = "Selecionar permissão";
            // 
            // lsbListaPermissao
            // 
            this.lsbListaPermissao.FormattingEnabled = true;
            this.lsbListaPermissao.Location = new System.Drawing.Point(12, 70);
            this.lsbListaPermissao.Name = "lsbListaPermissao";
            this.lsbListaPermissao.Size = new System.Drawing.Size(242, 511);
            this.lsbListaPermissao.TabIndex = 18;
            this.lsbListaPermissao.SelectedIndexChanged += new System.EventHandler(this.lsbListaPermissao_SelectedIndexChanged);
            this.lsbListaPermissao.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbListaPermissao_MouseDoubleClick);
            // 
            // lsbAdicionaPermissoes
            // 
            this.lsbAdicionaPermissoes.FormattingEnabled = true;
            this.lsbAdicionaPermissoes.Location = new System.Drawing.Point(339, 70);
            this.lsbAdicionaPermissoes.Name = "lsbAdicionaPermissoes";
            this.lsbAdicionaPermissoes.Size = new System.Drawing.Size(242, 511);
            this.lsbAdicionaPermissoes.TabIndex = 19;
            this.lsbAdicionaPermissoes.SelectedIndexChanged += new System.EventHandler(this.lsbAdicionaPermissoes_SelectedIndexChanged);
            this.lsbAdicionaPermissoes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbAdicionaPermissoes_MouseDoubleClick);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(260, 280);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 20;
            this.btnAdicionar.Text = ">>";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(260, 307);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 21;
            this.btnRemover.Text = "<<";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // txtDescricaoRotina
            // 
            this.txtDescricaoRotina.Location = new System.Drawing.Point(587, 76);
            this.txtDescricaoRotina.Multiline = true;
            this.txtDescricaoRotina.Name = "txtDescricaoRotina";
            this.txtDescricaoRotina.Size = new System.Drawing.Size(284, 166);
            this.txtDescricaoRotina.TabIndex = 22;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(584, 60);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(99, 13);
            this.lblDescricao.TabIndex = 23;
            this.lblDescricao.Text = "Descrição da rotina";
            // 
            // lblSessao
            // 
            this.lblSessao.AutoSize = true;
            this.lblSessao.Location = new System.Drawing.Point(581, 245);
            this.lblSessao.Name = "lblSessao";
            this.lblSessao.Size = new System.Drawing.Size(42, 13);
            this.lblSessao.TabIndex = 25;
            this.lblSessao.Text = "Sessão";
            // 
            // txtSessao
            // 
            this.txtSessao.Location = new System.Drawing.Point(587, 261);
            this.txtSessao.Name = "txtSessao";
            this.txtSessao.Size = new System.Drawing.Size(281, 20);
            this.txtSessao.TabIndex = 24;
            // 
            // chkPermissaoAdm
            // 
            this.chkPermissaoAdm.AutoSize = true;
            this.chkPermissaoAdm.Location = new System.Drawing.Point(470, 48);
            this.chkPermissaoAdm.Name = "chkPermissaoAdm";
            this.chkPermissaoAdm.Size = new System.Drawing.Size(105, 17);
            this.chkPermissaoAdm.TabIndex = 26;
            this.chkPermissaoAdm.Text = "Permissão admin";
            this.chkPermissaoAdm.UseVisualStyleBackColor = true;
            this.chkPermissaoAdm.CheckedChanged += new System.EventHandler(this.chkPermissaoAdm_CheckedChanged);
            // 
            // lblRotinasAplicadas
            // 
            this.lblRotinasAplicadas.AutoSize = true;
            this.lblRotinasAplicadas.Location = new System.Drawing.Point(336, 54);
            this.lblRotinasAplicadas.Name = "lblRotinasAplicadas";
            this.lblRotinasAplicadas.Size = new System.Drawing.Size(91, 13);
            this.lblRotinasAplicadas.TabIndex = 27;
            this.lblRotinasAplicadas.Text = "Rotinas aplicadas";
            // 
            // lblListaDeRotinas
            // 
            this.lblListaDeRotinas.AutoSize = true;
            this.lblListaDeRotinas.Location = new System.Drawing.Point(12, 54);
            this.lblListaDeRotinas.Name = "lblListaDeRotinas";
            this.lblListaDeRotinas.Size = new System.Drawing.Size(78, 13);
            this.lblListaDeRotinas.TabIndex = 28;
            this.lblListaDeRotinas.Text = "Lista de rotinas";
            // 
            // cbxSessao
            // 
            this.cbxSessao.FormattingEnabled = true;
            this.cbxSessao.Location = new System.Drawing.Point(133, 46);
            this.cbxSessao.Name = "cbxSessao";
            this.cbxSessao.Size = new System.Drawing.Size(121, 21);
            this.cbxSessao.TabIndex = 29;
            this.cbxSessao.SelectedIndexChanged += new System.EventHandler(this.cbxSessao_SelectedIndexChanged);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(634, 332);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(49, 16);
            this.lblNome.TabIndex = 30;
            this.lblNome.Text = "Name";
            // 
            // lblSetor
            // 
            this.lblSetor.AutoSize = true;
            this.lblSetor.Location = new System.Drawing.Point(634, 363);
            this.lblSetor.Name = "lblSetor";
            this.lblSetor.Size = new System.Drawing.Size(32, 13);
            this.lblSetor.TabIndex = 31;
            this.lblSetor.Text = "Setor";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(634, 349);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(33, 13);
            this.lblLogin.TabIndex = 32;
            this.lblLogin.Text = "Login";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(797, 558);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 33;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // cbxSetor
            // 
            this.cbxSetor.FormattingEnabled = true;
            this.cbxSetor.Items.AddRange(new object[] {
            "Financeiro",
            "Administrativo",
            "Logística",
            "Vendas",
            "Licitação",
            "Opções"});
            this.cbxSetor.Location = new System.Drawing.Point(260, 118);
            this.cbxSetor.Name = "cbxSetor";
            this.cbxSetor.Size = new System.Drawing.Size(73, 21);
            this.cbxSetor.TabIndex = 34;
            this.cbxSetor.SelectedIndexChanged += new System.EventHandler(this.CbxSetor_SelectedIndexChanged);
            // 
            // frmSelecionarPermissoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.ClientSize = new System.Drawing.Size(884, 593);
            this.Controls.Add(this.cbxSetor);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblSetor);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.cbxSessao);
            this.Controls.Add(this.lblListaDeRotinas);
            this.Controls.Add(this.lblRotinasAplicadas);
            this.Controls.Add(this.chkPermissaoAdm);
            this.Controls.Add(this.lblSessao);
            this.Controls.Add(this.txtSessao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricaoRotina);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.lsbAdicionaPermissoes);
            this.Controls.Add(this.lsbListaPermissao);
            this.Controls.Add(this.lblSelecionarPermissao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSelecionarPermissoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuários";
            this.Load += new System.EventHandler(this.frmSelecionarPermissoes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSelecionarPermissao;
        private System.Windows.Forms.ListBox lsbListaPermissao;
        private System.Windows.Forms.ListBox lsbAdicionaPermissoes;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.TextBox txtDescricaoRotina;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblSessao;
        private System.Windows.Forms.TextBox txtSessao;
        private System.Windows.Forms.CheckBox chkPermissaoAdm;
        private System.Windows.Forms.Label lblRotinasAplicadas;
        private System.Windows.Forms.Label lblListaDeRotinas;
        private System.Windows.Forms.ComboBox cbxSessao;
        public System.Windows.Forms.Label lblNome;
        public System.Windows.Forms.Label lblSetor;
        public System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.ComboBox cbxSetor;
    }
}