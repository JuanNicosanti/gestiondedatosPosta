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

namespace WindowsFormsApplication1.Listado_Estadistico
{
    public partial class Listado_Estadistico : Form
    {
        public static Listado_Estadistico lE;
        private DataBase db;
        SqlCommand cmd;
        SqlDataReader sdr;
        SqlDataAdapter adapter;

        private int indexTrimestreSeleccionado;
        private int anio;
        private String rubroElegido;
        private String visibilidadesElegidas;
        

        public Listado_Estadistico()
        {
            InitializeComponent();
            db = DataBase.GetInstance();
            Listado_Estadistico.lE = this;
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

        private void Listado_Estadistico_Load(object sender, EventArgs e)
        {
            lblTrim.Visible = false;
            cmdTrimestre.Visible = false;
            cboTrim.Visible = false;
            
            lblTopp.Visible = false;
            cmdTop1.Visible = false;
            cmdTop2.Visible = false;
            cmdTop3.Visible = false;
            cmdTop4.Visible = false;

            lblRubro.Visible = false;
            cmdRubro.Visible = false;
            cboRubro.Visible = false;

            lstVisi.Visible = false;
            lstVisiSel.Visible = false;
            cmdVisiAceptar.Visible = false;
            cmdVisiBorrar.Visible = false;
            cmdVisiSel.Visible = false;
            lblVisi.Visible = false;

        }

        private void cmdAnio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAnio.Text))
            {
                MessageBox.Show("Debe ingresar un año", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
               
            }
            if (int.Parse(txtAnio.Text) <= 0)
            {
                MessageBox.Show("No se aceptan años negativos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            txtAnio.Enabled = false;
            anio = int.Parse(txtAnio.Text.ToString());
            lblTrim.Visible = true;
            cmdTrimestre.Visible = true;
            cboTrim.Visible = true;
        }

        private void cmdTrimestre_Click(object sender, EventArgs e)
        {
            if (cboTrim.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un trimestre", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;

            }
            indexTrimestreSeleccionado = cboTrim.SelectedIndex;
            cboTrim.Enabled = false;
            lblTopp.Visible = true;
            cmdTop1.Visible = true;
            cmdTop2.Visible = true;
            cmdTop3.Visible = true;
            cmdTop4.Visible = true;
        }

        private void cmdTop1_Click(object sender, EventArgs e)
        {


            cmd = new SqlCommand("ROAD_TO_PROYECTO.Ver_Visibilidades", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Funcion");
            adapter.Fill(dt);
            this.lstVisi.DataSource = dt;
            this.lstVisi.DisplayMember = "Descripcion";
            lstVisi.ValueMember = lstVisi.DisplayMember;
            lstVisiSel.Items.Clear();

            MessageBox.Show("Seleccione si desea filtrar por visibilidad", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            lblRubro.Visible = false;
            cmdRubro.Visible = false;
            cboRubro.Visible = false;
            cboRubro.Enabled = true;

            lstVisi.Visible = true;
            lstVisiSel.Visible = true;
            cmdVisiAceptar.Visible = true;
            cmdVisiBorrar.Visible = true;
            cmdVisiSel.Visible = true;
            lblVisi.Visible = true;
            


        }

        private void cmdTop3_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("ROAD_TO_PROYECTO.Cantidad_Facturas_Vendedores", db.Connection);
            cmd.Parameters.AddWithValue("@Trimestre", SqlDbType.Int).Value = (indexTrimestreSeleccionado+1);
            cmd.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = anio;
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Usuario");
            adapter.Fill(dt);
            this.dataGridView1.DataSource = dt;

            lblRubro.Visible = false;
            cmdRubro.Visible = false;
            cboRubro.Visible = false;
            cboRubro.Enabled = true;

            lstVisi.Visible = false;
            lstVisiSel.Visible = false;
            cmdVisiAceptar.Visible = false;
            cmdVisiBorrar.Visible = false;
            cmdVisiSel.Visible = false;
            lblVisi.Visible = false;

        }

        private void cmdVerOtro_Click(object sender, EventArgs e)
        {
          
            txtAnio.Enabled = true;
            txtAnio.Text = "";

            cboTrim.Enabled = true;
            cboTrim.SelectedIndex = -1;
            cboTrim.Visible = false;
            cmdTrimestre.Visible = false;
            lblTrim.Visible = false;

            lblTopp.Visible = false;
            cmdTop1.Visible = false;
            cmdTop2.Visible = false;
            cmdTop3.Visible = false;
            cmdTop4.Visible = false;

            lblRubro.Visible = false;
            cmdRubro.Visible = false;
            cboRubro.Visible = false;
            cboRubro.Enabled = true;

            lstVisi.Visible = false;
            lstVisiSel.Visible = false;
            cmdVisiAceptar.Visible = false;
            cmdVisiBorrar.Visible = false;
            cmdVisiSel.Visible = false;
            lblVisi.Visible = false;
            
        }

        private void cmdTop4_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Monto_Facturado_Vendedor", db.Connection);
            cmd.Parameters.AddWithValue("@Trimestre", SqlDbType.Int).Value = (indexTrimestreSeleccionado+1);
            cmd.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = anio;
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Usuario");
            adapter.Fill(dt);
            this.dataGridView1.DataSource = dt;

            lblRubro.Visible = false;
            cmdRubro.Visible = false;
            cboRubro.Visible = false;
            cboRubro.Enabled = true;

            lstVisi.Visible = false;
            lstVisiSel.Visible = false;
            cmdVisiAceptar.Visible = false;
            cmdVisiBorrar.Visible = false;
            cmdVisiSel.Visible = false;
            lblVisi.Visible = false;
        }

        private void cmdTop2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccione un Rubro", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            lblRubro.Visible = true;
            cmdRubro.Visible = true;
            cboRubro.Visible = true;


            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.ListaRubros", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {
                cboRubro.Items.Add(sdr["DescripLarga"].ToString());
            }

            cboRubro.ValueMember = cboRubro.DisplayMember;

            lstVisi.Visible = false;
            lstVisiSel.Visible = false;
            cmdVisiAceptar.Visible = false;
            cmdVisiBorrar.Visible = false;
            cmdVisiSel.Visible = false;
            lblVisi.Visible = false;
        }

