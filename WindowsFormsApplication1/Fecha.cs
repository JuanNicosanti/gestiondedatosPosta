using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Fecha
    {       

        public static DateTime getFechaActual()
        {            
            return DateTime.ParseExact(ConfigurationManager.AppSettings["FechaSistema"], "yyyy-MM-dd HH:mm:ss",
                System.Globalization.CultureInfo.InvariantCulture);      
        }
    }
}
