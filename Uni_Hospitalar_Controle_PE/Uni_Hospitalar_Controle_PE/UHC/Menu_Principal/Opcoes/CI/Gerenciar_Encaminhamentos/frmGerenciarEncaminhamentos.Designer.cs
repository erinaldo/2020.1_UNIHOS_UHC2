namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI.Gerenciar_Encaminhamentos
{
    partial class frmGerenciarEncaminhamentos
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
            this.lblGerenciarEncaminhamentos = new System.Windows.Forms.Label();
            this.gpbEncaminhamentos = new System.Windows.Forms.GroupBox();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.gpbEncaminhamentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGerenciarEncaminhamentos
            // 
            this.lblGerenciarEncaminhamentos.AutoSize = true;
            this.lblGerenciarEncaminhamentos.BackColor = System.Drawing.Color.Gainsboro;
            this.lblGerenciarEncaminhamentos.Font = new System.Drawing.Font("Open Sans", 20F, System.Drawing.FontStyle.Bold);
            this.lblGerenciarEncaminhamentos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGerenciarEncaminhamentos.Location = new System.Drawing.Point(4, 5);
            this.lblGerenciarEncaminhamentos.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGerenciarEncaminhamentos.Name = "lblGerenciarEncaminhamentos";
            this.lblGerenciarEncaminhamentos.Size = new System.Drawing.Size(410, 37);
            this.lblGerenciarEncaminhamentos.TabIndex = 26;
            this.lblGerenciarEncaminhamentos.Text = "Gerenciar encaminhamentos";
            // 
            // gpbEncaminhamentos
            // 
            this.gpbEncaminhamentos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gpbEncaminhamentos.Controls.Add(this.dgvDados);
            this.gpbEncaminhamentos.Location = new System.Drawing.Point(11, 46);
            this.gpbEncaminhamentos.Name = "gpbEncaminhamentos";
            this.gpbEncaminhamentos.Size = new System.Drawing.Size(543, 213);
            this.gpbEncaminhamentos.TabIndex = 27;
            this.gpbEncaminhamentos.TabStop = false;
            this.gpbEncaminhamentos.Text = "Lista de encaminhamentos";
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
            this.dgvDados.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(3, 16);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.Size = new System.Drawing.Size(537, 194);
            this.dgvDados.TabIndex = 2;
            this.dgvDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDados_MouseDoubleClick);
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(423, 12);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 30;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserirEncaminhamento_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(560, 233);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 31;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmGerenciarEncaminhamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.ClientSize = new System.Drawing.Size(643, 262);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.gpbEncaminhamentos);
            this.Controls.Add(this.lblGerenciarEncaminhamentos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGerenciarEncaminhamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CI";
            this.Load += new System.EventHandler(this.frmGerenciarEncaminhamentos_Load);
            this.gpbEncaminhamentos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGerenciarEncaminhamentos;
        private System.Windows.Forms.GroupBox gpbEncaminhamentos;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnFechar;
    }
}