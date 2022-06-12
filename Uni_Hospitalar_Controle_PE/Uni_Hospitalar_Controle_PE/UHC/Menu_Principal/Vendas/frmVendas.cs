using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Analise_Venda;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Pedido_OL;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Precificacao;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas
{
    public partial class frmVendas : Form
    {
        public frmVendas()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;

        //Erro sql
        private void erroSQLE(SqlException SQLe)
        {
            mMessage = "Erro de acesso ao servidor: " + SQLe.Message;
            mTittle = "SQL Server error";
            mButton = MessageBoxButtons.OK;
            mIcon = MessageBoxIcon.Error;
            MessageBox.Show(mMessage, mTittle, mButton, mIcon);
        }

        //Variáveis de TextBox
        private String mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
                

        //Permissões 
        private void Carregar_Bloqueios()
        {
            //Dados
            lblConsultaDePrecos.Enabled = false;
            lblConsultarPedidoCliente.Enabled = false;
            lblConsultarPedidoOLAche.Enabled = false;
            lblVendasPorOperador_Analitico.Visible = false;
            lblVendasPorOperador_Sintetico.Enabled = false;
            
        }
        private void Carregar_Permissoes()
        {           
                //Subindo permissões
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT Cod_Usuario,Cod_Sessao,Cod_Rotina,Status_Acesso " +
                                              " FROM  UNIDB.[dbo].ACESS " +
                                              " WHERE Cod_Usuario = " + Usuario.userId;
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Cod_Usuario"] != null)
                            {
                                //Permissão para usuário
                                if (reader["Cod_Rotina"].ToString() == "24" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblConsultaDePrecos.Enabled = true;
                                    lblConsultarPedidoCliente.Enabled = true;
                                    lblConsultarPedidoOLAche.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "43" && reader["Status_Acesso"].ToString() == "1") 
                                {
                                    lblVendasPorOperador_Sintetico.Enabled = true;
                                }

                            }
                        }
                    }

                    catch (SqlException SQLe)
                    {
                        erroSQLE(SQLe);

                    }
                    finally
                    {
                        connectDMD.Close();

                    }
                }            
        }

        private void FrmVendas_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            Carregar_Bloqueios();
            Carregar_Permissoes();
        }


        //Dados
        //Consulta de preços
        private void LblConsultaDePrecos_Click(object sender, EventArgs e)
        {
            frmConsultarPrecos form = new frmConsultarPrecos();
            
            this.Hide();            
            form.Show();
        }
        private void LblConsultaDePrecos_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblConsultaDePrecos.ForeColor = Color.White;
            lblConsultaDePrecos.BackColor = Color.Black;
        }
        private void LblConsultaDePrecosI_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblConsultaDePrecos.ForeColor = Color.Black;
            lblConsultaDePrecos.BackColor = Color.Transparent;
        }

        //Consultar pedido do cliente
        private void lblConsultarPedidoCliente_Click(object sender, EventArgs e)
        {
            frmConsultarPedidoCliente form = new frmConsultarPedidoCliente();
            
            this.Hide();
            form.Show();
        }
        private void lblConsultarPedidoCliente_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblConsultarPedidoCliente.ForeColor = Color.White;
            lblConsultarPedidoCliente.BackColor = Color.Black;
        }
        private void lblConsultarPedidoCliente_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblConsultarPedidoCliente.ForeColor = Color.Black;
            lblConsultarPedidoCliente.BackColor = Color.Transparent;
        }

        //Fechar com esc
        private void FrmVendas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void lblConsultarPedidoOLAche_Click(object sender, EventArgs e)
        {
            frmPedidoOLAche form = new frmPedidoOLAche();
            
            form.Show();

        }
        private void lblConsultarPedidoOLAche_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblConsultarPedidoOLAche.ForeColor = Color.White;
            lblConsultarPedidoOLAche.BackColor = Color.Black;
        }
        private void lblConsultarPedidoOLAche_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblConsultarPedidoOLAche.ForeColor = Color.Black;
            lblConsultarPedidoOLAche.BackColor = Color.Transparent;
        }

        private void lblVendaPorOperador_Sintetico_Click(object sender, EventArgs e)
        {
            frmVendaPorOperador_Sintetico form = new frmVendaPorOperador_Sintetico();
            
            form.Show();
        }

        private void lblVendaPorOperador_Sintetico_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblVendasPorOperador_Sintetico.ForeColor = Color.White;
            lblVendasPorOperador_Sintetico.BackColor = Color.Black;
        }
        private void lblVendaPorOperador_Sintetico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblVendasPorOperador_Sintetico.ForeColor = Color.Black;
            lblVendasPorOperador_Sintetico.BackColor = Color.Transparent;
        }

        private void lblVendaPorOperador_Analitico_Click(object sender, EventArgs e)
        {
            
            
        }

        private void lblVendaPorOperador_Analitico_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblVendasPorOperador_Analitico.ForeColor = Color.White;
            lblVendasPorOperador_Analitico.BackColor = Color.Black;
        }
        
        private void lblVendaPorOperador_Analitico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblVendasPorOperador_Analitico.ForeColor = Color.Black;
            lblVendasPorOperador_Analitico.BackColor = Color.Transparent;
        }



        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
