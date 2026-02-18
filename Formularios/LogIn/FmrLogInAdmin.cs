using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Minimercados_Unidos.Claases;

namespace Minimercados_Unidos.Formularios.LogIn
{
    public partial class FmrLogInAdmin : Form
    {

        cConexiones cn; //crear objeto de cConexion
        SqlDataAdapter da;
        SqlCommand cmd, comd;
        DataTable dt;
        int contador;
        public FmrLogInAdmin()
        {
            InitializeComponent();
            cn = new cConexiones();
        }

        private void FmrLogInAdmin_Load(object sender, EventArgs e)
        {
            TxtContrasena.PasswordChar = '*'; // Mostrar asteriscos en lugar del texto
        }



        private void BttEntrar_Click(object sender, EventArgs e)
        {

            string usuario = txtUsuario.Text.Trim();
            string contraseña = TxtContrasena.Text;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MostrarMensaje("Debe ingresar usuario y contraseña", Color.Red);
                return;
            }

            if (AutenticarUsuario(usuario, contraseña))
            {
                Form fmradmi = new fmrAdmin();
                fmradmi.Show();
                this.Hide();
            }
            else
            {
                MostrarMensaje("Usuario o contraseña incorrectos", Color.Red);
                TxtContrasena.Clear();
                txtUsuario.Focus();
            }
        }



        private bool AutenticarUsuario(string usuario, string contraseña)
        {
            Debug.WriteLine("Iniciando autenticación...");
            Debug.WriteLine($"Usuario: {usuario}, Contraseña: {contraseña}");

            try
            {
                // Abre la conexión usando tu clase Conexiones (cn)
                var conexion = cn.AbrirConexion();
                Debug.WriteLine($"Estado conexión: {conexion.State}");

                string query = "SELECT COUNT(*) FROM Administrador WHERE usuario = @usuario AND contraseña = @contraseña";
                Debug.WriteLine($"Query: {query}");

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@contraseña", contraseña);

                    int count = (int)comando.ExecuteScalar();
                    Debug.WriteLine($"Resultado count: {count}");

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.ToString()}");
                MostrarMensaje("Error al verificar credenciales", Color.Red);
                return false;
            }
            finally
            {
                // Cierra la conexión usando tu clase Conexiones (cn)
                cn.CerrarConexion();
                Debug.WriteLine("Conexión cerrada");
            }
        }

        private void MostrarMensaje(string mensaje, Color color)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = color;
        }

        private void BttCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            TxtContrasena.Clear();
            lblMensaje.Text = "";
            txtUsuario.Focus();
        }

        private void bttVolver_Click(object sender, EventArgs e)
        {
            Form frmlogin = new FmrLogIn();
            frmlogin.Show();

            this.Hide();

        }

        private void TxtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BttEntrar_Click(sender, e);
            }
        }
    }
}
