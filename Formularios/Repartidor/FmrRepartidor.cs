using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minimercados_Unidos
{
    public partial class FmrRepartidor: Form
    {
        private Form activeForm = null;

        public FmrRepartidor()
        {
            InitializeComponent();
        }

        private void AbrirenPanel(Form frmHijo)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = frmHijo;
            frmHijo.TopLevel = false;
            frmHijo.FormBorderStyle = FormBorderStyle.None;
            frmHijo.Dock = DockStyle.Fill;
            pnlCentral.Controls.Add(frmHijo);
            pnlCentral.Tag = frmHijo;
            frmHijo.BringToFront();
            frmHijo.Show();

        }

        private void bttRegresar_Click(object sender, EventArgs e)
        {
            Form frmlog = new FmrLogIn();
            frmlog.Show();

            this.Hide();
        }

        private void bttPedidos_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new fmrDetalleRepartidor());
        }
    }
}
