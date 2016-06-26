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
    public partial class AltaPublicacion : Form
    {
        public static AltaPublicacion ap1;
        private int huboError = 0;
        private int huboErrorTipoDatos = 0;
        private int huboErrorFechaAnterior = 0;
        private int huboErrorNumerico = 0;
        public int envioHabilitado;
        public int esModif;
        public int publiId;
        public int tipoPubli;
        public string estado;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader sdr;
        private DataBase db;        

        public AltaPublicacion()
        {
            db = DataBase.GetInstance();
            InitializeComponent();
            AltaPublicacion.ap1 = this;          
        }

        private void cargarDatos()
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Buscar_Publicacion", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PubliId", SqlDbType.Int).Value = publiId;

            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                txtDescripcion.Text = sdr["Descipcion"].ToString();
                txtPrecio.Text = sdr["Precio"].ToString();
                txtStockInmediata.Text = sdr["Stock"].ToString();
                txtValorSubasta.Text = sdr["Precio"].ToString();
                cboRubro.SelectedValue = sdr["DescripLarga"].ToString();
                dtpFin.Value = DateTime.Parse(sdr["FechaFin"].ToString());
                lblVisSel.Text = sdr["Descripcion"].ToString();
                tipoPubli = (int)sdr["Tipo"];
                envioHabilitado = (int)sdr["EnvioHabilitado"];
            }
            sdr.Close();
        }

        private void lblValorSubasta_Click(object sender, EventArgs e)
        {
           
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipo.SelectedIndex == -1)
            {
                return;
            }
            if (cboTipo.SelectedItem.ToString() == "Subasta")
            {
                lblDescripcion.Visible = true;
                lblRubro.Visible = true;
               
                dtpFin.Visible = true;
                cboRubro.Visible = true;
                txtDescripcion.Visible = true;
                lblFin.Visible = true;

                lblValorSubasta.Visible = true;
                txtValorSubasta.Visible = true;

                lblStockInmediata.Visible = false;
                txtStockInmediata.Visible = false;

                lblPrecio.Visible = false;
                txtPrecio.Visible = false;
                
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
               
                label8.Visible = true;

                lblVisibilidad.Visible = true;
                lblVisSel.Visible = true;
                cmdSelVis.Visible = true;

            }

            if (cboTipo.SelectedItem.ToString() == "Compra inmediata")
            {
                lblDescripcion.Visible = true;
                lblRubro.Visible = true;
             
                dtpFin.Visible = true;
                cboRubro.Visible = true;
                txtDescripcion.Visible = true;
                lblFin.Visible = true;

                lblValorSubasta.Visible = false;
                txtValorSubasta.Visible = false;

                lblStockInmediata.Visible = true;
                txtStockInmediata.Visible = true;
                txtPrecio.Visible = true;
              
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                lblPrecio.Visible = true;
                label8.Visible = true;

                lblVisibilidad.Visible = true;
                lblVisSel.Visible = true;
                cmdSelVis.Visible = true;
            }
            timer1.Start();
        }

        private void AltaPublicacion_Load(object sender, EventArgs e)
        {
            dtpFin.Value = Fecha.getFechaActual();
           
            cargarComboBoxRubros();

            lblPrecio.Visible = false;
            txtPrecio.Visible = false;

            lblVisibilidad.Visible = false;
            lblVisSel.Visible = false;
            cmdSelVis.Visible = false;
            
            lblDescripcion.Visible = false;
            lblRubro.Visible = false;
           
            dtpFin.Visible = false;
            cboRubro.Visible = false;
            txtDescripcion.Visible = false;
            lblFin.Visible = false;

            lblValorSubasta.Visible = false;
            txtValorSubasta.Visible = false;

            lblStockInmediata.Visible = false;
            txtStockInmediata.Visible = false;
            label2.Visible = true;
            
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            lblPrecio.Visible = false;
            label8.Visible = false;

            if (esModif == 1)
            {
                label1.Visible = false;
                lblTitulo.Visible = true;
                label2.Visible = false;
                cboTipo.Visible = false;
                cargarDatos();
                if (tipoPubli == 1)
                {
                    cboTipo.SelectedIndex = 1;
                }
                else
                {
                    cboTipo.SelectedIndex = 0;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           

        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string cadenaDeErrores = "Debe completar los siguientes campos: \r";
            string cadenaDeErrorTipo = "Debe seleccionar un tipo de publicacion";
            string cadenaDeErrorValoresNegativos = "No puede tener valores negativos o cero en los siguientes campos: \r";
            string cadenaDeErrorFechaAnterior = "Debe ingresar una fecha igual o posterior a la del archivo de configuración\r";
            string cadenaDeErrorNumeroYEsCaracter = "No se permiten los tipos de datos ingresados en los siguientes campos: \r";
            int val = 0;
            if (cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show(cadenaDeErrorTipo, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            if (cboTipo.SelectedItem.ToString() == "Compra inmediata")                                 
            {
                if(string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    cadenaDeErrores += " Descripcion \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtDescripcion.Text)))
                {

                    if (Int32.TryParse(txtDescripcion.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Descripcion \r";
                        huboErrorNumerico++;
                    }
                }
                if(string.IsNullOrEmpty(txtStockInmediata.Text))
                {
                    cadenaDeErrores += " Stock \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtStockInmediata.Text)))
                {
                    if (!(Int32.TryParse(txtStockInmediata.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Stock \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtStockInmediata.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Stock \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }
              
                if (cboRubro.SelectedIndex == -1)
                {
                    cadenaDeErrores += " Rubro \r";
                    huboError++;
                }
                if (string.IsNullOrEmpty(lblVisSel.Text))
                {
                    cadenaDeErrores += "Visibilidad \r";
                    huboError++;
                }
                if (dtpFin.Value < Fecha.getFechaActual())
                {
                    huboErrorFechaAnterior++;                 
                }
                if (string.IsNullOrEmpty(txtPrecio.Text))
                {
                    cadenaDeErrores += " Precio \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtPrecio.Text)))
                {
                    if (!(Int32.TryParse(txtPrecio.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Precio \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtPrecio.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Precio \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }
              
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores +cadenaDeErrorNumeroYEsCaracter+ cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorTipoDatos = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorFechaAnterior = 0;
                    huboErrorTipoDatos = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if(huboError != 0 && huboErrorTipoDatos != 0){
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorTipoDatos = 0;
                    return;

                }
                if (huboError != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboError != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboError = 0;
                    return;
                }


                if (huboErrorTipoDatos!= 0 && huboErrorFechaAnterior!= 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboErrorTipoDatos != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboErrorTipoDatos = 0;
                    return;
                }

                if (huboErrorFechaAnterior  != 0 && huboErrorNumerico   != 0)
                {
                    string errorGeneral = cadenaDeErrorFechaAnterior + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboError != 0)
                {
                    string errorGeneral = cadenaDeErrores;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    return;
                    
                }
                if (huboErrorTipoDatos   != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    return;
                    
                }
                if (huboErrorFechaAnterior  != 0)
                {
                    string errorGeneral =cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorFechaAnterior = 0;
                    return;
                    
                }
                if (huboErrorNumerico   != 0)
                {
                    string errorGeneral =cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    return;
                }



                estado = "Borrador";
                PublicacionDOA doa = new PublicacionDOA();
             
                doa.crearPublicacion(txtDescripcion.Text, int.Parse(txtStockInmediata.Text), dtpFin.Value, txtPrecio.Text, lblVisSel.Text, cboRubro.SelectedValue.ToString(), cboTipo.SelectedItem.ToString(), lblUsername.Text, envioHabilitado, estado);
                MessageBox.Show("Se ha creado correctamente la publicacion", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
               
                
            }
            if (cboTipo.SelectedItem.ToString() == "Subasta")
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    cadenaDeErrores += " Descripcion \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtDescripcion.Text)))
                {

                    if (Int32.TryParse(txtDescripcion.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Descripcion \r";
                        huboErrorNumerico++;
                    }
                }
                if (string.IsNullOrEmpty(txtValorSubasta.Text))
                {
                    cadenaDeErrores += " Valor Inicial de la subasta \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtValorSubasta.Text)))
                {
                    if (!(Int32.TryParse(txtValorSubasta.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Valor Inicial de la subasta \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtValorSubasta.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Valor Inicial de la subasta \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }
                if (cboRubro.SelectedIndex == -1)
                {
                    cadenaDeErrores += " Rubro \r";
                    huboError++;
                }
                if (string.IsNullOrEmpty(lblVisSel.Text))
                {
                    cadenaDeErrores += "Visibilidad \r";
                    huboError++;
                }
                if (dtpFin.Value < Fecha.getFechaActual())
                {
                    huboErrorFechaAnterior++;
                }

                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorTipoDatos = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorFechaAnterior = 0;
                    huboErrorTipoDatos = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorTipoDatos = 0;
                    return;

                }
                if (huboError != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboError != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboError = 0;
                    return;
                }


                if (huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboErrorTipoDatos != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboErrorTipoDatos = 0;
                    return;
                }

                if (huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorFechaAnterior + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboErrorFechaAnterior = 0;
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
                    string errorGeneral = cadenaDeErrorValoresNegativos;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    return;

                }
                if (huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorFechaAnterior = 0;
                    return;

                }
                if (huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    return;
                }

                estado = "Borrador";
                PublicacionDOA doa = new PublicacionDOA();
                
                doa.crearPublicacion(txtDescripcion.Text, 1,dtpFin.Value, txtValorSubasta.Text,lblVisSel.Text, cboRubro.SelectedValue.ToString(),cboTipo.SelectedItem.ToString(), lblUsername.Text, envioHabilitado, estado);
                MessageBox.Show("Se ha creado correctamente la publicacion", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }     
            
            WindowsFormsApplication1.Form1.f1.Show();
            this.Hide();
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            cboRubro.SelectedIndex = -1;
            txtDescripcion.Text = "";
            txtStockInmediata.Text = "";
            txtValorSubasta.Text = "";
            txtPrecio.Text = "";
            lblVisSel.Text = "";
            dtpFin.Value = Fecha.getFechaActual();
            huboError = 0;
            huboErrorFechaAnterior = 0;
            huboErrorNumerico=0;
            huboErrorTipoDatos = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmdSelVis_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.ABM_Visibilidad.Form1 setVisibilidad = new WindowsFormsApplication1.ABM_Visibilidad.Form1();
            setVisibilidad.user = lblUsername.Text;
            setVisibilidad.Show();
            this.Hide();
        }

        public void cargarComboBoxRubros()
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.ListaRubros", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Rubro");
            adapter.Fill(dt);
            this.cboRubro.DataSource = dt;
            this.cboRubro.DisplayMember = "DescripLarga";

            cboRubro.ValueMember = cboRubro.DisplayMember;
            if (esModif == 0)
            {
                cboRubro.SelectedIndex = -1;
                cboRubro.Text = "Seleccione un rubro";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            string cadenaDeErrores = "Debe completar los siguientes campos: \r";
            //string cadenaDeErrorTipo = "Debe seleccionar un tipo de publicacion";
            string cadenaDeErrorValoresNegativos = "No puede tener valores negativos o cero en los siguientes campos: \r";
            string cadenaDeErrorFechaAnterior = "Debe ingresar una fecha igual o posterior a la del archivo de configuración\r";
            string cadenaDeErrorNumeroYEsCaracter = "No se permiten los tipos de datos ingresados en los siguientes campos: \r";
            int val = 0;
            if (cboTipo.SelectedItem.ToString() == "Compra inmediata")
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    cadenaDeErrores += " Descripcion \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtDescripcion.Text)))
                {

                    if (Int32.TryParse(txtDescripcion.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Descripcion \r";
                        huboErrorNumerico++;
                    }
                }
                if (string.IsNullOrEmpty(txtStockInmediata.Text))
                {
                    cadenaDeErrores += " Stock \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtStockInmediata.Text)))
                {
                    if (!(Int32.TryParse(txtStockInmediata.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Stock \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtStockInmediata.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Stock \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }           
                if (string.IsNullOrEmpty(lblVisSel.Text))
                {
                    cadenaDeErrores += "Visibilidad \r";
                    huboError++;
                }
                if (dtpFin.Value < Fecha.getFechaActual())
                {
                    huboErrorFechaAnterior++;
                }
                if (string.IsNullOrEmpty(txtPrecio.Text))
                {
                    cadenaDeErrores += " Precio \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtPrecio.Text)))
                {
                    if (!(Int32.TryParse(txtPrecio.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Precio \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtPrecio.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Precio \r";
                            huboErrorTipoDatos++;
                        }
                    }

                } 

                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorTipoDatos = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorFechaAnterior = 0;
                    huboErrorTipoDatos = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorTipoDatos = 0;
                    return;

                }
                if (huboError != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboError != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboError = 0;
                    return;
                }


                if (huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboErrorTipoDatos != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboErrorTipoDatos = 0;
                    return;
                }

                if (huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorFechaAnterior + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboErrorFechaAnterior = 0;
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
                    string errorGeneral = cadenaDeErrorValoresNegativos;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    return;

                }
                if (huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorFechaAnterior = 0;
                    return;

                }
                if (huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    return;
                }

                PublicacionDOA doa = new PublicacionDOA();

                doa.modificarPublicacion(publiId, txtDescripcion.Text, int.Parse(txtStockInmediata.Text), dtpFin.Value, txtPrecio.Text, lblVisSel.Text, cboRubro.SelectedValue.ToString(), cboTipo.SelectedItem.ToString(), lblUsername.Text, envioHabilitado);
            }
            if (cboTipo.SelectedItem.ToString() == "Subasta")
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    cadenaDeErrores += " Descripcion \r";
                    huboError++;
                }

                if (string.IsNullOrEmpty(txtValorSubasta.Text))
                {
                    cadenaDeErrores += " Valor Inicial de la subasta \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtValorSubasta.Text)))
                {
                    if (!(Int32.TryParse(txtValorSubasta.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Valor Inicial de la subasta \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtValorSubasta.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Valor Inicial de la subasta \r";
                            huboErrorTipoDatos++;
                        }
                    }

                } 
             
                if (string.IsNullOrEmpty(lblVisSel.Text))
                {
                    cadenaDeErrores += "Visibilidad \r";
                    huboError++;
                }
                if (dtpFin.Value < Fecha.getFechaActual())
                {
                    huboErrorFechaAnterior++;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorTipoDatos = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorFechaAnterior = 0;
                    huboErrorTipoDatos = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorTipoDatos = 0;
                    return;

                }
                if (huboError != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboError != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboError = 0;
                    return;
                }


                if (huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboErrorTipoDatos != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboErrorTipoDatos = 0;
                    return;
                }

                if (huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorFechaAnterior + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboErrorFechaAnterior = 0;
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
                    string errorGeneral = cadenaDeErrorValoresNegativos;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    return;

                }
                if (huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorFechaAnterior = 0;
                    return;

                }
                if (huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    return;
                }

                PublicacionDOA doa = new PublicacionDOA();

                doa.modificarPublicacion(publiId, txtDescripcion.Text, 1, dtpFin.Value, txtValorSubasta.Text, lblVisSel.Text, cboRubro.SelectedValue.ToString(), cboTipo.SelectedItem.ToString(), lblUsername.Text, envioHabilitado);
            }

            MessageBox.Show("Se ha modificado correctamente la publicacion", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            WindowsFormsApplication1.Generar_Publicación.EstadoPublicacion.estado.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cadenaDeErrores = "Debe completar los siguientes campos: \r";
            string cadenaDeErrorTipo = "Debe seleccionar un tipo de publicacion";
            string cadenaDeErrorValoresNegativos = "No puede tener valores negativos o cero en los siguientes campos: \r";
            string cadenaDeErrorFechaAnterior = "Debe ingresar una fecha igual o posterior a la del archivo de configuración\r";
            string cadenaDeErrorNumeroYEsCaracter = "No se permiten los tipos de datos ingresados en los siguientes campos: \r";

            int val = 0;
            if (cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show(cadenaDeErrorTipo, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            if (cboTipo.SelectedItem.ToString() == "Compra inmediata")
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    cadenaDeErrores += " Descripcion \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtDescripcion.Text)))
                {
                   
                    if (Int32.TryParse(txtDescripcion.Text, out val)){
                        cadenaDeErrorNumeroYEsCaracter += "Descripcion \r";
                        huboErrorNumerico++;
                    }
                }


                if (string.IsNullOrEmpty(txtStockInmediata.Text))
                {
                    cadenaDeErrores += " Stock \r";
                    huboError++;
                }

                if (!(string.IsNullOrEmpty(txtStockInmediata.Text)))
                {
                    if (!(Int32.TryParse(txtStockInmediata.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Stock \r";
                        huboErrorNumerico++;
                      
                    }
                    else
                    {
                        if (int.Parse(txtStockInmediata.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Stock \r";
                            huboErrorTipoDatos++;
                        }
                    }                  

                }
                if (cboRubro.SelectedIndex == -1)
                {
                    cadenaDeErrores += " Rubro \r";
                    huboError++;
                }
                if (string.IsNullOrEmpty(lblVisSel.Text))
                {
                    cadenaDeErrores += "Visibilidad \r";
                    huboError++;
                }
                if (dtpFin.Value < Fecha.getFechaActual())
                {
                    huboErrorFechaAnterior++;
                    
                }
                if (string.IsNullOrEmpty(txtPrecio.Text))
                {
                    cadenaDeErrores += " Precio \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtPrecio.Text)))
                {
                    if (!(Int32.TryParse(txtPrecio.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Precio \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtPrecio.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Precio \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorTipoDatos = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorFechaAnterior = 0;
                    huboErrorTipoDatos = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorTipoDatos = 0;
                    return;

                }
                if (huboError != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboError != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboError = 0;
                    return;
                }


                if (huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboErrorTipoDatos != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboErrorTipoDatos = 0;
                    return;
                }

                if (huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorFechaAnterior + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboErrorFechaAnterior = 0;
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
                    string errorGeneral = cadenaDeErrorValoresNegativos;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    return;

                }
                if (huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorFechaAnterior = 0;
                    return;

                }
                if (huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    return;
                }

                estado = "Activa";
                PublicacionDOA doa = new PublicacionDOA();

                doa.crearPublicacion(txtDescripcion.Text, int.Parse(txtStockInmediata.Text), dtpFin.Value, txtPrecio.Text, lblVisSel.Text, cboRubro.SelectedValue.ToString(), cboTipo.SelectedItem.ToString(), lblUsername.Text, envioHabilitado, estado);
                MessageBox.Show("Se ha creado y activado correctamente la publicacion", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);


            }
            if (cboTipo.SelectedItem.ToString() == "Subasta")
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    cadenaDeErrores += " Descripcion \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtDescripcion.Text)))
                {

                    if (Int32.TryParse(txtDescripcion.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Descripcion \r";
                        huboErrorNumerico++;
                    }
                }
                if (string.IsNullOrEmpty(txtValorSubasta.Text))
                {
                    cadenaDeErrores += "Valor Inicial de la subasta \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtValorSubasta.Text)))
                {
                    if (!(Int32.TryParse(txtValorSubasta.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Valor Inicial de la subasta \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtValorSubasta.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Valor Inicial de la subasta \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }

                if (cboRubro.SelectedIndex == -1)
                {
                    cadenaDeErrores += " Rubro \r";
                    huboError++;
                }
                if (string.IsNullOrEmpty(lblVisSel.Text))
                {
                    cadenaDeErrores += "Visibilidad \r";
                    huboError++;
                }
                if (dtpFin.Value < Fecha.getFechaActual())
                {
                    huboErrorFechaAnterior++;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorTipoDatos = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorFechaAnterior = 0;
                    huboErrorTipoDatos = 0;
                    huboErrorNumerico = 0;
                    return;
                }
                if (huboError != 0 && huboErrorTipoDatos != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorValoresNegativos;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorTipoDatos = 0;
                    return;

                }
                if (huboError != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboError = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboError != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrores + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboError = 0;
                    return;
                }


                if (huboErrorTipoDatos != 0 && huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    huboErrorFechaAnterior = 0;
                    return;
                }
                if (huboErrorTipoDatos != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorValoresNegativos + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboErrorTipoDatos = 0;
                    return;
                }

                if (huboErrorFechaAnterior != 0 && huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorFechaAnterior + cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    huboErrorFechaAnterior = 0;
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
                    string errorGeneral = cadenaDeErrorValoresNegativos;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorTipoDatos = 0;
                    return;

                }
                if (huboErrorFechaAnterior != 0)
                {
                    string errorGeneral = cadenaDeErrorFechaAnterior;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorFechaAnterior = 0;
                    return;

                }
                if (huboErrorNumerico != 0)
                {
                    string errorGeneral = cadenaDeErrorNumeroYEsCaracter;
                    MessageBox.Show(errorGeneral, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    huboErrorNumerico = 0;
                    return;
                }
                estado = "Activa";
                PublicacionDOA doa = new PublicacionDOA();

                doa.crearPublicacion(txtDescripcion.Text, 1, dtpFin.Value, txtValorSubasta.Text, lblVisSel.Text, cboRubro.SelectedValue.ToString(), cboTipo.SelectedItem.ToString(), lblUsername.Text, envioHabilitado, estado);
                MessageBox.Show("Se ha creado y activado correctamente la publicacion", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

            WindowsFormsApplication1.Form1.f1.Show();
            this.Hide();
        }
    }
}
