using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uni_Hospitalar_Controle_PE.UHC.Menu_Principal.Financeiro.GNRE.Exportar_GNRE
{
    public partial class frmGerarManual : Form
    {
        public frmGerarManual()
        {
            InitializeComponent();
        }

        //Variáveis de TextBox
        private string mMessage, mTittle;
        private MessageBoxButtons mButton;
#pragma warning disable CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        private new MessageBoxIcon mIcon = MessageBoxIcon.Asterisk;
#pragma warning restore CS0109 // O membro não oculta um membro herdado; não é necessária uma nova palavra-chave
        

        private void FrmGerarManual_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.Icon_Uni;
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtObs.Text.Trim().Length > 0)
            {
                this.Close();
            }
            else
            {
                mMessage = "A observação precisa ser válida.";
                mTittle = "Observação sobre bloqueio";
                mButton = MessageBoxButtons.YesNo;
                mIcon = MessageBoxIcon.Error;
                System.Windows.Forms.MessageBox.Show(mMessage, mTittle, mButton, mIcon);
                return;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            txtObs.Text = String.Empty;
            this.Close();
        }
    }
}
