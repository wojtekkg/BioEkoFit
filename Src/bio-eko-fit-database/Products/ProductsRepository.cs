using System;
using System.Collections.Generic;
using bio_eko_fit_database.Entities;
using bio_eko_fit_dto.Products;
using System.Data;
using System.Linq;
using bio_eko_fit_dto.Exceptions;

namespace bio_eko_fit_database.Products
{
    public class ProductsRepository : IProductsRepository
    {
        IContextFactory _contextFactory;
        public ProductsRepository(IContextFactory contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public void InsertProduct(Product product)
        {
            using (var context = _contextFactory.CreateDefaultContext())
            {
                context.Products.Add(new ProductEntity 
                { 
                    Name = product.Name 
                });
                context.SaveChanges();
            }        
        }

        public void DeleteProduct(int id)
        {
            using (var context = _contextFactory.CreateDefaultContext())
            {
                context.Products.Remove(new ProductEntity { Id = id });
                context.SaveChanges();
            }        
        }

        public void UpdateProduct(Product product)
        {
            using (var context = _contextFactory.CreateDefaultContext())
            {
                var productEntity = context.Products.FirstOrDefault(x => x.Id == product.Id);
                if (productEntity == null)
                {
                    throw new ObjectNotFoundException(nameof(productEntity));
                }
                productEntity.Name = product.Name;
                context.SaveChanges();
            }    
        }

        public List<Product> GetProducts(int? id)
        {
            using (var context = _contextFactory.CreateDefaultContext())
            {
                var query = context.Products.AsEnumerable();
                if (id.HasValue)
                {   
                    query = query.Where(x => x.Id == id.Value);
                }
                var products = query.Select(x => new Product(){ Id = x.Id, Name = x.Name }).ToList();
                return products;
            }        
        }
    }
}