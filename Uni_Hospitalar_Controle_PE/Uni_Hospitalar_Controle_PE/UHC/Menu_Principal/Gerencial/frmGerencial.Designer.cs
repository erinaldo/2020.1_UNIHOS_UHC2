namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Gerencial
{
    partial class frmGerencial
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
            this.gpbRelatorioGerenciais = new System.Windows.Forms.GroupBox();
            this.lblRelMargemBruta = new System.Windows.Forms.Label();
            this.lblGerencial = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.gpbRelatorioGerenciais.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbRelatorioGerenciais
            // 
            this.gpbRelatorioGerenciais.BackColor = System.Drawing.Color.Gainsboro;
            this.gpbRelatorioGerenciais.Controls.Add(this.lblRelMargemBruta);
            this.gpbRelatorioGerenciais.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.gpbRelatorioGerenciais.Location = new System.Drawing.Point(12, 91);
            this.gpbRelatorioGerenciais.Name = "gpbRelatorioGerenciais";
            this.gpbRelatorioGerenciais.Size = new System.Drawing.Size(226, 223);
            this.gpbRelatorioGerenciais.TabIndex = 16;
            this.gpbRelatorioGerenciais.TabStop = false;
            this.gpbRelatorioGerenciais.Text = "Relatórios Gerencais";
            // 
            // lblRelMargemBruta
            // 
            this.lblRelMargemBruta.AutoSize = true;
            this.lblRelMargemBruta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelMargemBruta.Location = new System.Drawing.Point(6, 25);
            this.lblRelMargemBruta.Name = "lblRelMargemBruta";
            this.lblRelMargemBruta.Size = new System.Drawing.Size(184, 18);
            this.lblRelMargemBruta.TabIndex = 0;
            this.lblRelMargemBruta.Text = "Relatório de Margem bruta";
            this.lblRelMargemBruta.Click += new System.EventHandler(this.lblRelMargemBruta_Click);
            this.lblRelMargemBruta.MouseLeave += new System.EventHandler(this.lblRelMargemBruta_MouseLeave);
            this.lblRelMargemBruta.MouseHover += new System.EventHandler(this.lblRelMargemBruta_MouseHover);
            // 
            // lblGerencial
            // 
            this.lblGerencial.AutoSize = true;
            this.lblGerencial.BackColor = System.Drawing.Color.Gainsboro;
            this.lblGerencial.Font = new System.Drawing.Font("Open Sans", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGerencial.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGerencial.Location = new System.Drawing.Point(10, 9);
            this.lblGerencial.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGerencial.Name = "lblGerencial";
            this.lblGerencial.Size = new System.Drawing.Size(381, 65);
            this.lblGerencial.TabIndex = 17;
            this.lblGerencial.Text = "Área Gerencial";
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnFechar.Location = new System.Drawing.Point(686, 402);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(103, 38);
            this.btnFechar.TabIndex = 21;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmGerencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblGerencial);
            this.Controls.Add(this.gpbRelatorioGerenciais);
            this.Name = "frmGerencial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerencial";
            this.Load += new System.EventHandler(this.frmGerencial_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGerencial_KeyDown);
            this.gpbRelatorioGerenciais.ResumeLayout(false);
            this.gpbRelatorioGerenciais.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbRelatorioGerenciais;
        private System.Windows.Forms.Label lblRelMargemBruta;
        private System.Windows.Forms.Label lblGerencial;
        private System.Windows.Forms.Button btnFechar;
    }
}