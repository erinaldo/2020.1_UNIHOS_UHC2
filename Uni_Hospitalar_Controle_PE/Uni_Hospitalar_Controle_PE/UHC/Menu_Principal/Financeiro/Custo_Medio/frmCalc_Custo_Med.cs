using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ulib;
using Uni_Hospitalar_Controle_PE.Background_Software;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Custo_Medio
{
    public partial class frmCalc_Custo_Med : Form
    {

        

        public frmCalc_Custo_Med()
        {
            InitializeComponent();
            
        }

   

        //Instância SQL

        //SQL variáveis de manipulações de dados.
        private SqlCommand command = new SqlCommand();
        private SqlDataReader reader;

        //SQL exception
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
        //private DialogResult options;

        
        //Custo Inicial
        List<int> iList_CustoInicial_CodProduto = new List<int>();
        List<double> dList_CustoInicial_VlrProduto = new List<double>();
        List<int> iList_CustoInicial_Estoque = new List<int>();

        //Custo Calculado
        List<int> iList_CalcCusto_ProtocoloNF = new List<int>();
        List<DateTime> dtList_CalcCusto_Transacao = new List<DateTime>();
        List<int> iList_CalcCusto_CodProduto = new List<int>();
        List<String> sList_CalcCusto_DescProduto = new List<String>();
        List<int> iList_CalcCusto_CFOP = new List<int>();
        List<double> dList_CalcCusto_PrcUnitario = new List<double>();
        List<int> iList_CalcCusto_Quantidade = new List<int>();
        List<String> sList_CalcCusto_Tipo = new List<String>();
        List<int> iList_CalcCusto_MovEst = new List<int>();
        List<int> iList_CalcCusto_EstAnterior = new List<int>();

        //Variável utilizada na composição da lógica do custo.
        int ContaNotas = 0;
         
        private void carregar_Informacoes_Custo_Inicial()
        {
            //Dados iniciais da UNIPE vindos do RI 2019/2020
            if (Usuario.unidade_Login == 1) {
                iList_CustoInicial_CodProduto.Add(20);
                iList_CustoInicial_CodProduto.Add(24);
                iList_CustoInicial_CodProduto.Add(25);
                iList_CustoInicial_CodProduto.Add(33);
                iList_CustoInicial_CodProduto.Add(65);
                iList_CustoInicial_CodProduto.Add(66);
                iList_CustoInicial_CodProduto.Add(75);
                iList_CustoInicial_CodProduto.Add(80);
                iList_CustoInicial_CodProduto.Add(85);
                iList_CustoInicial_CodProduto.Add(143);
                iList_CustoInicial_CodProduto.Add(158);
                iList_CustoInicial_CodProduto.Add(173);
                iList_CustoInicial_CodProduto.Add(177);
                iList_CustoInicial_CodProduto.Add(178);
                iList_CustoInicial_CodProduto.Add(186);
                iList_CustoInicial_CodProduto.Add(187);
                iList_CustoInicial_CodProduto.Add(190);
                iList_CustoInicial_CodProduto.Add(208);
                iList_CustoInicial_CodProduto.Add(215);
                iList_CustoInicial_CodProduto.Add(221);
                iList_CustoInicial_CodProduto.Add(226);
                iList_CustoInicial_CodProduto.Add(239);
                iList_CustoInicial_CodProduto.Add(240);
                iList_CustoInicial_CodProduto.Add(258);
                iList_CustoInicial_CodProduto.Add(264);
                iList_CustoInicial_CodProduto.Add(284);
                iList_CustoInicial_CodProduto.Add(285);
                iList_CustoInicial_CodProduto.Add(313);
                iList_CustoInicial_CodProduto.Add(316);
                iList_CustoInicial_CodProduto.Add(345);
                iList_CustoInicial_CodProduto.Add(350);
                iList_CustoInicial_CodProduto.Add(371);
                iList_CustoInicial_CodProduto.Add(372);
                iList_CustoInicial_CodProduto.Add(375);
                iList_CustoInicial_CodProduto.Add(386);
                iList_CustoInicial_CodProduto.Add(408);
                iList_CustoInicial_CodProduto.Add(444);
                iList_CustoInicial_CodProduto.Add(459);
                iList_CustoInicial_CodProduto.Add(471);
                iList_CustoInicial_CodProduto.Add(472);
                iList_CustoInicial_CodProduto.Add(476);
                iList_CustoInicial_CodProduto.Add(486);
                iList_CustoInicial_CodProduto.Add(491);
                iList_CustoInicial_CodProduto.Add(497);
                iList_CustoInicial_CodProduto.Add(508);
                iList_CustoInicial_CodProduto.Add(512);
                iList_CustoInicial_CodProduto.Add(513);
                iList_CustoInicial_CodProduto.Add(514);
                iList_CustoInicial_CodProduto.Add(516);
                iList_CustoInicial_CodProduto.Add(517);
                iList_CustoInicial_CodProduto.Add(539);
                iList_CustoInicial_CodProduto.Add(541);
                iList_CustoInicial_CodProduto.Add(543);
                iList_CustoInicial_CodProduto.Add(545);
                iList_CustoInicial_CodProduto.Add(565);
                iList_CustoInicial_CodProduto.Add(580);
                iList_CustoInicial_CodProduto.Add(633);
                iList_CustoInicial_CodProduto.Add(637);
                iList_CustoInicial_CodProduto.Add(640);
                iList_CustoInicial_CodProduto.Add(641);
                iList_CustoInicial_CodProduto.Add(659);
                iList_CustoInicial_CodProduto.Add(661);
                iList_CustoInicial_CodProduto.Add(673);
                iList_CustoInicial_CodProduto.Add(677);
                iList_CustoInicial_CodProduto.Add(692);
                iList_CustoInicial_CodProduto.Add(694);
                iList_CustoInicial_CodProduto.Add(696);
                iList_CustoInicial_CodProduto.Add(698);
                iList_CustoInicial_CodProduto.Add(710);
                iList_CustoInicial_CodProduto.Add(711);
                iList_CustoInicial_CodProduto.Add(712);
                iList_CustoInicial_CodProduto.Add(727);
                iList_CustoInicial_CodProduto.Add(728);
                iList_CustoInicial_CodProduto.Add(729);
                iList_CustoInicial_CodProduto.Add(747);
                iList_CustoInicial_CodProduto.Add(781);
                iList_CustoInicial_CodProduto.Add(785);
                iList_CustoInicial_CodProduto.Add(801);
                iList_CustoInicial_CodProduto.Add(804);
                iList_CustoInicial_CodProduto.Add(828);
                iList_CustoInicial_CodProduto.Add(834);
                iList_CustoInicial_CodProduto.Add(848);
                iList_CustoInicial_CodProduto.Add(850);
                iList_CustoInicial_CodProduto.Add(860);
                iList_CustoInicial_CodProduto.Add(863);
                iList_CustoInicial_CodProduto.Add(872);
                iList_CustoInicial_CodProduto.Add(873);
                iList_CustoInicial_CodProduto.Add(877);
                iList_CustoInicial_CodProduto.Add(884);
                iList_CustoInicial_CodProduto.Add(892);
                iList_CustoInicial_CodProduto.Add(893);
                iList_CustoInicial_CodProduto.Add(896);
                iList_CustoInicial_CodProduto.Add(901);
                iList_CustoInicial_CodProduto.Add(954);
                iList_CustoInicial_CodProduto.Add(969);
                iList_CustoInicial_CodProduto.Add(975);
                iList_CustoInicial_CodProduto.Add(988);
                iList_CustoInicial_CodProduto.Add(999);
                iList_CustoInicial_CodProduto.Add(1016);
                iList_CustoInicial_CodProduto.Add(1041);
                iList_CustoInicial_CodProduto.Add(1048);
                iList_CustoInicial_CodProduto.Add(1049);
                iList_CustoInicial_CodProduto.Add(1061);
                iList_CustoInicial_CodProduto.Add(1072);
                iList_CustoInicial_CodProduto.Add(1081);
                iList_CustoInicial_CodProduto.Add(1111);
                iList_CustoInicial_CodProduto.Add(1127);
                iList_CustoInicial_CodProduto.Add(1131);
                iList_CustoInicial_CodProduto.Add(1141);
                iList_CustoInicial_CodProduto.Add(1203);
                iList_CustoInicial_CodProduto.Add(1245);
                iList_CustoInicial_CodProduto.Add(1269);
                iList_CustoInicial_CodProduto.Add(1283);
                iList_CustoInicial_CodProduto.Add(1286);
                iList_CustoInicial_CodProduto.Add(1314);
                iList_CustoInicial_CodProduto.Add(1316);
                iList_CustoInicial_CodProduto.Add(1335);
                iList_CustoInicial_CodProduto.Add(1340);
                iList_CustoInicial_CodProduto.Add(1344);
                iList_CustoInicial_CodProduto.Add(1361);
                iList_CustoInicial_CodProduto.Add(1401);
                iList_CustoInicial_CodProduto.Add(1405);
                iList_CustoInicial_CodProduto.Add(1413);
                iList_CustoInicial_CodProduto.Add(1421);
                iList_CustoInicial_CodProduto.Add(1427);
                iList_CustoInicial_CodProduto.Add(1447);
                iList_CustoInicial_CodProduto.Add(1448);
                iList_CustoInicial_CodProduto.Add(1451);
                iList_CustoInicial_CodProduto.Add(1462);
                iList_CustoInicial_CodProduto.Add(1502);
                iList_CustoInicial_CodProduto.Add(1517);
                iList_CustoInicial_CodProduto.Add(1558);
                iList_CustoInicial_CodProduto.Add(1559);
                iList_CustoInicial_CodProduto.Add(1577);
                iList_CustoInicial_CodProduto.Add(1581);
                iList_CustoInicial_CodProduto.Add(1629);
                iList_CustoInicial_CodProduto.Add(1645);
                iList_CustoInicial_CodProduto.Add(1738);
                iList_CustoInicial_CodProduto.Add(1813);
                iList_CustoInicial_CodProduto.Add(1832);
                iList_CustoInicial_CodProduto.Add(1834);
                iList_CustoInicial_CodProduto.Add(1848);
                iList_CustoInicial_CodProduto.Add(1867);
                iList_CustoInicial_CodProduto.Add(1903);
                iList_CustoInicial_CodProduto.Add(1922);
                iList_CustoInicial_CodProduto.Add(1939);
                iList_CustoInicial_CodProduto.Add(1951);
                iList_CustoInicial_CodProduto.Add(1958);
                iList_CustoInicial_CodProduto.Add(1959);
                iList_CustoInicial_CodProduto.Add(1967);
                iList_CustoInicial_CodProduto.Add(1975);
                iList_CustoInicial_CodProduto.Add(1976);
                iList_CustoInicial_CodProduto.Add(1980);
                iList_CustoInicial_CodProduto.Add(1984);
                iList_CustoInicial_CodProduto.Add(1985);
                iList_CustoInicial_CodProduto.Add(1994);
                iList_CustoInicial_CodProduto.Add(2003);
                iList_CustoInicial_CodProduto.Add(2009);
                iList_CustoInicial_CodProduto.Add(2013);
                iList_CustoInicial_CodProduto.Add(2026);
                iList_CustoInicial_CodProduto.Add(2044);
                iList_CustoInicial_CodProduto.Add(2048);
                iList_CustoInicial_CodProduto.Add(2085);
                iList_CustoInicial_CodProduto.Add(2098);
                iList_CustoInicial_CodProduto.Add(2109);
                iList_CustoInicial_CodProduto.Add(2112);
                iList_CustoInicial_CodProduto.Add(2116);
                iList_CustoInicial_CodProduto.Add(2124);
                iList_CustoInicial_CodProduto.Add(2138);
                iList_CustoInicial_CodProduto.Add(2150);
                iList_CustoInicial_CodProduto.Add(2151);
                iList_CustoInicial_CodProduto.Add(2152);
                iList_CustoInicial_CodProduto.Add(2158);
                iList_CustoInicial_CodProduto.Add(2159);
                iList_CustoInicial_CodProduto.Add(2168);
                iList_CustoInicial_CodProduto.Add(2224);
                iList_CustoInicial_CodProduto.Add(2249);
                iList_CustoInicial_CodProduto.Add(2251);
                iList_CustoInicial_CodProduto.Add(2254);
                iList_CustoInicial_CodProduto.Add(2255);
                iList_CustoInicial_CodProduto.Add(2267);
                iList_CustoInicial_CodProduto.Add(2307);
                iList_CustoInicial_CodProduto.Add(2311);
                iList_CustoInicial_CodProduto.Add(2326);
                iList_CustoInicial_CodProduto.Add(2379);
                iList_CustoInicial_CodProduto.Add(2387);
                iList_CustoInicial_CodProduto.Add(2406);
                iList_CustoInicial_CodProduto.Add(2409);
                iList_CustoInicial_CodProduto.Add(2417);
                iList_CustoInicial_CodProduto.Add(2426);
                iList_CustoInicial_CodProduto.Add(2439);
                iList_CustoInicial_CodProduto.Add(2449);
                iList_CustoInicial_CodProduto.Add(2461);
                iList_CustoInicial_CodProduto.Add(2462);
                iList_CustoInicial_CodProduto.Add(2468);
                iList_CustoInicial_CodProduto.Add(2474);
                iList_CustoInicial_CodProduto.Add(2641);
                iList_CustoInicial_CodProduto.Add(2649);
                iList_CustoInicial_CodProduto.Add(2651);
                iList_CustoInicial_CodProduto.Add(2655);
                iList_CustoInicial_CodProduto.Add(2657);
                iList_CustoInicial_CodProduto.Add(2658);
                iList_CustoInicial_CodProduto.Add(2664);
                iList_CustoInicial_CodProduto.Add(2665);
                iList_CustoInicial_CodProduto.Add(2669);
                iList_CustoInicial_CodProduto.Add(2671);
                iList_CustoInicial_CodProduto.Add(2680);
                iList_CustoInicial_CodProduto.Add(2681);
                iList_CustoInicial_CodProduto.Add(2685);
                iList_CustoInicial_CodProduto.Add(10005);
                iList_CustoInicial_CodProduto.Add(10015);
                iList_CustoInicial_CodProduto.Add(10024);
                iList_CustoInicial_CodProduto.Add(10037);
                iList_CustoInicial_CodProduto.Add(10038);
                iList_CustoInicial_CodProduto.Add(10042);
                iList_CustoInicial_CodProduto.Add(10059);
                iList_CustoInicial_CodProduto.Add(10062);
                iList_CustoInicial_CodProduto.Add(10065);
                iList_CustoInicial_CodProduto.Add(10070);
                iList_CustoInicial_CodProduto.Add(10089);
                iList_CustoInicial_CodProduto.Add(10102);
                iList_CustoInicial_CodProduto.Add(10120);
                iList_CustoInicial_CodProduto.Add(10129);
                iList_CustoInicial_CodProduto.Add(10131);
                iList_CustoInicial_CodProduto.Add(10157);
                iList_CustoInicial_CodProduto.Add(10165);
                iList_CustoInicial_CodProduto.Add(10168);
                iList_CustoInicial_CodProduto.Add(10169);
                iList_CustoInicial_CodProduto.Add(10193);
                iList_CustoInicial_CodProduto.Add(10195);
                iList_CustoInicial_CodProduto.Add(10196);
                iList_CustoInicial_CodProduto.Add(10197);
                iList_CustoInicial_CodProduto.Add(10198);
                iList_CustoInicial_CodProduto.Add(10206);
                iList_CustoInicial_CodProduto.Add(10207);
                iList_CustoInicial_CodProduto.Add(10217);
                iList_CustoInicial_CodProduto.Add(10248);
                iList_CustoInicial_CodProduto.Add(10270);
                iList_CustoInicial_CodProduto.Add(10271);
                iList_CustoInicial_CodProduto.Add(10274);
                iList_CustoInicial_CodProduto.Add(10299);
                iList_CustoInicial_CodProduto.Add(10328);
                iList_CustoInicial_CodProduto.Add(10329);
                iList_CustoInicial_CodProduto.Add(10339);
                iList_CustoInicial_CodProduto.Add(10341);
                iList_CustoInicial_CodProduto.Add(10342);
                iList_CustoInicial_CodProduto.Add(10343);
                iList_CustoInicial_CodProduto.Add(10344);
                iList_CustoInicial_CodProduto.Add(10348);
                iList_CustoInicial_CodProduto.Add(10349);
                iList_CustoInicial_CodProduto.Add(10352);
                iList_CustoInicial_CodProduto.Add(10354);
                iList_CustoInicial_CodProduto.Add(10357);
                iList_CustoInicial_CodProduto.Add(10358);
                iList_CustoInicial_CodProduto.Add(10361);
                iList_CustoInicial_CodProduto.Add(10362);
                iList_CustoInicial_CodProduto.Add(10363);
                iList_CustoInicial_CodProduto.Add(10364);
                iList_CustoInicial_CodProduto.Add(10366);
                iList_CustoInicial_CodProduto.Add(10367);
                iList_CustoInicial_CodProduto.Add(10368);
                iList_CustoInicial_CodProduto.Add(10369);
                iList_CustoInicial_CodProduto.Add(10372);
                iList_CustoInicial_CodProduto.Add(10374);
                iList_CustoInicial_CodProduto.Add(10376);
                iList_CustoInicial_CodProduto.Add(10377);
                iList_CustoInicial_CodProduto.Add(10378);
                iList_CustoInicial_CodProduto.Add(10379);
                iList_CustoInicial_CodProduto.Add(10380);
                iList_CustoInicial_CodProduto.Add(10382);
                iList_CustoInicial_CodProduto.Add(10384);
                iList_CustoInicial_CodProduto.Add(10385);
                iList_CustoInicial_CodProduto.Add(10389);
                iList_CustoInicial_CodProduto.Add(10390);
                iList_CustoInicial_CodProduto.Add(10391);
                iList_CustoInicial_CodProduto.Add(10392);
                iList_CustoInicial_CodProduto.Add(10393);
                iList_CustoInicial_CodProduto.Add(10394);
                iList_CustoInicial_CodProduto.Add(10395);
                iList_CustoInicial_CodProduto.Add(10398);
                iList_CustoInicial_CodProduto.Add(10399);
                iList_CustoInicial_CodProduto.Add(10400);
                iList_CustoInicial_CodProduto.Add(10401);
                iList_CustoInicial_CodProduto.Add(10402);
                iList_CustoInicial_CodProduto.Add(10405);
                iList_CustoInicial_CodProduto.Add(10406);
                iList_CustoInicial_CodProduto.Add(10408);
                iList_CustoInicial_CodProduto.Add(10409);
                iList_CustoInicial_CodProduto.Add(10410);
                iList_CustoInicial_CodProduto.Add(10418);
                iList_CustoInicial_CodProduto.Add(10423);
                iList_CustoInicial_CodProduto.Add(10428);
                iList_CustoInicial_CodProduto.Add(10429);
                iList_CustoInicial_CodProduto.Add(10433);
                iList_CustoInicial_CodProduto.Add(10436);
                iList_CustoInicial_CodProduto.Add(10437);
                iList_CustoInicial_CodProduto.Add(10439);
                iList_CustoInicial_CodProduto.Add(10440);
                iList_CustoInicial_CodProduto.Add(10442);
                iList_CustoInicial_CodProduto.Add(10444);
                iList_CustoInicial_CodProduto.Add(10445);
                iList_CustoInicial_CodProduto.Add(10447);
                iList_CustoInicial_CodProduto.Add(10450);
                iList_CustoInicial_CodProduto.Add(10451);
                iList_CustoInicial_CodProduto.Add(10452);
                iList_CustoInicial_CodProduto.Add(10455);
                iList_CustoInicial_CodProduto.Add(10458);
                iList_CustoInicial_CodProduto.Add(10460);
                iList_CustoInicial_CodProduto.Add(10461);
                iList_CustoInicial_CodProduto.Add(10462);
                iList_CustoInicial_CodProduto.Add(10463);
                iList_CustoInicial_CodProduto.Add(10469);
                iList_CustoInicial_CodProduto.Add(10485);
                iList_CustoInicial_CodProduto.Add(10489);
                iList_CustoInicial_CodProduto.Add(10490);
                iList_CustoInicial_CodProduto.Add(10505);
                iList_CustoInicial_CodProduto.Add(10506);
                iList_CustoInicial_CodProduto.Add(10526);
                iList_CustoInicial_CodProduto.Add(10539);
                iList_CustoInicial_CodProduto.Add(10556);
                iList_CustoInicial_CodProduto.Add(10557);
                iList_CustoInicial_CodProduto.Add(10559);
                iList_CustoInicial_CodProduto.Add(10560);
                iList_CustoInicial_CodProduto.Add(10562);
                iList_CustoInicial_CodProduto.Add(10563);
                iList_CustoInicial_CodProduto.Add(10564);
                iList_CustoInicial_CodProduto.Add(10567);
                iList_CustoInicial_CodProduto.Add(10568);
                iList_CustoInicial_CodProduto.Add(10569);
                iList_CustoInicial_CodProduto.Add(10573);
                iList_CustoInicial_CodProduto.Add(10579);
                iList_CustoInicial_CodProduto.Add(10580);
                iList_CustoInicial_CodProduto.Add(10596);
                iList_CustoInicial_CodProduto.Add(10607);
                iList_CustoInicial_CodProduto.Add(10608);
                iList_CustoInicial_CodProduto.Add(10614);
                iList_CustoInicial_CodProduto.Add(10656);
                iList_CustoInicial_CodProduto.Add(10657);
                iList_CustoInicial_CodProduto.Add(10662);
                iList_CustoInicial_CodProduto.Add(10664);
                iList_CustoInicial_CodProduto.Add(10665);
                iList_CustoInicial_CodProduto.Add(10667);
                iList_CustoInicial_CodProduto.Add(10668);
                iList_CustoInicial_CodProduto.Add(10671);
                iList_CustoInicial_CodProduto.Add(10675);
                iList_CustoInicial_CodProduto.Add(10682);
                iList_CustoInicial_CodProduto.Add(10699);
                iList_CustoInicial_CodProduto.Add(10716);
                iList_CustoInicial_CodProduto.Add(10729);
                iList_CustoInicial_CodProduto.Add(10741);
                iList_CustoInicial_CodProduto.Add(10746);
                iList_CustoInicial_CodProduto.Add(10753);
                iList_CustoInicial_CodProduto.Add(10780);
                iList_CustoInicial_CodProduto.Add(10785);
                iList_CustoInicial_CodProduto.Add(10786);
                iList_CustoInicial_CodProduto.Add(10789);
                iList_CustoInicial_CodProduto.Add(10790);
                iList_CustoInicial_CodProduto.Add(10796);
                iList_CustoInicial_CodProduto.Add(10830);
                iList_CustoInicial_CodProduto.Add(10835);
                iList_CustoInicial_CodProduto.Add(10856);
                iList_CustoInicial_CodProduto.Add(10857);
                iList_CustoInicial_CodProduto.Add(10863);
                iList_CustoInicial_CodProduto.Add(10876);
                iList_CustoInicial_CodProduto.Add(10892);
                iList_CustoInicial_CodProduto.Add(10895);
                iList_CustoInicial_CodProduto.Add(10918);
                iList_CustoInicial_CodProduto.Add(10923);
                iList_CustoInicial_CodProduto.Add(10926);
                iList_CustoInicial_CodProduto.Add(10928);
                iList_CustoInicial_CodProduto.Add(10933);
                iList_CustoInicial_CodProduto.Add(10937);
                iList_CustoInicial_CodProduto.Add(10945);
                iList_CustoInicial_CodProduto.Add(10947);
                iList_CustoInicial_CodProduto.Add(10948);
                iList_CustoInicial_CodProduto.Add(10949);
                iList_CustoInicial_CodProduto.Add(11042);
                iList_CustoInicial_CodProduto.Add(11062);
                iList_CustoInicial_CodProduto.Add(11063);
                iList_CustoInicial_CodProduto.Add(11070);
                iList_CustoInicial_CodProduto.Add(11112);
                iList_CustoInicial_CodProduto.Add(11114);
                iList_CustoInicial_CodProduto.Add(11115);
                iList_CustoInicial_CodProduto.Add(11116);
                iList_CustoInicial_CodProduto.Add(11117);
                iList_CustoInicial_CodProduto.Add(11118);
                iList_CustoInicial_CodProduto.Add(11135);
                iList_CustoInicial_CodProduto.Add(11141);
                iList_CustoInicial_CodProduto.Add(11147);
                iList_CustoInicial_CodProduto.Add(11148);
                iList_CustoInicial_CodProduto.Add(11150);
                iList_CustoInicial_CodProduto.Add(11151);
                iList_CustoInicial_CodProduto.Add(11152);
                iList_CustoInicial_CodProduto.Add(11154);
                iList_CustoInicial_CodProduto.Add(11157);
                iList_CustoInicial_CodProduto.Add(11158);
                iList_CustoInicial_CodProduto.Add(11161);
                iList_CustoInicial_CodProduto.Add(11164);
                iList_CustoInicial_CodProduto.Add(11165);
                iList_CustoInicial_CodProduto.Add(11167);
                iList_CustoInicial_CodProduto.Add(11168);
                iList_CustoInicial_CodProduto.Add(11178);
                iList_CustoInicial_CodProduto.Add(11180);
                iList_CustoInicial_CodProduto.Add(11197);
                iList_CustoInicial_CodProduto.Add(11198);
                iList_CustoInicial_CodProduto.Add(11199);
                iList_CustoInicial_CodProduto.Add(11207);
                iList_CustoInicial_CodProduto.Add(11209);
                iList_CustoInicial_CodProduto.Add(11211);
                iList_CustoInicial_CodProduto.Add(11212);
                iList_CustoInicial_CodProduto.Add(11221);
                iList_CustoInicial_CodProduto.Add(11224);
                iList_CustoInicial_CodProduto.Add(11229);
                iList_CustoInicial_CodProduto.Add(11233);
                iList_CustoInicial_CodProduto.Add(11235);
                iList_CustoInicial_CodProduto.Add(11245);
                iList_CustoInicial_CodProduto.Add(11248);
                iList_CustoInicial_CodProduto.Add(11251);
                iList_CustoInicial_CodProduto.Add(11254);
                iList_CustoInicial_CodProduto.Add(11257);
                iList_CustoInicial_CodProduto.Add(11258);
                iList_CustoInicial_CodProduto.Add(11262);
                iList_CustoInicial_CodProduto.Add(11268);
                iList_CustoInicial_CodProduto.Add(11278);
                iList_CustoInicial_CodProduto.Add(11283);
                iList_CustoInicial_CodProduto.Add(11287);
                iList_CustoInicial_CodProduto.Add(11293);
                iList_CustoInicial_CodProduto.Add(11299);
                iList_CustoInicial_CodProduto.Add(11301);
                iList_CustoInicial_CodProduto.Add(11302);
                iList_CustoInicial_CodProduto.Add(11305);
                iList_CustoInicial_CodProduto.Add(11309);
                iList_CustoInicial_CodProduto.Add(11311);
                iList_CustoInicial_CodProduto.Add(11312);
                iList_CustoInicial_CodProduto.Add(11327);
                iList_CustoInicial_CodProduto.Add(11329);
                iList_CustoInicial_CodProduto.Add(11330);
                iList_CustoInicial_CodProduto.Add(11351);
                iList_CustoInicial_CodProduto.Add(11353);
                iList_CustoInicial_CodProduto.Add(11358);
                iList_CustoInicial_CodProduto.Add(11364);
                iList_CustoInicial_CodProduto.Add(11366);
                iList_CustoInicial_CodProduto.Add(11368);
                iList_CustoInicial_CodProduto.Add(11370);
                iList_CustoInicial_CodProduto.Add(11372);
                iList_CustoInicial_CodProduto.Add(11379);
                iList_CustoInicial_CodProduto.Add(11387);
                iList_CustoInicial_CodProduto.Add(11389);
                iList_CustoInicial_CodProduto.Add(11392);
                iList_CustoInicial_CodProduto.Add(11393);
                iList_CustoInicial_CodProduto.Add(11402);
                iList_CustoInicial_CodProduto.Add(11417);
                iList_CustoInicial_CodProduto.Add(11423);
                iList_CustoInicial_CodProduto.Add(11431);
                iList_CustoInicial_CodProduto.Add(11435);
                iList_CustoInicial_CodProduto.Add(11439);
                iList_CustoInicial_CodProduto.Add(11440);
                iList_CustoInicial_CodProduto.Add(11461);
                iList_CustoInicial_CodProduto.Add(11462);
                iList_CustoInicial_CodProduto.Add(11468);
                iList_CustoInicial_CodProduto.Add(11470);
                iList_CustoInicial_CodProduto.Add(11474);
                iList_CustoInicial_CodProduto.Add(11480);
                iList_CustoInicial_CodProduto.Add(11483);
                iList_CustoInicial_CodProduto.Add(11484);
                iList_CustoInicial_CodProduto.Add(11494);
                iList_CustoInicial_CodProduto.Add(11503);
                iList_CustoInicial_CodProduto.Add(11504);
                iList_CustoInicial_CodProduto.Add(11505);
                iList_CustoInicial_CodProduto.Add(11506);
                iList_CustoInicial_CodProduto.Add(11509);
                iList_CustoInicial_CodProduto.Add(11510);
                iList_CustoInicial_CodProduto.Add(11511);
                iList_CustoInicial_CodProduto.Add(11527);
                iList_CustoInicial_CodProduto.Add(11529);
                iList_CustoInicial_CodProduto.Add(11534);
                iList_CustoInicial_CodProduto.Add(11539);
                iList_CustoInicial_CodProduto.Add(11540);
                iList_CustoInicial_CodProduto.Add(11541);
                iList_CustoInicial_CodProduto.Add(11543);
                iList_CustoInicial_CodProduto.Add(11545);
                iList_CustoInicial_CodProduto.Add(11546);
                iList_CustoInicial_CodProduto.Add(11548);
                iList_CustoInicial_CodProduto.Add(11549);
                iList_CustoInicial_CodProduto.Add(11551);
                iList_CustoInicial_CodProduto.Add(11552);
                iList_CustoInicial_CodProduto.Add(11554);
                iList_CustoInicial_CodProduto.Add(11555);
                iList_CustoInicial_CodProduto.Add(11558);
                iList_CustoInicial_CodProduto.Add(11559);
                iList_CustoInicial_CodProduto.Add(11561);
                iList_CustoInicial_CodProduto.Add(11562);
                iList_CustoInicial_CodProduto.Add(11563);
                iList_CustoInicial_CodProduto.Add(11564);
                iList_CustoInicial_CodProduto.Add(11566);
                iList_CustoInicial_CodProduto.Add(11569);
                iList_CustoInicial_CodProduto.Add(11570);
                iList_CustoInicial_CodProduto.Add(11571);
                iList_CustoInicial_CodProduto.Add(11572);
                iList_CustoInicial_CodProduto.Add(11576);
                iList_CustoInicial_CodProduto.Add(11578);
                iList_CustoInicial_CodProduto.Add(11580);
                iList_CustoInicial_CodProduto.Add(11582);
                iList_CustoInicial_CodProduto.Add(11585);
                iList_CustoInicial_CodProduto.Add(11586);
                iList_CustoInicial_CodProduto.Add(11589);
                iList_CustoInicial_CodProduto.Add(11590);
                iList_CustoInicial_CodProduto.Add(11591);
                iList_CustoInicial_CodProduto.Add(11592);
                iList_CustoInicial_CodProduto.Add(11593);
                iList_CustoInicial_CodProduto.Add(11599);
                iList_CustoInicial_CodProduto.Add(11601);
                iList_CustoInicial_CodProduto.Add(11603);
                iList_CustoInicial_CodProduto.Add(11604);
                iList_CustoInicial_CodProduto.Add(11608);
                iList_CustoInicial_CodProduto.Add(11618);
                iList_CustoInicial_CodProduto.Add(11631);
                iList_CustoInicial_CodProduto.Add(11634);
                iList_CustoInicial_CodProduto.Add(11635);
                iList_CustoInicial_CodProduto.Add(11636);
                iList_CustoInicial_CodProduto.Add(11639);
                iList_CustoInicial_CodProduto.Add(11640);
                iList_CustoInicial_CodProduto.Add(11643);
                iList_CustoInicial_CodProduto.Add(11644);
                iList_CustoInicial_CodProduto.Add(11649);
                iList_CustoInicial_CodProduto.Add(11655);
                iList_CustoInicial_CodProduto.Add(11663);
                iList_CustoInicial_CodProduto.Add(11667);
                iList_CustoInicial_CodProduto.Add(11670);
                iList_CustoInicial_CodProduto.Add(11674);
                iList_CustoInicial_CodProduto.Add(11676);
                iList_CustoInicial_CodProduto.Add(11677);
                iList_CustoInicial_CodProduto.Add(11682);
                iList_CustoInicial_CodProduto.Add(11688);
                iList_CustoInicial_CodProduto.Add(11690);
                iList_CustoInicial_CodProduto.Add(11697);
                iList_CustoInicial_CodProduto.Add(11699);
                iList_CustoInicial_CodProduto.Add(11700);
                iList_CustoInicial_CodProduto.Add(11703);
                iList_CustoInicial_CodProduto.Add(11706);
                iList_CustoInicial_CodProduto.Add(11720);
                iList_CustoInicial_CodProduto.Add(11729);
                iList_CustoInicial_CodProduto.Add(11735);
                iList_CustoInicial_CodProduto.Add(11736);
                iList_CustoInicial_CodProduto.Add(11738);
                iList_CustoInicial_CodProduto.Add(11742);
                iList_CustoInicial_CodProduto.Add(11743);
                iList_CustoInicial_CodProduto.Add(11744);
                iList_CustoInicial_CodProduto.Add(11745);
                iList_CustoInicial_CodProduto.Add(11750);
                iList_CustoInicial_CodProduto.Add(11754);
                iList_CustoInicial_CodProduto.Add(11762);
                iList_CustoInicial_CodProduto.Add(11772);
                iList_CustoInicial_CodProduto.Add(11776);
                iList_CustoInicial_CodProduto.Add(11778);
                iList_CustoInicial_CodProduto.Add(11786);
                iList_CustoInicial_CodProduto.Add(11788);
                iList_CustoInicial_CodProduto.Add(11789);
                iList_CustoInicial_CodProduto.Add(11793);
                iList_CustoInicial_CodProduto.Add(11794);
                iList_CustoInicial_CodProduto.Add(11795);
                iList_CustoInicial_CodProduto.Add(11801);
                iList_CustoInicial_CodProduto.Add(11802);
                iList_CustoInicial_CodProduto.Add(11803);
                iList_CustoInicial_CodProduto.Add(11804);
                iList_CustoInicial_CodProduto.Add(11805);
                iList_CustoInicial_CodProduto.Add(11806);
                iList_CustoInicial_CodProduto.Add(11807);
                iList_CustoInicial_CodProduto.Add(11808);
                iList_CustoInicial_CodProduto.Add(11810);
                iList_CustoInicial_CodProduto.Add(11811);
                iList_CustoInicial_CodProduto.Add(11812);
                iList_CustoInicial_CodProduto.Add(11813);
                iList_CustoInicial_CodProduto.Add(11814);
                iList_CustoInicial_CodProduto.Add(11815);
                iList_CustoInicial_CodProduto.Add(11816);
                iList_CustoInicial_CodProduto.Add(11819);
                iList_CustoInicial_CodProduto.Add(11820);
                iList_CustoInicial_CodProduto.Add(11821);
                iList_CustoInicial_CodProduto.Add(11827);
                iList_CustoInicial_CodProduto.Add(11829);
                iList_CustoInicial_CodProduto.Add(11831);
                iList_CustoInicial_CodProduto.Add(11832);
                iList_CustoInicial_CodProduto.Add(11834);
                iList_CustoInicial_CodProduto.Add(11838);
                iList_CustoInicial_CodProduto.Add(11840);
                iList_CustoInicial_CodProduto.Add(11844);
                iList_CustoInicial_CodProduto.Add(11846);
                iList_CustoInicial_CodProduto.Add(11848);
                iList_CustoInicial_CodProduto.Add(11849);
                iList_CustoInicial_CodProduto.Add(11850);
                iList_CustoInicial_CodProduto.Add(11851);
                iList_CustoInicial_CodProduto.Add(11852);
                iList_CustoInicial_CodProduto.Add(11854);
                iList_CustoInicial_CodProduto.Add(11861);
                iList_CustoInicial_CodProduto.Add(11863);
                iList_CustoInicial_CodProduto.Add(11875);
                iList_CustoInicial_CodProduto.Add(11876);
                iList_CustoInicial_CodProduto.Add(11878);
                iList_CustoInicial_CodProduto.Add(11880);
                iList_CustoInicial_CodProduto.Add(11882);
                iList_CustoInicial_CodProduto.Add(11887);
                iList_CustoInicial_CodProduto.Add(11892);
                iList_CustoInicial_CodProduto.Add(11894);
                iList_CustoInicial_CodProduto.Add(11895);
                iList_CustoInicial_CodProduto.Add(11900);
                iList_CustoInicial_CodProduto.Add(11901);
                iList_CustoInicial_CodProduto.Add(11903);
                iList_CustoInicial_CodProduto.Add(11906);
                iList_CustoInicial_CodProduto.Add(11908);
                iList_CustoInicial_CodProduto.Add(11913);
                iList_CustoInicial_CodProduto.Add(11914);
                iList_CustoInicial_CodProduto.Add(11915);
                iList_CustoInicial_CodProduto.Add(11916);
                iList_CustoInicial_CodProduto.Add(11917);
                iList_CustoInicial_CodProduto.Add(11919);
                iList_CustoInicial_CodProduto.Add(11924);
                iList_CustoInicial_CodProduto.Add(11925);
                iList_CustoInicial_CodProduto.Add(11928);
                iList_CustoInicial_CodProduto.Add(11930);
                iList_CustoInicial_CodProduto.Add(11931);
                iList_CustoInicial_CodProduto.Add(11932);
                iList_CustoInicial_CodProduto.Add(11935);
                iList_CustoInicial_CodProduto.Add(11936);
                iList_CustoInicial_CodProduto.Add(11939);
                iList_CustoInicial_CodProduto.Add(11941);
                iList_CustoInicial_CodProduto.Add(11942);
                iList_CustoInicial_CodProduto.Add(11947);
                iList_CustoInicial_CodProduto.Add(11948);
                iList_CustoInicial_CodProduto.Add(11949);
                iList_CustoInicial_CodProduto.Add(11950);
                iList_CustoInicial_CodProduto.Add(11951);
                iList_CustoInicial_CodProduto.Add(11952);
                iList_CustoInicial_CodProduto.Add(11955);
                iList_CustoInicial_CodProduto.Add(11957);
                iList_CustoInicial_CodProduto.Add(11962);
                iList_CustoInicial_CodProduto.Add(11963);
                iList_CustoInicial_CodProduto.Add(11965);
                iList_CustoInicial_CodProduto.Add(11966);
                iList_CustoInicial_CodProduto.Add(11967);
                iList_CustoInicial_CodProduto.Add(11968);
                iList_CustoInicial_CodProduto.Add(11969);
                iList_CustoInicial_CodProduto.Add(11970);
                iList_CustoInicial_CodProduto.Add(11971);
                iList_CustoInicial_CodProduto.Add(11972);
                iList_CustoInicial_CodProduto.Add(11973);
                iList_CustoInicial_CodProduto.Add(11974);
                iList_CustoInicial_CodProduto.Add(11981);
                iList_CustoInicial_CodProduto.Add(11984);
                iList_CustoInicial_CodProduto.Add(11985);
                iList_CustoInicial_CodProduto.Add(11986);
                iList_CustoInicial_CodProduto.Add(11990);
                iList_CustoInicial_CodProduto.Add(11991);
                iList_CustoInicial_CodProduto.Add(11992);
                iList_CustoInicial_CodProduto.Add(11993);
                iList_CustoInicial_CodProduto.Add(11998);
                iList_CustoInicial_CodProduto.Add(12000);
                iList_CustoInicial_CodProduto.Add(12002);
                iList_CustoInicial_CodProduto.Add(12003);
                iList_CustoInicial_CodProduto.Add(12005);
                iList_CustoInicial_CodProduto.Add(12007);
                iList_CustoInicial_CodProduto.Add(12008);
                iList_CustoInicial_CodProduto.Add(12009);
                iList_CustoInicial_CodProduto.Add(12010);
                iList_CustoInicial_CodProduto.Add(12013);
                iList_CustoInicial_CodProduto.Add(12014);
                iList_CustoInicial_CodProduto.Add(12015);
                iList_CustoInicial_CodProduto.Add(12016);
                iList_CustoInicial_CodProduto.Add(12018);
                iList_CustoInicial_CodProduto.Add(12019);
                iList_CustoInicial_CodProduto.Add(12022);
                iList_CustoInicial_CodProduto.Add(12023);
                iList_CustoInicial_CodProduto.Add(12032);
                iList_CustoInicial_CodProduto.Add(12034);
                iList_CustoInicial_CodProduto.Add(12037);
                iList_CustoInicial_CodProduto.Add(12038);
                iList_CustoInicial_CodProduto.Add(12040);
                iList_CustoInicial_CodProduto.Add(12041);
                iList_CustoInicial_CodProduto.Add(12043);
                iList_CustoInicial_CodProduto.Add(12045);
                iList_CustoInicial_CodProduto.Add(12047);
                iList_CustoInicial_CodProduto.Add(12048);
                iList_CustoInicial_CodProduto.Add(12049);
                iList_CustoInicial_CodProduto.Add(12050);
                iList_CustoInicial_CodProduto.Add(12053);
                iList_CustoInicial_CodProduto.Add(12055);
                iList_CustoInicial_CodProduto.Add(12056);
                iList_CustoInicial_CodProduto.Add(12057);
                iList_CustoInicial_CodProduto.Add(12058);
                iList_CustoInicial_CodProduto.Add(12061);
                iList_CustoInicial_CodProduto.Add(12062);
                iList_CustoInicial_CodProduto.Add(12063);
                iList_CustoInicial_CodProduto.Add(12064);
                iList_CustoInicial_CodProduto.Add(12065);
                iList_CustoInicial_CodProduto.Add(12066);
                iList_CustoInicial_CodProduto.Add(12067);
                iList_CustoInicial_CodProduto.Add(12068);
                iList_CustoInicial_CodProduto.Add(12069);
                iList_CustoInicial_CodProduto.Add(12071);
                iList_CustoInicial_CodProduto.Add(12072);
                iList_CustoInicial_CodProduto.Add(12073);
                iList_CustoInicial_CodProduto.Add(12075);
                iList_CustoInicial_CodProduto.Add(12077);
                iList_CustoInicial_CodProduto.Add(12078);
                iList_CustoInicial_CodProduto.Add(12080);
                iList_CustoInicial_CodProduto.Add(12081);
                iList_CustoInicial_CodProduto.Add(12082);
                iList_CustoInicial_CodProduto.Add(12083);
                iList_CustoInicial_CodProduto.Add(12084);
                iList_CustoInicial_CodProduto.Add(12085);
                iList_CustoInicial_CodProduto.Add(12086);
                iList_CustoInicial_CodProduto.Add(12087);
                iList_CustoInicial_CodProduto.Add(12088);
                iList_CustoInicial_CodProduto.Add(12089);
                iList_CustoInicial_CodProduto.Add(12090);
                iList_CustoInicial_CodProduto.Add(12091);
                iList_CustoInicial_CodProduto.Add(12093);
                iList_CustoInicial_CodProduto.Add(12094);
                iList_CustoInicial_CodProduto.Add(12097);
                iList_CustoInicial_CodProduto.Add(12098);
                iList_CustoInicial_CodProduto.Add(12099);
                iList_CustoInicial_CodProduto.Add(12100);
                iList_CustoInicial_CodProduto.Add(12101);
                iList_CustoInicial_CodProduto.Add(12103);
                iList_CustoInicial_CodProduto.Add(12104);
                iList_CustoInicial_CodProduto.Add(12105);
                iList_CustoInicial_CodProduto.Add(12106);
                iList_CustoInicial_CodProduto.Add(12107);
                iList_CustoInicial_CodProduto.Add(12108);
                iList_CustoInicial_CodProduto.Add(12109);
                iList_CustoInicial_CodProduto.Add(12110);
                iList_CustoInicial_CodProduto.Add(12111);
                iList_CustoInicial_CodProduto.Add(12112);
                iList_CustoInicial_CodProduto.Add(12113);
                iList_CustoInicial_CodProduto.Add(12114);
                iList_CustoInicial_CodProduto.Add(12115);
                iList_CustoInicial_CodProduto.Add(12117);
                iList_CustoInicial_CodProduto.Add(12118);
                iList_CustoInicial_CodProduto.Add(12119);
                iList_CustoInicial_CodProduto.Add(12120);
                iList_CustoInicial_CodProduto.Add(12121);
                iList_CustoInicial_CodProduto.Add(12122);
                iList_CustoInicial_CodProduto.Add(12123);
                iList_CustoInicial_CodProduto.Add(12124);
                iList_CustoInicial_CodProduto.Add(12127);
                iList_CustoInicial_CodProduto.Add(12128);
                iList_CustoInicial_CodProduto.Add(12129);
                iList_CustoInicial_CodProduto.Add(12130);
                dList_CustoInicial_VlrProduto.Add(110);
                dList_CustoInicial_VlrProduto.Add(38);
                dList_CustoInicial_VlrProduto.Add(100);
                dList_CustoInicial_VlrProduto.Add(65);
                dList_CustoInicial_VlrProduto.Add(872);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(91);
                dList_CustoInicial_VlrProduto.Add(23);
                dList_CustoInicial_VlrProduto.Add(9);
                dList_CustoInicial_VlrProduto.Add(7);
                dList_CustoInicial_VlrProduto.Add(55);
                dList_CustoInicial_VlrProduto.Add(13);
                dList_CustoInicial_VlrProduto.Add(21);
                dList_CustoInicial_VlrProduto.Add(24);
                dList_CustoInicial_VlrProduto.Add(23);
                dList_CustoInicial_VlrProduto.Add(63);
                dList_CustoInicial_VlrProduto.Add(208);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(164);
                dList_CustoInicial_VlrProduto.Add(335);
                dList_CustoInicial_VlrProduto.Add(220);
                dList_CustoInicial_VlrProduto.Add(51);
                dList_CustoInicial_VlrProduto.Add(15);
                dList_CustoInicial_VlrProduto.Add(447);
                dList_CustoInicial_VlrProduto.Add(185);
                dList_CustoInicial_VlrProduto.Add(9);
                dList_CustoInicial_VlrProduto.Add(973);
                dList_CustoInicial_VlrProduto.Add(37);
                dList_CustoInicial_VlrProduto.Add(63);
                dList_CustoInicial_VlrProduto.Add(55);
                dList_CustoInicial_VlrProduto.Add(53);
                dList_CustoInicial_VlrProduto.Add(12);
                dList_CustoInicial_VlrProduto.Add(14);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(80);
                dList_CustoInicial_VlrProduto.Add(39);
                dList_CustoInicial_VlrProduto.Add(17);
                dList_CustoInicial_VlrProduto.Add(60);
                dList_CustoInicial_VlrProduto.Add(270);
                dList_CustoInicial_VlrProduto.Add(290);
                dList_CustoInicial_VlrProduto.Add(185);
                dList_CustoInicial_VlrProduto.Add(9);
                dList_CustoInicial_VlrProduto.Add(175);
                dList_CustoInicial_VlrProduto.Add(220);
                dList_CustoInicial_VlrProduto.Add(435);
                dList_CustoInicial_VlrProduto.Add(41);
                dList_CustoInicial_VlrProduto.Add(23);
                dList_CustoInicial_VlrProduto.Add(90);
                dList_CustoInicial_VlrProduto.Add(245);
                dList_CustoInicial_VlrProduto.Add(10);
                dList_CustoInicial_VlrProduto.Add(528);
                dList_CustoInicial_VlrProduto.Add(566);
                dList_CustoInicial_VlrProduto.Add(54);
                dList_CustoInicial_VlrProduto.Add(22);
                dList_CustoInicial_VlrProduto.Add(51);
                dList_CustoInicial_VlrProduto.Add(360);
                dList_CustoInicial_VlrProduto.Add(7);
                dList_CustoInicial_VlrProduto.Add(160);
                dList_CustoInicial_VlrProduto.Add(188);
                dList_CustoInicial_VlrProduto.Add(109);
                dList_CustoInicial_VlrProduto.Add(200);
                dList_CustoInicial_VlrProduto.Add(155);
                dList_CustoInicial_VlrProduto.Add(175);
                dList_CustoInicial_VlrProduto.Add(10);
                dList_CustoInicial_VlrProduto.Add(200);
                dList_CustoInicial_VlrProduto.Add(30);
                dList_CustoInicial_VlrProduto.Add(35);
                dList_CustoInicial_VlrProduto.Add(18);
                dList_CustoInicial_VlrProduto.Add(82);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(16);
                dList_CustoInicial_VlrProduto.Add(48);
                dList_CustoInicial_VlrProduto.Add(122);
                dList_CustoInicial_VlrProduto.Add(36);
                dList_CustoInicial_VlrProduto.Add(37);
                dList_CustoInicial_VlrProduto.Add(176);
                dList_CustoInicial_VlrProduto.Add(1246);
                dList_CustoInicial_VlrProduto.Add(71);
                dList_CustoInicial_VlrProduto.Add(57);
                dList_CustoInicial_VlrProduto.Add(8);
                dList_CustoInicial_VlrProduto.Add(175);
                dList_CustoInicial_VlrProduto.Add(50);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(158);
                dList_CustoInicial_VlrProduto.Add(113);
                dList_CustoInicial_VlrProduto.Add(61);
                dList_CustoInicial_VlrProduto.Add(174);
                dList_CustoInicial_VlrProduto.Add(99);
                dList_CustoInicial_VlrProduto.Add(65);
                dList_CustoInicial_VlrProduto.Add(123);
                dList_CustoInicial_VlrProduto.Add(105);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(97);
                dList_CustoInicial_VlrProduto.Add(92);
                dList_CustoInicial_VlrProduto.Add(16);
                dList_CustoInicial_VlrProduto.Add(32);
                dList_CustoInicial_VlrProduto.Add(266);
                dList_CustoInicial_VlrProduto.Add(300);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(205);
                dList_CustoInicial_VlrProduto.Add(28);
                dList_CustoInicial_VlrProduto.Add(148);
                dList_CustoInicial_VlrProduto.Add(141);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(41);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(310);
                dList_CustoInicial_VlrProduto.Add(7);
                dList_CustoInicial_VlrProduto.Add(100);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(22);
                dList_CustoInicial_VlrProduto.Add(90);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(12);
                dList_CustoInicial_VlrProduto.Add(10);
                dList_CustoInicial_VlrProduto.Add(105);
                dList_CustoInicial_VlrProduto.Add(26);
                dList_CustoInicial_VlrProduto.Add(299);
                dList_CustoInicial_VlrProduto.Add(20);
                dList_CustoInicial_VlrProduto.Add(818);
                dList_CustoInicial_VlrProduto.Add(51);
                dList_CustoInicial_VlrProduto.Add(106);
                dList_CustoInicial_VlrProduto.Add(15);
                dList_CustoInicial_VlrProduto.Add(141);
                dList_CustoInicial_VlrProduto.Add(12);
                dList_CustoInicial_VlrProduto.Add(66);
                dList_CustoInicial_VlrProduto.Add(177);
                dList_CustoInicial_VlrProduto.Add(32);
                dList_CustoInicial_VlrProduto.Add(52);
                dList_CustoInicial_VlrProduto.Add(194);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(315);
                dList_CustoInicial_VlrProduto.Add(86);
                dList_CustoInicial_VlrProduto.Add(110);
                dList_CustoInicial_VlrProduto.Add(507);
                dList_CustoInicial_VlrProduto.Add(98);
                dList_CustoInicial_VlrProduto.Add(42);
                dList_CustoInicial_VlrProduto.Add(24);
                dList_CustoInicial_VlrProduto.Add(92);
                dList_CustoInicial_VlrProduto.Add(36);
                dList_CustoInicial_VlrProduto.Add(91);
                dList_CustoInicial_VlrProduto.Add(195);
                dList_CustoInicial_VlrProduto.Add(90);
                dList_CustoInicial_VlrProduto.Add(400);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(140);
                dList_CustoInicial_VlrProduto.Add(180);
                dList_CustoInicial_VlrProduto.Add(239);
                dList_CustoInicial_VlrProduto.Add(50);
                dList_CustoInicial_VlrProduto.Add(12);
                dList_CustoInicial_VlrProduto.Add(30);
                dList_CustoInicial_VlrProduto.Add(97);
                dList_CustoInicial_VlrProduto.Add(225);
                dList_CustoInicial_VlrProduto.Add(442);
                dList_CustoInicial_VlrProduto.Add(19);
                dList_CustoInicial_VlrProduto.Add(173);
                dList_CustoInicial_VlrProduto.Add(80);
                dList_CustoInicial_VlrProduto.Add(48);
                dList_CustoInicial_VlrProduto.Add(57);
                dList_CustoInicial_VlrProduto.Add(48);
                dList_CustoInicial_VlrProduto.Add(20);
                dList_CustoInicial_VlrProduto.Add(667);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(55);
                dList_CustoInicial_VlrProduto.Add(306);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(60);
                dList_CustoInicial_VlrProduto.Add(186);
                dList_CustoInicial_VlrProduto.Add(57);
                dList_CustoInicial_VlrProduto.Add(48);
                dList_CustoInicial_VlrProduto.Add(43);
                dList_CustoInicial_VlrProduto.Add(61);
                dList_CustoInicial_VlrProduto.Add(311);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(7);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(14);
                dList_CustoInicial_VlrProduto.Add(18);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(114);
                dList_CustoInicial_VlrProduto.Add(76);
                dList_CustoInicial_VlrProduto.Add(8);
                dList_CustoInicial_VlrProduto.Add(63);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(285);
                dList_CustoInicial_VlrProduto.Add(19);
                dList_CustoInicial_VlrProduto.Add(92);
                dList_CustoInicial_VlrProduto.Add(17);
                dList_CustoInicial_VlrProduto.Add(584);
                dList_CustoInicial_VlrProduto.Add(360);
                dList_CustoInicial_VlrProduto.Add(23);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(140);
                dList_CustoInicial_VlrProduto.Add(57);
                dList_CustoInicial_VlrProduto.Add(148);
                dList_CustoInicial_VlrProduto.Add(100);
                dList_CustoInicial_VlrProduto.Add(20);
                dList_CustoInicial_VlrProduto.Add(9);
                dList_CustoInicial_VlrProduto.Add(10);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(47);
                dList_CustoInicial_VlrProduto.Add(50);
                dList_CustoInicial_VlrProduto.Add(100);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(13);
                dList_CustoInicial_VlrProduto.Add(49);
                dList_CustoInicial_VlrProduto.Add(22);
                dList_CustoInicial_VlrProduto.Add(35);
                dList_CustoInicial_VlrProduto.Add(50);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(120);
                dList_CustoInicial_VlrProduto.Add(17);
                dList_CustoInicial_VlrProduto.Add(12);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(9);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(103);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(49);
                dList_CustoInicial_VlrProduto.Add(43);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(26);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(41);
                dList_CustoInicial_VlrProduto.Add(353);
                dList_CustoInicial_VlrProduto.Add(42);
                dList_CustoInicial_VlrProduto.Add(70);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(22);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(10);
                dList_CustoInicial_VlrProduto.Add(13);
                dList_CustoInicial_VlrProduto.Add(11);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(9);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(19);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(12);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(11);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(20);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(26);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(12);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(10);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(10);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(20);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(19);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(9);
                dList_CustoInicial_VlrProduto.Add(7);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(13);
                dList_CustoInicial_VlrProduto.Add(8);
                dList_CustoInicial_VlrProduto.Add(8);
                dList_CustoInicial_VlrProduto.Add(302);
                dList_CustoInicial_VlrProduto.Add(575);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(195);
                dList_CustoInicial_VlrProduto.Add(37);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(70);
                dList_CustoInicial_VlrProduto.Add(195);
                dList_CustoInicial_VlrProduto.Add(25);
                dList_CustoInicial_VlrProduto.Add(204);
                dList_CustoInicial_VlrProduto.Add(50);
                dList_CustoInicial_VlrProduto.Add(59);
                dList_CustoInicial_VlrProduto.Add(100);
                dList_CustoInicial_VlrProduto.Add(228);
                dList_CustoInicial_VlrProduto.Add(150);
                dList_CustoInicial_VlrProduto.Add(300);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(8);
                dList_CustoInicial_VlrProduto.Add(17);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(195);
                dList_CustoInicial_VlrProduto.Add(33);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(25);
                dList_CustoInicial_VlrProduto.Add(37);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(18);
                dList_CustoInicial_VlrProduto.Add(9);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(1232);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(12);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(50);
                dList_CustoInicial_VlrProduto.Add(17);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(42);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(39);
                dList_CustoInicial_VlrProduto.Add(585);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(240);
                dList_CustoInicial_VlrProduto.Add(70);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(12);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(31);
                dList_CustoInicial_VlrProduto.Add(85);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(41);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(203);
                dList_CustoInicial_VlrProduto.Add(7);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(32);
                dList_CustoInicial_VlrProduto.Add(109);
                dList_CustoInicial_VlrProduto.Add(13);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(449);
                dList_CustoInicial_VlrProduto.Add(16);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(29);
                dList_CustoInicial_VlrProduto.Add(22);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(7);
                dList_CustoInicial_VlrProduto.Add(19);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(296);
                dList_CustoInicial_VlrProduto.Add(520);
                dList_CustoInicial_VlrProduto.Add(620);
                dList_CustoInicial_VlrProduto.Add(270);
                dList_CustoInicial_VlrProduto.Add(17);
                dList_CustoInicial_VlrProduto.Add(28);
                dList_CustoInicial_VlrProduto.Add(43);
                dList_CustoInicial_VlrProduto.Add(82);
                dList_CustoInicial_VlrProduto.Add(88);
                dList_CustoInicial_VlrProduto.Add(24);
                dList_CustoInicial_VlrProduto.Add(134);
                dList_CustoInicial_VlrProduto.Add(17);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(202);
                dList_CustoInicial_VlrProduto.Add(10);
                dList_CustoInicial_VlrProduto.Add(17);
                dList_CustoInicial_VlrProduto.Add(9);
                dList_CustoInicial_VlrProduto.Add(18);
                dList_CustoInicial_VlrProduto.Add(40);
                dList_CustoInicial_VlrProduto.Add(75);
                dList_CustoInicial_VlrProduto.Add(40);
                dList_CustoInicial_VlrProduto.Add(65);
                dList_CustoInicial_VlrProduto.Add(170);
                dList_CustoInicial_VlrProduto.Add(8);
                dList_CustoInicial_VlrProduto.Add(41);
                dList_CustoInicial_VlrProduto.Add(161);
                dList_CustoInicial_VlrProduto.Add(21);
                dList_CustoInicial_VlrProduto.Add(34);
                dList_CustoInicial_VlrProduto.Add(229);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(217);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(18);
                dList_CustoInicial_VlrProduto.Add(27);
                dList_CustoInicial_VlrProduto.Add(15);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(400);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(8);
                dList_CustoInicial_VlrProduto.Add(500);
                dList_CustoInicial_VlrProduto.Add(74);
                dList_CustoInicial_VlrProduto.Add(169);
                dList_CustoInicial_VlrProduto.Add(16);
                dList_CustoInicial_VlrProduto.Add(68);
                dList_CustoInicial_VlrProduto.Add(46);
                dList_CustoInicial_VlrProduto.Add(12);
                dList_CustoInicial_VlrProduto.Add(95);
                dList_CustoInicial_VlrProduto.Add(11);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(38);
                dList_CustoInicial_VlrProduto.Add(59);
                dList_CustoInicial_VlrProduto.Add(11);
                dList_CustoInicial_VlrProduto.Add(14);
                dList_CustoInicial_VlrProduto.Add(46);
                dList_CustoInicial_VlrProduto.Add(68);
                dList_CustoInicial_VlrProduto.Add(1200);
                dList_CustoInicial_VlrProduto.Add(150);
                dList_CustoInicial_VlrProduto.Add(47);
                dList_CustoInicial_VlrProduto.Add(14);
                dList_CustoInicial_VlrProduto.Add(745);
                dList_CustoInicial_VlrProduto.Add(990);
                dList_CustoInicial_VlrProduto.Add(38);
                dList_CustoInicial_VlrProduto.Add(750);
                dList_CustoInicial_VlrProduto.Add(167);
                dList_CustoInicial_VlrProduto.Add(78);
                dList_CustoInicial_VlrProduto.Add(155);
                dList_CustoInicial_VlrProduto.Add(649);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(7);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(10);
                dList_CustoInicial_VlrProduto.Add(41);
                dList_CustoInicial_VlrProduto.Add(309);
                dList_CustoInicial_VlrProduto.Add(223);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(21);
                dList_CustoInicial_VlrProduto.Add(48);
                dList_CustoInicial_VlrProduto.Add(18);
                dList_CustoInicial_VlrProduto.Add(50);
                dList_CustoInicial_VlrProduto.Add(677);
                dList_CustoInicial_VlrProduto.Add(19);
                dList_CustoInicial_VlrProduto.Add(80);
                dList_CustoInicial_VlrProduto.Add(49);
                dList_CustoInicial_VlrProduto.Add(150);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(409);
                dList_CustoInicial_VlrProduto.Add(784);
                dList_CustoInicial_VlrProduto.Add(85);
                dList_CustoInicial_VlrProduto.Add(7);
                dList_CustoInicial_VlrProduto.Add(53);
                dList_CustoInicial_VlrProduto.Add(54);
                dList_CustoInicial_VlrProduto.Add(98);
                dList_CustoInicial_VlrProduto.Add(546);
                dList_CustoInicial_VlrProduto.Add(472);
                dList_CustoInicial_VlrProduto.Add(478);
                dList_CustoInicial_VlrProduto.Add(56);
                dList_CustoInicial_VlrProduto.Add(9);
                dList_CustoInicial_VlrProduto.Add(350);
                dList_CustoInicial_VlrProduto.Add(20);
                dList_CustoInicial_VlrProduto.Add(195);
                dList_CustoInicial_VlrProduto.Add(40);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(265);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(40);
                dList_CustoInicial_VlrProduto.Add(11);
                dList_CustoInicial_VlrProduto.Add(11);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(75);
                dList_CustoInicial_VlrProduto.Add(513);
                dList_CustoInicial_VlrProduto.Add(16);
                dList_CustoInicial_VlrProduto.Add(60);
                dList_CustoInicial_VlrProduto.Add(11);
                dList_CustoInicial_VlrProduto.Add(150);
                dList_CustoInicial_VlrProduto.Add(66);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(60);
                dList_CustoInicial_VlrProduto.Add(1375);
                dList_CustoInicial_VlrProduto.Add(27);
                dList_CustoInicial_VlrProduto.Add(7);
                dList_CustoInicial_VlrProduto.Add(38);
                dList_CustoInicial_VlrProduto.Add(38);
                dList_CustoInicial_VlrProduto.Add(14);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(66);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(21);
                dList_CustoInicial_VlrProduto.Add(43);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(9);
                dList_CustoInicial_VlrProduto.Add(11);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(143);
                dList_CustoInicial_VlrProduto.Add(140);
                dList_CustoInicial_VlrProduto.Add(42);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(66);
                dList_CustoInicial_VlrProduto.Add(57);
                dList_CustoInicial_VlrProduto.Add(294);
                dList_CustoInicial_VlrProduto.Add(399);
                dList_CustoInicial_VlrProduto.Add(44);
                dList_CustoInicial_VlrProduto.Add(265);
                dList_CustoInicial_VlrProduto.Add(105);
                dList_CustoInicial_VlrProduto.Add(20);
                dList_CustoInicial_VlrProduto.Add(94);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(100);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(14);
                dList_CustoInicial_VlrProduto.Add(7);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(10);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(7);
                dList_CustoInicial_VlrProduto.Add(13);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(12);
                dList_CustoInicial_VlrProduto.Add(4000);
                dList_CustoInicial_VlrProduto.Add(34);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(76);
                dList_CustoInicial_VlrProduto.Add(258);
                dList_CustoInicial_VlrProduto.Add(41);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(1133);
                dList_CustoInicial_VlrProduto.Add(18);
                dList_CustoInicial_VlrProduto.Add(616);
                dList_CustoInicial_VlrProduto.Add(53);
                dList_CustoInicial_VlrProduto.Add(25);
                dList_CustoInicial_VlrProduto.Add(10);
                dList_CustoInicial_VlrProduto.Add(210);
                dList_CustoInicial_VlrProduto.Add(69);
                dList_CustoInicial_VlrProduto.Add(80);
                dList_CustoInicial_VlrProduto.Add(125);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(315);
                dList_CustoInicial_VlrProduto.Add(79);
                dList_CustoInicial_VlrProduto.Add(113);
                dList_CustoInicial_VlrProduto.Add(10);
                dList_CustoInicial_VlrProduto.Add(47);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(353);
                dList_CustoInicial_VlrProduto.Add(14);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(120);
                dList_CustoInicial_VlrProduto.Add(200);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(16);
                dList_CustoInicial_VlrProduto.Add(1938);
                dList_CustoInicial_VlrProduto.Add(2082);
                dList_CustoInicial_VlrProduto.Add(800);
                dList_CustoInicial_VlrProduto.Add(99);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(126);
                dList_CustoInicial_VlrProduto.Add(126);
                dList_CustoInicial_VlrProduto.Add(81);
                dList_CustoInicial_VlrProduto.Add(350);
                dList_CustoInicial_VlrProduto.Add(170);
                dList_CustoInicial_VlrProduto.Add(24);
                dList_CustoInicial_VlrProduto.Add(86);
                dList_CustoInicial_VlrProduto.Add(185);
                dList_CustoInicial_VlrProduto.Add(113);
                dList_CustoInicial_VlrProduto.Add(95);
                dList_CustoInicial_VlrProduto.Add(132);
                dList_CustoInicial_VlrProduto.Add(25);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(17);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(12);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(21);
                dList_CustoInicial_VlrProduto.Add(250);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(50);
                dList_CustoInicial_VlrProduto.Add(140);
                dList_CustoInicial_VlrProduto.Add(7);
                dList_CustoInicial_VlrProduto.Add(25);
                dList_CustoInicial_VlrProduto.Add(39);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(209);
                dList_CustoInicial_VlrProduto.Add(37);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(218);
                dList_CustoInicial_VlrProduto.Add(28);
                dList_CustoInicial_VlrProduto.Add(37);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(20);
                dList_CustoInicial_VlrProduto.Add(57);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(49);
                dList_CustoInicial_VlrProduto.Add(36);
                dList_CustoInicial_VlrProduto.Add(32);
                dList_CustoInicial_VlrProduto.Add(10);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(14);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(683);
                dList_CustoInicial_VlrProduto.Add(17);
                dList_CustoInicial_VlrProduto.Add(335);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(50);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(900);
                dList_CustoInicial_VlrProduto.Add(70);
                dList_CustoInicial_VlrProduto.Add(258);
                dList_CustoInicial_VlrProduto.Add(430);
                dList_CustoInicial_VlrProduto.Add(500);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(853);
                dList_CustoInicial_VlrProduto.Add(140);
                dList_CustoInicial_VlrProduto.Add(37);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(95);
                dList_CustoInicial_VlrProduto.Add(99);
                dList_CustoInicial_VlrProduto.Add(82);
                dList_CustoInicial_VlrProduto.Add(420);
                dList_CustoInicial_VlrProduto.Add(190);
                dList_CustoInicial_VlrProduto.Add(9);
                dList_CustoInicial_VlrProduto.Add(59);
                dList_CustoInicial_VlrProduto.Add(1);
                dList_CustoInicial_VlrProduto.Add(4);
                dList_CustoInicial_VlrProduto.Add(14);
                dList_CustoInicial_VlrProduto.Add(135);
                dList_CustoInicial_VlrProduto.Add(30);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(2);
                dList_CustoInicial_VlrProduto.Add(5);
                dList_CustoInicial_VlrProduto.Add(20);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(6);
                dList_CustoInicial_VlrProduto.Add(70);
                dList_CustoInicial_VlrProduto.Add(860);
                dList_CustoInicial_VlrProduto.Add(500);
                dList_CustoInicial_VlrProduto.Add(5600);
                dList_CustoInicial_VlrProduto.Add(20);
                dList_CustoInicial_VlrProduto.Add(60);
                dList_CustoInicial_VlrProduto.Add(174);
                dList_CustoInicial_VlrProduto.Add(12);
                dList_CustoInicial_VlrProduto.Add(13);
                dList_CustoInicial_VlrProduto.Add(3);
                dList_CustoInicial_VlrProduto.Add(657);
                dList_CustoInicial_VlrProduto.Add(345);
                dList_CustoInicial_VlrProduto.Add(909);
                dList_CustoInicial_VlrProduto.Add(425);
                iList_CustoInicial_Estoque.Add(15);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(179);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(20);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(590);
                iList_CustoInicial_Estoque.Add(176);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(33);
                iList_CustoInicial_Estoque.Add(18);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(64);
                iList_CustoInicial_Estoque.Add(38);
                iList_CustoInicial_Estoque.Add(11);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(24);
                iList_CustoInicial_Estoque.Add(82);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(194);
                iList_CustoInicial_Estoque.Add(16);
                iList_CustoInicial_Estoque.Add(1195);
                iList_CustoInicial_Estoque.Add(17);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(21);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(21);
                iList_CustoInicial_Estoque.Add(4457);
                iList_CustoInicial_Estoque.Add(1305);
                iList_CustoInicial_Estoque.Add(329);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(72);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(625);
                iList_CustoInicial_Estoque.Add(31);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(48);
                iList_CustoInicial_Estoque.Add(992);
                iList_CustoInicial_Estoque.Add(15);
                iList_CustoInicial_Estoque.Add(19);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(590);
                iList_CustoInicial_Estoque.Add(122);
                iList_CustoInicial_Estoque.Add(75);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(1533);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(2519);
                iList_CustoInicial_Estoque.Add(355);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(269);
                iList_CustoInicial_Estoque.Add(138);
                iList_CustoInicial_Estoque.Add(166);
                iList_CustoInicial_Estoque.Add(41);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(354);
                iList_CustoInicial_Estoque.Add(1265);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(664);
                iList_CustoInicial_Estoque.Add(883);
                iList_CustoInicial_Estoque.Add(82);
                iList_CustoInicial_Estoque.Add(41);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(12);
                iList_CustoInicial_Estoque.Add(398);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(171);
                iList_CustoInicial_Estoque.Add(47);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(113);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(11);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(588);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(35);
                iList_CustoInicial_Estoque.Add(38);
                iList_CustoInicial_Estoque.Add(62);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(341);
                iList_CustoInicial_Estoque.Add(66);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(113);
                iList_CustoInicial_Estoque.Add(30);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(69);
                iList_CustoInicial_Estoque.Add(348);
                iList_CustoInicial_Estoque.Add(88);
                iList_CustoInicial_Estoque.Add(696);
                iList_CustoInicial_Estoque.Add(41);
                iList_CustoInicial_Estoque.Add(131);
                iList_CustoInicial_Estoque.Add(633);
                iList_CustoInicial_Estoque.Add(54);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(80);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(49);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(63);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(98);
                iList_CustoInicial_Estoque.Add(40);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(55);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(5);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(68);
                iList_CustoInicial_Estoque.Add(81);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(26);
                iList_CustoInicial_Estoque.Add(58);
                iList_CustoInicial_Estoque.Add(1624);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(2510);
                iList_CustoInicial_Estoque.Add(96);
                iList_CustoInicial_Estoque.Add(114);
                iList_CustoInicial_Estoque.Add(17);
                iList_CustoInicial_Estoque.Add(197);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(51);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(75);
                iList_CustoInicial_Estoque.Add(114);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(384);
                iList_CustoInicial_Estoque.Add(489);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(608);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(11);
                iList_CustoInicial_Estoque.Add(315);
                iList_CustoInicial_Estoque.Add(86);
                iList_CustoInicial_Estoque.Add(501);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(129);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(116);
                iList_CustoInicial_Estoque.Add(56);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(56);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(59);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(511);
                iList_CustoInicial_Estoque.Add(117);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(30);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(43);
                iList_CustoInicial_Estoque.Add(93);
                iList_CustoInicial_Estoque.Add(247);
                iList_CustoInicial_Estoque.Add(962);
                iList_CustoInicial_Estoque.Add(11);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(14);
                iList_CustoInicial_Estoque.Add(167);
                iList_CustoInicial_Estoque.Add(399);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(656);
                iList_CustoInicial_Estoque.Add(31);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(12);
                iList_CustoInicial_Estoque.Add(50);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(302);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(936);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(197);
                iList_CustoInicial_Estoque.Add(17);
                iList_CustoInicial_Estoque.Add(19);
                iList_CustoInicial_Estoque.Add(29);
                iList_CustoInicial_Estoque.Add(65);
                iList_CustoInicial_Estoque.Add(126);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(3807);
                iList_CustoInicial_Estoque.Add(22);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(690);
                iList_CustoInicial_Estoque.Add(458);
                iList_CustoInicial_Estoque.Add(2031);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(5);
                iList_CustoInicial_Estoque.Add(294);
                iList_CustoInicial_Estoque.Add(154);
                iList_CustoInicial_Estoque.Add(87);
                iList_CustoInicial_Estoque.Add(15);
                iList_CustoInicial_Estoque.Add(15);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(5);
                iList_CustoInicial_Estoque.Add(84);
                iList_CustoInicial_Estoque.Add(187);
                iList_CustoInicial_Estoque.Add(180);
                iList_CustoInicial_Estoque.Add(93);
                iList_CustoInicial_Estoque.Add(30);
                iList_CustoInicial_Estoque.Add(132);
                iList_CustoInicial_Estoque.Add(123);
                iList_CustoInicial_Estoque.Add(22);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(5);
                iList_CustoInicial_Estoque.Add(218);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(5006);
                iList_CustoInicial_Estoque.Add(109);
                iList_CustoInicial_Estoque.Add(19);
                iList_CustoInicial_Estoque.Add(560);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(248);
                iList_CustoInicial_Estoque.Add(569);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(27);
                iList_CustoInicial_Estoque.Add(504);
                iList_CustoInicial_Estoque.Add(97);
                iList_CustoInicial_Estoque.Add(40);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(33);
                iList_CustoInicial_Estoque.Add(5);
                iList_CustoInicial_Estoque.Add(357);
                iList_CustoInicial_Estoque.Add(193);
                iList_CustoInicial_Estoque.Add(112);
                iList_CustoInicial_Estoque.Add(488);
                iList_CustoInicial_Estoque.Add(166);
                iList_CustoInicial_Estoque.Add(430);
                iList_CustoInicial_Estoque.Add(509);
                iList_CustoInicial_Estoque.Add(57);
                iList_CustoInicial_Estoque.Add(241);
                iList_CustoInicial_Estoque.Add(41);
                iList_CustoInicial_Estoque.Add(177);
                iList_CustoInicial_Estoque.Add(156);
                iList_CustoInicial_Estoque.Add(140);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(491);
                iList_CustoInicial_Estoque.Add(77);
                iList_CustoInicial_Estoque.Add(217);
                iList_CustoInicial_Estoque.Add(242);
                iList_CustoInicial_Estoque.Add(1061);
                iList_CustoInicial_Estoque.Add(261);
                iList_CustoInicial_Estoque.Add(2041);
                iList_CustoInicial_Estoque.Add(279);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(433);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(62);
                iList_CustoInicial_Estoque.Add(28);
                iList_CustoInicial_Estoque.Add(240);
                iList_CustoInicial_Estoque.Add(35);
                iList_CustoInicial_Estoque.Add(117);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(968);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(51);
                iList_CustoInicial_Estoque.Add(96);
                iList_CustoInicial_Estoque.Add(351);
                iList_CustoInicial_Estoque.Add(19254);
                iList_CustoInicial_Estoque.Add(127);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(144);
                iList_CustoInicial_Estoque.Add(32);
                iList_CustoInicial_Estoque.Add(314);
                iList_CustoInicial_Estoque.Add(267);
                iList_CustoInicial_Estoque.Add(66);
                iList_CustoInicial_Estoque.Add(21982);
                iList_CustoInicial_Estoque.Add(25884);
                iList_CustoInicial_Estoque.Add(34);
                iList_CustoInicial_Estoque.Add(45);
                iList_CustoInicial_Estoque.Add(9);
                iList_CustoInicial_Estoque.Add(120);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(12);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(149);
                iList_CustoInicial_Estoque.Add(110);
                iList_CustoInicial_Estoque.Add(41);
                iList_CustoInicial_Estoque.Add(363);
                iList_CustoInicial_Estoque.Add(77);
                iList_CustoInicial_Estoque.Add(76);
                iList_CustoInicial_Estoque.Add(75);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(30);
                iList_CustoInicial_Estoque.Add(90);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(9);
                iList_CustoInicial_Estoque.Add(22);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(46);
                iList_CustoInicial_Estoque.Add(572);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(16);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(454);
                iList_CustoInicial_Estoque.Add(90);
                iList_CustoInicial_Estoque.Add(1280);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(20);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(112);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(186);
                iList_CustoInicial_Estoque.Add(488);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(360);
                iList_CustoInicial_Estoque.Add(540);
                iList_CustoInicial_Estoque.Add(136);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(9);
                iList_CustoInicial_Estoque.Add(94);
                iList_CustoInicial_Estoque.Add(72);
                iList_CustoInicial_Estoque.Add(695);
                iList_CustoInicial_Estoque.Add(30);
                iList_CustoInicial_Estoque.Add(18);
                iList_CustoInicial_Estoque.Add(130);
                iList_CustoInicial_Estoque.Add(456);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(18);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(323);
                iList_CustoInicial_Estoque.Add(38);
                iList_CustoInicial_Estoque.Add(100);
                iList_CustoInicial_Estoque.Add(15);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(84);
                iList_CustoInicial_Estoque.Add(23);
                iList_CustoInicial_Estoque.Add(336);
                iList_CustoInicial_Estoque.Add(397);
                iList_CustoInicial_Estoque.Add(529);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(1033);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(301);
                iList_CustoInicial_Estoque.Add(97);
                iList_CustoInicial_Estoque.Add(158);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(22);
                iList_CustoInicial_Estoque.Add(214);
                iList_CustoInicial_Estoque.Add(193);
                iList_CustoInicial_Estoque.Add(89);
                iList_CustoInicial_Estoque.Add(147);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(77);
                iList_CustoInicial_Estoque.Add(507);
                iList_CustoInicial_Estoque.Add(106);
                iList_CustoInicial_Estoque.Add(210);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(3908);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(213);
                iList_CustoInicial_Estoque.Add(38);
                iList_CustoInicial_Estoque.Add(22);
                iList_CustoInicial_Estoque.Add(173);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(428);
                iList_CustoInicial_Estoque.Add(69);
                iList_CustoInicial_Estoque.Add(148);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(37);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(47);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(91);
                iList_CustoInicial_Estoque.Add(400);
                iList_CustoInicial_Estoque.Add(22);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(524);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(1455);
                iList_CustoInicial_Estoque.Add(1020);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(12);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(96);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(103);
                iList_CustoInicial_Estoque.Add(130);
                iList_CustoInicial_Estoque.Add(1186);
                iList_CustoInicial_Estoque.Add(84);
                iList_CustoInicial_Estoque.Add(415);
                iList_CustoInicial_Estoque.Add(30);
                iList_CustoInicial_Estoque.Add(911);
                iList_CustoInicial_Estoque.Add(168);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(68);
                iList_CustoInicial_Estoque.Add(58);
                iList_CustoInicial_Estoque.Add(183);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(9);
                iList_CustoInicial_Estoque.Add(143);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(692);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(9);
                iList_CustoInicial_Estoque.Add(80);
                iList_CustoInicial_Estoque.Add(14);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(56);
                iList_CustoInicial_Estoque.Add(49);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(56);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(13);
                iList_CustoInicial_Estoque.Add(426);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(54);
                iList_CustoInicial_Estoque.Add(43);
                iList_CustoInicial_Estoque.Add(13);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(80);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(219);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(20);
                iList_CustoInicial_Estoque.Add(5);
                iList_CustoInicial_Estoque.Add(132);
                iList_CustoInicial_Estoque.Add(79);
                iList_CustoInicial_Estoque.Add(42);
                iList_CustoInicial_Estoque.Add(39);
                iList_CustoInicial_Estoque.Add(677);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(32);
                iList_CustoInicial_Estoque.Add(5);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(25);
                iList_CustoInicial_Estoque.Add(19);
                iList_CustoInicial_Estoque.Add(16);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(473);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(37);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(32);
                iList_CustoInicial_Estoque.Add(43);
                iList_CustoInicial_Estoque.Add(39);
                iList_CustoInicial_Estoque.Add(123);
                iList_CustoInicial_Estoque.Add(228);
                iList_CustoInicial_Estoque.Add(45);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(28);
                iList_CustoInicial_Estoque.Add(99);
                iList_CustoInicial_Estoque.Add(17);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(232);
                iList_CustoInicial_Estoque.Add(31);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(16);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(5);
                iList_CustoInicial_Estoque.Add(186);
                iList_CustoInicial_Estoque.Add(20);
                iList_CustoInicial_Estoque.Add(30);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(50);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(20);
                iList_CustoInicial_Estoque.Add(88);
                iList_CustoInicial_Estoque.Add(9);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(26);
                iList_CustoInicial_Estoque.Add(150);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(600);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(9);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(18);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(345);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(168);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(154);
                iList_CustoInicial_Estoque.Add(517);
                iList_CustoInicial_Estoque.Add(180);
                iList_CustoInicial_Estoque.Add(737);
                iList_CustoInicial_Estoque.Add(427);
                iList_CustoInicial_Estoque.Add(66);
                iList_CustoInicial_Estoque.Add(146);
                iList_CustoInicial_Estoque.Add(220);
                iList_CustoInicial_Estoque.Add(110);
                iList_CustoInicial_Estoque.Add(135);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(200);
                iList_CustoInicial_Estoque.Add(494);
                iList_CustoInicial_Estoque.Add(612);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(90);
                iList_CustoInicial_Estoque.Add(28);
                iList_CustoInicial_Estoque.Add(23);
                iList_CustoInicial_Estoque.Add(279);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(31);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(373);
                iList_CustoInicial_Estoque.Add(35);
                iList_CustoInicial_Estoque.Add(12);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(25455);
                iList_CustoInicial_Estoque.Add(18);
                iList_CustoInicial_Estoque.Add(41);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(231);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(117);
                iList_CustoInicial_Estoque.Add(15);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(260);
                iList_CustoInicial_Estoque.Add(96);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(300);
                iList_CustoInicial_Estoque.Add(33);
                iList_CustoInicial_Estoque.Add(20418);
                iList_CustoInicial_Estoque.Add(13);
                iList_CustoInicial_Estoque.Add(17);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(81);
                iList_CustoInicial_Estoque.Add(372);
                iList_CustoInicial_Estoque.Add(108);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(72);
                iList_CustoInicial_Estoque.Add(44);
                iList_CustoInicial_Estoque.Add(121);
                iList_CustoInicial_Estoque.Add(22);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(105);
                iList_CustoInicial_Estoque.Add(90);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(12);
                iList_CustoInicial_Estoque.Add(29);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(21);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(49);
                iList_CustoInicial_Estoque.Add(75);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(17);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(77);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(288);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(116);
                iList_CustoInicial_Estoque.Add(213);
                iList_CustoInicial_Estoque.Add(984);
                iList_CustoInicial_Estoque.Add(97);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(60);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(345);
                iList_CustoInicial_Estoque.Add(11);
                iList_CustoInicial_Estoque.Add(272);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(151);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(20487);
                iList_CustoInicial_Estoque.Add(14);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(506);
                iList_CustoInicial_Estoque.Add(41);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(210);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(138);
                iList_CustoInicial_Estoque.Add(194);
                iList_CustoInicial_Estoque.Add(2442);
                iList_CustoInicial_Estoque.Add(541);
                iList_CustoInicial_Estoque.Add(183);
                iList_CustoInicial_Estoque.Add(142);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(9);
                iList_CustoInicial_Estoque.Add(80);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(325);
                iList_CustoInicial_Estoque.Add(15);
                iList_CustoInicial_Estoque.Add(64);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(23);
                iList_CustoInicial_Estoque.Add(23);
                iList_CustoInicial_Estoque.Add(177);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(67);
                iList_CustoInicial_Estoque.Add(56);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(513);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(79);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(1722);
                iList_CustoInicial_Estoque.Add(180);
                iList_CustoInicial_Estoque.Add(58);
                iList_CustoInicial_Estoque.Add(920);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(33);
                iList_CustoInicial_Estoque.Add(20);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(44);
                iList_CustoInicial_Estoque.Add(153);
                iList_CustoInicial_Estoque.Add(69);
                iList_CustoInicial_Estoque.Add(39);
                iList_CustoInicial_Estoque.Add(86);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(322);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(328);
                iList_CustoInicial_Estoque.Add(95);
                iList_CustoInicial_Estoque.Add(119);
                iList_CustoInicial_Estoque.Add(936);
                iList_CustoInicial_Estoque.Add(17);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(79);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(118);
                iList_CustoInicial_Estoque.Add(28);
                iList_CustoInicial_Estoque.Add(43);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(111);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(40);
                iList_CustoInicial_Estoque.Add(42);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(336);
                iList_CustoInicial_Estoque.Add(5);
                iList_CustoInicial_Estoque.Add(0);
                iList_CustoInicial_Estoque.Add(5);
                iList_CustoInicial_Estoque.Add(0);
            }
            //Dados iniciais da UNICE
            
            else if (Usuario.unidade_Login == 2)
            {
                iList_CustoInicial_CodProduto.Add(5);
                iList_CustoInicial_CodProduto.Add(6);
                iList_CustoInicial_CodProduto.Add(8);
                iList_CustoInicial_CodProduto.Add(9);
                iList_CustoInicial_CodProduto.Add(12);
                iList_CustoInicial_CodProduto.Add(17);
                iList_CustoInicial_CodProduto.Add(22);
                iList_CustoInicial_CodProduto.Add(23);
                iList_CustoInicial_CodProduto.Add(25);
                iList_CustoInicial_CodProduto.Add(29);
                iList_CustoInicial_CodProduto.Add(31);
                iList_CustoInicial_CodProduto.Add(32);
                iList_CustoInicial_CodProduto.Add(34);
                iList_CustoInicial_CodProduto.Add(35);
                iList_CustoInicial_CodProduto.Add(37);
                iList_CustoInicial_CodProduto.Add(43);
                iList_CustoInicial_CodProduto.Add(51);
                iList_CustoInicial_CodProduto.Add(52);
                iList_CustoInicial_CodProduto.Add(56);
                iList_CustoInicial_CodProduto.Add(58);
                iList_CustoInicial_CodProduto.Add(63);
                iList_CustoInicial_CodProduto.Add(65);
                iList_CustoInicial_CodProduto.Add(66);
                iList_CustoInicial_CodProduto.Add(70);
                iList_CustoInicial_CodProduto.Add(71);
                iList_CustoInicial_CodProduto.Add(73);
                iList_CustoInicial_CodProduto.Add(75);
                iList_CustoInicial_CodProduto.Add(78);
                iList_CustoInicial_CodProduto.Add(79);
                iList_CustoInicial_CodProduto.Add(81);
                iList_CustoInicial_CodProduto.Add(82);
                iList_CustoInicial_CodProduto.Add(83);
                iList_CustoInicial_CodProduto.Add(91);
                iList_CustoInicial_CodProduto.Add(92);
                iList_CustoInicial_CodProduto.Add(93);
                iList_CustoInicial_CodProduto.Add(94);
                iList_CustoInicial_CodProduto.Add(95);
                iList_CustoInicial_CodProduto.Add(97);
                iList_CustoInicial_CodProduto.Add(98);
                iList_CustoInicial_CodProduto.Add(101);
                iList_CustoInicial_CodProduto.Add(105);
                iList_CustoInicial_CodProduto.Add(121);
                iList_CustoInicial_CodProduto.Add(130);
                iList_CustoInicial_CodProduto.Add(131);
                iList_CustoInicial_CodProduto.Add(136);
                iList_CustoInicial_CodProduto.Add(138);
                iList_CustoInicial_CodProduto.Add(139);
                iList_CustoInicial_CodProduto.Add(142);
                iList_CustoInicial_CodProduto.Add(146);
                iList_CustoInicial_CodProduto.Add(147);
                iList_CustoInicial_CodProduto.Add(148);
                iList_CustoInicial_CodProduto.Add(151);
                iList_CustoInicial_CodProduto.Add(153);
                iList_CustoInicial_CodProduto.Add(161);
                iList_CustoInicial_CodProduto.Add(171);
                iList_CustoInicial_CodProduto.Add(172);
                iList_CustoInicial_CodProduto.Add(173);
                iList_CustoInicial_CodProduto.Add(175);
                iList_CustoInicial_CodProduto.Add(178);
                iList_CustoInicial_CodProduto.Add(183);
                iList_CustoInicial_CodProduto.Add(197);
                iList_CustoInicial_CodProduto.Add(198);
                iList_CustoInicial_CodProduto.Add(200);
                iList_CustoInicial_CodProduto.Add(201);
                iList_CustoInicial_CodProduto.Add(202);
                iList_CustoInicial_CodProduto.Add(204);
                iList_CustoInicial_CodProduto.Add(214);
                iList_CustoInicial_CodProduto.Add(215);
                iList_CustoInicial_CodProduto.Add(219);
                iList_CustoInicial_CodProduto.Add(220);
                iList_CustoInicial_CodProduto.Add(226);
                iList_CustoInicial_CodProduto.Add(227);
                iList_CustoInicial_CodProduto.Add(230);
                iList_CustoInicial_CodProduto.Add(232);
                iList_CustoInicial_CodProduto.Add(237);


                iList_CustoInicial_Estoque.Add(651);
                iList_CustoInicial_Estoque.Add(60);
                iList_CustoInicial_Estoque.Add(873);
                iList_CustoInicial_Estoque.Add(30);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(340);
                iList_CustoInicial_Estoque.Add(164);
                iList_CustoInicial_Estoque.Add(551);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(208);
                iList_CustoInicial_Estoque.Add(51);
                iList_CustoInicial_Estoque.Add(100);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(5);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(66);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(82);
                iList_CustoInicial_Estoque.Add(16);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(71);
                iList_CustoInicial_Estoque.Add(9);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(24);
                iList_CustoInicial_Estoque.Add(14);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(91);
                iList_CustoInicial_Estoque.Add(25);
                iList_CustoInicial_Estoque.Add(201);
                iList_CustoInicial_Estoque.Add(8);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(1343);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(6);
                iList_CustoInicial_Estoque.Add(10);
                iList_CustoInicial_Estoque.Add(8771);
                iList_CustoInicial_Estoque.Add(4);
                iList_CustoInicial_Estoque.Add(364);
                iList_CustoInicial_Estoque.Add(521);
                iList_CustoInicial_Estoque.Add(16);
                iList_CustoInicial_Estoque.Add(220);
                iList_CustoInicial_Estoque.Add(44);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(160);
                iList_CustoInicial_Estoque.Add(18);
                iList_CustoInicial_Estoque.Add(14);
                iList_CustoInicial_Estoque.Add(2);
                iList_CustoInicial_Estoque.Add(177);
                iList_CustoInicial_Estoque.Add(58);
                iList_CustoInicial_Estoque.Add(11);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(3);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(3726);
                iList_CustoInicial_Estoque.Add(27);
                iList_CustoInicial_Estoque.Add(7);
                iList_CustoInicial_Estoque.Add(200);
                iList_CustoInicial_Estoque.Add(1);
                iList_CustoInicial_Estoque.Add(13);

                dList_CustoInicial_VlrProduto.Add(66.129);
                dList_CustoInicial_VlrProduto.Add(52.9032);
                dList_CustoInicial_VlrProduto.Add(66.129);
                dList_CustoInicial_VlrProduto.Add(55.1075);
                dList_CustoInicial_VlrProduto.Add(149.7186);
                dList_CustoInicial_VlrProduto.Add(33.83);
                dList_CustoInicial_VlrProduto.Add(44.28);
                dList_CustoInicial_VlrProduto.Add(12.3938);
                dList_CustoInicial_VlrProduto.Add(42.7159);
                dList_CustoInicial_VlrProduto.Add(62.4);
                dList_CustoInicial_VlrProduto.Add(635.029);
                dList_CustoInicial_VlrProduto.Add(889.7);
                dList_CustoInicial_VlrProduto.Add(353.418);
                dList_CustoInicial_VlrProduto.Add(79.5);
                dList_CustoInicial_VlrProduto.Add(119.5);
                dList_CustoInicial_VlrProduto.Add(140.284);
                dList_CustoInicial_VlrProduto.Add(2.6187);
                dList_CustoInicial_VlrProduto.Add(27);
                dList_CustoInicial_VlrProduto.Add(5.7394);
                dList_CustoInicial_VlrProduto.Add(52);
                dList_CustoInicial_VlrProduto.Add(14.7);
                dList_CustoInicial_VlrProduto.Add(4.9801);
                dList_CustoInicial_VlrProduto.Add(1.6664);
                dList_CustoInicial_VlrProduto.Add(4.4);
                dList_CustoInicial_VlrProduto.Add(96.9892);
                dList_CustoInicial_VlrProduto.Add(1206.40);
                dList_CustoInicial_VlrProduto.Add(649.458);
                dList_CustoInicial_VlrProduto.Add(174.2709);
                dList_CustoInicial_VlrProduto.Add(49.086);
                dList_CustoInicial_VlrProduto.Add(1008.30);
                dList_CustoInicial_VlrProduto.Add(630.6525);
                dList_CustoInicial_VlrProduto.Add(303.0519);
                dList_CustoInicial_VlrProduto.Add(87.76);
                dList_CustoInicial_VlrProduto.Add(263.35);
                dList_CustoInicial_VlrProduto.Add(584.47);
                dList_CustoInicial_VlrProduto.Add(966.5031);
                dList_CustoInicial_VlrProduto.Add(397.9574);
                dList_CustoInicial_VlrProduto.Add(176.858);
                dList_CustoInicial_VlrProduto.Add(28.5);
                dList_CustoInicial_VlrProduto.Add(709.071);
                dList_CustoInicial_VlrProduto.Add(257.8392);
                dList_CustoInicial_VlrProduto.Add(206.6425);
                dList_CustoInicial_VlrProduto.Add(14.712);
                dList_CustoInicial_VlrProduto.Add(10.4746);
                dList_CustoInicial_VlrProduto.Add(3871.28);
                dList_CustoInicial_VlrProduto.Add(526.1546);
                dList_CustoInicial_VlrProduto.Add(10.9013);
                dList_CustoInicial_VlrProduto.Add(410);
                dList_CustoInicial_VlrProduto.Add(1.662);
                dList_CustoInicial_VlrProduto.Add(84.7164);
                dList_CustoInicial_VlrProduto.Add(42.7375);
                dList_CustoInicial_VlrProduto.Add(49.2257);
                dList_CustoInicial_VlrProduto.Add(5.7927);
                dList_CustoInicial_VlrProduto.Add(7.8824);
                dList_CustoInicial_VlrProduto.Add(701.343);
                dList_CustoInicial_VlrProduto.Add(23.8057);
                dList_CustoInicial_VlrProduto.Add(112.1281);
                dList_CustoInicial_VlrProduto.Add(79.5);
                dList_CustoInicial_VlrProduto.Add(4.7277);
                dList_CustoInicial_VlrProduto.Add(101.6624);
                dList_CustoInicial_VlrProduto.Add(141.0722);
                dList_CustoInicial_VlrProduto.Add(10.8923);
                dList_CustoInicial_VlrProduto.Add(187.802);
                dList_CustoInicial_VlrProduto.Add(6.3663);
                dList_CustoInicial_VlrProduto.Add(55.1075);
                dList_CustoInicial_VlrProduto.Add(1484.31);
                dList_CustoInicial_VlrProduto.Add(20.0498);
                dList_CustoInicial_VlrProduto.Add(5.9514);
                dList_CustoInicial_VlrProduto.Add(493.7359);
                dList_CustoInicial_VlrProduto.Add(151.5537);
                dList_CustoInicial_VlrProduto.Add(279.9396);
                dList_CustoInicial_VlrProduto.Add(131.2851);
                dList_CustoInicial_VlrProduto.Add(35);
                dList_CustoInicial_VlrProduto.Add(2.0367);
                dList_CustoInicial_VlrProduto.Add(3.1);

            }
            //Dados iniciais da UNISP (Empty)
            else if (Usuario.unidade_Login == 3)
            {

            }
        }

        private void configurar_DataGridView(DataGridView dgvCusto)
        {
            //Criação do table para armazenar os produtos e entender se já foi feita alguma referência a ele

            dgvCusto.Columns.Add("Prot_NF", "Protocolo / Num Nota");             //0
            dgvCusto.Columns.Add("Cod_Operacao", "Cod. Operação");               //1
            dgvCusto.Columns.Add("Dat_Transacao", "Dat. Transacão");             //2
            dgvCusto.Columns.Add("Cod_Produto", "Cod. Produto");                 //3
            dgvCusto.Columns.Add("Desc_Produto", "Desc. Produto");               //4
            dgvCusto.Columns.Add("Qtd_Unitario", "Qtd. Produto");                //5
            dgvCusto.Columns.Add("Prc_Unitario", "Prc. Unitario");               //6
            dgvCusto.Columns.Add("Tipo_Operacao ", "Tipo Operacao");             //7
            dgvCusto.Columns.Add("Vlr_Total_Produto  ", "Vlr. Total Produto");   //8
            dgvCusto.Columns.Add("Custo_Produto", "Custo Produto");              //9
            dgvCusto.Columns.Add("Custo_Total  ", "Custo Total");                //10            
            dgvCusto.Columns.Add("Estoque_Final  ", "Estoque");                  //11
        }

        private void recalcular_Custo()
        {
            this.Invoke((MethodInvoker)delegate { Cursor = Cursors.WaitCursor; });
            //Limpando o custo médio
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {

                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText =
                            " DELETE FROM [UNIDB].dbo.[CUSTO_MEDIO] ";



                        command.ExecuteNonQuery();



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
            
            //Levanta notas fiscais de Entrada, Saída e movimentações por acerto.
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {
                    try
                    {
                    //MessageBox.Show("Tentei");
                        connectDMD.Open();

                        command = connectDMD.CreateCommand();
                    command.CommandText =
" SELECT																																												"
+ "   NSCB.Num_Nota[Prot_NF]                                                            																									"
+ "   ,[Transacao]                                                                      																									"
+ "   =  CASE NSCB.Transacao                                                              																								"
+ "   WHEN NULL THEN NSIT.Transacao                                                     																									"
+ "   ELSE                                                                              																									"
+ "                                                                                     																									"
+ "       CASE WHEN NSCB.Transacao > NSIT.Transacao THEN NSIT.Transacao                 																									"
+ "        ELSE NSCB.Transacao                                                          																									"
+ "        END                                                                          																									"
+ "  END                                                                                																									"
+ "  ,NSIT.Cod_Produto[Cod_Produto]                                                     																									"
+ "  ,NSIT.Cod_Cfo[CFOP]                                                                																									"
+ "  ,PROD.Descricao                                                                    																									"
+ "  ,[Prc_Unitario] = (NSIT.Vlr_LiqVenIte/NSIT.Qtd_Produto)                            																									"
+ "  ,NSIT.Qtd_Produto[Quantidade]                                                      																									"
+ "  ,[Estoque_Anterior] = isnull((SELECT TOP 1 PR.Qtd_SldAtu FROM PRSLD PR WHERE PR.Cod_Produt = PROD.Codigo AND PR.Dat_Movime <= NSCB.Dat_Emissao ORDER BY PR.Dat_Movime DESC),0)		"
+ "  ,'Saida'[Tipo]      																																								"
+ "  ,nscb.flg_movest                                                                   																									"
+ " FROM                                                                                																									"
+ "  DMD.dbo.NFSIT NSIT                                                                 																									"
+ "  INNER JOIN DMD.dbo.NFSCB NSCB ON NSCB.Num_Nota = NSIT.Num_Nota                     																									"
+ "  INNER JOIN DMD.dbo.PRODU PROD ON PROD.Codigo = NSIT.Cod_Produto                    																									"
+ " WHERE                                                                               																									"
+ "  ( (NSIT.Transacao BETWEEN '01-01-2019' AND @DAT_FINAL)                             																									"
+ "  OR(NSCB.Transacao BETWEEN '01-01-2020' AND @DAT_FINAL AND NSIT.Transacao IS NULL)) 																									"
+ "  AND NSCB.STATUS = 'F'                   																																			"
//+ " AND PROD.CODIGO in (11849,75,358,2095,10248,10569,11558) "
+ " UNION        ALL                                                                    																									"
+ "                                                                                     																									"
+ " SELECT                                                                              																									"
+ "   NECB.Protocolo[Prot_NF]                                                           																									"
+ "  ,NEIT.Transacao[Transacao]                                                         																									"
+ "  ,NEIT.Cod_Produto[Cod_Produto]                                                     																									"
+ "  ,NEIT.Cod_Cfo[CFOP]                                                                																									"
+ "  ,PROD.Descricao                                                                    																									"
+ "  ,[Prc_Unitario] =                                                                  																									"
+ "  CASE((100 - NEIT.Per_DescItem) / 100)                                              																									"
+ "  WHEN 0 THEN NEIT.Prc_Unitario                                                      																									"
+ "  ELSE((100 - NEIT.Per_DescItem) / 100) * NEIT.Prc_Unitario                          																									"
+ "  END                                                                                																									"
+ "  ,NEIT.Qtd_Pedido[Quantidade]          																																				"
+ "  ,[Estoque Anterior] = isnull((SELECT TOP 1 PR.Qtd_SldAtu FROM PRSLD PR WHERE PR.Cod_Produt = PROD.Codigo AND PR.Dat_Movime <= NECB.Dat_Emissao ORDER BY PR.Dat_Movime DESC),0)		"
+ "  ,'Entrada'[Tipo]                                                                   																									"
+ "  ,NECB.flg_movest                                                                   																									"
+ " FROM                                                                                																									"
+ "  DMD.dbo.NFEIT NEIT                                                                 																									"
+ "  INNER JOIN DMD.dbo.NFECB NECB ON NECB.Protocolo = NEIT.Protocolo                   																									"
+ "  INNER JOIN DMD.dbo.PRODU PROD ON PROD.Codigo = NEIT.Cod_Produto                    																									"
+ " WHERE                                                                               																									"
+ "  NEIT.Transacao BETWEEN '01-01-2019' AND @DAT_FINAL                                 																									"
+ "  AND NECB.STATUS = 'F'       																																						"
//+ " AND PROD.CODIGO in (11849,75,358,2095,10248,10569,11558) "
+ " UNION    ALL                                                                        																									"
+ "                                                                                     																									"
+ " SELECT                                                                              																									"
+ "   ACER.Numero[Prot_NF]                                                              																									"
+ "  ,ACER.Transacao[Transacao]                                                         																									"
+ "  ,ACER.Cod_Produto[Cod_Produto]                                                     																									"
+ "  ,ACER.Cod_TipMov[CFOP]                                                             																									"
+ "  ,PROD.Descricao                                                                    																									"
+ "  ,0[Prc_Unitario]                                                                   																									"
+ "  ,ACER.Qtd_Acerto[Quantidade]                                                       																									"
+ "  ,[Estoque Anterior] = isnull((SELECT TOP 1 PR.Qtd_SldAtu FROM PRSLD PR WHERE PR.Cod_Produt = PROD.Codigo AND PR.Dat_Movime <= ACER.Transacao ORDER BY PR.Dat_Movime DESC),0)		"
+ "  ,'Acerto'[Tipo]                                                                    																									"
+ "  ,flg_movest = 1                                                                    																									"
+ " FROM                                                                                																									"
+ "  DMD.dbo.ACERT ACER                                                                 																									"
+ "  INNER JOIN PRODU PROD ON PROD.CODIGO = ACER.Cod_Produto                            																									"
+ " WHERE ACER.Transacao BETWEEN '01-01-2019' AND @DAT_FINAL       																														"
//+ " AND PROD.CODIGO in (11849,75,358,2095,10248,10569,11558) "
+ " ORDER BY Transacao asc                                                              																									";



                    command.Parameters.AddWithValue("Dat_Final", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                    //command.Parameters.AddWithValue("Dat_Final", Convert.ToDateTime(DateTime.Now.AddDays(-700).ToShortDateString()));
                    command.CommandTimeout = 120;
                    reader = command.ExecuteReader();
                    //MessageBox.Show("li");
                    while (reader.Read())
                        {
                            if (reader["Prot_NF"] != null)
                            {
                            //MessageBox.Show(reader["Prot_NF"].ToString());
                            iList_CalcCusto_ProtocoloNF.Add(Convert.ToInt32(reader["Prot_NF"].ToString()));
                                dtList_CalcCusto_Transacao.Add(Convert.ToDateTime(reader["Transacao"].ToString()));
                                iList_CalcCusto_CodProduto.Add(Convert.ToInt32(reader["Cod_Produto"].ToString()));
                                sList_CalcCusto_DescProduto.Add(reader["Descricao"].ToString());
                                iList_CalcCusto_CFOP.Add(Convert.ToInt32(reader["CFOP"].ToString()));
                                dList_CalcCusto_PrcUnitario.Add(Math.Round(Convert.ToDouble(reader["Prc_Unitario"].ToString()), 4));
                                iList_CalcCusto_Quantidade.Add(Convert.ToInt32(reader["Quantidade"].ToString()));
                                sList_CalcCusto_Tipo.Add(reader["Tipo"].ToString());
                                iList_CalcCusto_MovEst.Add(Convert.ToInt32(reader["Flg_MovEst"].ToString()));
                                iList_CalcCusto_EstAnterior.Add(Convert.ToInt32(reader["Estoque_Anterior"].ToString()));
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

            //Variáveis de cálculo

            double CustoAnterior = 0;
            int EstoqueAnterior = 0;
            
           pgbCustoMedio.Invoke(new MethodInvoker(delegate { pgbCustoMedio.Maximum = iList_CalcCusto_ProtocoloNF.Count; }));
           //Insere os produtos no Banco
           for (ContaNotas = 0; ContaNotas < iList_CalcCusto_ProtocoloNF.Count; ContaNotas++)
           {

                    int ExisteProdutoNaTabela = 0;

                    //Resgatando custo inicial
                    //O item já existe na tabela?
                    foreach (DataGridViewRow row in dgvCustoFinal.Rows)
                    {
                        if (row.Cells[3].Value.Equals(iList_CalcCusto_CodProduto[ContaNotas]))
                        {
                            ExisteProdutoNaTabela = 1;
                            break;
                        }
                    }

                    ////Se existir, procure o valor do custo                 
                    if (ExisteProdutoNaTabela == 1)
                    {
                        int ProcurarProdutoTabela = 0;

                        for (ProcurarProdutoTabela = ContaNotas - 1; ProcurarProdutoTabela > 0; ProcurarProdutoTabela--)
                        {
                            if (Convert.ToInt32(dgvCustoFinal.Rows[ProcurarProdutoTabela].Cells[3].Value) == iList_CalcCusto_CodProduto[ContaNotas])
                            {
                                CustoAnterior = Math.Round(Convert.ToDouble(dgvCustoFinal.Rows[ProcurarProdutoTabela].Cells[9].Value.ToString()), 4);
                                EstoqueAnterior = Convert.ToInt32(dgvCustoFinal.Rows[ProcurarProdutoTabela].Cells[11].Value);
                            //EstoqueAnterior = iList_CalcCusto_EstAnterior[ProcurarProdutoTabela];
                            break;
                            }
                        }
                    }
                    ////Se não existir
                    ////O item existe na estrutura de custo inicial?
                    else if (iList_CustoInicial_CodProduto.Contains(iList_CalcCusto_CodProduto[ContaNotas]))
                    {
                        for (int ProcurarProdutoLista = 0; ProcurarProdutoLista < iList_CustoInicial_CodProduto.Count; ProcurarProdutoLista++)
                        {
                            if (Convert.ToInt32(iList_CustoInicial_CodProduto[ProcurarProdutoLista]) == iList_CalcCusto_CodProduto[ContaNotas])
                            {
                                CustoAnterior = Math.Round(Convert.ToDouble(dList_CustoInicial_VlrProduto[ProcurarProdutoLista]), 4);
                            EstoqueAnterior = Convert.ToInt32(iList_CustoInicial_Estoque[ProcurarProdutoLista]);
                            //EstoqueAnterior = iList_CalcCusto_EstAnterior[ProcurarProdutoLista];
                            break;
                            }
                        }
                    }
                    else
                    {
                        CustoAnterior = 0;
                        EstoqueAnterior = 0;
                }


                    ////Calcular Custo
                    double CustoFinal = 0.0;
                    int EstoqueFinal = 0;
                    double Faturamento = 0.0;
                    double CustoFinalTotal = 0.0;

                    if (iList_CalcCusto_MovEst[ContaNotas] == 0)
                    {
                        CustoFinal = Math.Round(CustoAnterior, 4);
                        EstoqueFinal = EstoqueAnterior;
                        Faturamento = 0;
                    }
                    else if (sList_CalcCusto_Tipo[ContaNotas].Equals("Entrada"))
                    {
                        //Entrada por compra normal
                        if (iList_CalcCusto_CFOP[ContaNotas] == 1101
                            || iList_CalcCusto_CFOP[ContaNotas] == 1102
                            || iList_CalcCusto_CFOP[ContaNotas] == 1117
                            || iList_CalcCusto_CFOP[ContaNotas] == 1401
                            || iList_CalcCusto_CFOP[ContaNotas] == 1403
                            || iList_CalcCusto_CFOP[ContaNotas] == 2101
                            || iList_CalcCusto_CFOP[ContaNotas] == 2102
                            || iList_CalcCusto_CFOP[ContaNotas] == 2117
                            || iList_CalcCusto_CFOP[ContaNotas] == 2403
                           )
                        {

                            CustoFinal = Math.Round(((EstoqueAnterior * CustoAnterior) + (iList_CalcCusto_Quantidade[ContaNotas] * dList_CalcCusto_PrcUnitario[ContaNotas])) /
                                           (EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas]), 4);

                        EstoqueFinal = EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas];
                        Faturamento = 0;
                        }

                        //Entrada por bonificação
                        else if (iList_CalcCusto_CFOP[ContaNotas] == 1910
                              || iList_CalcCusto_CFOP[ContaNotas] == 2910
                            )
                        {
                            CustoFinal = Math.Round((EstoqueAnterior * CustoAnterior) / (EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas]), 4);
                            EstoqueFinal = EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas];
                            Faturamento = 0;
                        }
                        //Entrada por devolução
                        else if (iList_CalcCusto_CFOP[ContaNotas] == 1201
                                 || iList_CalcCusto_CFOP[ContaNotas] == 1202
                                 || iList_CalcCusto_CFOP[ContaNotas] == 1411
                                 || iList_CalcCusto_CFOP[ContaNotas] == 2201
                                 || iList_CalcCusto_CFOP[ContaNotas] == 2202
                                 || iList_CalcCusto_CFOP[ContaNotas] == 2411
                                 || iList_CalcCusto_CFOP[ContaNotas] == 1919
                                 || iList_CalcCusto_CFOP[ContaNotas] == 2919
                                )
                        {
                            CustoFinal = Math.Round(CustoAnterior, 4);
                            EstoqueFinal = EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas];
                            Faturamento = 0;
                        }
                        //Caso contrário
                        else
                        {
                            CustoFinal = Math.Round(CustoAnterior, 4);
                            EstoqueFinal = EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas];
                            Faturamento = 0;
                        }

                    }
                    else if (sList_CalcCusto_Tipo[ContaNotas].Equals("Saida"))
                    {
                        //Saída por Venda
                        if (iList_CalcCusto_CFOP[ContaNotas] == 5102
                        || iList_CalcCusto_CFOP[ContaNotas] == 5114
                        || iList_CalcCusto_CFOP[ContaNotas] == 5117
                        || iList_CalcCusto_CFOP[ContaNotas] == 5120
                        || iList_CalcCusto_CFOP[ContaNotas] == 5403
                        || iList_CalcCusto_CFOP[ContaNotas] == 5405
                        || iList_CalcCusto_CFOP[ContaNotas] == 5551
                        || iList_CalcCusto_CFOP[ContaNotas] == 5929
                        || iList_CalcCusto_CFOP[ContaNotas] == 6102
                        || iList_CalcCusto_CFOP[ContaNotas] == 6106
                        || iList_CalcCusto_CFOP[ContaNotas] == 6108
                        || iList_CalcCusto_CFOP[ContaNotas] == 6114
                        || iList_CalcCusto_CFOP[ContaNotas] == 6117
                        || iList_CalcCusto_CFOP[ContaNotas] == 6119
                        || iList_CalcCusto_CFOP[ContaNotas] == 6120
                        || iList_CalcCusto_CFOP[ContaNotas] == 6403
                        || iList_CalcCusto_CFOP[ContaNotas] == 6404
                        || iList_CalcCusto_CFOP[ContaNotas] == 6551)
                        {
                            CustoFinal = Math.Round(CustoAnterior, 4);
                            EstoqueFinal = EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas];
                            Faturamento = Math.Round(iList_CalcCusto_Quantidade[ContaNotas] * dList_CalcCusto_PrcUnitario[ContaNotas], 4);
                        }
                        //Saída por Devolução
                        else if (iList_CalcCusto_CFOP[ContaNotas] == 5202
                                 || iList_CalcCusto_CFOP[ContaNotas] == 5411
                                 || iList_CalcCusto_CFOP[ContaNotas] == 6202
                                 || iList_CalcCusto_CFOP[ContaNotas] == 6411
                                 )
                        {





                            if (EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas] != 0)
                            {
                                CustoFinal = Math.Round(((EstoqueAnterior * CustoAnterior) + (iList_CalcCusto_Quantidade[ContaNotas] * -dList_CalcCusto_PrcUnitario[ContaNotas])) /
                                         (EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas]), 4);


                                EstoqueFinal = EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas];
                                Faturamento = 0;
                            }


                            else
                            {
                                CustoFinal = 0;
                                EstoqueFinal = EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas];
                                Faturamento = 0;
                            }
                        }
                        else
                        {
                            CustoFinal = Math.Round(CustoAnterior, 4);
                            EstoqueFinal = EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas];
                            Faturamento = Math.Round(iList_CalcCusto_Quantidade[ContaNotas] * dList_CalcCusto_PrcUnitario[ContaNotas], 4);
                        }
                    }
                else if (sList_CalcCusto_Tipo[ContaNotas].Equals("Acerto"))
                {
                    //Entrada por acerto
                    //11
                    //12
                    //13
                    //15
                    //16
                    //17
                    //18
                    //31
                    //32
                    //33
                    //35
                    //37



                    if (iList_CalcCusto_CFOP[ContaNotas] == 11
                         || iList_CalcCusto_CFOP[ContaNotas] == 12
                         || iList_CalcCusto_CFOP[ContaNotas] == 13
                         || iList_CalcCusto_CFOP[ContaNotas] == 14
                         //|| iList_CalcCusto_CFOP[ContaNotas] == 15
                         || iList_CalcCusto_CFOP[ContaNotas] == 16
                         || iList_CalcCusto_CFOP[ContaNotas] == 17
                         || iList_CalcCusto_CFOP[ContaNotas] == 18
                         || iList_CalcCusto_CFOP[ContaNotas] == 31
                         || iList_CalcCusto_CFOP[ContaNotas] == 32
                         || iList_CalcCusto_CFOP[ContaNotas] == 33
                         || iList_CalcCusto_CFOP[ContaNotas] == 35
                         || iList_CalcCusto_CFOP[ContaNotas] == 37)
                    {
                        CustoFinal = Math.Round(CustoAnterior, 4);
                        EstoqueFinal = EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas];
                        Faturamento = 0;
                    }
                    //Saída por acerto
                    else if (
                        iList_CalcCusto_CFOP[ContaNotas] == 21
                     || iList_CalcCusto_CFOP[ContaNotas] == 22
                     || iList_CalcCusto_CFOP[ContaNotas] == 23
                     || iList_CalcCusto_CFOP[ContaNotas] == 25
                     //|| iList_CalcCusto_CFOP[ContaNotas] == 26
                     || iList_CalcCusto_CFOP[ContaNotas] == 27
                     || iList_CalcCusto_CFOP[ContaNotas] == 29
                     || iList_CalcCusto_CFOP[ContaNotas] == 30
                     || iList_CalcCusto_CFOP[ContaNotas] == 34
                     || iList_CalcCusto_CFOP[ContaNotas] == 36
                     )
                    {
                        CustoFinal = Math.Round(CustoAnterior, 4);
                        EstoqueFinal = EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas];
                        Faturamento = 0;
                    }
                    else if (iList_CalcCusto_CFOP[ContaNotas] == 26 || iList_CalcCusto_CFOP[ContaNotas] == 15)
                    {
                        CustoFinal = Math.Round(CustoAnterior, 4);
                        EstoqueFinal = EstoqueAnterior;
                        Faturamento = 0;
                    }

                }

                //C.C das operações. Se não estiver tabelado, é puramente demonstrativo
                else 
                    {
                        CustoFinal = Math.Round(CustoAnterior, 4);
                        EstoqueFinal = EstoqueAnterior;
                        Faturamento = 0;

                    }


                    CustoFinalTotal = Math.Round(CustoFinal * iList_CalcCusto_Quantidade[ContaNotas], 4);

                    if (EstoqueFinal < 0)
                        EstoqueFinal = 0;

                    dgvCustoFinal.Rows.Add(iList_CalcCusto_ProtocoloNF[ContaNotas]   //0
                                          , iList_CalcCusto_CFOP[ContaNotas]         //1
                                          , dtList_CalcCusto_Transacao[ContaNotas]   //2
                                          , iList_CalcCusto_CodProduto[ContaNotas]   //3
                                          , sList_CalcCusto_DescProduto[ContaNotas]  //4
                                          , iList_CalcCusto_Quantidade[ContaNotas]   //5
                                          , dList_CalcCusto_PrcUnitario[ContaNotas]  //6
                                          , sList_CalcCusto_Tipo[ContaNotas]         //7
                                          , Math.Round(Faturamento, 4)                //8
                                          , Math.Round(CustoFinal, 4)                 //9
                                          , Math.Round(CustoFinalTotal, 4)            //10                                                                                                       
                                          , EstoqueFinal                             //11
                                          );

                    using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                    {

                        try
                        {
                            connectDMD.Open();
                            command = connectDMD.CreateCommand();
                            command.CommandText =
                                " INSERT INTO  UNIDB.[dbo].CUSTO_MEDIO "
                              + " (Protocolo_NF      "     //0
                              + " ,Cod_CFOP          "     //1
                              + " ,Dat_Transacao     "     //2
                              + " ,Cod_Produto       "     //3
                              + " ,Prc_Unitario      "     //4
                              + " ,Qtd_Movimento     "     //5
                              + " ,Tipo_Operacao     "     //6
                              + " ,Faturamento       "     //7
                              + " ,CustoProduto      "     //8
                              + " ,CustoTotal        "     //9
                              + " ,EstoqueFinal)     "     //10
                              + " VALUES             "
                              + " (@NF_Protocolo     "
                              + " ,@CFOP             "
                              + " ,@Dat_Transacao    "
                              + " ,@Cod_Produto      "
                              + " ,@Prc_Unitario     "
                              + " ,@Quantidade       "
                              + " ,@Tipo             "
                              + " ,@Faturamento      "
                              + " ,@Custo_Produto    "
                              + " ,@Custo_Final      "
                              + " ,@Quantidade_Final)";


                            //Adicionar parãmetro de NF - Protocolo
                            SqlParameter Param_NF_Protocolo = new SqlParameter("@NF_Protocolo", SqlDbType.Int);
                            Param_NF_Protocolo.Value = iList_CalcCusto_ProtocoloNF[ContaNotas];
                            command.Parameters.Add(Param_NF_Protocolo);

                            //Adicionar parâmetro CFOP
                            SqlParameter Param_CFOP = new SqlParameter("@CFOP", SqlDbType.Int);
                            Param_CFOP.Value = iList_CalcCusto_CFOP[ContaNotas];
                            command.Parameters.Add(Param_CFOP);

                            //Adicionar parâmetro Dat. Transacão
                            SqlParameter Param_Dat_Transacao = new SqlParameter("@Dat_Transacao", SqlDbType.DateTime);
                            Param_Dat_Transacao.Value = dtList_CalcCusto_Transacao[ContaNotas];
                            command.Parameters.Add(Param_Dat_Transacao);

                            //Adicionar parâmetro Cod_Produto
                            SqlParameter Param_Cod_Produto = new SqlParameter("@Cod_Produto", SqlDbType.Int);
                            Param_Cod_Produto.Value = iList_CalcCusto_CodProduto[ContaNotas];
                            command.Parameters.Add(Param_Cod_Produto);

                            //Adicionar parâmetro Prc_Unitario
                            SqlParameter Param_Prc_Unitario = new SqlParameter("@Prc_Unitario", SqlDbType.Real);
                            Param_Prc_Unitario.Value = Math.Round(dList_CalcCusto_PrcUnitario[ContaNotas], 4);
                            command.Parameters.Add(Param_Prc_Unitario);

                            //Adicionar parâmetro Quantidade
                            SqlParameter Param_Quantidade = new SqlParameter("@Quantidade", SqlDbType.Int);
                            Param_Quantidade.Value = iList_CalcCusto_Quantidade[ContaNotas];
                            command.Parameters.Add(Param_Quantidade);

                            //Adicionar parâmetro Tipo
                            SqlParameter Param_Tipo = new SqlParameter("@Tipo", SqlDbType.VarChar);
                            Param_Tipo.Value = sList_CalcCusto_Tipo[ContaNotas];
                            command.Parameters.Add(Param_Tipo);

                            //Adicionar parâmetro Faturamento
                            SqlParameter Param_Faturamento = new SqlParameter("@Faturamento", SqlDbType.Real);
                            Param_Faturamento.Value = Faturamento;
                            command.Parameters.Add(Param_Faturamento);

                            //Adicionar parâmetro Custo por Produto
                            SqlParameter Param_Custo_Por_Produto = new SqlParameter("@Custo_Produto", SqlDbType.Real);
                            Param_Custo_Por_Produto.Value = CustoFinal;
                            command.Parameters.Add(Param_Custo_Por_Produto);

                            //Adicionar parâmetro Custo Total
                            SqlParameter Param_Custo_Total = new SqlParameter("@Custo_Final", SqlDbType.Real);
                            Param_Custo_Total.Value = CustoFinalTotal;
                            command.Parameters.Add(Param_Custo_Total);

                            //Adicionar parâmetro Quantidade Final
                            SqlParameter Param_Quantidade_Final = new SqlParameter("@Quantidade_Final", SqlDbType.Int);
                            Param_Quantidade_Final.Value = EstoqueFinal;
                            command.Parameters.Add(Param_Quantidade_Final);



                            command.ExecuteNonQuery();



                        }

                        catch (SqlException SQLe)
                        {
                            erroSQLE(SQLe);
                        }
                        finally
                        {
                            connectDMD.Close();

                            if (pgbCustoMedio.InvokeRequired)
                            {
                                pgbCustoMedio.Invoke(new MethodInvoker(delegate { pgbCustoMedio.Value = pgbCustoMedio.Value + 1; }));
                            }
                            else
                            {
                                pgbCustoMedio.Value = pgbCustoMedio.Value + 1;
                            }


                        }

                    }



                }
            

             
            this.Invoke(new MethodInvoker (delegate{
                mMessage = "Cálculo de custo médio finalizado.";
                mTittle = "Calculadora do Custo";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Information;
                Cursor = Cursors.Default;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            }));

        }


        private void calcular_Custo()
        {
            this.Invoke((MethodInvoker)delegate { Cursor = Cursors.WaitCursor; });

            DateTime ultMovim = Convert.ToDateTime("01-01-2019");
            //Carregando última movimentação
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {

                try
                {
                    connectDMD.Open();
                    command = connectDMD.CreateCommand();
                    command.CommandText =
                        " SELECT dt = max(Dat_Transacao) from [UNIDB].dbo.[CUSTO_MEDIO] ";


                    reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        if (reader.HasRows)
                        {
                            ultMovim = Convert.ToDateTime(reader["dt"]);
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

            //Levanta notas fiscais de Entrada, Saída e movimentações por acerto.
            using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
            {
                try
                {
                    connectDMD.Open();

                    command = connectDMD.CreateCommand();
                    command.CommandText =
                        " SELECT																																												"
                    + "   NSCB.Num_Nota[Prot_NF]                                                            																									"
                    + "   ,[Transacao]                                                                      																									"
                    + "   =  CASE NSCB.Transacao                                                              																								"
                    + "   WHEN NULL THEN NSIT.Transacao                                                     																									"
                    + "   ELSE                                                                              																									"
                    + "                                                                                     																									"
                    + "       CASE WHEN NSCB.Transacao > NSIT.Transacao THEN NSIT.Transacao                 																									"
                    + "        ELSE NSCB.Transacao                                                          																									"
                    + "        END                                                                          																									"
                    + "  END                                                                                																									"
                    + "  ,NSIT.Cod_Produto[Cod_Produto]                                                     																									"
                    + "  ,NSIT.Cod_Cfo[CFOP]                                                                																									"
                    + "  ,PROD.Descricao                                                                    																									"
                    + "  ,[Prc_Unitario] = (NSIT.Vlr_LiqVenIte/NSIT.Qtd_Produto)                            																									"
                    + "  ,NSIT.Qtd_Produto[Quantidade]                                                      																									"
                    + "  ,[Estoque_Anterior] = isnull((SELECT TOP 1 PR.Qtd_SldAtu FROM PRSLD PR WHERE PR.Cod_Produt = PROD.Codigo AND PR.Dat_Movime <= NSCB.Dat_Emissao ORDER BY PR.Dat_Movime DESC),0)		"
                    + "  ,'Saida'[Tipo]      																																								"
                    + "  ,nscb.flg_movest                                                                   																									"
                    + " FROM                                                                                																									"
                    + "  DMD.dbo.NFSIT NSIT                                                                 																									"
                    + "  INNER JOIN DMD.dbo.NFSCB NSCB ON NSCB.Num_Nota = NSIT.Num_Nota                     																									"
                    + "  INNER JOIN DMD.dbo.PRODU PROD ON PROD.Codigo = NSIT.Cod_Produto                    																									"
                    + "WHERE                                                                               "
                    + " ( (NSIT.Transacao BETWEEN @DAT_INICIAL AND @DAT_FINAL)                             "
                    + " OR(NSCB.Transacao BETWEEN @DAT_INICIAL AND @DAT_FINAL AND NSIT.Transacao IS NULL)) "
                    + " AND NSCB.STATUS = 'F'                                                              "
                    + "UNION        ALL                                                                    "
                    + "                                                                                    "
                    + " SELECT                                                                              																									"
                    + "   NECB.Protocolo[Prot_NF]                                                           																									"
                    + "  ,NEIT.Transacao[Transacao]                                                         																									"
                    + "  ,NEIT.Cod_Produto[Cod_Produto]                                                     																									"
                    + "  ,NEIT.Cod_Cfo[CFOP]                                                                																									"
                    + "  ,PROD.Descricao                                                                    																									"
                    + "  ,[Prc_Unitario] =                                                                  																									"
                    + "  CASE((100 - NEIT.Per_DescItem) / 100)                                              																									"
                    + "  WHEN 0 THEN NEIT.Prc_Unitario                                                      																									"
                    + "  ELSE((100 - NEIT.Per_DescItem) / 100) * NEIT.Prc_Unitario                          																									"
                    + "  END                                                                                																									"
                    + "  ,NEIT.Qtd_Pedido[Quantidade]          																																				"
                    + "  ,[Estoque Anterior] = isnull((SELECT TOP 1 PR.Qtd_SldAtu FROM PRSLD PR WHERE PR.Cod_Produt = PROD.Codigo AND PR.Dat_Movime <= NECB.Dat_Emissao ORDER BY PR.Dat_Movime DESC),0)		"
                    + "  ,'Entrada'[Tipo]                                                                   																									"
                    + "  ,NECB.flg_movest                                                                   																									"
                    + " FROM                                                                                																									"
                    + "  DMD.dbo.NFEIT NEIT                                                                 																									"
                    + "  INNER JOIN DMD.dbo.NFECB NECB ON NECB.Protocolo = NEIT.Protocolo                   																									"
                    + "  INNER JOIN DMD.dbo.PRODU PROD ON PROD.Codigo = NEIT.Cod_Produto                    																									"
                    + " WHERE                                                                               																									"
                    + " NEIT.Transacao BETWEEN @DAT_INICIAL AND @DAT_FINAL                                 "
                    + " AND NECB.STATUS = 'F'                                                              "
                    + "UNION    ALL                                                                        "
                    + "                                                                                    "
                    + " SELECT                                                                              																									"
                    + "   ACER.Numero[Prot_NF]                                                              																									"
                    + "  ,ACER.Transacao[Transacao]                                                         																									"
                    + "  ,ACER.Cod_Produto[Cod_Produto]                                                     																									"
                    + "  ,ACER.Cod_TipMov[CFOP]                                                             																									"
                    + "  ,PROD.Descricao                                                                    																									"
                    + "  ,0[Prc_Unitario]                                                                   																									"
                    + "  ,ACER.Qtd_Acerto[Quantidade]                                                       																									"
                    + "  ,[Estoque Anterior] = isnull((SELECT TOP 1 PR.Qtd_SldAtu FROM PRSLD PR WHERE PR.Cod_Produt = PROD.Codigo AND PR.Dat_Movime <= ACER.Transacao ORDER BY PR.Dat_Movime DESC),0)		"
                    + "  ,'Acerto'[Tipo]                                                                    																									"
                    + "  ,flg_movest = 1                                                                    																									"
                    + " FROM                                                                                																									"
                    + "  DMD.dbo.ACERT ACER                                                                 																									"
                    + "  INNER JOIN PRODU PROD ON PROD.CODIGO = ACER.Cod_Produto                            																									"                    
                    + "WHERE ACER.Transacao BETWEEN @DAT_INICIAL AND @DAT_FINAL                            "
                    + "ORDER BY Transacao asc                                                              ";

                    command.Parameters.AddWithValue("Dat_Inicial", ultMovim);
                    command.Parameters.AddWithValue("Dat_Final", Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                    //command.Parameters.AddWithValue("Dat_Final", Convert.ToDateTime(DateTime.Now.AddDays(-700).ToShortDateString()));
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["Prot_NF"] != null)
                        {
                            iList_CalcCusto_ProtocoloNF.Add(Convert.ToInt32(reader["Prot_NF"].ToString()));
                            dtList_CalcCusto_Transacao.Add(Convert.ToDateTime(reader["Transacao"].ToString()));
                            iList_CalcCusto_CodProduto.Add(Convert.ToInt32(reader["Cod_Produto"].ToString()));
                            sList_CalcCusto_DescProduto.Add(reader["Descricao"].ToString());
                            iList_CalcCusto_CFOP.Add(Convert.ToInt32(reader["CFOP"].ToString()));
                            dList_CalcCusto_PrcUnitario.Add(Math.Round(Convert.ToDouble(reader["Prc_Unitario"].ToString()), 4));
                            iList_CalcCusto_Quantidade.Add(Convert.ToInt32(reader["Quantidade"].ToString()));
                            sList_CalcCusto_Tipo.Add(reader["Tipo"].ToString());
                            iList_CalcCusto_MovEst.Add(Convert.ToInt32(reader["Flg_MovEst"].ToString()));
                            iList_CalcCusto_EstAnterior.Add(Convert.ToInt32(reader["Estoque_Anterior"].ToString()));
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


            //Variáveis de cálculo

            double CustoAnterior = 0;
            int EstoqueAnterior = 0;

            pgbCustoMedio.Invoke(new MethodInvoker(delegate { pgbCustoMedio.Maximum = iList_CalcCusto_ProtocoloNF.Count; }));
            //Insere os produtos no Banco
            for (ContaNotas = 0; ContaNotas < iList_CalcCusto_ProtocoloNF.Count; ContaNotas++)
            {

                int ExisteProdutoNaTabela = 0;

                //Resgatando custo inicial
                //O item já existe na tabela?
                foreach (DataGridViewRow row in dgvCustoFinal.Rows)
                {
                    if (row.Cells[3].Value.Equals(iList_CalcCusto_CodProduto[ContaNotas]))
                    {
                        ExisteProdutoNaTabela = 1;
                        break;
                    }
                }

                ////Se existir, procure o valor do custo                 
                if (ExisteProdutoNaTabela == 1)
                {
                    int ProcurarProdutoTabela = 0;

                    for (ProcurarProdutoTabela = ContaNotas - 1; ProcurarProdutoTabela > 0; ProcurarProdutoTabela--)
                    {
                        if (Convert.ToInt32(dgvCustoFinal.Rows[ProcurarProdutoTabela].Cells[3].Value) == iList_CalcCusto_CodProduto[ContaNotas])
                        {
                            CustoAnterior = Math.Round(Convert.ToDouble(dgvCustoFinal.Rows[ProcurarProdutoTabela].Cells[9].Value.ToString()), 4);
                            EstoqueAnterior = Convert.ToInt32(dgvCustoFinal.Rows[ProcurarProdutoTabela].Cells[11].Value);
                            //EstoqueAnterior = iList_CalcCusto_EstAnterior[ProcurarProdutoTabela];
                            break;
                        }
                    }
                }
                ////Se não existir
                ////O item existe na estrutura de custo inicial?
                else if (iList_CustoInicial_CodProduto.Contains(iList_CalcCusto_CodProduto[ContaNotas]))
                {
                    for (int ProcurarProdutoLista = 0; ProcurarProdutoLista < iList_CustoInicial_CodProduto.Count; ProcurarProdutoLista++)
                    {
                        if (Convert.ToInt32(iList_CustoInicial_CodProduto[ProcurarProdutoLista]) == iList_CalcCusto_CodProduto[ContaNotas])
                        {
                            CustoAnterior = Math.Round(Convert.ToDouble(dList_CustoInicial_VlrProduto[ProcurarProdutoLista]), 4);
                            EstoqueAnterior = Convert.ToInt32(iList_CustoInicial_Estoque[ProcurarProdutoLista]);
                            //EstoqueAnterior = iList_CalcCusto_EstAnterior[ProcurarProdutoLista];
                            break;
                        }
                    }
                }
                else
                {
                    CustoAnterior = 0;
                    EstoqueAnterior = 0;
                }


                ////Calcular Custo
                double CustoFinal = 0.0;
                int EstoqueFinal = 0;
                double Faturamento = 0.0;
                double CustoFinalTotal = 0.0;

                if (iList_CalcCusto_MovEst[ContaNotas] == 0)
                {
                    CustoFinal = Math.Round(CustoAnterior, 4);
                    EstoqueFinal = EstoqueAnterior;
                    Faturamento = 0;
                }
                else if (sList_CalcCusto_Tipo[ContaNotas].Equals("Entrada"))
                {
                    //Entrada por compra normal
                    if (iList_CalcCusto_CFOP[ContaNotas] == 1101
                        || iList_CalcCusto_CFOP[ContaNotas] == 1102
                        || iList_CalcCusto_CFOP[ContaNotas] == 1117
                        || iList_CalcCusto_CFOP[ContaNotas] == 1401
                        || iList_CalcCusto_CFOP[ContaNotas] == 1403
                        || iList_CalcCusto_CFOP[ContaNotas] == 2101
                        || iList_CalcCusto_CFOP[ContaNotas] == 2102
                        || iList_CalcCusto_CFOP[ContaNotas] == 2117
                        || iList_CalcCusto_CFOP[ContaNotas] == 2403
                       )
                    {

                        CustoFinal = Math.Round(((EstoqueAnterior * CustoAnterior) + (iList_CalcCusto_Quantidade[ContaNotas] * dList_CalcCusto_PrcUnitario[ContaNotas])) /
                                       (EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas]), 4);

                        EstoqueFinal = EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas];
                        Faturamento = 0;
                    }

                    //Entrada por bonificação
                    else if (iList_CalcCusto_CFOP[ContaNotas] == 1910
                          || iList_CalcCusto_CFOP[ContaNotas] == 2910
                        )
                    {
                        CustoFinal = Math.Round((EstoqueAnterior * CustoAnterior) / (EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas]), 4);
                        EstoqueFinal = EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas];
                        Faturamento = 0;
                    }
                    //Entrada por devolução
                    else if (iList_CalcCusto_CFOP[ContaNotas] == 1201
                             || iList_CalcCusto_CFOP[ContaNotas] == 1202
                             || iList_CalcCusto_CFOP[ContaNotas] == 1411
                             || iList_CalcCusto_CFOP[ContaNotas] == 2201
                             || iList_CalcCusto_CFOP[ContaNotas] == 2202
                             || iList_CalcCusto_CFOP[ContaNotas] == 2411
                             || iList_CalcCusto_CFOP[ContaNotas] == 1919
                             || iList_CalcCusto_CFOP[ContaNotas] == 2919
                            )
                    {
                        CustoFinal = Math.Round(CustoAnterior, 4);
                        EstoqueFinal = EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas];
                        Faturamento = 0;
                    }
                    //Caso contrário
                    else
                    {
                        CustoFinal = Math.Round(CustoAnterior, 4);
                        EstoqueFinal = EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas];
                        Faturamento = 0;
                    }

                }
                else if (sList_CalcCusto_Tipo[ContaNotas].Equals("Saida"))
                {
                    //Saída por Venda
                    if (iList_CalcCusto_CFOP[ContaNotas] == 5102
                    || iList_CalcCusto_CFOP[ContaNotas] == 5114
                    || iList_CalcCusto_CFOP[ContaNotas] == 5117
                    || iList_CalcCusto_CFOP[ContaNotas] == 5120
                    || iList_CalcCusto_CFOP[ContaNotas] == 5403
                    || iList_CalcCusto_CFOP[ContaNotas] == 5405
                    || iList_CalcCusto_CFOP[ContaNotas] == 5551
                    || iList_CalcCusto_CFOP[ContaNotas] == 5929
                    || iList_CalcCusto_CFOP[ContaNotas] == 6102
                    || iList_CalcCusto_CFOP[ContaNotas] == 6106
                    || iList_CalcCusto_CFOP[ContaNotas] == 6108
                    || iList_CalcCusto_CFOP[ContaNotas] == 6114
                    || iList_CalcCusto_CFOP[ContaNotas] == 6117
                    || iList_CalcCusto_CFOP[ContaNotas] == 6119
                    || iList_CalcCusto_CFOP[ContaNotas] == 6120
                    || iList_CalcCusto_CFOP[ContaNotas] == 6403
                    || iList_CalcCusto_CFOP[ContaNotas] == 6404
                    || iList_CalcCusto_CFOP[ContaNotas] == 6551)
                    {
                        CustoFinal = Math.Round(CustoAnterior, 4);
                        EstoqueFinal = EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas];
                        Faturamento = Math.Round(iList_CalcCusto_Quantidade[ContaNotas] * dList_CalcCusto_PrcUnitario[ContaNotas], 4);
                    }
                    //Saída por Devolução
                    else if (iList_CalcCusto_CFOP[ContaNotas] == 5202
                             || iList_CalcCusto_CFOP[ContaNotas] == 5411
                             || iList_CalcCusto_CFOP[ContaNotas] == 6202
                             || iList_CalcCusto_CFOP[ContaNotas] == 6411
                             )
                    {





                        if (EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas] != 0)
                        {
                            CustoFinal = Math.Round(((EstoqueAnterior * CustoAnterior) + (iList_CalcCusto_Quantidade[ContaNotas] * -dList_CalcCusto_PrcUnitario[ContaNotas])) /
                                     (EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas]), 4);


                            EstoqueFinal = EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas];
                            Faturamento = 0;
                        }


                        else
                        {
                            CustoFinal = 0;
                            EstoqueFinal = EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas];
                            Faturamento = 0;
                        }
                    }
                    else
                    {
                        CustoFinal = Math.Round(CustoAnterior, 4);
                        EstoqueFinal = EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas];
                        Faturamento = Math.Round(iList_CalcCusto_Quantidade[ContaNotas] * dList_CalcCusto_PrcUnitario[ContaNotas], 4);
                    }
                }
                else if (sList_CalcCusto_Tipo[ContaNotas].Equals("Acerto"))
                {
                    //Entrada por acerto
                    //11
                    //12
                    //13
                    //15
                    //16
                    //17
                    //18
                    //31
                    //32
                    //33
                    //35
                    //37



                    if (iList_CalcCusto_CFOP[ContaNotas] == 11
                         || iList_CalcCusto_CFOP[ContaNotas] == 12
                         || iList_CalcCusto_CFOP[ContaNotas] == 13
                         || iList_CalcCusto_CFOP[ContaNotas] == 14
                         //|| iList_CalcCusto_CFOP[ContaNotas] == 15
                         || iList_CalcCusto_CFOP[ContaNotas] == 16
                         || iList_CalcCusto_CFOP[ContaNotas] == 17
                         || iList_CalcCusto_CFOP[ContaNotas] == 18
                         || iList_CalcCusto_CFOP[ContaNotas] == 31
                         || iList_CalcCusto_CFOP[ContaNotas] == 32
                         || iList_CalcCusto_CFOP[ContaNotas] == 33
                         || iList_CalcCusto_CFOP[ContaNotas] == 35
                         || iList_CalcCusto_CFOP[ContaNotas] == 37)
                    {
                        CustoFinal = Math.Round(CustoAnterior, 4);
                        EstoqueFinal = EstoqueAnterior + iList_CalcCusto_Quantidade[ContaNotas];
                        Faturamento = 0;
                    }
                    //Saída por acerto
                    else if (
                        iList_CalcCusto_CFOP[ContaNotas] == 21
                     || iList_CalcCusto_CFOP[ContaNotas] == 22
                     || iList_CalcCusto_CFOP[ContaNotas] == 23
                     || iList_CalcCusto_CFOP[ContaNotas] == 25
                     //|| iList_CalcCusto_CFOP[ContaNotas] == 26
                     || iList_CalcCusto_CFOP[ContaNotas] == 27
                     || iList_CalcCusto_CFOP[ContaNotas] == 29
                     || iList_CalcCusto_CFOP[ContaNotas] == 30
                     || iList_CalcCusto_CFOP[ContaNotas] == 34
                     || iList_CalcCusto_CFOP[ContaNotas] == 36
                     )
                    {
                        CustoFinal = Math.Round(CustoAnterior, 4);
                        EstoqueFinal = EstoqueAnterior - iList_CalcCusto_Quantidade[ContaNotas];
                        Faturamento = 0;
                    }
                    else if (iList_CalcCusto_CFOP[ContaNotas] == 26 || iList_CalcCusto_CFOP[ContaNotas] == 15)
                    {
                        CustoFinal = Math.Round(CustoAnterior, 4);
                        EstoqueFinal = EstoqueAnterior;
                        Faturamento = 0;
                    }

                }

                //C.C das operações. Se não estiver tabelado, é puramente demonstrativo
                else
                {
                    CustoFinal = Math.Round(CustoAnterior, 4);
                    EstoqueFinal = EstoqueAnterior;
                    Faturamento = 0;

                }


                CustoFinalTotal = Math.Round(CustoFinal * iList_CalcCusto_Quantidade[ContaNotas], 4);

                if (EstoqueFinal < 0)
                    EstoqueFinal = 0;

                dgvCustoFinal.Rows.Add(iList_CalcCusto_ProtocoloNF[ContaNotas]   //0
                                      , iList_CalcCusto_CFOP[ContaNotas]         //1
                                      , dtList_CalcCusto_Transacao[ContaNotas]   //2
                                      , iList_CalcCusto_CodProduto[ContaNotas]   //3
                                      , sList_CalcCusto_DescProduto[ContaNotas]  //4
                                      , iList_CalcCusto_Quantidade[ContaNotas]   //5
                                      , dList_CalcCusto_PrcUnitario[ContaNotas]  //6
                                      , sList_CalcCusto_Tipo[ContaNotas]         //7
                                      , Math.Round(Faturamento, 4)                //8
                                      , Math.Round(CustoFinal, 4)                 //9
                                      , Math.Round(CustoFinalTotal, 4)            //10                                                                                                       
                                      , EstoqueFinal                             //11
                                      );

                using (SqlConnection connectDMD = ConnectionDB.getInstancia().getConnection(Usuario.unidade_Login))
                {

                    try
                    {
                        connectDMD.Open();
                        command = connectDMD.CreateCommand();
                        command.CommandText =
                            " INSERT INTO  UNIDB.[dbo].CUSTO_MEDIO "
                          + " (Protocolo_NF      "     //0
                          + " ,Cod_CFOP          "     //1
                          + " ,Dat_Transacao     "     //2
                          + " ,Cod_Produto       "     //3
                          + " ,Prc_Unitario      "     //4
                          + " ,Qtd_Movimento     "     //5
                          + " ,Tipo_Operacao     "     //6
                          + " ,Faturamento       "     //7
                          + " ,CustoProduto      "     //8
                          + " ,CustoTotal        "     //9
                          + " ,EstoqueFinal)     "     //10
                          + " VALUES             "
                          + " (@NF_Protocolo     "
                          + " ,@CFOP             "
                          + " ,@Dat_Transacao    "
                          + " ,@Cod_Produto      "
                          + " ,@Prc_Unitario     "
                          + " ,@Quantidade       "
                          + " ,@Tipo             "
                          + " ,@Faturamento      "
                          + " ,@Custo_Produto    "
                          + " ,@Custo_Final      "
                          + " ,@Quantidade_Final)";


                        //Adicionar parãmetro de NF - Protocolo
                        SqlParameter Param_NF_Protocolo = new SqlParameter("@NF_Protocolo", SqlDbType.Int);
                        Param_NF_Protocolo.Value = iList_CalcCusto_ProtocoloNF[ContaNotas];
                        command.Parameters.Add(Param_NF_Protocolo);

                        //Adicionar parâmetro CFOP
                        SqlParameter Param_CFOP = new SqlParameter("@CFOP", SqlDbType.Int);
                        Param_CFOP.Value = iList_CalcCusto_CFOP[ContaNotas];
                        command.Parameters.Add(Param_CFOP);

                        //Adicionar parâmetro Dat. Transacão
                        SqlParameter Param_Dat_Transacao = new SqlParameter("@Dat_Transacao", SqlDbType.DateTime);
                        Param_Dat_Transacao.Value = dtList_CalcCusto_Transacao[ContaNotas];
                        command.Parameters.Add(Param_Dat_Transacao);

                        //Adicionar parâmetro Cod_Produto
                        SqlParameter Param_Cod_Produto = new SqlParameter("@Cod_Produto", SqlDbType.Int);
                        Param_Cod_Produto.Value = iList_CalcCusto_CodProduto[ContaNotas];
                        command.Parameters.Add(Param_Cod_Produto);

                        //Adicionar parâmetro Prc_Unitario
                        SqlParameter Param_Prc_Unitario = new SqlParameter("@Prc_Unitario", SqlDbType.Real);
                        Param_Prc_Unitario.Value = Math.Round(dList_CalcCusto_PrcUnitario[ContaNotas], 4);
                        command.Parameters.Add(Param_Prc_Unitario);

                        //Adicionar parâmetro Quantidade
                        SqlParameter Param_Quantidade = new SqlParameter("@Quantidade", SqlDbType.Int);
                        Param_Quantidade.Value = iList_CalcCusto_Quantidade[ContaNotas];
                        command.Parameters.Add(Param_Quantidade);

                        //Adicionar parâmetro Tipo
                        SqlParameter Param_Tipo = new SqlParameter("@Tipo", SqlDbType.VarChar);
                        Param_Tipo.Value = sList_CalcCusto_Tipo[ContaNotas];
                        command.Parameters.Add(Param_Tipo);

                        //Adicionar parâmetro Faturamento
                        SqlParameter Param_Faturamento = new SqlParameter("@Faturamento", SqlDbType.Real);
                        Param_Faturamento.Value = Faturamento;
                        command.Parameters.Add(Param_Faturamento);

                        //Adicionar parâmetro Custo por Produto
                        SqlParameter Param_Custo_Por_Produto = new SqlParameter("@Custo_Produto", SqlDbType.Real);
                        Param_Custo_Por_Produto.Value = CustoFinal;
                        command.Parameters.Add(Param_Custo_Por_Produto);

                        //Adicionar parâmetro Custo Total
                        SqlParameter Param_Custo_Total = new SqlParameter("@Custo_Final", SqlDbType.Real);
                        Param_Custo_Total.Value = CustoFinalTotal;
                        command.Parameters.Add(Param_Custo_Total);

                        //Adicionar parâmetro Quantidade Final
                        SqlParameter Param_Quantidade_Final = new SqlParameter("@Quantidade_Final", SqlDbType.Int);
                        Param_Quantidade_Final.Value = EstoqueFinal;
                        command.Parameters.Add(Param_Quantidade_Final);



                        command.ExecuteNonQuery();



                    }

                    catch (SqlException SQLe)
                    {
                        erroSQLE(SQLe);
                    }
                    finally
                    {
                        connectDMD.Close();

                        if (pgbCustoMedio.InvokeRequired)
                        {
                            pgbCustoMedio.Invoke(new MethodInvoker(delegate { pgbCustoMedio.Value = pgbCustoMedio.Value + 1; }));
                        }
                        else
                        {
                            pgbCustoMedio.Value = pgbCustoMedio.Value + 1;
                        }


                    }

                }



            }



            this.Invoke(new MethodInvoker(delegate {
                mMessage = "Cálculo de custo médio finalizado.";
                mTittle = "Calculadora do Custo";
                mButton = MessageBoxButtons.OK;
                mIcon = MessageBoxIcon.Information;
                Cursor = Cursors.Default;
                MessageBox.Show(mMessage, mTittle, mButton, mIcon);
            }));

        }
        //Configurações de inicialização
        private void configuracoes_Iniciais()
        {
            this.Icon = Properties.Resources.Icon_Uni;
            txtInfo.Text =
                "O custo médio é obtido a partir de um cálculo feito pelo UHC a com toda a base de dados do Allypharma.";
            txtInfo.ReadOnly = true;

            configurar_DataGridView(dgvCustoFinal);
            

        }

        //Load do form
        private void frmCalc_Custo_Med_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            configuracoes_Iniciais();
            Task.Factory.StartNew(() => carregar_Informacoes_Custo_Inicial());
        }

       
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Task.WaitAny();    
            Task.Factory.StartNew(() => calcular_Custo());
        }

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            Task.WaitAny();
            Task.Factory.StartNew(() => recalcular_Custo());
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

    }
}
