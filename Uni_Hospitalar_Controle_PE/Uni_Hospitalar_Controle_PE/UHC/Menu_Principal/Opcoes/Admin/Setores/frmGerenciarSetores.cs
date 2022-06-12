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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Setores
{
    public partial class frmGerenciarSetores : Form
    {
        public frmGerenciarSetores()
        {
            InitializeComponent();
        }

        private void frmGerenciarSetores_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            exibirSetoresEsquerda();
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

        


        //Setor
        String sSetorEscolhido;
        int iCodSetorEscolhido;

        //Visualizar setores       
        private void exibirSetoresEsquerda()
        {
          
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" SELECT Desc_Setor [Setor]" +
                                                 " FROM UNIDB.[dbo].SETOR " +
                                                 " ORDER BY Desc_Setor ASC", connectDMD);


                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Setor"] != null) //Sendo o leitor diferente de nulo
                            {
                                lsbSetor.Items.Add(reader["Setor"].ToString());
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
        //Visualizador direito a partir da troca do index da List box da esquerda
        private void lsbSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditar.Visible = true;
            lsbColaboradores.Items.Clear();
            txtEmailDoSetor.Clear();

        
                //Preenche e-mail
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" SELECT Email_Setor [Email]" +
                                                 " ,COD_SETOR" +
                                                 " FROM UNIDB.[dbo].SETOR " +
                                                 " WHERE Desc_Setor like '" + lsbSetor.SelectedItem.ToString() + "'" +
                                                 " ORDER BY Desc_Setor ASC", connectDMD);


                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Email"] != null) //Sendo o leitor diferente de nulo
                            {
                                txtEmailDoSetor.Text = reader["Email"].ToString();
                                iCodSetorEscolhido = Convert.ToInt32(reader["Cod_Setor"].ToString());
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
                //Preenche colaboradores
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" SELECT USU.Nome_Usuario [Nome]" +
                                                 " FROM UNIDB.[dbo].SETOR STR " +
                                                 " INNER JOIN UNIDB.[dbo].USUAR USU on USU.Cod_Setor = STR.Cod_Setor" +
                                                 " WHERE STR.Desc_Setor like '" + lsbSetor.SelectedItem.ToString() + "'" +
                                                 " ORDER BY STR.Desc_Setor ASC", connectDMD);


                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Nome"] != null) //Sendo o leitor diferente de nulo
                            {
                                lsbColaboradores.Items.Add(reader["Nome"].ToString());



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
                        sSetorEscolhido = lsbSetor.SelectedItem.ToString();
                        connectDMD.Close();
                        if (lsbColaboradores.Items.Count == 0)
                        {
                            lsbColaboradores.Items.Add("Nenhum colaborador cadastrado para este setor.");
                        }

                    
                }
            }
            
        }
        //Limpar itens
        private void limparItens()
        {
            lsbSetor.Items.Clear();
            txtEmailDoSetor.Clear();
            lsbColaboradores.Items.Clear();
        }
       
       


        //Botão inserir
      
        private void btnInserir_Click(object sender, EventArgs e)
        {            
            frmInserirSetor form = new frmInserirSetor();            
            form.ShowDialog();
            limparItens();
            exibirSetoresEsquerda();
        }

        //Botão editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            frmEditarSetor form = new frmEditarSetor();
            form.iCodSetor = iCodSetorEscolhido;            
            form.txtSetor.Text = sSetorEscolhido;
            form.txtEmailSetor.Text = txtEmailDoSetor.Text;
            this.Visible = false;
            form.ShowDialog();
            limparItens();
            exibirSetoresEsquerda();
            this.Visible = true;
            
        }

        private void frmGerenciarSetores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }




        //Botão fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
       

       

    }
}
