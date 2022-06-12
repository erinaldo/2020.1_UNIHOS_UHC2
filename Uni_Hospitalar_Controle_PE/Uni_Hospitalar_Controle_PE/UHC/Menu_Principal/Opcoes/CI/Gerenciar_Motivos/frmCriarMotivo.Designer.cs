namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI.Gerenciar_Motivos
{
    partial class frmCriarMotivo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCriarMotivo = new System.Windows.Forms.Label();
            this.txtDescricaoMotivo = new System.Windows.Forms.TextBox();
            this.lblDescricaoMotivo = new System.Windows.Forms.Label();
            this.chkMovimentaDevolucao = new System.Windows.Forms.CheckBox();
            this.gpbMotivosRecentes = new System.Windows.Forms.GroupBox();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.gpbMotivosRecentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCriarMotivo
            // 
            this.lblCriarMotivo.AutoSize = true;
            this.lblCriarMotivo.BackColor = System.Drawing.Color.Gainsboro;
            this.lblCriarMotivo.Font = new System.Drawing.Font("Open Sans", 20F, System.Drawing.FontStyle.Bold);
            this.lblCriarMotivo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCriarMotivo.Location = new System.Drawing.Point(3, 4);
            this.lblCriarMotivo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCriarMotivo.Name = "lblCriarMotivo";
            this.lblCriarMotivo.Size = new System.Drawing.Size(185, 37);
            this.lblCriarMotivo.TabIndex = 20;
            this.lblCriarMotivo.Text = "Criar motivo";
            // 
            // txtDescricaoMotivo
            // 
            this.txtDescricaoMotivo.Location = new System.Drawing.Point(6, 63);
            this.txtDescricaoMotivo.MaxLength = 52;
            this.txtDescricaoMotivo.Multiline = true;
            this.txtDescricaoMotivo.Name = "txtDescricaoMotivo";
            this.txtDescricaoMotivo.Size = new System.Drawing.Size(416, 21);
            this.txtDescricaoMotivo.TabIndex = 21;
            // 
            // lblDescricaoMotivo
            // 
            this.lblDescricaoMotivo.AutoSize = true;
            this.lblDescricaoMotivo.Location = new System.Drawing.Point(3, 47);
            this.lblDescricaoMotivo.Name = "lblDescricaoMotivo";
            this.lblDescricaoMotivo.Size = new System.Drawing.Size(104, 13);
            this.lblDescricaoMotivo.TabIndex = 22;
            this.lblDescricaoMotivo.Text = "Descrição do motivo";
            // 
            // chkMovimentaDevolucao
            // 
            this.chkMovimentaDevolucao.AutoSize = true;
            this.chkMovimentaDevolucao.Checked = true;
            this.chkMovimentaDevolucao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMovimentaDevolucao.Location = new System.Drawing.Point(7, 90);
            this.chkMovimentaDevolucao.Name = "chkMovimentaDevolucao";
            this.chkMovimentaDevolucao.Size = new System.Drawing.Size(131, 17);
            this.chkMovimentaDevolucao.TabIndex = 23;
            this.chkMovimentaDevolucao.Text = "Movimenta devolução";
            this.chkMovimentaDevolucao.UseVisualStyleBackColor = true;
            this.chkMovimentaDevolucao.CheckedChanged += new System.EventHandler(this.chkMovimentaDevolucao_CheckedChanged);
            // 
            // gpbMotivosRecentes
            // 
            this.gpbMotivosRecentes.Controls.Add(this.dgvDados);
            this.gpbMotivosRecentes.Location = new System.Drawing.Point(7, 130);
            this.gpbMotivosRecentes.Name = "gpbMotivosRecentes";
            this.gpbMotivosRecentes.Size = new System.Drawing.Size(416, 242);
            this.gpbMotivosRecentes.TabIndex = 30;
            this.gpbMotivosRecentes.TabStop = false;
            this.gpbMotivosRecentes.Text = "Motivos recentes";
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(3, 16);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.Size = new System.Drawing.Size(410, 223);
            this.dgvDados.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(267, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(348, 90);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 39;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnCriarMotivo_Click);
            // 
            // frmCriarMotivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(433, 384);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.gpbMotivosRecentes);
            this.Controls.Add(this.chkMovimentaDevolucao);
            this.Controls.Add(this.lblDescricaoMotivo);
            this.Controls.Add(this.txtDescricaoMotivo);
            this.Controls.Add(this.lblCriarMotivo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCriarMotivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CI";
            this.Load += new System.EventHandler(this.frmCriarMotivo_Load);
            this.gpbMotivosRecentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCriarMotivo;
        private System.Windows.Forms.TextBox txtDescricaoMotivo;
        private System.Windows.Forms.Label lblDescricaoMotivo;
        private System.Windows.Forms.CheckBox chkMovimentaDevolucao;
        private System.Windows.Forms.GroupBox gpbMotivosRecentes;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnInserir;
    }
}