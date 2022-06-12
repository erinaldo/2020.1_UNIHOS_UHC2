using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Administrativo.Fretes.ConferenciaDeFretes
{
    public partial class frmConversorLayout : Form
    {
        public frmConversorLayout()
        {
            InitializeComponent();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFrete = new OpenFileDialog();
            ofdFrete.Filter = "Documento Excel|*.xlsx";

            ofdFrete.ShowDialog();

         


            if (!ofdFrete.FileName.ToString().Equals(String.Empty))
            {
                String arquivo = ofdFrete.FileName.ToString();
                lblNomeArquivo.Text = ofdFrete.FileName.ToString();
                string strConexao = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=0\"", arquivo);
                OleDbConnection conn = new OleDbConnection(strConexao);
                conn.Open();
                DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                //Cria o objeto dataset para receber o conteúdo do arquivo Excel
                DataSet output = new DataSet();
                foreach (DataRow row in dt.Rows)
                {
                    // obtem o noma da planilha corrente
                    string sheet = row["TABLE_NAME"].ToString();
                    // obtem todos as linhas da planilha corrente
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                    cmd.CommandType = CommandType.Text;
                    // copia os dados da planilha para o datatable
                    DataTable outputTable = new DataTable(sheet);
                    output.Tables.Add(outputTable);
                    new OleDbDataAdapter(cmd).Fill(outputTable);
                }
                dgvDados.DataSource = output.Tables[0];
                dgvDados.AutoGenerateColumns = true;
            }

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter sw = null;
            //Caractere delimitador
            //string delimitador = "\t"; //tab

            //Escolher onde salvar o arquivo
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.FileName = "Arquivo.txt";
            sfd.Filter = "Arquivo de texto (*.txt)|*.txt";            
                //Se usuário escolher nome corretamente e clicar em salvar
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Pega o caminho do arquivo
                        string caminho = sfd.FileName;
                        //Cria um StreamWriter no local
                        sw = new System.IO.StreamWriter(caminho);
                        
                        int qtdColunas = dgvDados.Columns.Count;
                        //Loop em todas as linhas para escrever na stream já com o delimitador.
                        foreach (DataGridViewRow dgvLinha in dgvDados.Rows)
                        {
                        string linha = null;
                        for (int i = 0; i < qtdColunas; i++)
                            {
                            if (dgvLinha.Cells[i].Value != null)
                            {

                                int y = 0;
                                if (dgvLinha.Cells[11].Value.ToString().Contains("/"))
                                {
                                    
                                    string[]Notas = dgvLinha.Cells[11].Value.ToString().Split('/');
                                    foreach (var letra in dgvLinha.Cells[11].Value.ToString())
                                    {
                                        if (letra.ToString().Contains("/"))
                                            y++;                                        
                                    }

                                    double ValorDividido = Convert.ToDouble(dgvLinha.Cells[49].Value.ToString().Replace(".", ","))/(y+1);


                                    for (int x=0; x<=y;x++)
                                    {
                                        linha += dgvLinha.Cells[10].Value.ToString().Replace("-1", "");
                                        linha += ";;";
                                        linha += Notas[x].ToString();
                                        linha += ";;";
                                        linha += ValorDividido.ToString();
                                        linha += ";;";
                                        if (x != y) 
                                        linha += "\n";
                                    }
                                    
                                }

                                else if(!dgvLinha.Cells[11].Value.ToString().Contains("/"))
                                {
                                    linha += dgvLinha.Cells[10].Value.ToString().Replace("-1", "");
                                    linha += ";;";
                                    linha += dgvLinha.Cells[11].Value;
                                    linha += ";;";
                                    linha += dgvLinha.Cells[49].Value.ToString().Replace(".", ",");
                                    linha += ";;";
                                    //linha += "\n";
                                }
                                break;
                            }
                            }
                            if (linha != null)
                                sw.WriteLine(linha);
                        }

                        //Mensagem de confirmação
                        MessageBox.Show("Exportado com sucesso", "Exportado com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        //Fechar stream SEMPRE
                        sw.Close();
                    }

                
            }
         
        }

     

        //Load do Form
        private void frmConversorLayout_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
        }

        //Fechar o form
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConversorLayout_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }

        }
    }
    }

