namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Fretes.Configuracoes_Fretes
{
    partial class frmConfigurar_Percentual
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnProcurarTransportadora = new System.Windows.Forms.PictureBox();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.txtCodTransportadora = new System.Windows.Forms.TextBox();
            this.lblConfigurarPercentualTransportadora = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.btnInserirCidade = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcurarTransportadora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnProcurarTransportadora);
            this.splitContainer1.Panel1.Controls.Add(this.lblTransportadora);
            this.splitContainer1.Panel1.Controls.Add(this.txtTransportadora);
            this.splitContainer1.Panel1.Controls.Add(this.txtCodTransportadora);
            this.splitContainer1.Panel1.Controls.Add(this.lblConfigurarPercentualTransportadora);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 96;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnProcurarTransportadora
            // 
            this.btnProcurarTransportadora.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnProcurarTransportadora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProcurarTransportadora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurarTransportadora.Location = new System.Drawing.Point(321, 63);
            this.btnProcurarTransportadora.Name = "btnProcurarTransportadora";
            this.btnProcurarTransportadora.Size = new System.Drawing.Size(25, 23);
            this.btnProcurarTransportadora.TabIndex = 65;
            this.btnProcurarTransportadora.TabStop = false;
            this.btnProcurarTransportadora.Click += new System.EventHandler(this.btnProcurarTransportadora_Click);
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(12, 50);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(79, 13);
            this.lblTransportadora.TabIndex = 62;
            this.lblTransportadora.Text = "Transportadora";
            // 
            // txtTransportadora
            // 
            this.txtTransportadora.Location = new System.Drawing.Point(66, 66);
            this.txtTransportadora.Name = "txtTransportadora";
            this.txtTransportadora.ReadOnly = true;
            this.txtTransportadora.Size = new System.Drawing.Size(249, 20);
            this.txtTransportadora.TabIndex = 64;
            // 
            // txtCodTransportadora
            // 
            this.txtCodTransportadora.Location = new System.Drawing.Point(12, 66);
            this.txtCodTransportadora.MaxLength = 5;
            this.txtCodTransportadora.Name = "txtCodTransportadora";
            this.txtCodTransportadora.Size = new System.Drawing.Size(48, 20);
            this.txtCodTransportadora.TabIndex = 63;
            this.txtCodTransportadora.TextChanged += new System.EventHandler(this.txtCodTransportadora_TextChanged);
            // 
            // lblConfigurarPercentualTransportadora
            // 
            this.lblConfigurarPercentualTransportadora.AutoSize = true;
            this.lblConfigurarPercentualTransportadora.BackColor = System.Drawing.Color.Gainsboro;
            this.lblConfigurarPercentualTransportadora.Font = new System.Drawing.Font("Open Sans", 18F, System.Drawing.FontStyle.Bold);
            this.lblConfigurarPercentualTransportadora.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblConfigurarPercentualTransportadora.Location = new System.Drawing.Point(6, 9);
            this.lblConfigurarPercentualTransportadora.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblConfigurarPercentualTransportadora.Name = "lblConfigurarPercentualTransportadora";
            this.lblConfigurarPercentualTransportadora.Size = new System.Drawing.Size(507, 33);
            this.lblConfigurarPercentualTransportadora.TabIndex = 61;
            this.lblConfigurarPercentualTransportadora.Text = "Configurar percentual de Transportadora";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvDados);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnCancelar);
            this.splitContainer2.Panel2.Controls.Add(this.btnInserirCidade);
            this.splitContainer2.Panel2.Controls.Add(this.btnInserir);
            this.splitContainer2.Size = new System.Drawing.Size(800, 350);
            this.splitContainer2.SplitterDistance = 299;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToOrderColumns = true;
            this.dgvDados.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDados.Location = new System.Drawing.Point(0, 0);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDados.Size = new System.Drawing.Size(800, 299);
            this.dgvDados.TabIndex = 2;
            // 
            // btnInserirCidade
            // 
            this.btnInserirCidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInserirCidade.Location = new System.Drawing.Point(12, 12);
            this.btnInserirCidade.Name = "btnInserirCidade";
            this.btnInserirCidade.Size = new System.Drawing.Size(70, 23);
            this.btnInserirCidade.TabIndex = 44;
            this.btnInserirCidade.Text = "Cidades";
            this.btnInserirCidade.UseVisualStyleBackColor = true;
            this.btnInserirCidade.Click += new System.EventHandler(this.btnInserirCidade_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInserir.Location = new System.Drawing.Point(713, 12);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 41;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(632, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 45;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmConfigurar_Percentual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "frmConfigurar_Percentual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar percentual de transportadora";
            this.Load += new System.EventHandler(this.frmConfigurar_Percentual_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConfigurar_Percentual_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnProcurarTransportadora)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox btnProcurarTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.TextBox txtTransportadora;
        private System.Windows.Forms.TextBox txtCodTransportadora;
        private System.Windows.Forms.Label lblConfigurarPercentualTransportadora;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.Button btnInserirCidade;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnCancelar;
    }
}