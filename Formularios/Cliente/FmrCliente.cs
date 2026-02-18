using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minimercados_Unidos.Formularios.Cliente;

namespace Minimercados_Unidos
{
    public partial class FmrCliente: Form
    {
        private Form activeForm = null;

        public FmrCliente()
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

            this.Close();
        }

        private void bttPedidosCliente_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new FmrPedidos());

        }

        private void BttMinimercado_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new FmrMiniMercado());
        }

        private void bttCarrito_Click(object sender, EventArgs e)
        {
        }

        private void Bttpagar_Click(object sender, EventArgs e)
        {
            AbrirenPanel(new FmrPagar());
        }
    }
}
