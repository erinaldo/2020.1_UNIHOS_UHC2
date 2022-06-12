using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulib;
using System.Windows.Forms;
using Uni_Hospitalar_Controle_PE.Background_Software;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Precificacao
{
    public partial class frmPesquisarFabricante : Form
    {
        public frmPesquisarFabricante()
        {
            InitializeComponent();
        }
        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataAdapter adaptador;

        public int Unidade_Sevidor;

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

        private void FrmPesquisarProduto_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            txtDescricaoOpcao.Focus();
        }

        public int Cod_Fabricante;
        int iControle;
        private void DgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cod_Fabricante = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
            lblFabricanteSelecionado.Text = "Fabricante selecionado: "+dgvDados.CurrentRow.Cells[1].Value.ToString();
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            mMessage = "Você escolheu o código " + Cod_Fabricante.ToString() + ", do Cliente, " + dgvDados.CurrentRow.Cells[1].Value.ToString()+ ", deseja continuar?";
            mTittle = "Seleção de Fabricante";
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

        private void DgvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BtnConfirmar_Click(dgvDados, new EventArgs());
        }

        private void FrmPesquisarFabricante_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (iControle == 0)
                txtDescricaoOpcao.Text = String.Empty;
            
        }

        private void FrmPesquisarFabricante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }

        private void TxtDescricaoOpcao_TextChanged(object sender, EventArgs e)
        {
           using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = "   SELECT  Codigo [Codigo]" +
                                              "  ,Fantasia [Fantasia]" +
                                              "   FROM FABRI" +
                                              "   WHERE Fantasia like '%" + txtDescricaoOpcao.Text.Trim() + "%'";

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
    }
}
