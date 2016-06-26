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


namespace WindowsFormsApplication1.ABM_Visibilidad
{
    public partial class Form1 : Form
    {

        SqlCommand cmd;
        SqlDataReader sdr;
        SqlDataAdapter adapter;
        private DataBase db;
        public string user;
        public static Form1 visibilidad;
        private int envioHab;

        public Form1()
        {
            db = DataBase.GetInstance();
            Form1.visibilidad = this;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelComs.Visible = false;

            cargarComboBox();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelEnvio.Visible = false;
            if (cboTipoVis.SelectedIndex != -1)
            {
                if (cboTipoVis.SelectedValue.ToString() == "Gratis")
                {
                    cbEnvio.Visible = false;
                }
                else
                {
                    cbEnvio.Visible = true;
                    cbEnvio.Checked = false;
                }
                panelComs.Visible = true;                
                textBoxTipo.Enabled = false;
                textBoxProd.Enabled = false;
                textBoxEnvio.Enabled = false;

                cmd = new SqlCommand("ROAD_TO_PROYECTO.Comisiones_Valores", db.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Visibilidad", SqlDbType.NVarChar).Value = cboTipoVis.SelectedValue.ToString();

                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    textBoxTipo.Text = sdr["ComiFija"].ToString();
                    textBoxProd.Text = sdr["ComiVariable"].ToString();
                    textBoxEnvio.Text = sdr["ComiEnvio"].ToString();
                }
                sdr.Close();
            }
        }

        private void cbEnvio_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnvio.Checked == false)
            {
                panelEnvio.Visible = false;
            } else 
            {
                panelEnvio.Visible = true;
            }
        }        

        public void cargarComboBox() //Vuelvo a traer los valores de Visibilidad para actualizar el ComboBox
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Comisiones_Visibilidad", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@UserId", SqlDbType.NVarChar).Value = user;

            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Visibilidad");
            adapter.Fill(dt);
            this.cboTipoVis.DataSource = dt;
            this.cboTipoVis.DisplayMember = "Descripcion";

            cboTipoVis.ValueMember = cboTipoVis.DisplayMember;
            cboTipoVis.SelectedIndex = -1;
            cboTipoVis.Text = "Seleccione un tipo de visibilidad";
        }

        private void cmdAceptarComisiones_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Generar_Publicación.AltaPublicacion.ap1.lblVisSel.Text = cboTipoVis.SelectedValue.ToString();
            if (cbEnvio.Checked) envioHab = 1;
            else envioHab = 0;
            WindowsFormsApplication1.Generar_Publicación.AltaPublicacion.ap1.envioHabilitado = envioHab;
            WindowsFormsApplication1.Generar_Publicación.AltaPublicacion.ap1.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Close();
        }              

    }
}
