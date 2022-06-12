namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Setores
{
    partial class frmGerenciarSetores
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
            this.lsbColaboradores = new System.Windows.Forms.ListBox();
            this.gpbSetor = new System.Windows.Forms.GroupBox();
            this.lsbSetor = new System.Windows.Forms.ListBox();
            this.gpbDados = new System.Windows.Forms.GroupBox();
            this.lblColaboradores = new System.Windows.Forms.Label();
            this.lblEmailDoSetor = new System.Windows.Forms.Label();
            this.txtEmailDoSetor = new System.Windows.Forms.TextBox();
            this.lblGerenciarMotivos = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.gpbSetor.SuspendLayout();
            this.gpbDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsbColaboradores
            // 
            this.lsbColaboradores.FormattingEnabled = true;
            this.lsbColaboradores.Location = new System.Drawing.Point(38, 78);
            this.lsbColaboradores.Name = "lsbColaboradores";
            this.lsbColaboradores.Size = new System.Drawing.Size(327, 160);
            this.lsbColaboradores.TabIndex = 0;
            // 
            // gpbSetor
            // 
            this.gpbSetor.Controls.Add(this.lsbSetor);
            this.gpbSetor.Location = new System.Drawing.Point(10, 47);
            this.gpbSetor.Name = "gpbSetor";
            this.gpbSetor.Size = new System.Drawing.Size(143, 288);
            this.gpbSetor.TabIndex = 1;
            this.gpbSetor.TabStop = false;
            this.gpbSetor.Text = "Setor";
            // 
            // lsbSetor
            // 
            this.lsbSetor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbSetor.FormattingEnabled = true;
            this.lsbSetor.Location = new System.Drawing.Point(3, 16);
            this.lsbSetor.Name = "lsbSetor";
            this.lsbSetor.Size = new System.Drawing.Size(137, 269);
            this.lsbSetor.TabIndex = 0;
            this.lsbSetor.SelectedIndexChanged += new System.EventHandler(this.lsbSetor_SelectedIndexChanged);
            // 
            // gpbDados
            // 
            this.gpbDados.Controls.Add(this.lblColaboradores);
            this.gpbDados.Controls.Add(this.lblEmailDoSetor);
            this.gpbDados.Controls.Add(this.txtEmailDoSetor);
            this.gpbDados.Controls.Add(this.lsbColaboradores);
            this.gpbDados.Location = new System.Drawing.Point(159, 47);
            this.gpbDados.Name = "gpbDados";
            this.gpbDados.Size = new System.Drawing.Size(408, 245);
            this.gpbDados.TabIndex = 2;
            this.gpbDados.TabStop = false;
            this.gpbDados.Text = "Dados";
            // 
            // lblColaboradores
            // 
            this.lblColaboradores.AutoSize = true;
            this.lblColaboradores.Location = new System.Drawing.Point(35, 62);
            this.lblColaboradores.Name = "lblColaboradores";
            this.lblColaboradores.Size = new System.Drawing.Size(75, 13);
            this.lblColaboradores.TabIndex = 3;
            this.lblColaboradores.Text = "Colaboradores";
            // 
            // lblEmailDoSetor
            // 
            this.lblEmailDoSetor.AutoSize = true;
            this.lblEmailDoSetor.Location = new System.Drawing.Point(3, 16);
            this.lblEmailDoSetor.Name = "lblEmailDoSetor";
            this.lblEmailDoSetor.Size = new System.Drawing.Size(76, 13);
            this.lblEmailDoSetor.TabIndex = 2;
            this.lblEmailDoSetor.Text = "E-mail do setor";
            // 
            // txtEmailDoSetor
            // 
            this.txtEmailDoSetor.Location = new System.Drawing.Point(6, 34);
            this.txtEmailDoSetor.Name = "txtEmailDoSetor";
            this.txtEmailDoSetor.Size = new System.Drawing.Size(396, 20);
            this.txtEmailDoSetor.TabIndex = 1;
            // 
            // lblGerenciarMotivos
            // 
            this.lblGerenciarMotivos.AutoSize = true;
            this.lblGerenciarMotivos.BackColor = System.Drawing.Color.Gainsboro;
            this.lblGerenciarMotivos.Font = new System.Drawing.Font("Open Sans", 20F, System.Drawing.FontStyle.Bold);
            this.lblGerenciarMotivos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblGerenciarMotivos.Location = new System.Drawing.Point(3, 5);
            this.lblGerenciarMotivos.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblGerenciarMotivos.Name = "lblGerenciarMotivos";
            this.lblGerenciarMotivos.Size = new System.Drawing.Size(255, 37);
            this.lblGerenciarMotivos.TabIndex = 21;
            this.lblGerenciarMotivos.Text = "Gerenciar setores";
            this.lblGerenciarMotivos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(497, 312);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 35;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(159, 312);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 36;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(497, 12);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 37;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // frmGerenciarSetores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgdFundo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(580, 338);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblGerenciarMotivos);
            this.Controls.Add(this.gpbDados);
            this.Controls.Add(this.gpbSetor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmGerenciarSetores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setores";
            this.Load += new System.EventHandler(this.frmGerenciarSetores_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGerenciarSetores_KeyDown);
            this.gpbSetor.ResumeLayout(false);
            this.gpbDados.ResumeLayout(false);
            this.gpbDados.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lsbColaboradores;
        private System.Windows.Forms.GroupBox gpbSetor;
        private System.Windows.Forms.ListBox lsbSetor;
        private System.Windows.Forms.GroupBox gpbDados;
        private System.Windows.Forms.Label lblColaboradores;
        private System.Windows.Forms.Label lblEmailDoSetor;
        private System.Windows.Forms.Label lblGerenciarMotivos;
        private System.Windows.Forms.TextBox txtEmailDoSetor;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnInserir;
    }
}