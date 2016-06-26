using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Usuario
    {
      
        private string _username;
        private string _password;
        private bool _habilitado;
        private int _id_rol;
        private bool _esAdmin;
        public bool EsAdmin
        {
            get { return _esAdmin; }
            set { _esAdmin = value; }
        }

        public int Id_rol
        {
            get { return _id_rol; }
            set { _id_rol = value; }
        }

       /* public int Id
        {
            get { return _id; }
            set { _id = value; }
        }*/

        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

    }
}
