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
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Canhotos.Ausencia_Canhotos;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Canhotos.Controle_Canhotos;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Fretes.ConferenciaDeFretes;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo
{
    public partial class frmAdministrativo : Form
    {
        public frmAdministrativo()
        {
            InitializeComponent();
        }


        private void frmAdministrativo_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            Carregar_Bloqueios();
            Carregar_Permissoes();
        }
        

        //SQL
        private SqlCommand command = new SqlCommand(); //Para comandos     
        private SqlDataReader reader;
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
        
        private void Carregar_Bloqueios()
        {

            //Canhotos
            lblAusenciaGeral.Enabled = false;           
            lblControleCanhotos.Enabled = false;

            //Fretes
            lblConferenciaFretes.Enabled = false;
            lblInfo.Enabled = false;
            lblManutencao.Enabled = false;
            lblConversorParaLayout.Enabled = false;

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
                                if (reader["Cod_Rotina"].ToString() == "19" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblConferenciaFretes.Enabled = true;
                                    lblConversorParaLayout.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "27" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblControleCanhotos.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "28" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblAusenciaGeral.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "39" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblInfo.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "41" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblManutencao.Enabled = true;
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


        //Canhotos

        //Botão ausência geral
        private void lblAusenciaGeral_MouseHover(object sender, EventArgs e)
        {

            this.Cursor = Cursors.Hand;
            lblAusenciaGeral.ForeColor = Color.White;
            lblAusenciaGeral.BackColor = Color.Black;
        }
        private void lblAusenciaGeral_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblAusenciaGeral.ForeColor = Color.Black;
            lblAusenciaGeral.BackColor = Color.Transparent;
        }

 

        private void LblControleCanhotos_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmControleCanhotos form = new frmControleCanhotos();            
            form.Show();
            this.Cursor = Cursors.Default;
        }

        //Controle canhotos
        private void lblControleCanhotos_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblControleCanhotos.ForeColor = Color.White;
            lblControleCanhotos.BackColor = Color.Black;
        }
        private void lblControleCanhotos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblControleCanhotos.ForeColor = Color.Black;
            lblControleCanhotos.BackColor = Color.Transparent;
        }

        //Fretes

        //Conferencia de fretes
        private void lblConferenciaFretes_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblConferenciaFretes.ForeColor = Color.White;
            lblConferenciaFretes.BackColor = Color.Black;
        }
        private void lblConferenciaFretes_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblConferenciaFretes.ForeColor = Color.Black;
            lblConferenciaFretes.BackColor = Color.Transparent;
        }

        private void lblConferenciaFretes_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            frmNewConferenciaFretes form = new frmNewConferenciaFretes();            
            form.Show();
            this.Cursor = Cursors.Default;
        }

        //Info frete
        private void lblInfo_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblInfo.ForeColor = Color.White;
            lblInfo.BackColor = Color.Black;
        }
        private void lblInfo_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblInfo.ForeColor = Color.Black;
            lblInfo.BackColor = Color.Transparent;
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            frmInfoFretes form = new frmInfoFretes();
            form.Show();
            this.Cursor = Cursors.Default;
        }


        //Manutencao frete
        private void lblManutencao_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblManutencao.ForeColor = Color.White;
            lblManutencao.BackColor = Color.Black;
        }
        private void lblManutencao_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblManutencao.ForeColor = Color.Black;
            lblManutencao.BackColor = Color.Transparent;
        }
        private void lblManutencao_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmManutencaoFretes form = new frmManutencaoFretes();
            form.Show();
            this.Cursor = Cursors.Default;
        }


        //ConversorParaLayout
        private void lblConversorParaLayout_Click(object sender, EventArgs e)
        {
            frmConversorLayout form = new frmConversorLayout();
            form.Show();
        }
        private void lblConversorParaLayout_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblConversorParaLayout.ForeColor = Color.White;
            lblConversorParaLayout.BackColor = Color.Black;
        }
        private void lblConversorParaLayout_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblConversorParaLayout.ForeColor = Color.Black;
            lblConversorParaLayout.BackColor = Color.Transparent;
        }



        private void frmAdministrativo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void LblAusenciaGeral_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmAusenciaCanhotos form = new frmAusenciaCanhotos();
            form.Show();
            this.Cursor = Cursors.Default;
        }

        






        //Botão fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }      

    }
}
