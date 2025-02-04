using CodigoFacilito.JwtSerilog.Models;

namespace CodigoFacilito.JwtSerilog.Data
{
    public static class DBContext
    {
        public static List<Country> Countries { get; set; }
        public static List<Product> Products { get; set; }
        public static List<Employee> Employees { get; set; }
        public static List<User> Users { get; set; }

        static DBContext()
        {

            Countries =
            [
                new Country() { Name = "Argentina" },
                new Country() { Name = "Peru" },
                new Country() { Name = "Mexico" },
            ];

            Products =
            [
                new Product() { Name = "Coca Cola", Description = "Bebida con gas" },
                new Product() { Name = "Agua Villavicencio", Description = "Agua mineral de 2L" },
            ];

            Employees =
            [
                new Employee() { FirstName = "Tomas", LastName = "Aliaga", Email = "taliaga@gmail.com" },
                new Employee() { FirstName = "Marcos", LastName = "Gonzalez", Email = "mgonzalez@gmail.com" },
            ];

            Users =
            [
                new User() { Username = "jperez", Password = "admin123", Rol = "Administrador", EmailAddress = "jperez@gmail.com", FirstName = "Juan", LastName = "Perez" },
                new User() { Username = "mgonzalez", Password = "admin123", Rol = "Vendedor", EmailAddress = "mgonzalez@gmail.com", FirstName = "Maria", LastName = "Gonzalez" },
            ];
        }
    }
}
