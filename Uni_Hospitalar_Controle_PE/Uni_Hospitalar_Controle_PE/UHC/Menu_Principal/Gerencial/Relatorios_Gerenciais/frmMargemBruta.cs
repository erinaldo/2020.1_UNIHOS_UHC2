using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Excel = Microsoft.Office.Interop.Excel;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Gerencial.Relatorios_Gerenciais
{
    public partial class frmMargemBruta : Form
    {
        public frmMargemBruta()
        {
            InitializeComponent();
        }

        //Instância hereditária
        //public int Unidade_Servidor;

        //Variáveis de TextBox
        private String mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave

        //Erro sql
        private void erroSQLE(SqlException SQLe)
        {
            mMessage = "Erro de acesso ao servidor: " + SQLe.Message;
            mTittle = "SQL Server error";
            mButton = MessageBoxButtons.OK;
            mIcon = MessageBoxIcon.Error;
            MessageBox.Show(mMessage, mTittle, mButton, mIcon);
        }




        //SQL
        //Ano atual
        private SqlCommand command_Consulta = new SqlCommand();
        private SqlDataReader reader_Consulta;

        List<int>    lAno               = new List<int>();
        List<int>    lMes               = new List<int>();
        List<int>    lCodigo            = new List<int>();
        List<String> lDescricao         = new List<String>();
        List<int>    lQuantidade        = new List<int>();
        List<double> lTotal_Compras     = new List<double>();
        List<double> lTotal_Vendas      = new List<double>();
        double dValor_Total = 0;
                      
        //Configurações iniciais
        private void configuracoes_Iniciais()
        {
            //
            dgvRelatorios.Visible = false;
            //Relatório Gerencial Produto x Fabricante
            cbxProdutosRelatoriosEspeciais.Items.Add("Produtos x Fabricantes");
            cbxProdutosRelatoriosEspeciais.Items.Add("Tot por Estados");


            //Parâmetros iniciais
            //mtxAno.Text = mtxAno.Text = DateTime.Now.Year.ToString();
            mtxAno.Text = "2021";
            mtxTop.Text = "20";
            dtpCorte.Value = DateTime.Now;
            dtpCorte.Enabled = false;

    
            rdbAnual.Checked = true;


            //Execução
            btnProdutos.BackColor = Color.DarkSeaGreen;
            cbxProdutosRelatoriosEspeciais.Enabled = true;

            configurar_DataGridView();
            carregar_Consulta("Produtos");
            inserir_Dados();
            identar_dgvDados();
            filtrar_Grid();

        }






        private void carregar_Consulta(String fonte_Dados)
        {
            this.Cursor = Cursors.WaitCursor;

            lAno.Clear();
            lMes.Clear();
            lCodigo.Clear();
            lDescricao.Clear();
            lQuantidade.Clear();
            lTotal_Compras  .Clear();
            lTotal_Vendas.Clear();





            String codigo_Fonte = null
                    , descricao_Fonte = null
                    , condicao_Fonte = null
                    , Top = null
                    , dat_Corte = null;

            if (chkDataCorte.Checked)
            {
                dat_Corte = " AND NF_Saida.Dat_Emissao <= '"+dtpCorte.Value.ToString("yyyy-MM-dd HH:mm:ss")+"'";
            }
            
          

            if (fonte_Dados.Equals("Fabricantes"))
            {
                codigo_Fonte = " Fabricante.Codigo ";
                descricao_Fonte = "Fabricante.Fantasia ";
            }
            else if (fonte_Dados.Equals("Produtos"))
            {
                codigo_Fonte = " Produto.Codigo ";
                descricao_Fonte = " Produto.Descricao ";
            }
            else if (fonte_Dados.Equals("Clientes"))
            {
                codigo_Fonte = " Cliente.Codigo ";
                descricao_Fonte = " Cliente.Razao_Social ";
            }
            else if (fonte_Dados.Equals("Clientes_Privados"))
            {
                codigo_Fonte = " Cliente.Codigo ";
                descricao_Fonte = " Cliente.Razao_Social ";
                condicao_Fonte = " AND Cliente.Tipo_Consumidor IN ('N','F')";
            }
            else if (fonte_Dados.Equals("Clientes_Publicos"))
            {
                codigo_Fonte = " Cliente.Codigo ";
                descricao_Fonte = " Cliente.Razao_Social";
                condicao_Fonte = " AND Cliente.Tipo_Consumidor NOT IN ('N','F') ";
            }



            //MessageBox.Show(Usuario.unidade_Login);
                //Carregar Consulta Ano Atual
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command_Consulta = connectDMD.CreateCommand();
                        command_Consulta.CommandText =
                                                 " SELECT	"+Top
                                                +"       "+codigo_Fonte+"                           [Codigo]                                                                                                                   " 
                                                +"      ,"+descricao_Fonte+"                        [Descricao]                   " 
                                                +"      , Fabricante.Fantasia [Fabricante] "                                                                                             
                                                +"      ,MONTH(NF_Saida.Dat_Emissao)                [Mes]                                                                                                                      " 
                                                +"      ,YEAR(NF_Saida.Dat_Emissao)                 [Ano]                                                                                                                      " 
                                                +"      ,[Qtd_Vendas] = SUM(Custo.Qtd_Movimento)                                                                                                                               " 
                                                +"      ,[Tot_Compras] =SUM(Custo.CustoTotal)                                                                                                                                " 
                                                +"      ,[Tot_Vendas] = SUM(Custo.Faturamento)                                                                                                                                 " 
                                                +"      ,[Tot_Geral] = (SELECT SUM(Custo_Total.Faturamento)                                                                                                                    " 
                                                +"                       FROM [UNIDB].dbo.[CUSTO_MEDIO] Custo_Total JOIN[DMD].dbo.[NFSCB] NF_Saida_Total ON NF_Saida_Total.Num_Nota = Custo_Total.Protocolo_NF                 " 
                                                +"                       WHERE YEAR(NF_Saida_Total.Dat_Emissao) IN("+mtxAno.Text+ ") AND Custo.Tipo_Operacao = 'Saida' AND NF_Saida_Total.Tip_Saida IN('V') AND NF_Saida_Total.STATUS = 'F'                 )                                                                    "
                                                + "      FROM[DMD].dbo.[NFScb] NF_Saida                                                                                                                                         "
                                                +"      JOIN[UNIDB].dbo.[CUSTO_MEDIO] CUSTO ON Custo.Protocolo_NF = NF_SAIDA.Num_nota                                                                                          "                                                
                                                +"                                            AND Custo.Tipo_Operacao = 'Saida'                                                                                                "
                                                +"      JOIN[DMD].dbo.[PRODU] Produto ON Produto.Codigo = Custo.Cod_Produto                                                                                                    "
                                                +"      JOIN[DMD].dbo.[FABRI] Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante                                                                                         "
                                                +"      JOIN[DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Saida.Cod_Cliente                                                                                                 "
                                                + condicao_Fonte
                                                +"      WHERE  1=1                                                                                                                                                                 "                                                
                                                +"      AND year(NF_SAIDA.Dat_emissao) IN ("+mtxAno.Text+") "
                                                +dat_Corte
                                                +"      AND NF_Saida.Tip_Saida IN('V') AND STATUS = 'F'                                                                                                                        "
                                                +"                                                                                                                                                                             "
                                                +"      GROUP BY                                                                                                                                                               "
                                                +"                                                                                                                                                                             "
                                                +"              "+ codigo_Fonte + "                                                                                                                                           "
                                                +"      		,"+descricao_Fonte+"   " 
                                                +"              ,Fabricante.Fantasia                                                                                                                                        "
                                                +"      		,MONTH(NF_Saida.Dat_Emissao)                                                                                                                                   "
                                                +"      		,YEAR(NF_Saida.Dat_Emissao)                                                                                                                                    "
                                                +"      		,Custo.Tipo_Operacao                                                                                                                                           "
                                                +" ORDER BY Codigo asc, Ano DESC, Mes asc                                                                                                                                     "    ; 


                                                   
                        reader_Consulta = command_Consulta.ExecuteReader();



                        while (reader_Consulta.Read())
                        {
                            if (reader_Consulta["Tot_Geral"] != null)
                            {
                                //MessageBox.Show(reader_Consulta["Codigo"].ToString());
                                lCodigo.Add(Convert.ToInt32(reader_Consulta["Codigo"].ToString()));
                                lDescricao.Add(reader_Consulta["Descricao"].ToString());
                                lMes.Add(Convert.ToInt32(reader_Consulta["Mes"].ToString()));
                                lAno.Add(Convert.ToInt32(reader_Consulta["Ano"].ToString()));
                                lQuantidade.Add(Convert.ToInt32(reader_Consulta["Qtd_Vendas"].ToString()));
                                lTotal_Vendas.Add(Convert.ToDouble(reader_Consulta["Tot_Vendas"].ToString()));
                                lTotal_Compras.Add(Convert.ToDouble(reader_Consulta["Tot_Compras"].ToString()));
                                dValor_Total = Convert.ToDouble(reader_Consulta["Tot_Geral"].ToString());

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
           
            this.Cursor = Cursors.Default;



        }

        private void carregar_Consulta_Estado()
        {
            this.Cursor = Cursors.WaitCursor;

            DataTable dt = new DataTable();
            String dat_Corte = null;

            if (chkDataCorte.Checked)
            {
                dat_Corte = " AND NF_Saida.Dat_Emissao <= '" + dtpCorte.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            //Carregar Consulta Ano Atual
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command_Consulta = connectDMD.CreateCommand();
                    command_Consulta.CommandTimeout = 500;
                    command_Consulta.CommandText =
                                             " DECLARE @TOTAL NUMERIC(20,4)                                                                              "
                                            +" SET @TOTAL =                                                                                              "
                                            +"(SELECT SUM(Custo_Total.Faturamento)                                                                       "                                            
                                            +" FROM[UNIDB].dbo.[CUSTO_MEDIO] Custo_Total                                                                 "                                            
                                            +" JOIN[DMD].dbo.[NFSCB] NF_Saida_Total                                                                      "                                            
                                            +" ON NF_Saida_Total.Num_Nota = Custo_Total.Protocolo_NF                                                     "                                            
                                            + " WHERE YEAR(NF_Saida_Total.Dat_Emissao) IN("+mtxAno.Text+") AND Custo_Total.Tipo_Operacao = 'Saida'                   "
                                            + dat_Corte
                                            + " AND NF_Saida_Total.Tip_Saida IN('V') AND NF_Saida_Total.STATUS = 'F')                                     "                                                  
                                            + "                                                                                                          "                                            
                                            + " SELECT                                                                                                   "
                                            + "       NF_Saida.Estado                                                                                    "
                                            + "      ,YEAR(NF_Saida.Dat_Emissao)[Ano]                                                                    "
                                            + "      ,[Qtd_Vendas] = SUM(Custo.Qtd_Movimento)                                                            "
                                            + "      ,[Tot_Vendas] = SUM(Custo.Faturamento)                                                              "
                                            + " 	 ,[Tot_Compras] = SUM(Custo.CustoTotal)                                                              "
                                            + " 	 ,[% Margem Bruta] = (SUM(Custo.Faturamento) / SUM(Custo.CustoTotal)) - 1                            "
                                            + " 	 ,[% Total Faturamento] = SUM(Custo.Faturamento) / (SELECT SUM(Custo_Total.Faturamento)              "
                                            + "                                                                                                          "
                                            + "                 FROM[UNIDB].dbo.[CUSTO_MEDIO] Custo_Total                                                "
                                            + "                JOIN[DMD].dbo.[NFSCB] NF_Saida_Total                                                      "
                                            + "               ON NF_Saida_Total.Num_Nota = Custo_Total.Protocolo_NF                                      "
                                            + "                                                                                                          "
                                            + "                 WHERE YEAR(NF_Saida_Total.Dat_Emissao) IN (" + mtxAno.Text + ") AND Custo_Total.Tipo_Operacao = 'Saida'  "
                                            + "                                                                                                          "
                                            + "                 AND NF_Saida_Total.Tip_Saida IN('V') AND NF_Saida_Total.STATUS = 'F')                    "                                            
                                            + "      FROM[DMD].dbo.[NFScb] NF_Saida                                                                      "
                                            + "      JOIN[UNIDB].dbo.[CUSTO_MEDIO] CUSTO ON Custo.Protocolo_NF = NF_SAIDA.Num_nota                       "
                                            + "                                            AND Custo.Tipo_Operacao = 'Saida'                             "
                                            + "      JOIN[DMD].dbo.[PRODU] Produto ON Produto.Codigo = Custo.Cod_Produto                                 "
                                            + "      JOIN[DMD].dbo.[FABRI] Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante                      "
                                            + "      JOIN[DMD].dbo.[CLIEN] Cliente ON Cliente.Codigo = NF_Saida.Cod_Cliente                              "
                                            + "                                                                                                          "
                                            + "       WHERE  1 = 1                                                                                       "
                                            + dat_Corte
                                            + "       AND year(NF_SAIDA.Dat_emissao) IN ("+mtxAno.Text+")                                                            "
                                            + "      AND NF_Saida.Tip_Saida IN('V') AND STATUS = 'F'                                                     "                                            
                                            + "      GROUP BY                                                                                            "
                                            + "             NF_Saida.Estado                                                                              "
                                            + "      		,YEAR(NF_Saida.Dat_Emissao)                                                                  "
                                            + "      		,Custo.Tipo_Operacao                                                                         "
                                            + " ORDER BY[Tot_Vendas] desc                                                                                ";

                    SqlDataAdapter adaptador = new SqlDataAdapter(command_Consulta);
                    adaptador.Fill(dt);
                    dgvRelatorios.DataSource = dt;
                    exportarExcel(dgvRelatorios);

                }
                catch (SqlException SQLe)
                {
                    erroSQLE(SQLe);
                }
                finally
                {
                    connectDMD.Close();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void frmMargemBruta_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;

            configuracoes_Iniciais();



        }

        private void inserir_Dados()
        {

            int flg_Alterar = 0;
            if (rdbAnual.Checked) {
                for (int x=0;x<lDescricao.Count;x++)
                {
                    if (x == 0)
                    {
                        if (lTotal_Compras[x] != 0)
                        {
                            dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x], lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total);
                        }
                        else
                        {
                            dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x], lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total);
                        }

                    }

                    flg_Alterar = 0;
                    foreach(DataGridViewRow row in dgvDados.Rows)
                    {
                        if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x]) {

                            row.Cells[3].Value = Convert.ToInt64(row.Cells[3].Value) + lQuantidade[x];
                            row.Cells[4].Value = Convert.ToDouble(row.Cells[4].Value) + lTotal_Vendas[x];
                            row.Cells[5].Value = Convert.ToDouble(row.Cells[5].Value) + lTotal_Compras[x];
                            row.Cells[6].Value =(Convert.ToDouble(row.Cells[4].Value )/ Convert.ToDouble(row.Cells[5].Value))-1;
                            row.Cells[7].Value =   Convert.ToDouble(row.Cells[4].Value) / dValor_Total ;
                            flg_Alterar=1;
                        }
                    }
                    if (flg_Alterar ==0)
                    {
                        if (lTotal_Compras[x] != 0)
                        {
                            dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x], lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total);
                        }
                        else
                        {
                            dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x], lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total);
                        }
                    }                                       
                }
            }
            else
            {
                for (int x = 0; x < lDescricao.Count; x++)
                {
                    if (x == 0)
                    {
                        if (lTotal_Compras[x] != 0)
                        {
                            if (lMes[x] == 1)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 2)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 3)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 4)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 5)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 6)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 7)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 8)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 9)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 10)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 11)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 12)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }

                        }
                        else
                        {
                            if (lMes[x] == 1)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 2)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 3)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 4)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 5)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 6)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 7)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 8)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 9)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 10)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 11)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }
                            else if (lMes[x] == 12)
                            {
                                dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                 , 0, 0, 0, 0, 0    //Fev
                                                 , 0, 0, 0, 0, 0    //Mar
                                                 , 0, 0, 0, 0, 0    //Abr
                                                 , 0, 0, 0, 0, 0    //Mai
                                                 , 0, 0, 0, 0, 0    //Jun
                                                 , 0, 0, 0, 0, 0    //Jul
                                                 , 0, 0, 0, 0, 0    //Ago
                                                 , 0, 0, 0, 0, 0    //Set
                                                 , 0, 0, 0, 0, 0    //Out
                                                 , 0, 0, 0, 0, 0    //Nov
                                                 , 0, 0, 0, 0, 0    //Dez
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                 , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                  );
                            }


                        }


                    }

                    flg_Alterar = 0;
                    if (x > 0)
                    {
                        foreach (DataGridViewRow row in dgvDados.Rows)
                        {
                            if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x] && lMes[x] == 1)
                            {
                                row.Cells[3].Value = Convert.ToInt64(row.Cells[3].Value) + lQuantidade[x];
                                row.Cells[4].Value = Convert.ToDouble(row.Cells[4].Value) + lTotal_Vendas[x];
                                row.Cells[5].Value = Convert.ToDouble(row.Cells[5].Value) + lTotal_Compras[x];
                                row.Cells[6].Value = (Convert.ToDouble(row.Cells[6].Value) / Convert.ToDouble(row.Cells[5].Value)) - 1;
                                row.Cells[7].Value = Convert.ToDouble(row.Cells[7].Value) / dValor_Total;
                                flg_Alterar = 1;
                            }
                            else if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x] && lMes[x] == 2)
                            {
                                row.Cells[8].Value = Convert.ToInt64(row.Cells[8].Value) + lQuantidade[x];
                                row.Cells[9].Value = Convert.ToDouble(row.Cells[9].Value) + lTotal_Vendas[x];
                                row.Cells[10].Value = Convert.ToDouble(row.Cells[10].Value) + lTotal_Compras[x];
                                row.Cells[11].Value = (Convert.ToDouble(row.Cells[9].Value) / Convert.ToDouble(row.Cells[10].Value)) - 1;
                                row.Cells[12].Value = Convert.ToDouble(row.Cells[9].Value) / dValor_Total;
                                flg_Alterar = 1;
                            }
                            else if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x] && lMes[x] == 3)
                            {
                                row.Cells[13].Value = Convert.ToInt64(row.Cells[13].Value) + lQuantidade[x];
                                row.Cells[14].Value = Convert.ToDouble(row.Cells[14].Value) + lTotal_Vendas[x];
                                row.Cells[15].Value = Convert.ToDouble(row.Cells[15].Value) + lTotal_Compras[x];
                                row.Cells[16].Value = (Convert.ToDouble(row.Cells[14].Value) / Convert.ToDouble(row.Cells[15].Value)) - 1;
                                row.Cells[17].Value = Convert.ToDouble(row.Cells[14].Value) / dValor_Total;
                                flg_Alterar = 1;
                            }
                            else if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x] && lMes[x] == 4)
                            {
                                row.Cells[18].Value = Convert.ToInt64(row.Cells[18].Value) + lQuantidade[x];
                                row.Cells[19].Value = Convert.ToDouble(row.Cells[19].Value) + lTotal_Vendas[x];
                                row.Cells[20].Value = Convert.ToDouble(row.Cells[20].Value) + lTotal_Compras[x];
                                row.Cells[21].Value = (Convert.ToDouble(row.Cells[19].Value) / Convert.ToDouble(row.Cells[20].Value)) - 1;
                                row.Cells[22].Value = Convert.ToDouble(row.Cells[19].Value) / dValor_Total;
                                flg_Alterar = 1;
                            }
                            else if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x] && lMes[x] == 5)
                            {
                                row.Cells[23].Value = Convert.ToInt64(row.Cells[23].Value) + lQuantidade[x];
                                row.Cells[24].Value = Convert.ToDouble(row.Cells[24].Value) + lTotal_Vendas[x];
                                row.Cells[25].Value = Convert.ToDouble(row.Cells[25].Value) + lTotal_Compras[x];
                                row.Cells[26].Value = (Convert.ToDouble(row.Cells[24].Value) / Convert.ToDouble(row.Cells[25].Value)) - 1;
                                row.Cells[27].Value = Convert.ToDouble(row.Cells[24].Value) / dValor_Total;
                                flg_Alterar = 1;
                            }
                            else if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x] && lMes[x] == 6)
                            {
                                row.Cells[28].Value = Convert.ToInt64(row.Cells[28].Value) + lQuantidade[x];
                                row.Cells[29].Value = Convert.ToDouble(row.Cells[29].Value) + lTotal_Vendas[x];
                                row.Cells[30].Value = Convert.ToDouble(row.Cells[30].Value) + lTotal_Compras[x];
                                row.Cells[31].Value = (Convert.ToDouble(row.Cells[29].Value) / Convert.ToDouble(row.Cells[30].Value)) - 1;
                                row.Cells[32].Value = Convert.ToDouble(row.Cells[29].Value) / dValor_Total;
                                flg_Alterar = 1;
                            }
                            else if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x] && lMes[x] == 7)
                            {
                                row.Cells[33].Value = Convert.ToInt64(row.Cells[33].Value) + lQuantidade[x];
                                row.Cells[34].Value = Convert.ToDouble(row.Cells[34].Value) + lTotal_Vendas[x];
                                row.Cells[35].Value = Convert.ToDouble(row.Cells[35].Value) + lTotal_Compras[x];
                                row.Cells[36].Value = (Convert.ToDouble(row.Cells[34].Value) / Convert.ToDouble(row.Cells[35].Value)) - 1;
                                row.Cells[37].Value = Convert.ToDouble(row.Cells[34].Value) / dValor_Total;
                                flg_Alterar = 1;
                            }
                            else if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x] && lMes[x] == 8)
                            {
                                row.Cells[38].Value = Convert.ToInt64(row.Cells[38].Value) + lQuantidade[x];
                                row.Cells[39].Value = Convert.ToDouble(row.Cells[39].Value) + lTotal_Vendas[x];
                                row.Cells[40].Value = Convert.ToDouble(row.Cells[40].Value) + lTotal_Compras[x];
                                row.Cells[41].Value = (Convert.ToDouble(row.Cells[39].Value) / Convert.ToDouble(row.Cells[40].Value)) - 1;
                                row.Cells[42].Value = Convert.ToDouble(row.Cells[39].Value) / dValor_Total;
                                flg_Alterar = 1;
                            }
                            else if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x] && lMes[x] == 9)
                            {
                                row.Cells[43].Value = Convert.ToInt64(row.Cells[43].Value) + lQuantidade[x];
                                row.Cells[44].Value = Convert.ToDouble(row.Cells[44].Value) + lTotal_Vendas[x];
                                row.Cells[45].Value = Convert.ToDouble(row.Cells[45].Value) + lTotal_Compras[x];
                                row.Cells[46].Value = (Convert.ToDouble(row.Cells[44].Value) / Convert.ToDouble(row.Cells[45].Value)) - 1;
                                row.Cells[47].Value = Convert.ToDouble(row.Cells[44].Value) / dValor_Total;
                                flg_Alterar = 1;
                            }
                            else if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x] && lMes[x] == 10)
                            {
                                row.Cells[48].Value = Convert.ToInt64(row.Cells[48].Value) + lQuantidade[x];
                                row.Cells[49].Value = Convert.ToDouble(row.Cells[49].Value) + lTotal_Vendas[x];
                                row.Cells[50].Value = Convert.ToDouble(row.Cells[50].Value) + lTotal_Compras[x];
                                row.Cells[51].Value = (Convert.ToDouble(row.Cells[49].Value) / Convert.ToDouble(row.Cells[50].Value)) - 1;
                                row.Cells[52].Value = Convert.ToDouble(row.Cells[49].Value) / dValor_Total;
                                flg_Alterar = 1;
                            }
                            else if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x] && lMes[x] == 11)
                            {
                                row.Cells[53].Value = Convert.ToInt64(row.Cells[53].Value) + lQuantidade[x];
                                row.Cells[54].Value = Convert.ToDouble(row.Cells[54].Value) + lTotal_Vendas[x];
                                row.Cells[55].Value = Convert.ToDouble(row.Cells[55].Value) + lTotal_Compras[x];
                                row.Cells[56].Value = (Convert.ToDouble(row.Cells[54].Value) / Convert.ToDouble(row.Cells[55].Value)) - 1;
                                row.Cells[57].Value = Convert.ToDouble(row.Cells[54].Value) / dValor_Total;
                                flg_Alterar = 1;
                            }
                            else if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x] && lMes[x] == 12)
                            {
                                row.Cells[58].Value = Convert.ToInt64(row.Cells[58].Value) + lQuantidade[x];
                                row.Cells[59].Value = Convert.ToDouble(row.Cells[59].Value) + lTotal_Vendas[x];
                                row.Cells[60].Value = Convert.ToDouble(row.Cells[60].Value) + lTotal_Compras[x];
                                row.Cells[61].Value = (Convert.ToDouble(row.Cells[59].Value) / Convert.ToDouble(row.Cells[60].Value)) - 1;
                                row.Cells[62].Value = Convert.ToDouble(row.Cells[59].Value) / dValor_Total;
                                flg_Alterar = 1;
                            }


                            if (Convert.ToInt64(row.Cells[0].Value) == lAno[x] && Convert.ToInt32(row.Cells[1].Value) == lCodigo[x])
                            {
                                row.Cells[63].Value = Convert.ToInt64(row.Cells[63].Value) + lQuantidade[x];
                                row.Cells[64].Value = Convert.ToDouble(row.Cells[64].Value) + lTotal_Vendas[x];
                                row.Cells[65].Value = Convert.ToDouble(row.Cells[65].Value) + lTotal_Compras[x];
                                row.Cells[66].Value = (Convert.ToDouble(row.Cells[64].Value) / Convert.ToDouble(row.Cells[65].Value)) - 1;
                                row.Cells[67].Value = Convert.ToDouble(row.Cells[65].Value) / dValor_Total;
                                flg_Alterar = 1;
                            }

                        }
                        if (flg_Alterar == 0)
                        {
                            if (lTotal_Compras[x] != 0)
                            {
                                if (lMes[x] == 1)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 2)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 3)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 4)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 5)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 6)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 7)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 8)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 9)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 10)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 11)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 12)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / lTotal_Compras[x]) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }

                            }
                            else
                            {
                                if (lMes[x] == 1)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 2)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 3)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 4)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 5)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 6)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 7)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 8)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 9)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 10)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 11)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }
                                else if (lMes[x] == 12)
                                {
                                    dgvDados.Rows.Add(lAno[x], lCodigo[x], lDescricao[x]      //Top
                                                     , 0, 0, 0, 0, 0    //Fev
                                                     , 0, 0, 0, 0, 0    //Mar
                                                     , 0, 0, 0, 0, 0    //Abr
                                                     , 0, 0, 0, 0, 0    //Mai
                                                     , 0, 0, 0, 0, 0    //Jun
                                                     , 0, 0, 0, 0, 0    //Jul
                                                     , 0, 0, 0, 0, 0    //Ago
                                                     , 0, 0, 0, 0, 0    //Set
                                                     , 0, 0, 0, 0, 0    //Out
                                                     , 0, 0, 0, 0, 0    //Nov
                                                     , 0, 0, 0, 0, 0    //Dez
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Jan
                                                     , lQuantidade[x], lTotal_Vendas[x], lTotal_Compras[x], (lTotal_Vendas[x] / 1) - 1, lTotal_Vendas[x] / dValor_Total  //Total
                                                      );
                                }


                            }

                        }
                    }
                }
                }
        }


        //Parametrizar visualização do Grid
        private void configurar_DataGridView()
        {


            dgvDados.Rows.Clear();
            dgvDados.Columns.Clear();
            if (rdbMensal.Checked)
            {

                //Cabeçalho
                dgvDados.Columns.Add("1Ano", "Ano");
                dgvDados.Columns.Add("2Codigo", "Código");
                dgvDados.Columns.Add("3Descricao", "Descrição");


                //Janeiro
                dgvDados.Columns.Add("4Jan_Quantidade", "Jan | Qtd. Vendas");
                dgvDados.Columns.Add("5Jan_Vendas", "Jan | Vendas");
                dgvDados.Columns.Add("6Jan_Compras", "Jan | Compras");
                dgvDados.Columns.Add("7Jan_MargemBruta", "Jan | Margem Bruta");
                dgvDados.Columns.Add("8Jan_Perc_Total", "Jan | % do Faturamento");

                //Fevereiro
                dgvDados.Columns.Add("9Fev_Quantidade", "Fev | Qtd. Vendas");
                dgvDados.Columns.Add("10Fev_Vendas", "Fev | Vendas");
                dgvDados.Columns.Add("11Fev_Compras", "Fev | Compras");
                dgvDados.Columns.Add("12Fev_MargemBruta", "Fev | Margem Bruta");
                dgvDados.Columns.Add("13Fev_Perc_Total", "Fev | % do Faturamento");

                //Março
                dgvDados.Columns.Add("14Mar_Quantidade", "Mar | Qtd. Vendas");
                dgvDados.Columns.Add("15Mar_Vendas", "Mar | Vendas");
                dgvDados.Columns.Add("16Mar_Compras", "Mar | Compras");
                dgvDados.Columns.Add("17Mar_MargemBruta", "Mar | Margem Bruta");
                dgvDados.Columns.Add("18Mar_Perc_Total", "Mar | % do Faturamento");

                //Abril
                dgvDados.Columns.Add("19Abr_Quantidade", "Abr | Qtd. Vendas");
                dgvDados.Columns.Add("20Abr_Vendas", "Abr | Vendas");
                dgvDados.Columns.Add("21Abr_Compras", "Abr | Compras");
                dgvDados.Columns.Add("22Abr_MargemBruta", "Abr | Margem Bruta");
                dgvDados.Columns.Add("23Abr_Perc_Total", "Abr | % do Faturamento");

                //Maio
                dgvDados.Columns.Add("24Mai_Quantidade", "Mai | Qtd. Vendas");
                dgvDados.Columns.Add("25Mai_Vendas", "Mai | Vendas");
                dgvDados.Columns.Add("26Mai_Compras", "Mai | Compras");
                dgvDados.Columns.Add("27Mai_MargemBruta", "Mai | Margem Bruta");
                dgvDados.Columns.Add("28Mai_Perc_Total", "Mai | % do Faturamento");

                //Junho
                dgvDados.Columns.Add("29Jun_Quantidade", "Jun | Qtd. Vendas");
                dgvDados.Columns.Add("30Jun_Vendas", "Jun | Vendas");
                dgvDados.Columns.Add("31Jun_Compras", "Jun | Compras");
                dgvDados.Columns.Add("32Jun_MargemBruta", "Jun | Margem Bruta");
                dgvDados.Columns.Add("33Jun_Perc_Total", "Jun | % do Faturamento");

                //Julho
                dgvDados.Columns.Add("34Jul_Quantidade", "Jul | Qtd. Vendas");
                dgvDados.Columns.Add("35Jul_Vendas", "Jul | Vendas");
                dgvDados.Columns.Add("36Jul_Compras", "Jul | Compras");
                dgvDados.Columns.Add("37Jul_MargemBruta", "Jul | Margem Bruta");
                dgvDados.Columns.Add("38Jul_Perc_Total", "Jul | % do Faturamento");

                //Agosto
                dgvDados.Columns.Add("39Ago_Quantidade", "Ago | Qtd. Vendas");
                dgvDados.Columns.Add("40Ago_Vendas", "Ago | Vendas");
                dgvDados.Columns.Add("41Ago_Compras", "Ago | Compras");
                dgvDados.Columns.Add("42Ago_MargemBruta", "Ago | Margem Bruta");
                dgvDados.Columns.Add("43Ago_Perc_Total", "Ago | % do Faturamento");

                //Setembro
                dgvDados.Columns.Add("44Set_Quantidade", "Set | Qtd. Vendas");
                dgvDados.Columns.Add("45Set_Vendas", "Set | Vendas");
                dgvDados.Columns.Add("46Set_Compras", "Set | Compras");
                dgvDados.Columns.Add("47Set_MargemBruta", "Set | Margem Bruta");
                dgvDados.Columns.Add("48Set_Perc_Total", "Set | % do Faturamento");

                //Outubro
                dgvDados.Columns.Add("49Out_Quantidade", "Out | Qtd. Vendas");
                dgvDados.Columns.Add("50Out_Vendas", "Out | Vendas");
                dgvDados.Columns.Add("51Out_Compras", "Out | Compras");
                dgvDados.Columns.Add("52Out_MargemBruta", "Out | Margem Bruta");
                dgvDados.Columns.Add("53Out_Perc_Total", "Out | % do Faturamento");

                //Novembro
                dgvDados.Columns.Add("54Nov_Quantidade", "Nov | Qtd. Vendas");
                dgvDados.Columns.Add("55Nov_Vendas", "Nov | Vendas");
                dgvDados.Columns.Add("56Nov_Compras", "Nov | Compras");
                dgvDados.Columns.Add("57Nov_MargemBruta", "Nov | Margem Bruta");
                dgvDados.Columns.Add("58Nov_Perc_Total", "Nov | % do Faturamento");

                //Dezembro
                dgvDados.Columns.Add("59Dez_Quantidade", "Dez | Qtd. Vendas");
                dgvDados.Columns.Add("60Dez_Vendas", "Dez | Vendas");
                dgvDados.Columns.Add("61Dez_Compras", "Dez | Compras");
                dgvDados.Columns.Add("62Dez_MargemBruta", "Dez | Margem Bruta");
                dgvDados.Columns.Add("63Dez_Perc_Total", "Dez | % do Faturamento");

                //Total
                dgvDados.Columns.Add("64Total_Quantidade", "Tot | Qtd. Vendas");
                dgvDados.Columns.Add("65Total_Vendas", "Tot | Vendas");
                dgvDados.Columns.Add("66Total_Compras", "Tot | Compras");
                dgvDados.Columns.Add("67Total_MargemBruta", "Tot | Margem Bruta");
                dgvDados.Columns.Add("68Total_Perc_Total", "Tot | % do Faturamento");

                
            }
            else
            {
                dgvDados.Columns.Add("Ano", "Ano");
                dgvDados.Columns.Add("Codigo", "Código");
                dgvDados.Columns.Add("Descricao", "Descrição");
                dgvDados.Columns.Add("Total_Quantidade", "Tot | Qtd. Vendas");
                dgvDados.Columns.Add("Total_Vendas", "Tot | Vendas");
                dgvDados.Columns.Add("Total_Compras", "Tot | Compras");
                dgvDados.Columns.Add("Total_MargemBruta", "Tot | % Margem Bruta");
                dgvDados.Columns.Add("Total_Perc_Total", "Tot | % do Faturamento");



                
            }
            dgvDados.Columns[2].Width = 250;
        }

        private void identar_dgvDados()
        {
            if (rdbMensal.Checked)
            {           
dgvDados.Columns["5Jan_Vendas"].ValueType = typeof(decimal);
dgvDados.Columns["6Jan_Compras"  ] .ValueType = typeof(decimal);
dgvDados.Columns["10Fev_Vendas"  ] .ValueType = typeof(decimal);
dgvDados.Columns["11Fev_Compras"  ].ValueType = typeof(decimal);
dgvDados.Columns["15Mar_Vendas"  ] .ValueType = typeof(decimal);
dgvDados.Columns["16Mar_Compras"  ].ValueType = typeof(decimal);
dgvDados.Columns["20Abr_Vendas"  ] .ValueType = typeof(decimal);
dgvDados.Columns["21Abr_Compras"  ].ValueType = typeof(decimal);
dgvDados.Columns["25Mai_Vendas"  ] .ValueType = typeof(decimal);
dgvDados.Columns["26Mai_Compras"  ].ValueType = typeof(decimal);
dgvDados.Columns["30Jun_Vendas"  ] .ValueType = typeof(decimal);
dgvDados.Columns["31Jun_Compras"  ].ValueType = typeof(decimal);
dgvDados.Columns["35Jul_Vendas"  ] .ValueType = typeof(decimal);
dgvDados.Columns["36Jul_Compras"  ].ValueType = typeof(decimal);
dgvDados.Columns["40Ago_Vendas"  ] .ValueType = typeof(decimal);
dgvDados.Columns["41Ago_Compras"  ].ValueType = typeof(decimal);
dgvDados.Columns["45Set_Vendas"  ] .ValueType = typeof(decimal);
dgvDados.Columns["46Set_Compras"  ].ValueType = typeof(decimal);
dgvDados.Columns["50Out_Vendas"  ] .ValueType = typeof(decimal);
dgvDados.Columns["51Out_Compras"  ].ValueType = typeof(decimal);
dgvDados.Columns["55Nov_Vendas"  ] .ValueType = typeof(decimal);
dgvDados.Columns["56Nov_Compras"  ].ValueType = typeof(decimal);
dgvDados.Columns["60Dez_Vendas"  ] .ValueType = typeof(decimal);
dgvDados.Columns["61Dez_Compras"  ].ValueType = typeof(decimal);
dgvDados.Columns["65Total_Vendas" ].ValueType = typeof(decimal);
dgvDados.Columns["66Total_Compras"].ValueType = typeof(decimal);
dgvDados.Columns["5Jan_Vendas"].    DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["6Jan_Compras"].   DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["10Fev_Vendas"].   DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["11Fev_Compras"].  DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["15Mar_Vendas"].   DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["16Mar_Compras"].  DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["20Abr_Vendas"].   DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["21Abr_Compras"].  DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["25Mai_Vendas"].   DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["26Mai_Compras"].  DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["30Jun_Vendas"].   DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["31Jun_Compras"].  DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["35Jul_Vendas"].   DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["36Jul_Compras"].  DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["40Ago_Vendas"].   DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["41Ago_Compras"].  DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["45Set_Vendas"].   DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["46Set_Compras"].  DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["50Out_Vendas"].   DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["51Out_Compras"].  DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["55Nov_Vendas"].   DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["56Nov_Compras"].  DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["60Dez_Vendas"].   DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["61Dez_Compras"].  DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["65Total_Vendas"]. DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["66Total_Compras"].DefaultCellStyle.Format = "R$ #,##0.00";
dgvDados.Columns["7Jan_MargemBruta"]    .ValueType = typeof(decimal);
dgvDados.Columns["8Jan_Perc_Total"]     .ValueType = typeof(decimal);
dgvDados.Columns["12Fev_MargemBruta"]   .ValueType = typeof(decimal);
dgvDados.Columns["13Fev_Perc_Total"]    .ValueType = typeof(decimal);
dgvDados.Columns["17Mar_MargemBruta"]   .ValueType = typeof(decimal);
dgvDados.Columns["18Mar_Perc_Total"]    .ValueType = typeof(decimal);
dgvDados.Columns["22Abr_MargemBruta"]   .ValueType = typeof(decimal);
dgvDados.Columns["23Abr_Perc_Total"]    .ValueType = typeof(decimal);
dgvDados.Columns["27Mai_MargemBruta"]   .ValueType = typeof(decimal);
dgvDados.Columns["28Mai_Perc_Total"]    .ValueType = typeof(decimal);
dgvDados.Columns["32Jun_MargemBruta"]   .ValueType = typeof(decimal);
dgvDados.Columns["33Jun_Perc_Total"]    .ValueType = typeof(decimal);
dgvDados.Columns["37Jul_MargemBruta"]   .ValueType = typeof(decimal);
dgvDados.Columns["38Jul_Perc_Total"]    .ValueType = typeof(decimal);
dgvDados.Columns["42Ago_MargemBruta"]   .ValueType = typeof(decimal);
dgvDados.Columns["43Ago_Perc_Total"]    .ValueType = typeof(decimal);
dgvDados.Columns["47Set_MargemBruta"]   .ValueType = typeof(decimal);
dgvDados.Columns["48Set_Perc_Total"]    .ValueType = typeof(decimal);
dgvDados.Columns["52Out_MargemBruta"]   .ValueType = typeof(decimal);
dgvDados.Columns["53Out_Perc_Total"]    .ValueType = typeof(decimal);
dgvDados.Columns["57Nov_MargemBruta"]   .ValueType = typeof(decimal);
dgvDados.Columns["58Nov_Perc_Total"]    .ValueType = typeof(decimal);
dgvDados.Columns["62Dez_MargemBruta"]   .ValueType = typeof(decimal);
dgvDados.Columns["63Dez_Perc_Total"]    .ValueType = typeof(decimal);
dgvDados.Columns["67Total_MargemBruta"] .ValueType = typeof(decimal);
dgvDados.Columns["68Total_Perc_Total"]  .ValueType = typeof(decimal);

dgvDados.Columns["7Jan_MargemBruta"].DefaultCellStyle.Format =      "P";
dgvDados.Columns["8Jan_Perc_Total"].DefaultCellStyle.Format =       "P";
dgvDados.Columns["12Fev_MargemBruta"].DefaultCellStyle.Format =     "P";
dgvDados.Columns["13Fev_Perc_Total"].DefaultCellStyle.Format =      "P";
dgvDados.Columns["17Mar_MargemBruta"].DefaultCellStyle.Format =     "P";
dgvDados.Columns["18Mar_Perc_Total"].DefaultCellStyle.Format =      "P";
dgvDados.Columns["22Abr_MargemBruta"].DefaultCellStyle.Format =     "P";
dgvDados.Columns["23Abr_Perc_Total"].DefaultCellStyle.Format =      "P";
dgvDados.Columns["27Mai_MargemBruta"].DefaultCellStyle.Format =     "P";
dgvDados.Columns["28Mai_Perc_Total"].DefaultCellStyle.Format =      "P";
dgvDados.Columns["32Jun_MargemBruta"].DefaultCellStyle.Format =     "P";
dgvDados.Columns["33Jun_Perc_Total"].DefaultCellStyle.Format =      "P";
dgvDados.Columns["37Jul_MargemBruta"].DefaultCellStyle.Format =     "P";
dgvDados.Columns["38Jul_Perc_Total"].DefaultCellStyle.Format =      "P";
dgvDados.Columns["42Ago_MargemBruta"].DefaultCellStyle.Format =     "P";
dgvDados.Columns["43Ago_Perc_Total"].DefaultCellStyle.Format =      "P";
dgvDados.Columns["47Set_MargemBruta"].DefaultCellStyle.Format =     "P";
dgvDados.Columns["48Set_Perc_Total"].DefaultCellStyle.Format =      "P";
dgvDados.Columns["52Out_MargemBruta"].DefaultCellStyle.Format =     "P";
dgvDados.Columns["53Out_Perc_Total"].DefaultCellStyle.Format =      "P";
dgvDados.Columns["57Nov_MargemBruta"].DefaultCellStyle.Format =     "P";
dgvDados.Columns["58Nov_Perc_Total"].DefaultCellStyle.Format =      "P";
dgvDados.Columns["62Dez_MargemBruta"].DefaultCellStyle.Format =     "P";
dgvDados.Columns["63Dez_Perc_Total"].DefaultCellStyle.Format =      "P";
dgvDados.Columns["67Total_MargemBruta"].DefaultCellStyle.Format =   "P";
dgvDados.Columns["68Total_Perc_Total"].DefaultCellStyle.Format =    "P";                
            }
            else
            {

                dgvDados.Columns[4].ValueType = typeof(decimal);
                dgvDados.Columns[5].ValueType = typeof(decimal);
                dgvDados.Columns[6].ValueType = typeof(decimal);
                dgvDados.Columns[7].ValueType = typeof(decimal);
                dgvDados.Columns[4].DefaultCellStyle.Format = "R$ #,##0.00";
                dgvDados.Columns[5].DefaultCellStyle.Format = "R$ #,##0.00";
                dgvDados.Columns[6].DefaultCellStyle.Format = "P";
                dgvDados.Columns[7].DefaultCellStyle.Format = "P";
            }
        }

        private void filtrar_Grid()
        {
            if (rdbAnual.Checked)
            {
                dgvDados.Sort(dgvDados.Columns["Total_Vendas"], System.ComponentModel.ListSortDirection.Descending);
                dgvDados.FirstDisplayedScrollingRowIndex = 0;

            }
            else
            {
                dgvDados.Sort(dgvDados.Columns["65Total_Vendas"], System.ComponentModel.ListSortDirection.Descending);
                dgvDados.FirstDisplayedScrollingRowIndex = 0;
            }
            int cont = 0;
            foreach (DataGridViewRow row in dgvDados.Rows)
            {



                String[] ano = mtxAno.Text.Split(',');
                row.Visible = false;
                if (cont < Convert.ToInt32(mtxTop.Text))
                {

                    if (!txtDescricao.Text.Equals(String.Empty)) 
                    {
                        if (ano.Length > 1)
                        {
                            for (int x = 0; x < ano.Length; x++)
                            {
                                if (row.Cells[0].Value.ToString() == ano[x] && row.Cells[2].Value.ToString().Contains(txtDescricao.Text))
                                {
                                    row.Visible = true;
                                    cont++;
                                }

                            }
                        }
                        else
                        {
                            if (row.Cells[0].Value.ToString() == ano[0] && row.Cells[2].Value.ToString().Contains(txtDescricao.Text))
                            {
                                row.Visible = true;
                                cont++;
                            }
                        }
                    }
                    else 
                    { 
                        if (ano.Length > 1)
                        {
                            for (int x = 0; x < ano.Length; x++)
                            {
                                if (row.Cells[0].Value.ToString() == ano[x])
                                {
                                    row.Visible = true;
                                    cont++;
                                }

                            }
                        }
                        else
                        {
                            if (row.Cells[0].Value.ToString() == ano[0])
                            {
                                row.Visible = true;
                                cont++;
                            }
                        }
                    }
                }

            }


        }

        


        //Define os bloqueios do campo ao Checked alterado
        private void rdbAnual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAnual.Checked)
            {
                lblGraficos.Visible = false;
                lblGraficoComp.Visible = false;
            }
            else
            {
                lblGraficos.Visible = true;
                lblGraficoComp.Visible = true;
            }

        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            exportarExcel(dgvDados);
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
        private void exportarExcel(DataGridView dgvDados)
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

            //namesheet
            String name_Sheet = null;
            if (btnProdutos.BackColor == Color.DarkSeaGreen)
            {
                name_Sheet = "Top " + mtxTop.Text + " Produtos";
            }
            else if (btnClientes.BackColor == Color.DarkSeaGreen)
            {
                if (btnPrivado.BackColor == Color.DarkSeaGreen && btnPublico.BackColor == Color.DarkSeaGreen)
                {
                    name_Sheet = "Top " + mtxTop.Text + " Clientes";
                }
                else if (btnPrivado.BackColor == Color.DarkSeaGreen)
                {
                    name_Sheet = "Top " + mtxTop.Text + " Clientes Priv";
                }
                else if (btnPublico.BackColor == Color.DarkSeaGreen)
                {
                    name_Sheet = "Top " + mtxTop.Text + " Clientes Públ";
                }
            }
            else if (btnFabricantes.BackColor == Color.DarkSeaGreen) 
            {
                name_Sheet = "Top " + mtxTop.Text + " Fabricantes";
            }

            
            
            worksheet.Name = name_Sheet + " "+mtxAno.Text; //Adicionando o nome a planilha
            //Identar tabela 
            foreach (Excel.Worksheet wrkst in workbook.Worksheets)
            {
                Excel.Range usedrange = wrkst.UsedRange;
                usedrange.Columns.AutoFit();
            }
        }


        //Selecionar modalidade produtos
        private void btnProdutos_Click(object sender, EventArgs e)
        {

            cbxProdutosRelatoriosEspeciais.Enabled = true;
            btnProdutos.BackColor = Color.DarkSeaGreen;
            btnClientes.BackColor = Color.FromArgb(64, 64, 64);
            btnPrivado.BackColor = Color.FromArgb(64, 64, 64);
            btnPublico.BackColor = Color.FromArgb(64, 64, 64);
            btnFabricantes.BackColor = Color.FromArgb(64, 64, 64);
            configurar_DataGridView();
            carregar_Consulta("Produtos");
            inserir_Dados();
            identar_dgvDados();
            filtrar_Grid();

        }

        private void dgvDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (rdbMensal.Checked)
            {
                frmGraficoMargemBruta form = new frmGraficoMargemBruta();
                form.lblRelatorioMargemBruta.Text = dgvDados.CurrentRow.Cells[2].Value + " - " + dgvDados.CurrentRow.Cells[0].Value;
                form.compraJan = Convert.ToDouble(dgvDados.CurrentRow.Cells[5].Value.ToString().Replace("R$ ", ""));
                form.compraFev = Convert.ToDouble(dgvDados.CurrentRow.Cells[10].Value.ToString().Replace("R$ ", ""));
                form.compraMar = Convert.ToDouble(dgvDados.CurrentRow.Cells[15].Value.ToString().Replace("R$ ", ""));
                form.compraAbr = Convert.ToDouble(dgvDados.CurrentRow.Cells[20].Value.ToString().Replace("R$ ", ""));
                form.compraMai = Convert.ToDouble(dgvDados.CurrentRow.Cells[25].Value.ToString().Replace("R$ ", ""));
                form.compraJun = Convert.ToDouble(dgvDados.CurrentRow.Cells[30].Value.ToString().Replace("R$ ", ""));
                form.compraJul = Convert.ToDouble(dgvDados.CurrentRow.Cells[35].Value.ToString().Replace("R$ ", ""));
                form.compraAgo = Convert.ToDouble(dgvDados.CurrentRow.Cells[40].Value.ToString().Replace("R$ ", ""));
                form.compraSet = Convert.ToDouble(dgvDados.CurrentRow.Cells[45].Value.ToString().Replace("R$ ", ""));
                form.compraOut = Convert.ToDouble(dgvDados.CurrentRow.Cells[50].Value.ToString().Replace("R$ ", ""));
                form.compraNov = Convert.ToDouble(dgvDados.CurrentRow.Cells[55].Value.ToString().Replace("R$ ", ""));
                form.compraDez = Convert.ToDouble(dgvDados.CurrentRow.Cells[60].Value.ToString().Replace("R$ ", ""));

                //form.lblRelatorioMargemBruta.Text = dgvDados.CurrentRow.Cells[2].Value + " - " + mtxAno.Text;
                form.vendaJan = Convert.ToDouble(dgvDados.CurrentRow.Cells[4].Value.ToString().Replace("R$ ", ""));
                form.vendaFev = Convert.ToDouble(dgvDados.CurrentRow.Cells[9].Value.ToString().Replace("R$ ", ""));
                form.vendaMar = Convert.ToDouble(dgvDados.CurrentRow.Cells[14].Value.ToString().Replace("R$ ", ""));
                form.vendaAbr = Convert.ToDouble(dgvDados.CurrentRow.Cells[19].Value.ToString().Replace("R$ ", ""));
                form.vendaMai = Convert.ToDouble(dgvDados.CurrentRow.Cells[24].Value.ToString().Replace("R$ ", ""));
                form.vendaJun = Convert.ToDouble(dgvDados.CurrentRow.Cells[29].Value.ToString().Replace("R$ ", ""));
                form.vendaJul = Convert.ToDouble(dgvDados.CurrentRow.Cells[34].Value.ToString().Replace("R$ ", ""));
                form.vendaAgo = Convert.ToDouble(dgvDados.CurrentRow.Cells[39].Value.ToString().Replace("R$ ", ""));
                form.vendaSet = Convert.ToDouble(dgvDados.CurrentRow.Cells[44].Value.ToString().Replace("R$ ", ""));
                form.vendaOut = Convert.ToDouble(dgvDados.CurrentRow.Cells[49].Value.ToString().Replace("R$ ", ""));
                form.vendaNov = Convert.ToDouble(dgvDados.CurrentRow.Cells[54].Value.ToString().Replace("R$ ", ""));
                form.vendaDez = Convert.ToDouble(dgvDados.CurrentRow.Cells[59].Value.ToString().Replace("R$ ", ""));


                //form.lblRelatorioMargemBruta.Text = dgvDados.CurrentRow.Cells[1].Value + " - " + mtxAno.Text;
                //form.margemJan = Convert.ToDouble(dgvDados.CurrentRow.Cells[5].Value.ToString().Replace( " %", ""));
                //form.margemFev = Convert.ToDouble(dgvDados.CurrentRow.Cells[9].Value.ToString().Replace( " %", ""));
                //form.margemMar = Convert.ToDouble(dgvDados.CurrentRow.Cells[13].Value.ToString().Replace( " %", ""));
                //form.margemAbr = Convert.ToDouble(dgvDados.CurrentRow.Cells[17].Value.ToString().Replace(" %", ""));
                //form.margemMai = Convert.ToDouble(dgvDados.CurrentRow.Cells[21].Value.ToString().Replace(" %", ""));
                //form.margemJun = Convert.ToDouble(dgvDados.CurrentRow.Cells[25].Value.ToString().Replace(" %", ""));
                //form.margemJul = Convert.ToDouble(dgvDados.CurrentRow.Cells[29].Value.ToString().Replace(" %", ""));
                //form.margemAgo = Convert.ToDouble(dgvDados.CurrentRow.Cells[33].Value.ToString().Replace(" %", ""));
                //form.margemSet = Convert.ToDouble(dgvDados.CurrentRow.Cells[37].Value.ToString().Replace(" %", ""));
                //form.margemOut = Convert.ToDouble(dgvDados.CurrentRow.Cells[41].Value.ToString().Replace(" %", ""));
                //form.margemNov = Convert.ToDouble(dgvDados.CurrentRow.Cells[45].Value.ToString().Replace(" %", ""));
                //form.margemDez = Convert.ToDouble(dgvDados.CurrentRow.Cells[49].Value.ToString().Replace(" %", ""));














                form.Show();
            }
        }

        //Selecionar modalidade clientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            cbxProdutosRelatoriosEspeciais.Enabled = false;



            btnProdutos.BackColor = Color.FromArgb(64, 64, 64);
            btnClientes.BackColor = Color.DarkSeaGreen;
            btnPrivado.BackColor = Color.DarkSeaGreen;
            btnPublico.BackColor = Color.DarkSeaGreen;
            btnFabricantes.BackColor = Color.FromArgb(64, 64, 64);
            configurar_DataGridView();
            carregar_Consulta("Clientes");
            inserir_Dados();
            identar_dgvDados();
            filtrar_Grid();
        }
        //Selecionar modalidade clientes privado
        private void btnPrivado_Click(object sender, EventArgs e)
        {
            cbxProdutosRelatoriosEspeciais.Enabled = false;
            if (btnClientes.BackColor == Color.DarkSeaGreen && btnPrivado.BackColor == Color.DarkSeaGreen)
            {
                btnPrivado.BackColor = Color.FromArgb(64, 64, 64);
                btnPublico.BackColor = Color.DarkSeaGreen;
                configurar_DataGridView();
                carregar_Consulta("Clientes_Publicos");
                inserir_Dados();
                identar_dgvDados();
                filtrar_Grid();
            }

            else
            {
                
                btnPrivado.BackColor = Color.DarkSeaGreen;
                configurar_DataGridView();
                carregar_Consulta("Clientes");
                inserir_Dados();
                identar_dgvDados();
                filtrar_Grid();
            }

        }

        //Selecionar modalidade clientes público
        private void btnPublico_Click(object sender, EventArgs e)
        {



            cbxProdutosRelatoriosEspeciais.Enabled = false;
            if (btnClientes.BackColor == Color.DarkSeaGreen && btnPublico.BackColor == Color.DarkSeaGreen)
            {
                btnPublico.BackColor = Color.FromArgb(64, 64, 64);
                btnPrivado.BackColor = Color.DarkSeaGreen;
                configurar_DataGridView();
                carregar_Consulta("Clientes_Privados");
                inserir_Dados();
                identar_dgvDados();
                filtrar_Grid();
            }            
            else
            {

                btnPublico.BackColor = btnPrivado.BackColor = Color.DarkSeaGreen;
                configurar_DataGridView();
                carregar_Consulta("Clientes");
                inserir_Dados();
                identar_dgvDados();
                filtrar_Grid();

            }
        }

        //Selecionar modalidade fabricantes
        private void btnFabricantes_Click(object sender, EventArgs e)
        {
            cbxProdutosRelatoriosEspeciais.Enabled = false;
            btnProdutos.BackColor = Color.FromArgb(64, 64, 64);
            btnClientes.BackColor = Color.FromArgb(64, 64, 64);
            btnPrivado.BackColor = Color.FromArgb(64, 64, 64);
            btnPublico.BackColor = Color.FromArgb(64, 64, 64);
            btnFabricantes.BackColor = Color.DarkSeaGreen;

            configurar_DataGridView();
            carregar_Consulta("Fabricantes");
            inserir_Dados();
            identar_dgvDados();
            filtrar_Grid();


        }

        private void rdbMensal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkDataCorte_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDataCorte.Checked)
            {
                dtpCorte.Enabled = true;
            }
            else
            {
                dtpCorte.Enabled = false;
            }

        }

        private void cbxProdutosRelatoriosEspeciais_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvRelatorios.Rows.Clear();
            dgvRelatorios.Columns.Clear();
            if (rdbAnual.Checked)
            {
                if (cbxProdutosRelatoriosEspeciais.SelectedItem.ToString().Equals("Produtos x Fabricantes"))
                {
                    dgvRelatorios.Columns.Add("PxF_Ano", "Ano");
                    dgvRelatorios.Columns.Add("PxF_Codi_Produto", "Código");
                    dgvRelatorios.Columns.Add("PxF_Desc_Produto", "Descrição");
                    dgvRelatorios.Columns.Add("PxF_Desc_Fabricante", "Fabricante");
                    dgvRelatorios.Columns.Add("PxF_Tot_QtdVendas", "Tot | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("PxF_Tot_Vendas", "Tot | Vendas");
                    dgvRelatorios.Columns.Add("PxF_Tot_Compras", "Tot | Compras");
                    dgvRelatorios.Columns.Add("PxF_Tot_MB", "Tot | % Margem Bruta");
                    dgvRelatorios.Columns.Add("PxF_Tot_Fat", "Tot | % do Faturamento");


                    for (int conta_Linhas = 0; conta_Linhas < Convert.ToInt32(mtxTop.Text); conta_Linhas++)
                    {

                        if (conta_Linhas >= dgvDados.Rows.Count)
                            break;
                        dgvRelatorios.Rows.Add(
                             dgvDados.Rows[conta_Linhas].Cells[0].Value //1 Ano
                            , dgvDados.Rows[conta_Linhas].Cells[1].Value //2 Cod_Produto
                            , dgvDados.Rows[conta_Linhas].Cells[2].Value //3 Descrição
                            , consultar_Fornecedor(Convert.ToInt32(dgvDados.Rows[conta_Linhas].Cells[1].Value)) // 4 Fabricante
                            , dgvDados.Rows[conta_Linhas].Cells[3].Value //5 Qtd Vendas
                            , dgvDados.Rows[conta_Linhas].Cells[4].Value //6 Tot Vendas
                            , dgvDados.Rows[conta_Linhas].Cells[5].Value //7 Tot Compras
                            , Convert.ToDouble(dgvDados.Rows[conta_Linhas].Cells[6].Value)//8 % MB
                            , Convert.ToDouble(dgvDados.Rows[conta_Linhas].Cells[7].Value)//9 % Faturamento
                            );

                    }
                    
                    dgvRelatorios.Columns[5].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[6].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[7].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[8].ValueType = typeof(decimal);
                    
                    dgvRelatorios.Columns[5].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[6].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[7].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[8].DefaultCellStyle.Format = "P";
                    


                    this.Cursor = Cursors.WaitCursor;
                    exportarExcel(dgvRelatorios);
                    this.Cursor = Cursors.Default;

                }
                else if (cbxProdutosRelatoriosEspeciais.SelectedItem.ToString().Equals("Tot por Estados"))
                {
                    carregar_Consulta_Estado();
                }
            }
            else
            {
                if (cbxProdutosRelatoriosEspeciais.SelectedItem.ToString().Equals("Produtos x Fabricantes"))
                {
                    dgvRelatorios.Columns.Add("0_PxF_Ano", "Ano");
                    dgvRelatorios.Columns.Add("1_PxF_Codi_Produto", "Código");
                    dgvRelatorios.Columns.Add("2_PxF_Desc_Produto", "Descrição");
                    dgvRelatorios.Columns.Add("3_PxF_Desc_Fabricante", "Fabricante");
                    
                    dgvRelatorios.Columns.Add("4_PxF_Tot_QtdVendas",    "Jan | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("5_PxF_Tot_Vendas",       "Jan | Vendas");
                    dgvRelatorios.Columns.Add("6_PxF_Tot_Compras",      "Jan | Compras");
                    dgvRelatorios.Columns.Add("7_PxF_Tot_MB",           "Jan | % Margem Bruta");
                    dgvRelatorios.Columns.Add("8_PxF_Tot_Fat",          "Jan | % do Faturamento");

                    dgvRelatorios.Columns.Add("9_PxF_Tot_QtdVendas",    "Fev | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("10_PxF_Tot_Vendas",       "Fev | Vendas");
                    dgvRelatorios.Columns.Add("11_PxF_Tot_Compras",      "Fev | Compras");
                    dgvRelatorios.Columns.Add("12_PxF_Tot_MB",           "Fev | % Margem Bruta");
                    dgvRelatorios.Columns.Add("13_PxF_Tot_Fat",          "Fev | % do Faturamento");

                    dgvRelatorios.Columns.Add("14_PxF_Tot_QtdVendas",   "Mar | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("15_PxF_Tot_Vendas",      "Mar | Vendas");
                    dgvRelatorios.Columns.Add("16_PxF_Tot_Compras",     "Mar | Compras");
                    dgvRelatorios.Columns.Add("17_PxF_Tot_MB",          "Mar | % Margem Bruta");
                    dgvRelatorios.Columns.Add("18_PxF_Tot_Fat",         "Mar | % do Faturamento");

                    dgvRelatorios.Columns.Add("19_PxF_Tot_QtdVendas",   "Abr | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("20_PxF_Tot_Vendas",      "Abr | Vendas");
                    dgvRelatorios.Columns.Add("21_PxF_Tot_Compras",     "Abr | Compras");
                    dgvRelatorios.Columns.Add("22_PxF_Tot_MB",          "Abr | % Margem Bruta");
                    dgvRelatorios.Columns.Add("23_PxF_Tot_Fat",         "Abr | % do Faturamento");

                    dgvRelatorios.Columns.Add("24_PxF_Tot_QtdVendas",   "Mai | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("25_PxF_Tot_Vendas",      "Mai | Vendas");
                    dgvRelatorios.Columns.Add("26_PxF_Tot_Compras",     "Mai | Compras");
                    dgvRelatorios.Columns.Add("27_PxF_Tot_MB",          "Mai | % Margem Bruta");
                    dgvRelatorios.Columns.Add("28_PxF_Tot_Fat",         "Mai | % do Faturamento");

                    dgvRelatorios.Columns.Add("29_PxF_Tot_QtdVendas",   "Jun | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("30_PxF_Tot_Vendas",      "Jun | Vendas");
                    dgvRelatorios.Columns.Add("31_PxF_Tot_Compras",     "Jun | Compras");
                    dgvRelatorios.Columns.Add("32_PxF_Tot_MB",          "Jun | % Margem Bruta");
                    dgvRelatorios.Columns.Add("33_PxF_Tot_Fat",         "Jun | % do Faturamento");

                    dgvRelatorios.Columns.Add("34_PxF_Tot_QtdVendas",   "Jul | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("35_PxF_Tot_Vendas",      "Jul | Vendas");
                    dgvRelatorios.Columns.Add("36_PxF_Tot_Compras",     "Jul | Compras");
                    dgvRelatorios.Columns.Add("37_PxF_Tot_MB",          "Jul | % Margem Bruta");
                    dgvRelatorios.Columns.Add("38_PxF_Tot_Fat",         "Jul | % do Faturamento");

                    dgvRelatorios.Columns.Add("39_PxF_Tot_QtdVendas",   "Ago | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("40_PxF_Tot_Vendas",      "Ago | Vendas");
                    dgvRelatorios.Columns.Add("41_PxF_Tot_Compras",     "Ago | Compras");
                    dgvRelatorios.Columns.Add("42_PxF_Tot_MB",          "Ago | % Margem Bruta");
                    dgvRelatorios.Columns.Add("43_PxF_Tot_Fat",         "Ago | % do Faturamento");

                    dgvRelatorios.Columns.Add("44_PxF_Tot_QtdVendas",   "Set | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("45_PxF_Tot_Vendas",      "Set | Vendas");
                    dgvRelatorios.Columns.Add("46_PxF_Tot_Compras",     "Set | Compras");
                    dgvRelatorios.Columns.Add("47_PxF_Tot_MB",          "Set | % Margem Bruta");
                    dgvRelatorios.Columns.Add("48_PxF_Tot_Fat",         "Set | % do Faturamento");

                    dgvRelatorios.Columns.Add("49_PxF_Tot_QtdVendas",   "Out | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("50_PxF_Tot_Vendas",      "Out | Vendas");
                    dgvRelatorios.Columns.Add("51_PxF_Tot_Compras",     "Out | Compras");
                    dgvRelatorios.Columns.Add("52_PxF_Tot_MB",          "Out | % Margem Bruta");
                    dgvRelatorios.Columns.Add("53_PxF_Tot_Fat",         "Out | % do Faturamento");

                    dgvRelatorios.Columns.Add("54_PxF_Tot_QtdVendas",   "Nov | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("55_PxF_Tot_Vendas",      "Nov | Vendas");
                    dgvRelatorios.Columns.Add("56_PxF_Tot_Compras",     "Nov | Compras");
                    dgvRelatorios.Columns.Add("57_PxF_Tot_MB",          "Nov | % Margem Bruta");
                    dgvRelatorios.Columns.Add("58_PxF_Tot_Fat",         "Nov | % do Faturamento");

                    dgvRelatorios.Columns.Add("59_PxF_Tot_QtdVendas",   "Dez | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("60_PxF_Tot_Vendas",      "Dez | Vendas");
                    dgvRelatorios.Columns.Add("61_PxF_Tot_Compras",     "Dez | Compras");
                    dgvRelatorios.Columns.Add("62_PxF_Tot_MB",          "Dez | % Margem Bruta");
                    dgvRelatorios.Columns.Add("63_PxF_Tot_Fat",         "Dez | % do Faturamento");

                    dgvRelatorios.Columns.Add("64_PxF_Tot_QtdVendas",   "Tot | Qtd. Vendas");
                    dgvRelatorios.Columns.Add("65_PxF_Tot_Vendas",      "Tot | Vendas");
                    dgvRelatorios.Columns.Add("66_PxF_Tot_Compras",     "Tot | Compras");
                    dgvRelatorios.Columns.Add("67_PxF_Tot_MB",          "Tot | % Margem Bruta");
                    dgvRelatorios.Columns.Add("68_PxF_Tot_Fat",         "Tot | % do Faturamento");
                    for (int conta_Linhas = 0; conta_Linhas < Convert.ToInt32(mtxTop.Text); conta_Linhas++)
                    {

                        if (conta_Linhas >= dgvDados.Rows.Count)
                            break;
                        dgvRelatorios.Rows.Add(
                              dgvDados.Rows[conta_Linhas].Cells[0].Value //0 Ano
                            , dgvDados.Rows[conta_Linhas].Cells[1].Value //1 Cod_Produto
                            , dgvDados.Rows[conta_Linhas].Cells[2].Value //2 Descrição
                            , consultar_Fornecedor(Convert.ToInt32(dgvDados.Rows[conta_Linhas].Cells[1].Value)) // 3 Fabricante
                            , dgvDados.Rows[conta_Linhas].Cells[3].Value
                            , dgvDados.Rows[conta_Linhas].Cells[4].Value
                            , dgvDados.Rows[conta_Linhas].Cells[5].Value
                            , dgvDados.Rows[conta_Linhas].Cells[6].Value
                            , dgvDados.Rows[conta_Linhas].Cells[7].Value
                            , dgvDados.Rows[conta_Linhas].Cells[8].Value
                            , dgvDados.Rows[conta_Linhas].Cells[9].Value
                            , dgvDados.Rows[conta_Linhas].Cells[10].Value
                            , dgvDados.Rows[conta_Linhas].Cells[11].Value
                            , dgvDados.Rows[conta_Linhas].Cells[12].Value
                            , dgvDados.Rows[conta_Linhas].Cells[13].Value
                            , dgvDados.Rows[conta_Linhas].Cells[14].Value
                            , dgvDados.Rows[conta_Linhas].Cells[15].Value
                            , dgvDados.Rows[conta_Linhas].Cells[16].Value
                            , dgvDados.Rows[conta_Linhas].Cells[17].Value
                            , dgvDados.Rows[conta_Linhas].Cells[18].Value
                            , dgvDados.Rows[conta_Linhas].Cells[19].Value
                            , dgvDados.Rows[conta_Linhas].Cells[20].Value
                            , dgvDados.Rows[conta_Linhas].Cells[21].Value
                            , dgvDados.Rows[conta_Linhas].Cells[22].Value
                            , dgvDados.Rows[conta_Linhas].Cells[23].Value
                            , dgvDados.Rows[conta_Linhas].Cells[24].Value
                            , dgvDados.Rows[conta_Linhas].Cells[25].Value
                            , dgvDados.Rows[conta_Linhas].Cells[26].Value
                            , dgvDados.Rows[conta_Linhas].Cells[27].Value
                            , dgvDados.Rows[conta_Linhas].Cells[28].Value
                            , dgvDados.Rows[conta_Linhas].Cells[29].Value
                            , dgvDados.Rows[conta_Linhas].Cells[30].Value
                            , dgvDados.Rows[conta_Linhas].Cells[31].Value
                            , dgvDados.Rows[conta_Linhas].Cells[32].Value
                            , dgvDados.Rows[conta_Linhas].Cells[33].Value
                            , dgvDados.Rows[conta_Linhas].Cells[34].Value
                            , dgvDados.Rows[conta_Linhas].Cells[35].Value
                            , dgvDados.Rows[conta_Linhas].Cells[36].Value
                            , dgvDados.Rows[conta_Linhas].Cells[37].Value
                            , dgvDados.Rows[conta_Linhas].Cells[38].Value
                            , dgvDados.Rows[conta_Linhas].Cells[39].Value
                            , dgvDados.Rows[conta_Linhas].Cells[40].Value
                            , dgvDados.Rows[conta_Linhas].Cells[41].Value
                            , dgvDados.Rows[conta_Linhas].Cells[42].Value
                            , dgvDados.Rows[conta_Linhas].Cells[43].Value
                            , dgvDados.Rows[conta_Linhas].Cells[44].Value
                            , dgvDados.Rows[conta_Linhas].Cells[45].Value
                            , dgvDados.Rows[conta_Linhas].Cells[46].Value
                            , dgvDados.Rows[conta_Linhas].Cells[47].Value
                            , dgvDados.Rows[conta_Linhas].Cells[48].Value
                            , dgvDados.Rows[conta_Linhas].Cells[49].Value
                            , dgvDados.Rows[conta_Linhas].Cells[50].Value
                            , dgvDados.Rows[conta_Linhas].Cells[51].Value
                            , dgvDados.Rows[conta_Linhas].Cells[52].Value
                            , dgvDados.Rows[conta_Linhas].Cells[53].Value
                            , dgvDados.Rows[conta_Linhas].Cells[54].Value
                            , dgvDados.Rows[conta_Linhas].Cells[55].Value
                            , dgvDados.Rows[conta_Linhas].Cells[56].Value
                            , dgvDados.Rows[conta_Linhas].Cells[57].Value
                            , dgvDados.Rows[conta_Linhas].Cells[58].Value
                            , dgvDados.Rows[conta_Linhas].Cells[59].Value
                            , dgvDados.Rows[conta_Linhas].Cells[60].Value
                            , dgvDados.Rows[conta_Linhas].Cells[61].Value
                            , dgvDados.Rows[conta_Linhas].Cells[62].Value
                            , dgvDados.Rows[conta_Linhas].Cells[63].Value
                            , dgvDados.Rows[conta_Linhas].Cells[64].Value
                            , dgvDados.Rows[conta_Linhas].Cells[65].Value
                            , dgvDados.Rows[conta_Linhas].Cells[66].Value
                            , dgvDados.Rows[conta_Linhas].Cells[67].Value
                            );
                    }
                    dgvRelatorios.Columns[5].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[6].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[7].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[8].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[10].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[11].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[12].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[13].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[15].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[16].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[17].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[18].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[20].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[21].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[22].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[23].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[25].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[26].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[27].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[28].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[30].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[31].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[32].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[33].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[35].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[36].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[37].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[38].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[40].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[41].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[42].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[43].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[45].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[46].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[47].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[48].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[50].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[51].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[52].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[53].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[55].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[56].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[57].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[58].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[60].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[61].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[62].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[63].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[65].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[66].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[67].ValueType = typeof(decimal);
                    dgvRelatorios.Columns[68].ValueType = typeof(decimal);

                    dgvRelatorios.Columns[5].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[6].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[7].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[8].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[10].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[11].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[12].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[13].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[15].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[16].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[17].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[18].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[20].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[21].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[22].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[23].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[25].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[26].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[27].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[28].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[30].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[31].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[32].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[33].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[35].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[36].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[37].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[38].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[40].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[41].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[42].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[43].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[45].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[46].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[47].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[48].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[50].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[51].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[52].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[53].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[55].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[56].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[57].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[58].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[60].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[61].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[62].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[63].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[65].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[66].DefaultCellStyle.Format = "R$ #,##0.00";
                    dgvRelatorios.Columns[67].DefaultCellStyle.Format = "P";
                    dgvRelatorios.Columns[68].DefaultCellStyle.Format = "P";


                    this.Cursor = Cursors.WaitCursor;
                    exportarExcel(dgvRelatorios);
                    this.Cursor = Cursors.Default;

                }
            }
        }

        private String consultar_Fornecedor(int Cod_Produto) 
        {
            String fornecedor = null;
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command_Consulta = connectDMD.CreateCommand();
                    command_Consulta.CommandText =
                                               " SELECT "
                                             + " Fabricante.Fantasia       " 
                                             + " FROM PRODU Produto        " 
                                             + " JOIN FABRI Fabricante ON Fabricante.Codigo = Produto.Cod_Fabricante"
                                             + " WHERE Produto.Codigo =    " +Cod_Produto
                                             + "                ";


                    reader_Consulta = command_Consulta.ExecuteReader();



                    while (reader_Consulta.Read())
                    {
                        if (reader_Consulta["Fantasia"] != null)
                        {
                            fornecedor = reader_Consulta["Fantasia"].ToString();

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

            return fornecedor;
        }





        //Fechar form
        private void btnFechar_Click(object sender, EventArgs e)
        {
            mTittle = "Fechar formulário";
            mMessage = "Esta ação irá encerrar o formulário, deseja prosseguir?";
            mIcon = MessageBoxIcon.Warning;
            mButton = MessageBoxButtons.YesNo;
            DialogResult dlEncerrar_Formulario = MessageBox.Show(mMessage, mTittle,mButton, mIcon);

            if (dlEncerrar_Formulario == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
