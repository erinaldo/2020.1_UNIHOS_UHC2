using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.A_pagar;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.CI;

using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Custo_Medio;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.GNRE.ControleDifal_FCP;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.GNRE.Exportar_GNRE;

using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Recebimento.Contas_a_receber;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Recebimento.Contas_Recebidas;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Recebimento.Recebimento_Publico;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro
{
    public partial class frmFinanceiro : Form
    {
        public frmFinanceiro()
        {
            InitializeComponent();
        }

        private void frmFinanceiro_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            Carregar_Bloqueios();
            Carregar_Permissoes();
        }

       

        //SQL
        private SqlCommand command = new SqlCommand(); //Para comandos     
        private SqlDataReader reader;
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

        
        private void Carregar_Bloqueios()
        {

            //Canhotos
            lblAusenciaDeCanhotos.Enabled = false;
            lblCanhotosRecebidos.Enabled = false;

            //CI
            lblConferenciaDeCI.Enabled = false;
            //lblCustoDaCi.Enabled = false;
            //Custo
            lblCustoMedio.Enabled = false;
            lblCustoDeSaida.Enabled = false;
            //Recebimento
            lblContasAreceber.Enabled = false;
            lblRecebimentoPublicoPrivado.Enabled = false;
            lblContasRecebidas.Enabled = false;

            //GNRE
            lblDifalFCP.Enabled = false;
            lblExportacaoGnre.Enabled = false;
            lblMonitorGNRE.Enabled = false;

            //A pagar
            lblContasApagar.Enabled = false;

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
                                //Permissão para usuário
                                if (reader["Cod_Rotina"].ToString() == "1" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblConferenciaDeCI.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "17" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblDifalFCP.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "18" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblMonitorGNRE.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "23" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblContasApagar.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "25" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    //lblCustoDaCi.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "26" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblExportacaoGnre.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "35" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblContasAreceber.Enabled = true;
                                    lblContasRecebidas.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "36" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblRecebimentoPublicoPrivado.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "40" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblCustoDeSaida.Enabled = true;
                                    lblCustoMedio.Enabled = true;
                                }


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


        //Custo

        //Botão custo médio
        private void lblCustoMedio_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblCustoMedio.ForeColor = Color.White;
            lblCustoMedio.BackColor = Color.Black;
            
        }
        private void lblCustoMedio_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblCustoMedio.ForeColor = Color.Black;
            lblCustoMedio.BackColor = Color.Transparent;
            
        }
        private void lblCustoMedio_Click(object sender, EventArgs e)
        {
            frmCusto_Medio form = new frmCusto_Medio();
            
            form.Show();
        }

        //Botão custo de saída
        private void lblCustoDeSaida_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblCustoDeSaida.ForeColor = Color.White;
            lblCustoDeSaida.BackColor = Color.Black;

        }
        private void lblCustoDeSaida_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblCustoDeSaida.ForeColor = Color.Black;
            lblCustoDeSaida.BackColor = Color.Transparent;
        }


        //Recebimento

        //Botão Contas à receber
        private void lblContasAreceber_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblContasAreceber.ForeColor = Color.White;
            lblContasAreceber.BackColor = Color.Black;

        }
        private void lblContasAreceber_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblContasAreceber.ForeColor = Color.Black;
            lblContasAreceber.BackColor = Color.Transparent;

        }

        //Botão Recebimento público
        private void lblRecebimentoPublico_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblRecebimentoPublicoPrivado.ForeColor = Color.White;
            lblRecebimentoPublicoPrivado.BackColor = Color.Black;

        }
        private void lblRecebimentoPublico_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblRecebimentoPublicoPrivado.ForeColor = Color.Black;
            lblRecebimentoPublicoPrivado.BackColor = Color.Transparent;

        }

        //Botão Contas Recebidas
        private void lblContasRecebidas_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblContasRecebidas.ForeColor = Color.White;
            lblContasRecebidas.BackColor = Color.Black;

        }
        private void lblContasRecebidas_MouseLeave(object sender, EventArgs e)
        {            this.Cursor = Cursors.Default;
            lblContasRecebidas.ForeColor = Color.Black;
            lblContasRecebidas.BackColor = Color.Transparent;
        }



        //GNRE

        //Botão Controle Difal - FCP
        private void lblDifalFCP_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Cursor = Cursors.WaitCursor;
            
            frmAnaliseGnre form = new frmAnaliseGnre();
            
            form.Show();
            this.Cursor = Cursors.Default;
        }
        private void lblDifalFCP_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblDifalFCP.ForeColor = Color.White;
            lblDifalFCP.BackColor = Color.Black;

        }
        private void lblDifalFCP_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblDifalFCP.ForeColor = Color.Black;
            lblDifalFCP.BackColor = Color.Transparent;
        }
        
        //Botão ExportarGNRE
        private void lblExportacaoGnre_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblExportacaoGnre.ForeColor = Color.White;
            lblExportacaoGnre.BackColor = Color.Black;

        }
        private void lblExportacaoGnre_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblExportacaoGnre.ForeColor = Color.Black;
            lblExportacaoGnre.BackColor = Color.Transparent;
            
        }

        //Monitor GNRE
        private void lblMonitorGNRE_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            
            
            this.Cursor = Cursors.Default;
        }
        private void lblMonitorGNRE_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblMonitorGNRE.ForeColor = Color.White;
            lblMonitorGNRE.BackColor = Color.Black;

        }
        private void lblMonitorGNRE_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblMonitorGNRE.ForeColor = Color.Black;
            lblMonitorGNRE.BackColor = Color.Transparent;
        }



        //Canhotos
        //Botão ausencia de canhotos por pagamento
        private void lblAusenciaDeCanhotos_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblAusenciaDeCanhotos.ForeColor = Color.White;
            lblAusenciaDeCanhotos.BackColor = Color.Black;
        }
        private void lblAusenciaDeCanhotos_MouseLeave(object sender, EventArgs e)
        {

            this.Cursor = Cursors.Default;
            lblAusenciaDeCanhotos.ForeColor = Color.Black;
            lblAusenciaDeCanhotos.BackColor = Color.Transparent;
        }
        //Botão canhotos recebidos
        private void lblCanhotosRecebidos_MouseHover(object sender, EventArgs e)
        {

            this.Cursor = Cursors.Hand;
            lblCanhotosRecebidos.ForeColor = Color.White;
            lblCanhotosRecebidos.BackColor = Color.Black;
        }
        private void lblCanhotosRecebidos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblCanhotosRecebidos.ForeColor = Color.Black;
            lblCanhotosRecebidos.BackColor = Color.Transparent;
        }

        //CI
        //Conferência de CI
        private void lblConferenciaDeCI_Click(object sender, EventArgs e)
        {
            
            this.Cursor = Cursors.WaitCursor;
            this.Hide();
            frmConferenciaDeCi form = new frmConferenciaDeCi();            
            form.Show();
            this.Cursor = Cursors.Default;
        }
        private void lblConferenciaDeCI_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblConferenciaDeCI.ForeColor = Color.White;
            lblConferenciaDeCI.BackColor = Color.Black;

        }
        private void lblConferenciaDeCI_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblConferenciaDeCI.ForeColor = Color.Black;
            lblConferenciaDeCI.BackColor = Color.Transparent;
        }


        //à pagar
        private void lblContasApagar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Hide();
            frmContasApagar form = new frmContasApagar();
            
            form.Show();
            this.Cursor = Cursors.Default;

        }
        private void lblContasApagar_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblContasApagar.ForeColor = Color.White;
            lblContasApagar.BackColor = Color.Black;

        }
        private void lblContasApagar_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblContasApagar.ForeColor = Color.Black;
            lblContasApagar.BackColor = Color.Transparent;
        }

        private void LblExportacaoGnre_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.Hide();
            frmExportar_GNRE form = new frmExportar_GNRE();
            
            form.Show();
            this.Cursor = Cursors.Default;
        }

        private void LblContasAreceber_Click(object sender, EventArgs e)
        {
            
            frmContasAreceber form = new frmContasAreceber();            
            form.Show();
            
        }



        private void abrir_ContasRec()
        {
            Application.Run(new frmContasRecebidas());            
        }
        
        private void LblContasRecebidas_Click(object sender, EventArgs e)
        {

            Thread tContasRec = new Thread(abrir_ContasRec);
            tContasRec.SetApartmentState(ApartmentState.STA);
            tContasRec.Start();

        }



        private void abrir_RecPublicoPrivado()
        {
            Application.Run(new frmRecebimentoPublicoPrivado());
        }

        private void LblRecebimentoPublicoPrivado_Click(object sender, EventArgs e)
        {
            Thread tRecPubPriv = new Thread(abrir_RecPublicoPrivado);
            tRecPubPriv.SetApartmentState(ApartmentState.STA);
            tRecPubPriv.Start();
        }



        private void abrir_CustoMedio()
        {
            Application.Run(new frmCalc_Custo_Med());
        }

        private void lblCustoDeSaida_Click(object sender, EventArgs e)
        {
            Thread tCusto = new Thread(abrir_CustoMedio);
            tCusto.SetApartmentState(ApartmentState.STA);
            tCusto.Start();            
        }


        //Fechar form
        private void frmFinanceiro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }


        //Botão fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {                     
            this.Close();            
        }      
    }
}
