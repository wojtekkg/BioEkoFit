using bio_eko_fit.Meals;
using bio_eko_fit.Menus;
using bio_eko_fit.Products;
using bio_eko_fit_database.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace bio_eko_fit_products.Extensions
{
    public static class IWebHostBuilderExtensions
    {
        public static IWebHostBuilder UseBioEkoFitDatabase(this IWebHostBuilder builder, string connectionString)
        {
            builder.UseDatabase(connectionString);
            return builder;
        }

        public static IWebHostBuilder UseProductsService(this IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IProductsService, ProductsService>();
            });
            return builder;
        } 

        public static IWebHostBuilder UseMealsService(this IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IMealsService, MealsService>();
            });
            return builder;
        } 

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