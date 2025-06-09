using System.Drawing;
using System.Windows.Forms;

namespace Perfumeria
{
    partial class ProductosVentana
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nombreLabel = new System.Windows.Forms.Label();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.descTextbox = new System.Windows.Forms.TextBox();
            this.descLabel = new System.Windows.Forms.Label();
            this.piezasTextbox = new System.Windows.Forms.TextBox();
            this.PiezasLabel = new System.Windows.Forms.Label();
            this.compraTextbox = new System.Windows.Forms.TextBox();
            this.compraLabel = new System.Windows.Forms.Label();
            this.ventaTextbox = new System.Windows.Forms.TextBox();
            this.ventaLabel = new System.Windows.Forms.Label();
            this.guardarButton = new System.Windows.Forms.Button();
            this.buscarTextbox = new System.Windows.Forms.TextBox();
            this.productosTabla = new System.Windows.Forms.DataGridView();
            this.buscarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productosTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.nombreLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreLabel.ForeColor = System.Drawing.Color.LightGray;
            this.nombreLabel.Location = new System.Drawing.Point(28, 20);
            this.nombreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(179, 21);
            this.nombreLabel.TabIndex = 0;
            this.nombreLabel.Text = "Nombre del producto";
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.nombreTextBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreTextBox.Location = new System.Drawing.Point(28, 43);
            this.nombreTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(121, 27);
            this.nombreTextBox.TabIndex = 1;
            // 
            // descTextbox
            // 
            this.descTextbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.descTextbox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descTextbox.Location = new System.Drawing.Point(28, 111);
            this.descTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.descTextbox.Multiline = true;
            this.descTextbox.Name = "descTextbox";
            this.descTextbox.Size = new System.Drawing.Size(121, 52);
            this.descTextbox.TabIndex = 5;
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.descLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descLabel.ForeColor = System.Drawing.Color.LightGray;
            this.descLabel.Location = new System.Drawing.Point(28, 88);
            this.descLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(100, 21);
            this.descLabel.TabIndex = 4;
            this.descLabel.Text = "Descripcion";
            // 
            // piezasTextbox
            // 
            this.piezasTextbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.piezasTextbox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.piezasTextbox.Location = new System.Drawing.Point(28, 196);
            this.piezasTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.piezasTextbox.Name = "piezasTextbox";
            this.piezasTextbox.Size = new System.Drawing.Size(121, 27);
            this.piezasTextbox.TabIndex = 7;
            // 
            // PiezasLabel
            // 
            this.PiezasLabel.AutoSize = true;
            this.PiezasLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.PiezasLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PiezasLabel.ForeColor = System.Drawing.Color.LightGray;
            this.PiezasLabel.Location = new System.Drawing.Point(28, 173);
            this.PiezasLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PiezasLabel.Name = "PiezasLabel";
            this.PiezasLabel.Size = new System.Drawing.Size(56, 21);
            this.PiezasLabel.TabIndex = 6;
            this.PiezasLabel.Text = "Piezas";
            // 
            // compraTextbox
            // 
            this.compraTextbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.compraTextbox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compraTextbox.Location = new System.Drawing.Point(28, 262);
            this.compraTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.compraTextbox.Name = "compraTextbox";
            this.compraTextbox.Size = new System.Drawing.Size(121, 27);
            this.compraTextbox.TabIndex = 9;
            // 
            // compraLabel
            // 
            this.compraLabel.AutoSize = true;
            this.compraLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.compraLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compraLabel.ForeColor = System.Drawing.Color.LightGray;
            this.compraLabel.Location = new System.Drawing.Point(28, 239);
            this.compraLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.compraLabel.Name = "compraLabel";
            this.compraLabel.Size = new System.Drawing.Size(148, 21);
            this.compraLabel.TabIndex = 8;
            this.compraLabel.Text = "Precio de compra";
            // 
            // ventaTextbox
            // 
            this.ventaTextbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ventaTextbox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaTextbox.Location = new System.Drawing.Point(28, 325);
            this.ventaTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.ventaTextbox.Name = "ventaTextbox";
            this.ventaTextbox.Size = new System.Drawing.Size(121, 27);
            this.ventaTextbox.TabIndex = 11;
            // 
            // ventaLabel
            // 
            this.ventaLabel.AutoSize = true;
            this.ventaLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ventaLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventaLabel.ForeColor = System.Drawing.Color.LightGray;
            this.ventaLabel.Location = new System.Drawing.Point(28, 302);
            this.ventaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ventaLabel.Name = "ventaLabel";
            this.ventaLabel.Size = new System.Drawing.Size(134, 21);
            this.ventaLabel.TabIndex = 10;
            this.ventaLabel.Text = "Precio de venta";
            // 
            // guardarButton
            // 
            this.guardarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.guardarButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardarButton.ForeColor = System.Drawing.Color.LightGray;
            this.guardarButton.Location = new System.Drawing.Point(44, 356);
            this.guardarButton.Margin = new System.Windows.Forms.Padding(2);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(84, 31);
            this.guardarButton.TabIndex = 12;
            this.guardarButton.Text = "Guardar";
            this.guardarButton.UseVisualStyleBackColor = false;
            // 
            // buscarTextbox
            // 
            this.buscarTextbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.buscarTextbox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarTextbox.Location = new System.Drawing.Point(481, 11);
            this.buscarTextbox.Margin = new System.Windows.Forms.Padding(2);
            this.buscarTextbox.Name = "buscarTextbox";
            this.buscarTextbox.Size = new System.Drawing.Size(188, 27);
            this.buscarTextbox.TabIndex = 14;
            this.buscarTextbox.Tag = "";
            this.buscarTextbox.Text = "\r\n";
            // 
            // productosTabla
            // 
            this.productosTabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.productosTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productosTabla.Location = new System.Drawing.Point(265, 42);
            this.productosTabla.Margin = new System.Windows.Forms.Padding(2);
            this.productosTabla.Name = "productosTabla";
            this.productosTabla.ReadOnly = true;
            this.productosTabla.RowHeadersWidth = 51;
            this.productosTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productosTabla.Size = new System.Drawing.Size(441, 337);
            this.productosTabla.TabIndex = 15;
            // 
            // buscarButton
            // 
            this.buscarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.buscarButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarButton.ForeColor = System.Drawing.Color.LightGray;
            this.buscarButton.Location = new System.Drawing.Point(673, 8);
            this.buscarButton.Margin = new System.Windows.Forms.Padding(2);
            this.buscarButton.Name = "buscarButton";
            this.buscarButton.Size = new System.Drawing.Size(33, 30);
            this.buscarButton.TabIndex = 16;
            this.buscarButton.Text = "🔍";
            this.buscarButton.UseVisualStyleBackColor = false;
            // 
            // ProductosVentana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(755, 398);
            this.Controls.Add(this.buscarButton);
            this.Controls.Add(this.productosTabla);
            this.Controls.Add(this.buscarTextbox);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.ventaTextbox);
            this.Controls.Add(this.ventaLabel);
            this.Controls.Add(this.compraTextbox);
            this.Controls.Add(this.compraLabel);
            this.Controls.Add(this.piezasTextbox);
            this.Controls.Add(this.PiezasLabel);
            this.Controls.Add(this.descTextbox);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.nombreTextBox);
            this.Controls.Add(this.nombreLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProductosVentana";
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.ProductosVentana_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productosTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label nombreLabel;
        private TextBox nombreTextBox;
        private TextBox descTextbox;
        private Label descLabel;
        private TextBox piezasTextbox;
        private Label PiezasLabel;
        private TextBox compraTextbox;
        private Label compraLabel;
        private TextBox ventaTextbox;
        private Label ventaLabel;
        private Button guardarButton;
        private TextBox buscarTextbox;
        private DataGridView productosTabla;
        private Button buscarButton;
    }
}
