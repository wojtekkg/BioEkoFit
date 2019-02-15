using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace bio_eko_fit_meals.Extensions
{
    public static class IWebHostBuilderExtensions
    {
       public static IWebHostBuilder UseMealsService(this IWebHostBuilder builder)
       {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IMealsService, MealsService>();
            });
            return builder;
       } 
    }
}