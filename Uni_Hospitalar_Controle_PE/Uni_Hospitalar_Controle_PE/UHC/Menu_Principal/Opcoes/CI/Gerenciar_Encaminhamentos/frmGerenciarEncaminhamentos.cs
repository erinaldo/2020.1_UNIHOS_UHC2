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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI.Gerenciar_Encaminhamentos
{
    public partial class frmGerenciarEncaminhamentos : Form
    {
        public frmGerenciarEncaminhamentos()
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

        private int iVerifica_Ocorrencia;

        public int Unidade_Servidor;


        public void exibirEncaminhamentos()
        {            
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = "  SELECT Cod_Encaminhamento [Codigo] " +
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


        private void frmGerenciarEncaminhamentos_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            exibirEncaminhamentos();
        }

        //Botão fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {            
            this.Close();
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
                        command.CommandText = "SELECT Cod_Encaminhamento [Codigo] " +
                                              " FROM UNIDB.[dbo].CITOP " +
                                              " WHERE Cod_Encaminhamento = " + dgvDados.CurrentRow.Cells[0].Value.ToString();

                        reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.HasRows)
                            {
                                mMessage = "Encaminhamento associado a uma ocorrência, por favor entre em contato com o T.I através do nosso sistema de chamados.";
                                mTittle = "Encaminhamento";
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
                            frmEditarEncaminhamentos form = new frmEditarEncaminhamentos();
                            
                            form.pubsCod_Encaminhamento = dgvDados.CurrentRow.Cells[0].Value.ToString();
                            form.ShowDialog();
                            frmGerenciarEncaminhamentos_Load(dgvDados, new EventArgs());
                        }


                    }
                }                                       
        }


        //Botão inserir encaminhamento
        private void btnInserirEncaminhamento_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            frmInserirEncaminhamento form = new frmInserirEncaminhamento();            
            form.ShowDialog();
            this.Visible = true;
            exibirEncaminhamentos();
        }
      
    }
}
