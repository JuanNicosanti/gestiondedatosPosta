﻿using System;
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
    public partial class AgregarVisibilidad : Form
    {

        SqlCommand cmd;
        private DataBase db;
        private int huboError = 0;
        private int huboErrorTipoDatos = 0;
        private int huboErrorNegativos = 0;
        private Boolean existeLaVisibilidad = false;

        public AgregarVisibilidad()
        {
            db = DataBase.GetInstance();
            InitializeComponent();
        }

        private void cmdAceptarVis_Click(object sender, EventArgs e)
        {
            string cadenaDeErrores = "Debe completar los siguientes campos: \r";
            string cadenaDeErrorValoresNegativos = "No puede tener valores negativos o cero en los siguientes campos: \r";
            string cadenaDeErrorNumeroYEsCaracter = "No se permiten los tipos de datos ingresados en los siguientes campos: \r";
            int valint = 0;
            double valDouble = 0;
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
            if (string.IsNullOrEmpty(tbComiFija.Text))
            {

                cadenaDeErrores += "Comision por tipo de publicacion \r";
                huboError++;
            }
            if (!(string.IsNullOrEmpty(tbComiFija.Text)))
            {
                
                if (!(double.TryParse(tbComiFija.Text, out valDouble)))
                {
                    cadenaDeErrorNumeroYEsCaracter += "Comision por tipo de publicacion \r";
                    huboErrorTipoDatos++;

                }
                else
                {
                    if (double.Parse(tbComiFija.Text) <= 0)
                    {
                        cadenaDeErrorValoresNegativos += "Comision por tipo de publicacion \r";
                        huboErrorNegativos++;
                    }
                }
            }
            if (string.IsNullOrEmpty(tbComiVariable.Text))
            {
                cadenaDeErrores += "Comision por producto vendido \r";
                huboError++;
            }
            if (!(string.IsNullOrEmpty(tbComiVariable.Text)))
            {

                if (!(double.TryParse(tbComiVariable.Text, out valDouble)))
                {
                    cadenaDeErrorNumeroYEsCaracter += "Comision por producto vendido \r";
                    huboErrorTipoDatos++;

                }
                else
                {
                    if (double.Parse(tbComiVariable.Text) <= 0)
                    {
                        cadenaDeErrorValoresNegativos += "Comision por producto vendido \r";
                        huboErrorNegativos++;
                    }
                }
            }
            if (string.IsNullOrEmpty(tbEnvio.Text))
            {
                cadenaDeErrores += "Comision de envio \r";
                huboError++;
               
            }
            if (!(string.IsNullOrEmpty(tbEnvio.Text)))
            {

                if (!(double.TryParse(tbEnvio.Text, out valDouble)))
                {
                    cadenaDeErrorNumeroYEsCaracter += "Comision de envio \r";
                    huboErrorTipoDatos++;

                }
                else
                {
                    if (double.Parse(tbEnvio.Text) <= 0)
                    {
                        cadenaDeErrorValoresNegativos += "Comision de envio \r";
                        huboErrorNegativos++;
                    }
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
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Agregar_Visibilidad", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Descripcion", SqlDbType.NVarChar).Value = tbDescripcion.Text;
            cmd.Parameters.AddWithValue("@ComiFijaString", SqlDbType.NVarChar).Value = tbComiFija.Text;
            cmd.Parameters.AddWithValue("@ComiVariableString", SqlDbType.NVarChar).Value = tbComiVariable.Text;
            cmd.Parameters.AddWithValue("@ComiEnvioString", SqlDbType.NVarChar).Value = tbEnvio.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("La visibilidad se ha creado correctamente", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            WindowsFormsApplication1.Form1.f1.Show();
            this.Close();
          
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            tbDescripcion.Text = "";
            tbComiFija.Text = "";
            tbComiVariable.Text = "";
            tbEnvio.Text = "";
        }

        private void cmdVolverComs_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbEnvio_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbComiVariable_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbComiFija_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Close();
        }

        private void AgregarVisibilidad_Load(object sender, EventArgs e)
        {

        }
    }
}
