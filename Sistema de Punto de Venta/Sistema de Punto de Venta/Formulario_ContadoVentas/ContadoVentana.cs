using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perfumeria
{
    public partial class ContadoVentana : Form
    {
        private string connectionString = "Server=localhost;Database=Perfumeria;User ID=root;Password=;SslMode=none;";
        public ContadoVentana()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Iniciar en pantalla completa
            CargarProductos();
            CargarClientes();
        }

        private void CargarProductos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT nombre_producto, descripcion, cantidad, precio_venta FROM Productos";
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

        private void CargarClientes()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT nombre, apellido_paterno, apellido_materno, estado, colonia, calle, numero_exterior, telefono FROM CLIENTES";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        clientesTabla.DataSource = dt;
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
                    string texto = productosTextbox.Text.Trim();

                    string query;

                    if (string.IsNullOrWhiteSpace(texto))
                    {
                        query = "SELECT nombre_producto, descripcion, cantidad, precio_venta FROM PRODUCTOS";
                    }
                    else
                    {
                        query = "SELECT nombre_producto, descripcion, cantidad, precio_venta FROM PRODUCTOS WHERE nombre_producto LIKE @texto OR descripcion LIKE @texto";
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

        private void clientesButton_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string texto = buscarClienteTextbox.Text.Trim();

                    string query;

                    if (string.IsNullOrWhiteSpace(texto))
                    {
                        query = "SELECT nombre, apellido_paterno, apellido_materno, estado, colonia, calle, numero_exterior, telefono FROM CLIENTES";
                    }
                    else
                    {
                        query = "SELECT nombre, apellido_paterno, apellido_materno, estado, colonia, calle, numero_exterior, telefono FROM CLIENTES WHERE nombre LIKE @texto OR apellido_paterno LIKE @texto OR apellido_materno LIKE @texto";
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
                            clientesTabla.DataSource = dt;
                            clientesTabla.Refresh();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void productosTabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow filaSeleccionada = productosTabla.Rows[e.RowIndex];

                string nombre = filaSeleccionada.Cells["nombre_producto"].Value.ToString();
                string desc = filaSeleccionada.Cells["descripcion"].Value.ToString();
                decimal venta = Convert.ToDecimal(filaSeleccionada.Cells["precio_venta"].Value);

                bool productoExiste = false;


                foreach (DataGridViewRow row in carritoTabla.Rows)
                {
                    if (row.Cells["nombre"].Value != null && row.Cells["nombre"].Value.ToString() == nombre)
                    {
                        int cantidadActual = Convert.ToInt32(row.Cells["cantidad"].Value);
                        row.Cells["cantidad"].Value = cantidadActual + 1;
                        productoExiste = true;
                        break;
                    }
                }


                if (!productoExiste)
                {
                    carritoTabla.Rows.Add(nombre, desc, 1, venta);
                }

                ActualizarTotal();
            }
        }

        private void borrarButton_MouseClick(object sender, MouseEventArgs e)
        {
            string productoABorrar = borrarTextbox.Text.Trim();

            if (!string.IsNullOrWhiteSpace(productoABorrar))
            {
                bool encontrado = false;


                foreach (DataGridViewRow row in carritoTabla.Rows)
                {
                    if (row.Cells["nombre"].Value != null && row.Cells["nombre"].Value.ToString().Equals(productoABorrar, StringComparison.OrdinalIgnoreCase))
                    {
                        carritoTabla.Rows.Remove(row);
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    MessageBox.Show("El producto no se encuentra en el carrito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de producto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            double total = 0;

            foreach (DataGridViewRow row in carritoTabla.Rows)
            {
                if (row.Cells["cantidad"].Value != null && row.Cells["precio"].Value != null)
                {
                    int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);
                    double precio = Convert.ToDouble(row.Cells["precio"].Value);
                    total += cantidad * precio;
                }
            }

            totalTextbox.Text = total.ToString("F2");
        }

        private void ventaButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (carritoTabla.Rows.Count == 1)
            {
                MessageBox.Show("El carrito está vacío. Agrega productos antes de finalizar la compra.");
                return;
            }

            
            if (clientesTabla.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un cliente antes de finalizar la compra.");
                return;
            }

            
            DataGridViewRow filaCliente = clientesTabla.SelectedRows[0];
            string nombre = filaCliente.Cells["nombre"].Value.ToString();
            string apellidoPaterno = filaCliente.Cells["apellido_paterno"].Value.ToString();
            string apellidoMaterno = filaCliente.Cells["apellido_materno"].Value.ToString();
            string estado = filaCliente.Cells["estado"].Value.ToString();
            string colonia = filaCliente.Cells["colonia"].Value.ToString();
            string calle = filaCliente.Cells["calle"].Value.ToString();
            string numeroExterior = filaCliente.Cells["numero_exterior"].Value.ToString();
            string telefono = filaCliente.Cells["telefono"].Value.ToString();

            string clienteInfo = $"{nombre} {apellidoPaterno} {apellidoMaterno}\n" +
                                 $" Dirección: {calle}, {colonia}, {estado}, No. {numeroExterior}\n" +
                                 $" Teléfono: {telefono}";

            
            string folioVenta = "VENTA_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

           
            string fechaVenta = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            
            string totalVenta = totalTextbox.Text;

            
            StringBuilder ticket = new StringBuilder();
            ticket.AppendLine("===== TICKET DE COMPRA =====");
            ticket.AppendLine("Folio: " + folioVenta);
            ticket.AppendLine("Fecha: " + fechaVenta);
            ticket.AppendLine("============================");
            ticket.AppendLine("Cliente:");
            ticket.AppendLine(clienteInfo);
            ticket.AppendLine("============================");
            ticket.AppendLine("Productos:");

            foreach (DataGridViewRow row in carritoTabla.Rows)
            {
                if (row.Cells["nombre"].Value != null && row.Cells["cantidad"].Value != null && row.Cells["precio"].Value != null)
                {
                    string nombreProducto = row.Cells["nombre"].Value.ToString();
                    int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);
                    double precio = Convert.ToDouble(row.Cells["precio"].Value);
                    double subtotal = cantidad * precio;

                    ticket.AppendLine($"{nombreProducto} - {cantidad} x {precio:C} = {subtotal:C}");
                }
            }

            ticket.AppendLine("============================");
            ticket.AppendLine("TOTAL: " + totalVenta);
            ticket.AppendLine("============================");

            
            ticketTextbox.Text = ticket.ToString();

            ActualizarInventario();
            
            string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), folioVenta + ".txt");
            File.WriteAllText(rutaArchivo, ticket.ToString());

            
            carritoTabla.Rows.Clear();
            totalTextbox.Text = "0.00";

            MessageBox.Show("Venta finalizada. Ticket generado en: " + rutaArchivo, "Venta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ActualizarInventario()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in carritoTabla.Rows)
                    {
                        if (row.Cells["nombre"].Value != null && row.Cells["cantidad"].Value != null)
                        {
                            string nombreProducto = row.Cells["nombre"].Value.ToString();
                            int cantidadVendida = Convert.ToInt32(row.Cells["cantidad"].Value);

                            // Obtener el ID del producto por nombre
                            string getIdQuery = "SELECT id_producto FROM Productos WHERE nombre_producto = @nombre";
                            int idProducto = 0;

                            using (MySqlCommand cmd = new MySqlCommand(getIdQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@nombre", nombreProducto);
                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        idProducto = reader.GetInt32("id_producto");
                                    }
                                }
                            }

                            if (idProducto > 0)
                            {
                                // Actualizar la cantidad del producto en el inventario
                                string updateQuery = "UPDATE Productos SET cantidad = cantidad - @cantidad WHERE id_producto = @id";

                                using (MySqlCommand cmdUpdate = new MySqlCommand(updateQuery, conn))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@cantidad", cantidadVendida);
                                    cmdUpdate.Parameters.AddWithValue("@id", idProducto);
                                    cmdUpdate.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar inventario: " + ex.Message);
            }
        }

        private void ContadoVentana_Load(object sender, EventArgs e)
        {

        }
    }
}
