
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace _3_Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Crea un DbContextOptionsBuilder para configurar el DbContext
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Configura el DbContext para usar MySQL con tu cadena de conexión
            optionsBuilder.UseMySQL("connection string");

            // Retorna una nueva instancia de AppDbContext con las opciones configuradas
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
