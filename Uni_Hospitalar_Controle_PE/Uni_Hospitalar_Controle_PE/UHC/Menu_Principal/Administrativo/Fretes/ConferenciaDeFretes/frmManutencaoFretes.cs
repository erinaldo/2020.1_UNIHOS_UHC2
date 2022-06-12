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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Fretes.ConferenciaDeFretes
{
    public partial class frmManutencaoFretes : Form
    {
        public frmManutencaoFretes()
        {
            InitializeComponent();
        }
        
        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataAdapter adaptador;
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

        //Variáveis de TextBox
        private String mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        //private DialogResult options;


        private void gpbFiltros_Enter(object sender, EventArgs e)
        {

        }

        private void frmManutencaoFretes_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            configuracoes_Iniciais();
        }

        private void btnProcurarTransportadora_Click(object sender, EventArgs e)
        {
            frmCriarCi_EscolherTransportadora form = new frmCriarCi_EscolherTransportadora();            
            form.ShowDialog();
            if (form.cod_transportadora != 0)
                txtCodTransportadora.Text = Convert.ToString(form.cod_transportadora);
        }

        private void configuracoes_Iniciais()
        {
            gpbCalculadoraPercent.Enabled = false;            
        }

        //Filtro por transportadora
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
                            erroSQLE(SQLe);
                        }
                        finally
                        {
                            connectDMD.Close();
                        }


                    }             
            }
            if (!txtTransportadora.Text.Equals(String.Empty))
            btnPesquisar_Click(btnPesquisar, new EventArgs());
        }

        //Função para digitar somente números
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8))
            {
                e.Handled = true;
            }
        }

        private void chkCalculadora_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCalculadora.Checked)
            {
                gpbCalculadoraPercent.Enabled = true;
                txtPercentCalc.Text = "0";
            }
            else
            {
                gpbCalculadoraPercent.Enabled = false;
            }
        }




        private void filtrar_Dados()
        {
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {

                String filtro_NF = null;
                String filtro_CTE = null;
                String filtro_Transportadora = null;
                txtEditarCTE.Text = string.Empty;                
                txtEditarObservacao.Text = string.Empty;
                txtEditarValorUni.Text = string.Empty;

                if (!txtTransportadora.Text.Equals(String.Empty))
                {
                    filtro_Transportadora = " AND CONF.COD_TRANSPORTADORA = " + txtCodTransportadora.Text;
                }

                if (!txtNota.Text.Equals(String.Empty))
                {
                    filtro_NF = " AND CONF.Num_Nota like ('%" + txtNota.Text + "%')";
                }

              
                if(!txtCTE.Text.Equals(String.Empty))
                {
                    filtro_CTE = " AND CONF.Num_CTR LIKE ('%"+txtCTE.Text+"%') ";
                }



                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText =
                      " SELECT                                                                                                                                               "       
                     +"  CONF.Num_Nota[Num.Nota]                                                                                                                             "
                     +" ,CONF.Num_CTR[CTR]                                                                                                                                   "
                     +" ,[Cidade] =                                                                                                                                          "
                     +" CASE NSCB.Cidade                                                                                                                                     "
                     +" WHEN NULL THEN NECB.Cidade                                                                                                                           "
                     +" ELSE NSCB.Cidade                                                                                                                                     "
                     +" END                                                                                                                                                  "
                     +" ,[Estado] =                                                                                                                                          "
                     +" CASE NSCB.Estado                                                                                                                                     "
                     +" WHEN NULL THEN NECB.Cod_UfOrigem                                                                                                                     "
                     +" ELSE NSCB.Estado                                                                                                                                     "
                     +" END                                                                                                                                                  "
                     +" ,[Num CI] = (SELECT TOP 1 Num_CI FROM[UNIDB].dbo.[CITOP] CI WHERE CI.NF_origem LIKE('%' + CAST(CONF.Num_Nota AS varchar) + '%'))                     "
                     +" ,[NF Devolução] = (SELECT TOP 1 CI_BOT.NF_Devolucao FROM[UNIDB].dbo.[CITOP] CI JOIN[UNIDB].dbo.[CIBOT] CI_BOT ON CI_BOT.Num_CI = CI.Num_CI           "
                     +"                                                                                                                                                      "
                     +"                    WHERE CI.NF_origem LIKE('%' + CAST(CONF.Num_Nota AS varchar) + '%'))                                                              "
                     +" ,[Obs. CI] = (SELECT TOP 1 CI.Observacao FROM[UNIDB].dbo.[CITOP] CI                                                                             "
                     +"                  WHERE CI.NF_origem LIKE('%' + CAST(CONF.Num_Nota AS varchar) + '%'))                                                                "
                     +" ,CONF.Vlr_Frete_Calculado[Vlr.Uni]                                                                                                                   "
                     +" ,NSCB.Vlr_TotalNota[Vlr.NF]                                                                                                                          "
                     +" ,CONF.Vlr_Frete_Real[Vlr.Transp]                                                                                                                     "
                     +" ,CONF.Vlr_Frete_Calculado - Vlr_Frete_Real[Equivalência]                                                                                             "
                     +" FROM[UNIDB].dbo.[CONFERENCIA_FRETES] CONF                                                                                                            "
                     +" LEFT JOIN[DMD].dbo.[NFSCB]                NSCB ON NSCB.Num_Nota = CONF.Num_Nota                                                                      "
                     +" LEFT JOIN[DMD].dbo.[NFECB]                NECB ON NECB.Numero = CONF.Num_Nota AND NECB.Tip_NF = 'D'                                                  "
                     +" JOIN[DMD].dbo.[TRANS]                TRSP ON TRSP.Codigo = CONF.Cod_Transportadora                                                                   "
                     +" WHERE                                                                                                                                                "
                     +" 1 = 1                                                                                                                                                "
                     +filtro_CTE
					 +filtro_NF
					 +filtro_Transportadora
                                                                                                                                                                



                     ;






                    adaptador = new SqlDataAdapter(command);
                    System.Data.DataTable tableDados = new System.Data.DataTable();
                    adaptador.Fill(tableDados);
                    dgvDados.DataSource = tableDados;

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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            filtrar_Dados();
            this.Cursor = Cursors.Default;
        }

        private void txtNota_TextChanged(object sender, EventArgs e)
        {
            btnPesquisar_Click(btnPesquisar, new EventArgs());
        }

        private void txtCTE_TextChanged(object sender, EventArgs e)
        {
            btnPesquisar_Click(btnPesquisar, new EventArgs());
        }

        private void frmManutencaoFretes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

      

        private void txtPercentCalc_TextChanged(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null && !txtPercentCalc.Text.Equals(String.Empty))
            {
                if (!txtPercentCalc.Text[txtPercentCalc.Text.Length - 1].Equals("."))
                {                    
                    txtResultado.Text = (Convert.ToDouble(dgvDados.CurrentRow.Cells[6].Value.ToString()) * (Convert.ToDouble(txtPercentCalc.Text) / 100)).ToString("C");
                }
            }
        }

        private void dgvDados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDados.Rows.Count > 0)
            {
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText =   " SELECT Vlr_Frete_Real                "
                                              + " ,Observacao                          "
                                              + " ,Num_CTR                             "
                                              + " FROM[UNIDB].dbo.[Conferencia_Fretes] "
                                              + " WHERE Num_Nota = " + dgvDados.CurrentRow.Cells[0].Value.ToString()
                        ;

                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Vlr_Frete_Real"] != null)
                            {                                
                                txtEditarCTE.Text = reader["Num_CTR"].ToString();
                                txtEditarObservacao.Text = reader["Observacao"].ToString();
                                txtEditarValorUni.Text = reader["Vlr_Frete_Real"].ToString();
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
            txtPercentCalc_TextChanged(dgvDados, new EventArgs());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            atualizar_ConfFretes(Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString()));
        }


        private void atualizar_ConfFretes(int num_nota)
        {
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {                                           
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText =
                                          " UPDATE[UNIDB].dbo.[Conferencia_Fretes] "
                                          + " SET Num_CTR = " + txtEditarCTE.Text
                                          + "    , Vlr_Frete_Real = " + txtEditarValorUni.Text.Replace(",",".")
                                          + "    , Observacao = '" + txtEditarObservacao.Text+"'"
                                          + " WHERE Num_Nota = " + num_nota;

                    command.ExecuteNonQuery();
                                                                                

                }
                catch (SqlException SQLe)
                {
                    erroSQLE(SQLe);
                }
                finally
                {
                    connectDMD.Close();
                    mMessage = "Atualizado com sucesso!";
                    mTittle = "NF "+num_nota;
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Information;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    filtrar_Dados();

                }


            }
        }

        private void txtCTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            btnPesquisar_Click(btnPesquisar, new EventArgs());
        }

        private void txtNota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnPesquisar_Click(btnPesquisar, new EventArgs());
        }


        //Função para digitar somente números decimais
        private void txt_DigitarNumerosDecimais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }


    }
}
