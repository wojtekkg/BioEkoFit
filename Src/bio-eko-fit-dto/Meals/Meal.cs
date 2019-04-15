using System.Collections.Generic;
using bio_eko_fit_dto.Products;

namespace bio_eko_fit_dto.Meals
{
    public class Meal
    {
        public int Id { get; set; }
    
        public string Name { get; set; }

        public List<Step> Steps { get; set; }

        public List<Product> Products { get; set; }
    }
}