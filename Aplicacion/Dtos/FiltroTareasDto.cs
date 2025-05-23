using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dtos
{
    public class FiltroTareasDto
    {
        public string Estado { get; set; }
        public string OrdenarPor { get; set; } = "Prioridad";
        public string Direccion { get; set; } = "Desc";
    }
}
