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
            nombreLabel = new Label();
            nombreTextBox = new TextBox();
            idTextbox = new TextBox();
            idLabel = new Label();
            descTextbox = new TextBox();
            descLabel = new Label();
            piezasTextbox = new TextBox();
            PiezasLabel = new Label();
            compraTextbox = new TextBox();
            compraLabel = new Label();
            ventaTextbox = new TextBox();
            ventaLabel = new Label();
            guardarButton = new Button();
            productosListbox = new ListBox();
            buscarTextbox = new TextBox();
            SuspendLayout();
            // 
            // nombreLabel
            // 
            nombreLabel.AutoSize = true;
            nombreLabel.Location = new Point(38, 31);
            nombreLabel.Name = "nombreLabel";
            nombreLabel.Size = new Size(154, 20);
            nombreLabel.TabIndex = 0;
            nombreLabel.Text = "Nombre del producto";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Location = new Point(38, 54);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(160, 27);
            nombreTextBox.TabIndex = 1;
            // 
            // idTextbox
            // 
            idTextbox.Location = new Point(38, 129);
            idTextbox.Name = "idTextbox";
            idTextbox.Size = new Size(160, 27);
            idTextbox.TabIndex = 3;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(38, 106);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(24, 20);
            idLabel.TabIndex = 2;
            idLabel.Text = "ID";
            // 
            // descTextbox
            // 
            descTextbox.Location = new Point(38, 201);
            descTextbox.Multiline = true;
            descTextbox.Name = "descTextbox";
            descTextbox.Size = new Size(160, 78);
            descTextbox.TabIndex = 5;
            // 
            // descLabel
            // 
            descLabel.AutoSize = true;
            descLabel.Location = new Point(38, 178);
            descLabel.Name = "descLabel";
            descLabel.Size = new Size(87, 20);
            descLabel.TabIndex = 4;
            descLabel.Text = "Descripcion";
            // 
            // piezasTextbox
            // 
            piezasTextbox.Location = new Point(38, 330);
            piezasTextbox.Name = "piezasTextbox";
            piezasTextbox.Size = new Size(160, 27);
            piezasTextbox.TabIndex = 7;
            // 
            // PiezasLabel
            // 
            PiezasLabel.AutoSize = true;
            PiezasLabel.Location = new Point(38, 307);
            PiezasLabel.Name = "PiezasLabel";
            PiezasLabel.Size = new Size(50, 20);
            PiezasLabel.TabIndex = 6;
            PiezasLabel.Text = "Piezas";
            // 
            // compraTextbox
            // 
            compraTextbox.Location = new Point(38, 417);
            compraTextbox.Name = "compraTextbox";
            compraTextbox.Size = new Size(160, 27);
            compraTextbox.TabIndex = 9;
            // 
            // compraLabel
            // 
            compraLabel.AutoSize = true;
            compraLabel.Location = new Point(38, 394);
            compraLabel.Name = "compraLabel";
            compraLabel.Size = new Size(126, 20);
            compraLabel.TabIndex = 8;
            compraLabel.Text = "Precio de compra";
            // 
            // ventaTextbox
            // 
            ventaTextbox.Location = new Point(38, 502);
            ventaTextbox.Name = "ventaTextbox";
            ventaTextbox.Size = new Size(160, 27);
            ventaTextbox.TabIndex = 11;
            // 
            // ventaLabel
            // 
            ventaLabel.AutoSize = true;
            ventaLabel.Location = new Point(38, 479);
            ventaLabel.Name = "ventaLabel";
            ventaLabel.Size = new Size(111, 20);
            ventaLabel.TabIndex = 10;
            ventaLabel.Text = "Precio de venta";
            // 
            // guardarButton
            // 
            guardarButton.Location = new Point(62, 549);
            guardarButton.Name = "guardarButton";
            guardarButton.Size = new Size(112, 35);
            guardarButton.TabIndex = 12;
            guardarButton.Text = "Guardar";
            guardarButton.UseVisualStyleBackColor = true;
            // 
            // productosListbox
            // 
            productosListbox.FormattingEnabled = true;
            productosListbox.Location = new Point(489, 54);
            productosListbox.Name = "productosListbox";
            productosListbox.Size = new Size(452, 484);
            productosListbox.TabIndex = 13;
            // 
            // buscarTextbox
            // 
            buscarTextbox.Location = new Point(692, 21);
            buscarTextbox.Name = "buscarTextbox";
            buscarTextbox.Size = new Size(249, 27);
            buscarTextbox.TabIndex = 14;
            buscarTextbox.Text = "Buscar";
            // 
            // ProductosVentana
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 612);
            Controls.Add(buscarTextbox);
            Controls.Add(productosListbox);
            Controls.Add(guardarButton);
            Controls.Add(ventaTextbox);
            Controls.Add(ventaLabel);
            Controls.Add(compraTextbox);
            Controls.Add(compraLabel);
            Controls.Add(piezasTextbox);
            Controls.Add(PiezasLabel);
            Controls.Add(descTextbox);
            Controls.Add(descLabel);
            Controls.Add(idTextbox);
            Controls.Add(idLabel);
            Controls.Add(nombreTextBox);
            Controls.Add(nombreLabel);
            Name = "ProductosVentana";
            Text = "Productos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nombreLabel;
        private TextBox nombreTextBox;
        private TextBox idTextbox;
        private Label idLabel;
        private TextBox descTextbox;
        private Label descLabel;
        private TextBox piezasTextbox;
        private Label PiezasLabel;
        private TextBox compraTextbox;
        private Label compraLabel;
        private TextBox ventaTextbox;
        private Label ventaLabel;
        private Button guardarButton;
        private ListBox productosListbox;
        private TextBox buscarTextbox;
    }
}
