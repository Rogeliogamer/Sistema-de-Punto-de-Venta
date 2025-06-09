using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WinFormsApp1.Clases
{
    public class ConexionDB
    {
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conectar = null;
            try
            {
                conectar = new MySqlConnection("server=127.0.0.1; database=puntoventa; Uid=root; pwd=0309;");
                conectar.Open();
                MessageBox.Show("Conexión exitosa");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}");
            }
            return conectar;
        }
    }
}
