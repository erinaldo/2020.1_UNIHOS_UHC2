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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci
{
    public partial class frmCriarCi_EscolherCliente : Form
    {
        public frmCriarCi_EscolherCliente()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataAdapter adaptador;
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
        private DialogResult options;

        //Variável para alocação do código do cliente para o form anterior
        public int cod_cliente;        
        int iControle = 0;
        //Carrega informações iniciais
        private void carregarInformacoes()
        {
            cbxOpcoesDePesquisa.Text = "Razão Social";
            cbxOpcoesDePesquisa.Items.Add("Razão Social");
            cbxOpcoesDePesquisa.Items.Add("Nome fantasia");
            cbxOpcoesDePesquisa.Items.Add("CNPJ");
        }





        //Botão de pesquisa (Preencher cliente)
        private void btnPreencherCliente_Click(object sender, EventArgs e)
        {

            //Pesquisa condicional do cliente
            //Pesquisa pela razão social

           
                if (cbxOpcoesDePesquisa.Text.Equals("Razão Social") || cbxOpcoesDePesquisa.SelectedItem.Equals("Razão Social"))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "   SELECT C.Codigo [Codigo]" +
                                                  "  ,C.Razao_Social [Razao Social]" +
                                                  "  ,C.cgc_cpf [CNPJ]" +
                                                  "   FROM CLIEN C" +
                                                  "   WHERE C.Razao_Social like '%" + txtDescricaoOpcao.Text.Trim() + "%'";

                            adaptador = new SqlDataAdapter(command);
                            System.Data.DataTable tableDados = new System.Data.DataTable();
                            adaptador.Fill(tableDados);
                            dgvDados.DataSource = tableDados;

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
                //Pesquisa pelo nome fantasia
                else if (cbxOpcoesDePesquisa.Text.Equals("Nome Fantasia"))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "   SELECT C.Codigo [Codigo]" +
                                                  "  ,C.Razao_Social [Razao Social]" +
                                                  "  ,C.cgc_cpf [CNPJ]" +
                                                  "   FROM CLIEN C" +
                                                  "   WHERE C.Razao_Social like '%" + txtDescricaoOpcao.Text.Trim() + "%'";

                            adaptador = new SqlDataAdapter(command);
                            System.Data.DataTable tableDados = new System.Data.DataTable();
                            adaptador.Fill(tableDados);
                            dgvDados.DataSource = tableDados;

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
                //Pesquisa pelo CNPJ
                else
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "   SELECT C.Codigo [Codigo]" +
                                                  "  ,C.Razao_Social [Razao Social]" +
                                                  "  ,C.cgc_cpf [CNPJ]" +
                                                  "   FROM CLIEN C" +
                                                  "   WHERE C.cgc_cpf like '%" + txtDescricaoOpcao.Text.Trim() + "%'";

                            adaptador = new SqlDataAdapter(command);
                            System.Data.DataTable tableDados = new System.Data.DataTable();
                            adaptador.Fill(tableDados);
                            dgvDados.DataSource = tableDados;

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
            dgvDados.Columns[0].Width = 40;
            dgvDados.Columns[1].Width = 320;
            dgvDados.Columns[2].Width = 120;
        }


        //Load do form
        private void frmCriarCi_EscolherCliente_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            carregarInformacoes();
        }

        //Salva a informação selecionada no GRID        
        private void dgvDados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            cod_cliente = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
            lblCliente.Text = dgvDados.CurrentRow.Cells[1].Value.ToString();
        }

        //txtDescricaoOpcao pesquisar com Enter       
        private void txtDescricaoOpcao_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPreencherCliente_Click(btnPreencherCliente, new EventArgs());
            }
        }

        private void DgvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnConfirmar_Click(dgvDados, new EventArgs());
        }

        private void FrmCriarCi_EscolherCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {

                this.Close();

            }
        }

        private void FrmCriarCi_EscolherCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            if (iControle == 0)
                cod_cliente = 0;
        }

        private void TxtDescricaoOpcao_TextChanged(object sender, EventArgs e)
        {
            btnPreencherCliente_Click(txtDescricaoOpcao, new EventArgs());
        }



        //Botão para Confirmar
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            mMessage = "Você escolheu o código " + cod_cliente.ToString() + ", do Cliente, " + lblCliente.Text.ToString() + ", deseja continuar?";
            mTittle = "Seleção de cliente";
            mIcon = MessageBoxIcon.Asterisk;
            mButton = MessageBoxButtons.YesNo;

            options = MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            if (options == DialogResult.No)
                return;
            else
            {
                iControle = 1;
                this.Close();
            }
        }
      
    }
}
