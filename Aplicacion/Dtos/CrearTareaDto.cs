using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dtos
{
    public class CrearTareaDto
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(200, ErrorMessage = "El título no puede exceder 200 caracteres")]
        public string Titulo { get; set; }

        [StringLength(1000, ErrorMessage = "La descripción no puede exceder 1000 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria")]
        public DateTime FechaVencimiento { get; set; }

        [Required(ErrorMessage = "La prioridad es obligatoria")]
        [Range(1, 3, ErrorMessage = "La prioridad debe ser: 1=Baja, 2=Media, 3=Alta")]
        public int Prioridad { get; set; }
    }
}
