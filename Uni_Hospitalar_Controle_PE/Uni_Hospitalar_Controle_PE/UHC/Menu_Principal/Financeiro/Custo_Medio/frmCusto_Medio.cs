using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;
using Ulib;
using System.Threading.Tasks;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Custo_Medio
{
    public partial class frmCusto_Medio : Form
    {
        public frmCusto_Medio()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlCommand command_2 = new SqlCommand();
        private SqlDataReader reader,reader_2;        


        
        
        


        
        //Erro sql
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
        

        //Autocomplete utilizado para sugerir os produtos ao serem digitados, essa variável é utilizada no método autocomplete_Produtos
        AutoCompleteStringCollection dadosProdutos = new AutoCompleteStringCollection();

        //Threads
        //Thread tAnalitico,tSintetico;

        //Load do form
        private void frmCusto_Medio_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            
            configuracoes_Iniciais();
        }

        //Carregar CFOPs
        private void carregar_CFOPs(CheckedListBox _clb)
        {

            _clb.Invoke((MethodInvoker)delegate
           {
               using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
               {
                   try
                   {
                       connectDMD.Open();

                       command = connectDMD.CreateCommand();
                       command.CommandText = "SELECT Distinct Cod_CFOP FROM [UNIDB].dbo.[CUSTO_MEDIO] ORDER BY Cod_CFOP DESC";

                       reader = command.ExecuteReader();

                       while (reader.Read())
                       {
                           if (reader["Cod_CFOP"] != null)
                           {
                               _clb.Items.Add(reader["Cod_CFOP"].ToString());
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
                       for (int x = 0; x < clbCFOP.Items.Count; x++)
                       {
                           _clb.SetItemChecked(x, true);
                       }
                   }

               }
           });
            
        }


        

        //Autocomplete para o campo Produtos
        //O autcomplete funciona da seguinte forma: Primeiro é feita a alimentação da base de dados presente no componente, após isso, ele faz um filtro dentre os existentes para sugerir ao usuário algumas opções de acordo com o que ele digitou.
        private void autocomplete_Produto()
        {            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = "SELECT Descricao FROM [DMD].dbo.[PRODU]";

                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Descricao"] != null)
                            {
                                dadosProdutos.Add(reader["Descricao"].ToString());
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
                txtProduto.Invoke((MethodInvoker) delegate { txtProduto.AutoCompleteCustomSource = dadosProdutos; });
        }


        //Função para digitar somente números
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        
        //Resgata a última atualização feita no custo
        private String data_Atualizacao_Custo()
            {

            String atualizacao = null;
            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = "SELECT TOP 1 CTME.Dat_Transacao FROM [UNIDB].dbo.[CUSTO_MEDIO] CTME ORDER BY CTME.DAT_TRANSACAO DESC";

                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Dat_Transacao"] != null)
                            {
                                atualizacao = "Última Atualização: " + reader["Dat_Transacao"].ToString();
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
            return atualizacao;
            
        }
            

        //Parâmetros iniciais
        //Esse método é utilizado no Load para deixá-lo mais enxuto. Aqui fica concetrada todas as configurações dos componentes dos forms
        private void configuracoes_Iniciais()
        {
            
            Task.Factory.StartNew(() => autocomplete_Produto());
            dtpDatCorte.Value = DateTime.Now;                       

            //Ajuda
            lblAjuda_Produto.Visible = false;
            lblAjuda_Cliente.Visible = false;
            lblAjuda_Custo0.Visible = false;
            lblAjuda_InfoTela.Visible = false;
            lblAjuda_Produto.Visible = false;
            lblAjuda_TipoRelatorio.Visible = false;
            lblAjuda_TransitoRelatorio.Visible = false;
            lblAjuda_UltimaAtt.Visible = false;
            lblAjuda_CFOP.Visible = false;
            lblAjuda_Filtrar_Clientes.Visible = false;
            lblAjudaExportar.Visible = false;
            lblHelpMensal.Visible = false;





            chkMostrarNulos.Enabled = false ;
            chkMostrarNulos.Checked = true;
            Task.Factory.StartNew(() => carregar_CFOPs(clbCFOP));
            Task.Factory.StartNew(() =>
                           lblAtt.Invoke((MethodInvoker)delegate {lblAtt.Text = data_Atualizacao_Custo();})) ;

            //Task.Factory.StartNew(() => filtrar_Dados_Analitico());
            //Task.Factory.StartNew(() => filtrar_Dados_Sintetico());
        }


        private void filtrar_Dados_Sintetico()
        {

            //Invocando o form para aplicar o Waitcursor
            this.Invoke(new MethodInvoker(delegate { this.Cursor = Cursors.WaitCursor; }));
            //Invocando o dgvCustoSintetico para resetar as linhas e coluinas
            dgvCustoSintetico.Invoke(new MethodInvoker(delegate
            {
                dgvCustoSintetico.Rows.Clear();
                dgvCustoSintetico.Columns.Clear();
            }));

            //Invocando a progress bar para computar o progresso da tarefa
            pcbSintetico.Invoke(new MethodInvoker(delegate { pcbSintetico.Value = 0; }));


            String sCondicaoCFOP = null;
            String sCondicaoNum_Nota = null;
            String sCondicaoProduto = null;
            String sCondicaoCliente = null;
            String sCondicao_Datas_Where = null;
            String sCondicao_Datas_Select = null;

            //Verifica os CFOPs que estão marcados para incluir na consulta
            clbCFOP.Invoke(new MethodInvoker(delegate { 
            foreach (var CFOP in clbCFOP.CheckedItems) 
            {
                if (sCondicaoCFOP != null)
                    sCondicaoCFOP = sCondicaoCFOP + "," + CFOP.ToString();
                else
                    sCondicaoCFOP = CFOP.ToString();
            }
            }));



            if (!txtCodCliente.Text.Equals(String.Empty))
            {
                sCondicaoCliente = " AND NSCB.Cod_Cliente = " + txtCodCliente.Text;
            }

            if (!txtCodProduto.Text.Equals(String.Empty))
            {
                sCondicaoProduto = "AND PROD.Codigo =  " + txtCodProduto.Text;
            }
            if (!txtNF.Text.Equals(String.Empty))
            {
                sCondicaoNum_Nota = " AND CTME.Protocolo_NF = " + txtNF.Text;
                sCondicao_Datas_Where = " =CTME.Dat_Transacao OR CTME.Dat_Transacao is null";
                sCondicao_Datas_Select = " =CTME.Dat_Transacao ";
                //Consulta e alimenta o Grid Sintético
                pcbSintetico.Invoke(new MethodInvoker(delegate { pcbSintetico.Maximum = 100; }));
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {

                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText =
                          "                SELECT                                                                                                                                                                                "
                        + "        PROD.Cod_ClaFis[Class.Fiscal]                                                                                                                                                                 "
                        + "	   ,PROD.Codigo[Cod.Produto]                                                                                                                                                                         "
                        + "	   ,PROD.Descricao[Produto]                                                                                                                                                                          "
                        + "	   ,PROD.Unidade_Venda[Unidade]                                                                                                                                                                      "
                        + "	   ,ESTOQUE = CASE                                                                                                                                                                                   "
                        + "                                                                                                                                                                                                      "
                        + "                       ISNULL((SELECT top 1 Qtd_SldAtu FROM[DMD].dbo.[PRSLD] PR                                                                                                                       "
                        + "                                                                                                                                                                                                      "
                        + "                               WHERE PR.Dat_Movime < (SELECT MAX(CM.DAT_TRANSACAO) FROM[UNIDB].dbo.[CUSTO_MEDIO] CM WHERE CM.Cod_Produto = PROD.Codigo AND CM.Dat_Transacao < " + sCondicao_Datas_Select + ")             "
                        + "                                                                                                                                                                                                      "
                        + "                                                         AND PR.Cod_Produt = PROD.Codigo                                                                                                              "
                        + "                                                                                                                                                                                                      "
                        + "                                                      ORDER BY Dat_Movime DESC),0)					                                                                                                 "
                        + "				   WHEN 0 THEN                                                                                                                                                                           "
                        + "                                                                                                                                                                                                      "
                        + "                       ISNULL((SELECT top 1 Qtd_SldAtu FROM[DMD].dbo.[PRSLD] PR                                                                                                                       "
                        + "                                                                                                                                                                                                      "
                        + "                               WHERE PR.Dat_Movime < (SELECT MAX(CM.DAT_TRANSACAO) FROM[UNIDB].dbo.[CUSTO_MEDIO] CM WHERE CM.Dat_Transacao < " + sCondicao_Datas_Select + " )                                               "
                        + "                                                                                                                                                                                                      "
                        + "                                                        AND PR.Cod_Produt = PROD.Codigo                                                                                                               "
                        + "                                                                                                                                                                                                      "
                        + "                                                     ORDER BY Dat_Movime DESC),0)				                                                                                                     "
                        + "				   ELSE                                                                                                                                                                                  "
                        + "                                                                                                                                                                                                      "
                        + "                       ISNULL((SELECT top 1 Qtd_SldAtu FROM[DMD].dbo.[PRSLD] PR                                                                                                                       "
                        + "                                                                                                                                                                                                      "
                        + "                               WHERE PR.Dat_Movime < (SELECT MAX(CM.DAT_TRANSACAO) FROM[UNIDB].dbo.[CUSTO_MEDIO] CM WHERE CM.Cod_Produto = PROD.Codigo AND CM.Dat_Transacao < " + sCondicao_Datas_Select + ")             "
                        + "                                                                                                                                                                                                      "
                        + "                                  AND PR.Cod_Produt = PROD.Codigo                                                                                                                                     "
                        + "                                                                                                                                                                                                      "
                        + "                               ORDER BY Dat_Movime DESC),0)                                                                                                                                           "
                        + "				   END                                                                                                                                                                                   "
                        + "	   ,[Ult.Custo] =                                                                                                                                                                                    "
                        + "                   CASE                                                                                                                                                                               "
                        + "                                                                                                                                                                                                      "
                        + "                       ISNULL((SELECT top 1 CustoProduto FROM[UNIDB].dbo.[CUSTO_MEDIO] CM                                                                                                             "
                        + "                                                                                                                                                                                                      "
                        + "                               WHERE CM.Dat_Transacao = (SELECT MAX(CMD.DAT_TRANSACAO) FROM[UNIDB].dbo.[CUSTO_MEDIO] CMD WHERE CMD.Cod_Produto = PROD.Codigo AND CM.Dat_Transacao < " + sCondicao_Datas_Select + ")       "
                        + "                                                                                                                                                                                                      "
                        + "                               AND CM.Cod_Produto = CTME.Cod_Produto),0)                                                                                                                              "
                        + "				   WHEN 0 THEN                                                                                                                                                                           "
                        + "                                                                                                                                                                                                      "
                        + "                       PROD.Prc_CustoMedio                                                                                                                                                            "
                        + "                   ELSE                                                                                                                                                                               "
                        + "                                                                                                                                                                                                      "
                        + "                       ISNULL((SELECT top 1 CustoProduto FROM[UNIDB].dbo.[CUSTO_MEDIO] CM                                                                                                             "
                        + "                                                                                                                                                                                                      "
                        + "                               WHERE CM.Dat_Transacao = (SELECT MAX(CMD.DAT_TRANSACAO) FROM[UNIDB].dbo.[CUSTO_MEDIO] CMD WHERE CMD.Cod_Produto = PROD.Codigo AND CM.Dat_Transacao < " + sCondicao_Datas_Select + ")       "
                        + "                                                                                                                                                                                                      "
                        + "                               AND CM.Cod_Produto = CTME.Cod_Produto),0)                                                                                                                              "
                        + "				   END                                                                                                                                                                                   "
                        + "FROM[DMD].dbo.[PRODU]          PROD                                                                                                                                                                   "
                        + "LEFT JOIN[UNIDB].dbo.[CUSTO_MEDIO]  CTME ON CTME.Cod_Produto = PROD.Codigo                                                                                                                            "
                        + "LEFT JOIN[DMD].dbo.[NFSCB] NSCB ON NSCB.Num_Nota = CTME.Protocolo_NF                                                                                                                                  "
                        + "WHERE                                                                                                                                                                                                 "
                        + "Tipo NOT IN('U','B','S','A','P')                                                                                                                                                                      "
                        + "AND(CTME.Dat_Transacao < " + sCondicao_Datas_Where + ")                                                                                                                                       "
                        + "AND CTME.Cod_CFOP IN ( " + sCondicaoCFOP + " )                                                                                                                                                        "
                        + sCondicaoCliente
                        + sCondicaoProduto
                        + sCondicaoNum_Nota
                        + "GROUP BY                                                                                                                                                                                              "
                        + " PROD.Cod_ClaFis                                                                                                                                                                                      "
                        + ",PROD.Codigo                                                                                                                                                                                          "
                        + ",PROD.Descricao                                                                                                                                                                                       "
                        + ",PROD.Unidade_Venda                                                                                                                                                                                   "
                        + ",Qtd_Disponivel                                                                                                                                                                                       "
                        + ",Qtd_Avariado                                                                                                                                                                                         "
                        + ",CTME.Cod_Produto                                                                                                                                                                                     "
                        + ",PROD.Prc_CustoMedio   " 
                        + ",CTME.Dat_Transacao "
                        + "ORDER BY PROD.Codigo                                                                                                                                                                                  ";




                        SqlParameter pDat_Corte = new SqlParameter("@Dat_Corte", SqlDbType.DateTime);
                        pDat_Corte.Value = dtpDatCorte.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                        command.Parameters.Add(pDat_Corte);
                        command.CommandTimeout = 500;                        

                        reader = command.ExecuteReader();

                        dgvCustoSintetico.Invoke(new MethodInvoker(delegate {
                            dgvCustoSintetico.Columns.Add("Class_Fiscal", "Class. Fiscal");
                            dgvCustoSintetico.Columns.Add("Cod_Produto", "Cód . Produto");
                            dgvCustoSintetico.Columns.Add("Produto", "Produto");
                            dgvCustoSintetico.Columns.Add("Unidade", "Unidade");
                            dgvCustoSintetico.Columns.Add("Estoque", "Estoque");
                            dgvCustoSintetico.Columns.Add("Ult_Custo", "Últ. Custo");





                            while (reader.Read())
                            {
                                if (reader["Class.Fiscal"] != null)
                                {
                                    dgvCustoSintetico.Rows.Add(reader["Class.Fiscal"].ToString(), reader["Cod.Produto"].ToString(), reader["Produto"].ToString(), reader["Unidade"].ToString(),
                                                               reader["Estoque"].ToString(), reader["Ult.Custo"].ToString());
                                    pcbSintetico.Invoke(new MethodInvoker(delegate { pcbSintetico.Value = pcbSintetico.Value + 1; }));
                                }
                            }
                        }));
                    }
                    catch (SqlException SQLe)
                    {
                        erro_DeAcesso(SQLe);
                    }
                    finally
                    {
                        connectDMD.Close();
                        dgvCustoSintetico.Invoke(new MethodInvoker(delegate {
                            dgvCustoSintetico.Columns.Add("Total_Custo", "Total custo");

                            foreach (DataGridViewRow row in dgvCustoSintetico.Rows)
                            {
                                row.Cells[6].Value = Convert.ToInt32(row.Cells[4].Value) * Convert.ToDouble(row.Cells[5].Value.ToString());
                                chkMostrarNulos.Invoke(new MethodInvoker(delegate
                                {
                                    if (chkMostrarNulos.Checked == false)
                                    {
                                        if (Convert.ToDouble(row.Cells[6].Value) == 0)
                                        {
                                            row.Visible = false;
                                        }
                                        else
                                        {
                                            row.Cells[6].Value = Convert.ToDouble(row.Cells[6].Value).ToString("C");
                                            row.Cells[5].Value = Convert.ToDouble(row.Cells[5].Value).ToString("C");
                                        }
                                    }

                                }));
                                //row.Cells[4].Value = Convert.ToDouble(row.Cells[4].Value).ToString("C");
                                pcbSintetico.Invoke(new MethodInvoker(delegate { pcbSintetico.Value = pcbSintetico.Value + 1; }));
                            }


                        }));
                        mTittle = "Sintético";
                        mMessage = "Consulta concluída";
                        mButton = MessageBoxButtons.OK;
                        mIcon = MessageBoxIcon.Information;
                        pcbSintetico.Invoke(new MethodInvoker(delegate { pcbSintetico.Value = 100; }));
                        MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                        
                    }
                }
                this.Invoke(new MethodInvoker(delegate { this.Cursor = Cursors.Default; }));
                return;
            }
            else
            {
                sCondicao_Datas_Where= " @Dat_Corte  OR  Dat_Transacao IS NULL ";
                sCondicao_Datas_Select = " @Dat_Corte ";
            }

           

        

            //Consulta o número de itens para definir um limite para o progressbar
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                int valor_teste = 0;
                try
                {

                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText =
                      " SELECT                                                                                                                                                  "
                    + " COUNT (distinct PROD.Codigo)       [CONT]                                                                                                             "
                    + "FROM[DMD].dbo.[PRODU]          PROD                                                                                                                      "
                    + "LEFT JOIN[UNIDB].dbo.[CUSTO_MEDIO]  CTME ON CTME.Cod_Produto = PROD.Codigo                                                                               "
                    + "LEFT JOIN[DMD].dbo.[NFSCB] NSCB ON NSCB.Num_Nota = CTME.Protocolo_NF                                                                                     "
                    + "WHERE                                                                                                                                                    "
                    + "Tipo NOT IN('U','B','S','A','P')                                                                                                                         "
                    + "AND(CTME.Dat_Transacao < " + sCondicao_Datas_Where + ")                                                                                                  "
                    //+ "AND CTME.Cod_CFOP IN ( " + sCondicaoCFOP + " )                                                                                                           "
                    + sCondicaoCliente
                    + sCondicaoProduto;
                    //+"group by CTME.CustoProduto ";






                    SqlParameter pDat_Corte = new SqlParameter("@Dat_Corte", SqlDbType.DateTime);
                    pDat_Corte.Value = dtpDatCorte.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                    command.Parameters.Add(pDat_Corte);
                    command.CommandTimeout = 100;

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["CONT"] != null)
                        {
                            //pcbSintetico.Invoke(new MethodInvoker(delegate { pcbSintetico.Maximum = Convert.ToInt32(reader["CONT"].ToString()) + pcbAnalitico.`; }));
                            valor_teste = Convert.ToInt32(reader["CONT"].ToString()) + valor_teste;
                        }
                    }

                                      
                }
                catch (SqlException SQLe)
                {
                    erro_DeAcesso(SQLe);
                }
                finally
                {
                    pcbSintetico.Invoke(new MethodInvoker(delegate { pcbSintetico.Maximum = valor_teste* 2; }));
                    connectDMD.Close();                    
                }
            }
            //Consulta e alimenta o Grid Sintético
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {

                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText =
                      "                SELECT                                                                                                                                                                                "
                    + "        PROD.Cod_ClaFis[Class.Fiscal]                                                                                                                                                                 "
                    + "	   ,PROD.Codigo[Cod.Produto]                                                                                                                                                                         "
                    + "	   ,PROD.Descricao[Produto]                                                                                                                                                                          "
                    + "	   ,PROD.Unidade_Venda[Unidade]                                                                                                                                                                      "
                    + "	   ,ESTOQUE = CASE                                                                                                                                                                                   "
                    + "                                                                                                                                                                                                      "
                    + "                       ISNULL((SELECT top 1 Qtd_SldAtu FROM[DMD].dbo.[PRSLD] PR                                                                                                                       "
                    + "                                                                                                                                                                                                      "
                    + "                               WHERE PR.Dat_Movime < (SELECT MAX(CM.DAT_TRANSACAO) FROM[UNIDB].dbo.[CUSTO_MEDIO] CM WHERE CM.Cod_Produto = PROD.Codigo AND CM.Dat_Transacao < "+sCondicao_Datas_Select+ ")             "
                    + "                                                                                                                                                                                                      "
                    + "                                                         AND PR.Cod_Produt = PROD.Codigo                                                                                                              "
                    + "                                                                                                                                                                                                      "
                    + "                                                      ORDER BY Dat_Movime DESC),0)					                                                                                                 "
                    + "				   WHEN 0 THEN                                                                                                                                                                           "
                    + "                                                                                                                                                                                                      "
                    + "                       ISNULL((SELECT top 1 Qtd_SldAtu FROM[DMD].dbo.[PRSLD] PR                                                                                                                       "
                    + "                                                                                                                                                                                                      "
                    + "                               WHERE PR.Dat_Movime < (SELECT MAX(CM.DAT_TRANSACAO) FROM[UNIDB].dbo.[CUSTO_MEDIO] CM WHERE CM.Dat_Transacao < "+sCondicao_Datas_Select+" )                                               "
                    + "                                                                                                                                                                                                      "
                    + "                                                        AND PR.Cod_Produt = PROD.Codigo                                                                                                               "
                    + "                                                                                                                                                                                                      "
                    + "                                                     ORDER BY Dat_Movime DESC),0)				                                                                                                     "
                    + "				   ELSE                                                                                                                                                                                  "
                    + "                                                                                                                                                                                                      "
                    + "                       ISNULL((SELECT top 1 Qtd_SldAtu FROM[DMD].dbo.[PRSLD] PR                                                                                                                       "
                    + "                                                                                                                                                                                                      "
                    + "                               WHERE PR.Dat_Movime < (SELECT MAX(CM.DAT_TRANSACAO) FROM[UNIDB].dbo.[CUSTO_MEDIO] CM WHERE CM.Cod_Produto = PROD.Codigo AND CM.Dat_Transacao < "+sCondicao_Datas_Select+ ")             "
                    + "                                                                                                                                                                                                      "
                    + "                                  AND PR.Cod_Produt = PROD.Codigo                                                                                                                                     "
                    + "                                                                                                                                                                                                      "
                    + "                               ORDER BY Dat_Movime DESC),0)                                                                                                                                           "
                    + "				   END                                                                                                                                                                                   "
                    + "	   ,[Ult.Custo] =                                                      "
                    + " CASE ISNULL(MAX(CTME.CustoProduto),0)                                                                                        "
					+ "				 WHEN 0 THEN ISNULL(PROD.Prc_CustoMedio,0)                                                                       "
					+ "				 ELSE                                                                                                            "
                    + "                 (SELECT TOP 1(CTME_UltimoCusto.CustoProduto) FROM[UNIDB].dbo.[CUSTO_MEDIO] CTME_UltimoCusto                    "
                    + "                                                                                                                              "
                    + "                  WHERE CTME_UltimoCusto.Cod_Produto = PROD.Codigo AND CTME_UltimoCusto.Dat_Transacao < "+sCondicao_Datas_Select+" ORDER BY CTME_UltimoCusto.Dat_Transacao DESC)           "
                    + "                                                                                                                              "
                    + "                  END                                                                                                         "
                    + "FROM[DMD].dbo.[PRODU]          PROD                                                                                                                                                                   "
                    + "LEFT JOIN[UNIDB].dbo.[CUSTO_MEDIO]  CTME ON CTME.Cod_Produto = PROD.Codigo                                                                                                                            " 
                    + "LEFT JOIN[DMD].dbo.[NFSCB] NSCB ON NSCB.Num_Nota = CTME.Protocolo_NF                                                                                                                                  "
                    + "WHERE                                                                                                                                                                                                 "
                    + "Tipo NOT IN('U','B','S','A','P')                                                                                                                                                                      "                                                                                                     
                    +"AND(CTME.Dat_Transacao < "+sCondicao_Datas_Where+")                                                                                                                                       "
                    //+ "AND CTME.Cod_CFOP IN ( " + sCondicaoCFOP + " )                                                                                                                                                        "
                    +sCondicaoCliente
                    +sCondicaoProduto
                    +" GROUP BY "
                    +" PROD.Cod_ClaFis      "
                    +" ,PROD.Codigo         "
                    +" ,PROD.Descricao      "
                    +" ,PROD.Unidade_Venda  "
                    +" ,Qtd_Disponivel      "
                    +" ,Qtd_Avariado        "
                    +" ,CTME.Cod_Produto    "
                    +" ,PROD.Prc_CustoMedio "
                    + "ORDER BY PROD.Codigo                                                                                                                                                                                  ";




                    SqlParameter pDat_Corte = new SqlParameter("@Dat_Corte", SqlDbType.DateTime);
                    pDat_Corte.Value = dtpDatCorte.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                    command.Parameters.Add(pDat_Corte);
                    command.CommandTimeout = 100;
                    

                    reader = command.ExecuteReader();

                    dgvCustoSintetico.Invoke(new MethodInvoker(delegate {
                    dgvCustoSintetico.Columns.Add("Class_Fiscal","Class. Fiscal");
                    dgvCustoSintetico.Columns.Add("Cod_Produto","Cód . Produto");
                    dgvCustoSintetico.Columns.Add("Produto","Produto");
                    dgvCustoSintetico.Columns.Add("Unidade","Unidade");
                    dgvCustoSintetico.Columns.Add("Estoque","Estoque");
                    dgvCustoSintetico.Columns.Add("Ult_Custo","Últ. Custo");
                    




                    while (reader.Read())
                    {
                        if (reader["Class.Fiscal"] != null)
                        {
                                dgvCustoSintetico.Rows.Add(reader["Class.Fiscal"].ToString(),reader["Cod.Produto"].ToString(),reader["Produto"].ToString(),reader["Unidade"].ToString(),
                                                           reader["Estoque"].ToString(),reader["Ult.Custo"].ToString());
                                pcbSintetico.Invoke(new MethodInvoker(delegate { pcbSintetico.Value = pcbSintetico.Value + 1; }));
                            }
                    }
                    }));
                }
                catch (SqlException SQLe)
                {
                    erro_DeAcesso(SQLe);
                }
                finally
                {
                    connectDMD.Close();
                    dgvCustoSintetico.Invoke(new MethodInvoker(delegate {                        
                        dgvCustoSintetico.Columns.Add("Total_Custo", "Total custo");

                        foreach (DataGridViewRow row in dgvCustoSintetico.Rows)
                    {
                        row.Cells[6].Value = Convert.ToInt32(row.Cells[4].Value) * Convert.ToDouble(row.Cells[5].Value.ToString());
                            chkMostrarNulos.Invoke(new MethodInvoker(delegate
                            {
                                if (chkMostrarNulos.Checked == false)
                                {
                                    if (Convert.ToDouble(row.Cells[6].Value) == 0)
                                    {
                                        row.Visible = false;
                                    }
                                    else
                                    {
                                        row.Cells[6].Value = Convert.ToDouble(row.Cells[6].Value).ToString("C");
                                        row.Cells[5].Value = Convert.ToDouble(row.Cells[5].Value).ToString("C");
                                    }
                                }
                                
                            }));
                            //row.Cells[4].Value = Convert.ToDouble(row.Cells[4].Value).ToString("C");
                            pcbSintetico.Invoke(new MethodInvoker(delegate { pcbSintetico.Value = pcbSintetico.Value+ 1; }));
                        }
                        
                    
                    }));                    
                }
            }
            this.Invoke(new MethodInvoker(delegate { this.Cursor = Cursors.Default; }));

            mTittle = "Sintético";
            mMessage= "Consulta concluída";
            mButton = MessageBoxButtons.OK;
            mIcon = MessageBoxIcon.Information;
            MessageBox.Show(mMessage,mTittle,mButton,mIcon);
        }
        private void filtrar_Dados_Analitico()
        {

            String sCondicaoCFOP = null;
            String sCondicaoNum_Nota = null;
            String sCondicaoProduto = null;
            String sCondicaoCliente = null;
            String sCondicao_Datas_Select = null;
            String sCondicao_Mensal = null;
            this.Invoke(new MethodInvoker(delegate { this.Cursor = Cursors.WaitCursor; }));
            pcbAnalitico.Invoke(new MethodInvoker(delegate {pcbAnalitico.Value = 0; }));

            dgvCustoAnalitico.Invoke(new MethodInvoker(delegate
            {
                dgvCustoAnalitico.Rows.Clear();
                dgvCustoAnalitico.Columns.Clear();
            }));


            //Verifica os CFOPs que estão marcados para incluir na consulta
            foreach (var CFOP in clbCFOP.CheckedItems)
            {
                if (sCondicaoCFOP != null)
                    sCondicaoCFOP = sCondicaoCFOP + "," + CFOP.ToString();
                else
                    sCondicaoCFOP = CFOP.ToString();
            }



            if (!txtCodCliente.Text.Equals(String.Empty))
            {
                sCondicaoCliente = " AND NSCB.Cod_Cliente = " + txtCodCliente.Text;
            }

            if (!txtCodProduto.Text.Equals(String.Empty))
            {
                sCondicaoProduto = "AND CTME.Cod_Produto =  " + txtCodProduto.Text;
            }
            if (!txtNF.Text.Equals(String.Empty))
            {
                sCondicaoNum_Nota = "AND CTME.Protocolo_NF = " + txtNF.Text;
                sCondicao_Datas_Select = " =CTME.Dat_Transacao";
            }            
            else
            {
                sCondicao_Datas_Select = " @Dat_Corte";
            }

            if (chkMensal.Checked)
            {
                sCondicao_Mensal = " AND MONTH(CTME.Dat_Transacao) = MONTH(@DAT_CORTE)" +
                                   " AND YEAR(CTME.Dat_Transacao) = YEAR(@DAT_CORTE)";
            }


            


            //Consulta o número de itens para definir um limite para o progressbar
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {

                    connectDMD.Open();

                    command_2 = connectDMD.CreateCommand();
                    command_2.CommandText =
                         " SELECT                                                                                                       "
                       + " COUNT(*) [CONT]                                                                                              "
                       + "  FROM[UNIDB].dbo.[CUSTO_MEDIO] CTME                                                                          "
                       + "  LEFT JOIN[DMD].dbo.[NFSCB] NSCB ON NSCB.num_nota = CTME.Protocolo_NF  AND CTME.Tipo_Operacao LIKE 'Saida'   "
                       + "  LEFT JOIN[DMD].dbo.[NFECB] NECB ON NECB.Protocolo = CTME.Protocolo_NF AND CTME.Tipo_Operacao LIKE 'Entrada' "
                       + "  JOIN[DMD].dbo.[PRODU] PROD ON PROD.Codigo = CTME.Cod_Produto                                                "
                       + "  WHERE                                                                                                       "
                       + "    Tipo NOT IN('U','B','S','A','P')                                                                          "
                       + "	AND (NSCB.Dat_Emissao < "+sCondicao_Datas_Select+" or NECB.Dat_Emissao < "+sCondicao_Datas_Select+")                                        "
                       + "  AND CTME.Cod_CFOP IN ("+sCondicaoCFOP+")                                                                    "
                       +sCondicaoCliente
                       +sCondicaoNum_Nota
                       +sCondicaoProduto
                       +sCondicao_Mensal
                       ;                       

    





                    SqlParameter pDat_Corte = new SqlParameter("@Dat_Corte", SqlDbType.DateTime);
                    pDat_Corte.Value = dtpDatCorte.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                    command_2.Parameters.Add(pDat_Corte);
                    command_2.CommandTimeout = 500;

                    reader_2 = command_2.ExecuteReader();

                    while (reader_2.Read())
                    {
                        if (reader_2["CONT"] != null)
                        {
                            pcbAnalitico.Invoke(new MethodInvoker(delegate { pcbAnalitico.Maximum = Convert.ToInt32(reader_2["CONT"].ToString()) * 2; }));
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
            //Consulta e alimenta o Grid Sintético
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {

                    connectDMD.Open();

                    command_2 = connectDMD.CreateCommand();
                    command_2.CommandText =
                         " SELECT                                                                                                       "
                       + "  [NF_Protocolo] =                                                                                          "
                       + "  CASE CTME.Tipo_Operacao                                                                                     "
                       + "  WHEN 'Saida' THEN NSCB.Num_Nota                                                                             "
                       + "  ELSE NECB.Protocolo                                                                                         "
                       + "  END                                                                                                         "
                       + "  ,[Emissao_Entrada] =                                                                                      "
                       + "   CASE CTME.Tipo_Operacao                                                                                    "
                       + "   WHEN 'Saida' THEN NSCB.Dat_Emissao                                                                         "
                       + "   ELSE NECB.Dat_Entrada                                                                                      "
                       + "   END                                                                                                        "
                       + "  ,CTME.Cod_Produto                                                                                           "
                       + "  ,PROD.Descricao                                                                                             "
                       + "  ,CTME.Cod_CFOP                                                                                              "
                       + "  ,CTME.Prc_Unitario                                                                                          "
                       + "  ,CTME.Qtd_Movimento                                                                                         "
                       + "  ,[Faturamento] = CTME.Prc_Unitario * CTME.Qtd_Movimento                                                     "
                       + "  ,CTME.CustoProduto                                                                                          "
                       + "  ,CTME.CustoTotal                                                                                            "
                       + "  ,Lucro = (CTME.Prc_Unitario * CTME.Qtd_Movimento) - CTME.CustoTotal                                         "
                       +" ,Estoque = CASE                                                                                                                                                                                   "
                        + "                                                                                                                                                                                                      "
                        + "                       ISNULL((SELECT top 1 Qtd_SldAtu FROM[DMD].dbo.[PRSLD] PR                                                                                                                       "
                        + "                                                                                                                                                                                                      "
                        + "                               WHERE PR.Dat_Movime < (SELECT MAX(CM.DAT_TRANSACAO) FROM[UNIDB].dbo.[CUSTO_MEDIO] CM WHERE CM.Cod_Produto = PROD.Codigo AND CM.Dat_Transacao < " + sCondicao_Datas_Select + ")             "
                        + "                                                                                                                                                                                                      "
                        + "                                                         AND PR.Cod_Produt = PROD.Codigo                                                                                                              "
                        + "                                                                                                                                                                                                      "
                        + "                                                      ORDER BY Dat_Movime DESC),0)					                                                                                                 "
                        + "				   WHEN 0 THEN                                                                                                                                                                           "
                        + "                                                                                                                                                                                                      "
                        + "                       ISNULL((SELECT top 1 Qtd_SldAtu FROM[DMD].dbo.[PRSLD] PR                                                                                                                       "
                        + "                                                                                                                                                                                                      "
                        + "                               WHERE PR.Dat_Movime < (SELECT MAX(CM.DAT_TRANSACAO) FROM[UNIDB].dbo.[CUSTO_MEDIO] CM WHERE CM.Dat_Transacao < " + sCondicao_Datas_Select + " )                                               "
                        + "                                                                                                                                                                                                      "
                        + "                                                        AND PR.Cod_Produt = PROD.Codigo                                                                                                               "
                        + "                                                                                                                                                                                                      "
                        + "                                                     ORDER BY Dat_Movime DESC),0)				                                                                                                     "
                        + "				   ELSE                                                                                                                                                                                  "
                        + "                                                                                                                                                                                                      "
                        + "                       ISNULL((SELECT top 1 Qtd_SldAtu FROM[DMD].dbo.[PRSLD] PR                                                                                                                       "
                        + "                                                                                                                                                                                                      "
                        + "                               WHERE PR.Dat_Movime < (SELECT MAX(CM.DAT_TRANSACAO) FROM[UNIDB].dbo.[CUSTO_MEDIO] CM WHERE CM.Cod_Produto = PROD.Codigo AND CM.Dat_Transacao < " + sCondicao_Datas_Select + ")             "
                        + "                                                                                                                                                                                                      "
                        + "                                  AND PR.Cod_Produt = PROD.Codigo                                                                                                                                     "
                        + "                                                                                                                                                                                                      "
                        + "                               ORDER BY Dat_Movime DESC),0)                                                                                                                                           "
                        + "				   END                                                                                                                                                                                   "
                       + "  ,CTME.Tipo_Operacao                                                                                         "
                       + "  FROM[UNIDB].dbo.[CUSTO_MEDIO] CTME                                                                          "
                       + "  LEFT JOIN[DMD].dbo.[NFSCB] NSCB ON NSCB.num_nota = CTME.Protocolo_NF  AND CTME.Tipo_Operacao LIKE 'Saida'   "
                       + "  LEFT JOIN[DMD].dbo.[NFECB] NECB ON NECB.Protocolo = CTME.Protocolo_NF AND CTME.Tipo_Operacao LIKE 'Entrada' "
                       + "  JOIN[DMD].dbo.[PRODU] PROD ON PROD.Codigo = CTME.Cod_Produto                                                "
                       + "  WHERE                                                                                                       "
                       + "    Tipo NOT IN('U','B','S','A','P')                                                                          "
                       + "	AND (NSCB.Dat_Emissao < @Dat_Corte or NECB.Dat_Emissao < @Dat_Corte)                                        "
                       + "  AND CTME.Cod_CFOP IN (" + sCondicaoCFOP + ")                                                                  "
                       + sCondicaoCliente
                       + sCondicaoNum_Nota
                       + sCondicaoProduto
                       + sCondicao_Mensal;
                       




                    SqlParameter pDat_Corte = new SqlParameter("@Dat_Corte", SqlDbType.DateTime);
                    pDat_Corte.Value = dtpDatCorte.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                    command_2.Parameters.Add(pDat_Corte);
                    command_2.CommandTimeout = 500;
                    

                    reader_2 = command_2.ExecuteReader();

                    dgvCustoAnalitico.Invoke(new MethodInvoker(delegate
                    {
                        dgvCustoAnalitico.Columns.Add("NF_Protocolo", "NF / Protocolo");          //0
                        dgvCustoAnalitico.Columns.Add("Data_Emi_Ent", "Dat. Entrada / Emissão");  //1
                        dgvCustoAnalitico.Columns.Add("Cod_Produto", "Cod. Produto");             //2
                        dgvCustoAnalitico.Columns.Add("Desc_Produto", "Descrição");               //3
                        dgvCustoAnalitico.Columns.Add("Cod_CFOP", "CFOP");                        //4
                        dgvCustoAnalitico.Columns.Add("Prc_Unitario", "Prc. Unitário");           //5
                        dgvCustoAnalitico.Columns.Add("Qtd_Movimento", "Qtd. Movimento");         //6
                        dgvCustoAnalitico.Columns.Add("Faturamento", "Faturamento");              //7
                        dgvCustoAnalitico.Columns.Add("Custo_Unitario", "Custo Unitário");        //8
                        dgvCustoAnalitico.Columns.Add("Custo_Total", "Custo Total");              //9
                        dgvCustoAnalitico.Columns.Add("Lucro", "Lucro");                          //10
                        dgvCustoAnalitico.Columns.Add("Estoque", "Estoque Final");                //11
                        dgvCustoAnalitico.Columns.Add("Operacao", "Operação");                    //12





                        while (reader_2.Read())
                        {
                            if (reader_2["Estoque"] != null)
                            {
                                dgvCustoAnalitico.Rows.Add(reader_2["NF_Protocolo"].ToString(), reader_2["Emissao_Entrada"].ToString(), Convert.ToInt32(reader_2["Cod_Produto"].ToString()), reader_2["Descricao"].ToString(),
                                                           reader_2["Cod_CFOP"].ToString(), reader_2["Prc_Unitario"].ToString(), reader_2["Qtd_Movimento"].ToString(), reader_2["Faturamento"].ToString(), reader_2["CustoProduto"].ToString(),
                                                           reader_2["CustoTotal"].ToString(), reader_2["Lucro"].ToString(), reader_2["Estoque"].ToString(), reader_2["Tipo_Operacao"].ToString());
                                pcbAnalitico.Invoke(new MethodInvoker(delegate { pcbAnalitico.Value = pcbAnalitico.Value + 1; }));
                            }
                        }
                    }));
                }
                catch (SqlException SQLe)
                {
                    erro_DeAcesso(SQLe);
                }
                finally
                {
                    connectDMD.Close();
                    dgvCustoAnalitico.Invoke(new MethodInvoker(delegate
                    {                        
                        foreach (DataGridViewRow row in dgvCustoAnalitico.Rows)
                        {
                            row.Cells[5].Value = Convert.ToDouble(row.Cells[5].Value).ToString("C");
                            row.Cells[7].Value = Convert.ToDouble(row.Cells[7].Value).ToString("C");
                            row.Cells[8].Value = Convert.ToDouble(row.Cells[8].Value).ToString("C");
                            row.Cells[9].Value = Convert.ToDouble(row.Cells[9].Value).ToString("C");
                            row.Cells[10].Value = Convert.ToDouble(row.Cells[10].Value).ToString("C");
                            pcbAnalitico.Invoke(new MethodInvoker(delegate { pcbAnalitico.Value = pcbAnalitico.Value + 1; }));
                        }


                    }));
                }
            }
            this.Invoke(new MethodInvoker(delegate { this.Cursor = Cursors.Default; }));
            mTittle = "Analítico";
            mMessage = "Consulta concluída";
            mButton = MessageBoxButtons.OK;
            mIcon = MessageBoxIcon.Information;
            MessageBox.Show(mMessage, mTittle, mButton, mIcon);
        }



        private void filtrar_Dados()
        {
            if (rdbAnalitico.Checked)
            Task.Factory.StartNew(() => filtrar_Dados_Analitico());
            else
            Task.Factory.StartNew(() => filtrar_Dados_Sintetico());
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
                            erro_DeAcesso(SQLe);
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

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            filtrar_Dados();
        }

        private void rdbSintetico_CheckedChanged(object sender, EventArgs e)
        {
            chkMostrarNulos.Enabled = true;
        }

        private void rdbAnalitico_CheckedChanged(object sender, EventArgs e)
        {
            chkMostrarNulos.Enabled = false;
        }

        private void chkHelp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHelp.Checked == true)
            {
                lblAjuda_Produto.Visible = true;
                lblAjuda_Cliente.Visible =           true;
                lblAjuda_Custo0.Visible =            true;
                lblAjuda_InfoTela.Visible =          true;
                lblAjuda_Produto.Visible =           true;
                lblAjuda_TipoRelatorio.Visible =     true;
                lblAjuda_TransitoRelatorio.Visible = true;
                lblAjuda_UltimaAtt.Visible =         true;
                lblAjuda_CFOP.Visible = true;
                lblAjuda_Filtrar_Clientes.Visible = true;
                lblAjudaExportar.Visible = true;
                lblHelpMensal.Visible = true;
            }
            else
            {
                lblAjuda_Produto.Visible = false;
                lblAjuda_Cliente.Visible = false;
                lblAjuda_Custo0.Visible = false;
                lblAjuda_InfoTela.Visible = false;
                lblAjuda_Produto.Visible = false;
                lblAjuda_TipoRelatorio.Visible = false;
                lblAjuda_TransitoRelatorio.Visible = false;
                lblAjuda_UltimaAtt.Visible = false;
                lblAjuda_CFOP.Visible = false;
                lblAjuda_Filtrar_Clientes.Visible = false;
                lblAjudaExportar.Visible = false;
                lblHelpMensal.Visible = false;
            }
        }

        private void pcbSintetico_SizeChanged(object sender, EventArgs e)
        {
            
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (dgvCustoAnalitico.Rows.Count > 0 && dgvCustoSintetico.Rows.Count > 0)
            exportarExcel();
            else
            {
                mTittle = "Falha ao exportar";
                mMessage = "Gere o analítico e sintético para exportar em excel.";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Warning;
                MessageBox.Show(mMessage,mTittle,mButton,mIcon);
            }
            this.Cursor = Cursors.Default;
        }

        private void gpbTipoRelatorio_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {


            txtCodProduto.Text = String.Empty;            
                if (!txtProduto.Text.Equals(String.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText =
                                                  " SELECT                                                 " +
                                                  "     P.Codigo     [Cod_Produto]                              " +
                                                  "    ,P.Descricao  [Produto]                               " +
                                                  "    ,F.Fantasia   [Fabricante]                             " +
                                                  " FROM[DMD].dbo.[PRODU] P                                " +
                                                  " JOIN[DMD].dbo.[FABRI] F ON F.Codigo = P.Cod_Fabricante " +
                                                  " WHERE Descricao like '" + txtProduto.Text + "%'        ";

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Produto"] != null)
                                {
                                    txtCodProduto.Text = reader["Cod_Produto"].ToString();
                                    txtFabricante.Text = reader["Fabricante"].ToString();
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


            
                CopyToClipboardWithHeaders(dgvCustoAnalitico);
                Excel.Application app;
                Excel.Workbook CustoMedio;           
                Excel.Worksheet abaAnalitico;            
                object misValue = System.Reflection.Missing.Value;
                app = new Excel.Application();
                app.Visible = true;
                CustoMedio = app.Workbooks.Add(misValue);
                abaAnalitico = (Excel.Worksheet)CustoMedio.Worksheets.get_Item(1);
                Excel.Range CR = (Excel.Range)abaAnalitico.Cells[1, 1];
                CR.Rows.AutoFit();
                CR.Select();
                Excel.Range rng1 = abaAnalitico.get_Range("A1", "Z1");
                rng1.Font.Bold = true;
                rng1.Font.ColorIndex = 3;
                rng1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                abaAnalitico.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                abaAnalitico.Name = "Custo analítico"; //AdicionAND o o nome a planilha
                                                       //Identar tabela

            
                foreach (Excel.Worksheet wrkst in CustoMedio.Worksheets)
                {
                    Excel.Range usedrange = wrkst.UsedRange;
                    usedrange.Columns.AutoFit();

                }
            
            
            
            var xlSheets = CustoMedio.Sheets as Excel.Sheets;
            var abaSintetico = (Excel.Worksheet)xlSheets.Add(xlSheets[1], Type.Missing, Type.Missing, Type.Missing);
            abaSintetico.Name = "Custo sintético";
            abaSintetico = (Excel.Worksheet)CustoMedio.Worksheets.get_Item(1);
            CopyToClipboardWithHeaders(dgvCustoSintetico);
            Excel.Range CR2 = (Excel.Range)abaSintetico.Cells[1, 1];
            CR2.Rows.AutoFit();
            CR2.Select();
            rng1 = abaSintetico.get_Range("A1", "Z1");
            rng1.Font.Bold = true;
            rng1.Font.ColorIndex = 3;
            rng1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            abaSintetico.PasteSpecial(CR2, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
            //Identar tabela
            foreach (Excel.Worksheet wrkst in CustoMedio.Worksheets)
            {
                Excel.Range usedrange = wrkst.UsedRange;
                usedrange.Columns.AutoFit();
            }

        
            //Identar tabela
            foreach (Excel.Worksheet wrkst in CustoMedio.Worksheets)
            {
                Excel.Range usedrange = wrkst.UsedRange;
                usedrange.Columns.AutoFit();

            }

        }
    }
}
