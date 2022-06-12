using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Excel = Microsoft.Office.Interop.Excel;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Recebimento.Contas_a_receber
{
    public partial class frmContasAreceber : Form
    {
        public frmContasAreceber()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlCommand command2 = new SqlCommand();

        //private SqlDataReader reader;
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

        DataTable tableDados;

        //Variáveis de TextBox
        private string mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave

        //Cálculo do Total do CAR
        double dTotalCar = 0;

        //Data de Atualização
        DateTime dtDat_Atualização = DateTime.Now;

        //Configurações do gráfico
        LiveCharts.ChartValues<double> values = new LiveCharts.ChartValues<double>();
        List<String> labels = new List<String>();
        public int Unidade_Servidor;

        private void configurar_Grids(DataGridView _dgv,DataGridView _dgv2)
        {

            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Columns.Add("Esfera", "Grupo");
                _dgv.Columns.Add("Cod_Cliente", "Cód.Cli.");
                _dgv.Columns.Add("Des_Cliente", "Cliente");
                _dgv.Columns.Add("Grupo_Cliente", "Grupo do Cliente");
                _dgv.Columns.Add("Duplicata", "Duplicata");
                _dgv.Columns.Add("Dat_Emissao", "Dat.Emissão");
                _dgv.Columns.Add("Dat_Vencimento", "Dat.Vencimento");
                _dgv.Columns.Add("Periodo", "Período");
                _dgv.Columns.Add("Dat_Pagamento", "Dat.Pagamento");
                _dgv.Columns.Add("Vlr_Princ", "Vlr. Principal");
                _dgv.Columns.Add("Vlr_Princ_Acresc", "Vlr. Princ. + acréscimo");
                _dgv.Columns.Add("Vlr_Recebido", "Vlr. Recebido");
                _dgv.Columns.Add("Vlr_Desconto", "Vlr. Desconto ");
                _dgv.Columns.Add("Sld_Receber", "Sld.à Receber");
            });
            _dgv2.Invoke((MethodInvoker)delegate
            {
                _dgv2.Columns.Add("Cod_Cliente", "Código");
                _dgv2.Columns.Add("Des_Cliente", "Cliente");
                _dgv2.Columns.Add("Sld_Total", "Sld. Total a Receber");
            }
            );

        }


        private void Configuracoes_Iniciais()
        {
            dtpDatCorte.Value = DateTime.Now;
            configurar_Grids(dgvDados,dgvRanking);            
            Filtrar_Dados(dgvDados, dgvRanking);
            
        }

        
        private void FrmContasAreceber_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            btnInformacoesGerenciais.Enabled = true;
            Configuracoes_Iniciais();


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
            Excel.Workbook MapaChiesi;
            Excel.Worksheet abaEstoque;

            object misValue = System.Reflection.Missing.Value;
            app = new Excel.Application();
            app.Visible = true;
            MapaChiesi = app.Workbooks.Add(misValue);
            abaEstoque = (Excel.Worksheet)MapaChiesi.Worksheets.get_Item(1);
            Excel.Range CR = (Excel.Range)abaEstoque.Cells[1, 1];
            CR.Rows.AutoFit();
            CR.Select();
            Excel.Range rng1 = abaEstoque.get_Range("A1", "Z1");
            rng1.Font.Bold = true;
            rng1.Font.ColorIndex = 3;
            rng1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            abaEstoque.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            abaEstoque.Name = "CAR"; //AdicionAND o o nome a planilha
                                         //Identar tabela
            foreach (Excel.Worksheet wrkst in MapaChiesi.Worksheets)
            {
                Excel.Range usedrange = wrkst.UsedRange;
                usedrange.Columns.AutoFit();

            }

            var xlSheets = MapaChiesi.Sheets as Excel.Sheets;
            var abaDemanda = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
            abaDemanda.Name = "Ranking";
            abaDemanda = (Excel.Worksheet)MapaChiesi.Worksheets.get_Item(1);
            CopyToClipboardWithHeaders(dgvRanking);
            Excel.Range CR2 = (Excel.Range)abaDemanda.Cells[1, 1];
            CR2.Rows.AutoFit();
            CR2.Select();
            rng1 = abaDemanda.get_Range("A1", "Z1");
            rng1.Font.Bold = true;
            rng1.Font.ColorIndex = 3;
            rng1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            abaDemanda.PasteSpecial(CR2, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            //Identar tabela
            foreach (Excel.Worksheet wrkst in MapaChiesi.Worksheets)
            {
                Excel.Range usedrange = wrkst.UsedRange;
                usedrange.Columns.AutoFit();
            }
           
        }

        private void Adicionar_Grafico(DataGridView _dgv)
        {

            gRanking.Invoke((MethodInvoker)delegate
           {
               gRanking.Series.Clear();
               gRanking.AxisX.Clear();
               gRanking.AxisY.Clear();
               values.Clear();
               labels.Clear();
               int x = 0;
               _dgv.Invoke((MethodInvoker)delegate
               {
                   foreach (DataGridViewRow row in _dgv.Rows)
                   {
                       x++;
                       values.Add(Convert.ToDouble(row.Cells[2].Value.ToString().Replace("R$","")));
                       labels.Add(row.Cells[1].Value.ToString());
                       if (x == 10)
                       {
                           break;
                       }
                   }
               });

               gRanking.Series = new LiveCharts.SeriesCollection
           {
                new ColumnSeries
                {
                    Title = "Ranking CAP",
                    Values = values,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green
                }
           };


               gRanking.AxisX.Add(new Axis
               {
                   Title = "Descrição",
                   Labels = labels,
                   Unit = 1,

               });

               gRanking.AxisY.Add(new Axis
               {
                   Title = "Totalizador",
                   LabelFormatter = value => value.ToString("C")
               });

           });
        }


        private void Filtrar_Dados(DataGridView _dgv, DataGridView _dgv2)
        {
            dTotalCar = 0;
            
            this.Invoke((MethodInvoker)delegate { this.Cursor = Cursors.WaitCursor; });

                        
                    String filtro_Documento = null;

                    if (!txtTitulo.Text.Equals(String.Empty))
                    {
                       filtro_Documento = " AND  CT.Num_Documento LIKE '%" + txtTitulo.Text + "%'";
                    }

                    //Configurando exibição do car por data de corte
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                try
                {




                    connectDMD.Open();
                    command = connectDMD.CreateCommand();
                    command.CommandText =

                              "  CREATE table #BXREC_LIMIT (                                                                                                                                                                                                                                                                   "
                             + "  [Cod_Documento][int]             NOT NULL,                                                                                                                                                                                                                                                    "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                                                                                                                                                                                                                                                                                                "
                             + " [Dat_Registro]  [datetime]        NULL,                                                                                                                                                                                                                                                        "
                             + "  [Vlr_Principal] [numeric] (18, 4) NULL CONSTRAINT[DF_BXREC_Vlr_Principal]  DEFAULT(0),                                                                                                                                                                                                        "
                             + "  [Vlr_Desconto]  [numeric] (18, 4) NULL CONSTRAINT[DF_BXREC_Vlr_Desconto]   DEFAULT(0),                                                                                                                                                                                                        "
                             + "  [Vlr_Deducoes]  [numeric] (18, 4) NULL CONSTRAINT[DF_BXREC_Vlr_Deducoes]   DEFAULT(0),                                                                                                                                                                                                        "
                             + "  [Dat_Caixa]     [datetime]        NULL                                                                                                                                                                                                                                                        "
                             + " )                                                                                                                                                                                                                                                                                              "
                             + " INSERT INTO #BXREC_LIMIT                                                                                                                                                                                                                                                                       "
                             + " (Cod_Documento, Dat_Registro, Vlr_Principal, Vlr_Desconto, Vlr_Deducoes, Dat_Caixa)                                                                                                                                                                                                            "
                             + " (                                                                                                                                                                                                                                                                                              "
                             + "   SELECT BX.Cod_Documento                                                                                                                                                                                                                                                                      "
                             + "         ,BX.Dat_Registro                                                                                                                                                                                                                                                                       "
                             + " 		,BX.Vlr_Principal                                                                                                                                                                                                                                                                      "
                             + " 		,BX.Vlr_Desconto                                                                                                                                                                                                                                                                       "
                             + " 		,BX.Vlr_Deducoes                                                                                                                                                                                                                                                                       "
                             + " 		,BX.Dat_Caixa                                                                                                                                                                                                                                                                          "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "   FROM[DMD].dbo.[BXREC] BX                                                                                                                                                                                                                                                                     "
                             + "  WHERE BX.Dat_Caixa <= @DAT_INICIAL                                                                                                                                                                                                                                                            "
                             + " )                                                                                                                                                                                                                                                                                              "
                             + "                                                                                                                                                                                                                                                                                                "
                             + " SELECT                                                                                                                                                                                                                                                                                         "
                             + "  [Esfera] = CASE CLI.Tipo_Consumidor                                                                                                                                                                                                                                                            "
                             + "           WHEN 'F' THEN 'PRIVADO'                                                                                                                                                                                                                                                              "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                            WHEN 'N' THEN 'PRIVADO'                                                                                                                                                                                                                                             "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                            ELSE 'PÚBLICO'                                                                                                                                                                                                                                                      "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                            END                                                                                                                                                                                                                                                                 "
                             + " ,[Cod_CLiente]               = CLI.Codigo                                                                                                                                                                                                                                                         "
                             + " ,[Des_Cliente]                = CLI.Razao_Social                                                                                                                                                                                                                                                   "
                             + " ,[Grupo_Cliente]          = GP_Cliente.Des_GrpCli                                                                                                                                                                                                                                              "
                             + " ,[Duplicata]              = CT.Num_Documento + ' ' + CT.Par_Documento                                                                                                                                                                                                                          "
                             + " ,[Dat_Emissao]            = CONVERT(DATE, CT.Dat_Emissao)                                                                                                                                                                                                                                      "
                             + " ,[Dat_Vencimento]         = CONVERT(DATE, CT.Dat_Vencimento)                                                                                                                                                                                                                                   "
                             + " ,[Periodo] = CASE                                                                                                                                                                                                                                                                              "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "           WHEN(CT.Dat_Vencimento >= @DAT_INICIAL) THEN 'A vencer'                                                                                                                                                                                                                              "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "           WHEN(CT.Dat_Vencimento >= @DAT_INICIAL - 90) THEN 'Vencidos de 1 dia até 90 dias'                                                                                                                                                                                                    "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "           WHEN(CT.Dat_Vencimento >= @DAT_INICIAL - 180) THEN 'Vencidos de 91 dias até 180 dias'                                                                                                                                                                                                "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "           WHEN(CT.Dat_Vencimento >= @DAT_INICIAL - 360) THEN 'Vencidos de 181 dias até 360 dias'                                                                                                                                                                                               "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "           WHEN(CT.Dat_Vencimento < @DAT_INICIAL - 360) THEN 'Vencidos a mais de 360 dias'                                                                                                                                                                                                      "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "           END                                                                                                                                                                                                                                                                                  "
                             + " ,[Dat_Pagamento]          = CONVERT(DATE, MAX(BX.Dat_Caixa))                                                                                                                                                                                                                                   "
                             + " ,[Vlr_Princ]          = REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR, CAST((SUM(DISTINCT CT.Vlr_ParTit))                                                                     AS MONEY), 1), ',', '_'), '.', ','), '_', '.')                                                                     "
                             + " ,[Vlr_Princ_Acresc] = REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR, CAST((ISNULL(SUM(DISTINCT CT.Vlr_OutAcr), 0) + ISNULL(SUM(DISTINCT CT.Vlr_ParTit), 0))                   AS MONEY), 1), ',', '_'), '.', ','), '_', '.')                                                                    "
                             + " ,[Vlr_Recebido]           = REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR, CAST((ISNULL(SUM(BX.Vlr_Principal), 0) - ISNULL(SUM(BX.Vlr_Deducoes + BX.Vlr_Desconto), 0))             AS MONEY), 1), ',', '_'), '.', ','), '_', '.')                                                                    "
                             + " ,[Vlr_Desconto]           = CASE                                                                                                                                                                                                                                                               "
                             + "                             WHEN(CT.TRANSACAO < @DAT_INICIAL)                                                                                                                                                                                                                                  "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                             THEN                                                                                                                                                                                                                                                               "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                             REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR, CAST((ABS(ISNULL(SUM(BX.Vlr_Deducoes + BX.Vlr_Desconto), 0) - ISNULL(SUM(DISTINCT Vlr_DescConced), 0))) AS MONEY), 1), ',', '_'), '.', ','), '_', '.')                                                                    "
                             + "                             ELSE '0,00'                                                                                                                                                                                                                                                        "
                             + "                             END                                                                                                                                                                                                                                                                "
                             + " ,[Sld_Receber]          = CASE                                                                                                                                                                                                                                                               "
                             + "                             WHEN(CT.TRANSACAO < @DAT_INICIAL)                                                                                                                                                                                                                                  "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                             THEN                                                                                                                                                                                                                                                               "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                             REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR, CAST((SUM(DISTINCT CT.Vlr_ParTit) - ISNULL(SUM(BX.Vlr_Principal), 0) - ABS(ISNULL(SUM(BX.Vlr_Deducoes + BX.Vlr_Desconto), 0) + ISNULL(SUM(DISTINCT Vlr_DescConced), 0))) AS MONEY), 1), ',', '_'), '.', ','), '_', '.')   "
                             + "                             ELSE                                                                                                                                                                                                                                                               "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                             REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR, CAST((SUM(DISTINCT CT.Vlr_ParTit) - ISNULL(SUM(BX.Vlr_Principal), 0) - ABS(ISNULL(SUM(BX.Vlr_Deducoes + BX.Vlr_Desconto), 0))) AS MONEY), 1), ',', '_'), '.', ','), '_', '.')                                             "
                             + "                             END                                                                                                                                                                                                                                                                "
                             + " FROM[DMD].dbo.CTREC CT                                                                                                                                                                                                                                                                         "
                             + " LEFT OUTER JOIN #BXREC_LIMIT      BX  ON CT.Cod_Documento = BX.Cod_Documento                                                                                                                                                                                                                   "
                             + "      INNER JOIN[DMD].dbo.[CLIEN] CLI ON CLI.Codigo = CT.Cod_Cliente                                                                                                                                                                                                                            "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "      LEFT JOIN[DMD].dbo.[GRCLI] GP_Cliente ON GP_Cliente.Cod_GrpCli = CLI.Cod_GrpCli                                                                                                                                                                                                           "
                             + " WHERE                                                                                                                                                                                                                                                                                          "
                             + "    ((CT.Dat_Emissao <= @DAT_INICIAL AND NOT Status IN('C', 'B'))                                                                                                                                                                                                                               "
                             + "  OR(CT.Dat_Emissao <= @DAT_INICIAL AND     Status IN('B') AND CT.Dat_Quitacao > @DAT_INICIAL))                                                                                                                                                                                                 "
                             + filtro_Documento
                             + " GROUP BY                                                                                                                                                                                                                                                                                       "
                             + "          CT.Par_Documento                                                                                                                                                                                                                                                                      "
                             + " 		,CT.Status                                                                                                                                                                                                                                                                             "
                             + " 		,CT.Vlr_OutAcr                                                                                                                                                                                                                                                                         "
                             + " 		,CT.Vlr_ParTit                                                                                                                                                                                                                                                                         "
                             + " 		,CT.Num_Documento                                                                                                                                                                                                                                                                      "
                             + " 		,CT.Num_NfOrigem                                                                                                                                                                                                                                                                       "
                             + " 		,CT.Par_Documento                                                                                                                                                                                                                                                                      "
                             + " 		,CLI.Codigo                                                                                                                                                                                                                                                                            "
                             + " 		,CLI.Razao_Social                                                                                                                                                                                                                                                                      "
                             + " 		,CLI.Tipo_Consumidor                                                                                                                                                                                                                                                                   "
                             + " 		,CT.Dat_Emissao                                                                                                                                                                                                                                                                        "
                             + " 		,CT.Dat_Vencimento                                                                                                                                                                                                                                                                     "
                             + " 		,CT.Transacao                                                                                                                                                                                                                                                                          "
                            + "	,GP_Cliente.Des_GrpCli                                                                                                                                                                                                                                                                         "
                             + " HAVING                                                                                                                                                                                                                                                                                         "
                             + "        SUM(DISTINCT CT.Vlr_ParTit) - ISNULL(SUM(BX.Vlr_Principal), 0) - ISNULL(SUM(BX.Vlr_Deducoes + BX.Vlr_Desconto), 0) - ISNULL(SUM(DISTINCT CT.Vlr_DescConced), 0) > 0                                                                                                                     "
                             + "                                                                                                                                                                                                                                                                                                "
                             + "                                                                                                                                                                                                                                                                                                "
                             + " ORDER BY CT.Num_NfOrigem DESC                                                                                                                                                                                                                                                                  "
                             + " DROP TABLE #BXREC_LIMIT                                                                                                                                                                                                                                                                        "
                              ;


                    command.Parameters.AddWithValue("Dat_Inicial", dtpDatCorte.Value);
                    adaptador = new SqlDataAdapter(command);
                    tableDados = new DataTable();
                    adaptador.Fill(tableDados);

                }

                catch (SqlException SQLe)
                {
                    erro_DeAcesso(SQLe);
                }
                finally
                {
                    //txtCAR.Text = dTotalCar.ToString("C");
                    connectDMD.Close();
                    var lista_Filtrada = from car in tableDados.AsEnumerable()
                                       select car;

                    _dgv.Invoke((MethodInvoker)delegate
                    {
                        _dgv.Rows.Clear();
                        foreach (var item in lista_Filtrada)
                        {

                            _dgv.Rows.Add(item["Esfera"],item["Cod_Cliente"],item["Des_Cliente"],item["Grupo_Cliente"]
                                ,item["Duplicata"],item["Dat_Emissao"],item["Dat_Vencimento"],item["Periodo"]
                                ,item["Dat_Pagamento"],item["Vlr_Princ"],item["Vlr_Princ_Acresc"]
                                ,item["Vlr_Recebido"],item["Vlr_Desconto"],item["Sld_Receber"]);
                            dTotalCar = Convert.ToDouble(item["sld_receber"]) + dTotalCar;
                        }
                        foreach (DataGridViewRow row in _dgv.Rows)
                        {
                            row.Cells["Vlr_Princ_Acresc"].Value = Convert.ToDouble(row.Cells["Vlr_Princ_Acresc"].Value.ToString().Replace("R$","")).ToString("C");
                            row.Cells["Vlr_Recebido"].Value = Convert.ToDouble(row.Cells["Vlr_Recebido"].Value.ToString().Replace("R$", "")).ToString("C");
                            row.Cells["Vlr_Desconto"].Value = Convert.ToDouble(row.Cells["Vlr_Desconto"].Value.ToString().Replace("R$", "")).ToString("C");
                            row.Cells["Sld_Receber"].Value = Convert.ToDouble(row.Cells["Sld_Receber"].Value.ToString().Replace("R$", "")).ToString("C");
                        }

                    });

                    List<int> codigo = new List<int>();
                    List<string> descricao = new List<string>();
                    List<double> valor = new List<double>();


                    foreach (var item in lista_Filtrada)
                    {
                        if (!codigo.Contains(Convert.ToInt32(item["Cod_Cliente"])))
                        {
                            codigo.Add(Convert.ToInt32(item["Cod_Cliente"]));
                            descricao.Add(item["Des_Cliente"].ToString());
                            valor.Add(Convert.ToDouble(item["Sld_Receber"]));
                        }
                        else
                        {
                            valor[codigo.IndexOf(Convert.ToInt32(item["Cod_Cliente"]))] =
                                valor[codigo.IndexOf(Convert.ToInt32(item["Cod_Cliente"]))] + Convert.ToDouble(item["Sld_Receber"]);
                        }
                    }
                    _dgv2.Invoke((MethodInvoker)delegate
                    {
                        _dgv2.Rows.Clear();
                        for (int preencher_Grid = 0; preencher_Grid < codigo.Count; preencher_Grid++)
                        {
                            _dgv2.Rows.Add(codigo[preencher_Grid], descricao[preencher_Grid], valor[preencher_Grid]);
                        }
                        _dgv2.Sort(_dgv2.Columns["Sld_Total"], ListSortDirection.Descending);
                        
                        //Adicionando gráfico do ranking
                        Adicionar_Grafico(dgvRanking);
                                                       
                        foreach (DataGridViewRow row in _dgv2.Rows)
                        {
                            row.Cells[2].Value = Convert.ToDouble(row.Cells[2].Value.ToString().Replace("R$", "")).ToString("C");
                        }
                    });


                }
                    }
            //MessageBox.Show(dTotalCar.ToString());
            //MessageBox.Show(dTotalCar.ToString("C"));
            txtCAR.Invoke((MethodInvoker)delegate { txtCAR.Text = dTotalCar.ToString("C"); });
            this.Invoke((MethodInvoker)delegate { this.Cursor = Cursors.Default; });
            


        }

        //Exportar relatório para excel
        private void BtnExportarCAR_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            exportarExcel();
            this.Cursor = Cursors.Default;
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (dtpDatCorte.Value != dtDat_Atualização) 
            {
                dtDat_Atualização = dtpDatCorte.Value;
                //lock(dgvDados)
                Filtrar_Dados(dgvDados,dgvRanking);                


            }
            //else if (!txtTitulo.Text.Equals(String.Empty))
            //{
            //    foreach (DataGridViewRow row in dgvDados.Rows)
            //    {
            //        if (row.Cells[4].Value.ToString().Contains(txtTitulo.Text))
            //        {
            //            row.Visible = true;
            //        }
            //        else
            //        {
            //            row.Visible = false;
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (DataGridViewRow row in dgvDados.Rows)
            //    {
            //        row.Visible = true;
            //    }

            //}
        }

        private void TxtTitulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPesquisar_Click(txtTitulo, new EventArgs());
            }
        }

        //Exportar gráfico
        private void BtnExportarGrafico_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(gRanking.Width, gRanking.Height);
            gRanking.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            SaveFileDialog salvarArquivo = new SaveFileDialog();

            salvarArquivo.FileName = "Ranking Top 10 CAR";
            salvarArquivo.DefaultExt = "*.png";
            salvarArquivo.Filter = "Documentos de imagem (*.png)|*.png| Todos os arquivos (*.*)|*.*";
            if (salvarArquivo.ShowDialog() == System.Windows.Forms.DialogResult.OK && salvarArquivo.FileName.Length > 0)
            {
                bmp.Save(salvarArquivo.FileName, ImageFormat.Png);
            }
        }
                                
        //Fechar com Esc
        private void frmContasAreceber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void btnInformacoesGerenciais_Click(object sender, EventArgs e)
        {
            frmCARinformacoesGerenceiais form = new frmCARinformacoesGerenceiais();                                       
            form.dgvContas_Receber = dgvDados;
            form.dtDat_Corte = dtpDatCorte.Value.Date;
            form.Unidade_Servidor = Unidade_Servidor;
            form.ShowDialog(); 

            

        }

        private void splitContainer4_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Fechar
        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
