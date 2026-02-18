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

namespace Minimercados_Unidos.Formularios.Admin
{
    public partial class FmrAgregarProveedor : Form
    {
        cConexiones cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;




        public FmrAgregarProveedor()
        {
            InitializeComponent();
            cn = new cConexiones();
        }

        private void BttCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void FmrAgregarProveedor_Load(object sender, EventArgs e)
        {
            CargarProveedores(dataGridViewProveedores);
        }

        public void CargarProveedores(DataGridView dgvProveedores)
        {
            try
            {
                SqlConnection conexion = cn.AbrirConexion();
                SqlCommand comando = null;
                SqlDataAdapter adapter = null;

                try
                {
                    string query = @"
            SELECT 
                Id_proveedor AS [ID],
                Nombre AS [Proveedor],
                Direccion AS [Dirección],
                Correo AS [Correo Electrónico]
            FROM Proveedor
            ORDER BY Nombre";

                    comando = new SqlCommand(query, conexion);
                    adapter = new SqlDataAdapter(comando);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        dgvProveedores.DataSource = dt;
                        ConfigurarGridProveedores(dgvProveedores);
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron proveedores registrados",
                                      "Información",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }
                }
                finally
                {
                    // Clean up resources in reverse order
                    if (adapter != null)
                        adapter.Dispose();

                    if (comando != null)
                        comando.Dispose();

                    if (conexion != null && conexion.State != ConnectionState.Closed)
                        conexion.Close();

                    cn.CerrarConexion();
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
        }

        private void ConfigurarGridProveedores(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;

            // Configuración básica
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Estilo de cabeceras
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Ajustar anchos de columnas
            dgv.Columns["ID"].FillWeight = 15;
            dgv.Columns["Proveedor"].FillWeight = 30;
            dgv.Columns["Dirección"].FillWeight = 35;
            dgv.Columns["Correo Electrónico"].FillWeight = 20;

            // Centrar columna de ID
            dgv.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Habilitar ordenamiento
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }


        private void BttAgregarProdu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txtnombre.Text) ||
    string.IsNullOrWhiteSpace(Txtdireccion.Text) ||
    string.IsNullOrWhiteSpace(Txtcorreo.Text))
            {
                MessageBox.Show("Complete todos los campos obligatorios", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection conexion = null;
            SqlCommand cmd = null;

            try
            {
                // Abrir conexión manualmente
                conexion = cn.AbrirConexion();

                // Obtener el próximo ID disponible
                int nuevoId = ObtenerProximoIdProveedor(conexion);

                string query = @"
    INSERT INTO Proveedor 
    (Id_proveedor, Nombre, Direccion, Correo)
    VALUES 
    (@IdProveedor, @Nombre, @Direccion, @Correo)";

                // Crear comando manualmente
                cmd = new SqlCommand(query, conexion);

                // Agregar parámetros (incluyendo el nuevo ID)
                cmd.Parameters.AddWithValue("@IdProveedor", nuevoId);
                cmd.Parameters.AddWithValue("@Nombre", Txtnombre.Text);
                cmd.Parameters.AddWithValue("@Direccion", Txtdireccion.Text);
                cmd.Parameters.AddWithValue("@Correo", Txtcorreo.Text);

                // Ejecutar comando
                int filasAfectadas = cmd.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show($"Proveedor agregado exitosamente\nID asignado: {nuevoId}", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el proveedor", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de clave primaria (por si acaso)
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
            finally
            {
                // Cerrar recursos en orden inverso
                if (cmd != null)
                    cmd.Dispose();

                if (conexion != null && conexion.State != ConnectionState.Closed)
                    conexion.Close();

                cn.CerrarConexion();
            }
        }

        private int ObtenerProximoIdProveedor(SqlConnection conexion)
        {
            string query = "SELECT ISNULL(MAX(Id_proveedor), 0) + 1 FROM Proveedor";
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                return Convert.ToInt32(comando.ExecuteScalar());
            }
        }




        private void TXTContraseña_Click(object sender, EventArgs e)
        {

        }

        private void Txtcorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Txtdireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
