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

namespace WindowsFormsApplication1.ComprarOfertar
{
    public partial class Facturar : Form
    {
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader sdr;
        private DataBase db;
        public static Facturar fact;
        public int factId;
        public int publId;
        public int esPorConsulta;
        public string rol;

        public Facturar()
        {
            InitializeComponent();
            db = DataBase.GetInstance();
            Facturar.fact = this;
            cargarDatos();
        }

        private void Facturar_Load(object sender, EventArgs e)
        {
            cargarDatos();
            cargarTabla();
        }

        public void cargarDatos() 
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Buscar_Factura", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FactId", SqlDbType.Int).Value = factId;
            cmd.Parameters.AddWithValue("@PubliId", SqlDbType.Int).Value = publId;

            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                rol = sdr["Rol"].ToString();
                lblFactNro.Text = sdr["FactNro"].ToString();
                lblFecha.Text = sdr["Fecha"].ToString();
                if (rol == "Cliente")
                {
                    lblNombre.Text = sdr["Nombre"].ToString();
                    lblDoc.Visible = true;
                    lblCuit.Visible = false;
                    lblCuitValor.Visible = false;
                    lblDocum.Visible = true;
                    lblDoc.Text = sdr["NroDocumento"].ToString();
                }
                else if (rol == "Empresa")
                {
                    lblCuit.Visible = true;
                    lblCuitValor.Visible = true;
                    lblDocum.Visible = false;
                    lblDoc.Visible = false;
                    lblNombre.Text = sdr["RazonSocial"].ToString();
                    lblCuitValor.Text = sdr["CUIT"].ToString();
                }
                lblDom.Text = sdr["Domicilio"].ToString();                
                lblPostal.Text = sdr["CodPostal"].ToString();
                lblMonto.Text = sdr["Monto"].ToString();
            }
            sdr.Close();
        }

        public void cargarTabla() 
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Obtener_Datos_Factura", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FactNro", SqlDbType.Int).Value = factId;

            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Factura");
            adapter.Fill(dt);
            this.dataGridView1.DataSource = dt;       
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {            
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Close();
        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            if (esPorConsulta == 1)
            {
                WindowsFormsApplication1.Facturas.ConsultaFacturas.cf.Show();
                this.Close();
            }
            else
            {
                WindowsFormsApplication1.Generar_Publicación.EstadoPublicacion.estado.Show();
                this.Close();
            }
        }
    }
}
