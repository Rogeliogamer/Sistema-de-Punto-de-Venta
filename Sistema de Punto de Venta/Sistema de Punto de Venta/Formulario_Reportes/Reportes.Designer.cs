namespace Sistema_de_Punto_de_Venta.Formulario_Reportes
{
    partial class Reportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1_Fecha_inicio = new System.Windows.Forms.Label();
            this.label2_Fecha_fin = new System.Windows.Forms.Label();
            this.dateTimePicker1_Fecha_inicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2_Fecha_fin = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1_Reporte = new System.Windows.Forms.DataGridView();
            this.button1_Generar = new System.Windows.Forms.Button();
            this.comboBox1_Tipo_reporte = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_Reporte)).BeginInit();
            this.SuspendLayout();
            // 
            // label1_Fecha_inicio
            // 
            this.label1_Fecha_inicio.AutoSize = true;
            this.label1_Fecha_inicio.Location = new System.Drawing.Point(88, 59);
            this.label1_Fecha_inicio.Name = "label1_Fecha_inicio";
            this.label1_Fecha_inicio.Size = new System.Drawing.Size(79, 13);
            this.label1_Fecha_inicio.TabIndex = 0;
            this.label1_Fecha_inicio.Text = "Fecha de inicio";
            this.label1_Fecha_inicio.Click += new System.EventHandler(this.label1_Fecha_inicio_Click);
            // 
            // label2_Fecha_fin
            // 
            this.label2_Fecha_fin.AutoSize = true;
            this.label2_Fecha_fin.Location = new System.Drawing.Point(416, 59);
            this.label2_Fecha_fin.Name = "label2_Fecha_fin";
            this.label2_Fecha_fin.Size = new System.Drawing.Size(66, 13);
            this.label2_Fecha_fin.TabIndex = 1;
            this.label2_Fecha_fin.Text = "Fecha de fin";
            this.label2_Fecha_fin.Click += new System.EventHandler(this.label2_Fecha_fin_Click);
            // 
            // dateTimePicker1_Fecha_inicio
            // 
            this.dateTimePicker1_Fecha_inicio.Location = new System.Drawing.Point(91, 86);
            this.dateTimePicker1_Fecha_inicio.Name = "dateTimePicker1_Fecha_inicio";
            this.dateTimePicker1_Fecha_inicio.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1_Fecha_inicio.TabIndex = 2;
            this.dateTimePicker1_Fecha_inicio.ValueChanged += new System.EventHandler(this.dateTimePicker1_Fecha_inicio_ValueChanged);
            // 
            // dateTimePicker2_Fecha_fin
            // 
            this.dateTimePicker2_Fecha_fin.Location = new System.Drawing.Point(419, 85);
            this.dateTimePicker2_Fecha_fin.Name = "dateTimePicker2_Fecha_fin";
            this.dateTimePicker2_Fecha_fin.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2_Fecha_fin.TabIndex = 3;
            this.dateTimePicker2_Fecha_fin.ValueChanged += new System.EventHandler(this.dateTimePicker2_Fecha_fin_ValueChanged);
            // 
            // dataGridView1_Reporte
            // 
            this.dataGridView1_Reporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1_Reporte.Location = new System.Drawing.Point(91, 154);
            this.dataGridView1_Reporte.Name = "dataGridView1_Reporte";
            this.dataGridView1_Reporte.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1_Reporte.TabIndex = 4;
            this.dataGridView1_Reporte.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_Reporte_CellContentClick);
            // 
            // button1_Generar
            // 
            this.button1_Generar.Location = new System.Drawing.Point(488, 206);
            this.button1_Generar.Name = "button1_Generar";
            this.button1_Generar.Size = new System.Drawing.Size(75, 23);
            this.button1_Generar.TabIndex = 6;
            this.button1_Generar.Text = "Generar";
            this.button1_Generar.UseVisualStyleBackColor = true;
            this.button1_Generar.Click += new System.EventHandler(this.button1_Generar_Click);
            // 
            // comboBox1_Tipo_reporte
            // 
            this.comboBox1_Tipo_reporte.FormattingEnabled = true;
            this.comboBox1_Tipo_reporte.Location = new System.Drawing.Point(488, 154);
            this.comboBox1_Tipo_reporte.Name = "comboBox1_Tipo_reporte";
            this.comboBox1_Tipo_reporte.Size = new System.Drawing.Size(121, 21);
            this.comboBox1_Tipo_reporte.TabIndex = 7;
            this.comboBox1_Tipo_reporte.SelectedIndexChanged += new System.EventHandler(this.comboBox1_Tipo_reporte_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1_Tipo_reporte);
            this.Controls.Add(this.button1_Generar);
            this.Controls.Add(this.dataGridView1_Reporte);
            this.Controls.Add(this.dateTimePicker2_Fecha_fin);
            this.Controls.Add(this.dateTimePicker1_Fecha_inicio);
            this.Controls.Add(this.label2_Fecha_fin);
            this.Controls.Add(this.label1_Fecha_inicio);
            this.Name = "Form2";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_Reporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_Fecha_inicio;
        private System.Windows.Forms.Label label2_Fecha_fin;
        private System.Windows.Forms.DateTimePicker dateTimePicker1_Fecha_inicio;
        private System.Windows.Forms.DateTimePicker dateTimePicker2_Fecha_fin;
        private System.Windows.Forms.DataGridView dataGridView1_Reporte;
        private System.Windows.Forms.Button button1_Generar;
        private System.Windows.Forms.ComboBox comboBox1_Tipo_reporte;
    }
}