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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Conferencia
{
    public partial class frmProdutosDaCi : Form
    {
        public frmProdutosDaCi()
        {
            InitializeComponent();
        }
        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlCommand command2 = new SqlCommand();
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
        
        int iControleAtualizacao=0;
        List<int> lQuantidade_Anterior = new List<int>();
    
        //Permissões
        private void Carregar_Bloqueios()
        {
            dgvDados2.Enabled = false;           
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
                                if (reader["Cod_Rotina"].ToString() == "5" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    dgvDados2.Enabled = true;


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

        public int Cod_CI;
        List<int> lProtocolos_CIBOT = new List<int>();
        int iSomaStatus;
        private void carregar_DadosIniciais()
        {
                       
            lblCI.Text = Cod_CI.ToString();

            //NOTAS DE DEVOLUÇÃO
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText = " SELECT NF_Devolucao " +
                                          " FROM UNIDB.[dbo].CIDEV WHERE Num_CI = " + Cod_CI;

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["NF_Devolucao"] != null)
                        {
                            lsbNFdevolucao.Items.Add(reader["NF_Devolucao"].ToString());
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

            //NOTA DE ORIMGEM
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText = " SELECT NF_ORIGEM " +
                                          " FROM UNIDB.[dbo].CITOP WHERE Num_CI = " + Cod_CI;

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["NF_ORIGEM"] != null)
                        {
                            txtNForigem.Text = (reader["NF_ORIGEM"].ToString());
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

            //NOTA DE REFATURA
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText = " SELECT NF_REFATURA " +
                                          " FROM UNIDB.[dbo].CITOP WHERE Num_CI = " + Cod_CI;

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["NF_REFATURA"] != null)
                        {
                            txtNFrefatura.Text = (reader["NF_REFATURA"].ToString());
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

            //OPERAÇÃO
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText = " SELECT [OPERACAO] = CASE TIPO_OPERACAO" +
                                          " WHEN 'T' THEN 'TOTAL' " +
                                          " WHEN 'P' THEN 'PARCIAL' " +
                                          " END " +
                                          " FROM UNIDB.[dbo].CITOP WHERE Num_CI = " + Cod_CI;

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["OPERACAO"] != null)
                        {
                            lblRespostaO.Text = (reader["OPERACAO"].ToString());
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

            //RETORNO FISICO
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText = " SELECT RETORNO_FISICO " +

                                          " FROM UNIDB.[dbo].CITOP WHERE Num_CI = " + Cod_CI;

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["RETORNO_FISICO"] != null)
                        {
                            if (Convert.ToInt32(reader["RETORNO_FISICO"].ToString()) == 0)
                            {
                                lblRespostaRetorno.Text = "Não";
                            }
                            else if (Convert.ToInt32(reader["RETORNO_FISICO"].ToString()) == 1)
                            {
                                lblRespostaRetorno.Text = "Sim";
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

            //SETOR
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText = " SELECT DESC_SETOR " +
                                          " FROM UNIDB.[dbo].CITOP " +
                                          " INNER JOIN UNIDB.[dbo].SETOR STO ON STO.COD_SETOR = CITOP.COD_SETOR " +
                                          " WHERE Num_CI = " + Cod_CI;

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["DESC_SETOR"] != null)
                        {

                            lblRespostaSetor.Text = reader["DESC_SETOR"].ToString();


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

            //CLIENTE
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText = " SELECT CODIGO,RAZAO_SOCIAL " +
                                          " FROM UNIDB.[dbo].CITOP " +
                                          " INNER JOIN CLIEN ON CLIEN.CODIGO = CITOP.COD_CLIENTE " +
                                          " WHERE Num_CI = " + Cod_CI;

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["RAZAO_SOCIAL"] != null)
                        {
                            txtCodCliente.Text = reader["CODIGO"].ToString();
                            txtCliente.Text = reader["RAZAO_SOCIAL"].ToString();
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

            //TRANSportadora
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText = " SELECT CODIGO,RAZAO_SOCIAL " +
                                          " FROM UNIDB.[dbo].CITOP " +
                                          " INNER JOIN TRANS ON TRANS.CODIGO = CITOP.cod_transportadora " +
                                          " WHERE Num_CI = " + Cod_CI;

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["RAZAO_SOCIAL"] != null)
                        {
                            txtCodTransportadora.Text = reader["CODIGO"].ToString();
                            txtTransportadora.Text = reader["RAZAO_SOCIAL"].ToString();
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

            //Motivo
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText = " SELECT desc_motivo " +
                                          " FROM UNIDB.[dbo].CITOP " +
                                          " INNER JOIN UNIDB.[dbo].MOTIV ON MOTIV.COD_MOTIVO = CITOP.COD_MOTIVO " +
                                          " WHERE Num_CI = " + Cod_CI;

                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["DESC_MOTIVO"] != null)
                        {
                            txtMotivo.Text = reader["DESC_MOTIVO"].ToString();

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

            //Dados Iniciais Descritivo
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText = " SELECT P.Codigo [Codigo], " +
                                          " P.Descricao[Produto], " +
                                          " CBOT.Qtd_ItemInicial[Qtd. NF], " +
                                          " REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((CBOT.Prc_Unitario) AS money), 1), ',', '_'), '.', ','), '_', '.') AS[Prç. Unit]," +
                                          " CBOT.Qtd_ItemFinal [Qtd. Presente] " +
                                          " FROM PRODU P " +
                                          " INNER JOIN UNIDB.[dbo].CIBOT CBOT ON CBOT.Cod_Produto = P.Codigo " +
                                          " WHERE NUM_CI = " + Cod_CI +
                                          " ORDER BY P.DESCRICAO ASC";

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
                    dgvDados.Columns[0].Width = 50;
                    dgvDados.Columns[1].Width = 180;
                    dgvDados.Columns[2].Width = 80;
                    dgvDados.Columns[3].Width = 74;

                }
            }


            //DgvDados 2
            dgvDados2.Columns.Clear();
            dgvDados2.Columns.Add("Quantidade", "Quantidade");
            dgvDados2.Rows.Clear();
            lQuantidade_Anterior.Clear();
            foreach (DataGridViewRow rows in dgvDados.Rows)
            {

                dgvDados2.Rows.Add();
                lQuantidade_Anterior.Add(Convert.ToInt32(rows.Cells[4].Value.ToString()));
            }

            dgvDados2.Columns[0].Width = 67;

            //Resultante
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText = " SELECT (CBOT.QTD_ITEMINICIAL - CBOT.Qtd_ItemFinal) [Qtd. restante]," +
                                          " REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST((CBOT.QTD_ITEMINICIAL * CBOT.PRC_UNITARIO) AS money), 1), ',', '_'), '.', ','), '_', '.') AS[Vlr. Item]" +
                                          " FROM PRODU P " +
                                          " INNER JOIN UNIDB.[dbo].CIBOT CBOT ON CBOT.Cod_Produto = P.Codigo " +
                                          " WHERE NUM_CI = " + Cod_CI +
                                          " ORDER BY P.DESCRICAO ASC";

                    adaptador = new SqlDataAdapter(command);
                    System.Data.DataTable tableDados = new System.Data.DataTable();
                    adaptador.Fill(tableDados);
                    dgvDados3.DataSource = tableDados;
                }
                catch (SqlException SQLe)
                {
                    erroSQLE(SQLe);
                }
                finally
                {
                    connectDMD.Close();

                    dgvDados3.Columns[1].Width = 83;
                }            
        }
            
        }
        private void encaminhamento_Financeiro()
        {
            for (int x = 0; x < dgvDados3.Rows.Count; x++)
            {
                if (dgvDados2.Rows[x].Cells[0].Value == null)
                iSomaStatus = iSomaStatus + (Convert.ToInt32(dgvDados.Rows[x].Cells[2].Value.ToString())- (Convert.ToInt32(dgvDados.Rows[x].Cells[4].Value.ToString()) + (0)));
                else
                    iSomaStatus = iSomaStatus + (Convert.ToInt32(dgvDados.Rows[x].Cells[2].Value.ToString()) - (Convert.ToInt32(dgvDados.Rows[x].Cells[4].Value.ToString()) + (Convert.ToInt32(dgvDados2.Rows[x].Cells[0].Value.ToString()))));
            }
            if (iSomaStatus == 0)
            {
                
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {

                        try
                        {
                            connectDMD.Open();
                            command2 = connectDMD.CreateCommand();

                            command2.CommandText = " UPDATE UNIDB.[dbo].CITOP set STATUS = 'A'" +
                                                   " WHERE Num_CI = " + Cod_CI;
                            command2.ExecuteNonQuery();



                        }

                        catch (SqlException SQLe)
                        {
                            erroSQLE(SQLe);
                            return;
                        }
                        finally
                        {
                            connectDMD.Close();
                            mMessage = "CI encaminhada para o Financeiro";
                            mTittle = "CI";
                            mButton = MessageBoxButtons.OK;
                            mIcon = MessageBoxIcon.Information;
                            MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                            this.Close();
                        }

                    }
                
                

            }
        }
        private void alterar_Quantidade()
        {            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT CBOT.Protocolo" +
                                              " FROM PRODU P " +
                                              " INNER JOIN UNIDB.[dbo].CIBOT CBOT ON CBOT.Cod_Produto = P.Codigo " +
                                              " WHERE NUM_CI = " + Cod_CI +
                                              " ORDER BY P.DESCRICAO ASC";



                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Protocolo"] != null)
                            {
                                lProtocolos_CIBOT.Add(Convert.ToInt32(reader["Protocolo"].ToString()));
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
                        dgvDados.Columns[0].Width = 50;
                        dgvDados.Columns[1].Width = 180;
                        dgvDados.Columns[2].Width = 80;
                        dgvDados.Columns[3].Width = 74;
                        iControleAtualizacao = 0;
                    }
                }

                for (int x = 0; x < dgvDados2.Rows.Count; x++)
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {

                        try
                        {


                            if (dgvDados2.Rows[x].Cells[0].Value != (null))
                            {
                                connectDMD.Open();
                                command2 = connectDMD.CreateCommand();

                                command2.CommandText = " UPDATE UNIDB.[dbo].CIBOT set Qtd_ItemFinal = @Quantidade" +
                                                       " WHERE Protocolo = " + lProtocolos_CIBOT[x];
                                if (Convert.ToInt32(dgvDados.Rows[x].Cells[2].Value.ToString()) < Convert.ToInt32(dgvDados2.Rows[x].Cells[0].Value.ToString()) + (lQuantidade_Anterior[x]))
                                {
                                    mMessage = "A quantidade do produto " + dgvDados.Rows[x].Cells[1].Value.ToString() + " não pode ser maior que a existente na nota de devolução.";
                                    mTittle = "CI";
                                    mButton = MessageBoxButtons.OK;
                                    mIcon = MessageBoxIcon.Exclamation;
                                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                                    iControleAtualizacao = 1;
                                    break;
                                }

                                //Quantidade foinal
                                SqlParameter pQuantidade = new SqlParameter("@Quantidade", SqlDbType.Int);
                                pQuantidade.Value = Convert.ToInt32(dgvDados2.Rows[x].Cells[0].Value.ToString()) + (lQuantidade_Anterior[x]);
                                command2.Parameters.Add(pQuantidade);

                                command2.ExecuteNonQuery();
                            }


                        }

                        catch (SqlException SQLe)
                        {
                            erroSQLE(SQLe);
                            return;
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
                            if (dgvDados2.Rows[x].Cells[0].Value != (null))
                            {
                                connectDMD.Open();
                                command2 = connectDMD.CreateCommand();

                                command2.CommandText = " INSERT INTO UNIDB.[dbo].CILOG  (Num_CI,Quantidade_Anterior,Quantidade_Atualizada,Dat_Registro,Usuario) " +
                                                       " VALUES  (@Num_CI,@Quantidade_Anterior,@Quantidade_Atualizada,GetDate(),@Usuario)";



                                //Num_CI
                                SqlParameter pNum_CI = new SqlParameter("@Num_CI", SqlDbType.Int);
                                pNum_CI.Value = Convert.ToInt32(Cod_CI);
                                command2.Parameters.Add(pNum_CI);

                                //Quantidade anterior
                                SqlParameter pQuantidade_Anterior = new SqlParameter("@Quantidade_Anterior", SqlDbType.Int);
                                pQuantidade_Anterior.Value = Convert.ToInt32(lQuantidade_Anterior[x].ToString());
                                command2.Parameters.Add(pQuantidade_Anterior);

                                //Quantidade atualizada
                                SqlParameter pQuantidade_Atualizada = new SqlParameter("@Quantidade_Atualizada", SqlDbType.Int);
                                pQuantidade_Atualizada.Value = Convert.ToInt32(dgvDados2.Rows[x].Cells[0].Value.ToString());
                                command2.Parameters.Add(pQuantidade_Atualizada);

                                //Usuario
                                SqlParameter pUsuario = new SqlParameter("@Usuario", SqlDbType.VarChar, 15);
                                pUsuario.Value = Usuario.userDesc;
                                command2.Parameters.Add(pUsuario);

                                command2.ExecuteNonQuery();


                            }
                        }

                        catch (SqlException SQLe)
                        {
                            erroSQLE(SQLe);
                            break;
                        }
                        finally
                        {
                            connectDMD.Close();



                        }
                    }
                }

                if (iControleAtualizacao != 1)
                {
                    for (int x = 0; x < lQuantidade_Anterior.Count; x++)
                    {


                    }
                    mMessage = "Produtos atualizados";
                    mTittle = "CI";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Information;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    encaminhamento_Financeiro();
                    this.frmProdutosDaCi_Load(btnConfirmar, new EventArgs());                
            }
          
        }
        private void limpar_Dados()
        {
            dgvDados2.Rows.Clear();
            
            lsbNFdevolucao.Items.Clear();
            iSomaStatus = 0;
        }

        //Load do form
        private void frmProdutosDaCi_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            limpar_Dados();
            carregar_DadosIniciais();
            Carregar_Bloqueios();
            Carregar_Permissoes();
        }

        private void dgvDados2_Scroll(object sender, ScrollEventArgs e)
        {
            dgvDados.FirstDisplayedScrollingRowIndex =
         dgvDados2.FirstDisplayedScrollingRowIndex;

            dgvDados3.FirstDisplayedScrollingRowIndex =
         dgvDados2.FirstDisplayedScrollingRowIndex;            
        }

        private void dgvDados2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDados3.Rows.Count > 0)
            {
                if (dgvDados2.CurrentRow.Index > 0)
                {
                    dgvDados.Rows[e.RowIndex - 1].Selected = false;
                    dgvDados3.Rows[e.RowIndex - 1].Selected = false;
                }
                dgvDados.Rows[e.RowIndex].Selected = true;
                dgvDados3.Rows[e.RowIndex].Selected = true;
                if (dgvDados2.CurrentRow.Index < dgvDados2.Rows.Count-1)
                {
                    dgvDados.Rows[e.RowIndex + 1].Selected = false;
                    dgvDados3.Rows[e.RowIndex + 1].Selected = false;
                }
            }
        }

        private void frmProdutosDaCi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void ChkRecebimentoTotal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRecebimentoTotal.Checked == true)
            {
                for (int x = 0; x < dgvDados2.Rows.Count; x++)
                {
                    dgvDados2.Rows[x].Cells[0].Value = dgvDados3.Rows[x].Cells[0].Value.ToString();
                }
            }
            else
            {
                for (int x = 0; x < dgvDados2.Rows.Count; x++)
                    dgvDados2.Rows[x].Cells[0].Value = 0;
            }
        }


        //Botão para Confirmar
        private void btnConfirmar_Click(object sender, EventArgs e)
        {            
            
            alterar_Quantidade();
            
        }
       
    }
}
