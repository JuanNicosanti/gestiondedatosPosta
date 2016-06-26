namespace WindowsFormsApplication1.Facturas
{
    partial class ConsultaFacturas
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
            this.panelBusqueda = new System.Windows.Forms.Panel();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.tbVendedor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbContenido = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbImporteMaximo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbImporteMinimo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelResultados = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmdVerFactura = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelMIL = new System.Windows.Forms.Label();
            this.cmdPrimera = new System.Windows.Forms.Button();
            this.cmdAnterior = new System.Windows.Forms.Button();
            this.cmdProxima = new System.Windows.Forms.Button();
            this.cmdUltima = new System.Windows.Forms.Button();
            this.lblPaginaActual = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalPagina = new System.Windows.Forms.Label();
            this.lblCantidadTotal = new System.Windows.Forms.Label();
            this.panelBusqueda.SuspendLayout();
            this.panelResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBusqueda
            // 
            this.panelBusqueda.Controls.Add(this.cmdLimpiar);
            this.panelBusqueda.Controls.Add(this.cmdBuscar);
            this.panelBusqueda.Controls.Add(this.dtpFechaFinal);
            this.panelBusqueda.Controls.Add(this.dtpFechaInicial);
            this.panelBusqueda.Controls.Add(this.tbVendedor);
            this.panelBusqueda.Controls.Add(this.label6);
            this.panelBusqueda.Controls.Add(this.tbContenido);
            this.panelBusqueda.Controls.Add(this.label5);
            this.panelBusqueda.Controls.Add(this.tbImporteMaximo);
            this.panelBusqueda.Controls.Add(this.label2);
            this.panelBusqueda.Controls.Add(this.label4);
            this.panelBusqueda.Controls.Add(this.tbImporteMinimo);
            this.panelBusqueda.Controls.Add(this.label3);
            this.panelBusqueda.Controls.Add(this.label1);
            this.panelBusqueda.Location = new System.Drawing.Point(13, 38);
            this.panelBusqueda.Name = "panelBusqueda";
            this.panelBusqueda.Size = new System.Drawing.Size(731, 146);
            this.panelBusqueda.TabIndex = 0;
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.BackColor = System.Drawing.Color.LightCoral;
            this.cmdLimpiar.Location = new System.Drawing.Point(570, 13);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(75, 23);
            this.cmdLimpiar.TabIndex = 13;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.UseVisualStyleBackColor = false;
            this.cmdLimpiar.Click += new System.EventHandler(this.cmdLimpiar_Click);
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.BackColor = System.Drawing.Color.LawnGreen;
            this.cmdBuscar.Location = new System.Drawing.Point(570, 67);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(75, 23);
            this.cmdBuscar.TabIndex = 12;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = false;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Location = new System.Drawing.Point(317, 12);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaFinal.TabIndex = 12;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Location = new System.Drawing.Point(85, 12);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaInicial.TabIndex = 5;
            // 
            // tbVendedor
            // 
            this.tbVendedor.Location = new System.Drawing.Point(74, 95);
            this.tbVendedor.Name = "tbVendedor";
            this.tbVendedor.Size = new System.Drawing.Size(130, 20);
            this.tbVendedor.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Vendedor";
            // 
            // tbContenido
            // 
            this.tbContenido.Location = new System.Drawing.Point(138, 70);
            this.tbContenido.Name = "tbContenido";
            this.tbContenido.Size = new System.Drawing.Size(172, 20);
            this.tbContenido.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Contenido de la factura";
            // 
            // tbImporteMaximo
            // 
            this.tbImporteMaximo.Location = new System.Drawing.Point(210, 42);
            this.tbImporteMaximo.Name = "tbImporteMaximo";
            this.tbImporteMaximo.Size = new System.Drawing.Size(100, 20);
            this.tbImporteMaximo.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "y";
            // 
            // tbImporteMinimo
            // 
            this.tbImporteMinimo.Location = new System.Drawing.Point(85, 42);
            this.tbImporteMinimo.Name = "tbImporteMinimo";
            this.tbImporteMinimo.Size = new System.Drawing.Size(100, 20);
            this.tbImporteMinimo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Importe entre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha entre";
            // 
            // panelResultados
            // 
            this.panelResultados.Controls.Add(this.dataGridView1);
            this.panelResultados.Location = new System.Drawing.Point(13, 190);
            this.panelResultados.Name = "panelResultados";
            this.panelResultados.Size = new System.Drawing.Size(731, 177);
            this.panelResultados.TabIndex = 1;
            this.panelResultados.Visible = false;
            this.panelResultados.Paint += new System.Windows.Forms.PaintEventHandler(this.panelResultados_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(725, 170);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // cmdVerFactura
            // 
            this.cmdVerFactura.BackColor = System.Drawing.Color.NavajoWhite;
            this.cmdVerFactura.Location = new System.Drawing.Point(305, 455);
            this.cmdVerFactura.Name = "cmdVerFactura";
            this.cmdVerFactura.Size = new System.Drawing.Size(143, 23);
            this.cmdVerFactura.TabIndex = 2;
            this.cmdVerFactura.Text = "Ver factura";
            this.cmdVerFactura.UseVisualStyleBackColor = false;
            this.cmdVerFactura.Visible = false;
            this.cmdVerFactura.Click += new System.EventHandler(this.cmdVerFactura_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.NavajoWhite;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(754, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.NavajoWhite;
            this.statusStrip1.Location = new System.Drawing.Point(0, 481);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(754, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelMIL
            // 
            this.labelMIL.AllowDrop = true;
            this.labelMIL.BackColor = System.Drawing.Color.LightGray;
            this.labelMIL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMIL.Location = new System.Drawing.Point(13, 370);
            this.labelMIL.Name = "labelMIL";
            this.labelMIL.Size = new System.Drawing.Size(728, 82);
            this.labelMIL.TabIndex = 5;
            this.labelMIL.Visible = false;
            // 
            // cmdPrimera
            // 
            this.cmdPrimera.Location = new System.Drawing.Point(50, 383);
            this.cmdPrimera.Name = "cmdPrimera";
            this.cmdPrimera.Size = new System.Drawing.Size(120, 23);
            this.cmdPrimera.TabIndex = 6;
            this.cmdPrimera.Text = "Primera pagina";
            this.cmdPrimera.UseVisualStyleBackColor = true;
            this.cmdPrimera.Visible = false;
            this.cmdPrimera.Click += new System.EventHandler(this.cmdPrimera_Click);
            // 
            // cmdAnterior
            // 
            this.cmdAnterior.Location = new System.Drawing.Point(223, 383);
            this.cmdAnterior.Name = "cmdAnterior";
            this.cmdAnterior.Size = new System.Drawing.Size(120, 23);
            this.cmdAnterior.TabIndex = 7;
            this.cmdAnterior.Text = "Pagina anterior";
            this.cmdAnterior.UseVisualStyleBackColor = true;
            this.cmdAnterior.Visible = false;
            this.cmdAnterior.Click += new System.EventHandler(this.cmdAnterior_Click);
            // 
            // cmdProxima
            // 
            this.cmdProxima.Location = new System.Drawing.Point(410, 383);
            this.cmdProxima.Name = "cmdProxima";
            this.cmdProxima.Size = new System.Drawing.Size(120, 23);
            this.cmdProxima.TabIndex = 8;
            this.cmdProxima.Text = "Proxima pagina";
            this.cmdProxima.UseVisualStyleBackColor = true;
            this.cmdProxima.Visible = false;
            this.cmdProxima.Click += new System.EventHandler(this.cmdProxima_Click);
            // 
            // cmdUltima
            // 
            this.cmdUltima.Location = new System.Drawing.Point(583, 383);
            this.cmdUltima.Name = "cmdUltima";
            this.cmdUltima.Size = new System.Drawing.Size(120, 23);
            this.cmdUltima.TabIndex = 9;
            this.cmdUltima.Text = "Ultima pagina";
            this.cmdUltima.UseVisualStyleBackColor = true;
            this.cmdUltima.Visible = false;
            this.cmdUltima.Click += new System.EventHandler(this.cmdUltima_Click);
            // 
            // lblPaginaActual
            // 
            this.lblPaginaActual.AutoSize = true;
            this.lblPaginaActual.BackColor = System.Drawing.Color.LightGray;
            this.lblPaginaActual.Location = new System.Drawing.Point(334, 426);
            this.lblPaginaActual.Name = "lblPaginaActual";
            this.lblPaginaActual.Size = new System.Drawing.Size(35, 13);
            this.lblPaginaActual.TabIndex = 10;
            this.lblPaginaActual.Text = "label8";
            this.lblPaginaActual.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightGray;
            this.label9.Location = new System.Drawing.Point(375, 426);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "/";
            this.label9.Visible = false;
            // 
            // lblTotalPagina
            // 
            this.lblTotalPagina.AutoSize = true;
            this.lblTotalPagina.BackColor = System.Drawing.Color.LightGray;
            this.lblTotalPagina.Location = new System.Drawing.Point(407, 426);
            this.lblTotalPagina.Name = "lblTotalPagina";
            this.lblTotalPagina.Size = new System.Drawing.Size(41, 13);
            this.lblTotalPagina.TabIndex = 12;
            this.lblTotalPagina.Text = "label10";
            this.lblTotalPagina.Visible = false;
            // 
            // lblCantidadTotal
            // 
            this.lblCantidadTotal.AutoSize = true;
            this.lblCantidadTotal.BackColor = System.Drawing.Color.LightGray;
            this.lblCantidadTotal.Location = new System.Drawing.Point(530, 426);
            this.lblCantidadTotal.Name = "lblCantidadTotal";
            this.lblCantidadTotal.Size = new System.Drawing.Size(41, 13);
            this.lblCantidadTotal.TabIndex = 13;
            this.lblCantidadTotal.Text = "label11";
            this.lblCantidadTotal.Visible = false;
            // 
            // ConsultaFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(754, 503);
            this.Controls.Add(this.lblCantidadTotal);
            this.Controls.Add(this.lblTotalPagina);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblPaginaActual);
            this.Controls.Add(this.cmdUltima);
            this.Controls.Add(this.cmdProxima);
            this.Controls.Add(this.cmdAnterior);
            this.Controls.Add(this.cmdPrimera);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmdVerFactura);
            this.Controls.Add(this.panelResultados);
            this.Controls.Add(this.panelBusqueda);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.labelMIL);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ConsultaFacturas";
            this.Text = "ConsultaFacturas";
            this.Load += new System.EventHandler(this.ConsultaFacturas_Load);
            this.panelBusqueda.ResumeLayout(false);
            this.panelBusqueda.PerformLayout();
            this.panelResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBusqueda;
        private System.Windows.Forms.TextBox tbContenido;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbImporteMaximo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbImporteMinimo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelResultados;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.TextBox tbVendedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cmdVerFactura;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label labelMIL;
        private System.Windows.Forms.Button cmdPrimera;
        private System.Windows.Forms.Button cmdAnterior;
        private System.Windows.Forms.Button cmdProxima;
        private System.Windows.Forms.Button cmdUltima;
        private System.Windows.Forms.Label lblPaginaActual;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalPagina;
        private System.Windows.Forms.Label lblCantidadTotal;
    }
}