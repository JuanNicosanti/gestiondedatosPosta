using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class EmpresaDOA
    {
        private DataBase db;

        public EmpresaDOA()
        {
            db = DataBase.GetInstance();
        }

        public Empresa crearUnaEmpresa(String userEmpresa)
        {
            //especifico que SP voy a ejecutar
            SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.ObtenerDatosEmpresa", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            //seteo los parametros que recibe el stored procedure
            cmd.Parameters.AddWithValue("@IdUsuario", SqlDbType.NVarChar).Value = userEmpresa;
            Empresa unaEmpresa = null;
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                unaEmpresa = LoadObject(sdr);
            }
            sdr.Close();
            return unaEmpresa;
        }

        private Empresa LoadObject(SqlDataReader reader)
        {
            Empresa unaEmpresa = new Empresa();
            //lo que va entre parentesis son los nombres de las columnas que devuelve el SP
            unaEmpresa.username = reader["Usuario"].ToString();
            unaEmpresa.password = reader["Contraseña"].ToString();
            unaEmpresa.mail = reader["Mail"].ToString();
            unaEmpresa.cuit = reader["CUIT"].ToString();
            unaEmpresa.nombreContacto = reader["NombreContacto"].ToString();
            unaEmpresa.razonSocial = reader["RazonSocial"].ToString();
            unaEmpresa.telefono = int.Parse(reader["Telefono"].ToString());
            unaEmpresa.rubro = reader["DescripLarga"].ToString();
            unaEmpresa.codPostal = int.Parse(reader["CodPostal"].ToString());
            unaEmpresa.localidad = reader["Localidad"].ToString();
            unaEmpresa.piso = int.Parse(reader["Piso"].ToString());
            unaEmpresa.numero = int.Parse(reader["Numero"].ToString());
            unaEmpresa.calle = reader["Calle"].ToString();
            unaEmpresa.departamento = reader["Depto"].ToString();
            unaEmpresa.ciudad = reader["Ciudad"].ToString();
            unaEmpresa.creacion = Convert.ToDateTime(reader["FechaCreacion"]);
            return unaEmpresa;
        }
    }
}

