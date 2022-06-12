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
using Excel = Microsoft.Office.Interop.Excel;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Recebimento.Recebimento_Publico
{
    public partial class frmRecebimentoPublicoPrivado : Form
    {
        public frmRecebimentoPublicoPrivado()
        {
            InitializeComponent();
        }


        //SQL
        private SqlCommand command = new SqlCommand();        
        private SqlDataReader reader;
        private SqlDataAdapter adaptador;
        
        //SQL Exception
        private void erro_DeAcesso(SqlException SQLe)
        {
            mMessage = "Erro de acesso ao servidor: " + SQLe.Message;
            mTittle = "SQL Server error";
            mButton = MessageBoxButtons.OK;
            mIcon = MessageBoxIcon.Error;
            MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            return;
        }

        //Variáveis de TextBox
        private String mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave

        //public int Unidade_Servidor;

        //Filtrar dados
        private void Filtrar_Dados()
        {            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                    String condicao_Grupo = "";
                    String condicao_Esfera = "";
                    String flagEstado = "";
                    String flagVendedor = "";


                    if (!txtDescGrpCliente.Text.Equals(String.Empty))
                    {
                        condicao_Grupo = " and CLIEN.Cod_GRPCLI = "+txtCodGrpCliente.Text;
                        
                    }

                    if (!chkPrivado.Checked) 
                    {
                        condicao_Esfera = " and CLIEN.Tipo_Consumidor in ('P','M','E') ";
                    }
                    else
                    {
                        condicao_Esfera = " and CLIEN.Tipo_Consumidor in ('F','N') ";
                    }
                    
                    
                    
                        

                        if (chkAC.Checked == true || chkAL.Checked == true || chkAP.Checked == true || chkAM.Checked == true || chkBA.Checked == true || chkCE.Checked == true ||
                           chkDF.Checked == true || chkES.Checked == true || chkGO.Checked == true || chkMA.Checked == true || chkMT.Checked == true || chkMS.Checked == true ||
                           chkMG.Checked == true || chkPA.Checked == true || chkPB.Checked == true || chkPE.Checked == true || chkPI.Checked == true || chkRJ.Checked == true ||
                           chkRJ.Checked == true || chkRN.Checked == true || chkRS.Checked == true || chkRO.Checked == true || chkRR.Checked == true || chkSC.Checked == true ||
                           chkSP.Checked == true || chkSE.Checked == true || chkTO.Checked == true)
                        {
                            flagEstado = " AND CLIEN.COD_ESTADO IN ( ";

                            if (chkAC.Checked == true)
                            {
                                flagEstado = flagEstado + "'AC',";
                            }
                            if (chkAL.Checked == true)
                            {
                                flagEstado = flagEstado + "'AL',";
                            }
                            if (chkAP.Checked == true)
                            {
                                flagEstado = flagEstado + "'AP',";
                            }
                            if (chkAM.Checked == true)
                            {
                                flagEstado = flagEstado + "'AM',";
                            }
                            if (chkBA.Checked == true)
                            {
                                flagEstado = flagEstado + "'BA',";
                            }
                            if (chkCE.Checked == true)
                            {
                                flagEstado = flagEstado + "'CE',";
                            }
                            if (chkDF.Checked == true)
                            {
                                flagEstado = flagEstado + "'DF',";
                            }
                            if (chkES.Checked == true)
                            {
                                flagEstado = flagEstado + "'ES',";
                            }
                            if (chkGO.Checked == true)
                            {
                                flagEstado = flagEstado + "'GO',";
                            }
                            if (chkMA.Checked == true)
                            {
                                flagEstado = flagEstado + "'MA',";
                            }
                            if (chkMT.Checked == true)
                            {
                                flagEstado = flagEstado + "'MT',";
                            }
                            if (chkMS.Checked == true)
                            {
                                flagEstado = flagEstado + "'MS',";
                            }
                            if (chkMG.Checked == true)
                            {
                                flagEstado = flagEstado + "'MG',";
                            }
                            if (chkPA.Checked == true)
                            {
                                flagEstado = flagEstado + "'PA',";
                            }
                            if (chkPB.Checked == true)
                            {
                                flagEstado = flagEstado + "'PB',";
                            }
                            if (chkPE.Checked == true)
                            {
                                flagEstado = flagEstado + "'PE',";
                            }
                            if (chkPI.Checked == true)
                            {
                                flagEstado = flagEstado + "'PI',";
                            }
                            if (chkRJ.Checked == true)
                            {
                                flagEstado = flagEstado + "'RJ',";
                            }
                            if (chkRN.Checked == true)
                            {
                                flagEstado = flagEstado + "'RN',";
                            }
                            if (chkRS.Checked == true)
                            {
                                flagEstado = flagEstado + "'RS',";
                            }
                            if (chkRO.Checked == true)
                            {
                                flagEstado = flagEstado + "'RO',";
                            }
                            if (chkRR.Checked == true)
                            {
                                flagEstado = flagEstado + "'RR',";
                            }
                            if (chkSC.Checked == true)
                            {
                                flagEstado = flagEstado + "'SC',";
                            }
                            if (chkSP.Checked == true)
                            {
                                flagEstado = flagEstado + "'SP',";
                            }
                            if (chkSE.Checked == true)
                            {
                                flagEstado = flagEstado + "'SE',";
                            }
                            if (chkTO.Checked == true)
                            {
                                flagEstado = flagEstado + "'TO',";
                            }

                            flagEstado = flagEstado + "'NOTHING')";

                        }




                        if (!txtCod_Vendedor.Text.Equals(String.Empty))
                        {
                            flagVendedor = "and VENDE.CODIGO = " + txtCod_Vendedor.Text;
                        }

                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText =
                             " SELECT 	DISTINCT                                                                                                                                                                                           "
                            + " [UF] = CLIEN.Cod_Estado                                                                                                                                                                                      "
                            + " ,Dat_Caixa[Data de Pagamento]                                                                                                                                                                                "
                            + " ,Dat_Emissao    [Dat. Emissão]           "
                            + " ,CTREC.Cod_Cliente[Código]                                                                                                                                                                                   "
                            + " ,CLIEN.Razao_Social[Razão Social]                                                                                                                                                                             "
                            + " ,VENDE.Codigo [Código vendedor]                                                                                                                                                                         "
                            + " ,VENDE.Nome_Guerra[Desc.Vendedor]                                                                                                                                                                            "
                            + " ,CTREC.Num_NfOrigem[NF]                                                                                                                                                                                      "
                            + " ,REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((Sum(BXREC.Vlr_Principal)) AS money), 1), ',', '_'), '.', ','), '_', '.') AS[Vlr.Principal]                                                                   "
                            + " ,REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((ISNULL(Sum(BXREC.Vlr_Deducoes + BXREC.Vlr_Desconto), 0)) AS money), 1), ',', '_'), '.', ','), '_', '.') AS[Vlr.Desconto]                                     "
                            + " ,REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((Sum(BXREC.Vlr_Principal) - ISNULL(Sum(BXREC.Vlr_Deducoes + BXREC.Vlr_Desconto), 0)) AS money), 1), ',', '_'), '.', ','), '_', '.') AS[Vlr.Recebimento]       "
                            + " FROM BXREC                                                                                                                                                                                                   "
                            + " INNER JOIN CTREC ON BXREC.Cod_Documento = CTREC.Cod_Documento                                                                                                                                                "
                            + " INNER JOIN CLIEN ON CTREC.Cod_Cliente = CLIEN.Codigo                                                                                                                                                         "
                            + " INNER JOIN LANCB ON(LANCB.Cod_Lancam = BXREC.Cod_LanDep) OR(LANCB.Cod_Lancam = BXREC.Cod_CabLanFin)                                                                                                          "
                            + " INNER JOIN CTPAR ON CTPAR.Cod_CtaPar = LANCB.Cod_CtaPar                                                                                                                                                      "
                            + " INNER JOIN VENDE ON VENDE.CODIGO = CTREC.Cod_Vendedor                                                                                                                                                        "
                            + " INNER JOIN DMD.[dbo].GRCLI  ON GRCLI.Cod_GrpCli = CLIEN.Cod_GrpCli                                                                                                                                           "
                            + " WHERE                                                                                                                                                                                                        "
                            + " CTREC.Status = 'Q'                                                                                                                                                                                           "
                            + " AND (BXREC.Dat_Caixa BETWEEN @DAT_INICIAL AND @DAT_FINAL)       "                            
                            + condicao_Grupo
                            + flagEstado
                            + flagVendedor
                            + condicao_Esfera
                            + " GROUP BY CLIEN.Cod_Estado, Dat_Caixa,CTREC.Cod_Cliente,CLIEN.Razao_Social,VENDE.Nome_Guerra,CTREC.Num_NfOrigem,vende.codigo,Dat_Emissao"
                           ;
                        command.Parameters.AddWithValue("Dat_Inicial", Convert.ToDateTime(dtpDataInicial.Value));
                        command.Parameters.AddWithValue("Dat_Final", Convert.ToDateTime(dtpDataFinal.Value));
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

        //Parâmetros iniciais
        private void Parametros_Iniciais()
        {


            DateTime primeiroDiaDoMes = DateTime.Now;
            DateTime ultimoDiaDoMes     = DateTime.Now;

            if (DateTime.Now.Month == 1)
            {
                primeiroDiaDoMes = Convert.ToDateTime("01-01-"+DateTime.Now.Year);
                ultimoDiaDoMes = Convert.ToDateTime("31-01-" + DateTime.Now.Year);
            }
            else
            {
                primeiroDiaDoMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, 1);
                ultimoDiaDoMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month - 1));
            }

            dtpDataInicial.Value = primeiroDiaDoMes;
            dtpDataFinal.Value = ultimoDiaDoMes;
        }
                
        //Load do form
        private void frmRecebimentoPublicoPrivado_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;            
            Parametros_Iniciais();
            //Filtrar_Dados();

        }

        //Filtro de VENDEDOR por código 
        private void txtCod_Vendedor_TextChanged(object sender, EventArgs e)
        {
            txtVendedor.Clear();
            if (!txtCod_Vendedor.Text.Trim().Equals(String.Empty))
            {               
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT Nome_Guerra FROM DMD.[dbo].VENDE WHERE CODIGO = " + (txtCod_Vendedor.Text);

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Nome_Guerra"] != null)
                                {
                                    txtVendedor.Text = reader["Nome_Guerra"].ToString();
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
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Filtrar_Dados();
        }

      

        //Filtro de UF por código
        private void txtUF_TextChanged(object sender, EventArgs e)
        {

            Filtrar_Dados();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            exportarExcel();
        }

        //Função para digitar somente números
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
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

        private void Nova_Pesquisa(object sender, EventArgs e)
        {
            Filtrar_Dados();
        }

                //Marcação
        private void alterar_Marcacao(CheckBox chk, Boolean status)
        {
            chk.Invoke((MethodInvoker)delegate { chk.Checked = status; });
        }




        private void chkMarcarTodos_CheckedChanged(object sender, EventArgs e)
        {
            List<Task> tList = new List<Task>();
            


            if (chkMarcarTodos.Checked == true)
            {
                Task.Factory.StartNew(() => alterar_Marcacao(chkAC, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAL, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAC, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAL, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAP, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAM, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkBA, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkCE, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkDF, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkES, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkGO, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMA, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMT, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMS, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMG, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPA, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPB, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPE, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPI, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRJ, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRN, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRS, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRO, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRR, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkSC, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkSP, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkSE, true));
                Task.Factory.StartNew(() => alterar_Marcacao(chkTO, true));
                Task.WaitAll();



            }
            else
            {
                Task.Factory.StartNew(() => alterar_Marcacao(chkAC, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAL, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAC, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAL, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAP, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkAM, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkBA, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkCE, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkDF, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkES, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkGO, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMA, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMT, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMS, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkMG, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPA, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPB, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPE, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkPI, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRJ, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRN, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRS, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRO, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkRR, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkSC, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkSP, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkSE, false));
                Task.Factory.StartNew(() => alterar_Marcacao(chkTO, false));
                Task.WaitAll();
            }

        }

        private void btnPreencherVendedor_Click(object sender, EventArgs e)
        {
            //Apontado para o CI da aba logísitica
            frmConsultarVendedor form = new frmConsultarVendedor();
            form.ShowDialog();
            if (form.Cod_Vendedor != 0)
                txtCod_Vendedor.Text = Convert.ToString(form.Cod_Vendedor);

        }

        //Fechar com esc
        private void frmRecebimentoPublicoPrivado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void codGrpCliente_TextChanged(object sender, EventArgs e)
        {
            if (!txtCodGrpCliente.Text.Equals(String.Empty))
            {
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = "SELECT Des_GrpCli FROM GRCLI WHERE Cod_GrpCli = " + (txtCodGrpCliente.Text);

                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Des_GrpCli"] != null)
                            {
                                txtDescGrpCliente.Text = reader["Des_GrpCli"].ToString();
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
            worksheet.Name = "Recebimento"; //Adicionando o nome a planilha
            //Identar tabela
            foreach (Excel.Worksheet wrkst in workbook.Worksheets)
            {
                Excel.Range usedrange = wrkst.UsedRange;
                usedrange.Columns.AutoFit();
            }
        }
    }
}
