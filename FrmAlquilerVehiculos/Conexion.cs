using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FrmAlquilerVehiculos
{
    internal class Conexion
    {
        private readonly string cadena =
            "Server = LAPTOP-T7G8UDJV; Database = RentaVehiculos; Integrated Security = True;";
        public SqlConnection Abrir()
        {
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            return cn;
        }
    }
}
