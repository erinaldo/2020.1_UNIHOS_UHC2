using System;
using System.Data.SqlClient;
using Ulib;
using System.Windows.Forms;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Precificacao
{
    public partial class frmContratosVendas : Form
    {
        public frmContratosVendas()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlCommand command_2 = new SqlCommand();
        private SqlDataReader reader;
        private SqlDataAdapter adaptador = new SqlDataAdapter();

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

        

        //Variável que define em qual conexão o programa se encontra 1 = PE 2 = CE 3 = SP
        




        private void dgvDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //Load do form
        private void frmContratosVendas_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            configuracoes_Iniciais();
        }


        private void configuracoes_Iniciais()
        {
            dgvDados.Columns.Add("Cod_Produto", "Cód. Produto");
            dgvDados.Columns.Add("Des_Produto", "Produto");
            dgvDados.Columns.Add("Prc_Contrato", "Prc. Contrato");
            dgvDados.Columns.Add("Fabricante", "Fabricante");
        }



        
        private void txtCodCliente_TextChanged(object sender, EventArgs e)
        {
           
                txtCliente.Clear();
                if (!txtCodCliente.Text.Trim().Equals(String.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT razao_social FROM clien WHERE CODIGO = " + Convert.ToInt32(txtCodCliente.Text);

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["razao_social"] != null)
                                {
                                    txtCliente.Text = reader["razao_social"].ToString();
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
                    if (!txtCliente.Text.Equals(String.Empty))
                    {
                        int condicaoExistencia = 0;
                        //Existe?
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText =  " SELECT TOP  1 Cod_Cliente                                 "
                                                      +" FROM[UNIDB].dbo.[Contrato_Precos_Televendas]              "
                                                      +" WHERE Cod_Cliente  = " + Convert.ToInt32(txtCodCliente.Text);

                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Cod_Cliente"] != null)
                                    {
                                        condicaoExistencia = 1;
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

                        if (condicaoExistencia == 1) {
                            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                            {
                                try
                                {
                                    connectDMD.Open();
                                    command = connectDMD.CreateCommand();
                                    command.CommandText = " SELECT                                                   "
                                                          +"      CONTR_TELE.Cod_Produto                             "
                                                          +"     ,PROD.Descricao                                     "
                                                          +"	 ,CONTR_TELE.Vlr_Item                                "
                                                          +"     ,FABR.Fantasia                                      "
                                                          +" FROM[UNIDB].dbo.[Contrato_Precos_Televendas] CONTR_TELE " 
                                                          + " JOIN[DMD].dbo.[PRODU] PROD ON PROD.Codigo = CONTR_TELE.Cod_Produto " 
                                                          + " JOIN[DMD].dbo.[FABRI] FABR ON FABR.Codigo = PROD.Cod_Fabricante "
                                                          + " WHERE CONTR_TELE.Cod_Cliente = "+txtCodCliente.Text;                                    
                                    reader = command.ExecuteReader();

                                    while (reader.Read())
                                    {
                                        if (reader["Cod_Produto"] != null)
                                        {
                                            dgvDados.Rows.Add(reader["Cod_Produto"].ToString(),reader["Descricao"].ToString(), reader["Vlr_Item"].ToString().Replace(".",","),reader["Fantasia"].ToString());
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
                    }
                }           
           
        }





        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mTittle = "Alerta!";
            mMessage = "Tem certeza que deseja sair?";
            mIcon = MessageBoxIcon.Warning;
            mButton = MessageBoxButtons.YesNo;
            DialogResult mResult = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            if (mResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvDados_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDados.Rows[e.RowIndex].Cells[0].Value != null)
            {
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = new SqlCommand(" SELECT PROD.Descricao,FABR.Fantasia FROM [DMD].dbo.[PRODU] PROD " +
                            " INNER JOIN [DMD].dbo.[FABRI] FABR ON FABR.CODIGO = PROD.COD_FABRICANTE " +
                            " WHERE PROD.CODIGO = "+ dgvDados.Rows[e.RowIndex].Cells[0].Value.ToString(), connectDMD);                        
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Descricao"] != null) //Sendo o leitor diferente de nulo
                            {
                                dgvDados.Rows[e.RowIndex].Cells[1].Value = reader["Descricao"].ToString();
                                dgvDados.Rows[e.RowIndex].Cells[3].Value = reader["Fantasia"].ToString();
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

            if (dgvDados.Rows[e.RowIndex].Cells[2].Value != null && !dgvDados.Rows[e.RowIndex].Cells[2].Value.ToString().Contains("R$"))
            {

                dgvDados.Rows[e.RowIndex].Cells[2].Value = Convert.ToDouble(dgvDados.Rows[e.RowIndex].Cells[2].Value).ToString("C");
            }
        }

        private void dgvDados_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }




        private void salvar_Dados_Contrato()
        {
            mTittle = "Continuar?";
            mMessage = "Salvar dados?";
            mIcon = MessageBoxIcon.Information;
            mButton = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(mMessage, mTittle, mButton, mIcon);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText =
                            " DELETE FROM [UNIDB].dbo.[Contrato_Precos_Televendas] "
                           + " WHERE Cod_Cliente = " + txtCodCliente.Text;

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
                for (int x = 0; x < dgvDados.Rows.Count - 1; x++)
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();
                            command = connectDMD.CreateCommand();
                            command.CommandText =
                                " INSERT INTO [UNIDB].dbo.[Contrato_Precos_Televendas] "
                                + " (Cod_Cliente, Cod_Produto, Vlr_Item, Usuario,Dat_Registro) "
                                + " VALUES "
                                + " (" + txtCodCliente.Text + "," + dgvDados.Rows[x].Cells[0].Value.ToString() + ","
                                + Convert.ToDouble(dgvDados.Rows[x].Cells[2].Value.ToString().Substring(2)).ToString().Replace(",", ".") + ", '" 
                                + Usuario.userDesc + "',Getdate()) ";

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
                this.Close();
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            salvar_Dados_Contrato();

        }

        private void btnPreencherCliente_Click(object sender, EventArgs e)
        {
            //Apontado para o CI da aba logísitica
            frmCriarCi_EscolherCliente form = new frmCriarCi_EscolherCliente();            
            form.ShowDialog();
            if (form.cod_cliente != 0)
                txtCodCliente.Text = Convert.ToString(form.cod_cliente);
        }
    }
}
