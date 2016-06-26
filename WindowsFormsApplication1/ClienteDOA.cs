using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class ClienteDOA
    {
        private DataBase db;

        public ClienteDOA()
        {
            db = DataBase.GetInstance();
        }
        
        public Cliente crearUnCliente(String userCliente)
        {
            //especifico que SP voy a ejecutar
            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.ObtenerDatosCliente", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //seteo los parametros que recibe el stored procedure
            cmd.Parameters.AddWithValue("@IdUsuario", SqlDbType.NVarChar).Value = userCliente;
            Cliente unCliente = null;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                unCliente = LoadObject(sdr);
            }
            sdr.Close();
            return unCliente;
        }

        private Cliente LoadObject(SqlDataReader reader)
        {
            Cliente unCliente = new Cliente();
            //lo que va entre parentesis son los nombres de las columnas que devuelve el SP
            unCliente.username = reader["Usuario"].ToString();
            unCliente.password = reader["Contraseña"].ToString();
            unCliente.mail = reader["Mail"].ToString();
            unCliente.nombre = reader["Nombres"].ToString();
            unCliente.apellido = reader["Apellido"].ToString();
            unCliente.dni = int.Parse(reader["NroDocumento"].ToString());
            unCliente.telefono = int.Parse(reader["Telefono"].ToString());
            unCliente.tipoDocumento = reader["Tipodocumento"].ToString();
            unCliente.codPostal = int.Parse(reader["Codpostal"].ToString());
            unCliente.localidad = reader["Localidad"].ToString();
            unCliente.piso = int.Parse(reader["Piso"].ToString());
            unCliente.numero = int.Parse(reader["Numero"].ToString());
            unCliente.calle = reader["Calle"].ToString();
            unCliente.departamento = reader["Depto"].ToString();
            unCliente.nacimiento = Convert.ToDateTime(reader["Fechanacimiento"]);
            return unCliente;
        }
    }
}