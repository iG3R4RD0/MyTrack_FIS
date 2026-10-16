using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNueva.PostgreConect
{
    internal class Equipo
    {
        public int EquipoID { get; set; }
        public int Carga { get; set; }
        public string Tipo { get; set; }
        public string Uso { get; set; }
        public int Estatus { get; set; }
        public string Nombre { get; set; }
    }
}
