namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo
{
    partial class frmAdministrativo
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
            this.lblAdministrativo = new System.Windows.Forms.Label();
            this.gpbFretes = new System.Windows.Forms.GroupBox();
            this.lblConversorParaLayout = new System.Windows.Forms.Label();
            this.lblManutencao = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblConferenciaFretes = new System.Windows.Forms.Label();
            this.gpbCanhotos = new System.Windows.Forms.GroupBox();
            this.lblControleCanhotos = new System.Windows.Forms.Label();
            this.lblAusenciaGeral = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.gpbFretes.SuspendLayout();
            this.gpbCanhotos.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAdministrativo
            // 
            this.lblAdministrativo.AutoSize = true;
            this.lblAdministrativo.BackColor = System.Drawing.Color.Gainsboro;
            this.lblAdministrativo.Font = new System.Drawing.Font("Open Sans", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdministrativo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAdministrativo.Location = new System.Drawing.Point(13, 6);
            this.lblAdministrativo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblAdministrativo.Name = "lblAdministrativo";
            this.lblAdministrativo.Size = new System.Drawing.Size(389, 65);
            this.lblAdministrativo.TabIndex = 3;
            this.lblAdministrativo.Text = "Administrativo";
            // 
            // gpbFretes
            // 
            this.gpbFretes.BackColor = System.Drawing.Color.Gainsboro;
            this.gpbFretes.Controls.Add(this.lblConversorParaLayout);
            this.gpbFretes.Controls.Add(this.lblManutencao);
            this.gpbFretes.Controls.Add(this.lblInfo);
            this.gpbFretes.Controls.Add(this.lblConferenciaFretes);
            this.gpbFretes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.gpbFretes.Location = new System.Drawing.Point(229, 87);
            this.gpbFretes.Name = "gpbFretes";
            this.gpbFretes.Size = new System.Drawing.Size(193, 317);
            this.gpbFretes.TabIndex = 19;
            this.gpbFretes.TabStop = false;
            this.gpbFretes.Text = "Fretes";
            // 
            // lblConversorParaLayout
            // 
            this.lblConversorParaLayout.AutoSize = true;
            this.lblConversorParaLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConversorParaLayout.Location = new System.Drawing.Point(11, 81);
            this.lblConversorParaLayout.Name = "lblConversorParaLayout";
            this.lblConversorParaLayout.Size = new System.Drawing.Size(159, 18);
            this.lblConversorParaLayout.TabIndex = 3;
            this.lblConversorParaLayout.Text = "Conversor para Layout";
            this.lblConversorParaLayout.Click += new System.EventHandler(this.lblConversorParaLayout_Click);
            this.lblConversorParaLayout.MouseLeave += new System.EventHandler(this.lblConversorParaLayout_MouseLeave);
            this.lblConversorParaLayout.MouseHover += new System.EventHandler(this.lblConversorParaLayout_MouseHover);
            // 
            // lblManutencao
            // 
            this.lblManutencao.AutoSize = true;
            this.lblManutencao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManutencao.Location = new System.Drawing.Point(11, 62);
            this.lblManutencao.Name = "lblManutencao";
            this.lblManutencao.Size = new System.Drawing.Size(156, 18);
            this.lblManutencao.TabIndex = 2;
            this.lblManutencao.Text = "Manutenção de Fretes";
            this.lblManutencao.Click += new System.EventHandler(this.lblManutencao_Click);
            this.lblManutencao.MouseLeave += new System.EventHandler(this.lblManutencao_MouseLeave);
            this.lblManutencao.MouseHover += new System.EventHandler(this.lblManutencao_MouseHover);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(11, 43);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(32, 18);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Info";
            this.lblInfo.Click += new System.EventHandler(this.lblInfo_Click);
            this.lblInfo.MouseLeave += new System.EventHandler(this.lblInfo_MouseLeave);
            this.lblInfo.MouseHover += new System.EventHandler(this.lblInfo_MouseHover);
            // 
            // lblConferenciaFretes
            // 
            this.lblConferenciaFretes.AutoSize = true;
            this.lblConferenciaFretes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConferenciaFretes.Location = new System.Drawing.Point(11, 25);
            this.lblConferenciaFretes.Name = "lblConferenciaFretes";
            this.lblConferenciaFretes.Size = new System.Drawing.Size(88, 18);
            this.lblConferenciaFretes.TabIndex = 0;
            this.lblConferenciaFretes.Text = "Conferência";
            this.lblConferenciaFretes.Click += new System.EventHandler(this.lblConferenciaFretes_Click);
            this.lblConferenciaFretes.MouseLeave += new System.EventHandler(this.lblConferenciaFretes_MouseLeave);
            this.lblConferenciaFretes.MouseHover += new System.EventHandler(this.lblConferenciaFretes_MouseHover);
            // 
            // gpbCanhotos
            // 
            this.gpbCanhotos.BackColor = System.Drawing.Color.Gainsboro;
            this.gpbCanhotos.Controls.Add(this.lblControleCanhotos);
            this.gpbCanhotos.Controls.Add(this.lblAusenciaGeral);
            this.gpbCanhotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.gpbCanhotos.Location = new System.Drawing.Point(12, 86);
            this.gpbCanhotos.Name = "gpbCanhotos";
            this.gpbCanhotos.Size = new System.Drawing.Size(193, 317);
            this.gpbCanhotos.TabIndex = 18;
            this.gpbCanhotos.TabStop = false;
            this.gpbCanhotos.Text = "Canhotos";
            // 
            // lblControleCanhotos
            // 
            this.lblControleCanhotos.AutoSize = true;
            this.lblControleCanhotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControleCanhotos.Location = new System.Drawing.Point(11, 44);
            this.lblControleCanhotos.Name = "lblControleCanhotos";
            this.lblControleCanhotos.Size = new System.Drawing.Size(65, 18);
            this.lblControleCanhotos.TabIndex = 2;
            this.lblControleCanhotos.Text = "Controle";
            this.lblControleCanhotos.Click += new System.EventHandler(this.LblControleCanhotos_Click);
            this.lblControleCanhotos.MouseLeave += new System.EventHandler(this.lblControleCanhotos_MouseLeave);
            this.lblControleCanhotos.MouseHover += new System.EventHandler(this.lblControleCanhotos_MouseHover);
            // 
            // lblAusenciaGeral
            // 
            this.lblAusenciaGeral.AutoSize = true;
            this.lblAusenciaGeral.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAusenciaGeral.Location = new System.Drawing.Point(11, 25);
            this.lblAusenciaGeral.Name = "lblAusenciaGeral";
            this.lblAusenciaGeral.Size = new System.Drawing.Size(104, 18);
            this.lblAusenciaGeral.TabIndex = 0;
            this.lblAusenciaGeral.Text = "Ausência geral";
            this.lblAusenciaGeral.Click += new System.EventHandler(this.LblAusenciaGeral_Click);
            this.lblAusenciaGeral.MouseLeave += new System.EventHandler(this.lblAusenciaGeral_MouseLeave);
            this.lblAusenciaGeral.MouseHover += new System.EventHandler(this.lblAusenciaGeral_MouseHover);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(760, 418);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(73, 34);
            this.btnFechar.TabIndex = 7;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // frmAdministrativo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgd_Administrativo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(837, 455);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gpbFretes);
            this.Controls.Add(this.gpbCanhotos);
            this.Controls.Add(this.lblAdministrativo);
            this.KeyPreview = true;
            this.Name = "frmAdministrativo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrativo";
            this.Load += new System.EventHandler(this.frmAdministrativo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAdministrativo_KeyDown);
            this.gpbFretes.ResumeLayout(false);
            this.gpbFretes.PerformLayout();
            this.gpbCanhotos.ResumeLayout(false);
            this.gpbCanhotos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAdministrativo;
        private System.Windows.Forms.GroupBox gpbFretes;
        private System.Windows.Forms.Label lblConferenciaFretes;
        private System.Windows.Forms.GroupBox gpbCanhotos;
        private System.Windows.Forms.Label lblAusenciaGeral;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblControleCanhotos;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblManutencao;
        private System.Windows.Forms.Label lblConversorParaLayout;
    }
}