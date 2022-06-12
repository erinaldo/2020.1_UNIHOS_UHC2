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
    public partial class frmInserirSetor : Form
    {
        public frmInserirSetor()
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
        

        //Inserir setor
        public void inserirSetor()
        {
            if (txtSetor.Text.Trim().Equals(String.Empty))
            {

                mMessage = "A descrição precisa estar preenchida!";
                mTittle = "Descrição do setor";
                mIcon = MessageBoxIcon.Exclamation;
                mButton = MessageBoxButtons.OK;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                return;
            }

            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {

                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = " INSERT INTO UNIDB.[dbo].SETOR " +
                                              " (Desc_Setor,Email_Setor) " +
                                              "VALUES (@Desc_Setor,@Email_Setor)";


                        //Adiciona login
                        SqlParameter pSetor = new SqlParameter("@Desc_Setor", SqlDbType.VarChar, 30);
                        pSetor.Value = txtSetor.Text;
                        command.Parameters.Add(pSetor);

                        //Parâmetro Movimenta_Devolucao
                        SqlParameter pEmailSetor = new SqlParameter("@Email_Setor", SqlDbType.VarChar, 50);
                        pEmailSetor.Value = txtEmailSetor.Text;
                        command.Parameters.Add(pEmailSetor);

                        command.ExecuteNonQuery();

                        mMessage = "Setor inserido com sucesso!";
                        mTittle = "Setor";
                        mIcon = MessageBoxIcon.Information;
                        mButton = MessageBoxButtons.OK;
                        MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                        this.Close();
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


        //Botão inserir
       

        private void frmInserirSetor_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
        }

        private void frmInserirSetor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            inserirSetor();
        }
    }
}
