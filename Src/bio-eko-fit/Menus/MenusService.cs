using System;
using System.Threading.Tasks;
using bio_eko_fit_database;
using bio_eko_fit_dto;
using Microsoft.Extensions.Logging;

namespace bio_eko_fit.Menus
{
    public class MenusService : BaseService, IMenusService
    {

        public MenusService(ILogger<MenusService> logger)
        : base(logger, nameof(MenusService))
        {
        }
    
        protected override void InitializeServices()
        {
            base.InitializeServices();
        }
    }
}