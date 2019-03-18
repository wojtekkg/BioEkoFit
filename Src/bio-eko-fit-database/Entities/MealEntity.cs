using System.ComponentModel.DataAnnotations;

namespace bio_eko_fit_database.Entities
{
    public class MealEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}