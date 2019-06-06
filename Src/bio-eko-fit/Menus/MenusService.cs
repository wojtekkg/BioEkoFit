using System;
using System.Threading.Tasks;
using bio_eko_fit_database;
using bio_eko_fit_dto;
using Microsoft.Extensions.Logging;
using RawRabbit;
using RawRabbit.Context;

namespace bio_eko_fit.Menus
{
    public class MenusService : BaseService, IMenusService
    {

        public MenusService(IBusClient client, IContextFactory contextFactory, ILogger<MenusService> logger)
        : base(client, contextFactory, logger, nameof(MenusService))
        {
        }
    
        protected override void InitializeServices()
        {
            base.InitializeServices();
        }
    }
}