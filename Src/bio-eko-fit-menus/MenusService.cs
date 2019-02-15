using System;
using System.Threading.Tasks;
using bio_eko_fit_dto;
using RawRabbit;
using RawRabbit.Context;

namespace bio_eko_fit_menus
{
    public class MenusService : IMenusService
    {
        private readonly IBusClient _client;

        public MenusService(IBusClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
    }
}