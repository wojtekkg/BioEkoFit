using System;
using System.Threading.Tasks;
using bio_eko_fit_dto;
using RawRabbit;
using RawRabbit.Context;

namespace bio_eko_fit_meals
{
    public class MealsService : IMealsService
    {
        private readonly IBusClient _client;

        public MealsService(IBusClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
    }
}