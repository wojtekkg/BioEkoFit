using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

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
            });
            return builder;
       }
    }
}