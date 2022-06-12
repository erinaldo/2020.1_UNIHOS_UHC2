using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI.Gerenciar_Encaminhamentos
{
    public partial class frmInserirEncaminhamento : Form
    {
        public frmInserirEncaminhamento()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand(); //Para comandos
                    
        private SqlDataAdapter adaptador;

        //Erro de acesso ao sql
        private void erro_DeAcesso(SqlException SQLe)
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
        

        //Criar motivo
        public void criarEncaminhamento()
        {
            if (txtDescricaoEncaminhamento.Text.Trim().Equals(String.Empty))
            {

                mMessage = "A descrição precisa estar preenchida!";
                mTittle = "Descrição do encaminhamento";
                mIcon = MessageBoxIcon.Exclamation;
                mButton = MessageBoxButtons.OK;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                return;
            }
            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {

                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = " INSERT INTO UNIDB.[dbo].ENCAN " +
                                              " (Desc_Encaminhamento) " +
                                              "VALUES (@Encaminhamento)";


                        //Adiciona login
                        SqlParameter pEncaminhamento = new SqlParameter("@Encaminhamento", SqlDbType.VarChar, 70);
                        pEncaminhamento.Value = txtDescricaoEncaminhamento.Text;
                        command.Parameters.Add(pEncaminhamento);

                        command.ExecuteNonQuery();

                        mMessage = "Encaminhamento inserido com sucesso!";
                        mTittle = "Encaminhamento";
                        mIcon = MessageBoxIcon.Information;
                        mButton = MessageBoxButtons.OK;
                        MessageBox.Show(mMessage, mTittle, mButton, mIcon);

                    }

                    catch (SqlException SQLe)
                    {
                        erro_DeAcesso(SQLe);

                    }
                    finally
                    {
                        connectDMD.Close();
                        exibirEncaminhamentosRecentes();
                    }

                }
         

        }

        //Visualizar motivos recentes
        public void exibirEncaminhamentosRecentes()
        {            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = "  SELECT top 5" +
                                              "  Cod_Encaminhamento [Codigo] " +
                                              " ,Desc_Encaminhamento [Encaminhamento] " +
                                              " FROM UNIDB.[dbo].ENCAN " +
                                              " ORDER BY Cod_Encaminhamento desc";
                        adaptador = new SqlDataAdapter(command);
                        DataTable tableDados = new DataTable();
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
                        dgvDados.Columns[0].Width = 60;
                        dgvDados.Columns[1].Width = 275;
                    }
                }
            
        }

        //Limpar dados
        public void limparDados()
        {
            txtDescricaoEncaminhamento.Text = String.Empty;            
        }

        //Botão para cancelar      

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInserirEncaminhamento_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
        }


        //Botão inserir encaminhamento
        private void btnInserirEncaminhamento_Click(object sender, EventArgs e)
        {
            
            this.Cursor = Cursors.WaitCursor;       
            criarEncaminhamento();
            this.Cursor = Cursors.Default;
            limparDados();
        }
       
    }
}
