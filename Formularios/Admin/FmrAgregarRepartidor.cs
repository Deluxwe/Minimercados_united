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
    public partial class FmrAgregarRepartidor: Form
    {
        cConexiones cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;


        public FmrAgregarRepartidor()
        {
            InitializeComponent();
            cn = new cConexiones();
        }

        private void FmrAgregarRepartidor_Load(object sender, EventArgs e)
        {
            CargarRepartidores();

            DtgRepartidores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DtgRepartidores.MultiSelect = false;
            DtgRepartidores.ReadOnly = true;

        }

        private void BttAgregarRep_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Txtid_repartidor.Text) || string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MessageBox.Show("Debe completar todos los campos", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(Txtid_repartidor.Text, out int idRepartidor))
            {
                MessageBox.Show("El ID debe ser un número válido", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 1. Obtener conexión de tu clase cn
                var conexion = cn.AbrirConexion();

                // 2. Preparar consulta SQL
                string query = "INSERT INTO Repartidor (Id_repartidor, Nombre) VALUES (@IdRepartidor, @Nombre)";

                // 3. Crear y ejecutar comando
                var comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdRepartidor", idRepartidor);
                comando.Parameters.AddWithValue("@Nombre", TxtNombre.Text.Trim());

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Repartidor agregado correctamente", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarRepartidores(); // Refrescar DataGridView

                    // Limpiar campos
                    Txtid_repartidor.Text = "";
                    TxtNombre.Text = "";
                    Txtid_repartidor.Focus();
                }
            }
            catch (SqlException ex) when (ex.Number == 2627) // Violación de clave primaria (ID duplicado)
            {
                MessageBox.Show("El ID de repartidor ya existe", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar repartidor: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.CerrarConexion(); // Cierre seguro
            }
        }

        private void BttEliminarRep_Click(object sender, EventArgs e)
        {
            if (DtgRepartidores.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un repartidor para eliminar", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idRepartidor = Convert.ToInt32(DtgRepartidores.SelectedRows[0].Cells["Id_repartidor"].Value);
            string nombreRepartidor = DtgRepartidores.SelectedRows[0].Cells["Nombre"].Value.ToString();

            if (MessageBox.Show($"¿Está seguro de eliminar al repartidor {nombreRepartidor}?", "Confirmar",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // 1. Obtener conexión de tu clase cn
                    var conexion = cn.AbrirConexion();

                    // 2. Preparar consulta SQL
                    string query = "DELETE FROM Repartidor WHERE Id_repartidor = @IdRepartidor";

                    // 3. Crear y ejecutar comando
                    var comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@IdRepartidor", idRepartidor);

                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        MessageBox.Show("Repartidor eliminado correctamente", "Éxito",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarRepartidores(); // Refrescar el DataGridView
                    }
                }
                catch (SqlException ex) when (ex.Number == 547) // Error de integridad referencial
                {
                    MessageBox.Show("No se puede eliminar el repartidor porque tiene pedidos asignados",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar repartidor: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cn.CerrarConexion(); // Cierre seguro
                }
            }
        }




        private void CargarRepartidores()
        {
            try
            {
                // Abrir conexión usando tu clase cn
                var conexion = cn.AbrirConexion();

                string query = "SELECT Id_repartidor, Nombre FROM Repartidor ORDER BY Nombre";

                // Crear DataTable manualmente
                DataTable dt = new DataTable();
                dt.Columns.Add("Id_repartidor", typeof(int));
                dt.Columns.Add("Nombre", typeof(string));

                // Ejecutar consulta con DataReader
                var comando = new SqlCommand(query, conexion);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dt.Rows.Add(
                            reader.GetInt32(0),    // Id_repartidor
                            reader.GetString(1)    // Nombre
                        );
                    }
                }

                // Asignar datos al DataGridView
                DtgRepartidores.DataSource = dt;
                DtgRepartidores.Columns["Id_repartidor"].HeaderText = "ID Repartidor";
                DtgRepartidores.Columns["Nombre"].HeaderText = "Nombre Completo";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar repartidores: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cn.CerrarConexion();
            }
        }

    }
}
