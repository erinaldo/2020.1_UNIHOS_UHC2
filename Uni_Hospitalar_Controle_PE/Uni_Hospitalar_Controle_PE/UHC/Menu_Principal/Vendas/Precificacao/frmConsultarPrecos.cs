using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Ulib;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Precificacao
{
    public partial class frmConsultarPrecos : Form
    {
        public frmConsultarPrecos()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlCommand command2 = new SqlCommand();
        private SqlDataReader reader,reader2;
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

        //Configurações de inicialização da tela
        private void Configuracoes_Iniciais()
        {        
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = "  SELECT P.Codigo	   [Código] " +
                                              " ,P.Descricao[Produto] " +
                                              " ,P.Cod_EAN[Cód.Ean] " +
                                              " ,P.Qtd_Disponivel[Qtd.Disponível] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(P.Prc_Venda AS money), 1),',', '_'), '.', ','), '_', '.'),0) AS [T1] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(TPX.Val_PrcVen AS money), 1),',', '_'), '.', ','), '_', '.'),0) AS [T2] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(TPXPR.Val_PrcVen AS money), 1), ',', '_'), '.', ','), '_', '.'), 0) AS[T3] " +
                                              " ,Des_NomGen[Nome Genérico] " +
                                              " ,F.Fantasia[Fabricante] " +
                                              " ,[Medicamento] = case flg_Oncologico when 1 then 'Onco' when 0 then 'Hosp' end" +
                                              " FROM PRODU P " +
                                              " RIGHT OUTER JOIN TPXPR TPX ON TPX.COD_PRODUT = P.Codigo " +
                                              " RIGHT OUTER JOIN TPXPR ON(TPXPR.Cod_Produt = P.Codigo AND TPXPR.Cod_TabPrc = 3) " +
                                              " INNER JOIN FABRI F ON F.Codigo = P.Cod_Fabricante " +
                                              " WHERE tpx.Cod_TabPrc = 2 " +
                                              " and (Flg_Oncologico = " + iOnco + " or Flg_Oncologico = " + iHosp + ") " +
                                              " and(Qtd_Disponivel = " + iNao + " or Qtd_Disponivel > " + iSim + ")";
                        adaptador = new SqlDataAdapter(command);
                        System.Data.DataTable tableDados = new System.Data.DataTable();
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

                        dgvDados.Columns[0].Width = 50;
                        dgvDados.Columns[1].Width = 250;
                        dgvDados.Columns[2].Width = 120;
                        dgvDados.Columns[3].Width = 50;
                        dgvDados.Columns[4].Width = 50;
                        dgvDados.Columns[5].Width = 50;
                        dgvDados.Columns[6].Width = 50;
                        dgvDados.Columns[7].Width = 200;

                    }
                }                    
        }


        //Instancia dos filtros checkáveis
        int iSim=0;
        int iNao=0;
        int iOnco=1;
        int iHosp=0;
        private void Filtrar_Dados()
        {
            this.Cursor = Cursors.WaitCursor;
            
                if (!txtFabricante.Text.Trim().Equals(String.Empty) == true)
                {
                    //Fabricante e produto
                    if (!txtFabricante.Text.Trim().Equals(String.Empty) == true && !txtGenerico.Text.Trim().Equals(String.Empty) == true)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = "  SELECT P.Codigo	   [Código] " +
                                              " ,P.Descricao[Produto] " +
                                              " ,P.Cod_EAN[Cód.Ean] " +
                                              " ,P.Qtd_Disponivel[Qtd.Disponível] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(P.Prc_Venda AS money), 1),',', '_'), '.', ','), '_', '.'),0) AS [T1] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(TPX.Val_PrcVen AS money), 1),',', '_'), '.', ','), '_', '.'),0) AS [T2] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(TPXPR.Val_PrcVen AS money), 1), ',', '_'), '.', ','), '_', '.'), 0) AS[T3] " +
                                              " ,Des_NomGen[Nome Genérico] " +
                                              " ,F.Fantasia[Fabricante] " +
                                              " ,[Medicamento] = case flg_Oncologico when 1 then 'Onco' when 0 then 'Hosp' end" +
                                              " FROM PRODU P " +
                                              " RIGHT OUTER JOIN TPXPR TPX ON TPX.COD_PRODUT = P.Codigo " +
                                              " RIGHT OUTER JOIN TPXPR ON(TPXPR.Cod_Produt = P.Codigo AND TPXPR.Cod_TabPrc = 3) " +
                                              " INNER JOIN FABRI F ON F.Codigo = P.Cod_Fabricante " +
                                              " WHERE tpx.Cod_TabPrc = 2 " +
                                                      " and (Flg_Oncologico = " + iOnco + " or Flg_Oncologico = " + iHosp + ") " +
                                                      " and(Qtd_Disponivel = " + iNao + " or Qtd_Disponivel > " + iSim + ")" +
                                                      " AND F.CODIGO LIKE " + txtCodFabricante.Text +
                                                      " AND Des_NomGen LIKE '%" + txtGenerico.Text + "%'";
                                adaptador = new SqlDataAdapter(command);
                                System.Data.DataTable tableDados = new System.Data.DataTable();
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

                                dgvDados.Columns[0].Width = 50;
                                dgvDados.Columns[1].Width = 250;
                                dgvDados.Columns[2].Width = 120;
                                dgvDados.Columns[3].Width = 50;
                                dgvDados.Columns[4].Width = 50;
                                dgvDados.Columns[5].Width = 50;
                                dgvDados.Columns[6].Width = 50;
                                dgvDados.Columns[7].Width = 200;
                            }
                        }
                    }

                    //Fabricante e generico
                    else if (!txtFabricante.Text.Trim().Equals(String.Empty) == true && !txtProduto.Text.Trim().Equals(String.Empty) == true)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = "  SELECT P.Codigo	   [Código] " +
                                              " ,P.Descricao[Produto] " +
                                              " ,P.Cod_EAN[Cód.Ean] " +
                                              " ,P.Qtd_Disponivel[Qtd.Disponível] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(P.Prc_Venda AS money), 1),',', '_'), '.', ','), '_', '.'),0) AS [T1] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(TPX.Val_PrcVen AS money), 1),',', '_'), '.', ','), '_', '.'),0) AS [T2] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(TPXPR.Val_PrcVen AS money), 1), ',', '_'), '.', ','), '_', '.'), 0) AS[T3] " +
                                              " ,Des_NomGen[Nome Genérico] " +
                                              " ,F.Fantasia[Fabricante] " +
                                              " ,[Medicamento] = case flg_Oncologico when 1 then 'Onco' when 0 then 'Hosp' end" +
                                              " FROM PRODU P " +
                                              " RIGHT OUTER JOIN TPXPR TPX ON TPX.COD_PRODUT = P.Codigo " +
                                              " RIGHT OUTER JOIN TPXPR ON(TPXPR.Cod_Produt = P.Codigo AND TPXPR.Cod_TabPrc = 3) " +
                                              " INNER JOIN FABRI F ON F.Codigo = P.Cod_Fabricante " +
                                              " WHERE tpx.Cod_TabPrc = 2 " +
                                                      " and (Flg_Oncologico = " + iOnco + " or Flg_Oncologico = " + iHosp + ") " +
                                                      " and(Qtd_Disponivel = " + iNao + " or Qtd_Disponivel > " + iSim + ")" +
                                                      " AND F.CODIGO LIKE " + txtCodFabricante.Text +
                                                      " AND P.Descricao LIKE '%" + txtProduto.Text + "%'";
                                adaptador = new SqlDataAdapter(command);
                                System.Data.DataTable tableDados = new System.Data.DataTable();
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

                                dgvDados.Columns[0].Width = 50;
                                dgvDados.Columns[1].Width = 250;
                                dgvDados.Columns[2].Width = 120;
                                dgvDados.Columns[3].Width = 50;
                                dgvDados.Columns[4].Width = 50;
                                dgvDados.Columns[5].Width = 50;
                                dgvDados.Columns[6].Width = 50;
                                dgvDados.Columns[7].Width = 200;
                            }
                        }

                    }

                    //Fabricante
                    else
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = "  SELECT P.Codigo	   [Código] " +
                                              " ,P.Descricao[Produto] " +
                                              " ,P.Cod_EAN[Cód.Ean] " +
                                              " ,P.Qtd_Disponivel[Qtd.Disponível] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(P.Prc_Venda AS money), 1),',', '_'), '.', ','), '_', '.'),0) AS [T1] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(TPX.Val_PrcVen AS money), 1),',', '_'), '.', ','), '_', '.'),0) AS [T2] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(TPXPR.Val_PrcVen AS money), 1), ',', '_'), '.', ','), '_', '.'), 0) AS[T3] " +
                                              " ,Des_NomGen[Nome Genérico] " +
                                              " ,F.Fantasia[Fabricante] " +
                                              " ,[Medicamento] = case flg_Oncologico when 1 then 'Onco' when 0 then 'Hosp' end" +
                                              " FROM PRODU P " +
                                              " RIGHT OUTER JOIN TPXPR TPX ON TPX.COD_PRODUT = P.Codigo " +
                                              " RIGHT OUTER JOIN TPXPR ON(TPXPR.Cod_Produt = P.Codigo AND TPXPR.Cod_TabPrc = 3) " +
                                              " INNER JOIN FABRI F ON F.Codigo = P.Cod_Fabricante " +
                                              " WHERE tpx.Cod_TabPrc = 2 " +
                                                      " and (Flg_Oncologico = " + iOnco + " or Flg_Oncologico = " + iHosp + ") " +
                                                      " and(Qtd_Disponivel = " + iNao + " or Qtd_Disponivel > " + iSim + ")" +
                                                      " AND F.CODIGO LIKE " + txtCodFabricante.Text;
                                adaptador = new SqlDataAdapter(command);
                                System.Data.DataTable tableDados = new System.Data.DataTable();
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

                                dgvDados.Columns[0].Width = 50;
                                dgvDados.Columns[1].Width = 250;
                                dgvDados.Columns[2].Width = 120;
                                dgvDados.Columns[3].Width = 50;
                                dgvDados.Columns[4].Width = 50;
                                dgvDados.Columns[5].Width = 50;
                                dgvDados.Columns[6].Width = 50;
                                dgvDados.Columns[7].Width = 200;
                            }
                        }
                    }
                }
                else if (!txtGenerico.Text.Trim().Equals(String.Empty) == true)
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();
                            ;
                            command = connectDMD.CreateCommand();
                            command.CommandText = "  SELECT P.Codigo	   [Código] " +
                                              " ,P.Descricao[Produto] " +
                                              " ,P.Cod_EAN[Cód.Ean] " +
                                              " ,P.Qtd_Disponivel[Qtd.Disponível] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(P.Prc_Venda AS money), 1),',', '_'), '.', ','), '_', '.'),0) AS [T1] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(TPX.Val_PrcVen AS money), 1),',', '_'), '.', ','), '_', '.'),0) AS [T2] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(TPXPR.Val_PrcVen AS money), 1), ',', '_'), '.', ','), '_', '.'), 0) AS[T3] " +
                                              " ,Des_NomGen[Nome Genérico] " +
                                              " ,F.Fantasia[Fabricante] " +
                                              " ,[Medicamento] = case flg_Oncologico when 1 then 'Onco' when 0 then 'Hosp' end" +
                                              " FROM PRODU P " +
                                              " RIGHT OUTER JOIN TPXPR TPX ON TPX.COD_PRODUT = P.Codigo " +
                                              " RIGHT OUTER JOIN TPXPR ON(TPXPR.Cod_Produt = P.Codigo AND TPXPR.Cod_TabPrc = 3) " +
                                              " INNER JOIN FABRI F ON F.Codigo = P.Cod_Fabricante " +
                                              " WHERE tpx.Cod_TabPrc = 2 " +
                                                  " and (Flg_Oncologico = " + iOnco + " or Flg_Oncologico = " + iHosp + ") " +
                                                  " and(Qtd_Disponivel = " + iNao + " or Qtd_Disponivel > " + iSim + ")" +
                                                  " AND Des_NomGen LIKE '%" + txtGenerico.Text + "%'";
                            adaptador = new SqlDataAdapter(command);
                            System.Data.DataTable tableDados = new System.Data.DataTable();
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


                            dgvDados.Columns[0].Width = 50;
                            dgvDados.Columns[1].Width = 250;
                            dgvDados.Columns[2].Width = 120;
                            dgvDados.Columns[3].Width = 50;
                            dgvDados.Columns[4].Width = 50;
                            dgvDados.Columns[5].Width = 50;
                            dgvDados.Columns[6].Width = 50;
                            dgvDados.Columns[7].Width = 200;
                        }
                    }
                }
                else if (!txtProduto.Text.Trim().Equals(String.Empty) == true)
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "  SELECT P.Codigo	   [Código] " +
                                              " ,P.Descricao[Produto] " +
                                              " ,P.Cod_EAN[Cód.Ean] " +
                                              " ,P.Qtd_Disponivel[Qtd.Disponível] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(P.Prc_Venda AS money), 1),',', '_'), '.', ','), '_', '.'),0) AS [T1] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(TPX.Val_PrcVen AS money), 1),',', '_'), '.', ','), '_', '.'),0) AS [T2] " +
                                              " ,ISNULL(REPLACE(REPLACE(REPLACE(CONVERT(varchar, CAST(TPXPR.Val_PrcVen AS money), 1), ',', '_'), '.', ','), '_', '.'), 0) AS[T3] " +
                                              " ,Des_NomGen[Nome Genérico] " +
                                              " ,F.Fantasia[Fabricante] " +
                                              " ,[Medicamento] = case flg_Oncologico when 1 then 'Onco' when 0 then 'Hosp' end" +
                                              " FROM PRODU P " +
                                              " RIGHT OUTER JOIN TPXPR TPX ON TPX.COD_PRODUT = P.Codigo " +
                                              " RIGHT OUTER JOIN TPXPR ON(TPXPR.Cod_Produt = P.Codigo AND TPXPR.Cod_TabPrc = 3) " +
                                              " INNER JOIN FABRI F ON F.Codigo = P.Cod_Fabricante " +
                                              " WHERE tpx.Cod_TabPrc = 2 " +
                                                  " and (Flg_Oncologico = " + iOnco + " or Flg_Oncologico = " + iHosp + ") " +
                                                  " and(Qtd_Disponivel = " + iNao + " or Qtd_Disponivel > " + iSim + ")" +
                                                  " AND P.Descricao LIKE '%" + txtProduto.Text + "%'";
                            adaptador = new SqlDataAdapter(command);
                            System.Data.DataTable tableDados = new System.Data.DataTable();
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


                            dgvDados.Columns[0].Width = 50;
                            dgvDados.Columns[1].Width = 250;
                            dgvDados.Columns[2].Width = 120;
                            dgvDados.Columns[3].Width = 50;
                            dgvDados.Columns[4].Width = 50;
                            dgvDados.Columns[5].Width = 50;
                            dgvDados.Columns[6].Width = 50;
                            dgvDados.Columns[7].Width = 200;
                        }
                    }
                }
                else {
                    Configuracoes_Iniciais();
                }                        
            this.Cursor = Cursors.Default;
        }
           
        
        //Load do form
        private void FrmConsultarPrecos_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            Configuracoes_Iniciais();
        }

        //Fechar com esc
        private void FrmConsultarPrecos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Down)
            {
                dgvDados.Focus();
            }
        }

        //Preencher produto
        private void TxtCodProduto_TextChanged(object sender, EventArgs e)
        {
            txtProduto.Clear();
            if (!txtCodProduto.Text.Trim().Equals(String.Empty))
            {
                txtProduto.ReadOnly = true;
                
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT Descricao FROM produ WHERE CODIGO = " + Convert.ToInt32(txtCodProduto.Text);

                            reader2 = command.ExecuteReader();

                            while (reader2.Read())
                            {
                                if (reader2["Descricao"] != null)
                                {
                                    txtProduto.Text = reader2["Descricao"].ToString();
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
            else
            {
                txtProduto.ReadOnly = false;
            }
        }
        private void TxtProduto_TextChanged(object sender, EventArgs e)
        {
            
            Filtrar_Dados();
            if (txtProduto.Text.Length > 0)
            {
                txtGenerico.Enabled = false;
                txtGenerico.Clear();
            }
            else
            {
                txtGenerico.Enabled = true;
            }
        }

      


        //Preencher fabricante
        private void TxtCodFabricante_TextChanged(object sender, EventArgs e)
        {
            txtFabricante.Clear();
            if (!txtCodFabricante.Text.Trim().Equals(String.Empty))
            {
             
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT Fantasia FROM dmd.dbo.fabri WHERE CODIGO = " + (txtCodFabricante.Text);

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Fantasia"] != null)
                                {
                                    txtFabricante.Text = reader["Fantasia"].ToString();
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
       

        private void BtnPreencherFabricante_Click(object sender, EventArgs e)
        {
            frmPesquisarFabricante form = new frmPesquisarFabricante();            
            form.ShowDialog();
            if (form.Cod_Fabricante != 0)
                txtCodFabricante.Text = Convert.ToString(form.Cod_Fabricante);
        }

        private void TxtGenerico_TextChanged(object sender, EventArgs e)
        {
            Filtrar_Dados();
            if (txtGenerico.Text.Length > 0)
            {
                txtProduto.Enabled = false;
                txtCodProduto.Enabled = false;
                txtCodProduto.Clear();
                txtProduto.Clear();
            }
            else
            {
                txtProduto.Enabled = true;
                txtCodProduto.Enabled = true;
            }
        }
     
        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            if (chkSim.Checked == false && chkNão.Checked == false)
            {
                mMessage = "É necessário selecionar algum filtro de estoque";
                mTittle = "Estoque";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Asterisk;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                return;
            }
            if (chkOncologico.Checked == false && chkHospitalar.Checked == false)
            {
                mMessage = "É necessário selecionar algum filtro de Tipo";
                mTittle = "Tipo";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Asterisk;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                return;
            }
            Filtrar_Dados();

        }

        //Filtra itens com estoque disponível
        private void ChkSim_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSim.Checked == true)
            {
                iSim = 0;
            }
            else
            {
                iSim = 999999999;
            }
        }
        //Filtra itens com estoque não disponível
        private void ChkNão_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNão.Checked == true)
            {
                iNao = 0;
            }
            else
            {
                iNao = -1;
            }
        }
        //Filtra itens oncológicos
        private void ChkOncologico_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOncologico.Checked == true)
            {
                iOnco = 1;
            }
            else
            {
                iOnco = 0;
            }
        }

        private void DgvDados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            
            
            
            


            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT c.Descricao, " +
                                              " [Localizacao] = CASE COD_LOCFIS " +
                                              " WHEN '1' THEN 'Medicamento comum' " +
                                              " WHEN '2' THEN 'Medicamento controlado' " +
                                              " WHEN '3' THEN 'Medicamento perecível' " +
                                              " WHEN '4' THEN 'Correlatos' " +
                                              " WHEN 'ALM' THEN 'Almoxarifado' " +
                                              " ELSE " +
                                              " 'Localização inválida' " +
                                              " END " +
                                              " FROM PRODU P " +
                                              " INNER JOIN CLASS C ON C.Codigo = SUBSTRING(COD_CLASSIF,0,5) " +
                                              " WHERE P.CODIGO = " + dgvDados.CurrentRow.Cells[0].Value.ToString();

                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Localizacao"] != null)
                            {
                                txtLocalizacao.Text = reader["Localizacao"].ToString();
                                txtTipo.Text = reader["Descricao"].ToString();
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
            

            if (!dgvDados.CurrentRow.Cells[2].Value.ToString().Equals(String.Empty))
            {
                
                string Ean = dgvDados.CurrentRow.Cells[2].Value.ToString();
                if (Ean != null)
                Clipboard.SetText(Ean);
            }
            else if (dgvDados.CurrentRow.Cells[2].Value.ToString().Equals(String.Empty))
            {
                
                string Ean = "O item " + dgvDados.CurrentRow.Cells[1].Value.ToString() + " não possui código EAN";
                if (Ean != null)
                    Clipboard.SetText(Ean);
            }



        }
        //Filtra itens hospitalares
        private void ChkHospitalar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHospitalar.Checked == true)
            {
                iHosp = 0;
            }
            else
            {
                iHosp = 1;
            }
        }

        private void DgvDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frmInfoConsultarPrecos form = new frmInfoConsultarPrecos();
            
            form.lblProduto.Text = "Produto: " + dgvDados.CurrentRow.Cells[1].Value.ToString();
            form.pubsCod_Produto = dgvDados.CurrentRow.Cells[0].Value.ToString();
            form.ShowDialog();
        }

        //Função para digitar somente números
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }




    }
}
