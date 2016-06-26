using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class UsuarioDOA
    {
        private DataBase db;
        public List<Usuario> listaUsuarios = new List<Usuario>();
        public UsuarioDOA()
        {
            db = DataBase.GetInstance();
        }
        
        public void crearCliente(string cliente, string usuario, string password, string mail, string apellido, string nombre, int DOC, int telefono, string tipoDOC, string codPos, string Dpto, string localidad, int piso, int numero, string calle, DateTime nacimiento){
            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.Alta_Cliente", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RolAsignado", SqlDbType.NVarChar).Value = cliente;
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = usuario;
            cmd.Parameters.AddWithValue("@Contraseña", SqlDbType.NVarChar).Value = password;
            cmd.Parameters.AddWithValue("@Mail", SqlDbType.NVarChar).Value = mail;
            cmd.Parameters.AddWithValue("@Apellido", SqlDbType.NVarChar).Value = apellido;
            cmd.Parameters.AddWithValue("@Nombres", SqlDbType.NVarChar).Value = nombre;
            cmd.Parameters.AddWithValue("@NroDocumento", SqlDbType.Int).Value = DOC;
            cmd.Parameters.AddWithValue("@Telefono", SqlDbType.Int).Value = telefono;
            cmd.Parameters.AddWithValue("@TipoDocumento", SqlDbType.NVarChar).Value = tipoDOC;
            cmd.Parameters.AddWithValue("@CodPostal", SqlDbType.NVarChar).Value = codPos;
            cmd.Parameters.AddWithValue("@Depto", SqlDbType.NVarChar).Value = Dpto;
            cmd.Parameters.AddWithValue("@Localidad",SqlDbType.NVarChar).Value = localidad;
            cmd.Parameters.AddWithValue("@Piso", SqlDbType.Int).Value = piso;
            cmd.Parameters.AddWithValue("@Numero", SqlDbType.Int).Value = numero;
            cmd.Parameters.AddWithValue("@Calle", SqlDbType.NVarChar).Value = calle;
            cmd.Parameters.AddWithValue("@FechaNacimiento", SqlDbType.DateTime).Value = nacimiento;
            cmd.Parameters.AddWithValue("@FechaActual", SqlDbType.DateTime).Value = Fecha.getFechaActual();
            cmd.ExecuteNonQuery();

        }

        public void crearEmpresa(string empresa, string usuario, string password, string mail, string cuit, string nombreContacto, string razonEmp, int telefono, string codPos, string Dpto, string localidad, int piso, int numero, string calle, DateTime nacimiento, string rubro, string ciudad)
        {
            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.Alta_Empresa", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RolAsignado", SqlDbType.NVarChar).Value = empresa;
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = usuario;
            cmd.Parameters.AddWithValue("@Contraseña", SqlDbType.NVarChar).Value = password;
            cmd.Parameters.AddWithValue("@Mail", SqlDbType.NVarChar).Value = mail;
            cmd.Parameters.AddWithValue("@CUIT", SqlDbType.NVarChar).Value = cuit;
            cmd.Parameters.AddWithValue("@NombreContacto", SqlDbType.NVarChar).Value = nombreContacto;
            cmd.Parameters.AddWithValue("@RazonSocial", SqlDbType.NVarChar).Value = razonEmp;
            cmd.Parameters.AddWithValue("@Telefono", SqlDbType.Int).Value = telefono;
            cmd.Parameters.AddWithValue("@CodPostal", SqlDbType.NVarChar).Value = codPos;
            cmd.Parameters.AddWithValue("@Depto", SqlDbType.NVarChar).Value = Dpto;
            cmd.Parameters.AddWithValue("@Localidad", SqlDbType.NVarChar).Value = localidad;
            cmd.Parameters.AddWithValue("@Piso", SqlDbType.Int).Value = piso;
            cmd.Parameters.AddWithValue("@Numero", SqlDbType.Int).Value = numero;
            cmd.Parameters.AddWithValue("@Calle", SqlDbType.NVarChar).Value = calle;
            cmd.Parameters.AddWithValue("@FechaCreacion", SqlDbType.DateTime).Value = nacimiento;
            cmd.Parameters.AddWithValue("@Rubro", SqlDbType.NVarChar).Value = rubro;
            cmd.Parameters.AddWithValue("@Ciudad", SqlDbType.NVarChar).Value = ciudad;
            cmd.Parameters.AddWithValue("@FechaActual", SqlDbType.DateTime).Value = Fecha.getFechaActual();
            cmd.ExecuteNonQuery();
                
        }

        public void cambiarContrasenia(string usuario, string nuevaContrasenia, string actualContrasenia)
        {
            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.Cambiar_Contraseña", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = usuario;
            cmd.Parameters.AddWithValue("@Contraseña", SqlDbType.NVarChar).Value = actualContrasenia;
            cmd.Parameters.AddWithValue("@ContraseñaNueva", SqlDbType.NVarChar).Value = nuevaContrasenia;
            cmd.ExecuteNonQuery();
        }

        public void modificarCliente(string cliente, string usuario, string password, string mail, string apellido, string nombre, int DOC, int telefono, string tipoDOC, string codPos, string Dpto, string localidad, int piso, int numero, string calle, DateTime nacimiento)
        {
            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.Modificacion_Cliente", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RolAsignado", SqlDbType.NVarChar).Value = cliente;
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = usuario;
            cmd.Parameters.AddWithValue("@Contraseña", SqlDbType.NVarChar).Value = password;
            cmd.Parameters.AddWithValue("@Mail", SqlDbType.NVarChar).Value = mail;
            cmd.Parameters.AddWithValue("@Apellido", SqlDbType.NVarChar).Value = apellido;
            cmd.Parameters.AddWithValue("@Nombres", SqlDbType.NVarChar).Value = nombre;
            cmd.Parameters.AddWithValue("@NroDocumento", SqlDbType.Int).Value = DOC;
            cmd.Parameters.AddWithValue("@Telefono", SqlDbType.Int).Value = telefono;
            cmd.Parameters.AddWithValue("@TipoDocumento", SqlDbType.NVarChar).Value = tipoDOC;
            cmd.Parameters.AddWithValue("@CodPostal", SqlDbType.NVarChar).Value = codPos;
            cmd.Parameters.AddWithValue("@Depto", SqlDbType.NVarChar).Value = Dpto;
            cmd.Parameters.AddWithValue("@Localidad", SqlDbType.NVarChar).Value = localidad;
            cmd.Parameters.AddWithValue("@Piso", SqlDbType.Int).Value = piso;
            cmd.Parameters.AddWithValue("@Numero", SqlDbType.Int).Value = numero;
            cmd.Parameters.AddWithValue("@Calle", SqlDbType.NVarChar).Value = calle;
            cmd.Parameters.AddWithValue("@FechaNacimiento", SqlDbType.DateTime).Value = nacimiento;
            cmd.ExecuteNonQuery();
        }
        public void modificarEmpresa(string empresa, string usuario, string password, string mail, string cuit, string nombreContacto, string razonEmp, int telefono, string codPos, string Dpto, string localidad, int piso, int numero, string calle, DateTime nacimiento, string rubro, string ciudad)
        {
            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.Modificacion_Empresa", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RolAsignado", SqlDbType.NVarChar).Value = empresa;
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = usuario;
            cmd.Parameters.AddWithValue("@Contraseña", SqlDbType.NVarChar).Value = password;
            cmd.Parameters.AddWithValue("@Mail", SqlDbType.NVarChar).Value = mail;
            cmd.Parameters.AddWithValue("@CUIT", SqlDbType.NVarChar).Value = cuit;
            cmd.Parameters.AddWithValue("@NombreContacto", SqlDbType.NVarChar).Value = nombreContacto;
            cmd.Parameters.AddWithValue("@RazonSocial", SqlDbType.NVarChar).Value = razonEmp;
            cmd.Parameters.AddWithValue("@Telefono", SqlDbType.Int).Value = telefono;
            cmd.Parameters.AddWithValue("@CodPostal", SqlDbType.NVarChar).Value = codPos;
            cmd.Parameters.AddWithValue("@Depto", SqlDbType.NVarChar).Value = Dpto;
            cmd.Parameters.AddWithValue("@Localidad", SqlDbType.NVarChar).Value = localidad;
            cmd.Parameters.AddWithValue("@Piso", SqlDbType.Int).Value = piso;
            cmd.Parameters.AddWithValue("@Numero", SqlDbType.Int).Value = numero;
            cmd.Parameters.AddWithValue("@Calle", SqlDbType.NVarChar).Value = calle;
            cmd.Parameters.AddWithValue("@FechaCreacion", SqlDbType.DateTime).Value = nacimiento;
            cmd.Parameters.AddWithValue("@Rubro", SqlDbType.NVarChar).Value = rubro;
            cmd.Parameters.AddWithValue("@Ciudad", SqlDbType.NVarChar).Value = ciudad;
            cmd.ExecuteNonQuery();
        }



        public List<Usuario> Login(string username, string password)
        {
            

            //especifico que SP voy a ejecutar
            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.Usuario_Login", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //seteo los parametros que recibe el stored procedure
            cmd.Parameters.AddWithValue("@username", SqlDbType.NVarChar).Value = username;
            cmd.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = password;
            //ejecuto la consulta y traigo el resultado
            
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Usuario usuarioResultado = null;
                usuarioResultado = LoadObject(sdr);
                listaUsuarios.Add(usuarioResultado);
            }
            sdr.Close();
            WindowsFormsApplication1.Form1.f1.user = username;
            return listaUsuarios;
        }

        private Usuario LoadObject(SqlDataReader reader)
        {
            Usuario usuario = new Usuario();
            //lo que va entre parentesis son los nombres de las columnas que devuelve el SP
            usuario.Username = reader["username"].ToString();
            usuario.Password = reader["password"].ToString();
            usuario.Habilitado = Convert.ToBoolean(reader["habilitado"].ToString());
            usuario.Id_rol = (int)reader["rol"];
          
            return usuario;
        }
    }
}
