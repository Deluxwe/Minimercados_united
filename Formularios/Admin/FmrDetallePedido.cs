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

namespace Minimercados_Unidos
{
    public partial class FmrDetallePedido: Form
    {

        cConexiones cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;



        public FmrDetallePedido()
        {
            InitializeComponent();
            cn = new cConexiones();
        }

        private void FmrDetallePedido_Load(object sender, EventArgs e)
        {
            LoadDetallePedido();
        }

        private void LoadDetallePedido()
        {
            try
            {
                using (SqlConnection conexion = cn.AbrirConexion())
                {
                    string query = @"
            SELECT 
                dp.Cantidad,
                dp.Subtotal,
                CONVERT(varchar, dp.Fecha_llegada, 103) AS [Fecha Llegada],
                dp.Id_pedido AS [N° Pedido],
                dp.Id_producto AS [ID Producto],
                dp.Id_cliente AS [ID Cliente],
                p.Id_repartidor AS [ID Repartidor]  -- Nueva columna agregada
            FROM Detalle_Pedido dp
            INNER JOIN Pedido p ON dp.Id_pedido = p.Id_pedido  -- JOIN con la tabla Pedido
            ORDER BY dp.Fecha_llegada DESC";

                    using (SqlCommand comando = new SqlCommand(query, conexion))
                    {
                        DataTable dt = new DataTable();
                        new SqlDataAdapter(comando).Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            DtgDetallePedido.DataSource = dt;
                            ConfigurarDataGridDetallePedido();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron detalles de pedidos", "Información",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
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

        private void ConfigurarDataGridDetallePedido()
        {
            if (DtgDetallePedido.Columns.Count == 0) return;

            // Configurar nombres de columnas
            DtgDetallePedido.Columns["Cantidad"].HeaderText = "Cantidad";
            DtgDetallePedido.Columns["Subtotal"].HeaderText = "Subtotal";
            DtgDetallePedido.Columns["Fecha Llegada"].HeaderText = "Fecha de Llegada";
            DtgDetallePedido.Columns["N° Pedido"].HeaderText = "Número de Pedido";
            DtgDetallePedido.Columns["ID Producto"].HeaderText = "Producto";
            DtgDetallePedido.Columns["ID Cliente"].HeaderText = "Cliente";

            // Configurar formatos
            DtgDetallePedido.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            DtgDetallePedido.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DtgDetallePedido.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DtgDetallePedido.Columns["N° Pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DtgDetallePedido.Columns["ID Producto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DtgDetallePedido.Columns["ID Cliente"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Configurar estilo visual
            DtgDetallePedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DtgDetallePedido.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            DtgDetallePedido.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            DtgDetallePedido.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            DtgDetallePedido.EnableHeadersVisualStyles = false;
            DtgDetallePedido.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            DtgDetallePedido.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Configurar pesos relativos para las columnas
            DtgDetallePedido.Columns["Cantidad"].FillWeight = 10;
            DtgDetallePedido.Columns["Subtotal"].FillWeight = 15;
            DtgDetallePedido.Columns["Fecha Llegada"].FillWeight = 15;
            DtgDetallePedido.Columns["N° Pedido"].FillWeight = 12;
            DtgDetallePedido.Columns["ID Producto"].FillWeight = 13;
            DtgDetallePedido.Columns["ID Cliente"].FillWeight = 15;

            // Habilitar ordenamiento
            foreach (DataGridViewColumn column in DtgDetallePedido.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

    }
}
