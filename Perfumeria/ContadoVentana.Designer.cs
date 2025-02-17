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
            carritoLabel = new Label();
            carritoListbox = new ListBox();
            totalLabel = new Label();
            totalTextbox = new TextBox();
            ventaButton = new Button();
            clienteListbox = new ListBox();
            buscarClienteTextbox = new TextBox();
            resumenTextbox = new TextBox();
            ticketTextbox = new TextBox();
            SuspendLayout();
            // 
            // carritoLabel
            // 
            carritoLabel.AutoSize = true;
            carritoLabel.Location = new Point(30, 29);
            carritoLabel.Name = "carritoLabel";
            carritoLabel.Size = new Size(54, 20);
            carritoLabel.TabIndex = 0;
            carritoLabel.Text = "Carrito";
            carritoLabel.Click += carritoLabel_Click;
            // 
            // carritoListbox
            // 
            carritoListbox.FormattingEnabled = true;
            carritoListbox.Location = new Point(30, 64);
            carritoListbox.Name = "carritoListbox";
            carritoListbox.Size = new Size(217, 184);
            carritoListbox.TabIndex = 1;
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Location = new Point(30, 270);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(42, 20);
            totalLabel.TabIndex = 2;
            totalLabel.Text = "Total";
            // 
            // totalTextbox
            // 
            totalTextbox.Location = new Point(30, 305);
            totalTextbox.Name = "totalTextbox";
            totalTextbox.Size = new Size(214, 27);
            totalTextbox.TabIndex = 3;
            totalTextbox.Text = "$$$$$$";
            // 
            // ventaButton
            // 
            ventaButton.Location = new Point(65, 360);
            ventaButton.Name = "ventaButton";
            ventaButton.Size = new Size(139, 43);
            ventaButton.TabIndex = 4;
            ventaButton.Text = "Registrar venta";
            ventaButton.UseVisualStyleBackColor = true;
            // 
            // clienteListbox
            // 
            clienteListbox.FormattingEnabled = true;
            clienteListbox.Location = new Point(618, 64);
            clienteListbox.Name = "clienteListbox";
            clienteListbox.Size = new Size(386, 184);
            clienteListbox.TabIndex = 5;
            clienteListbox.SelectedIndexChanged += clienteListbox_SelectedIndexChanged;
            // 
            // buscarClienteTextbox
            // 
            buscarClienteTextbox.Location = new Point(764, 26);
            buscarClienteTextbox.Name = "buscarClienteTextbox";
            buscarClienteTextbox.Size = new Size(240, 27);
            buscarClienteTextbox.TabIndex = 6;
            buscarClienteTextbox.Text = "Buscar cliente";
            buscarClienteTextbox.TextChanged += buscarClienteTextbox_TextChanged;
            // 
            // resumenTextbox
            // 
            resumenTextbox.Location = new Point(764, 312);
            resumenTextbox.Name = "resumenTextbox";
            resumenTextbox.Size = new Size(240, 27);
            resumenTextbox.TabIndex = 8;
            resumenTextbox.Text = "RESUMEN DE LA VENTA";
            // 
            // ticketTextbox
            // 
            ticketTextbox.Location = new Point(630, 345);
            ticketTextbox.Multiline = true;
            ticketTextbox.Name = "ticketTextbox";
            ticketTextbox.Size = new Size(374, 196);
            ticketTextbox.TabIndex = 9;
            ticketTextbox.Text = "TICKET DE LA VENTA";
            // 
            // ContadoVentana
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1061, 612);
            Controls.Add(ticketTextbox);
            Controls.Add(resumenTextbox);
            Controls.Add(buscarClienteTextbox);
            Controls.Add(clienteListbox);
            Controls.Add(ventaButton);
            Controls.Add(totalTextbox);
            Controls.Add(totalLabel);
            Controls.Add(carritoListbox);
            Controls.Add(carritoLabel);
            Name = "ContadoVentana";
            Text = "ContadoVentana";
            Load += ContadoVentana_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label carritoLabel;
        private ListBox carritoListbox;
        private Label totalLabel;
        private TextBox totalTextbox;
        private Button ventaButton;
        private ListBox clienteListbox;
        private TextBox buscarClienteTextbox;
        private TextBox resumenTextbox;
        private TextBox ticketTextbox;
    }
}