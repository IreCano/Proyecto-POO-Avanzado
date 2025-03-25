using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoPOOAvanzado.conexion
{
    internal class ClaseConexionDB
    {
        private string configuracionConexion ="Server=mysql.r4sp1.duckdns.org;User=root;Password=rootpassword;Database=sistemapos";

        public MySqlConnection EjecutarConexion()
        {

            MySqlConnection mySqlConnection = new MySqlConnection(this.configuracionConexion);
            mySqlConnection.Open();
            return mySqlConnection;
        }
            
    }
}
