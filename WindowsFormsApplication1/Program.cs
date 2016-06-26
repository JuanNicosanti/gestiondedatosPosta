using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //cnn = new SqlConnection(@"Data Source=localhost\SQLSERVER2012;Initial Catalog=GD1C2016;Persist Security Info=True;User ID=gd;Password=gd2016");

            string connectionString = @"Data Source=localhost\SQLSERVER2012;Initial Catalog=GD1C2016;Persist Security Info=True;User ID=gd;Password=gd2016";
            connectionString += "; MultipleActiveResultSets=True";
            
            try
            {                
                DataBase.GetInstance().Conectar(connectionString);                
            }
            catch
            {
                MessageBox.Show("No se pudo conectar con " + DataBase.GetInstance().ConnectionString);
                Application.Exit();
            }
            
            Application.Run(new Form1());
        }
        public static Usuario UsuarioLogueado;
    }
}
