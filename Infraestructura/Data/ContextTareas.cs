using Dominio.Entidades;
using Infraestructura.Data.Configuracion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data
{
    public class ContextTareas : DbContext
    {
        public ContextTareas(DbContextOptions<ContextTareas> options) : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplicar configuraciones
            modelBuilder.ApplyConfiguration(new ConfiguracionTarea());
        }
    }
}
