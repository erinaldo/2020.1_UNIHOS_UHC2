using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Gerencial.Relatorios_Gerenciais
{
    public partial class frmGraficoMargemBruta : Form
    {
        public frmGraficoMargemBruta()
        {
            InitializeComponent();
        }

        //Montagem do gráfico anual
        public double vendaJan, vendaFev, vendaMar, vendaAbr, vendaMai, vendaJun, vendaJul, vendaAgo, vendaSet, vendaOut, vendaNov, vendaDez;
        public double compraJan, compraFev, compraMar, compraAbr, compraMai, compraJun, compraJul, compraAgo, compraSet, compraOut, compraNov, compraDez;
        public double margemJan, margemFev, margemMar, margemAbr, margemMai, margemJun, margemJul, margemAgo, margemSet, margemOut, margemNov, margemDez;


        private void frmGraficoMargemBruta_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            preencher_Grafico();
        }


        private void preencher_Grafico()
        {
            gMes.Series.Add(new LineSeries
            {
                Title = "Compras: ",
                Values = new ChartValues<double> { Math.Round(compraJan, 2), Math.Round(compraFev, 2), Math.Round(compraMar / 100, 2), Math.Round(compraMai/ 100, 2), Math.Round(compraAbr, 2), Math.Round(compraJun, 2), Math.Round(compraJul, 2), Math.Round(compraAgo, 2), Math.Round(compraSet, 2), Math.Round(compraOut, 2), Math.Round(compraNov, 2), Math.Round(compraDez, 2) },                              
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 10,
                

            }
              );
            gMes.Series.Add(new LineSeries
            {
                Title = "Vendas: ",
                Values = new ChartValues<double> { Math.Round(vendaJan, 2), Math.Round(vendaFev, 2), Math.Round(vendaMar / 100, 2), Math.Round(vendaMai / 100, 2), Math.Round(vendaAbr, 2), Math.Round(vendaJun, 2), Math.Round(vendaJul, 2), Math.Round(vendaAgo, 2), Math.Round(vendaSet, 2), Math.Round(vendaOut, 2), Math.Round(vendaNov, 2), Math.Round(vendaDez, 2) },
                PointGeometry = DefaultGeometries.Circle,
                PointGeometrySize = 10,
                                
            }                          
              );
            gMes.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Labels = new[] { "Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Sep", "Out", "Nov", "Dez" }
            }
                );
            gMes.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Total",
                LabelFormatter = value => value.ToString("C")
            }
            );

        }

    }
}
