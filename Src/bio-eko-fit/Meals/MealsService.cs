using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bio_eko_fit_database;
using bio_eko_fit_database.Entities;
using bio_eko_fit_dto;
using bio_eko_fit_dto.Common;
using bio_eko_fit_dto.Meals;
using Microsoft.Extensions.Logging;
using bio_eko_fit_dto.Extensions;
using RawRabbit;
using RawRabbit.Context;
using System.Net;
using bio_eko_fit_database.Meals;

namespace bio_eko_fit.Meals
{
    public class MealsService : BaseService, IMealsService
    {
        private readonly IMealsRepository _mealsRepository;
        public MealsService(IBusClient client, ILogger<MealsService> logger,
        IMealsRepository mealsRepository)
        : base(client, logger, nameof(MealsService))
        {
            _mealsRepository = mealsRepository ?? throw new ArgumentNullException(nameof(mealsRepository));
        }

        protected override void InitializeServices()
        {
            _client.RespondAsync<GetMealsRequest, ResponseMessage>((req, msgContext) => HandleRequest(() => GetMeals(req, msgContext)));
            _client.RespondAsync<DeleteMealRequest, ResponseMessage>((req, msgContext) => HandleRequest(() => DeleteMeal(req, msgContext)));
            _client.RespondAsync<CreateMealRequest, ResponseMessage>((req, msgContext) => HandleRequest(() => CreateMeal(req, msgContext)));
            _client.RespondAsync<UpdateMealRequest, ResponseMessage>((req, msgContext) => HandleRequest(() => UpdateMeal(req, msgContext)));
            base.InitializeServices();
        }

        private Task<ResponseMessage> GetMeals(GetMealsRequest request, MessageContext msgContext)
        {
            var response = new ResponseMessage();
            var meals = _mealsRepository.GetMeals(request.Id);
            if (request.Id.HasValue && meals.Count == 0)
            {
                return Fault(HttpStatusCode.NotFound);
            }
            response.Data = meals;
            return Task.FromResult(response);
        } 

        private Task<ResponseMessage> DeleteMeal(DeleteMealRequest request, MessageContext msgContext)
        {
            _mealsRepository.DeleteMeal(request.Id);
            return Ok();
        }

        private Task<ResponseMessage> CreateMeal(CreateMealRequest request, MessageContext msgContext)
        {
            if (string.IsNullOrEmpty(request.Meal.Name))
            {
                return Fault(HttpStatusCode.BadRequest, FaultCode.NULL_OR_EMPTY, new string[] {nameof(request.Meal.Name)});
            }
            _mealsRepository.InsertMeal(request.Meal);
            return Ok();
        }

        private Task<ResponseMessage> UpdateMeal(UpdateMealRequest request, MessageContext msgContext)
        {
            if (request.Meal == null)
            {
                return Fault(HttpStatusCode.BadRequest);
            }
            if (string.IsNullOrEmpty(request.Meal.Name))
            {
                return Fault(HttpStatusCode.BadRequest, FaultCode.NULL_OR_EMPTY, new string[] {nameof(request.Meal.Name)});
            }
            _mealsRepository.UpdateMeal(request.Meal);
            return Ok();
        }

    }
}