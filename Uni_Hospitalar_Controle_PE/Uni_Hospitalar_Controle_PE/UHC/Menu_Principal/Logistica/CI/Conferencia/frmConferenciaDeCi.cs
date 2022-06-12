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
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Conferencia
{
    public partial class frmConferenciaDeCi : Form
    {
        public frmConferenciaDeCi()
        {
            InitializeComponent();
        }

        private void frmConferenciaDeCi_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            filtrarDados();
            Carregar_Bloqueios();
            Carregar_Permissoes();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;
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
        
        private void Carregar_Bloqueios()
        {
            btnCriarCi.Enabled = false;
            dgvDados.Enabled = false;
            btnEditar.Enabled = false;

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
                                if (reader["Cod_Rotina"].ToString() == "6" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    btnCriarCi.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "4" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    dgvDados.Enabled = true;
                                }
                                if (reader["Cod_Rotina"].ToString() == "21" && reader["Status_Acesso"].ToString() == "1")
                                {
                                    btnEditar.Enabled = true;
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
        private void filtrarDados()
        {
            String filtro_NFDevolucao = null;
            String filtro_NFRefatura = null;
            String filtro_NOcorrencia = null;
            String filtro_NFOrigem = null;
            String filtro_Cliente = null;
            String filtro_Transportadora = null;            
            String filtro_Status = null;



            //Filtro NF devolução
            if (!txtNFdevol.Text.Equals(String.Empty))
            {
                filtro_NFDevolucao = " AND CID.NF_Devolucao LIKE '%" + txtNFdevol.Text + "%'";
            }

            //Filtro NF Refat
            if (!txtNFrefat.Text.Equals(String.Empty))
            {
                filtro_NFRefatura = " AND CIT.NF_Refatura LIKE '%" + txtNFrefat.Text + "%'";
            }

            //Filtro NF Origem
            if (!txtNF_Origem.Text.Equals(String.Empty))
            {
                filtro_NFOrigem =  " AND CIT.NF_origem LIKE '%"+txtNF_Origem.Text+"%'";
            }

            //N ocorrência
            if (!txtNocorrencia.Text.Equals(String.Empty))
            { 
                filtro_NOcorrencia = " AND CIT.Num_CI = " + txtNocorrencia.Text + "";
            }
            //Cliente
            if (!txtCliente.Text.Equals(String.Empty))
            {
                filtro_Cliente = " AND CLI.Codigo = " + txtCodCliente.Text + "";
            }

            //Transportadora
            if (!txtTransportadora.Text.Equals(String.Empty))
            {
                filtro_Transportadora = " AND TRA.Codigo = " + txtCodTransportadora.Text + "";
            }
            //Pendente

            filtro_Status = " AND CIT.Status IN ('0'";
            if (chkPendente.Checked)
            {
                filtro_Status = filtro_Status + ",'P'";
            }
            //Aguardando financeiro
            if (chkAguardandoFinanceiro.Checked)
            {
                filtro_Status = filtro_Status + " ,'A'";
            }
            //Concluídas
            if (chkConcluido.Checked)
            {
                filtro_Status = filtro_Status + " ,'C'";
            }
            filtro_Status = filtro_Status+" ) ";

                      
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT                                                                             "
                                                + "         CIT.Num_CI[Ocorrência]                                                     "
                                                + " 	   ,MOT.Desc_Motivo[Motivo]                                                      "
                                                + " 	   ,STO.Desc_Setor[Setor]                                                        "
                                                + "        ,CLI.Razao_Social[Cliente]                                                  "
                                                + " 	   ,TRA.Fantasia[Transportadora]                                                 "
                                                + "        ,[Operação] = CASE CIT.Tipo_Operacao                                        "
                                                + "                      WHEN 'T' THEN 'Devolução Total'                               "
                                                + "                      WHEN 'P'  THEN 'Devolução Parcial'                            "
                                                + "                      END                                                           "
                                                + " 	   ,[Retorno Físico] = CASE CIT.Retorno_Fisico                                   "
                                                + "                      WHEN '1' THEN 'Sim'                                           "
                                                + "                      WHEN '0'  THEN 'Não'                                          "
                                                + "                      END                                                           "
                                                + "  ,CIT.NF_Refatura[Nota de Refatura]                                                "
                                                + "  ,REPLACE(NF_origem, ',', '/')[Nota de Origem]                                     "
                                                + "  ,CIT.Dat_Entrada[Dat.Registro]                                                    "
                                                + "  ,CIT.Observacao                                                                   "
                                                + "  ,CIT.STATUS                                                                       "
                                                + "   FROM UNIDB.[dbo].CITOP CIT                                                       "
                                                + "   INNER JOIN UNIDB.[dbo].MOTIV MOT ON MOT.Cod_Motivo = CIT.Cod_Motivo              "
                                                + "   INNER JOIN UNIDB.[dbo].SETOR STO ON STO.Cod_Setor = CIT.Cod_Setor                "
                                                + "   INNER JOIN DMD.[dbo].CLIEN CLI ON CLI.Codigo = CIT.Cod_Cliente                   "
                                                + "   LEFT OUTER JOIN DMD.[dbo].TRANS TRA ON TRA.Codigo = CIT.Cod_Transportadora       "
                                                + "   left JOIN UNIDB.[dbo].CIDEV CID ON CID.Num_CI = CIT.Num_CI                      "
                                                + "   WHERE 1 = 1                                                                      "
                                                + filtro_NFDevolucao
                                                + filtro_NFRefatura
                                                + filtro_NOcorrencia
                                                + filtro_NFOrigem
                                                + filtro_Cliente
                                                + filtro_Transportadora
                                                + filtro_Status                                              
                                                ;


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
                            dgvDados.Columns[0].Width = 65;
                            dgvDados.Columns[2].Width = 230;
                            dgvDados.Columns[1].Width = 100;
                            dgvDados.Columns[3].Width = 280;
                            dgvDados.Columns[4].Width = 230;
                            dgvDados.Columns[6].Width = 55;
                            dgvDados.Columns[7].Width = 55;
                            dgvDados.Columns[8].Width = 55;
                            dgvDados.Columns[9].Width = 90;
                            dgvDados.Columns[10].Width = 30;


                        }
                    }
             
            
           
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (row.Cells[11].Value.ToString() == "A")
                {
                    row.DefaultCellStyle.BackColor = Color.DarkGray;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                if (Convert.ToDateTime(row.Cells[9].Value) < DateTime.Today.AddDays(-30))
                {
                        row.DefaultCellStyle.BackColor = Color.Red;
                }
                if(row.Cells[11].Value.ToString() == "C")
                {
                    row.DefaultCellStyle.BackColor = Color.DarkGreen;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }            
            }
        }


        //Botão pesquisar
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            filtrarDados();
            this.Cursor = Cursors.Default;
            
        }
       



        //Botão fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
      

        //Botão limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //Limpar Cliente
            txtCodCliente.Text = String.Empty;
            txtCliente.Text = String.Empty;

            //Limpar Transportadora
            txtCodTransportadora.Text = String.Empty;
            txtTransportadora.Text = String.Empty;

            //Limpar Notas
            txtNFdevol.Text = String.Empty;
            txtNFrefat.Text = String.Empty;
            txtNocorrencia.Text = String.Empty;

            
            
        }
       


        //Botão Criar Ci
        private void btnCriarCi_Click(object sender, EventArgs e)
        {
            
            
            frmCriarCi form = new frmCriarCi();
            
            form.ShowDialog();
            btnPesquisar_Click(form,new EventArgs());

            
        }
       

        //Group box status
        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {

            
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
                            erroSQLE(SQLe);
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
            if (form.cod_cliente!=0)
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
                            erroSQLE(SQLe);
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

        //Função para digitar somente números
        private void txt_DigitarNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        //Acessar os itens da CI
        private void dgvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            DataGridView.HitTestInfo hit = dgvDados.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                return;
            }
            if (dgvDados.CurrentRow.Cells[11].Value.ToString() == "P")
            {
                frmProdutosDaCi form = new frmProdutosDaCi();
                form.Cod_CI = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value);

                form.ShowDialog();
                btnPesquisar_Click(dgvDados, new EventArgs());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDados.CurrentRow.Selected == true)
            {
                frmEditarCi form = new frmEditarCi();

                form.pubiNum_Ci =  Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
                form.ShowDialog();
                frmConferenciaDeCi_Load(btnEditar,new EventArgs());
            }
            else
            {
                mMessage = "Selecione um item para editar.";
                mTittle = "Editar CI";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Exclamation;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            }
        }

        private void frmConferenciaDeCi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                
                frmLogistica form = new frmLogistica();

                form.Show();
                this.Close();
            }
        }

        private void DgvDados_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (row.Cells[11].Value.ToString() == "A")
                {
                    row.DefaultCellStyle.BackColor = Color.DarkGray;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
                if (Convert.ToDateTime(row.Cells[9].Value) < DateTime.Today.AddDays(-30))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                if (row.Cells[11].Value.ToString() == "C")
                {
                    row.DefaultCellStyle.BackColor = Color.DarkGreen;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }

            }
        }









        //Função para pesquisar com o Enter
        private void pesquisarComEnter_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPesquisar_Click(btnPesquisar, new EventArgs());
            }
        }
    }
}
