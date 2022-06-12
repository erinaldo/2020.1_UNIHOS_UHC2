namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Custo_Medio
{
    partial class frmCalc_Custo_Med
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pgbCustoMedio = new System.Windows.Forms.ProgressBar();
            this.lblContasAreceber = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.dgvCustoFinal = new System.Windows.Forms.DataGridView();
            this.btnRecalcular = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustoFinal)).BeginInit();
            this.SuspendLayout();
            // 
            // pgbCustoMedio
            // 
            this.pgbCustoMedio.Location = new System.Drawing.Point(16, 66);
            this.pgbCustoMedio.Margin = new System.Windows.Forms.Padding(4);
            this.pgbCustoMedio.Name = "pgbCustoMedio";
            this.pgbCustoMedio.Size = new System.Drawing.Size(416, 46);
            this.pgbCustoMedio.TabIndex = 0;
            // 
            // lblContasAreceber
            // 
            this.lblContasAreceber.AutoSize = true;
            this.lblContasAreceber.BackColor = System.Drawing.Color.Gainsboro;
            this.lblContasAreceber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContasAreceber.Location = new System.Drawing.Point(16, 12);
            this.lblContasAreceber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContasAreceber.Name = "lblContasAreceber";
            this.lblContasAreceber.Size = new System.Drawing.Size(255, 31);
            this.lblContasAreceber.TabIndex = 4;
            this.lblContasAreceber.Text = "Calculadora Custo";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(332, 119);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(100, 33);
            this.btnCalcular.TabIndex = 5;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(332, 295);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 33);
            this.btnFechar.TabIndex = 7;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(16, 165);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(415, 118);
            this.txtInfo.TabIndex = 8;
            // 
            // dgvCustoFinal
            // 
            this.dgvCustoFinal.AllowUserToAddRows = false;
            this.dgvCustoFinal.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCustoFinal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustoFinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustoFinal.Location = new System.Drawing.Point(275, 295);
            this.dgvCustoFinal.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCustoFinal.Name = "dgvCustoFinal";
            this.dgvCustoFinal.ReadOnly = true;
            this.dgvCustoFinal.RowHeadersVisible = false;
            this.dgvCustoFinal.RowHeadersWidth = 51;
            this.dgvCustoFinal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustoFinal.Size = new System.Drawing.Size(49, 36);
            this.dgvCustoFinal.TabIndex = 9;
            this.dgvCustoFinal.Visible = false;
            // 
            // btnRecalcular
            // 
            this.btnRecalcular.Location = new System.Drawing.Point(224, 119);
            this.btnRecalcular.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecalcular.Name = "btnRecalcular";
            this.btnRecalcular.Size = new System.Drawing.Size(100, 33);
            this.btnRecalcular.TabIndex = 10;
            this.btnRecalcular.Text = "Recalcular";
            this.btnRecalcular.UseVisualStyleBackColor = true;
            this.btnRecalcular.Click += new System.EventHandler(this.btnRecalcular_Click);
            // 
            // frmCalc_Custo_Med
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 340);
            this.Controls.Add(this.btnRecalcular);
            this.Controls.Add(this.dgvCustoFinal);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblContasAreceber);
            this.Controls.Add(this.pgbCustoMedio);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(466, 387);
            this.MinimumSize = new System.Drawing.Size(466, 387);
            this.Name = "frmCalc_Custo_Med";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora Custo";
            this.Load += new System.EventHandler(this.frmCalc_Custo_Med_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustoFinal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbCustoMedio;
        private System.Windows.Forms.Label lblContasAreceber;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.DataGridView dgvCustoFinal;
        private System.Windows.Forms.Button btnRecalcular;
    }
}