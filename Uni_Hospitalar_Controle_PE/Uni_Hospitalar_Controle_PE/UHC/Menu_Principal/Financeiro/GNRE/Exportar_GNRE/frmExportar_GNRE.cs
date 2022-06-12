using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Uni_Hospitalar_Controle_PE.Background_Software;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Logistica.CI.Criar_Ci;
using System.IO;
using System.Xml;
using Ulib;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.GNRE.Exportar_GNRE
{
    public partial class frmExportar_GNRE : Form
    {
        public frmExportar_GNRE()
        {
            InitializeComponent();
        }

        //SQL
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;

        //Erro sql
        private void erro_DeAcesso(SqlException SQLe)
        {
            mMessage = "Erro de acesso ao servidor: " + SQLe.Message;
            mTittle = "SQL Server error";
            mButton = MessageBoxButtons.OK;
            mIcon = MessageBoxIcon.Error;
            System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            return;
        }

        //Variáveis de TextBox
        private string mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        DialogResult options;

        
        String cidade;
        Boolean Permissao_Exportar;

        //Permissoes
        private void Carregar_Bloqueios()
        {
            btnGerarManual.Enabled = false;
            btnExportarTodos.Enabled = false;
            btnRemoverTodos.Enabled = false;
            btnFecharConfirmar.Enabled = false;
            Permissao_Exportar = false;
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
                                if (reader["Cod_Rotina"].ToString() == "34" && reader["Status_Acesso"].ToString() == "1")
                                {

                                    btnGerarManual.Enabled = true;
                                    btnExportarTodos.Enabled = true;
                                    btnRemoverTodos.Enabled = true;
                                    btnFecharConfirmar.Enabled = true;
                                    Permissao_Exportar = true;


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
      


        //Variáveis de manipulação
        String bloqueio; //Manipula o bloqueio da nota, este campo recebe o dado do banco de dados e formata em formato de grid.

        //Variáveis somatório
        int iNotasBloqueadas = 0;
        int iNotasExportadas = 0;
        int iNotasNaoExportadas = 0;
        int iGuiasParaGerar = 0;
        //Listas de manipulação
        List<String> lBloqueio = new List<string>();

        private void Preenche_Somatorio()
        {
            iNotasBloqueadas = 0;
            iNotasExportadas = 0;
            iNotasNaoExportadas = 0;
            foreach (DataGridViewRow row in dgvDados.Rows)
            {
                if (row.Cells[0].Value.ToString() == "B1")
                {
                    iNotasBloqueadas++;
                }
                if (!row.Cells[11].Value.ToString().Equals(String.Empty))
                {
                    iNotasExportadas++;
                }
                else
                {
                    iNotasNaoExportadas++;
                }

            }
            txtNotasBloqueadas.Text = iNotasBloqueadas.ToString();
            txtNotasExportadas.Text = iNotasExportadas.ToString();
            txtNotasNaoExportadas.Text = iNotasNaoExportadas.ToString();

        }


        private void Configuracoes_Iniciais()
        {
            //Define a data do vencimento como a data inicial
            dtpDtInicial.Text = Convert.ToString(DateTime.Today);
            dtpDtFinal.Text = Convert.ToString(DateTime.Today);

            //Configurar o data grid view
            Configurar_dgvDados();

            //Gerar manual automaticamente inabilitada
            btnGerarManual.Enabled = false;
            btnGerarManual.BackColor = Color.LightGray;







            //Torna o status inativo
            ChkTodasAsGuias_CheckedChanged(chkTodasAsGuias, new EventArgs());

            //Botão fechar e cancelar
            btnCancelar.Visible = false;


            btnFecharConfirmar.BackColor = Color.Gray;
            btnFecharConfirmar.Text = "Fechar";
            //Dados iniciais
            Filtrar_Dados();

        }

        private void Configurar_dgvDados()
        {
            var col = new DataGridViewCheckBoxColumn();
            col.Name = "NF_Block";
            col.HeaderText = "B";
            col.FalseValue = "B0";
            col.TrueValue = "B1";
            col.CellTemplate.Value = true;
            col.CellTemplate.Style.NullValue = true;
            col.Width = 20;

            dgvDados.Columns.Insert(0, col);


            dgvDados.Columns.Add("Num_Nota", "NF");
            dgvDados.Columns.Add("Cod_Cliente", "Cód. Cliente");
            dgvDados.Columns.Add("Desc_Cliente", "Cliente");
            dgvDados.Columns.Add("Cod_Estado", "Estado");

            dgvDados.Columns.Add("CFOP", "Desc. CFOP");
            dgvDados.Columns.Add("Dat_Emissao", "Dat. Emissão");
            dgvDados.Columns.Add("Vlr_NF", "Vlr. NF");
            dgvDados.Columns.Add("Vlr_ICM", "Vlr. Difal");

            dgvDados.Columns.Add("Vlr_FCP", "Vlr. FCP");
            dgvDados.Columns.Add("Dat_Bloqueio", "Dat. Bloqueio");
            dgvDados.Columns.Add("Dat_Exportacao", "Dat. Exportação");
            dgvDados.Columns.Add("Obs_GNRE", "Observação");

            dgvDados.Columns[1].Width = 80;
            dgvDados.Columns[2].Width = 40;
            dgvDados.Columns[3].Width = 200;
            dgvDados.Columns[4].Width = 40;

            dgvDados.Columns[5].Width = 150;
            dgvDados.Columns[6].Width = 80;
            dgvDados.Columns[7].Width = 100;
            dgvDados.Columns[8].Width = 60;

            dgvDados.Columns[9].Width = 60;
            dgvDados.Columns[10].Width = 130;
            dgvDados.Columns[11].Width = 130;
            dgvDados.Columns[12].Width = 150;

            var col2 = new DataGridViewCheckBoxColumn();
            col2.Name = "NF_Block";
            col2.HeaderText = "B";
            col2.FalseValue = "B0";
            col2.TrueValue = "B1";
            col2.CellTemplate.Value = true;
            col2.CellTemplate.Style.NullValue = true;
            col2.Width = 20;

            dgvtransicao.Columns.Insert(0, col2);

            dgvtransicao.Columns.Add("Num_Nota", "NF");
            dgvtransicao.Columns.Add("Cod_Cliente", "Cód. Cliente");
            dgvtransicao.Columns.Add("Desc_Cliente", "Cliente");
            dgvtransicao.Columns.Add("Cod_Estado", "Estado");

            dgvtransicao.Columns.Add("CFOP", "Desc. CFOP");
            dgvtransicao.Columns.Add("Dat_Emissao", "Dat. Emissão");
            dgvtransicao.Columns.Add("Vlr_NF", "Vlr. NF");
            dgvtransicao.Columns.Add("Vlr_ICM", "Vlr. Difal");

            dgvtransicao.Columns.Add("Vlr_FCP", "Vlr. FCP");
            dgvtransicao.Columns.Add("Dat_Bloqueio", "Dat. Bloqueio");
            dgvtransicao.Columns.Add("Dat_Exportacao", "Dat. Exportação");
            dgvtransicao.Columns.Add("Obs_GNRE", "Observação");

            dgvtransicao.Columns[1].Width = 80;
            dgvtransicao.Columns[2].Width = 40;
            dgvtransicao.Columns[3].Width = 200;
            dgvtransicao.Columns[4].Width = 40;

            dgvtransicao.Columns[5].Width = 150;
            dgvtransicao.Columns[6].Width = 80;
            dgvtransicao.Columns[7].Width = 100;
            dgvtransicao.Columns[8].Width = 60;

            dgvtransicao.Columns[9].Width = 60;
            dgvtransicao.Columns[10].Width = 130;
            dgvtransicao.Columns[11].Width = 130;
            dgvtransicao.Columns[12].Width = 150;

        }

        private void construir_Arquivo()
        {           
                try
                {
                    this.Cursor = Cursors.WaitCursor;



                    string folder = @"C:\XML_Lote"; //nome do diretorio a ser criado

                    //Se o diretório não existir...

                    if (!Directory.Exists(folder))
                    {

                        //Criamos um com o nome folder
                        Directory.CreateDirectory(folder);

                    }

                    XmlTextWriter writer = new XmlTextWriter(@"c:\XML_Lote\XML_GNRE_" + DateTime.Today.Day + "_" + DateTime.Today.Month + "_" + DateTime.Today.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + ".xml", null);





                    //inicia o documento xml
                    writer.WriteStartDocument();

                    //define a indentação do arquivo
                    writer.Formatting = Formatting.Indented;
                    //escreve um comentário
                    //writer.WriteComment("Arquivos de filmes");

                    //Cabeçalho
                    writer.WriteStartElement("TLote_GNRE");
                    writer.WriteAttributeString("xmlns", "http://www.gnre.pe.gov.br");
                    writer.WriteAttributeString("versao", "2.00");


                    writer.WriteStartElement("guias");

                    for (int x = 0; x < lsbExportar.Items.Count; x++)
                    {
                        //1º etapa
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = "SELECT cidade FROM nfscb WHERE num_nota = " + lsbExportar.Items[x];

                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["cidade"] != null)
                                    {
                                        cidade = reader["cidade"].ToString();
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
                        

                                String municipio = null;
                                if (Usuario.unidade_Login == 1)
                                {
                                municipio = "11606";
                                }
                                else if (Usuario.unidade_Login == 2)
                                {
                                municipio = "04400";
                                }
                                else if (Usuario.unidade_Login == 3)
                                {
                                municipio = "13009";
                                }
                            
                        //2º etapa
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();


                                command.CommandText = " SELECT " +
                                                      " [c01_UfFavorecida] = NSCB.Estado " +
                                                      " ,[c02_receita] = '100102' " +
                                                      " ,num_nota" +
                                                      " ,CONVERT(varchar, CAST(isnull(NSCB.Vlr_IcmFcpUfDes,0) AS money)) [FCP]  " +
                                                      " ,CONVERT(varchar, CAST(isnull(NSCB.Vlr_IcmIntUfDes,0) AS money)) [c06_valorPrincipal]" +
                                                      " ,[c14_dataVencimento] = replace(convert(varchar, getdate(),102) ,'.','-')" +
                                                      " ,[c17_inscricaoEstadualEmitente] = '032746083' " +
                                                      " ,[c34_tipoIdentificacaoDestinatario] = '1' " +
                                                      " ,[CNPJ] = C.Cgc_Cpf " +
                                                      " ,[c37_razaoSocialDestinatario] = c.Razao_Social " +
                                                      " ,[c38_municipioDestinatario] = GN.COD_MUNICIPIO " +
                                                      " ,desc_municipio " +
                                                      " ,[c33_dataPagamento] = replace(convert(varchar, GETDATE(),102) ,'.','-')  " +
                                                      " ,[mes] = case month(getdate()) " +
                                                      " when 10 then convert(varchar, month(getdate())) " +
                                                      " when 11 then convert(varchar, month(getdate())) " +
                                                      " when 12 then convert(varchar, month(getdate())) " +
                                                      " else '0' + convert(varchar, month(getdate())) " +
                                                      " end " +
                                                      " ,[Dat_Emissao] = NSCB.Dat_Emissao" +
                                                      " ,[ano] = year(getdate()) " +
                                                      " ,[codigo] = 116 " +
                                                      " ,[tipo] = 'T' " +
                                                      " ,[valor] = nscb.chv_acesso " +
                                                      " ,[CNPJ_EMPRESA] = (SELECT TOP 1 CGC FROM EMPRE)" +
                                                      " ,[RZSOC_EMPRESA] = (SELECT TOP 1 RAZAO_SOCIAL FROM EMPRE) " +
                                                      " ,[Endereco_Numero] = (SELECT TOP 1 ENDERECO +', '+Numero FROM EMPRE)" +
                                                      " ,[Municipio_Emitente] = '" + municipio + "'" +
                                                      " ,[Cep_Emitente] = (SELECT TOP 1 CEP FROM EMPRE)" +
                                                      " ,[UF_Emitente] = (SELECT TOP 1 Estado FROM EMPRE)" +
                                                      " ,[Telefone_Emitente] = (SELECT TOP 1 Cod_DDD+FONE FROM EMPRE)" +
                                                      " FROM NFSCB NSCB " +
                                                      " INNER JOIN CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                      " LEFT OUTER JOIN CTREC CREC ON CREC.Num_NfOrigem = NSCB.Num_Nota " +
                                                      " INNER JOIN ESTAD EST ON EST.Codigo = C.Cod_Estado " +
                                                      " INNER JOIN UNIDB.dbo.EXPGN GN ON GN.COD_ESTADO = EST.Cod_Ibge " +
                                                      " WHERE NUM_NOTA =  " + lsbExportar.Items[x];

                            reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["c01_UfFavorecida"] != null)
                                    {

                                        if (cidade.Equals(reader["desc_municipio"].ToString().Trim().ToUpper()))
                                        {

                                            if (Convert.ToDouble(reader["c06_valorPrincipal"].ToString()) != 0)
                                            {
                                                //Rio grande do norte   OK
                                                if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("RN"))
                                                {
                                                writer.WriteStartElement("TDadosGNRE");
                                                writer.WriteAttributeString("versao", "2.00");

                                                writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                writer.WriteElementString("tipoGnre", "0");

                                                writer.WriteStartElement("contribuinteEmitente");
                                                writer.WriteStartElement("identificacao");
                                                writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                writer.WriteEndElement();
                                                writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                writer.WriteEndElement();

                                                writer.WriteStartElement("itensGNRE");
                                                writer.WriteStartElement("item");

                                                writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                writer.WriteStartElement("referencia");
                                                writer.WriteElementString("mes", reader["mes"].ToString());
                                                writer.WriteElementString("ano", reader["ano"].ToString());
                                                writer.WriteEndElement();
                                                writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                writer.WriteStartElement("contribuinteDestinatario");
                                                writer.WriteStartElement("identificacao");
                                                writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                writer.WriteEndElement();
                                                writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                writer.WriteEndElement();




                                                writer.WriteStartElement("camposExtras");
                                                writer.WriteStartElement("campoExtra");
                                                writer.WriteElementString("codigo", "97");
                                                writer.WriteElementString("valor", reader["valor"].ToString());
                                                writer.WriteEndElement();
                                                writer.WriteEndElement();

                                                writer.WriteEndElement();
                                                writer.WriteEndElement();

                                                writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                //Lock funcions                                          
                                                writer.WriteEndElement();

                                            }
                                                //PERNAMBUCO 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("PE"))
                                                {
                                                    
                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");

                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"24\">" + reader["Valor"].ToString() + "</documentoOrigem>");                                                                                                       
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteStartElement("contribuinteDestinatario");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteEndElement();

                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();
                                                
                                                
                                                }
                                                //Alagoas 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("AL"))
                                                {
                                                    



                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "1.00");

                                                    //Escreve os sub-elementos
                                                    writer.WriteElementString("c01_UfFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("c02_receita", reader["c02_receita"].ToString());
                                                    writer.WriteElementString("c27_tipoIdentificacaoEmitente", "1"); //Sempre 1

                                                    writer.WriteStartElement("c03_idContribuinteEmitente");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();


                                                    writer.WriteElementString("c06_valorPrincipal", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("c14_dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteElementString("c16_razaoSocialEmitente", reader["RZSOC_EMPRESA"].ToString());

                                                    writer.WriteElementString("c18_enderecoEmitente", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("c19_municipioEmitente", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("c20_ufEnderecoEmitente", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("c21_cepEmitente", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("c22_telefoneEmitente", reader["Telefone_Emitente"].ToString());

                                                    writer.WriteElementString("c34_tipoIdentificacaoDestinatario", "1");
                                                    writer.WriteStartElement("c35_idContribuinteDestinatario");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("c37_razaoSocialDestinatario", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("c38_municipioDestinatario", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteElementString("c33_dataPagamento", reader["c33_dataPagamento"].ToString());

                                                    writer.WriteStartElement("c05_referencia");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("c39_camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "65"); //Semrpe igual
                                                    writer.WriteElementString("tipo", reader["tipo"].ToString()); //Sempre igual
                                                    writer.WriteElementString("valor", reader["valor"].ToString()); //chave de acesso da nota
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    //Lock funcions
                                                    writer.WriteEndElement();

                                                
                                                }

                                                //Acre
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("AC"))
                                                {
                                                    


                                                        //Definição do loop
                                                        writer.WriteStartElement("TDadosGNRE");
                                                        writer.WriteAttributeString("versao", "2.00");

                                                        writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                        writer.WriteElementString("tipoGnre", "0");

                                                        writer.WriteStartElement("contribuinteEmitente");
                                                        writer.WriteStartElement("identificacao");
                                                        writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                        writer.WriteEndElement();
                                                        writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                        writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                        writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                        writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                        writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                        writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                        writer.WriteEndElement();

                                                        writer.WriteStartElement("itensGNRE");
                                                        writer.WriteStartElement("item");

                                                        writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                        writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                        writer.WriteStartElement("referencia");
                                                        writer.WriteElementString("mes", reader["mes"].ToString());
                                                        writer.WriteElementString("ano", reader["ano"].ToString());
                                                        writer.WriteEndElement();
                                                        writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                        writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");
                                                        writer.WriteStartElement("contribuinteDestinatario");
                                                        writer.WriteStartElement("identificacao");
                                                        writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                        writer.WriteEndElement();
                                                        writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                        writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                        writer.WriteEndElement();

                                                        writer.WriteStartElement("camposExtras");
                                                        writer.WriteStartElement("campoExtra");
                                                        writer.WriteElementString("codigo", "76");
                                                        writer.WriteElementString("valor", reader["valor"].ToString());
                                                        writer.WriteEndElement();
                                                        writer.WriteEndElement();

                                                        writer.WriteEndElement();
                                                        writer.WriteEndElement();

                                                        writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                        writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                        //Lock funcions                                          
                                                        writer.WriteEndElement();
                                                    
                                                }

                                                //Amazonas 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("AM"))
                                                {

                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");

                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"22\">" + reader["Valor"].ToString() + "</documentoOrigem>");
                                                    writer.WriteElementString("produto", "33");
                                                    writer.WriteStartElement("referencia");
                                                    writer.WriteElementString("periodo", "0");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteStartElement("contribuinteDestinatario");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteEndElement();

                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();

                                                }
                                                //AMAPA 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("AP"))
                                                {

                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "1.00");

                                                    //Escreve os sub-elementos
                                                    writer.WriteElementString("c01_UfFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("c02_receita", reader["c02_receita"].ToString());
                                                    writer.WriteElementString("c27_tipoIdentificacaoEmitente", "1"); //Sempre 1

                                                    writer.WriteStartElement("c03_idContribuinteEmitente");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();


                                                    writer.WriteElementString("c28_tipoDocOrigem", "10");
                                                    writer.WriteElementString("c04_docOrigem", reader["Num_Nota"].ToString());
                                                    writer.WriteElementString("c06_valorPrincipal", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("c14_dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteElementString("c16_razaoSocialEmitente", reader["RZSOC_EMPRESA"].ToString());

                                                    writer.WriteElementString("c18_enderecoEmitente", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("c19_municipioEmitente", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("c20_ufEnderecoEmitente", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("c21_cepEmitente", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("c22_telefoneEmitente", reader["Telefone_Emitente"].ToString());


                                                    writer.WriteElementString("c34_tipoIdentificacaoDestinatario", reader["c34_tipoIdentificacaoDestinatario"].ToString()); //Sempre 1


                                                    writer.WriteStartElement("c35_idContribuinteDestinatario");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("c37_razaoSocialDestinatario", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("c38_municipioDestinatario", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteElementString("c33_dataPagamento", reader["c33_dataPagamento"].ToString());

                                                    writer.WriteStartElement("c05_referencia");
                                                    writer.WriteElementString("periodo", "0");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("c39_camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "47"); //Semrpe igual
                                                    writer.WriteElementString("tipo", reader["tipo"].ToString()); //Sempre igual
                                                    writer.WriteElementString("valor", reader["valor"].ToString()); //chave de acesso da nota

                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    //Lock funcions
                                                    writer.WriteEndElement();

                                                }
                                                //BAHIA     
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("BA"))
                                                {

                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");

                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteStartElement("referencia");
                                                    writer.WriteElementString("periodo", "0");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "86");
                                                    writer.WriteElementString("valor", reader["valor"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();

                                                }
                                                //CEARA                                 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("CE"))
                                                {
                                                    //Definição do loop
                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");

                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteStartElement("contribuinteDestinatario");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "50");
                                                    writer.WriteElementString("valor", reader["c33_dataPagamento"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();
                                                }
                                                //DF    
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("DF"))
                                                {
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");

                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                    writer.WriteStartElement("referencia");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");


                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();
                                                }
                                                //Goiás 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("GO"))
                                                {
                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");

                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                    writer.WriteStartElement("referencia");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteStartElement("contribuinteDestinatario");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteEndElement();




                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "102");
                                                    writer.WriteElementString("valor", reader["valor"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();

                                                }
                                                //Maranhão 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("MA"))
                                                {

                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");

                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                    writer.WriteElementString("produto", "23");
                                                    writer.WriteStartElement("referencia");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteStartElement("contribuinteDestinatario");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteEndElement();




                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "94");
                                                    writer.WriteElementString("valor", reader["valor"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();


                                                    ////Definição do loop
                                                    //writer.WriteStartElement("TDadosGNRE");
                                                    //writer.WriteAttributeString("versao", "1.00");

                                                    ////Escreve os sub-elementos
                                                    //writer.WriteElementString("c01_UfFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    //writer.WriteElementString("c02_receita", reader["c02_receita"].ToString());
                                                    //writer.WriteElementString("c27_tipoIdentificacaoEmitente", "1"); //Sempre 1

                                                    //writer.WriteStartElement("c03_idContribuinteEmitente");
                                                    //writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    //writer.WriteEndElement();

                                                    //writer.WriteElementString("c28_tipoDocOrigem", "10");
                                                    //writer.WriteElementString("c04_docOrigem", reader["num_nota"].ToString());
                                                    //writer.WriteElementString("c06_valorPrincipal", reader["c06_valorPrincipal"].ToString());
                                                    //writer.WriteElementString("c14_dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    //writer.WriteElementString("c16_razaoSocialEmitente", reader["RZSOC_EMPRESA"].ToString());
                                                    //writer.WriteElementString("c18_enderecoEmitente", reader["ENDERECO_NUMERO"].ToString());
                                                    //writer.WriteElementString("c19_municipioEmitente", reader["Municipio_Emitente"].ToString());
                                                    //writer.WriteElementString("c20_ufEnderecoEmitente", reader["Uf_Emitente"].ToString());
                                                    //writer.WriteElementString("c21_cepEmitente", reader["Cep_Emitente"].ToString());
                                                    //writer.WriteElementString("c22_telefoneEmitente", reader["Telefone_Emitente"].ToString());
                                                    //writer.WriteElementString("c34_tipoIdentificacaoDestinatario", "1");


                                                    //writer.WriteStartElement("c35_idContribuinteDestinatario");
                                                    //writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    //writer.WriteEndElement();

                                                    //writer.WriteElementString("c37_razaoSocialDestinatario", reader["c37_razaoSocialDestinatario"].ToString());
                                                    //writer.WriteElementString("c38_municipioDestinatario", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    //writer.WriteElementString("c33_dataPagamento", reader["c33_dataPagamento"].ToString());

                                                    //writer.WriteStartElement("c05_referencia");
                                                    //writer.WriteElementString("mes", reader["mes"].ToString());
                                                    //writer.WriteElementString("ano", reader["ano"].ToString());
                                                    //writer.WriteEndElement();

                                                    //writer.WriteStartElement("c39_camposExtras");
                                                    //writer.WriteStartElement("campoExtra");
                                                    //writer.WriteElementString("codigo", "94");
                                                    //writer.WriteElementString("tipo", "T");
                                                    //writer.WriteElementString("valor", reader["valor"].ToString());
                                                    //writer.WriteEndElement();
                                                    //writer.WriteEndElement();
                                                    ////Lock funcions
                                                    //writer.WriteEndElement();

                                                    //GNRE 2.0
                                                    ////Open TDadosGNRE
                                                    //writer.WriteStartElement("TDadosGNRE");
                                                    //writer.WriteAttributeString("versao", "2.00");

                                                    //writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    //writer.WriteElementString("tipoGnre", "0");

                                                    ////Open Contribuinte Emitente
                                                    //writer.WriteStartElement("contribuinteEmitente");
                                                    ////Open identificacao
                                                    //writer.WriteStartElement("identificacao");
                                                    //writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    ////Lock identificacao
                                                    //writer.WriteEndElement();
                                                    //writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    //writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    //writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    //writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    //writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    //writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    ////Lock Contribuinte Emitente
                                                    //writer.WriteEndElement();

                                                    ////Open itensGNRE
                                                    //writer.WriteStartElement("itensGNRE");
                                                    //writer.WriteStartElement("item");
                                                    //writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    //writer.WriteRaw("<documentoOrigem tipo =\"10\">" + lsbExportar.Items[x].ToString() + "</documentoOrigem>");
                                                    ////Open referencia
                                                    //writer.WriteStartElement("referencia");
                                                    //writer.WriteElementString("mes", reader["mes"].ToString());
                                                    //writer.WriteElementString("ano", reader["ano"].ToString());
                                                    ////Lock referencia
                                                    //writer.WriteEndElement();
                                                    //writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    //writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");                                                

                                                    ////Open Contribuinte destinatário
                                                    //writer.WriteStartElement("contribuinteDestinatario");
                                                    ////Open identificacao
                                                    //writer.WriteStartElement("identificacao");
                                                    //writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    ////Lock identificacao
                                                    //writer.WriteEndElement();
                                                    //writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                    //writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    ////Lock Contribuinte destinatário
                                                    //writer.WriteEndElement();

                                                    ////Open camposExtras
                                                    //writer.WriteStartElement("camposExtras");
                                                    ////Open campoExtra
                                                    //writer.WriteStartElement("campoExtra");
                                                    //writer.WriteElementString("codigo", "94");
                                                    //writer.WriteElementString("valor", reader["valor"].ToString());
                                                    ////Lock camposExtras
                                                    //writer.WriteEndElement();
                                                    ////Lock campoExtra
                                                    //writer.WriteEndElement();

                                                    ////Lock itens
                                                    //writer.WriteEndElement();
                                                    ////Lock itensGNRE
                                                    //writer.WriteEndElement();




                                                    //writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    //writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());


                                                    ////Lock TDadosGNRE
                                                    //writer.WriteEndElement();
                                                }
                                                //Minas Gerais 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("MG"))
                                                {

                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");


                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + lsbExportar.Items[x].ToString() + "</documentoOrigem>");
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();
                                                }
                                                //Mato Grosso do Sul 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("MS"))
                                                {
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");

                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteStartElement("contribuinteDestinatario");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteEndElement();




                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "88");
                                                    writer.WriteElementString("valor", reader["valor"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();

                                                }

                                                //Mato Grosso 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("MT"))
                                                {
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");

                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteElementString("detalhamentoReceita", "000055");

                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                    writer.WriteStartElement("referencia");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "108");
                                                    writer.WriteElementString("valor", reader["valor"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();

                                                }

                                                //Para 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("PA"))
                                                {
                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");


                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                    writer.WriteStartElement("referencia");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteStartElement("contribuinteDestinatario");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "101");
                                                    writer.WriteElementString("valor", reader["valor"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();


                                                }
                                                //Paraiba                                                 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("PB"))
                                                {
                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");


                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                    writer.WriteStartElement("referencia");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");


                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "99");
                                                    writer.WriteElementString("valor", reader["valor"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();
                                                }
                                                //Piaui (São geradas duas guias distintas) 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("PI"))
                                                {
                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");

                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteStartElement("contribuinteDestinatario");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteEndElement();





                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();


                                                    //Se FCP não for 0
                                                    if (Convert.ToDouble(reader["FCP"].ToString()) != 0)
                                                    {
                                                        //Para FCP

                                                        //Definição do loop
                                                        writer.WriteStartElement("TDadosGNRE");
                                                        writer.WriteAttributeString("versao", "2.00");

                                                        writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                        writer.WriteElementString("tipoGnre", "0");

                                                        writer.WriteStartElement("contribuinteEmitente");
                                                        writer.WriteStartElement("identificacao");
                                                        writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                        writer.WriteEndElement();
                                                        writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                        writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                        writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                        writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                        writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                        writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                        writer.WriteEndElement();

                                                        writer.WriteStartElement("itensGNRE");
                                                        writer.WriteStartElement("item");

                                                        //writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                        writer.WriteElementString("receita", "100129");
                                                        writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                        writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                        writer.WriteRaw("<valor tipo =\"11\">" + reader["FCP"].ToString() + "</valor>");

                                                        writer.WriteStartElement("contribuinteDestinatario");
                                                        writer.WriteStartElement("identificacao");
                                                        writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                        writer.WriteEndElement();
                                                        writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                        writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                        writer.WriteEndElement();





                                                        writer.WriteEndElement();
                                                        writer.WriteEndElement();

                                                        writer.WriteElementString("valorGNRE", reader["FCP"].ToString());
                                                        writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                        //Lock funcions                                          
                                                        writer.WriteEndElement();
                                                    }


                                                }
                                                //Parana 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("PR"))
                                                {

                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");


                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");
                                                    //writer.WriteRaw("<valor tipo =\"12\">" + reader["FCP"].ToString() + "</valor>");                        //Valor FCP

                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "107");
                                                    writer.WriteElementString("valor", reader["valor"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();







                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();


                                                }
                                                //Rondonia 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("RO"))
                                                {
                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");


                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                    writer.WriteStartElement("referencia");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");
                                                    //writer.WriteRaw("<valor tipo =\"12\">" + reader["FCP"].ToString() + "</valor>");                        //Valor FCP

                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "83");
                                                    writer.WriteElementString("valor", reader["valor"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();







                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();




                                                }
                                                //Roraiama 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("RR"))
                                                {
                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");


                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["Num_Nota"].ToString() + "</documentoOrigem>");
                                                    writer.WriteStartElement("referencia");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");
                                                    //writer.WriteRaw("<valor tipo =\"12\">" + reader["FCP"].ToString() + "</valor>");                        //Valor FCP

                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "36");
                                                    writer.WriteElementString("valor", reader["valor"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();







                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();
                                                }
                                                //Rio de Janeiro
                                                //Rio de Janeiro
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("RJ"))
                                                {
                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");


                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");
                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"24\">" + reader["Valor"].ToString() + "</documentoOrigem>");
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteStartElement("contribuinteDestinatario");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "117");
                                                    writer.WriteElementString("valor", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "118");
                                                    writer.WriteElementString("valor", reader["Num_Nota"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();







                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();


                                                }
                                                //Rio Grande do sul 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("RS"))
                                                {
                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");


                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"22\">" + reader["Valor"].ToString() + "</documentoOrigem>");
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");





                                                    writer.WriteStartElement("contribuinteDestinatario");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteEndElement();




                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "62");
                                                    writer.WriteElementString("valor", reader["valor"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();



                                                }
                                                //Santa Catarina 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("SC"))
                                                {
                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");


                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteElementString("cep", reader["Cep_Emitente"].ToString());
                                                    writer.WriteElementString("telefone", reader["Telefone_Emitente"].ToString());
                                                    writer.WriteEndElement();

                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");

                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"24\">" + reader["Valor"].ToString() + "</documentoOrigem>");
                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");




                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();

                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();




                                                }
                                                //Sergipe 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("SE"))
                                                {
                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");


                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteEndElement();


                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");
                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["num_nota"].ToString() + "</documentoOrigem>");
                                                    writer.WriteStartElement("referencia");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();


                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteStartElement("contribuinteDestinatario");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteEndElement();




                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "77");
                                                    writer.WriteElementString("valor", reader["valor"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();


                                                }
                                                //Tocantins 
                                                else if (reader["c01_UfFavorecida"].ToString().Trim().ToUpper().Equals("TO"))
                                                {
                                                    //Definição do loop
                                                    writer.WriteStartElement("TDadosGNRE");
                                                    writer.WriteAttributeString("versao", "2.00");

                                                    writer.WriteElementString("ufFavorecida", reader["c01_UfFavorecida"].ToString()); //UF da nota fiscal
                                                    writer.WriteElementString("tipoGnre", "0");


                                                    writer.WriteStartElement("contribuinteEmitente");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ_EMPRESA"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["RZSOC_EMPRESA"].ToString());
                                                    writer.WriteElementString("endereco", reader["ENDERECO_NUMERO"].ToString());
                                                    writer.WriteElementString("municipio", reader["Municipio_Emitente"].ToString());
                                                    writer.WriteElementString("uf", reader["Uf_Emitente"].ToString());
                                                    writer.WriteEndElement();


                                                    writer.WriteStartElement("itensGNRE");
                                                    writer.WriteStartElement("item");
                                                    writer.WriteElementString("receita", reader["c02_receita"].ToString());
                                                    writer.WriteRaw("<documentoOrigem tipo =\"10\">" + reader["num_nota"].ToString() + "</documentoOrigem>");
                                                    writer.WriteStartElement("referencia");
                                                    writer.WriteElementString("mes", reader["mes"].ToString());
                                                    writer.WriteElementString("ano", reader["ano"].ToString());
                                                    writer.WriteEndElement();


                                                    writer.WriteElementString("dataVencimento", reader["c14_dataVencimento"].ToString());
                                                    writer.WriteRaw("<valor tipo =\"11\">" + reader["c06_valorPrincipal"].ToString() + "</valor>");

                                                    writer.WriteStartElement("contribuinteDestinatario");
                                                    writer.WriteStartElement("identificacao");
                                                    writer.WriteElementString("CNPJ", reader["CNPJ"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("razaoSocial", reader["c37_razaoSocialDestinatario"].ToString());
                                                    writer.WriteElementString("municipio", reader["c38_municipioDestinatario"].ToString().Trim());
                                                    writer.WriteEndElement();




                                                    writer.WriteStartElement("camposExtras");
                                                    writer.WriteStartElement("campoExtra");
                                                    writer.WriteElementString("codigo", "80");
                                                    writer.WriteElementString("valor", reader["valor"].ToString());
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();
                                                    writer.WriteEndElement();
                                                    writer.WriteElementString("valorGNRE", reader["c06_valorPrincipal"].ToString());
                                                    writer.WriteElementString("dataPagamento", reader["c33_dataPagamento"].ToString());
                                                    //Lock funcions                                          
                                                    writer.WriteEndElement();
                                                }

                                                break;
                                            }
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

                        //3º etapa
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = "update unidb.dbo.nsgnr set dat_export = getdate(), usuario = '" + Usuario.userDesc + "' WHERE num_nota = " + lsbExportar.Items[x];

                                command.ExecuteNonQuery();

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


                    writer.WriteFullEndElement();
                    writer.Close();
                    this.Cursor = Cursors.Default;
                    mMessage = "Exportado com sucesso, vá na unidade C:/XML_Lote para encontrar o arquivo";
                    mTittle = "Exportação";
                    mIcon = MessageBoxIcon.Information;
                    mButton = MessageBoxButtons.OK;
                    MessageBox.Show(mMessage, mTittle, mButton, mIcon);




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }                       

        }
        private void Filtrar_Dados()
        {
            if (Usuario.unidade_Login == 1)
            {
                this.Cursor = Cursors.WaitCursor;
                dgvDados.Rows.Clear();
                lBloqueio.Clear();
                iGuiasParaGerar = 0;
                if (!txtNF.Text.Trim().Equals(String.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = " SELECT										NSCB.Num_Nota [Num_Nota]       " +
                                                        " ,C.CODIGO[Cod_Cliente] " +
                                                        " ,C.Razao_Social[Des_Cliente] " +
                                                        " ,NSCB.Estado[Estado] " +
                                                        " ,TBCFO.Descricao[Descricao] " +
                                                        " ,Convert(Date, NSCB.Dat_Emissao)[Dat_Emissao] " +
                                                        " ,isnull(NSCB.Vlr_TotalNota, 0)[Vlr_Nota] " +
                                                        " ,isnull(NSCB.Vlr_IcmIntUfDes, 0)[Vlr_GNRE] " +
                                                        " ,isnull(NSCB.Vlr_IcmFCPUfDes, 0)[Vlr_FCP] " +
                                                        " ,GNR.Dat_Bloqueio[Dat_Bloqueio] " +
                                                        " ,GNR.Dat_Export[Dat_Export] " +
                                                        " ,GNR.Obs_GNRE " +
                                                        " ,GNR.flg_BloqExport " +
                                                        " FROM NFSCB NSCB " +
                                                        " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                        " INNER JOIN UNIDB.dbo.NSGNR GNR ON GNR.NUM_NOTA = NSCB.NUM_NOTA " +
                                                        " INNER JOIN DMD.dbo.TBCFO ON Cod_Cfo1 = TBCFO.Codigo " +
                                                        " WHERE(STATUS = 'F' and Ser_Nota NOT LIKE 'XXX')" +
                                                        " AND NSCB.Num_Nota = " + txtNF.Text.Trim();

                            command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                            command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Des_Cliente"] != null)
                                {

                                    if (reader["flg_BloqExport"].ToString().Equals("1"))
                                    {
                                        bloqueio = "B1";

                                    }
                                    else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                    {
                                        bloqueio = "B0";
                                    }


                                    dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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
                    this.Cursor = Cursors.Default;
                    return;
                }

                String comando;

                if (!txtCliente.Text.Trim().Equals(String.Empty))
                {
                    comando = " SELECT										NSCB.Num_Nota [Num_Nota]       " +
                                                        " ,C.CODIGO[Cod_Cliente] " +
                                                        " ,C.Razao_Social[Des_Cliente] " +
                                                        " ,NSCB.Estado[Estado] " +
                                                        " ,TBCFO.Descricao[Descricao] " +
                                                        " ,Convert(Date, NSCB.Dat_Emissao)[Dat_Emissao] " +
                                                        " ,isnull(NSCB.Vlr_TotalNota, 0)[Vlr_Nota] " +
                                                        " ,isnull(NSCB.Vlr_IcmIntUfDes, 0)[Vlr_GNRE] " +
                                                        " ,isnull(NSCB.Vlr_IcmFCPUfDes, 0)[Vlr_FCP] " +
                                                        " ,GNR.Dat_Bloqueio[Dat_Bloqueio] " +
                                                        " ,GNR.Dat_Export[Dat_Export] " +
                                                        " ,GNR.Obs_GNRE " +
                                                        " ,GNR.flg_BloqExport " +
                                                        " FROM NFSCB NSCB " +
                                                        " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                        " INNER JOIN UNIDB.dbo.NSGNR GNR ON GNR.NUM_NOTA = NSCB.NUM_NOTA " +
                                                        " INNER JOIN DMD.dbo.TBCFO ON Cod_Cfo1 = TBCFO.Codigo " +
                                                        " WHERE(STATUS = 'F' and Ser_Nota NOT LIKE 'XXX')" +
                                                        " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL " +
                                                        " AND C.CODIGO = " + txtCod_Cliente.Text.Trim();
                }
                else if (!txtUFDesc.Text.Trim().Equals(String.Empty))
                {
                    comando = " SELECT										NSCB.Num_Nota [Num_Nota]       " +
                                                       " ,C.CODIGO[Cod_Cliente] " +
                                                       " ,C.Razao_Social[Des_Cliente] " +
                                                       " ,NSCB.Estado[Estado] " +
                                                       " ,TBCFO.Descricao[Descricao] " +
                                                       " ,Convert(Date, NSCB.Dat_Emissao)[Dat_Emissao] " +
                                                       " ,isnull(NSCB.Vlr_TotalNota, 0)[Vlr_Nota] " +
                                                       " ,isnull(NSCB.Vlr_IcmIntUfDes, 0)[Vlr_GNRE] " +
                                                       " ,isnull(NSCB.Vlr_IcmFCPUfDes, 0)[Vlr_FCP] " +
                                                       " ,GNR.Dat_Bloqueio[Dat_Bloqueio] " +
                                                       " ,GNR.Dat_Export[Dat_Export] " +
                                                       " ,GNR.Obs_GNRE " +
                                                       " ,GNR.flg_BloqExport " +
                                                       " FROM NFSCB NSCB " +
                                                       " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                       " INNER JOIN UNIDB.dbo.NSGNR GNR ON GNR.NUM_NOTA = NSCB.NUM_NOTA " +
                                                       " INNER JOIN DMD.dbo.TBCFO ON Cod_Cfo1 = TBCFO.Codigo " +
                                                       " WHERE(STATUS = 'F' and Ser_Nota NOT LIKE 'XXX')" +
                                                       " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL " +
                                                       " AND NSCB.Estado like '" + txtUF.Text.Trim().ToUpper() + "' ";
                }
                else
                {
                    comando = " SELECT										NSCB.Num_Nota [Num_Nota]       " +
                                                        " ,C.CODIGO[Cod_Cliente] " +
                                                        " ,C.Razao_Social[Des_Cliente] " +
                                                        " ,NSCB.Estado[Estado] " +
                                                        " ,TBCFO.Descricao[Descricao] " +
                                                        " ,Convert(Date, NSCB.Dat_Emissao)[Dat_Emissao] " +
                                                        " ,isnull(NSCB.Vlr_TotalNota, 0)[Vlr_Nota] " +
                                                        " ,isnull(NSCB.Vlr_IcmIntUfDes, 0)[Vlr_GNRE] " +
                                                        " ,isnull(NSCB.Vlr_IcmFCPUfDes, 0)[Vlr_FCP] " +
                                                        " ,GNR.Dat_Bloqueio[Dat_Bloqueio] " +
                                                        " ,GNR.Dat_Export[Dat_Export] " +
                                                        " ,GNR.Obs_GNRE " +
                                                        " ,GNR.flg_BloqExport " +
                                                        " FROM NFSCB NSCB " +
                                                        " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                        " INNER JOIN UNIDB.dbo.NSGNR GNR ON GNR.NUM_NOTA = NSCB.NUM_NOTA " +
                                                        " INNER JOIN DMD.dbo.TBCFO ON Cod_Cfo1 = TBCFO.Codigo " +
                                                        " WHERE(STATUS = 'F' and Ser_Nota NOT LIKE 'XXX')" +
                                                        " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL ";

                }


                //Filtros gerais
                if (chkTodasAsGuias.Checked == true)
                {

                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = comando;

                            command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                            command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Des_Cliente"] != null)
                                {


                                    if (reader["flg_BloqExport"].ToString().Equals("1"))
                                    {
                                        bloqueio = "B1";

                                    }
                                    else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                    {
                                        bloqueio = "B0";
                                    }




                                    dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString()
                                        , reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString()
                                        , reader["Estado"].ToString(), reader["Descricao"].ToString()
                                        , reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C")
                                        , Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C")
                                        ,Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C")
                                        , reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString()
                                        , reader["Obs_GNRE"].ToString());







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
                else
                {
                    //Foco cliente           
                    if (chkExportadas.Checked == false && chkNaoExportadas.Checked == false && chkBloqueadas.Checked == false)
                    {
                        mMessage = "Selecione algum filtro de status.";
                        mTittle = "Status GNRE";
                        mButton = MessageBoxButtons.OK;
                        mIcon = MessageBoxIcon.Information;
                        System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    }

                    else if (chkExportadas.Checked == false && chkNaoExportadas.Checked == false && chkBloqueadas.Checked == true)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and flg_BloqExport = 1 ";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString()
                                            , reader["Des_Cliente"].ToString(), reader["Estado"].ToString()
                                            , reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString()
                                            , Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C")
                                            , Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C")
                                            , Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C")
                                            , reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString()
                                            , reader["Obs_GNRE"].ToString());
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

                    else if (chkExportadas.Checked == false && chkNaoExportadas.Checked == true && chkBloqueadas.Checked == false)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and Dat_Export is null and flg_BloqExport = 0 ";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == false && chkNaoExportadas.Checked == true && chkBloqueadas.Checked == true)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and Dat_Export is null and flg_BloqExport = 1 ";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }

                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == true && chkNaoExportadas.Checked == false && chkBloqueadas.Checked == false)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and Dat_Export is not null and flg_BloqExport = 0";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == true && chkNaoExportadas.Checked == false && chkBloqueadas.Checked == true)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and Dat_Export is not null and flg_BloqExport = 1";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == true && chkNaoExportadas.Checked == true && chkBloqueadas.Checked == false)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and flg_BloqExport = 0 ";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == true && chkNaoExportadas.Checked == true && chkBloqueadas.Checked == true)
                    {

                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando;

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                }

                //Transicao
                dgvtransicao.Rows.Clear();
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[11].Value.Equals(String.Empty) && !row.Cells[0].Value.Equals("B1"))
                    {
                        dgvtransicao.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value,
                                              row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value);
                    }
                }

                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[0].Value.Equals("B1"))
                    {
                        dgvtransicao.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value,
                                              row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value);
                    }
                }

                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (!row.Cells[11].Value.Equals(String.Empty) && !row.Cells[0].Value.Equals("B1"))
                    {
                        dgvtransicao.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value,
                                              row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value);
                    }
                }

                dgvDados.Rows.Clear();
                foreach (DataGridViewRow row in dgvtransicao.Rows)
                {
                    dgvDados.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value,
                                          row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value);
                }

                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[4].Value.Equals("SP") ||
                        //row.Cells[4].Value.Equals("RJ") || 
                        row.Cells[4].Value.Equals("ES"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.BackColor = Color.DarkGreen;
                    }

                    else if (row.Cells[4].Value.Equals("BA") || row.Cells[4].Value.Equals("RN") || row.Cells[4].Value.Equals("PB") || row.Cells[4].Value.Equals("CE") || row.Cells[4].Value.Equals("AL") || row.Cells[4].Value.Equals("AM")
                             || row.Cells[4].Value.Equals("MA"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.BackColor = Color.DarkKhaki;
                    }

                    if (row.Cells[0].Value.Equals("B1"))
                    {
                        // Se estiver bloqueado, cor vermelha
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.BackColor = Color.DarkRed;
                        row.ReadOnly = true;
                    }

                    if (row.Cells[8].Value.Equals("R$ 0,00") && row.Cells[9].Value.Equals("R$ 0,00"))
                    {
                        row.Visible = false;
                    }

                    else if (!row.Cells[11].Value.Equals(String.Empty))
                    {
                        // Se já tiver sido exportado, fica cinza
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.BackColor = Color.Gray;
                    }




                }

                Preenche_Somatorio();
                this.Cursor = Cursors.Default;
            }
            else if (Usuario.unidade_Login == 2)
            {
                this.Cursor = Cursors.WaitCursor;
                dgvDados.Rows.Clear();
                lBloqueio.Clear();
                iGuiasParaGerar = 0;
                if (!txtNF.Text.Trim().Equals(String.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = " SELECT										NSCB.Num_Nota [Num_Nota]       " +
                                                        " ,C.CODIGO[Cod_Cliente] " +
                                                        " ,C.Razao_Social[Des_Cliente] " +
                                                        " ,NSCB.Estado[Estado] " +
                                                        " ,TBCFO.Descricao[Descricao] " +
                                                        " ,Convert(Date, NSCB.Dat_Emissao)[Dat_Emissao] " +
                                                        " ,isnull(NSCB.Vlr_TotalNota, 0)[Vlr_Nota] " +
                                                        " ,isnull(NSCB.Vlr_IcmIntUfDes, 0)[Vlr_GNRE] " +
                                                        " ,isnull(NSCB.Vlr_IcmFCPUfDes, 0)[Vlr_FCP] " +
                                                        " ,GNR.Dat_Bloqueio[Dat_Bloqueio] " +
                                                        " ,GNR.Dat_Export[Dat_Export] " +
                                                        " ,GNR.Obs_GNRE " +
                                                        " ,GNR.flg_BloqExport " +
                                                        " FROM NFSCB NSCB " +
                                                        " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                        " INNER JOIN UNIDB.dbo.NSGNR GNR ON GNR.NUM_NOTA = NSCB.NUM_NOTA " +
                                                        " INNER JOIN DMD.dbo.TBCFO ON Cod_Cfo1 = TBCFO.Codigo " +
                                                        " WHERE(STATUS = 'F' and Ser_Nota NOT LIKE 'XXX')" +
                                                        " AND NSCB.Num_Nota = " + txtNF.Text.Trim();

                            command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                            command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Des_Cliente"] != null)
                                {

                                    if (reader["flg_BloqExport"].ToString().Equals("1"))
                                    {
                                        bloqueio = "B1";

                                    }
                                    else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                    {
                                        bloqueio = "B0";
                                    }


                                    dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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
                    this.Cursor = Cursors.Default;
                    return;
                }

                String comando;

                if (!txtCliente.Text.Trim().Equals(String.Empty))
                {
                    comando = " SELECT										NSCB.Num_Nota [Num_Nota]       " +
                                                        " ,C.CODIGO[Cod_Cliente] " +
                                                        " ,C.Razao_Social[Des_Cliente] " +
                                                        " ,NSCB.Estado[Estado] " +
                                                        " ,TBCFO.Descricao[Descricao] " +
                                                        " ,Convert(Date, NSCB.Dat_Emissao)[Dat_Emissao] " +
                                                        " ,isnull(NSCB.Vlr_TotalNota, 0)[Vlr_Nota] " +
                                                        " ,isnull(NSCB.Vlr_IcmIntUfDes, 0)[Vlr_GNRE] " +
                                                        " ,isnull(NSCB.Vlr_IcmFCPUfDes, 0)[Vlr_FCP] " +
                                                        " ,GNR.Dat_Bloqueio[Dat_Bloqueio] " +
                                                        " ,GNR.Dat_Export[Dat_Export] " +
                                                        " ,GNR.Obs_GNRE " +
                                                        " ,GNR.flg_BloqExport " +
                                                        " FROM NFSCB NSCB " +
                                                        " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                        " INNER JOIN UNIDB.dbo.NSGNR GNR ON GNR.NUM_NOTA = NSCB.NUM_NOTA " +
                                                        " INNER JOIN DMD.dbo.TBCFO ON Cod_Cfo1 = TBCFO.Codigo " +
                                                        " WHERE(STATUS = 'F' and Ser_Nota NOT LIKE 'XXX')" +
                                                        " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL " +
                                                        " AND C.CODIGO = " + txtCod_Cliente.Text.Trim();
                }
                else if (!txtUFDesc.Text.Trim().Equals(String.Empty))
                {
                    comando = " SELECT										NSCB.Num_Nota [Num_Nota]       " +
                                                       " ,C.CODIGO[Cod_Cliente] " +
                                                       " ,C.Razao_Social[Des_Cliente] " +
                                                       " ,NSCB.Estado[Estado] " +
                                                       " ,TBCFO.Descricao[Descricao] " +
                                                       " ,Convert(Date, NSCB.Dat_Emissao)[Dat_Emissao] " +
                                                       " ,isnull(NSCB.Vlr_TotalNota, 0)[Vlr_Nota] " +
                                                       " ,isnull(NSCB.Vlr_IcmIntUfDes, 0)[Vlr_GNRE] " +
                                                       " ,isnull(NSCB.Vlr_IcmFCPUfDes, 0)[Vlr_FCP] " +
                                                       " ,GNR.Dat_Bloqueio[Dat_Bloqueio] " +
                                                       " ,GNR.Dat_Export[Dat_Export] " +
                                                       " ,GNR.Obs_GNRE " +
                                                       " ,GNR.flg_BloqExport " +
                                                       " FROM NFSCB NSCB " +
                                                       " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                       " INNER JOIN UNIDB.dbo.NSGNR GNR ON GNR.NUM_NOTA = NSCB.NUM_NOTA " +
                                                       " INNER JOIN DMD.dbo.TBCFO ON Cod_Cfo1 = TBCFO.Codigo " +
                                                       " WHERE(STATUS = 'F' and Ser_Nota NOT LIKE 'XXX')" +
                                                       " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL " +
                                                       " AND NSCB.Estado like '" + txtUF.Text.Trim().ToUpper() + "' ";
                }
                else
                {
                    comando = " SELECT										NSCB.Num_Nota [Num_Nota]       " +
                                                        " ,C.CODIGO[Cod_Cliente] " +
                                                        " ,C.Razao_Social[Des_Cliente] " +
                                                        " ,NSCB.Estado[Estado] " +
                                                        " ,TBCFO.Descricao[Descricao] " +
                                                        " ,Convert(Date, NSCB.Dat_Emissao)[Dat_Emissao] " +
                                                        " ,isnull(NSCB.Vlr_TotalNota, 0)[Vlr_Nota] " +
                                                        " ,isnull(NSCB.Vlr_IcmIntUfDes, 0)[Vlr_GNRE] " +
                                                        " ,isnull(NSCB.Vlr_IcmFCPUfDes, 0)[Vlr_FCP] " +
                                                        " ,GNR.Dat_Bloqueio[Dat_Bloqueio] " +
                                                        " ,GNR.Dat_Export[Dat_Export] " +
                                                        " ,GNR.Obs_GNRE " +
                                                        " ,GNR.flg_BloqExport " +
                                                        " FROM NFSCB NSCB " +
                                                        " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                        " INNER JOIN UNIDB.dbo.NSGNR GNR ON GNR.NUM_NOTA = NSCB.NUM_NOTA " +
                                                        " INNER JOIN DMD.dbo.TBCFO ON Cod_Cfo1 = TBCFO.Codigo " +
                                                        " WHERE(STATUS = 'F' and Ser_Nota NOT LIKE 'XXX')" +
                                                        " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL ";

                }


                //Filtros gerais
                if (chkTodasAsGuias.Checked == true)
                {

                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = comando;

                            command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                            command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Des_Cliente"] != null)
                                {
                                    if (reader["flg_BloqExport"].ToString().Equals("1"))
                                    {
                                        bloqueio = "B1";

                                    }
                                    else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                    {
                                        bloqueio = "B0";
                                    }
                                    dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString()
                                        , reader["Des_Cliente"].ToString(), reader["Estado"].ToString()
                                        , reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString()
                                        , Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C")
                                        , Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C")
                                        , Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C")
                                        , reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString()
                                        , reader["Obs_GNRE"].ToString());
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
                else
                {


                    //Foco cliente           
                    if (chkExportadas.Checked == false && chkNaoExportadas.Checked == false && chkBloqueadas.Checked == false)
                    {
                        mMessage = "Selecione algum filtro de status.";
                        mTittle = "Status GNRE";
                        mButton = MessageBoxButtons.OK;
                        mIcon = MessageBoxIcon.Information;
                        System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    }

                    else if (chkExportadas.Checked == false && chkNaoExportadas.Checked == false && chkBloqueadas.Checked == true)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and flg_BloqExport = 1 ";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == false && chkNaoExportadas.Checked == true && chkBloqueadas.Checked == false)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and Dat_Export is null and flg_BloqExport = 0 ";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == false && chkNaoExportadas.Checked == true && chkBloqueadas.Checked == true)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and Dat_Export is null and flg_BloqExport = 1 ";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }

                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == true && chkNaoExportadas.Checked == false && chkBloqueadas.Checked == false)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and Dat_Export is not null and flg_BloqExport = 0";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == true && chkNaoExportadas.Checked == false && chkBloqueadas.Checked == true)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and Dat_Export is not null and flg_BloqExport = 1";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == true && chkNaoExportadas.Checked == true && chkBloqueadas.Checked == false)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and flg_BloqExport = 0 ";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == true && chkNaoExportadas.Checked == true && chkBloqueadas.Checked == true)
                    {

                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando;

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                }

                //Transicao
                dgvtransicao.Rows.Clear();
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[11].Value.Equals(String.Empty) && !row.Cells[0].Value.Equals("B1"))
                    {
                        dgvtransicao.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value,
                                              row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value);
                    }
                }

                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[0].Value.Equals("B1"))
                    {
                        dgvtransicao.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value,
                                              row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value);
                    }
                }

                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (!row.Cells[11].Value.Equals(String.Empty) && !row.Cells[0].Value.Equals("B1"))
                    {
                        dgvtransicao.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value,
                                              row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value);
                    }
                }

                dgvDados.Rows.Clear();
                foreach (DataGridViewRow row in dgvtransicao.Rows)
                {
                    dgvDados.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value,
                                          row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value);
                }

                foreach (DataGridViewRow row in dgvDados.Rows)
                {

                    if (row.Cells[0].Value.Equals("B1"))
                    {
                        // Se estiver bloqueado, cor vermelha
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.BackColor = Color.DarkRed;
                        row.ReadOnly = true;
                    }

                    if (row.Cells[8].Value.Equals("R$ 0,00") && row.Cells[9].Value.Equals("R$ 0,00"))
                    {
                        row.Visible = false;
                    }

                    else if (!row.Cells[11].Value.Equals(String.Empty))
                    {
                        // Se já tiver sido exportado, fica cinza
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.BackColor = Color.Gray;
                    }




                }

                Preenche_Somatorio();
                this.Cursor = Cursors.Default;
            }
            else if (Usuario.unidade_Login == 3)
            {
                this.Cursor = Cursors.WaitCursor;
                dgvDados.Rows.Clear();
                lBloqueio.Clear();
                iGuiasParaGerar = 0;
                if (!txtNF.Text.Trim().Equals(String.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = " SELECT										NSCB.Num_Nota [Num_Nota]       " +
                                                        " ,C.CODIGO[Cod_Cliente] " +
                                                        " ,C.Razao_Social[Des_Cliente] " +
                                                        " ,NSCB.Estado[Estado] " +
                                                        " ,TBCFO.Descricao[Descricao] " +
                                                        " ,Convert(Date, NSCB.Dat_Emissao)[Dat_Emissao] " +
                                                        " ,isnull(NSCB.Vlr_TotalNota, 0)[Vlr_Nota] " +
                                                        " ,isnull(NSCB.Vlr_IcmIntUfDes, 0)[Vlr_GNRE] " +
                                                        " ,isnull(NSCB.Vlr_IcmFCPUfDes, 0)[Vlr_FCP] " +
                                                        " ,GNR.Dat_Bloqueio[Dat_Bloqueio] " +
                                                        " ,GNR.Dat_Export[Dat_Export] " +
                                                        " ,GNR.Obs_GNRE " +
                                                        " ,GNR.flg_BloqExport " +
                                                        " FROM NFSCB NSCB " +
                                                        " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                        " INNER JOIN UNIDB.dbo.NSGNR GNR ON GNR.NUM_NOTA = NSCB.NUM_NOTA " +
                                                        " INNER JOIN DMD.dbo.TBCFO ON Cod_Cfo1 = TBCFO.Codigo " +
                                                        " WHERE(STATUS = 'F' and Ser_Nota NOT LIKE 'XXX')" +
                                                        " AND NSCB.Num_Nota = " + txtNF.Text.Trim();

                            command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                            command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Des_Cliente"] != null)
                                {

                                    if (reader["flg_BloqExport"].ToString().Equals("1"))
                                    {
                                        bloqueio = "B1";

                                    }
                                    else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                    {
                                        bloqueio = "B0";
                                    }


                                    dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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
                    this.Cursor = Cursors.Default;
                    return;
                }

                String comando;

                if (!txtCliente.Text.Trim().Equals(String.Empty))
                {
                    comando = " SELECT										NSCB.Num_Nota [Num_Nota]       " +
                                                        " ,C.CODIGO[Cod_Cliente] " +
                                                        " ,C.Razao_Social[Des_Cliente] " +
                                                        " ,NSCB.Estado[Estado] " +
                                                        " ,TBCFO.Descricao[Descricao] " +
                                                        " ,Convert(Date, NSCB.Dat_Emissao)[Dat_Emissao] " +
                                                        " ,isnull(NSCB.Vlr_TotalNota, 0)[Vlr_Nota] " +
                                                        " ,isnull(NSCB.Vlr_IcmIntUfDes, 0)[Vlr_GNRE] " +
                                                        " ,isnull(NSCB.Vlr_IcmFCPUfDes, 0)[Vlr_FCP] " +
                                                        " ,GNR.Dat_Bloqueio[Dat_Bloqueio] " +
                                                        " ,GNR.Dat_Export[Dat_Export] " +
                                                        " ,GNR.Obs_GNRE " +
                                                        " ,GNR.flg_BloqExport " +
                                                        " FROM NFSCB NSCB " +
                                                        " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                        " INNER JOIN UNIDB.dbo.NSGNR GNR ON GNR.NUM_NOTA = NSCB.NUM_NOTA " +
                                                        " INNER JOIN DMD.dbo.TBCFO ON Cod_Cfo1 = TBCFO.Codigo " +
                                                        " WHERE(STATUS = 'F' and Ser_Nota NOT LIKE 'XXX')" +
                                                        " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL " +
                                                        " AND C.CODIGO = " + txtCod_Cliente.Text.Trim();
                }
                else if (!txtUFDesc.Text.Trim().Equals(String.Empty))
                {
                    comando = " SELECT										NSCB.Num_Nota [Num_Nota]       " +
                                                       " ,C.CODIGO[Cod_Cliente] " +
                                                       " ,C.Razao_Social[Des_Cliente] " +
                                                       " ,NSCB.Estado[Estado] " +
                                                       " ,TBCFO.Descricao[Descricao] " +
                                                       " ,Convert(Date, NSCB.Dat_Emissao)[Dat_Emissao] " +
                                                       " ,isnull(NSCB.Vlr_TotalNota, 0)[Vlr_Nota] " +
                                                       " ,isnull(NSCB.Vlr_IcmIntUfDes, 0)[Vlr_GNRE] " +
                                                       " ,isnull(NSCB.Vlr_IcmFCPUfDes, 0)[Vlr_FCP] " +
                                                       " ,GNR.Dat_Bloqueio[Dat_Bloqueio] " +
                                                       " ,GNR.Dat_Export[Dat_Export] " +
                                                       " ,GNR.Obs_GNRE " +
                                                       " ,GNR.flg_BloqExport " +
                                                       " FROM NFSCB NSCB " +
                                                       " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                       " INNER JOIN UNIDB.dbo.NSGNR GNR ON GNR.NUM_NOTA = NSCB.NUM_NOTA " +
                                                       " INNER JOIN DMD.dbo.TBCFO ON Cod_Cfo1 = TBCFO.Codigo " +
                                                       " WHERE(STATUS = 'F' and Ser_Nota NOT LIKE 'XXX')" +
                                                       " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL " +
                                                       " AND NSCB.Estado like '" + txtUF.Text.Trim().ToUpper() + "' ";
                }
                else
                {
                    comando = " SELECT										NSCB.Num_Nota [Num_Nota]       " +
                                                        " ,C.CODIGO[Cod_Cliente] " +
                                                        " ,C.Razao_Social[Des_Cliente] " +
                                                        " ,NSCB.Estado[Estado] " +
                                                        " ,TBCFO.Descricao[Descricao] " +
                                                        " ,Convert(Date, NSCB.Dat_Emissao)[Dat_Emissao] " +
                                                        " ,isnull(NSCB.Vlr_TotalNota, 0)[Vlr_Nota] " +
                                                        " ,isnull(NSCB.Vlr_IcmIntUfDes, 0)[Vlr_GNRE] " +
                                                        " ,isnull(NSCB.Vlr_IcmFCPUfDes, 0)[Vlr_FCP] " +
                                                        " ,GNR.Dat_Bloqueio[Dat_Bloqueio] " +
                                                        " ,GNR.Dat_Export[Dat_Export] " +
                                                        " ,GNR.Obs_GNRE " +
                                                        " ,GNR.flg_BloqExport " +
                                                        " FROM NFSCB NSCB " +
                                                        " INNER JOIN DMD.dbo.CLIEN C ON C.Codigo = NSCB.Cod_Cliente " +
                                                        " INNER JOIN UNIDB.dbo.NSGNR GNR ON GNR.NUM_NOTA = NSCB.NUM_NOTA " +
                                                        " INNER JOIN DMD.dbo.TBCFO ON Cod_Cfo1 = TBCFO.Codigo " +
                                                        " WHERE(STATUS = 'F' and Ser_Nota NOT LIKE 'XXX')" +
                                                        " AND NSCB.Dat_Emissao BETWEEN @DT_INICIAL AND @DT_FINAL ";

                }


                //Filtros gerais
                if (chkTodasAsGuias.Checked == true)
                {

                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = comando;

                            command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                            command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["Des_Cliente"] != null)
                                {


                                    if (reader["flg_BloqExport"].ToString().Equals("1"))
                                    {
                                        bloqueio = "B1";

                                    }
                                    else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                    {
                                        bloqueio = "B0";
                                    }




                                    dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString()
                                        , reader["Des_Cliente"].ToString(), reader["Estado"].ToString()
                                        , reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString()
                                        ,Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C")
                                        , Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C")
                                        , Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C")
                                        , reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString()
                                        , reader["Obs_GNRE"].ToString());

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
                else
                {


                    //Foco cliente           
                    if (chkExportadas.Checked == false && chkNaoExportadas.Checked == false && chkBloqueadas.Checked == false)
                    {
                        mMessage = "Selecione algum filtro de status.";
                        mTittle = "Status GNRE";
                        mButton = MessageBoxButtons.OK;
                        mIcon = MessageBoxIcon.Information;
                        System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                    }

                    else if (chkExportadas.Checked == false && chkNaoExportadas.Checked == false && chkBloqueadas.Checked == true)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and flg_BloqExport = 1 ";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());

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

                    else if (chkExportadas.Checked == false && chkNaoExportadas.Checked == true && chkBloqueadas.Checked == false)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();
                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and Dat_Export is null and flg_BloqExport = 0 ";
                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));
                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());

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

                    else if (chkExportadas.Checked == false && chkNaoExportadas.Checked == true && chkBloqueadas.Checked == true)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and Dat_Export is null and flg_BloqExport = 1 ";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }

                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == true && chkNaoExportadas.Checked == false && chkBloqueadas.Checked == false)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and Dat_Export is not null and flg_BloqExport = 0";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == true && chkNaoExportadas.Checked == false && chkBloqueadas.Checked == true)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and Dat_Export is not null and flg_BloqExport = 1";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString()
                                            , reader["Des_Cliente"].ToString(), reader["Estado"].ToString()
                                            , reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString()
                                            , Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C")
                                            , Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C")
                                            , Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C")
                                            , reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString()
                                            , reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == true && chkNaoExportadas.Checked == true && chkBloqueadas.Checked == false)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando + " and flg_BloqExport = 0 ";

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                    else if (chkExportadas.Checked == true && chkNaoExportadas.Checked == true && chkBloqueadas.Checked == true)
                    {

                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = comando;

                                command.Parameters.AddWithValue("DT_INICIAL", Convert.ToDateTime(dtpDtInicial.Text));
                                command.Parameters.AddWithValue("DT_FINAL", Convert.ToDateTime(dtpDtFinal.Text));


                                reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    if (reader["Des_Cliente"] != null)
                                    {


                                        if (reader["flg_BloqExport"].ToString().Equals("1"))
                                        {
                                            bloqueio = "B1";

                                        }
                                        else if (reader["flg_BloqExport"].ToString().Equals("0"))
                                        {
                                            bloqueio = "B0";
                                        }
                                        dgvDados.Rows.Add(bloqueio, reader["Num_Nota"].ToString(), reader["Cod_Cliente"].ToString(), reader["Des_Cliente"].ToString(), reader["Estado"].ToString(), reader["Descricao"].ToString(), reader["Dat_Emissao"].ToString(), Convert.ToDouble(reader["Vlr_Nota"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_GNRE"].ToString()).ToString("C"), Convert.ToDouble(reader["Vlr_FCP"].ToString()).ToString("C"), reader["Dat_Bloqueio"].ToString(), reader["Dat_Export"].ToString(), reader["Obs_GNRE"].ToString());







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

                }

                //Transicao
                dgvtransicao.Rows.Clear();
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[11].Value.Equals(String.Empty) && !row.Cells[0].Value.Equals("B1"))
                    {
                        dgvtransicao.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value,
                                              row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value);
                    }
                }

                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[0].Value.Equals("B1"))
                    {
                        dgvtransicao.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value,
                                              row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value);
                    }
                }

                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (!row.Cells[11].Value.Equals(String.Empty) && !row.Cells[0].Value.Equals("B1"))
                    {
                        dgvtransicao.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value,
                                              row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value);
                    }
                }

                dgvDados.Rows.Clear();
                foreach (DataGridViewRow row in dgvtransicao.Rows)
                {
                    dgvDados.Rows.Add(row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value, row.Cells[6].Value,
                                          row.Cells[7].Value, row.Cells[8].Value, row.Cells[9].Value, row.Cells[10].Value, row.Cells[11].Value, row.Cells[12].Value);
                }

                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[4].Value.Equals("SP"))
                    //row.Cells[4].Value.Equals("RJ") || 
                    //row.Cells[4].Value.Equals("ES"))
                    {
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.BackColor = Color.DarkGreen;
                    }

                    //else if (row.Cells[4].Value.Equals("BA") || row.Cells[4].Value.Equals("RN") || row.Cells[4].Value.Equals("PB") || row.Cells[4].Value.Equals("CE") || row.Cells[4].Value.Equals("AL"))
                    //{
                    //    row.DefaultCellStyle.ForeColor = Color.White;
                    //    row.DefaultCellStyle.BackColor = Color.DarkKhaki;
                    //}

                    if (row.Cells[0].Value.Equals("B1"))
                    {
                        // Se estiver bloqueado, cor vermelha
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.BackColor = Color.DarkRed;
                        row.ReadOnly = true;
                    }

                    if (row.Cells[8].Value.Equals("R$ 0,00") && row.Cells[9].Value.Equals("R$ 0,00"))
                    {
                        row.Visible = false;
                    }

                    else if (!row.Cells[11].Value.Equals(String.Empty))
                    {
                        // Se já tiver sido exportado, fica cinza
                        row.DefaultCellStyle.ForeColor = Color.White;
                        row.DefaultCellStyle.BackColor = Color.Gray;
                    }




                }

                Preenche_Somatorio();
                this.Cursor = Cursors.Default;
            }
        }



        //Cliente
        //Pesquisa de cliente por código
        private void TxtCod_Cliente_TextChanged(object sender, EventArgs e)
        {
            
                txtCliente.Clear();
                if (!txtCod_Cliente.Text.Trim().Equals(string.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            //Comando sql
                            command = new SqlCommand("SELECT C.Razao_Social FROM DMD.[dbo].CLIEN C WHERE C.CODIGO = " + txtCod_Cliente.Text, connectDMD);
                            connectDMD.Open();
                            reader = command.ExecuteReader();
                            //Verifica se ocorrerá alteração de senha
                            while (reader.Read())
                            {
                                if (reader["Razao_Social"] != null) //Sendo o leitor diferente de nulo
                                {

                                    txtCliente.Text = (reader["Razao_Social"].ToString());
                                }
                            }
                            reader.Close();

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
            
           
        }
        //Botão para selecionar cliente
        private void BtnProcurarCliente_Click(object sender, EventArgs e)
        {
            frmCriarCi_EscolherCliente form = new frmCriarCi_EscolherCliente();
            
            form.ShowDialog();
            if (form.cod_cliente != 0)
            {
                txtCod_Cliente.Text = Convert.ToString(form.cod_cliente);
            }
        }


        //Load do form
        private void FrmExportar_GNRE_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;

            //Configurações iniciais
            Carregar_Bloqueios();
            Carregar_Permissoes();
            Configuracoes_Iniciais();
        }

        private void DgvDados_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnGerarManual.Enabled = true;
            btnGerarManual.BackColor = Color.OliveDrab;
        }

        private void BtnGerarManual_Click(object sender, EventArgs e)
        {            
                frmGerarManual form = new frmGerarManual();                
                form.ShowDialog();
                if (form.txtObs.Text.Trim().Length > 0)
                {

                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "UPDATE UNIDB.dbo.NSGNR set Dat_Export = Getdate(), Obs_GNRE = '" + form.txtObs.Text + "' " +
                            ",Usuario = '" + Usuario.userDesc + "' where num_nota = " + dgvDados.CurrentRow.Cells[1].Value.ToString();
                            command.ExecuteNonQuery();
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


                    Filtrar_Dados();
                }
                else
                {
                    return;
                }                    
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            Filtrar_Dados();
            BtnRemoverTodos_Click(btnPesquisar, new EventArgs());
        }

        //Altera o status das guias
        private void ChkTodasAsGuias_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodasAsGuias.Checked == true)
            {
                gpbStatus.Enabled = false;
            }
            else
            {
                gpbStatus.Enabled = true;
            }
        }


        //Adicionar tudo
        private void BtnExportarTodos_Click(object sender, EventArgs e)
        {

            if (Usuario.unidade_Login == 1)
            {
                iGuiasParaGerar = 0;
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[0].Value.ToString() != "B1" && (row.Cells[4].Value.ToString() != "SP" && row.Cells[4].Value.ToString() != "ES"
                        //&& row.Cells[4].Value.ToString() != "RJ" 
                        && row.Cells[4].Value.ToString() != "BA" && row.Cells[4].Value.ToString() != "RN" && row.Cells[4].Value.ToString() != "PB"
                        && row.Cells[4].Value.ToString() != "CE" && row.Cells[4].Value.ToString() != "AL" && row.Cells[4].Value.ToString() != "AM"
                        && row.Cells[4].Value.ToString() != "MA"))
                        if (row.Cells[0].Value.ToString() != "B1" && (row.Cells[4].Value.ToString() != "SP" && row.Cells[4].Value.ToString() != "ES"
                            //&& row.Cells[4].Value.ToString() != "RJ"
                            && row.Cells[4].Value.ToString() != "BA" && row.Cells[4].Value.ToString() != "RN" && row.Cells[4].Value.ToString() != "PB"
                            && row.Cells[4].Value.ToString() != "CE" && row.Cells[4].Value.ToString() != "AL" && row.Cells[4].Value.ToString() != "AM"
                            && row.Cells[4].Value.ToString() != "MA"))
                        {
                            if (!lsbExportar.Items.Contains(row.Cells[1].Value.ToString()))
                            {

                                if (row.Cells[11].Value.Equals(String.Empty))
                                {
                                    lsbExportar.Items.Add(row.Cells[1].Value.ToString());
                                    row.Visible = false;
                                    if ((row.Cells[8].Value.ToString() != "R$ 0,00") && (row.Cells[9].Value.ToString() != "R$ 0,00"))
                                        iGuiasParaGerar = iGuiasParaGerar + 2;
                                    else if (row.Cells[9].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                    else if (row.Cells[8].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                }
                            }
                        }
                }
                txtGuias.Text = iGuiasParaGerar.ToString();

                if (lsbExportar.Items.Count > 0)
                {
                    btnCancelar.Visible = true;

                    btnFecharConfirmar.Size = new Size(100, 34);
                    btnFecharConfirmar.BackColor = Color.Green;
                    btnFecharConfirmar.Text = "Exportar";
                }
                else
                {
                    btnCancelar.Visible = false;

                    btnFecharConfirmar.BackColor = Color.Gray;

                    btnFecharConfirmar.Text = "Fechar";
                }
            }
            else if (Usuario.unidade_Login == 2)
            {
                iGuiasParaGerar = 0;
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[0].Value.ToString() != "B1")
                        if (row.Cells[0].Value.ToString() != "B1")
                        {
                            if (!lsbExportar.Items.Contains(row.Cells[1].Value.ToString()))
                            {

                                if (row.Cells[11].Value.Equals(String.Empty))
                                {
                                    lsbExportar.Items.Add(row.Cells[1].Value.ToString());
                                    row.Visible = false;
                                    if ((row.Cells[8].Value.ToString() != "R$ 0,00") && (row.Cells[9].Value.ToString() != "R$ 0,00"))
                                        iGuiasParaGerar = iGuiasParaGerar + 2;
                                    else if (row.Cells[9].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                    else if (row.Cells[8].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                }
                            }
                        }
                }
                txtGuias.Text = iGuiasParaGerar.ToString();

                if (lsbExportar.Items.Count > 0)
                {
                    btnCancelar.Visible = true;

                    btnFecharConfirmar.Size = new Size(100, 34);
                    btnFecharConfirmar.BackColor = Color.Green;
                    btnFecharConfirmar.Text = "Exportar";
                }
                else
                {
                    btnCancelar.Visible = false;

                    btnFecharConfirmar.BackColor = Color.Gray;

                    btnFecharConfirmar.Text = "Fechar";
                }
            }
            else if (Usuario.unidade_Login == 3)
            {
                iGuiasParaGerar = 0;
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[0].Value.ToString() != "B1")
                        if (row.Cells[0].Value.ToString() != "B1")
                        {
                            if (!lsbExportar.Items.Contains(row.Cells[1].Value.ToString()))
                            {

                                if (row.Cells[11].Value.Equals(String.Empty))
                                {
                                    lsbExportar.Items.Add(row.Cells[1].Value.ToString());
                                    row.Visible = false;
                                    if ((row.Cells[8].Value.ToString() != "R$ 0,00") && (row.Cells[9].Value.ToString() != "R$ 0,00"))
                                        iGuiasParaGerar = iGuiasParaGerar + 2;
                                    else if (row.Cells[9].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                    else if (row.Cells[8].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                }
                            }
                        }
                }
                txtGuias.Text = iGuiasParaGerar.ToString();

                if (lsbExportar.Items.Count > 0)
                {
                    btnCancelar.Visible = true;

                    btnFecharConfirmar.Size = new Size(100, 34);
                    btnFecharConfirmar.BackColor = Color.Green;
                    btnFecharConfirmar.Text = "Exportar";
                }
                else
                {
                    btnCancelar.Visible = false;

                    btnFecharConfirmar.BackColor = Color.Gray;

                    btnFecharConfirmar.Text = "Fechar";
                }
            }
        }

        //Remover todos
        private void BtnRemoverTodos_Click(object sender, EventArgs e)
        {
            while (lsbExportar.Items.Count != 0)
            {
                String itens = lsbExportar.Items[0].ToString();
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[1].Value.ToString() == itens.ToString())
                    {
                        row.Visible = true;
                        break;
                    }
                }
                lsbExportar.Items.Remove(itens);
            }
            txtGuias.Text = 0.ToString();

            btnCancelar.Visible = false;

            btnFecharConfirmar.BackColor = Color.Gray;

            btnFecharConfirmar.Text = "Fechar";
            btnCancelar.Visible = false;
        }

        //Removendo itens
        private void LsbExportar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsbExportar.SelectedItem != null)
            {
                int indice = 0;
                foreach (DataGridViewRow row in dgvDados.Rows)
                {
                    if (row.Cells[1].Value.ToString() == lsbExportar.SelectedItem.ToString())
                    {
                        row.Visible = true;
                        indice = row.Index;
                        break;
                    }
                }


                if ((dgvDados.Rows[indice].Cells[8].Value.ToString() != "R$ 0,00") && (dgvDados.Rows[indice].Cells[9].Value.ToString() != "R$ 0,00"))
                {
                    iGuiasParaGerar = Convert.ToInt32(txtGuias.Text);
                    txtGuias.Text = (iGuiasParaGerar = iGuiasParaGerar - 2).ToString();
                }
                else if (dgvDados.Rows[indice].Cells[9].Value.ToString() != "R$ 0,00")
                {
                    iGuiasParaGerar = Convert.ToInt32(txtGuias.Text);
                    txtGuias.Text = (iGuiasParaGerar = iGuiasParaGerar - 1).ToString();
                }
                else if (dgvDados.Rows[indice].Cells[8].Value.ToString() != "R$ 0,00")
                {
                    iGuiasParaGerar = Convert.ToInt32(txtGuias.Text);
                    txtGuias.Text = (iGuiasParaGerar = iGuiasParaGerar - 1).ToString();

                }
                lsbExportar.Items.Remove(lsbExportar.SelectedItem);

            }
            if (lsbExportar.Items.Count > 0)
            {
                btnCancelar.Visible = true;

                btnFecharConfirmar.Size = new Size(100, 34);
                btnFecharConfirmar.BackColor = Color.Green;
                btnFecharConfirmar.Text = "Exportar";
            }
            else
            {
                btnCancelar.Visible = false;

                btnFecharConfirmar.BackColor = Color.Gray;

                btnFecharConfirmar.Text = "Fechar";
            }
        }

        //Adicionando itens
        private void DgvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Usuario.unidade_Login == 1)
            {
                if (Permissao_Exportar == true)
                {
                    DataGridView.HitTestInfo hit = dgvDados.HitTest(e.X, e.Y);
                    if (hit.Type == DataGridViewHitTestType.ColumnHeader)
                    {
                        return;
                    }

                    if (dgvDados.Rows.Count > 0)
                    {
                        if (!lsbExportar.Items.Contains(dgvDados.CurrentRow.Cells[1].Value.ToString()))
                        {

                            if (dgvDados.CurrentRow.Cells[0].Value.ToString() == "B1")
                            {
                                mMessage = "Deseja desbloquear a guia?";
                                mTittle = "Desbloqueio de Guia";
                                mButton = MessageBoxButtons.YesNo;
                                mIcon = MessageBoxIcon.Question;
                                options = System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);

                                if (options == DialogResult.Yes)
                                {
                                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                                    {
                                        try
                                        {
                                            connectDMD.Open();

                                            command = connectDMD.CreateCommand();
                                            command.CommandText = "UPDATE UNIDB.dbo.NSGNR set flg_BloqExport = 0" +
                                                ", Dat_Bloqueio = Getdate()" +
                                                ", Usuario = '" + Usuario.userDesc + 
                                                "' where num_nota = " + dgvDados.CurrentRow.Cells[1].Value.ToString();



                                            command.ExecuteNonQuery();



                                        }
                                        catch (SqlException SQLe)
                                        {
                                            erro_DeAcesso(SQLe);
                                        }
                                        finally
                                        {
                                            connectDMD.Close();
                                            dgvDados.CurrentCell.Value = "B0";
                                            Filtrar_Dados();

                                            if ((dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00") && (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00"))
                                                iGuiasParaGerar = iGuiasParaGerar + 2;
                                            else if (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00")
                                                iGuiasParaGerar++;
                                            else if (dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00")
                                                iGuiasParaGerar++;
                                            lsbExportar.Items.Add(dgvDados.CurrentRow.Cells[1].Value.ToString());
                                            dgvDados.CurrentRow.Visible = false;
                                        }


                                    }
                                }
                                else
                                    return;
                            }

                            if (dgvDados.CurrentRow.Cells[4].Value.ToString() == "SP" ||
                                dgvDados.CurrentRow.Cells[4].Value.ToString() == "MA" ||
                                dgvDados.CurrentRow.Cells[4].Value.ToString() == "ES" &&
                                dgvDados.CurrentRow.Cells[4].Value.ToString() == "BA" &&
                                dgvDados.CurrentRow.Cells[4].Value.ToString() == "RN" &&
                                dgvDados.CurrentRow.Cells[4].Value.ToString() == "PB" &&
                                dgvDados.CurrentRow.Cells[4].Value.ToString() == "CE")
                            {
                                mMessage = dgvDados.CurrentRow.Cells[4].Value.ToString() + " não é uma UF contemplada, tem certeza que deseja adicionar para exportação?";
                                mTittle = "Estado não contemplado";
                                mButton = MessageBoxButtons.YesNo;
                                mIcon = MessageBoxIcon.Question;
                                options = System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);

                                if (options == DialogResult.Yes)
                                {

                                    if ((dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00") && (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00"))
                                        iGuiasParaGerar = iGuiasParaGerar + 2;
                                    else if (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                    else if (dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                    lsbExportar.Items.Add(dgvDados.CurrentRow.Cells[1].Value.ToString());
                                    dgvDados.CurrentRow.Visible = false;


                                }
                                else
                                    return;
                            }
                            else if (!dgvDados.CurrentRow.Cells[11].Value.ToString().Equals(String.Empty))
                            {
                                mMessage = "Esta guia já foi exportada, deseja realmente exportar?";
                                mTittle = "Guia já exportada";
                                mButton = MessageBoxButtons.YesNo;
                                mIcon = MessageBoxIcon.Question;
                                options = System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                                if (options == DialogResult.Yes)
                                {

                                    if ((dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00") && (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00"))
                                        iGuiasParaGerar = iGuiasParaGerar + 2;
                                    else if (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                    else if (dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                    lsbExportar.Items.Add(dgvDados.CurrentRow.Cells[1].Value.ToString());
                                    dgvDados.CurrentRow.Visible = false;
                                }
                                else
                                    return;
                            }
                            else
                            {
                                if ((dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00") && (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00"))
                                    iGuiasParaGerar = iGuiasParaGerar + 2;
                                else if (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00")
                                    iGuiasParaGerar++;
                                else if (dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00")
                                    iGuiasParaGerar++;
                                lsbExportar.Items.Add(dgvDados.CurrentRow.Cells[1].Value.ToString());
                                dgvDados.CurrentRow.Visible = false;
                            }


                            txtGuias.Text = iGuiasParaGerar.ToString();

                        }
                        else
                        {
                            mMessage = "Guia já se encontra na lista de exportação";
                            mTittle = "Guia GNRE";
                            mButton = MessageBoxButtons.OK;
                            mIcon = MessageBoxIcon.Question;
                            System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                        }


                        if (lsbExportar.Items.Count > 0)
                        {
                            btnCancelar.Visible = true;

                            btnFecharConfirmar.Size = new Size(100, 34);
                            btnFecharConfirmar.BackColor = Color.Green;
                            btnFecharConfirmar.Text = "Exportar";
                        }
                        else
                        {
                            btnCancelar.Visible = false;

                            btnFecharConfirmar.BackColor = Color.Gray;

                            btnFecharConfirmar.Text = "Fechar";
                        }
                    }
                }
            }
            else if (Usuario.unidade_Login == 2)
            {
                if (Permissao_Exportar == true)
                {
                    DataGridView.HitTestInfo hit = dgvDados.HitTest(e.X, e.Y);
                    if (hit.Type == DataGridViewHitTestType.ColumnHeader)
                    {
                        return;
                    }

                    if (dgvDados.Rows.Count > 0)
                    {
                        if (!lsbExportar.Items.Contains(dgvDados.CurrentRow.Cells[1].Value.ToString()))
                        {

                            if (dgvDados.CurrentRow.Cells[0].Value.ToString() == "B1")
                            {
                                mMessage = "Deseja desbloquear a guia?";
                                mTittle = "Desbloqueio de Guia";
                                mButton = MessageBoxButtons.YesNo;
                                mIcon = MessageBoxIcon.Question;
                                options = System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);

                                if (options == DialogResult.Yes)
                                {
                                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                                    {
                                        try
                                        {
                                            connectDMD.Open();

                                            command = connectDMD.CreateCommand();
                                            command.CommandText = "UPDATE UNIDB.dbo.NSGNR set flg_BloqExport = 0" +
                                                ", Dat_Bloqueio = Getdate()" +
                                                ", Usuario = '" + Usuario.userDesc +
                                                "' where num_nota = " + dgvDados.CurrentRow.Cells[1].Value.ToString();



                                            command.ExecuteNonQuery();



                                        }
                                        catch (SqlException SQLe)
                                        {
                                            erro_DeAcesso(SQLe);
                                        }
                                        finally
                                        {
                                            connectDMD.Close();
                                            dgvDados.CurrentCell.Value = "B0";
                                            Filtrar_Dados();

                                            if ((dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00") && (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00"))
                                                iGuiasParaGerar = iGuiasParaGerar + 2;
                                            else if (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00")
                                                iGuiasParaGerar++;
                                            else if (dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00")
                                                iGuiasParaGerar++;
                                            lsbExportar.Items.Add(dgvDados.CurrentRow.Cells[1].Value.ToString());
                                            dgvDados.CurrentRow.Visible = false;
                                        }


                                    }
                                }
                                else
                                    return;
                            }

                            else if (!dgvDados.CurrentRow.Cells[11].Value.ToString().Equals(String.Empty))
                            {
                                mMessage = "Esta guia já foi exportada, deseja realmente exportar?";
                                mTittle = "Guia já exportada";
                                mButton = MessageBoxButtons.YesNo;
                                mIcon = MessageBoxIcon.Question;
                                options = System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                                if (options == DialogResult.Yes)
                                {

                                    if ((dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00") && (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00"))
                                        iGuiasParaGerar = iGuiasParaGerar + 2;
                                    else if (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                    else if (dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                    lsbExportar.Items.Add(dgvDados.CurrentRow.Cells[1].Value.ToString());
                                    dgvDados.CurrentRow.Visible = false;
                                }
                                else
                                    return;
                            }
                            else
                            {
                                if ((dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00") && (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00"))
                                    iGuiasParaGerar = iGuiasParaGerar + 2;
                                else if (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00")
                                    iGuiasParaGerar++;
                                else if (dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00")
                                    iGuiasParaGerar++;
                                lsbExportar.Items.Add(dgvDados.CurrentRow.Cells[1].Value.ToString());
                                dgvDados.CurrentRow.Visible = false;
                            }


                            txtGuias.Text = iGuiasParaGerar.ToString();

                        }
                        else
                        {
                            mMessage = "Guia já se encontra na lista de exportação";
                            mTittle = "Guia GNRE";
                            mButton = MessageBoxButtons.OK;
                            mIcon = MessageBoxIcon.Question;
                            System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                        }


                        if (lsbExportar.Items.Count > 0)
                        {
                            btnCancelar.Visible = true;

                            btnFecharConfirmar.Size = new Size(100, 34);
                            btnFecharConfirmar.BackColor = Color.Green;
                            btnFecharConfirmar.Text = "Exportar";
                        }
                        else
                        {
                            btnCancelar.Visible = false;

                            btnFecharConfirmar.BackColor = Color.Gray;

                            btnFecharConfirmar.Text = "Fechar";
                        }
                    }
                }
            }
            else if (Usuario.unidade_Login == 3)
            {
                if (Permissao_Exportar == true)
                {
                    DataGridView.HitTestInfo hit = dgvDados.HitTest(e.X, e.Y);
                    if (hit.Type == DataGridViewHitTestType.ColumnHeader)
                    {
                        return;
                    }

                    if (dgvDados.Rows.Count > 0)
                    {
                        if (!lsbExportar.Items.Contains(dgvDados.CurrentRow.Cells[1].Value.ToString()))
                        {

                            if (dgvDados.CurrentRow.Cells[0].Value.ToString() == "B1")
                            {
                                mMessage = "Deseja desbloquear a guia?";
                                mTittle = "Desbloqueio de Guia";
                                mButton = MessageBoxButtons.YesNo;
                                mIcon = MessageBoxIcon.Question;
                                options = System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);

                                if (options == DialogResult.Yes)
                                {
                                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                                    {
                                        try
                                        {
                                            connectDMD.Open();

                                            command = connectDMD.CreateCommand();
                                            command.CommandText = "UPDATE UNIDB.dbo.NSGNR set flg_BloqExport = 0" +
                                                ", Dat_Bloqueio = Getdate(), Usuario = '" + Usuario.userDesc + "'" +
                                                " where num_nota = " + dgvDados.CurrentRow.Cells[1].Value.ToString();



                                            command.ExecuteNonQuery();



                                        }
                                        catch (SqlException SQLe)
                                        {
                                            erro_DeAcesso(SQLe);
                                        }
                                        finally
                                        {
                                            connectDMD.Close();
                                            dgvDados.CurrentCell.Value = "B0";
                                            Filtrar_Dados();

                                            if ((dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00") && (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00"))
                                                iGuiasParaGerar = iGuiasParaGerar + 2;
                                            else if (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00")
                                                iGuiasParaGerar++;
                                            else if (dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00")
                                                iGuiasParaGerar++;
                                            lsbExportar.Items.Add(dgvDados.CurrentRow.Cells[1].Value.ToString());
                                            dgvDados.CurrentRow.Visible = false;
                                        }


                                    }
                                }
                                else
                                    return;
                            }

                            if (dgvDados.CurrentRow.Cells[4].Value.ToString() == "SP" ||
                                dgvDados.CurrentRow.Cells[4].Value.ToString() == "MA" ||
                                dgvDados.CurrentRow.Cells[4].Value.ToString() == "ES" &&
                                dgvDados.CurrentRow.Cells[4].Value.ToString() == "BA" &&
                                dgvDados.CurrentRow.Cells[4].Value.ToString() == "RN" &&
                                dgvDados.CurrentRow.Cells[4].Value.ToString() == "PB" &&
                                dgvDados.CurrentRow.Cells[4].Value.ToString() == "CE")
                            {
                                mMessage = dgvDados.CurrentRow.Cells[4].Value.ToString() + " não é uma UF contemplada, tem certeza que deseja adicionar para exportação?";
                                mTittle = "Estado não contemplado";
                                mButton = MessageBoxButtons.YesNo;
                                mIcon = MessageBoxIcon.Question;
                                options = System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);

                                if (options == DialogResult.Yes)
                                {

                                    if ((dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00") && (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00"))
                                        iGuiasParaGerar = iGuiasParaGerar + 2;
                                    else if (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                    else if (dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                    lsbExportar.Items.Add(dgvDados.CurrentRow.Cells[1].Value.ToString());
                                    dgvDados.CurrentRow.Visible = false;


                                }
                                else
                                    return;
                            }
                            else if (!dgvDados.CurrentRow.Cells[11].Value.ToString().Equals(String.Empty))
                            {
                                mMessage = "Esta guia já foi exportada, deseja realmente exportar?";
                                mTittle = "Guia já exportada";
                                mButton = MessageBoxButtons.YesNo;
                                mIcon = MessageBoxIcon.Question;
                                options = System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                                if (options == DialogResult.Yes)
                                {

                                    if ((dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00") && (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00"))
                                        iGuiasParaGerar = iGuiasParaGerar + 2;
                                    else if (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                    else if (dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00")
                                        iGuiasParaGerar++;
                                    lsbExportar.Items.Add(dgvDados.CurrentRow.Cells[1].Value.ToString());
                                    dgvDados.CurrentRow.Visible = false;
                                }
                                else
                                    return;
                            }
                            else
                            {
                                if ((dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00") && (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00"))
                                    iGuiasParaGerar = iGuiasParaGerar + 2;
                                else if (dgvDados.CurrentRow.Cells[9].Value.ToString() != "R$ 0,00")
                                    iGuiasParaGerar++;
                                else if (dgvDados.CurrentRow.Cells[8].Value.ToString() != "R$ 0,00")
                                    iGuiasParaGerar++;
                                lsbExportar.Items.Add(dgvDados.CurrentRow.Cells[1].Value.ToString());
                                dgvDados.CurrentRow.Visible = false;
                            }


                            txtGuias.Text = iGuiasParaGerar.ToString();

                        }
                        else
                        {
                            mMessage = "Guia já se encontra na lista de exportação";
                            mTittle = "Guia GNRE";
                            mButton = MessageBoxButtons.OK;
                            mIcon = MessageBoxIcon.Question;
                            System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                        }


                        if (lsbExportar.Items.Count > 0)
                        {
                            btnCancelar.Visible = true;

                            btnFecharConfirmar.Size = new Size(100, 34);
                            btnFecharConfirmar.BackColor = Color.Green;
                            btnFecharConfirmar.Text = "Exportar";
                        }
                        else
                        {
                            btnCancelar.Visible = false;

                            btnFecharConfirmar.BackColor = Color.Gray;

                            btnFecharConfirmar.Text = "Fechar";
                        }
                    }
                }
            }
        }

        private void DgvDados_MouseClick(object sender, MouseEventArgs e)
        {

        }
        //Ativa o botão de gerar manual
        private void DgvDados_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (Permissao_Exportar == true)
            {
                btnGerarManual.Enabled = true;
                btnGerarManual.BackColor = Color.OliveDrab;
            }
        }

        //Ativar e desativar bloqueio
        private void DgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                if (e.RowIndex == -1) return;
                //Desativa bloqueio
                if (dgvDados.CurrentCell.Value.ToString() == "B1")
                {


                    if (lBloqueio.Contains(dgvDados.CurrentRow.Cells[1].Value.ToString()))
                    {
                        dgvDados.CurrentCell.Value = "B0";
                        lBloqueio.Remove(dgvDados.CurrentRow.Cells[1].Value.ToString());
                    }
                    else
                    {
                        mMessage = "Deseja desbloquear a guia?";
                        mTittle = "Desbloqueio de Guia";
                        mButton = MessageBoxButtons.YesNo;
                        mIcon = MessageBoxIcon.Question;
                        options = System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);

                        if (options == DialogResult.Yes)
                        {
                            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                            {
                                try
                                {
                                    connectDMD.Open();

                                    command = connectDMD.CreateCommand();
                                    command.CommandText = "UPDATE UNIDB.dbo.NSGNR set flg_BloqExport = 0" +
                                        ", Dat_Bloqueio = Getdate(), Usuario = '" + Usuario.userDesc + "' " +
                                        " where num_nota = " + dgvDados.CurrentRow.Cells[1].Value.ToString();



                                    command.ExecuteNonQuery();



                                }
                                catch (SqlException SQLe)
                                {
                                    erro_DeAcesso(SQLe);
                                }
                                finally
                                {
                                    connectDMD.Close();
                                    dgvDados.CurrentCell.Value = "B0";
                                    Filtrar_Dados();
                                }


                            }
                        }
                        else
                            return;

                    }


                }

                //Ativa bloqueio
                else if (dgvDados.CurrentCell.Value.ToString() == "B0")
                {
                    dgvDados.CurrentCell.Value = "B1";
                    lBloqueio.Add(dgvDados.CurrentRow.Cells[1].Value.ToString());
                }
            
           
        }

        private void BtnBloquear_Click(object sender, EventArgs e)
        {
            if (lBloqueio.Count == 0)
            {
                mMessage = "Selecione notas para bloquear";
                mTittle = "Bloqueio";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Information;
                System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                return;
            }

            frmObservacao_Gnre form = new frmObservacao_Gnre();            
            form.ShowDialog();

            if (form.txtObs.Text.Trim().Length > 0)
            {
                for (int x = 0; x < lBloqueio.Count; x++)
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            connectDMD.Open();

                            command = connectDMD.CreateCommand();
                            command.CommandText = "UPDATE UNIDB.dbo.NSGNR set flg_BloqExport = 1" +
                                ", Dat_Bloqueio = Getdate(), Obs_GNRE = '" + form.txtObs.Text + "', Usuario = '" + Usuario.userDesc + "'  where num_nota = " + lBloqueio[x];
                            command.ExecuteNonQuery();
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
                Filtrar_Dados();
            }
            else
            {
                return;
            }

        }

        private void BtnFecharConfirmar_Click(object sender, EventArgs e)
        {
           
                if (btnFecharConfirmar.Text == "Exportar")
                {
                    //Exportar lote
                    construir_Arquivo();

                    //Editar cadastro
                    foreach (var items in lsbExportar.Items)
                    {
                        using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                        {
                            try
                            {
                                connectDMD.Open();

                                command = connectDMD.CreateCommand();
                                command.CommandText = "UPDATE UNIDB.dbo.NSGNR set Dat_Export = Getdate(), Usuario = '" + Usuario.userDesc + "'" +
                                    "  where num_nota = " + items;



                                command.ExecuteNonQuery();



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

                    //Reiniciar tela atualizada
                    Filtrar_Dados();
                    BtnRemoverTodos_Click(btnExportarTodos, new EventArgs());
                }
                else
                {
                    this.Close();
                }
            
        

        }

        private void BtnGNRE_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnGNRE_Click(object sender, EventArgs e)
        {
            // Navigate to a URL.
            this.Cursor = Cursors.WaitCursor;
            System.Diagnostics.Process pStart = new System.Diagnostics.Process();
            pStart.StartInfo = new System.Diagnostics.ProcessStartInfo(@"http://www.gnre.pe.gov.br/gnre/v/lote/gerar");
            pStart.Start();
            this.Cursor = Cursors.Default;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            BtnRemoverTodos_Click(btnCancelar, new EventArgs());
        }



        //Estado [UF]
        //Pesquisar por UF
        private void TxtUF_TextChanged(object sender, EventArgs e)
        {
           
                txtUFDesc.Clear();
                if (!txtUF.Text.Trim().Equals(string.Empty))
                {
                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {
                        try
                        {
                            //Comando sql
                            command = new SqlCommand("SELECT UF.Descricao FROM DMD.[dbo].ESTAD UF WHERE UF.CODIGO LIKE '" + txtUF.Text.Trim().ToUpper() + "'", connectDMD);
                            connectDMD.Open();
                            reader = command.ExecuteReader();
                            //Verifica se ocorrerá alteração de senha
                            while (reader.Read())
                            {
                                if (reader["Descricao"] != null) //Sendo o leitor diferente de nulo
                                {

                                    txtUFDesc.Text = (reader["Descricao"].ToString());
                                }
                            }
                            reader.Close();

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
            
      
        }



        //Pesquisar por enter
        private void Pesquisar_Com_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnPesquisar_Click(btnPesquisar, new EventArgs());
            }
        }

        private void txtNF_TextChanged(object sender, EventArgs e)
        {

        }

        //Sair com esc
        private void FrmExportar_GNRE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }
        }
    }
}