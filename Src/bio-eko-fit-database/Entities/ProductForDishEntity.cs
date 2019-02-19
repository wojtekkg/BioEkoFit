using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace bio_eko_fit_database.Entities
{
    class ProductForDishEntity
    {
        public int Id { get; set; }
        [Required]
        public DishEntity Dish { get; set; }
        [Required]
        public ProductEntity Product { get; set; }
        [Required]
        public string ProductWeight { get; set; }
    }
}
