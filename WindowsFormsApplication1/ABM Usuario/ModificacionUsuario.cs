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

namespace WindowsFormsApplication1.ABM_Usuario
{
    public partial class ModificacionUsuario : Form
    {
       
        SqlCommand cmd;
        SqlDataReader sdr;
        SqlDataAdapter adapter;
        private DataBase db;
        private Cliente unCliente;
        private Empresa unaEmpresa;
        private ClienteDOA doaCliente = new ClienteDOA();
        private EmpresaDOA doaEmpresa = new EmpresaDOA();

        public Boolean esModificar;

        public ModificacionUsuario()
        {
            InitializeComponent();
            db = DataBase.GetInstance();
        }

        private void ModificacionUsuario_Load(object sender, EventArgs e)
        {

            txtRazonSocial.Visible = false;
            txtEmailE.Visible = false;
            txtCUIT.Visible = false;
            lblCUIT.Visible = false;
            lblEmailE.Visible = false;
            lblRazonSocial.Visible = false;

            txtApellido.Visible = false;
            txtEmailC.Visible = false;
            txtDNI.Visible = false;
            txtNombre.Visible = false;
            lblApellido.Visible = false;
            lblDNI.Visible = false;
            lblEmailC.Visible = false;
            lblNombre.Visible = false;


            cmd = new SqlCommand("ROAD_TO_PROYECTO.ListaRoles", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Rol");
            adapter.Fill(dt);
            this.lstRoles.DataSource = dt;
            this.lstRoles.DisplayMember = "Nombre";
            lstRoles.ValueMember = lstRoles.DisplayMember;


             
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            //FALTA EL FILTRADO
        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            Form1.f1.Show();
            
            this.Hide();
            
        }

        private void cboSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSeleccion.SelectedItem.ToString() == "Cliente" )
            {
                txtApellido.Visible = true;
                txtEmailC.Visible = true;
                txtDNI.Visible = true;
                txtNombre.Visible = true;
                lblApellido.Visible = true;
                lblDNI.Visible = true;
                lblEmailC.Visible = true;
                lblNombre.Visible = true;


                txtRazonSocial.Visible = false;
                txtEmailE.Visible = false;
                txtCUIT.Visible = false;
                lblCUIT.Visible = false;
                lblEmailE.Visible = false;
                lblRazonSocial.Visible = false;
                txtRazonSocial.Text = "";
                txtEmailE.Text = "";
                txtCUIT.Text = "";
              
            }
            if (cboSeleccion.SelectedItem.ToString() == "Empresa")
            {
                txtRazonSocial.Visible = true;
                txtEmailE.Visible = true;
                txtCUIT.Visible = true;
                lblCUIT.Visible = true;
                lblEmailE.Visible = true;
                lblRazonSocial.Visible = true;

                txtApellido.Visible = false;
                txtEmailC.Visible = false;
                txtDNI.Visible = false;
                txtNombre.Visible = false;
                lblApellido.Visible = false;
                lblDNI.Visible = false;
                lblEmailC.Visible = false;
                lblNombre.Visible = false;
                txtApellido.Text = "";
                txtEmailC.Text = "";
                txtDNI.Text = "";
                txtNombre.Text = "";


            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.f1.Close(); 
        }

