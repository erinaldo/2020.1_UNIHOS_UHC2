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
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Setores;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Usuarios
{
    public partial class frmEditarUsuario : Form
    {
        public frmEditarUsuario()
        {
            InitializeComponent();
        }
        //SQL
        private SqlCommand command = new SqlCommand();        
        private SqlDataReader reader;

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
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        DialogResult options;

        String sCod_Setor;
        List<String> lPermissao = new List<String>();
        List<String> lCod_Sessao = new List<String>();
        List<String> lCod_Rotina = new List<String>();
        public int pubsCod_Usuario;

        //public int Unidade_Servidor;

        private void Configuracao_Edicao()
        {
            
                //Adiciona os setores
                cbxSetor.Text = String.Empty;            
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
                                cbxSetor.Items.Add(reader["Setor"].ToString());
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
        private void Permissao_Edicao(Boolean somenteler,Boolean ativar)
        {
            txtNome.ReadOnly = somenteler;
            txtUsuario.ReadOnly = somenteler;
            txtEmail.ReadOnly = somenteler;
            txtComputador.ReadOnly = somenteler;
            cbxSetor.Enabled = ativar;
            btnExcluir.Visible = ativar;
            btnPermissoes.Visible = ativar;
            btnResetSenha.Visible = ativar;
            btnCancelar.Visible = ativar;
            btnInserirSetor.Visible = ativar;
        }
        private void Configuracao_Inicial()
        {            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" SELECT Login_Usuario" +
                                                 " ,Desc_Setor" +
                                                 " ,Nome_Usuario" +
                                                 " ,PC_Usuario" +
                                                 " ,Email_Usuario " +
                                                 " FROM UNIDB.dbo.USUAR " +
                                                 " INNER JOIN UNIDB.[dbo].SETOR ON SETOR.COD_SETOR = USUAR.COD_SETOR " +
                                                 " WHERE COD_USUARIO = " + pubsCod_Usuario, connectDMD);


                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Login_Usuario"] != null) //Sendo o leitor diferente de nulo
                            {
                                txtUsuario.Text = (reader["Login_Usuario"].ToString());
                                txtNome.Text = (reader["Nome_Usuario"].ToString());
                                txtComputador.Text = (reader["PC_Usuario"].ToString());
                                txtEmail.Text = (reader["Email_Usuario"].ToString());
                                cbxSetor.Text = (reader["Desc_Setor"].ToString());
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

        private void frmEditarUsuario_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            Permissao_Edicao(true,false);
            Configuracao_Inicial();
            lblCodigo.Text = pubsCod_Usuario.ToString();
            
        }


        

        //Botão para cancelar as operações
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnEditar.Text = "Editar";
            Permissao_Edicao(true, false);
            Configuracao_Inicial();
            
        }

        //Botão para excluiur o usuário
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            mMessage = "Tem certeza que deseja excluir o usuário?";
            mTittle = "Exclusão do usuário";
            mButton = MessageBoxButtons.YesNo;
            mIcon = MessageBoxIcon.Asterisk;
           options =  MessageBox.Show(mMessage, mTittle, mButton, mIcon);

            if (options == DialogResult.Yes)
            {
                
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            //Comando sql
                            command = new SqlCommand(" DELETE FROM UNIDB.[dbo].USUAR WHERE COD_USUARIO = " + pubsCod_Usuario +
                                " DELETE FROM UNIDB.[dbo].ACESS WHERE COD_USUARIO =" + pubsCod_Usuario
                                , connectDMD);


                            connectDMD.Open();
                            command.ExecuteNonQuery();
                            //Verifica se ocorrerá alteração de senha                   

                        }
                        catch (SqlException SQLe)
                        {
                            erro_DeAcesso(SQLe);
                        }
                        finally
                        {
                            connectDMD.Close();
                            this.Close();
                        }
                    
                }
                
            }
        }

        //Botão reset senha
        private void btnResetSenha_Click(object sender, EventArgs e)
        {


            mMessage = "Tem certeza que deseja alterar a senha do usuário para a padrão?";
            mTittle = "Senha do usuário";
            mButton = MessageBoxButtons.YesNo;
            mIcon = MessageBoxIcon.Asterisk;
            options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);

            if (options == DialogResult.Yes)
            {                
                    //Alterar senha
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {

                        try
                        {
                            connectDMD.Open();
                            command = connectDMD.CreateCommand();
                            command.CommandText = "UPDATE  UNIDB.[dbo].USUAR " +
                                "SET Senha_Usuario = PWDENCRYPT ( ''+@Senha_Usuario+'' ), flg_senha = 1 " +
                                "WHERE COD_USUARIO = " + pubsCod_Usuario;


                            //Parâmetro de Senha
                            SqlParameter parametroSenha_Usuario = new SqlParameter("@Senha_Usuario", SqlDbType.VarChar);
                            parametroSenha_Usuario.Value = "uni123";
                            command.Parameters.Add(parametroSenha_Usuario);

                            command.ExecuteNonQuery();
                        }

                        catch (SqlException SQLe)
                        {
                            erro_DeAcesso(SQLe);
                            return;

                        }
                        finally
                        {
                            mMessage = "Senha alterada com sucesso?";
                            mTittle = "Senha do usuário";
                            mButton = MessageBoxButtons.OK;
                            mIcon = MessageBoxIcon.Information;
                            options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                            connectDMD.Close();

                        }



                    }                
            }
        }

        //Acessa o form para editar as permissões
        private void btnPermissoes_Click(object sender, EventArgs e)
        {
            frmEditarPermissoes form = new frmEditarPermissoes();            
            form.lblNome.Text = txtNome.Text;
            form.lblLogin.Text = txtUsuario.Text;
            form.lblSetor.Text = cbxSetor.Text;            
            form.ShowDialog();
            if (form.publCod_RotinaMaster.Count > 0)
            {
               
                for (int x = 0; x < form.publPermissoes.Count; x++)
                {
                    if (form.publPermissoes[x] != "0")
                    {
                        lPermissao.Add(form.publPermissoes[x]);
                        lCod_Sessao.Add(form.publCod_SessaoMaster[x]);
                        lCod_Rotina.Add(form.publCod_RotinaMaster[x]);
                    }
                }
            }

        }



        //Botão para editar e confirmar edição

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (btnEditar.Text == "Editar")
            {
                btnEditar.Text = "Confirmar";
                String selecao = cbxSetor.Text;
                Permissao_Edicao(false, true);
                Configuracao_Edicao();
                cbxSetor.SelectedItem = selecao;
            }
            else
            {
                mMessage = "Tem certeza que deseja editar o registro?";
                mTittle = "Edição de usuário";
                mButton = MessageBoxButtons.YesNo;
                mIcon = MessageBoxIcon.Asterisk;
                options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);

                if (options == DialogResult.Yes)
                {
                  
                        //Confere se o usuário já existe
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                //Comando sql
                                command = new SqlCommand("SELECT [Acesso] = Senha_Usuario " +
                                    "FROM UNIDB.[dbo].USUAR " +
                                    "WHERE Login_Usuario = @USUARIO AND COD_USUARIO <> " + pubsCod_Usuario, connectDMD);

                                //Parâmetro de Usuário
                                SqlParameter parametroUsuario = new SqlParameter("@USUARIO", SqlDbType.VarChar, 15);
                                parametroUsuario.Value = txtUsuario.Text;
                                command.Parameters.Add(parametroUsuario);



                                connectDMD.Open();

                                SqlDataReader dr = command.ExecuteReader();

                                if (dr.HasRows)
                                {
                                    //usuario existe                        
                                    mMessage = "Usuário existente!";
                                    mTittle = "Cadastro de usuário";
                                    mButton = MessageBoxButtons.OK;
                                    mIcon = MessageBoxIcon.Exclamation;
                                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                                    txtUsuario.Focus();
                                    return;
                                }

                            }

                            catch (SqlException SQLe)
                            {
                                erro_DeAcesso(SQLe);
                                return;
                            }
                            finally
                            {
                                connectDMD.Close();
                            }
                        }

                        //Setor do usuário
                        if (cbxSetor.SelectedItem == null)
                        {
                            mMessage = "O setor do colaborador precisa ser informado!";
                            mTittle = "Cadastro de usuário";
                            mButton = MessageBoxButtons.OK;
                            mIcon = MessageBoxIcon.Information;
                            MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                            cbxSetor.Focus();
                            return;
                        }

                    //carregar cod do setor
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {

                        try
                        {
                            connectDMD.Open();
                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT COD_SETOR FROM UNIDB.[dbo].SETOR" +
                                                  " WHERE DESC_SETOR LIKE '" + cbxSetor.SelectedItem.ToString() + "'";

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["cod_setor"] != null)
                                {
                                    sCod_Setor = reader["Cod_Setor"].ToString();
                                }
                            }
                        }

                        catch (SqlException SQLe)
                        {
                            erro_DeAcesso(SQLe);
                            return;

                        }
                        finally
                        {
                            connectDMD.Close();

                        }
                    }

                        //Editar campos de cadastro
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                //Comando sql
                                command = new SqlCommand(" UPDATE UNIDB.[dbo].USUAR" +
                                                         " SET Login_Usuario = '" + txtUsuario.Text + "', Cod_Setor = '" + sCod_Setor + "',Nome_Usuario = '" + txtNome.Text + "', PC_Usuario = '" + txtComputador.Text + "', Email_Usuario = '" + txtEmail.Text + "' " +
                                                         " WHERE COD_USUARIO = " + pubsCod_Usuario, connectDMD);


                                connectDMD.Open();
                                command.ExecuteNonQuery();
                                //Verifica se ocorrerá alteração de senha                   

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


                        if (lCod_Sessao.Count > 0)
                        {
                            //Deletar registro de usuário
                            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                            {

                                try
                                {
                                    connectDMD.Open();
                                    command = connectDMD.CreateCommand();
                                    command.CommandText =

                                        "DELETE FROM UNIDB.[dbo].ACESS WHERE COD_USUARIO = " + pubsCod_Usuario;



                                    command.ExecuteNonQuery();
                                }

                                catch (SqlException SQLe)
                                {
                                    erro_DeAcesso(SQLe);
                                    return;

                                }
                                finally
                                {
                                    connectDMD.Close();

                                }
                            }
                            //Cadastro de permissão
                            for (int x = 0; x < lCod_Sessao.Count; x++)
                            {
                                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                                {

                                    try
                                    {
                                        connectDMD.Open();
                                        command = connectDMD.CreateCommand();
                                        command.CommandText =

                                            "INSERT INTO  UNIDB.[dbo].ACESS " +
                                            "(Cod_Usuario,Cod_Sessao,Cod_Rotina,Status_Acesso) " +
                                            "VALUES (@Cod_Usuario,@Cod_Sessao,@Cod_Rotina,@Status_Acesso)";

                                        //Parâmetro código do usuário
                                        SqlParameter parametroCod_Usuario = new SqlParameter("@Cod_Usuario", SqlDbType.Int);
                                        parametroCod_Usuario.Value = pubsCod_Usuario;
                                        command.Parameters.Add(parametroCod_Usuario);

                                        //Parâmetro código da sessão
                                        SqlParameter parametroCod_Sessao = new SqlParameter("@Cod_Sessao", SqlDbType.Int);
                                        parametroCod_Sessao.Value = lCod_Sessao[x];
                                        command.Parameters.Add(parametroCod_Sessao);

                                        //Parâmetro código da rotina
                                        SqlParameter parametroCod_Rotina = new SqlParameter("@Cod_Rotina", SqlDbType.Int);
                                        parametroCod_Rotina.Value = lCod_Rotina[x];
                                        command.Parameters.Add(parametroCod_Rotina);

                                        //Parâmetro permissão
                                        SqlParameter parametroPermissao = new SqlParameter("@Status_Acesso", SqlDbType.Int);
                                        parametroPermissao.Value = lPermissao[x];
                                        command.Parameters.Add(parametroPermissao);


                                        command.ExecuteNonQuery();
                                    }

                                    catch (SqlException SQLe)
                                    {
                                        erro_DeAcesso(SQLe);
                                        return;

                                    }
                                    finally
                                    {
                                        connectDMD.Close();

                                    }
                                }
                            }
                        }

                    }

                

                    this.Close();
                }
            
        }

        private void frmEditarUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        //Botão que encaminha para a tela de inserção dos setores
        private void btnInserirSetor_Click(object sender, EventArgs e)
        {
            frmGerenciarSetores form = new frmGerenciarSetores();            
            form.ShowDialog();
            cbxSetor.Items.Clear();
            Configuracao_Edicao();            
        }      
    }
}
