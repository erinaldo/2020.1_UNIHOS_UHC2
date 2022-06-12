using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Setores;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Usuarios;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Canhotos;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.CI.Gerenciar_Encaminhamentos;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Fretes.Configuracoes_Fretes;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes
{
    public partial class frmOpcoes : Form
    {
        public frmOpcoes()
        {
            InitializeComponent();
        }

        //Load do form
        private void frmOpcoes_Load(object sender, EventArgs e)
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
            lblSetores.Enabled = false;
            lblUsuarios.Enabled = false;
            lblMotivos.Enabled = false;
            lblEncaminhamentos.Enabled = false;
            lblConfigurar_Percentual.Enabled = false;
            lblCadastrarEmailTransp.Enabled = false;
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
                                if (reader["Cod_Rotina"].ToString() == "13")
                                {
                                    lblUsuarios.Enabled = true;
                                }
                                //Permissão para setor
                                if (reader["Cod_Rotina"].ToString() == "14")
                                {
                                    lblSetores.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "15")
                                {
                                    lblMotivos.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "16")
                                {
                                    lblEncaminhamentos.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "37")
                                {
                                    lblConfigurar_Percentual.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "38")
                                {
                                    lblCadastrarEmailTransp.Enabled = true;
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

        public String pubsLogin_Usuario;
        

        //CI
        //Botão para Gerenciar motivos CI
        private void lblMotivos_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblMotivos.ForeColor = Color.White;
            lblMotivos.BackColor = Color.Black;
        }
        private void lblMotivos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblMotivos.ForeColor = Color.Black;
            lblMotivos.BackColor = Color.Transparent;
        }
        private void lblMotivos_Click(object sender, EventArgs e)
        {
            frmGerenciarMotivos form = new frmGerenciarMotivos();            
            form.ShowDialog();

        }
        private void lblEncaminhamentos_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblEncaminhamentos.ForeColor = Color.White;
            lblEncaminhamentos.BackColor = Color.Black;
        }
        private void lblEncaminhamentos_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblEncaminhamentos.ForeColor = Color.Black;
            lblEncaminhamentos.BackColor = Color.Transparent;
        }
        private void lblEncaminhamentos_Click(object sender, EventArgs e)
        {
            frmGerenciarEncaminhamentos form = new frmGerenciarEncaminhamentos();            
            form.ShowDialog();

        }




        //Admin       

        //Botão para gerenciar os setores
        private void lblSetores_Click(object sender, EventArgs e)
        {
            frmGerenciarSetores form = new frmGerenciarSetores();
            this.Visible = false;            
            form.ShowDialog();
            this.Visible = true;
        }
        private void lblSetores_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblSetores.ForeColor = Color.White;
            lblSetores.BackColor = Color.Black;
        }
        private void lblSetores_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblSetores.ForeColor = Color.Black;
            lblSetores.BackColor = Color.Transparent;
        }
      
    
        //Botão para gerenciar os usuários
        private void lblUsarios_MouseClick(object sender, EventArgs e)
        {

            frmUsuarios form = new frmUsuarios();            
            this.Visible = false;
            form.ShowDialog();
            this.Visible = true;
        }
        private void lblUsuarios_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblUsuarios.ForeColor = Color.White;
            lblUsuarios.BackColor = Color.Black;
        }
        private void lblUsuarios_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblUsuarios.ForeColor = Color.Black;
            lblUsuarios.BackColor = Color.Transparent;

        }

       

        private void lblConfigurar_Percentual_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblConfigurar_Percentual.ForeColor = Color.White;
            lblConfigurar_Percentual.BackColor = Color.Black;
        }

        private void lblConfigurar_Percentual_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblConfigurar_Percentual.ForeColor = Color.Black;
            lblConfigurar_Percentual.BackColor = Color.Transparent;
        }

        private void lblConfigurar_Percentual_Click(object sender, EventArgs e)
        {
            frmConfigurar_Percentual form = new frmConfigurar_Percentual();            
            this.Visible = false;
            form.ShowDialog();
            this.Visible = true;

        }





        //Canhotos
        private void lblCadastrarEmailTransp_Click(object sender, EventArgs e)
        {
            frmCadastrarEmailTransportadora form = new frmCadastrarEmailTransportadora();
            
            form.Show();


        }

        private void lblCadastrarEmailTransp_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblCadastrarEmailTransp.ForeColor = Color.White;
            lblCadastrarEmailTransp.BackColor = Color.Black;
        }

        private void lblCadastrarEmailTransp_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblCadastrarEmailTransp.ForeColor = Color.Black;
            lblCadastrarEmailTransp.BackColor = Color.Transparent;
        }



        //Botão fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        //Fechar com esc
        private void FrmOpcoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

    }
}
