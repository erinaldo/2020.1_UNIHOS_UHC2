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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.CI.Conferencia
{
    public partial class frmAlterarStatusDaCi : Form
    {
        public frmAlterarStatusDaCi()
        {
            InitializeComponent();
        }

        private void frmAlterarStatusDaCi_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            lblCI.Text = "CI: " + Cod_CI;
            configuracoesIniciais();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlCommand command2 = new SqlCommand();
        private SqlDataReader reader;
        
        //Erro sql
        private void erroSQLE(SqlException SQLe)
        {
            mMessage = "Erro de acesso ao servidor: " + SQLe.Message;
            mTittle = "SQL Server error";
            mButton = MessageBoxButtons.OK;
            mIcon = MessageBoxIcon.Error;
            MessageBox.Show(mMessage, mTittle, mButton, mIcon);
        }
        
        public int Cod_CI;        
        Char cStatusCI;
        int iCodEncaminhamento;
    
        //Variáveis de TextBox
        private String mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
        DialogResult options;



#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave

        private void configuracoesIniciais()
        {
            
                //status
                cbxStatus.Items.Add("Aguardando financeiro");
                cbxStatus.Items.Add("Concluído");
                cbxStatus.Items.Add("Pendente");

                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {

                    try
                    {
                        connectDMD.Open();
                        command2 = connectDMD.CreateCommand();

                        command2.CommandText = "SELECT DESC_ENCAMINHAMENTO FROM UNIDB.[dbo].ENCAN";


                        reader = command2.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["desc_encaminhamento"] != null)
                            {
                                cbxEncaminhamento.Items.Add(reader["desc_encaminhamento"].ToString());

                            }
                        }



                    }

                    catch (SqlException SQLe)
                    {
                        erroSQLE(SQLe);
                        return;
                    }
                    finally
                    {
                        connectDMD.Close();



                    }

                }
            
         
        }
        private void conclusaoDaCi()
        {           
                if (cbxEncaminhamento.SelectedItem == null && !cbxStatus.SelectedItem.ToString().Equals("Pendente"))
                {
                    mMessage = "O encaminhamento precisa ser preenchido";
                    mTittle = "CI";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Exclamation;
                    options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    return;
                }

                if (cbxStatus.SelectedItem == null)
                {
                    mMessage = "O status precisa ser preenchido";
                    mTittle = "CI";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Exclamation;
                    options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    return;
                }

                if (txtObservacao.Text.Trim().Equals(String.Empty))
                {
                    mMessage = "A observação precisa ser preenchida";
                    mTittle = "CI";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Exclamation;
                    options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    return;
                }

                if (cbxEncaminhamento.SelectedItem != null)
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {

                        try
                        {
                            connectDMD.Open();
                            command2 = connectDMD.CreateCommand();

                            command2.CommandText = "SELECT Cod_Encaminhamento FROM UNIDB.[dbo].ENCAN" +
                                                   " WHERE DESC_ENCAMINHAMENTO LIKE '" + cbxEncaminhamento.SelectedItem.ToString() + "'";


                            reader = command2.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["Cod_Encaminhamento"] != null)
                                {
                                    iCodEncaminhamento = Convert.ToInt32(reader["Cod_Encaminhamento"].ToString());

                                }
                            }



                        }

                        catch (SqlException SQLe)
                        {
                            erroSQLE(SQLe);
                            return;
                        }
                        finally
                        {
                            connectDMD.Close();

                        }

                    }
                    mMessage = "Status alterado para " + cbxStatus.SelectedItem.ToString() + " com o encaminhamento " + cbxEncaminhamento.SelectedItem.ToString() + ", deseja continuar?";
                    mTittle = "CI";
                    mButton = MessageBoxButtons.YesNo;
                    mIcon = MessageBoxIcon.Information;
                    options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                }
                
                else
                {
                    mMessage = "Status alterado para Pendente, deseja continuar?";
                    mTittle = "CI";
                    mButton = MessageBoxButtons.YesNo;
                    mIcon = MessageBoxIcon.Information;
                    options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                }

                if (options == DialogResult.Yes)
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {

                        try
                        {
                            connectDMD.Open();
                            command2 = connectDMD.CreateCommand();

                            if (cbxEncaminhamento.SelectedItem == null)
                                iCodEncaminhamento = 0;

                            command2.CommandText = " UPDATE UNIDB.[dbo].CITOP set STATUS = @Status , Cod_Encaminhamento = @ENCAMINHAMENTO, Observacao_Fin = @Observacao , Usuario_Fin = @Usuario , Dat_Encaminhamento = GetDate()" +
                                                   " WHERE Num_CI = " + Cod_CI;

                            if (cbxStatus.SelectedItem.Equals("Pendente"))
                            {
                                cStatusCI = 'P';
                            }
                            else if (cbxStatus.SelectedItem.Equals("Concluído"))
                            {
                                cStatusCI = 'C';
                            }
                            else
                            {
                                cStatusCI = 'A';
                            }



                            //Status
                            SqlParameter pStatus = new SqlParameter("@Status", SqlDbType.Char);
                            pStatus.Value = cStatusCI;
                            command2.Parameters.Add(pStatus);

                            //Status
                            SqlParameter pEncaminhamento = new SqlParameter("@Encaminhamento", SqlDbType.Int);
                            pEncaminhamento.Value = iCodEncaminhamento;
                            command2.Parameters.Add(pEncaminhamento);

                            //Observação
                            SqlParameter pObservacao = new SqlParameter("@Observacao", SqlDbType.VarChar, 300);
                            pObservacao.Value = txtObservacao.Text;
                            command2.Parameters.Add(pObservacao);
                            //Usuário
                            SqlParameter pUsuario = new SqlParameter("@Usuario", SqlDbType.VarChar, 15);
                            pUsuario.Value = Usuario.userDesc;
                            command2.Parameters.Add(pUsuario);
                            command2.ExecuteNonQuery();



                        }

                        catch (SqlException SQLe)
                        {
                            erroSQLE(SQLe);
                            return;
                        }
                        finally
                        {
                            connectDMD.Close();



                            this.Close();
                        }

                    }
                    mMessage = "CI alterada!";
                    mTittle = "CI";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Information;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    this.Close();
                }                       
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAlterarStatusDaCi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        //Confirmar
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            conclusaoDaCi();           
        }     

    }
}
