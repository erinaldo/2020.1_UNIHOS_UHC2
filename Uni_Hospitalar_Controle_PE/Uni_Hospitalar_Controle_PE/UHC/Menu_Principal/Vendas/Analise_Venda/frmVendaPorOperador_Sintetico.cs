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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Analise_Venda
{
    public partial class frmVendaPorOperador_Sintetico : Form
    {
        public frmVendaPorOperador_Sintetico()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();        
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

        //Configurações Iniciais
        private void configuracoes_Iniciais()
        {
            this.Icon = Properties.Resources.Icon_Uni;
            filtrar_Dados();
            dtpDatInicial.Value = DateTime.Now;
            dtpDatFinal.Value = DateTime.Now;
        }

        private void filtrar_Dados()
        {

            string filtro_Operador = null;
            if (!txtOperador.Text.Equals(String.Empty))
            {
                filtro_Operador = " AND  Vendedor.Codigo = " + txtCodOperador.Text;
            }
            string filtro_Cliente = null;
            if (!txtCliente.Text.Equals(String.Empty))
            {
                filtro_Cliente = " AND  NF_Saida.Cod_Cliente = " + txtCodCliente.Text;
            }

            string filtro_Produto = null;
            if (!txtProduto.Text.Equals(String.Empty))
            {
                filtro_Produto = " AND  NF_Saida_Itens.Cod_Produto = " + txtCodProduto.Text;
            }
                                    
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText =
                                               " SELECT Vendedor.codigo [Código]                                                                      "
                                              + " 			 ,Vendedor.Nome_Guerra  [Operador]                                                        "
                                              + "              ,[Qtd.Vendas] = Sum(NF_Saida_Itens.qtd_produto + NF_Saida_Itens.qtd_bonificacao)       "
                                              + "              ,[Vlr.Vendas] = Sum(NF_Saida_Itens.Vlr_LiqItem - NF_Saida_Itens.vlr_substrib           "
                                              + "                                - NF_Saida_Itens.vlr_sbtres - NF_Saida_Itens.vlr_recsbt -            "
                                              + "                                  NF_Saida_Itens.vlr_substribemb - NF_Saida_Itens.vlr_desprateada)   "
                                              + " FROM NFSCB NF_Saida                                                                                 "
                                              + " JOIN[DMD].dbo.[NFSIT] NF_Saida_Itens ON NF_Saida.num_nota = NF_Saida_Itens.Num_Nota                 "
                                              + " JOIN[DMD].dbo.[PDVCB] Pedido_Venda ON Pedido_Venda.Cod_NumNfsIni = NF_Saida.Num_Nota                "
                                              + " JOIN[DMD].dbo.[VENDE] Vendedor ON Pedido_Venda.Cod_VendTlmkt = Vendedor.Codigo                      "
                                              + " WHERE                                                                                               "
                                              + "                                                                                                     "
                                              + "            NF_Saida.Status = 'F'                                                                    "
                                              + " AND NF_Saida.Tip_Saida = 'V'                                                                        "
                                              + " AND NF_Saida.Dat_Emissao >= '"+dtpDatInicial.Value.ToString("yyyyMMdd")+"'                          "
                                              + " AND NF_Saida.Dat_Emissao <= '"+dtpDatFinal.Value.ToString("yyyyMMdd")+"'                            "
                                              + filtro_Operador
                                              + filtro_Cliente
                                              + filtro_Produto                                                                                            
                                              + " GROUP BY                                                                                            "
                                              + "  Vendedor.codigo                                                                                    "
                                              + " ,Vendedor.Nome_Guerra                                                                               "
                                              + "                                                                                                     "
                                              + " ORDER BY[Vlr.Vendas] desc                                                                           ";
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
                        dgvDados.Columns[2].ValueType = typeof(decimal);
                        dgvDados.Columns[3].DefaultCellStyle.Format = "R$ #,##0.00";
                    }
                }                    
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            filtrar_Dados();
            this.Cursor = Cursors.Default;
        }


        //Produtos
        private void btnPreencherCliente_Click(object sender, EventArgs e)
        {
            //Apontado para o CI da aba logísitica
            frmCriarCi_EscolherCliente form = new frmCriarCi_EscolherCliente();            
            form.ShowDialog();
            if (form.cod_cliente != 0)
                txtCodCliente.Text = Convert.ToString(form.cod_cliente);
        }

        private void txtCodCliente_TextChanged(object sender, EventArgs e)
        {
            txtCliente.Text = String.Empty;
            if (!txtCodCliente.Text.Equals(String.Empty))
            {
                
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText =
                                                     " SELECT Cliente.Razao_Social       "
                                                   + " FROM [DMD].dbo.[CLIEN] Cliente "
                                                   + " WHERE Cliente.Codigo = " + txtCodCliente.Text;
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["Razao_Social"] != null)
                                {
                                    txtCliente.Text = reader["Razao_Social"].ToString();
                                }
                            }
                            reader.Close();
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

        private void pcbPreencherProduto_Click(object sender, EventArgs e)
        {
            frmSelecionarProduto form = new frmSelecionarProduto();            
            form.ShowDialog();
            if (form.flag_Preencher == 1)
            {
                txtCodProduto.Text = form.dgvDados.CurrentRow.Cells[0].Value.ToString();
            }
           
        }

   


        private void txtCodProduto_TextChanged(object sender, EventArgs e)
        {
            txtProduto.Text = String.Empty;
            if (!txtCodProduto.Text.Equals(String.Empty))
            {                
                
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText =
                                                    " SELECT Produto.Descricao       "                                                            
                                                   +" FROM [DMD].dbo.[PRODU] Produto "
                                                   +" WHERE Produto.Codigo = "+txtCodProduto.Text   ;
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["Descricao"] != null)
                                {
                                    txtProduto.Text = reader["Descricao"].ToString();
                                }
                            }
                            reader.Close();
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

        private void txtCodOperador_TextChanged(object sender, EventArgs e)
        {
            txtOperador.Text = String.Empty;
            if (!txtCodOperador.Text.Equals(String.Empty))
            {                              
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText =
                                                    " SELECT Vendedor.Nome_Guerra       "
                                                   + " FROM [DMD].dbo.[VENDE] Vendedor "
                                                   + " WHERE Vendedor.Codigo = " + txtCodOperador.Text;
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["Nome_Guerra"] != null)
                                {
                                    txtOperador.Text = reader["Nome_Guerra"].ToString();
                                }
                            }
                            reader.Close();
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVendaPorOperador_Sintetico_Load(object sender, EventArgs e)
        {
            configuracoes_Iniciais();
        }
    }
}
