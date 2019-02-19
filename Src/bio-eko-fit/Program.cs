using System;
using System.IO;
using bio_eko_fit_meals.Extensions;
using bio_eko_fit_products.Extensions;
using bio_eko_fit_menus.Extensions;
using bio_eko_fit_meals;
using bio_eko_fit_products;
using bio_eko_fit_menus;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using bio_eko_fit_database.Extensions;

namespace bio_eko_fit
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();

            var host = new WebHostBuilder()
            .UseDatabase()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseMealsService()
            .UseProductsService()
            .UseMenusService()
            .UseStartup<Startup>()
            .UseUrls("http://localhost:5020/")
            .Build();

            host.Services.GetService(typeof(IMealsService));
            host.Services.GetService(typeof(IProductsService));
            host.Services.GetService(typeof(IMenusService));

            Console.WriteLine("Server started");
            host.Run();
        }
    }
}