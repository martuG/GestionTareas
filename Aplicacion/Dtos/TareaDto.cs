namespace Aplicacion.Dtos
{
    public class TareaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaCompletado { get; set; }
        public bool EstaVencida { get; set; }
    }
}
