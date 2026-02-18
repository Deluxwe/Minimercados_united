using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minimercados_Unidos.Claases;
using Minimercados_Unidos.Formularios.LogIn;

namespace Minimercados_Unidos
{
    public partial class FmrPedidos : Form
    {
        cConexiones cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;
        int contador;

        public FmrPedidos()
        {
            cn = new cConexiones();
            InitializeComponent();

            if (!string.IsNullOrEmpty(DatosCliente.Nombre))
            {
                LblNombreCiente.Text = $"Cliente: {DatosCliente.Nombre}";
                LblNombreCiente.Visible = true;
            }
        }

        private void bttConsultar_Click(object sender, EventArgs e)
        {
       
            if (DatosCliente.Cedula == 0)
            {
                MessageBox.Show("No se ha identificado al cliente correctamente", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Abrir conexión usando tu clase personalizada
                SqlConnection conexion = cn.AbrirConexion();

                string query = @"
            SELECT 
                c.Nombre AS NombreCliente,
                dp.Cantidad,
                p.Nombre AS Productos,
                c.Direccion,
                ped.Total AS [Total A Pagar],
                ped.Estado AS [Estado De Pago]
            FROM Detalle_Pedido dp
            INNER JOIN Cliente c ON dp.Id_cliente = c.Id_cliente
            INNER JOIN Producto p ON dp.Id_producto = p.Id_producto
            INNER JOIN Pedido ped ON dp.Id_pedido = ped.Id_pedido
            WHERE c.Id_cliente = @IdCliente
            ORDER BY ped.Fecha DESC";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Usar la cédula del contenedor
                    comando.Parameters.AddWithValue("@IdCliente", DatosCliente.Cedula);

                    DataTable dt = new DataTable();
                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron pedidos para este cliente",
                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DttgrindPedidos.DataSource = dt;
                    ConfigurarDataGrid();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de base de datos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.CerrarConexion();
            }

        }

        private void ConfigurarDataGrid()
        {
            // Asegurarse que el DataGridView tiene datos
            if (DttgrindPedidos.Columns.Count == 0) return;

            // Configurar nombres de columnas
            DttgrindPedidos.Columns["NombreCliente"].HeaderText = "Nombre del Cliente";
            DttgrindPedidos.Columns["Cantidad"].HeaderText = "Cantidad";
            DttgrindPedidos.Columns["Productos"].HeaderText = "Productos Adquiridos";
            DttgrindPedidos.Columns["Direccion"].HeaderText = "Dirección del Cliente";
            DttgrindPedidos.Columns["Total A Pagar"].HeaderText = "Total A Pagar";
            DttgrindPedidos.Columns["Estado De Pago"].HeaderText = "Estado del Pago";

            // Configurar formatos
            DttgrindPedidos.Columns["Total A Pagar"].DefaultCellStyle.Format = "C2"; // Formato de moneda
            DttgrindPedidos.Columns["Total A Pagar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DttgrindPedidos.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Autoajustar columnas
            DttgrindPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Alternar colores de filas para mejor legibilidad
            DttgrindPedidos.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Permitir ordenar por columnas
            foreach (DataGridViewColumn column in DttgrindPedidos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
    }
}
