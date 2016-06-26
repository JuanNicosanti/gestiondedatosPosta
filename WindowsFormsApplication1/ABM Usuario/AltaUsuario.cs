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
using System.Security.Cryptography;
using System.IO;

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class AltaUsuario : Form
    {
        public static AltaUsuario aus;
        private int huboError = 0;
        private int huboErrorNumerico = 0;
        private int huboErrorTipoDatos = 0;
        private int huboErrorFechaAnterior = 0;

        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader sdr;
        private DataBase db;

        public String rubroModificado;
        
        public int esAltaUsuario =1;
        public int irAlMenuPrincipal;
        
        public AltaUsuario()
        {
            InitializeComponent();
            db = DataBase.GetInstance(); 
            AltaUsuario.aus = this;
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.rbCliente.Checked == true)
            {
                this.lblApellidoCliente.Visible = true;
                this.lblNombreCliente.Visible = true;
                this.lblFechaNacCliente.Visible = true;
                this.lblNroDocCliente.Visible = true;
                this.lblTelCliente.Visible = true;
                this.lblTipoDNICliente.Visible = true;

                this.txtApellidoCliente.Visible = true;
                this.txtDNICliente.Visible = true;                             
                this.txtNombreCliente.Visible = true;                            
                this.txtTelCliente.Visible = true;
                this.cboTipoCliente.Visible = true;
                

                this.txtCUITEmpresa.Text = "";
                this.txtNombreContEmpresa.Text = "";
                this.txtRazonEmpresa.Text = "";
                this.txtTelEmpresa.Text = "";

                this.cboRubro.Visible = false;
                this.lblRubroEmpresa.Visible = false;
                
                this.lblCiudadEmpresa.Visible = false;
                this.txtCiudadEmpresa.Visible = false;
                             
               

            }
            if (this.rbEmpresa.Checked == true)
            {
                this.lblFechaEmpresa.Visible = true;
                this.lblNombreEmpresa.Visible = true;
                this.lblRazonEmpresa.Visible = true;
                this.lblTelefonoEmpresa.Visible = true;
                this.lblCUITEmpresa.Visible = true;

                this.txtCUITEmpresa.Visible = true;
                this.txtNombreContEmpresa.Visible = true;
                this.txtRazonEmpresa.Visible = true;
                this.txtTelEmpresa.Visible = true;

                this.cboRubro.Visible = true;
                this.lblRubroEmpresa.Visible = true;
                

                this.lblCiudadEmpresa.Visible = true;
                this.txtCiudadEmpresa.Visible = true;
            

                this.txtApellidoCliente.Text = "";
                this.txtDNICliente.Text = "";
                this.txtNombreCliente.Text = "";
                this.txtTelCliente.Text = "";
                this.cboTipoCliente.Text = "";
            
          
                               
            }

            if(this.rbCliente.Checked == true || this.rbEmpresa.Checked == true)
            {
                this.lblCalle.Visible = true;
                this.lblCodPos.Visible = true;
                this.lblDom.Visible = true;
                this.lblDpto.Visible = true;
                this.lblLocal.Visible = true;
                this.lblPiso.Visible = true;
                this.lblNum.Visible = true;

                this.txtCalle.Visible = true;
                this.txtCodPos.Visible = true;
                this.txtDpto.Visible = true;
                this.txtLocalidad.Visible = true;
                this.txtPiso.Visible = true;
                this.txtNumero.Visible = true;
                this.dtpCreacion.Visible = true;
            }
          
            if(this.rbCliente.Checked == false)
            {
                this.lblApellidoCliente.Visible = false;
                this.lblNombreCliente.Visible = false;
                this.lblFechaNacCliente.Visible = false;
                this.lblNroDocCliente.Visible = false;
                this.lblTelCliente.Visible = false;
                this.lblTipoDNICliente.Visible = false;

                this.txtApellidoCliente.Visible = false;
                this.txtDNICliente.Visible = false;
                this.txtNombreCliente.Visible = false;
                this.txtTelCliente.Visible = false;
                this.cboTipoCliente.Visible = false;

                
            }
            if (this.rbEmpresa.Checked == false)
            {
                this.lblFechaEmpresa.Visible = false;
                this.lblNombreEmpresa.Visible = false;
                this.lblRazonEmpresa.Visible = false;
                this.lblTelefonoEmpresa.Visible = false;
                this.lblCUITEmpresa.Visible = false;

                this.txtCUITEmpresa.Visible = false;
                this.txtNombreContEmpresa.Visible = false;
                this.txtRazonEmpresa.Visible = false;
                this.txtTelEmpresa.Visible = false;

                this.lblCiudadEmpresa.Visible = false;
                this.txtCiudadEmpresa.Visible = false;
            }
         }
        private void AltaUsuario_Load(object sender, EventArgs e)
        {
            this.dtpCreacion.Value = Fecha.getFechaActual();
            this.cboRubro.Visible = false;
            this.lblRubroEmpresa.Visible = false;
            cargarComboBoxRubros();            

            this.lblApellidoCliente.Visible = false;
            this.lblNombreCliente.Visible = false;
            this.lblFechaNacCliente.Visible = false;
            this.lblNroDocCliente.Visible = false;
            this.lblTelCliente.Visible = false;
            this.lblTipoDNICliente.Visible = false;
            this.lblFechaEmpresa.Visible = false;
            this.lblNombreEmpresa.Visible = false;
            this.lblRazonEmpresa.Visible = false;
            this.lblTelefonoEmpresa.Visible = false;
            this.lblCUITEmpresa.Visible = false;
            this.lblCalle.Visible = false;
            this.lblCodPos.Visible = false;
            this.lblDom.Visible = false;
            this.lblDpto.Visible = false;
            this.lblLocal.Visible = false;
            this.lblPiso.Visible = false;
            this.lblNum.Visible = false;
            this.txtApellidoCliente.Visible = false;
            this.txtDNICliente.Visible = false;
            this.txtNombreCliente.Visible = false;
            this.txtTelCliente.Visible = false;
            this.cboTipoCliente.Visible = false;
            this.txtCalle.Visible = false;
            this.txtCodPos.Visible = false;
            this.txtDpto.Visible = false;
            this.txtLocalidad.Visible = false;
            this.txtPiso.Visible = false;
            this.txtNumero.Visible = false;
            this.txtCUITEmpresa.Visible = false;
            this.txtNombreContEmpresa.Visible = false;
            this.txtRazonEmpresa.Visible = false;
            this.txtTelEmpresa.Visible = false;
            this.dtpCreacion.Visible = false;
            this.lblCiudadEmpresa.Visible = false;
            this.txtCiudadEmpresa.Visible = false;
            this.dtpCreacion.Value = Fecha.getFechaActual();
            this.timer1.Start();
            
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
            if (esAltaUsuario == 1)
            {
                cboRubro.SelectedIndex = -1;
                cboRubro.Text = "Seleccione un rubro";
            } 
            else
            {                
                cboRubro.SelectedValue = rubroModificado;
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string cadenaDeErrores = "Debe completar los siguientes campos: \r";
            string cadenaDeErrorTipo = "Debe seleccionar un tipo de Usuario";
            string cadenaDeErrorValoresNegativos = "No puede tener valores negativos o cero en los siguientes campos: \r";
            string cadenaDeErrorFechaAnterior = "Debe ingresar una fecha igual o anterior a la del archivo de configuración\r";
            string cadenaDeErrorNumeroYEsCaracter = "No se permiten los tipos de datos ingresados en los siguientes campos: \r";
            int val = 0;

            if(rbCliente.Checked== false && rbEmpresa.Checked == false)
            {
                MessageBox.Show(cadenaDeErrorTipo, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }


            if(rbCliente.Checked== true)
                   
            {
                if (string.IsNullOrEmpty(txtUsuario.Text))
                {
                    cadenaDeErrores += " Usuario \r";
                    huboError++;
                }
              
                if(string.IsNullOrEmpty(txtPassword.Text))
                {
                    cadenaDeErrores += " Password \r";
                    huboError++;
                }
                if(string.IsNullOrEmpty(txtMail.Text))
                {
                    cadenaDeErrores += " Mail \r";
                    huboError++;
                }
                
                if(string.IsNullOrEmpty(txtApellidoCliente.Text))
                {
                    cadenaDeErrores += " Apellido \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtApellidoCliente.Text)))
                {
                    if (Int32.TryParse(txtApellidoCliente.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Apellido \r";
                        huboErrorNumerico++;
                    }
                }
                if(string.IsNullOrEmpty(txtNombreCliente.Text))
                {
                    cadenaDeErrores += " Nombre \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtNombreCliente.Text)))
                {
                    if (Int32.TryParse(txtNombreCliente.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Nombre \r";
                        huboErrorNumerico++;
                    }
                }
                if (dtpCreacion.Value > Fecha.getFechaActual())
                {
                    huboErrorFechaAnterior++;
                }
                if (string.IsNullOrEmpty(txtDNICliente.Text))
                {
                    cadenaDeErrores += " DNI \r";
                    huboError++;
                }

                if (!(string.IsNullOrEmpty(txtDNICliente.Text)))
                {
                    if (!(Int32.TryParse(txtDNICliente.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "DNI \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtDNICliente.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "DNI \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }
                if(string.IsNullOrEmpty(txtTelCliente.Text)) 
                {
                    cadenaDeErrores += " Telefono \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtTelCliente.Text)))
                {
                    if (!(Int32.TryParse(txtTelCliente.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Telefono \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtTelCliente.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Telefono \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }
                if (this.cboTipoCliente.SelectedIndex == -1)
                {
                    cadenaDeErrores += " Tipo Documento \r";
                    huboError++;
                }

                if (string.IsNullOrEmpty(txtCodPos.Text)) 
                {
                    cadenaDeErrores += " CodigoPostal \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtCodPos.Text)))
                {
                    if (!(Int32.TryParse(txtCodPos.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "CodigoPostal \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtCodPos.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "CodigoPostal \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }
                
                if (!(string.IsNullOrEmpty(txtDpto.Text)))
                {
                    if (Int32.TryParse(txtDpto.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Departamento \r";
                        huboErrorNumerico++;
                    }
                }
                if (string.IsNullOrEmpty(txtLocalidad.Text)) 
                {
                    cadenaDeErrores += " Localidad \r"; 
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtLocalidad.Text)))
                {
                    if (Int32.TryParse(txtLocalidad.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Localidad \r";
                        huboErrorNumerico++;
                    }
                }
               
                if (!(string.IsNullOrEmpty(txtPiso.Text)))
                {
                    if (!(Int32.TryParse(txtPiso.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Piso \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtPiso.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Piso \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }
                if (string.IsNullOrEmpty(txtNumero.Text))
                {
                    cadenaDeErrores += " Numero \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtNumero.Text)))
                {
                    if (!(Int32.TryParse(txtNumero.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Numero \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtNumero.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Numero \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }
                if (string.IsNullOrEmpty(txtCalle.Text))
                 {
                    cadenaDeErrores += " Calle \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtCalle.Text)))
                {
                    if (Int32.TryParse(txtCalle.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Calle \r";
                        huboErrorNumerico++;
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
                
                UsuarioDOA doa = new UsuarioDOA();
                if (esAltaUsuario == 1)
                {
                    string hash = this.encriptacion(txtPassword.Text);
                    doa.crearCliente("Cliente", txtUsuario.Text, hash, txtMail.Text, txtApellidoCliente.Text, txtNombreCliente.Text, int.Parse(txtDNICliente.Text), int.Parse(txtTelCliente.Text), this.cboTipoCliente.SelectedItem.ToString(), txtCodPos.Text, txtDpto.Text, txtLocalidad.Text, int.Parse(txtPiso.Text), int.Parse(txtNumero.Text), txtCalle.Text, dtpCreacion.Value);
                    MessageBox.Show("Se creo el cliente satisfactoriamente", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    if (irAlMenuPrincipal == 1)
                    {
                        Form1.f1.Show();
                        this.Hide();
                    }
                    if (irAlMenuPrincipal == 0)
                    {
                        Login.lg.Show();
                        this.Hide();
                    }
                    return;
                     
                }
                
                if (esAltaUsuario == 0)
                {
                    doa.modificarCliente("Cliente", txtUsuario.Text, txtPassword.Text, txtMail.Text, txtApellidoCliente.Text, txtNombreCliente.Text, int.Parse(txtDNICliente.Text), int.Parse(txtTelCliente.Text), this.cboTipoCliente.SelectedItem.ToString(), txtCodPos.Text, txtDpto.Text, txtLocalidad.Text, int.Parse(txtPiso.Text), int.Parse(txtNumero.Text), txtCalle.Text, dtpCreacion.Value);
                    MessageBox.Show("Se modifico el cliente satisfactoriamente", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    ModificacionUsuario mUsu = new ModificacionUsuario();
                    mUsu.esModificar = true;
                    mUsu.cmdModificar.Visible = true;
                    mUsu.cmdEliminar.Visible = false;
                    mUsu.Show();
                    this.Hide();
                    return;
                }
                    

                
            }
            if (rbEmpresa.Checked == true)
            {
                if (string.IsNullOrEmpty(txtUsuario.Text))
                {
                    cadenaDeErrores += " Usuario \r";
                    huboError++;

                }
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    cadenaDeErrores += " Password \r";
                    huboError++;
                }
                if (string.IsNullOrEmpty(txtMail.Text))
                {
                    cadenaDeErrores += " Mail \r";
                    huboError++;
                }
                if (string.IsNullOrEmpty(txtCUITEmpresa.Text))
                {
                    cadenaDeErrores += " CUIT \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtCUITEmpresa.Text)))
                {

                    if (Int32.TryParse(txtCUITEmpresa.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "CUIT \r";
                        huboErrorNumerico++;
                    }
                }
                if (dtpCreacion.Value > Fecha.getFechaActual())
                {
                    huboErrorFechaAnterior++;
                }
                if (string.IsNullOrEmpty(txtNombreContEmpresa.Text))
                {
                    cadenaDeErrores += " Nombre de Contacto \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtNombreContEmpresa.Text)))
                {

                    if (Int32.TryParse(txtNombreContEmpresa.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Nombre de Contacto \r";
                        huboErrorNumerico++;
                    }
                }
                if (string.IsNullOrEmpty(txtRazonEmpresa.Text))
                {
                    cadenaDeErrores += " Razon Social \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtRazonEmpresa.Text)))
                {

                    if (Int32.TryParse(txtRazonEmpresa.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Razon Social \r";
                        huboErrorNumerico++;
                    }
                }
                if (string.IsNullOrEmpty(txtTelEmpresa.Text))
                {
                    cadenaDeErrores += " Telefono \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtTelEmpresa.Text)))
                {
                    if (!(Int32.TryParse(txtTelEmpresa.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Telefono \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtTelEmpresa.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Telefono \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }
                if (cboRubro.SelectedIndex.Equals(-1))
                {
                    cadenaDeErrores += " Rubro \r";
                    huboError++;
                }
                if (string.IsNullOrEmpty(txtCodPos.Text))
                {
                    cadenaDeErrores += " CodigoPostal \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtCodPos.Text)))
                {
                    if (!(Int32.TryParse(txtCodPos.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "CodigoPostal \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtCodPos.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "CodigoPostal \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }
                
                if (!(string.IsNullOrEmpty(txtDpto.Text)))
                {
                    if (Int32.TryParse(txtDpto.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Departamento \r";
                        huboErrorNumerico++;
                    }
                }
                if (string.IsNullOrEmpty(txtLocalidad.Text))
                {
                    cadenaDeErrores += " Localidad \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtLocalidad.Text)))
                {
                    if (Int32.TryParse(txtLocalidad.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Localidad \r";
                        huboErrorNumerico++;
                    }
                }
               
                if (!(string.IsNullOrEmpty(txtPiso.Text)))
                {
                    if (!(Int32.TryParse(txtPiso.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Piso \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtPiso.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Piso \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }
                if (string.IsNullOrEmpty(txtNumero.Text))
                {
                    cadenaDeErrores += " Numero \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtNumero.Text)))
                {
                    if (!(Int32.TryParse(txtNumero.Text, out val)))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Numero \r";
                        huboErrorNumerico++;

                    }
                    else
                    {
                        if (int.Parse(txtNumero.Text) <= 0)
                        {
                            cadenaDeErrorValoresNegativos += "Numero \r";
                            huboErrorTipoDatos++;
                        }
                    }

                }
                if (string.IsNullOrEmpty(txtCalle.Text))
                {
                    cadenaDeErrores += " Calle \r";
                    huboError++;
                }
                if (!(string.IsNullOrEmpty(txtCalle.Text)))
                {
                    if (Int32.TryParse(txtCalle.Text, out val))
                    {
                        cadenaDeErrorNumeroYEsCaracter += "Calle \r";
                        huboErrorNumerico++;
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
                if (cboRubro.SelectedValue.ToString() == "Sin especificar")
                {
                    MessageBox.Show("Debe ingresar un rubro válido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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


                string hash = this.encriptacion(txtPassword.Text);
                UsuarioDOA doa = new UsuarioDOA();
                if (esAltaUsuario == 1)
                {
                    string hashE = this.encriptacion(txtPassword.Text);
                    doa.crearEmpresa("Empresa", txtUsuario.Text, hashE, txtMail.Text, txtCUITEmpresa.Text, txtNombreContEmpresa.Text, txtRazonEmpresa.Text, int.Parse(txtTelEmpresa.Text), txtCodPos.Text, txtDpto.Text, txtLocalidad.Text, int.Parse(txtPiso.Text), int.Parse(txtNumero.Text), txtCalle.Text, dtpCreacion.Value, cboRubro.SelectedValue.ToString(), txtCiudadEmpresa.Text);
                    MessageBox.Show("Se creo la empresa satisfactoriamente", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    if (irAlMenuPrincipal == 1)
                    {
                        Form1.f1.Show();
                        this.Hide();
                    }
                    if (irAlMenuPrincipal == 0)
                    {
                        Login.lg.Show();
                        this.Hide();
                    }
                    return;
                   
                }
                if (esAltaUsuario == 0)
                {
                    doa.modificarEmpresa("Empresa", txtUsuario.Text, txtPassword.Text, txtMail.Text, txtCUITEmpresa.Text, txtNombreContEmpresa.Text, txtRazonEmpresa.Text, int.Parse(txtTelEmpresa.Text), txtCodPos.Text, txtDpto.Text, txtLocalidad.Text, int.Parse(txtPiso.Text), int.Parse(txtNumero.Text), txtCalle.Text, dtpCreacion.Value, cboRubro.SelectedValue.ToString(), txtCiudadEmpresa.Text);
                    ModificacionUsuario mUsu = new ModificacionUsuario();
                    MessageBox.Show("Se modifico la empresa satisfactoriamente", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    mUsu.esModificar = true;
                    mUsu.cmdModificar.Visible = true;
                    mUsu.cmdEliminar.Visible = false;
                    mUsu.Show();
                    this.Hide();
                }
            }

         
        

          
           //GUARDAR LOS DATOS DE LOS txtUsuario txtContrasenia y demas en la BDD
          Login.lg.Show();
          this.Hide();

                
        }

        public string encriptacion(string input)
        {
            SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = provider.ComputeHash(inputBytes);

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)
                output.Append(hashedBytes[i].ToString("x2").ToLower());

            return output.ToString();
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            this.txtMail.Text = "";
            this.txtPassword.Text = "";
            this.txtUsuario.Text = "";

            this.txtCalle.Text = "";
            this.txtCodPos.Text = "";
            this.txtDpto.Text = "";
            this.txtLocalidad.Text = "";
            this.txtPiso.Text = "";
            this.txtNumero.Text = "";

            this.txtApellidoCliente.Text = "";
            this.txtDNICliente.Text = "";
            this.txtNombreCliente.Text = "";
            this.txtTelCliente.Text = "";
            this.cboTipoCliente.Text = "";

            this.txtCUITEmpresa.Text = "";
            this.txtNombreContEmpresa.Text = "";
            this.txtRazonEmpresa.Text = "";
            this.txtTelEmpresa.Text = "";
            this.cboRubro.Visible = false;
            this.lblRubroEmpresa.Visible = false;
            this.dtpCreacion.Value = Fecha.getFechaActual();
            
            

            this.dtpCreacion.Visible = false;


            this.rbEmpresa.Checked = false;
            this.rbCliente.Checked = false;

        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            if (esAltaUsuario == 1) {     
                if (irAlMenuPrincipal == 1)
                {
                    Form1.f1.Show();
                    this.Hide();
                }
                if (irAlMenuPrincipal == 0)
                {
                    Login.lg.Show();
                    this.Hide();
                }
            }
            if (esAltaUsuario == 0)
            {
                ModificacionUsuario mUsu = new ModificacionUsuario();
                mUsu.Show();
                mUsu.cmdModificar.Visible = true;
                mUsu.cmdEliminar.Visible = false;
                mUsu.esModificar = true;
                
                this.Hide();

            }
           
        }

        private void rbCliente_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.f1.Close(); 
        }

       
    }
}


