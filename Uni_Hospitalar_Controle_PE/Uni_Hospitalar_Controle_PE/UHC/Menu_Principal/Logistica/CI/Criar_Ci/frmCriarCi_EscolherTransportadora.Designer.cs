namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci
{
    partial class frmCriarCi_EscolherTransportadora
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
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.btnPreencherTransportadora = new System.Windows.Forms.PictureBox();
            this.lblTransportadoraSelecionada = new System.Windows.Forms.Label();
            this.cbxOpcoesDePesquisa = new System.Windows.Forms.ComboBox();
            this.txtDescricaoOpcao = new System.Windows.Forms.TextBox();
            this.pnlDados = new System.Windows.Forms.Panel();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherTransportadora)).BeginInit();
            this.pnlDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.BackColor = System.Drawing.Color.Transparent;
            this.lblTransportadora.Location = new System.Drawing.Point(148, 224);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(0, 13);
            this.lblTransportadora.TabIndex = 32;
            // 
            // btnPreencherTransportadora
            // 
            this.btnPreencherTransportadora.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherTransportadora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherTransportadora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherTransportadora.Location = new System.Drawing.Point(398, 7);
            this.btnPreencherTransportadora.Name = "btnPreencherTransportadora";
            this.btnPreencherTransportadora.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherTransportadora.TabIndex = 30;
            this.btnPreencherTransportadora.TabStop = false;
            this.btnPreencherTransportadora.Click += new System.EventHandler(this.btnPreencherTransportadora_Click);
            // 
            // lblTransportadoraSelecionada
            // 
            this.lblTransportadoraSelecionada.AutoSize = true;
            this.lblTransportadoraSelecionada.Location = new System.Drawing.Point(10, 224);
            this.lblTransportadoraSelecionada.Name = "lblTransportadoraSelecionada";
            this.lblTransportadoraSelecionada.Size = new System.Drawing.Size(142, 13);
            this.lblTransportadoraSelecionada.TabIndex = 29;
            this.lblTransportadoraSelecionada.Text = "Transportadora selecionada:";
            // 
            // cbxOpcoesDePesquisa
            // 
            this.cbxOpcoesDePesquisa.FormattingEnabled = true;
            this.cbxOpcoesDePesquisa.Location = new System.Drawing.Point(12, 6);
            this.cbxOpcoesDePesquisa.Name = "cbxOpcoesDePesquisa";
            this.cbxOpcoesDePesquisa.Size = new System.Drawing.Size(106, 21);
            this.cbxOpcoesDePesquisa.TabIndex = 28;
            // 
            // txtDescricaoOpcao
            // 
            this.txtDescricaoOpcao.Location = new System.Drawing.Point(124, 7);
            this.txtDescricaoOpcao.Name = "txtDescricaoOpcao";
            this.txtDescricaoOpcao.Size = new System.Drawing.Size(273, 20);
            this.txtDescricaoOpcao.TabIndex = 27;
            this.txtDescricaoOpcao.TextChanged += new System.EventHandler(this.txtDescricaoOpcao_TextChanged);
            this.txtDescricaoOpcao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescricaoOpcao_KeyUp);
            // 
            // pnlDados
            // 
            this.pnlDados.Controls.Add(this.dgvDados);
            this.pnlDados.Location = new System.Drawing.Point(12, 33);
            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Size = new System.Drawing.Size(499, 185);
            this.pnlDados.TabIndex = 26;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(499, 185);
            this.dgvDados.TabIndex = 0;
            this.dgvDados.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellEnter);
            this.dgvDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDados_MouseDoubleClick);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.IndianRed;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(425, 224);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(84, 34);
            this.btnConfirmar.TabIndex = 43;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // frmCriarCi_EscolherTransportadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 265);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblTransportadora);
            this.Controls.Add(this.btnPreencherTransportadora);
            this.Controls.Add(this.lblTransportadoraSelecionada);
            this.Controls.Add(this.cbxOpcoesDePesquisa);
            this.Controls.Add(this.txtDescricaoOpcao);
            this.Controls.Add(this.pnlDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCriarCi_EscolherTransportadora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar transportadora";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCriarCi_EscolherTransportadora_FormClosed);
            this.Load += new System.EventHandler(this.frmCriarCi_EscolherTransportadora_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCriarCi_EscolherTransportadora_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FrmCriarCi_EscolherTransportadora_MouseDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherTransportadora)).EndInit();
            this.pnlDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.PictureBox btnPreencherTransportadora;
        private System.Windows.Forms.Label lblTransportadoraSelecionada;
        private System.Windows.Forms.ComboBox cbxOpcoesDePesquisa;
        private System.Windows.Forms.TextBox txtDescricaoOpcao;
        private System.Windows.Forms.Panel pnlDados;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnConfirmar;
    }
}