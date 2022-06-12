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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI.Gerenciar_Motivos
{
    public partial class frmEditarMotivo : Form
    {
        public frmEditarMotivo()
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



        public String pubsCod_Motivo;
        
        int iGera_Devolucao = 0;

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
                        command.CommandText = " SELECT Desc_Motivo,Gera_Devolucao FROM UNIDB.[dbo].MOTIV " +
                                              " WHERE COD_MOTIVO = " + pubsCod_Motivo;

                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Desc_Motivo"] != null)
                            {
                                txtDescricaoMotivo.Text = reader["Desc_Motivo"].ToString();
                                if (reader["Gera_Devolucao"].ToString().Equals("1"))
                                {
                                    chkMovimentaDevolucao.Checked = true;
                                    iGera_Devolucao = 1;
                                }
                                else if (reader["Gera_Devolucao"].ToString().Equals("0"))
                                {
                                    chkMovimentaDevolucao.Checked = false;
                                    iGera_Devolucao = 0;
                                }
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
                        lblEditarMotivo.Text = "Editar motivo " + pubsCod_Motivo;
                    }
                }
            
       

        }

        //Configura se a edição está ativa ou não
        private void Configuracao_Edicao(Boolean permissao)
        {
            txtDescricaoMotivo.Enabled = permissao;
            chkMovimentaDevolucao.Enabled = permissao;
            btnCancelar.Visible = permissao;
            btnExcluir.Visible = permissao;
            Configuracoes_Iniciais();
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnEditar.Text == "Editar")
            {
                btnEditar.Text = "Confirmar";
                btnCancelar.Visible = true;
                Configuracao_Edicao(true);
            }
            else
            {                
                mMessage = "Deseja realmente prosseguir com a edição?";
                mTittle = "Editar motivo";
                mButton = MessageBoxButtons.YesNo;
                mIcon = MessageBoxIcon.Information;
                txtDescricaoMotivo.Focus();
                options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                if (options == DialogResult.Yes)
                {
                    if (txtDescricaoMotivo.Text.Trim().Equals(String.Empty))
                    {
                        mMessage = "A descrição precisa ser inserida.";
                        mTittle = "Descrição do motivo";
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
                                command.CommandText = " UPDATE UNIDB.[dbo].MOTIV " +
                                                      " SET Desc_Motivo ='" + txtDescricaoMotivo.Text + "', Gera_Devolucao =" + iGera_Devolucao +
                                                      " WHERE COD_MOTIVO = " + pubsCod_Motivo;

                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Desc_Motivo"] != null)
                                    {
                                        txtDescricaoMotivo.Text = reader["Desc_Motivo"].ToString();
                                        if (reader["Gera_Devolucao"].ToString().Equals("1"))
                                        {
                                            chkMovimentaDevolucao.Checked = true;
                                        }
                                        else if (reader["Gera_Devolucao"].ToString().Equals("0"))
                                        {
                                            chkMovimentaDevolucao.Checked = false;
                                        }
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
                                mTittle = "Editar motivo";
                                mButton = MessageBoxButtons.OK;
                                mIcon = MessageBoxIcon.Information;
                                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                                btnEditar.Text = "Editar";
                                frmEditarMotivo_Load(btnEditar, new EventArgs());
                            }
                        }
                    
                    
                }
            }
        }

        //Botão para cancelar edição
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEditar.Text = "Editar";
            btnCancelar.Visible = false;
            Configuracao_Edicao(false);
        }

        //Chk movimenta devolução
        private void chkMovimentaDevolucao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMovimentaDevolucao.Checked == true)
            {
                iGera_Devolucao = 1;
            }
            else
            {
                iGera_Devolucao = 0;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            mMessage = "Tem certeza que deseja excluir?";
            mTittle = "Excluir motivo";
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
                                                  " WHERE COD_MOTIVO = " + pubsCod_Motivo;

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


        //Load do form
        private void frmEditarMotivo_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            
            Configuracoes_Iniciais();
            Configuracao_Edicao(false);
        }
    }
}
