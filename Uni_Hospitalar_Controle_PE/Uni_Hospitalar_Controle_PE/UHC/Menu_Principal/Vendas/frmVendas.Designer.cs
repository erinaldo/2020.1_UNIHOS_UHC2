namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas
{
    partial class frmVendas
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
            this.btnFechar = new System.Windows.Forms.Button();
            this.gpbPrecificacao = new System.Windows.Forms.GroupBox();
            this.lblConsultarPedidoCliente = new System.Windows.Forms.Label();
            this.lblConsultaDePrecos = new System.Windows.Forms.Label();
            this.lblLogistica = new System.Windows.Forms.Label();
            this.gpbPedidoOL = new System.Windows.Forms.GroupBox();
            this.lblConsultarPedidoOLAche = new System.Windows.Forms.Label();
            this.gpbAnaliseVendas = new System.Windows.Forms.GroupBox();
            this.lblVendasPorOperador_Analitico = new System.Windows.Forms.Label();
            this.lblVendasPorOperador_Sintetico = new System.Windows.Forms.Label();
            this.gpbPrecificacao.SuspendLayout();
            this.gpbPedidoOL.SuspendLayout();
            this.gpbAnaliseVendas.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(604, 324);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(73, 34);
            this.btnFechar.TabIndex = 19;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.BtnFechar_Click);
            // 
            // gpbPrecificacao
            // 
            this.gpbPrecificacao.BackColor = System.Drawing.Color.Gainsboro;
            this.gpbPrecificacao.Controls.Add(this.lblConsultarPedidoCliente);
            this.gpbPrecificacao.Controls.Add(this.lblConsultaDePrecos);
            this.gpbPrecificacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.gpbPrecificacao.Location = new System.Drawing.Point(12, 86);
            this.gpbPrecificacao.Name = "gpbPrecificacao";
            this.gpbPrecificacao.Size = new System.Drawing.Size(218, 217);
            this.gpbPrecificacao.TabIndex = 20;
            this.gpbPrecificacao.TabStop = false;
            this.gpbPrecificacao.Text = "Precificação";
            // 
            // lblConsultarPedidoCliente
            // 
            this.lblConsultarPedidoCliente.AutoSize = true;
            this.lblConsultarPedidoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultarPedidoCliente.Location = new System.Drawing.Point(6, 45);
            this.lblConsultarPedidoCliente.Name = "lblConsultarPedidoCliente";
            this.lblConsultarPedidoCliente.Size = new System.Drawing.Size(190, 18);
            this.lblConsultarPedidoCliente.TabIndex = 1;
            this.lblConsultarPedidoCliente.Text = "Consultar pedido do Cliente";
            this.lblConsultarPedidoCliente.Click += new System.EventHandler(this.lblConsultarPedidoCliente_Click);
            this.lblConsultarPedidoCliente.MouseLeave += new System.EventHandler(this.lblConsultarPedidoCliente_MouseLeave);
            this.lblConsultarPedidoCliente.MouseHover += new System.EventHandler(this.lblConsultarPedidoCliente_MouseHover);
            // 
            // lblConsultaDePrecos
            // 
            this.lblConsultaDePrecos.AutoSize = true;
            this.lblConsultaDePrecos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultaDePrecos.Location = new System.Drawing.Point(6, 25);
            this.lblConsultaDePrecos.Name = "lblConsultaDePrecos";
            this.lblConsultaDePrecos.Size = new System.Drawing.Size(137, 18);
            this.lblConsultaDePrecos.TabIndex = 0;
            this.lblConsultaDePrecos.Text = "Consulta de preços";
            this.lblConsultaDePrecos.Click += new System.EventHandler(this.LblConsultaDePrecos_Click);
            this.lblConsultaDePrecos.MouseLeave += new System.EventHandler(this.LblConsultaDePrecosI_MouseLeave);
            this.lblConsultaDePrecos.MouseHover += new System.EventHandler(this.LblConsultaDePrecos_MouseHover);
            // 
            // lblLogistica
            // 
            this.lblLogistica.AutoSize = true;
            this.lblLogistica.BackColor = System.Drawing.Color.Gainsboro;
            this.lblLogistica.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogistica.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLogistica.Location = new System.Drawing.Point(4, 3);
            this.lblLogistica.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLogistica.Name = "lblLogistica";
            this.lblLogistica.Size = new System.Drawing.Size(194, 55);
            this.lblLogistica.TabIndex = 21;
            this.lblLogistica.Text = "Vendas";
            // 
            // gpbPedidoOL
            // 
            this.gpbPedidoOL.BackColor = System.Drawing.Color.Gainsboro;
            this.gpbPedidoOL.Controls.Add(this.lblConsultarPedidoOLAche);
            this.gpbPedidoOL.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.gpbPedidoOL.Location = new System.Drawing.Point(236, 86);
            this.gpbPedidoOL.Name = "gpbPedidoOL";
            this.gpbPedidoOL.Size = new System.Drawing.Size(218, 217);
            this.gpbPedidoOL.TabIndex = 21;
            this.gpbPedidoOL.TabStop = false;
            this.gpbPedidoOL.Text = "Pedido OL";
            // 
            // lblConsultarPedidoOLAche
            // 
            this.lblConsultarPedidoOLAche.AutoSize = true;
            this.lblConsultarPedidoOLAche.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultarPedidoOLAche.Location = new System.Drawing.Point(6, 25);
            this.lblConsultarPedidoOLAche.Name = "lblConsultarPedidoOLAche";
            this.lblConsultarPedidoOLAche.Size = new System.Drawing.Size(115, 18);
            this.lblConsultarPedidoOLAche.TabIndex = 1;
            this.lblConsultarPedidoOLAche.Text = "Pedido OL Aché";
            this.lblConsultarPedidoOLAche.Click += new System.EventHandler(this.lblConsultarPedidoOLAche_Click);
            this.lblConsultarPedidoOLAche.MouseLeave += new System.EventHandler(this.lblConsultarPedidoOLAche_MouseLeave);
            this.lblConsultarPedidoOLAche.MouseHover += new System.EventHandler(this.lblConsultarPedidoOLAche_MouseHover);
            // 
            // gpbAnaliseVendas
            // 
            this.gpbAnaliseVendas.BackColor = System.Drawing.Color.Gainsboro;
            this.gpbAnaliseVendas.Controls.Add(this.lblVendasPorOperador_Analitico);
            this.gpbAnaliseVendas.Controls.Add(this.lblVendasPorOperador_Sintetico);
            this.gpbAnaliseVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.gpbAnaliseVendas.Location = new System.Drawing.Point(460, 86);
            this.gpbAnaliseVendas.Name = "gpbAnaliseVendas";
            this.gpbAnaliseVendas.Size = new System.Drawing.Size(218, 217);
            this.gpbAnaliseVendas.TabIndex = 22;
            this.gpbAnaliseVendas.TabStop = false;
            this.gpbAnaliseVendas.Text = "Análise de Vendas";
            // 
            // lblVendasPorOperador_Analitico
            // 
            this.lblVendasPorOperador_Analitico.AutoSize = true;
            this.lblVendasPorOperador_Analitico.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendasPorOperador_Analitico.Location = new System.Drawing.Point(6, 46);
            this.lblVendasPorOperador_Analitico.Name = "lblVendasPorOperador_Analitico";
            this.lblVendasPorOperador_Analitico.Size = new System.Drawing.Size(194, 18);
            this.lblVendasPorOperador_Analitico.TabIndex = 2;
            this.lblVendasPorOperador_Analitico.Text = "Vendas x Operador Analítico";
            this.lblVendasPorOperador_Analitico.Click += new System.EventHandler(this.lblVendaPorOperador_Analitico_Click);
            this.lblVendasPorOperador_Analitico.MouseLeave += new System.EventHandler(this.lblVendaPorOperador_Analitico_MouseLeave);
            this.lblVendasPorOperador_Analitico.MouseHover += new System.EventHandler(this.lblVendaPorOperador_Analitico_MouseHover);
            // 
            // lblVendasPorOperador_Sintetico
            // 
            this.lblVendasPorOperador_Sintetico.AutoSize = true;
            this.lblVendasPorOperador_Sintetico.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendasPorOperador_Sintetico.Location = new System.Drawing.Point(6, 25);
            this.lblVendasPorOperador_Sintetico.Name = "lblVendasPorOperador_Sintetico";
            this.lblVendasPorOperador_Sintetico.Size = new System.Drawing.Size(196, 18);
            this.lblVendasPorOperador_Sintetico.TabIndex = 1;
            this.lblVendasPorOperador_Sintetico.Text = "Vendas x Operador Sintetico";
            this.lblVendasPorOperador_Sintetico.Click += new System.EventHandler(this.lblVendaPorOperador_Sintetico_Click);
            this.lblVendasPorOperador_Sintetico.MouseLeave += new System.EventHandler(this.lblVendaPorOperador_Sintetico_MouseLeave);
            this.lblVendasPorOperador_Sintetico.MouseHover += new System.EventHandler(this.lblVendaPorOperador_Sintetico_MouseHover);
            // 
            // frmVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Uni_Hospitalar_Controle_PE.Properties.Resources.bgd_Televendas;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(688, 365);
            this.Controls.Add(this.gpbAnaliseVendas);
            this.Controls.Add(this.gpbPedidoOL);
            this.Controls.Add(this.lblLogistica);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gpbPrecificacao);
            this.KeyPreview = true;
            this.Name = "frmVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendas";
            this.Load += new System.EventHandler(this.FrmVendas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmVendas_KeyDown);
            this.gpbPrecificacao.ResumeLayout(false);
            this.gpbPrecificacao.PerformLayout();
            this.gpbPedidoOL.ResumeLayout(false);
            this.gpbPedidoOL.PerformLayout();
            this.gpbAnaliseVendas.ResumeLayout(false);
            this.gpbAnaliseVendas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.GroupBox gpbPrecificacao;
        private System.Windows.Forms.Label lblConsultaDePrecos;
        private System.Windows.Forms.Label lblLogistica;
        private System.Windows.Forms.Label lblConsultarPedidoCliente;
        private System.Windows.Forms.GroupBox gpbPedidoOL;
        private System.Windows.Forms.Label lblConsultarPedidoOLAche;
        private System.Windows.Forms.GroupBox gpbAnaliseVendas;
        private System.Windows.Forms.Label lblVendasPorOperador_Sintetico;
        private System.Windows.Forms.Label lblVendasPorOperador_Analitico;
    }
}