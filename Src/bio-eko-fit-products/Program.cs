using System;
using System.IO;
using bio_eko_fit_products.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace bio_eko_fit_products
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();

            var host = new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseProductsService("User ID=postgres;Password=1234Qwer;Host=localhost;Port=5432;Database=Products")
            .UseStartup<Startup>()
            .UseUrls("http://localhost:5010/")
            .Build();

            //TODO: Find a way to run service without that, or with that but inside UseProductsService() method
            host.Services.GetService(typeof(IProductsService));
            Console.WriteLine("Products service started");
            host.Run();
        }
    }
}
