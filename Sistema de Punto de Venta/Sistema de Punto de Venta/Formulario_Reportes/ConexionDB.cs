using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class ConexionDB
    {
        // Método estático para obtener una conexión a la base de datos
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = null;

            try
            {
                // Cadena de conexión a la base de datos
                string cadenaConexion = "Server=localhost;Database=Perfumeria;User ID=root;Password=;SslMode=none;";

                // Crear la conexión
                conectar = new MySqlConnection(cadenaConexion);

                // Abrir la conexión
                conectar.Open();
                // Mensaje de éxito(opcional)
                MessageBox.Show("Conexión exitosa");
            }
            catch (MySqlException ex)
            {
                // Manejo de errores
                MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}");
            }

            // Retornar la conexión
            return conectar;
        }
    }
}

