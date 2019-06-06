using System.Collections.Generic;
using bio_eko_fit_dto.Products;

namespace bio_eko_fit_database.Products
{
    public interface IProductsRepository
    {
        void UpdateProduct(Product product);
        void InsertProduct(Product product);
        void DeleteProduct(int id);
        List<Product> GetProducts(int? id);
    }
}