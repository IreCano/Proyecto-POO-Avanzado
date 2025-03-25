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
using MySql.Data.MySqlClient;
using ProyectoPOOAvanzado.conexion;
using ProyectoPOOAvanzado.CRUD;

namespace ProyectoPOOAvanzado
{
    public partial class formGestionVentas : Form
    {

        //OBTENEMOS LOS DATOS AL MOMENTO DE CARGAR EL FORMULARIO EN LA EJECUCION
        public formGestionVentas()
        {
            InitializeComponent();
            ClaseCrud crud = new ClaseCrud();
            dtgClientes.DataSource = crud.index("clientes");
        }
        private void btnConexionBd_Click(object sender, EventArgs e)
        {
            string CadenaConexion = "Server=mysql.r4sp1.duckdns.org;User=root;Password=rootpassword;Database=sistemapos";
            MySqlConnection variableConexion = new MySqlConnection(CadenaConexion);
            try
            {
                variableConexion.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Conectarse a la Base de Datos" + ex.Message);
                return;
            }
            variableConexion.Close();
            MessageBox.Show("Conectado Exitosamente a la Base de Datos");
        }

        //INSERTAMOS LOS DATOS Y REFRESCAMOS EL DATAGRIDVIEW
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            ClaseCrud crud = new ClaseCrud();
            crud.store(txtCedula.Text, txtPrimerNombre.Text, txtSegundoNombre.Text, txtPrimerApellido.Text, txtSegundoApellido.Text);
            dtgClientes.DataSource = crud.index("clientes");
            dtgClientes.Refresh();
        }

        private void dtgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = dtgClientes.CurrentRow.Cells["cedula"].Value.ToString();
                MessageBox.Show(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); return;
            }
        }
    }
}
