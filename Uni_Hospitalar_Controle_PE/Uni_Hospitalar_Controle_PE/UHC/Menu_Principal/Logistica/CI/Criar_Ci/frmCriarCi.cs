using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci
{
    public partial class frmCriarCi : Form
    {
        public frmCriarCi()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlCommand command2 = new SqlCommand();
        private SqlDataReader reader,reader2;

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


        int iValidarCI=0;
        //Variáveis para criação da CI
        Char cTipo_Operacao;
        int iCod_Motivo;
        int iCod_Setor;
        int iRetorno_Fisico;
        
        int iNum_CI;

        int iNum_Nota;
        Char cStatus;
        List<int> lDevolucoes = new List<int>();
        List<int> lQuantidadeSemRetorno = new List<int>();
        List<double> lPrc_Unitario = new List<double>();
        List<int> lCod_Produto = new List<int>();
        List<int> lQtd_Produto = new List<int>();
        List<int> lDevolucoesCheck = new List<int>();

        


        private void Carregar_Bloqueios()
        {
            txtCodTransportadora.Enabled = false;
            btnPreencherTransportadora.Visible = false;


        }


        //Carregar permissões de tela 
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
                                          " WHERE Cod_Usuario = " + Usuario.userId; ;
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Cod_Usuario"] != null)
                            {
                                //Permissão para usuário
                                if (reader["Cod_Rotina"].ToString() == "20" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    txtCodTransportadora.Enabled = true;
                                    btnPreencherTransportadora.Visible = true;
                                }
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



        //Load do form
        private void frmCriarCi_Load(object sender, EventArgs e)
        {
            Carregar_Bloqueios();
            Carregar_Permissoes();
            this.Icon = Properties.Resources.Icon_Uni;
            configuracao_Inicial();

        }

        private void configuracao_Inicial()
        {            
                //Adiciona os setores
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" SELECT Desc_Setor [Setor]" +
                                                 " FROM UNIDB.[dbo].SETOR " +
                                                 " ORDER BY Desc_Setor ASC", connectDMD);


                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Setor"] != null) //Sendo o leitor diferente de nulo
                            {
                                cbxSetor.Items.Add(reader["Setor"].ToString());
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

                //Inserir motivos
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        //Comando sql
                        command = new SqlCommand(" SELECT Desc_Motivo [Motivo]" +
                                                 " FROM UNIDB.[dbo].MOTIV " +
                                                 " ORDER BY Desc_Motivo ASC", connectDMD);


                        connectDMD.Open();
                        reader = command.ExecuteReader();
                        //Verifica se ocorrerá alteração de senha
                        while (reader.Read())
                        {
                            if (reader["Motivo"] != null) //Sendo o leitor diferente de nulo
                            {
                                cbxMotivo.Items.Add(reader["Motivo"].ToString());
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

                //Bloqueio de notas de devolução já criadas numa CI
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = "SELECT DEV.NF_devolucao FROM UNIDB.[dbo].CIDEV DEV ";


                        reader2 = command.ExecuteReader();

                        while (reader2.Read())
                        {
                            if (reader2["NF_Devolucao"] != null)
                            {
                                lDevolucoesCheck.Add(Convert.ToInt32(reader2["NF_Devolucao"].ToString()));
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

        //Validação da CI (Travas)
        private void validarCi()
        {            
                if (cbxMotivo.SelectedItem == null)
                {
                    mMessage = "O motivo precisa ser informado";
                    mTittle = "Motivo";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Error;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    return;
                }

                if (cbxSetor.SelectedItem == null)
                {
                    mMessage = "O setor precisa ser informado";
                    mTittle = "Setor";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Error;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    return;
                }

                if (txtCliente.Text.Trim().Equals(String.Empty))
                {
                    mMessage = "O cliente precisa ser informado";
                    mTittle = "Cliente";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Error;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    return;
                }

                if (rdbSim.Checked == false && rdbNao.Checked == false)
                {
                    mMessage = "É necessário a informação de retorno físico.";
                    mTittle = "Retorno físico";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Error;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    return;
                }

               
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT Gera_devolucao FROM UNIDB.[dbo].MOTIV " +
                                                  " WHERE Desc_Motivo like '" + cbxMotivo.SelectedItem + "'";


                            reader2 = command.ExecuteReader();

                            while (reader2.Read())
                            {
                                if (reader2["Gera_devolucao"] != null)
                                {
                                    if ((Convert.ToInt32(reader2["Gera_devolucao"].ToString()) == 0 && clbNFdevol.CheckedItems.Count == 0) || ((Convert.ToInt32(reader2["Gera_devolucao"].ToString()) == 0) && clbNFdevol.CheckedItems.Count == 0))
                                    {


                                    }
                                    else if (clbNFdevol.CheckedItems.Count == 0)
                                    {
                                        mMessage = "A nota de devolução precisa ser informada";
                                        mTittle = "NF devolução";
                                        mButton = MessageBoxButtons.OK;
                                        mIcon = MessageBoxIcon.Error;
                                        MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                                        return;
                                    }
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
                           
                if (txtNForigem.Text.Trim().Equals(String.Empty))
                {
                    mMessage = "A nota de origem precisa ser informada";
                    mTittle = "NF origem";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Error;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    return;
                }

                if (txtTransportadora.Text.Trim().Equals(String.Empty) && rdbSim.Checked == true)
                {
                    mMessage = "A partir do momento que há retorno de mercadoria, a transportadora deve ser inserida";
                    mTittle = "Transportadora";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Error;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    return;
                }
                iValidarCI = 1;
            

        }

        //Criação da CI
        private void criarCI()
        {
            
                if (iValidarCI == 1)
                {
                    //Tipo de operação
                    if (rdbDevTotal.Checked == true)
                    {
                        cTipo_Operacao = 'T'; //Devolução total
                    }
                    else if (rdbDevParcial.Checked == true)
                    {
                        cTipo_Operacao = 'P'; //Devolução parcial
                    }

                    //Motivo
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT Cod_Motivo FROM UNIDB.[dbo].MOTIV WHERE Desc_Motivo like '" + cbxMotivo.SelectedItem + "'";

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Cod_Motivo"] != null)
                                {
                                    iCod_Motivo = Convert.ToInt32(reader["Cod_Motivo"].ToString());
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

                    //Setor
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT Cod_Setor FROM UNIDB.[dbo].SETOR WHERE Desc_Setor like '" + cbxSetor.SelectedItem + "'";

                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Cod_Setor"] != null)
                                {
                                    iCod_Setor = Convert.ToInt32(reader["Cod_Setor"].ToString());
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

                    //Retorno físico
                    if (rdbSim.Checked == true)
                    {
                        iRetorno_Fisico = 1;
                        cStatus = 'P';
                    }
                    else if (rdbNao.Checked == true)
                    {
                        iRetorno_Fisico = 0; //Devolução parcial
                        cStatus = 'A';
                    }

                    //Alimentar CITOP
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {

                        try
                        {
                            connectDMD.Open();
                            command2 = connectDMD.CreateCommand();

                            command2.CommandText = " INSERT INTO UNIDB.[dbo].CITOP " +
                                              " (Tipo_Operacao,Cod_Motivo,Cod_Setor,Cod_Cliente,Cod_Transportadora,Retorno_Fisico,NF_Refatura,NF_Origem,Observacao,Usuario,Dat_Entrada,Status) " +
                                              "VALUES (@Tipo_Operacao,@Cod_Motivo,@Cod_Setor,@Cod_Cliente,@Cod_Transportadora,@Retorno_Fisico,@NF_Refatura,@NF_Origem,@Observacao,@Usuario,GetDate(),@Status)";



                            if (txtCodTransportadora.Text.Equals(String.Empty))
                            {
                                txtCodTransportadora.Text = 0.ToString();
                            }
                            if (txtNFrefatura.Text.Equals(String.Empty))
                            {
                                txtNFrefatura.Text = 0.ToString();
                            }


                            //Tipo de operação
                            SqlParameter pTipo_Operacao = new SqlParameter("@Tipo_Operacao", SqlDbType.Char, 1);
                            pTipo_Operacao.Value = cTipo_Operacao;
                            command2.Parameters.Add(pTipo_Operacao);
                            //Motivo
                            SqlParameter pCod_Motivo = new SqlParameter("@Cod_Motivo", SqlDbType.Int);
                            pCod_Motivo.Value = iCod_Motivo;
                            command2.Parameters.Add(pCod_Motivo);
                            //Setor
                            SqlParameter pCod_Setor = new SqlParameter("@Cod_Setor", SqlDbType.Int);
                            pCod_Setor.Value = iCod_Setor;
                            command2.Parameters.Add(pCod_Setor);
                            //Cliente
                            SqlParameter pCod_Cliente = new SqlParameter("@Cod_Cliente", SqlDbType.Int);
                            pCod_Cliente.Value = Convert.ToUInt32(txtCodCliente.Text.Trim());
                            command2.Parameters.Add(pCod_Cliente);

                            SqlParameter pCod_Transportadora = new SqlParameter("@Cod_Transportadora", SqlDbType.Int);
                            pCod_Transportadora.Value = Convert.ToInt16(txtCodTransportadora.Text.Trim());
                            command2.Parameters.Add(pCod_Transportadora);

                            //Retorno físico
                            SqlParameter pRetorno_Fisico = new SqlParameter("@Retorno_Fisico", SqlDbType.Int);
                            pRetorno_Fisico.Value = iRetorno_Fisico;
                            command2.Parameters.Add(pRetorno_Fisico);

                            //NF refatura
                            SqlParameter pNF_Refatura = new SqlParameter("@NF_Refatura", SqlDbType.Int);
                            pNF_Refatura.Value = Convert.ToInt32(txtNFrefatura.Text);
                            command2.Parameters.Add(pNF_Refatura);

                            //NF origem
                            SqlParameter pNF_Origem = new SqlParameter("@NF_Origem", SqlDbType.VarChar, 15);
                            pNF_Origem.Value = txtNForigem.Text;
                            command2.Parameters.Add(pNF_Origem);
                            //Observacao
                            SqlParameter pObservacao = new SqlParameter("@Observacao", SqlDbType.VarChar, 300);
                            pObservacao.Value = txtObservacao.Text;
                            command2.Parameters.Add(pObservacao);
                            //Usuario
                            SqlParameter pUsuario = new SqlParameter("@Usuario", SqlDbType.VarChar, 15);
                            pUsuario.Value = Usuario.userDesc;
                            command2.Parameters.Add(pUsuario);
                            //Tipo de operação
                            SqlParameter pStatus = new SqlParameter("@Status", SqlDbType.Char, 1);
                            pStatus.Value = cStatus;
                            command2.Parameters.Add(pStatus);

                            command2.ExecuteNonQuery();


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


                    //Alimentar CIDEV
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT TOP 1 Num_CI FROM UNIDB.[dbo].CITOP " +
                                                  " order by Num_CI desc ";

                            reader2 = command.ExecuteReader();

                            while (reader2.Read())
                            {
                                if (reader2["Num_CI"] != null)
                                {
                                    iNum_CI = Convert.ToInt32(reader2["Num_CI"].ToString());
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
                    foreach (var NF_Devolucao in lDevolucoes)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {

                            try
                            {
                                connectDMD.Open();
                                command = connectDMD.CreateCommand();
                                command.CommandText = " INSERT INTO UNIDB.[dbo].CIDEV " +
                                                      " (Num_CI,NF_Devolucao) " +
                                                      "VALUES (@Num_CI,@NF_Devolucao)";


                                //Tipo de operação
                                SqlParameter pNum_CI = new SqlParameter("@Num_CI", SqlDbType.Int);
                                pNum_CI.Value = iNum_CI;
                                command.Parameters.Add(pNum_CI);
                                //Motivo
                                SqlParameter pNF_Devolucao = new SqlParameter("@NF_Devolucao", SqlDbType.Int);
                                pNF_Devolucao.Value = NF_Devolucao;
                                command.Parameters.Add(pNF_Devolucao);


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

                    //Alimentar CIBOT
                    foreach (var NF_Devolucao in lDevolucoes)
                    {
                        lCod_Produto.Clear();
                        lPrc_Unitario.Clear();
                        lQtd_Produto.Clear();

                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command2 = connectDMD.CreateCommand();
                                command2.CommandText = " SELECT NUMERO,COD_PRODUTO,QTD_PEDIDO,PRC_UNITARIO FROM NFECB " +
                                                      " INNER JOIN NFEIT ON NFEIT.PROTOCOLO = NFECB.PROTOCOLO " +
                                                      " WHERE Cod_EmiCliente =" + txtCodCliente.Text +
                                                      " AND TIP_NF = 'D' AND STATUS = 'F'" +
                                                      " AND NUMERO = " + NF_Devolucao +
                                                      " order by Dat_Entrada desc ";

                                reader2 = command2.ExecuteReader();

                                while (reader2.Read())
                                {
                                    if (reader2["Numero"] != null)
                                    {
                                        lCod_Produto.Add(Convert.ToInt32(reader2["Cod_Produto"].ToString()));
                                        lPrc_Unitario.Add(Convert.ToDouble(reader2["Prc_Unitario"].ToString()));
                                        lQtd_Produto.Add(Convert.ToInt32(reader2["Qtd_Pedido"].ToString()));
                                        if (rdbNao.Checked == true)
                                        {
                                            lQuantidadeSemRetorno.Add(Convert.ToInt32(reader2["Qtd_Pedido"].ToString()));
                                        }
                                        else
                                        {
                                            lQuantidadeSemRetorno.Add(0);
                                        }

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

                        for (int x = 0; x < lPrc_Unitario.Count; x++)
                        {
                            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                            {
                                try
                                {
                                    connectDMD.Open();
                                    command = connectDMD.CreateCommand();
                                    command.CommandText = " INSERT INTO UNIDB.[dbo].CIBOT " +
                                                          " (Num_CI,NF_Devolucao,Cod_Produto,Qtd_ItemInicial,Qtd_ItemFinal,Prc_Unitario,Dat_Modificacao,Usuario) " +
                                                          "VALUES (@Num_CI,@NF_Devolucao,@Cod_Produto,@Qtd_ItemInicial,@Qtd_ItemFinal,@Prc_Unitario,GetDate(),@Usuario)";


                                    //Tipo de operação
                                    SqlParameter pNum_CI = new SqlParameter("@Num_CI", SqlDbType.Int);
                                    pNum_CI.Value = iNum_CI;
                                    command.Parameters.Add(pNum_CI);
                                    //Devolucao
                                    SqlParameter pNF_Devolucao = new SqlParameter("@NF_Devolucao", SqlDbType.Int);
                                    pNF_Devolucao.Value = NF_Devolucao;
                                    command.Parameters.Add(pNF_Devolucao);
                                    //Cod_Produto
                                    SqlParameter pCod_Produto = new SqlParameter("@Cod_Produto", SqlDbType.Int);
                                    pCod_Produto.Value = lCod_Produto[x];
                                    command.Parameters.Add(pCod_Produto);
                                    //Qtd_ItemInicial
                                    SqlParameter pQtd_ItemInicial = new SqlParameter("@Qtd_ItemInicial", SqlDbType.Int);
                                    pQtd_ItemInicial.Value = lQtd_Produto[x];
                                    command.Parameters.Add(pQtd_ItemInicial);
                                    //QTD_ITEMFINAL
                                    SqlParameter pQtd_ItemFinal = new SqlParameter("@Qtd_ItemFinal", SqlDbType.Int);
                                    pQtd_ItemFinal.Value = lQuantidadeSemRetorno[x];
                                    command.Parameters.Add(pQtd_ItemFinal);
                                    //Prc_Unitario
                                    SqlParameter pPrc_Unitario = new SqlParameter("@Prc_Unitario", SqlDbType.Int);
                                    pPrc_Unitario.Value = lPrc_Unitario[x];
                                    command.Parameters.Add(pPrc_Unitario);
                                    //@Usuario
                                    SqlParameter pUsuario = new SqlParameter("@Usuario", SqlDbType.VarChar, 15);
                                    pUsuario.Value = Usuario.userDesc;
                                    command.Parameters.Add(pUsuario);

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

            
            
            mMessage = "CI criada com sucesso";
                    mTittle = "CI";
                    mButton = MessageBoxButtons.OK;
                    mIcon = MessageBoxIcon.Information;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    this.Close();
                
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
        private void btnPreencherCliente_Click(object sender, EventArgs e)
        {
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
                            erro_DeAcesso(SQLe);
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
            frmCriarCi_EscolherTransportadora form = new frmCriarCi_EscolherTransportadora();            
            form.ShowDialog();
            if (form.cod_transportadora != 0)
                txtCodTransportadora.Text = Convert.ToString(form.cod_transportadora);
        }

        
        //Botão Criar Ci
        private void btnCriarCi_Click(object sender, EventArgs e)
        {
            
            validarCi();
                criarCI();                        
        }
      
        //Botão limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {

            //Limpar tipo de operação
            rdbDevParcial.Checked = false;
            rdbDevTotal.Checked = false;

            //Motivo
            cbxMotivo.Text = String.Empty;

            //Setor
            cbxSetor.Text = String.Empty;            

            //Limpar Cliente
            txtCodCliente.Text = String.Empty;
            txtCliente.Text = String.Empty;

            //Limpar Transportadora
            txtCodTransportadora.Text = String.Empty;
            txtTransportadora.Text = String.Empty;

            //Limpar Notas
            txtNForigem.Text = String.Empty;
            txtNFrefatura.Text = String.Empty;

            //Limpar observacao
            txtObservacao.Text = String.Empty;


            

        }
      

        //Limpar NF origem para escrever
        private void btnLimparNForigem_Click(object sender, EventArgs e)
        {
            txtNForigem.ReadOnly =false;
            txtNForigem.Text = String.Empty;
        }

    

        //Checked list box para NF de devolução
        //Alimenta o campo das notas de origem
        private void clbNFdevol_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
                if (e.NewValue == CheckState.Checked)
                {
                    lDevolucoes.Add(Convert.ToInt32(clbNFdevol.SelectedItem.ToString()));
                    //Olhar a partir dos canhotos
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT STR_RELDOC FROM NFECB " +

                                                  " WHERE numero =" + clbNFdevol.SelectedItem.ToString() +
                                                  " AND TIP_NF = 'D'" +
                                                  " order by Dat_Entrada desc ";

                            reader2 = command.ExecuteReader();

                            while (reader2.Read())
                            {
                                if (reader2["Str_RelDoc"] != null)
                                {
                                    if (!txtNForigem.Text.Trim().Equals(String.Empty) && !txtNForigem.Text.Equals(reader2["Str_RelDoc"].ToString()))
                                        txtNForigem.Text = txtNForigem.Text + ";" + (reader2["Str_RelDoc"].ToString());
                                    else
                                    {
                                        txtNForigem.Text = reader2["Str_RelDoc"].ToString();
                                    }
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
                    //Alimenta o campo transportadora
                    if (iNum_Nota != 0)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = "select cod_transp from dmd.dbo.NFECB where numero =" + iNum_Nota;


                                reader2 = command.ExecuteReader();

                                while (reader2.Read())
                                {
                                    if (reader2["cod_transp"] != null)
                                    {
                                        txtCodTransportadora.Text = reader2["cod_transp"].ToString();
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
                else if (e.NewValue == CheckState.Unchecked)
                {
                    lDevolucoes.Remove(Convert.ToInt32(clbNFdevol.SelectedItem.ToString()));
                    txtNForigem.Text = String.Empty;

                }
                 
        }

        private void cbxMotivo_SelectedIndexChanged(object sender, EventArgs e)
        {         
                //Resgatando login do usuario
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT Gera_Devolucao " +
                                              " FROM  UNIDB.[dbo].MOTIV " +
                                              " WHERE Desc_Motivo like '" + cbxMotivo.SelectedItem.ToString() + "'";
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Gera_Devolucao"] != null)
                            {
                                if (reader["Gera_Devolucao"].ToString() == "1")
                                {
                                    rdbSim.Checked = true;
                                }
                                else
                                {
                                    rdbNao.Checked = true;
                                }
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

        private void frmCriarCi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }



        //Alimenta o campo das devoluções
        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            clbNFdevol.Items.Clear();
            int controle=0;
            if (!txtCliente.Text.Equals(String.Empty))
            {           
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "SELECT NUMERO,TIP_NF FROM NFECB " +
                                                  " WHERE Cod_EmiCliente =" + txtCodCliente.Text +
                                                  " AND TIP_NF = 'D' AND Numero IS NOT NULL" +
                                                  " order by Dat_Entrada desc ";

                            reader2 = command.ExecuteReader();

                            while (reader2.Read())
                            {
                                if (reader2["Numero"] != null)
                                {
                                    //if (!lDevolucoesCheck.Contains(Convert.ToInt32(reader2["Numero"].ToString())))
                                    clbNFdevol.Items.Add(reader2["Numero"].ToString());

                                    if (controle == 0)
                                    {
                                        iNum_Nota = Convert.ToInt32(reader2["Numero"].ToString());
                                        controle++;
                                    }
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
