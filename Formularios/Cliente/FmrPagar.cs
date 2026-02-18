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

namespace Minimercados_Unidos.Formularios.Cliente
{


    public partial class FmrPagar : Form
    {
        cConexiones cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;
        int contador;


        public FmrPagar()
        {
            InitializeComponent();
            DtpPagos.Value = DateTime.Now;
            cn = new cConexiones();

            // Verificar y mostrar datos del cliente
            if (DatosCliente.Cedula == 0 || string.IsNullOrEmpty(DatosCliente.Nombre))
            {
                MessageBox.Show("No se ha identificado correctamente al cliente", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Mostrar datos del cliente
            LblNombreCiente.Text = $"Cliente: {DatosCliente.Nombre}";
            LblNombreCiente.Visible = true;
            LblNombreCiente.ForeColor = Color.Black;
            LblNombreCiente.Font = new Font(LblNombreCiente.Font, FontStyle.Bold);

            // Cargar datos automáticamente
            CargarPagosDtg();
        }


        private void bttConsultar_Click(object sender, EventArgs e)
        {
           
        }

        private void CargarPagosDtg()
        {
            // Validación usando el contenedor
            if (DatosCliente.Cedula == 0)
            {
                MessageBox.Show("No se ha identificado al cliente correctamente", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection conexion = null;
            try
            {
                conexion = cn.AbrirConexion();

                string query = @"
            SELECT 
                c.Nombre AS [Nombre Cliente],
                p.Id_pedido,
                ped.Total,
                p.Total_pagado,
                p.Fecha_pago,
                p.Estadopago 
            FROM Pagos p
            INNER JOIN Cliente c ON p.Id_cliente = c.Id_cliente  
            INNER JOIN Pedido ped ON p.Id_pedido = ped.Id_pedido
            WHERE c.Id_cliente = @IdCliente
            ORDER BY p.Fecha_pago DESC";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Usar la cédula del contenedor
                    comando.Parameters.AddWithValue("@IdCliente", DatosCliente.Cedula);

                    DataTable dt = new DataTable();
                    new SqlDataAdapter(comando).Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron pagos para este cliente",
                                      "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    DttgrindPagos.DataSource = dt;
                    ConfigurarDataGridPagos();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de base de datos: {ex.Message}\nVerifica los nombres de columnas en tus tablas.",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexion != null)
                {
                    cn.CerrarConexion();
                }
            }
        }

        private void bttPagar_Click(object sender, EventArgs e)
        {
            // 1. Validar selección en el DataGridView
            if (DttgrindPagos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un pedido del listado", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtener el ID del pedido de la fila seleccionada
            string idPedido = DttgrindPagos.SelectedRows[0].Cells["Id_pedido"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(idPedido))
            {
                MessageBox.Show("No se pudo obtener el ID del pedido seleccionado", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validaciones de pago
            if (string.IsNullOrWhiteSpace(TxtAbonar.Text))
            {
                MessageBox.Show("Por favor ingrese el monto a pagar", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(TxtAbonar.Text, out double montoPago) || montoPago <= 0)
            {
                MessageBox.Show("Ingrese un monto válido mayor a cero", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlConnection conexion = null;
            try
            {
                conexion = cn.AbrirConexion();

                // 1. Obtener información del pago
                string querySelect = @"
                    SELECT 
                        ped.Total,
                        p.Total_pagado,
                        p.Estadopago
                    FROM Pagos p
                    INNER JOIN Pedido ped ON p.Id_pedido = ped.Id_pedido
                    WHERE p.Id_pedido = @IdPedido";

                double total = 0;
                double totalPagado = 0;
                string estadoActual = "";

                using (SqlCommand comandoSelect = new SqlCommand(querySelect, conexion))
                {
                    comandoSelect.Parameters.AddWithValue("@IdPedido", idPedido);

                    using (SqlDataReader reader = comandoSelect.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            total = reader.IsDBNull(0) ? 0 : Convert.ToDouble(reader[0]);
                            totalPagado = reader.IsDBNull(1) ? 0 : Convert.ToDouble(reader[1]);
                            estadoActual = reader.IsDBNull(2) ? "Pendiente" : reader[2].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el pedido especificado", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                // 2. Validar el estado actual
                if (estadoActual == "Pagado")
                {
                    MessageBox.Show("Este pedido ya está completamente pagado", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 3. Calcular nuevo estado y cambio
                double nuevoTotalPagado = totalPagado + montoPago;
                double cambio = 0;
                string nuevoEstado = "Pendiente";

                if (nuevoTotalPagado >= total)
                {
                    nuevoEstado = "Pagado";
                    cambio = nuevoTotalPagado - total;
                    nuevoTotalPagado = total;
                }

                // 4. Actualizar el pago y el pedido en una transacción
                string queryUpdatePago = @"
                    UPDATE Pagos
                    SET 
                        Total_pagado = @TotalPagado,
                        Estadopago = @Estadopago,
                        Fecha_pago = @FechaPago
                    WHERE Id_pedido = @IdPedido";

                string queryUpdatePedido = @"
                    UPDATE Pedido
                    SET 
                        Estado = @EstadoPedido
                    WHERE Id_pedido = @IdPedido";

                SqlTransaction transaction = null;
                try
                {
                    transaction = conexion.BeginTransaction();

                    // Actualizar tabla Pagos
                    using (SqlCommand comandoUpdate = new SqlCommand(queryUpdatePago, conexion, transaction))
                    {
                        comandoUpdate.Parameters.AddWithValue("@TotalPagado", nuevoTotalPagado);
                        comandoUpdate.Parameters.AddWithValue("@Estadopago", nuevoEstado);
                        comandoUpdate.Parameters.AddWithValue("@FechaPago", DtpPagos?.Value ?? DateTime.Now);
                        comandoUpdate.Parameters.AddWithValue("@IdPedido", idPedido);

                        if (comandoUpdate.ExecuteNonQuery() == 0)
                        {
                            throw new Exception("No se pudo actualizar el pago");
                        }
                    }

                    // Actualizar tabla Pedido
                    using (SqlCommand comandoUpdatePedido = new SqlCommand(queryUpdatePedido, conexion, transaction))
                    {
                        comandoUpdatePedido.Parameters.AddWithValue("@EstadoPedido", nuevoEstado);
                        comandoUpdatePedido.Parameters.AddWithValue("@IdPedido", idPedido);

                        if (comandoUpdatePedido.ExecuteNonQuery() == 0)
                        {
                            throw new Exception("No se pudo actualizar el estado del pedido");
                        }
                    }

                    transaction.Commit();

                    // Mostrar mensaje apropiado
                    if (nuevoEstado == "Pagado")
                    {
                        if (cambio > 0)
                        {
                            MessageBox.Show($"¡Pago completado con éxito! Pedido marcado como pagado.\nCambio devuelto: {cambio:C2}",
                                          "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("¡Pago completado con éxito! Pedido marcado como pagado.",
                                          "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Abono registrado. Estado actualizado. Saldo pendiente: {(total - nuevoTotalPagado):C2}",
                                      "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Limpiar controles y actualizar grid
                    TxtAbonar.Clear();
                    CargarPagosDtg();
                }
                catch (Exception ex)
                {
                    try
                    {
                        transaction?.Rollback();
                        MessageBox.Show($"Error al actualizar: {ex.Message}\nNo se realizaron cambios.", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception rollbackEx)
                    {
                        MessageBox.Show($"Error crítico: {rollbackEx.Message}", "Error Grave",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    transaction?.Dispose();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de base de datos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show($"Error de tipo de datos: {ex.Message}\nVerifique los tipos en la base de datos.", "Error",
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
        
        private void ConfigurarDataGridPagos()
        {
            if (DttgrindPagos.Columns.Count == 0) return;

            // Configuración corregida para usar "Estado" (el alias)
            DttgrindPagos.Columns["Estadopago"].HeaderText = "Estado de Pago";  // Cambiado para usar el alias

            // Resto de la configuración permanece igual
            DttgrindPagos.Columns["Nombre Cliente"].HeaderText = "Nombre del Cliente";
            DttgrindPagos.Columns["Id_pedido"].HeaderText = "N° Pedido";
            DttgrindPagos.Columns["Total"].HeaderText = "Total Pedido";
            DttgrindPagos.Columns["Total_pagado"].HeaderText = "Total Pagado";
            DttgrindPagos.Columns["Fecha_pago"].HeaderText = "Fecha de Pago";

            // Formatos y alineaciones
            DttgrindPagos.Columns["Total"].DefaultCellStyle.Format = "C2";
            DttgrindPagos.Columns["Total_pagado"].DefaultCellStyle.Format = "C2";
            DttgrindPagos.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DttgrindPagos.Columns["Total_pagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DttgrindPagos.Columns["Id_pedido"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DttgrindPagos.Columns["Fecha_pago"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Autoajuste y estilo
            DttgrindPagos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DttgrindPagos.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            foreach (DataGridViewColumn column in DttgrindPagos.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }


    }
}