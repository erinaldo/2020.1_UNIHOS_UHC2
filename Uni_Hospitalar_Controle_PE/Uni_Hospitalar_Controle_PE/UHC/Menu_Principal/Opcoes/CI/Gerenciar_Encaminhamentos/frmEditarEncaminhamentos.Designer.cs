namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI.Gerenciar_Encaminhamentos
{
    partial class frmEditarEncaminhamentos
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblDescricaoEncaminhamento = new System.Windows.Forms.Label();
            this.txtDescricaoEncaminhamento = new System.Windows.Forms.TextBox();
            this.lblEditarEncaminhamento = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(426, 93);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(507, 93);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 42;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblDescricaoEncaminhamento
            // 
            this.lblDescricaoEncaminhamento.AutoSize = true;
            this.lblDescricaoEncaminhamento.Location = new System.Drawing.Point(10, 46);
            this.lblDescricaoEncaminhamento.Name = "lblDescricaoEncaminhamento";
            this.lblDescricaoEncaminhamento.Size = new System.Drawing.Size(154, 13);
            this.lblDescricaoEncaminhamento.TabIndex = 41;
            this.lblDescricaoEncaminhamento.Text = "Descrição do encaminhamento";
            // 
            // txtDescricaoEncaminhamento
            // 
            this.txtDescricaoEncaminhamento.Location = new System.Drawing.Point(13, 62);
            this.txtDescricaoEncaminhamento.MaxLength = 52;
            this.txtDescricaoEncaminhamento.Multiline = true;
            this.txtDescricaoEncaminhamento.Name = "txtDescricaoEncaminhamento";
            this.txtDescricaoEncaminhamento.Size = new System.Drawing.Size(569, 21);
            this.txtDescricaoEncaminhamento.TabIndex = 40;
            // 
            // lblEditarEncaminhamento
            // 
            this.lblEditarEncaminhamento.AutoSize = true;
            this.lblEditarEncaminhamento.BackColor = System.Drawing.Color.Gainsboro;
            this.lblEditarEncaminhamento.Font = new System.Drawing.Font("Open Sans", 20F, System.Drawing.FontStyle.Bold);
            this.lblEditarEncaminhamento.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditarEncaminhamento.Location = new System.Drawing.Point(6, 6);
            this.lblEditarEncaminhamento.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEditarEncaminhamento.Name = "lblEditarEncaminhamento";
            this.lblEditarEncaminhamento.Size = new System.Drawing.Size(345, 37);
            this.lblEditarEncaminhamento.TabIndex = 39;
            this.lblEditarEncaminhamento.Text = "Editar encaminhamento";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(507, 12);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 44;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // frmEditarEncaminhamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.ClientSize = new System.Drawing.Size(592, 125);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.lblDescricaoEncaminhamento);
            this.Controls.Add(this.txtDescricaoEncaminhamento);
            this.Controls.Add(this.lblEditarEncaminhamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEditarEncaminhamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Encaminhamentos";
            this.Load += new System.EventHandler(this.frmEditarEncaminhamentos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblDescricaoEncaminhamento;
        private System.Windows.Forms.TextBox txtDescricaoEncaminhamento;
        private System.Windows.Forms.Label lblEditarEncaminhamento;
        private System.Windows.Forms.Button btnExcluir;
    }
}