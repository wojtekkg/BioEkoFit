using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using bio_eko_fit_database.Products;
using bio_eko_fit_database.Meals;
using bio_eko_fit_database.Menus;

namespace bio_eko_fit_database.Extensions
{
    public static class IWebHostBuilderExtensions
    {
       public static IWebHostBuilder UseDatabase(this IWebHostBuilder builder, string connectionString)
       {
            builder.ConfigureServices(services =>
            {
                services.Configure<DbOptions>(options => options.ConnectionString = connectionString);
                services.AddOptions();
                services.AddTransient<IContextFactory, ContextFactory>();
                services.AddTransient<IProductsRepository, ProductsRepository>();
                services.AddTransient<IMealsRepository, MealsRepository>();
                services.AddTransient<IMenusRepository, MenusRepository>();
            });
            return builder;
       }
    }
}