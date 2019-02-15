using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace bio_eko_fit_products.Extensions
{
    public static class IWebHostBuilderExtensions
    {
       public static IWebHostBuilder UseProductsService(this IWebHostBuilder builder)
       {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IProductsService, ProductsService>();
            });
            return builder;
       } 
    }
}