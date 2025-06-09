using System;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Perfumeria
{
    public partial class ProductosVentana : Form
    {

        private string connectionString = "Server=localhost;Database=Perfumeria;User ID=root;Password=;SslMode=none;";
        public ProductosVentana()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Iniciar en pantalla completa
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_producto, nombre_producto, descripcion, cantidad, precio_compra, precio_venta FROM Productos";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        productosTabla.DataSource = dt;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buscarButton_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string texto = buscarTextbox.Text.Trim();

                    string query;

                    if (string.IsNullOrWhiteSpace(texto))
                    {
                        query = "SELECT * FROM PRODUCTOS";
                    }
                    else
                    {
                        query = "SELECT * FROM PRODUCTOS WHERE nombre_producto LIKE @texto OR descripcion LIKE @texto";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(texto))
                        {
                            cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
                        }


                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            productosTabla.DataSource = dt;
                            productosTabla.Refresh();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void guardarButton_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                string nombre = nombreTextBox.Text;
                string desc = descTextbox.Text;
                int piezas = int.Parse(piezasTextbox.Text.Trim());
                double compra = double.Parse(compraTextbox.Text.Trim());
                double venta = double.Parse(ventaTextbox.Text.Trim());

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(desc) || piezas <= 0 || compra <= 0 || venta <= 0)
                {
                    MessageBox.Show("Por favor, complete todos los campos correctamente.");
                    return;
                }

                string query = "INSERT INTO PRODUCTOS (nombre_producto, descripcion, cantidad, precio_compra, precio_venta) " +
                          "VALUES (@nombre, @desc, @piezas, @compra, @venta)";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@desc", desc);
                        cmd.Parameters.AddWithValue("@piezas", piezas);
                        cmd.Parameters.AddWithValue("@compra", compra);
                        cmd.Parameters.AddWithValue("@venta", venta);


                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Producto guardado correctamente.");
                            productosTabla.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Hubo un problema al guardar el producto.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ProductosVentana_Load(object sender, EventArgs e)
        {

        }
    }
}
