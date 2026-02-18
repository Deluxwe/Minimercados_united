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
using Minimercados_Unidos.Formularios.Admin;

namespace Minimercados_Unidos
{

    public partial class FmrInventario: Form
    {

        cConexiones cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;
        int contador;



        public FmrInventario()
        {
            InitializeComponent();
            PnlAdvertencia.Visible = false;
            cn = new cConexiones();
        }

        private void FmrInventario_Load(object sender, EventArgs e)
        {

            CargarInventario();
        }

        private void CargarInventario()
        {
            SqlConnection conexion = null;
            SqlCommand comando = null;
            SqlDataAdapter adapter = null;

            try
            {
                conexion = cn.AbrirConexion();
                string query = @"
            SELECT 
                p.Id_producto,
                p.Nombre AS [Nombre Producto],
                p.Descripcion,
                p.Precio,
                p.Stock,
                p.Min_stock AS [Stock Mínimo],
                p.Max_stock AS [Stock Máximo],
                p.Id_proveedor,
                prov.Nombre AS [Nombre Proveedor],
                prov.Direccion AS [Dirección Proveedor],
                prov.Correo AS [Correo Proveedor]
            FROM Producto p
            INNER JOIN Proveedor prov ON p.Id_proveedor = prov.Id_proveedor
            ORDER BY p.Nombre";

                comando = new SqlCommand(query, conexion);
                adapter = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DtdInventario.DataSource = dt;
                    ConfigurarDataGridInventario();
                }
                else
                {
                    MessageBox.Show("No se encontraron productos en el inventario", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al cargar el inventario: {ex.Message}", "Error de base de datos",
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

        private void BttAgregarPro_Click(object sender, EventArgs e)
        {
            Form frmProve = new FmrAgregarProveedor();
            frmProve.Show();

        }

        private void BttAgregarProdu_Click(object sender, EventArgs e)
        {
            // Validaciones iniciales 
            if (string.IsNullOrWhiteSpace(TxtnombreP.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(TxtPrecio.Text) ||
                string.IsNullOrWhiteSpace(Txt_idprovedor.Text) ||
                string.IsNullOrWhiteSpace(TxtMinStock.Text) ||
                string.IsNullOrWhiteSpace(TxtMaxStock.Text))
            {
                PnlAdvertencia.Visible = true;
                MessageBox.Show("Por favor complete todos los campos obligatorios", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad < 0)
            {
                MessageBox.Show("Ingrese una cantidad válida (número entero positivo)", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(TxtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingrese un precio válido mayor a cero", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(Txt_idprovedor.Text, out int idProveedor))
            {
                MessageBox.Show("ID de proveedor inválido", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(TxtMinStock.Text, out int minStock) || minStock < 0)
            {
                MessageBox.Show("Ingrese un stock mínimo válido", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(TxtMaxStock.Text, out int maxStock) || maxStock <= 0)
            {
                MessageBox.Show("Ingrese un stock máximo válido mayor a cero", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (minStock >= maxStock)
            {
                MessageBox.Show("El stock mínimo debe ser menor al stock máximo", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cantidad > maxStock)
            {
                MessageBox.Show($"La cantidad no puede superar el stock máximo de {maxStock}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                SqlConnection conexion = cn.AbrirConexion();
                SqlCommand comandoProveedor = null;
                SqlDataReader readerProveedor = null;
                SqlCommand comandoInsert = null;

                try
                {
                    // Obtener el próximo ID disponible
                    int nuevoId = ObtenerProximoIdProducto(conexion);

                    // 1. Verificar que el proveedor existe y obtener sus datos
                    string queryProveedor = @"
                    SELECT Nombre, Direccion, Correo 
                    FROM Proveedor 
                    WHERE Id_proveedor = @IdProveedor";

                    string nombreProveedor = "";
                    string direccionProveedor = "";
                    string correoProveedor = "";

                    comandoProveedor = new SqlCommand(queryProveedor, conexion);
                    comandoProveedor.Parameters.AddWithValue("@IdProveedor", idProveedor);

                    readerProveedor = comandoProveedor.ExecuteReader();
                    if (readerProveedor.Read())
                    {
                        nombreProveedor = readerProveedor["Nombre"].ToString();
                        direccionProveedor = readerProveedor["Direccion"].ToString();
                        correoProveedor = readerProveedor["Correo"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("El proveedor especificado no existe", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    readerProveedor.Close();

                    // 2. Insertar el nuevo producto
                    string queryInsert = @"
                    INSERT INTO Producto 
                    (Id_producto, Nombre, Descripcion, Precio, Stock, Min_stock, Max_stock, Id_proveedor)
                    VALUES 
                    (@IdProducto, @Nombre, @Descripcion, @Precio, @Stock, @MinStock, @MaxStock, @IdProveedor)";

                    comandoInsert = new SqlCommand(queryInsert, conexion);
                    comandoInsert.Parameters.AddWithValue("@IdProducto", nuevoId);
                    comandoInsert.Parameters.AddWithValue("@Nombre", TxtnombreP.Text);
                    comandoInsert.Parameters.AddWithValue("@Descripcion", TxtDescripcion.Text);
                    comandoInsert.Parameters.AddWithValue("@Precio", precio);
                    comandoInsert.Parameters.AddWithValue("@Stock", cantidad);
                    comandoInsert.Parameters.AddWithValue("@MinStock", minStock);
                    comandoInsert.Parameters.AddWithValue("@MaxStock", maxStock);
                    comandoInsert.Parameters.AddWithValue("@IdProveedor", idProveedor);

                    int filasAfectadas = comandoInsert.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show($"Producto agregado exitosamente\n\n" +
                                      $"ID Generado: {nuevoId}\n" +
                                      $"Proveedor: {nombreProveedor}\n" +
                                      $"Dirección: {direccionProveedor}\n" +
                                      $"Contacto: {correoProveedor}",
                                      "Éxito",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);

                        // Limpiar controles
                        TxtnombreP.Clear();
                        TxtDescripcion.Clear();
                        txtCantidad.Clear();
                        TxtPrecio.Clear();
                        Txt_idprovedor.Clear();
                        TxtMinStock.Clear();
                        TxtMaxStock.Clear();

                        // Actualizar el DataGridView
                        CargarInventario();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el producto", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    // Cerrar recursos en orden inverso
                    if (readerProveedor != null && !readerProveedor.IsClosed)
                        readerProveedor.Close();

                    if (comandoProveedor != null)
                        comandoProveedor.Dispose();

                    if (comandoInsert != null)
                        comandoInsert.Dispose();

                    cn.CerrarConexion();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MessageBox.Show("Error al generar el ID automático", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Error de base de datos: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObtenerProximoIdProducto(SqlConnection conexion)
        {
            string query = "SELECT ISNULL(MAX(Id_producto), 0) + 1 FROM Producto";
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }


        private void ConfigurarDataGridInventario()
        {

            if (DtdInventario.Columns.Count == 0) return;

            // Configurar nombres de columnas
            DtdInventario.Columns["Nombre Producto"].HeaderText = "Producto";
            DtdInventario.Columns["Descripcion"].HeaderText = "Descripción";
            DtdInventario.Columns["Precio"].HeaderText = "Precio Unitario";
            DtdInventario.Columns["Stock"].HeaderText = "Existencia";
            DtdInventario.Columns["Stock Mínimo"].HeaderText = "Mínimo";
            DtdInventario.Columns["Stock Máximo"].HeaderText = "Máximo";
            DtdInventario.Columns["Id_proveedor"].HeaderText = "ID Prov.";
            DtdInventario.Columns["Nombre Proveedor"].HeaderText = "Proveedor";
            DtdInventario.Columns["Dirección Proveedor"].HeaderText = "Dirección";
            DtdInventario.Columns["Correo Proveedor"].HeaderText = "Correo";

            // Ocultar columna de Id_producto si no es necesaria
            DtdInventario.Columns["Id_producto"].Visible = false;

            // Configurar formatos
            DtdInventario.Columns["Precio"].DefaultCellStyle.Format = "C2";
            DtdInventario.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DtdInventario.Columns["Stock Mínimo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DtdInventario.Columns["Stock Máximo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DtdInventario.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DtdInventario.Columns["Id_proveedor"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Configurar estilo visual
            DtdInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DtdInventario.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            DtdInventario.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            DtdInventario.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            DtdInventario.EnableHeadersVisualStyles = false;
            DtdInventario.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            DtdInventario.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Configurar pesos relativos para las columnas
            DtdInventario.Columns["Nombre Producto"].FillWeight = 15;
            DtdInventario.Columns["Descripcion"].FillWeight = 20;
            DtdInventario.Columns["Precio"].FillWeight = 10;
            DtdInventario.Columns["Stock"].FillWeight = 8;
            DtdInventario.Columns["Stock Mínimo"].FillWeight = 8;
            DtdInventario.Columns["Stock Máximo"].FillWeight = 8;
            DtdInventario.Columns["Id_proveedor"].FillWeight = 6;
            DtdInventario.Columns["Nombre Proveedor"].FillWeight = 15;
            DtdInventario.Columns["Dirección Proveedor"].FillWeight = 15;
            DtdInventario.Columns["Correo Proveedor"].FillWeight = 15;

            // Habilitar ordenamiento
            foreach (DataGridViewColumn column in DtdInventario.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            // Resaltar productos con bajo stock o sobre stock
            DtdInventario.CellFormatting += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == DtdInventario.Columns["Stock"].Index && e.Value != null)
                {
                    if (int.TryParse(e.Value.ToString(), out int stock))
                    {
                        int minStock = Convert.ToInt32(DtdInventario.Rows[e.RowIndex].Cells["Stock Mínimo"].Value);
                        int maxStock = Convert.ToInt32(DtdInventario.Rows[e.RowIndex].Cells["Stock Máximo"].Value);

                        if (stock < minStock)
                        {
                            e.CellStyle.BackColor = Color.LightPink;
                            e.CellStyle.ForeColor = Color.DarkRed;
                            e.CellStyle.Font = new Font(DtdInventario.DefaultCellStyle.Font, FontStyle.Bold);
                        }
                        else if (stock > maxStock)
                        {
                            e.CellStyle.BackColor = Color.LightYellow;
                            e.CellStyle.ForeColor = Color.DarkGoldenrod;
                            e.CellStyle.Font = new Font(DtdInventario.DefaultCellStyle.Font, FontStyle.Bold);
                        }
                    }
                }
            };
        }
    }
}
