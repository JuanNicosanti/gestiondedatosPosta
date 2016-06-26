using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Calificar
{
    public partial class CalificarVendedor : Form
    {
        SqlCommand cmd;
        SqlDataReader sdr;
        SqlDataAdapter adapter;
        private DataBase db;
        public string user;
        public int calificacion;        
        public static CalificarVendedor calif;

        public CalificarVendedor()
        {
            db = DataBase.GetInstance();
            CalificarVendedor.calif = this;
            InitializeComponent();           
            user = WindowsFormsApplication1.Form1.f1.user;            
            cargarTabla();           
        }

        private void CalificarVendedor_Load(object sender, EventArgs e)
        {           
            
        }

        public void cargarTabla() {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Transacciones_Sin_Calificar", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = user;            

            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Transaccion");
            adapter.Fill(dt);
            this.dgPublis.DataSource = dt;
        }    

        private void cmdCalificar_Click(object sender, EventArgs e)
        {
            if (rb1.Checked) calificacion = 1;
            else if (rb2.Checked) calificacion = 2;
            else if (rb3.Checked) calificacion = 3;
            else if (rb4.Checked) calificacion = 4;
            else if (rb5.Checked) calificacion = 5;
            else {
                MessageBox.Show("Debe ingresar una calificación", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            int fila = dgPublis.CurrentRow.Index;

            cmd = new SqlCommand("ROAD_TO_PROYECTO.Calificar_Transaccion", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@TranId", SqlDbType.Int).Value = (int)dgPublis[0, fila].Value;
            cmd.Parameters.AddWithValue("@CantidadEstrellas", SqlDbType.Int).Value = calificacion;
            cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.NVarChar).Value = taDetalle.Text;
            cmd.ExecuteNonQuery();
            
            MessageBox.Show("Publicación calificada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            cargarTabla();
            panelCalificaciones.Visible = false;
            lblDetalle.Visible = false;
            taDetalle.Visible = false;
            cmdCalificar.Visible = false;
        }

        private void panelCalificaciones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Calificar.MenuCalificaciones.menuCalif.Show();
            this.Close();
        }

        private void dgPublis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgPublis.CurrentRow != null)
            {
                panelCalificaciones.Visible = true;
                cmdCalificar.Visible = true;
                lblDetalle.Visible = true;
                taDetalle.Visible = true;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Close();
        }
    }
}
