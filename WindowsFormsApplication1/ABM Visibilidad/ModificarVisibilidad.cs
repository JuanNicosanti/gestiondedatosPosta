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

namespace WindowsFormsApplication1.ABM_Visibilidad
{
    public partial class ModificarVisibilidad : Form
    {
        SqlCommand cmd;
        private DataBase db;
        private int huboError = 0;
        private Boolean existeLaVisibilidad = false;
        private int huboErrorTipoDatos = 0;
        private int huboErrorNegativos = 0;
        public static ModificarVisibilidad modVis;
        public int visiId;
        public int habilitada = 1;

        private String visibilidadVieja;

        public ModificarVisibilidad()
        {
            InitializeComponent();
            ModificarVisibilidad.modVis = this;
            db = DataBase.GetInstance();
        }

        private void ModificarVisibilidad_Load(object sender, EventArgs e)
        {
            nudComiFija.Text = "";
            nudComiVariable.Text = "";
            nudEnvio.Text = "";
            visibilidadVieja = tbDescripcion.Text;
            if (habilitada == 1)
            {
                cbHabilitada.Checked = true;
            }
            else 
            {
                cbHabilitada.Checked = false;
            }
        }

        private void cmdVolverComs_Click(object sender, EventArgs e)
        {
            BusquedaVisibilidad.bVisi.Show();
            this.Hide();
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            tbDescripcion.Text = "";
            nudComiFija.Text = "";
            nudComiVariable.Text = "";
            nudEnvio.Text = "";
        }

        private void cmdAceptarVis_Click(object sender, EventArgs e)
        {
            string cadenaDeErrores = "Debe completar los siguientes campos: \r";
            string cadenaDeErrorValoresNegativos = "No puede tener valores negativos o cero en los siguientes campos: \r";
            string cadenaDeErrorNumeroYEsCaracter = "No se permiten los tipos de datos ingresados en los siguientes campos: \r";
            int valint = 0;
            //double valDouble = 0;
            if (string.IsNullOrEmpty(tbDescripcion.Text))
            {
                cadenaDeErrores += "Descripcion \r";
                huboError++;

            }
            if (!(string.IsNullOrEmpty(tbDescripcion.Text)))
            {
                if (Int32.TryParse(tbDescripcion.Text, out valint))
                {
                    cadenaDeErrorNumeroYEsCaracter += "Descripcion \r";
                    huboErrorTipoDatos++;
                }
            }
            if (string.IsNullOrEmpty(nudComiFija.Text))
            {

                cadenaDeErrores += "Comision por tipo de publicacion \r";
                huboError++;
            }
            if (!(string.IsNullOrEmpty(nudComiFija.Text)))
            {

             
                if (double.Parse(nudComiFija.Text) <= 0)
                {
                    cadenaDeErrorValoresNegativos += "Comision por tipo de publicacion \r";
                    huboErrorNegativos++;
                }
                
            }
            if (string.IsNullOrEmpty(nudComiVariable.Text))
            {
                cadenaDeErrores += "Comision por producto vendido \r";
                huboError++;
            }
            if (!(string.IsNullOrEmpty(nudComiVariable.Text)))
            {


                if (double.Parse(nudComiVariable.Text) <= 0)
                    {
                        cadenaDeErrorValoresNegativos += "Comision por producto vendido \r";
                        huboErrorNegativos++;
                    }
                
            }
            if (string.IsNullOrEmpty(nudEnvio.Text))
            {
                cadenaDeErrores += "Comision de envio \r";
                huboError++;

            }
            if (!(string.IsNullOrEmpty(nudEnvio.Text)))
            {

              
                    if (double.Parse(nudEnvio.Text) < 0)
                    {
                        cadenaDeErrorValoresNegativos += "Comision de envio \r";
                        huboErrorNegativos++;
                    }
                
            }



            if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorNegativos != 0)
            {
                string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                huboError = 0;
                huboErrorTipoDatos = 0;
                huboErrorNegativos = 0;
                return;
            }

            if (huboError != 0 && huboErrorTipoDatos != 0)
            {
                string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter;
                MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                huboError = 0;
                huboErrorTipoDatos = 0;
                return;

            }

            if (huboError != 0 && huboErrorNegativos != 0)
            {
                string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter;
                MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                huboErrorNegativos = 0;
                huboError = 0;
                return;
            }



            if (huboErrorTipoDatos != 0 && huboErrorNegativos != 0)
            {
                string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                huboErrorNegativos = 0;
                huboErrorTipoDatos = 0;
                return;
            }


            if (huboError != 0)
            {
                string errorGeneral = cadenaDeErrores;
                MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                huboError = 0;
                return;

            }
            if (huboErrorTipoDatos != 0)
            {
                string errorGeneral = cadenaDeErrorNumeroYEsCaracter;
                MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                huboErrorTipoDatos = 0;
                return;

            }

            if (huboErrorNegativos != 0)
            {
                string errorGeneral = cadenaDeErrorValoresNegativos;
                MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                huboErrorNegativos = 0;
                return;
            }

            if (cbHabilitada.Checked)
            {
                habilitada = 1;
            }
            else 
            {
                habilitada = 0;
            }

            if (!tbDescripcion.Text.Equals(visibilidadVieja))
            {
                SqlCommand cmd32 = new SqlCommand("ROAD_TO_PROYECTO.Validacion_Existe_Visibilidad", db.Connection);
                cmd32.CommandType = CommandType.StoredProcedure;
                cmd32.Parameters.AddWithValue("@Descripcion", SqlDbType.NVarChar).Value = tbDescripcion.Text;
                SqlDataReader sdr2 = cmd32.ExecuteReader();
                while (sdr2.Read())
                {
                    existeLaVisibilidad = true;
                }
                if (existeLaVisibilidad)
                {
                    existeLaVisibilidad = false;
                    MessageBox.Show("La visibilidad ingresada ya existe", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
          
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Modificacion_Visibilidad", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VisiId", SqlDbType.Int).Value = visiId;
            cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.NVarChar).Value = tbDescripcion.Text;
            cmd.Parameters.AddWithValue("@ComiFijaString", SqlDbType.NVarChar).Value = nudComiFija.Text;
            cmd.Parameters.AddWithValue("@ComiVariableString", SqlDbType.NVarChar).Value = nudComiVariable.Text;
            cmd.Parameters.AddWithValue("@ComiEnvioString", SqlDbType.NVarChar).Value = nudEnvio.Text;
            cmd.Parameters.AddWithValue("@Habilitado", SqlDbType.Int).Value = habilitada;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Visibilidad modificada correctamente", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            BusquedaVisibilidad.bVisi.Show();
            this.Close();
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Close();
        }
    }
}
