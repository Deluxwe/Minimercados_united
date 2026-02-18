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
    public partial class FmrLogInDomiciliario : Form
    {



        cConexiones cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;
        int contador;

        public FmrLogInDomiciliario()
        {
            cn = new cConexiones();
            InitializeComponent();
        }

        private void bttVolver_Click(object sender, EventArgs e)
        {

            Form frmlogin = new FmrLogIn();
            frmlogin.Show();

            this.Hide();


        }

        private void BttEntrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();

            if (ValidarRepartidor(nombre))
            {
                Form repartidor = new FmrRepartidor();
                repartidor.Show();

                this.Close();
            }
            else
            {
                MostrarMensaje("Nombre no registrado", Color.Red);
                txtNombre.Focus();
            }
        }

        


        private bool ValidarRepartidor(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MostrarMensaje("Debe ingresar su nombre completo", Color.Red);
                return false;
            }

            try
            {
                // Abrimos la conexión directamente sin using
                SqlConnection conexion = cn.AbrirConexion();

                string query = "SELECT 1 FROM Repartidor WHERE Nombre = @Nombre";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", nombre);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
            catch (SqlException ex)
            {
                MostrarMensaje("Error al verificar en la base de datos: " + ex.Message, Color.Red);
                return false;
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error inesperado: " + ex.Message, Color.Red);
                return false;
            }
            finally
            {
                // Cerramos la conexión usando el método de tu clase Conexiones
                cn.CerrarConexion();
            }
        }

        private void FmrLogInDomiciliario_Load(object sender, EventArgs e)
        {

        }

        private void MostrarMensaje(string mensaje, Color color)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;
        }
    }
}
