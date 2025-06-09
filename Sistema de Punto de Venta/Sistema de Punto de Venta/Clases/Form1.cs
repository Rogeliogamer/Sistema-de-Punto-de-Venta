using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Clases;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // Lista para almacenar los productos del carrito
        List<Producto> carrito = new List<Producto>();

        public Form1()
        {
            InitializeComponent();
            //Inicializamos datagrid de productos
            MostrarProductos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarTodosLosTickets();
            CargarTickets();
            CargarProductos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        /**
         * Para devolver producto
         */
        private void button4_Click(object sender, EventArgs e)
        {

            // Validar que los TextBox no estén vacíos
            if (string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5Idticket.Text))
            {
                MessageBox.Show("Por favor, ingresa el ID del producto y el ID del ticket.");
                return;
            }

            int idProducto = Convert.ToInt32(textBox4.Text);
            int idTicket = Convert.ToInt32(textBox5Idticket.Text);

            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();
                MySqlTransaction transaccion = conexion.BeginTransaction();
                try
                {
                    // Obtener la cantidad del producto en el ticket específico
                    string queryCantidad = @"SELECT cantidad 
                                     FROM detalle_tickets 
                                     WHERE id_ticket = @idTicket AND id_producto = @idProducto 
                                     LIMIT 1";

                    MySqlCommand comandoCantidad = new MySqlCommand(queryCantidad, conexion, transaccion);
                    comandoCantidad.Parameters.AddWithValue("@idTicket", idTicket);
                    comandoCantidad.Parameters.AddWithValue("@idProducto", idProducto);

                    object resultado = comandoCantidad.ExecuteScalar();
                    if (resultado == null)
                    {
                        MessageBox.Show("El producto no se encuentra en el ticket especificado.");
                        return;
                    }

                    int cantidadDevuelta = Convert.ToInt32(resultado);

                    // Eliminar el producto del detalle del ticket específico
                    string queryEliminar = @"DELETE FROM detalle_tickets 
                                     WHERE id_ticket = @idTicket AND id_producto = @idProducto 
                                     LIMIT 1";

                    MySqlCommand comandoEliminar = new MySqlCommand(queryEliminar, conexion, transaccion);
                    comandoEliminar.Parameters.AddWithValue("@idTicket", idTicket);
                    comandoEliminar.Parameters.AddWithValue("@idProducto", idProducto);
                    comandoEliminar.ExecuteNonQuery();

                    // Devolver la cantidad al inventario solo del producto específico
                    string queryActualizarInventario = @"UPDATE productos 
                                                 SET cantidad = cantidad + @cantidad 
                                                 WHERE id_producto = @idProducto 
                                                 LIMIT 1";

                    MySqlCommand comandoActualizarInventario = new MySqlCommand(queryActualizarInventario, conexion, transaccion);
                    comandoActualizarInventario.Parameters.AddWithValue("@cantidad", cantidadDevuelta);
                    comandoActualizarInventario.Parameters.AddWithValue("@idProducto", idProducto);
                    comandoActualizarInventario.ExecuteNonQuery();

                    // Confirmar la transacción
                    transaccion.Commit();

                    MessageBox.Show("¡Producto devuelto al inventario y eliminado del ticket!");
                }
                catch (Exception ex)
                {
                    // Revertir la transacción en caso de error
                    transaccion.Rollback();
                    MessageBox.Show($"Error al devolver el producto: {ex.Message}");
                }
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        //Consulta del cliente
        private void button2_Click(object sender, EventArgs e)
        {
            string nombre = textName.Text.Trim();
            string apellidoPaterno = textLastname1.Text.Trim();
            string apellidoMaterno = textLastname2.Text.Trim();

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidoPaterno) || string.IsNullOrEmpty(apellidoMaterno))
            {
                MessageBox.Show("Por favor, ingresa todos los campos.");
                return;
            }

            // Realiza la búsqueda en la base de datos
            BuscarCliente(nombre, apellidoPaterno, apellidoMaterno);
        }

        // Método para buscar al cliente en la base de datos
        private void BuscarCliente(string nombre, string apellidoPaterno, string apellidoMaterno)
        {
            // Conexión a la base de datos
            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = @"SELECT * 
                                     FROM Clientes 
                                     WHERE nombre = @nombre 
                                     AND apellido_paterno = @apellidoPaterno 
                                     AND apellido_materno = @apellidoMaterno";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.Parameters.AddWithValue("@apellidoPaterno", apellidoPaterno);
                    comando.Parameters.AddWithValue("@apellidoMaterno", apellidoMaterno);

                    MySqlDataReader reader = comando.ExecuteReader();
                    var tabla = new System.Data.DataTable();
                    tabla.Load(reader);

                    // Muestra los resultados en el DataGridView
                    dataGridView4.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar en la base de datos: {ex.Message}");
                }
            }
        }

        // Método para agregar productos al carrito
        private void AgregarAlCarrito(int idProducto, string nombre, string descripcion, int cantidad, decimal precio)
        {
            // Verificar que la cantidad sea mayor a cero
            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.");
                return;
            }

            // Crear un nuevo producto con los datos seleccionados
            Producto producto = new Producto()
            {
                Id = idProducto,
                Nombre = nombre,
                Descripcion = descripcion,
                Cantidad = cantidad,
                Precio = precio
            };

            // Agregar el producto a la lista del carrito
            carrito.Add(producto);

            // Actualizar el DataGridView del carrito
            dataGridViewCarrito.DataSource = null;
            dataGridViewCarrito.DataSource = carrito;

            // Llamar al método para calcular el total con IVA
            CalcularTotalConIVA();
        }

        // Método para calcular el total con IVA
        private void CalcularTotalConIVA()
        {
            // Inicializar el total en 0
            decimal total = 0;

            // Recorrer los productos en el carrito y calcular el total
            foreach (var producto in carrito)
            {
                total += producto.Precio * producto.Cantidad;
            }

            // Calcular el IVA (10% del total)
            decimal iva = total * 0.10m;
            decimal totalConIVA = total + iva;

            // Mostrar el total con IVA en el label6
            label6.Text = $"Muestra de Subtotal \n\n" +
                          $"Subtotal: ${total} \n" +
                          $"Total con IVA: ${totalConIVA:F2}";
        }

        //Carga de todos los tickets
        private void CargarTodosLosTickets()
        {
            // Cadena de conexión a la base de datos
            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT * FROM detalle_tickets";
                    MySqlCommand comando = new MySqlCommand(query, conexion);

                    MySqlDataReader reader = comando.ExecuteReader();
                    var tabla = new System.Data.DataTable();
                    tabla.Load(reader);

                    // Cargar los datos en el DataGridView
                    dataGridViewDescripcion.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los tickets: {ex.Message}");
                }
            }
        }

        private void CargarTickets()
        {
            // Cadena de conexión a la base de datos
            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT * FROM tickets";
                    MySqlCommand comando = new MySqlCommand(query, conexion);

                    MySqlDataReader reader = comando.ExecuteReader();
                    var tabla = new System.Data.DataTable();
                    tabla.Load(reader);

                    // Cargar los datos en el DataGridView
                    dataGridViewAnticipo.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los tickets: {ex.Message}");
                }
            }
        }
        //Filtra el cliente
        private void FiltrarClientes()
        {
            // Obtener los valores de los TextBox y eliminar espacios en blanco
            string nombre = textName.Text.Trim();
            string apellidoPaterno = textLastname1.Text.Trim();
            string apellidoMaterno = textLastname2.Text.Trim();

            // Conexión a la base de datos
            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();

                    // Construir la consulta SQL dinámica
                    string query = @"SELECT * 
                             FROM Clientes 
                             WHERE 1=1";  // Para facilitar el uso de AND posteriormente

                    // Agregar filtros según el contenido de los TextBox
                    if (!string.IsNullOrEmpty(nombre))
                    {
                        query += " AND nombre LIKE @nombre";
                    }
                    if (!string.IsNullOrEmpty(apellidoPaterno))
                    {
                        query += " AND apellido_paterno LIKE @apellidoPaterno";
                    }
                    if (!string.IsNullOrEmpty(apellidoMaterno))
                    {
                        query += " AND apellido_materno LIKE @apellidoMaterno";
                    }

                    MySqlCommand comando = new MySqlCommand(query, conexion);

                    // Añadir parámetros solo si no están vacíos
                    if (!string.IsNullOrEmpty(nombre))
                    {
                        comando.Parameters.AddWithValue("@nombre", "%" + nombre + "%");
                    }
                    if (!string.IsNullOrEmpty(apellidoPaterno))
                    {
                        comando.Parameters.AddWithValue("@apellidoPaterno", "%" + apellidoPaterno + "%");
                    }
                    if (!string.IsNullOrEmpty(apellidoMaterno))
                    {
                        comando.Parameters.AddWithValue("@apellidoMaterno", "%" + apellidoMaterno + "%");
                    }

                    MySqlDataReader reader = comando.ExecuteReader();
                    var tabla = new System.Data.DataTable();
                    tabla.Load(reader);

                    // Actualizar el DataGridView con los resultados filtrados
                    dataGridView4.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar en la base de datos: {ex.Message}");
                }
            }
        }


        //Metodo para ir filtando segun escribas en el textfield
        private void FiltrarTickets(string filtro)
        {
            // Cadena de conexión a la base de datos
            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    // Consulta que filtra por id_ticket
                    string query = @"SELECT * 
                             FROM detalle_tickets
                             WHERE id_ticket LIKE @filtro";

                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@filtro", $"%{filtro}%");

                    MySqlDataReader reader = comando.ExecuteReader();
                    var tabla = new System.Data.DataTable();
                    tabla.Load(reader);

                    // Mostrar los resultados filtrados en el DataGridView
                    dataGridViewDescripcion.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al filtrar los tickets: {ex.Message}");
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Muestra los productos existentes
        private void MostrarProductos()
        {
            // Conexión a la base de datos
            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    string query = "SELECT id_producto, nombre_producto, descripcion, cantidad, precio_venta FROM Productos";

                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    MySqlDataReader reader = comando.ExecuteReader();
                    var tabla = new System.Data.DataTable();
                    tabla.Load(reader);

                    // Muestra los resultados en el DataGridView
                    dataGridView1.DataSource = tabla;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error al obtener los productos: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}");
                }
            }
        }

        private void dataGridViewCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Boton para agregar al carrito
        private void button3_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView de productos
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener los datos de la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                int idProducto = Convert.ToInt32(filaSeleccionada.Cells["id_producto"].Value);
                string nombre = filaSeleccionada.Cells["nombre_producto"].Value.ToString();
                string descripcion = filaSeleccionada.Cells["descripcion"].Value.ToString();
                decimal precio = Convert.ToDecimal(filaSeleccionada.Cells["precio_venta"].Value);

                // Obtener la cantidad seleccionada en el NumericUpDown
                int cantidad = (int)numericUpDownCantidad.Value;

                // Verificar que la cantidad sea mayor a 0
                if (cantidad <= 0)
                {
                    MessageBox.Show("Por favor, selecciona una cantidad válida.");
                    return;
                }

                // Verificar el inventario antes de agregar al carrito
                if (VerificarInventario(idProducto, cantidad))
                {
                    // Agregar el producto al carrito con la cantidad seleccionada
                    AgregarAlCarrito(idProducto, nombre, descripcion, cantidad, precio);

                    // Disminuir la cantidad en el inventario
                    DisminuirInventario(idProducto, cantidad);

                    // Actualizar el DataGridView de productos
                    CargarProductos();
                }
                else
                {
                    MessageBox.Show("No hay suficiente stock disponible para este producto.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para agregar al carrito.");
            }
        }
        //Verifica existencia de producto para poder agregar al carrito
        private bool VerificarInventario(int idProducto, int cantidadSolicitada)
        {
            bool hayStock = false;
            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();
                string query = @"SELECT cantidad 
                         FROM Productos 
                         WHERE id_producto = @idProducto";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idProducto", idProducto);

                int cantidadDisponible = Convert.ToInt32(comando.ExecuteScalar());

                // Verificar si hay suficiente cantidad
                if (cantidadDisponible >= cantidadSolicitada)
                {
                    hayStock = true;
                }
            }
            return hayStock;
        }
        //Disminuye el producto aregado
        private void DisminuirInventario(int idProducto, int cantidadVendida)
        {
            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();
                string query = @"UPDATE Productos 
                         SET cantidad = cantidad - @cantidadVendida 
                         WHERE id_producto = @idProducto";
                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@cantidadVendida", cantidadVendida);
                comando.Parameters.AddWithValue("@idProducto", idProducto);

                comando.ExecuteNonQuery();
            }
        }
        // Método para cargar productos en el DataGridView
        private void CargarProductos()
        {
            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string queryProductos = @"SELECT 
                    id_producto, 
                    nombre_producto, 
                    descripcion, 
                    precio_venta AS precio_venta, 
                    cantidad 
                  FROM productos 
                  WHERE cantidad > 0";
                MySqlDataAdapter adaptador = new MySqlDataAdapter(queryProductos, conexion);
                DataTable dtProductos = new DataTable();
                adaptador.Fill(dtProductos);

                dataGridView1.DataSource = dtProductos;
            }
        }



        private void textBox5Idticket_TextChanged(object sender, EventArgs e)
        {

            string filtro = textBox5Idticket.Text.Trim();

            // Si el filtro está vacío, carga todos los tickets
            if (string.IsNullOrEmpty(filtro))
            {
                CargarTodosLosTickets();
            }
            else
            {
                // Si hay texto en el filtro, filtra los tickets
                FiltrarTickets(filtro);
            }


        }

        //Anticipo
        private void button5_Click(object sender, EventArgs e)
        {

            // 1. Validar que se haya ingresado el ID del ticket
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Por favor, ingresa un número de ticket.");
                return;
            }

            int idTicket;
            if (!int.TryParse(textBox1.Text.Trim(), out idTicket))
            {
                MessageBox.Show("El número de ticket debe ser un valor numérico.");
                return;
            }

            // 2. Obtener el anticipo (primer pago) desde numericUpDown2
            decimal anticipo = numericUpDown2.Value;
            if (anticipo <= 0)
            {
                MessageBox.Show("La cantidad de anticipo debe ser mayor a 0.");
                return;
            }

            // Variables para guardar datos que obtendremos de la tabla 'tickets'/'ventas'
            decimal montoTotal = 0;
            int idCliente = 0;

            // 3. Conexión a la base de datos
            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();
                MySqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    // -----------------------------------------------------------------
                    // 4. Consultar la tabla 'tickets' para obtener el monto_total
                    //    y, opcionalmente, el id_cliente (haciendo JOIN con 'ventas')
                    // -----------------------------------------------------------------
                    string queryTicket = @"
                SELECT v.id_cliente, t.monto_total
                FROM tickets t
                INNER JOIN ventas v ON t.id_venta = v.id_venta
                WHERE t.id_ticket = @idTicket
            ";

                    MySqlCommand cmdTicket = new MySqlCommand(queryTicket, conexion, transaccion);
                    cmdTicket.Parameters.AddWithValue("@idTicket", idTicket);

                    using (MySqlDataReader reader = cmdTicket.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show($"No se encontró un ticket con ID {idTicket}.");
                            transaccion.Rollback();
                            return;
                        }

                        // Leer los valores del ticket y la venta
                        if (reader.Read())
                        {
                            idCliente = reader.GetInt32("id_cliente");
                            montoTotal = reader.GetDecimal("monto_total");
                        }
                    }

                    // 5. Calcular lo que queda pendiente
                    decimal montoPendiente = montoTotal - anticipo;
                    if (montoPendiente < 0)
                    {
                        MessageBox.Show("El anticipo excede el monto total. Operación no válida.");
                        transaccion.Rollback();
                        return;
                    }

                    // -----------------------------------------------------------------
                    // 6. Insertar un nuevo registro en 'pagos'
                    // -----------------------------------------------------------------
                    string queryInsertPagos = @"
                INSERT INTO pagos 
                    (id_cliente, id_estado_pago, fecha_pago, monto_total, abono_inicial, monto_pendiente)
                VALUES 
                    (@idCliente, @idEstadoPago, NOW(), @montoTotal, @abonoInicial, @montoPendiente)
            ";

                    MySqlCommand cmdInsertPagos = new MySqlCommand(queryInsertPagos, conexion, transaccion);
                    cmdInsertPagos.Parameters.AddWithValue("@idCliente", idCliente);

                    // Ajusta el estado según tu lógica (ej. 2 = "Pago Parcial" o "En proceso")
                    cmdInsertPagos.Parameters.AddWithValue("@idEstadoPago", 2);

                    cmdInsertPagos.Parameters.AddWithValue("@montoTotal", montoTotal);
                    cmdInsertPagos.Parameters.AddWithValue("@abonoInicial", anticipo);
                    cmdInsertPagos.Parameters.AddWithValue("@montoPendiente", montoPendiente);

                    cmdInsertPagos.ExecuteNonQuery();

                    // -----------------------------------------------------------------
                    // 7. Actualizar el monto_total en la tabla 'tickets'
                    // -----------------------------------------------------------------
                    string queryUpdateTicket = @"
                UPDATE tickets 
                SET monto_total = @montoPendiente 
                WHERE id_ticket = @idTicket
            ";

                    MySqlCommand cmdUpdateTicket = new MySqlCommand(queryUpdateTicket, conexion, transaccion);
                    cmdUpdateTicket.Parameters.AddWithValue("@montoPendiente", montoPendiente);
                    cmdUpdateTicket.Parameters.AddWithValue("@idTicket", idTicket);

                    cmdUpdateTicket.ExecuteNonQuery();

                    // 8. Confirmar la transacción
                    transaccion.Commit();

                    MessageBox.Show("¡Primer pago registrado y monto del ticket actualizado correctamente!");
                }
                catch (Exception ex)
                {
                    // Revertir en caso de error
                    transaccion.Rollback();
                    MessageBox.Show("Error al registrar el primer pago: " + ex.Message);
                }
            }

        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void textLastname1_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void textLastname2_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }


        //**
        //
        //Creacion del ticket en txt
        //
        //
        private void GuardarTicketEnArchivo(long idTicket, decimal montoConIva, List<Producto> carrito)
        {
            // Ruta de la carpeta donde se guardarán los tickets
            string carpetaTickets = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tickets");

            // Crear la carpeta si no existe
            if (!Directory.Exists(carpetaTickets))
            {
                Directory.CreateDirectory(carpetaTickets);
            }

            // Ruta del archivo de ticket
            string rutaArchivo = Path.Combine(carpetaTickets, $"ticket_{idTicket}.txt");

            // Crear el contenido del ticket
            StringBuilder contenidoTicket = new StringBuilder();
            contenidoTicket.AppendLine("=== Ticket de Venta ===");
            contenidoTicket.AppendLine($"ID Ticket: {idTicket}");
            contenidoTicket.AppendLine($"Fecha: {DateTime.Now}");
            contenidoTicket.AppendLine($"Monto Total (IVA incluido): ${montoConIva:F2}");
            contenidoTicket.AppendLine();
            contenidoTicket.AppendLine("=== Productos ===");

            foreach (var producto in carrito)
            {
                contenidoTicket.AppendLine($"ID Producto: {producto.Id}");
                contenidoTicket.AppendLine($"Nombre: {producto.Nombre}");
                contenidoTicket.AppendLine($"Descripción: {producto.Descripcion}");
                contenidoTicket.AppendLine($"Cantidad: {producto.Cantidad}");
                contenidoTicket.AppendLine($"Precio Unitario: ${producto.Precio:F2}");
                contenidoTicket.AppendLine($"Subtotal: ${producto.Cantidad * producto.Precio:F2}");
                contenidoTicket.AppendLine();
            }

            // Escribir el contenido en el archivo
            File.WriteAllText(rutaArchivo, contenidoTicket.ToString());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            // Validar que haya un usuario seleccionado
            if (dataGridView4.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un usuario.");
                return;
            }

            // Validar que haya productos en el carrito
            if (dataGridViewCarrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito está vacío. Agrega productos antes de continuar.");
                return;
            }

            // Obtener el ID del usuario seleccionado
            int idCliente = Convert.ToInt32(dataGridView4.SelectedRows[0].Cells["id_cliente"].Value);

            // Cadena de conexión
            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();
                MySqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    // Inicializar el monto total
                    decimal montoTotal = 0;

                    // Recorrer todos los productos en el carrito (dataGridViewCarrito)
                    foreach (DataGridViewRow row in dataGridViewCarrito.Rows)
                    {
                        // Obtener el ID del producto y la cantidad desde el carrito
                        int idProductoCarrito = Convert.ToInt32(row.Cells["id"].Value); // Cambiado a "id"
                        int cantidadSeleccionada = Convert.ToInt32(row.Cells["cantidad"].Value);

                        // Obtener el precio y stock del producto desde la tabla de productos
                        string queryProducto = "SELECT id_producto, precio_venta, cantidad FROM productos WHERE id_producto = @idProducto";
                        MySqlCommand comandoProducto = new MySqlCommand(queryProducto, conexion, transaccion);
                        comandoProducto.Parameters.AddWithValue("@idProducto", idProductoCarrito);
                        MySqlDataReader reader = comandoProducto.ExecuteReader();

                        if (!reader.Read())
                        {
                            MessageBox.Show($"Producto con ID {idProductoCarrito} no encontrado en la tabla de productos.");
                            reader.Close();
                            return;
                        }

                        int idProductoBD = Convert.ToInt32(reader["id_producto"]);
                        decimal precioUnitario = Convert.ToDecimal(reader["precio_venta"]);
                        int cantidadDisponible = Convert.ToInt32(reader["cantidad"]);
                        reader.Close();

                        // Verificar si hay suficiente cantidad en stock
                        if (cantidadSeleccionada > cantidadDisponible)
                        {
                            MessageBox.Show($"No hay suficiente stock del producto con ID {idProductoBD}.");
                            return;
                        }

                        // Calcular el subtotal para este producto
                        decimal subTotal = precioUnitario * cantidadSeleccionada;
                        montoTotal += subTotal;

                        // Actualizar la cantidad en inventario
                        string queryActualizarInventario = @"UPDATE productos 
              SET cantidad = cantidad - @cantidad 
              WHERE id_producto = @idProducto";
                        MySqlCommand comandoActualizar = new MySqlCommand(queryActualizarInventario, conexion, transaccion);
                        comandoActualizar.Parameters.AddWithValue("@cantidad", cantidadSeleccionada);
                        comandoActualizar.Parameters.AddWithValue("@idProducto", idProductoBD);
                        comandoActualizar.ExecuteNonQuery();
                    }

                    // Agregar el 10% de IVA al monto total
                    decimal iva = montoTotal * 0.10m;
                    decimal montoConIva = montoTotal + iva;

                    // Insertar una venta en la tabla ventas
                    string queryVenta = @"INSERT INTO ventas (id_cliente, id_tipo_venta, fecha_venta, monto_total) 
                      VALUES (@idCliente, @idTipoVenta, NOW(), @montoTotal)";
                    MySqlCommand comandoVenta = new MySqlCommand(queryVenta, conexion, transaccion);
                    comandoVenta.Parameters.AddWithValue("@idCliente", idCliente);
                    comandoVenta.Parameters.AddWithValue("@idTipoVenta", 1); // Asume un tipo de venta por defecto
                    comandoVenta.Parameters.AddWithValue("@montoTotal", montoConIva);
                    comandoVenta.ExecuteNonQuery();

                    // Obtener el ID de la venta recién creada
                    long idVenta = comandoVenta.LastInsertedId;

                    // Insertar el ticket
                    string queryTicket = @"INSERT INTO tickets (id_venta, fecha_emision, monto_total, estado_ticket) 
                      VALUES (@idVenta, NOW(), @montoTotal, 'Activo')";
                    MySqlCommand comandoTicket = new MySqlCommand(queryTicket, conexion, transaccion);
                    comandoTicket.Parameters.AddWithValue("@idVenta", idVenta); // Usar el id_venta generado
                    comandoTicket.Parameters.AddWithValue("@montoTotal", montoConIva);
                    comandoTicket.ExecuteNonQuery();

                    // Obtener el ID del ticket recién creado
                    long idTicket = comandoTicket.LastInsertedId;

                    // Recorrer nuevamente los productos en el carrito para insertar los detalles del ticket
                    foreach (DataGridViewRow row in dataGridViewCarrito.Rows)
                    {
                        int idProductoCarrito = Convert.ToInt32(row.Cells["id"].Value); // Cambiado a "id"
                        int cantidadSeleccionada = Convert.ToInt32(row.Cells["cantidad"].Value);

                        // Obtener el precio unitario del producto
                        string queryProducto = "SELECT precio_venta FROM productos WHERE id_producto = @idProducto";
                        MySqlCommand comandoProducto = new MySqlCommand(queryProducto, conexion, transaccion);
                        comandoProducto.Parameters.AddWithValue("@idProducto", idProductoCarrito);
                        decimal precioUnitario = Convert.ToDecimal(comandoProducto.ExecuteScalar());

                        // Calcular el subtotal para este producto
                        decimal subTotal = precioUnitario * cantidadSeleccionada;

                        // Insertar el detalle del ticket
                        string queryDetalle = @"INSERT INTO detalle_tickets (id_ticket, id_producto, cantidad, precio_unitario, sub_total)
    VALUES (@idTicket, @idProducto, @cantidad, @precioUnitario, @subTotal)";
                        MySqlCommand comandoDetalle = new MySqlCommand(queryDetalle, conexion, transaccion);
                        comandoDetalle.Parameters.AddWithValue("@idTicket", idTicket);
                        comandoDetalle.Parameters.AddWithValue("@idProducto", idProductoCarrito);
                        comandoDetalle.Parameters.AddWithValue("@cantidad", cantidadSeleccionada);
                        comandoDetalle.Parameters.AddWithValue("@precioUnitario", precioUnitario);
                        comandoDetalle.Parameters.AddWithValue("@subTotal", subTotal);
                        comandoDetalle.ExecuteNonQuery();
                    }

                    // Confirmar la transacción
                    transaccion.Commit();

                    // Mostrar mensaje de éxito
                    MessageBox.Show("¡Ticket creado exitosamente!");

                    // Guardar el ticket en un archivo .txt
                    GuardarTicketEnArchivo(idTicket, montoConIva, carrito);

                    // Actualizar el monto total con IVA en el label
                    label6.Text = $"Total (IVA incluido): ${montoConIva:F2}";
                }
                catch (Exception ex)
                {
                    // Revertir la transacción en caso de error
                    transaccion.Rollback();
                    MessageBox.Show($"Error al crear el ticket: {ex.Message}");
                }
            }


        }

        // Este método consulta la tabla ticket filtrando por el valor de textBox1
        private void FiltrarTicketsAnticipo()
        {
            // Obtiene el texto a filtrar y lo limpia de espacios extra
            string filtro = textBox1.Text.Trim();

            // Cadena de conexión (ajústala si es necesario)
            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    // Si id_ticket es de tipo entero, para poder usar LIKE lo convertimos a CHAR
                    string query = "SELECT * FROM tickets WHERE CAST(id_ticket AS CHAR) LIKE @filtro";
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    // Se construye el parámetro para buscar coincidencias parciales
                    comando.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    // Actualizar el DataGridView con los resultados filtrados
                    dataGridViewAnticipo.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al filtrar tickets: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            FiltrarTicketsAnticipo();
        }

        /**
         *Para filtrar productos en detalles de ticket 
         */
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string cadenaConexion = "Server=localhost;Database=perfumeria;User ID=root;Password=;SslMode=none;";
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();
                string query = "SELECT * FROM detalle_tickets WHERE id_producto LIKE @idProducto";

                MySqlCommand comando = new MySqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@idProducto", textBox4.Text.Trim() + "%");

                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                adaptador.Fill(dt);

                dataGridViewDescripcion.DataSource = dt;
            }
        }
    }
}
