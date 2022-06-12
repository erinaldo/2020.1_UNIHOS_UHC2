namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro
{
    partial class frmFinanceiro
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
            this.lblFinanceiro = new System.Windows.Forms.Label();
            this.gpbRecebimindo = new System.Windows.Forms.GroupBox();
            this.lblContasRecebidas = new System.Windows.Forms.Label();
            this.lblRecebimentoPublicoPrivado = new System.Windows.Forms.Label();
            this.lblContasAreceber = new System.Windows.Forms.Label();
            this.gpbGNRE = new System.Windows.Forms.GroupBox();
            this.lblMonitorGNRE = new System.Windows.Forms.Label();
            this.lblExportacaoGnre = new System.Windows.Forms.Label();
            this.lblDifalFCP = new System.Windows.Forms.Label();
            this.gpbCanhotos = new System.Windows.Forms.GroupBox();
            this.lblCanhotosRecebidos = new System.Windows.Forms.Label();
            this.lblAusenciaDeCanhotos = new System.Windows.Forms.Label();
            this.gpbCI = new System.Windows.Forms.GroupBox();
            this.lblConferenciaDeCI = new System.Windows.Forms.Label();
            this.gpbApagar = new System.Windows.Forms.GroupBox();
            this.lblContasApagar = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblCustoMedio = new System.Windows.Forms.Label();
            this.lblCustoDeSaida = new System.Windows.Forms.Label();
            this.gpbCusto = new System.Windows.Forms.GroupBox();
            this.lblCustoMensal = new System.Windows.Forms.Label();
            this.gpbRecebimindo.SuspendLayout();
            this.gpbGNRE.SuspendLayout();
            this.gpbCanhotos.SuspendLayout();
            this.gpbCI.SuspendLayout();
            this.gpbApagar.SuspendLayout();
            this.gpbCusto.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFinanceiro
            // 
            this.lblFinanceiro.AutoSize = true;
            this.lblFinanceiro.BackColor = System.Drawing.Color.Gainsboro;
            this.lblFinanceiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinanceiro.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFinanceiro.Location = new System.Drawing.Point(15, 9);
            this.lblFinanceiro.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblFinanceiro.Name = "lblFinanceiro";
            this.lblFinanceiro.Size = new System.Drawing.Size(318, 69);
            this.lblFinanceiro.TabIndex = 0;
            this.lblFinanceiro.Text = "Financeiro";
            // 
            // gpbRecebimindo
            // 
            this.gpbRecebimindo.BackColor = System.Drawing.Color.Gainsboro;
            this.gpbRecebimindo.Controls.Add(this.lblContasRecebidas);
            this.gpbRecebimindo.Controls.Add(this.lblRecebimentoPublicoPrivado);
            this.gpbRecebimindo.Controls.Add(this.lblContasAreceber);
            this.gpbRecebimindo.Location = new System.Drawing.Point(13, 233);
            this.gpbRecebimindo.Name = "gpbRecebimindo";
            this.gpbRecebimindo.Size = new System.Drawing.Size(193, 97);
            this.gpbRecebimindo.TabIndex = 2;
            this.gpbRecebimindo.TabStop = false;
            this.gpbRecebimindo.Text = "Recebimento";
            // 
            // lblContasRecebidas
            // 
            this.lblContasRecebidas.AutoSize = true;
            this.lblContasRecebidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContasRecebidas.Location = new System.Drawing.Point(6, 69);
            this.lblContasRecebidas.Name = "lblContasRecebidas";
            this.lblContasRecebidas.Size = new System.Drawing.Size(156, 24);
            this.lblContasRecebidas.TabIndex = 2;
            this.lblContasRecebidas.Text = "Contas recebidas";
            this.lblContasRecebidas.Click += new System.EventHandler(this.LblContasRecebidas_Click);
            this.lblContasRecebidas.MouseLeave += new System.EventHandler(this.lblContasRecebidas_MouseLeave);
            this.lblContasRecebidas.MouseHover += new System.EventHandler(this.lblContasRecebidas_MouseHover);
            // 
            // lblRecebimentoPublicoPrivado
            // 
            this.lblRecebimentoPublicoPrivado.AutoSize = true;
            this.lblRecebimentoPublicoPrivado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecebimentoPublicoPrivado.Location = new System.Drawing.Point(6, 47);
            this.lblRecebimentoPublicoPrivado.Name = "lblRecebimentoPublicoPrivado";
            this.lblRecebimentoPublicoPrivado.Size = new System.Drawing.Size(221, 24);
            this.lblRecebimentoPublicoPrivado.TabIndex = 1;
            this.lblRecebimentoPublicoPrivado.Text = "Receb. público e privado";
            this.lblRecebimentoPublicoPrivado.Click += new System.EventHandler(this.LblRecebimentoPublicoPrivado_Click);
            this.lblRecebimentoPublicoPrivado.MouseLeave += new System.EventHandler(this.lblRecebimentoPublico_MouseLeave);
            this.lblRecebimentoPublicoPrivado.MouseHover += new System.EventHandler(this.lblRecebimentoPublico_MouseHover);
            // 
            // lblContasAreceber
            // 
            this.lblContasAreceber.AutoSize = true;
            this.lblContasAreceber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContasAreceber.Location = new System.Drawing.Point(6, 25);
            this.lblContasAreceber.Name = "lblContasAreceber";
            this.lblContasAreceber.Size = new System.Drawing.Size(154, 24);
            this.lblContasAreceber.TabIndex = 0;
            this.lblContasAreceber.Text = "Contas a receber";
            this.lblContasAreceber.Click += new System.EventHandler(this.LblContasAreceber_Click);
            this.lblContasAreceber.MouseLeave += new System.EventHandler(this.lblContasAreceber_MouseLeave);
            this.lblContasAreceber.MouseHover += new System.EventHandler(this.lblContasAreceber_MouseHover);
            // 
            // gpbGNRE
            // 
            this.gpbGNRE.BackColor = System.Drawing.Color.Gainsboro;
            this.gpbGNRE.Controls.Add(this.lblMonitorGNRE);
            this.gpbGNRE.Controls.Add(this.lblExportacaoGnre);
            this.gpbGNRE.Controls.Add(this.lblDifalFCP);
            this.gpbGNRE.Location = new System.Drawing.Point(211, 233);
            this.gpbGNRE.Name = "gpbGNRE";
            this.gpbGNRE.Size = new System.Drawing.Size(193, 97);
            this.gpbGNRE.TabIndex = 2;
            this.gpbGNRE.TabStop = false;
            this.gpbGNRE.Text = "GNRE";
            // 
            // lblMonitorGNRE
            // 
            this.lblMonitorGNRE.AutoSize = true;
            this.lblMonitorGNRE.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonitorGNRE.Location = new System.Drawing.Point(11, 69);
            this.lblMonitorGNRE.Name = "lblMonitorGNRE";
            this.lblMonitorGNRE.Size = new System.Drawing.Size(103, 24);
            this.lblMonitorGNRE.TabIndex = 2;
            this.lblMonitorGNRE.Text = "Monitor DF";
            this.lblMonitorGNRE.Click += new System.EventHandler(this.lblMonitorGNRE_Click);
            this.lblMonitorGNRE.MouseLeave += new System.EventHandler(this.lblMonitorGNRE_MouseLeave);
            this.lblMonitorGNRE.MouseHover += new System.EventHandler(this.lblMonitorGNRE_MouseHover);
            // 
            // lblExportacaoGnre
            // 
            this.lblExportacaoGnre.AutoSize = true;
            this.lblExportacaoGnre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportacaoGnre.Location = new System.Drawing.Point(11, 47);
            this.lblExportacaoGnre.Name = "lblExportacaoGnre";
            this.lblExportacaoGnre.Size = new System.Drawing.Size(183, 24);
            this.lblExportacaoGnre.TabIndex = 1;
            this.lblExportacaoGnre.Text = "Exportação de XML ";
            this.lblExportacaoGnre.Click += new System.EventHandler(this.LblExportacaoGnre_Click);
            this.lblExportacaoGnre.MouseLeave += new System.EventHandler(this.lblExportacaoGnre_MouseLeave);
            this.lblExportacaoGnre.MouseHover += new System.EventHandler(this.lblExportacaoGnre_MouseHover);
            // 
            // lblDifalFCP
            // 
            this.lblDifalFCP.AutoSize = true;
            this.lblDifalFCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifalFCP.Location = new System.Drawing.Point(11, 25);
            this.lblDifalFCP.Name = "lblDifalFCP";
            this.lblDifalFCP.Size = new System.Drawing.Size(191, 24);
            this.lblDifalFCP.TabIndex = 0;
            this.lblDifalFCP.Text = "Controle DIFAL - FCP";
            this.lblDifalFCP.Click += new System.EventHandler(this.lblDifalFCP_Click);
            this.lblDifalFCP.MouseLeave += new System.EventHandler(this.lblDifalFCP_MouseLeave);
            this.lblDifalFCP.MouseHover += new System.EventHandler(this.lblDifalFCP_MouseHover);
            // 
            // gpbCanhotos
            // 
            this.gpbCanhotos.BackColor = System.Drawing.Color.Gainsboro;
            this.gpbCanhotos.Controls.Add(this.lblCanhotosRecebidos);
            this.gpbCanhotos.Controls.Add(this.lblAusenciaDeCanhotos);
            this.gpbCanhotos.Location = new System.Drawing.Point(12, 130);
            this.gpbCanhotos.Name = "gpbCanhotos";
            this.gpbCanhotos.Size = new System.Drawing.Size(193, 97);
            this.gpbCanhotos.TabIndex = 3;
            this.gpbCanhotos.TabStop = false;
            this.gpbCanhotos.Text = "Canhotos";
            // 
            // lblCanhotosRecebidos
            // 
            this.lblCanhotosRecebidos.AutoSize = true;
            this.lblCanhotosRecebidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanhotosRecebidos.Location = new System.Drawing.Point(6, 47);
            this.lblCanhotosRecebidos.Name = "lblCanhotosRecebidos";
            this.lblCanhotosRecebidos.Size = new System.Drawing.Size(179, 24);
            this.lblCanhotosRecebidos.TabIndex = 1;
            this.lblCanhotosRecebidos.Text = "Canhotos recebidos";
            this.lblCanhotosRecebidos.MouseLeave += new System.EventHandler(this.lblCanhotosRecebidos_MouseLeave);
            this.lblCanhotosRecebidos.MouseHover += new System.EventHandler(this.lblCanhotosRecebidos_MouseHover);
            // 
            // lblAusenciaDeCanhotos
            // 
            this.lblAusenciaDeCanhotos.AutoSize = true;
            this.lblAusenciaDeCanhotos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAusenciaDeCanhotos.Location = new System.Drawing.Point(6, 25);
            this.lblAusenciaDeCanhotos.Name = "lblAusenciaDeCanhotos";
            this.lblAusenciaDeCanhotos.Size = new System.Drawing.Size(222, 24);
            this.lblAusenciaDeCanhotos.TabIndex = 0;
            this.lblAusenciaDeCanhotos.Text = "Ausência por pagamento";
            this.lblAusenciaDeCanhotos.MouseLeave += new System.EventHandler(this.lblAusenciaDeCanhotos_MouseLeave);
            this.lblAusenciaDeCanhotos.MouseHover += new System.EventHandler(this.lblAusenciaDeCanhotos_MouseHover);
            // 
            // gpbCI
            // 
            this.gpbCI.BackColor = System.Drawing.Color.Gainsboro;
            this.gpbCI.Controls.Add(this.lblConferenciaDeCI);
            this.gpbCI.Location = new System.Drawing.Point(211, 130);
            this.gpbCI.Name = "gpbCI";
            this.gpbCI.Size = new System.Drawing.Size(193, 97);
            this.gpbCI.TabIndex = 2;
            this.gpbCI.TabStop = false;
            this.gpbCI.Text = "CI";
            // 
            // lblConferenciaDeCI
            // 
            this.lblConferenciaDeCI.AutoSize = true;
            this.lblConferenciaDeCI.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConferenciaDeCI.Location = new System.Drawing.Point(6, 25);
            this.lblConferenciaDeCI.Name = "lblConferenciaDeCI";
            this.lblConferenciaDeCI.Size = new System.Drawing.Size(161, 24);
            this.lblConferenciaDeCI.TabIndex = 0;
            this.lblConferenciaDeCI.Text = "Conferencia de CI";
            this.lblConferenciaDeCI.Click += new System.EventHandler(this.lblConferenciaDeCI_Click);
            this.lblConferenciaDeCI.MouseLeave += new System.EventHandler(this.lblConferenciaDeCI_MouseLeave);
            this.lblConferenciaDeCI.MouseHover += new System.EventHandler(this.lblConferenciaDeCI_MouseHover);
            // 
            // gpbApagar
            // 
            this.gpbApagar.BackColor = System.Drawing.Color.Gainsboro;
            this.gpbApagar.Controls.Add(this.lblContasApagar);
            this.gpbApagar.Location = new System.Drawing.Point(410, 233);
            this.gpbApagar.Name = "gpbApagar";
            this.gpbApagar.Size = new System.Drawing.Size(193, 97);
            this.gpbApagar.TabIndex = 5;
            this.gpbApagar.TabStop = false;
            this.gpbApagar.Text = "A pagar";
            // 
            // lblContasApagar
            // 
            this.lblContasApagar.AutoSize = true;
            this.lblContasApagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContasApagar.Location = new System.Drawing.Point(6, 25);
            this.lblContasApagar.Name = "lblContasApagar";
            this.lblContasApagar.Size = new System.Drawing.Size(136, 24);
            this.lblContasApagar.TabIndex = 0;
            this.lblContasApagar.Text = "Contas a pagar";
            this.lblContasApagar.Click += new System.EventHandler(this.lblContasApagar_Click);
            this.lblContasApagar.MouseLeave += new System.EventHandler(this.lblContasApagar_MouseLeave);
            this.lblContasApagar.MouseHover += new System.EventHandler(this.lblContasApagar_MouseHover);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(555, 388);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(73, 34);
            this.btnFechar.TabIndex = 7;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // lblCustoMedio
            // 
            this.lblCustoMedio.AutoSize = true;
            this.lblCustoMedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustoMedio.Location = new System.Drawing.Point(6, 47);
            this.lblCustoMedio.Name = "lblCustoMedio";
            this.lblCustoMedio.Size = new System.Drawing.Size(116, 24);
            this.lblCustoMedio.TabIndex = 0;
            this.lblCustoMedio.Text = "Custo médio";
            this.lblCustoMedio.Click += new System.EventHandler(this.lblCustoMedio_Click);
            this.lblCustoMedio.MouseLeave += new System.EventHandler(this.lblCustoMedio_MouseLeave);
            this.lblCustoMedio.MouseHover += new System.EventHandler(this.lblCustoMedio_MouseHover);
            // 
            // lblCustoDeSaida
            // 
            this.lblCustoDeSaida.AutoSize = true;
            this.lblCustoDeSaida.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustoDeSaida.Location = new System.Drawing.Point(6, 25);
            this.lblCustoDeSaida.Name = "lblCustoDeSaida";
            this.lblCustoDeSaida.Size = new System.Drawing.Size(221, 24);
            this.lblCustoDeSaida.TabIndex = 1;
            this.lblCustoDeSaida.Text = "Calculadora Custo Médio";
            this.lblCustoDeSaida.Click += new System.EventHandler(this.lblCustoDeSaida_Click);
            this.lblCustoDeSaida.MouseLeave += new System.EventHandler(this.lblCustoDeSaida_MouseLeave);
            this.lblCustoDeSaida.MouseHover += new System.EventHandler(this.lblCustoDeSaida_MouseHover);
            // 
            // gpbCusto
            // 
            this.gpbCusto.BackColor = System.Drawing.Color.Gainsboro;
            this.gpbCusto.Controls.Add(this.lblCustoMensal);
            this.gpbCusto.Controls.Add(this.lblCustoDeSaida);
            this.gpbCusto.Controls.Add(this.lblCustoMedio);
            this.gpbCusto.Location = new System.Drawing.Point(410, 130);
            this.gpbCusto.Name = "gpbCusto";
            this.gpbCusto.Size = new System.Drawing.Size(193, 97);
            this.gpbCusto.TabIndex = 1;
            this.gpbCusto.TabStop = false;
            this.gpbCusto.Text = "Custo";
            // 
            // lblCustoMensal
            // 
            this.lblCustoMensal.AutoSize = true;
            this.lblCustoMensal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustoMensal.Location = new System.Drawing.Point(6, 68);
            this.lblCustoMensal.Name = "lblCustoMensal";
            this.lblCustoMensal.Size = new System.Drawing.Size(182, 24);
            this.lblCustoMensal.TabIndex = 2;
            this.lblCustoMensal.Text = "Custo Médio Mensal";
            this.lblCustoMensal.Visible = false;
            // 
            // frmFinanceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgd_Financeiro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(633, 425);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gpbApagar);
            this.Controls.Add(this.gpbCI);
            this.Controls.Add(this.gpbCanhotos);
            this.Controls.Add(this.gpbGNRE);
            this.Controls.Add(this.gpbRecebimindo);
            this.Controls.Add(this.gpbCusto);
            this.Controls.Add(this.lblFinanceiro);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmFinanceiro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financeiro";
            this.Load += new System.EventHandler(this.frmFinanceiro_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFinanceiro_KeyDown);
            this.gpbRecebimindo.ResumeLayout(false);
            this.gpbRecebimindo.PerformLayout();
            this.gpbGNRE.ResumeLayout(false);
            this.gpbGNRE.PerformLayout();
            this.gpbCanhotos.ResumeLayout(false);
            this.gpbCanhotos.PerformLayout();
            this.gpbCI.ResumeLayout(false);
            this.gpbCI.PerformLayout();
            this.gpbApagar.ResumeLayout(false);
            this.gpbApagar.PerformLayout();
            this.gpbCusto.ResumeLayout(false);
            this.gpbCusto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFinanceiro;
        private System.Windows.Forms.GroupBox gpbRecebimindo;
        private System.Windows.Forms.Label lblContasRecebidas;
        private System.Windows.Forms.Label lblRecebimentoPublicoPrivado;
        private System.Windows.Forms.Label lblContasAreceber;
        private System.Windows.Forms.GroupBox gpbGNRE;
        private System.Windows.Forms.Label lblExportacaoGnre;
        private System.Windows.Forms.Label lblDifalFCP;
        private System.Windows.Forms.GroupBox gpbCanhotos;
        private System.Windows.Forms.Label lblAusenciaDeCanhotos;
        private System.Windows.Forms.Label lblCanhotosRecebidos;
        private System.Windows.Forms.GroupBox gpbCI;
        private System.Windows.Forms.Label lblConferenciaDeCI;
        private System.Windows.Forms.Label lblMonitorGNRE;
        private System.Windows.Forms.GroupBox gpbApagar;
        private System.Windows.Forms.Label lblContasApagar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblCustoMedio;
        private System.Windows.Forms.Label lblCustoDeSaida;
        private System.Windows.Forms.GroupBox gpbCusto;
        private System.Windows.Forms.Label lblCustoMensal;
    }
}