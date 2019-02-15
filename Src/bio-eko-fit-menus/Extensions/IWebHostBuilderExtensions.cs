using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace bio_eko_fit_menus.Extensions
{
    public static class IWebHostBuilderExtensions
    {
       public static IWebHostBuilder UseMenusService(this IWebHostBuilder builder)
       {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IMenusService, MenusService>();
            });
            return builder;
       } 
    }
}