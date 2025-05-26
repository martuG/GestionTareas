using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data
{
    public class ContextTareasFactory : IDesignTimeDbContextFactory<ContextTareas>
    {
        public ContextTareas CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextTareas>();

            // Aquí defines la cadena de conexión (ajusta según tu base de datos)
            optionsBuilder.UseSqlServer("Data Source=MARTU\\SQLEXPRESS;Initial Catalog=TareasDB;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0");

            return new ContextTareas(optionsBuilder.Options);
        }
    }
}
