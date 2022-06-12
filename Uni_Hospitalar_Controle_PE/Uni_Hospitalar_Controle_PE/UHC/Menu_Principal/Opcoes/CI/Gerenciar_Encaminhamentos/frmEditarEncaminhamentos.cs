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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI.Gerenciar_Encaminhamentos
{
    public partial class frmEditarEncaminhamentos : Form
    {
        public frmEditarEncaminhamentos()
        {
            InitializeComponent();
        }
        
        //SQL
        private SqlCommand command = new SqlCommand(); //Para comandos
        private SqlDataReader reader;


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
        DialogResult options;


        public String pubsCod_Encaminhamento;        

        //Configurações iniciais do form
        private void Configuracoes_Iniciais()
        {
            //Carrega informações iniciais do motivo
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();
                    command = connectDMD.CreateCommand();
                    command.CommandText = " SELECT Desc_Encaminhamento FROM UNIDB.[dbo].ENCAN " +
                                          " WHERE Cod_Encaminhamento = " + pubsCod_Encaminhamento;

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["Desc_Encaminhamento"] != null)
                        {
                            txtDescricaoEncaminhamento.Text = reader["Desc_Encaminhamento"].ToString();
                           
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
                    lblEditarEncaminhamento.Text = "Editar encaminhamento " + pubsCod_Encaminhamento;
                }
            }

        }

        //Configura se a edição está ativa ou não
        private void Configuracao_Edicao(Boolean permissao)
        {
            txtDescricaoEncaminhamento .Enabled = permissao;            
            btnCancelar.Visible = permissao;
            btnExcluir.Visible = permissao;
            Configuracoes_Iniciais();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnEditar.Text == "Editar")
            {
                btnEditar.Text = "Confirmar";
                
                Configuracao_Edicao(true);
            }
            else
            {
                mMessage = "Deseja realmente prosseguir com a edição?";
                mTittle = "Editar encaminhamento";
                mButton = MessageBoxButtons.YesNo;
                mIcon = MessageBoxIcon.Information;
                txtDescricaoEncaminhamento.Focus();
                options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                if (options == DialogResult.Yes)
                {
                    if (txtDescricaoEncaminhamento.Text.Trim().Equals(String.Empty))
                    {
                        mMessage = "A descrição precisa ser inserida";
                        mTittle = "Descrição do encaminhamento";
                        mButton = MessageBoxButtons.OK;
                        mIcon = MessageBoxIcon.Exclamation;
                        MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                        return;
                    }


                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();
                            command = connectDMD.CreateCommand();
                            command.CommandText = " UPDATE UNIDB.[dbo].ENCAN " +
                                                  " SET Desc_Encaminhamento ='" + txtDescricaoEncaminhamento.Text +
                                                  " WHERE COD_MOTIVO = " + pubsCod_Encaminhamento;

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Desc_Motivo"] != null)
                                {
                                    txtDescricaoEncaminhamento.Text = reader["Desc_Motivo"].ToString();                                   
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
                            connectDMD.Close();
                            mMessage = "Editado com sucesso!";
                            mTittle = "Editar Encaminhamento";
                            mButton = MessageBoxButtons.OK;
                            mIcon = MessageBoxIcon.Information;
                            MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                            btnEditar.Text = "Editar";
                            frmEditarEncaminhamentos_Load(btnEditar, new EventArgs());
                        }
                    }
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            mMessage = "Tem certeza que deseja excluir?";
            mTittle = "Excluir encaminhamento";
            mButton = MessageBoxButtons.YesNo;
            mIcon = MessageBoxIcon.Warning;
            options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            if (options == DialogResult.Yes)
            {
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = " DELETE FROM UNIDB.[dbo].MOTIV " +
                                              " WHERE COD_MOTIVO = " + pubsCod_Encaminhamento;

                        command.ExecuteNonQuery();




                    }

                    catch (SqlException SQLe)
                    {
                        erro_DeAcesso(SQLe);

                    }
                    finally
                    {
                        connectDMD.Close();
                        mMessage = "Excluido com sucesso!";
                        mTittle = "Excluir CI";
                        mButton = MessageBoxButtons.OK;
                        mIcon = MessageBoxIcon.Information;
                        MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                        this.Close();
                    }
                }
            }
        }

        private void frmEditarEncaminhamentos_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            Configuracoes_Iniciais();
            Configuracao_Edicao(false);
        }
    }
}
