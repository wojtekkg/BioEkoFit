using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RawRabbit.Configuration;
using RawRabbit.vNext;

namespace bio_eko_fit_products
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRawRabbit(cfg => 
            {
                cfg.AddJsonFile("rabbitmq.json");
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}