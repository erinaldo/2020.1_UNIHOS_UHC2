using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Canhotos.Ausencia_Canhotos;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Fretes.ConferenciaDeFretes;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Conferencia;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica
{
    public partial class frmLogistica : Form
    {
        public frmLogistica()
        {
            InitializeComponent();
        }

        private void frmLogistica_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            Carregar_Bloqueios();
            Carregar_Permissoes();
        }

        

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
        
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

        


        private void Carregar_Bloqueios()
        {
            //Canhotos
            lblAusenciaGeral.Enabled = false;
           
            //Fretes
            lblConferenciaFretes.Enabled = false;

            //CI
            lblConferenciaCI.Enabled = false;
            

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
                                              " WHERE Cod_Usuario = " + Usuario.userId;
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Cod_Usuario"] != null)
                            {
                                //Permissão para usuário
                                if (reader["Cod_Rotina"].ToString() == "3" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblConferenciaCI.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "19" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblConferenciaFretes.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "28" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    lblAusenciaGeral.Enabled = true;
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
        //Canhotos
        //Botão Relatório Ausência Geral de canhotos
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

        

      
        //Fretes

        //Botão para conferência de fretes
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


        //Botão fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        //Comunicação Interna (CI)

        //botão para Conferencia de CI

        private void lblConferenciaCI_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmConferenciaDeCi form = new frmConferenciaDeCi();            
            form.Show();

        }

        private void lblConferenciaCI_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblConferenciaCI.ForeColor = Color.White;
            lblConferenciaCI.BackColor = Color.Black;
        }

        private void lblConferenciaCI_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblConferenciaCI.ForeColor = Color.Black;
            lblConferenciaCI.BackColor = Color.Transparent;
        }


        private void frmLogistica_KeyDown(object sender, KeyEventArgs e)
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


        //Não se sabe se a log terá acesso a esta informação
        private void LblConferenciaFretes_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            this.Cursor = Cursors.Default;
        }


      



    }
}
