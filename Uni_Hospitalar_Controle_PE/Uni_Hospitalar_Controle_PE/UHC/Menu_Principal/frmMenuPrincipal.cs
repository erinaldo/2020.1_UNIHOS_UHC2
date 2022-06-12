using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;
using Uni_Hospitalar_Controle_PE.UHC.Login;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Gerencial;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal
{
    public partial class frmMenuPrincipal : Form
    {
              
        public frmMenuPrincipal()
        {
            InitializeComponent();

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

        //Configurações Iniciais

        private void configuracoes_Iniciais()
        {
            this.Icon = Properties.Resources.Icon_Uni;
            
            if (Usuario.unidade_Login == 1)
            {
                lblEmpresa.Text = "Sessão: Uni Hosptialar LTDA";
            }
            else if (Usuario.unidade_Login == 2)
            {
                lblEmpresa.Text = "Sessão: Uni Ceará";
            }
            else if (Usuario.unidade_Login == 3)
            {
                lblEmpresa.Text = "Sessão: SP Hospitalar";
            }

            //Parâmetros para data e hora
            lblDiaMes.Text = (DateTime.Now.Day.ToString() + " de " + DateTime.Now.mes_PorEscrito());
            lblAno.Text = DateTime.Now.Year.ToString();
            lblUsuarioLogado.Text = "Usuário: " + Usuario.userDesc;

            Carregar_Bloqueios();
            Carregar_Permissoes();
        }
                            
        //Bloqueios
        private void Carregar_Bloqueios()
        {
            btnFinanceiro.Enabled = false;            
            btnLogistica.Enabled = false;            
            btnLicitacao.Enabled = false;            
            btnAdministrativo.Enabled = false;           
            btnVendas.Enabled = false;            
            btnGerencial.Enabled = false;           
            btnOpcoes.Enabled = false;            


        }
        //Permissões
        private void Carregar_Permissoes()
        {         
                //Resgatando login do usuario
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT Cod_Usuario " +
                                              " FROM  UNIDB.[dbo].USUAR " +
                                              " WHERE Login_Usuario like '" + Usuario.userDesc + "'";
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader["Cod_Usuario"] != null)
                            {
                                Usuario.userId = Convert.ToInt32(reader["Cod_Usuario"].ToString());
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
                                if (reader["Cod_Rotina"].ToString() == "7" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    btnFinanceiro.Enabled = true;                                    

                                }
                                //Permissão para setor
                                if (reader["Cod_Rotina"].ToString() == "8" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    btnLogistica.Enabled = true;                                    
                                }
                                if (reader["Cod_Rotina"].ToString() == "9" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    btnLicitacao.Enabled = true;                                    
                                }
                                if (reader["Cod_Rotina"].ToString() == "10" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    btnAdministrativo.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "11" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    btnVendas.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "12" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    btnOpcoes.Enabled = true;                                    
                                }
                                if (reader["Cod_Rotina"].ToString() == "42" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    btnGerencial.Enabled = true;                                    
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
      
        //Load form principal
        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            configuracoes_Iniciais();
        }

        //Controlador datetime
        private void Hour_Tick(object sender, EventArgs e)
        {
          txtRelogio.Text = DateTime.Now.ToLongTimeString();          
        }

        private void pcbSuporte_Click(object sender, EventArgs e)
        {
            // Navigate to a URL.
            System.Diagnostics.Process.Start("http://10.5.1.20/glpi/");
        }

        //Botão deslogar (Trocar usuário)


        private void abrir_TelaLogin()
        {
            Application.Run(new frmLogin());
        }

        private void btnDeslogar_Click(object sender, EventArgs e)
        {            
            this.Visible = false;
            Thread t1 = new Thread(abrir_TelaLogin);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
            
        }        


        

        //Botao Financeiro
    
        private void btnFinanceiro_Click(object sender, EventArgs e)
        {                        
            frmFinanceiro form = new frmFinanceiro();                        
            form.Show();
            
        }

        //Botao Logística

        private void btnLogistica_Click(object sender, EventArgs e)
       {
            this.Cursor = Cursors.WaitCursor;
            frmLogistica form = new frmLogistica();                   
            form.Show();
            this.Cursor = Cursors.Default;

        }

        //Botão Administrativo  
        private void btnAdministrativo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmAdministrativo form = new frmAdministrativo();
                        
            form.Show();
            this.Cursor = Cursors.Default;
        }
        
        //Botão licitacao


        
        //Botão vendas
        private void BtnVendas_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmVendas form = new frmVendas();                        
            form.Show();
            this.Cursor = Cursors.Default;
        }       

        //Botão opções
        private void btnOptions_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmOpcoes form = new frmOpcoes();                        
            form.Show();
            this.Cursor = Cursors.Default;

        }


        //Btn Gerencial
        private void btnGerencial_Click(object sender, EventArgs e)
        {
            frmGerencial form = new frmGerencial();

            form.Show();
        }




        //Botão fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {            
            Application.Exit();
        }
        

    
    }
}
