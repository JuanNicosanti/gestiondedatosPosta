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

namespace WindowsFormsApplication1.Generar_Publicación
{
    public partial class EstadoPublicacion : Form
    {
        SqlCommand cmd;
        SqlDataReader sdr;
        SqlDataAdapter adapter;
        private DataBase db;
        public string user;
        public static EstadoPublicacion estado;
        private int fila;
        private int factId;
        private int esNuevo;
        private string visibPubli;

        public EstadoPublicacion()
        {
            InitializeComponent();
            EstadoPublicacion.estado = this;
            db = DataBase.GetInstance();
            cargarEstados();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            cargarTabla();            
            dgPublis.Visible = true;
        }

        public void cargarTabla()
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Buscar_Publicacion_Estado", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = user;
            cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.NVarChar).Value = tbDescripcion.Text;
            if (cboEstados.SelectedIndex != -1)
            {
                cmd.Parameters.AddWithValue("@Estado", SqlDbType.NVarChar).Value = cboEstados.SelectedValue.ToString();
            }
            else
            {
                cmd.Parameters.AddWithValue("@Estado", SqlDbType.NVarChar).Value = "";
            }
            

            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Publicacion");
            adapter.Fill(dt);
            this.dgPublis.DataSource = dt;
        }

        private void cargarEstados() {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.lista_Estados", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Estado");
            adapter.Fill(dt);
            this.cboEstados.DataSource = dt;
            this.cboEstados.DisplayMember = "Descripcion";

            cboEstados.ValueMember = cboEstados.DisplayMember;
            cboEstados.SelectedIndex = -1;
            cboEstados.Text = "Seleccione un estado";
        }

        private void cboEstados_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dgPublis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgPublis.CurrentRow.Index != -1)
            { 
                fila = dgPublis.CurrentRow.Index;
                if (dgPublis[3, fila].Value.ToString() == "Activa")
                {
                    cmdActivar.Visible = false;                    
                    cmdPausar.Visible = true;
                    cmdFinalizar.Visible = true;
                    cmdModificar.Visible = false;
                }
                if (dgPublis[3, fila].Value.ToString() == "Pausada")
                {
                    cmdActivar.Visible = true;
                    cmdPausar.Visible = false;
                    cmdFinalizar.Visible = true;
                    cmdModificar.Visible = false;
                }
                if (dgPublis[3, fila].Value.ToString() == "Finalizada")
                {
                    cmdActivar.Visible = false;
                    cmdPausar.Visible = false;
                    cmdFinalizar.Visible = false;
                    cmdModificar.Visible = false;
                }
                if (dgPublis[3, fila].Value.ToString() == "Borrador")
                {
                    cmdActivar.Visible = true;
                    cmdPausar.Visible = false;
                    cmdFinalizar.Visible = false;
                    cmdModificar.Visible = true;
                }
            }
        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Show();
            this.Close();
        }

        private void cmdActivar_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Activar_Publicacion", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PubliId", SqlDbType.Int).Value = (int)dgPublis[0, fila].Value;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Publicación activada");
            cargarTabla();        
        }

        private void cmdPausar_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Pausar_Publicacion", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PubliId", SqlDbType.Int).Value = (int)dgPublis[0, fila].Value;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Publicación pausada");
            cargarTabla();        
        }

        private void cmdFinalizar_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Usuario_Nuevo", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.Int).Value = user;

            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                esNuevo = int.Parse(sdr["Nuevo"].ToString());
            }
            sdr.Close();

            cmd = new SqlCommand("ROAD_TO_PROYECTO.Visibilidad_Publicacion", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PubliId", SqlDbType.Int).Value = (int)dgPublis[0, fila].Value;

            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                visibPubli = sdr["Descripcion"].ToString();
            }
            sdr.Close();

            cmd = new SqlCommand("ROAD_TO_PROYECTO.Finalizar_Publicacion", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PubliId", SqlDbType.Int).Value = (int)dgPublis[0, fila].Value;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Publicación finalizada");            

            dgPublis.Visible = false;
            cmdActivar.Visible = false;
            cmdModificar.Visible = false;
            cmdPausar.Visible = false;
            cmdFinalizar.Visible = false;

            if (esNuevo == 0 && !(visibPubli == "Gratis"))
            {
                cmd = new SqlCommand("ROAD_TO_PROYECTO.Buscar_Ultima_Factura", db.Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    factId = int.Parse(sdr["FactNro"].ToString());
                }
                sdr.Close();                

                WindowsFormsApplication1.ComprarOfertar.Facturar factura = new WindowsFormsApplication1.ComprarOfertar.Facturar();
                factura.factId = factId;
                factura.publId = int.Parse(dgPublis[0, fila].Value.ToString());
                factura.esPorConsulta = 0;
                factura.Show();
                this.Hide();
            }            
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Generar_Publicación.AltaPublicacion ap1 = new WindowsFormsApplication1.Generar_Publicación.AltaPublicacion();
            ap1.esModif = 1;
            ap1.cmdCrearActivar.Visible = false;
            ap1.cmdAceptar.Visible = false;
            ap1.cmdModificar.Visible = true;
            ap1.lblUsername.Text = user;
            ap1.publiId = (int)dgPublis[0, fila].Value;
            ap1.Show();            
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Close();
        }        
    }
}