        private void cmdRubro_Click(object sender, EventArgs e)
        {
            if (cboRubro.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un rubro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;

            }
            rubroElegido = cboRubro.SelectedItem.ToString();
            cboRubro.Enabled = false;

            cmd = new SqlCommand("ROAD_TO_PROYECTO.Clientes_Productos_Comprados", db.Connection);
            cmd.Parameters.AddWithValue("@Trimestre", SqlDbType.Int).Value = (indexTrimestreSeleccionado + 1);
            cmd.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = anio;
            cmd.Parameters.AddWithValue("@RubroDesc", SqlDbType.NVarChar).Value = rubroElegido;
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Usuario");
            adapter.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }

        private void cmdVisiAceptar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstVisiSel.Items.Count; i++)
            {
                visibilidadesElegidas += lstVisiSel.Items[i].ToString() + ",";
            }

            if (!lstVisiSel.Items.Count.Equals(0))
            {
                visibilidadesElegidas = visibilidadesElegidas.TrimEnd(',');
            }
            else
            {
                visibilidadesElegidas = "";
            }

            cmd = new SqlCommand("ROAD_TO_PROYECTO.Vendedores_Productos_No_Vendidos_Old", db.Connection);
            cmd.Parameters.AddWithValue("@Trimestre", SqlDbType.Int).Value = (indexTrimestreSeleccionado + 1);
            cmd.Parameters.AddWithValue("@Año", SqlDbType.Int).Value = anio;
            cmd.Parameters.AddWithValue("@Parametros", SqlDbType.NVarChar).Value = visibilidadesElegidas;
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Usuario");
            adapter.Fill(dt);
            this.dataGridView1.DataSource = dt;

            visibilidadesElegidas = "";


        }

        private void cmdVisiSel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstVisiSel.Items.Count; i++)
            {
                if (lstVisiSel.Items[i].ToString().Equals(lstVisi.SelectedValue.ToString()))
                {
                    MessageBox.Show("Ya ha seleccionado la visibilidad", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            lstVisiSel.Items.Add(lstVisi.SelectedValue.ToString()); 
        }

        private void cmdVisiBorrar_Click(object sender, EventArgs e)
        {
            lstVisiSel.Items.RemoveAt(lstVisiSel.SelectedIndex);
        }
    }
}
