using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Fretes.ConferenciaDeFretes
{
    public partial class frmNewConferenciaFretes : Form
    {
        public frmNewConferenciaFretes()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;

        DataTable dt;

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
                
        private double Soma()
        {
            double Soma_Valor = 0;
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (row.Cells[9].Value != null)
                {
                    if (row.Cells[9].Value.ToString().Contains("R$"))
                    {
                        Soma_Valor = Convert.ToDouble(row.Cells[9].Value.ToString().Substring(2)) + Soma_Valor;

                    }
                    else
                    {
                        Soma_Valor = Soma_Valor + Convert.ToDouble(row.Cells[9].Value.ToString());
                        row.Cells[9].Value = Convert.ToDouble(row.Cells[9].Value.ToString()).ToString("C");
                    }
                }
            }
                return Soma_Valor;
        }



        //Load do form
        private void frmNewConferenciaFretes_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;

            //Thread que carrega as configurações iniciais do FORM
            carregar_Percentuais();
            Configuracoes_Iniciais();
            configurar_dgvDados(dgvDados);                  
            filtrar_Dados(dgvDados,dt);
            btnRecalc_Click(sender, e);

            btnImportar.Enabled = false;







        }
        private void Configuracoes_Iniciais()
        {
            dtpDtInicial.Value = DateTime.Now.AddDays(-16);
            dtpDtFinal.Value = DateTime.Now.AddDays(-1);
            gpbCalculadoraPercent.Enabled = false;
            chkHelp_CheckedChanged(chkHelp, new EventArgs());


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
                            erro_DeAcesso(SQLe);
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

        //Não permite caracteres, apenas números
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }



        private void configurar_dgvDados(DataGridView _dgv)
        {

            _dgv.Invoke((MethodInvoker)delegate
            {
                _dgv.Columns.Add("NF", "NF");                                         //0
                _dgv.Columns.Add("Cod_Transportadora", "Cod. Transportadora");        //1
                _dgv.Columns.Add("Des_Transportadora", "Transportadora");             //2
                _dgv.Columns.Add("Dat_Emissao", "Dt. Emissão");                       //3
                _dgv.Columns.Add("Estado", "Estado");                                 //4
                _dgv.Columns.Add("Cidade", "Cidade");                                 //5
                _dgv.Columns.Add("Vlr_NF", "Vlr. NF");                                //6
                _dgv.Columns.Add("Vlr_Calculado", "Vlr. Uni");                        //7
                _dgv.Columns.Add("Porcentagem", "%");                                 //8
                _dgv.Columns.Add("Vlr_Transportadora", "Vlr. Transportadora");        //9
                _dgv.Columns.Add("Num_CTR", "Num. CTR");                              //10
                _dgv.Columns.Add("Observacao", "Observação");                         //11
                _dgv.Columns[11].Width = 450;
            });
        }

        //Listas de percentual da cidade
        //Os percentuais da cidade possuem maior prioridade quando forem comparados logicamente com os percentuais por estado, sempre de dentro pra fora
        List<String> lsCid_CodTransportadora = new List<String>();
        List<String> lsCid_Estado = new List<String>();
        List<String> lsCid_Cidade = new List<String>();
        List<String> lsCidValor_Minimo = new List<String>();
        List<String> lsCid_Percentual = new List<String>();

        //Listas de percentual de estado
        List<String> lsEst_CodTransportadora = new List<String>();
        List<String> lsEst_Estado        = new List<String>();
        List<String> lsEst_PercentualCapital                  = new List<String>();
        List<String> lsEst_PercentualInterior                  = new List<String>();
        List<String> lsEst_ValorMinimoCapital                  = new List<String>();
        List<String> lsEst_ValorMinimoInterior                  = new List<String>();

                
        private void carregar_Percentuais()
        {
                //Carregar percentuais da cidade
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        string comando = " SELECT "
                                         + "  CID.Cod_Transportadora "
                                         + " ,CID.Cod_UF "
                                         + " ,CID.Cidade "
                                         + " ,CID.Percentual_Cidade "
                                         + " ,CID.Valor_Minimo_Cidade "
                                         + " FROM[UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA_CIDADE] CID";


                        command = connectDMD.CreateCommand();
                        command.CommandText = comando;

                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Cod_Transportadora"] != null)
                            {
                                lsCid_CodTransportadora.Add(reader["Cod_Transportadora"].ToString());
                                lsCid_Estado.Add(reader["Cod_UF"].ToString());
                                lsCid_Cidade.Add(reader["Cidade"].ToString());
                                lsCid_Percentual.Add(reader["Percentual_Cidade"].ToString());
                                lsCidValor_Minimo.Add(reader["Valor_Minimo_Cidade"].ToString());
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

                //Carregar percentuais do estado
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        string comando = " SELECT                     "
                                         + "  EST.Cod_Transportadora    "
                                         + " ,EST.Cod_UF                "
                                         + " ,EST.Percentual_Capital    "
                                         + " ,EST.Percentual_Interior   "
                                         + " ,EST.Valor_Minimo_Capital  "
                                         + " ,EST.Valor_Minimo_Interior "
                                         + " FROM[UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA] EST";


                        command = connectDMD.CreateCommand();
                        command.CommandText = comando;

                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Cod_Transportadora"] != null)
                            {
                                lsEst_CodTransportadora.Add(reader["Cod_Transportadora"].ToString());
                                lsEst_Estado.Add(reader["Cod_UF"].ToString());
                                lsEst_PercentualCapital.Add(reader["Percentual_Capital"].ToString());
                                lsEst_PercentualInterior.Add(reader["Percentual_Interior"].ToString());
                                lsEst_ValorMinimoCapital.Add(reader["Valor_Minimo_Capital"].ToString());
                                lsEst_ValorMinimoInterior.Add(reader["Valor_Minimo_Interior"].ToString());
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

     
        
        private void inserir_Percentuais(DataTable _dt)
        {

            var lista_Filtrada = from item in _dt.AsEnumerable()
                                 select  item ;
            
            
            
            int valor_Minimo;
            foreach (var lista in lista_Filtrada)
            {
                valor_Minimo = 0;
                                           
                if (lsEst_CodTransportadora.Contains(lista["Cod_Transportadora"].ToString()))
                {
                    for (int x=0; x<lsEst_CodTransportadora.Count;x++)
                    {
                        if (lsEst_CodTransportadora[x].ToString().Equals(lista["Cod_Transportadora"].ToString())) {
                            if (lista["Estado"].ToString().ToUpper().Equals(lsEst_Estado[x]))
                            {
                                if ((lista["Cidade"].ToString().ToUpper().Equals("RIO BRANCO")      && lista["Estado"].ToString().ToUpper().Equals("AC")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("MACEIO")          && lista["Estado"].ToString().ToUpper().Equals("AL")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("MACAPA")          && lista["Estado"].ToString().ToUpper().Equals("AP")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("MANAUS")          && lista["Estado"].ToString().ToUpper().Equals("AM")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("SALVADOR")        && lista["Estado"].ToString().ToUpper().Equals("BA")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("FORTALEZA")       && lista["Estado"].ToString().ToUpper().Equals("CE")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("BRASILIA")        && lista["Estado"].ToString().ToUpper().Equals("DF")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("VITORIA")         && lista["Estado"].ToString().ToUpper().Equals("ES")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("GOIANIA")         && lista["Estado"].ToString().ToUpper().Equals("GO")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("SAO LUIS")        && lista["Estado"].ToString().ToUpper().Equals("MA")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("CUIABA")          && lista["Estado"].ToString().ToUpper().Equals("MT")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("CAMPO GRANDE")    && lista["Estado"].ToString().ToUpper().Equals("MS")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("BELO HORIZONTE")  && lista["Estado"].ToString().ToUpper().Equals("MG")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("BELEM")           && lista["Estado"].ToString().ToUpper().Equals("PA")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("JOAO PESSOA")     && lista["Estado"].ToString().ToUpper().Equals("PB")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("CURITIBA")        && lista["Estado"].ToString().ToUpper().Equals("PR")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("RECIFE")          && lista["Estado"].ToString().ToUpper().Equals("PE")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("TERESINA")        && lista["Estado"].ToString().ToUpper().Equals("PI")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("RIO DE JANEIRO")  && lista["Estado"].ToString().ToUpper().Equals("RJ")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("NATAL")           && lista["Estado"].ToString().ToUpper().Equals("RN")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("PORTO ALEGRE")    && lista["Estado"].ToString().ToUpper().Equals("RS")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("PORTO VELHO")     && lista["Estado"].ToString().ToUpper().Equals("RO")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("BOA VISTA")       && lista["Estado"].ToString().ToUpper().Equals("RR")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("FLORIANOPOLIS")   && lista["Estado"].ToString().ToUpper().Equals("SC")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("SAO PAULO")       && lista["Estado"].ToString().ToUpper().Equals("SP")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("ARACAJU")         && lista["Estado"].ToString().ToUpper().Equals("SE")) ||
                                    (lista["Cidade"].ToString().ToUpper().Equals("PALMAS")          && lista["Estado"].ToString().ToUpper().Equals("TO")))
                                {
                                    if ((Convert.ToDouble(lista["Vlr_NF"]) * (Convert.ToDouble(lsEst_PercentualCapital[x]) / 100)) > Convert.ToDouble(lsEst_ValorMinimoCapital[x]))
                                    {
                                        lista["Vlr_Calculado"] = (Convert.ToDouble(lista["Vlr_NF"].ToString()) * (Convert.ToDouble(lsEst_PercentualCapital[x]) / 100));
                                        lista["%"] = Convert.ToDouble(lsEst_PercentualCapital[x]);
                                        lista["Vlr_Minimo"] = Convert.ToDouble(lista["Vlr_Calculado"]);
                                        break;
                                    }
                                    else
                                    {
                                        lista["Vlr_Calculado"] = Convert.ToDouble(lsEst_ValorMinimoCapital[x]);
                                        lista["%"] = Convert.ToDouble(lsEst_PercentualCapital[x]);
                                        lista["Vlr_Minimo"] = Convert.ToDouble(lista["Vlr_Calculado"]);
                                        valor_Minimo = 1;
                                        break;                                        
                                    }
                                }
                                else
                                {
                                    if ((Convert.ToDouble(lista["Vlr_NF"]) * (Convert.ToDouble(lsEst_PercentualInterior[x]) / 100)) > Convert.ToDouble(lsEst_ValorMinimoInterior[x]))
                                    {
                                        lista["Vlr_Calculado"] = (Convert.ToDouble(lista["Vlr_NF"].ToString()) * (Convert.ToDouble(lsEst_PercentualInterior[x]) / 100));
                                        lista["%"] = Convert.ToDouble(lsEst_PercentualInterior[x]);
                                        lista["Vlr_Minimo"] = Convert.ToDouble(lista["Vlr_Calculado"]);
                                        break;
                                    }
                                    else
                                    {

                                        lista["Vlr_Calculado"] = Convert.ToDouble(lsEst_ValorMinimoInterior[x]);
                                        lista["%"] = Convert.ToDouble(lsEst_PercentualInterior[x]);
                                        lista["Vlr_Minimo"] = Convert.ToDouble(lista["Vlr_Calculado"]);
                                        valor_Minimo = 1;
                                        break;
                                    }


                                }

                            }
                        }
                    }
                }
                
                if (lsCid_CodTransportadora.Contains(lista["Cod_Transportadora"].ToString()))
                {
                    for (int x = 0; x < lsCid_CodTransportadora.Count; x++)
                    {
                        if (lista["Cod_Transportadora"].ToString() == lsCid_CodTransportadora[x].ToString())
                        {
                            if (lista["Cidade"].ToString().ToUpper().Equals(lsCid_Cidade[x].ToUpper()) && lista["Estado"].ToString().ToUpper().Equals(lsCid_Estado[x].ToUpper()))
                            {
                                if ((Convert.ToDouble(lista["Vlr_NF"]) * (Convert.ToDouble(lsCid_Percentual[x]) / 100)) > Convert.ToDouble(lsCidValor_Minimo[x]))
                                {
                                    valor_Minimo = 0;
                                    lista["Vlr_Calculado"] = (Convert.ToDouble(lista["Vlr_NF"].ToString()) * (Convert.ToDouble(lsCid_Percentual[x]) / 100));
                                    lista["%"] = Convert.ToDouble(lsCid_Percentual[x]);
                                    lista["Vlr_Minimo"] = Convert.ToDouble(lista["Vlr_Calculado"]);
                                    break;
                                }
                                else
                                {

                                    lista["Vlr_Calculado"] = Convert.ToDouble(lsCidValor_Minimo[x]);
                                    lista["%"] = Convert.ToDouble(lsCid_Percentual[x]);
                                    lista["Vlr_Minimo"] = Convert.ToDouble(lista["Vlr_Calculado"]);
                                    valor_Minimo = 1;
                                    break;

                                }



                            }

                        }
                    }
                }
                
                
                
                
                String condicao_Especial = null;
                if (lista["Vlr_Calculado"] != null)
                {
                    if (valor_Minimo == 1)
                        condicao_Especial = "Condição especial, valor " + Convert.ToDouble(lista["Vlr_Calculado"]).ToString("C");


                    lista["Observacao"] = "Percentual aplicado: " + lista["%"].ToString() + " % " + condicao_Especial;
                }




            }
            
                    

        }

        

        private void filtrar_Dados(DataGridView _dgv, DataTable dt)
        {         
            _dgv.Rows.Clear();
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();
                    String transportadora = null;
                    String transportadora_d = null;




                    if (!txtTransportadora.Text.Trim().Equals(String.Empty))
                    {

                        transportadora_d = "AND Cod_Transp = " + txtCodTransportadora.Text;
                        transportadora = " AND Cod_Transportadora = " + txtCodTransportadora.Text;
                    }
                    string comando = 
                           " SELECT													    													"
                         + " 	 	 NSCB.Num_Nota                 [NF]										  									"
                         + " 		,TRA.Codigo                    [Cod_Transportadora]					  										"
                         + " 		,TRA.Fantasia                  [Transportadora]							  									"
                         + " 		,NSCB.Dat_Emissao			   [Dat_Emissao]		  					  									"
                         + " 		,NSCB.Estado                   [Estado]									  									"
                         + " 		,NSCB.Cidade                   [Cidade]  								  									"
                         + "       ,NSCB.Vlr_TotalNota            [Vlr_NF]                                   									"
                         + " 		,0.0                          [Vlr_Calculado]							  									"
                         + " 		,0.0                          [%]										  									"
                         + " 		,0.0                          [Vlr_Minimo]							  									"
                         + " 		,null                          [Num_CTR]								  									"
                         + " 		,' '                           [Observacao]								  									"
                         + " 																				  									"
                         + " 																				  									"
                         + "  FROM       [DMD].dbo.[NFSCB] NSCB  											  									"
                         + "  INNER JOIN [DMD].dbo.[TRANS] TRA  ON TRA.Codigo = NSCB.Cod_Transportadora  	  									"
                         + " WHERE	NSCB.SER_NOTA NOT LIKE 'XXX' AND NSCB.Status NOT LIKE 'C'												"
                         + " AND NSCB.Num_Nota NOT IN 																						"
                         + " (																												"
                         + " SELECT CF.Num_Nota FROM [UNIDB].dbo.[Conferencia_Fretes] CF														"
                         + " JOIN DMD.dbo.NFSCB NF_Saida ON NF_Saida.Num_Nota = CF.Num_Nota													"
                         + " WHERE NF_saida.Dat_Emissao BETWEEN @DAT_INICIAL AND @DAT_FINAL )													"
                         + " AND (TRA.Codigo IN (SELECT DISTINCT COD_TRANSPORTADORA FROM [UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA]) 			"
                         + " OR  TRA.Codigo IN (SELECT DISTINCT COD_TRANSPORTADORA FROM [UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA_CIDADE])) 		"
                         + " AND  NSCB.Dat_Emissao BETWEEN @DAT_INICIAL AND @DAT_FINAL                            							"
                         + transportadora
                         + "  UNION ALL 																										"
                         + "  SELECT  																										"
                         + "    NECB.Numero [NF]                                                                                          	"
                         + "  ,TRA.Codigo[Cod_Transportadora]                                                                             	"
                         + "  ,TRA.Fantasia[Transportadora]                                                                               	"
                         + "  ,NECB.Dat_Emissao[Dat_Emissao]                                                                              	"
                         + "  ,NECB.Cod_UfOrigem[Estado]                                                                                  	"
                         + "  ,NECB.Cidade[Cidade]                                                                                        	"
                         + "  ,NECB.Vlr_Nota[Vlr_NF]                                                                                      	"
                         + "  ,0.0[Vlr.Calculado]                                                                                        	"
                         + "  ,0.0[%]                                                                                                    	"
                         + "  ,0.0[Valor mínimo]                                                                                         	"
                         + "  ,null [Num.CTR]                                                                                              	"
                         + "  ,' '  [Observação]                                                                                           	"
                         + "   FROM[DMD].dbo.[NFECB] NECB                                                                                 	"
                         + "  INNER JOIN[DMD].dbo.[TRANS] TRA ON TRA.Codigo = NECB.Cod_Transp                                             	"
                         + "  WHERE NECB.Status NOT LIKE 'C' AND Tip_NF = 'D'                                                             	"
                         + "   AND(TRA.Codigo IN(SELECT DISTINCT COD_TRANSPORTADORA FROM[UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA])          	"
                         + "   OR   TRA.Codigo IN(SELECT DISTINCT COD_TRANSPORTADORA FROM[UNIDB].dbo.[PERCENTUAL_TRANSPORTADORA_CIDADE])) 	"
                         + "  AND  NECB.Dat_Emissao BETWEEN @DAT_INICIAL AND @DAT_FINAL                                                   	"
                         + "  AND NECB.Numero is not null                                                                                 	"
                         + "  AND NECB.Numero NOT IN 																							"
                         + "  (																												"
                         + "  SELECT CF.Num_Nota FROM [UNIDB].dbo.[Conferencia_Fretes] CF														"
                         + " JOIN DMD.dbo.NFECB NF_Entrada ON NF_Entrada.Numero = CF.Num_Nota													"
                         + " WHERE NF_Entrada.Dat_Entrada BETWEEN @DAT_INICIAL AND @DAT_FINAL)   	" 
                         + transportadora_d
                         + " ORDER BY [NF] asc           																						";






                    command = connectDMD.CreateCommand();
                    command.CommandText = comando;

                    SqlParameter pDat_Inicial = new SqlParameter("@DAT_INICIAL", SqlDbType.DateTime);
                    pDat_Inicial.Value = dtpDtInicial.Value.AddHours(0).AddMinutes(0).AddSeconds(0);
                    command.Parameters.Add(pDat_Inicial);

                    SqlParameter pDat_Final = new SqlParameter("@DAT_FINAL", SqlDbType.DateTime);
                    pDat_Final.Value = dtpDtFinal.Value.AddHours(23).AddMinutes(59).AddSeconds(59);
                    command.Parameters.Add(pDat_Final);
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    dt = new DataTable();
                    adapter.Fill(dt);
                                                         
                }
                catch (SqlException SQLe)
                {
                    erro_DeAcesso(SQLe);
                }
                finally
                {
                    connectDMD.Close();                    
                    _dgv.Invoke(new MethodInvoker(delegate
                    {
                        inserir_Percentuais(dt);

                        var lista_Filtrada = from item in dt.AsEnumerable()
                                             select item;

                        foreach (var x in lista_Filtrada)
                        {
                            _dgv.Rows.Add(x["NF"],x["Cod_Transportadora"],x["Transportadora"],x["Dat_Emissao"],x["Estado"],x["Cidade"],Convert.ToDouble(x["Vlr_NF"]).ToString("C"),Convert.ToDouble(x["Vlr_Calculado"]).ToString("C"),Convert.ToDouble(x["%"]).ToString("F"), Convert.ToDouble(x["Vlr_Minimo"]).ToString("C"),"", x["Observacao"] );
                        }
                    }));
                }

            
                }
                        
        }
        
         























        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            txtNF.Text = String.Empty;
            filtrar_Dados(dgvDados,dt);
            btnRecalc_Click(btnPesquisar, new EventArgs());
            this.Cursor = Cursors.Default;
        }


        //Fechar form
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {            
                for (int x = 0; x < dgvDados.Rows.Count; x++)
                {

                    if (dgvDados.Rows[x].DefaultCellStyle.BackColor != System.Drawing.Color.Red)
                    {
                        if (dgvDados.Rows[x].Cells[9].Value != null && dgvDados.Rows[x].Cells[10].Value != null && dgvDados.Rows[x].Cells[11].Value != null)
                        {
                            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                            {
                                try
                                {
                                    connectDMD.Open();

                                    command = connectDMD.CreateCommand();
                                    command.CommandText = " INSERT INTO [UNIDB].dbo.[Conferencia_Fretes] "
                                                          + " (Num_Nota" 
                                                          + " ,Cod_Transportadora" 
                                                          + " ,Vlr_Frete_Calculado" 
                                                          + " ,Vlr_Frete_Real" 
                                                          + " ,Observacao" 
                                                          + " ,Usuario" 
                                                          + ", Data_Cadastro" 
                                                          + ", Num_CTR) "
                                                          + " VALUES "
                                                          + " ("  + dgvDados.Rows[x].Cells[0].Value.ToString() 
                                                          + ","   + dgvDados.Rows[x].Cells[1].Value.ToString() 
                                                          + ","   + dgvDados.Rows[x].Cells[7].Value.ToString().Replace(".", "").Replace(",", ".").Substring(2) 
                                                          + ","   + dgvDados.Rows[x].Cells[9].Value.ToString().Replace(".", "").Replace(",", ".").Substring(2) 
                                                          + ",'"  + dgvDados.Rows[x].Cells[11].Value.ToString() 
                                                          + "','" + Usuario.userDesc 
                                                          + "',GETDATE()," 
                                                          + dgvDados.Rows[x].Cells[10].Value.ToString() + ")";

                                    command.ExecuteNonQuery();


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
                dgvDados.Rows.Clear();
                filtrar_Dados(dgvDados,dt);
        }

        private void btnRecalc_Click(object sender, EventArgs e)
        {
            txtTotalFrete.Text = Soma().ToString("C");
        }

        private void dgvDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgvDados_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvDados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            txtTotalFrete.Text = Soma().ToString("C");
        }

        
            //Função para pesquisar com o Enter
            private void pesquisarComEnter_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnPesquisar_Click(btnPesquisar, new EventArgs());
                }
            }

        private void txtNF_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDados.Rows)
            { 
                if (row.Cells[0].Value.ToString().Contains(txtNF.Text))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
                    
                }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {










        }

        private void txtTransportadora_TextChanged(object sender, EventArgs e)
        {
            if (!txtTransportadora.Text.Equals(String.Empty))
            {
                btnImportar.Enabled = true;
                
            }
            else
            {
                btnImportar.Enabled = false;
                
            }

            filtrar_Dados(dgvDados,dt);
        }

        private void btnMarcar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null)
            {
                foreach (DataGridViewRow row in dgvDados.SelectedRows)
                {
                    if (row.DefaultCellStyle.BackColor == System.Drawing.Color.Yellow)
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                    else
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;



                }
            }

        }

        private void btnAddObs_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null)
            {

                foreach (DataGridViewRow row in dgvDados.SelectedRows)
                {
                    row.Cells[11].Value = txtObsPadrao.Text;
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Yellow;
                }



                
            }
        }

        private void lsbExcept_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtObsPadrao.Text = lsbExcept.SelectedItem.ToString();
        }

        private void chkCalculadora_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCalculadora.Checked)
            {
                gpbCalculadoraPercent.Enabled = true;
                txtPercentCalc.Text = "0";
            }
            else
            {
                gpbCalculadoraPercent.Enabled = false;
            }
        }




        private void txtPercentCalc_TextChanged(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow != null && !txtPercentCalc.Text.Equals(String.Empty))
            {
                if (!txtPercentCalc.Text[txtPercentCalc.Text.Length-1].Equals(".")) {
                    txtResultado.Text = (Convert.ToDouble(dgvDados.CurrentRow.Cells[6].Value.ToString().Substring(2)) * (Convert.ToDouble(txtPercentCalc.Text) / 100)).ToString("C");
                    txtPorcentagemValor.Text = (Math.Round((Convert.ToDouble(dgvDados.CurrentRow.Cells[9].Value.ToString().Substring(2)) / Convert.ToDouble(dgvDados.CurrentRow.Cells[6].Value.ToString().Substring(2)) * 100), 2)).ToString() + " %";
                }
            }
        }

        private void dgvDados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtPercentCalc_TextChanged(dgvDados, new EventArgs());
            
        }

        private void chkHelp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHelp.Checked)
            {
                lblHelpCalculadoraPercentual.Visible = true;
                lblHelpCalculoPercentual.Visible     = true;
                lblHelpFiltrosPesquisa.Visible       = true;
                lblHelpImportar.Visible              = true;
                lblHelpObsCores.Visible              = true;
                lblHelpObservacao.Visible            = true;
                lblHelpObsFiltroData.Visible         = true;
                lblHelpPadrao.Visible                = true;
                lblHelpRecalcular.Visible            = true;
                lblHelpValoresAlterados.Visible      = true;
                
            }
            else
            {
                lblHelpCalculadoraPercentual.Visible = false;
                lblHelpCalculoPercentual.Visible     = false;
                lblHelpFiltrosPesquisa.Visible       = false;
                lblHelpImportar.Visible              = false;
                lblHelpObsCores.Visible              = false;
                lblHelpObservacao.Visible            = false;
                lblHelpObsFiltroData.Visible         = false;
                lblHelpPadrao.Visible                = false;
                lblHelpRecalcular.Visible            = false;
                lblHelpValoresAlterados.Visible      = false;
            }
        }

        private void txt_DigitarNumerosDecimais_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

       

        private void btnImportar_Click(object sender, EventArgs e)
        {            
                OpenFileDialog ofdFrete = new OpenFileDialog();
                ofdFrete.Filter = "Documentos de texto|*.txt";
                ofdFrete.ShowDialog();


                if (!ofdFrete.FileName.ToString().Equals(String.Empty))
                {

                    String arq_Path = ofdFrete.FileName;
                    using (StreamReader FluxoTexto = new StreamReader(arq_Path))
                    {
                        while (true)
                        {
                            string LinhaTexto = FluxoTexto.ReadLine();
                            if (LinhaTexto == null)
                            {
                                break;
                            }
                            try
                            {
                                string[] tokens = LinhaTexto.Split(';');

                                foreach (DataGridViewRow row in dgvDados.Rows)
                                {
                                    if (row.Cells[0].Value.ToString().Equals(tokens[2]))
                                    {
                                        row.Cells[9].Value = tokens[4];
                                        row.Cells[10].Value = tokens[0];


                                        btnRecalc_Click(btnRecalc, new EventArgs());
                                        if (!row.Cells[7].Value.ToString().Equals(row.Cells[9].Value))
                                            row.DefaultCellStyle.BackColor = System.Drawing.Color.Red;

                                    }
                                }

                            }
                            catch (IOException ioExcept)
                            {
                                MessageBox.Show(arq_Path + ioExcept.ToString());
                            }
                            finally
                            {

                            }
                        }
                    }

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
