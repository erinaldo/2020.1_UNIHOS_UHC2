using System;

using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Excel = Microsoft.Office.Interop.Excel;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Recebimento.Contas_Recebidas
{
    public partial class frmContasRecebidas : Form
    {
        public frmContasRecebidas()
        {
            InitializeComponent();
        }


        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataAdapter adaptador;

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

        public int Unidade_Servidor;

        private void FrmContasRecebidas_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            dtpDataInicial.Value = DateTime.Now.AddDays(-30);
            dtpDataFinal.Value = DateTime.Now;
            Filtrar_Dados();
        }

        private void DtpDataInicial_ValueChanged(object sender, EventArgs e)
        {
            Filtrar_Dados();
        }

        private void DtpDataFinal_ValueChanged(object sender, EventArgs e)
        {
            Filtrar_Dados();
        }

        private void btnExportar_Click(object sender, EventArgs e)
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
            abaEstoque.Name = "Contas recebidas"; //Adicionando o nome a planilha

            //Identar tabela
            foreach (Excel.Worksheet wrkst in MapaChiesi.Worksheets)
            {
                Excel.Range usedrange = wrkst.UsedRange;
                usedrange.Columns.AutoFit();
            }
        }

        private void Filtrar_Dados()
        {            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = "SELECT 	DISTINCT 		" +
                            "CTREC.Num_NfOrigem		[NF]        		" +
                            ",CTREC.Cod_Cliente		[Cód. Cliente]        		" +
                            ",CLIEN.Razao_Social		[Cliente Razão]         		" +
                            ",CLIEN.Fantasia			[Cliente Fantasia]        		" +
                            ",CTREC.num_Documento	[Num. Documento]        		" +
                            ",CTREC.Par_Documento	[Par. Documento]        		" +
                            ",CTREC.Dat_Emissao		[Dat. Emissao]        		" +
                            ",CTREC.Dat_Vencimento	[Dat. Vencimento]       		" +
                            ",CTREC.Status			[Status CT]       		" +
                            ",CTREC.Tip_Documento	[Tip. Documento CT]      		" +
                            ",BXREC.Dat_Caixa		[Dat. Caixa]      		" +
                            ",BXREC.Status			[Status BX]      		" +
                            ",CTREC.Cod_Agente		[Cod. Agente]       		" +
                            ",BXREC.Tip_Doc			[Tip. Documento BX]     		" +
                            ",CTREC.Observacao		[Observação]     		" +
                            ",REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((CTREC.vlr_partit) AS money), 1),',', '_'), '.', ','), '_', '.')	[Vlr. Par. Tít.]   		" +
                            ",REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((CTREC.Vlr_Documento) AS money), 1),',', '_'), '.', ','), '_', '.')	[Vlr. Documento]      		" +
                            ",REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((CTREC.Vlr_OutAcr) AS money), 1),',', '_'), '.', ','), '_', '.')	[z. Out. Acr.]     		" +
                            ",REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((BXREC.vlr_juros) AS money), 1),',', '_'), '.', ','), '_', '.')		[Vlr. Juros]    		" +
                            ",REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((CTREC.vlr_Saldo) AS money), 1),',', '_'), '.', ','), '_', '.')		[Vlr. Saldo]			" +
                            ",CTPAR.Des_CtaPar [Des. Cta. Par.]    		" +
                            ",CTREC.Cod_Barra		[Cod. Barra]    		" +
                            ",REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((Sum(BXREC.Vlr_Principal)) AS money), 1),',', '_'), '.', ','), '_', '.') AS [Vlr. Principal]       		" +
                            ",REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((Sum(BXREC.Vlr_Juros)) AS money), 1),',', '_'), '.', ','), '_', '.') AS [BX Vlr. Juros]        " +
                            ",REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((Sum(BXREC.Sld_Principal)) AS money), 1),',', '_'), '.', ','), '_', '.') AS [Sld. Principal]     		" +
                            ",REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((Sum(BXREC.Vlr_Deducoes + BXREC.Vlr_Desconto)) AS money), 1),',', '_'), '.', ','), '_', '.') AS [Vlr. Outros] " +
                            "FROM BXREC INNER JOIN CTREC ON BXREC.Cod_Documento = CTREC.Cod_Documento " +
                            "INNER JOIN CLIEN ON CTREC.Cod_Cliente = CLIEN.Codigo " +
                            "INNER JOIN LANCB ON (LANCB.Cod_Lancam = BXREC.Cod_LanDep) OR (LANCB.Cod_Lancam = BXREC.Cod_CabLanFin) " +
                            "INNER JOIN CTPAR ON CTPAR.Cod_CtaPar = LANCB.Cod_CtaPar " +
                            "WHERE BXREC.Dat_Caixa BETWEEN @dat_inicial-1 and @dat_final+1 " +
                            "GROUP BY CTREC.Num_NfOrigem,          " +
                            "CTREC.Cod_Cliente,           " +
                            "CLIEN.Razao_Social,         " +
                            "CLIEN.Fantasia,         " +
                            "CTREC.num_Documento,         " +
                            "CTREC.Par_Documento,        " +
                            " CTREC.Dat_Emissao,         " +
                            "CTREC.Dat_Vencimento,         " +
                            "CTREC.Status,         " +
                            "CTREC.Tip_Documento,         " +
                            "BXREC.Dat_Caixa,         " +
                            "BXREC.Status,         " +
                            "CTREC.Cod_Agente,         " +
                            "BXREC.Tip_Doc,         " +
                            "CTREC.Observacao,         " +
                            "CTREC.vlr_partit,         " +
                            "CTREC.Vlr_Documento,         " +
                            "CTREC.Vlr_OutAcr,         " +
                            "BXREC.vlr_juros,         " +
                            "CTREC.vlr_Saldo,         " +
                            "CTPAR.Des_CtaPar,         " +
                            "CTREC.Cod_Barra " +
                            "ORDER BY " +
                            "CTREC.Num_NfOrigem,        " +
                            "CTREC.Dat_Emissao";
                        command.Parameters.AddWithValue("Dat_Inicial", Convert.ToDateTime(dtpDataInicial.Value));
                        command.Parameters.AddWithValue("Dat_Final", Convert.ToDateTime(dtpDataFinal.Text.Trim()));
                        adaptador = new SqlDataAdapter(command);
                        DataTable tableDados = new DataTable();
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

    }
}
