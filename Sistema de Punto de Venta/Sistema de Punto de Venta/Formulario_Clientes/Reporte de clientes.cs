using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

namespace Sistema_de_Punto_de_Venta.Formulario_Clientes
{
    public partial class Reporte_de_Clientes : Form
    {
        public Reporte_de_Clientes()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Iniciar en pantalla completa
        }

        // Variable para almacenar el formato seleccionado ("CSV" o "TXT")
        private string formatoSeleccionado = "";

        // Cadena de conexión a MySQL
        private string connectionString = "Server=localhost;Database=Perfumeria;User ID=root;Password=;SslMode=none;";

        // Evento Load del formulario: carga los datos en la previsualización
        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDatosEnPrevisualizacion();
        }

        private void CargarDatosEnPrevisualizacion()
        {
            StringBuilder previsualizacion = new StringBuilder();
            previsualizacion.AppendLine("📋 **Reporte de Clientes**\n");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT nombre, apellido_paterno, apellido_materno, estado, municipio, colonia, calle, numero_exterior, numero_interior, telefono, correo_electronico FROM Clientes";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        previsualizacion.AppendLine($" {reader["nombre"]} {reader["apellido_paterno"]} {reader["apellido_materno"]}");
                        previsualizacion.AppendLine($" {reader["estado"]}, {reader["municipio"]}, {reader["colonia"]}");
                        previsualizacion.AppendLine($" {reader["calle"]} #{reader["numero_exterior"]}, #{reader["numero_interior"]} | {reader["telefono"]} {reader["correo_electronico"]}");
                        previsualizacion.AppendLine(new string('-', 50));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }

            Reporte_Visual.Text = previsualizacion.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formatoSeleccionado = "CSV";
            GenerarPrevisualizacion();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(formatoSeleccionado))
            {
                MessageBox.Show("Seleccione un formato antes de generar el reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (formatoSeleccionado)
            {
                case "CSV":
                    ExportarCSV();
                    break;
                case "TXT":
                    ExportarTXT();
                    break;
                default:
                    MessageBox.Show("Formato no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formatoSeleccionado = "TXT";
            GenerarPrevisualizacion();
        }

        // Método que genera la previsualización a partir de la base de datos y los CheckBox seleccionados
        private void GenerarPrevisualizacion()
        {
            StringBuilder previsualizacion = new StringBuilder();
            previsualizacion.AppendLine("📋 **Reporte de Clientes**\n");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT nombre, apellido_paterno, apellido_materno, estado, municipio, colonia, calle, numero_exterior, numero_interior, codigo_postal, telefono, correo_electronico FROM Clientes"; MySqlCommand cmd = new MySqlCommand(query, conn);
                    //MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (checkBox_Nombre.Checked)
                            previsualizacion.Append($"{reader["nombre"]} ");
                        if (checkBox_Apellido_Paterno.Checked)
                            previsualizacion.Append($"{reader["apellido_paterno"]} ");
                        if (checkBox_Apellido_Materno.Checked)
                            previsualizacion.Append($"{reader["apellido_materno"]} ");
                        if (checkBox_Estado.Checked)
                            previsualizacion.Append($"| {reader["estado"]} ");
                        if (checkBox_Municipio.Checked)
                            previsualizacion.Append($"| {reader["municipio"]} ");
                        if (checkBox_Colonia.Checked)
                            previsualizacion.Append($"| {reader["colonia"]} ");
                        if (checkBox_Calle.Checked)
                            previsualizacion.Append($"| {reader["calle"]} ");
                        if (checkBox_Numero_Exterior.Checked)
                            previsualizacion.Append($"| {reader["numero_exterior"]} ");
                        if (checkBox_Numero_Interior.Checked)
                            previsualizacion.Append($"| {reader["numero_interior"]} ");
                        if (checkBox_Codigo_Postal.Checked)
                            previsualizacion.Append($"| {reader["codigo_postal"]} ");
                        if (checkBox_Telefono.Checked)
                            previsualizacion.Append($"| {reader["telefono"]} ");
                        if (checkBox_Correo_Electronico.Checked)
                            previsualizacion.Append($"| {reader["correo_electronico"]} ");

                        previsualizacion.AppendLine("\n" + new string('-', 50));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar datos: " + ex.Message);
                }
            }

            // Mostrar la previsualización en el control (por ejemplo, un RichTextBox llamado Reporte_Visual)
            Reporte_Visual.Text = previsualizacion.ToString();
        }

        // Evento (por ejemplo, si se cambia algún CheckBox)
        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            // Puedes llamar a GenerarPrevisualizacion() si quieres actualizar la vista al cambiar opciones.
        }

        // Exporta el contenido de Reporte_Visual a un archivo CSV
        private void ExportarCSV()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Guardar Reporte como CSV"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Se quita la línea de encabezado si se desea
                string contenido = Reporte_Visual.Text.Replace("📋 **Reporte de Clientes**\n", "");
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    sw.WriteLine(contenido);
                }
                MessageBox.Show("Reporte guardado correctamente como CSV.");
            }
        }

        // Exporta el contenido de Reporte_Visual a un archivo TXT
        private void ExportarTXT()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Guardar Reporte como TXT"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, Reporte_Visual.Text);
                MessageBox.Show("Reporte guardado correctamente como TXT.");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
