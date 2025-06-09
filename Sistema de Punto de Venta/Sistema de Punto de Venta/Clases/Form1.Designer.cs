using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //Estructura para almacenar los colores para los botones u otros elementos
        private struct Btn_Colors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Conexion a la base de datos



        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            textBox1 = new TextBox();
            label13 = new Label();
            label12 = new Label();
            dataGridViewDescripcion = new DataGridView();
            dataGridView4 = new DataGridView();
            dataGridViewCarrito = new DataGridView();
            label11 = new Label();
            buttonAnticipo = new Button();
            numericUpDown2 = new NumericUpDown();
            dataGridViewAnticipo = new DataGridView();
            label10 = new Label();
            label9 = new Label();
            textBox4 = new TextBox();
            textBox5Idticket = new TextBox();
            label8 = new Label();
            button4 = new Button();
            button1 = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            button3 = new Button();
            numericUpDownCantidad = new NumericUpDown();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            label4 = new Label();
            textLastname2 = new TextBox();
            label3 = new Label();
            textLastname1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            textName = new TextBox();
            panel2 = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDescripcion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAnticipo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(dataGridViewDescripcion);
            panel1.Controls.Add(dataGridView4);
            panel1.Controls.Add(dataGridViewCarrito);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(buttonAnticipo);
            panel1.Controls.Add(numericUpDown2);
            panel1.Controls.Add(dataGridViewAnticipo);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox5Idticket);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(numericUpDownCantidad);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textLastname2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textLastname1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textName);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1552, 950);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1277, 159);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(139, 23);
            textBox1.TabIndex = 31;
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(1277, 135);
            label13.Name = "label13";
            label13.RightToLeft = RightToLeft.No;
            label13.Size = new Size(52, 15);
            label13.TabIndex = 30;
            label13.Text = "ID Ticket";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(1277, 212);
            label12.Name = "label12";
            label12.RightToLeft = RightToLeft.No;
            label12.Size = new Size(105, 15);
            label12.TabIndex = 29;
            label12.Text = "Monto de anticipo";
            // 
            // dataGridViewDescripcion
            // 
            dataGridViewDescripcion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDescripcion.Location = new Point(1119, 521);
            dataGridViewDescripcion.Name = "dataGridViewDescripcion";
            dataGridViewDescripcion.Size = new Size(391, 174);
            dataGridViewDescripcion.TabIndex = 28;
            // 
            // dataGridView4
            // 
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new Point(59, 199);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.Size = new Size(608, 96);
            dataGridView4.TabIndex = 27;
            // 
            // dataGridViewCarrito
            // 
            dataGridViewCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCarrito.Location = new Point(59, 757);
            dataGridViewCarrito.Name = "dataGridViewCarrito";
            dataGridViewCarrito.Size = new Size(667, 181);
            dataGridViewCarrito.TabIndex = 25;
            dataGridViewCarrito.CellContentClick += dataGridViewCarrito_CellContentClick;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.FlatStyle = FlatStyle.Flat;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(59, 714);
            label11.Name = "label11";
            label11.Size = new Size(70, 25);
            label11.TabIndex = 24;
            label11.Text = "Carrito";
            // 
            // buttonAnticipo
            // 
            buttonAnticipo.Location = new Point(1277, 293);
            buttonAnticipo.Name = "buttonAnticipo";
            buttonAnticipo.Size = new Size(116, 23);
            buttonAnticipo.TabIndex = 23;
            buttonAnticipo.Text = "Realizar Anticipo";
            buttonAnticipo.UseVisualStyleBackColor = true;
            buttonAnticipo.Click += button5_Click;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown2.Location = new Point(1277, 247);
            numericUpDown2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDown2.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 22;
            numericUpDown2.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // dataGridViewAnticipo
            // 
            dataGridViewAnticipo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAnticipo.Location = new Point(867, 135);
            dataGridViewAnticipo.Name = "dataGridViewAnticipo";
            dataGridViewAnticipo.Size = new Size(365, 181);
            dataGridViewAnticipo.TabIndex = 21;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(946, 564);
            label10.Name = "label10";
            label10.RightToLeft = RightToLeft.No;
            label10.Size = new Size(70, 15);
            label10.TabIndex = 20;
            label10.Text = "ID Producto";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(946, 496);
            label9.Name = "label9";
            label9.RightToLeft = RightToLeft.No;
            label9.Size = new Size(52, 15);
            label9.TabIndex = 19;
            label9.Text = "ID Ticket";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(947, 592);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(139, 23);
            textBox4.TabIndex = 18;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // textBox5Idticket
            // 
            textBox5Idticket.Location = new Point(946, 521);
            textBox5Idticket.Name = "textBox5Idticket";
            textBox5Idticket.Size = new Size(139, 23);
            textBox5Idticket.TabIndex = 17;
            textBox5Idticket.TextChanged += textBox5Idticket_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(947, 428);
            label8.Name = "label8";
            label8.Size = new Size(197, 25);
            label8.TabIndex = 16;
            label8.Text = "Devolucion de pedido";
            label8.Click += label8_Click;
            // 
            // button4
            // 
            button4.Location = new Point(947, 647);
            button4.Name = "button4";
            button4.Size = new Size(83, 48);
            button4.TabIndex = 15;
            button4.Text = "Devolver producto";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button1
            // 
            button1.Location = new Point(749, 905);
            button1.Name = "button1";
            button1.Size = new Size(138, 33);
            button1.TabIndex = 14;
            button1.Text = "Finalizar Compra";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(867, 90);
            label7.Name = "label7";
            label7.Size = new Size(82, 25);
            label7.TabIndex = 13;
            label7.Text = "Anticipo";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(749, 757);
            label6.Name = "label6";
            label6.Size = new Size(189, 25);
            label6.TabIndex = 12;
            label6.Text = "Muestra del subtotal";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(59, 313);
            label5.Name = "label5";
            label5.Size = new Size(203, 25);
            label5.TabIndex = 11;
            label5.Text = "Busqueda de Producto";
            // 
            // button3
            // 
            button3.Location = new Point(749, 404);
            button3.Name = "button3";
            button3.Size = new Size(83, 33);
            button3.TabIndex = 10;
            button3.Text = "Agregar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // numericUpDownCantidad
            // 
            numericUpDownCantidad.Location = new Point(749, 364);
            numericUpDownCantidad.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownCantidad.Name = "numericUpDownCantidad";
            numericUpDownCantidad.Size = new Size(120, 23);
            numericUpDownCantidad.TabIndex = 9;
            numericUpDownCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(59, 364);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(667, 331);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button2
            // 
            button2.Location = new Point(567, 149);
            button2.Name = "button2";
            button2.Size = new Size(100, 33);
            button2.TabIndex = 7;
            button2.Text = "Localizar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(394, 135);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 6;
            label4.Text = "Apellido Materno";
            // 
            // textLastname2
            // 
            textLastname2.Location = new Point(394, 159);
            textLastname2.Name = "textLastname2";
            textLastname2.Size = new Size(139, 23);
            textLastname2.TabIndex = 5;
            textLastname2.TextChanged += textLastname2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(224, 135);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 4;
            label3.Text = "Apellido Paterno";
            // 
            // textLastname1
            // 
            textLastname1.Location = new Point(224, 159);
            textLastname1.Name = "textLastname1";
            textLastname1.Size = new Size(139, 23);
            textLastname1.TabIndex = 3;
            textLastname1.TextChanged += textLastname1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 135);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(59, 90);
            label1.Name = "label1";
            label1.Size = new Size(191, 25);
            label1.TabIndex = 1;
            label1.Text = "Busqueda de Usuario";
            // 
            // textName
            // 
            textName.Location = new Point(59, 159);
            textName.Name = "textName";
            textName.Size = new Size(139, 23);
            textName.TabIndex = 0;
            textName.TextChanged += textName_TextChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(29, 29, 29);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1552, 65);
            panel2.TabIndex = 2;
            panel2.Paint += panel2_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(29, 29, 29);
            ClientSize = new Size(1552, 950);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Creditos";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDescripcion).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCarrito).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAnticipo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private TextBox textName;
        private Button button2;
        private Label label4;
        private TextBox textLastname2;
        private Label label3;
        private TextBox textLastname1;
        private Label label2;
        private Button button3;
        private NumericUpDown numericUpDownCantidad;
        private DataGridView dataGridView1;
        private Label label5;
        private Label label7;
        private Label label6;
        private Button button1;
        private Button button4;
        private Label label8;
        private TextBox textBox4;
        private TextBox textBox5Idticket;
        private Button buttonAnticipo;
        private NumericUpDown numericUpDown2;
        private DataGridView dataGridViewAnticipo;
        private Label label10;
        private Label label9;
        private DataGridView dataGridViewCarrito;
        private Label label11;
        private DataGridView dataGridView4;
        private DataGridView dataGridViewDescripcion;
        private Label label12;
        private TextBox textBox1;
        private Label label13;
    }

}
