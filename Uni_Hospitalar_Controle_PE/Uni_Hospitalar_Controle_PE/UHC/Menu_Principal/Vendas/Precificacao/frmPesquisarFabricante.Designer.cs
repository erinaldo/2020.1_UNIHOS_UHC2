namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Precificacao
{
    partial class frmPesquisarFabricante
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
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblFabricanteSelecionado = new System.Windows.Forms.Label();
            this.txtDescricaoOpcao = new System.Windows.Forms.TextBox();
            this.pnlDados = new System.Windows.Forms.Panel();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.pnlDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmar.BackColor = System.Drawing.Color.IndianRed;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(427, 221);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(84, 34);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // lblFabricanteSelecionado
            // 
            this.lblFabricanteSelecionado.AutoSize = true;
            this.lblFabricanteSelecionado.Location = new System.Drawing.Point(9, 221);
            this.lblFabricanteSelecionado.Name = "lblFabricanteSelecionado";
            this.lblFabricanteSelecionado.Size = new System.Drawing.Size(120, 13);
            this.lblFabricanteSelecionado.TabIndex = 46;
            this.lblFabricanteSelecionado.Text = "Fabricante selecionado:";
            // 
            // txtDescricaoOpcao
            // 
            this.txtDescricaoOpcao.Location = new System.Drawing.Point(12, 8);
            this.txtDescricaoOpcao.Name = "txtDescricaoOpcao";
            this.txtDescricaoOpcao.Size = new System.Drawing.Size(499, 20);
            this.txtDescricaoOpcao.TabIndex = 0;
            this.txtDescricaoOpcao.TextChanged += new System.EventHandler(this.TxtDescricaoOpcao_TextChanged);
            // 
            // pnlDados
            // 
            this.pnlDados.Controls.Add(this.dgvDados);
            this.pnlDados.Location = new System.Drawing.Point(12, 34);
            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Size = new System.Drawing.Size(499, 182);
            this.pnlDados.TabIndex = 43;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToResizeColumns = false;
            this.dgvDados.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            this.dgvDados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDados_CellClick);
            this.dgvDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DgvDados_MouseDoubleClick);
            // 
            // frmPesquisarFabricante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 257);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblFabricanteSelecionado);
            this.Controls.Add(this.txtDescricaoOpcao);
            this.Controls.Add(this.pnlDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmPesquisarFabricante";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar fabricante";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPesquisarFabricante_FormClosed);
            this.Load += new System.EventHandler(this.FrmPesquisarProduto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPesquisarFabricante_KeyDown);
            this.pnlDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblFabricanteSelecionado;
        private System.Windows.Forms.TextBox txtDescricaoOpcao;
        private System.Windows.Forms.Panel pnlDados;
        private System.Windows.Forms.DataGridView dgvDados;
    }
}