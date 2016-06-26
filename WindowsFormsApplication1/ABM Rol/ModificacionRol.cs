using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1.ABM_Rol
{
    public partial class ModificacionRol : Form
    {
        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataReader sdr;
        SqlDataAdapter adapter;
        private DataBase db;
        public ModificacionRol()
        {
            InitializeComponent();
            db = DataBase.GetInstance();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.f1.Close(); 
        }

        private void ModificacionRol_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.ListaRoles", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Rol");
            adapter.Fill(dt);
            this.dataGridView1.DataSource = dt;

          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            Form1.f1.Show();
            this.Hide();
        }

        private void cmdModificarRol_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {

                MessageBox.Show("Debe seleccionar un Rol a modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            int fila = dataGridView1.CurrentRow.Index;
            
            int celdaIdRol = (int)dataGridView1[0, fila].Value;
            String filaNombreRol = dataGridView1[1,fila].Value.ToString();
            AltaRol aRol = new AltaRol();
            aRol.idRolAModificar = celdaIdRol;
            aRol.txtNuevoRol.Text = filaNombreRol;
            aRol.esAltaRol = 0;
            aRol.cargarFuncionalidadesElegidasDeDeterminadoRol(celdaIdRol);
         
            
            aRol.Show();
            this.Hide();

    
        }

        private void cmdHabilitarRol_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {

                MessageBox.Show("Debe seleccionar un Rol a modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            int fila = dataGridView1.CurrentRow.Index;

            int celdaIdRol = (int)dataGridView1[0, fila].Value;
            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.HabilitarRol", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Rol", SqlDbType.Int).Value = celdaIdRol;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se ha habilitado el rol con exito", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);


            cmd = new SqlCommand("ROAD_TO_PROYECTO.ListaRoles", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Rol");
            adapter.Fill(dt);
            this.dataGridView1.DataSource = dt;


        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {

                MessageBox.Show("Debe seleccionar un Rol", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            int fila = dataGridView1.CurrentRow.Index;
            int celdaIdRol = (int)dataGridView1[0, fila].Value;

            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.BajaRol", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Rol", SqlDbType.Int).Value = celdaIdRol;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se dio de baja satisfactoriamente", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

           /*
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();*/

            cmd = new SqlCommand("ROAD_TO_PROYECTO.ListaRoles", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Rol");
            adapter.Fill(dt);
            this.dataGridView1.DataSource = dt;


        }

    }
}
