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
    public partial class Login : Form
    {
        public int intentos_fallidos;
        public bool tieneMasDeUnRol;
        public String unRol;
        public int idUnRol;

        public bool necesita_logueo;
        public SHA256 mySHA256 = SHA256Managed.Create();
        public static Login lg;
        private List<int> idRoles = new List<int>();
        private DataBase db;

        private String rolElegido;

    
        public Login()
        {

            InitializeComponent();
            db = DataBase.GetInstance();
            intentos_fallidos=0;
            Login.lg = this;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cboRoles.Visible = false;
            cmdLoguear.Visible = false;
            
        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            Form1.f1.Show();
            this.Hide();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            txtContrasenia.Clear();
            txtUsuario.Clear();
            this.timer1.Stop();
            this.toolStripProgressBar1.Value = 0;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string cadenaDeErrores = "Debe completar los siguientes campos: \r";
            int huboError = 0;
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                cadenaDeErrores += " Usuario \r";
                huboError++;
            }
            if (string.IsNullOrEmpty(txtContrasenia.Text))
            {
                cadenaDeErrores += " Contrasenia \r";
                huboError++;
            }

            if (huboError != 0)
            {
                MessageBox.Show(cadenaDeErrores, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            string hash = this.encriptacion(txtContrasenia.Text);
            UsuarioDOA doa = new UsuarioDOA();
            List<Usuario> user = doa.Login(txtUsuario.Text, hash);
          
            if (user.Count > 1)
            {
                for(int i = 0; user.Count > i  ; i++){
                   idRoles.Add(user[i].Id_rol);
                }

                if (!user[0].Habilitado)
                {
                    MessageBox.Show("Usuario inhabilitado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    Form1.f1.estaHabilitado = false;
                }
                else
                {
                    Form1.f1.estaHabilitado = true;
                }
                this.cargarComboBoxDeRoles(idRoles);
                cmdAceptar.Enabled = false;
                MessageBox.Show("Elija un rol", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                cboRoles.Visible = true;
                cboRoles.SelectedIndex = -1;
                cmdLoguear.Visible = true;
                tieneMasDeUnRol = true;
                return;
            }

            if (!user.Any<Usuario>())
            {
                MessageBox.Show("Datos incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                return;
            }
            else if (!user[0].Habilitado)
            {
                MessageBox.Show("Usuario inhabilitado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                Form1.f1.estaHabilitado = false;                
            }
            else
            {
                Form1.f1.estaHabilitado = true;
            }
    
            idRoles.Add(user[0].Id_rol);
            tieneMasDeUnRol = false;
            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.DetalleDeUnRol", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Rol", SqlDbType.Int).Value = idRoles[0];
             
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            unRol = sdr["nombreRol"].ToString();
            if (unRol.Equals("Administrador"))
            {
                Form1.f1.esAdmin = true;
            }
            idUnRol = idRoles[0];
            this.timer1.Start();              
           
 }

        private void cargarComboBoxDeRoles(List<int> idRoles){
            for(int i = 0; idRoles.Count > i ; i++){
                SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.DetalleDeUnRol", db.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rol", SqlDbType.Int).Value = idRoles[i];
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                cboRoles.Items.Add(sdr["nombreRol"].ToString());
            }
            cboRoles.ValueMember = cboRoles.DisplayMember;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripProgressBar1.Increment(1);
        
            if (this.toolStripProgressBar1.Value == toolStripProgressBar1.Maximum )
            {
                this.toolStripProgressBar1.Value = 0;

                Form1.f1.user = this.txtUsuario.Text;
                
                if (tieneMasDeUnRol)
                {
                    Form1.f1.rol = this.cboRoles.SelectedItem.ToString();
                }
                else
                {
                    Form1.f1.rol = unRol;
                    
                }
                Form1.f1.hayUsuario = true;
                Form1.f1.Show();
                Form1.f1.idRol = idUnRol;
                this.timer1.Stop();
                
                this.Hide();
                
            }
            
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            ProgressBar pBar = new ProgressBar();
        }

        private void cmdRegistrarse_Click(object sender, EventArgs e)
        {
            AltaUsuario altaUsuario = new AltaUsuario();
            altaUsuario.esAltaUsuario = 1;
            altaUsuario.irAlMenuPrincipal = 0;
            altaUsuario.Show();
            this.Hide();
            
        }

        private void cmdCambiarContrasenia_Click(object sender, EventArgs e)
        {
            CambiarContrasenia cambioContrasenia = new CambiarContrasenia();
            cambioContrasenia.soyAdmin = false;
            cambioContrasenia.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1.f1.Close(); 
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

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

        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            rolElegido = cboRoles.SelectedItem.ToString();
            
        }

        private void cmdLoguear_Click(object sender, EventArgs e)
        {
            if (cboRoles.SelectedIndex == -1)
            {
                MessageBox.Show("Elija un rol", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            cmdAceptar.Enabled = true;
            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.IdBasadoANombreRol", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", SqlDbType.NVarChar).Value = rolElegido;

            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            idUnRol = (int)sdr["id"];
            this.timer1.Start();
        }

    }
}
