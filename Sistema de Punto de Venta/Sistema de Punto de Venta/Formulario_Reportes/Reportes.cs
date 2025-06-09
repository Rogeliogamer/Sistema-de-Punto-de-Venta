using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Sistema_de_Punto_de_Venta.Formulario_Reportes
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Agregar opciones al ComboBox
            comboBox1_Tipo_reporte.Items.Add("Ventas");
            comboBox1_Tipo_reporte.Items.Add("Pagos");
            comboBox1_Tipo_reporte.SelectedIndex = 0; // Seleccionar "Ventas" por defecto
        }

        private void label1_Fecha_inicio_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_Fecha_inicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Fecha_fin_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_Fecha_fin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Reporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_Tipo_reporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Generar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimePicker1_Fecha_inicio.Value;
            DateTime fechaFin = dateTimePicker2_Fecha_fin.Value;
            string tipoReporte = comboBox1_Tipo_reporte.SelectedItem.ToString();

            string query = "";

            // Definir la consulta según el tipo de reporte
            if (tipoReporte == "Ventas")
            {
                query = @"
                SELECT 
                    V.id_venta AS ID_Venta,
                    C.nombre AS Cliente,
                    V.fecha_venta AS Fecha,
                    V.monto_total AS Total
                FROM Ventas V
                INNER JOIN Clientes C ON V.id_cliente = C.id_cliente
                WHERE V.fecha_venta BETWEEN @FechaInicio AND @FechaFin";
            }
            else if (tipoReporte == "Pagos")
            {
                query = @"
                SELECT 
                    P.id_pago AS ID_Pago,
                    C.nombre AS Cliente,
                    P.fecha_pago AS Fecha,
                    P.monto_total AS Total,
                    P.abono_inicial AS Abono_Inicial,
                    P.monto_pendiente AS Pendiente
                FROM Pagos P
                INNER JOIN Clientes C ON P.id_cliente = C.id_cliente
                WHERE P.fecha_pago BETWEEN @FechaInicio AND @FechaFin";
            }

            // Obtener la conexión usando la clase ConexionDB
            using (MySqlConnection conn = ConexionDB.ObtenerConexion())
            {
                if (conn != null)
                {
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                        cmd.Parameters.AddWithValue("@FechaFin", fechaFin);

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1_Reporte.DataSource = dt; // Mostrar los datos en el DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al generar el reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo establecer la conexión a la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
