using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FrmAlquilerVehiculos
{
    internal class VehiculoDAL
    {
        private Conexion conexion = new Conexion();

        public List<Vehiculo> ListarVehiculos()
        {
            List<Vehiculo> lista = new List<Vehiculo>();

            using (SqlConnection cn = conexion.Abrir())
            {
                string query = "SELECT Placa, Marca + ' ' + Modelo AS NombreVehiculo FROM Vehiculos";

                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Vehiculo
                    {
                        Placa = dr["Placa"].ToString(),
                        Nombre = dr["NombreVehiculo"].ToString()
                    });
                }
            }
            return lista;
        }
    }
}
