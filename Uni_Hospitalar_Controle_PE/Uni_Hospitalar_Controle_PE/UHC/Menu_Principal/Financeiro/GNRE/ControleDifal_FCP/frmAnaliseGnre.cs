using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

using System.Windows.Forms;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;
using System.Drawing;
using System.Drawing.Imaging;
using Ulib;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.GNRE.ControleDifal_FCP
{
    public partial class frmAnaliseGnre : Form
    {
        public frmAnaliseGnre()
        {
            InitializeComponent();
        }
        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlCommand command2 = new SqlCommand();

        private SqlDataReader reader, reader2,reader3;

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

        //Load do form
        private void frmAnaliseGnre_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Icon_Uni;
            Configura_Dados_Iniciais();
            Configura_DgvDados();
            Filtrar_Dados();
            Grafico_Estado();
        }

        public int Unidade_Servidor;


        private List<string> lNum_Nota = new List<string>();
        private List<string> lVlrTotal_Nota = new List<string>();
        private List<string> lVlr_FCP = new List<string>();
        private List<string> lVlr_DIFAL = new List<string>();
        private List<string> lStatus = new List<string>();
        private List<DateTime> lDat_Emissao = new List<DateTime>();
        private List<string> lEstado = new List<string>();
        private List<string> lCliente = new List<string>();
        private List<string> lObservacao = new List<string>();
        private List<string> lDuplicatas = new List<string>();

        double dSoma_Difal;
        double dSoma_FCP;



        //Montagem do gráfico anual
        private double dgJan, dgFev, dgMar, dgAbr, dgMai, dgJun, dgJul, dgAgo, dgSet, dgOut, dgNov, dgDez;
        private double dfJan, dfFev, dfMar, dfAbr, dfMai, dfJun, dfJul, dfAgo, dfSet, dfOut, dfNov, dfDez;

        private void gMes_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        //Montagem piechart
        private Func<LiveCharts.ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

        //Montagem do Difal x Estado
        private double dAC, dAL, dAP, dAM, dBA, dCE, dDF, dES, dGO, dMA, dMT, dMS, dMG, dPA, dPB, dPR, dPE, dPI, dRJ, dRN, dRS, dRO, dRR, dSC, dSP, dSE, dTO;

        //Gráfico das UF's
        private void Grafico_Estado()
        {
            //Gráfico pizza de acordo com filtro
            LiveCharts.SeriesCollection piechartData = new LiveCharts.SeriesCollection();
            if (dRR != 0)
            {
                piechartData.Add(
               new PieSeries
               {
                   Title = "RR",
                   Values = new ChartValues<double> { Math.Round(dRR / 1000, 2) },
                   DataLabels = true,
                   LabelPoint = labelPoint,
               }
               );
            }
            if (dAL != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "AL",
                    Values = new ChartValues<double> { Math.Round(dAL / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,




                }
                );
            }
            if (dAP != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "AP",
                    Values = new ChartValues<double> { Math.Round(dAP / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,

                }
                );
            }
            if (dAM != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "AM",
                    Values = new ChartValues<double> { Math.Round(dAM / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,

                }
                 );
            }
            if (dSC != 0)
            {
                piechartData.Add(
               new PieSeries
               {

                   Title = "SC",
                   Values = new ChartValues<double> { Math.Round(dSC / 1000, 2) },
                   DataLabels = true,
                   LabelPoint = labelPoint,
               }
               );
            }
            if (dBA != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "BA",
                    Values = new ChartValues<double> { Math.Round(dBA / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,

                }
                );
            }
            if (dRS != 0)
            {
                piechartData.Add(
               new PieSeries
               {
                   Title = "RS",
                   Values = new ChartValues<double> { Math.Round(dRS / 1000, 2) },
                   DataLabels = true,
                   LabelPoint = labelPoint,
               }
               );
            }
            if (dRO != 0)
            {
                piechartData.Add(
               new PieSeries
               {
                   Title = "RO",
                   Values = new ChartValues<double> { Math.Round(dRO / 1000, 2) },
                   DataLabels = true,
                   LabelPoint = labelPoint,
                   LabelPosition = PieLabelPosition.OutsideSlice
               }
               );
            }
            if (dAC != 0)
            {

                piechartData.Add(
                new PieSeries
                {
                    Title = "AC",
                    Values = new ChartValues<double> { Math.Round(dAC / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    LabelPosition = PieLabelPosition.OutsideSlice




                }
                );
            }
            if (dCE != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "CE",
                    Values = new ChartValues<double> { Math.Round(dCE / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,

                }
                );
            }
            if (dTO != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "TO",
                    Values = new ChartValues<double> { Math.Round(dTO / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,

                }
               );

            }
            if (dDF != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "DF",
                    Values = new ChartValues<double> { Math.Round(dDF / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
                );
            }
            if (dES != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "ES",
                    Values = new ChartValues<double> { Math.Round(dES / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
                );
            }
            if (dGO != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "GO",
                    Values = new ChartValues<double> { Math.Round(dGO / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
             );
            }
            if (dMA != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "MA",
                    Values = new ChartValues<double> { Math.Round(dMA / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
                );
            }
            if (dMG != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "MG",
                    Values = new ChartValues<double> { Math.Round(dMG / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
                );
            }
            if (dMT != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "MT",
                    Values = new ChartValues<double> { Math.Round(dMT / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
                );
            }
            if (dMS != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "MS",
                    Values = new ChartValues<double> { Math.Round(dMS / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
                );
            }
            if (dPA != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "PA",
                    Values = new ChartValues<double> { Math.Round(dPA / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
                );
            }
            if (dPB != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "PB",
                    Values = new ChartValues<double> { Math.Round(dPB / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
                );
            }
            if (dPR != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "PR",
                    Values = new ChartValues<double> { Math.Round(dPR / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
                );
            }
            if (dPE != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "PE",
                    Values = new ChartValues<double> { Math.Round(dPE / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
                );
            }
            if (dPI != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "PI",
                    Values = new ChartValues<double> { Math.Round(dPI / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
                );
            }
            if (dRJ != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "RJ",
                    Values = new ChartValues<double> { Math.Round(dRJ / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
                );
            }
            if (dRN != 0)
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "RN",
                    Values = new ChartValues<double> { Math.Round(dRN / 1000, 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                }
                );
            }
            if (dSP != 0)
            {
                piechartData.Add(
               new PieSeries
               {
                   Title = "SP",
                   Values = new ChartValues<double> { Math.Round(dSP / 1000, 2) },
                   DataLabels = true,
                   LabelPoint = labelPoint,
               }
               );
            }
            if (dSE != 0)
            {
                piechartData.Add(
              new PieSeries
              {
                  Title = "SE",
                  Values = new ChartValues<double> { Math.Round(dSE / 1000, 2) },
                  DataLabels = true,
                  LabelPoint = labelPoint,

              }
              );
            }
            // Define os valores do gráfico pizza
            gEstados.Series = piechartData;
            // Muda a legenda para a direita
            gEstados.LegendLocation = LegendLocation.Right;

        }


        //Configuração do dgvDados
        private void Configura_DgvDados()
        {
            dgvDados.Columns.Clear();

            //Colunas do DGV
            dgvDados.Columns.Add("Num_Nota", "NF");
            dgvDados.Columns.Add("Desc_Cliente", "Cliente");
            dgvDados.Columns.Add("Dat_Emissao", "Dt. Emissão");
            dgvDados.Columns.Add("UF", "UF");
            dgvDados.Columns.Add("Status_Pagamento", "Status");
            dgvDados.Columns.Add("Vlr_Nota", "Vlr. NF");
            dgvDados.Columns.Add("Vlr_Difal", "Vlr. Difal");
            dgvDados.Columns.Add("Vlr_FCP", "Vlr. FCP");
            dgvDados.Columns.Add("Observacao", "Observação");
            //Tamanho das colunas do DGV
            dgvDados.Columns[0].Width = 50;
            dgvDados.Columns[1].Width = 250;
            dgvDados.Columns[2].Width = 80;
            dgvDados.Columns[3].Width = 30;
            dgvDados.Columns[4].Width = 80;
            dgvDados.Columns[5].Width = 90;
            dgvDados.Columns[6].Width = 90;
            dgvDados.Columns[7].Width = 200;


        }

        
        //Filtrar os dados
        private void Filtrar_Dados()
        {            
                dgvDados.Rows.Clear();
                lNum_Nota.Clear();
                lVlrTotal_Nota.Clear();
                lVlr_FCP.Clear();
                lVlr_DIFAL.Clear();
                lDat_Emissao.Clear();
                lEstado.Clear();
                lCliente.Clear();
                lStatus.Clear();
                dSoma_Difal = 0;
                dSoma_FCP = 0;
                gEstados.AxisX.Clear();
                gEstados.AxisY.Clear();

                dAC = 0;
                dAL = 0;
                dAP = 0;
                dAM = 0;
                dBA = 0;
                dCE = 0;
                dDF = 0;
                dES = 0;
                dGO = 0;
                dMA = 0;
                dMT = 0;
                dMS = 0;
                dMG = 0;
                dPA = 0;
                dPB = 0;
                dPR = 0;
                dPE = 0;
                dPI = 0;
                dRJ = 0;
                dRN = 0;
                dRS = 0;
                dRO = 0;
                dRR = 0;
                dSC = 0;
                dSP = 0;
                dSE = 0;
                dTO = 0;


                String comando = " SELECT GNRE.Num_Nota [NF] " +
                                                 " , NSCB.Vlr_TotalNota[Total] " +
                                                 " , NSCB.Vlr_IcmFcpUfDes[FCP] " +
                                                 " , Vlr_IcmIntUfDes[Difal] " +
                                                 " , CAST(NSCB.Dat_Emissao as date)[Dat_Emissao] " +
                                                 " , [Status] = ''" +
                                                 " , Estado[UF] " +
                                                 " , c.Razao_social [Cliente]" +
                                                 " , GNRE.Obs_GNRE [Observacao]" +
                                                 " FROM UNIDB.dbo.NSGNR GNRE " +
                                                 " INNER JOIN DMD.dbo.NFSCB NSCB ON NSCB.NUM_NOTA = GNRE.NUM_NOTA " +
                                                 " INNER JOIN DMD.dbo.CLIEN c on c.codigo = nscb.cod_cliente " +

                                                 " WHERE(Vlr_IcmFcpUfDes <> 0 or Vlr_IcmIntUfDes <> 0) AND GNRE.Dat_Emissao BETWEEN @Dat_Inicial AND @DAT_FINAL " +
                                                 " AND STATUS = 'F' " +
                                                 " ORDER BY GNRE.Num_Nota DESC";


                //Recebe os dados das notas
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(comando, connectDMD);

                        command.Parameters.AddWithValue("Dat_Inicial", Convert.ToDateTime(dtpDtInicial.Text.Trim()));
                        command.Parameters.AddWithValue("Dat_Final", Convert.ToDateTime(dtpDtFinal.Text.Trim()));

                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["NF"] != null) //Sendo o leitor diferente de nulo
                            {
                                lNum_Nota.Add(reader["NF"].ToString());
                                lVlrTotal_Nota.Add(reader["Total"].ToString());
                                lVlr_FCP.Add(reader["FCP"].ToString());
                                lVlr_DIFAL.Add(reader["DIFAL"].ToString());
                                lDat_Emissao.Add(Convert.ToDateTime(reader["Dat_Emissao"].ToString()));
                                lEstado.Add(reader["UF"].ToString());
                                lCliente.Add(reader["Cliente"].ToString());
                                lStatus.Add("");
                                lObservacao.Add(reader["Observacao"].ToString());
                                //Somatórios


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


                //Contato para saber qual a quantidade existente
                int cont, linea = 0;

                //Preenchendo o status
                for (int x = 0; x < lNum_Nota.Count; x++)
                {
                    cont = 0;
                    linea = 0;
                    for (int y = 0; y < lDuplicatas.Count; y++)
                    {
                        if (y > linea)
                        {
                            if (lDuplicatas[y].Contains(lNum_Nota[x]))
                            {
                                cont++;
                                linea = y;
                            }
                        }
                    }

                    if (lEstado[x].ToString() == "PI")
                    {
                        if (cont == 2)
                        {
                            lStatus[x] = ("Pago");
                        }
                        else if (cont == 1)
                        {
                            lStatus[x] = ("Pago parcialmente");
                        }
                        else if (cont == 0)
                        {
                            lStatus[x] = ("Não pago");
                        }
                    }
                    else
                    {
                        if (cont == 1)
                        {
                            lStatus[x] = ("Pago");
                        }
                        else if (cont == 0)
                        {
                            lStatus[x] = ("Não pago");
                        }
                    }

                }

                //Preenchendo o data grid view
                for (int x = 0; x < lNum_Nota.Count; x++)
                {
                    //Nota
                    if (!txtNota.Text.Trim().Equals(String.Empty))
                    {
                        if (lNum_Nota[x].ToString().Equals(txtNota.Text))
                        {
                            dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                            dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                            dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            return;
                        }
                    }

                    //Cliente
                    //Cliente e observação
                    else if (!txtCliente.Text.Trim().Equals(String.Empty) && !txtObservacao.Text.Trim().Equals(String.Empty))
                    {
                        //Filtro cliente e observação geral
                        if (chkPago.Checked == true && chkNaoPago.Checked == true)
                        {
                            if (lCliente[x].ToString().Equals(txtCliente.Text) && lObservacao.ToString().Contains(txtObservacao.Text))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }
                        }
                        //Filtro cliente e observação geral
                        else if (chkPago.Checked == false && chkNaoPago.Checked == false)
                        {
                            if (lCliente[x].ToString().Equals(txtCliente.Text) && lObservacao.ToString().Contains(txtObservacao.Text))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }

                        }
                        //Filtro cliente e observação pagos
                        else if (chkPago.Checked == true)
                        {
                            if (lCliente[x].ToString().Equals(txtCliente.Text) && lObservacao.ToString().Equals(txtObservacao.Text) && lStatus[x].ToString().Contains("Pago"))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }


                        }
                        //Filtro cliente e observação não pagos
                        else if (chkNaoPago.Checked == true)
                        {
                            if (lCliente[x].ToString().Equals(txtCliente.Text) && lObservacao.ToString().Contains(txtObservacao.Text) && (lStatus[x].ToString().Equals("Não pago") || lStatus[x].ToString().Equals("Pago parcialmente")))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }

                        }
                    }
                    //Cliente
                    else if (!txtCliente.Text.Trim().Equals(String.Empty))
                    {
                        //Filtro cliente e observação geral
                        if (chkPago.Checked == true && chkNaoPago.Checked == true)
                        {
                            if (lCliente[x].ToString().Equals(txtCliente.Text))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }
                        }
                        //Filtro cliente e observação geral
                        else if (chkPago.Checked == false && chkNaoPago.Checked == false)
                        {
                            if (lCliente[x].ToString().Equals(txtCliente.Text))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }
                        }
                        //Filtro cliente e observação pagos
                        else if (chkPago.Checked == true)
                        {
                            if (lCliente[x].ToString().Equals(txtCliente.Text) && lStatus[x].ToString().Equals("Pago"))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString()); dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }
                        }
                        //Filtro cliente e observação não pagos
                        else if (chkNaoPago.Checked == true)
                        {
                            if (lCliente[x].ToString().Equals(txtCliente.Text) && (lStatus[x].ToString().Equals("Não pago") || lStatus[x].ToString().Equals("Pago parcialmente")))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }

                        }
                    }

                    //Estado
                    //Estado e observação
                    else if (!txtUF.Text.Trim().Equals(String.Empty) && !txtObservacao.Text.Trim().Equals(String.Empty))
                    {
                        //Filtro estado e observação geral
                        if (chkPago.Checked == true && chkNaoPago.Checked == true)
                        {
                            if (lEstado[x].ToString().Equals(txtUF.Text.ToUpper()) && lObservacao.ToString().Contains(txtObservacao.Text))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                            }

                        }
                        //Filtro estado e observação geral
                        else if (chkPago.Checked == false && chkNaoPago.Checked == false)
                        {
                            if (lEstado[x].ToString().Equals(txtUF.Text.ToUpper()) && lObservacao.ToString().Contains(txtObservacao.Text))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }

                        }
                        //Filtro estado e observação pagos
                        else if (chkPago.Checked == true)
                        {
                            if (lEstado[x].ToString().Equals(txtUF.Text.ToUpper()) && lObservacao.ToString().Equals(txtObservacao.Text) && lStatus[x].ToString().Contains("Pago"))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }


                        }
                        //Filtro estado e observação não pagos
                        else if (chkNaoPago.Checked == true)
                        {
                            if (lEstado[x].ToString().Equals(txtUF.Text.ToUpper()) && lObservacao.ToString().Contains(txtObservacao.Text) && (lStatus[x].ToString().Equals("Não pago") || lStatus[x].ToString().Equals("Pago parcialmente")))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }

                        }
                    }
                    //Estado
                    else if (!txtUF.Text.Trim().Equals(String.Empty))
                    {
                        //Filtro cliente e observação geral
                        if (chkPago.Checked == true && chkNaoPago.Checked == true)
                        {
                            if (lEstado[x].ToString().Equals(txtUF.Text.ToUpper()))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }
                        }
                        //Filtro cliente e observação geral
                        else if (chkPago.Checked == false && chkNaoPago.Checked == false)
                        {
                            if (lEstado[x].ToString().Equals(txtUF.Text.ToUpper()))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }
                        }
                        //Filtro cliente e observação pagos
                        else if (chkPago.Checked == true)
                        {
                            if (lEstado[x].ToString().Equals(txtUF.Text.ToUpper()) && lStatus[x].ToString().Equals("Pago"))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }
                        }
                        //Filtro cliente e observação não pagos
                        else if (chkNaoPago.Checked == true)
                        {
                            if (lEstado[x].ToString().Equals(txtUF.Text.ToUpper()) && (lStatus[x].ToString().Equals("Não pago") || lStatus[x].ToString().Equals("Pago parcialmente")))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }

                        }
                    }
                    //Observação
                    else if (!txtObservacao.Text.Trim().Equals(String.Empty))
                    {
                        if (chkPago.Checked == true && chkNaoPago.Checked == true)
                        {
                            if ((lObservacao[x].ToString().ToUpper().Contains(txtObservacao.Text.ToUpper())))
                            {
                                dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                                dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                                dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                            }
                        }
                    }
                    //Filtro pago e não pago
                    else if (chkNaoPago.Checked == true && chkPago.Checked == true)
                    {
                        dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                        dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                        dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                    }
                    //Filtro cliente e observação pagos
                    else if (chkPago.Checked == true)
                    {
                        if (lStatus[x].ToString().Equals("Pago"))
                        {
                            dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                            dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                            dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                        }
                    }
                    //Filtro cliente e observação não pagos
                    else if (chkNaoPago.Checked == true)
                    {
                        if ((lStatus[x].ToString().Equals("Não pago") || lStatus[x].ToString().Equals("Pago parcialmente")))
                        {
                            dgvDados.Rows.Add(lNum_Nota[x].ToString(), lCliente[x].ToString(), lDat_Emissao[x].ToString(), lEstado[x].ToString(), lStatus[x].ToString(), Convert.ToDouble(lVlrTotal_Nota[x]).ToString("C"), Convert.ToDouble(lVlr_DIFAL[x]).ToString("C"), Convert.ToDouble(lVlr_FCP[x]).ToString("C"), lObservacao[x].ToString());
                            dSoma_Difal = dSoma_Difal + Convert.ToDouble(lVlr_DIFAL[x].ToString());
                            dSoma_FCP = dSoma_FCP + Convert.ToDouble(lVlr_FCP[x].ToString());
                        }

                    }

                    if (lStatus[x].ToString().Equals("Pago") || lStatus.ToString().Equals("Pago Parcialmente"))
                    {

                        //Alimenta Pizza Chart
                        if (lEstado[x].ToString().Equals("TO"))
                        {
                            dTO = dTO + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("RS"))
                        {
                            dRS = dRS + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("RO"))
                        {
                            dRO = dRO + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("RR"))
                        {
                            dRR = dRR + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("SC"))
                        {
                            dSC = dSC + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("MG"))
                        {
                            dMG = dMG + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("AC"))
                        {
                            dAC = dAC + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("AL"))
                        {
                            dAL = dAL + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("AP"))
                        {
                            dAP = dAP + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("AM"))
                        {
                            dAM = dAM + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("BA"))
                        {
                            dBA = dBA + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("CE"))
                        {
                            dCE = dCE + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("DF"))
                        {
                            dDF = dDF + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("ES"))
                        {
                            dES = dES + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("GO"))
                        {
                            dGO = dGO + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("MA"))
                        {
                            dMA = dMA + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("MT"))
                        {
                            dMT = dMT + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("MS"))
                        {
                            dMS = dMS + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("PA"))
                        {
                            dPA = dPA + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("PB"))
                        {
                            dPB = dPB + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("PR"))
                        {
                            dPR = dPR + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("PE"))
                        {
                            dPE = dPE + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("PI"))
                        {
                            dPI = dPI + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("RJ"))
                        {
                            dRJ = dRJ + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("RN"))
                        {
                            dRN = dRN + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("SP"))
                        {
                            dSP = dSP + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }
                        if (lEstado[x].ToString().Equals("SE"))
                        {
                            dSE = dSE + (Convert.ToDouble(lVlr_DIFAL[x].ToString()) + Convert.ToDouble(lVlr_FCP[x].ToString()));
                        }

                    }
                }


                //Composição do somatório
                txtTotalFCP.Text = dSoma_FCP.ToString("C");
                txtTotalDifal.Text = dSoma_Difal.ToString("C");


            
        }
        
        //Configura dados iniciais
        private void Configura_Dados_Iniciais()
        {            
                //Preenchendo as NF de comparativo com o status
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" 	SELECT Num_Docume FROM PAGCT CP " +
                                                 "  WHERE CP.Num_NotOri IS NULL " +
                                                 "  AND CP.Sta_Docume = 'Q' " +
                                                 "  AND CP.Cod_Favore = 0037 " +
                                                 "  AND CP.Tip_Docume <> 'F' " +
                                                 "  ORDER BY Num_Docume DESC",
                                                 connectDMD);
                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Num_Docume"] != null) //Sendo o leitor diferente de nulo
                            {
                                lDuplicatas.Add(reader["Num_Docume"].ToString());
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


                //Adiciona o fator ano ao cbxAno para manipular o gráfico
                cbxAno.Text = "0";
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" select distinct [Ano] = year(dat_emissao) from DMD.dbo.NFSCB WHERE  YEAR(dAT_EMISSAO) >=2016 ORDER BY year(dat_emissao) DESC ",
                                                 connectDMD);
                        connectDMD.Open();
                        reader2 = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader2.Read())
                        {
                            if (reader2["Ano"] != null) //Sendo o leitor diferente de nulo
                            {
                                cbxAno.Items.Add(reader2["Ano"].ToString());
                            }
                        }
                        reader2.Close();

                    }
                    catch (SqlException SQLe)
                    {
                        erro_DeAcesso(SQLe);
                    }
                    finally
                    {
                        connectDMD.Close();

                        cbxAno.SelectedItem = DateTime.Today.Year.ToString();

                    }
                }

                //Configura gráfico anual
                //Atualizando o gráfico
                gMes.AxisX.Add(new LiveCharts.Wpf.Axis
                {
                    Labels = new[] { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Sep", "Out", "Nov", "Dez" }
                }
                );
                gMes.AxisY.Add(new LiveCharts.Wpf.Axis
                {
                    Title = "Total",
                    LabelFormatter = value => value.ToString("C")
                }
                );

                DateTime dtinicial = Convert.ToDateTime("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString());
                //Configuraçãod e data
                dtpDtFinal.Value = DateTime.Now;
                dtpDtInicial.Value = dtinicial;            
        }
        
        //Configura gráfico anual
        private void Grafico_Anual()
        {
           
                this.Cursor = Cursors.WaitCursor;
                lNum_Nota.Clear();
                lVlrTotal_Nota.Clear();
                lVlr_FCP.Clear();
                lVlr_DIFAL.Clear();
                lDat_Emissao.Clear();
                lEstado.Clear();
                lCliente.Clear();
                dgJan = 0;
                dgFev = 0;
                dgMar = 0;
                dgAbr = 0;
                dgMai = 0;
                dgJun = 0;
                dgJul = 0;
                dgAgo = 0;
                dgSet = 0;
                dgOut = 0;
                dgNov = 0;
                dgDez = 0;
                dfJan = 0;
                dfFev = 0;
                dfMar = 0;
                dfAbr = 0;
                dfMai = 0;
                dfJun = 0;
                dfJul = 0;
                dfAgo = 0;
                dfSet = 0;
                dfOut = 0;
                dfNov = 0;
                dfDez = 0;


                //Recebe os dados das notas
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command2 = new SqlCommand(" SELECT GNRE.Num_Nota [NF] " +
                                                 " , NSCB.Vlr_TotalNota[Total] " +
                                                 " , NSCB.Vlr_IcmFcpUfDes[FCP] " +
                                                 " , Vlr_IcmIntUfDes[Difal] " +
                                                 " , CAST(NSCB.Dat_Emissao as date)[Dat_Emissao] " +
                                                 " , [Status] = ''" +
                                                 " , Estado[UF] " +
                                                 " , c.Razao_social [Cliente]" +
                                                 " , GNRE.Obs_GNRE [Observação]" +
                                                 " FROM UNIDB.dbo.NSGNR GNRE " +
                                                 " INNER JOIN DMD.dbo.NFSCB NSCB ON NSCB.NUM_NOTA = GNRE.NUM_NOTA " +
                                                 " INNER JOIN DMD.dbo.CLIEN c on c.codigo = nscb.cod_cliente " +

                                                 " WHERE(Vlr_IcmFcpUfDes <> 0 or Vlr_IcmIntUfDes <> 0) AND YEAR(GNRE.Dat_Emissao) = " + cbxAno.SelectedItem.ToString() +
                                                 " AND STATUS = 'F' " +
                                                 " ORDER BY GNRE.Num_Nota DESC", connectDMD);


                        connectDMD.Open();
                        reader3 = command2.ExecuteReader();

                        while (reader3.Read())
                        {
                            if (reader3["NF"] != null) //Sendo o leitor diferente de nulo
                            {
                                if (reader3["NF"] != null) //Sendo o leitor diferente de nulo
                                {
                                    lNum_Nota.Add(reader3["NF"].ToString());
                                    lVlrTotal_Nota.Add(reader3["Total"].ToString());
                                    lVlr_FCP.Add(reader3["FCP"].ToString());
                                    lVlr_DIFAL.Add(reader3["DIFAL"].ToString());
                                    lDat_Emissao.Add(Convert.ToDateTime(reader3["Dat_Emissao"].ToString()));
                                    lEstado.Add(reader3["UF"].ToString());
                                    lCliente.Add(reader3["Cliente"].ToString());



                                }
                            }
                            reader.Close();

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


                //Contato para saber qual a quantidade existente
                int cont, linea = 0;
                //Preenchendo o status
                for (int x = 0; x < lNum_Nota.Count; x++)
                {
                    cont = 0;
                    linea = 0;
                    for (int y = 0; y < lDuplicatas.Count; y++)
                    {
                        if (y > linea)
                        {
                            if (lDuplicatas[y].Contains(lNum_Nota[x]))
                            {
                                cont++;
                                linea = y;
                            }
                        }
                    }

                    if (lEstado[x].ToString() == "PI")
                    {
                        if (cont == 2)
                        {
                            lStatus.Add("Pago");
                        }
                        else if (cont == 1)
                        {
                            lStatus.Add("Pago parcialmente");
                        }
                        else
                        {
                            lStatus.Add("Não pago");
                        }
                    }
                    else
                    {
                        if (cont == 1)
                        {
                            lStatus.Add("Pago");
                        }
                        else
                        {
                            lStatus.Add("Não pago");
                        }
                    }

                }

                //Preenchendo o data grid view
                for (int x = 0; x < lNum_Nota.Count; x++)
                {

                    if (lStatus[x].ToString().Equals("Pago") || lStatus.ToString().Equals("Pago Parcialmente"))
                    {
                        //Alimenta Bar Chart
                        if (Convert.ToDateTime(lDat_Emissao[x].ToString()).Month.ToString().Equals("1"))
                        {
                            dgJan = Convert.ToDouble(lVlr_DIFAL[x].ToString()) + dgJan;
                            dfJan = Convert.ToDouble(lVlr_FCP[x].ToString()) + dfJan;
                        }
                        else if (Convert.ToDateTime(lDat_Emissao[x].ToString()).Month.ToString().Equals("2"))
                        {
                            dgFev = Convert.ToDouble(lVlr_DIFAL[x].ToString()) + dgFev;
                            dfFev = Convert.ToDouble(lVlr_FCP[x].ToString()) + dfFev;
                        }
                        else if (Convert.ToDateTime(lDat_Emissao[x].ToString()).Month.ToString().Equals("3"))
                        {
                            dgMar = Convert.ToDouble(lVlr_DIFAL[x].ToString()) + dgMar;
                            dfMar = Convert.ToDouble(lVlr_FCP[x].ToString()) + dfMar;
                        }
                        else if (Convert.ToDateTime(lDat_Emissao[x].ToString()).Month.ToString().Equals("4"))
                        {
                            dgAbr = Convert.ToDouble(lVlr_DIFAL[x].ToString()) + dgAbr;
                            dfAbr = Convert.ToDouble(lVlr_FCP[x].ToString()) + dfAbr;
                        }
                        else if (Convert.ToDateTime(lDat_Emissao[x].ToString()).Month.ToString().Equals("5"))
                        {
                            dgMai = Convert.ToDouble(lVlr_DIFAL[x].ToString()) + dgMai;
                            dfMai = Convert.ToDouble(lVlr_FCP[x].ToString()) + dfMai;
                        }
                        else if (Convert.ToDateTime(lDat_Emissao[x].ToString()).Month.ToString().Equals("6"))
                        {
                            dgJun = Convert.ToDouble(lVlr_DIFAL[x].ToString()) + dgJun;
                            dfJun = Convert.ToDouble(lVlr_FCP[x].ToString()) + dfJun;
                        }
                        else if (Convert.ToDateTime(lDat_Emissao[x].ToString()).Month.ToString().Equals("7"))
                        {
                            dgJul = Convert.ToDouble(lVlr_DIFAL[x].ToString()) + dgJul;
                            dfJul = Convert.ToDouble(lVlr_FCP[x].ToString()) + dfJul;
                        }
                        else if (Convert.ToDateTime(lDat_Emissao[x].ToString()).Month.ToString().Equals("8"))
                        {
                            dgAgo = Convert.ToDouble(lVlr_DIFAL[x].ToString()) + dgAgo;
                            dfAgo = Convert.ToDouble(lVlr_FCP[x].ToString()) + dfAgo;
                        }
                        else if (Convert.ToDateTime(lDat_Emissao[x].ToString()).Month.ToString().Equals("9"))
                        {
                            dgSet = Convert.ToDouble(lVlr_DIFAL[x].ToString()) + dgSet;
                            dfSet = Convert.ToDouble(lVlr_FCP[x].ToString()) + dfSet;
                        }
                        else if (Convert.ToDateTime(lDat_Emissao[x].ToString()).Month.ToString().Equals("10"))
                        {
                            dgOut = Convert.ToDouble(lVlr_DIFAL[x].ToString()) + dgOut;
                            dfOut = Convert.ToDouble(lVlr_FCP[x].ToString()) + dfOut;
                        }
                        else if (Convert.ToDateTime(lDat_Emissao[x].ToString()).Month.ToString().Equals("11"))
                        {
                            dgNov = Convert.ToDouble(lVlr_DIFAL[x].ToString()) + dgNov;
                            dfNov = Convert.ToDouble(lVlr_FCP[x].ToString()) + dfNov;
                        }
                        else if (Convert.ToDateTime(lDat_Emissao[x].ToString()).Month.ToString().Equals("12"))
                        {
                            dgDez = Convert.ToDouble(lVlr_DIFAL[x].ToString()) + dgDez;
                            dfDez = Convert.ToDouble(lVlr_FCP[x].ToString()) + dfDez;
                        }

                    }
                }

                gMes.Series.Add(new LineSeries
                {
                    Title = "DIFAL: " + cbxAno.SelectedItem.ToString(),
                    Values = new ChartValues<double> { Math.Round((dgJan + dfJan) / 100, 2), Math.Round((dgFev + dfFev) / 100, 2), Math.Round((dgMar + dfMar) / 100, 2), Math.Round((dgAbr + dfAbr) / 100, 2), Math.Round((dgMai + dfMai) / 100, 2), Math.Round((dgJun + dfJun) / 100, 2), Math.Round((dgJul + dfJul) / 100, 2), Math.Round((dgAgo + dfAgo) / 100, 2), Math.Round((dgSet + dfSet) / 100, 2), Math.Round((dgOut + dfOut) / 100, 2), Math.Round((dgNov + dfNov) / 100, 2), Math.Round((dgDez + dfDez) / 100, 2) },
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10

                }
                );

                this.Cursor = Cursors.Default;
                cbxAno.Items.Remove(cbxAno.SelectedItem.ToString());
            }
         
        

      

        //Relacionado a UF
        //Pesquisa por código da UF
        private void txtUF_TextChanged(object sender, EventArgs e)
        {            
                txtUFDesc.Clear();
                if (!txtUF.Text.Trim().Equals(string.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            //Comando sql
                            command = new SqlCommand("SELECT UF.Descricao FROM DMD.[dbo].ESTAD UF WHERE UF.CODIGO LIKE '" + txtUF.Text.Trim().ToUpper() + "'", connectDMD);
                            connectDMD.Open();
                            reader = command.ExecuteReader();
                            //Verifica se ocorrerá alteração de senha
                            while (reader.Read())
                            {
                                if (reader["Descricao"] != null) //Sendo o leitor diferente de nulo
                                {

                                    txtUFDesc.Text = (reader["Descricao"].ToString());
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

        //Relacionado ao cliente
        //Botão para selecionar cliente
        private void btnProcurarCliente_Click(object sender, EventArgs e)
        {
            frmCriarCi_EscolherCliente form = new frmCriarCi_EscolherCliente();
            form.ShowDialog();
            if (form.cod_cliente != 0)
            {
                txtCod_Cliente.Text = Convert.ToString(form.cod_cliente);
            }
        }
        //Pesquisa de cliente por código
        private void txtCod_Cliente_TextChanged(object sender, EventArgs e)
        {            
                txtCliente.Clear();
                if (!txtCod_Cliente.Text.Trim().Equals(string.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            //Comando sql
                            command = new SqlCommand("SELECT C.Razao_Social FROM DMD.[dbo].CLIEN C WHERE C.CODIGO = " + txtCod_Cliente.Text, connectDMD);
                            connectDMD.Open();
                            reader = command.ExecuteReader();
                            //Verifica se ocorrerá alteração de senha
                            while (reader.Read())
                            {
                                if (reader["Razao_Social"] != null) //Sendo o leitor diferente de nulo
                                {
                                    txtCliente.Text = (reader["Razao_Social"].ToString());
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
       
        //Btn exportar relação do DgvDados para excel
        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            exportarExcel();
            this.Cursor = Cursors.Default;
        }

        //Exportar para excel
        //Copiar todos os dados do dgvDados
        private void CopyToClipboardWithHeaders(DataGridView _dgv)
        {
            //Copy to clipboard
            _dgv.SelectAll();
            _dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            DataObject dataObj = _dgv.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);
        }
        private void exportarExcel()
        {
            CopyToClipboardWithHeaders(dgvDados);
            Excel.Application app;
            Excel.Workbook workbook;
            Excel.Worksheet worksheet;
            object misValue = System.Reflection.Missing.Value;
            app = new Excel.Application();
            app.Visible = true;
            workbook = app.Workbooks.Add(misValue);
            worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)worksheet.Cells[1, 1];
            CR.Rows.AutoFit();
            CR.Select();
            Excel.Range rng1 = worksheet.get_Range("A1", "Z1");
            rng1.Font.Bold = true;
            rng1.Font.ColorIndex = 3;
            rng1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            worksheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            worksheet.Name = "Difal - FCP"; //Adicionando o nome a planilha
            //Identar tabela
            foreach (Excel.Worksheet wrkst in workbook.Worksheets)
            {
                Excel.Range usedrange = wrkst.UsedRange;
                usedrange.Columns.AutoFit();
            }
        }

        //Botão para pesquisa
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Filtrar_Dados();
            Grafico_Estado();
            this.Cursor = Cursors.Default;
        }

        //Função para digitar somente números
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        //btn exportar grafico ano
        private void btnExportarGraficoAnu_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(gMes.Width, gMes.Height);
            gMes.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            SaveFileDialog salvarArquivo = new SaveFileDialog();

            salvarArquivo.FileName = "Gráfico - Difal x FCP - Anual";
            salvarArquivo.DefaultExt = "*.png";
            salvarArquivo.Filter = "Documentos de imagem (*.png)|*.png| Todos os arquivos (*.*)|*.*";
            if (salvarArquivo.ShowDialog() == System.Windows.Forms.DialogResult.OK && salvarArquivo.FileName.Length > 0)
            {
                bmp.Save(salvarArquivo.FileName, ImageFormat.Png);
            }

        }

        //btn exportar grafico uf
        private void btnExportarGraficoUF_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(gEstados.Width, gEstados.Height);
            gEstados.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            SaveFileDialog salvarArquivo = new SaveFileDialog();

            salvarArquivo.FileName = "Gráfico - Difal x UF";
            salvarArquivo.DefaultExt = "*.png";
            salvarArquivo.Filter = "Documentos de imagem (*.png)|*.png| Todos os arquivos (*.*)|*.*";
            if (salvarArquivo.ShowDialog() == System.Windows.Forms.DialogResult.OK && salvarArquivo.FileName.Length > 0)
            {
                bmp.Save(salvarArquivo.FileName, ImageFormat.Png);
            }

        }

        //Mudança de index do ano do gráfico anual
        private void cbxAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grafico_Anual();
        }

        //Visualizar detalhamento 
        private void dgvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmAnaliseGnreDuplicatas form = new frmAnaliseGnreDuplicatas();
            form.pubsNum_Nota = dgvDados.CurrentRow.Cells[0].Value.ToString();
            form.pubsUF = dgvDados.CurrentRow.Cells[3].Value.ToString();
            form.pubdtDt_Emissao = Convert.ToDateTime(dgvDados.CurrentRow.Cells[2].Value.ToString());
            form.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        //Pesquisar com ENTER
        private void PesquisaComEnter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPesquisar_Click(btnPesquisar, new EventArgs());
            }
        }

        //Fechar com Esc
        private void frmAnaliseGnre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

    }
}
