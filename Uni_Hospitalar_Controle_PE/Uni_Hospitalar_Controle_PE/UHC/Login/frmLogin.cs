using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Ulib;
using System.Windows.Forms;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal;


namespace Uni_Hospitalar_Controle_PE.UHC.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
        SqlDataReader dr;

        
        //Erro sql
        private void erroSQLE(SqlException SQLe)
        {
            mMessage = "Erro de acesso ao servidor: " + SQLe.Message;
            mTittle = "SQL Server";
            mButton = MessageBoxButtons.OK;
            mIcon = MessageBoxIcon.Error;
            MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            
        }

        
        
        //Variáveis Text box
        private String mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private DialogResult mOptions;

        //Variáveis de controle
        private int flag_senha;
        private int controlEnter;

        

        //Carrega o form
        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Icon = Uni_Hospitalar_Controle_PE.Properties.Resources.Icon_Uni;                        
        }

        //Valida o login
        private void checaLogin()
        {
            if (rdbPE.Checked)
            {
                Usuario.unidade_Login = 1;
            } 
            else if (rdbCE.Checked)
            {
                Usuario.unidade_Login = 2;
            } 
            else if (rdbSP.Checked)
            {
                Usuario.unidade_Login = 3;
            }

            if (controlEnter != 1)
            {
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand("SELECT [Acesso] = Senha_Usuario" 
                                                +" ,flg_Senha " 
                                                +" FROM UNIDB.[dbo].USUAR " 
                                                +" WHERE Login_Usuario = @USUARIO " 
                                                +" AND PWDCOMPARE(CONVERT (varchar,@senha),Senha_Usuario) = 1", connectDMD);
                        //Parâmetro de Usuário
                        SqlParameter parametroUsuario = new SqlParameter("@USUARIO", SqlDbType.VarChar, 20);
                        parametroUsuario.Value = txtLogin.Text;
                        command.Parameters.Add(parametroUsuario);

                        //Parâmetro de login
                        SqlParameter parametroSenha = new SqlParameter("@SENHA", SqlDbType.VarChar);
                        parametroSenha.Value = txtSenha.Text;
                        command.Parameters.Add(parametroSenha);

                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Acesso"] != null) //Sendo o leitor diferente de nulo
                            {
                                if (reader["flg_Senha"].ToString().Equals("1"))
                                {
                                    flag_senha = 1;
                                }
                            }
                        }
                        reader.Close();

                        //Primeiro login, altera a senha
                        if (flag_senha == 1)
                        {
                            this.Visible = false;
                            frmAlterarSenha form = new frmAlterarSenha();
                            Usuario.userDesc = txtLogin.Text.Trim();                            
                            form.ShowDialog();
                            this.Visible = true;
                            flag_senha = 0;
                            txtSenha.Text = form.key;
                            txtSenha.Focus();
                            return;

                        }
                        //Login normal
                        else
                        {
                            dr = command.ExecuteReader();
                            //usuario existe
                            if (dr.HasRows)
                            {
                                mMessage = "Login efetuado com sucesso";
                                mTittle = "Login";
                                mButton = MessageBoxButtons.OK;
                                mIcon = MessageBoxIcon.Information;
                                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                                controlEnter = 1;
                                for (double opacity = 1.0; opacity <= 1.0; opacity -= 0.1)
                                {
                                    DateTime start = DateTime.Now;
                                    this.Opacity = opacity;


                                    while (DateTime.Now.Subtract(start).TotalMilliseconds <= 60.6)
                                    {
                                        Application.DoEvents();
                                    }

                                    if (this.Opacity == 0)
                                    {
                                        frmMenuPrincipal form = new frmMenuPrincipal();
                                        Usuario.userDesc = txtLogin.Text;                                        
                                        form.Show();
                                        this.Hide();
                                        break;


                                    }
                                }

                            }
                            //usuario nao existe
                            else
                            {
                                mMessage = "Login ou senha não conferem.";
                                mTittle = "Login";
                                mButton = MessageBoxButtons.RetryCancel;
                                mIcon = MessageBoxIcon.Exclamation;
                                mOptions = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                                if (mOptions == DialogResult.Retry)
                                {
                                    txtSenha.Focus();
                                    controlEnter = 1;
                                }
                                else
                                {
                                    Application.Exit();
                                }
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

        //Limpadores de texto (Esta função muda o cursor)
        private void btn_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        private void btn_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        //Fechar o form
        private void btnFechar_Click(object sender, EventArgs e)
        {            
            Application.Exit();
        }
   

        //Botão para entrada
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            checaLogin();
        }                
        

        //Botão para o suporte (O clique aciona diretamente o GLPI)    
        private void btnSuporte_Click(object sender, EventArgs e)
        {
            // Navigate to a URL.
            System.Diagnostics.Process.Start("http://10.5.1.20/glpi/");
        }

        //Controla se o TextBox de Senha foi alterado ou não
        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            controlEnter = 0;
        }

        //Botão para limpar a senha
        private void btnLimparSenha_Click(object sender, EventArgs e)
        {
            txtSenha.Text = String.Empty;
        }

        //Botão para limpar login
        private void btnLimparLogin_Click(object sender, EventArgs e)
        {
            txtLogin.Text = String.Empty;
        }

        //Controla se o TextBox de Login foi alterado ou não
        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            controlEnter = 0;
        }
  
        //Se o ambos os TextBox de login estiverem preenchidos, a validação de Login Ocorre
        private void txtLoginSenha_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && controlEnter != 1)
            {
                btnEntrar_Click(btnEntrar, new EventArgs());
            }
        }


    }
}
