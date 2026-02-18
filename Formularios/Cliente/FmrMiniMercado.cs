using System;
using System.CodeDom;
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
    public partial class FmrMiniMercado: Form
    {
        cConexiones cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;

        public FmrMiniMercado()
        {
            InitializeComponent();
            cn = new cConexiones();

            // Configurar visualización del cliente
            if (!string.IsNullOrEmpty(DatosCliente.Nombre))
            {
                LblNombreCiente.Text = $"Cliente: {DatosCliente.Nombre}";
                LblNombreCiente.Visible = true;
                txtTotal.Enabled = false;
            }
        }
        private void numericUpDownCantidad_ValueChanged(object sender, EventArgs e)
        {
            // Solo actualizar si hay filas seleccionadas
            if (dgvSeleccionado.Rows.Count > 0 && dgvSeleccionado.SelectedRows.Count > 0)
            {
                int cantidad = (int)numericUpDownCantidad.Value;
                DataGridViewRow selectedRow = dgvSeleccionado.SelectedRows[0];

                if (selectedRow.Cells[2].Value != null) // Verificar que tiene precio unitario
                {
                    decimal precioUnitario = Convert.ToDecimal(selectedRow.Cells[2].Value);
                    decimal total = precioUnitario * cantidad;

                    selectedRow.Cells[3].Value = cantidad;
                    selectedRow.Cells[4].Value = total;

                    // Recalcular total general
                    decimal totalGeneral = 0;
                    foreach (DataGridViewRow row in dgvSeleccionado.Rows)
                    {
                        if (row.Cells[4].Value != null)
                        {
                            totalGeneral += Convert.ToDecimal(row.Cells[4].Value);
                        }
                    }
                    txtTotal.Text = totalGeneral.ToString("C2");
                }
            }
        }


        private void FmrMiniMercado_Load(object sender, EventArgs e)
        {

            CargarProductos();
        }

        private void BttAnadir_Click(object sender, EventArgs e)
        {
        }
        
        private int ObtenerMinStock(int idProducto)
        {
            SqlConnection conexion = null;
            SqlCommand comando = null;

            try
            {
                // 1. Abrir conexión
                conexion = cn.AbrirConexion();

                // 2. Crear y configurar comando
                comando = new SqlCommand("SELECT Min_stock FROM Producto WHERE Id_producto = @Id", conexion);
                comando.Parameters.AddWithValue("@Id", idProducto);

                // 3. Ejecutar consulta
                object resultado = comando.ExecuteScalar();

                // 4. Devolver resultado (convertido) o 0 si es nulo
                return resultado != null ? Convert.ToInt32(resultado) : 0;
            }
            catch
            {
                return 0; // Valor por defecto si hay error
            }
            finally
            {
                // 5. Liberar recursos en orden inverso
                if (comando != null)
                    comando.Dispose();

                if (conexion != null && conexion.State != ConnectionState.Closed)
                    conexion.Close();

                // 6. Cierre adicional por si la clase cn maneja otra conexión
                cn.CerrarConexion();
            }
        }


        // 1. Método para cargar los productos (puede ser private o public según necesites)
        private void CargarProductos()
        {
            try
            {
                DataTable dtProductos = ObtenerProductosDesdeBD();
                MostrarProductosEnDataGrid(dtProductos);
                ConfigurarDataGridProductos();
            }
            catch (SqlException ex)
            {
                MostrarError($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                MostrarError($"Error inesperado: {ex.Message}");
            }
        }

        // 1. Método para obtener datos de la base de datos
        private DataTable ObtenerProductosDesdeBD()
        {
            string query = @"
        SELECT 
            p.Id_producto AS [ID],
            p.Nombre AS [Producto],
            p.Descripcion AS [Descripción],
            p.Precio,
            p.Stock,
            pr.Nombre AS [Proveedor]
        FROM Producto p
        INNER JOIN Proveedor pr ON p.Id_proveedor = pr.Id_proveedor
        ORDER BY p.Nombre";

            DataTable dt = new DataTable();
            SqlConnection conexion = null;
            SqlCommand comando = null;
            SqlDataReader reader = null;

            try
            {
                conexion = cn.AbrirConexion();
                comando = new SqlCommand(query, conexion);
                reader = comando.ExecuteReader();

                dt.Load(reader);
                return dt;
            }
            finally
            {
                // Cerrar recursos en orden inverso
                if (reader != null && !reader.IsClosed)
                    reader.Close();

                if (comando != null)
                    comando.Dispose();

                if (conexion != null && conexion.State != ConnectionState.Closed)
                    conexion.Close();

                // Cierre adicional de tu clase de conexión
                cn.CerrarConexion();
            }
        }   

        // 2. Método para mostrar datos en el DataGridView
        private void MostrarProductosEnDataGrid(DataTable datos)
        {
            dgvArticulos.DataSource = datos;
        }

        // 3. Método para configurar el DataGridView
        private void ConfigurarDataGridProductos()
        {
            // Configuración básica
            dgvArticulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArticulos.MultiSelect = false;
            dgvArticulos.ReadOnly = true;
            dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArticulos.DefaultCellStyle.Font = new Font("Segoe UI", 10);

            // Configuración específica de columnas
            if (dgvArticulos.Columns.Count > 0)
            {
                dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "C2";
                dgvArticulos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvArticulos.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvArticulos.Columns["Descripción"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // Establecer ancho personalizado para algunas columnas
                dgvArticulos.Columns["ID"].Width = 80;
                dgvArticulos.Columns["Precio"].Width = 100;
                dgvArticulos.Columns["Stock"].Width = 80;
            }
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // 1. Validar que hay filas seleccionadas
            if (dgvArticulos.SelectedRows.Count == 0)
            {
                MostrarError("Debe seleccionar al menos un producto del listado");
                return;
            }

            // 2. Validar cantidad
            int cantidad = (int)numericUpDownCantidad.Value;
            if (cantidad <= 0)
            {
                MostrarError("La cantidad debe ser mayor a cero");
                numericUpDownCantidad.Focus();
                return;
            }

            // 3. Validar stock mínimo para cada producto seleccionado
            foreach (DataGridViewRow row in dgvArticulos.SelectedRows)
            {
                if (row != null && !row.IsNewRow)
                {
                    try
                    {
                        int idProducto = Convert.ToInt32(row.Cells["ID"].Value);
                        int stockActual = Convert.ToInt32(row.Cells["Stock"].Value);
                        int minStock = ObtenerMinStock(idProducto);

                        // Validar que no se exceda el stock mínimo
                        if (stockActual - cantidad < minStock)
                        {
                            int maxPermitido = Math.Max(stockActual - minStock, 0);
                            string mensaje = $"No hay suficiente stock para {row.Cells["Producto"].Value}:\n" +
                                            $"Stock actual: {stockActual}\n" +
                                            $"Mínimo requerido: {minStock}\n" +
                                            $"Máximo permitido: {maxPermitido}";

                            MostrarError(mensaje);
                            numericUpDownCantidad.Value = maxPermitido > 0 ? maxPermitido : 1;
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MostrarError($"Error al validar stock: {ex.Message}");
                        return;
                    }
                }
            }

            // 4. Procesar productos seleccionados
            foreach (DataGridViewRow row in dgvArticulos.SelectedRows)
            {
                if (row != null && !row.IsNewRow)
                {
                    try
                    {
                        string codigo = row.Cells["ID"].Value?.ToString() ?? string.Empty;
                        string descripcion = row.Cells["Producto"].Value?.ToString() ?? string.Empty;
                        decimal precioUnitario = row.Cells["Precio"].Value != null ?
                            Convert.ToDecimal(row.Cells["Precio"].Value) : 0m;
                        int stockActual = Convert.ToInt32(row.Cells["Stock"].Value);

                        decimal total = precioUnitario * cantidad;

                        // Agregar al DataGridView de seleccionados
                        int nuevaFila = dgvSeleccionado.Rows.Add();
                        dgvSeleccionado.Rows[nuevaFila].Cells["Codigo"].Value = codigo;
                        dgvSeleccionado.Rows[nuevaFila].Cells["Descripcion"].Value = descripcion;
                        dgvSeleccionado.Rows[nuevaFila].Cells["PrecioUnitario"].Value = precioUnitario;
                        dgvSeleccionado.Rows[nuevaFila].Cells["Cantidad"].Value = cantidad;
                        dgvSeleccionado.Rows[nuevaFila].Cells["Total"].Value = total;

                        // Actualizar stock en el grid principal (solo visual)
                        row.Cells["Stock"].Value = stockActual - cantidad;
                    }
                    catch (Exception ex)
                    {
                        MostrarError($"Error al procesar producto: {ex.Message}");
                        continue;
                    }
                }
            }

            // 5. Calcular total general
            CalcularTotalPedido();

            // 6. Resetear controles
            numericUpDownCantidad.Value = 1;
        }
        private void CalcularTotalPedido()
        {
            float totalGeneral = 0;

            foreach (DataGridViewRow row in dgvSeleccionado.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    totalGeneral += Convert.ToSingle(row.Cells["Total"].Value);
                }
            }

            txtTotal.Text = totalGeneral.ToString("C2");
        }

        private void BttMandelo_Click(object sender, EventArgs e)
        {
            // Validar que hay productos en el carrito
            if (dgvSeleccionado.Rows.Count == 0 || dgvSeleccionado.Rows[0].Cells["Codigo"].Value == null)
            {
                MessageBox.Show("No hay productos en el carrito", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que hay datos del cliente
            if (DatosCliente.Cedula == 0)
            {
                MessageBox.Show("No se ha identificado al cliente", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conexion = null;
            SqlTransaction transaccion = null;
            SqlCommand cmdPedido = null;
            SqlCommand cmdPago = null;
            SqlCommand cmdDetalle = null;
            SqlCommand cmdActualizarStock = null; // Nuevo comando para actualizar stock

            try
            {
                // Abrir conexión y comenzar transacción
                conexion = cn.AbrirConexion();
                if (conexion == null || conexion.State != ConnectionState.Open)
                {
                    MessageBox.Show("Error al conectar con la base de datos", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                transaccion = conexion.BeginTransaction();

                // Obtener los próximos IDs
                var (idPedido, idPago) = ObtenerProximosIDs(conexion, transaccion);

                // Asignar repartidor
                int idRepartidor = ObtenerRepartidorAleatorio(conexion, transaccion);
                if (idRepartidor == -1)
                {
                    transaccion.Rollback();
                    MessageBox.Show("No se pudo asignar un repartidor", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calcular el total de todos los productos
                float totalPedido = 0;
                foreach (DataGridViewRow row in dgvSeleccionado.Rows)
                {
                    if (row.Cells["Total"].Value != null)
                    {
                        totalPedido += Convert.ToSingle(row.Cells["Total"].Value);
                    }
                }

                // 1. Insertar en tabla Pedido (un solo pedido para todos los productos)
                cmdPedido = new SqlCommand(
                    @"INSERT INTO Pedido (Id_pedido, Fecha, Estado, Total, Id_repartidor) 
              VALUES (@IdPedido, @Fecha, 'Pendiente', @Total, @IdRepartidor)",
                    conexion, transaccion);

                cmdPedido.Parameters.AddWithValue("@IdPedido", idPedido);
                cmdPedido.Parameters.AddWithValue("@Fecha", DateTime.Today);
                cmdPedido.Parameters.AddWithValue("@Total", totalPedido);
                cmdPedido.Parameters.AddWithValue("@IdRepartidor", idRepartidor);
                cmdPedido.ExecuteNonQuery();

                // 2. Insertar en tabla Pagos (un solo pago para el pedido)
                cmdPago = new SqlCommand(
                    @"INSERT INTO Pagos (Id_pago, Total_pagado, Fecha_pago, Estadopago, Id_pedido, Id_cliente) 
              VALUES (@IdPago, 0, NULL, 'Pendiente', @IdPedido, @IdCliente)",
                    conexion, transaccion);

                cmdPago.Parameters.AddWithValue("@IdPago", idPago);
                cmdPago.Parameters.AddWithValue("@IdPedido", idPedido);
                cmdPago.Parameters.AddWithValue("@IdCliente", DatosCliente.Cedula);
                cmdPago.ExecuteNonQuery();

                // 3. Insertar todos los productos en Detalle_pedido y actualizar stock
                foreach (DataGridViewRow row in dgvSeleccionado.Rows)
                {
                    if (row.Cells["Codigo"].Value != null)
                    {
                        int idProducto = Convert.ToInt32(row.Cells["Codigo"].Value);
                        int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        float subtotal = Convert.ToSingle(row.Cells["Total"].Value);

                        // Insertar detalle del pedido
                        cmdDetalle = new SqlCommand(
                            @"INSERT INTO Detalle_pedido (Id_pedido, Id_producto, Id_cliente, Cantidad, Subtotal, Fecha_llegada) 
                      VALUES (@IdPedido, @IdProducto, @IdCliente, @Cantidad, @Subtotal, NULL)",
                            conexion, transaccion);

                        cmdDetalle.Parameters.AddWithValue("@IdPedido", idPedido);
                        cmdDetalle.Parameters.AddWithValue("@IdProducto", idProducto);
                        cmdDetalle.Parameters.AddWithValue("@IdCliente", DatosCliente.Cedula);
                        cmdDetalle.Parameters.AddWithValue("@Cantidad", cantidad);
                        cmdDetalle.Parameters.AddWithValue("@Subtotal", subtotal);
                        cmdDetalle.ExecuteNonQuery();

                        // 4. Actualizar stock en la tabla Producto (NUEVA OPERACIÓN)
                        cmdActualizarStock = new SqlCommand(
                            @"UPDATE Producto SET Stock = Stock - @Cantidad 
                      WHERE Id_producto = @IdProducto",
                            conexion, transaccion);

                        cmdActualizarStock.Parameters.AddWithValue("@IdProducto", idProducto);
                        cmdActualizarStock.Parameters.AddWithValue("@Cantidad", cantidad);
                        cmdActualizarStock.ExecuteNonQuery();
                    }
                }

                transaccion.Commit();

                MessageBox.Show($"Pedido #{idPedido} creado correctamente con {dgvSeleccionado.Rows.Count} productos\n" +
                      $"Repartidor asignado: {idRepartidor}\n" +
                      $"Pago pendiente: #{idPago}\n" +
                      $"Total del pedido: {totalPedido:C}",
                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar el DataGridView después del pedido exitoso
                dgvSeleccionado.Rows.Clear();

                // Actualizar la lista de productos para reflejar el nuevo stock
                CargarProductos();
            }
            catch (Exception ex)
            {
                try { if (transaccion != null) transaccion.Rollback(); } catch { }
                MessageBox.Show($"Error al procesar el pedido: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cmdActualizarStock != null) cmdActualizarStock.Dispose();
                if (cmdDetalle != null) cmdDetalle.Dispose();
                if (cmdPago != null) cmdPago.Dispose();
                if (cmdPedido != null) cmdPedido.Dispose();
                if (transaccion != null) transaccion.Dispose();
                cn.CerrarConexion();
            }
        }
        private (int proximoIdPedido, int proximoIdPago) ObtenerProximosIDs(SqlConnection conexion, SqlTransaction transaccion)
        {
            using (SqlCommand cmdObtenerId = new SqlCommand("SELECT ISNULL(MAX(Id_pedido), 0) + 1 FROM Pedido", conexion, transaccion))
            {
                int proximoIdPedido = Convert.ToInt32(cmdObtenerId.ExecuteScalar());

                cmdObtenerId.CommandText = "SELECT ISNULL(MAX(Id_pago), 0) + 1 FROM Pagos";
                int proximoIdPago = Convert.ToInt32(cmdObtenerId.ExecuteScalar());

                return (proximoIdPedido, proximoIdPago);
            }
        }

        // Versión modificada de ObtenerRepartidorAleatorio que acepta transacción
        private int ObtenerRepartidorAleatorio(SqlConnection conexion, SqlTransaction transaccion)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    @"SELECT TOP 1 Id_repartidor FROM Repartidor ORDER BY NEWID()",
                    conexion, transaccion))
                {
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch
            {
                return -1;
            }
        }
        

        // 4. Método para mostrar errores
        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
