namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Usuarios
{
    partial class frmEditarUsuario
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
            this.lblControleDeUsuarios = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComputador = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnResetSenha = new System.Windows.Forms.Button();
            this.cbxSetor = new System.Windows.Forms.ComboBox();
            this.lblSetor = new System.Windows.Forms.Label();
            this.btnInserirSetor = new System.Windows.Forms.PictureBox();
            this.btnPermissoes = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnInserirSetor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblControleDeUsuarios
            // 
            this.lblControleDeUsuarios.AutoSize = true;
            this.lblControleDeUsuarios.BackColor = System.Drawing.Color.Gainsboro;
            this.lblControleDeUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControleDeUsuarios.Location = new System.Drawing.Point(6, 5);
            this.lblControleDeUsuarios.Name = "lblControleDeUsuarios";
            this.lblControleDeUsuarios.Size = new System.Drawing.Size(258, 25);
            this.lblControleDeUsuarios.TabIndex = 3;
            this.lblControleDeUsuarios.Text = "Informações de usuário";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 54);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(197, 20);
            this.txtNome.TabIndex = 4;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(281, 10);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(35, 18);
            this.lblCodigo.TabIndex = 5;
            this.lblCodigo.Text = "123";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(9, 38);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 6;
            this.lblNome.Text = "Nome";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(212, 38);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 8;
            this.lblUsuario.Text = "Usuário";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(215, 54);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(112, 20);
            this.txtUsuario.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Computador";
            // 
            // txtComputador
            // 
            this.txtComputador.Location = new System.Drawing.Point(237, 93);
            this.txtComputador.Name = "txtComputador";
            this.txtComputador.Size = new System.Drawing.Size(90, 20);
            this.txtComputador.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(8, 77);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(11, 93);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(220, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(12, 189);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(81, 22);
            this.btnExcluir.TabIndex = 18;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnResetSenha
            // 
            this.btnResetSenha.Location = new System.Drawing.Point(99, 161);
            this.btnResetSenha.Name = "btnResetSenha";
            this.btnResetSenha.Size = new System.Drawing.Size(75, 22);
            this.btnResetSenha.TabIndex = 19;
            this.btnResetSenha.Text = "Reset senha";
            this.btnResetSenha.UseVisualStyleBackColor = true;
            this.btnResetSenha.Click += new System.EventHandler(this.btnResetSenha_Click);
            // 
            // cbxSetor
            // 
            this.cbxSetor.FormattingEnabled = true;
            this.cbxSetor.Location = new System.Drawing.Point(12, 134);
            this.cbxSetor.Name = "cbxSetor";
            this.cbxSetor.Size = new System.Drawing.Size(134, 21);
            this.cbxSetor.TabIndex = 20;
            // 
            // lblSetor
            // 
            this.lblSetor.AutoSize = true;
            this.lblSetor.Location = new System.Drawing.Point(9, 121);
            this.lblSetor.Name = "lblSetor";
            this.lblSetor.Size = new System.Drawing.Size(32, 13);
            this.lblSetor.TabIndex = 21;
            this.lblSetor.Text = "Setor";
            // 
            // btnInserirSetor
            // 
            this.btnInserirSetor.BackColor = System.Drawing.Color.Transparent;
            this.btnInserirSetor.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnInserirSetor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInserirSetor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInserirSetor.Location = new System.Drawing.Point(152, 134);
            this.btnInserirSetor.Name = "btnInserirSetor";
            this.btnInserirSetor.Size = new System.Drawing.Size(22, 21);
            this.btnInserirSetor.TabIndex = 22;
            this.btnInserirSetor.TabStop = false;
            this.btnInserirSetor.Click += new System.EventHandler(this.btnInserirSetor_Click);
            // 
            // btnPermissoes
            // 
            this.btnPermissoes.Location = new System.Drawing.Point(11, 161);
            this.btnPermissoes.Name = "btnPermissoes";
            this.btnPermissoes.Size = new System.Drawing.Size(82, 22);
            this.btnPermissoes.TabIndex = 23;
            this.btnPermissoes.Text = "Permissões";
            this.btnPermissoes.UseVisualStyleBackColor = true;
            this.btnPermissoes.Click += new System.EventHandler(this.btnPermissoes_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(252, 189);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 22);
            this.btnEditar.TabIndex = 24;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(252, 161);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 22);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmEditarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.ClientSize = new System.Drawing.Size(335, 221);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnPermissoes);
            this.Controls.Add(this.btnInserirSetor);
            this.Controls.Add(this.lblSetor);
            this.Controls.Add(this.cbxSetor);
            this.Controls.Add(this.btnResetSenha);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtComputador);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblControleDeUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmEditarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuário";
            this.Load += new System.EventHandler(this.frmEditarUsuario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEditarUsuario_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnInserirSetor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblControleDeUsuarios;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtComputador;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnResetSenha;
        private System.Windows.Forms.ComboBox cbxSetor;
        private System.Windows.Forms.Label lblSetor;
        private System.Windows.Forms.PictureBox btnInserirSetor;
        private System.Windows.Forms.Button btnPermissoes;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnCancelar;
    }
}