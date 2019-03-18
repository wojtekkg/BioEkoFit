using System.ComponentModel.DataAnnotations;

namespace bio_eko_fit_database.Entities
{
    public class StepEntity
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public MealEntity Meal { get; set; }

        [Required]
        public string Description { get; set; }
    }
}