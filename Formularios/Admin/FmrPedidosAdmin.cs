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
    public partial class FmrPedidosAdmin: Form
    {

        cConexiones cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;
        int contador;



        public FmrPedidosAdmin()
        {
            InitializeComponent();
            cn = new cConexiones();
        }

        private void FmrPedidosAdmin_Load(object sender, EventArgs e)
        {
            CargarDetallePedidos(DttgDescripcionPedi);
        }



        private void BttRefrescar_Click(object sender, EventArgs e)
        { 
        }


        public void CargarDetallePedidos(DataGridView dgvDetallePedidos)
        {
            try
            {
                // Usamos directamente la conexión de tu clase cn
                string query = @"
                SELECT 
                    dp.Cantidad,
                    dp.Subtotal,
                    CONVERT(varchar, dp.Fecha_llegada, 103) AS [Fecha Llegada],
                    p.Fecha AS [Fecha Pedido],
                    p.Estado AS [Estado Pedido],
                    p.Total AS [Total Pedido],
                    r.Nombre AS [Repartidor],
                    prod.Nombre AS [Producto],
                    prod.Descripcion AS [Descripción Producto],
                    prod.Precio AS [Precio Unitario],
                    c.Nombre AS [Cliente],
                    c.Direccion AS [Dirección Cliente]
                FROM Detalle_Pedido dp
                INNER JOIN Pedido p ON dp.Id_pedido = p.Id_pedido
                LEFT JOIN Repartidor r ON p.Id_repartidor = r.Id_repartidor
                INNER JOIN Producto prod ON dp.Id_producto = prod.Id_producto
                INNER JOIN Cliente c ON dp.Id_cliente = c.Id_cliente
                ORDER BY dp.Fecha_llegada DESC";

                SqlCommand comando = new SqlCommand(query, cn.AbrirConexion());
                DataTable dt = new DataTable();
                new SqlDataAdapter(comando).Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dgvDetallePedidos.DataSource = dt;
                    ConfigurarGridDetallePedidos(dgvDetallePedidos);
                }
                else
                {
                    MessageBox.Show("No se encontraron detalles de pedidos",
                                  "Información",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de base de datos: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            finally
            {
                cn.CerrarConexion(); 
            }
        }

        private void BttAgregarProdu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txt_idpedido.Text))
            {
                MessageBox.Show("Ingrese un ID de pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_idpedido.Focus();
                return;
            }

            if (!int.TryParse(Txt_idpedido.Text, out int idPedido))
            {
                MessageBox.Show("El ID debe ser un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Txt_idpedido.Focus();
                return;
            }

            SqlConnection conexion = null;
            SqlDataAdapter adapter = null;

            try
            {
                DataTable dtResultados = new DataTable();

                // Abrir conexión manualmente
                conexion = cn.AbrirConexion();

                string query = @"SELECT dp.*, p.Nombre AS Producto 
            FROM Detalle_pedido dp
            INNER JOIN Producto p ON dp.Id_producto = p.Id_producto
            WHERE dp.Id_pedido = @IdPedido";

                // Crear adapter manualmente
                adapter = new SqlDataAdapter(query, conexion);
                adapter.SelectCommand.Parameters.Add("@IdPedido", SqlDbType.Int).Value = idPedido;
                adapter.Fill(dtResultados);

                // Mostrar resultados
                if (dtResultados.Rows.Count > 0)
                {
                    DttgDescripcionPedi.DataSource = dtResultados;
                    MessageBox.Show($"Se encontraron {dtResultados.Rows.Count} registros", "Resultados",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DttgDescripcionPedi.DataSource = null;
                    MessageBox.Show("No se encontraron detalles para este pedido", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de base de datos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar recursos en orden inverso
                if (adapter != null)
                    adapter.Dispose();

                if (conexion != null && conexion.State != ConnectionState.Closed)
                    conexion.Close();

                cn.CerrarConexion();
            }
        }


        private void ConfigurarGridDetallePedidos(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;

            // Configuración básica para autoajuste
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Estilo visual mejorado
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            // Formato de columnas
            dgv.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            dgv.Columns["Total Pedido"].DefaultCellStyle.Format = "C2";
            dgv.Columns["Precio Unitario"].DefaultCellStyle.Format = "C2";

            // Alineación de contenido
            dgv.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Total Pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv.Columns["Precio Unitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Configuración específica para columnas largas
            dgv.Columns["Descripción Producto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Dirección Cliente"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Habilitar ordenamiento
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }


            // Ajustar después de cargar los datos
            dgv.DataBindingComplete += (sender, e) =>
            {
                dgv.AutoResizeColumns();
                dgv.AutoResizeRows();
            };
        }




    }
}
