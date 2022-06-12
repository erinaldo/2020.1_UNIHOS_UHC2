using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Gerencial.Relatorios_Gerenciais;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Gerencial
{
    public partial class frmGerencial : Form
    {
        public frmGerencial()
        {
            InitializeComponent();
        }

        public int Unidade_Servidor;
        
        




        //Load do form
        private void frmGerencial_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
            this.BackgroundImage = Properties.Resources.bgd_Televendas;

        }





        //Fechar
        private void btnFechar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void frmGerencial_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyValue.Equals(27))
            {
                this.Close();
            }

        }




        //btnRelMargemBruta
        private void lblRelMargemBruta_Click(object sender, EventArgs e)
        {
            frmMargemBruta form = new frmMargemBruta();
            //form.Unidade_Servidor = Unidade_Servidor;
            form.Show();
        }

        private void lblRelMargemBruta_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
            lblRelMargemBruta.ForeColor = Color.White;
            lblRelMargemBruta.BackColor = Color.Black;
        }

        private void lblRelMargemBruta_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            lblRelMargemBruta.ForeColor = Color.Black;
            lblRelMargemBruta.BackColor = Color.Transparent;
        }

    }
}
