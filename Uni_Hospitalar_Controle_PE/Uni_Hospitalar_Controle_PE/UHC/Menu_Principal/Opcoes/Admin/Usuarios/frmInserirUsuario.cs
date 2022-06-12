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
    public partial class frmInserirUsuario : Form
    {
        public frmInserirUsuario()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlCommand command2 = new SqlCommand();
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

        String sCod_Setor;
        String sCod_Usuario;

        

        private void Configuracao_Inicial()
        {

            
                //Adiciona os setores
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

        //Criação do usuário
        private void Criar_Usuario()
        {
            //Nome do usuário
            if (txtNome.Text.Trim().Equals(String.Empty))
            {
                mMessage = "O nome do colaborador precisa ser informado!";
                mTittle = "Cadastro de usuário";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Information;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                txtNome.Focus();
                return;
            }

            //Email do usuário
            if (txtEmail.Text.Trim().Equals(String.Empty))
            {
                mMessage = "O e-mail de uso do colaborador precisa ser informado!";
                mTittle = "Cadastro de usuário";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Information;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                txtEmail.Focus();
                return;
            }

            //Computador do usuário
            if (txtComputador.Text.Trim().Equals(String.Empty))
            {
                mMessage = "O nome do computador precisa ser informado!";
                mTittle = "Cadastro de usuário";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Information;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                txtComputador.Focus();
                return;
            }

            //Login do usuário
            if (txtUsuario.Text.Trim().Equals(String.Empty))
            {
                mMessage = "O nome de usuário colaborador precisa ser informado!";
                mTittle = "Cadastro de usuário";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Information;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                txtUsuario.Focus();
                return;
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


          
                //Confere se o usuário já existe
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                try
                {
                    //Comando sql
                    command = new SqlCommand("SELECT [Acesso] = Senha_Usuario " +
                        "FROM UNIDB.[dbo].USUAR " +
                        "WHERE Login_Usuario = @USUARIO ", connectDMD);

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
                        this.Close();
                    }
                }

                //Cadastro de usuário
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {

                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = "INSERT INTO  UNIDB.[dbo].USUAR " +
                            "(Login_Usuario,Senha_Usuario,Cod_Setor,Nome_Usuario,PC_Usuario,Email_Usuario,flg_senha) " +
                            "VALUES (@Login_Usuario,PWDENCRYPT ( ''+@Senha_Usuario+'' ),@Cod_Setor,@Nome_Usuario,@PC_Usuario,@Email_Usuario,1)";

                        //Adiciona Login
                        SqlParameter parametroLogin_Usuario = new SqlParameter("@Login_Usuario", SqlDbType.VarChar, 15);
                        parametroLogin_Usuario.Value = txtUsuario.Text;
                        command.Parameters.Add(parametroLogin_Usuario);
                        //Parâmetro de Senha
                        SqlParameter parametroSenha_Usuario = new SqlParameter("@Senha_Usuario", SqlDbType.VarChar);
                        parametroSenha_Usuario.Value = "uni123";
                        command.Parameters.Add(parametroSenha_Usuario);
                        //Parâmetro código do setor
                        SqlParameter parametroCod_Setor = new SqlParameter("@Cod_Setor", SqlDbType.Int);
                        parametroCod_Setor.Value = sCod_Setor;
                        command.Parameters.Add(parametroCod_Setor);
                        //Parâmetro nome do usuário
                        SqlParameter parametroNome_Usuario = new SqlParameter("@Nome_Usuario", SqlDbType.VarChar, 100);
                        parametroNome_Usuario.Value = txtNome.Text;
                        command.Parameters.Add(parametroNome_Usuario);
                        //Parâmetro PC do usuário
                        SqlParameter parametroPC_Usuario = new SqlParameter("@PC_Usuario", SqlDbType.VarChar, 20);
                        parametroPC_Usuario.Value = txtComputador.Text;
                        command.Parameters.Add(parametroPC_Usuario);
                        //Parâmetro Email do usuário
                        SqlParameter parametroEmail_Usuario = new SqlParameter("@Email_Usuario", SqlDbType.VarChar, 140);
                        parametroEmail_Usuario.Value = txtEmail.Text;
                        command.Parameters.Add(parametroEmail_Usuario);

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
                        this.Close();
                    }



                }

                //Resgatando usuario            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {

                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT TOP 1 Cod_Usuario FROM UNIDB.[dbo].USUAR " +
                                              " ORDER BY COD_USUARIO DESC ";

                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Cod_Usuario"] != null)
                            {
                                sCod_Usuario = reader["Cod_Usuario"].ToString();
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
                        this.Close();
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
                            command.CommandText = "INSERT INTO  UNIDB.[dbo].ACESS " +
                                "(Cod_Usuario,Cod_Sessao,Cod_Rotina,Status_Acesso) " +
                                "VALUES (@Cod_Usuario,@Cod_Sessao,@Cod_Rotina,@Status_Acesso)";

                            //Parâmetro código do usuário
                            SqlParameter parametroCod_Usuario = new SqlParameter("@Cod_Usuario", SqlDbType.Int);
                            parametroCod_Usuario.Value = sCod_Usuario;
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
          
            mMessage = "Usuário cadastrado com sucesso.";
            mTittle = "Cadastro de usuário";
            mButton = MessageBoxButtons.OK;
            mIcon = MessageBoxIcon.Information;
            MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            this.Close();

        }
         

        //Load do form
        private void frmInserirUsuario_Load(object sender, EventArgs e)
        {
            Configuracao_Inicial();
        }

        List<String> lPermissao = new List<String>();
        List<String> lCod_Sessao = new List<String>();
        List<String> lCod_Rotina = new List<String>();

        private void Limpar_Permissoes()
        {
            lPermissao.Clear();
            lCod_Rotina.Clear();
            lCod_Rotina.Clear();
        }

        //Botão permissões
        private void lblPermissao_Click(object sender, EventArgs e)
        {

            //Nome do usuário
            if (txtNome.Text.Trim().Equals(String.Empty))
            {
                mMessage = "O nome do colaborador precisa ser informado!";
                mTittle = "Cadastro de usuário";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Information;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                txtNome.Focus();
                return;
            }

            //Login do usuário
            if (txtUsuario.Text.Trim().Equals(String.Empty))
            {
                mMessage = "O nome de usuário colaborador precisa ser informado!";
                mTittle = "Cadastro de usuário";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Information;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                txtUsuario.Focus();
                return;
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


            Limpar_Permissoes();            

            frmSelecionarPermissoes form = new frmSelecionarPermissoes();            
            form.lblNome.Text = txtNome.Text;
            form.lblLogin.Text = txtUsuario.Text;
            form.lblSetor.Text = cbxSetor.SelectedItem.ToString();
            form.ShowDialog();
            lblPermissao.ForeColor = Color.Gray;
            if (form.publCod_RotinaMaster.Count >0)
            {
                btnConfirmar.Visible = true;
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
        private void lblPermissao_Hover(object sender, EventArgs e)
        {
            lblPermissao.ForeColor = Color.Blue;
        }
        private void lblPermissao_Leave(object sender, EventArgs e)
        {
            lblPermissao.ForeColor = Color.Black;
        }


        //Botão para confirmar
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            
            Criar_Usuario();
        }

        private void frmInserirUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void btnInserirSetor_Click(object sender, EventArgs e)
        {
            frmGerenciarSetores form = new frmGerenciarSetores();            
            form.ShowDialog();
            cbxSetor.Items.Clear();
            frmInserirUsuario_Load(form, new EventArgs());
        }

        

        
    }
}
