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
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI.Gerenciar_Motivos;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI
{
    public partial class frmGerenciarMotivos : Form
    {
        public frmGerenciarMotivos()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand(); //Para comandos
        private SqlDataReader reader;
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

        public int Unidade_Servidor;
        
        private int iVerifica_Ocorrencia;
        


        //Visualizar motivos recentes
        public void exibirMotivos()
        {
         
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = "  SELECT Cod_Motivo [Codigo] " +
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

        //Load do form
        private void frmGerenciarMotivos_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            exibirMotivos();
        }

        //Botão para criar motivo
       
        private void btnCriarMotivo_Click(object sender, EventArgs e)
        {

            
            this.Visible = false;
            frmCriarMotivo form = new frmCriarMotivo();
            
            form.ShowDialog();
            this.Visible = true;
            exibirMotivos();
        }

        private void dgvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {         
                iVerifica_Ocorrencia = 0;
                //Verifica se existe ocorrência
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = "SELECT Cod_Motivo [Codigo] " +
                                              " FROM UNIDB.[dbo].CITOP " +
                                              " WHERE COD_MOTIVO = " + dgvDados.CurrentRow.Cells[0].Value.ToString();

                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                mMessage = "Motivo associado a uma ocorrência, por favor entre em contato com o T.I através do nosso sistema de chamados.";
                                mTittle = "Motivo";
                                mButton = MessageBoxButtons.OK;
                                mIcon = MessageBoxIcon.Information;
                                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                                iVerifica_Ocorrencia = 1;
                                break;


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
                        if (iVerifica_Ocorrencia == 0)
                        {
                            frmEditarMotivo form = new frmEditarMotivo();
                            form.pubsCod_Motivo = dgvDados.CurrentRow.Cells[0].Value.ToString();                            
                            form.ShowDialog();
                            frmGerenciarMotivos_Load(dgvDados, new EventArgs());
                        }


                    
                }
            }
        

        }

        //Botão fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
       

      
    }
}
