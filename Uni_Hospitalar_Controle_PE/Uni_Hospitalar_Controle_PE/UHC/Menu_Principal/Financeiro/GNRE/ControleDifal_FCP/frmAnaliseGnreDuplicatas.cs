using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.GNRE.ControleDifal_FCP
{
    public partial class frmAnaliseGnreDuplicatas : Form
    {
        public frmAnaliseGnreDuplicatas()
        {
            InitializeComponent();
        }
       
        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataAdapter adaptador;
        SqlDataReader reader;

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

        private List<string> lNum_Nota = new List<string>();                        
        private List<string> lStatus = new List<string>();
        private List<string> lEstado = new List<string>();
        private List<string> lDuplicatas = new List<string>();


        public String pubsNum_Nota;
        public String pubsUF;
        public DateTime pubdtDt_Emissao;
        public int Unidade_Servidor;

        //Load do form
        private void frmAnaliseGnreDuplicatas_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            Configuracao_Inicial();
            Exibe_Duplicata();

            //Função bloqueada
            txtObservacao.Enabled = false;
        }

        //Configurações iniciais
        private void Configuracao_Inicial()
        {
            lblNota.Text = "Nota " + pubsNum_Nota;
            txtUF.Text = pubsUF;
            txtDatEmissao.Text = pubdtDt_Emissao.ToString();
        }
      
        private void Exibe_Duplicata()
        {          
                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {

                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText = "select		 Num_Docume [Duplicata], " +
                                                " [Vlr.Difal] = CASE NUM_DOCUME " +
                                                " WHEN @num_nota THEN(Cast(Round(CP.Val_Docume,2) as money)) " +
                                                " WHEN @num_nota+'/1' THEN(Cast(Round(CP.Val_Docume, 2) as money)) " +
                                                " WHEN @num_nota+'-1' THEN(Cast(Round(CP.Val_Docume, 2) as money)) " +
                                                " else (Cast(Round(0, 2) as money)) " +
                                                " end " +
                                                " ,[Vlr.FCP] = CASE NUM_DOCUME " +
                                                " WHEN @num_nota+'/2' THEN(Cast(Round(CP.Val_Docume,2) as money)) " +
                                                " WHEN @num_nota+'-2' THEN(Cast(Round(CP.Val_Docume,2) as money)) " +
                                                " else (Cast(Round(0,2) as money))	" +
                                                " end   " +
                                                " ,[Pagamento] = Cast(Dat_Quitac as date) " +
                                               " FROM dmd.dbo.pagct CP " +
                            " WHERE CP.Num_NotOri IS NULL" +
                            " AND CP.Sta_Docume = 'Q' " +
                            " AND CP.Cod_Favore = 0037" +
                            " AND CP.Tip_Docume<> 'F'  " +
                            " AND CP.Num_Docume LIKE @NUM_NOTA+'%'";
                        command.Parameters.AddWithValue("NUM_NOTA", pubsNum_Nota);

                        reader = command.ExecuteReader();

                        reader.Close();



                        adaptador = new SqlDataAdapter(command);
                        DataTable tableDados = new DataTable();
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

        //Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Fechar com Esc
        private void frmAnaliseGnreDuplicatas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }
    }
        
    }

