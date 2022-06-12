namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Setores
{
    partial class frmEditarSetor
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
            this.lblEmailSetor = new System.Windows.Forms.Label();
            this.lblDescricaoSetor = new System.Windows.Forms.Label();
            this.txtEmailSetor = new System.Windows.Forms.TextBox();
            this.txtSetor = new System.Windows.Forms.TextBox();
            this.lblEditarSetor = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEmailSetor
            // 
            this.lblEmailSetor.AutoSize = true;
            this.lblEmailSetor.BackColor = System.Drawing.Color.Transparent;
            this.lblEmailSetor.Location = new System.Drawing.Point(8, 87);
            this.lblEmailSetor.Name = "lblEmailSetor";
            this.lblEmailSetor.Size = new System.Drawing.Size(76, 13);
            this.lblEmailSetor.TabIndex = 33;
            this.lblEmailSetor.Text = "E-mail do setor";
            // 
            // lblDescricaoSetor
            // 
            this.lblDescricaoSetor.AutoSize = true;
            this.lblDescricaoSetor.BackColor = System.Drawing.Color.Transparent;
            this.lblDescricaoSetor.Location = new System.Drawing.Point(9, 49);
            this.lblDescricaoSetor.Name = "lblDescricaoSetor";
            this.lblDescricaoSetor.Size = new System.Drawing.Size(96, 13);
            this.lblDescricaoSetor.TabIndex = 32;
            this.lblDescricaoSetor.Text = "Descrição do setor";
            // 
            // txtEmailSetor
            // 
            this.txtEmailSetor.Location = new System.Drawing.Point(12, 103);
            this.txtEmailSetor.MaxLength = 50;
            this.txtEmailSetor.Name = "txtEmailSetor";
            this.txtEmailSetor.Size = new System.Drawing.Size(248, 20);
            this.txtEmailSetor.TabIndex = 31;
            // 
            // txtSetor
            // 
            this.txtSetor.Location = new System.Drawing.Point(11, 65);
            this.txtSetor.MaxLength = 30;
            this.txtSetor.Name = "txtSetor";
            this.txtSetor.Size = new System.Drawing.Size(142, 20);
            this.txtSetor.TabIndex = 30;
            // 
            // lblEditarSetor
            // 
            this.lblEditarSetor.AutoSize = true;
            this.lblEditarSetor.BackColor = System.Drawing.Color.Gainsboro;
            this.lblEditarSetor.Font = new System.Drawing.Font("Open Sans", 20F, System.Drawing.FontStyle.Bold);
            this.lblEditarSetor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditarSetor.Location = new System.Drawing.Point(4, 3);
            this.lblEditarSetor.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEditarSetor.Name = "lblEditarSetor";
            this.lblEditarSetor.Size = new System.Drawing.Size(174, 37);
            this.lblEditarSetor.TabIndex = 29;
            this.lblEditarSetor.Text = "Editar setor";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(185, 134);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 34;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmEditarSetor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.ClientSize = new System.Drawing.Size(271, 162);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblEmailSetor);
            this.Controls.Add(this.lblDescricaoSetor);
            this.Controls.Add(this.txtEmailSetor);
            this.Controls.Add(this.txtSetor);
            this.Controls.Add(this.lblEditarSetor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmEditarSetor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setor";
            this.Load += new System.EventHandler(this.frmEditarSetor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEditarSetor_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEmailSetor;
        private System.Windows.Forms.Label lblDescricaoSetor;
        private System.Windows.Forms.Label lblEditarSetor;
        public System.Windows.Forms.TextBox txtEmailSetor;
        public System.Windows.Forms.TextBox txtSetor;
        private System.Windows.Forms.Button btnConfirmar;
    }
}