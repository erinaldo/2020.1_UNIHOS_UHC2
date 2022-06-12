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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Pedido_OL
{
    public partial class frmPedidoOLAche : Form
    {
        public frmPedidoOLAche()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
        private SqlDataAdapter adaptador;
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




        //Instancia        



        private void frmPedidoOLAche_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Filtrar
        private void filtrar_Dados()
            {
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {

                    String filtro_NF = null;
                    String filtro_OL = null;
                    String filtro_Cliente = null;
                    String chk_NF_Existente = null;
                    String chk_Problema = null;

                    if (!txtCodCliente.Text.Equals(String.Empty))
                    {
                        filtro_Cliente = " AND Cliente.Codigo ="+txtCodCliente.Text;
                    }

                    if (!txtNF.Text.Equals(String.Empty))
                    {
                    filtro_NF = " AND NotaFiscal_CB.Num_Nota LIKE '%" + txtNF.Text + "%'";
                    }


                    if (!txtPedidoOL.Text.Equals(String.Empty))
                    {
                        filtro_OL = " AND Pedido_OL.Cod_PedCli LIKE '%" + txtPedidoOL.Text + "%' ";
                    }

                    if (chkNF.Checked)
                {
                    chk_NF_Existente = " AND Log_OL.NF_Pedido_OL IS NOT NULL ";
                }
                if (chkProblema.Checked)
                {
                    chk_Problema = " AND Observacao_Retorno_PedidoOL IS NOT NULL ";
                }



                try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText =
                          " SELECT                                                                                                                  "
                          +"          Log_OL.Num_PedidoOL[Pedido OL]                                                                                 "
                          +" 		,Log_OL.Dat_Entrada_PedidoOL[Dt.Entrada OL]                                                                     "
                          +" 		,NotaFiscal_CB.Num_Nota[NF]                                                                                     "
                          +" 		,NotaFiscal_CB.Dat_Emissao[Dt.Emissão NF]                                                                       "
                          +" 		,Log_OL.Observacao_Retorno_PedidoOL[Retorno]                                                                    "
                          +" 		,Cliente.Codigo[Cód.Cliente]                                                                                    "
                          +" 		,Cliente.Razao_Social[Cliente]                                                                                  "
                          +"                                                                                                                         "
                          +"                                                                                                                         "
                          +" FROM[UNIDB].dbo.[ROBOT_LogOL] Log_OL                                                                                    "
                          +" INNER JOIN[DMD].dbo.[PDECB] Pedido_OL ON Pedido_OL.Cod_PedCli = Log_OL.Num_PedidoOL COLLATE Latin1_General_CI_AS        "
                          +" LEFT JOIN[DMD].dbo.[NFSCB] NotaFiscal_CB ON NotaFiscal_CB.Num_Nota = Log_OL.NF_Pedido_OL                                "
                          +" INNER JOIN[DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = Pedido_OL.Cod_Client                                            "
                          +" WHERE 1 = 1                                                                                                             "
                          +filtro_Cliente
                          +filtro_NF
                          +filtro_OL
                          +chk_NF_Existente
                          +chk_Problema










                         ;






                        adaptador = new SqlDataAdapter(command);
                        System.Data.DataTable tableDados = new System.Data.DataTable();
                        adaptador.Fill(tableDados);
                        dgvPedido.DataSource = tableDados;

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

        //Função para digitar somente números
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }


        //Preenchimento Clientes
        private void btnPreencherCliente_Click(object sender, EventArgs e)
        {
            //Apontado para o CI da aba logísitica
            frmCriarCi_EscolherCliente form = new frmCriarCi_EscolherCliente();            
            form.ShowDialog();
            if (form.cod_cliente != 0)
                txtCodCliente.Text = Convert.ToString(form.cod_cliente);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            filtrar_Dados();
        }

        private void dgvPedido_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPedido.Rows.Count > 1)
            {
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
               


                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText =
                          " SELECT                                                                                                                  "                         
                        +  "           Produto.Codigo[Cód.Produto]                                                                                   "
                        +  " 		 ,Produto.Descricao[Produto]                                                                                    "
                        +  " 		 ,Produto.Cod_EAN[Cód.EAN]                                                                                      "
                        +  " 		 ,Pedido_OL_Itens.Prc_Unitario[Prc.Unitário]                                                                    "
                        +  " 		 ,Pedido_OL_Itens.Qtd_Atendi[Qtd.Itens]                                                                         "
                        +  " 		 ,[Total] = Pedido_OL_Itens.Prc_Unitario * Pedido_OL_Itens.Qtd_Atendi                                           "
                        +  " FROM[UNIDB].dbo.[ROBOT_LogOL] Log_OL                                                                                    "
                        +  " INNER JOIN[DMD].dbo.[PDECB] Pedido_OL ON Pedido_OL.Cod_PedCli = Log_OL.Num_PedidoOL COLLATE Latin1_General_CI_AS        "
                        +  " INNER JOIN[DMD].dbo.[PDEIT] Pedido_OL_Itens ON Pedido_OL_Itens.Cod_PedCli = Pedido_OL.Cod_PedCli                        "
                        +  " INNER JOIN[DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = Pedido_OL.Cod_Client                                            "
                        +  " INNER JOIN[DMD].dbo.[PRODU] Produto ON Produto.Codigo = Pedido_OL_Itens.Cod_Produt                                      "
                        +  " LEFT JOIN[DMD].dbo.[NFSCB] NotaFiscal_CB ON NotaFiscal_CB.Num_Nota = Log_OL.NF_Pedido_OL                                "
                        + " WHERE 1 = 1                                                                                                             "
                          +" AND Log_OL.Num_PedidoOL = " + dgvPedido.CurrentRow.Cells[0].Value.ToString();










                         ;






                        adaptador = new SqlDataAdapter(command);
                        System.Data.DataTable tableDados = new System.Data.DataTable();
                        adaptador.Fill(tableDados);
                        dgvProdutos.DataSource = tableDados;

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
                            erroSQLE(SQLe);
                        }
                        finally
                        {
                            connectDMD.Close();
                        }


                    }
                }                     
        }
    }
}
