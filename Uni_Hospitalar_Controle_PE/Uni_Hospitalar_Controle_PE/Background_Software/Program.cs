using System;
using System.Windows.Forms;
using Uni_Hospitalar_Controle_PE.UHC.Login;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.Recebimento.Contas_a_receber;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Gerencial.Relatorios_Gerenciais;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Vendas.Analise_Venda;

namespace Uni_Hospitalar_Controle_PE
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>    [STAThread]
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
