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
    public partial class CambiarContrasenia : Form
    {

        public Boolean soyAdmin;
        public CambiarContrasenia()
        {
            InitializeComponent();
        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            if (soyAdmin)
            {
                Form1.f1.Show();
                this.Hide();
                return;
            }
            Login.lg.Show();
            this.Hide();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string cadenaDeErrores = "Debe completar los siguientes campos: \r";
            string cadenaDeErrorContrasenias = "Las contrasenias no coinciden";
            int huboError = 0;
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                cadenaDeErrores += " Usuario \r";
                huboError++;
            }
            if (string.IsNullOrEmpty(txtActual.Text))
            {
                cadenaDeErrores += " Contraseña actual\r";
                huboError++;
            }
            if (string.IsNullOrEmpty(txtContrasenia.Text))
            {
                cadenaDeErrores += " Contrasenia \r";
                huboError++;
            }


            if(string.IsNullOrEmpty(txtRepetir.Text))
            {
                cadenaDeErrores += " Repetir la contrasenia \r";
                huboError++;
            }

            
          
            if (huboError != 0)
            {
                MessageBox.Show(cadenaDeErrores, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                huboError = 0;
                return;
            }
           
            if(this.txtContrasenia.Text != this.txtRepetir.Text)
            {
                MessageBox.Show(cadenaDeErrorContrasenias, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtContrasenia.Text = "";
                txtRepetir.Text = "";
                return;
            }

            string hash1 = this.encriptacion(txtContrasenia.Text);
            string hash2 = this.encriptacion(txtActual.Text);
            UsuarioDOA doa = new UsuarioDOA();
            doa.cambiarContrasenia(txtUsuario.Text, hash1, hash2);
            MessageBox.Show("Se cambio la contraseña satisfactoriamente", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form1.f1.Close();
        }

        private void CambiarContrasenia_Load(object sender, EventArgs e)
        {

        }
    }
}
