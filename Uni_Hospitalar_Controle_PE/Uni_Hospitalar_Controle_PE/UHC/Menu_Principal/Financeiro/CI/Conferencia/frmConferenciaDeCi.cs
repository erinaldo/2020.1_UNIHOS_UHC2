using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.CI.Conferencia;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Conferencia;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.CI
{
    public partial class frmConferenciaDeCi : Form
    {
        public frmConferenciaDeCi()
        {
            InitializeComponent();
        }

        private void frmConferenciaDeCi_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            filtrarDados();
            formatarDados(dgvDados);
            Carregar_Bloqueios();
            Carregar_Permissoes();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
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

        List<String> lNF_Devolucao = new List<String>();
        List<String> lNum_Ci = new List<String>();

        String sCI;
        
        
        private void Carregar_Bloqueios()
        {
            dgvDados.Enabled = false;
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
                                              " WHERE Cod_Usuario = " + Usuario.userId;
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Cod_Usuario"] != null)
                            {
                                //Permissão para usuário
                                if (reader["Cod_Rotina"].ToString() == "2" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    dgvDados.Enabled = true;
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

        private void filtrarDados()
        {

                if (!txtNFdevol.Text.Trim().Equals(String.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "  SELECT CIT.Num_CI [Ocorrência] " +
                                                  " ,MOT.Desc_Motivo[Motivo] " +
                                                  " ,STO.Desc_Setor[Setor] " +
                                                  " ,CLI.Razao_Social[Cliente] " +
                                                  " ,TRA.Fantasia[Transportadora] " +
                                                  " ,[Operação] = CASE CIT.Tipo_Operacao " +
                                                  "  WHEN 'T' THEN 'Devolução Total' " +
                                                  "  WHEN 'P'  THEN 'Devolução Parcial' " +
                                                  "  END " +
                                                  " ,[Retorno físico] = CASE CIT.Retorno_Fisico " +
                                                  "  WHEN '1' THEN 'Sim' " +
                                                  "  WHEN '0'  THEN 'Não' " +
                                                  "  END " +
                                                  " ,CIT.NF_Refatura[Nota de refatura] " +
                                                  " ,REPLACE(NF_origem,',','/')[Nota de Origem]" +
                                                  " ,CIT.Dat_Entrada [Dat. Registro]" +
                                                  " ,CIT.Observacao" +
                                                  " ,CIT.STATUS" +
                                                  " ,Observacao_Fin [Obs. Financeira] " +
                                                  "  FROM UNIDB.[dbo].CITOP CIT " +
                                                  "  INNER JOIN UNIDB.[dbo].MOTIV MOT ON MOT.Cod_Motivo = CIT.Cod_Motivo " +
                                                  "  INNER JOIN UNIDB.[dbo].SETOR STO ON STO.Cod_Setor = CIT.Cod_Setor " +
                                                  "  INNER JOIN DMD.[dbo].CLIEN CLI ON CLI.Codigo = CIT.Cod_Cliente " +
                                                  "  LEFT OUTER JOIN DMD.[dbo].TRANS TRA ON TRA.Codigo = CIT.Cod_Transportadora " +
                                                  "  INNER JOIN UNIDB.[dbo].CIDEV CID ON CID.Num_CI = CIT.Num_CI " +
                                                  "  WHERE CID.NF_Devolucao = @NF_Devolucao " +
                                                  " ORDER BY CIT.NUM_CI DESC";

                            SqlParameter pNF_Devolucao = new SqlParameter("@NF_Devolucao", SqlDbType.Int);
                            pNF_Devolucao.Value = Convert.ToInt32(txtNFdevol.Text);
                            command.Parameters.Add(pNF_Devolucao);

                            adaptador = new SqlDataAdapter(command);
                            System.Data.DataTable tableDados = new System.Data.DataTable();
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
                            dgvDados.Columns[0].Width = 65;
                            dgvDados.Columns[2].Width = 230;
                            dgvDados.Columns[1].Width = 100;
                            dgvDados.Columns[3].Width = 280;
                            dgvDados.Columns[4].Width = 230;
                            dgvDados.Columns[6].Width = 55;
                            dgvDados.Columns[7].Width = 55;
                        }
                    }
                    return;
                }
                if (!txtNFrefat.Text.Trim().Equals(String.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "  SELECT CIT.Num_CI [Ocorrência] " +
                                                  " ,MOT.Desc_Motivo[Motivo] " +
                                                  " ,STO.Desc_Setor[Setor] " +
                                                  " ,CLI.Razao_Social[Cliente] " +
                                                  " ,TRA.Fantasia[Transportadora] " +
                                                  " ,[Operação] = CASE CIT.Tipo_Operacao " +
                                                  "  WHEN 'T' THEN 'Devolução Total' " +
                                                  "  WHEN 'P'  THEN 'Devolução Parcial' " +
                                                  "  END " +
                                                  " ,[Retorno físico] = CASE CIT.Retorno_Fisico " +
                                                  "  WHEN '1' THEN 'Sim' " +
                                                  "  WHEN '0'  THEN 'Não' " +
                                                  "  END " +
                                                  " ,CIT.NF_Refatura[Nota de refatura]" +
                                                  " ,REPLACE(NF_origem,',','/')[Nota de Origem]" +
                                                  " ,CIT.Dat_Entrada [Dat. Registro]" +
                                                  " ,CIT.Observacao" +
                                                  " ,CIT.STATUS" +
                                                  " ,Observacao_Fin [Obs. Financeira] " +
                                                  "  FROM UNIDB.[dbo].CITOP CIT " +
                                                  "  INNER JOIN UNIDB.[dbo].MOTIV MOT ON MOT.Cod_Motivo = CIT.Cod_Motivo " +
                                                  "  INNER JOIN UNIDB.[dbo].SETOR STO ON STO.Cod_Setor = CIT.Cod_Setor " +
                                                  "  INNER JOIN DMD.[dbo].CLIEN CLI ON CLI.Codigo = CIT.Cod_Cliente " +
                                                  "  LEFT OUTER JOIN DMD.[dbo].TRANS TRA ON TRA.Codigo = CIT.Cod_Transportadora " +
                                                  "  WHERE CIT.NF_Refatura = @NF_Refatura " +
                                                  " ORDER BY CIT.NUM_CI DESC";

                            SqlParameter pNF_Refatura = new SqlParameter("@NF_Refatura", SqlDbType.Int);
                            pNF_Refatura.Value = Convert.ToInt32(txtNFrefat.Text);
                            command.Parameters.Add(pNF_Refatura);

                            adaptador = new SqlDataAdapter(command);
                            System.Data.DataTable tableDados = new System.Data.DataTable();
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
                            dgvDados.Columns[0].Width = 65;
                            dgvDados.Columns[2].Width = 230;
                            dgvDados.Columns[1].Width = 100;
                            dgvDados.Columns[3].Width = 280;
                            dgvDados.Columns[4].Width = 230;
                            dgvDados.Columns[6].Width = 55;
                            dgvDados.Columns[7].Width = 55;
                        }
                    }
                    return;
                }
                if (!txtNFOrigem.Text.Trim().Equals(String.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "  SELECT CIT.Num_CI [Ocorrência] " +
                                                  " ,MOT.Desc_Motivo[Motivo] " +
                                                  " ,STO.Desc_Setor[Setor] " +
                                                  " ,CLI.Razao_Social[Cliente] " +
                                                  " ,TRA.Fantasia[Transportadora] " +
                                                  " ,[Operação] = CASE CIT.Tipo_Operacao " +
                                                  "  WHEN 'T' THEN 'Devolução Total' " +
                                                  "  WHEN 'P'  THEN 'Devolução Parcial' " +
                                                  "  END " +
                                                  " ,[Retorno físico] = CASE CIT.Retorno_Fisico " +
                                                  "  WHEN '1' THEN 'Sim' " +
                                                  "  WHEN '0'  THEN 'Não' " +
                                                  "  END " +
                                                  " ,CIT.NF_Refatura[Nota de refatura] " +
                                                  " ,REPLACE(NF_origem,',','/')[Nota de Origem]" +
                                                  " ,CIT.Dat_Entrada [Dat. Registro]" +
                                                  " ,CIT.Observacao" +
                                                  " ,CIT.STATUS" +
                                                  " ,Observacao_Fin [Obs. Financeira] " +
                                                  "  FROM UNIDB.[dbo].CITOP CIT " +
                                                  "  INNER JOIN UNIDB.[dbo].MOTIV MOT ON MOT.Cod_Motivo = CIT.Cod_Motivo " +
                                                  "  INNER JOIN UNIDB.[dbo].SETOR STO ON STO.Cod_Setor = CIT.Cod_Setor " +
                                                  "  INNER JOIN DMD.[dbo].CLIEN CLI ON CLI.Codigo = CIT.Cod_Cliente " +
                                                  "  LEFT OUTER JOIN DMD.[dbo].TRANS TRA ON TRA.Codigo = CIT.Cod_Transportadora " +
                                                  "  WHERE CIT.NF_Origem like '%" + txtNFOrigem.Text + "%' " +
                                                  " ORDER BY CIT.NF_Origem DESC";


                            adaptador = new SqlDataAdapter(command);
                            System.Data.DataTable tableDados = new System.Data.DataTable();
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
                            dgvDados.Columns[0].Width = 65;
                            dgvDados.Columns[2].Width = 230;
                            dgvDados.Columns[1].Width = 100;
                            dgvDados.Columns[3].Width = 280;
                            dgvDados.Columns[4].Width = 230;
                            dgvDados.Columns[6].Width = 55;
                            dgvDados.Columns[7].Width = 55;
                        }
                    }
                    return;
                }
                if (!txtNocorrencia.Text.Trim().Equals(String.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "  SELECT CIT.Num_CI [Ocorrência] " +
                                                  " ,MOT.Desc_Motivo[Motivo] " +
                                                  " ,STO.Desc_Setor[Setor] " +
                                                  " ,CLI.Razao_Social[Cliente] " +
                                                  " ,TRA.Fantasia[Transportadora] " +
                                                  " ,[Operação] = CASE CIT.Tipo_Operacao " +
                                                  "  WHEN 'T' THEN 'Devolução Total' " +
                                                  "  WHEN 'P'  THEN 'Devolução Parcial' " +
                                                  "  END " +
                                                  " ,[Retorno físico] = CASE CIT.Retorno_Fisico " +
                                                  "  WHEN '1' THEN 'Sim' " +
                                                  "  WHEN '0'  THEN 'Não' " +
                                                  "  END " +
                                                  " ,CIT.NF_Refatura[Nota de refatura] " +
                                                  " ,REPLACE(NF_origem,',','/')[Nota de Origem]" +
                                                  " ,CIT.Dat_Entrada [Dat. Registro]" +
                                                  " ,CIT.Observacao" +
                                                  " ,CIT.STATUS" +
                                                  " ,Observacao_Fin [Obs. Financeira] " +
                                                  "  FROM UNIDB.[dbo].CITOP CIT " +
                                                  "  INNER JOIN UNIDB.[dbo].MOTIV MOT ON MOT.Cod_Motivo = CIT.Cod_Motivo " +
                                                  "  INNER JOIN UNIDB.[dbo].SETOR STO ON STO.Cod_Setor = CIT.Cod_Setor " +
                                                  "  INNER JOIN DMD.[dbo].CLIEN CLI ON CLI.Codigo = CIT.Cod_Cliente " +
                                                  "  LEFT OUTER JOIN DMD.[dbo].TRANS TRA ON TRA.Codigo = CIT.Cod_Transportadora " +
                                                  "  WHERE CIT.Num_CI = @Num_CI " +
                                                  " ORDER BY CIT.NUM_CI DESC";

                            SqlParameter pNum_Ci = new SqlParameter("@Num_CI", SqlDbType.Int);
                            pNum_Ci.Value = Convert.ToInt32(txtNocorrencia.Text);
                            command.Parameters.Add(pNum_Ci);

                            adaptador = new SqlDataAdapter(command);
                            System.Data.DataTable tableDados = new System.Data.DataTable();
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
                            dgvDados.Columns[0].Width = 65;
                            dgvDados.Columns[2].Width = 230;
                            dgvDados.Columns[1].Width = 100;
                            dgvDados.Columns[3].Width = 280;
                            dgvDados.Columns[4].Width = 230;
                            dgvDados.Columns[6].Width = 55;
                            dgvDados.Columns[7].Width = 55;
                        }
                    }
                    return;
                }



                //Filtro por cliente e transportadora
                if (!txtCliente.Text.Trim().Equals(String.Empty) && !txtTransportadora.Text.Trim().Equals(String.Empty))
                {
                    //Status ON
                    if (chkStatus.Checked == true)
                    {
                        if (rdbConcluido.Checked == true)
                        {

                        }
                        else if (rdbPendente.Checked == true)
                        {

                        }
                        else if (rdbAguardandoFinanceiro.Checked == true)
                        {

                        }
                    }
                    //Status OFF
                    else
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = "  SELECT CIT.Num_CI [Ocorrência] " +
                                                      " ,MOT.Desc_Motivo[Motivo] " +
                                                      " ,STO.Desc_Setor[Setor] " +
                                                      " ,CLI.Razao_Social[Cliente] " +
                                                      " ,TRA.Fantasia[Transportadora] " +
                                                      " ,[Operação] = CASE CIT.Tipo_Operacao " +
                                                      "  WHEN 'T' THEN 'Devolução Total' " +
                                                      "  WHEN 'P'  THEN 'Devolução Parcial' " +
                                                      "  END " +
                                                      " ,[Retorno físico] = CASE CIT.Retorno_Fisico " +
                                                      "  WHEN '1' THEN 'Sim' " +
                                                      "  WHEN '0'  THEN 'Não' " +
                                                      "  END " +
                                                      " ,CIT.NF_Refatura[Nota de refatura] " +
                                                      " ,REPLACE(NF_origem,',','/')[Nota de Origem]" +
                                                  " ,CIT.Dat_Entrada [Dat. Registro]" +
                                                  " ,CIT.Observacao" +
                                                  " ,CIT.STATUS" +
                                                  " ,Observacao_Fin [Obs. Financeira] " +
                                                      "  FROM UNIDB.[dbo].CITOP CIT " +
                                                      "  INNER JOIN UNIDB.[dbo].MOTIV MOT ON MOT.Cod_Motivo = CIT.Cod_Motivo " +
                                                      "  INNER JOIN UNIDB.[dbo].SETOR STO ON STO.Cod_Setor = CIT.Cod_Setor " +
                                                      "  INNER JOIN DMD.[dbo].CLIEN CLI ON CLI.Codigo = CIT.Cod_Cliente " +
                                                      "  LEFT OUTER JOIN DMD.[dbo].TRANS TRA ON TRA.Codigo = CIT.Cod_Transportadora " +
                                                      "  WHERE TRA.Codigo = @Cod_Transportadora and CLI.Codigo = @Cod_Cliente" +
                                                  " ORDER BY CIT.NUM_CI DESC";

                                SqlParameter pCod_Transportadora = new SqlParameter("@Cod_Transportadora", SqlDbType.Int);
                                pCod_Transportadora.Value = Convert.ToInt32(txtCodTransportadora.Text);
                                command.Parameters.Add(pCod_Transportadora);

                                SqlParameter pCod_Cliente = new SqlParameter("@Cod_Cliente", SqlDbType.Int);
                                pCod_Cliente.Value = Convert.ToInt32(txtCodCliente.Text);
                                command.Parameters.Add(pCod_Cliente);

                                adaptador = new SqlDataAdapter(command);
                                System.Data.DataTable tableDados = new System.Data.DataTable();
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
                                dgvDados.Columns[0].Width = 65;
                                dgvDados.Columns[2].Width = 230;
                                dgvDados.Columns[1].Width = 100;
                                dgvDados.Columns[3].Width = 280;
                                dgvDados.Columns[4].Width = 230;
                                dgvDados.Columns[6].Width = 55;
                                dgvDados.Columns[7].Width = 55;
                            }
                        }
                    }
                }
                //Filtro por cliente
                else if (!txtCliente.Text.Trim().Equals(String.Empty))
                {
                    //Status ON
                    if (chkStatus.Checked == true)
                    {
                        if (rdbConcluido.Checked == true)
                        {

                        }
                        else if (rdbPendente.Checked == true)
                        {

                        }
                        else if (rdbAguardandoFinanceiro.Checked == true)
                        {

                        }
                    }
                    //Status OFF
                    else
                    {

                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = "  SELECT CIT.Num_CI [Ocorrência] " +
                                                      " ,MOT.Desc_Motivo[Motivo] " +
                                                      " ,STO.Desc_Setor[Setor] " +
                                                      " ,CLI.Razao_Social[Cliente] " +
                                                      " ,TRA.Fantasia[Transportadora] " +
                                                      " ,[Operação] = CASE CIT.Tipo_Operacao " +
                                                      "  WHEN 'T' THEN 'Devolução Total' " +
                                                      "  WHEN 'P'  THEN 'Devolução Parcial' " +
                                                      "  END " +
                                                      " ,[Retorno físico] = CASE CIT.Retorno_Fisico " +
                                                      "  WHEN '1' THEN 'Sim' " +
                                                      "  WHEN '0'  THEN 'Não' " +
                                                      "  END " +
                                                      " ,CIT.NF_Refatura[Nota de refatura] " +
                                                      " ,REPLACE(NF_origem,',','/')[Nota de Origem]" +
                                                  " ,CIT.Dat_Entrada [Dat. Registro]" +
                                                  " ,CIT.Observacao" +
                                                  " ,CIT.STATUS" +
                                                  " ,Observacao_Fin [Obs. Financeira] " +
                                                      "  FROM UNIDB.[dbo].CITOP CIT " +
                                                      "  INNER JOIN UNIDB.[dbo].MOTIV MOT ON MOT.Cod_Motivo = CIT.Cod_Motivo " +
                                                      "  INNER JOIN UNIDB.[dbo].SETOR STO ON STO.Cod_Setor = CIT.Cod_Setor " +
                                                      "  INNER JOIN DMD.[dbo].CLIEN CLI ON CLI.Codigo = CIT.Cod_Cliente " +
                                                      "  LEFT OUTER JOIN DMD.[dbo].TRANS TRA ON TRA.Codigo = CIT.Cod_Transportadora " +
                                                      "  WHERE CLI.Codigo = @Cod_Cliente" +
                                                  " ORDER BY CIT.NUM_CI DESC";

                                SqlParameter pCod_Cliente = new SqlParameter("@Cod_Cliente", SqlDbType.Int);
                                pCod_Cliente.Value = Convert.ToInt32(txtCodCliente.Text);
                                command.Parameters.Add(pCod_Cliente);

                                adaptador = new SqlDataAdapter(command);
                                System.Data.DataTable tableDados = new System.Data.DataTable();
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
                                dgvDados.Columns[0].Width = 65;
                                dgvDados.Columns[2].Width = 230;
                                dgvDados.Columns[1].Width = 100;
                                dgvDados.Columns[3].Width = 280;
                                dgvDados.Columns[4].Width = 230;
                                dgvDados.Columns[6].Width = 55;
                                dgvDados.Columns[7].Width = 55;
                            }
                        }
                    }
                }

                //Filtro por transportadora
                else if (!txtTransportadora.Text.Trim().Equals(String.Empty))
                {
                    //Status ON
                    if (chkStatus.Checked == true)
                    {
                        if (rdbConcluido.Checked == true)
                        {

                        }
                        else if (rdbPendente.Checked == true)
                        {

                        }
                        else if (rdbAguardandoFinanceiro.Checked == true)
                        {

                        }
                    }
                    //Status OFF
                    else
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = "  SELECT CIT.Num_CI [Ocorrência] " +
                                                      " ,MOT.Desc_Motivo[Motivo] " +
                                                      " ,STO.Desc_Setor[Setor] " +
                                                      " ,CLI.Razao_Social[Cliente] " +
                                                      " ,TRA.Fantasia[Transportadora] " +
                                                      " ,[Operação] = CASE CIT.Tipo_Operacao " +
                                                      "  WHEN 'T' THEN 'Devolução Total' " +
                                                      "  WHEN 'P'  THEN 'Devolução Parcial' " +
                                                      "  END " +
                                                      " ,[Retorno físico] = CASE CIT.Retorno_Fisico " +
                                                      "  WHEN '1' THEN 'Sim' " +
                                                      "  WHEN '0'  THEN 'Não' " +
                                                      "  END " +
                                                      " ,CIT.NF_Refatura[Nota de refatura] " +
                                                      " ,REPLACE(NF_origem,',','/')[Nota de Origem]" +
                                                  " ,CIT.Dat_Entrada [Dat. Registro]" +
                                                  " ,CIT.Observacao" +
                                                  " ,CIT.STATUS" +
                                                  " ,Observacao_Fin [Obs. Financeira] " +
                                                      "  FROM UNIDB.[dbo].CITOP CIT " +
                                                      "  INNER JOIN UNIDB.[dbo].MOTIV MOT ON MOT.Cod_Motivo = CIT.Cod_Motivo " +
                                                      "  INNER JOIN UNIDB.[dbo].SETOR STO ON STO.Cod_Setor = CIT.Cod_Setor " +
                                                      "  INNER JOIN DMD.[dbo].CLIEN CLI ON CLI.Codigo = CIT.Cod_Cliente " +
                                                      "  LEFT OUTER JOIN DMD.[dbo].TRANS TRA ON TRA.Codigo = CIT.Cod_Transportadora " +
                                                      "  WHERE TRA.Codigo = @Cod_Transportadora" +
                                                  " ORDER BY CIT.NUM_CI DESC";

                                SqlParameter pCod_Transportadora = new SqlParameter("@Cod_Transportadora", SqlDbType.Int);
                                pCod_Transportadora.Value = Convert.ToInt32(txtCodTransportadora.Text);
                                command.Parameters.Add(pCod_Transportadora);


                                adaptador = new SqlDataAdapter(command);
                                System.Data.DataTable tableDados = new System.Data.DataTable();
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
                                dgvDados.Columns[0].Width = 65;
                                dgvDados.Columns[2].Width = 230;
                                dgvDados.Columns[1].Width = 100;
                                dgvDados.Columns[3].Width = 280;
                                dgvDados.Columns[4].Width = 230;
                                dgvDados.Columns[6].Width = 55;
                                dgvDados.Columns[7].Width = 55;
                            }
                        }
                    }
                }
                //Sem filtro
                else
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "  SELECT CIT.Num_CI [Ocorrência] " +
                                                  " ,MOT.Desc_Motivo[Motivo] " +
                                                  " ,STO.Desc_Setor[Setor] " +
                                                  " ,CLI.Razao_Social[Cliente] " +
                                                  " ,TRA.Fantasia[Transportadora] " +
                                                  " ,[Operação] = CASE CIT.Tipo_Operacao " +
                                                  "  WHEN 'T' THEN 'Devolução Total' " +
                                                  "  WHEN 'P'  THEN 'Devolução Parcial' " +
                                                  "  END " +
                                                  " ,[Retorno físico] = CASE CIT.Retorno_Fisico " +
                                                  "  WHEN '1' THEN 'Sim' " +
                                                  "  WHEN '0'  THEN 'Não' " +
                                                  "  END " +
                                                  " ,CIT.NF_Refatura[Nota de refatura] " +
                                                  " ,REPLACE(NF_origem,',','/')[Nota de Origem]" +
                                                  " ,CIT.Dat_Entrada [Dat. Registro]" +
                                                  " ,CIT.Observacao" +
                                                  " ,CIT.STATUS" +
                                                  " ,Observacao_Fin [Obs. Financeira] " +
                                                  "  FROM UNIDB.[dbo].CITOP CIT " +
                                                  "  INNER JOIN UNIDB.[dbo].MOTIV MOT ON MOT.Cod_Motivo = CIT.Cod_Motivo " +
                                                  "  INNER JOIN UNIDB.[dbo].SETOR STO ON STO.Cod_Setor = CIT.Cod_Setor " +
                                                  "  INNER JOIN DMD.[dbo].CLIEN CLI ON CLI.Codigo = CIT.Cod_Cliente " +
                                                  "  LEFT OUTER JOIN DMD.[dbo].TRANS TRA ON TRA.Codigo = CIT.Cod_Transportadora " +
                                                  " ORDER BY CIT.NUM_CI DESC";



                            adaptador = new SqlDataAdapter(command);
                            System.Data.DataTable tableDados = new System.Data.DataTable();
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
                            dgvDados.Columns[0].Width = 65;
                            dgvDados.Columns[2].Width = 230;
                            dgvDados.Columns[1].Width = 100;
                            dgvDados.Columns[3].Width = 280;
                            dgvDados.Columns[4].Width = 230;
                            dgvDados.Columns[6].Width = 55;
                            dgvDados.Columns[7].Width = 55;
                        }
                    }
                }
            
        }
        private void formatarDados(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[11].Value.ToString().Equals("P"))
                {
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                }
                else if (row.Cells[11].Value.ToString().Equals("A"))
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                }
            }
        }

        //Botão pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            filtrarDados();
            formatarDados(dgvDados);
            
            this.Cursor = Cursors.Default;
            
        }
       

        //Botão limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Limpar Cliente
            txtCodCliente.Text = String.Empty;
            txtCliente.Text = String.Empty;

            //Limpar Transportadora
            txtCodTransportadora.Text = String.Empty;
            txtTransportadora.Text = String.Empty;

            //Limpar Notas
            txtNFdevol.Text = String.Empty;
            txtNFrefat.Text = String.Empty;
            txtNocorrencia.Text = String.Empty;
            txtNFOrigem.Text = String.Empty;
            //Limpar status
            chkStatus.Checked = false;
            rdbAguardandoFinanceiro.Checked = false;
            rdbConcluido.Checked = false;
            rdbPendente.Checked = false;

            

        }
       

        //Group box status
        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {

            if (chkStatus.Checked == true)
            {
                rdbPendente.Enabled = true;
                rdbAguardandoFinanceiro.Enabled = true;
                rdbConcluido.Enabled = true;
            }
            else
            {
                rdbPendente.Enabled = false;
                rdbAguardandoFinanceiro.Enabled = false;
                rdbConcluido.Enabled = false;
            }
        }
        //Cliente
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
                            command.CommandText = "SELECT razao_social FROM clien WHERE CODIGO = " + Convert.ToInt32(txtCodCliente.Text);

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
            //Apontado para o CI da aba logísitica
            frmCriarCi_EscolherCliente form = new frmCriarCi_EscolherCliente();            
            form.ShowDialog();
            if (form.cod_cliente != 0)
                txtCodCliente.Text = Convert.ToString(form.cod_cliente);
        }

        //Transportadora
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
        private void btnPreencherTransportadora_Click(object sender, EventArgs e)
        {
            //Apontado para o CI da aba logísitica
            frmCriarCi_EscolherTransportadora form = new frmCriarCi_EscolherTransportadora();            
            form.ShowDialog();
            if (form.cod_transportadora != 0)
                txtCodTransportadora.Text = Convert.ToString(form.cod_transportadora);
        }

        //Função para digitar somente números
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        //Função para pesquisar com o Enter
        private void pesquisarComEnter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPesquisar_Click(btnPesquisar, new EventArgs());
            }
        }

        private void frmConferenciaDeCi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                frmFinanceiro form = new frmFinanceiro();                
                form.Show();
                this.Close();
                
            }
        }

        private void DgvDados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {            
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (row.Cells[11].Value.ToString().Equals("P"))
                {
                    row.DefaultCellStyle.ForeColor = Color.Gray;
                }
                else if (row.Cells[11].Value.ToString().Equals("A"))
                {
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.Green;
                }
            }
        }
        //Mostrar notas de devolução
        private void DgvDados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {           
                if (sCI != dgvDados.CurrentRow.Cells[0].Value.ToString())
                {
                    lsbNF_Devolucao.Items.Clear();
                    sCI = (dgvDados.CurrentRow.Cells[0].Value.ToString());


                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT NF_Devolucao FROM UNIDB.dbo.CIDEV WHERE Num_CI = " + sCI;
                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["NF_Devolucao"] != null)
                                {
                                    lsbNF_Devolucao.Items.Add(reader["NF_Devolucao"].ToString());
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

        private void lblCliente_Click(object sender, EventArgs e)
        {

        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {

        }



















        //Alterar status da CI
        private void dgvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            DataGridView.HitTestInfo hit = dgvDados.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                return;
            }

            frmAlterarStatusDaCi form = new frmAlterarStatusDaCi();
            form.Cod_CI = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value);            
            form.ShowDialog();
            btnPesquisar_Click(dgvDados, new EventArgs());

        }



    }
}
