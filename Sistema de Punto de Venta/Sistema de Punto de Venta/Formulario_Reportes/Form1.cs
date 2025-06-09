using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Agregar opciones al ComboBox
            cmbTipoReporte.Items.Add("Ventas");
            cmbTipoReporte.Items.Add("Pagos");
            cmbTipoReporte.SelectedIndex = 0; // Seleccionar "Ventas" por defecto
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFin = dtpFechaFin.Value;
            string tipoReporte = cmbTipoReporte.SelectedItem.ToString();

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

                        dgvResultados.DataSource = dt; // Mostrar los datos en el DataGridView
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
