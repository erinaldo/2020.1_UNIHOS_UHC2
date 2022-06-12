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

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Opcoes.Admin.Usuarios
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }
        //SQL
        private SqlCommand command = new SqlCommand();
        SqlDataAdapter adaptador;
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

        //public int Unidade_Servidor;


        //Função que carrega os usuários no DGV
        private void Carregar_Usuarios()
        {
           
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                        command.CommandText = " SELECT " +
                                              " U.Cod_Usuario [Código]," +
                                              " U.Nome_Usuario [Nome], " +
                                              " S.Desc_Setor [Setor], " +
                                              " U.Login_Usuario [Login] " +
                                              " FROM UNIDB.[dbo].USUAR U " +
                                              " INNER JOIN UNIDB.[dbo].SETOR S ON S.COD_SETOR = U.COD_SETOR";
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
                        dgvDados.Columns[0].Width = 60;
                        dgvDados.Columns[1].Width = 230;
                        dgvDados.Columns[2].Width = 100;
                        dgvDados.Columns[3].Width = 100;
                    }
                }
            
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            Carregar_Usuarios();
        }

        //Editar com Duplo Clique
        private void dgvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmEditarUsuario form = new frmEditarUsuario();            
            form.pubsCod_Usuario = Convert.ToInt32(dgvDados.CurrentRow.Cells[0].Value.ToString());
            form.ShowDialog();
            frmUsuarios_Load(dgvDados,new EventArgs());
            
        }

        //Botão inserir
        private void btnInserir_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            
            frmInserirUsuario form = new frmInserirUsuario();
            
            form.ShowDialog();
            frmUsuarios_Load(form,new EventArgs());
            
        }

        private void frmUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            } 
        }


        //Botão fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
       

       
    }
}
