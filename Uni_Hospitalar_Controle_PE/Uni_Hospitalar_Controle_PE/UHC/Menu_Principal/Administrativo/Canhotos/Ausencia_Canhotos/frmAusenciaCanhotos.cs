using ClosedXML.Excel;
using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using Ulib;
using System.Windows.Forms;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;
using System.Text;
using System.Collections.Generic;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Canhotos.Ausencia_Canhotos
{
    public partial class frmAusenciaCanhotos : Form
    {
        public frmAusenciaCanhotos()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand(); //Para comandos     
        private SqlDataReader reader;
        private SqlDataAdapter adaptador;
        //Erro de acesso ao sql
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

        
        Boolean PermissaoEmail = false;

        private void Carregar_Bloqueios()
        {

            //Canhotos
            gpbPagamento.Enabled = false;
            gpbRomaneio.Enabled = false;
            PermissaoEmail = false;


            

        }
        private void Carregar_Permissoes()
        {            
                //Subindo permissões
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT Cod_Usuario,Cod_Sessao,Cod_Rotina,Status_Acesso " +
                                              " FROM  UNIDB.[dbo].ACESS " +
                                              " WHERE Cod_Usuario =" + Usuario.userId;
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Cod_Usuario"] != null)
                            {
                                //Permissão para usuário
                                if (reader["Cod_Rotina"].ToString() == "31" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    gpbPagamento.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "32" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    gpbRomaneio.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "33" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    PermissaoEmail = true;
                                }



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

        public String user_Login;

        //Variáveis de complemento código sql
        String comando;
        String pagamento;
        String romaneio;
        String registro_canhoto;

        //Variáveis de update        
        String sPeriodo;      
        String Filtro_Pagamento;
        String Filtro_Romaneio;
        String Filtro_Canhoto;

        List<String> lsLista_Distribuicao_Email = new List<String>();
        
        //Filtar os dados
        private void Filtrar_Dados()
        {

            //Pagamento 
            if (chkPagSim.Checked == true && chkPagNao.Checked == true)
            {
                pagamento = "";
                Filtro_Pagamento = "T";
            }
            else if ((chkPagSim.Checked == true && chkPagNao.Checked == false))
            {
                pagamento = "AND xrec.Dat_Registro is not null";
                Filtro_Pagamento = "S";
            }
            else if ((chkPagSim.Checked == false && chkPagNao.Checked == true))
            {
                pagamento = "AND xrec.Dat_Registro is null and REC.Status <> 'B' ";
                Filtro_Pagamento = "N";
            }
            else if (((chkPagSim.Checked == false && chkPagNao.Checked == false))) 
            {
                pagamento = "";
                Filtro_Pagamento = "T";
            }

            //Romaneio
            if (chkRomSim.Checked == true && chkRomNao.Checked == true)
            {
                romaneio = "";
                Filtro_Romaneio = "T";
            }
            else if ((chkRomSim.Checked == true && chkRomNao.Checked == false))
            {
                romaneio = "and CAN.Num_Nota in (SELECT num_nota from DMD.dbo.RMNIT)";
                Filtro_Romaneio = "S";
            }
            else if ((chkRomSim.Checked == false && chkRomNao.Checked == true))
            {
                romaneio = " and CAN.Num_Nota not in (SELECT num_nota from DMD.dbo.RMNIT) ";
                Filtro_Romaneio = "N";
            }
            else if (((chkRomSim.Checked == false && chkRomNao.Checked == false)))
            {
                romaneio = "";
                Filtro_Romaneio = "T";
            }

            //Registro
            if (chkRegSim.Checked == true && chkRegNao.Checked == true)
            {
                registro_canhoto = "";
                Filtro_Canhoto = "T";
            }
            else if ((chkRegSim.Checked == true && chkRegNao.Checked == false))
            {
                registro_canhoto = "AND CAN.Dat_Canhoto IS NOT NULL";
                Filtro_Canhoto = "S";
            }
            else if ((chkRegSim.Checked == false && chkRegNao.Checked == true))
            {
                registro_canhoto = " AND CAN.Dat_Canhoto IS NULL ";
                Filtro_Canhoto = "N";
            }
            else if (((chkRegSim.Checked == false && chkRegNao.Checked == false)))
            {
                registro_canhoto = "";
                Filtro_Canhoto = "T";
            }


            if (!txtTransportadora.Text.Trim().Equals(String.Empty))
            {
                comando =
" 				SELECT DISTINCT CAN.Num_Nota [Nota]     "+
" 				,[Dt. Emissão] =  CONVERT(DATE,NFS.DAT_EMISSAO)  "+
" 				,CLI.Codigo [Cód. Cliente]    "+
" 				,CLI.Razao_Social [Desc. Clien]    "+
" 				,CLI.Cod_Estado [UF]    "+
" 				,NFS.COD_CFO1 as [CFOP]    "+
" 				,CFO.Descricao as [Desc. CFOP]    "+
" 				,TRA.Razao_Social as [Responsável]				"+
" 				FROM DMD.dbo.NFSCB NFS "+
" 				INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NFS.Num_Nota 												"+
" 				LEFT OUTER JOIN DMD.dbo.CLIEN CLI ON CLI.CODIGO = NFS.Cod_Cliente "+
" 				LEFT OUTER JOIN DMD.dbo.TBCFO CFO ON CFO.CODIGO = NFS.Cod_Cfo1 "+
" 				LEFT OUTER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NFS.Cod_Transportadora "+
" 				LEFT OUTER JOIN DMD.dbo.CTREC REC ON REC.Num_NfOrigem = NFS.Num_Nota "+
" 				LEFT OUTER JOIN DMD.dbo.bxrec XREC ON XREC.Cod_Documento = REC.Cod_Documento"+
" 				"+
" 				WHERE NFS.Dat_Emissao >= '2018-01-01' AND NFS.Status = 'F' AND Tip_Saida <> ('D') and nfs.Dat_Emissao between @dat_inicial and @dat_final"+

"               and TRA.CODIGO ="+txtCodTransportadora.Text+

                registro_canhoto+

 				pagamento+

                romaneio+
" "+
" 				UNION"+
" "+
" 				SELECT DISTINCT CAN.Num_Nota [Nota]     "+
" 				,[Dt. Emissão] =  CONVERT(DATE,NFS.DAT_EMISSAO)  "+
" 				,CLI.Codigo [Cód. Cliente]    "+
" 				,CLI.Razao_Social [Desc. Clien]    "+
" 				,CLI.Cod_Estado [UF]    "+
" 				,NFS.COD_CFO as [CFOP]    "+
" 				,CFO.Descricao as [Desc. CFOP]    "+
" 				,TRA.Razao_Social as [Responsável]				"+
" 				FROM DMD.dbo.NFECB NFS "+
" 				INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NFS.Numero 												"+
" 				LEFT OUTER JOIN DMD.dbo.CLIEN CLI ON CLI.CODIGO = NFS.Cod_EmiCliente "+
" 				LEFT OUTER JOIN DMD.dbo.TBCFO CFO ON CFO.CODIGO = NFS.Cod_Cfo "+
" 				LEFT OUTER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NFS.Cod_Transp"+
" 				LEFT OUTER JOIN DMD.dbo.CTREC REC ON REC.Num_NfOrigem = NFS.Numero"+
" 				LEFT OUTER JOIN DMD.dbo.bxrec XREC ON XREC.Cod_Documento = REC.Cod_Documento"+
" 				"+
" 				WHERE NFS.Dat_Emissao >= '2018-01-01' AND NFS.Status = 'F' AND Tip_NF = ('D') and nfs.Dat_Emissao between @dat_inicial and @dat_final"+

"               and TRA.CODIGO =" + txtCodTransportadora.Text +

                registro_canhoto +

                 pagamento +

                romaneio +
" 				" +
" 				"+
" 				ORDER BY Nota DESC";
            }
            else
            {
                comando =
" 				SELECT DISTINCT CAN.Num_Nota [Nota]     " +
" 				,[Dt. Emissão] =  CONVERT(DATE,NFS.DAT_EMISSAO)  " +
" 				,CLI.Codigo [Cód. Cliente]    " +
" 				,CLI.Razao_Social [Desc. Clien]    " +
" 				,CLI.Cod_Estado [UF]    " +
" 				,NFS.COD_CFO1 as [CFOP]    " +
" 				,CFO.Descricao as [Desc. CFOP]    " +
" 				,TRA.Razao_Social as [Responsável]				" +
" 				FROM DMD.dbo.NFSCB NFS " +
" 				INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NFS.Num_Nota 												" +
" 				LEFT OUTER JOIN DMD.dbo.CLIEN CLI ON CLI.CODIGO = NFS.Cod_Cliente " +
" 				LEFT OUTER JOIN DMD.dbo.TBCFO CFO ON CFO.CODIGO = NFS.Cod_Cfo1 " +
" 				LEFT OUTER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NFS.Cod_Transportadora " +
" 				LEFT OUTER JOIN DMD.dbo.CTREC REC ON REC.Num_NfOrigem = NFS.Num_Nota " +
" 				LEFT OUTER JOIN DMD.dbo.bxrec XREC ON XREC.Cod_Documento = REC.Cod_Documento" +
" 				" +
" 				WHERE NFS.Dat_Emissao >= '2018-01-01' AND NFS.Status = 'F' AND Tip_Saida <> ('D') and nfs.Dat_Emissao between @dat_inicial and @dat_final " +



registro_canhoto +

 pagamento +

romaneio +
" " +
" 				UNION" +
" " +
" 				SELECT DISTINCT CAN.Num_Nota [Nota]     " +
" 				,[Dt. Emissão] =  CONVERT(DATE,NFS.DAT_EMISSAO)  " +
" 				,CLI.Codigo [Cód. Cliente]    " +
" 				,CLI.Razao_Social [Desc. Clien]    " +
" 				,CLI.Cod_Estado [UF]    " +
" 				,NFS.COD_CFO as [CFOP]    " +
" 				,CFO.Descricao as [Desc. CFOP]    " +
" 				,TRA.Razao_Social as [Responsável]				" +
" 				FROM DMD.dbo.NFECB NFS " +
" 				INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NFS.Numero 												" +
" 				LEFT OUTER JOIN DMD.dbo.CLIEN CLI ON CLI.CODIGO = NFS.Cod_EmiCliente " +
" 				LEFT OUTER JOIN DMD.dbo.TBCFO CFO ON CFO.CODIGO = NFS.Cod_Cfo " +
" 				LEFT OUTER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NFS.Cod_Transp" +
" 				LEFT OUTER JOIN DMD.dbo.CTREC REC ON REC.Num_NfOrigem = NFS.Numero" +
" 				LEFT OUTER JOIN DMD.dbo.bxrec XREC ON XREC.Cod_Documento = REC.Cod_Documento" +
" 				" +
" 				WHERE NFS.Dat_Emissao >= '2018-01-01' AND NFS.Status = 'F' AND Tip_NF = ('D') and nfs.Dat_Emissao between @dat_inicial and @dat_final " +


registro_canhoto +

 pagamento +

romaneio +
" 				" +
" 				" +
" 				ORDER BY Nota DESc";
            }

           
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = comando;
                        command.Parameters.AddWithValue("DAT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                        command.Parameters.AddWithValue("DAT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));

                        adaptador = new SqlDataAdapter(command);
                        System.Data.DataTable tableDados2 = new System.Data.DataTable();
                        adaptador.Fill(tableDados2);
                        dgvDados.DataSource = tableDados2;

                    }
                    catch (SqlException SQLe)
                    {
                        erroSQLE(SQLe);
                    }
                    finally
                    {
                        connectDMD.Close();
                        dgvDados.Columns[0].Width = 65;
                        dgvDados.Columns[2].Width = 80;
                        dgvDados.Columns[1].Width = 80;
                        dgvDados.Columns[3].Width = 280;
                        dgvDados.Columns[4].Width = 75;
                        dgvDados.Columns[6].Width = 140;
                        dgvDados.Columns[7].Width = 180;
                    }
                }
           
        }
         
        //Enviar e-mail em formato excel com datagridivew
        protected void ExportExcel(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            //Alimentando variáveis de controle
            sPeriodo = dtpDtInicial.Text + " até " + dtpDtFinal.Text;
            //Pagamento 
            if (chkPagSim.Checked == true && chkPagNao.Checked == true)
            {
                
                Filtro_Pagamento = "T";
            }
            else if ((chkPagSim.Checked == true && chkPagNao.Checked == false))
            {                
                Filtro_Pagamento = "S";
            }
            else if ((chkPagSim.Checked == false && chkPagNao.Checked == true))
            {                
                Filtro_Pagamento = "N";
            }
            else if (((chkPagSim.Checked == false && chkPagNao.Checked == false)))
            {
                
                Filtro_Pagamento = "T";
            }

            //Romaneio
            if (chkRomSim.Checked == true && chkRomNao.Checked == true)
            {
                
                Filtro_Romaneio = "T";
            }
            else if ((chkRomSim.Checked == true && chkRomNao.Checked == false))
            {
                
                Filtro_Romaneio = "S";
            }
            else if ((chkRomSim.Checked == false && chkRomNao.Checked == true))
            {
                
                Filtro_Romaneio = "N";
            }
            else if (((chkRomSim.Checked == false && chkRomNao.Checked == false)))
            {
                
                Filtro_Romaneio = "T";
            }

            //Registro
            if (chkRegSim.Checked == true && chkRegNao.Checked == true)
            {
                
                Filtro_Canhoto = "T";
            }
            else if ((chkRegSim.Checked == true && chkRegNao.Checked == false))
            {
                
                Filtro_Canhoto = "S";
            }
            else if ((chkRegSim.Checked == false && chkRegNao.Checked == true))
            {
                
                Filtro_Canhoto = "N";
            }
            else if (((chkRegSim.Checked == false && chkRegNao.Checked == false)))
            {
                
                Filtro_Canhoto = "T";
            }



            String Transp = txtTransportadora.Text.Substring(0, 12);
            DataTable tableDados2 = null;

            //Select aqui ();
            if (!txtTransportadora.Text.Trim().Equals(String.Empty))
            {
                comando =
" 				SELECT DISTINCT CAN.Num_Nota [Nota]     " +
" 				,[Dt. Emissão] =  CONVERT(DATE,NFS.DAT_EMISSAO)  " +
" 				,CLI.Codigo [Cód. Cliente]    " +
" 				,CLI.Razao_Social [Desc. Clien]    " +
" 				,CLI.Cod_Estado [UF]    " +
" 				,NFS.COD_CFO1 as [CFOP]    " +
" 				,CFO.Descricao as [Desc. CFOP]    " +
" 				,TRA.Razao_Social as [Responsável]				" +
" 				FROM DMD.dbo.NFSCB NFS " +
" 				INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NFS.Num_Nota 												" +
" 				LEFT OUTER JOIN DMD.dbo.CLIEN CLI ON CLI.CODIGO = NFS.Cod_Cliente " +
" 				LEFT OUTER JOIN DMD.dbo.TBCFO CFO ON CFO.CODIGO = NFS.Cod_Cfo1 " +
" 				LEFT OUTER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NFS.Cod_Transportadora " +
" 				LEFT OUTER JOIN DMD.dbo.CTREC REC ON REC.Num_NfOrigem = NFS.Num_Nota " +
" 				LEFT OUTER JOIN DMD.dbo.bxrec XREC ON XREC.Cod_Documento = REC.Cod_Documento" +
" 				" +
" 				WHERE NFS.Dat_Emissao >= '2018-01-01' AND NFS.Status = 'F' AND Tip_Saida <> ('D') and nfs.Dat_Emissao between @dat_inicial and @dat_final" +

"               and TRA.CODIGO =" + txtCodTransportadora.Text +

                registro_canhoto +

                 pagamento +

                romaneio +
" " +
" 				UNION" +
" " +
" 				SELECT DISTINCT CAN.Num_Nota [Nota]     " +
" 				,[Dt. Emissão] =  CONVERT(DATE,NFS.DAT_EMISSAO)  " +
" 				,CLI.Codigo [Cód. Cliente]    " +
" 				,CLI.Razao_Social [Desc. Clien]    " +
" 				,CLI.Cod_Estado [UF]    " +
" 				,NFS.COD_CFO as [CFOP]    " +
" 				,CFO.Descricao as [Desc. CFOP]    " +
" 				,TRA.Razao_Social as [Responsável]				" +
" 				FROM DMD.dbo.NFECB NFS " +
" 				INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NFS.Numero 												" +
" 				LEFT OUTER JOIN DMD.dbo.CLIEN CLI ON CLI.CODIGO = NFS.Cod_EmiCliente " +
" 				LEFT OUTER JOIN DMD.dbo.TBCFO CFO ON CFO.CODIGO = NFS.Cod_Cfo " +
" 				LEFT OUTER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NFS.Cod_Transp" +
" 				LEFT OUTER JOIN DMD.dbo.CTREC REC ON REC.Num_NfOrigem = NFS.Numero" +
" 				LEFT OUTER JOIN DMD.dbo.bxrec XREC ON XREC.Cod_Documento = REC.Cod_Documento" +
" 				" +
" 				WHERE NFS.Dat_Emissao >= '2018-01-01' AND NFS.Status = 'F' AND Tip_NF = ('D') and nfs.Dat_Emissao between @dat_inicial and @dat_final" +
                
                "               and TRA.CODIGO =" + txtCodTransportadora.Text +

                registro_canhoto +

                 pagamento +

                romaneio +
" 				" +
" 				" +
" 				ORDER BY Nota DESC";
            }
            else
            {
                comando =
" 				SELECT DISTINCT CAN.Num_Nota [Nota]     " +
" 				,[Dt. Emissão] =  CONVERT(DATE,NFS.DAT_EMISSAO)  " +
" 				,CLI.Codigo [Cód. Cliente]    " +
" 				,CLI.Razao_Social [Desc. Clien]    " +
" 				,CLI.Cod_Estado [UF]    " +
" 				,NFS.COD_CFO1 as [CFOP]    " +
" 				,CFO.Descricao as [Desc. CFOP]    " +
" 				,TRA.Razao_Social as [Responsável]				" +
" 				FROM DMD.dbo.NFSCB NFS " +
" 				INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NFS.Num_Nota 												" +
" 				LEFT OUTER JOIN DMD.dbo.CLIEN CLI ON CLI.CODIGO = NFS.Cod_Cliente " +
" 				LEFT OUTER JOIN DMD.dbo.TBCFO CFO ON CFO.CODIGO = NFS.Cod_Cfo1 " +
" 				LEFT OUTER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NFS.Cod_Transportadora " +
" 				LEFT OUTER JOIN DMD.dbo.CTREC REC ON REC.Num_NfOrigem = NFS.Num_Nota " +
" 				LEFT OUTER JOIN DMD.dbo.bxrec XREC ON XREC.Cod_Documento = REC.Cod_Documento" +
" 				" +
" 				WHERE NFS.Dat_Emissao >= '2018-01-01' AND NFS.Status = 'F' AND Tip_Saida <> ('D') and nfs.Dat_Emissao between @dat_inicial and @dat_final" +



registro_canhoto +

 pagamento +

romaneio +
" " +
" 				UNION" +
" " +
" 				SELECT DISTINCT CAN.Num_Nota [Nota]     " +
" 				,[Dt. Emissão] =  CONVERT(DATE,NFS.DAT_EMISSAO)  " +
" 				,CLI.Codigo [Cód. Cliente]    " +
" 				,CLI.Razao_Social [Desc. Clien]    " +
" 				,CLI.Cod_Estado [UF]    " +
" 				,NFS.COD_CFO as [CFOP]    " +
" 				,CFO.Descricao as [Desc. CFOP]    " +
" 				,TRA.Razao_Social as [Responsável]				" +
" 				FROM DMD.dbo.NFECB NFS " +
" 				INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NFS.Numero 												" +
" 				LEFT OUTER JOIN DMD.dbo.CLIEN CLI ON CLI.CODIGO = NFS.Cod_EmiCliente " +
" 				LEFT OUTER JOIN DMD.dbo.TBCFO CFO ON CFO.CODIGO = NFS.Cod_Cfo " +
" 				LEFT OUTER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NFS.Cod_Transp" +
" 				LEFT OUTER JOIN DMD.dbo.CTREC REC ON REC.Num_NfOrigem = NFS.Numero" +
" 				LEFT OUTER JOIN DMD.dbo.bxrec XREC ON XREC.Cod_Documento = REC.Cod_Documento" +
" 				" +
" 				WHERE NFS.Dat_Emissao >= '2018-01-01' AND NFS.Status = 'F' AND Tip_NF = ('D') and nfs.Dat_Emissao between @dat_inicial and @dat_final " +


registro_canhoto +

 pagamento +

romaneio +
" 				" +
" 				" +
" 				ORDER BY Nota DESc";
            }                     
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = comando;
                        command.Parameters.AddWithValue("DAT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                        command.Parameters.AddWithValue("DAT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));



                        adaptador = new SqlDataAdapter(command);
                        tableDados2 = new System.Data.DataTable();
                        adaptador.Fill(tableDados2);
                        dgvDados.DataSource = tableDados2;
                    }
                    catch (SqlException SQLe)
                    {
                        erroSQLE(SQLe);
                    }
                    finally
                    {
                        connectDMD.Close();
                        dgvDados.Columns[0].Width = 65;
                        dgvDados.Columns[2].Width = 80;
                        dgvDados.Columns[1].Width = 80;
                        dgvDados.Columns[3].Width = 280;
                        dgvDados.Columns[4].Width = 75;
                        dgvDados.Columns[6].Width = 140;
                        dgvDados.Columns[7].Width = 180;
                    }
                }
            
            

           
            
         
            //Set DataTable Name which will be the name of Excel Sheet.
            tableDados2.TableName = "Canhotos "+ Transp;

            //Create a New Workbook.
            using (XLWorkbook wb = new XLWorkbook())
            {
                //Add the DataTable as Excel Worksheet.
                wb.Worksheets.Add(tableDados2);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    //Save the Excel Workbook to MemoryStream.
                    wb.SaveAs(memoryStream);

                    //Convert MemoryStream to Byte array.
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();

                    


                    //Send Email with Excel attachment.
                    using (MailMessage mm = new MailMessage("inteligence@unihospitalar.com.br","administrativo@unihospitalar.com.br"))
                    {

                        try
                        {
                            foreach (var item in lsLista_Distribuicao_Email)
                            {
                                mm.To.Add(item);
                            }
                                                        
                            StringBuilder CorpoEmail = new StringBuilder();
                            //mm.To.Add("ti@unihospitalar.com.br");
                            mm.CC.Add("recepcao@unihospitalar.com.br");
                            mm.CC.Add("administrativo@unihospitalar.com.br");
                            //mm.CC.Add("ti@unihospitalar.com.br");
                            mm.Subject = "Canhotos " + Transp;
                            // Define o corpo do E-mail --------------------------------------------------------------------------------

                            // Insere a imagem superior centralizada ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
                            CorpoEmail.Append("<table style=\"width: 100%\" border=\"0\">");
                            CorpoEmail.Append("<p>Prezado(a),</p>");
                            CorpoEmail.Append("<p>Anexa, relação de canhotos pendentes de recebimento. Solicitamos o envio imediato dos canhotos originais devidamente assinados.</p>");
                            CorpoEmail.Append("<p>Em caso de dúvidas ou necessidade, entrar em contato através dos e-mails: </p>");
                            CorpoEmail.Append("<p>&emsp; administrativo@unihospitalar.com.br </p>");
                            CorpoEmail.Append("<p>&emsp; recepcao@unihospitalar.com.br</p>");                                                                                                     
                            CorpoEmail.Append("<p>Ou pelo telefone abaixo:</p>");
                            CorpoEmail.Append("<p>&emsp; (81) 3472-7201</p>");

                            CorpoEmail.Append("<tr>");
                            CorpoEmail.Append("<b>Agradecemos pela sua parceria.</b><br>");
                            CorpoEmail.Append("<b>Atenciosamente,</b><br>");
                           
                            CorpoEmail.Append("<td align=\"left\">");
                            CorpoEmail.Append("<img src=\"https://i.ibb.co/fD2PfKS/Assina-Email-Inteligence.png\" />"); //assinatura
                            CorpoEmail.Append("</td>");
                            CorpoEmail.Append("</tr>");
                            CorpoEmail.Append("</table>");

                            // Insere uma mensagem padrão ¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨¨
                            CorpoEmail.Append("<br />");
                            CorpoEmail.Append("<b>E-mail gerado automaticamente pelo sistema UHC 2. Favor não responder!</b>");

                            CorpoEmail.Append("<br />");
                            CorpoEmail.Append("<br />");

                            
                            mm.IsBodyHtml = true;

                            mm.BodyEncoding = Encoding.GetEncoding("ISO-8859-1"); // <-- Define o Encoding para aceitar caracteres especiais
                            mm.Body = CorpoEmail.ToString();
                            //Add Byte array as Attachment.
                            mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "Canhotos " + sPeriodo + ".xlsx"));

                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";

                            smtp.EnableSsl = true;
                            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                            credentials.UserName = Parametros_Empresa.email_Automatico;
                            credentials.Password = Parametros_Empresa.password_email_Automatico; 



                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = credentials;
                            smtp.Port = 587;
                            smtp.Send(mm);
                        }
                        catch(SmtpException except)
                        {
                            MessageBox.Show(except.ToString());
                        }
                        finally
                        {
                            mMessage = "E-mail enviado para "+Transp+" do período "+sPeriodo;
                            mTittle = "E-mail enviado";
                            mButton = MessageBoxButtons.OK;
                            mIcon = MessageBoxIcon.Information;
                            MessageBox.Show(mMessage, mTittle, mButton, mIcon);

                            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                            {
                                try
                                {
                                    connectDMD.Open();

                                    command = connectDMD.CreateCommand();
                                    command.CommandText = " INSERT INTO UNIDB.dbo.ENVCA" +
                                                          " (Usuario,Cod_Transportadora,Dat_Envio,Periodo,Filtro_Pagamento,Filtro_Romaneio,Filtro_Canhoto)" +
                                                          " VALUES('"+user_Login+"', "+txtCodTransportadora.Text.Trim()+", Getdate(), '"+sPeriodo+"', '"+Filtro_Pagamento+"', '"+Filtro_Romaneio+"' ,'"+Filtro_Canhoto+"')";




                                    command.ExecuteNonQuery();
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
                    }
                }
            }
        }
       
        private void Configuracoes_Iniciais()
        {
            dtpDtInicial.Text = DateTime.Now.AddDays(-15).ToString();
            dtpDtFinal.Text = DateTime.Now.ToString();
            BtnPesquisar_Click(btnPesquisar, new EventArgs());

        }

        //Load do form
        private void FrmAusenciaCanhotos_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            Carregar_Bloqueios();
            Carregar_Permissoes();
            Configuracoes_Iniciais();
           
        }



        //Informa a transportadora
        private void TxtCodTransportadora_TextChanged(object sender, EventArgs e)
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
                        command.CommandText = "SELECT razao_social FROM trans WHERE CODIGO = " + Convert.ToUInt32(txtCodTransportadora.Text);

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
        //Permite a ativação do botão enviar e-mail
        private void TxtTransportadora_TextChanged(object sender, EventArgs e)
        {
            lblEnvioTransp.Text = txtTransportadora.Text;            
            if (PermissaoEmail == true)
            {
                if (txtTransportadora.Text.Length > 0)
                {
                    btnEnviarEmail.Enabled = true;
                    BtnPesquisar_Click(txtTransportadora, new EventArgs());
                }
                else
                {
                    btnEnviarEmail.Enabled = false;
                }
            }
        }
        

        private void BtnPreencherTransportadora_Click(object sender, EventArgs e)
        {
            //Apontado para o CI da aba logísitica
            frmCriarCi_EscolherTransportadora form = new frmCriarCi_EscolherTransportadora();            
            
            form.ShowDialog();
            if (form.cod_transportadora != 0)
                txtCodTransportadora.Text = Convert.ToString(form.cod_transportadora);
        }
        
        //Fechar com esc
        private void FrmAusenciaCanhotos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }

        //Fiai moriltrar
        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Filtrar_Dados();
            this.Cursor = Cursors.Default;
        }




      //Enviar o e-mail
        private void BtnEnviarEmail_Click(object sender, EventArgs e)
        {
            lsLista_Distribuicao_Email.Clear();            
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText = "SELECT Email_Transportadora FROM [UNIDB].dbo.[EMAIL_TRANSPORTADORA] WHERE Cod_Transportadora = " + Convert.ToUInt32(txtCodTransportadora.Text);

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["Email_Transportadora"] != null)
                        {
                            lsLista_Distribuicao_Email.Add(reader["Email_Transportadora"].ToString());
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
                    if (lsLista_Distribuicao_Email.Count > 0)                        
                        ExportExcel(btnEnviarEmail, new EventArgs());
                    else
                    {
                        mMessage = "Não há email cadastrado para a transportadora";
                        mTittle = "Ausência de cadastro";
                        mButton = MessageBoxButtons.OK;
                        mIcon = MessageBoxIcon.Exclamation;
                        MessageBox.Show(mMessage,mTittle,mButton,mIcon);
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
            worksheet.Name = "Canhotos";
            foreach (Excel.Worksheet wrkst in workbook.Worksheets)
            {
                Excel.Range usedrange = wrkst.UsedRange;
                usedrange.Columns.AutoFit();
            }
        }



        //Função para digitar somente números
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        //Pesquisa com enter
        private void Pesquisa_Com_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPesquisar_Click(btnPesquisar,new EventArgs());
            }
        }
    }
}
