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
        public ContextTareas(DbContextOptions<ContextTareas> opciones) : base(opciones)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ConfiguracionTarea());
        }
    }
}
