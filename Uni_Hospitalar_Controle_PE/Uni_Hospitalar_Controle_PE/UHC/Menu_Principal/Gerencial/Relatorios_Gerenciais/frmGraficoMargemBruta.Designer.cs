namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Gerencial.Relatorios_Gerenciais
{
    partial class frmGraficoMargemBruta
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblRelatorioMargemBruta = new System.Windows.Forms.Label();
            this.gMes = new LiveCharts.WinForms.CartesianChart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblRelatorioMargemBruta);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gMes);
            this.splitContainer1.Size = new System.Drawing.Size(1185, 615);
            this.splitContainer1.SplitterDistance = 51;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblRelatorioMargemBruta
            // 
            this.lblRelatorioMargemBruta.AutoSize = true;
            this.lblRelatorioMargemBruta.BackColor = System.Drawing.Color.Gainsboro;
            this.lblRelatorioMargemBruta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRelatorioMargemBruta.Location = new System.Drawing.Point(12, 9);
            this.lblRelatorioMargemBruta.Name = "lblRelatorioMargemBruta";
            this.lblRelatorioMargemBruta.Size = new System.Drawing.Size(261, 25);
            this.lblRelatorioMargemBruta.TabIndex = 21;
            this.lblRelatorioMargemBruta.Text = "Relatório Margem Bruta";
            // 
            // gMes
            // 
            this.gMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMes.Location = new System.Drawing.Point(0, 0);
            this.gMes.Name = "gMes";
            this.gMes.Size = new System.Drawing.Size(1185, 560);
            this.gMes.TabIndex = 45;
            // 
            // frmGraficoMargemBruta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 615);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmGraficoMargemBruta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gráfico";
            this.Load += new System.EventHandler(this.frmGraficoMargemBruta_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.Label lblRelatorioMargemBruta;
        private LiveCharts.WinForms.CartesianChart gMes;
    }
}