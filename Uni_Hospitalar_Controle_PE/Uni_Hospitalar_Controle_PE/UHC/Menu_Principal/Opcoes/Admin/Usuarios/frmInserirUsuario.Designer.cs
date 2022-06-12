namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Usuarios
{
    partial class frmInserirUsuario
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
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtComputador = new System.Windows.Forms.TextBox();
            this.lblComputador = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblSetor = new System.Windows.Forms.Label();
            this.cbxSetor = new System.Windows.Forms.ComboBox();
            this.lblPermissao = new System.Windows.Forms.Label();
            this.btnInserirSetor = new System.Windows.Forms.PictureBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnInserirSetor)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(12, 68);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(12, 25);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(201, 20);
            this.txtNome.TabIndex = 0;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(9, 9);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 3;
            this.lblNome.Text = "Nome";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(9, 52);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Usuário";
            // 
            // txtComputador
            // 
            this.txtComputador.Location = new System.Drawing.Point(219, 25);
            this.txtComputador.Name = "txtComputador";
            this.txtComputador.Size = new System.Drawing.Size(89, 20);
            this.txtComputador.TabIndex = 1;
            // 
            // lblComputador
            // 
            this.lblComputador.AutoSize = true;
            this.lblComputador.Location = new System.Drawing.Point(216, 9);
            this.lblComputador.Name = "lblComputador";
            this.lblComputador.Size = new System.Drawing.Size(64, 13);
            this.lblComputador.TabIndex = 6;
            this.lblComputador.Text = "Computador";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 113);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(296, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(9, 97);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 8;
            this.lblEmail.Text = "E-mail";
            // 
            // lblSetor
            // 
            this.lblSetor.AutoSize = true;
            this.lblSetor.Location = new System.Drawing.Point(115, 52);
            this.lblSetor.Name = "lblSetor";
            this.lblSetor.Size = new System.Drawing.Size(32, 13);
            this.lblSetor.TabIndex = 10;
            this.lblSetor.Text = "Setor";
            // 
            // cbxSetor
            // 
            this.cbxSetor.FormattingEnabled = true;
            this.cbxSetor.Location = new System.Drawing.Point(118, 68);
            this.cbxSetor.Name = "cbxSetor";
            this.cbxSetor.Size = new System.Drawing.Size(162, 21);
            this.cbxSetor.TabIndex = 3;
            // 
            // lblPermissao
            // 
            this.lblPermissao.AutoSize = true;
            this.lblPermissao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPermissao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblPermissao.Location = new System.Drawing.Point(12, 153);
            this.lblPermissao.Name = "lblPermissao";
            this.lblPermissao.Size = new System.Drawing.Size(91, 17);
            this.lblPermissao.TabIndex = 5;
            this.lblPermissao.Text = "Permissões";
            this.lblPermissao.Click += new System.EventHandler(this.lblPermissao_Click);
            this.lblPermissao.MouseLeave += new System.EventHandler(this.lblPermissao_Leave);
            this.lblPermissao.MouseHover += new System.EventHandler(this.lblPermissao_Hover);
            // 
            // btnInserirSetor
            // 
            this.btnInserirSetor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInserirSetor.BackColor = System.Drawing.Color.Transparent;
            this.btnInserirSetor.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnInserirSetor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnInserirSetor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInserirSetor.Location = new System.Drawing.Point(286, 68);
            this.btnInserirSetor.Name = "btnInserirSetor";
            this.btnInserirSetor.Size = new System.Drawing.Size(22, 21);
            this.btnInserirSetor.TabIndex = 17;
            this.btnInserirSetor.TabStop = false;
            this.btnInserirSetor.Click += new System.EventHandler(this.btnInserirSetor_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(233, 153);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 18;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmInserirUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.ClientSize = new System.Drawing.Size(320, 186);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnInserirSetor);
            this.Controls.Add(this.lblPermissao);
            this.Controls.Add(this.cbxSetor);
            this.Controls.Add(this.lblSetor);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblComputador);
            this.Controls.Add(this.txtComputador);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmInserirUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inserir usuário";
            this.Load += new System.EventHandler(this.frmInserirUsuario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInserirUsuario_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnInserirSetor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtComputador;
        private System.Windows.Forms.Label lblComputador;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblSetor;
        private System.Windows.Forms.ComboBox cbxSetor;
        private System.Windows.Forms.Label lblPermissao;
        private System.Windows.Forms.PictureBox btnInserirSetor;
        private System.Windows.Forms.Button btnConfirmar;
    }
}