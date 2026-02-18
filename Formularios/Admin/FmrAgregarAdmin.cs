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
    public partial class FmrAgregarAdmin: Form
    {

        cConexiones cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;

        public FmrAgregarAdmin()
        {
            InitializeComponent();
            cn = new cConexiones();
        }


        private void BttAgregarAdm_Click(object sender, EventArgs e)
        {

            // Obtener valores de los controles
            string usuario = Txtusuario.Text;
            string contraseña = Txtcontrasena.Text;

            // Validar que el ID sea un número válido
            if (!int.TryParse(Txtid_admin.Text, out int idAdmin) || idAdmin <= 0)
            {
                MessageBox.Show("Ingrese un ID válido (número positivo)", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Complete todos los campos obligatorios", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmar con el usuario
            DialogResult confirmacion = MessageBox.Show(
                $"¿Agregar nuevo administrador?\n\nID: {idAdmin}\nUsuario: {usuario}",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // Intentar agregar el administrador
                if (AgregarAdministrador(usuario, contraseña, idAdmin))
                {
                    // Si se agregó correctamente:
                    CargarAdministradores(dataGridViewAdmins); // Actualizar el listado

                }
            }

        }
        



        private void FmrAgregarAdmin_Load(object sender, EventArgs e)
        {
            CargarAdministradores(dataGridViewAdmins);

        }


        public void CargarAdministradores(DataGridView dgvAdmins)
        {
            DataTable dt = new DataTable();

            try
            {
                // Usar la conexión de tu objeto cn
                SqlConnection conexion = cn.AbrirConexion();
                string query = @"
            SELECT 
                Id_Admin AS [ID],
                Usuario AS [Nombre de Usuario],
                Contraseña AS [Contraseña]
            FROM Administrador
            ORDER BY Usuario";

                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataAdapter adapter = new SqlDataAdapter(comando);
                adapter.Fill(dt);

                dgvAdmins.DataSource = dt;

                // Configurar el DataGridView
                dgvAdmins.Columns["ID"].Width = 50;
                dgvAdmins.Columns["Nombre de Usuario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvAdmins.Columns["Contraseña"].Width = 150;
                dgvAdmins.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
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
                // Cerrar conexión usando tu objeto cn
                cn.CerrarConexion();
            }
        }

        public bool AgregarAdministrador(string usuario, string contraseña, int idAdmin)
        {
            bool resultado = false;

            try
            {
                // Validación de campos
                if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
                {
                    MessageBox.Show("Debe completar todos los campos", "Advertencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (idAdmin <= 0)
                {
                    MessageBox.Show("El ID de administrador debe ser un número positivo", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Usar la conexión de tu objeto cn
                SqlConnection conexion = cn.AbrirConexion();
                string query = @"
            INSERT INTO Administrador 
            (Id_Admin, Usuario, Contraseña) 
            VALUES 
            (@IdAdmin, @Usuario, @Contraseña)";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdAdmin", idAdmin);
                comando.Parameters.AddWithValue("@Usuario", usuario.Trim());
                comando.Parameters.AddWithValue("@Contraseña", contraseña.Trim());

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show($"Administrador {usuario} con ID {idAdmin} agregado exitosamente",
                                  "Éxito",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    resultado = true;
                }
            }
            catch (SqlException ex) when (ex.Number == 2627) // Violación de clave única
            {
                if (ex.Message.Contains("PK_Administrador"))
                {
                    MessageBox.Show($"El ID {idAdmin} ya está en uso", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("El nombre de usuario ya existe", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Cerrar conexión usando tu objeto cn
                cn.CerrarConexion();
            }

            return resultado;
        }

        public bool EliminarAdministrador(int idAdmin)
        {
            bool resultado = false;

            try
            {
                // Usar la conexión de tu objeto cn
                SqlConnection conexion = cn.AbrirConexion();
                string query = "DELETE FROM Administrador WHERE Id_Admin = @IdAdmin";

                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@IdAdmin", idAdmin);

                int filasAfectadas = comando.ExecuteNonQuery();

                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Administrador eliminado correctamente", "Éxito",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resultado = true;
                }
                else
                {
                    MessageBox.Show("No se encontró el administrador especificado", "Advertencia",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cerrar conexión usando tu objeto cn
                cn.CerrarConexion();
            }

            return resultado;
        }


     

        private void BttRefrescar_Click(object sender, EventArgs e)
        {
        }

       

        private void BttEliminarAdm_Click(object sender, EventArgs e)
        {

            if (dataGridViewAdmins.SelectedRows.Count > 0)
            {
                int idAdmin = Convert.ToInt32(dataGridViewAdmins.SelectedRows[0].Cells["ID"].Value);
                string nombreAdmin = dataGridViewAdmins.SelectedRows[0].Cells["Nombre de Usuario"].Value.ToString();

                if (MessageBox.Show($"¿Está seguro de eliminar al administrador {nombreAdmin}?",
                                  "Confirmar Eliminación",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (EliminarAdministrador(idAdmin))
                    {
                        CargarAdministradores(dataGridViewAdmins);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un administrador para eliminar", "Advertencia",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void BttCancelar_Click(object sender, EventArgs e)
        {

        }



    }
}
