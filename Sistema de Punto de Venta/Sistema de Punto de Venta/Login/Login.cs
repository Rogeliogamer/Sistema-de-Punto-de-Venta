using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Librería para MySQL

namespace Sistema_de_Punto_de_Venta.Login
{
    public partial class Login : Form
    {
        // Variables para el arrastre del formulario
        private bool arrastrando = false;
        private Point posicionInicial;

        public Login()
        {
            InitializeComponent();

            // Asignar eventos al formulario
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.MouseMove += new MouseEventHandler(Form_MouseMove);
            this.MouseUp += new MouseEventHandler(Form_MouseUp);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Usuario_Enter(object sender, EventArgs e)
        {
            if (textBox_Usuario.Text == "USUARIO")
            {
                textBox_Usuario.Text = "";
                textBox_Usuario.ForeColor = Color.LightGray;
            }
        }

        private void textBox_Usuario_Leave(object sender, EventArgs e)
        {
            if (textBox_Usuario.Text == "")
            {
                textBox_Usuario.Text = "USUARIO";
                textBox_Usuario.ForeColor = Color.DimGray;
            }
        }

        private void textBox_Contraseña_Enter(object sender, EventArgs e)
        {
            if (textBox_Contraseña.Text == "CONTRASEÑA")
            {
                textBox_Contraseña.Text = "";
                textBox_Contraseña.ForeColor = Color.LightGray;
                textBox_Contraseña.UseSystemPasswordChar = true;
            }
        }

        private void textBox_Contraseña_Leave(object sender, EventArgs e)
        {
            if (textBox_Contraseña.Text == "")
            {
                textBox_Contraseña.Text = "CONTRASEÑA";
                textBox_Contraseña.ForeColor = Color.DimGray;
                textBox_Contraseña.UseSystemPasswordChar = false;
            }
        }

        private void pictureBox_X_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            arrastrando = true;
            posicionInicial = new Point(e.X, e.Y);
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrando)
            {
                this.Left += e.X - posicionInicial.X;
                this.Top += e.Y - posicionInicial.Y;
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrando = false;
        }

        private void button_Acceder_Click(object sender, EventArgs e)
        {
            string usuario = textBox_Usuario.Text;
            string contraseña = textBox_Contraseña.Text;

            // Cadena de conexión (ajústala si es necesario)
            string conexionString = "Server=localhost;Database=Perfumeria;User ID=root;Password=;SslMode=none;";

            using (MySqlConnection conexion = new MySqlConnection(conexionString))
            {
                try
                {
                    conexion.Open();

                    // Consulta para verificar usuario y contraseña
                    string query = "SELECT * FROM Usuarios WHERE nombre_usuario = @usuario AND contrasena = @contrasena";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contraseña); // ⚠️ No recomendado en producción (mejor usar hash)

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // Si hay datos, usuario y contraseña son correctos
                    {
                        MessageBox.Show("Inicio de sesión exitoso", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Abrir el formulario principal y cerrar login
                        Menu.Menu menu = new Menu.Menu();
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la conexión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
