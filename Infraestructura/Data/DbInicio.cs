using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Infraestructura.Data
{
    public static class DbInicio
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ContextTareas>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<ContextTareas>>();

            try
            {
                // Aplicar migraciones pendientes
                await context.Database.MigrateAsync();

                // Seed data opcional
                await SeedDataAsync(context);

                logger.LogInformation("Base de datos inicializada correctamente");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error al inicializar la base de datos");
                throw;
            }
        }

        private static async Task SeedDataAsync(ContextTareas context)
        {
            if (await context.Tareas.AnyAsync())
                return;

            await context.SaveChangesAsync();
        }
    }
}
