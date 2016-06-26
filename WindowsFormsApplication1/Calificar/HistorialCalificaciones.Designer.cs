namespace WindowsFormsApplication1.Calificar
{
    partial class HistorialCalificaciones
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgComprasCalif = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCompras = new System.Windows.Forms.Label();
            this.lblUnaStar = new System.Windows.Forms.Label();
            this.lblDosStar = new System.Windows.Forms.Label();
            this.lblTresStar = new System.Windows.Forms.Label();
            this.lblCuatroStar = new System.Windows.Forms.Label();
            this.lblCincoStar = new System.Windows.Forms.Label();
            this.cmdVolver = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label8 = new System.Windows.Forms.Label();
            this.lblComprasSinCalificar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgComprasCalif)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Últimas publicaciones calificadas";
            // 
            // dgComprasCalif
            // 
            this.dgComprasCalif.AllowUserToAddRows = false;
            this.dgComprasCalif.AllowUserToDeleteRows = false;
            this.dgComprasCalif.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgComprasCalif.Location = new System.Drawing.Point(22, 53);
            this.dgComprasCalif.Name = "dgComprasCalif";
            this.dgComprasCalif.ReadOnly = true;
            this.dgComprasCalif.Size = new System.Drawing.Size(442, 150);
            this.dgComprasCalif.TabIndex = 1;
            this.dgComprasCalif.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgComprasCalif_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cantidad de compras realizadas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cantidad de compras calificadas con una estrella:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cantidad de compras calificadas con tres estrellas:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 322);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cantidad de compras calificadas con cuatro estrellas:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(254, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Cantidad de compras calificadas con cinco estrellas:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 282);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(245, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Cantidad de compras calificadas con dos estrellas:";
            // 
            // lblCompras
            // 
            this.lblCompras.AutoSize = true;
            this.lblCompras.Location = new System.Drawing.Point(185, 216);
            this.lblCompras.Name = "lblCompras";
            this.lblCompras.Size = new System.Drawing.Size(35, 13);
            this.lblCompras.TabIndex = 8;
            this.lblCompras.Text = "label8";
            // 
            // lblUnaStar
            // 
            this.lblUnaStar.AutoSize = true;
            this.lblUnaStar.Location = new System.Drawing.Point(266, 263);
            this.lblUnaStar.Name = "lblUnaStar";
            this.lblUnaStar.Size = new System.Drawing.Size(35, 13);
            this.lblUnaStar.TabIndex = 9;
            this.lblUnaStar.Text = "label9";
            // 
            // lblDosStar
            // 
            this.lblDosStar.AutoSize = true;
            this.lblDosStar.Location = new System.Drawing.Point(266, 282);
            this.lblDosStar.Name = "lblDosStar";
            this.lblDosStar.Size = new System.Drawing.Size(41, 13);
            this.lblDosStar.TabIndex = 10;
            this.lblDosStar.Text = "label10";
            // 
            // lblTresStar
            // 
            this.lblTresStar.AutoSize = true;
            this.lblTresStar.Location = new System.Drawing.Point(266, 301);
            this.lblTresStar.Name = "lblTresStar";
            this.lblTresStar.Size = new System.Drawing.Size(41, 13);
            this.lblTresStar.TabIndex = 11;
            this.lblTresStar.Text = "label11";
            // 
            // lblCuatroStar
            // 
            this.lblCuatroStar.AutoSize = true;
            this.lblCuatroStar.Location = new System.Drawing.Point(283, 322);
            this.lblCuatroStar.Name = "lblCuatroStar";
            this.lblCuatroStar.Size = new System.Drawing.Size(41, 13);
            this.lblCuatroStar.TabIndex = 12;
            this.lblCuatroStar.Text = "label12";
            // 
            // lblCincoStar
            // 
            this.lblCincoStar.AutoSize = true;
            this.lblCincoStar.Location = new System.Drawing.Point(279, 343);
            this.lblCincoStar.Name = "lblCincoStar";
            this.lblCincoStar.Size = new System.Drawing.Size(41, 13);
            this.lblCincoStar.TabIndex = 13;
            this.lblCincoStar.Text = "label13";
            // 
            // cmdVolver
            // 
            this.cmdVolver.BackColor = System.Drawing.Color.Cyan;
            this.cmdVolver.Location = new System.Drawing.Point(389, 338);
            this.cmdVolver.Name = "cmdVolver";
            this.cmdVolver.Size = new System.Drawing.Size(75, 23);
            this.cmdVolver.TabIndex = 14;
            this.cmdVolver.Text = "Volver";
            this.cmdVolver.UseVisualStyleBackColor = false;
            this.cmdVolver.Click += new System.EventHandler(this.cmdVolver_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.NavajoWhite;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(571, 24);
            this.menuStrip1.TabIndex = 15;
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
            this.statusStrip1.Size = new System.Drawing.Size(571, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(215, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Cantidad de compras realizadas sin calificar:";
            // 
            // lblComprasSinCalificar
            // 
            this.lblComprasSinCalificar.AutoSize = true;
            this.lblComprasSinCalificar.Location = new System.Drawing.Point(238, 238);
            this.lblComprasSinCalificar.Name = "lblComprasSinCalificar";
            this.lblComprasSinCalificar.Size = new System.Drawing.Size(35, 13);
            this.lblComprasSinCalificar.TabIndex = 18;
            this.lblComprasSinCalificar.Text = "label8";
            // 
            // HistorialCalificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(571, 403);
            this.Controls.Add(this.lblComprasSinCalificar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmdVolver);
            this.Controls.Add(this.lblCincoStar);
            this.Controls.Add(this.lblCuatroStar);
            this.Controls.Add(this.lblTresStar);
            this.Controls.Add(this.lblDosStar);
            this.Controls.Add(this.lblUnaStar);
            this.Controls.Add(this.lblCompras);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgComprasCalif);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HistorialCalificaciones";
            this.Text = "HistorialCalificaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dgComprasCalif)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgComprasCalif;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCompras;
        private System.Windows.Forms.Label lblUnaStar;
        private System.Windows.Forms.Label lblDosStar;
        private System.Windows.Forms.Label lblTresStar;
        private System.Windows.Forms.Label lblCuatroStar;
        private System.Windows.Forms.Label lblCincoStar;
        private System.Windows.Forms.Button cmdVolver;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblComprasSinCalificar;
    }
}