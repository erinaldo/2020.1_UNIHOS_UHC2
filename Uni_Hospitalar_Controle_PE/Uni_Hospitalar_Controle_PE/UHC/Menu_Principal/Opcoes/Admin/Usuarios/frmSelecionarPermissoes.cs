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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Usuarios
{
    public partial class frmSelecionarPermissoes : Form
    {
        public frmSelecionarPermissoes()
        {
            InitializeComponent();
        }


        //SQL
        private SqlCommand command = new SqlCommand(); //Para comandos
        private SqlDataReader reader;                  //Para reader                


        //Erro de acesso ao sql
        private void erro_DeAcesso(SqlException SQLe)
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

        
       

        //Listas para ordenamento das permissões
        List<String> lCod_Rotina = new List<String>();
        List<String> lDesc_Rotina = new List<String>();
        List<String> lFuncao_Rotina= new List<String>();
        List<String> lCod_Sessao = new List<String>();
        List<String> lDesc_Sessao = new List<String>();


        //Lista de exportação das permissões
        public List<String> publPermissoes = new List<String>();
        public List<String> publCod_RotinaMaster = new List<String>();
        public List<String> publCod_SessaoMaster = new List<String>();
        public List<String> publDesc_RotinaMaster = new List<String>();

        //Inicialização do form
        private void Configuracao_Inicial()
        {
            cbxSessao.Text = "Geral";
            cbxSessao.Items.Add("Geral");            
                //Adiciona as sessões
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" SELECT " +
                                                 " S.Desc_Sessao " +
                                                 " FROM UNIDB.[dbo].SESSA S ", connectDMD);
                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Desc_Sessao"] != null) //Sendo o leitor diferente de nulo
                            {
                                cbxSessao.Items.Add(reader["Desc_Sessao"].ToString());
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
                        for (int x = 0; x < lCod_Sessao.Count; x++)
                        {
                            lsbListaPermissao.Items.Add(lDesc_Rotina[x]);
                        }
                    }
                }
                //Adiciona as rotinas filtradas
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" SELECT " +
                                                 " Cod_Rotina, " +
                                                 " Desc_Rotina, " +
                                                 " Funcao_Rotina, " +
                                                 " S.Cod_Sessao, " +
                                                 " S.Desc_Sessao " +
                                                 " FROM UNIDB.[dbo].SESSA S " +
                                                 " INNER JOIN UNIDB.[dbo].ROTIN R ON R.Cod_Sessao = S.Cod_Sessao " +
                                                 " ORDER BY Cod_Rotina ", connectDMD);
                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Cod_Rotina"] != null) //Sendo o leitor diferente de nulo
                            {
                                publCod_RotinaMaster.Add(reader["Cod_Rotina"].ToString());
                                publCod_SessaoMaster.Add(reader["Cod_Sessao"].ToString());
                                publDesc_RotinaMaster.Add(reader["Desc_Rotina"].ToString());
                                publPermissoes.Add("0");
                                lCod_Rotina.Add(reader["Cod_Rotina"].ToString());
                                lDesc_Rotina.Add(reader["Desc_Rotina"].ToString());
                                lFuncao_Rotina.Add(reader["Funcao_Rotina"].ToString());
                                lCod_Sessao.Add(reader["Cod_Sessao"].ToString());
                                lDesc_Sessao.Add(reader["Desc_Sessao"].ToString());
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
                        for (int x = 0; x < lCod_Sessao.Count; x++)
                        {
                            lsbListaPermissao.Items.Add(lDesc_Rotina[x]);
                        }
                    }
                }            
        }
        //Limpa as listas variáveis
        private void Limpar_Dados()
        {
            lsbListaPermissao.Items.Clear();
            lCod_Rotina.Clear();
            lDesc_Rotina.Clear();
            lFuncao_Rotina.Clear();
            lCod_Sessao.Clear();
            lDesc_Sessao.Clear();
        }

       

       

        //Método que permite a adição das permissões à lsbAdicionaPermissoes
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (lsbListaPermissao.SelectedItem != null)
            {
                lsbAdicionaPermissoes.Items.Add(lsbListaPermissao.SelectedItem.ToString());
                lsbListaPermissao.Items.Remove(lsbListaPermissao.SelectedItem.ToString());                
            }
            else
            {
                
                mMessage = "Selecione a permissão e clique em \">>\" para adicionar";
                mTittle = "Permissões";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Hand;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            }
        }
        private void lsbListaPermissao_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnAdicionar_Click(lsbListaPermissao, new EventArgs());           
        }
        //Permite a inserção das informações do lado direito, bloqueando ou desbloqueando o botão de adição
        private void lsbListaPermissao_SelectedIndexChanged(object sender, EventArgs e)
        {            
                //Adiciona as informações da direita referente a permissão
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" SELECT " +
                                                 " Cod_Rotina, " +
                                                 " Desc_Rotina, " +
                                                 " Funcao_Rotina, " +
                                                 " S.Cod_Sessao, " +
                                                 " S.Desc_Sessao " +
                                                 " FROM UNIDB.[dbo].SESSA S " +
                                                 " INNER JOIN UNIDB.[dbo].ROTIN R ON R.Cod_Sessao = S.Cod_Sessao " +
                                                 " WHERE Desc_Rotina like '" + lsbListaPermissao.SelectedItem + "'" +
                                                 " ORDER BY Cod_Rotina ", connectDMD);
                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Cod_Rotina"] != null) //Sendo o leitor diferente de nulo
                            {
                                txtSessao.Text = reader["Desc_Sessao"].ToString();
                                txtDescricaoRotina.Text = reader["Funcao_Rotina"].ToString();
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
          
          
            btnRemover.Enabled = false;
            btnAdicionar.Enabled = true;
        }

        //Método que permite a remoçãozomboy das permissões à lsbAdicionaPermissoes
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lsbAdicionaPermissoes.SelectedItem != null)
            {
                lsbListaPermissao.Items.Add(lsbAdicionaPermissoes.SelectedItem.ToString());
                lsbAdicionaPermissoes.Items.Remove(lsbAdicionaPermissoes.SelectedItem.ToString());
                
            }
            else
            {
                btnAdicionar.Enabled = false;
                mMessage = "Selecione a permissão e clique em \"<<\"";
                mTittle = "Permissões";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Hand;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            }

        }
        private void lsbAdicionaPermissoes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnRemover_Click(lsbAdicionaPermissoes,new EventArgs());
           
        }
        //Permite a inserção das informações do lado direito, bloqueando ou desbloqueando o botão de remoção
        private void lsbAdicionaPermissoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                //Adiciona as informações da direita referente a permissão
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" SELECT " +
                                                 " Cod_Rotina, " +
                                                 " Desc_Rotina, " +
                                                 " Funcao_Rotina, " +
                                                 " S.Cod_Sessao, " +
                                                 " S.Desc_Sessao " +
                                                 " FROM UNIDB.[dbo].SESSA S " +
                                                 " INNER JOIN UNIDB.[dbo].ROTIN R ON R.Cod_Sessao = S.Cod_Sessao " +
                                                 " WHERE Desc_Rotina like '" + lsbAdicionaPermissoes.SelectedItem + "'" +
                                                 " ORDER BY Cod_Rotina ", connectDMD);
                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Cod_Rotina"] != null) //Sendo o leitor diferente de nulo
                            {
                                txtSessao.Text = reader["Desc_Sessao"].ToString();
                                txtDescricaoRotina.Text = reader["Funcao_Rotina"].ToString();
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
                 
            btnRemover.Enabled = true;
            btnAdicionar.Enabled = false;
        }    
        private void cbxSessao_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpar_Dados();            
                if (cbxSessao.Text.Trim().Equals("Geral") || cbxSessao.SelectedItem.ToString().Trim().Equals("Geral"))
                {
                    //Adiciona as rotinas padrão
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            //Comando sql
                            command = new SqlCommand(" SELECT " +
                                                     " Cod_Rotina, " +
                                                     " Desc_Rotina, " +
                                                     " Funcao_Rotina, " +
                                                     " S.Cod_Sessao, " +
                                                     " S.Desc_Sessao " +
                                                     " FROM UNIDB.[dbo].SESSA S " +
                                                     " INNER JOIN UNIDB.[dbo].ROTIN R ON R.Cod_Sessao = S.Cod_Sessao " +
                                                     " ORDER BY Cod_Rotina ", connectDMD);
                            connectDMD.Open();
                            reader = command.ExecuteReader();
                            //Verifica se ocorrerá alteração de senha
                            while (reader.Read())
                            {
                                if (reader["Cod_Rotina"] != null) //Sendo o leitor diferente de nulo
                                {
                                    lCod_Rotina.Add(reader["Cod_Rotina"].ToString());
                                    lDesc_Rotina.Add(reader["Desc_Rotina"].ToString());
                                    lFuncao_Rotina.Add(reader["Funcao_Rotina"].ToString());
                                    lCod_Sessao.Add(reader["Cod_Sessao"].ToString());
                                    lDesc_Sessao.Add(reader["Desc_Sessao"].ToString());
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
                            for (int x = 0; x < lCod_Sessao.Count; x++)
                            {
                                lsbListaPermissao.Items.Add(lDesc_Rotina[x]);
                            }
                        }
                    }
                }
                else
                {
                    //Adiciona as rotinas filtradas
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            //Comando sql
                            command = new SqlCommand(" SELECT " +
                                                     " Cod_Rotina, " +
                                                     " Desc_Rotina, " +
                                                     " Funcao_Rotina, " +
                                                     " S.Cod_Sessao, " +
                                                     " S.Desc_Sessao " +
                                                     " FROM UNIDB.[dbo].SESSA S " +
                                                     " INNER JOIN UNIDB.[dbo].ROTIN R ON R.Cod_Sessao = S.Cod_Sessao " +
                                                     " WHERE DESC_SESSAO LIKE '" + cbxSessao.SelectedItem + "' " +
                                                     " ORDER BY Cod_Rotina ", connectDMD);
                            connectDMD.Open();
                            reader = command.ExecuteReader();
                            //Verifica se ocorrerá alteração de senha
                            while (reader.Read())
                            {
                                if (reader["Cod_Rotina"] != null) //Sendo o leitor diferente de nulo
                                {
                                    lCod_Rotina.Add(reader["Cod_Rotina"].ToString());
                                    lDesc_Rotina.Add(reader["Desc_Rotina"].ToString());
                                    lFuncao_Rotina.Add(reader["Funcao_Rotina"].ToString());
                                    lCod_Sessao.Add(reader["Cod_Sessao"].ToString());
                                    lDesc_Sessao.Add(reader["Desc_Sessao"].ToString());
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
                            for (int x = 0; x < lCod_Sessao.Count; x++)
                            {
                                lsbListaPermissao.Items.Add(lDesc_Rotina[x]);
                            }
                        }
                    }
                }            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            mMessage = "Deseja confirmar as opções?";
            mTittle = "Permissões";
            mButton = MessageBoxButtons.YesNo;
            mIcon = MessageBoxIcon.Information;
            DialogResult options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);


            if (options == DialogResult.Yes) {
                foreach (var item in lsbAdicionaPermissoes.Items)
                {
                    
                    for (int x = 0; x < publCod_RotinaMaster.Count; x++)
                    {
                        if (item.Equals(publDesc_RotinaMaster[x]))
                        {
                            
                            publPermissoes[x] = "1";
                        }
                    }

                }               

            }
            this.Close();
        }

        private void chkPermissaoAdm_CheckedChanged(object sender, EventArgs e)
        {            
                if (chkPermissaoAdm.Checked == true)
                {
                    lsbAdicionaPermissoes.Enabled = false;
                    lsbListaPermissao.Enabled = false;
                    //Adiciona as sessões
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            //Comando sql
                            command = new SqlCommand(" SELECT " +
                                                     " S.Desc_Sessao " +
                                                     " FROM UNIDB.[dbo].SESSA S ", connectDMD);
                            connectDMD.Open();
                            reader = command.ExecuteReader();
                            //Verifica se ocorrerá alteração de senha
                            while (reader.Read())
                            {
                                if (reader["Desc_Sessao"] != null) //Sendo o leitor diferente de nulo
                                {
                                    cbxSessao.Items.Add(reader["Desc_Sessao"].ToString());
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
                            for (int x = 0; x < lCod_Sessao.Count; x++)
                            {
                                lsbAdicionaPermissoes.Items.Add(lDesc_Rotina[x]);
                                lsbListaPermissao.Items.Clear();
                            }
                        }
                    }
                }
                else
                {
                    lsbAdicionaPermissoes.Enabled = true;
                    lsbListaPermissao.Enabled = true;
                    //Adiciona as sessões
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            //Comando sql
                            command = new SqlCommand(" SELECT " +
                                                     " S.Desc_Sessao " +
                                                     " FROM UNIDB.[dbo].SESSA S ", connectDMD);
                            connectDMD.Open();
                            reader = command.ExecuteReader();
                            //Verifica se ocorrerá alteração de senha
                            while (reader.Read())
                            {
                                if (reader["Desc_Sessao"] != null) //Sendo o leitor diferente de nulo
                                {
                                    cbxSessao.Items.Add(reader["Desc_Sessao"].ToString());
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
                            for (int x = 0; x < lCod_Sessao.Count; x++)
                            {
                                lsbListaPermissao.Items.Add(lDesc_Rotina[x]);
                                lsbAdicionaPermissoes.Items.Clear();
                            }
                        }
                    }
                }
            
        }

        private void CbxSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int disc_Comando = 0;
            cbxSessao.SelectedItem = null;
            if (cbxSetor.Text == "Financeiro")
            {
                disc_Comando = 1;
            }
            else if (cbxSetor.Text == "Vendas")
            {
                disc_Comando = 1;
            }
            else if (cbxSetor.Text == "Licitação")
            {
                disc_Comando = 1;
            }
            else if (cbxSetor.Text == "Administrativo")
            {
                disc_Comando = 1;
            }
            else if (cbxSetor.Text == "Logística")
            {
                disc_Comando = 1;
            }
            else if (cbxSetor.Text == "Opções" )
            {
                disc_Comando = 1;
            }
            if (disc_Comando == 1) {
                lsbListaPermissao.Items.Clear();                
                    //Adiciona as rotinas padrão
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            //Comando sql
                            command = new SqlCommand(" SELECT " +
                                                     " Cod_Rotina, " +
                                                     " Desc_Rotina, " +
                                                     " Funcao_Rotina, " +
                                                     " S.Cod_Sessao, " +
                                                     " S.Desc_Sessao " +
                                                     " FROM UNIDB.[dbo].SESSA S " +
                                                     " INNER JOIN UNIDB.[dbo].ROTIN R ON R.Cod_Sessao = S.Cod_Sessao " +
                                                     " WHERE DESC_ROTINa LIKE '% - " + cbxSetor.SelectedItem.ToString().ToUpper().Substring(0, 3).Replace("Ç", "C") + "'" +
                                                     " ORDER BY Cod_Rotina ", connectDMD);
                            connectDMD.Open();
                            reader = command.ExecuteReader();
                            //Verifica se ocorrerá alteração de senha
                            while (reader.Read())
                            {
                                if (reader["Cod_Rotina"] != null) //Sendo o leitor diferente de nulo
                                {
                                    if (!lsbAdicionaPermissoes.Items.Contains(reader["Desc_Rotina"].ToString()))
                                        lsbListaPermissao.Items.Add(reader["Desc_Rotina"].ToString());
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

        private void frmSelecionarPermissoes_Load(object sender, EventArgs e)
        {
            Configuracao_Inicial();
        }
    }
}
