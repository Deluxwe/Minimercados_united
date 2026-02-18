using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Minimercados_Unidos.Claases;

//using Word = Microsoft.Office.Interop.Word;

namespace Minimercados_Unidos.Formularios
{



    public partial class frmOrdenCompra : Form
    {
        cConexiones cn;
        int nroOrden;
        public frmOrdenCompra()
        {
            InitializeComponent();
            cn = new cConexiones();


        }

        private void frmOrdenCompra_Load(object sender, EventArgs e)
        {
            numeral();
            llenarProducto();

        }

        void numeral()
        {
            SqlCommand cmd = new SqlCommand("select max(idOrden) from tblOrden", cn.AbrirConexion());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                nroOrden = int.Parse(dt.Rows[0][0].ToString()) + 1;
                lblNroOrden.Text = nroOrden.ToString();
            }

        }


        void llenarProducto()
        {
            int n = 0;
            SqlCommand cmd = new SqlCommand("select * from tblArticulo", cn.AbrirConexion());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                n = dt.Rows.Count;
                dgvArticulos.Rows.Add(n - 1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvArticulos.Rows[i].Cells[1].Value = dt.Rows[i][0].ToString();
                    dgvArticulos.Rows[i].Cells[2].Value = dt.Rows[i][1].ToString();
                    dgvArticulos.Rows[i].Cells[3].Value = dt.Rows[i][2].ToString();
                }
            }
        }








        private void btnAceptar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvArticulos.Rows)
            {
                bool seleccionado = Convert.ToBoolean(row.Cells["Elegir"].Value);
                if (seleccionado)
                {
                    int n = dgvSeleccionado.Rows.Add();
                    dgvSeleccionado.Rows[n].Cells[0].Value = row.Cells[1].Value.ToString();
                    dgvSeleccionado.Rows[n].Cells[1].Value = row.Cells[2].Value.ToString();
                    dgvSeleccionado.Rows[n].Cells[2].Value = row.Cells[3].Value.ToString();
                }
            }
        }


        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //object ObjMiss = System.Reflection.Missing.Value;
            //Word.Application ObjWord = new Word.Application();
            //Word.Document ObjDoc = ObjWord.Documents.Add(ref ObjMiss);
            //ObjDoc.Activate();
            //ObjWord.Selection.Font.Color = Word.WdColor.wdColorBlueGray;
            //ObjWord.Selection.Font.Size = 18;
            //ObjWord.Selection.TypeParagraph();//salto de linea
            //ObjWord.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            //ObjWord.Selection.TypeText("Orden de Compra ");
            //ObjWord.Selection.TypeText("Nro. " + lblNroOrden.Text);
            //ObjWord.Selection.TypeParagraph();
            //ObjWord.Selection.TypeParagraph();
            //ObjWord.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            //ObjWord.Selection.Font.Color = Word.WdColor.wdColorBlack;
            //ObjWord.Selection.TypeText("Nit:    " + txtNit.Text);
            //ObjWord.Selection.TypeParagraph();
            //ObjWord.Selection.TypeText("Compañía:  " + txtNombreCompañia.Text);
            //ObjWord.Selection.TypeParagraph();
            //ObjWord.Selection.TypeParagraph();
            //ObjWord.Selection.TypeParagraph();
            //ObjWord.Selection.Font.Size = 14;
            //ObjWord.Selection.TypeText("Código    " + "Descripción              " + "Valor Unitario          " + "Cantidad      " + "Total");
            //ObjWord.Selection.TypeParagraph();
            //ObjWord.Selection.TypeText("_______________________________________________________________");
            //for (int i = 0; i < dgvSeleccionado.Rows.Count - 1; i++)
            //{
            //    ObjWord.Selection.TypeParagraph();
            //    ObjWord.Selection.TypeText(dgvSeleccionado.Rows[i].Cells[0].Value + "\t" + "\t" + dgvSeleccionado.Rows[i].Cells[1].Value + "\t" + "\t" + dgvSeleccionado.Rows[i].Cells[2].Value + "\t" + "\t" + "\t" + dgvSeleccionado.Rows[i].Cells[3].Value + "\t" + "\t" + dgvSeleccionado.Rows[i].Cells[4].Value);
            //}

            //ObjWord.Visible = true;
        }
        private void txtNit_Leave(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select nombrecompania from tblCliente where nit='" + txtNit.Text + "'", cn.AbrirConexion());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Sonso, el proveedor no existe");
                txtNit.Clear();
                txtNit.Focus();
            }
            else
            {
                txtNombreCompañia.Text = dt.Rows[0][0].ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNit.Text.Equals(""))
            {
                MessageBox.Show("Ingrese Nit");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("insert into tblOrden values('" + dtpFecha.Text + "','" + txtNit.Text + "','" + txtTotal.Text + "')", cn.AbrirConexion());
                cmd.ExecuteNonQuery();
                for (int i = 0; i < dgvSeleccionado.Rows.Count - 1; i++)
                {
                    SqlCommand cmd1 = new SqlCommand("insert into tblDetalleOrden values('" + nroOrden + "','" + dgvSeleccionado.Rows[i].Cells[0].Value.ToString() + "', '" + dgvSeleccionado.Rows[i].Cells[3].Value.ToString() + "')", cn.AbrirConexion());
                    cmd1.ExecuteNonQuery();
                }
                MessageBox.Show("Orden Ingresada");
            }
        }


        private void dgvSeleccionado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSeleccionado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int cantidad = 0, precio_unit = 0, precio_total, total = 0;
            if (dgvSeleccionado.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                try
                {
                    cantidad = int.Parse(dgvSeleccionado.Rows[e.RowIndex].Cells[3].Value.ToString());
                    precio_unit = int.Parse(dgvSeleccionado.Rows[e.RowIndex].Cells[2].Value.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe ingresar una cantidad");
                }
                if (cantidad != 0)
                {
                    precio_total = cantidad * precio_unit;
                    dgvSeleccionado.Rows[e.RowIndex].Cells[4].Value = precio_total;
                    foreach (DataGridViewRow row in dgvSeleccionado.Rows)
                    {
                        total += Convert.ToInt32(row.Cells["Total"].Value);
                    }
                    txtTotal.Text = total.ToString();
                }
                else
                {
                    MessageBox.Show("Debe ingresar una cantidad");
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            numeral();
            txtNit.Clear();
            txtNombreCompañia.Clear();
            txtTotal.Clear();
            dgvSeleccionado.Rows.Clear();
        }






        private void txtNit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txtNombreCompañia_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void dgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
