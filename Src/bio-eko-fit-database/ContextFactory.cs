using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace bio_eko_fit_database
{
    public class ContextFactory : IContextFactory
    {
        DbOptions _options;
        public ContextFactory(IOptionsMonitor<DbOptions> options)
        {
            _options = options.CurrentValue;
        }

        public BioEkoFitContext CreateDefaultContext()
        {
            var options = new DbContextOptionsBuilder<BioEkoFitContext>();
            options.UseNpgsql(_options.ConnectionString);
            return new BioEkoFitContext(options.Options);
        }
    }
}