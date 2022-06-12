using LiveCharts;
using LiveCharts.Wpf;
using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;
using System.Data.SqlClient;
using Uni_Hospitalar_Controle_PE.Background_Software;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Ulib;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Recebimento.Contas_a_receber
{
    public partial class frmCARinformacoesGerenceiais : Form
    {
        public frmCARinformacoesGerenceiais()
        {
            InitializeComponent();
        }

        public DataGridView dgvContas_Receber;
        public DateTime dtDat_Corte;
        public int Unidade_Servidor;



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

        //Variáveis de TextBox
        private String mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
                     
        //Variáveis dos dias Vencidos
        double vencidos_Menores_Que_90 = 0 ;
        double vencidos_Menores_Que_180= 0 ;
        double vencidos_Menores_Que_360= 0 ;
        double vencidos_Maiores_Que_360= 0 ;
        double vencidos_Menores_Que_0 = 0;
        double Total = 0;




        //Montagem piechart
        private Func<LiveCharts.ChartPoint, string> labelPoint = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y.ToString("C"), chartPoint.Participation);
       
        //Preenche o gráfico dos vencimentos
        private void preencher_gPieVencimentos()
        {            

            //Gráfico pizza de acordo com filtro
            LiveCharts.SeriesCollection piechartData = new LiveCharts.SeriesCollection();

            double tx_min = 0.6;
            double tx_max = 1.4;

            //vencidos_Menores_Que_0   = 10000 ;
            //vencidos_Menores_Que_90  =  100;
            //vencidos_Menores_Que_180 =  500;
            //vencidos_Menores_Que_360 =  197;
            //vencidos_Maiores_Que_360 =  3000;

            double media = (vencidos_Menores_Que_0 + vencidos_Menores_Que_90 + vencidos_Menores_Que_180 + vencidos_Menores_Que_360 + vencidos_Maiores_Que_360)
                / 5;





            if (vencidos_Menores_Que_0 != 0 && (vencidos_Menores_Que_0 > media * (0.6)))
            {
                piechartData.Add(
               new PieSeries
               {
                   Title = "A vencer",
                   Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_0), 2) },
                   DataLabels = true,
                   LabelPoint = labelPoint,
                   LabelPosition = PieLabelPosition.InsideSlice,
                   FontSize = 15,
                   Fill = System.Windows.Media.Brushes.CornflowerBlue,


               }

               );
            }
            else if (vencidos_Menores_Que_0 != 0)
            {
                piechartData.Add(
             new PieSeries
             {
                 Title = "A vencer",
                 Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_0), 2) },
                 DataLabels = true,
                 LabelPoint = labelPoint,
                 LabelPosition = PieLabelPosition.OutsideSlice,
                 FontSize = 15,
                 Fill = System.Windows.Media.Brushes.CornflowerBlue,


             }

             );
            }




            if (vencidos_Menores_Que_90 != 0 && (vencidos_Menores_Que_90 > media * (0.6)))
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "Vencidos 1.. 90 dias",
                    Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_90), 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    LabelPosition = PieLabelPosition.InsideSlice,
                    FontSize = 15,
                    Fill = System.Windows.Media.Brushes.DeepSkyBlue,

                }
                );
            }
            else if (vencidos_Menores_Que_90 != 0)
            {

                if ((vencidos_Menores_Que_0 * tx_min <= vencidos_Menores_Que_90) && (vencidos_Menores_Que_0 * tx_max >= vencidos_Menores_Que_90))
                {

                    piechartData.Add(
                new PieSeries
                {
                    Title = "Vencidos 1.. 90 dias",
                    Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_90), 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    LabelPosition = PieLabelPosition.InsideSlice,
                    FontSize = 15,
                    Fill = System.Windows.Media.Brushes.DeepSkyBlue,

                }
                );
                }
                else
                {
                    piechartData.Add(
                new PieSeries
                {
                    Title = "Vencidos 1.. 90 dias",
                    Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_90), 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    LabelPosition = PieLabelPosition.OutsideSlice,
                    FontSize = 15,
                    Fill = System.Windows.Media.Brushes.DeepSkyBlue,

                }
                );
                }


            }



            if (vencidos_Menores_Que_180 != 0 && (vencidos_Menores_Que_180 > media * (0.6)))
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "Vencidos 91.. 180 dias",
                    Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_180), 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    LabelPosition = PieLabelPosition.InsideSlice,
                    FontSize = 15,
                    Fill = System.Windows.Media.Brushes.Goldenrod,


                }
                );
            }
            else if (vencidos_Menores_Que_180 != 0)
            {

                if ((vencidos_Menores_Que_90 * tx_min <= vencidos_Menores_Que_180) && (vencidos_Menores_Que_90 * tx_max >= vencidos_Menores_Que_180))
                {
                    piechartData.Add(
               new PieSeries
               {
                   Title = "Vencidos 91.. 180 dias",
                   Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_180), 2) },
                   DataLabels = true,
                   LabelPoint = labelPoint,
                   LabelPosition = PieLabelPosition.OutsideSlice,
                   FontSize = 15,
                   Fill = System.Windows.Media.Brushes.Goldenrod,


               }
               );

                }
                else
                {
                    piechartData.Add(
      new PieSeries
      {
          Title = "Vencidos 91.. 180 dias",
          Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_180), 2) },
          DataLabels = true,
          LabelPoint = labelPoint,
          LabelPosition = PieLabelPosition.InsideSlice,
          FontSize = 15,
          Fill = System.Windows.Media.Brushes.Goldenrod,


      }
      );
                }



            }


            if (vencidos_Menores_Que_360 != 0 && (vencidos_Menores_Que_360 > media * (0.6)))
            {
                piechartData.Add(
                new PieSeries
                {
                    Title = "Vencidos 181.. 360 dias",
                    Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_360), 2) },
                    DataLabels = true,
                    LabelPoint = labelPoint,
                    LabelPosition = PieLabelPosition.InsideSlice,
                    FontSize = 15,
                    Fill = System.Windows.Media.Brushes.SlateGray,
                }
                 );
            }
            else if (vencidos_Menores_Que_360 != 0)
            {


                if ((vencidos_Menores_Que_180 * tx_min <= vencidos_Menores_Que_360) && (vencidos_Menores_Que_180 * tx_max >= vencidos_Menores_Que_360))
                {
                    piechartData.Add(
              new PieSeries
              {
                  Title = "Vencidos 181.. 360 dias",
                  Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_360), 2) },
                  DataLabels = true,
                  LabelPoint = labelPoint,
                  LabelPosition = PieLabelPosition.InsideSlice,
                  FontSize = 15,
                  Fill = System.Windows.Media.Brushes.SlateGray,
              }
               );

                }
                else
                {
                    piechartData.Add(
              new PieSeries
              {
                  Title = "Vencidos 181.. 360 dias",
                  Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_360), 2) },
                  DataLabels = true,
                  LabelPoint = labelPoint,
                  LabelPosition = PieLabelPosition.OutsideSlice,
                  FontSize = 15,
                  Fill = System.Windows.Media.Brushes.SlateGray,
              }
               );
                }

            }


            if (vencidos_Maiores_Que_360 != 0 && (vencidos_Maiores_Que_360 > media * (0.6)))
            {
                piechartData.Add(
               new PieSeries
               {

                   Title = "Vencidos a mais 360 dias",
                   Values = new ChartValues<double> { Math.Round((vencidos_Maiores_Que_360), 2) },
                   DataLabels = true,
                   LabelPoint = labelPoint,
                   LabelPosition = PieLabelPosition.InsideSlice,
                   FontSize = 15,
                   Fill = System.Windows.Media.Brushes.Red,


               }
               );
            }
            else if (vencidos_Maiores_Que_360 != 0)
            {

                if (vencidos_Menores_Que_360 * tx_min <= vencidos_Maiores_Que_360 && vencidos_Menores_Que_360 * tx_max >= vencidos_Maiores_Que_360)
                {
                    piechartData.Add(
               new PieSeries
               {

                   Title = "Vencidos a mais 360 dias",
                   Values = new ChartValues<double> { Math.Round((vencidos_Maiores_Que_360), 2) },
                   DataLabels = true,
                   LabelPoint = labelPoint,
                   LabelPosition = PieLabelPosition.OutsideSlice,
                   FontSize = 15,
                   Fill = System.Windows.Media.Brushes.Red,


               }
               );
                }
                else
                {
                    piechartData.Add(
                     new PieSeries
                     {

                         Title = "Vencidos a mais 360 dias",
                         Values = new ChartValues<double> { Math.Round((vencidos_Maiores_Que_360), 2) },
                         DataLabels = true,
                         LabelPoint = labelPoint,
                         LabelPosition = PieLabelPosition.InsideSlice,
                         FontSize = 15,
                         Fill = System.Windows.Media.Brushes.Red,


                     }
                     );
                }
            }

            //if (vencidos_Menores_Que_0 != 0)
            //{
            //    piechartData.Add(
            //   new PieSeries
            //   {
            //       Title = "A vencer",
            //       Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_0), 2) },
            //       DataLabels = true,
            //       LabelPoint = labelPoint,
            //       LabelPosition = PieLabelPosition.InsideSlice,
            //       FontSize = 15,
            //       Fill = System.Windows.Media.Brushes.CornflowerBlue,


            //   }

            //   );
            //}
            //if (vencidos_Menores_Que_90 != 0)
            //{
            //    piechartData.Add(
            //    new PieSeries
            //    {
            //        Title = "Vencidos 1.. 90 dias",
            //        Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_90), 2) },
            //        DataLabels = true,
            //        LabelPoint = labelPoint,
            //        LabelPosition = PieLabelPosition.InsideSlice,
            //        FontSize = 15,
            //        Fill = System.Windows.Media.Brushes.DeepSkyBlue,

            //    }
            //    );
            //}
            //if (vencidos_Menores_Que_180 != 0)
            //{
            //    piechartData.Add(
            //    new PieSeries
            //    {
            //        Title = "Vencidos 91.. 180 dias",
            //        Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_180), 2) },
            //        DataLabels = true,
            //        LabelPoint = labelPoint,
            //        LabelPosition = PieLabelPosition.OutsideSlice,
            //        FontSize = 15,
            //        Fill = System.Windows.Media.Brushes.Goldenrod,


            //    }
            //    );
            //}
            //if (vencidos_Menores_Que_360 != 0)
            //{
            //    piechartData.Add(
            //    new PieSeries
            //    {
            //        Title = "Vencidos 181.. 360 dias",
            //        Values = new ChartValues<double> { Math.Round((vencidos_Menores_Que_360), 2) },
            //        DataLabels = true,
            //        LabelPoint = labelPoint,
            //        LabelPosition = PieLabelPosition.InsideSlice,
            //        FontSize = 15,
            //        Fill = System.Windows.Media.Brushes.SlateGray,
            //    }
            //     );
            //}
            //if (vencidos_Maiores_Que_360 != 0)
            //{
            //    piechartData.Add(
            //   new PieSeries
            //   {

            //       Title = "Vencidos a mais 360 dias",
            //       Values = new ChartValues<double> { Math.Round((vencidos_Maiores_Que_360), 2) },
            //       DataLabels = true,
            //       LabelPoint = labelPoint,
            //       LabelPosition = PieLabelPosition.OutsideSlice,
            //       FontSize = 15,
            //       Fill = System.Windows.Media.Brushes.Red,


            //   }
            //   );
            //}


            // Define os valores do gráfico pizza
            gPieVencimentos.Series = piechartData;                        
            // Muda a legenda para a direita
            gPieVencimentos.LegendLocation = LegendLocation.Right;
            

        }

        private void frmCARinformacoesGerenceiais_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            btnVisualizarComposicao.Visible = false;
            configuracoes_Iniciais();
        }

        //Configurar o DataGridView para visualização inicial dos dados herdados da tela anterior
        private void configurar_dgvDados()
        {            

            Total = vencidos_Menores_Que_0
                  + vencidos_Menores_Que_90
                  + vencidos_Menores_Que_180
                  + vencidos_Menores_Que_360
                  + vencidos_Maiores_Que_360;

            dgvDados.Columns.Add("column_Periodo","Período");
            dgvDados.Columns.Add("column_Valor", "Valor R$");
            dgvDados.Columns[1].Width = 80;

            dgvDados.Rows.Add("A vencer", vencidos_Menores_Que_0.ToString("C").Replace("R$ ", ""));
            dgvDados.Rows.Add("Vencidos de 1 dia até 90 dias", vencidos_Menores_Que_90.ToString("C").Replace("R$ ", ""));
            dgvDados.Rows.Add("Vencidos de 91 dias até 180 dias", vencidos_Menores_Que_180.ToString("C").Replace("R$ ", ""));
            dgvDados.Rows.Add("Vencidos de 181 dias até 360 dias", vencidos_Menores_Que_360.ToString("C").Replace("R$ ", ""));
            dgvDados.Rows.Add("Vencidos a mais de 360 dias", vencidos_Maiores_Que_360.ToString("C").Replace("R$ ", ""));            
            dgvDados.Rows.Add("Valor Total: ", Total.ToString("C").Replace("R$ ",""));
            
            
            preencher_gPieVencimentos();

        }

        //Configurações Iniciais
        private void configuracoes_Iniciais()
        {
            dtpDat_Relatorio.Value = dtDat_Corte;
            //dtpDat_Relatorio.Value = DateTime.Now;


            foreach (DataGridViewRow row in dgvContas_Receber.Rows)
            {
                if (!lsbGrupoClientes.Items.Contains(row.Cells[3].Value.ToString()))
                {
                    lsbGrupoClientes.Items.Add(row.Cells[3].Value.ToString());
                }
            }

            calcular_Totais();

        }


        //Fecha o Form
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        //Exportar Tabela
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
            worksheet.Name = "Vencimento por Período"; //Adicionando o nome a planilha
            //Identar tabela
            foreach (Excel.Worksheet wrkst in workbook.Worksheets)
            {
                Excel.Range usedrange = wrkst.UsedRange;
                usedrange.Columns.AutoFit();
            }
        }

        //Exportar Gráfico
        private void btnExportarGraficoPizza_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(gPieVencimentos.Width, gPieVencimentos.Height);
            gPieVencimentos.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));

            SaveFileDialog salvarArquivo = new SaveFileDialog();

            salvarArquivo.FileName = "Período x Vencimento";
            salvarArquivo.DefaultExt = "*.png";
            salvarArquivo.Filter = "Documentos de imagem (*.png)|*.png| Todos os arquivos (*.*)|*.*";
            if (salvarArquivo.ShowDialog() == System.Windows.Forms.DialogResult.OK && salvarArquivo.FileName.Length > 0)
            {
                bmp.Save(salvarArquivo.FileName, ImageFormat.Png);
            }

        }

        private void calcular_Totais()
        {
            ////Prodyção
            vencidos_Menores_Que_0 = 0;
            vencidos_Menores_Que_90 = 0;
            vencidos_Menores_Que_180 = 0;
            vencidos_Menores_Que_360 = 0;
            vencidos_Maiores_Que_360 = 0;

            ////Variáveis teste
            //vencidos_Menores_Que_0 = 6175486.8746;
            //vencidos_Menores_Que_90 = 4567546;
            //vencidos_Menores_Que_180 = 2567546;
            //vencidos_Menores_Que_360 = 456700.7874;
            //vencidos_Maiores_Que_360 = 1000000;
            Total = 0;
            dgvDados.Rows.Clear();
            dgvDados.Columns.Clear();
            gPieVencimentos.Series.Clear();



            //Indica os Valores Default
            foreach (DataGridViewRow row in dgvContas_Receber.Rows)
            {

                if (chkPublico.Checked == false && chkPrivado.Checked == false)
                {
                    mMessage = "Por favor selecione algum filtro de esfera";
                    mTittle = "Filtro não atribuído";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Warning;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    break;
                }

                if (!txtCliente.Text.Equals(String.Empty))
                {
                    if (row.Cells[1].Value.ToString().Equals(txtCodCliente.Text.Trim()))
                    {

                        //Parametros de Data
                        if (row.Cells[7].Value.ToString().Equals("A vencer")) // A vencer
                        {
                            vencidos_Menores_Que_0 = vencidos_Menores_Que_0 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));
                        }
                        else if (row.Cells[7].Value.ToString().Equals("Vencidos de 1 dia até 90 dias")) //Vencidos à 90 dias
                        {
                            vencidos_Menores_Que_90 = vencidos_Menores_Que_90 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));
                        }
                        else if (row.Cells[7].Value.ToString().Equals("Vencidos de 91 dias até 180 dias")) //Vencidos entre 91 dias e 180 dias
                        {
                            vencidos_Menores_Que_180 = vencidos_Menores_Que_180 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));

                        }
                        else if (row.Cells[7].Value.ToString().Equals("Vencidos de 181 dias até 360 dias"))// Vencidos Entre 181 dias e 360 dias
                        {
                            vencidos_Menores_Que_360 = vencidos_Menores_Que_360 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));

                        }
                        else if (row.Cells[7].Value.ToString().Equals("Vencidos a mais de 360 dias"))// Vencidos a mais de 360
                        {
                            vencidos_Maiores_Que_360 = vencidos_Maiores_Que_360 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));
                        }
                    }
                }
                else
                {


                    if (chkPublico.Checked == false && chkPrivado.Checked == true)
                    {
                        if (row.Cells[0].Value.ToString().Equals("PRIVADO")
                            && lsbGrupoClientes.Items.Contains(row.Cells[3].Value.ToString())
                            )
                        {
                            //Parametros de Data
                            if (row.Cells[7].Value.ToString().Equals("A vencer")) // A vencer
                            {
                                vencidos_Menores_Que_0 = vencidos_Menores_Que_0 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));
                            }
                            else if (row.Cells[7].Value.ToString().Equals("Vencidos de 1 dia até 90 dias")) //Vencidos à 90 dias
                            {
                                vencidos_Menores_Que_90 = vencidos_Menores_Que_90 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));
                            }
                            else if (row.Cells[7].Value.ToString().Equals("Vencidos de 91 dias até 180 dias")) //Vencidos entre 91 dias e 180 dias
                            {
                                vencidos_Menores_Que_180 = vencidos_Menores_Que_180 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));

                            }
                            else if (row.Cells[7].Value.ToString().Equals("Vencidos de 181 dias até 360 dias"))// Vencidos Entre 181 dias e 360 dias
                            {
                                vencidos_Menores_Que_360 = vencidos_Menores_Que_360 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));

                            }
                            else if (row.Cells[7].Value.ToString().Equals("Vencidos a mais de 360 dias"))// Vencidos a mais de 360
                            {
                                vencidos_Maiores_Que_360 = vencidos_Maiores_Que_360 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));
                            }
                        }
                    }
                    else if (chkPublico.Checked == true && chkPrivado.Checked == false)
                    {
                        if (row.Cells[0].Value.ToString().Equals("PÚBLICO")
                            && lsbGrupoClientes.Items.Contains(row.Cells[3].Value.ToString())
                            )
                        {
                            //Parametros de Data
                            if (row.Cells[7].Value.ToString().Equals("A vencer")) // A vencer
                            {
                                vencidos_Menores_Que_0 = vencidos_Menores_Que_0 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));
                            }
                            else if (row.Cells[7].Value.ToString().Equals("Vencidos de 1 dia até 90 dias")) //Vencidos à 90 dias
                            {
                                vencidos_Menores_Que_90 = vencidos_Menores_Que_90 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));
                            }
                            else if (row.Cells[7].Value.ToString().Equals("Vencidos de 91 dias até 180 dias")) //Vencidos entre 91 dias e 180 dias
                            {
                                vencidos_Menores_Que_180 = vencidos_Menores_Que_180 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));

                            }
                            else if (row.Cells[7].Value.ToString().Equals("Vencidos de 181 dias até 360 dias"))// Vencidos Entre 181 dias e 360 dias
                            {
                                vencidos_Menores_Que_360 = vencidos_Menores_Que_360 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));

                            }
                            else if (row.Cells[7].Value.ToString().Equals("Vencidos a mais de 360 dias"))// Vencidos a mais de 360
                            {
                                vencidos_Maiores_Que_360 = vencidos_Maiores_Que_360 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));
                            }
                        }
                    }
                    else if (chkPublico.Checked == true && chkPrivado.Checked == true)
                    {
                        if ((row.Cells[0].Value.ToString().Equals("PRIVADO") || row.Cells[0].Value.ToString().Equals("PÚBLICO"))
                            && lsbGrupoClientes.Items.Contains(row.Cells[3].Value.ToString())
                            )
                        {
                            //Parametros de Data
                            if (row.Cells[7].Value.ToString().Equals("A vencer")) // A vencer
                            {
                                vencidos_Menores_Que_0 = vencidos_Menores_Que_0 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));
                            }
                            else if (row.Cells[7].Value.ToString().Equals("Vencidos de 1 dia até 90 dias")) //Vencidos à 90 dias
                            {
                                vencidos_Menores_Que_90 = vencidos_Menores_Que_90 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));
                            }
                            else if (row.Cells[7].Value.ToString().Equals("Vencidos de 91 dias até 180 dias")) //Vencidos entre 91 dias e 180 dias
                            {
                                vencidos_Menores_Que_180 = vencidos_Menores_Que_180 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));

                            }
                            else if (row.Cells[7].Value.ToString().Equals("Vencidos de 181 dias até 360 dias"))// Vencidos Entre 181 dias e 360 dias
                            {
                                vencidos_Menores_Que_360 = vencidos_Menores_Que_360 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));

                            }
                            else if (row.Cells[7].Value.ToString().Equals("Vencidos a mais de 360 dias"))// Vencidos a mais de 360
                            {
                                vencidos_Maiores_Que_360 = vencidos_Maiores_Que_360 + Convert.ToDouble(row.Cells[13].Value.ToString().Replace("R$",""));
                            }
                        }
                    }
                }


            }
            configurar_dgvDados();

        }
            
        




        private void chkPrivado_CheckedChanged(object sender, EventArgs e)
        {
            calcular_Totais();
        }

        private void chkPublico_CheckedChanged(object sender, EventArgs e)
        {
            calcular_Totais();
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


        private void btnPreencherCliente_Click(object sender, EventArgs e)
        {
            frmCriarCi_EscolherCliente form = new frmCriarCi_EscolherCliente();
            
            form.ShowDialog();
            if (form.cod_cliente != 0)
                txtCodCliente.Text = Convert.ToString(form.cod_cliente);
        }



        private void btnResetar_Click(object sender, EventArgs e)
        {

            lsbGrupoClientes.Items.Clear();
            foreach (DataGridViewRow row in dgvContas_Receber.Rows)
            {
                if (!lsbGrupoClientes.Items.Contains(row.Cells[3].Value.ToString()))
                {
                    lsbGrupoClientes.Items.Add(row.Cells[3].Value.ToString());
                    
                }
                
            }
            calcular_Totais();

        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dgvDados.ColumnCount);
            //Nome do arquivo PDF
            
 
            //Características da tabela
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 25f;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            float[] widths = new float[] { 6f, 3f };
            pdfTable.SetWidths(widths);

            iTextSharp.text.Font tituloRelatorio = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 18,1);  //Fonte filtros
            iTextSharp.text.Font descricaoRelatorio = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 7, 1);  //Fonte filtros
            iTextSharp.text.Font tablefonttitle = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 11,1); //Fonte cabeçalho
            iTextSharp.text.Font tablefonttext = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 9);  //Fonte relatório
            

            //Adicionando cabeçalho
            foreach (DataGridViewColumn column in dgvDados.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, tablefonttitle));
                pdfTable.AddCell(cell);
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            }
            int row = dgvDados.Rows.Count;
            int cell2 = dgvDados.Rows[1].Cells.Count;
            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < cell2; j++)
                {
                    if (dgvDados.Rows[i].Cells[j].Value == null)
                    {
                        //return directly
                        //return;
                        //or set a value for the empty data
                        dgvDados.Rows[i].Cells[j].Value = "null";
                    }
                    PdfPCell cell3 = new PdfPCell(new Phrase(dgvDados.Rows[i].Cells[j].Value.ToString(), tablefonttext));
                    if (j == 1)
                    {
                        cell3.HorizontalAlignment = Element.ALIGN_RIGHT;
                    }
                    pdfTable.AddCell(cell3);
                }
            }
            

            string titulo;
            //Exporting to PDF        
            SaveFileDialog salvarArquivoPDF = new SaveFileDialog();
            Stream stream;
            salvarArquivoPDF.Filter = "Arquivo PDF|*.pdf";
            salvarArquivoPDF.Title = "Salvar arquivo PDF";
            salvarArquivoPDF.FilterIndex = 2;

            if (chkPrivado.Checked && chkPublico.Checked)
            {
                titulo = "Saldo do Contas a Receber - Geral";
            }
            else if (chkPublico.Checked)
            {
                titulo = "Saldo do Contas a Receber - Público";
            }
            else
            {
                titulo = "Saldo do Contas a Receber - Privado";
            }

            salvarArquivoPDF.FileName = titulo;
            salvarArquivoPDF.RestoreDirectory = true;

            if (salvarArquivoPDF.ShowDialog() == DialogResult.OK)
            {
                if ((stream = salvarArquivoPDF.OpenFile()) != null)
                {

                    //Parametrização do PDF
                    Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    
                    



                    
                    
                    if (chkPrivado.Checked && chkPublico.Checked)
                    {
                        titulo = "Saldo do Contas a Receber - Geral";
                    }
                    else if (chkPublico.Checked)
                    {
                        titulo = "Saldo do Contas a Receber - Público";
                    }
                    else
                    {
                        titulo = "Saldo do Contas a Receber - Privado";
                    }


                    iTextSharp.text.Image IMGlogo = null;

                    if (Unidade_Servidor == 1) {
                        //Logo do IMGlogo
                        IMGlogo = iTextSharp.text.Image.GetInstance(Properties.Resources.Logo_Uni_PNG, System.Drawing.Imaging.ImageFormat.Png);
                        IMGlogo.ScaleToFit(200f, 270f);
                        IMGlogo.SetAbsolutePosition(5, 515);
                    }
                    else if (Unidade_Servidor == 2) {
                        //Logo do IMGlogo
                        IMGlogo = iTextSharp.text.Image.GetInstance(Properties.Resources.Uni_CE_LOGO, System.Drawing.Imaging.ImageFormat.Png);
                        IMGlogo.ScaleToFit(200f, 270f);
                        IMGlogo.SetAbsolutePosition(5, 480);
                    }
                    else {
                        //Logo do IMGlogo
                        IMGlogo = iTextSharp.text.Image.GetInstance(Properties.Resources.sphospitalar_logo_10cm_01_01, System.Drawing.Imaging.ImageFormat.Png);
                        IMGlogo.ScaleToFit(200f, 270f);
                        IMGlogo.SetAbsolutePosition(5, 430);
                    }

                    //Gráfico
                    Bitmap bmp = new Bitmap(gPieVencimentos.Width, gPieVencimentos.Height);
                    gPieVencimentos.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));
                    iTextSharp.text.Image IMGgrafico = iTextSharp.text.Image.GetInstance(bmp, System.Drawing.Imaging.ImageFormat.Bmp); //Adicionando imagem de cabeçalho                    
                    IMGgrafico.ScaleToFit(600f, 482f);
                    IMGgrafico.SetAbsolutePosition(240f, 15f);
                                                    
                    //Montagem documento
                    pdfDoc.Add(new Phrase(  "                                                         " +
                                            titulo, tituloRelatorio));
                    pdfDoc.Add(new Phrase(  "\n                                                                                       "
                                          + "                                                                            "
                                          + " UHC 2 - Visão Gerencial - " + titulo + " - " + dtpDat_Relatorio.Value.ToShortDateString(), descricaoRelatorio));
                    pdfDoc.Add(IMGlogo);
                    pdfDoc.Add(IMGgrafico);
                    pdfDoc.Add(new Paragraph(new Chunk("\n\n\n\n\n\n")));
                    pdfDoc.Add(pdfTable);
                    pdfDoc.Add(new Phrase("Valor Total ........................ " + Total.ToString("C"), tablefonttitle));
                    pdfDoc.Close();
                    stream.Close();

                    mMessage = "Exportado com sucesso!";
                    mTittle = "Relatório";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Information;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                }
            }
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            calcular_Totais();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {

            if (lsbGrupoClientes.SelectedItem != null)
            {
                lsbGrupoClientes.Items.Remove(lsbGrupoClientes.SelectedItem);
                calcular_Totais();
            }

          

        }
    }
}
