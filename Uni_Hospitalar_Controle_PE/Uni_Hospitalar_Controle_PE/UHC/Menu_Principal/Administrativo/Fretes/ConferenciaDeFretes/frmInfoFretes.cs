using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;
using System.Drawing.Imaging;
using Ulib;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Fretes.ConferenciaDeFretes
{
    public partial class frmInfoFretes : Form
    {
        public frmInfoFretes()
        {
            InitializeComponent();
        }

        public int Unidade_Servidor;
        public String user_Login;

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
               

        private void Filtrar_Analitico()
        {            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {

                    String filtro_NF = null;
                    String filtro_CTR = null;
                    String filtro_Transportadora = null;
                    String filtro_Data = null;

                    if (!txtTransportadora.Text.Equals(String.Empty))
                    {
                        filtro_Transportadora = " AND CONF.COD_TRANSPORTADORA = " + txtCodTransportadora.Text;
                    }

                    if (!txtNota.Text.Equals(String.Empty))
                    {
                        filtro_NF = " AND CONF.  " +
                            "Num_Nota like '%" + txtNota.Text + "%'";
                    }

                    if (!txtCTR.Text.Equals(String.Empty))
                    {
                        filtro_CTR = " AND CONF.Num_CTR like '%" + txtCTR.Text + "%'";
                    }

                    if (cbxParamData.Text == "Data Emissão" || cbxParamData.SelectedItem.ToString().Equals("Data Emissão"))                        
                    {
                        filtro_Data = " (NSCB.Dat_Emissao BETWEEN @DAT_INICIAL AND @DAT_FINAL  ";
                    }
                    else
                    {
                        filtro_Data = " (CONF.Data_Cadastro BETWEEN @DAT_INICIAL AND @DAT_FINAL  ";
                    }



                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText =
                          "   SELECT                                                                                             "
                         +"   CONF.Num_Nota[Num.Nota]                                                                           "
                         +"  ,CONF.Num_CTR[CTR]                                                                                 "
                         +"  ,NSCB.Dat_Emissao[Dat.Emissão]                                                                     "
                         +"  ,CONF.Cod_Transportadora[Cod.Transportadora]                                                       "
                         +"  ,TRSP.Razao_Social[Transportadora]                                                                 "
                         +"  ,[Cidade] =                                                                                        "
                         +"  CASE NSCB.Cidade                                                                                   "
                         +"  WHEN NULL THEN NECB.Cidade                                                                         "
                         +"  ELSE NSCB.Cidade                                                                                   "
                         +"  END                                                                                                "
                         +"  ,[Estado] =                                                                                        "
                         +"  CASE NSCB.Estado                                                                                   "
                         +"  WHEN NULL THEN NECB.Cod_UfOrigem                                                                   "
                         +"  ELSE NSCB.Estado                                                                                   "
                         +"  END                                                                                                "
                         +"                                                                                                     "
                         +"  ,[Vlr.NF] =                                                                                        "
                         +"  CASE NSCB.Vlr_TotalNota                                                                            "
                         +"  WHEN NULL THEN NECB.Vlr_Nota                                                                       "
                         +"  ELSE NSCB.Vlr_TotalNota                                                                            "
                         +"  END                                                                                                "
                         +"  ,CONF.Observacao[Observação]                                                                       "
                         +"  ,CONF.Vlr_Frete_Calculado[Vlr.Uni]                                                                 "
                         +"  ,CONF.Vlr_Frete_Real[Vlr.Transp]                                                                   "
                         +"  ,CONF.Vlr_Frete_Calculado - Vlr_Frete_Real[Equivalência]                                           "
                         +" FROM[UNIDB].dbo.[CONFERENCIA_FRETES] CONF                                                           "
                         +" LEFT JOIN[DMD].dbo.[NFSCB]          NSCB ON NSCB.Num_Nota = CONF.Num_Nota                           "
                         +" LEFT JOIN[DMD].dbo.[NFECB]          NECB ON NECB.Numero = CONF.Num_Nota AND NECB.Tip_NF = 'D'       "
                         +" JOIN[DMD].dbo.[TRANS]                TRSP ON TRSP.Codigo = CONF.Cod_Transportadora                  "
                         +" WHERE" 
                         + filtro_Data                         
                         +" OR NECB.Dat_Emissao BETWEEN @DAT_INICIAL AND @DAT_FINAL)                                            "
                         + filtro_Transportadora
                         + filtro_NF
                         + filtro_CTR
                         ;


                        //Parâmetro Data inicial
                        SqlParameter parametroInicial = new SqlParameter("@DAT_INICIAL", SqlDbType.SmallDateTime);
                        parametroInicial.Value = dtpDtInicial.Text;
                        command.Parameters.Add(parametroInicial);

                        //Parâmetro Data inicial
                        SqlParameter parametroFinal = new SqlParameter("@dat_final", SqlDbType.DateTime);
                        parametroFinal.Value = (dtpDtFinal.Value.AddHours(23).AddMinutes(59).AddSeconds(59)).ToString();
                        command.Parameters.Add(parametroFinal);






                        adaptador = new SqlDataAdapter(command);
                        System.Data.DataTable tableDados = new System.Data.DataTable();
                        adaptador.Fill(tableDados);
                        dgvAnalitico.DataSource = tableDados;

                    }
                    catch (SqlException SQLe)
                    {
                        erroSQLE(SQLe);
                    }
                    finally
                    {
                        connectDMD.Close();
                        double SomaValor = 0.0;
                        foreach (DataGridViewRow row in dgvAnalitico.Rows)
                        {
                            SomaValor = SomaValor + Convert.ToDouble(row.Cells[10].Value);
                        }
                        txtTotalFrete.Text = SomaValor.ToString("C");
                    }


                }                       
        }
        private void Filtrar_Sintetico()
        {

            string filtro_Data = null;
            if (cbxParamData.Text == "Data Emissão" || cbxParamData.SelectedItem.ToString().Equals("Data Emissão"))
            {
                filtro_Data = " (NSCB.Dat_Emissao BETWEEN @DAT_INICIAL AND @DAT_FINAL                                                 "
                            + "     OR NECB.Dat_Emissao BETWEEN @DAT_INICIAL AND @DAT_FINAL)                                          ";
            }
            else
            {
                filtro_Data = " (CONF.Data_Cadastro BETWEEN @DAT_INICIAL AND @DAT_FINAL)  ";
            }
            
                gFreteXTransportadora.Series["Valor Frete"].Points.Clear();
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText =
                         " SELECT                                                                                                "
                        + "  CONF.Cod_Transportadora[Cod.Transportadora]                                                          "
                        + " ,TRSP.Razao_Social[Transportadora]                                                                    "
                        + " ,[Vlr.Total] = sum(conf.Vlr_Frete_Real)                                                               "
                        + " FROM[UNIDB].dbo.[CONFERENCIA_FRETES] CONF                                                             "
                        + " LEFT JOIN[DMD].dbo.[NFSCB]          NSCB ON NSCB.Num_Nota = CONF.Num_Nota                             "
                        + " LEFT JOIN[DMD].dbo.[NFECB]          NECB ON NECB.Numero = CONF.Num_Nota AND NECB.Tip_NF = 'D'         "
                        + " JOIN [DMD].dbo.[TRANS]                TRSP ON TRSP.Codigo = CONF.Cod_Transportadora                    "
                        + " WHERE                                                                                                  "
                        + filtro_Data
                        + " GROUP BY                                                                                              "
                        + " CONF.Cod_Transportadora                                                                               "
                        + ",TRSP.Razao_Social                                                                                     "
                            ;



                        //Parâmetro Data inicial
                        SqlParameter parametroInicial = new SqlParameter("@DAT_INICIAL", SqlDbType.SmallDateTime);
                        parametroInicial.Value = dtpDtInicial.Text;
                        command.Parameters.Add(parametroInicial);

                        //Parâmetro Data inicial
                        SqlParameter parametroFinal = new SqlParameter("@DAT_FINAL", SqlDbType.DateTime);
                        parametroFinal.Value = (dtpDtFinal.Value.AddHours(23).AddMinutes(59).AddSeconds(59)).ToString();
                        command.Parameters.Add(parametroFinal);






                        adaptador = new SqlDataAdapter(command);
                        System.Data.DataTable tableDados = new System.Data.DataTable();
                        adaptador.Fill(tableDados);
                        dgvSintetico.DataSource = tableDados;

                    }
                    catch (SqlException SQLe)
                    {
                        erroSQLE(SQLe);
                    }
                    finally
                    {
                        connectDMD.Close();
                        foreach (DataGridViewRow row in dgvSintetico.Rows)
                        {
                            gFreteXTransportadora.Series["Valor Frete"].Points.AddXY(row.Cells[1].Value.ToString(), Convert.ToDouble(row.Cells[2].Value.ToString()));
                        }
                    }


                }
                        
        }

      

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Filtrar_Analitico();
            Filtrar_Sintetico();
            this.Cursor = Cursors.Default;
        }

        private void frmInfoFretes_Load(object sender, EventArgs e)
        {
             this.Icon = Properties.Resources.Icon_Uni;

            dtpDtInicial.Value = DateTime.Now.AddDays(-15);
            dtpDtFinal.Value = DateTime.Now;

            Filtrar_Analitico();
            Filtrar_Sintetico(); 
            gFreteXTransportadora.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            gFreteXTransportadora.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            //gFreteXTransportadora.Series.Add("Valor Frete");
        }

        //Alimentar transportadora
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

            
        }

        private void btnProcurarTransportadora_Click(object sender, EventArgs e)
        {

            frmCriarCi_EscolherTransportadora form = new frmCriarCi_EscolherTransportadora();
            
            form.ShowDialog();
            if (form.cod_transportadora != 0)
                txtCodTransportadora.Text = Convert.ToString(form.cod_transportadora);
        }

        private void txtCTR_TextChanged(object sender, EventArgs e)
        {
            //Filtrar_Analitico();
        }

        private void txtTransportadora_TextChanged(object sender, EventArgs e)
        {
            if (!txtTransportadora.Text.Equals(String.Empty))
            {
                Filtrar_Analitico();
            }
        }

        
       //btnExcel para Excel 
        private void btnExcel_Click(object sender, EventArgs e)
        {
            exportarExcel();
        }

        

        //Exportar Excel
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
            CopyToClipboardWithHeaders(dgvSintetico);
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
            abaEstoque.Name = "Sintético"; //Adicionando o nome a planilha


            var xlSheets = MapaChiesi.Sheets as Excel.Sheets;
            var abaDemanda = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
            abaDemanda.Name = "Analítico";
            abaDemanda = (Excel.Worksheet)MapaChiesi.Worksheets.get_Item(1);
            CopyToClipboardWithHeaders(dgvAnalitico);
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


        //btnGrafico exporta a imagem do gráfico.
        private void btnGrafico_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(gFreteXTransportadora.Width, gFreteXTransportadora.Height);
            gFreteXTransportadora.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height));

            SaveFileDialog salvarArquivo = new SaveFileDialog();

            salvarArquivo.FileName = "Gráfico - Frete x Transportadoras";
            salvarArquivo.DefaultExt = "*.png";
            salvarArquivo.Filter = "Documentos de imagem (*.png)|*.png| Todos os arquivos (*.*)|*.*";
            if (salvarArquivo.ShowDialog() == System.Windows.Forms.DialogResult.OK && salvarArquivo.FileName.Length > 0)
            {
                bmp.Save(salvarArquivo.FileName, ImageFormat.Png);
            }
        }

        private void txtNota_TextChanged(object sender, EventArgs e)
        {
            // Filtrar_Analitico();
        }






        //Não permite caracteres, apenas números
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }

         
        }

        private void txtNota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Cursor = Cursors.WaitCursor;
                Filtrar_Analitico();
                this.Cursor = Cursors.Default;
            }
        }

        private void txtCTR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Cursor = Cursors.WaitCursor;
                Filtrar_Analitico();
                this.Cursor = Cursors.Default;
            }
        }

        //Exportar para XLS ou XLSX        
        public void exportar_ParaExcel(string _nomeArquivo, DataGridView _dgv)
        {
            SaveFileDialog salvar = new SaveFileDialog();
            Excel.Application App; // Aplicação Excel 
            Excel.Workbook WorkBook; // Pasta 
            Excel.Worksheet WorkSheet; // Planilha 
            object misValue = System.Reflection.Missing.Value;

            App = new Excel.Application();
            WorkBook = App.Workbooks.Add(misValue);
            WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0;

            for (int c = 1; c < _dgv.Columns.Count + 1; c++)
            {
                WorkSheet.Cells[1, c] = _dgv.Columns[c - 1].HeaderText;
            }

            // passa as celulas do DataGridView para a Pasta do Excel 
            for (i = 0; i <= _dgv.RowCount - 1; i++)
            {

                for (j = 0; j <= _dgv.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = _dgv[j, i];
                    WorkSheet.Cells[i + 2, j + 1] = cell.Value;
                }
            }

            // define algumas propriedades da caixa salvar 
            salvar.Title = _nomeArquivo;
            salvar.Filter = "Arquivo do Excel *.xls | *.xls |Arquivo do Excel *.xlsx | *.xlsx";
            salvar.FilterIndex = 2;
            salvar.ShowDialog(); // mostra 

            if (!salvar.FileName.Equals(String.Empty))
            {
                //Salvar como XLSX
                if (salvar.FilterIndex == 2)
                {
                    WorkBook.SaveAs(salvar.FileName, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue,

                              Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                    WorkBook.Close(true, misValue, misValue);
                    App.Quit(); // encerra o excel 
                }
                //Salvar como XLS
                else
                {
                    // salva o arquivo 
                    WorkBook.SaveAs(salvar.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,

                    Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                    WorkBook.Close(true, misValue, misValue);
                    App.Quit(); // encerra o excel                     
                }
                mMessage = "Arquivo salvo com sucesso!";
                mTittle = "Klassifis Information";
                mIcon = MessageBoxIcon.Information;
                mButton = MessageBoxButtons.OK;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            }



        }



        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            mMessage = "Deseja exportar o analítico?";
            mTittle = "Exportar arquivivo";
            mButton = MessageBoxButtons.YesNo;
            mIcon = MessageBoxIcon.Question;
            DialogResult result = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            if (result == DialogResult.Yes)
            {
                exportar_ParaExcel("Analítico " + DateTime.Now, dgvAnalitico);
            }

            mMessage = "Deseja exportar o analítico?";
            mTittle = "Exportar arquivivo";
            mButton = MessageBoxButtons.YesNo;
            mIcon = MessageBoxIcon.Question;
            result = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            if (result == DialogResult.Yes)
            {
                exportar_ParaExcel("Sintético " + DateTime.Now, dgvSintetico);
            }
            
        }


        //Fechar com ESC
        private void frmNewConferenciaFretes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }



    }
}
