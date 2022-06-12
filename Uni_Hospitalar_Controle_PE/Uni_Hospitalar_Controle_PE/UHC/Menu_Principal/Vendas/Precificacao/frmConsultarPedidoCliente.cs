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
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Precificacao
{
    public partial class frmConsultarPedidoCliente : Form
    {
        public frmConsultarPedidoCliente()
        {
            InitializeComponent();
        }


        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlCommand command_2 = new SqlCommand();
        private SqlDataReader reader;
        private SqlDataAdapter adaptador = new SqlDataAdapter();

        //Erro sql
        private void erro_DeAcesso(SqlException SQLe)
        {
            mMessage = "Erro de acesso ao servidor: " + SQLe.Message;
            mTittle = "SQL Server error";
            mButton = MessageBoxButtons.OK;
            mIcon = MessageBoxIcon.Error;
            MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            return;
        }
        
        //Variáveis de TextBox
        private String mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;

        

        //Variável que define em qual conexão o programa se encontra 1 = PE 2 = CE 3 = SP
        //public int Unidade_Servidor;
        //public String user_Login;



        private void filtrar_Dados()
        {
            String sCondicao_PedidoCliente = null;
            String sCondicao_Cliente = null;

            //Condição PedidoCliente,
            if (!txtPedidoCliente.Text.Equals(String.Empty))
            {
                sCondicao_PedidoCliente = " AND PVCB.Observacao LIKE '%"+txtPedidoCliente.Text.Trim()+"%' ";
            }


            //Condição
            if (!txtCliente.Text.Equals(String.Empty))
            {
                sCondicao_Cliente = " AND CLIE.Codigo = "+txtCodCliente.Text+" ";
            }


           
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = "   SELECT NSCB.Num_Nota [NF]                                                "
                                              + "      ,NSCB.Dat_Emissao[Dat. Emissão]                                      "
                                              + "	  ,CLIE.Codigo[Cód. Cliente]                                              "
                                              + "	  ,CLIE.Razao_Social[Cliente]                                            "
                                              + "	  ,[CNPJ] = SUBSTRING(CLIE.Cgc_Cpf, 1, 2) + '.'                          "
                                              + "               + SUBSTRING(CLIE.Cgc_Cpf, 3, 3) + '.'                        "
                                              + "               + SUBSTRING(CLIE.Cgc_Cpf, 6, 3) + '/'                        "
                                              + "               + SUBSTRING(CLIE.Cgc_Cpf, 9, 4) + '-'                        "
                                              + "               + SUBSTRING(CLIE.Cgc_Cpf, 13, 2)                             "
                                              + "	  ,PVCB.Numero[Número Pedido Ally]                                                  "
                                              + "	  ,PVCB.Dat_Pedido[Dat. Pedido Ally]                                           "
                                              + "	  ,PVCB.Observacao [Observação]                                                          "
                                              + "   FROM[DMD].dbo.[PDVCB] PVCB                                               "
                                              + "   INNER JOIN[DMD].dbo.[CLIEN] CLIE ON CLIE.Codigo = PVCB.Cod_Cliente       "
                                              + "   LEFT JOIN[DMD].dbo.[NFSCB] NSCB ON NSCB.Cod_Pedido = PVCB.Numero         "
                                              + "   WHERE                                                                    "
                                              + "   PVCB.Observacao NOT LIKE '%TESTE%'                                       "
                                              + sCondicao_PedidoCliente
                                              + sCondicao_Cliente;
                        adaptador = new SqlDataAdapter(command);
                        System.Data.DataTable tableDados = new System.Data.DataTable();
                        adaptador.Fill(tableDados);
                        dgvDados.DataSource = tableDados;

                    }
                    catch (SqlException SQLe)
                    {
                        erro_DeAcesso(SQLe);
                    }
                    finally
                    {
                        connectDMD.Close();
                    }                    
                }               
        }

        private void filtrar_Produtos(DataGridViewRow row)
        {
            if (dgvDados.Rows.Count > 0)
            {

                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText =
                         "  SELECT PROD.Codigo[Cód.Produto]                                       "
                        + "  ,PROD.Descricao[Produto]                                              "
                        + "  	  ,NSIT.Qtd_Produto[Qtd.]                                            "
                        + "  	  ,NSIT.Prc_Unitario[Prc.Unitario]                                   "
                        + "  FROM[DMD].dbo.[PDVCB] PVCB                                            "
                        + "  INNER JOIN[DMD].dbo.[CLIEN] CLIE ON CLIE.Codigo = PVCB.Cod_Cliente    "
                        + "  LEFT JOIN[DMD].dbo.[NFSCB] NSCB ON NSCB.Cod_Pedido = PVCB.Numero      "
                        + "  LEFT JOIN[DMD].dbo.[NFSIT] NSIT ON NSIT.Num_Nota = NSCB.Num_Nota      "
                        + "  INNER JOIN[DMD].dbo.[PRODU] PROD ON PROD.Codigo = NSIT.Cod_Produto    "
                        + "  WHERE NSCB.Num_Nota = " + row.Cells[0].Value.ToString();
                        adaptador = new SqlDataAdapter(command);
                        System.Data.DataTable tableDados = new System.Data.DataTable();
                        adaptador.Fill(tableDados);
                        dgvProdutosNF.DataSource = tableDados;

                    }
                    catch (SqlException SQLe)
                    {
                        erro_DeAcesso(SQLe);
                    }
                    finally
                    {
                        connectDMD.Close();
                    }
                }



            }
        }

            private void txtPedidoCliente_TextChanged(object sender, EventArgs e)
            {
                //filtrar_Dados();
            }

            private void lblPedidoCliente_Click(object sender, EventArgs e)
            {

            }

            private void txtPedidoCliente_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    filtrar_Dados();
                }

            }



            private void txtCodCliente_TextChanged(object sender, EventArgs e)
            {
                txtCliente.Clear();
                if (!txtCodCliente.Text.Trim().Equals(String.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT razao_social FROM clien WHERE CODIGO = " + Convert.ToInt32(txtCodCliente.Text);

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["razao_social"] != null)
                                {
                                    txtCliente.Text = reader["razao_social"].ToString();
                                }
                            }

                        }
                        catch (SqlException SQLe)
                        {
                            erro_DeAcesso(SQLe);
                        }
                        finally
                        {
                            connectDMD.Close();
                        }


                    }
                }
            }
        

        private void btnPreencherCliente_Click(object sender, EventArgs e)
        {
            //Apontado para o CI da aba logísitica
            frmCriarCi_EscolherCliente form = new frmCriarCi_EscolherCliente();            
            form.ShowDialog();
            if (form.cod_cliente != 0)
                txtCodCliente.Text = Convert.ToString(form.cod_cliente);
        }

        private void dgvDados_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            filtrar_Produtos(dgvDados.Rows[e.RowIndex]);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            filtrar_Dados();
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            frmContratosVendas form = new frmContratosVendas();            
            form.Show();
            
        }

        private void chkHelp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHelp.Checked == true)
            {
                
                lblAjudaCodCliente.Visible = true;
                lblAjudaConsulta.Visible = true;
                lblAjudaContratos.Visible = true;
                lblAjudaFiltrarClientes.Visible = true;
                lblAjudaNF.Visible = true;
                lblAjudaPedidoCliente.Visible = true;
            }
            else
            {
                
                lblAjudaCodCliente.Visible = false;
                lblAjudaConsulta.Visible = false;
                lblAjudaContratos.Visible = false;
                lblAjudaFiltrarClientes.Visible = false;
                lblAjudaNF.Visible = false;
                lblAjudaPedidoCliente.Visible = false;
            }
        }






        //Load do FORM
        private void frmConsultarPedidoCliente_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            lblAjudaCodCliente.Visible = false;
            lblAjudaConsulta.Visible = false;
            lblAjudaContratos.Visible = false;
            lblAjudaFiltrarClientes.Visible = false;
            lblAjudaNF.Visible = false;
            lblAjudaPedidoCliente.Visible = false;
        }


    }
}
