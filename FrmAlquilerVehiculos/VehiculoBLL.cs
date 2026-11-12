using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmAlquilerVehiculos
{
    internal class VehiculoBLL
    {
        private VehiculoDAL vehiculoDAL = new VehiculoDAL();

        public List<Vehiculo> ObtenerVehiculos()
        {
            return vehiculoDAL.ListarVehiculos();
        }
    }
}
