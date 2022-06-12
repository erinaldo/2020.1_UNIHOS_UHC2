using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Canhotos.Controle_Canhotos
{
    public partial class frmControleCanhotos : Form
    {
        public frmControleCanhotos()
        {
            InitializeComponent();
        }



        //Login
        public String user_Login;
       
      
            //SQL
            private SqlCommand command = new SqlCommand();


            private SqlDataReader reader;

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

            

        //Instancia de listas
        List<String> lExportacao = new List<String>();
        //public int Unidade_Servidor;

        //Load do form
        private void FrmControleCanhotos_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            Configuracoes_Iniciais();
        }

        //Configurações iniciais
        private void Configuracoes_Iniciais()
            {
                dtpDtInicial.Text = DateTime.Today.AddDays(-15).ToString();
                dtpDtFinal.Text = DateTime.Today.ToString();
                dtpDataEntrega.Text = DateTime.Today.ToString();
                Filtrar_Dados();
                chkDataEntrega_CheckedChanged(chkDataEntrega,new EventArgs());
            chkHelp_CheckedChanged(chkHelp, new EventArgs());
            }

        //Filtrar_Dados
        private void Filtrar_Dados()
        {
            
                this.Cursor = Cursors.WaitCursor;
                clbNotas.Items.Clear();
                if (!txtNF.Text.Trim().Equals(String.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();
                            command = connectDMD.CreateCommand();
                            command.CommandText = " SELECT MAX(NFS.Num_Nota) as [Num_Nota] " +
                                                     " FROM DMD.dbo.NFSCB NFS " +
                                                     " INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.NUM_NOTA = NFS.NUM_NOTA " +
                                                     " LEFT OUTER JOIN DMD.dbo.RMNIT RIT ON RIT.Num_Nota = NFS.Num_Nota " +
                                                     " LEFT OUTER JOIN DMD.dbo.RMNCB RCB ON RCB.Numero = RIT.Num_Romaneio " +
                                                     " WHERE NFS.STATUS = 'F' AND CAN.Dat_Canhoto IS NULL AND NFS.Dat_Emissao > '2019-01-01' " +
                                                     " and NFS.num_nota = " + txtNF.Text +
                                                     " GROUP BY CAN.NUM_NOTA " +
                                                     " HAVING MAX(NFS.Num_Nota) is not null " +
                                                     " UNION " +
                                                     " SELECT MAX(NFS.Numero) as [Num_Nota] " +
                                                     " FROM DMD.dbo.NFECB NFS " +
                                                     " INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.NUM_NOTA = NFS.Numero " +
                                                     " LEFT OUTER JOIN DMD.dbo.RMNIT RIT ON RIT.Num_Nota = NFS.Numero " +
                                                     " LEFT OUTER JOIN DMD.dbo.RMNCB RCB ON RCB.Numero = RIT.Num_Romaneio " +
                                                     " WHERE NFS.STATUS = 'F' AND CAN.Dat_Canhoto IS NULL AND NFS.Dat_Emissao > '2019-01-01' " +
                                                     " and NFS.numero = " + txtNF.Text +
                                                     " GROUP BY CAN.Num_Nota " +
                                                     " HAVING MAX(NFS.Numero) is not null " +
                                                     " ORDER BY NUM_NOTA DESC";

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Num_Nota"] != null)
                                {
                                    clbNotas.Items.Add(reader["Num_nota"].ToString());
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
                    this.Cursor = Cursors.Default;
                    return;
                }

                if (!txtCliente.Text.Trim().Equals(String.Empty) == false && !txtCodTransportadora.Text.Trim().Equals(String.Empty) == false)
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();
                            command = connectDMD.CreateCommand();
                            command.CommandText = " SELECT MAX(NSCB.Num_Nota)[NUM_NOTA] " +
                                                     " FROM DMD.dbo.NFSCB NSCB " +
                                                     " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                     " INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NSCB.Num_Nota " +
                                                     " INNER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NSCB.Cod_Transportadora " +
                                                     " LEFT OUTER JOIN DMD.dbo.RMNIT RIT ON RIT.Num_Nota = NSCB.Num_Nota " +
                                                     " LEFT OUTER JOIN DMD.dbo.RMNCB RCB ON RCB.Numero = RIT.Num_Romaneio " +
                                                     " WHERE NSCB.Status = 'F' " +
                                                     " AND CAN.Dat_Canhoto IS NULL " +
                                                     " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL " +
                                                     " AND NSCB.Dat_Emissao > '2019-01-01' " +
                                                     " GROUP BY NSCB.Num_Nota " +

                                                     " UNION " +


                                                     " SELECT MAX(NSCB.Numero) [NUM_NOTA] " +
                                                     " FROM DMD.dbo.NFECB NSCB " +
                                                     " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_EmiCliente " +
                                                     " INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NSCB.Numero " +
                                                     " INNER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NSCB.Cod_Transp " +
                                                     " LEFT OUTER JOIN DMD.dbo.RMNIT RIT ON RIT.Num_Nota = NSCB.Numero " +
                                                     " LEFT OUTER JOIN DMD.dbo.RMNCB RCB ON RCB.Numero = RIT.Num_Romaneio " +
                                                     " WHERE NSCB.Status = 'F' " +
                                                     " AND CAN.Dat_Canhoto IS NULL " +
                                                     " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL " +
                                                     " AND NSCB.Dat_Emissao > '2019-01-01'    " +
                                                     " GROUP BY NSCB.Numero " +

                                                     " ORDER BY NUM_NOTA DESC  ";
                            command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                            command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));
                            reader = command.ExecuteReader();

                            //Exibe no checkedListBox a informação num_nota
                            while (reader.Read())
                            {
                                if (reader["NUM_NOTA"] != null)
                                {
                                    clbNotas.Items.Add(reader["NUM_NOTA"].ToString());
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

                else if (!txtCliente.Text.Trim().Equals(String.Empty) == true && !txtCodTransportadora.Text.Trim().Equals(String.Empty) == false)
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();
                            command = connectDMD.CreateCommand();
                            command.CommandText = " SELECT MAX(NSCB.Num_Nota) [NUM_NOTA] " +
                                                   " FROM DMD.dbo.NFSCB NSCB " +
                                                   " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                   " INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NSCB.Num_Nota " +
                                                   " INNER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NSCB.Cod_Transportadora " +
                                                   " LEFT OUTER JOIN DMD.dbo.RMNIT RIT ON RIT.Num_Nota = NSCB.Num_Nota " +
                                                   " LEFT OUTER JOIN DMD.dbo.RMNCB RCB ON RCB.Numero = RIT.Num_Romaneio " +
                                                   " WHERE NSCB.Status in ('F') " +
                                                   " AND CAN.Dat_Canhoto IS NULL " +
                                                   " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL " +
                                                   " AND C.Razao_Social LIKE ('%' + @CLIENTE + '%')  " +
                                                   " AND NSCB.Dat_Emissao > '2019-01-01' " +
                                                   " GROUP BY NSCB.Num_Nota " +
                                                   " UNION " +
                                                   " SELECT MAX(NSCB.Numero) [NUM_NOTA] " +
                                                   " FROM DMD.dbo.NFECB NSCB " +
                                                   " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_EmiCliente " +
                                                   " INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NSCB.Numero " +
                                                   " INNER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NSCB.Cod_Transp " +
                                                   " LEFT OUTER JOIN DMD.dbo.RMNIT RIT ON RIT.Num_Nota = NSCB.Numero " +
                                                   " LEFT OUTER JOIN DMD.dbo.RMNCB RCB ON RCB.Numero = RIT.Num_Romaneio " +
                                                   " WHERE NSCB.Status in ('F') " +
                                                   " AND CAN.Dat_Canhoto IS NULL " +
                                                   " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL " +
                                                   " AND C.Razao_Social LIKE ('%' + @CLIENTE + '%') " +
                                                   " AND NSCB.Dat_Emissao > '2019-01-01'  " +
                                                   " GROUP BY NSCB.Numero " +
                                                   " ORDER BY Num_Nota DESC ";
                            command.Parameters.AddWithValue("CLIENTE", (txtCliente.Text.Trim()));
                            command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                            command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));
                            reader = command.ExecuteReader();

                            //Exibe no checkedListBox a informação num_nota
                            while (reader.Read())
                            {
                                if (reader["NUM_NOTA"] != null)
                                {
                                    clbNotas.Items.Add(reader["NUM_NOTA"].ToString());
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

                else if (!txtCliente.Text.Trim().Equals(String.Empty) == false && !txtCodTransportadora.Text.Trim().Equals(String.Empty) == true)
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();
                            command = connectDMD.CreateCommand();
                            command.CommandText = " SELECT MAX(NSCB.Num_Nota)[NUM_NOTA] " +
                                                   " FROM DMD.dbo.NFSCB NSCB " +
                                                   " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                   " INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NSCB.Num_Nota " +
                                                   " INNER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NSCB.Cod_Transportadora " +
                                                   " LEFT OUTER JOIN DMD.dbo.RMNIT RIT ON RIT.Num_Nota = NSCB.Num_Nota " +
                                                   " LEFT OUTER JOIN DMD.dbo.RMNCB RCB ON RCB.Numero = RIT.Num_Romaneio " +
                                                   " WHERE NSCB.Status in ('F') " +
                                                   " AND CAN.Dat_Canhoto IS NULL " +
                                                   " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL " +
                                                   " AND tra.codigo = " + txtCodTransportadora.Text +
                                                   " AND NSCB.Dat_Emissao > '2019-01-01' " +
                                                   " GROUP BY NSCB.Num_Nota " +
                                                   " UNION" +
                                                   " SELECT MAX(NSCB.Numero)[NUM_NOTA] " +
                                                   " FROM DMD.dbo.NFECB NSCB " +
                                                   " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_EmiCliente " +
                                                   " INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NSCB.Numero " +
                                                   " INNER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NSCB.Cod_Transp " +
                                                   " LEFT OUTER JOIN DMD.dbo.RMNIT RIT ON RIT.Num_Nota = NSCB.Numero " +
                                                   " LEFT OUTER JOIN DMD.dbo.RMNCB RCB ON RCB.Numero = RIT.Num_Romaneio " +
                                                   " WHERE NSCB.Status in ('F') " +
                                                   " AND CAN.Dat_Canhoto IS NULL " +
                                                   " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL " +
                                                   " AND tra.codigo = " + txtCodTransportadora.Text +
                                                   " AND NSCB.Dat_Emissao > '2019-01-01' " +
                                                   " GROUP BY NSCB.Numero " +
                                                   " ORDER BY NUM_NOTA DESC";

                            command.Parameters.AddWithValue("TRANSPORTADORA", (txtTransportadora.Text.Trim()));
                            command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                            command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));
                            reader = command.ExecuteReader();

                            //Exibe no checkedListBox a informação num_nota
                            while (reader.Read())
                            {
                                if (reader["NUM_NOTA"] != null)
                                {
                                    clbNotas.Items.Add(reader["NUM_NOTA"].ToString());
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

                else if (!txtCliente.Text.Trim().Equals(String.Empty) == true && !txtCodTransportadora.Text.Trim().Equals(String.Empty) == true)
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();
                            command = connectDMD.CreateCommand();
                            command.CommandText = " SELECT MAX(NSCB.Num_Nota)[NUM_NOTA] " +
                                                   " FROM DMD.dbo.NFSCB NSCB " +
                                                   " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                   " INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NSCB.Num_Nota " +
                                                   " INNER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NSCB.Cod_Transportadora " +
                                                   " LEFT OUTER JOIN DMD.dbo.RMNIT RIT ON RIT.Num_Nota = NSCB.Num_Nota " +
                                                   " LEFT OUTER JOIN DMD.dbo.RMNCB RCB ON RCB.Numero = RIT.Num_Romaneio " +
                                                   " WHERE NSCB.Status in ('F') " +
                                                   " AND CAN.Dat_Canhoto IS NULL " +
                                                   " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL " +
                                                   " AND C.Razao_Social LIKE ('%' + @CLIENTE + '%')   " +
                                                   " AND tra.codigo = " + txtCodTransportadora.Text +
                                                   " AND NSCB.Dat_Emissao > '2019-01-01' " +
                                                   " GROUP BY NSCB.Num_Nota " +

                                                   " UNION " +

                                                   " SELECT MAX(NSCB.Numero) [NUM_NOTA] " +
                                                   " FROM DMD.dbo.NFECB NSCB " +
                                                   " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_EmiCliente " +
                                                   " INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.Num_Nota = NSCB.Numero " +
                                                   " INNER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NSCB.Cod_Transp " +
                                                   " LEFT OUTER JOIN DMD.dbo.RMNIT RIT ON RIT.Num_Nota = NSCB.Numero " +
                                                   " LEFT OUTER JOIN DMD.dbo.RMNCB RCB ON RCB.Numero = RIT.Num_Romaneio " +
                                                   " WHERE NSCB.Status in ('F') " +
                                                   " AND CAN.Dat_Canhoto IS NULL " +
                                                   " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL  " +
                                                   " AND C.Razao_Social LIKE ('%' + @CLIENTE + '%') " +
                                                   " AND tra.codigo = " + txtCodTransportadora.Text +
                                                   " AND NSCB.Dat_Emissao > '2019-01-01'  " +
                                                   " GROUP BY NSCB.Numero " +
                                                   " ORDER BY NUM_NOTA DESC ";
                            command.Parameters.AddWithValue("CLIENTE", (txtCliente.Text.Trim()));
                            command.Parameters.AddWithValue("TRANSPORTADORA", (txtTransportadora.Text.Trim()));
                            command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                            command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));
                            reader = command.ExecuteReader();

                            //Exibe no checkedListBox a informação num_nota
                            while (reader.Read())
                            {
                                if (reader["NUM_NOTA"] != null)
                                {
                                    clbNotas.Items.Add(reader["NUM_NOTA"].ToString());
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
                this.Cursor = Cursors.Default;            
        }


 


        //Inserir os canhotos no banco de dados
        private void Marcar_Canhotos()
            {

          
                if (lExportacao.Count == 0)
                {
                    mMessage = "Selecione alguma nota para continuar";
                    mTittle = "Seleção de canhotos";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Information;
                    System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    return;
                }
                mMessage = "Há " + lExportacao.Count + " nota(s) selecionada(s), deseja salvar a marcação?";
                mTittle = "Marcar canhoto";
                mButton = MessageBoxButtons.YesNo;
                mIcon = MessageBoxIcon.Information;
                DialogResult option = System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);


                //Define as operação padrão do set
                String linhaComando = " SET Dat_Canhoto = Getdate(), Usuario = '" + user_Login + "'";

                if (chkDataEntrega.Checked)
                {
                    String dia, mes;
                    String sData_Entrega = null;
                    //Adaptação para interpretar dia e mês da forma correta por conta do padrão americano de datas
                    //Essa função pode e deve ser revisada futuramente, estamos focando agilidade
                    if (Convert.ToInt32(dtpDataEntrega.Value.Day.ToString()) < 10)
                        dia = "0" + dtpDataEntrega.Value.Day.ToString();
                    else
                        dia = dtpDataEntrega.Value.Day.ToString();

                    if (Convert.ToInt32(dtpDataEntrega.Value.Month.ToString()) < 10)
                        mes = "0" + dtpDataEntrega.Value.Month.ToString();
                    else
                        mes =dtpDataEntrega.Value.Month.ToString();


                    sData_Entrega = dtpDataEntrega.Value.Year.ToString() + "-" + mes + "-" + dia;
                    linhaComando = " SET Dat_Canhoto = Getdate(), Usuario = '" + user_Login + "',Data_Chegada = '" + sData_Entrega + "'";

                }
                                
                if (option == DialogResult.Yes)
                {
                    for (int x = 0; x < lExportacao.Count; x++)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();
                                command = connectDMD.CreateCommand();
                                command.CommandText =  " UPDATE UNIDB.dbo.NSCAN"
                                                      +linhaComando
                                                      +" WHERE NUM_NOTA =" + lExportacao[x].ToString();

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
                    mMessage = "Registro efetuado com sucesso!";
                    mTittle = "Registro de canhoto";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Information;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    lExportacao.Clear();
                    clbNotas.Items.Clear();
                    Configuracoes_Iniciais();
                }
                else
                {
                    lExportacao.Clear();
                    clbNotas.Items.Clear();
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

        //Clientes
        private void btnPreencherCliente_Click(object sender, EventArgs e)
            {
            frmCriarCi_EscolherCliente form = new frmCriarCi_EscolherCliente();
            
            form.ShowDialog();
            if (form.cod_cliente != 0)
                txtCodCliente.Text = Convert.ToString(form.cod_cliente);
        }

        //Transportadoras
        private void BtnProcurarTransportadora_Click(object sender, EventArgs e)
            {
                frmCriarCi_EscolherTransportadora form = new frmCriarCi_EscolherTransportadora();
                
                form.ShowDialog();
                if (form.cod_transportadora != 0)
                    txtCodTransportadora.Text = Convert.ToString(form.cod_transportadora);
            }
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
                            erro_DeAcesso(SQLe);
                        }
                        finally
                        {
                            connectDMD.Close();
                        }


                    }
                }                        
        }


        //Form
        //Sair com esc
        private void FrmControleDeCanhotos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }
       
        //Botão para exportar
        private void BtnFecharExportar_Click(object sender, EventArgs e)
        {
            if (btnFecharExportar.Text == "Fechar")
            {
                this.Close();
            }else
            {
                Marcar_Canhotos();
                Filtrar_Dados();
            }
        }

        //checked list box notas
        private void ClbNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
                lblNota.Text = clbNotas.SelectedItem.ToString();
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = "SELECT  " +
                                                  " MAX(NFS.Num_Nota) as [Num_Nota] " +
                                                  " ,NFS.Dat_emissao " +
                                                  " ,RCB.Transacao as [Dt.Transação] " +
                                                  " ,NFS.Status " +
                                                  " ,CLI.Codigo as [Cod_Cliente] " +
                                                 " ,CLI.Razao_Social as [Desc_Clien] " +
                                                  " ,CLI.Cod_Estado as [UF] " +
                                                  " ,NFS.COD_CFO1 as [CFOP] " +
                                                  " ,CFO.Descricao as [Desc_CFOP] " +
                                                  " ,TRA.Fantasia as [Transp] " +
                                                  " ,TRA.Codigo as [Cod_Transp]  " +
                                                  " ,Rcb.Data_Coleta as [Dat_Coleta] " +
                                                  " ,RCB.Transacao[Dat_Transacao] " +
                                                  " ,CAN.Dat_Canhoto " +
                                                  " FROM DMD.dbo.NFSCB NFS " +
                                                  " INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.NUM_NOTA = NFS.NUM_NOTA " +
                                                  " LEFT OUTER JOIN DMD.dbo.RMNIT RIT ON RIT.Num_Nota = NFS.Num_Nota " +
                                                  " LEFT OUTER JOIN DMD.dbo.RMNCB RCB ON RCB.Numero = RIT.Num_Romaneio " +
                                                  " LEFT OUTER JOIN DMD.dbo.CLIEN CLI ON CLI.CODIGO = NFS.Cod_Cliente " +
                                                  " LEFT OUTER JOIN DMD.dbo.TBCFO CFO ON CFO.CODIGO = NFS.Cod_Cfo1 " +
                                                  " LEFT OUTER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NFS.Cod_Transportadora " +
                                                  " LEFT OUTER JOIN DMD.dbo.CTREC REC ON REC.Num_NfOrigem = NFS.Num_Nota " +
                                                  " LEFT OUTER JOIN DMD.dbo.BXREC ON BXREC.Cod_Documento = REC.Cod_Documento " +
                                                  " WHERE NFS.Dat_Emissao > '2019-01-01' and NFS.Status in ('F') and NFS.Num_Nota = @NF " +
                                                  " GROUP BY NFS.Num_Nota " +
                                                    " ,RCB.Transacao " +
                                                    " ,NFS.Status " +
                                                    " ,CLI.Codigo " +
                                                    " ,CLI.Cod_Estado " +
                                                    " ,NFS.COD_CFO1 " +
                                                    " ,TRA.Fantasia " +
                                                    " ,RCB.Data_Coleta " +
                                                    " ,CLI.RAZAO_SOCIAL " +
                                                    " ,CFO.DESCRICAO " +
                                                    " ,NFS.Dat_Emissao " +
                                                    " ,TRA.CODIGO " +
                                                    " ,CAN.Dat_Canhoto " +
                                                 " union " +

                                                 " SELECT " +
                                                   " MAX(NFS.Numero) as [Num_Nota] " +
                                                " ,NFS.Dat_emissao " +
                                                  " ,RCB.Transacao as [Dt.Transação] " +
                                                  " ,NFS.Status " +
                                                  " ,CLI.Codigo as [Cod_Cliente] " +
                                                  " ,CLI.Razao_Social as [Desc_Clien] " +
                                                  " ,CLI.Cod_Estado as [UF] " +
                                                  " ,NFS.COD_CFO as [CFOP] " +
                                                  " ,CFO.Descricao as [Desc_CFOP] " +
                                                  " , TRA.Fantasia as [Transp] " +
                                                  " ,TRA.Codigo as [Cod_Transp] " +
                                                  " ,Rcb.Data_Coleta as [Dat_Coleta] " +
                                                  " ,RCB.Transacao[Dat_Transacao] " +
                                                  " ,CAN.Dat_Canhoto " +
                                                  " FROM DMD.dbo.NFECB NFS " +
                                                  " INNER JOIN UNIDB.dbo.NSCAN CAN ON CAN.NUM_NOTA = NFS.Numero " +
                                                  " LEFT OUTER JOIN DMD.dbo.RMNIT RIT ON RIT.Num_Nota = NFS.Numero " +
                                                  " LEFT OUTER JOIN DMD.dbo.RMNCB RCB ON RCB.Numero = RIT.Num_Romaneio " +
                                                  " LEFT OUTER JOIN DMD.dbo.CLIEN CLI ON CLI.CODIGO = NFS.Cod_EmiCliente " +
                                                  " LEFT OUTER JOIN DMD.dbo.TBCFO CFO ON CFO.CODIGO = NFS.Cod_Cfo " +
                                                  " LEFT OUTER JOIN DMD.dbo.TRANS TRA ON TRA.Codigo = NFS.Cod_Transp " +
                                                  " LEFT OUTER JOIN DMD.dbo.CTREC REC ON REC.Num_NfOrigem = NFS.Numero " +
                                                  " LEFT OUTER JOIN DMD.dbo.BXREC ON BXREC.Cod_Documento = REC.Cod_Documento " +
                                                  " WHERE NFS.Dat_Emissao > '2019-01-01' and NFS.Status in ('F') and NFS.Numero = @NF " +
                                                  " GROUP BY NFS.Numero " +
                                                    " ,RCB.Transacao " +
                                                    " ,NFS.Status " +
                                                    " ,CLI.Codigo " +
                                                    " ,CLI.Cod_Estado " +
                                                    " ,NFS.COD_CFO " +
                                                    " ,TRA.Fantasia " +
                                                    " ,RCB.Data_Coleta " +
                                                    " ,CLI.RAZAO_SOCIAL " +
                                                    " ,CFO.DESCRICAO " +
                                                    " ,NFS.Dat_Emissao " +
                                                    " ,TRA.CODIGO " +
                                                  " ,CAN.Dat_Canhoto ";


                        command.Parameters.AddWithValue("NF", Convert.ToInt32(clbNotas.SelectedItem.ToString().Trim()));
                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader["Dat_Emissao"] != null)
                            {
                                txtDat_Emissao.Text = (reader["Dat_Emissao"].ToString());
                                txtStatus.Text = (reader["Status"].ToString());
                                txtUF.Text = (reader["UF"].ToString());
                                txtCFOP.Text = (reader["CFOP"].ToString());
                                txtCFOP.Text = (reader["Desc_CFOP"].ToString());
                                txtCodClienteInfo.Text = (reader["Cod_Cliente"].ToString());
                                txtClienteInfo.Text = (reader["Desc_Clien"].ToString());
                                txtCodTransp.Text = (reader["Cod_Transp"].ToString());
                                txtTransp.Text = (reader["Transp"].ToString());
                                txtDatColeta.Text = (reader["Dat_Coleta"].ToString());
                                txtDatTransacao.Text = (reader["Dat_Transacao"].ToString());
                                txtRegistroCanhoto.Text = (reader["Dat_Canhoto"].ToString());

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

        private void ClbNotas_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                lExportacao.Add(clbNotas.SelectedItem.ToString());
                if (lExportacao.Count > 0)
                {
                    btnFecharExportar.BackColor = Color.ForestGreen;
                    btnFecharExportar.Text = "Confirmar";
                }
            }
            else
            {
                lExportacao.Remove(clbNotas.SelectedItem.ToString());
                if (lExportacao.Count == 0)
                {
                    btnFecharExportar.BackColor = Color.Gray;
                    btnFecharExportar.Text = "Fechar";
                }

            }
        }

        private void ClbNotas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                if (lExportacao.Count > 0)
                {
                    BtnFecharExportar_Click(clbNotas, new EventArgs());
                }
            }
        }

        //Botão pesquisar
        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            Filtrar_Dados();
        }

        //Psqusiar com enter
        private void txt_PesquisaComEnter_KeyDown (object sender , KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            BtnPesquisar_Click(btnPesquisar, new EventArgs());
        }

        private void chkDataEntrega_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDataEntrega.Checked)
                dtpDataEntrega.Enabled = true;
            else
                dtpDataEntrega.Enabled = false;

            
        }

        private void chkHelp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHelp.Checked)
            {
                lblAjudaDataDeEntrega.Visible = true;
                lblAjudaFiltros.Visible = true;
                lblAjudaInformacoes.Visible = true;


            }
            else
            {
                lblAjudaDataDeEntrega.Visible = false;
                lblAjudaFiltros.Visible       = false;
                lblAjudaInformacoes.Visible   = false;
            }

        }

        //Digitar somente números        
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
