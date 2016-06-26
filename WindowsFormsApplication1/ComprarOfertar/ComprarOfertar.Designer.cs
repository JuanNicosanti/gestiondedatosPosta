namespace WindowsFormsApplication1.ComprarOfertar
{
    partial class ComprarOfertar
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.cmdVolver = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdPrimera = new System.Windows.Forms.Button();
            this.cmdProxima = new System.Windows.Forms.Button();
            this.cmdAnterior = new System.Windows.Forms.Button();
            this.cmdUltima = new System.Windows.Forms.Button();
            this.lblCantidadTotal = new System.Windows.Forms.Label();
            this.lblPaginaActual = new System.Windows.Forms.Label();
            this.lblTotalPagina = new System.Windows.Forms.Label();
            this.lstRubros = new System.Windows.Forms.ListBox();
            this.cmdSeleccionarRubro = new System.Windows.Forms.Button();
            this.lstRubrosElegidos = new System.Windows.Forms.ListBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdBorrarFiltro = new System.Windows.Forms.Button();
            this.we = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rbEnvioSi = new System.Windows.Forms.RadioButton();
            this.rbEnvioNo = new System.Windows.Forms.RadioButton();
            this.lblGuita = new System.Windows.Forms.Label();
            this.txtGuita = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.NavajoWhite;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1037, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.NavajoWhite;
            this.statusStrip1.Location = new System.Drawing.Point(0, 480);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1037, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(195, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 350);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar publicaciones";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(215, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 231);
            this.label2.TabIndex = 3;
            this.label2.Text = "Rubro";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(218, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 68);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripcion";
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.BackColor = System.Drawing.Color.LawnGreen;
            this.cmdBuscar.Location = new System.Drawing.Point(218, 404);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(210, 23);
            this.cmdBuscar.TabIndex = 5;
            this.cmdBuscar.Text = "Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = false;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click_1);
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.BackColor = System.Drawing.Color.LightCoral;
            this.cmdLimpiar.Location = new System.Drawing.Point(484, 402);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(210, 23);
            this.cmdLimpiar.TabIndex = 6;
            this.cmdLimpiar.Text = "Limpiar Busqueda";
            this.cmdLimpiar.UseVisualStyleBackColor = false;
            this.cmdLimpiar.Click += new System.EventHandler(this.cmdLimpiar_Click);
            // 
            // cmdVolver
            // 
            this.cmdVolver.BackColor = System.Drawing.Color.Cyan;
            this.cmdVolver.Location = new System.Drawing.Point(793, 402);
            this.cmdVolver.Name = "cmdVolver";
            this.cmdVolver.Size = new System.Drawing.Size(210, 23);
            this.cmdVolver.TabIndex = 7;
            this.cmdVolver.Text = "Volver";
            this.cmdVolver.UseVisualStyleBackColor = false;
            this.cmdVolver.Click += new System.EventHandler(this.cmdVolver_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(484, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(519, 279);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label4
            // 
            this.label4.AllowDrop = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(484, 316);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(519, 68);
            this.label4.TabIndex = 13;
            // 
            // cmdPrimera
            // 
            this.cmdPrimera.Location = new System.Drawing.Point(516, 328);
            this.cmdPrimera.Name = "cmdPrimera";
            this.cmdPrimera.Size = new System.Drawing.Size(99, 23);
            this.cmdPrimera.TabIndex = 14;
            this.cmdPrimera.Text = "Primera pagina";
            this.cmdPrimera.UseVisualStyleBackColor = true;
            this.cmdPrimera.Click += new System.EventHandler(this.cmdPrimera_Click_1);
            // 
            // cmdProxima
            // 
            this.cmdProxima.Location = new System.Drawing.Point(763, 328);
            this.cmdProxima.Name = "cmdProxima";
            this.cmdProxima.Size = new System.Drawing.Size(99, 23);
            this.cmdProxima.TabIndex = 15;
            this.cmdProxima.Text = "Proxima pagina";
            this.cmdProxima.UseVisualStyleBackColor = true;
            this.cmdProxima.Click += new System.EventHandler(this.cmdProxima_Click_1);
            // 
            // cmdAnterior
            // 
            this.cmdAnterior.Location = new System.Drawing.Point(642, 328);
            this.cmdAnterior.Name = "cmdAnterior";
            this.cmdAnterior.Size = new System.Drawing.Size(99, 23);
            this.cmdAnterior.TabIndex = 16;
            this.cmdAnterior.Text = "Pagina anterior";
            this.cmdAnterior.UseVisualStyleBackColor = true;
            this.cmdAnterior.Click += new System.EventHandler(this.cmdAnterior_Click_1);
            // 
            // cmdUltima
            // 
            this.cmdUltima.Location = new System.Drawing.Point(884, 328);
            this.cmdUltima.Name = "cmdUltima";
            this.cmdUltima.Size = new System.Drawing.Size(99, 23);
            this.cmdUltima.TabIndex = 17;
            this.cmdUltima.Text = "Ultima pagina";
            this.cmdUltima.UseVisualStyleBackColor = true;
            this.cmdUltima.Click += new System.EventHandler(this.cmdUltima_Click_1);
            // 
            // lblCantidadTotal
            // 
            this.lblCantidadTotal.AutoSize = true;
            this.lblCantidadTotal.BackColor = System.Drawing.Color.LightGray;
            this.lblCantidadTotal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadTotal.Location = new System.Drawing.Point(801, 367);
            this.lblCantidadTotal.Name = "lblCantidadTotal";
            this.lblCantidadTotal.Size = new System.Drawing.Size(0, 13);
            this.lblCantidadTotal.TabIndex = 18;
            // 
            // lblPaginaActual
            // 
            this.lblPaginaActual.AutoSize = true;
            this.lblPaginaActual.BackColor = System.Drawing.Color.LightGray;
            this.lblPaginaActual.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaginaActual.Location = new System.Drawing.Point(710, 359);
            this.lblPaginaActual.Name = "lblPaginaActual";
            this.lblPaginaActual.Size = new System.Drawing.Size(0, 16);
            this.lblPaginaActual.TabIndex = 19;
            // 
            // lblTotalPagina
            // 
            this.lblTotalPagina.AutoSize = true;
            this.lblTotalPagina.BackColor = System.Drawing.Color.LightGray;
            this.lblTotalPagina.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPagina.Location = new System.Drawing.Point(756, 359);
            this.lblTotalPagina.Name = "lblTotalPagina";
            this.lblTotalPagina.Size = new System.Drawing.Size(0, 16);
            this.lblTotalPagina.TabIndex = 20;
            // 
            // lstRubros
            // 
            this.lstRubros.FormattingEnabled = true;
            this.lstRubros.Location = new System.Drawing.Point(215, 79);
            this.lstRubros.Name = "lstRubros";
            this.lstRubros.Size = new System.Drawing.Size(213, 69);
            this.lstRubros.TabIndex = 21;
            // 
            // cmdSeleccionarRubro
            // 
            this.cmdSeleccionarRubro.BackColor = System.Drawing.Color.LawnGreen;
            this.cmdSeleccionarRubro.Location = new System.Drawing.Point(279, 154);
            this.cmdSeleccionarRubro.Name = "cmdSeleccionarRubro";
            this.cmdSeleccionarRubro.Size = new System.Drawing.Size(75, 23);
            this.cmdSeleccionarRubro.TabIndex = 22;
            this.cmdSeleccionarRubro.Text = "Seleccionar";
            this.cmdSeleccionarRubro.UseVisualStyleBackColor = false;
            this.cmdSeleccionarRubro.Click += new System.EventHandler(this.cmdSeleccionarRubro_Click);
            // 
            // lstRubrosElegidos
            // 
            this.lstRubrosElegidos.FormattingEnabled = true;
            this.lstRubrosElegidos.Location = new System.Drawing.Point(215, 183);
            this.lstRubrosElegidos.Name = "lstRubrosElegidos";
            this.lstRubrosElegidos.Size = new System.Drawing.Size(213, 69);
            this.lstRubrosElegidos.TabIndex = 23;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(245, 331);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(165, 20);
            this.txtDescripcion.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(745, 359);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "/";
            // 
            // cmdBorrarFiltro
            // 
            this.cmdBorrarFiltro.BackColor = System.Drawing.Color.LightCoral;
            this.cmdBorrarFiltro.Location = new System.Drawing.Point(279, 258);
            this.cmdBorrarFiltro.Name = "cmdBorrarFiltro";
            this.cmdBorrarFiltro.Size = new System.Drawing.Size(75, 23);
            this.cmdBorrarFiltro.TabIndex = 26;
            this.cmdBorrarFiltro.Text = "Borrar filtro";
            this.cmdBorrarFiltro.UseVisualStyleBackColor = false;
            this.cmdBorrarFiltro.Click += new System.EventHandler(this.cmdBorrarFiltro_Click);
            // 
            // we
            // 
            this.we.BackColor = System.Drawing.Color.Moccasin;
            this.we.Location = new System.Drawing.Point(9, 280);
            this.we.Name = "we";
            this.we.Size = new System.Drawing.Size(167, 145);
            this.we.TabIndex = 27;
            this.we.Text = "COMPRAR/OFERTAR";
            this.we.UseVisualStyleBackColor = false;
            this.we.Click += new System.EventHandler(this.cmdComprarOfertar_Click);
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(9, 39);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 212);
            this.label6.TabIndex = 28;
            this.label6.Text = "Pago";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AllowDrop = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(22, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 94);
            this.label7.TabIndex = 30;
            this.label7.Text = "Desea envio?";
            // 
            // rbEnvioSi
            // 
            this.rbEnvioSi.AutoSize = true;
            this.rbEnvioSi.Location = new System.Drawing.Point(78, 107);
            this.rbEnvioSi.Margin = new System.Windows.Forms.Padding(2);
            this.rbEnvioSi.Name = "rbEnvioSi";
            this.rbEnvioSi.Size = new System.Drawing.Size(35, 17);
            this.rbEnvioSi.TabIndex = 31;
            this.rbEnvioSi.TabStop = true;
            this.rbEnvioSi.Text = "SI";
            this.rbEnvioSi.UseVisualStyleBackColor = true;
            // 
            // rbEnvioNo
            // 
            this.rbEnvioNo.AutoSize = true;
            this.rbEnvioNo.Location = new System.Drawing.Point(78, 136);
            this.rbEnvioNo.Margin = new System.Windows.Forms.Padding(2);
            this.rbEnvioNo.Name = "rbEnvioNo";
            this.rbEnvioNo.Size = new System.Drawing.Size(41, 17);
            this.rbEnvioNo.TabIndex = 32;
            this.rbEnvioNo.TabStop = true;
            this.rbEnvioNo.Text = "NO";
            this.rbEnvioNo.UseVisualStyleBackColor = true;
            // 
            // lblGuita
            // 
            this.lblGuita.AllowDrop = true;
            this.lblGuita.Location = new System.Drawing.Point(61, 183);
            this.lblGuita.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGuita.Name = "lblGuita";
            this.lblGuita.Size = new System.Drawing.Size(28, 18);
            this.lblGuita.TabIndex = 33;
            this.lblGuita.Text = "$";
            // 
            // txtGuita
            // 
            this.txtGuita.Location = new System.Drawing.Point(78, 183);
            this.txtGuita.Margin = new System.Windows.Forms.Padding(2);
            this.txtGuita.Name = "txtGuita";
            this.txtGuita.Size = new System.Drawing.Size(76, 20);
            this.txtGuita.TabIndex = 34;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(29, 185);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 35;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(78, 183);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(76, 20);
            this.txtCantidad.TabIndex = 36;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ComprarOfertar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1037, 502);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtGuita);
            this.Controls.Add(this.lblGuita);
            this.Controls.Add(this.rbEnvioNo);
            this.Controls.Add(this.rbEnvioSi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.we);
            this.Controls.Add(this.cmdBorrarFiltro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lstRubrosElegidos);
            this.Controls.Add(this.cmdSeleccionarRubro);
            this.Controls.Add(this.lstRubros);
            this.Controls.Add(this.lblTotalPagina);
            this.Controls.Add(this.lblPaginaActual);
            this.Controls.Add(this.lblCantidadTotal);
            this.Controls.Add(this.cmdUltima);
            this.Controls.Add(this.cmdAnterior);
            this.Controls.Add(this.cmdProxima);
            this.Controls.Add(this.cmdPrimera);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdVolver);
            this.Controls.Add(this.cmdLimpiar);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ComprarOfertar";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ComprarOfertar_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.Button cmdVolver;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdPrimera;
        private System.Windows.Forms.Button cmdProxima;
        private System.Windows.Forms.Button cmdAnterior;
        private System.Windows.Forms.Button cmdUltima;
        private System.Windows.Forms.Label lblCantidadTotal;
        private System.Windows.Forms.Label lblPaginaActual;
        private System.Windows.Forms.Label lblTotalPagina;
        private System.Windows.Forms.ListBox lstRubros;
        private System.Windows.Forms.Button cmdSeleccionarRubro;
        private System.Windows.Forms.ListBox lstRubrosElegidos;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdBorrarFiltro;
        private System.Windows.Forms.Button we;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbEnvioSi;
        private System.Windows.Forms.RadioButton rbEnvioNo;
        private System.Windows.Forms.Label lblGuita;
        private System.Windows.Forms.TextBox txtGuita;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Timer timer1;
    }
}