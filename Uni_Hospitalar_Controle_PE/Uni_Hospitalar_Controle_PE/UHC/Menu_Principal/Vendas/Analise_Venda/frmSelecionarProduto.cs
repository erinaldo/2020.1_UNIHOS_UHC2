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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Analise_Venda
{
    public partial class frmSelecionarProduto : Form
    {
        public frmSelecionarProduto()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        //private SqlDataReader reader;
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
        public int Unidade_Servidor;
        public String user_Login;
        public int flag_Preencher = 0;

        //Configuracoes Iniciais
        private void configuracoes_Iniciais()
        {
            this.Icon = Properties.Resources.Icon_Uni;
            filtrar_Produtos(txtProduto.Text);
            dgvDados.Columns[1].Width = 300;
        }

        //Filtra produtos por nome Generico e Descrição
        private void filtrar_Produtos(String descricao)
        {            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText =
                                               " SELECT                                                                 "
                                               + "          Produto.Codigo                                               "
                                               + " 		,Produto.Descricao[Desc.Produto]                                "
                                               + " FROM PRODU Produto                                                    "
                                               + " WHERE                                                                 "
                                               + "     (Produto.Descricao LIKE '%" + descricao + "%'                   "
                                               + "    OR Produto.Des_NomGen LIKE '%" + descricao + "%' )               "
                                               + "                                                                       ";
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


        

        //Load do form
        private void frmSelecionarProduto_Load(object sender, EventArgs e)
        {
            configuracoes_Iniciais();
        }

        private void dgvDados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null)
            {
                flag_Preencher = 1;
                this.Close();
            }
            else
            {
                this.Close();                
            }
            
        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {
            filtrar_Produtos(txtProduto.Text);
        }

      
    }
}
