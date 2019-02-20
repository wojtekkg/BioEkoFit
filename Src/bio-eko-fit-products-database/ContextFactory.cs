using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace bio_eko_fit_products_database
{
    public class ContextFactory : IContextFactory
    {
        DbOptions _options;
        public ContextFactory(IOptionsMonitor<DbOptions> options)
        {
            _options = options.CurrentValue;
        }

        public ProductsContext CreateDefaultContext()
        {
            var options = new DbContextOptionsBuilder<ProductsContext>();
            options.UseNpgsql(_options.ConnectionString);
            return new ProductsContext(options.Options);
        }
    }
}