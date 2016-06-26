namespace WindowsFormsApplication1.Generar_Publicación
{
    partial class AltaPublicacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblStockInmediata = new System.Windows.Forms.Label();
            this.lblValorSubasta = new System.Windows.Forms.Label();
            this.lblFin = new System.Windows.Forms.Label();
            this.lblRubro = new System.Windows.Forms.Label();
            this.cmdLimpiar = new System.Windows.Forms.Button();
            this.cmdVolver = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblRubroSe = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtValorSubasta = new System.Windows.Forms.TextBox();
            this.txtStockInmediata = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblVisibilidad = new System.Windows.Forms.Label();
            this.lblVisSel = new System.Windows.Forms.Label();
            this.cmdSelVis = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.cboRubro = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdCrearActivar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 286);
            this.label1.TabIndex = 0;
            this.label1.Text = "Creacion de publicacion";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(78, 88);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // lblStockInmediata
            // 
            this.lblStockInmediata.AutoSize = true;
            this.lblStockInmediata.Location = new System.Drawing.Point(106, 119);
            this.lblStockInmediata.Name = "lblStockInmediata";
            this.lblStockInmediata.Size = new System.Drawing.Size(38, 13);
            this.lblStockInmediata.TabIndex = 2;
            this.lblStockInmediata.Text = "Stock:";
            // 
            // lblValorSubasta
            // 
            this.lblValorSubasta.AutoSize = true;
            this.lblValorSubasta.Location = new System.Drawing.Point(81, 119);
            this.lblValorSubasta.Name = "lblValorSubasta";
            this.lblValorSubasta.Size = new System.Drawing.Size(63, 13);
            this.lblValorSubasta.TabIndex = 3;
            this.lblValorSubasta.Text = "Valor inicial:";
            this.lblValorSubasta.Click += new System.EventHandler(this.lblValorSubasta_Click);
            // 
            // lblFin
            // 
            this.lblFin.AutoSize = true;
            this.lblFin.Location = new System.Drawing.Point(28, 151);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(116, 13);
            this.lblFin.TabIndex = 4;
            this.lblFin.Text = "Fecha de Vencimiento:";
            // 
            // lblRubro
            // 
            this.lblRubro.AutoSize = true;
            this.lblRubro.Location = new System.Drawing.Point(105, 195);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(39, 13);
            this.lblRubro.TabIndex = 5;
            this.lblRubro.Text = "Rubro:";
            // 
            // cmdLimpiar
            // 
            this.cmdLimpiar.BackColor = System.Drawing.Color.LightCoral;
            this.cmdLimpiar.Location = new System.Drawing.Point(246, 323);
            this.cmdLimpiar.Name = "cmdLimpiar";
            this.cmdLimpiar.Size = new System.Drawing.Size(97, 23);
            this.cmdLimpiar.TabIndex = 6;
            this.cmdLimpiar.Text = "Limpiar";
            this.cmdLimpiar.UseVisualStyleBackColor = false;
            this.cmdLimpiar.Click += new System.EventHandler(this.cmdLimpiar_Click);
            // 
            // cmdVolver
            // 
            this.cmdVolver.BackColor = System.Drawing.Color.Cyan;
            this.cmdVolver.Location = new System.Drawing.Point(246, 352);
            this.cmdVolver.Name = "cmdVolver";
            this.cmdVolver.Size = new System.Drawing.Size(97, 23);
            this.cmdVolver.TabIndex = 8;
            this.cmdVolver.Text = "Volver";
            this.cmdVolver.UseVisualStyleBackColor = false;
            this.cmdVolver.Click += new System.EventHandler(this.cmdVolver_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.Color.LawnGreen;
            this.cmdAceptar.Location = new System.Drawing.Point(47, 323);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(97, 23);
            this.cmdAceptar.TabIndex = 9;
            this.cmdAceptar.Text = "Aceptar Borrador";
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // dtpFin
            // 
            this.dtpFin.Location = new System.Drawing.Point(158, 151);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(153, 20);
            this.dtpFin.TabIndex = 10;
            this.dtpFin.Value = new System.DateTime(2015, 7, 15, 0, 0, 0, 0);
            this.dtpFin.ValueChanged += new System.EventHandler(this.dtpFin_ValueChanged);
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Subasta",
            "Compra inmediata"});
            this.cboTipo.Location = new System.Drawing.Point(31, 49);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(124, 21);
            this.cboTipo.TabIndex = 11;
            this.cboTipo.Text = "Seleccione un tipo ";
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // lblRubroSe
            // 
            this.lblRubroSe.AutoSize = true;
            this.lblRubroSe.Location = new System.Drawing.Point(155, 195);
            this.lblRubroSe.Name = "lblRubroSe";
            this.lblRubroSe.Size = new System.Drawing.Size(0, 13);
            this.lblRubroSe.TabIndex = 12;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(158, 85);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcion.TabIndex = 14;
            // 
            // txtValorSubasta
            // 
            this.txtValorSubasta.Location = new System.Drawing.Point(158, 116);
            this.txtValorSubasta.Name = "txtValorSubasta";
            this.txtValorSubasta.Size = new System.Drawing.Size(100, 20);
            this.txtValorSubasta.TabIndex = 15;
            // 
            // txtStockInmediata
            // 
            this.txtStockInmediata.Location = new System.Drawing.Point(158, 116);
            this.txtStockInmediata.Name = "txtStockInmediata";
            this.txtStockInmediata.Size = new System.Drawing.Size(100, 20);
            this.txtStockInmediata.TabIndex = 16;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.NavajoWhite;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(397, 24);
            this.menuStrip1.TabIndex = 17;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 381);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(397, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "(*)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "(*)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "(*)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "(*)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(82, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "(*)";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(94, 275);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(50, 13);
            this.lblPrecio.TabIndex = 24;
            this.lblPrecio.Text = "(*)Precio:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 291);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "(*) Campos obligatorios";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(158, 268);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 26;
            // 
            // lblVisibilidad
            // 
            this.lblVisibilidad.AutoSize = true;
            this.lblVisibilidad.Location = new System.Drawing.Point(78, 228);
            this.lblVisibilidad.Name = "lblVisibilidad";
            this.lblVisibilidad.Size = new System.Drawing.Size(66, 13);
            this.lblVisibilidad.TabIndex = 27;
            this.lblVisibilidad.Text = "(*)Visibilidad:";
            // 
            // lblVisSel
            // 
            this.lblVisSel.AutoSize = true;
            this.lblVisSel.Location = new System.Drawing.Point(158, 228);
            this.lblVisSel.Name = "lblVisSel";
            this.lblVisSel.Size = new System.Drawing.Size(0, 13);
            this.lblVisSel.TabIndex = 28;
            // 
            // cmdSelVis
            // 
            this.cmdSelVis.BackColor = System.Drawing.Color.LawnGreen;
            this.cmdSelVis.Location = new System.Drawing.Point(309, 228);
            this.cmdSelVis.Name = "cmdSelVis";
            this.cmdSelVis.Size = new System.Drawing.Size(75, 23);
            this.cmdSelVis.TabIndex = 29;
            this.cmdSelVis.Text = "Seleccionar";
            this.cmdSelVis.UseVisualStyleBackColor = false;
            this.cmdSelVis.Click += new System.EventHandler(this.cmdSelVis_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(476, 237);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 13);
            this.lblUsername.TabIndex = 30;
            this.lblUsername.Visible = false;
            // 
            // cboRubro
            // 
            this.cboRubro.FormattingEnabled = true;
            this.cboRubro.Location = new System.Drawing.Point(158, 192);
            this.cboRubro.Name = "cboRubro";
            this.cboRubro.Size = new System.Drawing.Size(153, 21);
            this.cboRubro.TabIndex = 31;
            this.cboRubro.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(12, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(139, 13);
            this.lblTitulo.TabIndex = 32;
            this.lblTitulo.Text = "Modificación de publicación";
            this.lblTitulo.Visible = false;
            // 
            // cmdModificar
            // 
            this.cmdModificar.BackColor = System.Drawing.Color.LawnGreen;
            this.cmdModificar.Location = new System.Drawing.Point(47, 323);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(97, 23);
            this.cmdModificar.TabIndex = 33;
            this.cmdModificar.Text = "Modificar";
            this.cmdModificar.UseVisualStyleBackColor = false;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdCrearActivar
            // 
            this.cmdCrearActivar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.cmdCrearActivar.Location = new System.Drawing.Point(47, 352);
            this.cmdCrearActivar.Name = "cmdCrearActivar";
            this.cmdCrearActivar.Size = new System.Drawing.Size(97, 23);
            this.cmdCrearActivar.TabIndex = 34;
            this.cmdCrearActivar.Text = "Aceptar y Activar";
            this.cmdCrearActivar.UseVisualStyleBackColor = false;
            this.cmdCrearActivar.Click += new System.EventHandler(this.button1_Click);
            // 
            // AltaPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(397, 403);
            this.Controls.Add(this.cmdCrearActivar);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.cboRubro);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.cmdSelVis);
            this.Controls.Add(this.lblVisSel);
            this.Controls.Add(this.lblVisibilidad);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtStockInmediata);
            this.Controls.Add(this.txtValorSubasta);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblRubroSe);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.cmdVolver);
            this.Controls.Add(this.cmdLimpiar);
            this.Controls.Add(this.lblRubro);
            this.Controls.Add(this.lblFin);
            this.Controls.Add(this.lblValorSubasta);
            this.Controls.Add(this.lblStockInmediata);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AltaPublicacion";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AltaPublicacion_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblStockInmediata;
        private System.Windows.Forms.Label lblValorSubasta;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.Button cmdLimpiar;
        private System.Windows.Forms.Button cmdVolver;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtValorSubasta;
        private System.Windows.Forms.TextBox txtStockInmediata;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.Label lblRubroSe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblVisibilidad;
        private System.Windows.Forms.Button cmdSelVis;
        public System.Windows.Forms.Label lblVisSel;
        public System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ComboBox cboRubro;
        private System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.Button cmdModificar;
        public System.Windows.Forms.Button cmdCrearActivar;
        public System.Windows.Forms.Button cmdAceptar;
    }
}