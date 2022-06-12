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
    public partial class frmEditarSetor : Form
    {
        public frmEditarSetor()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();


        //Erro sql
        private void erro_DeAcesso(SqlException SQLe)
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
        

        //Setor
        public int iCodSetor;        

        private void editarSetor(){

            if (txtSetor.Text.Trim().Equals(String.Empty))
            {
                mMessage = "A descrição do setor precisa ser digitada!";
                mTittle = "Setor";
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
                        command.CommandText = " UPDATE UNIDB.[dbo].SETOR " +
                                              " SET Desc_Setor = @Desc_Setor, Email_Setor = @Email_Setor" +
                                              " WHERE Cod_Setor = @Cod_Setor";


                        //Adiciona Descrição do setor
                        SqlParameter pSetor = new SqlParameter("@Desc_Setor", SqlDbType.VarChar, 30);
                        pSetor.Value = txtSetor.Text;
                        command.Parameters.Add(pSetor);

                        //Parâmetro Email do setor
                        SqlParameter pEmailSetor = new SqlParameter("@Email_Setor", SqlDbType.VarChar, 50);
                        pEmailSetor.Value = txtEmailSetor.Text;
                        command.Parameters.Add(pEmailSetor);

                        //Parâmetro Movimenta_Devolucao
                        SqlParameter pCodSetor = new SqlParameter("@Cod_Setor", SqlDbType.Int);
                        pCodSetor.Value = iCodSetor;
                        command.Parameters.Add(pCodSetor);

                        command.ExecuteNonQuery();

                        mMessage = "Setor alterado com sucesso!";
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

        //Load do form
        private void frmEditarSetor_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            
          
        }

        private void frmEditarSetor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }









        //Botão para confirmar
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            editarSetor();

        }
 
    }
}
