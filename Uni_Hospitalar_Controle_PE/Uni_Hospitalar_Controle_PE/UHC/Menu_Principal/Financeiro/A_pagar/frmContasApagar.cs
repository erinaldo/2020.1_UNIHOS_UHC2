using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Ulib;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.A_pagar
{
    public partial class frmContasApagar : Form
    {
        public frmContasApagar()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlCommand command2 = new SqlCommand();

        private SqlDataReader reader;
        private SqlDataAdapter adaptador;
        //Erro sql
        private void erro_DeAcesso(SqlException SQLe)
        {
            mMessage = "Erro de acesso ao servidor: "+ SQLe.Message;
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
        private void frmContasApagar_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            configuracoes_Iniciais();
        }

        DataTable dt = new DataTable();      

        //Ranking
        List<String> lCliente = new List<String>();
        List<String> lValorTotal = new List<String>();
        
        //Auto complete
        AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();

        //Controle texto
        int iControleTexto =0;


        private void Autocomplete_Descricao()
        {            
                if (cbxTipoDaBusca.SelectedItem.ToString().Equals("Fornecedor"))
                {
                    //Carrega fornecedor
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText =
                                                  " SELECT Razao_Social FROM FORNE";
                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                autotext.Add(reader.GetString(0));
                            }
                            txtDescricao.AutoCompleteMode = AutoCompleteMode.Suggest;
                            txtDescricao.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            txtDescricao.AutoCompleteCustomSource = autotext;


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
                else if (cbxTipoDaBusca.SelectedItem.ToString().Equals("Favorecido"))
                {
                    //Carrega favorecido
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText =
                                                  " SELECT des_favore FROM favor";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                autotext.Add(reader.GetString(0));
                            }
                            txtDescricao.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            txtDescricao.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            txtDescricao.AutoCompleteCustomSource = autotext;

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
                else
                {
                    //Carrega transportadora
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText =
                                                  " SELECT Razao_Social FROM trans";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                autotext.Add(reader.GetString(0));
                            }
                            txtDescricao.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            txtDescricao.AutoCompleteSource = AutoCompleteSource.CustomSource;
                            txtDescricao.AutoCompleteCustomSource = autotext;

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
        
        private void configurar_Campos()
        {
            //Define ad ata do vencimento como a data inicial
            dtpDtVencInicial.Invoke((MethodInvoker) delegate { dtpDtVencInicial.Text = Convert.ToString(DateTime.Today); });
            dtpDtVencFinal.Invoke((MethodInvoker)delegate { dtpDtVencFinal.Text = Convert.ToString(DateTime.Today); });

            //Define a configuração inicial do cbxTipoDePesquisa
            cbxTipoDaBusca.Invoke((MethodInvoker)delegate
            {
                cbxTipoDaBusca.Items.Add("Favorecido");
                cbxTipoDaBusca.Items.Add("Fornecedor");
                cbxTipoDaBusca.Items.Add("Transportadora");
            });

            //Status valor

            chkValor.Invoke((MethodInvoker)delegate { habilitar_Valores(Convert.ToBoolean(chkValor.CheckState)); });
            //Status vencimento
            chkVencimento.Invoke ((MethodInvoker) delegate { Habilitar_Vencimento(Convert.ToBoolean(chkVencimento.CheckState)); });

            //Instancia do código e descrição do Forne,Favor ou Transp
            txtCodigo.Invoke((MethodInvoker)delegate { txtCodigo.Enabled = false; });
            txtDescricao.Invoke((MethodInvoker)delegate { txtDescricao.ReadOnly = true; });

        }

        private void configuracoes_Iniciais()
        {
            lock (dgvDados)
            {
                Task.Factory.StartNew(() => configurar_Grid(dgvDados,dgvRanking));
            }
            Task.Factory.StartNew(() => configurar_Campos());
            
            //Define a data do dia como data inicial
            dtpDatCorte.Text = Convert.ToString(DateTime.Today);
                       
        }
        //Define se pesquisa por valores está habilitada ou não
        
        private void habilitar_Valores(Boolean hab)
        {            
            mtxValorInicial.Enabled = hab;
            mtxValorFinal.Enabled = hab;
           if (hab == true)
            {
                mtxValorFinal.Text = 0.ToString("C");
                mtxValorInicial.Text = 0.ToString("C");
            }
            else
            {
                mtxValorFinal.Text = String.Empty;
                mtxValorInicial.Text = String.Empty;
            }
        }

        //Configurações do gráfico
        ChartValues<double> values = new ChartValues<double>();
        List<String> labels = new List<String>();
        private void Adicionar_Grafico()
        {
            gRanking.Series.Clear();
            gRanking.AxisX.Clear();
            gRanking.AxisY.Clear();
            values.Clear();
            labels.Clear();
            int x = 0;
            foreach (DataGridViewRow row in dgvRanking.Rows)
            {
                x++;
                values.Add(Convert.ToDouble(row.Cells[2].Value.ToString().Replace("R$ ","")));
                labels.Add(row.Cells[1].Value.ToString());                
                if (x == 10)
                {
                    break;
                }
            }

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
                
        }
       
        //Define se pesquisa por vencimento está habilitada ou não
        private void Habilitar_Vencimento(Boolean hab)
        {
            dtpDtVencInicial.Enabled = hab;
            dtpDtVencFinal.Enabled = hab;
        }


        //Inserir ou remover favorecido
        private void chkFavorecido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFavorecido.Checked == true)
            {
                cbxTipoDaBusca.Items.Add("Favorecido");
            }
            else
            {
                if (cbxTipoDaBusca.Text.ToString() == "Favorecido")
                {
                    cbxTipoDaBusca.SelectedItem = null;
                    cbxTipoDaBusca.Text = String.Empty;
                }
                cbxTipoDaBusca.Items.Remove("Favorecido");
               
            }
        }
        //Inserir ou remover fornecedor
        private void chkFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFornecedor.Checked == true)
            {
                cbxTipoDaBusca.Items.Add("Fornecedor");
                
            }
            else
            {
                if (cbxTipoDaBusca.Text.ToString() == "Fornecedor")
                {
                    cbxTipoDaBusca.SelectedItem = null;
                    cbxTipoDaBusca.Text = String.Empty;
                }
                cbxTipoDaBusca.Items.Remove("Fornecedor");
                
            }
        }
        //Inserir ou remover transportadora
        private void chkTransportadora_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTransportadora.Checked == true)
            {
                cbxTipoDaBusca.Items.Add("Transportadora");
            }
            else
            {
                if (cbxTipoDaBusca.Text.ToString() == "Transportadora")
                {
                    cbxTipoDaBusca.SelectedItem = null;

                    cbxTipoDaBusca.Text = String.Empty;

                }
                cbxTipoDaBusca.Items.Remove("Transportadora");
               
            }
        }

        //Define se pesquisa por valor é habilitado
        private void chkValor_CheckedChanged(object sender, EventArgs e)
        {
            habilitar_Valores(Convert.ToBoolean(chkValor.CheckState));
        }

        //Define se pesquisa por vencimento é habilitado
        private void chkVencimento_CheckedChanged(object sender, EventArgs e)
        {
            Habilitar_Vencimento(Convert.ToBoolean(chkVencimento.CheckState));
        }

        //Define se o a busca está ativada ou não (Cod fornecedor/transp/favor)
        private void cbxTipoDaBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTipoDaBusca.Text != String.Empty)
            {
                txtCodigo.Enabled = true;
                txtDescricao.Enabled = true;
                txtDescricao.ReadOnly = false;
                Autocomplete_Descricao();
            }
            else
            {
                txtCodigo.Enabled = false;
                txtDescricao.Enabled = false;
                txtDescricao.ReadOnly = true;
            }
            txtDescricao.Text = String.Empty;
            txtCodigo.Text = String.Empty;
        }
                     
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //dSomatorioCAP = 0;
            if (mtxValorInicial.Text.Trim().Equals(String.Empty) && !mtxValorFinal.Text.Trim().Equals(String.Empty))
            {
                mtxValorInicial.Text = mtxValorFinal.Text;
            }
            else if (!mtxValorInicial.Text.Trim().Equals(String.Empty) && mtxValorFinal.Text.Trim().Equals(String.Empty))
            {
                mtxValorFinal.Text = mtxValorInicial.Text;
            }


            filtrar_Dados_Analitico(dt,dgvDados);            
            this.Cursor = Cursors.Default;

        }

        


        private void filtrar_Dados_Analitico(DataTable _dt, DataGridView _dgv)
        {

            double val_min = 0;
            double val_max = 99999999999;

            DateTime dt_min = Convert.ToDateTime("01/01/1900");
            DateTime dt_max = Convert.ToDateTime("31/12/2500");



            if (chkValor.Checked)
            {
                val_min = Convert.ToDouble(mtxValorInicial.Text);
                val_max = Convert.ToDouble(mtxValorFinal.Text);
            }

            if (chkVencimento.Checked)
            {
                dt_min = dtpDtVencInicial.Value;
                dt_max = dtpDtVencFinal.Value;
            }

            var lista_Filtrada = from Conta_Receber in _dt.AsEnumerable()
                                 where 
                                        (Conta_Receber["Codigo"].ToString().Contains(txtCodigo.Text))
                                        && Convert.ToDouble(Conta_Receber["Valor_Principal"]) >= val_min
                                        && Convert.ToDouble(Conta_Receber["Valor_Principal"]) <= val_max
                                        && Convert.ToDateTime(Conta_Receber["Vencimento"]) >= dt_min
                                        && Convert.ToDateTime(Conta_Receber["Vencimento"]) <= dt_max
                                        && Conta_Receber["Duplicata"].ToString().Contains(txtTitulo.Text)
                                 select Conta_Receber;

            double soma = 0 ;
            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Rows.Clear();
                foreach (var item in lista_Filtrada)
                {
                    _dgv.Rows.Add(Convert.ToInt64(item["Codigo"]), item["Descricao_entidade"], item["Tipo_Entidade"], item["Duplicata"]
                                 , (item["Emissao"]), (item["Pagamento"])
                                 , (item["Vencimento"]), Convert.ToDouble(item["Valor_Principal"]).ToString("C"));
                    soma = soma + Convert.ToDouble(item["Valor_Principal"]);
                }
            });

            txtCAP.Text = soma.ToString("C");

            

        }
        private void filtrar_Dados_Sintetico(DataTable _dt, DataGridView _dgv)
        {
            
            List<int> codigo = new List<int>();
            List<string> descricao = new List<string>();
            List<double> valor = new List<double>();

            var lista_Filtrada = from Ranking in _dt.AsEnumerable()
                                 select Ranking;

            foreach (var item in lista_Filtrada)
            {
                if (!codigo.Contains(Convert.ToInt32(item["Codigo"])))
                {
                    codigo.Add(Convert.ToInt32(item["Codigo"]));
                    descricao.Add(item["Descricao_Entidade"].ToString());
                    valor.Add(Convert.ToDouble(item["Valor_Principal"]));
                }
                else
                {
                    valor[codigo.IndexOf(Convert.ToInt32(item["Codigo"]))] =
                        valor[codigo.IndexOf(Convert.ToInt32(item["Codigo"]))] + Convert.ToDouble(item["Valor_Principal"]);
                }
            }


            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Rows.Clear();
                for (int preencher_Grid = 0; preencher_Grid < codigo.Count; preencher_Grid++)
                {
                    _dgv.Rows.Add(codigo[preencher_Grid], descricao[preencher_Grid], valor[preencher_Grid]);
                }
                _dgv.Sort(_dgv.Columns["Valor_Total"], ListSortDirection.Descending);

                foreach (DataGridViewRow row in _dgv.Rows)
                {
                    row.Cells[2].Value = Convert.ToDouble(row.Cells[2].Value).ToString("C");
                }
            });
            
            Adicionar_Grafico();

        }

        private void configurar_Grid(DataGridView _dgvA,DataGridView _dgvB)
        {
            _dgvA.Invoke((MethodInvoker)delegate
           {
               _dgvA.Columns.Add("Codigo", "Cód. Entidade");
               _dgvA.Columns.Add("Descricao_entidade", "Entidade");
               _dgvA.Columns.Add("Tipo_Entidade", "Tipo");
               _dgvA.Columns.Add("Duplicata", "Duplicata");
               _dgvA.Columns.Add("Emissao", "Dat. Emissão");
               _dgvA.Columns.Add("Pagamento", "Dat. Pagamento");
               _dgvA.Columns.Add("Vencimento", "Dat. Vencimento");
               _dgvA.Columns.Add("Valor_Principal", "Vlr. Principal");
               _dgvA.Columns[0].Width = 60;
               _dgvA.Columns[1].Width = 380;
               _dgvA.Columns[2].Width = 80;
               _dgvA.Columns[3].Width = 80;
               _dgvA.Columns[4].Width = 80;
               _dgvA.Columns[5].Width = 80;
               _dgvA.Columns[6].Width = 80;
           });
            _dgvA.Invoke((MethodInvoker)delegate
            {
                _dgvB.Columns.Add("Codigo", "Cód. Entidade");
                _dgvB.Columns.Add("Descricao_entidade", "Entidade");                
                _dgvB.Columns.Add("Valor_Total", "Vlr. Total");
                _dgvB.Columns[0].Width = 60;
                _dgvB.Columns[1].Width = 380;
                _dgvB.Columns[2].Width = 100;
            });

        }

        private void carregar_Dados(DataTable dt)
        {
            dt.Clear();

            

            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();
                    command = connectDMD.CreateCommand();
                    command.CommandText =
                          " SELECT																						"
                        + " [Codigo] = 																					"
                        + " 		CASE ISNULL(CT.Cod_Fornec,0)															"
                        + " 		WHEN 0 THEN 																			"
                        + " 			CASE ISNULL(CT.Cod_Favore,0)														"
                        + " 			WHEN 0 THEN CT.Cod_Transp															"
                        + " 			ELSE CT.Cod_Favore																	"
                        + " 			END																					"
                        + " 		ELSE CT.Cod_Fornec																		"
                        + " 		END																						"
                        + " ,[Descricao_Entidade] = 																				"
                        + " 		CASE ISNULL(CT.Cod_Fornec,0)															"
                        + " 		WHEN 0 THEN 																			"
                        + " 			CASE ISNULL(CT.Cod_Favore,0)														"
                        + " 			WHEN 0 THEN Transportadora.Razao_Social												"
                        + " 			ELSE Favorecido.Des_Favore															"
                        + " 			END																					"
                        + " 		ELSE Fornecedor.Razao_Social															"
                        + " 		END																						"
                        + " ,[Tipo_Entidade] =																			"
                        + " 		CASE ISNULL(CT.Cod_Fornec,0)															"
                        + " 		WHEN 0 THEN 																			"
                        + " 			CASE ISNULL(CT.Cod_Favore,0)														"
                        + " 			WHEN 0 THEN 'Transportadora'														"
                        + " 			ELSE 'Favorecido'																	"
                        + " 			END																					"
                        + " 		ELSE 'Fornecedor'																		"
                        + " 		END																						"
                        + " 																								"
                        + " ,CT.Num_Docume					[Duplicata]													"
                        + " ,[Emissao]		= Convert(date, CT.Dat_Emissa)												"
                        + " ,[Pagamento]	= Convert(date,Dat_Quitac)		"
                        + " ,[Vencimento]	= Convert(date, Dat_Vencim) 													"
                        + " ,[Valor_Principal] = CT.Val_Docume														"
                        + " FROM PAGCT CT 																				"
                        + " LEFT JOIN FAVOR Favorecido ON Favorecido.Cod_Favore = CT.Cod_Favore							"
                        + " LEFT JOIN FORNE Fornecedor ON Fornecedor.Codigo = CT.Cod_Fornec								"
                        + " LEFT JOIN TRANS Transportadora ON Transportadora.Codigo = CT.Cod_Transp 						"
                        + " WHERE 																						"
                        + " (Sta_Docume NOT LIKE 'C' or Sta_Docume = 'C' AND Dat_Cancel > @Dat_Corte) 					"
                        + " AND(CT.Dat_Quitac > @Dat_Corte OR not (CT.Dat_Quitac <= @Dat_Corte and Sta_Docume = 'Q')) 	"
                        + " AND(CT.Dat_Registro <= @Dat_Corte AND Convert(date, Dat_Emissa) <= @DAT_CORTE)  				"
                        + " AND Num_Docume NOT LIKE '%P%'  																"
                        + " AND Tip_Documento not like 'OR'																"
                        ;

                    SqlParameter pDat_Corte = new SqlParameter("@Dat_Corte", SqlDbType.SmallDateTime);
                    pDat_Corte.Value = Convert.ToDateTime(dtpDatCorte.Text);
                    command.Parameters.Add(pDat_Corte);                    
                    adaptador = new SqlDataAdapter(command);
                    adaptador.Fill(dt);                    
                }
                catch (SqlException sqle)
                {
                    erro_DeAcesso(sqle);
                }
                finally
                {
                    connectDMD.Close();
                }
            }
        }
        
       

        //Valores com vírgula
        private void Valor_Com_Virgula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void BtnExportarCAP_Click(object sender, EventArgs e)
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
            worksheet.Name = "Contas à Pagar"; //Adicionando o nome a planilha
            //Identar tabela
            foreach (Excel.Worksheet wrkst in workbook.Worksheets)
            {
                Excel.Range usedrange = wrkst.UsedRange;
                usedrange.Columns.AutoFit();
            }
        }

        private void BtnExportarGrafico_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(gRanking.Width, gRanking.Height);
            gRanking.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            SaveFileDialog salvarArquivo = new SaveFileDialog();

            salvarArquivo.FileName = "Ranking Top 10 CAP";
            salvarArquivo.DefaultExt = "*.png";
            salvarArquivo.Filter = "Documentos de imagem (*.png)|*.png| Todos os arquivos (*.*)|*.*";
            if (salvarArquivo.ShowDialog() == System.Windows.Forms.DialogResult.OK && salvarArquivo.FileName.Length > 0)
            {
                bmp.Save(salvarArquivo.FileName, ImageFormat.Png);
            }
        }



        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmContasApagar_KeyDown(object sender, KeyEventArgs e)
        {            
                if (e.KeyValue.Equals(27))
                {
                    this.Close();
                }            
        }

        private void PesquisarComEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPesquisar_Click(btnPesquisar,new EventArgs());
            }
        }

        //Descrição
        private void TxtDescricao_TextChanged(object sender, EventArgs e)
        {
            if (iControleTexto == 1)
            {
                txtCodigo.Text = String.Empty;
                
                String comando = null;
                if (txtDescricao.Text != String.Empty)
                {
                    if (cbxTipoDaBusca.Text == "Fornecedor")
                    {
                        comando = "SELECT TOP 1 Codigo [Codigo] FROM DMD.[dbo].FORNE WHERE Razao_Social like '%"+ txtDescricao.Text+ "%'";
                    }
                    else if (cbxTipoDaBusca.Text == "Favorecido")
                    {
                        comando = "SELECT TOP 1 Cod_Favore [Codigo]FROM DMD.[dbo].FAVOR WHERE des_favore like '%"+ txtDescricao.Text+ "%'";
                    }
                    else if (cbxTipoDaBusca.Text == "Transportadora")
                    {
                        comando = "SELECT TOP 1  Codigo [Codigo] FROM DMD.[dbo].TRANS WHERE Razao_Social like '%" + txtDescricao.Text + "%'";
                    }
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                //Comando sql
                                command = new SqlCommand(comando, connectDMD);



                                connectDMD.Open();
                                reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    if (reader["Codigo"] != null) //Sendo o leitor diferente de nulo
                                    {
                                        txtCodigo.Text = reader["Codigo"].ToString();
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

        private void TxtDescricao_Enter(object sender, EventArgs e)
        {
            iControleTexto = 1;
        }

        //Código
        //Preenche o campo descrição de acordo com a descrição
        private void txtCod_TextChanged(object sender, EventArgs e)
        {
            if (iControleTexto == 2)
            {
                
                txtDescricao.Text = String.Empty;
                String comando = null;
                if (txtCodigo.Text != String.Empty)
                {
                    if (cbxTipoDaBusca.Text == "Fornecedor")
                    {
                        comando = "SELECT Razao_Social [Descricao] FROM DMD.[dbo].FORNE WHERE CODIGO ="+ txtCodigo.Text;
                    }
                    else if (cbxTipoDaBusca.Text == "Favorecido")
                    {
                        comando = "SELECT Des_Favore [Descricao]FROM DMD.[dbo].FAVOR WHERE Cod_Favore ="+ txtCodigo.Text;
                    }
                    else if (cbxTipoDaBusca.Text == "Transportadora")
                    {
                        comando = "SELECT Razao_Social [Descricao] FROM DMD.[dbo].TRANS WHERE Codigo ="+ txtCodigo.Text;
                    }
                    
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                //Comando sql
                                command = new SqlCommand(comando, connectDMD);



                                connectDMD.Open();
                                reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    if (reader["Descricao"] != null) //Sendo o leitor diferente de nulo
                                    {
                                        txtDescricao.Text = reader["Descricao"].ToString();
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
        private void TxtCodigo_Enter(object sender, EventArgs e)
        {
            iControleTexto = 2;
        }

        private void DtpDtVencInicial_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpDatCorte_ValueChanged(object sender, EventArgs e)
        {
            Task.WaitAny(Task.Factory.StartNew(() => carregar_Dados(dt)));
            filtrar_Dados_Analitico(dt,dgvDados);
            filtrar_Dados_Sintetico(dt,dgvRanking);
        }

        //Função para digitar somente números
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

    }
    
}
