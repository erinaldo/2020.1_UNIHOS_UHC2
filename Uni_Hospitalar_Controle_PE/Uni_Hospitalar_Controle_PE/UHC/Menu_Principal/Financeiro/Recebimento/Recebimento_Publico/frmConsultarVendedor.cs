using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Recebimento.Recebimento_Publico
{
    public partial class frmConsultarVendedor : Form
    {
        public frmConsultarVendedor()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataAdapter adaptador;

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

        private void frmConsultarVendedor_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            txtDescricaoOpcao.Focus();
        }

        public int Cod_Vendedor;
        public int Unidade_Servidor;
        int iControle;

        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cod_Vendedor = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
            lblVendedorSelecionado.Text = "Vendedor selecionado: " + dgvDados.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            mMessage = "Você escolheu o código " + Cod_Vendedor.ToString() + ", do Cliente, " + dgvDados.CurrentRow.Cells[1].Value.ToString() + ", deseja continuar?";
            mTittle = "Seleção de Vendedor";
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

        private void dgvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnConfirmar_Click(dgvDados, new EventArgs());
        }

        private void frmConsultarVendedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (iControle == 0)
                txtDescricaoOpcao.Text = String.Empty;
        }

        

        private void txtDescricaoOpcao_TextChanged(object sender, EventArgs e)
        {
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = "   SELECT  Codigo [Codigo]" +
                                              "  ,Nome_Guerra [Descricao]" +
                                              "   FROM VENDE" +
                                              "   WHERE Nome_Guerra like '%" + txtDescricaoOpcao.Text.Trim() + "%'";

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
                    dgvDados.Columns[0].Width = 40;
                    dgvDados.Columns[1].Width = 320;

                }
            

        }
        
        //Fechar com Esc
        private void frmConsultarVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }
    }
}
