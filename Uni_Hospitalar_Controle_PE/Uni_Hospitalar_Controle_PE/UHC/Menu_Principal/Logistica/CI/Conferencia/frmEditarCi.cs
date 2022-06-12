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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Conferencia
{
    public partial class frmEditarCi : Form
    {
        public frmEditarCi()
        {
            InitializeComponent();
        }
        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader,reader2;
        
        //Erro sql
        private void erroSQLE(SqlException SQLe)
        {
            mMessage = "Erro de acesso ao servidor: " + SQLe.Message;
            mTittle = "SQL Server error";
            mButton = MessageBoxButtons.OK;
            mIcon = MessageBoxIcon.Error;
            MessageBox.Show(mMessage, mTittle, mButton, mIcon);
        }

        //Instância
        public int pubiNum_Ci;
        String sCod_Motivo, sCod_Setor;
        int iCod_Setor;
        
        
        

        //Permissões
        private void Carregar_Bloqueios()
        {
            txtCodTransportadora.Enabled = false;
            btnPreencherTransportadora.Visible = false;
            btnExcluir.Enabled = false;
        }
        private void Carregar_Permissoes()
        {
   
                //Subindo permissões
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT Cod_Usuario,Cod_Sessao,Cod_Rotina,Status_Acesso " +
                                              " FROM  UNIDB.[dbo].ACESS " +
                                              " WHERE Cod_Usuario =" + Usuario.userId;
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Cod_Usuario"] != null)
                            {

                                if (reader["Cod_Rotina"].ToString() == "22" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    btnExcluir.Enabled = true;

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

        //Load do form
        private void frmEditarCi_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            Configuracoes_Iniciais();
            Carregar_Bloqueios();
            Carregar_Permissoes();

        }
        

        //Configurações iniciais
        private void Configuracoes_Iniciais()
        {
            lblEditarCI.Text = "Editar CI " + pubiNum_Ci;
            gpbTipoOperacao.Enabled = false;
            gpbRetornoFisico.Enabled = false;
            lsbNFdevol.Enabled = false;
            txtNFrefatura.ReadOnly = true;
            txtNForigem.ReadOnly = true;
            cbxMotivo.Enabled = false;
            txtCodCliente.ReadOnly = true;
                        
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
                        erroSQLE(SQLe);
                    }
                    finally
                    {
                        connectDMD.Close();
                    }
                }

                //Inserir motivos
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" SELECT Desc_Motivo [Motivo]" +
                                                 " FROM UNIDB.[dbo].MOTIV " +
                                                 " ORDER BY Desc_Motivo ASC", connectDMD);


                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Motivo"] != null) //Sendo o leitor diferente de nulo
                            {
                                cbxMotivo.Items.Add(reader["Motivo"].ToString());
                            }
                        }
                        reader.Close();

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

                //Carregando informações da CI
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = "  SELECT Tipo_Operacao " +
                                              " ,Cod_Motivo" +
                                              " ,Cod_Setor" +
                                              " ,Cod_Cliente" +
                                              " ,NF_Refatura" +
                                              " ,NF_Origem" +
                                              " ,Retorno_Fisico" +
                                              " ,Cod_Transportadora" +
                                              " ,Observacao" +
                                              " FROM UNIDB.dbo.CITOP" +
                                              " WHERE NUM_CI = " + pubiNum_Ci;

                        reader2 = command.ExecuteReader();

                        while (reader2.Read())
                        {
                            if (reader2["Tipo_Operacao"] != null)
                            {

                                //Observação
                                txtObservacao.Text = reader2["Observacao"].ToString();

                                //Tipo de operação
                                if (reader2["Tipo_Operacao"].ToString() == "P")
                                {
                                    rdbDevParcial.Checked = true;

                                }
                                else if (reader2["Tipo_Operacao"].ToString() == "T")
                                {
                                    rdbDevTotal.Checked = true;
                                }

                                //Retorno físico
                                if (reader2["Retorno_Fisico"].ToString() == "1")
                                {
                                    rdbSim.Checked = true;

                                }
                                else if (reader2["Retorno_Fisico"].ToString() == "0")
                                {
                                    rdbNao.Checked = true;
                                }

                                //Cliente
                                txtCodCliente.Text = reader2["Cod_Cliente"].ToString();

                                sCod_Motivo = reader2["Cod_Motivo"].ToString();
                                sCod_Setor = reader2["Cod_Setor"].ToString();

                                //Refatura
                                txtNFrefatura.Text = reader2["NF_Refatura"].ToString();

                                //Origem
                                txtNForigem.Text = reader2["NF_Origem"].ToString();

                                //Transp
                                txtCodTransportadora.Text = reader2["Cod_Transportadora"].ToString();




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

                //Motivo
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT DESC_MOTIVO FROM UNIDB.dbo.MOTIV WHERE COD_MOTIVO =" + sCod_Motivo;
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Desc_Motivo"] != null)
                            {
                                cbxMotivo.SelectedItem = reader["Desc_Motivo"].ToString();
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

                //Setor
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT DESC_SETOR FROM UNIDB.dbo.SETOR WHERE COD_SETOR =" + sCod_Setor;
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Desc_Setor"] != null)
                            {
                                cbxSetor.SelectedItem = reader["Desc_Setor"].ToString();
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

                //Adiciona os setores
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" SELECT Distinct  NF_Devolucao" +
                                                 " FROM UNIDB.[dbo].CIBOT " +
                                                 " WHERE Num_CI =" + pubiNum_Ci +
                                                 " ORDER BY NF_Devolucao DESC", connectDMD);


                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["NF_Devolucao"] != null) //Sendo o leitor diferente de nulo
                            {
                                lsbNFdevol.Items.Add(reader["NF_Devolucao"].ToString());

                            }
                        }
                        reader.Close();

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

        //Editar
        private void Confirmar_Edicao()
        {            
                //Setor
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = "SELECT Cod_Setor FROM UNIDB.[dbo].SETOR WHERE Desc_Setor like '" + cbxSetor.SelectedItem + "'";



                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Cod_Setor"] != null)
                            {
                                iCod_Setor = Convert.ToInt32(reader["Cod_Setor"].ToString());
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

                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = "UPDATE UNIDB.dbo.CITOP SET  OBSERVACAO = @OBSERVACAO, Cod_Transportadora = @Cod_Transportadora, @Usuario = @Usuario, Cod_Setor = @Cod_Setor WHERE Num_CI = " + pubiNum_Ci;

                        if (txtCodTransportadora.Text.Equals(String.Empty))
                        {
                            txtCodTransportadora.Text = 0.ToString();
                        }
                        if (txtNFrefatura.Text.Equals(String.Empty))
                        {
                            txtNFrefatura.Text = 0.ToString();
                        }

                        //Setor
                        SqlParameter pCod_Setor = new SqlParameter("@Cod_Setor", SqlDbType.Int);
                        pCod_Setor.Value = iCod_Setor;
                        command.Parameters.Add(pCod_Setor);

                        SqlParameter pCod_Transportadora = new SqlParameter("@Cod_Transportadora", SqlDbType.Int);
                        pCod_Transportadora.Value = Convert.ToInt16(txtCodTransportadora.Text.Trim());
                        command.Parameters.Add(pCod_Transportadora);

                        //Observacao
                        SqlParameter pObservacao = new SqlParameter("@Observacao", SqlDbType.VarChar, 300);
                        pObservacao.Value = txtObservacao.Text;
                        command.Parameters.Add(pObservacao);
                        //Usuario
                        SqlParameter pUsuario = new SqlParameter("@Usuario", SqlDbType.VarChar, 15);
                        pUsuario.Value = Usuario.userDesc;
                        command.Parameters.Add(pUsuario);

                        command.ExecuteNonQuery();




                    }
                    catch (SqlException SQLe)
                    {
                        erroSQLE(SQLe);
                    }
                    finally
                    {
                        connectDMD.Close();
                        mMessage = "Editado com sucesso";
                        mTittle = "Editar CI";
                        mButton = MessageBoxButtons.OK;
                        mIcon = MessageBoxIcon.Information;
                        MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    }


                }                        
        }

        //Variáveis de TextBox
        private String mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        DialogResult options;

        
      

        //Transportadora
        private void txtCodTransportadora_TextChanged(object sender, EventArgs e)
        {
            txtTransportadora.Clear();
            if (!txtCodTransportadora.Text.Trim().Equals(String.Empty))
            {                
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT razao_social FROM trans WHERE CODIGO = " + Convert.ToUInt32(txtCodTransportadora.Text);

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
                            erroSQLE(SQLe);
                        }
                        finally
                        {
                            connectDMD.Close();
                        }


                    }                            
            }
        }

        //Botão confirmar
        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            mMessage = "Deseja confirmar a edição?";
            mTittle = "Editar CI";
            mButton = MessageBoxButtons.YesNo;
            mIcon = MessageBoxIcon.Question;
            options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);

            if (options == DialogResult.Yes)
            {
                Confirmar_Edicao();
            }
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
                            command.CommandText = "SELECT razao_social FROM clien WHERE CODIGO = " + Convert.ToUInt32(txtCodCliente.Text);

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
                            erroSQLE(SQLe);
                        }
                        finally
                        {
                            connectDMD.Close();
                        }


                    }
              
        
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            mMessage = "Deseja excluir a CI?";
            mTittle = "Excluir CI";
            mButton = MessageBoxButtons.YesNo;
            mIcon = MessageBoxIcon.Question;
            options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);

            if (options == DialogResult.Yes)
            {             
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "delete from unidb.dbo.citop WHERE Num_CI = " + pubiNum_Ci +
                                                  "delete from unidb.dbo.cidev WHERE Num_CI = " + pubiNum_Ci +
                                                  "delete from unidb.dbo.cibot WHERE Num_CI = " + pubiNum_Ci +
                                                  "delete from unidb.dbo.cilog WHERE Num_CI = " + pubiNum_Ci;
                            command.ExecuteNonQuery();



                        }
                        catch (SqlException SQLe)
                        {
                            erroSQLE(SQLe);
                        }
                        finally
                        {
                            connectDMD.Close();
                            this.Close();
                        }


                    }             
            }
        }


        private void btnPreencherTransportadora_Click(object sender, EventArgs e)
        {
            frmCriarCi_EscolherTransportadora form = new frmCriarCi_EscolherTransportadora();           
            form.ShowDialog();
            if (form.cod_transportadora != 0)
                txtCodTransportadora.Text = Convert.ToString(form.cod_transportadora);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }





   
    }
}
