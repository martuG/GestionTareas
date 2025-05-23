using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Excepciones
{
    public class TareaNoEncontrada : Exception
    {
        public TareaNoEncontrada(int id)
            : base($"La tarea con ID {id} no fue encontrada")
        {
        }
    }
}
