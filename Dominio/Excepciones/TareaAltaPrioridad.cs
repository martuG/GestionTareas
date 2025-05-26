using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Excepciones
{
    public class TareaAltaPrioridad : Exception 
    {
        public int ContadorTareas { get; }

        public TareaAltaPrioridad(int contador)
            : base($"Aviso: Hay {contador} tareas pendientes de alta prioridad")
        {
            ContadorTareas = contador;
        }
    }
}
