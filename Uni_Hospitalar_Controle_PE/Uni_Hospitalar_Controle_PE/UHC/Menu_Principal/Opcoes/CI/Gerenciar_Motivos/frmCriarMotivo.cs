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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI.Gerenciar_Motivos
{
    public partial class frmCriarMotivo : Form
    {
        public frmCriarMotivo()
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

        

        //Variável de inserção
        int iMovimentaDevolucao = 1;

        //Load do form
        private void frmCriarMotivo_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            exibirMotivosRecentes();
        }


        //Criar motivo
        public void criarMotivo()
        {
            if (txtDescricaoMotivo.Text.Trim().Equals(String.Empty))
            {

                mMessage = "A descrição precisa estar preenchida!";
                mTittle = "Descrição do motivo";
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
                        command.CommandText = " INSERT INTO UNIDB.[dbo].MOTIV " +
                                              " (Desc_Motivo,Gera_Devolucao) " +
                                              "VALUES (@Motivo,@Movimenta_Devolucao)";


                        //Adiciona login
                        SqlParameter pMotivo = new SqlParameter("@Motivo", SqlDbType.VarChar, 70);
                        pMotivo.Value = txtDescricaoMotivo.Text;
                        command.Parameters.Add(pMotivo);

                        //Parâmetro Movimenta_Devolucao
                        SqlParameter pMovimentaDevolucao = new SqlParameter("@Movimenta_Devolucao", SqlDbType.Int);
                        pMovimentaDevolucao.Value = iMovimentaDevolucao;
                        command.Parameters.Add(pMovimentaDevolucao);

                        command.ExecuteNonQuery();

                        mMessage = "Motivo inserido com sucesso!";
                        mTittle = "Motivo";
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
                        exibirMotivosRecentes();
                    }

                }
            
            
        }

        //Visualizar motivos recentes
        public void exibirMotivosRecentes()
        {
      
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = "  SELECT top 5" +
                                              "  Cod_Motivo [Codigo] " +
                                              " ,Desc_Motivo [Motivo] " +
                                              " ,[Movimenta devolução] = CASE Gera_Devolucao " +
                                              "                         WHEN 1 THEN 'Sim' " +
                                              "                         WHEN 0 THEN 'Não' " +
                                              " END " +
                                              " FROM UNIDB.[dbo].MOTIV " +
                                              " ORDER BY Cod_Motivo desc";
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
                        dgvDados.Columns[2].Width = 70;
                    }
                }            
        
        }

        //Limpar dados
        public void limparDados()
        {
            txtDescricaoMotivo.Text = String.Empty;
            chkMovimentaDevolucao.Checked = true;
            iMovimentaDevolucao = 1;
        }


        //Botão para criar motivo
       
        private void btnCriarMotivo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            criarMotivo();
            this.Cursor = Cursors.Default;
            limparDados();


        }

        private void chkMovimentaDevolucao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMovimentaDevolucao.Checked == false)
            {
                iMovimentaDevolucao = 0;
            }
            else
            {
                iMovimentaDevolucao = 1;
            }
        }


        //Botão para cancelar
      
      

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

    }
}
