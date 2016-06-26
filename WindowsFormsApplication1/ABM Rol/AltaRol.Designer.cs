namespace WindowsFormsApplication1.ABM_Rol
{
    partial class AltaRol
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
            this.txtNuevoRol = new System.Windows.Forms.TextBox();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.cmdBorrar = new System.Windows.Forms.Button();
            this.cmdVolver = new System.Windows.Forms.Button();
            this.lstFuncionalidades = new System.Windows.Forms.ListBox();
            this.lstFuncElegidas = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cmdBorrarUnaFunc = new System.Windows.Forms.Button();
            this.cmdSeleccionar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.NavajoWhite;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(616, 24);
            this.menuStrip1.TabIndex = 0;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 278);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(616, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(-2, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 66);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rol:";
            // 
            // txtNuevoRol
            // 
            this.txtNuevoRol.Location = new System.Drawing.Point(22, 50);
            this.txtNuevoRol.Name = "txtNuevoRol";
            this.txtNuevoRol.Size = new System.Drawing.Size(127, 20);
            this.txtNuevoRol.TabIndex = 3;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.Color.Chartreuse;
            this.cmdAceptar.Location = new System.Drawing.Point(198, 36);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(94, 44);
            this.cmdAceptar.TabIndex = 4;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.BackColor = System.Drawing.Color.Cyan;
            this.cmdBorrar.Location = new System.Drawing.Point(313, 37);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(94, 44);
            this.cmdBorrar.TabIndex = 5;
            this.cmdBorrar.Text = "Borrar todo";
            this.cmdBorrar.UseVisualStyleBackColor = false;
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // cmdVolver
            // 
            this.cmdVolver.BackColor = System.Drawing.Color.Thistle;
            this.cmdVolver.Location = new System.Drawing.Point(430, 36);
            this.cmdVolver.Name = "cmdVolver";
            this.cmdVolver.Size = new System.Drawing.Size(94, 43);
            this.cmdVolver.TabIndex = 6;
            this.cmdVolver.Text = "Volver";
            this.cmdVolver.UseVisualStyleBackColor = false;
            this.cmdVolver.Click += new System.EventHandler(this.cmdVolver_Click_1);
            // 
            // lstFuncionalidades
            // 
            this.lstFuncionalidades.FormattingEnabled = true;
            this.lstFuncionalidades.Location = new System.Drawing.Point(0, 115);
            this.lstFuncionalidades.Name = "lstFuncionalidades";
            this.lstFuncionalidades.Size = new System.Drawing.Size(301, 134);
            this.lstFuncionalidades.TabIndex = 7;
            this.lstFuncionalidades.SelectedIndexChanged += new System.EventHandler(this.lstFuncionalidades_SelectedIndexChanged);
            // 
            // lstFuncElegidas
            // 
            this.lstFuncElegidas.FormattingEnabled = true;
            this.lstFuncElegidas.Location = new System.Drawing.Point(313, 115);
            this.lstFuncElegidas.Name = "lstFuncElegidas";
            this.lstFuncElegidas.Size = new System.Drawing.Size(303, 134);
            this.lstFuncElegidas.TabIndex = 8;
            this.lstFuncElegidas.SelectedIndexChanged += new System.EventHandler(this.lstFuncElegidas_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cmdBorrarUnaFunc
            // 
            this.cmdBorrarUnaFunc.BackColor = System.Drawing.Color.DarkSalmon;
            this.cmdBorrarUnaFunc.Location = new System.Drawing.Point(366, 252);
            this.cmdBorrarUnaFunc.Name = "cmdBorrarUnaFunc";
            this.cmdBorrarUnaFunc.Size = new System.Drawing.Size(200, 23);
            this.cmdBorrarUnaFunc.TabIndex = 9;
            this.cmdBorrarUnaFunc.Text = "Borrar funcionalidad";
            this.cmdBorrarUnaFunc.UseVisualStyleBackColor = false;
            this.cmdBorrarUnaFunc.Click += new System.EventHandler(this.cmdBorrarUnaFunc_Click);
            // 
            // cmdSeleccionar
            // 
            this.cmdSeleccionar.BackColor = System.Drawing.Color.DarkSalmon;
            this.cmdSeleccionar.Location = new System.Drawing.Point(48, 252);
            this.cmdSeleccionar.Name = "cmdSeleccionar";
            this.cmdSeleccionar.Size = new System.Drawing.Size(200, 23);
            this.cmdSeleccionar.TabIndex = 10;
            this.cmdSeleccionar.Text = "Seleccionar";
            this.cmdSeleccionar.UseVisualStyleBackColor = false;
            this.cmdSeleccionar.Click += new System.EventHandler(this.cmdSeleccionar_Click);
            // 
            // AltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(616, 300);
            this.Controls.Add(this.cmdSeleccionar);
            this.Controls.Add(this.cmdBorrarUnaFunc);
            this.Controls.Add(this.lstFuncElegidas);
            this.Controls.Add(this.lstFuncionalidades);
            this.Controls.Add(this.cmdVolver);
            this.Controls.Add(this.cmdBorrar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.txtNuevoRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AltaRol";
            this.Load += new System.EventHandler(this.AltaRol_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdBorrar;
        private System.Windows.Forms.Button cmdVolver;
        private System.Windows.Forms.ListBox lstFuncionalidades;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button cmdBorrarUnaFunc;
        private System.Windows.Forms.Button cmdSeleccionar;
        public System.Windows.Forms.TextBox txtNuevoRol;
        public System.Windows.Forms.ListBox lstFuncElegidas;
    }
}