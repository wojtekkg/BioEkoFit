using System;

namespace bio_eko_fit_dto
{
    [Serializable]
    public class Product
    {
        public string Name { get; set; }

        public Product(string name)
        {
            Name = name;
        }
    }
}
