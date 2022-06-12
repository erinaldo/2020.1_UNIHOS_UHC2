namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci
{
    partial class frmCriarCi_EscolherCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblClienteSelecionado = new System.Windows.Forms.Label();
            this.txtDescricaoOpcao = new System.Windows.Forms.TextBox();
            this.pnlDados = new System.Windows.Forms.Panel();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnPreencherCliente = new System.Windows.Forms.PictureBox();
            this.cbxOpcoesDePesquisa = new System.Windows.Forms.ComboBox();
            this.pnlDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.BackColor = System.Drawing.Color.Transparent;
            this.lblCliente.Location = new System.Drawing.Point(106, 223);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(0, 13);
            this.lblCliente.TabIndex = 23;
            // 
            // lblClienteSelecionado
            // 
            this.lblClienteSelecionado.AutoSize = true;
            this.lblClienteSelecionado.Location = new System.Drawing.Point(7, 223);
            this.lblClienteSelecionado.Name = "lblClienteSelecionado";
            this.lblClienteSelecionado.Size = new System.Drawing.Size(102, 13);
            this.lblClienteSelecionado.TabIndex = 22;
            this.lblClienteSelecionado.Text = "Cliente selecionado:";
            // 
            // txtDescricaoOpcao
            // 
            this.txtDescricaoOpcao.Location = new System.Drawing.Point(122, 8);
            this.txtDescricaoOpcao.Name = "txtDescricaoOpcao";
            this.txtDescricaoOpcao.Size = new System.Drawing.Size(273, 20);
            this.txtDescricaoOpcao.TabIndex = 20;
            this.txtDescricaoOpcao.TextChanged += new System.EventHandler(this.TxtDescricaoOpcao_TextChanged);
            this.txtDescricaoOpcao.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescricaoOpcao_KeyUp);
            // 
            // pnlDados
            // 
            this.pnlDados.Controls.Add(this.dgvDados);
            this.pnlDados.Location = new System.Drawing.Point(10, 34);
            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Size = new System.Drawing.Size(499, 182);
            this.pnlDados.TabIndex = 19;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.ColumnHeadersVisible = false;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(499, 182);
            this.dgvDados.TabIndex = 0;
            this.dgvDados.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellEnter);
            this.dgvDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DgvDados_MouseDoubleClick);
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
            this.btnConfirmar.TabIndex = 42;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnPreencherCliente
            // 
            this.btnPreencherCliente.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherCliente.Location = new System.Drawing.Point(396, 8);
            this.btnPreencherCliente.Name = "btnPreencherCliente";
            this.btnPreencherCliente.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherCliente.TabIndex = 24;
            this.btnPreencherCliente.TabStop = false;
            this.btnPreencherCliente.Click += new System.EventHandler(this.btnPreencherCliente_Click);
            // 
            // cbxOpcoesDePesquisa
            // 
            this.cbxOpcoesDePesquisa.FormattingEnabled = true;
            this.cbxOpcoesDePesquisa.Location = new System.Drawing.Point(10, 7);
            this.cbxOpcoesDePesquisa.Name = "cbxOpcoesDePesquisa";
            this.cbxOpcoesDePesquisa.Size = new System.Drawing.Size(106, 21);
            this.cbxOpcoesDePesquisa.TabIndex = 21;
            // 
            // frmCriarCi_EscolherCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 268);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnPreencherCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblClienteSelecionado);
            this.Controls.Add(this.cbxOpcoesDePesquisa);
            this.Controls.Add(this.txtDescricaoOpcao);
            this.Controls.Add(this.pnlDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmCriarCi_EscolherCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar cliente";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCriarCi_EscolherCliente_FormClosed);
            this.Load += new System.EventHandler(this.frmCriarCi_EscolherCliente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCriarCi_EscolherCliente_KeyDown);
            this.pnlDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblClienteSelecionado;
        private System.Windows.Forms.TextBox txtDescricaoOpcao;
        private System.Windows.Forms.Panel pnlDados;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.PictureBox btnPreencherCliente;
        private System.Windows.Forms.ComboBox cbxOpcoesDePesquisa;
    }
}