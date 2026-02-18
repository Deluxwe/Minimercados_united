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

namespace Minimercados_Unidos.Formularios.LogIn
{
    public partial class FmrSingInCliente: Form
    {

        cConexiones cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;
        int contador;

        public FmrSingInCliente()
        {
            InitializeComponent();
            cn = new cConexiones();
        }

        private void BttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttRegistrarse_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(TxtId_cliente.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(Txt_correo.Text) ||
                string.IsNullOrWhiteSpace(Txt_direccion.Text))
            {
                MostrarMensaje("Todos los campos son obligatorios", Color.Red);
                return;
            }

            // Validar que el ID sea numérico
            if (!int.TryParse(TxtId_cliente.Text, out int idCliente))
            {
                MostrarMensaje("El ID debe ser un número entero", Color.Red);
                TxtId_cliente.Focus();
                return;
            }

            try
            {
                SqlConnection conexion = cn.AbrirConexion();

                string query = @"INSERT INTO Cliente 
                        (Id_cliente, Nombre, Correo, Direccion) 
                        VALUES 
                        (@Id_cliente, @Nombre, @Correo, @Direccion)";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    // Parámetros convertidos al tipo correcto
                    comando.Parameters.AddWithValue("@Id_cliente", idCliente); // Ahora es int
                    comando.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    comando.Parameters.AddWithValue("@Correo", Txt_correo.Text);
                    comando.Parameters.AddWithValue("@Direccion", Txt_direccion.Text);

                    int resultado = comando.ExecuteNonQuery();

                    if (resultado > 0)
                    {
                        MostrarMensaje("Cliente registrado exitosamente", Color.Green);
                        LimpiarCampos();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    MostrarMensaje("El ID de cliente ya existe", Color.Red);
                }
                else
                {
                    MostrarMensaje($"Error de base de datos: {ex.Message}", Color.Red);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error: {ex.Message}", Color.Red);
            }
            finally
            {
                cn.CerrarConexion();
            }
        }


        private void MostrarMensaje(string mensaje, Color color)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;

            // Opcional: Ocultar el mensaje después de 5 segundos
            Timer timer = new Timer();
            timer.Interval = 5000; // 5 segundos
            timer.Tick += (s, e) => {
                lblMensaje.Text = "";
                timer.Stop();
            };
            timer.Start();
        }

        private void LimpiarCampos()
        {
            TxtId_cliente.Text = "";
            txtNombre.Text = "";
            Txt_correo.Text = "";
            Txt_direccion.Text = "";
            TxtId_cliente.Focus();
        }

        private void FmrSingInCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
