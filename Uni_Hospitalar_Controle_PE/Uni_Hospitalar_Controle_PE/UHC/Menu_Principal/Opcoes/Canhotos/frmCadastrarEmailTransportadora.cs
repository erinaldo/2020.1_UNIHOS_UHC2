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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Canhotos
{
    public partial class frmCadastrarEmailTransportadora : Form
    {
        public frmCadastrarEmailTransportadora()
        {
            InitializeComponent();
        }

        //Load do form
        private void frmCadastrarEmailTransportadora_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
        }

        public int Unidade_Servidor;

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
        //private SqlDataAdapter adaptador;

        //Erro sql
        private void erro_DeAcesso(SqlException SQLe)
        {
            mMessage = "Erro de acesso ao servidor: " + SQLe.Message;
            mTittle = "SQL Server error";
            mButton = MessageBoxButtons.OK;
            mIcon = MessageBoxIcon.Error;
            System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            return;
        }

        //Variáveis de TextBox
        private string mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private DialogResult mResult;


        //Seleciona transportadora
        private void txtCodTransportadora_TextChanged(object sender, EventArgs e)
        {
            txtTransportadora.Text = String.Empty;
            if (!txtCodTransportadora.Text.Trim().Equals(String.Empty))
            {                
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT razao_social FROM trans WHERE CODIGO = " + Convert.ToInt32(txtCodTransportadora.Text);

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["razao_social"] != null)
                                {
                                    txtTransportadora.Text = reader["razao_social"].ToString();
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
                        }


                    }

                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT Email_Transportadora FROM [UNIDB].dbo.[Email_Transportadora] WHERE Cod_Transportadora = " + Convert.ToInt32(txtCodTransportadora.Text);

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Email_Transportadora"] != null)
                                {
                                    lsbEmail.Items.Add(reader["Email_Transportadora"].ToString());
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
                        }


                    }
                
            }
        }

        private void btnProcurarTransportadora_Click(object sender, EventArgs e)
        {
            //Apontado para o CI da aba logísitica
            frmCriarCi_EscolherTransportadora form = new frmCriarCi_EscolherTransportadora();
            
            form.ShowDialog();
            if (form.cod_transportadora != 0)
                txtCodTransportadora.Text = Convert.ToString(form.cod_transportadora);
        }

        //Manipulação dos e-mails
        private void btnAdicionarEmail_Click(object sender, EventArgs e)
        {
            if (!txtEmail.Text.Trim().Equals(String.Empty))
            {

                lsbEmail.Items.Add(txtEmail.Text);
                txtEmail.Text = String.Empty;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnAdicionarEmail_Click(txtEmail, new EventArgs());
            }
        }

        private void lsbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                lsbEmail.Items.Remove(lsbEmail.SelectedItem);
            }
        }


        //Fecha o form
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCadastrarEmailTransportadora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }



        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            mMessage = "Deseja salvar as informações";
            mTittle = "Cadastrar informações";
            mIcon = MessageBoxIcon.Warning;
            mButton = MessageBoxButtons.YesNo;
            mResult = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            if (mResult == DialogResult.Yes)
            {

           
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "DELETE FROM [UNIDB].dbo.[EMAIL_TRANSPORTADORA] where Cod_Transportadora = " + Convert.ToInt32(txtCodTransportadora.Text);

                            command.ExecuteNonQuery();


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
                    
                    for (int x = 0; x < lsbEmail.Items.Count; x++)
                    {

                        if (!lsbEmail.Items[x].ToString().Equals(String.Empty))
                        {
                            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                            {
                                try
                                {
                                    connectDMD.Open();

                                    command = connectDMD.CreateCommand();
                                    command.CommandText = " INSERT INTO [UNIDB].dbo.[Email_Transportadora] " +
                                                          " (Cod_Transportadora, Email_Transportadora)" +
                                                          " VALUES " +
                                                          " (" + Convert.ToInt32(txtCodTransportadora.Text) + ",'" + lsbEmail.Items[x].ToString() + "')";

                                    command.ExecuteNonQuery();


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
                    this.Close();
                          

            }




        }

        private void txtCodTransportadora_KeyDown(object sender, KeyEventArgs e)
        {

            //Fechar com ESC
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

      
       
    }
}

