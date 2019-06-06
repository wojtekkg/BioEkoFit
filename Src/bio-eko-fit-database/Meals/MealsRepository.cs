using System;
using System.Collections.Generic;
using System.Linq;
using bio_eko_fit_database.Entities;
using bio_eko_fit_dto.Exceptions;
using bio_eko_fit_dto.Meals;

namespace bio_eko_fit_database.Meals
{
    public class MealsRepository : IMealsRepository
    {

        IContextFactory _contextFactory;
        public MealsRepository(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public List<Meal> GetMeals(int? id)
        {
            using (var context = _contextFactory.CreateDefaultContext())
            {
                var query = context.Meals.AsEnumerable();
                if (id.HasValue)
                {   
                    query = query.Where(x => x.Id == id.Value);
                }
                return query.Select(x => new Meal(){ Id = x.Id, Name = x.Name }).ToList();
            }        
        }

        public void InsertMeal(Meal meal)
        {
            using (var context = _contextFactory.CreateDefaultContext())
            {
                context.Meals.Add(new MealEntity
                {
                    Name = meal.Name
                });
                context.SaveChanges();
            }        
        }

        public void UpdateMeal(Meal meal)
        {
            using (var context = _contextFactory.CreateDefaultContext())
            {
                var mealEntity = context.Meals.FirstOrDefault(x => x.Id == meal.Id);
                mealEntity.Name = meal.Name;
                context.SaveChanges();
            }
        }

        void IMealsRepository.DeleteMeal(int id)
        {
            using (var context = _contextFactory.CreateDefaultContext())
            {
                var meal = context.Meals.FirstOrDefault(x => x.Id == id);
                if (meal == null)
                {
                    throw new ObjectNotFoundException(nameof(meal));
                }
                var productsRelatedToMeal = context.ProductsForFood.Where(x => x.Meal == meal);
                var steps = context.Steps.Where(x => x.Meal == meal);
                
                context.ProductsForFood.RemoveRange(productsRelatedToMeal);
                context.Steps.RemoveRange(steps);
                context.Meals.Remove(meal);
                context.SaveChanges();
            }        
        }
    }
}