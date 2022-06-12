namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Precificacao
{
    partial class frmInfoConsultarPrecos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblProduto = new System.Windows.Forms.Label();
            this.btnPreencherCliente = new System.Windows.Forms.PictureBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.gpbHistDeVendas = new System.Windows.Forms.GroupBox();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.gpbLotes = new System.Windows.Forms.GroupBox();
            this.dgvLotes = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtUltimaEntrada = new System.Windows.Forms.TextBox();
            this.lblUltimaEntrada = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).BeginInit();
            this.gpbHistDeVendas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            this.gpbLotes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.BackColor = System.Drawing.Color.Gainsboro;
            this.lblProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduto.Location = new System.Drawing.Point(10, 7);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(108, 25);
            this.lblProduto.TabIndex = 5;
            this.lblProduto.Text = "Produto: ";
            // 
            // btnPreencherCliente
            // 
            this.btnPreencherCliente.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnPreencherCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPreencherCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreencherCliente.Location = new System.Drawing.Point(535, 54);
            this.btnPreencherCliente.Name = "btnPreencherCliente";
            this.btnPreencherCliente.Size = new System.Drawing.Size(26, 22);
            this.btnPreencherCliente.TabIndex = 28;
            this.btnPreencherCliente.TabStop = false;
            this.btnPreencherCliente.Click += new System.EventHandler(this.BtnPreencherCliente_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(9, 38);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 27;
            this.lblCliente.Text = "Cliente";
            // 
            // gpbHistDeVendas
            // 
            this.gpbHistDeVendas.Controls.Add(this.dgvHistorico);
            this.gpbHistDeVendas.Location = new System.Drawing.Point(12, 87);
            this.gpbHistDeVendas.Name = "gpbHistDeVendas";
            this.gpbHistDeVendas.Size = new System.Drawing.Size(618, 258);
            this.gpbHistDeVendas.TabIndex = 29;
            this.gpbHistDeVendas.TabStop = false;
            this.gpbHistDeVendas.Text = "Histórico de vendas";
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.AllowUserToAddRows = false;
            this.dgvHistorico.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvHistorico.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorico.Location = new System.Drawing.Point(3, 16);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.ReadOnly = true;
            this.dgvHistorico.RowHeadersVisible = false;
            this.dgvHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorico.Size = new System.Drawing.Size(612, 239);
            this.dgvHistorico.TabIndex = 3;
            // 
            // gpbLotes
            // 
            this.gpbLotes.Controls.Add(this.dgvLotes);
            this.gpbLotes.Location = new System.Drawing.Point(633, 87);
            this.gpbLotes.Name = "gpbLotes";
            this.gpbLotes.Size = new System.Drawing.Size(291, 255);
            this.gpbLotes.TabIndex = 30;
            this.gpbLotes.TabStop = false;
            this.gpbLotes.Text = "Lotes";
            // 
            // dgvLotes
            // 
            this.dgvLotes.AllowUserToAddRows = false;
            this.dgvLotes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvLotes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLotes.Location = new System.Drawing.Point(3, 16);
            this.dgvLotes.Name = "dgvLotes";
            this.dgvLotes.ReadOnly = true;
            this.dgvLotes.RowHeadersVisible = false;
            this.dgvLotes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLotes.Size = new System.Drawing.Size(285, 236);
            this.dgvLotes.TabIndex = 3;
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnFechar.Location = new System.Drawing.Point(821, 353);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(103, 38);
            this.btnFechar.TabIndex = 31;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.BtnFechar_Click);
            // 
            // txtUltimaEntrada
            // 
            this.txtUltimaEntrada.Location = new System.Drawing.Point(570, 55);
            this.txtUltimaEntrada.Name = "txtUltimaEntrada";
            this.txtUltimaEntrada.ReadOnly = true;
            this.txtUltimaEntrada.Size = new System.Drawing.Size(60, 20);
            this.txtUltimaEntrada.TabIndex = 32;
            // 
            // lblUltimaEntrada
            // 
            this.lblUltimaEntrada.AutoSize = true;
            this.lblUltimaEntrada.Location = new System.Drawing.Point(567, 39);
            this.lblUltimaEntrada.Name = "lblUltimaEntrada";
            this.lblUltimaEntrada.Size = new System.Drawing.Size(75, 13);
            this.lblUltimaEntrada.TabIndex = 33;
            this.lblUltimaEntrada.Text = "Última entrada";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(62, 55);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(467, 20);
            this.txtCliente.TabIndex = 34;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(15, 55);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(41, 20);
            this.txtCodigo.TabIndex = 35;
            this.txtCodigo.TextChanged += new System.EventHandler(this.TxtCodCliente_TextChanged);
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // frmInfoConsultarPrecos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 393);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblUltimaEntrada);
            this.Controls.Add(this.txtUltimaEntrada);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gpbLotes);
            this.Controls.Add(this.gpbHistDeVendas);
            this.Controls.Add(this.btnPreencherCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblProduto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmInfoConsultarPrecos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Precificação";
            this.Load += new System.EventHandler(this.FrmInfoConsultarPrecos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmInfoConsultarPrecos_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.btnPreencherCliente)).EndInit();
            this.gpbHistDeVendas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            this.gpbLotes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.PictureBox btnPreencherCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.GroupBox gpbHistDeVendas;
        private System.Windows.Forms.GroupBox gpbLotes;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.DataGridView dgvLotes;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.TextBox txtUltimaEntrada;
        private System.Windows.Forms.Label lblUltimaEntrada;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtCodigo;
    }
}