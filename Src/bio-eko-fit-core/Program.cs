using System;
using System.IO;
using bio_eko_fit.Meals;
using bio_eko_fit.Menus;
using bio_eko_fit.Products;
using bio_eko_fit_products.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore;

namespace bio_eko_fit
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();

            var host = WebHost.CreateDefaultBuilder(args)
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseProductsService()
            .UseMealsService()
            .UseMenusService()
            .UseBioEkoFitDatabase("User ID=postgres;Password=1234Qwer;Host=localhost;Port=5432;Database=BioEkoFit")
            .UseStartup<Startup>()
            .UseUrls("http://localhost:5010/")
            .ConfigureAppConfiguration((hostingContext, config) => 
            {
                var env = hostingContext.HostingEnvironment;
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
            })
            .ConfigureLogging((hostingContext, logging) => 
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventSourceLogger();
            })
            .Build();

            host.Run();
        }
    }
}