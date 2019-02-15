using System;
using System.IO;
using bio_eko_fit_meals.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace bio_eko_fit_meals
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
            .UseMealsService()
            .UseStartup<Startup>()
            .UseUrls("http://localhost:5010/")
            .Build();

            //TODO: Find a way to run service without that, or with that but inside UseMealsService() method
            host.Services.GetService(typeof(IMealsService));
            Console.WriteLine("Meals service started");
            host.Run();
        }
    }
}
