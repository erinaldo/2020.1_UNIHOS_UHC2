namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI.Gerenciar_Motivos
{
    partial class frmEditarMotivo
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
            this.btnEditar = new System.Windows.Forms.Button();
            this.chkMovimentaDevolucao = new System.Windows.Forms.CheckBox();
            this.lblDescricaoMotivo = new System.Windows.Forms.Label();
            this.txtDescricaoMotivo = new System.Windows.Forms.TextBox();
            this.lblEditarMotivo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(352, 92);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 45;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // chkMovimentaDevolucao
            // 
            this.chkMovimentaDevolucao.AutoSize = true;
            this.chkMovimentaDevolucao.Location = new System.Drawing.Point(11, 92);
            this.chkMovimentaDevolucao.Name = "chkMovimentaDevolucao";
            this.chkMovimentaDevolucao.Size = new System.Drawing.Size(131, 17);
            this.chkMovimentaDevolucao.TabIndex = 44;
            this.chkMovimentaDevolucao.Text = "Movimenta devolução";
            this.chkMovimentaDevolucao.UseVisualStyleBackColor = true;
            this.chkMovimentaDevolucao.CheckedChanged += new System.EventHandler(this.chkMovimentaDevolucao_CheckedChanged);
            // 
            // lblDescricaoMotivo
            // 
            this.lblDescricaoMotivo.AutoSize = true;
            this.lblDescricaoMotivo.Location = new System.Drawing.Point(7, 49);
            this.lblDescricaoMotivo.Name = "lblDescricaoMotivo";
            this.lblDescricaoMotivo.Size = new System.Drawing.Size(104, 13);
            this.lblDescricaoMotivo.TabIndex = 43;
            this.lblDescricaoMotivo.Text = "Descrição do motivo";
            // 
            // txtDescricaoMotivo
            // 
            this.txtDescricaoMotivo.Location = new System.Drawing.Point(10, 65);
            this.txtDescricaoMotivo.MaxLength = 52;
            this.txtDescricaoMotivo.Multiline = true;
            this.txtDescricaoMotivo.Name = "txtDescricaoMotivo";
            this.txtDescricaoMotivo.Size = new System.Drawing.Size(416, 21);
            this.txtDescricaoMotivo.TabIndex = 42;
            // 
            // lblEditarMotivo
            // 
            this.lblEditarMotivo.AutoSize = true;
            this.lblEditarMotivo.BackColor = System.Drawing.Color.Gainsboro;
            this.lblEditarMotivo.Font = new System.Drawing.Font("Open Sans", 20F, System.Drawing.FontStyle.Bold);
            this.lblEditarMotivo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditarMotivo.Location = new System.Drawing.Point(7, 6);
            this.lblEditarMotivo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEditarMotivo.Name = "lblEditarMotivo";
            this.lblEditarMotivo.Size = new System.Drawing.Size(200, 37);
            this.lblEditarMotivo.TabIndex = 41;
            this.lblEditarMotivo.Text = "Editar motivo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(271, 92);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 46;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(351, 12);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 47;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // frmEditarMotivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(438, 130);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.chkMovimentaDevolucao);
            this.Controls.Add(this.lblDescricaoMotivo);
            this.Controls.Add(this.txtDescricaoMotivo);
            this.Controls.Add(this.lblEditarMotivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEditarMotivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Motivo";
            this.Load += new System.EventHandler(this.frmEditarMotivo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.CheckBox chkMovimentaDevolucao;
        private System.Windows.Forms.Label lblDescricaoMotivo;
        private System.Windows.Forms.TextBox txtDescricaoMotivo;
        private System.Windows.Forms.Label lblEditarMotivo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnExcluir;
    }
}