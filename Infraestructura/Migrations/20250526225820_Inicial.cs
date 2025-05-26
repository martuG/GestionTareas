using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCompletado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_Estado",
                table: "Tareas",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_Estado_Prioridad",
                table: "Tareas",
                columns: new[] { "Estado", "Prioridad" });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_FechaVencimiento",
                table: "Tareas",
                column: "FechaVencimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_Prioridad",
                table: "Tareas",
                column: "Prioridad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");
        }
    }
}
