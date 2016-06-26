using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1
{
    public class DataBase
    {
        private string _connectionString;
        private SqlConnection cnn;
        private static DataBase instance;
        private SqlTransaction tran;

        public static DataBase GetInstance()
        {
            if (instance == null)
                instance = new DataBase();

            return instance;
        }

        public SqlTransaction Transaccion
        {
            get { return tran; }
            set { tran = value; }
        }

        public SqlConnection Connection
        {
            get { return cnn; }
            set { cnn = value; }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public DataBase()
        {
        }

        public void Conectar(string cs)
        {
            ConnectionString = cs;
            cnn = new SqlConnection(ConnectionString);
            cnn.Open();

        }

        public void Desconectar()
        {
            cnn.Close();
        }

        public void Transaccion_Comenzar()
        {
            tran = cnn.BeginTransaction();
        }

        public void Transaccion_Commit()
        {
            tran.Commit();
            tran = null;
        }

        public void Transaccion_Rollback()
        {
            if (tran != null)
            {
                tran.Rollback();
                tran = null;
            }
        }
    }
}
