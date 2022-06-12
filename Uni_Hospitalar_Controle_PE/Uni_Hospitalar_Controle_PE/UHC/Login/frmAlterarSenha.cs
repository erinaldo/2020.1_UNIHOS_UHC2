using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Ulib;
namespace Uni_Hospitalar_Controle_PE.UHC.Login
{
    public partial class frmAlterarSenha : Form
    {
        public frmAlterarSenha()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand(); //Para comandos

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
        
        public String key;
       
        private void frmAlterarSenha_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
        }

        //Função de Update da Senha
        private void updateSenha()
        {            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = " UPDATE UNIDB.[dbo].USUAR " 
                                             +" SET Senha_Usuario = PWDENCRYPT ( ''+@SENHA+'' )" 
                                             +", flg_Senha = 0 WHERE Login_Usuario = '" + Usuario.userDesc + "'";

                        //Parâmetro de senha
                        SqlParameter parametroSenha = new SqlParameter("@SENHA", SqlDbType.VarChar);
                        parametroSenha.Value = txtConfirmarSenha.Text.Trim();
                        command.Parameters.Add(parametroSenha);

                        command.ExecuteNonQuery();

                        mMessage = "Usuário alterado com sucesso.";
                        mTittle = "Cadastro de usuário";
                        mButton = MessageBoxButtons.OK;
                        mIcon = MessageBoxIcon.Information;
                        MessageBox.Show(mMessage, mTittle, mButton, mIcon);
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtSenha.Text.Trim() == txtConfirmarSenha.Text.Trim())
            {
                updateSenha();
                frmLogin form = new frmLogin();
                key = txtConfirmarSenha.Text.Trim();
                form.Show();
            }
            else if (txtSenha.Text.Trim().Equals("uni123"))
            {
                mMessage = "A senha não pode ser padrão";
                mTittle = "Senha";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Exclamation;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            }
            else
            {
                mMessage = "Senhas não conferem";
                mTittle = "Senha";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Exclamation;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);

            }
        }
       
        //Botão para limpar o campo de confirmar senha
        private void btnLimparConfirmarSenha_Click(object sender, EventArgs e)
        {
            txtConfirmarSenha.Text = String.Empty;
        }
        //Botão para limpar o campo senha
        private void btnLimparSenha_Click(object sender, EventArgs e)
        {
            txtSenha.Text = String.Empty;
        }

        //Event key up do text
        private void btnConfirmar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirmar_Click(btnConfirmar, new EventArgs());
            }
        }
    }
}
