using System.Collections.Generic;
using bio_eko_fit_dto.Meals;

namespace bio_eko_fit_database.Meals
{
    public interface IMealsRepository
    {
        List<Meal> GetMeals(int? id);
        void InsertMeal(Meal meal);
        void UpdateMeal(Meal meal);
        void DeleteMeal(int id);
    }
}