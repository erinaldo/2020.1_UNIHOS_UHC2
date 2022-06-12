namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Usuarios
{
    partial class frmEditarPermissoes
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
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblSetor = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.cbxSessao = new System.Windows.Forms.ComboBox();
            this.lblListaDeRotinas = new System.Windows.Forms.Label();
            this.lblRotinasAplicadas = new System.Windows.Forms.Label();
            this.chkPermissaoAdm = new System.Windows.Forms.CheckBox();
            this.lblSessao = new System.Windows.Forms.Label();
            this.txtSessao = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricaoRotina = new System.Windows.Forms.TextBox();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.lsbAdicionaPermissoes = new System.Windows.Forms.ListBox();
            this.lsbListaPermissao = new System.Windows.Forms.ListBox();
            this.lblSelecionarPermissao = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.cbxSetor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(642, 355);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(33, 13);
            this.lblLogin.TabIndex = 49;
            this.lblLogin.Text = "Login";
            // 
            // lblSetor
            // 
            this.lblSetor.AutoSize = true;
            this.lblSetor.Location = new System.Drawing.Point(642, 369);
            this.lblSetor.Name = "lblSetor";
            this.lblSetor.Size = new System.Drawing.Size(32, 13);
            this.lblSetor.TabIndex = 48;
            this.lblSetor.Text = "Setor";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(642, 338);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(49, 16);
            this.lblNome.TabIndex = 47;
            this.lblNome.Text = "Name";
            // 
            // cbxSessao
            // 
            this.cbxSessao.FormattingEnabled = true;
            this.cbxSessao.Location = new System.Drawing.Point(141, 52);
            this.cbxSessao.Name = "cbxSessao";
            this.cbxSessao.Size = new System.Drawing.Size(121, 21);
            this.cbxSessao.TabIndex = 46;
            this.cbxSessao.SelectedIndexChanged += new System.EventHandler(this.cbxSessao_SelectedIndexChanged);
            // 
            // lblListaDeRotinas
            // 
            this.lblListaDeRotinas.AutoSize = true;
            this.lblListaDeRotinas.Location = new System.Drawing.Point(20, 60);
            this.lblListaDeRotinas.Name = "lblListaDeRotinas";
            this.lblListaDeRotinas.Size = new System.Drawing.Size(78, 13);
            this.lblListaDeRotinas.TabIndex = 45;
            this.lblListaDeRotinas.Text = "Lista de rotinas";
            // 
            // lblRotinasAplicadas
            // 
            this.lblRotinasAplicadas.AutoSize = true;
            this.lblRotinasAplicadas.Location = new System.Drawing.Point(344, 60);
            this.lblRotinasAplicadas.Name = "lblRotinasAplicadas";
            this.lblRotinasAplicadas.Size = new System.Drawing.Size(91, 13);
            this.lblRotinasAplicadas.TabIndex = 44;
            this.lblRotinasAplicadas.Text = "Rotinas aplicadas";
            // 
            // chkPermissaoAdm
            // 
            this.chkPermissaoAdm.AutoSize = true;
            this.chkPermissaoAdm.Location = new System.Drawing.Point(478, 54);
            this.chkPermissaoAdm.Name = "chkPermissaoAdm";
            this.chkPermissaoAdm.Size = new System.Drawing.Size(105, 17);
            this.chkPermissaoAdm.TabIndex = 43;
            this.chkPermissaoAdm.Text = "Permissão admin";
            this.chkPermissaoAdm.UseVisualStyleBackColor = true;
            this.chkPermissaoAdm.CheckedChanged += new System.EventHandler(this.chkPermissaoAdm_CheckedChanged);
            // 
            // lblSessao
            // 
            this.lblSessao.AutoSize = true;
            this.lblSessao.Location = new System.Drawing.Point(589, 251);
            this.lblSessao.Name = "lblSessao";
            this.lblSessao.Size = new System.Drawing.Size(42, 13);
            this.lblSessao.TabIndex = 42;
            this.lblSessao.Text = "Sessão";
            // 
            // txtSessao
            // 
            this.txtSessao.Location = new System.Drawing.Point(595, 267);
            this.txtSessao.Name = "txtSessao";
            this.txtSessao.Size = new System.Drawing.Size(281, 20);
            this.txtSessao.TabIndex = 41;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(592, 66);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(99, 13);
            this.lblDescricao.TabIndex = 40;
            this.lblDescricao.Text = "Descrição da rotina";
            // 
            // txtDescricaoRotina
            // 
            this.txtDescricaoRotina.Location = new System.Drawing.Point(595, 82);
            this.txtDescricaoRotina.Multiline = true;
            this.txtDescricaoRotina.Name = "txtDescricaoRotina";
            this.txtDescricaoRotina.Size = new System.Drawing.Size(284, 166);
            this.txtDescricaoRotina.TabIndex = 39;
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(268, 313);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 38;
            this.btnRemover.Text = "<<";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(268, 286);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 37;
            this.btnAdicionar.Text = ">>";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // lsbAdicionaPermissoes
            // 
            this.lsbAdicionaPermissoes.FormattingEnabled = true;
            this.lsbAdicionaPermissoes.Location = new System.Drawing.Point(347, 76);
            this.lsbAdicionaPermissoes.Name = "lsbAdicionaPermissoes";
            this.lsbAdicionaPermissoes.Size = new System.Drawing.Size(242, 511);
            this.lsbAdicionaPermissoes.TabIndex = 36;
            this.lsbAdicionaPermissoes.SelectedIndexChanged += new System.EventHandler(this.lsbAdicionaPermissoes_SelectedIndexChanged);
            this.lsbAdicionaPermissoes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbAdicionaPermissoes_MouseDoubleClick);
            // 
            // lsbListaPermissao
            // 
            this.lsbListaPermissao.FormattingEnabled = true;
            this.lsbListaPermissao.Location = new System.Drawing.Point(20, 76);
            this.lsbListaPermissao.Name = "lsbListaPermissao";
            this.lsbListaPermissao.Size = new System.Drawing.Size(242, 511);
            this.lsbListaPermissao.TabIndex = 35;
            this.lsbListaPermissao.SelectedIndexChanged += new System.EventHandler(this.lsbListaPermissao_SelectedIndexChanged);
            this.lsbListaPermissao.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbListaPermissao_MouseDoubleClick);
            // 
            // lblSelecionarPermissao
            // 
            this.lblSelecionarPermissao.AutoSize = true;
            this.lblSelecionarPermissao.BackColor = System.Drawing.Color.Gainsboro;
            this.lblSelecionarPermissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelecionarPermissao.Location = new System.Drawing.Point(12, 9);
            this.lblSelecionarPermissao.Name = "lblSelecionarPermissao";
            this.lblSelecionarPermissao.Size = new System.Drawing.Size(189, 25);
            this.lblSelecionarPermissao.TabIndex = 33;
            this.lblSelecionarPermissao.Text = "Editar permissão";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(804, 561);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 50;
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
            this.cbxSetor.Location = new System.Drawing.Point(268, 102);
            this.cbxSetor.Name = "cbxSetor";
            this.cbxSetor.Size = new System.Drawing.Size(73, 21);
            this.cbxSetor.TabIndex = 51;
            this.cbxSetor.SelectedIndexChanged += new System.EventHandler(this.CbxSetor_SelectedIndexChanged);
            // 
            // frmEditarPermissoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.ClientSize = new System.Drawing.Size(891, 596);
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
            this.KeyPreview = true;
            this.Name = "frmEditarPermissoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuário";
            this.Load += new System.EventHandler(this.frmEditarPermissoes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEditarPermissoes_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblLogin;
        public System.Windows.Forms.Label lblSetor;
        public System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.ComboBox cbxSessao;
        private System.Windows.Forms.Label lblListaDeRotinas;
        private System.Windows.Forms.Label lblRotinasAplicadas;
        private System.Windows.Forms.CheckBox chkPermissaoAdm;
        private System.Windows.Forms.Label lblSessao;
        private System.Windows.Forms.TextBox txtSessao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricaoRotina;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.ListBox lsbAdicionaPermissoes;
        private System.Windows.Forms.ListBox lsbListaPermissao;
        private System.Windows.Forms.Label lblSelecionarPermissao;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.ComboBox cbxSetor;
    }
}