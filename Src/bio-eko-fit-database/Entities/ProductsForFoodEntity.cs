using System.ComponentModel.DataAnnotations;

namespace bio_eko_fit_database.Entities
{
    public class ProductsForFoodEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public MealEntity Meal { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Weight { get; set; }
    }
}