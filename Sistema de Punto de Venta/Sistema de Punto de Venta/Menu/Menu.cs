using Sistema_de_Punto_de_Venta.Formulario_Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Punto_de_Venta.Menu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; // Iniciar en pantalla completa

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            button1_Clientes_del_negocio.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Clientes_del_negocio_Click(object sender, EventArgs e)
        {
            // Abrir el registro de clientes y cerrar el menu
            Formulario_Clientes.Registro_de_Clientes Registro = new Formulario_Clientes.Registro_de_Clientes();
            Registro.Show();
            this.Hide();
        }

        private void button4_Ventas_de_crédito_Click(object sender, EventArgs e)
        {
            Formulario_CreditoVentas.Credito credito = new Formulario_CreditoVentas.Credito();
            credito.Show();
            this.Hide();
        }

        private void button3_Ventas_de_contado_Click(object sender, EventArgs e)
        {
            Perfumeria.ContadoVentana contadoVenta = new Perfumeria.ContadoVentana();
            contadoVenta.Show();
            this.Hide();
        }

        private void button6_Reportes_financieros_Click(object sender, EventArgs e)
        {
            WindowsFormsApp1.Form form = new WindowsFormsApp1.Form();
            form.Show();
            this.Hide();
        }
    }
}
