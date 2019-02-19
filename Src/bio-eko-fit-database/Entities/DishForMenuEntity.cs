using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace bio_eko_fit_database.Entities
{
    class DishForMenuEntity
    {
        public int Id { get; set; }
        [Required]
        public MenuEntity Menu { get; set; }
        [Required]
        public DishEntity Dish { get; set; }
    }
}
