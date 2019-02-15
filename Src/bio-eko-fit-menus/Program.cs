using System;
using System.IO;
using bio_eko_fit_menus.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace bio_eko_fit_menus
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
            .UseMenusService()
            .UseStartup<Startup>()
            .UseUrls("http://localhost:5012/")
            .Build();

            //TODO: Find a way to run service without that, or with that but inside UseMenusService() method
            host.Services.GetService(typeof(IMenusService));
            Console.WriteLine("Menus service started");
            host.Run();
        }
    }
}
