using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Excepciones
{
    public class TareaVencida : Exception
    {
        public TareaVencida()
            : base("No se puede completar una tarea vencida")
        {
        }
    }
}
