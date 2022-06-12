namespace Uni_Hospitalar_Controle_PE.UHC.Login
{
    partial class frmAlterarSenha
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
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblConfirmarSenha = new System.Windows.Forms.Label();
            this.txtConfirmarSenha = new System.Windows.Forms.TextBox();
            this.btnLimparConfirmarSenha = new System.Windows.Forms.PictureBox();
            this.btnLimparSenha = new System.Windows.Forms.PictureBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimparConfirmarSenha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimparSenha)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.BackColor = System.Drawing.Color.Transparent;
            this.lblSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSenha.Location = new System.Drawing.Point(48, 54);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(43, 13);
            this.lblSenha.TabIndex = 5;
            this.lblSenha.Text = "Senha";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(51, 68);
            this.txtSenha.MaxLength = 6;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(202, 20);
            this.txtSenha.TabIndex = 4;
            // 
            // lblConfirmarSenha
            // 
            this.lblConfirmarSenha.AutoSize = true;
            this.lblConfirmarSenha.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmarSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmarSenha.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblConfirmarSenha.Location = new System.Drawing.Point(48, 92);
            this.lblConfirmarSenha.Name = "lblConfirmarSenha";
            this.lblConfirmarSenha.Size = new System.Drawing.Size(98, 13);
            this.lblConfirmarSenha.TabIndex = 7;
            this.lblConfirmarSenha.Text = "Confirmar senha";
            // 
            // txtConfirmarSenha
            // 
            this.txtConfirmarSenha.Location = new System.Drawing.Point(51, 106);
            this.txtConfirmarSenha.MaxLength = 6;
            this.txtConfirmarSenha.Name = "txtConfirmarSenha";
            this.txtConfirmarSenha.PasswordChar = '*';
            this.txtConfirmarSenha.Size = new System.Drawing.Size(202, 20);
            this.txtConfirmarSenha.TabIndex = 6;
            this.txtConfirmarSenha.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnConfirmar_KeyUp);
            // 
            // btnLimparConfirmarSenha
            // 
            this.btnLimparConfirmarSenha.BackColor = System.Drawing.Color.Transparent;
            this.btnLimparConfirmarSenha.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.button_Limpar;
            this.btnLimparConfirmarSenha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimparConfirmarSenha.Location = new System.Drawing.Point(254, 102);
            this.btnLimparConfirmarSenha.Name = "btnLimparConfirmarSenha";
            this.btnLimparConfirmarSenha.Size = new System.Drawing.Size(23, 25);
            this.btnLimparConfirmarSenha.TabIndex = 11;
            this.btnLimparConfirmarSenha.TabStop = false;
            this.btnLimparConfirmarSenha.Click += new System.EventHandler(this.btnLimparConfirmarSenha_Click);
            // 
            // btnLimparSenha
            // 
            this.btnLimparSenha.BackColor = System.Drawing.Color.Transparent;
            this.btnLimparSenha.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.button_Limpar;
            this.btnLimparSenha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimparSenha.Location = new System.Drawing.Point(254, 66);
            this.btnLimparSenha.Name = "btnLimparSenha";
            this.btnLimparSenha.Size = new System.Drawing.Size(23, 25);
            this.btnLimparSenha.TabIndex = 10;
            this.btnLimparSenha.TabStop = false;
            this.btnLimparSenha.Tag = "";
            this.btnLimparSenha.Click += new System.EventHandler(this.btnLimparSenha_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(199, 129);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 12;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "6 dígitos aceitáveis";
            // 
            // frmAlterarSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.Tela_AlteracaoDeSenha;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnLimparConfirmarSenha);
            this.Controls.Add(this.btnLimparSenha);
            this.Controls.Add(this.lblConfirmarSenha);
            this.Controls.Add(this.txtConfirmarSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtSenha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAlterarSenha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAlterarSenha";
            this.Load += new System.EventHandler(this.frmAlterarSenha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnLimparConfirmarSenha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLimparSenha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblConfirmarSenha;
        private System.Windows.Forms.TextBox txtConfirmarSenha;
        private System.Windows.Forms.PictureBox btnLimparConfirmarSenha;
        private System.Windows.Forms.PictureBox btnLimparSenha;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label1;
    }
}