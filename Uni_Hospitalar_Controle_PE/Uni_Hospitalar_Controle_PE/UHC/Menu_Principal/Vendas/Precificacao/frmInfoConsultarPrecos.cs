using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Conferencia;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Precificacao
{
    public partial class frmInfoConsultarPrecos : Form
    {
        public frmInfoConsultarPrecos()
        {
            InitializeComponent();
        }
        //SQL
        private SqlCommand command = new SqlCommand();        
        private SqlDataReader reader;
        private SqlDataAdapter adaptador;

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



        //Instancia
        public String pubsCod_Produto;
        

        //COnfigurações iniciais
        private void Configuracoes_Iniciais()
        {

                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT " +
                                              " REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(NSIT.Prc_Unitario AS money), 1), ',', '_'), '.', ','), '_', '.')[Prc.Venda] " +
                                              " ,[Dat.Venda] = CONVERT(DATE, NSCB.DAT_EMISSAO)" +
                                              " ,NSCB.COD_CLIENTE [Cód. Cliente] " +
                                              " ,C.Razao_Social [Cliente]" +
                                              " FROM produ p " +
                                              " LEFT OUTER JOIN NFSIT NSIT ON NSIT.Cod_Produto = p.codigo " +
                                              " LEFT OUTER JOIN NFSCB NSCB ON NSCB.Num_Nota = NSIT.Num_Nota " +
                                              " LEFT OUTER JOIN CLIEN c ON C.CODIGO = NSCB.Cod_Cliente " +
                                              " WHERE P.Codigo = " + pubsCod_Produto +
                                              " ORDER BY Dat_Emissao DESC";

                        adaptador = new SqlDataAdapter(command);
                        System.Data.DataTable tableDados = new System.Data.DataTable();
                        adaptador.Fill(tableDados);
                        dgvHistorico.DataSource = tableDados;

                    }
                    catch (SqlException SQLe)
                    {
                        erro_DeAcesso(SQLe);
                    }
                    finally
                    {
                        connectDMD.Close();
                        dgvHistorico.Columns[0].Width = 80;
                        dgvHistorico.Columns[1].Width = 80;
                        dgvHistorico.Columns[2].Width = 80;
                        dgvHistorico.Columns[3].Width = 250;
                    }
                }
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT Cod_Lote[Lote],Dat_Vencim [Vencimento],Qtd_Saldo[Disponível] FROM PRLOT " +
                                              " WHERE Qtd_Saldo > 0 AND Cod_Produt  = " + pubsCod_Produto +
                                              " ORDER BY Dat_Vencim asc";

                        adaptador = new SqlDataAdapter(command);
                        System.Data.DataTable tableDados = new System.Data.DataTable();
                        adaptador.Fill(tableDados);
                        dgvLotes.DataSource = tableDados;

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
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = " select Prc_UltEnt from produ" +
                                              " WHERE Codigo =  " + pubsCod_Produto;

                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["prc_ultent"] != null)
                            {
                                txtUltimaEntrada.Text = Convert.ToDouble(reader["prc_ultent"]).ToString("C");
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


        private void BtnPreencherCliente_Click(object sender, EventArgs e)
        {
            frmCriarCi_EscolherCliente form = new frmCriarCi_EscolherCliente();            
            form.ShowDialog();
            if (form.cod_cliente != 0)
                txtCodigo.Text = Convert.ToString(form.cod_cliente);
        }

        private void TxtCodCliente_TextChanged(object sender, EventArgs e)
        {
            txtCliente.Clear();
            if (!txtCodigo.Text.Trim().Equals(String.Empty))
            {                
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = " SELECT RAZAO_SOCIAL [CLIENTE] FROM CLIEN WHERE CODIGO = " + txtCodigo.Text;

                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                if (reader["Cliente"] != null)
                                {
                                    txtCliente.Text = reader["Cliente"].ToString();
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
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = " SELECT " +
                                                  " REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(NSIT.Prc_Unitario AS money), 1), ',', '_'), '.', ','), '_', '.')[Prc.Venda] " +
                                                  " ,[Dat.Venda] = CONVERT(DATE, NSCB.DAT_EMISSAO)" +
                                                  " ,NSCB.COD_CLIENTE [Cód. Cliente] " +
                                                  " ,C.Razao_Social [Cliente]" +
                                                  " FROM produ p " +
                                                  " LEFT OUTER JOIN NFSIT NSIT ON NSIT.Cod_Produto = p.codigo " +
                                                  " LEFT OUTER JOIN NFSCB NSCB ON NSCB.Num_Nota = NSIT.Num_Nota " +
                                                  " LEFT OUTER JOIN CLIEN c ON C.CODIGO = NSCB.Cod_Cliente " +
                                                  " WHERE P.Codigo = " + pubsCod_Produto +
                                                  " AND C.Codigo = " + txtCodigo.Text +
                                                  " ORDER BY Dat_Emissao DESC";
                            adaptador = new SqlDataAdapter(command);
                            System.Data.DataTable tableDados = new System.Data.DataTable();
                            adaptador.Fill(tableDados);
                            dgvHistorico.DataSource = tableDados;

                        }
                        catch (SqlException SQLe)
                        {
                            erro_DeAcesso(SQLe);
                        }
                        finally
                        {
                            connectDMD.Close();
                            dgvHistorico.Columns[0].Width = 80;
                            dgvHistorico.Columns[1].Width = 80;
                            dgvHistorico.Columns[2].Width = 80;
                            dgvHistorico.Columns[3].Width = 250;

                        }
                    }                
            }
            else
            {
                Configuracoes_Iniciais();
            }

        }

        private void FrmInfoConsultarPrecos_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            Configuracoes_Iniciais();
        }
        //Função para digitar somente números
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void FrmInfoConsultarPrecos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        //Digitar apenas números
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {           
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
                {
                    e.Handled = true;
                }
            
        }

        //Botão para fechar
        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
