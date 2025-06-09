using System.Drawing;
using System.Windows.Forms;

namespace Perfumeria
{
    partial class ContadoVentana
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
            this.carritoLabel = new System.Windows.Forms.Label();
            this.totalLabel = new System.Windows.Forms.Label();
            this.totalTextbox = new System.Windows.Forms.TextBox();
            this.ventaButton = new System.Windows.Forms.Button();
            this.buscarClienteTextbox = new System.Windows.Forms.TextBox();
            this.productosTabla = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.clientesTabla = new System.Windows.Forms.DataGridView();
            this.productosTextbox = new System.Windows.Forms.TextBox();
            this.productosButton = new System.Windows.Forms.Button();
            this.clientesButton = new System.Windows.Forms.Button();
            this.carritoTabla = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrarTextbox = new System.Windows.Forms.TextBox();
            this.borrarButton = new System.Windows.Forms.Button();
            this.ticketTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.productosTabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesTabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carritoTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // carritoLabel
            // 
            this.carritoLabel.AutoSize = true;
            this.carritoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.carritoLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carritoLabel.ForeColor = System.Drawing.Color.LightGray;
            this.carritoLabel.Location = new System.Drawing.Point(21, 14);
            this.carritoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.carritoLabel.Name = "carritoLabel";
            this.carritoLabel.Size = new System.Drawing.Size(64, 21);
            this.carritoLabel.TabIndex = 0;
            this.carritoLabel.Text = "Carrito";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.totalLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.Color.LightGray;
            this.totalLabel.Location = new System.Drawing.Point(21, 175);
            this.totalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(49, 21);
            this.totalLabel.TabIndex = 2;
            this.totalLabel.Text = "Total";
            // 
            // totalTextbox
            // 
            this.totalTextbox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTextbox.Location = new System.Drawing.Point(22, 198);
            this.totalTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.totalTextbox.Name = "totalTextbox";
            this.totalTextbox.ReadOnly = true;
            this.totalTextbox.Size = new System.Drawing.Size(162, 27);
            this.totalTextbox.TabIndex = 3;
            this.totalTextbox.Text = "$0.0";
            // 
            // ventaButton
            // 
            this.ventaButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ventaButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaButton.ForeColor = System.Drawing.Color.LightGray;
            this.ventaButton.Location = new System.Drawing.Point(25, 229);
            this.ventaButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ventaButton.Name = "ventaButton";
            this.ventaButton.Size = new System.Drawing.Size(148, 28);
            this.ventaButton.TabIndex = 4;
            this.ventaButton.Text = "Registrar venta";
            this.ventaButton.UseVisualStyleBackColor = false;
            // 
            // buscarClienteTextbox
            // 
            this.buscarClienteTextbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.buscarClienteTextbox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarClienteTextbox.Location = new System.Drawing.Point(546, 11);
            this.buscarClienteTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buscarClienteTextbox.Name = "buscarClienteTextbox";
            this.buscarClienteTextbox.Size = new System.Drawing.Size(181, 27);
            this.buscarClienteTextbox.TabIndex = 6;
            // 
            // productosTabla
            // 
            this.productosTabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.productosTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productosTabla.Location = new System.Drawing.Point(304, 42);
            this.productosTabla.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.productosTabla.Name = "productosTabla";
            this.productosTabla.ReadOnly = true;
            this.productosTabla.RowHeadersWidth = 51;
            this.productosTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productosTabla.Size = new System.Drawing.Size(217, 120);
            this.productosTabla.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(268, 198);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Resumen de la venta";
            // 
            // clientesTabla
            // 
            this.clientesTabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.clientesTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientesTabla.Location = new System.Drawing.Point(546, 42);
            this.clientesTabla.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clientesTabla.Name = "clientesTabla";
            this.clientesTabla.ReadOnly = true;
            this.clientesTabla.RowHeadersWidth = 51;
            this.clientesTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientesTabla.Size = new System.Drawing.Size(220, 120);
            this.clientesTabla.TabIndex = 12;
            // 
            // productosTextbox
            // 
            this.productosTextbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.productosTextbox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productosTextbox.Location = new System.Drawing.Point(303, 11);
            this.productosTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.productosTextbox.Name = "productosTextbox";
            this.productosTextbox.Size = new System.Drawing.Size(181, 27);
            this.productosTextbox.TabIndex = 13;
            // 
            // productosButton
            // 
            this.productosButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.productosButton.ForeColor = System.Drawing.Color.LightGray;
            this.productosButton.Location = new System.Drawing.Point(488, 11);
            this.productosButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.productosButton.Name = "productosButton";
            this.productosButton.Size = new System.Drawing.Size(32, 27);
            this.productosButton.TabIndex = 14;
            this.productosButton.Text = "🔍";
            this.productosButton.UseVisualStyleBackColor = false;
            // 
            // clientesButton
            // 
            this.clientesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.clientesButton.ForeColor = System.Drawing.Color.LightGray;
            this.clientesButton.Location = new System.Drawing.Point(730, 11);
            this.clientesButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clientesButton.Name = "clientesButton";
            this.clientesButton.Size = new System.Drawing.Size(32, 27);
            this.clientesButton.TabIndex = 15;
            this.clientesButton.Text = "🔍";
            this.clientesButton.UseVisualStyleBackColor = false;
            // 
            // carritoTabla
            // 
            this.carritoTabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.carritoTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.carritoTabla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.descripcion,
            this.cantidad,
            this.precio});
            this.carritoTabla.Location = new System.Drawing.Point(22, 42);
            this.carritoTabla.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.carritoTabla.Name = "carritoTabla";
            this.carritoTabla.ReadOnly = true;
            this.carritoTabla.RowHeadersWidth = 51;
            this.carritoTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.carritoTabla.Size = new System.Drawing.Size(256, 120);
            this.carritoTabla.TabIndex = 16;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 67;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "descripcion";
            this.descripcion.MinimumWidth = 6;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 86;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "piezas";
            this.cantidad.MinimumWidth = 6;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            this.cantidad.Width = 62;
            // 
            // precio
            // 
            this.precio.HeaderText = "precio";
            this.precio.MinimumWidth = 6;
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Width = 61;
            // 
            // borrarTextbox
            // 
            this.borrarTextbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.borrarTextbox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.borrarTextbox.Location = new System.Drawing.Point(105, 11);
            this.borrarTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borrarTextbox.Name = "borrarTextbox";
            this.borrarTextbox.Size = new System.Drawing.Size(138, 27);
            this.borrarTextbox.TabIndex = 17;
            // 
            // borrarButton
            // 
            this.borrarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.borrarButton.ForeColor = System.Drawing.Color.LightGray;
            this.borrarButton.Location = new System.Drawing.Point(247, 11);
            this.borrarButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.borrarButton.Name = "borrarButton";
            this.borrarButton.Size = new System.Drawing.Size(32, 27);
            this.borrarButton.TabIndex = 18;
            this.borrarButton.Text = "🗑";
            this.borrarButton.UseVisualStyleBackColor = false;
            // 
            // ticketTextbox
            // 
            this.ticketTextbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ticketTextbox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketTextbox.Location = new System.Drawing.Point(272, 226);
            this.ticketTextbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ticketTextbox.Multiline = true;
            this.ticketTextbox.Name = "ticketTextbox";
            this.ticketTextbox.ReadOnly = true;
            this.ticketTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ticketTextbox.Size = new System.Drawing.Size(492, 159);
            this.ticketTextbox.TabIndex = 9;
            this.ticketTextbox.Text = "TICKET DE LA VENTA";
            // 
            // ContadoVentana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(796, 398);
            this.Controls.Add(this.borrarButton);
            this.Controls.Add(this.borrarTextbox);
            this.Controls.Add(this.carritoTabla);
            this.Controls.Add(this.clientesButton);
            this.Controls.Add(this.productosButton);
            this.Controls.Add(this.productosTextbox);
            this.Controls.Add(this.clientesTabla);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productosTabla);
            this.Controls.Add(this.ticketTextbox);
            this.Controls.Add(this.buscarClienteTextbox);
            this.Controls.Add(this.ventaButton);
            this.Controls.Add(this.totalTextbox);
            this.Controls.Add(this.totalLabel);
            this.Controls.Add(this.carritoLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ContadoVentana";
            this.Text = "ContadoVentana";
            this.Load += new System.EventHandler(this.ContadoVentana_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productosTabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesTabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carritoTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label carritoLabel;
        private Label totalLabel;
        private TextBox totalTextbox;
        private Button ventaButton;
        private ListBox clienteListbox;
        private TextBox buscarClienteTextbox;
        private DataGridView productosTabla;
        private Label label1;
        private DataGridView clientesTabla;
        private TextBox productosTextbox;
        private Button productosButton;
        private Button clientesButton;
        private DataGridView carritoTabla;
        private TextBox borrarTextbox;
        private Button borrarButton;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn descripcion;
        private DataGridViewTextBoxColumn cantidad;
        private DataGridViewTextBoxColumn precio;
        private TextBox ticketTextbox;
    }
}