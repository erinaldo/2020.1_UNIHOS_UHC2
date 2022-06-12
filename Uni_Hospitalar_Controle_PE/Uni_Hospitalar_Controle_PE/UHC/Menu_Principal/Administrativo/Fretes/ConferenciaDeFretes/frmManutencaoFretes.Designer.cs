namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Fretes.ConferenciaDeFretes
{
    partial class frmManutencaoFretes
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
            this.txtCTE = new System.Windows.Forms.TextBox();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.gpbFiltros = new System.Windows.Forms.GroupBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCTE = new System.Windows.Forms.Label();
            this.btnProcurarTransportadora = new System.Windows.Forms.PictureBox();
            this.lblTransportadora = new System.Windows.Forms.Label();
            this.txtTransportadora = new System.Windows.Forms.TextBox();
            this.txtCodTransportadora = new System.Windows.Forms.TextBox();
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.gpbEditar = new System.Windows.Forms.GroupBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.chkCalculadora = new System.Windows.Forms.CheckBox();
            this.gpbCalculadoraPercent = new System.Windows.Forms.GroupBox();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.txtPercentCalc = new System.Windows.Forms.TextBox();
            this.lblPercent = new System.Windows.Forms.Label();
            this.Vlr_Uni = new System.Windows.Forms.Label();
            this.txtEditarValorUni = new System.Windows.Forms.TextBox();
            this.txtEditarObservacao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEditarCTE = new System.Windows.Forms.TextBox();
            this.gpbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcurarTransportadora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.gpbEditar.SuspendLayout();
            this.gpbCalculadoraPercent.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCTE
            // 
            this.txtCTE.Location = new System.Drawing.Point(91, 74);
            this.txtCTE.Name = "txtCTE";
            this.txtCTE.Size = new System.Drawing.Size(79, 20);
            this.txtCTE.TabIndex = 3;
            this.txtCTE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCTE_KeyDown);
            this.txtCTE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(6, 74);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(79, 20);
            this.txtNota.TabIndex = 2;
            this.txtNota.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNota_KeyDown);
            this.txtNota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // gpbFiltros
            // 
            this.gpbFiltros.Controls.Add(this.btnPesquisar);
            this.gpbFiltros.Controls.Add(this.label1);
            this.gpbFiltros.Controls.Add(this.lblCTE);
            this.gpbFiltros.Controls.Add(this.btnProcurarTransportadora);
            this.gpbFiltros.Controls.Add(this.txtCTE);
            this.gpbFiltros.Controls.Add(this.txtNota);
            this.gpbFiltros.Controls.Add(this.lblTransportadora);
            this.gpbFiltros.Controls.Add(this.txtTransportadora);
            this.gpbFiltros.Controls.Add(this.txtCodTransportadora);
            this.gpbFiltros.Location = new System.Drawing.Point(12, 12);
            this.gpbFiltros.Name = "gpbFiltros";
            this.gpbFiltros.Size = new System.Drawing.Size(361, 106);
            this.gpbFiltros.TabIndex = 0;
            this.gpbFiltros.TabStop = false;
            this.gpbFiltros.Text = "Filtros";
            this.gpbFiltros.Enter += new System.EventHandler(this.gpbFiltros_Enter);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Location = new System.Drawing.Point(261, 61);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(80, 37);
            this.btnPesquisar.TabIndex = 3;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Num. Nota";
            // 
            // lblCTE
            // 
            this.lblCTE.AutoSize = true;
            this.lblCTE.Location = new System.Drawing.Point(88, 58);
            this.lblCTE.Name = "lblCTE";
            this.lblCTE.Size = new System.Drawing.Size(56, 13);
            this.lblCTE.TabIndex = 61;
            this.lblCTE.Text = "Num. CTE";
            // 
            // btnProcurarTransportadora
            // 
            this.btnProcurarTransportadora.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.btnLupa;
            this.btnProcurarTransportadora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProcurarTransportadora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcurarTransportadora.Location = new System.Drawing.Point(316, 32);
            this.btnProcurarTransportadora.Name = "btnProcurarTransportadora";
            this.btnProcurarTransportadora.Size = new System.Drawing.Size(25, 23);
            this.btnProcurarTransportadora.TabIndex = 60;
            this.btnProcurarTransportadora.TabStop = false;
            this.btnProcurarTransportadora.Click += new System.EventHandler(this.btnProcurarTransportadora_Click);
            // 
            // lblTransportadora
            // 
            this.lblTransportadora.AutoSize = true;
            this.lblTransportadora.Location = new System.Drawing.Point(7, 19);
            this.lblTransportadora.Name = "lblTransportadora";
            this.lblTransportadora.Size = new System.Drawing.Size(79, 13);
            this.lblTransportadora.TabIndex = 57;
            this.lblTransportadora.Text = "Transportadora";
            // 
            // txtTransportadora
            // 
            this.txtTransportadora.Location = new System.Drawing.Point(61, 35);
            this.txtTransportadora.Name = "txtTransportadora";
            this.txtTransportadora.ReadOnly = true;
            this.txtTransportadora.Size = new System.Drawing.Size(249, 20);
            this.txtTransportadora.TabIndex = 1;
            // 
            // txtCodTransportadora
            // 
            this.txtCodTransportadora.Location = new System.Drawing.Point(7, 35);
            this.txtCodTransportadora.MaxLength = 5;
            this.txtCodTransportadora.Name = "txtCodTransportadora";
            this.txtCodTransportadora.Size = new System.Drawing.Size(48, 20);
            this.txtCodTransportadora.TabIndex = 0;
            this.txtCodTransportadora.TextChanged += new System.EventHandler(this.txtCodTransportadora_TextChanged);
            this.txtCodTransportadora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Location = new System.Drawing.Point(12, 122);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.RowHeadersVisible = false;
            this.dgvDados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDados.Size = new System.Drawing.Size(826, 316);
            this.dgvDados.TabIndex = 1;
            this.dgvDados.SelectionChanged += new System.EventHandler(this.dgvDados_SelectionChanged);
            // 
            // gpbEditar
            // 
            this.gpbEditar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.gpbEditar.Controls.Add(this.btnFechar);
            this.gpbEditar.Controls.Add(this.label3);
            this.gpbEditar.Controls.Add(this.btnSalvar);
            this.gpbEditar.Controls.Add(this.chkCalculadora);
            this.gpbEditar.Controls.Add(this.gpbCalculadoraPercent);
            this.gpbEditar.Controls.Add(this.Vlr_Uni);
            this.gpbEditar.Controls.Add(this.txtEditarValorUni);
            this.gpbEditar.Controls.Add(this.txtEditarObservacao);
            this.gpbEditar.Controls.Add(this.label2);
            this.gpbEditar.Controls.Add(this.txtEditarCTE);
            this.gpbEditar.Location = new System.Drawing.Point(844, 122);
            this.gpbEditar.Name = "gpbEditar";
            this.gpbEditar.Size = new System.Drawing.Size(229, 316);
            this.gpbEditar.TabIndex = 2;
            this.gpbEditar.TabStop = false;
            this.gpbEditar.Text = "Campos Editáveis";
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFechar.BackColor = System.Drawing.Color.DarkGray;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(57, 273);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(80, 37);
            this.btnFechar.TabIndex = 75;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 74;
            this.label3.Text = "Observação";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSalvar.BackColor = System.Drawing.Color.Green;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(143, 273);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(80, 37);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // chkCalculadora
            // 
            this.chkCalculadora.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCalculadora.AutoSize = true;
            this.chkCalculadora.Location = new System.Drawing.Point(85, 175);
            this.chkCalculadora.Name = "chkCalculadora";
            this.chkCalculadora.Size = new System.Drawing.Size(15, 14);
            this.chkCalculadora.TabIndex = 3;
            this.chkCalculadora.UseVisualStyleBackColor = true;
            this.chkCalculadora.CheckedChanged += new System.EventHandler(this.chkCalculadora_CheckedChanged);
            // 
            // gpbCalculadoraPercent
            // 
            this.gpbCalculadoraPercent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gpbCalculadoraPercent.Controls.Add(this.txtResultado);
            this.gpbCalculadoraPercent.Controls.Add(this.txtPercentCalc);
            this.gpbCalculadoraPercent.Controls.Add(this.lblPercent);
            this.gpbCalculadoraPercent.Location = new System.Drawing.Point(6, 166);
            this.gpbCalculadoraPercent.Name = "gpbCalculadoraPercent";
            this.gpbCalculadoraPercent.Size = new System.Drawing.Size(99, 80);
            this.gpbCalculadoraPercent.TabIndex = 3;
            this.gpbCalculadoraPercent.TabStop = false;
            this.gpbCalculadoraPercent.Text = "Calculadora";
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(6, 55);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(79, 20);
            this.txtResultado.TabIndex = 70;
            // 
            // txtPercentCalc
            // 
            this.txtPercentCalc.Location = new System.Drawing.Point(6, 19);
            this.txtPercentCalc.Name = "txtPercentCalc";
            this.txtPercentCalc.Size = new System.Drawing.Size(38, 20);
            this.txtPercentCalc.TabIndex = 0;
            this.txtPercentCalc.TextChanged += new System.EventHandler(this.txtPercentCalc_TextChanged);
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(50, 22);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(15, 13);
            this.lblPercent.TabIndex = 69;
            this.lblPercent.Text = "%";
            // 
            // Vlr_Uni
            // 
            this.Vlr_Uni.AutoSize = true;
            this.Vlr_Uni.Location = new System.Drawing.Point(88, 19);
            this.Vlr_Uni.Name = "Vlr_Uni";
            this.Vlr_Uni.Size = new System.Drawing.Size(41, 13);
            this.Vlr_Uni.TabIndex = 66;
            this.Vlr_Uni.Text = "Vlr. Uni";
            // 
            // txtEditarValorUni
            // 
            this.txtEditarValorUni.Location = new System.Drawing.Point(91, 35);
            this.txtEditarValorUni.Name = "txtEditarValorUni";
            this.txtEditarValorUni.Size = new System.Drawing.Size(79, 20);
            this.txtEditarValorUni.TabIndex = 1;
            this.txtEditarValorUni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumerosDecimais_KeyPress);
            // 
            // txtEditarObservacao
            // 
            this.txtEditarObservacao.Location = new System.Drawing.Point(6, 74);
            this.txtEditarObservacao.Multiline = true;
            this.txtEditarObservacao.Name = "txtEditarObservacao";
            this.txtEditarObservacao.Size = new System.Drawing.Size(217, 77);
            this.txtEditarObservacao.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "Num. CTE";
            // 
            // txtEditarCTE
            // 
            this.txtEditarCTE.Location = new System.Drawing.Point(6, 35);
            this.txtEditarCTE.Name = "txtEditarCTE";
            this.txtEditarCTE.Size = new System.Drawing.Size(79, 20);
            this.txtEditarCTE.TabIndex = 0;
            this.txtEditarCTE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_DigitarNumeros_KeyPress);
            // 
            // frmManutencaoFretes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 451);
            this.Controls.Add(this.gpbEditar);
            this.Controls.Add(this.dgvDados);
            this.Controls.Add(this.gpbFiltros);
            this.Name = "frmManutencaoFretes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manutenção de Fretes";
            this.Load += new System.EventHandler(this.frmManutencaoFretes_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmManutencaoFretes_KeyDown);
            this.gpbFiltros.ResumeLayout(false);
            this.gpbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnProcurarTransportadora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.gpbEditar.ResumeLayout(false);
            this.gpbEditar.PerformLayout();
            this.gpbCalculadoraPercent.ResumeLayout(false);
            this.gpbCalculadoraPercent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCTE;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.GroupBox gpbFiltros;
        private System.Windows.Forms.PictureBox btnProcurarTransportadora;
        private System.Windows.Forms.Label lblTransportadora;
        private System.Windows.Forms.TextBox txtTransportadora;
        private System.Windows.Forms.TextBox txtCodTransportadora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCTE;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.GroupBox gpbEditar;
        private System.Windows.Forms.Label Vlr_Uni;
        private System.Windows.Forms.TextBox txtEditarValorUni;
        private System.Windows.Forms.TextBox txtEditarObservacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEditarCTE;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.CheckBox chkCalculadora;
        private System.Windows.Forms.GroupBox gpbCalculadoraPercent;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.TextBox txtPercentCalc;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFechar;
    }
}