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



    public partial class FmrLogInCliente: Form
    {


        cConexiones cn;
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;
        int contador;

        public FmrLogInCliente()
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
            string correo = Txtcorreo.Text.Trim();
            string nombre = txtnombre.Text.Trim();

            if (!int.TryParse(TxtIdCliente.Text.Trim(), out int idCliente))
            {
                MostrarMensaje("La cédula debe ser un número válido", Color.Red);
                TxtIdCliente.Focus();
                return;
            }

            if (ValidarCliente(correo, nombre, idCliente))
            {
                // Almacenar datos en el contenedor
                DatosCliente.Nombre = nombre;
                DatosCliente.Cedula = idCliente;

                this.Hide();
                Form clienteForm = new FmrCliente();
                clienteForm.FormClosed += (s, args) => this.Close();
                clienteForm.Show();
            }
            else
            {
                MostrarMensaje("Credenciales incorrectas", Color.Red);
            }
        }

        private void MostrarMensaje(string mensaje, Color color)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form fmrSingin = new FmrSingInCliente();
            fmrSingin.Show();
        }

        private void FmrLogInCliente_Load(object sender, EventArgs e)
        {

        }

        private bool ValidarCliente(string correo, string nombre, int idCliente) 
        {
            try
            {
                SqlConnection conexion = cn.AbrirConexion();
                string query = @"SELECT 1 FROM Cliente 
                       WHERE Correo = @Correo 
                       AND Nombre = @Nombre
                       AND Id_cliente = @IdCliente"; 

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Correo", correo);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@IdCliente", idCliente);  

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
            catch (SqlException ex)
            {
                MostrarMensaje("Error al verificar en la base de datos", Color.Red);
                return false;
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error inesperado: {ex.Message}", Color.Red);
                return false;
            }
        }


    }
    public static class DatosCliente
    {
        public static string Nombre { get; set; }
        public static int Cedula { get; set; }
        public static void LimpiarDatos()
        {
            Nombre = null;
            Cedula = 0;

        }
    }
}
