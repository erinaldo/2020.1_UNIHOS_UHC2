using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Fretes.Configurar_Percentual
{
    public partial class frmConfigurar_Perc_Cidade : Form
    {
        public frmConfigurar_Perc_Cidade()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
        private SqlDataAdapter adaptador;

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

        //Variável de conexão
        public int Unidade_Servidor;

        //Flag que habilita a edição
        int flg_Edicao = 0;

        //Variáveis de TextBox
        private string mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private DialogResult mResult;

        
        //Load do form
        private void frmConfigurar_Perc_Cidade_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
        }
        //Verifica se existe percentual cadastrado para a transportadora
        private int validar_Transportadora()
        {
            int validar = 0;
          
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = "SELECT count(distinct Cod_Transportadora) [Contador] FROM [UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA_CIDADE] WHERE Cod_Transportadora =" + Convert.ToInt32(txtCodTransportadora.Text);

                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Contador"] != null)
                            {
                                validar = Convert.ToInt16(reader["Contador"].ToString());
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
                      
            return validar;
        }

        //Mostra as informações cadastradas com base no campo Cod Transportadora
        private void mostrar_Parametros_Cadastrados()
        {
            dgvDados.Rows.Clear();
            dgvDados.Columns.Clear();

                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = "  SELECT " +
                                              "  Cod_UF                         [Estado] " +
                                              " ,Cidade                         [Cidade] " +
                                              " ,Percentual_Cidade              [% Cidade] " +
                                              " ,Valor_Minimo_Cidade            [Vlr. Min. Cidade (R$)] " +                                              
                                              " FROM [UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA_CIDADE] " +
                                              " WHERE Cod_Transportadora = " + txtCodTransportadora.Text;
                        adaptador = new SqlDataAdapter(command);
                        DataTable tableDados = new DataTable();
                        adaptador.Fill(tableDados);
                        dgvDados.DataSource = tableDados;
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

        private void carregar_Estrutura_Cidade()
        {
            dgvDados.Columns.Add("Cod_UF","Estado [UF]");
            dgvDados.Columns.Add("Cod_UF", "Cidade [Sem acento]");
            dgvDados.Columns.Add("Cod_UF", "Percentual [% 0,00]");
            dgvDados.Columns.Add("Cod_UF", "Vlr. Min. Cidade [0,00]");
            
        }

        private int validar_Cidade(DataGridViewRow Row)
        {
            int validade = 0;

                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        String comando =
                                     " SELECT "
                                    + " top 1 'Cidade existente' [Resultado] "                                    
                                    + " WHERE '" + Row.Cells[0].Value.ToString() + "'+ + ' ' + '" + Row.Cells[1].Value.ToString() + "' IN "
                                    + " (SELECT [UF_CIDADE] = ESTADO.Codigo +' '+CIDADE.DESC_MUNICIPIO  COLLATE Latin1_General_CI_AS "
                                    + " FROM [UNIDB].dbo.[EXPGN] CIDADE "
                                    + " INNER JOIN[DMD].dbo.[ESTAD] ESTADO ON ESTADO.Cod_Ibge = CIDADE.COD_ESTADO) ";
                       


                        command = connectDMD.CreateCommand();




                        command.CommandText = comando;

                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Resultado"].ToString() != null)
                            {
                                validade = 1;
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

                        if (validade == 0)
                        {
                            mMessage = "A cidade " + Row.Cells[1].Value.ToString() + " não existe para o estado " + Row.Cells[0].Value.ToString();
                            mTittle = "Cidade inválida";
                            mButton = MessageBoxButtons.OK;
                            mIcon = MessageBoxIcon.Exclamation;
                            MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                          
                        }
                        
                          
                    }                    

                }
            
            return validade;
        }

        private void inserir_Percentuais()
        {            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        String comando = null;
                        for (int x = 0; x < dgvDados.Rows.Count-1; x++)
                        {
                            if (!dgvDados.Rows[x].Cells[0].Value.ToString().Trim().Equals(String.Empty)) {
                                comando = comando +
                                                 " INSERT INTO [UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA_CIDADE] "
                                               + " (Cod_Transportadora, Cod_UF, Cidade, Percentual_Cidade, Valor_Minimo_Cidade) "
                                               + " VALUES "
                                               + " (" + txtCodTransportadora.Text + "," 
                                               + "'"+dgvDados.Rows[x].Cells[0].Value.ToString()+"','"+dgvDados.Rows[x].Cells[1].Value.ToString().Replace(",", ".") + "',"
                                               + dgvDados.Rows[x].Cells[2].Value.ToString().Replace(",", ".") + ","
                                               + dgvDados.Rows[x].Cells[3].Value.ToString().Replace(",", ".") + ")";
                            }
                        }



                        command = connectDMD.CreateCommand();




                        command.CommandText = comando;

                        command.ExecuteNonQuery();

                    }
                    catch (SqlException SQLe)
                    {
                        erro_DeAcesso(SQLe);
                    }
                    finally
                    {
                        connectDMD.Close();
                        mMessage = "Parâmetros cadastrados";
                        mTittle = "Parâmetros";
                        mButton = MessageBoxButtons.OK;
                        mIcon = MessageBoxIcon.Information;
                        MessageBox.Show(mMessage, mTittle, mButton, mIcon);

                    }


                }                        
        }


        //Edita/sobrepõe os percentuais antigos por novos
        private void sobrepor_Percentuais()
        {

            mMessage = "Os parâmetros serão substituídos, tem certeza que quer efetuar a substituição?";
            mTittle = "Parâmetros";
            mButton = MessageBoxButtons.YesNo;
            mIcon = MessageBoxIcon.Information;
            mResult = MessageBox.Show(mMessage, mTittle, mButton, mIcon);

            if (mResult == DialogResult.Yes)
            {                
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            String comando = null;
                            
                                    comando =
                                                     " DELETE FROM [UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA_CIDADE] "                                                   
                                                   + " WHERE Cod_Transportadora = "+ txtCodTransportadora.Text;
                              



                            command = connectDMD.CreateCommand();




                            command.CommandText = comando;

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
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            String comando = null;
                            for (int x = 0; x < dgvDados.Rows.Count - 1; x++)
                            {
                                if (!dgvDados.Rows[x].Cells[0].Value.ToString().Trim().Equals(String.Empty))
                                {
                                    comando = comando +
                                                     " INSERT INTO [UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA_CIDADE] "
                                                   + " (Cod_Transportadora, Cod_UF, Cidade, Percentual_Cidade, Valor_Minimo_Cidade) "
                                                   + " VALUES "
                                                   + " (" + txtCodTransportadora.Text + ","
                                                   + "'" + dgvDados.Rows[x].Cells[0].Value.ToString() + "','" + dgvDados.Rows[x].Cells[1].Value.ToString().Replace(",", ".") + "',"
                                                   + dgvDados.Rows[x].Cells[2].Value.ToString().Replace(",", ".") + ","
                                                   + dgvDados.Rows[x].Cells[3].Value.ToString().Replace(",", ".") + ")";
                                }
                            }



                            command = connectDMD.CreateCommand();




                            command.CommandText = comando;

                            command.ExecuteNonQuery();

                        }
                        catch (SqlException SQLe)
                        {
                            erro_DeAcesso(SQLe);
                        }
                        finally
                        {
                            connectDMD.Close();
                            mMessage = "Parâmetros cadastrados";
                            mTittle = "Parâmetros";
                            mButton = MessageBoxButtons.OK;
                            mIcon = MessageBoxIcon.Information;
                            MessageBox.Show(mMessage, mTittle, mButton, mIcon);

                        }


                    }
                             
            }
            else
            {
                return;
            }

        }


        
        private void txtCodTransportadora_TextChanged(object sender, EventArgs e)
        {
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
             
             

                //Verifica edição, se já existir um elemento no DB com as configurações a edição é feita
                if (validar_Transportadora() == 1)
                {
                    mMessage = "Já existem percentuais cadastrados para a transportadora, deseja editar?";
                    mTittle = "Cadastro já existente";
                    mButton = MessageBoxButtons.YesNo;
                    mIcon = MessageBoxIcon.Exclamation;
                    mResult = MessageBox.Show(mMessage, mTittle, mButton, mIcon);

                    if (mResult == DialogResult.Yes)
                    {
                        mostrar_Parametros_Cadastrados();
                        flg_Edicao = 1;
                    }
                    else
                    {
                        flg_Edicao = 0;
                        return;
                    }

                }
                else
                {
                    dgvDados.DataSource = null;
                    dgvDados.Columns.Clear();
                    dgvDados.Rows.Clear();
                    carregar_Estrutura_Cidade();

                }


            }
            else
            {
                txtTransportadora.Text = String.Empty;
                dgvDados.DataSource = null;
                dgvDados.Rows.Clear();
                dgvDados.Columns.Clear();
            }
        }


        //Botão cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            int validade = 0;
            for (int x = 0; x < dgvDados.Rows.Count - 1; x++)
            {

                if (validar_Cidade(dgvDados.Rows[x]) == 0)
                {
                    validade = 0;
                    break;
                }
                else
                    validade = 1;

            }

            if (validade == 0)
            {
                return;
            }
            else
            {
                if (!txtTransportadora.Text.Equals(String.Empty))
                {
                    if (flg_Edicao == 0)
                    {
                        inserir_Percentuais();
                        txtCodTransportadora.Text = String.Empty;
                    }
                    else
                    {
                        sobrepor_Percentuais();
                        flg_Edicao = 0;
                        txtCodTransportadora.Text = String.Empty;
                    }
                }
                else
                {
                    mMessage = "Selecione uma transportadora para a edição.";
                    mTittle = "Transportadora";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Exclamation;
                    mResult = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                }
            }
        }



        //Fechar o form
        private void frmConfigurar_Perc_Cidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }



    }
}