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

namespace bio_eko_fit.Meals
{
    public class MealsService : BaseService, IMealsService
    {
        public MealsService(IBusClient client, IContextFactory contextFactory, ILogger<MealsService> logger)
        : base(client, contextFactory, logger, nameof(MealsService))
        {
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
            using (var context = _contextFactory.CreateDefaultContext())
            {
                var query = context.Meals.AsEnumerable();
                if (request.Id.HasValue)
                {   
                    query = query.Where(x => x.Id == request.Id.Value);
                }
                response.Data = query.Select(x => new Meal(){ Id = x.Id, Name = x.Name }).ToList();
            }
            return Task.FromResult(response);
        } 

        private Task<ResponseMessage> DeleteMeal(DeleteMealRequest request, MessageContext msgContext)
        {
            var response = new ResponseMessage();
            using (var context = _contextFactory.CreateDefaultContext())
            {
                var meal = context.Meals.FirstOrDefault(x => x.Id == request.Id);
                if (meal == null)
                {
                    return Task.FromResult(response.TransformToFault(HttpStatusCode.BadRequest));
                }
                var productsRelatedToMeal = context.ProductsForFood.Where(x => x.Meal == meal);
                var steps = context.Steps.Where(x => x.Meal == meal);
                
                context.ProductsForFood.RemoveRange(productsRelatedToMeal);
                context.Steps.RemoveRange(steps);
                context.Meals.Remove(meal);
                context.SaveChanges();
            }
            return Task.FromResult(response);
        }

        private Task<ResponseMessage> CreateMeal(CreateMealRequest request, MessageContext msgContext)
        {
            var response = new ResponseMessage();

            return Task.FromResult(response);
        }

        private Task<ResponseMessage> UpdateMeal(UpdateMealRequest request, MessageContext msgContext)
        {
            var response = new ResponseMessage();

            return Task.FromResult(response);
        }

    }
}