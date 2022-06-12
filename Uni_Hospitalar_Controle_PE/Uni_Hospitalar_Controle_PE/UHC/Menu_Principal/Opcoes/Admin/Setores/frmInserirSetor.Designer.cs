namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Setores
{
    partial class frmInserirSetor
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
            this.lblInserirSetor = new System.Windows.Forms.Label();
            this.txtSetor = new System.Windows.Forms.TextBox();
            this.txtEmailSetor = new System.Windows.Forms.TextBox();
            this.lblDescricaoSetor = new System.Windows.Forms.Label();
            this.lblEmailSetor = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInserirSetor
            // 
            this.lblInserirSetor.AutoSize = true;
            this.lblInserirSetor.BackColor = System.Drawing.Color.Gainsboro;
            this.lblInserirSetor.Font = new System.Drawing.Font("Open Sans", 20F, System.Drawing.FontStyle.Bold);
            this.lblInserirSetor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInserirSetor.Location = new System.Drawing.Point(4, 9);
            this.lblInserirSetor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblInserirSetor.Name = "lblInserirSetor";
            this.lblInserirSetor.Size = new System.Drawing.Size(182, 37);
            this.lblInserirSetor.TabIndex = 21;
            this.lblInserirSetor.Text = "Inserir setor";
            // 
            // txtSetor
            // 
            this.txtSetor.Location = new System.Drawing.Point(11, 71);
            this.txtSetor.MaxLength = 30;
            this.txtSetor.Name = "txtSetor";
            this.txtSetor.Size = new System.Drawing.Size(142, 20);
            this.txtSetor.TabIndex = 22;
            // 
            // txtEmailSetor
            // 
            this.txtEmailSetor.Location = new System.Drawing.Point(12, 109);
            this.txtEmailSetor.MaxLength = 50;
            this.txtEmailSetor.Name = "txtEmailSetor";
            this.txtEmailSetor.Size = new System.Drawing.Size(248, 20);
            this.txtEmailSetor.TabIndex = 23;
            // 
            // lblDescricaoSetor
            // 
            this.lblDescricaoSetor.AutoSize = true;
            this.lblDescricaoSetor.BackColor = System.Drawing.Color.Transparent;
            this.lblDescricaoSetor.Location = new System.Drawing.Point(9, 55);
            this.lblDescricaoSetor.Name = "lblDescricaoSetor";
            this.lblDescricaoSetor.Size = new System.Drawing.Size(96, 13);
            this.lblDescricaoSetor.TabIndex = 24;
            this.lblDescricaoSetor.Text = "Descrição do setor";
            // 
            // lblEmailSetor
            // 
            this.lblEmailSetor.AutoSize = true;
            this.lblEmailSetor.BackColor = System.Drawing.Color.Transparent;
            this.lblEmailSetor.Location = new System.Drawing.Point(8, 93);
            this.lblEmailSetor.Name = "lblEmailSetor";
            this.lblEmailSetor.Size = new System.Drawing.Size(76, 13);
            this.lblEmailSetor.TabIndex = 25;
            this.lblEmailSetor.Text = "E-mail do setor";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(186, 142);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 37;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmInserirSetor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.ClientSize = new System.Drawing.Size(273, 172);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblEmailSetor);
            this.Controls.Add(this.lblDescricaoSetor);
            this.Controls.Add(this.txtEmailSetor);
            this.Controls.Add(this.txtSetor);
            this.Controls.Add(this.lblInserirSetor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmInserirSetor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setores";
            this.Load += new System.EventHandler(this.frmInserirSetor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInserirSetor_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInserirSetor;
        private System.Windows.Forms.TextBox txtSetor;
        private System.Windows.Forms.TextBox txtEmailSetor;
        private System.Windows.Forms.Label lblDescricaoSetor;
        private System.Windows.Forms.Label lblEmailSetor;
        private System.Windows.Forms.Button btnConfirmar;
    }
}