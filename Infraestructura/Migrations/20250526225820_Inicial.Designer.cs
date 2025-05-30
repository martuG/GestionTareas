﻿// <auto-generated />
using System;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructura.Migrations
{
    [DbContext(typeof(ContextTareas))]
    [Migration("20250526225820_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.Entidades.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("Descripcion");

                    b.Property<int>("Estado")
                        .HasColumnType("int")
                        .HasColumnName("Estado");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCreacion");

                    b.Property<DateTime?>("FechaFinalizada")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaCompletado");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaVencimiento");

                    b.Property<int>("Prioridad")
                        .HasColumnType("int")
                        .HasColumnName("Prioridad");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("Estado")
                        .HasDatabaseName("IX_Tareas_Estado");

                    b.HasIndex("FechaVencimiento")
                        .HasDatabaseName("IX_Tareas_FechaVencimiento");

                    b.HasIndex("Prioridad")
                        .HasDatabaseName("IX_Tareas_Prioridad");

                    b.HasIndex("Estado", "Prioridad")
                        .HasDatabaseName("IX_Tareas_Estado_Prioridad");

                    b.ToTable("Tareas", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
