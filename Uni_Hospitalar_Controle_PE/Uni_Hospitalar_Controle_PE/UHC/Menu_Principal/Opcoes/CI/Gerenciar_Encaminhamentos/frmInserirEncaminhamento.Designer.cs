namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI.Gerenciar_Encaminhamentos
{
    partial class frmInserirEncaminhamento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblInserirEncaminhamento = new System.Windows.Forms.Label();
            this.gpbEncaminhamentosRecentes = new System.Windows.Forms.GroupBox();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.lblDescricaoEncaminhamento = new System.Windows.Forms.Label();
            this.txtDescricaoEncaminhamento = new System.Windows.Forms.TextBox();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.gpbEncaminhamentosRecentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInserirEncaminhamento
            // 
            this.lblInserirEncaminhamento.AutoSize = true;
            this.lblInserirEncaminhamento.BackColor = System.Drawing.Color.Gainsboro;
            this.lblInserirEncaminhamento.Font = new System.Drawing.Font("Open Sans", 20F, System.Drawing.FontStyle.Bold);
            this.lblInserirEncaminhamento.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblInserirEncaminhamento.Location = new System.Drawing.Point(2, 4);
            this.lblInserirEncaminhamento.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblInserirEncaminhamento.Name = "lblInserirEncaminhamento";
            this.lblInserirEncaminhamento.Size = new System.Drawing.Size(353, 37);
            this.lblInserirEncaminhamento.TabIndex = 31;
            this.lblInserirEncaminhamento.Text = "Inserir encaminhamento";
            // 
            // gpbEncaminhamentosRecentes
            // 
            this.gpbEncaminhamentosRecentes.Controls.Add(this.dgvDados);
            this.gpbEncaminhamentosRecentes.Location = new System.Drawing.Point(10, 120);
            this.gpbEncaminhamentosRecentes.Name = "gpbEncaminhamentosRecentes";
            this.gpbEncaminhamentosRecentes.Size = new System.Drawing.Size(416, 242);
            this.gpbEncaminhamentosRecentes.TabIndex = 36;
            this.gpbEncaminhamentosRecentes.TabStop = false;
            this.gpbEncaminhamentosRecentes.Text = "Encaminhamentos recentes";
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(3, 16);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.Size = new System.Drawing.Size(410, 223);
            this.dgvDados.TabIndex = 1;
            // 
            // lblDescricaoEncaminhamento
            // 
            this.lblDescricaoEncaminhamento.AutoSize = true;
            this.lblDescricaoEncaminhamento.Location = new System.Drawing.Point(6, 44);
            this.lblDescricaoEncaminhamento.Name = "lblDescricaoEncaminhamento";
            this.lblDescricaoEncaminhamento.Size = new System.Drawing.Size(154, 13);
            this.lblDescricaoEncaminhamento.TabIndex = 33;
            this.lblDescricaoEncaminhamento.Text = "Descrição do encaminhamento";
            // 
            // txtDescricaoEncaminhamento
            // 
            this.txtDescricaoEncaminhamento.Location = new System.Drawing.Point(9, 60);
            this.txtDescricaoEncaminhamento.MaxLength = 52;
            this.txtDescricaoEncaminhamento.Multiline = true;
            this.txtDescricaoEncaminhamento.Name = "txtDescricaoEncaminhamento";
            this.txtDescricaoEncaminhamento.Size = new System.Drawing.Size(416, 21);
            this.txtDescricaoEncaminhamento.TabIndex = 32;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(351, 91);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 37;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserirEncaminhamento_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(270, 91);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 38;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmInserirEncaminhamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(436, 376);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.gpbEncaminhamentosRecentes);
            this.Controls.Add(this.lblDescricaoEncaminhamento);
            this.Controls.Add(this.txtDescricaoEncaminhamento);
            this.Controls.Add(this.lblInserirEncaminhamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInserirEncaminhamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CI";
            this.Load += new System.EventHandler(this.frmInserirEncaminhamento_Load);
            this.gpbEncaminhamentosRecentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInserirEncaminhamento;
        private System.Windows.Forms.GroupBox gpbEncaminhamentosRecentes;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Label lblDescricaoEncaminhamento;
        private System.Windows.Forms.TextBox txtDescricaoEncaminhamento;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnCancelar;
    }
}