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
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Fretes.Configurar_Percentual;


namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Fretes.Configuracoes_Fretes
{
    public partial class frmConfigurar_Percentual : Form
    {
        public frmConfigurar_Percentual()
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
        public int Unidade_Servidor;

        int flg_Edicao = 0;
        //Variáveis de TextBox
        private string mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private DialogResult mResult;

        //Load do form
        private void frmConfigurar_Percentual_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
        }


        //Mostra as informações cadastradas com base no campo Cod Transportadora
        private void mostrar_Parametros_Cadastrados()
        {            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = "  SELECT " +
                                              "  Cod_UF                          [Estado] " +
                                              " ,Percentual_Capital              [% Capital] " +
                                              " ,Percentual_Interior             [% Interior] " +
                                              " ,Valor_Minimo_Capital            [Vlr. Min. Capital (R$)] " +
                                              " ,Valor_Minimo_Interior           [Vlr. Min. Interior (R$)] " +
                                              " FROM [UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA] " +
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
                        command.CommandText = "SELECT count(distinct Cod_Transportadora) [Contador] FROM [UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA] WHERE Cod_Transportadora =" + Convert.ToInt32(txtCodTransportadora.Text);

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

        //Carrega layout padrão para cadastro
        private void carregar_Estados()
        {
            dgvDados.Columns.Add("Cod_UF","Estado");
            dgvDados.Columns.Add("Percentual_Capital","Percentual na capital");
            dgvDados.Columns.Add("Percentual_Interior", "Percentual no interior");            
            dgvDados.Columns.Add("Valor_Minimo_Capital","Valor mínimo para a Capital");
            dgvDados.Columns.Add("Valor_Minimo_Interior", "Valor mínimo para a Interior");

            dgvDados.Rows.Add("AC", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("AL", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("AP", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("AM", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("BA", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("CE", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("DF", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("ES", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("GO", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("MA", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("MT", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("MS", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("MG", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("PA", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("PB", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("PR", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("PE", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("PI", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("RJ", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("RN", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("RS", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("RO", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("RR", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("SC", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("SP", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("SE", "0,00", "0,00", "0,00", "0,00");
            dgvDados.Rows.Add("TO", "0,00", "0,00", "0,00", "0,00");

        }

        //Insere percentual para transportadora sem percentual cadastrado
        private void inserir_Percentuais()
        {            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        String comando = null;
                        for (int x = 0; x < dgvDados.Rows.Count; x++)
                        {
                            comando = comando +
                                             " INSERT INTO [UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA] "
                                           + " (Cod_Transportadora, Cod_UF, Percentual_Capital, Percentual_Interior, Valor_Minimo_Capital, Valor_Minimo_Interior) "
                                           + " VALUES "
                                           + " (" + txtCodTransportadora.Text + ",'" + dgvDados.Rows[x].Cells[0].Value.ToString() + "',"
                                           + dgvDados.Rows[x].Cells[1].Value.ToString().Replace(",", ".") + "," + dgvDados.Rows[x].Cells[2].Value.ToString().Replace(",", ".") + ","
                                           + dgvDados.Rows[x].Cells[3].Value.ToString().Replace(",", ".") + "," + dgvDados.Rows[x].Cells[4].Value.ToString().Replace(",", ".") + ")";

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
                            for (int x = 0; x < dgvDados.Rows.Count; x++)
                            {
                                comando = comando +
                                                 " UPDATE [UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA] "
                                               + " SET Percentual_Capital = " + dgvDados.Rows[x].Cells[1].Value.ToString().Replace(",", ".")
                                               + ",    Percentual_Interior =" + dgvDados.Rows[x].Cells[2].Value.ToString().Replace(",", ".")
                                               + ",    Valor_Minimo_Capital = " + dgvDados.Rows[x].Cells[3].Value.ToString().Replace(",", ".")
                                               + ",    Valor_Minimo_Interior = " + dgvDados.Rows[x].Cells[4].Value.ToString().Replace(",", ".")
                                               + "  WHERE Cod_Transportadora = " + txtCodTransportadora.Text + " and Cod_UF = '" + dgvDados.Rows[x].Cells[0].Value.ToString() + "'";

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
                            mMessage = "Parâmetros substituidos";
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


        //Invoca o form para selecionar transprotadora
        private void btnProcurarTransportadora_Click(object sender, EventArgs e)
        {
            //Apontado para o CI da aba logísitica
            frmCriarCi_EscolherTransportadora form = new frmCriarCi_EscolherTransportadora();            
            form.ShowDialog();
            if (form.cod_transportadora != 0)
                txtCodTransportadora.Text = Convert.ToString(form.cod_transportadora);
        }

        //Preenche o campo bloqueado da transportadora
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
                if (validar_Transportadora()==1)
                {
                    mMessage = "Já existem percentuais cadastrados para a transportadora, deseja editar?";
                    mTittle = "Cadastro já existente";
                    mButton = MessageBoxButtons.YesNo;
                    mIcon = MessageBoxIcon.Exclamation;
                    mResult = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    
                    if (mResult == DialogResult.Yes)
                    {
                        dgvDados.Columns.Clear();
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
                    if (!txtTransportadora.Text.Equals(String.Empty))
                    carregar_Estados();

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




        //Botão inserir
        private void btnInserir_Click(object sender, EventArgs e)
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



        //Cidades
        private void btnInserirCidade_Click(object sender, EventArgs e)
        {
            frmConfigurar_Perc_Cidade form = new frmConfigurar_Perc_Cidade();
            form.Unidade_Servidor = Unidade_Servidor;
            form.txtCodTransportadora.Text = txtCodTransportadora.Text;
            form.Show();
        }



        //Fechar form
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
        //Fechar com esc
        private void FrmConfigurar_Percentual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }


    }
}
