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
    public partial class fmrDetalleRepartidor : Form
    {

        cConexiones cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;
        int contador;


        public fmrDetalleRepartidor()
        {
            InitializeComponent();
            cn = new cConexiones();
        }

        private void fmrDetalleRepartidor_Load(object sender, EventArgs e)
        {

        }

        private void BttEnviado_Click(object sender, EventArgs e)
        {
            // Verificar que hay una fila seleccionada
            if (dgvResultados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un pedido para marcar como entregado", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection conexion = null;
            SqlCommand comando = null;

            try
            {
                // Obtener el ID del pedido y estado actual
                int idPedido = Convert.ToInt32(dgvResultados.SelectedRows[0].Cells["ID Pedido"].Value);
                string estadoActual = dgvResultados.SelectedRows[0].Cells["Estado Pedido"].Value.ToString();
                DateTime fechaEntrega = dateTimePickerEntrega.Value;

                // Verificar si ya está marcado como entregado
                if (estadoActual.Equals("Entregado", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Este pedido ya fue marcado como entregado anteriormente", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Consulta de actualización
                string query = @"
        BEGIN TRANSACTION;
    
        -- Primero verificamos nuevamente el estado (por si cambió desde la selección)
        IF NOT EXISTS (SELECT 1 FROM Pedido WHERE Id_pedido = @IdPedido AND Estado = 'Entregado')
        BEGIN
            UPDATE Pedido SET 
                Estado = 'Entregado',
                Fecha = @Fecha
            WHERE Id_pedido = @IdPedido;
    
            UPDATE Detalle_Pedido SET
                Fecha_llegada = @Fecha_llegada
            WHERE Id_pedido = @IdPedido;
    
            SELECT 1;
        END
        ELSE
        BEGIN
            SELECT 0; 
        END
    
        COMMIT TRANSACTION;";

                // Ejecutar la actualización
                conexion = cn.AbrirConexion();
                comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdPedido", idPedido);
                comando.Parameters.AddWithValue("@Fecha", fechaEntrega);
                comando.Parameters.AddWithValue("@Fecha_llegada", fechaEntrega); // Parámetro faltante

                int resultado = Convert.ToInt32(comando.ExecuteScalar());

                if (resultado == 1)
                {
                    MessageBox.Show("Pedido marcado como entregado correctamente", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Actualizar el DataGridView
                    BttAgregarProdu_Click(sender, e);
                }
                else if (resultado == 0)
                {
                    MessageBox.Show("El pedido ya estaba marcado como entregado",
                                  "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BttAgregarProdu_Click(sender, e); // Refrescar datos
                }
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show($"Error: {ex.Message}\n\nAsegúrese que las columnas 'ID Pedido' y 'Estado Pedido' existen en el DataGridView",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error SQL al actualizar: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cierre manual seguro de la conexión
                if (comando != null)
                    comando.Dispose();

                if (conexion != null && conexion.State != ConnectionState.Closed)
                    conexion.Close();

                cn.CerrarConexion();
            }
        }

        private void BttAgregarProdu_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = null;
            SqlCommand comando = null;
            SqlDataAdapter adapter = null;

            try
            {
                // Validar que el ID de repartidor sea válido
                if (!int.TryParse(Txt_IdRepartidor.Text, out int idRepartidor))
                {
                    MessageBox.Show("Ingrese un ID de repartidor válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abrir conexión manualmente
                conexion = cn.AbrirConexion();

                // Consulta SQL modificada para incluir Id_pedido
                string query = @"
                    SELECT 
                    p.Id_pedido AS [ID Pedido],  
                    dp.Fecha_llegada AS [Fecha Llegada],
                    dp.Cantidad,
                    c.Nombre AS [Nombre Cliente],
                    c.Direccion AS [Dirección Cliente],
                    p.Fecha AS [Fecha Pedido],
                    p.Estado AS [Estado Pedido],
                    r.Nombre AS [Nombre Repartidor]
                FROM Detalle_Pedido dp
                INNER JOIN Pedido p ON dp.Id_pedido = p.Id_pedido
                INNER JOIN Cliente c ON dp.Id_cliente = c.Id_cliente
                INNER JOIN Repartidor r ON p.Id_repartidor = r.Id_repartidor
                WHERE p.Id_repartidor = @IdRepartidor
                ORDER BY dp.Fecha_llegada DESC";

                // Crear comando manualmente
                comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdRepartidor", idRepartidor);

                // Crear adapter manualmente
                adapter = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // Mostrar resultados en el DataGridView
                if (dt.Rows.Count > 0)
                {
                    dgvResultados.DataSource = dt;

                    // Opcional: Configurar columna ID como no editable y oculta si es necesario
                    dgvResultados.Columns["ID Pedido"].ReadOnly = true;
                    // dgvResultados.Columns["ID Pedido"].Visible = false;  // Descomentar para ocultar

                    MessageBox.Show($"Se encontraron {dt.Rows.Count} registros", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvResultados.DataSource = null;
                    MessageBox.Show("No se encontraron pedidos para este repartidor", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Cerrar recursos en orden inverso
                if (adapter != null)
                    adapter.Dispose();

                if (comando != null)
                    comando.Dispose();

                if (conexion != null && conexion.State != ConnectionState.Closed)
                    conexion.Close();

                cn.CerrarConexion();
            }
        }
    }
}
