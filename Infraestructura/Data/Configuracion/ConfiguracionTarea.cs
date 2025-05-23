using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.Configuracion
{
    public class ConfiguracionTarea : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            // Tabla
            builder.ToTable("Tareas");

            // Clave primaria
            builder.HasKey(t => t.Id);

            // Propiedades
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            // Configuración para TituloTarea (Value Object)
            builder.Property(t => t.Titulo)
                .HasConversion(
                    titulo => titulo,
                    valor => new TituloTarea(valor))
                .HasColumnName("Titulo")
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Descripcion)
                .HasColumnName("Descripcion")
                .HasColumnType("nvarchar(1000)")
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(t => t.FechaVencimiento)
                .HasColumnName("FechaVencimiento")
                .HasColumnType("datetime2")
                .IsRequired();

            // Enum como int en base de datos
            builder.Property(t => t.Prioridad)
                .HasColumnName("Prioridad")
                .HasConversion<int>()
                .IsRequired();

            builder.Property(t => t.Estado)
                .HasColumnName("Estado")
                .HasConversion<int>()
                .IsRequired();

            builder.Property(t => t.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(t => t.FechaFinalizada)
                .HasColumnName("FechaCompletado")
                .HasColumnType("datetime2")
                .IsRequired(false);

            // Índices para mejorar performance
            builder.HasIndex(t => t.Estado)
                .HasDatabaseName("IX_Tareas_Estado");

            builder.HasIndex(t => t.Prioridad)
                .HasDatabaseName("IX_Tareas_Prioridad");

            builder.HasIndex(t => t.FechaVencimiento)
                .HasDatabaseName("IX_Tareas_FechaVencimiento");

            builder.HasIndex(t => new { t.Estado, t.Prioridad })
                .HasDatabaseName("IX_Tareas_Estado_Prioridad");
        }
    }
}
