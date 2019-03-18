using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bio_eko_fit_database;
using bio_eko_fit_database.Entities;
using bio_eko_fit_dto;
using bio_eko_fit_dto.Meals;
using RawRabbit;
using RawRabbit.Context;

namespace bio_eko_fit.Meals
{
    public class MealsService : IMealsService
    {
        private readonly IBusClient _client;
        private readonly IContextFactory _contextFactory;

        public MealsService(IBusClient client, IContextFactory contextFactory)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            ServiceInitialization();
        }

        private void ServiceInitialization()
        {
            _client.RespondAsync<GetMealsRequest, GetMealsResponse>(GetMeals);
            _client.RespondAsync<DeleteMealRequest, bool>(DeleteMeal);
            _client.RespondAsync<CreateMealRequest, bool>(CreateMeal);
            _client.RespondAsync<UpdateMealRequest, bool>(UpdateMeal);
            Console.WriteLine($"{nameof(MealsService)} initialized.");
        }

        private Task<GetMealsResponse> GetMeals(GetMealsRequest request, MessageContext msgContext)
        {
            var response = new GetMealsResponse();
            try
            {
                using (var context = _contextFactory.CreateDefaultContext())
                {
                    var query = context.Meals.AsEnumerable();
                    if (request.Id.HasValue)
                    {   
                        query = query.Where(x => x.Id == request.Id.Value);
                    }
                    response.Meals = query.Select(x => new Meal(){ Id = x.Id, Name = x.Name }).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.FromResult(response);
        } 

        private Task<bool> DeleteMeal(DeleteMealRequest request, MessageContext msgContext)
        {
            try
            {
                using (var context = _contextFactory.CreateDefaultContext())
                {
                    var meal = context.Meals.FirstOrDefault(x => x.Id == request.Id);
                    if (meal == null)
                    {
                        return Task.FromResult(false);
                    }
                    var mealRelatedToProducts = context.ProductsForFood.Where(x => x.Meal == meal);
                    var steps = context.Steps.Where(x => x.Meal == meal);
                    
                    context.ProductsForFood.RemoveRange();
                    context.Steps.RemoveRange(steps);
                    context.Meals.Remove(meal);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.FromResult(false);
        }

        private Task<bool> CreateMeal(CreateMealRequest request, MessageContext msgContext)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.FromResult(false);
        }

        private Task<bool> UpdateMeal(UpdateMealRequest request, MessageContext msgContext)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.FromResult(false);
        }

    }
}