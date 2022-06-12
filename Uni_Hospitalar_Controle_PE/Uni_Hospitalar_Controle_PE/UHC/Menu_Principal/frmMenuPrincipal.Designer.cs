namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal
{
    partial class frmMenuPrincipal
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
            this.components = new System.ComponentModel.Container();
            this.Hour = new System.Windows.Forms.Timer(this.components);
            this.lblDiaMes = new System.Windows.Forms.Label();
            this.lblAno = new System.Windows.Forms.Label();
            this.pcbRelogio = new System.Windows.Forms.PictureBox();
            this.txtRelogio = new System.Windows.Forms.TextBox();
            this.pcbGLPI = new System.Windows.Forms.PictureBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblUsuarioLogado = new System.Windows.Forms.Label();
            this.btnFinanceiro = new System.Windows.Forms.Button();
            this.btnLogistica = new System.Windows.Forms.Button();
            this.btnLicitacao = new System.Windows.Forms.Button();
            this.btnAdministrativo = new System.Windows.Forms.Button();
            this.btnVendas = new System.Windows.Forms.Button();
            this.btnGerencial = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnDeslogar = new System.Windows.Forms.Button();
            this.btnOpcoes = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbRelogio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGLPI)).BeginInit();
            this.SuspendLayout();
            // 
            // Hour
            // 
            this.Hour.Enabled = true;
            this.Hour.Interval = 1000;
            this.Hour.Tick += new System.EventHandler(this.Hour_Tick);
            // 
            // lblDiaMes
            // 
            this.lblDiaMes.AutoSize = true;
            this.lblDiaMes.BackColor = System.Drawing.Color.Transparent;
            this.lblDiaMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaMes.Location = new System.Drawing.Point(16, 5);
            this.lblDiaMes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiaMes.Name = "lblDiaMes";
            this.lblDiaMes.Size = new System.Drawing.Size(123, 17);
            this.lblDiaMes.TabIndex = 9;
            this.lblDiaMes.Text = "19 de Setembro";
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.BackColor = System.Drawing.Color.Transparent;
            this.lblAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAno.Location = new System.Drawing.Point(16, 22);
            this.lblAno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(44, 17);
            this.lblAno.TabIndex = 10;
            this.lblAno.Text = "1997";
            // 
            // pcbRelogio
            // 
            this.pcbRelogio.BackColor = System.Drawing.Color.Transparent;
            this.pcbRelogio.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.imgRelogio;
            this.pcbRelogio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbRelogio.Location = new System.Drawing.Point(1220, 5);
            this.pcbRelogio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pcbRelogio.Name = "pcbRelogio";
            this.pcbRelogio.Size = new System.Drawing.Size(29, 25);
            this.pcbRelogio.TabIndex = 19;
            this.pcbRelogio.TabStop = false;
            // 
            // txtRelogio
            // 
            this.txtRelogio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRelogio.Location = new System.Drawing.Point(1257, 6);
            this.txtRelogio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRelogio.Name = "txtRelogio";
            this.txtRelogio.ReadOnly = true;
            this.txtRelogio.Size = new System.Drawing.Size(67, 22);
            this.txtRelogio.TabIndex = 0;
            // 
            // pcbGLPI
            // 
            this.pcbGLPI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pcbGLPI.BackColor = System.Drawing.Color.Transparent;
            this.pcbGLPI.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.button_GLPI;
            this.pcbGLPI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbGLPI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbGLPI.Location = new System.Drawing.Point(1, 683);
            this.pcbGLPI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pcbGLPI.Name = "pcbGLPI";
            this.pcbGLPI.Size = new System.Drawing.Size(131, 57);
            this.pcbGLPI.TabIndex = 26;
            this.pcbGLPI.TabStop = false;
            this.pcbGLPI.Click += new System.EventHandler(this.pcbSuporte_Click);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresa.Location = new System.Drawing.Point(16, 38);
            this.lblEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(71, 17);
            this.lblEmpresa.TabIndex = 27;
            this.lblEmpresa.Text = "Empresa";
            // 
            // lblUsuarioLogado
            // 
            this.lblUsuarioLogado.AutoSize = true;
            this.lblUsuarioLogado.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuarioLogado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioLogado.Location = new System.Drawing.Point(16, 55);
            this.lblUsuarioLogado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuarioLogado.Name = "lblUsuarioLogado";
            this.lblUsuarioLogado.Size = new System.Drawing.Size(69, 17);
            this.lblUsuarioLogado.TabIndex = 30;
            this.lblUsuarioLogado.Text = "Usuário:";
            // 
            // btnFinanceiro
            // 
            this.btnFinanceiro.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnFinanceiro.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnFinanceiro.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFinanceiro.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinanceiro.Location = new System.Drawing.Point(757, 325);
            this.btnFinanceiro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFinanceiro.Name = "btnFinanceiro";
            this.btnFinanceiro.Size = new System.Drawing.Size(569, 68);
            this.btnFinanceiro.TabIndex = 31;
            this.btnFinanceiro.Text = "Financeiro";
            this.btnFinanceiro.UseVisualStyleBackColor = false;
            this.btnFinanceiro.Click += new System.EventHandler(this.btnFinanceiro_Click);
            // 
            // btnLogistica
            // 
            this.btnLogistica.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLogistica.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnLogistica.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLogistica.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogistica.Location = new System.Drawing.Point(757, 473);
            this.btnLogistica.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogistica.Name = "btnLogistica";
            this.btnLogistica.Size = new System.Drawing.Size(569, 68);
            this.btnLogistica.TabIndex = 32;
            this.btnLogistica.Text = "Logística";
            this.btnLogistica.UseVisualStyleBackColor = false;
            this.btnLogistica.Click += new System.EventHandler(this.btnLogistica_Click);
            // 
            // btnLicitacao
            // 
            this.btnLicitacao.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnLicitacao.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnLicitacao.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLicitacao.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLicitacao.Location = new System.Drawing.Point(757, 398);
            this.btnLicitacao.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLicitacao.Name = "btnLicitacao";
            this.btnLicitacao.Size = new System.Drawing.Size(569, 68);
            this.btnLicitacao.TabIndex = 33;
            this.btnLicitacao.Text = "Licitação";
            this.btnLicitacao.UseVisualStyleBackColor = false;
            // 
            // btnAdministrativo
            // 
            this.btnAdministrativo.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnAdministrativo.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnAdministrativo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdministrativo.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrativo.Location = new System.Drawing.Point(756, 249);
            this.btnAdministrativo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdministrativo.Name = "btnAdministrativo";
            this.btnAdministrativo.Size = new System.Drawing.Size(569, 68);
            this.btnAdministrativo.TabIndex = 35;
            this.btnAdministrativo.Text = "Administrativo";
            this.btnAdministrativo.UseVisualStyleBackColor = false;
            this.btnAdministrativo.Click += new System.EventHandler(this.btnAdministrativo_Click);
            // 
            // btnVendas
            // 
            this.btnVendas.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnVendas.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnVendas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnVendas.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVendas.Location = new System.Drawing.Point(756, 549);
            this.btnVendas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVendas.Name = "btnVendas";
            this.btnVendas.Size = new System.Drawing.Size(569, 66);
            this.btnVendas.TabIndex = 36;
            this.btnVendas.Text = "Vendas";
            this.btnVendas.UseVisualStyleBackColor = false;
            this.btnVendas.Click += new System.EventHandler(this.BtnVendas_Click);
            // 
            // btnGerencial
            // 
            this.btnGerencial.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnGerencial.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnGerencial.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGerencial.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerencial.Location = new System.Drawing.Point(756, 623);
            this.btnGerencial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGerencial.Name = "btnGerencial";
            this.btnGerencial.Size = new System.Drawing.Size(569, 66);
            this.btnGerencial.TabIndex = 37;
            this.btnGerencial.Text = "Gerencial";
            this.btnGerencial.UseVisualStyleBackColor = false;
            this.btnGerencial.Click += new System.EventHandler(this.btnGerencial_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(1215, 694);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(111, 42);
            this.btnFechar.TabIndex = 38;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnDeslogar
            // 
            this.btnDeslogar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeslogar.BackColor = System.Drawing.Color.Silver;
            this.btnDeslogar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeslogar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeslogar.ForeColor = System.Drawing.Color.White;
            this.btnDeslogar.Location = new System.Drawing.Point(1096, 694);
            this.btnDeslogar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeslogar.Name = "btnDeslogar";
            this.btnDeslogar.Size = new System.Drawing.Size(111, 42);
            this.btnDeslogar.TabIndex = 39;
            this.btnDeslogar.Text = "Deslogar";
            this.btnDeslogar.UseVisualStyleBackColor = false;
            this.btnDeslogar.Click += new System.EventHandler(this.btnDeslogar_Click);
            // 
            // btnOpcoes
            // 
            this.btnOpcoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpcoes.BackColor = System.Drawing.Color.DarkRed;
            this.btnOpcoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpcoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpcoes.ForeColor = System.Drawing.Color.White;
            this.btnOpcoes.Location = new System.Drawing.Point(991, 694);
            this.btnOpcoes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpcoes.Name = "btnOpcoes";
            this.btnOpcoes.Size = new System.Drawing.Size(97, 42);
            this.btnOpcoes.TabIndex = 40;
            this.btnOpcoes.Text = "Opções";
            this.btnOpcoes.UseVisualStyleBackColor = false;
            this.btnOpcoes.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // frmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.Tela_Menu_Principal;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1333, 740);
            this.Controls.Add(this.btnOpcoes);
            this.Controls.Add(this.btnDeslogar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnGerencial);
            this.Controls.Add(this.btnVendas);
            this.Controls.Add(this.btnAdministrativo);
            this.Controls.Add(this.btnLicitacao);
            this.Controls.Add(this.btnLogistica);
            this.Controls.Add(this.btnFinanceiro);
            this.Controls.Add(this.lblUsuarioLogado);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.pcbGLPI);
            this.Controls.Add(this.pcbRelogio);
            this.Controls.Add(this.lblAno);
            this.Controls.Add(this.lblDiaMes);
            this.Controls.Add(this.txtRelogio);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmMenuPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbRelogio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbGLPI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Hour;
        private System.Windows.Forms.Label lblDiaMes;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.PictureBox pcbRelogio;
        private System.Windows.Forms.TextBox txtRelogio;
        private System.Windows.Forms.PictureBox pcbGLPI;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblUsuarioLogado;
        private System.Windows.Forms.Button btnFinanceiro;
        private System.Windows.Forms.Button btnLogistica;
        private System.Windows.Forms.Button btnLicitacao;
        private System.Windows.Forms.Button btnAdministrativo;
        private System.Windows.Forms.Button btnVendas;
        private System.Windows.Forms.Button btnGerencial;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnDeslogar;
        private System.Windows.Forms.Button btnOpcoes;
    }
}