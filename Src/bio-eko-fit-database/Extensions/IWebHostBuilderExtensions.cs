using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace bio_eko_fit_database.Extensions
{
    public static class IWebHostBuilderExtensions
    {
       public static IWebHostBuilder UseDatabase(this IWebHostBuilder builder)
       {
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<BioEkoFitContext>(options => options.UseNpgsql("User ID=postgres;Password=1234Qwer;Host=localhost;Port=5432;Database=BioEkoFit"));
            });
            return builder;
       }
    }
}