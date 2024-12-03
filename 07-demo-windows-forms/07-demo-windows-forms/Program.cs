using _1_Entities;
using _2_Services;
using _2_Services.DTOs;
using _2_Services.Mappers;
using _3_Data;
using _3_Repositories;
using _3_Repositories.AdditionalDataClass;
using _3_Repositories.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _07_demo_windows_forms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new FormMain());

            var mainForm = serviceProvider.GetRequiredService<FormMain>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services) 
        {
            //CONFIGURACIÓN.
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(@"C:\Users\Miguel\Desktop\practicas-csharp\07-demo-windows-forms\07-demo-windows-forms\appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // INYECCION DE DEPENDENCIAS.
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("DB")));

            services.AddTransient<IRepository<Brand>, BrandRepository>();
            services.AddTransient<IRepositoryAdditionalData<Beer, BeerAdditionalData>, BeerRepository>();
            services.AddTransient<AddBrand>();
            services.AddTransient<EditBrand>();
            services.AddTransient<AddBeer<BeerAdditionalData>>();
            services.AddTransient<EditBeer<BeerAdditionalData>>();
            services.AddTransient<IMapper<BeerDTO, Beer>, MapperToBeerEntity>();
            services.AddTransient<IMapper<BeerDTO, BeerAdditionalData>, MapperToBeerAdditionalData>();

            // INYECCIÓN DE FORMULARIOS.
            services.AddTransient<FormMain>();
            services.AddTransient<FormBrand>();
            services.AddTransient<FormNewEditBrand>();
            services.AddTransient<FormBeer>();
            services.AddTransient<FormNewEditBeer>();
        }
    }
}