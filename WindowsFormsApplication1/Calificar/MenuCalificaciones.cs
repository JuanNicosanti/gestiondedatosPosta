using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Calificar
{
    public partial class MenuCalificaciones : Form
    {
        public static MenuCalificaciones menuCalif;

        public MenuCalificaciones()
        {
            InitializeComponent();
            MenuCalificaciones.menuCalif = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Calificar.CalificarVendedor cv = new WindowsFormsApplication1.Calificar.CalificarVendedor();
            cv.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Calificar.HistorialCalificaciones hcalif = new WindowsFormsApplication1.Calificar.HistorialCalificaciones();
            hcalif.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Close();
        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            Form1.f1.Show();
            this.Hide();
        }
    }
}
