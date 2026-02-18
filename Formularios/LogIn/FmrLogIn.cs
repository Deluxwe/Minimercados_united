using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minimercados_Unidos.Formularios.LogIn;

namespace Minimercados_Unidos
{
    public partial class FmrLogIn: Form
    {
        private Form activeForm = null;

        public FmrLogIn()
        {
            InitializeComponent();
        }

        private void BttAdminLogin_Click(object sender, EventArgs e)
        {
            Form frmautenAd = new FmrLogInAdmin();
            frmautenAd.Show();

            this.Hide();

        }

        private void BttClienteLogin_Click(object sender, EventArgs e)
        {
            Form frmautenCli = new FmrLogInCliente();
            frmautenCli.Show();

            this.Hide();
        }

        private void bttRepartidor_Click(object sender, EventArgs e)
        {
            Form frmReparti = new FmrLogInDomiciliario();
            frmReparti.Show();

            this.Hide();

        }
    }
}
