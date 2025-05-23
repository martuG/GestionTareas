using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dtos
{
    public class ResultadoOperacionDto
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public bool EsAdvertencia { get; set; }

        public static ResultadoOperacionDto ExitosoConMensaje(string mensaje)
        {
            return new ResultadoOperacionDto
            {
                Exito = true,
                Mensaje = mensaje,
                EsAdvertencia = false
            };
        }

        public static ResultadoOperacionDto ExitosoConAdvertencia(string mensaje)
        {
            return new ResultadoOperacionDto
            {
                Exito = true,
                Mensaje = mensaje,
                EsAdvertencia = true
            };
        }

        public static ResultadoOperacionDto Fallido(string mensaje)
        {
            return new ResultadoOperacionDto
            {
                Exito = false,
                Mensaje = mensaje,
                EsAdvertencia = false
            };
        }
    }
}
