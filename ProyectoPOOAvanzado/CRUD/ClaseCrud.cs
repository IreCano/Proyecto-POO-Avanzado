using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ProyectoPOOAvanzado.conexion;

namespace ProyectoPOOAvanzado.CRUD
{
    internal class ClaseCrud
    {
        // traer datos de la base de datos
        public DataTable index(string table)
        {
            ClaseConexionDB conexion = new ClaseConexionDB();

            string query = "SELECT * FROM " + table + " order by id desc;";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion.EjecutarConexion());

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            return dt;

        }

        //insertar en base de datos
        public void store(string cedula, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido)
        {
            ClaseConexionDB mysqlConnection = new ClaseConexionDB();

            MySqlConnection abrirConexion = mysqlConnection.EjecutarConexion();

            string Query = "INSERT INTO `sistemapos`.`clientes`(" +
                "`cedula`," +
                "`nombre_1`," +
                "`nombre_2`," +
                "`apellido_1`," +
                "`apellido_2`" +
                ") VALUES ('" 
                + cedula + "', '" 
                + primerNombre + "', '" 
                + segundoNombre + "' , '" 
                + primerApellido + "' , '" 
                + segundoApellido + "')";

            MySqlCommand mySqlCommand = new MySqlCommand(Query, abrirConexion);

            mySqlCommand.ExecuteNonQuery();
        }

        public void update(int id, string cedula, string primerNombre, string segundoNombre, string primerApellido, string segundoApellido)
        {
            ClaseConexionDB mysqlConnection = new ClaseConexionDB();

            MySqlConnection abrirConexion = mysqlConnection.EjecutarConexion();

            string Query = "UPDATE `sistemapos`.`clientes` SET `cedula` = '" + cedula + "', `nombre_1` = '" + primerNombre + "', `nombre_2` = '" + segundoNombre + "', `apellido_1` = '" + primerApellido + "', `apellido_2` = '" + segundoApellido + "' WHERE `id` = " + id + ";";

            MySqlCommand mySqlCommand = new MySqlCommand(Query, abrirConexion);

            mySqlCommand.ExecuteNonQuery();
        }

        //public destroy()
        //{

        //}
    }
}
