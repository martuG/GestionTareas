using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class TituloTarea
    {
        public string Valor { get; }

        public TituloTarea(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("El título de la tarea no puede estar vacío", nameof(valor));

            if (valor.Length > 200)
                throw new ArgumentException("El título no puede exceder 200 caracteres", nameof(valor));

            Valor = valor.Trim();
        }

        public override bool Equals(object obj)
        {
            return obj is TituloTarea other && Valor == other.Valor;
        }

        public override int GetHashCode()
        {
            return Valor?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return Valor;
        }

        public static implicit operator string(TituloTarea titulo)
        {
            return titulo?.Valor;
        }

        public static implicit operator TituloTarea(string valor)
        {
            return new TituloTarea(valor);
        }
    }
}
