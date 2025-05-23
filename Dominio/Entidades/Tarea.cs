namespace Dominio.Entidades
{
    public class Tarea
    {
        public Tarea()
        {
            Estado = Estado.Pendiente;
            FechaCreacion = DateTime.Today;
        }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFinalizada { get; set; }
        public Prioridad Prioridad { get; set; }
        public Estado Estado { get; set; }

        public void MarcarComoCompletada()
        {
            if (Estado == Estado.Completada)
                throw new InvalidOperationException("La tarea ya está completada");

            if (DateTime.Now.Date > FechaVencimiento.Date)
                throw new InvalidOperationException("No se puede completar una tarea vencida");

            Estado = Estado.Completada;
            FechaFinalizada = DateTime.UtcNow;
        }

        public void ActualizarTarea(TituloTarea nuevoTitulo, string nuevaDescripcion, DateTime nuevaFechaVencimiento, Prioridad nuevaPrioridad)
        {
            if (Estado == Estado.Completada)
                throw new InvalidOperationException("No se puede modificar una tarea completada");

            if (nuevaFechaVencimiento < DateTime.Now.Date)
                throw new ArgumentException("La fecha de vencimiento no puede ser anterior a hoy", nameof(nuevaFechaVencimiento));

            Titulo = nuevoTitulo ?? throw new ArgumentNullException(nameof(nuevoTitulo));
            Descripcion = nuevaDescripcion ?? string.Empty;
            FechaVencimiento = nuevaFechaVencimiento;
            Prioridad = nuevaPrioridad;
        }

        public bool EstaVencida()
        {
            return DateTime.Now.Date > FechaVencimiento.Date && Estado == Estado.Pendiente;
        }

        public bool EsDeAltaPrioridad()
        {
            return Prioridad == Prioridad.Alta;
        }
    }
}