        private void cmdBusqueda_Click(object sender, EventArgs e)
        {
           
            string cadenaDeErrorTipo = "Debe seleccionar un tipo de filtro de busqueda";
            string cadenaDeErrorTipoUsuario = "Debe seleccionar un tipo de usuario";
            if (cboSeleccion.SelectedIndex == -1)
            {
                MessageBox.Show(cadenaDeErrorTipoUsuario, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (cboSeleccion.SelectedItem.ToString() == "Cliente")
            {
               
                
                if (string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtApellido.Text) && string.IsNullOrEmpty(txtDNI.Text) && string.IsNullOrEmpty(txtEmailC.Text))
                {
                    MessageBox.Show(cadenaDeErrorTipo, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                cmd = new SqlCommand("ROAD_TO_PROYECTO.Buscar_Cliente", db.Connection);
                cmd.CommandType = CommandType.StoredProcedure;


                if (string.IsNullOrEmpty(txtEmailC.Text))
                {
                    cmd.Parameters.AddWithValue("@Mail", SqlDbType.NVarChar).Value = "";
                }
                else {
                    cmd.Parameters.AddWithValue("@Mail", SqlDbType.NVarChar).Value = txtEmailC.Text;
                }

                
                if (string.IsNullOrEmpty(txtDNI.Text))
                {
                    cmd.Parameters.AddWithValue("@NroDocumento", DBNull.Value);
                }
                else {
                    cmd.Parameters.AddWithValue("@NroDocumento", SqlDbType.Int).Value = int.Parse(txtDNI.Text);
                }

               
               
                if (string.IsNullOrEmpty(txtApellido.Text))
                {
                    cmd.Parameters.AddWithValue("@Apellido", SqlDbType.NVarChar).Value = "";
                }
                else {
                    cmd.Parameters.AddWithValue("@Apellido", SqlDbType.NVarChar).Value = txtApellido.Text;
                }


                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    cmd.Parameters.AddWithValue("@Nombres", SqlDbType.NVarChar).Value = "";
                }
                else {
                    cmd.Parameters.AddWithValue("@Nombres", SqlDbType.NVarChar).Value = txtNombre.Text;
                }

                adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("ROAD_TO_PROYECTO.Cliente");
                adapter.Fill(dt);
                this.dataGridView1.DataSource = dt;

       

               
            }
            if (cboSeleccion.SelectedItem.ToString() == "Empresa")
            {
                if (string.IsNullOrEmpty(txtRazonSocial.Text) && string.IsNullOrEmpty(txtCUIT.Text) && string.IsNullOrEmpty(txtEmailE.Text))
                {
                    MessageBox.Show(cadenaDeErrorTipo, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                cmd = new SqlCommand("ROAD_TO_PROYECTO.Buscar_Empresa", db.Connection);
                cmd.CommandType = CommandType.StoredProcedure;


                if (string.IsNullOrEmpty(txtEmailE.Text))
                {
                    cmd.Parameters.AddWithValue("@Mail", SqlDbType.NVarChar).Value = "";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Mail", SqlDbType.NVarChar).Value = txtEmailE.Text;
                }


                if (string.IsNullOrEmpty(txtCUIT.Text))
                {
                    cmd.Parameters.AddWithValue("@CUIT", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CUIT", SqlDbType.NVarChar).Value = txtCUIT.Text;
                }



                if (string.IsNullOrEmpty(txtRazonSocial.Text))
                {
                    cmd.Parameters.AddWithValue("@RazonSocial", SqlDbType.NVarChar).Value = "";
                }
                else
                {
                    cmd.Parameters.AddWithValue("@RazonSocial", SqlDbType.NVarChar).Value = txtRazonSocial.Text;
                }


                adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("ROAD_TO_PROYECTO.Empresa");
                adapter.Fill(dt);
                this.dataGridView1.DataSource = dt;      

            }
            if (esModificar)
            {
                lstRoles.Visible = true;
                cmdAsignarRol.Visible = true;
                lblRoles.Visible = true;
            }
           
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {

                MessageBox.Show("Debe seleccionar un usuario a modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (cboSeleccion.SelectedItem.ToString() == "Cliente")
            {
              

                int fila = dataGridView1.CurrentRow.Index;
            
                String celdaUserCliente = (String)dataGridView1[0, fila].Value;

                cargarUnClienteSeleccionado(celdaUserCliente);

                this.Hide();
                AltaUsuario.aus.Show();
                return;


            }
            if (cboSeleccion.SelectedItem.ToString() == "Empresa")
            {
               

                int fila = dataGridView1.CurrentRow.Index;

                String celdaUserEmpresa = (String)dataGridView1[0, fila].Value;

                cargarUnaEmpresaSeleccionada(celdaUserEmpresa);

                this.Hide();
                AltaUsuario.aus.Show();
                return;

            }
       
        }

        private void cargarUnaEmpresaSeleccionada(String userEmpresa)
        {
            unaEmpresa = doaEmpresa.crearUnaEmpresa(userEmpresa);

            AltaUsuario aus = new AltaUsuario();
            AltaUsuario.aus.esAltaUsuario = 0;
            AltaUsuario.aus.rbEmpresa.Checked = true;
            AltaUsuario.aus.txtPassword.PasswordChar = '*';
            AltaUsuario.aus.txtUsuario.Text = unaEmpresa.username;
            AltaUsuario.aus.txtPassword.Text = unaEmpresa.password;
            AltaUsuario.aus.txtTelEmpresa.Text = Convert.ToString(unaEmpresa.telefono);
          
            AltaUsuario.aus.txtDpto.Text = unaEmpresa.departamento;
            AltaUsuario.aus.txtCalle.Text = unaEmpresa.calle;
            AltaUsuario.aus.txtPiso.Text =Convert.ToString(unaEmpresa.piso);
            AltaUsuario.aus.txtNumero.Text = Convert.ToString(unaEmpresa.numero);
            AltaUsuario.aus.txtLocalidad.Text =unaEmpresa.localidad;
            AltaUsuario.aus.txtRazonEmpresa.Text =unaEmpresa.razonSocial;
            AltaUsuario.aus.txtMail.Text =unaEmpresa.mail;
            AltaUsuario.aus.txtTelEmpresa.Text =Convert.ToString(unaEmpresa.telefono);
            AltaUsuario.aus.txtCodPos.Text =Convert.ToString(unaEmpresa.codPostal);
            AltaUsuario.aus.txtCiudadEmpresa.Text =unaEmpresa.ciudad;
            AltaUsuario.aus.txtCUITEmpresa.Text =Convert.ToString(unaEmpresa.cuit);
            AltaUsuario.aus.txtNombreContEmpresa.Text =unaEmpresa.nombreContacto;
            AltaUsuario.aus.rubroModificado = unaEmpresa.rubro;

            AltaUsuario.aus.rbCliente.Enabled = false;
            AltaUsuario.aus.rbEmpresa.Enabled = false;
            AltaUsuario.aus.txtUsuario.Enabled = false;
            AltaUsuario.aus.txtPassword.Enabled = false;
        }
        private void cargarUnClienteSeleccionado(String userCliente)
        {
            unCliente = doaCliente.crearUnCliente(userCliente);

            AltaUsuario aus = new AltaUsuario();
            aus.esAltaUsuario = 0;
            aus.rbCliente.Checked = true;

            aus.txtUsuario.Text = unCliente.username;
            aus.txtPassword.PasswordChar = '*';
            aus.txtPassword.Text =unCliente.password;
            aus.txtTelCliente.Text =Convert.ToString(unCliente.telefono);
            aus.txtDpto.Text =unCliente.departamento;
            aus.txtCalle.Text =unCliente.calle;
            aus.txtPiso.Text =Convert.ToString(unCliente.piso);
            aus.txtLocalidad.Text =unCliente.localidad;
            aus.txtApellidoCliente.Text =unCliente.apellido;
            aus.txtNombreCliente.Text =unCliente.nombre;
            aus.txtDNICliente.Text =Convert.ToString(unCliente.dni);
            aus.cboTipoCliente.SelectedItem =unCliente.tipoDocumento; 
            aus.txtMail.Text =unCliente.mail;
            aus.txtCodPos.Text =Convert.ToString(unCliente.codPostal);
            aus.dtpCreacion.Value = unCliente.nacimiento;
            aus.txtNumero.Text = Convert.ToString(unCliente.numero);

            AltaUsuario.aus.rbCliente.Enabled = false;
            AltaUsuario.aus.rbEmpresa.Enabled = false;
            AltaUsuario.aus.txtUsuario.Enabled = false;
            AltaUsuario.aus.txtPassword.Enabled = false;
            }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
            
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            cboSeleccion.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            
            txtRazonSocial.Text = "";
            txtEmailE.Text = "";
            txtCUIT.Text = "";          
            txtApellido.Text = "";
            txtEmailC.Text = "";
            txtDNI.Text = "";
            txtNombre.Text = "";

            lblRoles.Visible = false;
            lstRoles.Visible = false;
            cmdAsignarRol.Visible = false;
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {

                MessageBox.Show("Debe seleccionar un usuario a modificar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
         

                int fila = dataGridView1.CurrentRow.Index;

                String celdaUser = (String)dataGridView1[0, fila].Value;

                borrarUserSeleccionado(celdaUser);


        }


        private void borrarUserSeleccionado(String celdaUser)
        {
            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.Baja_Usuario", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = celdaUser;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Se dio se baja a un usuario correctamente", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        private void cmdAsignarRol_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {

                MessageBox.Show("Debe seleccionar un usuario a asignarle un rol", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }


            int fila = dataGridView1.CurrentRow.Index;

            String celdaUser = (String)dataGridView1[0, fila].Value;
            String nuevoRol = lstRoles.SelectedValue.ToString();

            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.AsignarRolAUsuario", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = celdaUser;
            cmd.Parameters.AddWithValue("@RolAsignado", SqlDbType.NVarChar).Value = nuevoRol;
            cmd.ExecuteNonQuery();

            MessageBox.Show("Se ha asignado un rol correctamente", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    
    }
}
