using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimercados_Unidos.Claases
{
    internal class cConexiones
    {

        //se define la ruta de la base de datos
        static private String CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\IUE U\POO\PROYECTO POO V0.3\MINIMERCADOS_UNIDOS\MINIMERCADOS_UNIDOS\MINIMERCADOS_UNIDOS\DATABASE1.MDF;Integrated Security=True;Connect Timeout=30";

        //Definir una variable para cargar la base de datos
        private SqlConnection Conexion = new SqlConnection(CadenaConexion);

        //metodo para abrir la base de datos
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open(); ;
            return Conexion;
        }
        //metodo para cerrar la base de datos
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close(); ;
            return Conexion;
        }

    }
}
