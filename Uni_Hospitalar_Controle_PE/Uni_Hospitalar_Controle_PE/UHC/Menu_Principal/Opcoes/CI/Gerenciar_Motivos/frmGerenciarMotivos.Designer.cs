namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI
{
    partial class frmGerenciarMotivos
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
            this.lblGerenciarMotivos = new System.Windows.Forms.Label();
            this.gpbMotivos = new System.Windows.Forms.GroupBox();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.gpbMotivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGerenciarMotivos
            // 
            this.lblGerenciarMotivos.AutoSize = true;
            this.lblGerenciarMotivos.BackColor = System.Drawing.Color.Gainsboro;
            this.lblGerenciarMotivos.Font = new System.Drawing.Font("Open Sans", 20F, System.Drawing.FontStyle.Bold);
            this.lblGerenciarMotivos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGerenciarMotivos.Location = new System.Drawing.Point(4, 5);
            this.lblGerenciarMotivos.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGerenciarMotivos.Name = "lblGerenciarMotivos";
            this.lblGerenciarMotivos.Size = new System.Drawing.Size(265, 37);
            this.lblGerenciarMotivos.TabIndex = 20;
            this.lblGerenciarMotivos.Text = "Gerenciar motivos";
            // 
            // gpbMotivos
            // 
            this.gpbMotivos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gpbMotivos.Controls.Add(this.dgvDados);
            this.gpbMotivos.Location = new System.Drawing.Point(11, 45);
            this.gpbMotivos.Name = "gpbMotivos";
            this.gpbMotivos.Size = new System.Drawing.Size(526, 213);
            this.gpbMotivos.TabIndex = 21;
            this.gpbMotivos.TabStop = false;
            this.gpbMotivos.Text = "Lista de motivos";
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
            this.dgvDados.Size = new System.Drawing.Size(520, 194);
            this.dgvDados.TabIndex = 2;
            this.dgvDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDados_MouseDoubleClick);
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(278, 13);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 26;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnCriarMotivo_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(560, 232);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 27;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmGerenciarMotivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(647, 263);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.gpbMotivos);
            this.Controls.Add(this.lblGerenciarMotivos);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmGerenciarMotivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CI";
            this.Load += new System.EventHandler(this.frmGerenciarMotivos_Load);
            this.gpbMotivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGerenciarMotivos;
        private System.Windows.Forms.GroupBox gpbMotivos;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnFechar;
    }
}