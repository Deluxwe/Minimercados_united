using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minimercados_Unidos.Formularios.Admin;

namespace Minimercados_Unidos
{
    public partial class fmrAdmin: Form
    {
        private Form activeForm = null;

        public fmrAdmin()
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
        private void BttRegresar_Click(object sender, EventArgs e)
        {
            Form frmlog = new FmrLogIn();
            frmlog.Show();

            this.Close();
        }

        private void BttInventario_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new FmrInventario());

        }

        private void BttRepartidor_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new fmrDetalleRepartidor());
        }

        private void BttPedidos_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new FmrPedidosAdmin());

        }

        private void BttDetallePedido_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new FmrDetallePedido());
        }

        private void BttMinimercado_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new FmrMiniMercado());
        }

        private void Add_admin_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new FmrAgregarAdmin());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new FmrAgregarRepartidor());
        }
    }
}
